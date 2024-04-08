using System;

namespace Payments
{
    partial class Payments
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

            }


            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtTotalWithVAT = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtInvoice = new System.Windows.Forms.DateTimePicker();
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.chkboxGroupOnly = new System.Windows.Forms.CheckBox();
            this.chkboxInvoice = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbSpecial = new System.Windows.Forms.RadioButton();
            this.rbPap = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbCyt = new System.Windows.Forms.RadioButton();
            this.rdbHis = new System.Windows.Forms.RadioButton();
            this.txtTotalSamples = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalBlocks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalPatients = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtByInvc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnQuit.Location = new System.Drawing.Point(29, 672);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 28);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "סגור";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click_1);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConfirm.Location = new System.Drawing.Point(150, 671);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 28);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "אישור";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCreateFile.Location = new System.Drawing.Point(29, 247);
            this.btnCreateFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(100, 28);
            this.btnCreateFile.TabIndex = 2;
            this.btnCreateFile.Text = "צור קובץ";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // txtInvoice
            // 
            this.txtInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtInvoice.Location = new System.Drawing.Point(429, 675);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(152, 22);
            this.txtInvoice.TabIndex = 4;
            this.txtInvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnePoint_keyPress);
            // 
            // txtTotalWithVAT
            // 
            this.txtTotalWithVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalWithVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTotalWithVAT.Location = new System.Drawing.Point(751, 669);
            this.txtTotalWithVAT.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalWithVAT.Name = "txtTotalWithVAT";
            this.txtTotalWithVAT.Size = new System.Drawing.Size(132, 22);
            this.txtTotalWithVAT.TabIndex = 5;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTotal.Location = new System.Drawing.Point(751, 625);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(132, 22);
            this.txtTotal.TabIndex = 6;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(1151, 63);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(160, 24);
            this.cmbMonth.TabIndex = 7;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(860, 63);
            this.cmbYear.Margin = new System.Windows.Forms.Padding(4);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(160, 24);
            this.cmbYear.TabIndex = 8;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 283);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1328, 335);
            this.dataGridView1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(1052, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "שנה";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(1333, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "חודש";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(891, 672);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "סה\"כ כולל מע\"מ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(891, 630);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "סה\"כ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(617, 677);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "מספר חשבונית";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(610, 631);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "תאריך חשבונית";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(603, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 29);
            this.label7.TabIndex = 18;
            this.label7.Text = "ניהול חיובים";
            // 
            // dtInvoice
            // 
            this.dtInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInvoice.Location = new System.Drawing.Point(429, 626);
            this.dtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.dtInvoice.Name = "dtInvoice";
            this.dtInvoice.Size = new System.Drawing.Size(152, 22);
            this.dtInvoice.TabIndex = 19;
            // 
            // lstCustomers
            // 
            this.lstCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.ItemHeight = 16;
            this.lstCustomers.Location = new System.Drawing.Point(838, 127);
            this.lstCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstCustomers.Size = new System.Drawing.Size(519, 132);
            this.lstCustomers.TabIndex = 20;
            this.lstCustomers.SelectedIndexChanged += new System.EventHandler(this.lstCustomers_SelectedIndexChanged);
            // 
            // chkboxGroupOnly
            // 
            this.chkboxGroupOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkboxGroupOnly.AutoSize = true;
            this.chkboxGroupOnly.Location = new System.Drawing.Point(643, 62);
            this.chkboxGroupOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkboxGroupOnly.Name = "chkboxGroupOnly";
            this.chkboxGroupOnly.Size = new System.Drawing.Size(127, 20);
            this.chkboxGroupOnly.TabIndex = 21;
            this.chkboxGroupOnly.Text = "הצג קבוצות בלבד";
            this.chkboxGroupOnly.UseVisualStyleBackColor = true;
            this.chkboxGroupOnly.CheckedChanged += new System.EventHandler(this.chkboxGroupOnly_CheckedChanged);
            // 
            // chkboxInvoice
            // 
            this.chkboxInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkboxInvoice.AutoSize = true;
            this.chkboxInvoice.Location = new System.Drawing.Point(613, 103);
            this.chkboxInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.chkboxInvoice.Name = "chkboxInvoice";
            this.chkboxInvoice.Size = new System.Drawing.Size(157, 20);
            this.chkboxInvoice.TabIndex = 22;
            this.chkboxInvoice.Text = "הצג שורות עם חשבונית";
            this.chkboxInvoice.UseVisualStyleBackColor = true;
            this.chkboxInvoice.CheckedChanged += new System.EventHandler(this.chkboxInvoice_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstCustomers);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTotalSamples);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtTotalBlocks);
            this.panel1.Controls.Add(this.txtInvoice);
            this.panel1.Controls.Add(this.txtTotalWithVAT);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtTotalPatients);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkboxGroupOnly);
            this.panel1.Controls.Add(this.dtInvoice);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkboxInvoice);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnCreateFile);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 3);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1379, 711);
            this.panel1.TabIndex = 23;
            this.panel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel1_PreviewKeyDown);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnExcel.Location = new System.Drawing.Point(150, 247);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(108, 28);
            this.btnExcel.TabIndex = 34;
            this.btnExcel.Text = "ייצוא לאקסל";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rbSpecial);
            this.panel2.Controls.Add(this.rbPap);
            this.panel2.Controls.Add(this.rdbAll);
            this.panel2.Controls.Add(this.rdbCyt);
            this.panel2.Controls.Add(this.rdbHis);
            this.panel2.Location = new System.Drawing.Point(594, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 129);
            this.panel2.TabIndex = 33;
            // 
            // rbSpecial
            // 
            this.rbSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSpecial.AutoSize = true;
            this.rbSpecial.Location = new System.Drawing.Point(49, 81);
            this.rbSpecial.Name = "rbSpecial";
            this.rbSpecial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbSpecial.Size = new System.Drawing.Size(119, 20);
            this.rbSpecial.TabIndex = 36;
            this.rbSpecial.TabStop = true;
            this.rbSpecial.Tag = "H";
            this.rbSpecial.Text = "צביעות מיוחדות";
            this.rbSpecial.UseVisualStyleBackColor = true;
            this.rbSpecial.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbPap
            // 
            this.rbPap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPap.AutoSize = true;
            this.rbPap.Location = new System.Drawing.Point(120, 55);
            this.rbPap.Name = "rbPap";
            this.rbPap.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbPap.Size = new System.Drawing.Size(48, 20);
            this.rbPap.TabIndex = 35;
            this.rbPap.TabStop = true;
            this.rbPap.Tag = "P";
            this.rbPap.Text = "פאפ";
            this.rbPap.UseVisualStyleBackColor = true;
            this.rbPap.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(51, 107);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbAll.Size = new System.Drawing.Size(117, 20);
            this.rdbAll.TabIndex = 34;
            this.rdbAll.TabStop = true;
            this.rdbAll.Tag = "A";
            this.rdbAll.Text = "הכל (מלבד פאפ)";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbCyt
            // 
            this.rdbCyt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbCyt.AutoSize = true;
            this.rdbCyt.Location = new System.Drawing.Point(85, 29);
            this.rdbCyt.Name = "rdbCyt";
            this.rdbCyt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbCyt.Size = new System.Drawing.Size(83, 20);
            this.rdbCyt.TabIndex = 33;
            this.rdbCyt.TabStop = true;
            this.rdbCyt.Tag = "C";
            this.rdbCyt.Text = "ציטולוגיה";
            this.rdbCyt.UseVisualStyleBackColor = true;
            this.rdbCyt.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbHis
            // 
            this.rdbHis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbHis.AutoSize = true;
            this.rdbHis.Location = new System.Drawing.Point(76, 3);
            this.rdbHis.Name = "rdbHis";
            this.rdbHis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbHis.Size = new System.Drawing.Size(92, 20);
            this.rdbHis.TabIndex = 32;
            this.rdbHis.TabStop = true;
            this.rdbHis.Tag = "B";
            this.rdbHis.Text = "היסטולוגיה";
            this.rdbHis.UseVisualStyleBackColor = true;
            this.rdbHis.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // txtTotalSamples
            // 
            this.txtTotalSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTotalSamples.Location = new System.Drawing.Point(1128, 656);
            this.txtTotalSamples.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalSamples.Name = "txtTotalSamples";
            this.txtTotalSamples.Size = new System.Drawing.Size(132, 22);
            this.txtTotalSamples.TabIndex = 30;
            this.txtTotalSamples.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(1274, 657);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "סה\"כ צנצנות";
            this.label12.Visible = false;
            // 
            // txtTotalBlocks
            // 
            this.txtTotalBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalBlocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTotalBlocks.Location = new System.Drawing.Point(1128, 683);
            this.txtTotalBlocks.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalBlocks.Name = "txtTotalBlocks";
            this.txtTotalBlocks.Size = new System.Drawing.Size(132, 22);
            this.txtTotalBlocks.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(1271, 684);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "סה\"כ בלוקים";
            // 
            // txtTotalPatients
            // 
            this.txtTotalPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTotalPatients.Location = new System.Drawing.Point(1128, 629);
            this.txtTotalPatients.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalPatients.Name = "txtTotalPatients";
            this.txtTotalPatients.Size = new System.Drawing.Size(132, 22);
            this.txtTotalPatients.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(1263, 630);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "סה\"כ מטופלים";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtByInvc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(29, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(204, 145);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "חיובים לפי חשבונית";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(86, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "הזן מספר חשבונית";
            // 
            // txtByInvc
            // 
            this.txtByInvc.Location = new System.Drawing.Point(20, 81);
            this.txtByInvc.Name = "txtByInvc";
            this.txtByInvc.Size = new System.Drawing.Size(178, 22);
            this.txtByInvc.TabIndex = 0;
            this.txtByInvc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtByInvc_KeyDown);
            this.txtByInvc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnePoint_keyPress);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(1252, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "לקוחות/קבוצות";
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Payments";
            this.Size = new System.Drawing.Size(1414, 717);
            this.Load += new System.EventHandler(this.Payments_Load);
            this.Leave += new System.EventHandler(this.Payments_Leave);
            this.Resize += new System.EventHandler(this.Payments_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtTotalWithVAT;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtInvoice;
        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.CheckBox chkboxGroupOnly;
        private System.Windows.Forms.CheckBox chkboxInvoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtByInvc;
        private System.Windows.Forms.TextBox txtTotalPatients;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalSamples;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalBlocks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbSpecial;
        private System.Windows.Forms.RadioButton rbPap;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbCyt;
        private System.Windows.Forms.RadioButton rdbHis;
    }
}
