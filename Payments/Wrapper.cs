using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Payments
{
    class Wrapper
    {
        public Wrapper()
        {

        }
        public Wrapper(string dt)
        {
            this.DisplayText = dt;
        }
        public string DisplayText { get; set; }
        public string AsciiType { get; set; }
        public override string ToString()
        {

            return DisplayText;
        }



        public string cg { get; set; }
    }

    public class PaymentsToGrid
    {
        [DisplayName("לקוח")]
        public string CustomerName { get; set; }
        [DisplayName("קבוצת לקוח")]
        public string GroupCode { get; set; }
       
        
  
      
[Browsable(false)]
        public long PaymentID { get; set; }
        [Browsable(false)]

        public string PriceVAT { get; set; }

        [Browsable(false)]
        public string PriceNoVAT { get; set; }

        [DisplayName("מחיר(ללא מעמ)")]
        public string PriceNoVATCustom
        {
            get { return Remove000(PriceNoVAT); }

        }

        [DisplayName("מספר דרישה")]
        public string PatholabName { get; set; }
        [Browsable(false)]
        public long CustomerCode { get; set; }

        [Browsable(false)]
        public string DateTaken { get; set; }

        [DisplayName("תאריך הגעה")]
        public string DateTakenCustom
        {
            get
            {
                if (DateTaken != null)
                {
                    DateTime myDate = DateTime.ParseExact(DateTaken, "ddMMyyyy",
                                                          System.Globalization.CultureInfo.InvariantCulture);
                    return myDate.ToString("ddMMyyyy");
                }
                else return "";
            }

        }

        [DisplayName("פריט")]
        public string PartTest { get; set; }
        [Browsable(false)]
        public string PartCode { get; set; }
        [Browsable(false)]
        public string SdgName { get; set; }
        [Browsable(false)]
     
        public long SDG_ID { get; set; }
   
        [Browsable(false)]

        public string LeumitPartName { get; set; }
        [Browsable(false)]

        public string LeumitConstant { get; set; }
        [Browsable(false)]
        public string MeuchedetCode { get; set; }
        [Browsable(false)]
        public string LeumitPatholab { get; set; }
        [Browsable(false)]
        public string ClalitCode { get; set; }
        [Browsable(false)]
        public string ClalitDescription { get; set; }
        [DisplayName("פריט הזמנה")]

        public string OrderPart { get; set; }
        [DisplayName("ת.ז נבדק")]

        public string ClientID { get; set; }

        [DisplayName("שם פרטי נבדק")]
        public string FirstName { get; set; }
        [DisplayName("שם משפחה נבדק")]
        public string LastName { get; set; }
        [Browsable(false)]
        public bool IsPassport { get; set; }
        
        [DisplayName("התחייבות")]
        public string CommitmentNumber { get; set; }

        [Browsable(false)]

        public string Quantity { get; set; }

        [DisplayName("כמות")]

        public string QuantityCustom
        {
            get { return Remove000(Quantity); }

        }



        [Browsable(false)]

        public string AmountVAT { get; set; }
        [DisplayName("סהכ")]
        public string AmountVATCustom
        {
            get { return Remove000(AmountVAT); }

        }
        [Browsable(false)]
        public string District { get; set; }






        [Browsable(false)]
        public string ClinicCode { get; set; }

        [DisplayName("מס רשיון רופא")]

        public string PHYSICIAN_LICENSE { get; set; }
        [DisplayName("שם רופא")]

        public string PHYSICIAN { get; set; }

        [Browsable(false)]

        public string TZ_PASS { get; set; }

        [Browsable(false)]

        public string AMOUNT_NO_VAT { get; set; }
        [DisplayName("סכום (ללא מעמ) ")]
        public string AMOUNT_NO_VATCustom
        {
            get { return Remove000(AMOUNT_NO_VAT); }

        }
        [DisplayName("מספר חשבונית")]

        public string InvcNbr { get; set; }


        private string _InvcDate;
        [DisplayName("תאריך חשבונית")]
        
         
        public string InvcDate
        {
            get
            {
                if (_InvcDate != null)
                {
                    DateTime myDate = DateTime.ParseExact(_InvcDate, "ddMMyyyy",
                                                          System.Globalization.CultureInfo.InvariantCulture);
                    return myDate.ToString("dd/MM/yyyy");
                }
                return "";

            }
            set { _InvcDate = value; }

        }
        private string _EventDate;
        [Browsable(false)]


        public string EventDate
        {
            get
            {
                if (_EventDate != null)
                {
                    DateTime myDate = DateTime.ParseExact(_EventDate, "ddMMyyyy",
                                                          System.Globalization.CultureInfo.InvariantCulture);
                    return myDate.ToString("dd/MM/yyyy");
                }
                return "";

            }
            set { _EventDate = value; }

        }

   [Browsable(true)][DisplayName("צביעות מיוחדות")]
        public string SpecialStain { get; set; }
   [Browsable(false)]

   public string TypeLetter { get; set; }
   [Browsable(false)]

   public string SDG_CREATED_ON { get; set; }
 

        private string Remove000(string str)
        {
            int i = 1;
            while (str[i] == '0')
            {
                i++;
            }
            str = str.Substring(i);
            return str;
        }

        public decimal? Priority { get; set; }
    }



}

