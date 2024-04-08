using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LSExtensionWindowLib;
using Microsoft.Office.Interop.Outlook;
using Oracle.DataAccess.Client;
using LSSERVICEPROVIDERLib;
using Patholab_Common;
using Patholab_DAL_V1;
using System.Diagnostics;
using System.IO;
using Exception = System.Exception;

namespace Payments
{

    [ComVisible(true)]
    [ProgId("Payments.Paymentscls")]
    public partial class Payments : UserControl, IExtensionWindow
    {
        #region Ctor
        public Payments()
        {
            InitializeComponent();
            this.BackColor = Color.FromName("Control");

        }
        #endregion


        #region private members

        private string mboxTitle = "ניהול חיובים";
        private IExtensionWindowSite2 _ntlsSite;
        private INautilusDBConnection _ntlsCon;
        private INautilusProcessXML _processXml;
        private INautilusServiceProvider SP;
        private bool ActivateMakeList = false;
        DataLayer DAL = new DataLayer();
        public bool DEBUG;
        #endregion

        #region Implementation of IExtensionWindow

        public bool CloseQuery()
        {
            if (DAL != null) DAL.Close();
            this.Dispose();
            return true;
        }

        public void Internationalise() { }

        public void SetSite(object site)
        {
            _ntlsSite = (IExtensionWindowSite2)site;
            _ntlsSite.SetWindowInternalName("Payments");
            _ntlsSite.SetWindowRegistryName("Payments");
            _ntlsSite.SetWindowTitle("Payments");



        }

        public void PreDisplay()
        {

            _processXml = Utils.GetXmlProcessor(SP);

        }

        public WindowButtonsType GetButtons()
        {
            return LSExtensionWindowLib.WindowButtonsType.windowButtonsNone;
        }

        public bool SaveData()
        {
            return false;
        }

        public void SetServiceProvider(object serviceProvider)
        {



            SP = serviceProvider as NautilusServiceProvider;
            _ntlsCon = Utils.GetNtlsCon(SP);
            string role = Utils.GetNautilusUser(SP).GetRoleName();

            DEBUG = (role.ToUpper() == "DEBUG");
        }

        public void SetParameters(string parameters)
        {
            //parameters of the command
        }

        public void Setup()
        {

            if (!DEBUG)
            {
                DAL.Connect(_ntlsCon);

            }
            else
            {
                // DAL.MockConnect();

                DAL.Connect(_ntlsCon);
                Debugger.Launch();
            }
            rdbAll.Checked = true;//.SetItemChecked(2, true);

            ;
            //  _customerGroups = DAL.FindBy<U_CUSTOMER_USER>(user => user.U_CUSTOMER_TYPE == "G").ToList();
            ActivateMakeList = true;
            MakeList();
        }

        public WindowRefreshType DataChange()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public WindowRefreshType ViewRefresh()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public void refresh() { }

        public void SaveSettings(int hKey) { }

        public void RestoreSettings(int hKey) { }




        #endregion

        private void Payments_Load(object sender, EventArgs e)
        {
            int tmpMonth;
            int tmpYear;

            //Prepare defaults for comboboxes

            tmpMonth = DateTime.Today.Month - 1;
            tmpYear = DateTime.Today.Year;
            if (tmpMonth == 0)
            {
                tmpMonth = 12;
                tmpYear -= 1;// tmpYear;
            }


            chkboxGroupOnly.Checked = false;
            //Prepare the months in cmbMonth


            List<String> Months = new List<String>(new String[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });

            cmbMonth.DataSource = Months;
            List<String> Years = new List<string>();

            //Prepare the last 10 years in cmbYear

            for (int I = tmpYear - 10; I <= tmpYear; I++)
            {
                Years.Add(I.ToString());
            }
            var t = (DateTime.Now.Year);
            if (!Years.Contains(t.ToString()))
            {
                Years.Add(t.ToString());
            }
            cmbYear.DataSource = Years;

            //set defaults in comboboxes

            cmbMonth.Text = tmpMonth.ToString("D2");
            cmbYear.Text = tmpYear.ToString("D4");

        }

        #region Files מאוחדת כללית לאומית

        private void btnCreateFile_Click(object sender, EventArgs e)
        {

            try
            {

                Wrapper wrapper = lstCustomers.SelectedItem as Wrapper;
                var ast = wrapper.AsciiType;

                var list = dataGridView1.DataSource as List<PaymentsToGrid>;
                string path2Send;
                if (ast == "20")
                {
                    path2Send = CreateClalitFile(list);
                }
                else if (ast == "50")
                {
                    path2Send = CreateMeuchedetFile(list);
                }

                else if (ast == "60")
                {
                    path2Send = CreateLeumitFile(list);
                }
                else
                {
                    path2Send = string.Empty;
                    MessageBox.Show("אין אפשרות ליצור קובץ עבור לקוח זה.", mboxTitle);
                    return;
                }

                if (path2Send == null)
                {
                    MessageBox.Show("Error on generate ascci file.", mboxTitle);
                    return;
                }
                if (list != null)
                {
                    var ids = list.Select(x => x.PaymentID).ToList();

                    var debits4Update = DAL.FindBy<U_DEBIT_USER>(p => ids.Contains(p.U_DEBIT_ID));

                    foreach (var d in debits4Update)
                    {
                        d.U_DEBIT_STATUS = "C";

                    }
                    DAL.SaveChanges();
                }
                MessageBox.Show("הקובץ נוצר בהצלחה", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bool galit = true;
                if (galit)

                    OpenOutlook(path2Send);
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                MessageBox.Show("שגיאה ביצירת קובץ , אנא פנה לתמיכה.", mboxTitle);

            }

        }

        private string CreateMeuchedetFile(List<PaymentsToGrid> list)
        {
            var typ = panel2.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Tag.ToString();
            PHRASE_HEADER Par = DAL.GetPhraseByName("System Parameters");
            var Dir = Par.PhraseEntriesDictonary["Meuhedet Files Directory"];
            if (((Wrapper)lstCustomers.SelectedItem).DisplayText == "מאוחדת מוקלד") typ = "M";
            string path = Dir + "EP" + typ + "B" + cmbYear.Text.Right(2) + cmbMonth.Text + ".txt";
            using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var streamWriter = new StreamWriter(file, Encoding.GetEncoding(862));
                StringBuilder MyStringBuilder = new StringBuilder();
                int i = 0;
                string commit;
                foreach (PaymentsToGrid p in list)
                {
                    try
                    {

                        i++;
                        MyStringBuilder.Append(' ', 384);
                        MyStringBuilder.Insert(0, "41704118");
                        MyStringBuilder.Insert(9, i.ToString().PadLeft(5, '0'));

                        MyStringBuilder.Insert(15, p.InvcNbr.Trim().Right(5).PadLeft(5, '0'));
                        MyStringBuilder.Insert(21, cmbYear.Text);
                        MyStringBuilder.Insert(26, cmbMonth.Text);
                        MyStringBuilder.Insert(29, (p.SDG_ID.ToString().PadLeft(11, '0')));
                        MyStringBuilder.Insert(41, (p.TZ_PASS + p.ClientID).PadLeft(9, '0'));
                        //if is passport then 1 else 2 + client.name לשרשר אפשסים לדרכון:
                        MyStringBuilder.Insert(52, p.FirstName ?? string.Empty);
                        MyStringBuilder.Insert(68, p.LastName ?? string.Empty);
                        commit = string.IsNullOrEmpty(p.CommitmentNumber.Left(9)) ? "999999999" : p.CommitmentNumber;
                        MyStringBuilder.Insert(84, commit.PadLeft(8, '0'));
                        MyStringBuilder.Insert(94,
                                               !string.IsNullOrEmpty(p.DateTaken)
                                                   ? p.DateTaken.Right(4) + p.DateTaken.Substring(2, 2) + p.DateTaken.Left(2)
                                                   : p.SDG_CREATED_ON.Right(4) + p.SDG_CREATED_ON.Substring(2, 2) + p.SDG_CREATED_ON.Left(2));
                        MyStringBuilder.Insert(103, double.Parse(p.Quantity).ToString().PadLeft(2, '0'));
                        MyStringBuilder.Insert(106, p.MeuchedetCode ?? string.Empty);

                        double qu, pr;
                        int loc = 0;
                        string amntNoVat = "";
                        if (double.TryParse(p.Quantity, out qu) && double.TryParse(p.PriceNoVAT, out pr))
                        {
                            var amntNoVatDBL = (double.Parse(p.Quantity) * double.Parse(p.PriceNoVAT));
                            amntNoVat = String.Format("{0:0.00}", amntNoVatDBL);// (double.Parse(p.Quantity) * double.Parse(p.PriceNoVAT)).ToString();

                            loc = amntNoVat.Length;
                        }

                        //MyStringBuilder.Insert(126 - loc, Math.Round(double.Parse(amntNoVat), 2));

                        MyStringBuilder.Insert(127 - loc, amntNoVat);
                        // כולל 2 מקומות אחרי נק,
                        streamWriter.WriteLine(MyStringBuilder.ToString().TrimEnd(' '));
                        MyStringBuilder.Clear();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error on CreateMeuchedetFile", mboxTitle, MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        Logger.WriteLogFile(ex);
                        return null;

                    }
                }


                streamWriter.Close();
            }
            return path;
        }

        private string CreateLeumitFile(List<PaymentsToGrid> list)
        {

            int i = 0;

            try
            {

                PHRASE_HEADER Par = DAL.GetPhraseByName("System Parameters");


                var Dir = Par.PhraseEntriesDictonary["Leumit Files Directory"];
                //
                string path = Dir + "KMACHON" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var streamWriter = new StreamWriter(file, Encoding.GetEncoding(862));
                    StringBuilder myStringBuilder = new StringBuilder();



                    foreach (PaymentsToGrid p in list)
                    {
                        i++;
                        if (i == 1505)
                        {
                            i = i;
                        }
                        myStringBuilder.Append(' ', 150);
                        myStringBuilder.Insert(0, "PTO-LAB");
                        myStringBuilder.Insert(13, p.InvcNbr.PadLeft(10, '0'));// "0000000011");
                        myStringBuilder.Insert(24, cmbMonth.Text);
                        myStringBuilder.Insert(26, cmbYear.Text);
                        string ClientID = (p.IsPassport ? "9" : "1") + p.ClientID.PadLeft(9, '0').Right(9).PadLeft(9, '0');//add 9 to a forighner or 1 for a citizen
                        myStringBuilder.Insert(31, ClientID);
                        // Galina 01/05/2023 להגביל אורך של השמות
                        //myStringBuilder.Insert(42, p.FirstName.PadLeft(14, ' '));
                        //myStringBuilder.Insert(56, p.LastName.PadLeft(8, ' ')); 
                        myStringBuilder.Insert(42, p.FirstName.Trim().Substring(0, p.FirstName.Trim().Length > 14 ? 14 : p.FirstName.Trim().Length).PadLeft(14, ' '));
                        myStringBuilder.Insert(56, p.LastName.Trim().Substring(0, p.LastName.Trim().Length > 8 ? 8 : p.LastName.Trim().Length).PadLeft(8, ' '));
                        //
                        string commit = string.IsNullOrEmpty(p.CommitmentNumber.Left(8)) ? string.Empty : p.CommitmentNumber;
                        myStringBuilder.Insert(66, commit.PadLeft(8, '0'));
                        myStringBuilder.Insert(75, string.Format(p.DateTakenCustom, "ddMMyyyy"));
                        myStringBuilder.Insert(84, p.LeumitPartName);
                        myStringBuilder.Insert(95, (decimal.Parse(p.Quantity)).ToString("#").PadLeft(2, '0'));

                        myStringBuilder.Insert(98, (decimal.Parse(p.PriceNoVAT) * 100).ToString("#").Replace(" ", "").PadLeft(7, '0'));
                        myStringBuilder.Insert(106,
                                               (decimal.Parse(p.PriceNoVAT) * 100 * (decimal.Parse(p.Quantity))).ToString("#").Replace(" ", "")
                                                                                                        .PadLeft(7, '0'));
                        streamWriter.WriteLine(myStringBuilder.ToString());
                        myStringBuilder.Clear();
                    }


                    streamWriter.Close();
                }
                return path;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on CreateLeumitFile(" + i.ToString() + ")", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
                return null;
            }
        }

        private string CreateClalitFile(IEnumerable<PaymentsToGrid> list)
        {
            try
            {

                if (list == null || list.Count() < 1)
                {
                    return null;
                }



                string district = list.First().District.TrimStart('0').PadLeft(2, '0');
                string clinicCode = list.First().ClinicCode;
                PHRASE_HEADER Par = DAL.GetPhraseByName("System Parameters");


                var Dir = Par.PhraseEntriesDictonary["Clalit Files Directory"];
                string path = Path.Combine(Dir, string.Format("{0}{1}.{2}.txt,", "7203", cmbMonth.Text + cmbYear.Text.Substring(2, 2), district));
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var streamWriter = new StreamWriter(file, Encoding.GetEncoding(862));
                    StringBuilder myStringBuilder = new StringBuilder();

                    int i;
                    string commit;
                    foreach (PaymentsToGrid p in list)
                    {
                        myStringBuilder.Append(' ', 150);
                        myStringBuilder.Insert(0, "000512273699");
                        myStringBuilder.Insert(13, "פתו-לאב דיאגנוסטיקה".MyReverse());
                        myStringBuilder.Insert(44, "072");
                        myStringBuilder.Insert(48, "007203");

                        myStringBuilder.Insert(55, cmbMonth.Text);
                        myStringBuilder.Insert(57, cmbYear.Text);
                        myStringBuilder.Insert(62, p.ClientID.PadLeft(11, '0'));
                        myStringBuilder.Insert(74, p.LastName.MyReverse());
                        myStringBuilder.Insert(94, p.FirstName.MyReverse());
                        myStringBuilder.Insert(110, p.District);
                        if (p.ClinicCode != null)
                            myStringBuilder.Insert(117, p.ClinicCode.PadLeft(6, '0'));
                        else
                        {
                            myStringBuilder.Insert(117, "000000");

                        }
                        myStringBuilder.Insert(124, p.PHYSICIAN_LICENSE.PadLeft(6, '0'));
                        myStringBuilder.Insert(131, p.PHYSICIAN.Left(14).MyReverse());
                        myStringBuilder.Insert(147, "         "); //PHYSICIAN firstname
                        myStringBuilder.Insert(157, "0000000000");
                        myStringBuilder.Insert(168, p.District);
                        myStringBuilder.Insert(175, "000000");
                        myStringBuilder.Insert(213, "02");
                        myStringBuilder.Insert(216, (p.EventDate ?? "").Replace("/", ""));
                        myStringBuilder.Insert(225, (p.EventDate ?? "").Replace("/", ""));

                        string clalitCode = p.ClalitCode;
                        if (p.SpecialStain != null &&   p.SpecialStain.Contains("דחוף")) 
                        {
                            try
                            {
                                int clalitCodeInt;
                                int.TryParse(clalitCode, out clalitCodeInt);
                                clalitCodeInt += 100;
                                clalitCode = clalitCodeInt.ToString();
                            }
                            catch (Exception)
                            {

                                clalitCode = "error";
                            }

                        }
                        myStringBuilder.Insert(234, clalitCode);


                        myStringBuilder.Insert(245, p.ClalitDescription);
                        myStringBuilder.Insert(271, "00000");

                        //string quantity = p.Quantity;
                        //quantity = quantity.Replace(".00", "");
                        //quantity.TrimStart('0');
                        //if (quantity.Length==1)quantity = "0" + quantity;

                        myStringBuilder.Insert(277, p.Quantity.Trim().PadLeft(4, '0') + ".00");

                        myStringBuilder.Insert(285, p.PriceNoVAT.Trim()); //287 like in example file,not like 286-1 in doc instruction

                        myStringBuilder.Insert(298, p.AMOUNT_NO_VAT.Trim());
                        myStringBuilder.Insert(312, p.AmountVAT.Trim());
                        myStringBuilder.Insert(326, "000");
                        myStringBuilder.Insert(330, "00");
                        myStringBuilder.Insert(333, p.InvcNbr.Trim().PadLeft(11, '0'));
                        myStringBuilder.Insert(345, (p.InvcDate ?? "").Trim().Replace("/", ""));
                        myStringBuilder.Append(' ', 30);
                        streamWriter.WriteLine(myStringBuilder.ToString());
                        myStringBuilder.Clear();
                    }


                    streamWriter.Close();
                }
                return path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on CreateClalitFile", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
                return null;
            }
        }

        #endregion



        private void MakeList()
        {
            IQueryable<Wrapper> CustList;
            IQueryable<Wrapper> GroupList;



            Debugger.Launch();
            if (!ActivateMakeList) return;

            lstCustomers.Items.Clear();
            dataGridView1.DataSource = null;

            if (chkboxInvoice.Checked)
            {
                GroupList = from p in DAL.GetAll<PAYMENT>()
                            where p.YEAR_MONTH.Substring(0, 4) == cmbYear.Text &
                          p.MONTH.Substring(0, 2) == cmbMonth.Text
                       & p.CUSTOMER_GROUP != null
                       & p.INVC_NBR != " "
                            orderby p.CUSTOMER_NAME
                            select new Wrapper { DisplayText = p.GROUP_NAME, cg = p.CUSTOMER_GROUP, AsciiType = p.ASCII_TYPE };

                CustList = from p in DAL.GetAll<PAYMENT>()
                           where p.YEAR_MONTH.Substring(0, 4) == cmbYear.Text &
                            p.MONTH.Substring(0, 2) == cmbMonth.Text
                             & p.CUSTOMER_GROUP == null
                       & p.INVC_NBR != " "
                           orderby p.CUSTOMER_NAME
                           select new Wrapper { DisplayText = p.CUSTOMER_NAME, AsciiType = p.ASCII_TYPE };

            }
            else
            {
                GroupList = from p in DAL.GetAll<PAYMENT>()
                            where p.YEAR_MONTH.Substring(0, 4) == cmbYear.Text &
                             p.MONTH.Substring(0, 2) == cmbMonth.Text &
                             p.INVC_NBR == " "
                              & p.CUSTOMER_GROUP != null
                            orderby p.CUSTOMER_NAME
                            select new Wrapper { DisplayText = p.GROUP_NAME, cg = p.CUSTOMER_GROUP, AsciiType = p.ASCII_TYPE };

                CustList = from p in DAL.GetAll<PAYMENT>()
                           where p.YEAR_MONTH.Substring(0, 4) == cmbYear.Text &
                            p.MONTH.Substring(0, 2) == cmbMonth.Text &
                              p.CUSTOMER_GROUP == null
                              & p.INVC_NBR == " "
                           orderby p.CUSTOMER_NAME
                           select new Wrapper { DisplayText = p.CUSTOMER_NAME, AsciiType = p.ASCII_TYPE };
            }


            if (chkboxGroupOnly.Checked)
            {
                var gl = GroupList.Distinct().ToList().OrderBy(p => p.DisplayText);

                foreach (Wrapper group in gl)
                {
                    if (!string.IsNullOrEmpty(group.DisplayText))
                        lstCustomers.Items.Add(group);
                }

            }
            else
            {
                CustList = CustList.Distinct().OrderBy(p => p.DisplayText);
                foreach (Wrapper cust in CustList)
                    lstCustomers.Items.Add(cust);
            }


        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeList();
        }
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeList();
        }
        private void chkboxGroupOnly_CheckedChanged(object sender, EventArgs e)
        {
            MakeList();
        }
        private void chkboxInvoice_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Enabled = !chkboxInvoice.Checked;
            MakeList();
        }
        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildQuery(!chkboxInvoice.Checked);
        }

        #region private methods

        KeyValuePair<string, bool> GetSdgType()
        {
            bool isEqualOpearator = false;
            string fl = "P";

            if (rdbAll.Checked)
            { }
            else if (rdbCyt.Checked)
            {
                isEqualOpearator = true;
                fl = "C";
            }

            else if (rdbHis.Checked)
            {
                isEqualOpearator = true;
                fl = "B";
            }
            else if (rbPap.Checked)
            {
                isEqualOpearator = true;
                fl = "P";
            }
            else if (rbSpecial.Checked)
            {
                isEqualOpearator = true;
                fl = "S";
            }
            return new KeyValuePair<string, bool>(fl, isEqualOpearator);
        }


        #endregion




        List<PaymentsToGrid> PaymentList1Temp;
        private void BuildQuery(bool withInvoice)
        {
            dataGridView1.DataSource = null;
            // dataGridView1.Rows.Clear();

            if (chkboxGroupOnly.Checked)
            {
                PaymentList1Temp = (from p in DAL.GetAll<PAYMENT>()
                                    where p.GROUP_NAME == lstCustomers.Text &
                                          p.YEAR_MONTH.Substring(0, 4) == cmbYear.Text &
                                          p.MONTH.Substring(0, 2) == cmbMonth.Text
                                          & string.Equals(p.INVC_NBR, " ") == withInvoice

                                    select new PaymentsToGrid
                                        {
                                            SDG_CREATED_ON = p.SDG_CREATED_ON,
                                            SDG_ID = p.SDG_ID,
                                            TypeLetter = p.TYPE_LETTER,
                                            SpecialStain = p.SPECIAL_STAIN,
                                            PatholabName = p.NBR,
                                            SdgName = p.SDG_NAME,
                                            PartTest = p.PART_TEST,
                                            PartCode = p.PART_CODE,
                                            OrderPart = p.ORDER_PART,
                                            ClalitCode = p.CLALIT_CODE,
                                            ClalitDescription = p.CLALIT_DESCR,
                                            PHYSICIAN_LICENSE = p.PHYSICIAN_LICENSE,
                                            PHYSICIAN = p.PHYSICIAN,
                                            ClinicCode = p.CLINIC_CODE,
                                            InvcNbr = p.INVC_NBR,
                                            InvcDate = p.INVC_DATE,
                                            EventDate = p.EVENT_DATE,
                                            CustomerName = p.CUSTOMER_NAME,
                                            GroupCode = p.GROUP_NAME,
                                            PaymentID = p.PAYMENT_ID,
                                            PriceVAT = p.PRICE_INC_VAT,
                                            PriceNoVAT = p.PRICE_NO_VAT,
                                            ClientID = p.CLIENT_ID,
                                            FirstName = p.FIRAT_NAME,
                                            LastName = p.LAST_NAME,
                                            IsPassport = (p.IS_PASSPORT ?? "F") == "T",//if is_passport is null refer to it as false
                                            CommitmentNumber = p.COMMITMENT,
                                            MeuchedetCode = p.MEUHEDET_CODE,
                                            DateTaken = p.DATE_TAKEN,
                                            LeumitPartName = p.LEUMIT_PART_NAME,
                                            Quantity = p.QNTY,
                                            AmountVAT = p.AMOUNT_INC_VAT,
                                            TZ_PASS = p.TZ_PASS,
                                            AMOUNT_NO_VAT = p.AMOUNT_NO_VAT,
                                            District = p.DISTRICT

                                        }).ToList();
            }
            else
            {
                PaymentList1Temp = (from p in DAL.GetAll<PAYMENT>()
                                    where p.CUSTOMER_NAME == lstCustomers.Text &
                                          p.YEAR_MONTH.Substring(0, 4) == cmbYear.Text &
                                          p.MONTH.Substring(0, 2) == cmbMonth.Text
                                           & string.Equals(p.INVC_NBR, " ") == withInvoice
                                    select new PaymentsToGrid
               {
                   SDG_CREATED_ON = p.SDG_CREATED_ON,

                   SDG_ID = p.SDG_ID,
                   TypeLetter = p.TYPE_LETTER,
                   SpecialStain = p.SPECIAL_STAIN,
                   SdgName = p.SDG_NAME,
                   OrderPart = p.ORDER_PART,
                   PatholabName = p.NBR,
                   PartTest = p.PART_TEST,
                   PartCode = p.PART_CODE,
                   ClalitCode = p.CLALIT_CODE,
                   ClalitDescription = p.CLALIT_DESCR,
                   PHYSICIAN_LICENSE = p.PHYSICIAN_LICENSE,
                   PHYSICIAN = p.PHYSICIAN,
                   ClinicCode = p.CLINIC_CODE,
                   CustomerName = p.CUSTOMER_NAME,
                   GroupCode = p.GROUP_NAME,
                   PaymentID = p.PAYMENT_ID,
                   PriceVAT = p.PRICE_INC_VAT,
                   PriceNoVAT = p.PRICE_NO_VAT,
                   ClientID = p.CLIENT_ID,
                   FirstName = p.FIRAT_NAME,
                   LastName = p.LAST_NAME,
                   IsPassport = (p.IS_PASSPORT ?? "F") == "T",//if is_passport is null refer to it as false
                   CommitmentNumber = p.COMMITMENT,
                   DateTaken = p.DATE_TAKEN,
                   MeuchedetCode = p.MEUHEDET_CODE,
                   InvcNbr = p.INVC_NBR,
                   InvcDate = p.INVC_DATE,
                   EventDate = p.EVENT_DATE,
                   LeumitPartName = p.LEUMIT_PART_NAME,
                   Quantity = p.QNTY,
                   AmountVAT = p.AMOUNT_INC_VAT,
                   AMOUNT_NO_VAT = p.AMOUNT_NO_VAT,
                   TZ_PASS = p.TZ_PASS,
                   District = p.DISTRICT
               }).ToList();

            }
            SetGrid(PaymentList1Temp);
        }

        protected void SetGrid(List<PaymentsToGrid> paymentListTemp)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            if (paymentListTemp == null || PaymentList1Temp.Count < 1) return;

            List<PaymentsToGrid> PaymentList;
            var pair = GetSdgType();
            //if (pair.Key == "Z")
            //    PaymentList = paymentListTemp.ToList();
            //else
            PaymentList = paymentListTemp.Where(p => (p.TypeLetter == pair.Key) == pair.Value).ToList();


            dataGridView1.DataSource = PaymentList;

            CalcTotal(PaymentList);
        }

        private void CalcTotal(List<PaymentsToGrid> PaymentList)
        {
            try
            {
                lstCustomers.Enabled = false;
                dataGridView1.Enabled = false;

                decimal Price = 0;
                decimal PriceIncVAT = 0;
                decimal blocks = 0;

                foreach (PaymentsToGrid p in PaymentList)
                {
                    Price += decimal.Parse(p.AMOUNT_NO_VAT);
                    PriceIncVAT += decimal.Parse(p.AmountVAT);
                    if (p.PartCode == "12" || p.PartCode == "13" || p.PartCode == "14" || p.PartCode == "15" || p.PartCode == "16")
                        blocks += decimal.Parse(p.Quantity ?? "0"); //part code = 12
                }


                //var samples1 = DAL.GetAll<SAMPLE>().ToList().Where //(x=>PaymentList.Contains((x=>x))
                //    (s => PaymentList.Any(p => p.SDG_ID == s.SDG_ID));
                ////    

                //var smpCnt = samples1.Count();


                //var blocks =
                //    samples1.SelectMany(
                //        x => x.ALIQUOTs.Where(xb => xb.ALIQUOT_USER.U_GLASS_TYPE == "B" && x.STATUS != "X" && x.STATUS != "R").Select(a => a.ALIQUOT_ID))
                //            .Distinct()
                //            .Count();




                txtTotalPatients.Text = PaymentList.GroupBy(X => X.ClientID).Count().ToString();

                //txtTotalSamples.Text = smpCnt.ToString();
                txtTotalBlocks.Text = blocks.ToString("#");
                if (txtTotalBlocks.Text == "") txtTotalBlocks.Text = "0";
                txtTotal.Text = Price.ToString(); //"C");
                txtTotalWithVAT.Text = PriceIncVAT.ToString(); //"C");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on Calculating total ", mboxTitle);
                Logger.WriteLogFile(ex);
            }
            finally
            {
                lstCustomers.Enabled = true;
                dataGridView1.Enabled = true;
            }
        }

        private void Payments_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(Width / 2 - panel1.Width / 2, panel1.Location.Y);

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtInvoice.Text))
                {
                    MessageBox.Show("אנא הקלד מספר חשבונית.", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                var list = dataGridView1.DataSource as List<PaymentsToGrid>;
                if (list == null || list.Count < 1)
                {
                    MessageBox.Show("לא מופיעים נתונים.", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;

                }

                //Get debit for payments
                var ids = list.Select(x => x.PaymentID).ToList();
                var allDebit = DAL.GetAll<U_DEBIT_USER>();
                var debits4Update = allDebit.Where(p => ids.Contains(p.U_DEBIT_ID));
                if (allDebit.Any(d => d.U_INVC_NBR == txtInvoice.Text))
                {
                    MessageBox.Show(".מספר חשבונית כבר קיים במערכת", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                foreach (var d in debits4Update)
                {
                    d.U_DEBIT_STATUS = "C";
                    if (!string.IsNullOrEmpty(txtInvoice.Text))
                    { d.U_INVC_NBR = txtInvoice.Text; }

                    d.U_INVC_DATE = dtInvoice.Value;
                }
                DAL.SaveChanges();


                MessageBox.Show("מספר חשבונית עודכן במערכת.", mboxTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                txtInvoice.Text = "";
                MakeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in btnConfirm_Click", mboxTitle);
                Logger.WriteLogFile(ex);
            }
        }

        private void btnQuit_Click_1(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("האם אתה בטוח שברצונך לצאת?", mboxTitle, MessageBoxButtons.YesNoCancel);

            if (dg == DialogResult.Yes)
            {
                if (_ntlsSite != null) _ntlsSite.CloseWindow();
            }
        }

        private void AllowOnePoint_keyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void txtByInvc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtByInvc.Text))
                {
                    lstCustomers.Items.Clear();
                    FillGrifByInvc(txtByInvc.Text);
                }
                else
                {
                    MessageBox.Show("אנא הזן ערך.", mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void FillGrifByInvc(string INVC_NBR)
        {
            PaymentList1Temp = (from p in DAL.GetAll<PAYMENT>()
                                where
                                  p.INVC_NBR == INVC_NBR
                                select new PaymentsToGrid
                                    {
                                        SDG_CREATED_ON = p.SDG_CREATED_ON,
                                        Priority = p.PRIORITY,
                                        SdgName = p.SDG_NAME,
                                        SDG_ID = p.SDG_ID,
                                        TypeLetter = p.TYPE_LETTER,
                                        SpecialStain = p.SPECIAL_STAIN,
                                        OrderPart = p.ORDER_PART,
                                        PatholabName = p.NBR,
                                        PartTest = p.PART_TEST,
                                        PartCode = p.PART_CODE,
                                        ClalitCode = p.CLALIT_CODE,
                                        ClalitDescription = p.CLALIT_DESCR,
                                        PHYSICIAN_LICENSE = p.PHYSICIAN_LICENSE,
                                        PHYSICIAN = p.PHYSICIAN,
                                        ClinicCode = p.CLINIC_CODE,
                                        CustomerName = p.CUSTOMER_NAME,
                                        GroupCode = p.GROUP_NAME,
                                        PaymentID = p.PAYMENT_ID,
                                        PriceVAT = p.PRICE_INC_VAT,
                                        PriceNoVAT = p.PRICE_NO_VAT,
                                        ClientID = p.CLIENT_ID,
                                        FirstName = p.FIRAT_NAME,
                                        LastName = p.LAST_NAME,
                                        IsPassport = (p.IS_PASSPORT ?? "F") == "T",//if is_passport is null refer to it as false
                                        CommitmentNumber = p.COMMITMENT,
                                        DateTaken = p.DATE_TAKEN,
                                        MeuchedetCode = p.MEUHEDET_CODE,
                                        InvcNbr = p.INVC_NBR,
                                        InvcDate = p.INVC_DATE,
                                        EventDate = p.EVENT_DATE,
                                        LeumitPartName = p.LEUMIT_PART_NAME,
                                        Quantity = p.QNTY,
                                        AmountVAT = p.AMOUNT_INC_VAT,
                                        TZ_PASS = p.TZ_PASS,
                                        AMOUNT_NO_VAT = p.AMOUNT_NO_VAT,
                                        District = p.DISTRICT
                                    }).ToList();


            chkboxInvoice.Checked = true;
            chkboxInvoice_CheckedChanged(null, null);
            SetGrid(PaymentList1Temp);

        }

        private void OpenOutlook(string path)
        {
            try
            {
                var oApp = new Microsoft.Office.Interop.Outlook.Application();
                MailItem oMailItem = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                var iAttachType = (int)OlAttachmentType.olByValue;
                oMailItem.Attachments.Add(path, iAttachType,
                    /*iPosition*/1, path);
                oMailItem.Display(true);
            }
            catch (Exception ex)
            { Logger.WriteLogFile(ex); }
        }

        private void Payments_Leave(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetGrid(PaymentList1Temp);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var dg = dataGridView1;

            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "ניהול חיובים";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dg.Rows.Count + 1; i++)
                {
                    for (int j = 0; j < dg.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dg.Columns[j].HeaderText;
                        }
                        else
                        {
                            var val = dg.Rows[i - 1].Cells[j].Value;
                            if (val != null)
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = val;
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = "Payments " + DateTime.Now.ToString("dd-MM-yyyy");
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F4)
            {
                Debugger.Launch();
            }
        }

    }


}


public static class StringExtensions
{
    public static string Right(this string str, int length)
    {
        if (string.IsNullOrEmpty(str)) return "";
        return str.Substring(str.Length - length, length);
    }
    public static string Left(this string @this, int count)
    {
        if (string.IsNullOrEmpty(@this)) return "";

        if (@this.Length <= count)
        {
            return @this;
        }
        else
        {
            return @this.Substring(0, count);
        }
    }

    public static string MyReverse(this string str)
    {
        if (string.IsNullOrEmpty(str)) return "";
        string ret = "";
        foreach (char c in str)
        {
            ret = c + ret;
        }
        return ret;
    }
}


