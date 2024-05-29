﻿namespace POSDocumentPrinter
{
    partial class frmSearchPayment
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPayment));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.cmbTenderType = new System.Windows.Forms.ComboBox();
            this.lblPaidBy = new System.Windows.Forms.Label();
            this.cmbPaidByLogic = new System.Windows.Forms.ComboBox();
            this.ntbTotalAmountTo = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbTotalAmountFrom = new POSDocumentPrinter.ctlNumberTextBox();
            this.ddgInvoice = new POSDocumentPrinter.DropDownDataGrid();
            this.ddgCustomers = new POSDocumentPrinter.DropDownDataGrid();
            this.lblReceiptAmount = new System.Windows.Forms.Label();
            this.cmbReceiptAmtLogic = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomerLogic = new System.Windows.Forms.ComboBox();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbDateLogic = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.cmbInvoiceLogic = new System.Windows.Forms.ComboBox();
            this.ddgOtherIncome = new POSDocumentPrinter.DropDownDataGrid();
            this.lblOtherIncome = new System.Windows.Forms.Label();
            this.cmbOtherIncomeLogic = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddgOtherIncome);
            this.groupBox1.Controls.Add(this.lblOtherIncome);
            this.groupBox1.Controls.Add(this.cmbOtherIncomeLogic);
            this.groupBox1.Controls.Add(this.txtInstrumentNo);
            this.groupBox1.Controls.Add(this.cmbTenderType);
            this.groupBox1.Controls.Add(this.lblPaidBy);
            this.groupBox1.Controls.Add(this.cmbPaidByLogic);
            this.groupBox1.Controls.Add(this.ntbTotalAmountTo);
            this.groupBox1.Controls.Add(this.ntbTotalAmountFrom);
            this.groupBox1.Controls.Add(this.ddgInvoice);
            this.groupBox1.Controls.Add(this.ddgCustomers);
            this.groupBox1.Controls.Add(this.lblReceiptAmount);
            this.groupBox1.Controls.Add(this.cmbReceiptAmtLogic);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.cmbCustomerLogic);
            this.groupBox1.Controls.Add(this.cmbSearchAndIncludeToPreviousResult);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.lblDocumentNumber);
            this.groupBox1.Controls.Add(this.ckAllOrAny);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblInvoice);
            this.groupBox1.Controls.Add(this.cmbDocumentNumberLogic);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.cmbDateLogic);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.txtDocumentNumber);
            this.groupBox1.Controls.Add(this.cmbInvoiceLogic);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterion";
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstrumentNo.Location = new System.Drawing.Point(344, 196);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(176, 20);
            this.txtInstrumentNo.TabIndex = 69;
            this.txtInstrumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInstrumentNo.Visible = false;
            this.txtInstrumentNo.WordWrap = false;
            // 
            // cmbTenderType
            // 
            this.cmbTenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenderType.FormattingEnabled = true;
            this.cmbTenderType.Items.AddRange(new object[] {
            "Cash",
            "Check",
            "CPO"});
            this.cmbTenderType.Location = new System.Drawing.Point(243, 196);
            this.cmbTenderType.Name = "cmbTenderType";
            this.cmbTenderType.Size = new System.Drawing.Size(95, 21);
            this.cmbTenderType.TabIndex = 68;
            this.cmbTenderType.SelectedIndexChanged += new System.EventHandler(this.cmbTenderType_SelectedIndexChanged);
            // 
            // lblPaidBy
            // 
            this.lblPaidBy.Location = new System.Drawing.Point(15, 198);
            this.lblPaidBy.Name = "lblPaidBy";
            this.lblPaidBy.Size = new System.Drawing.Size(103, 19);
            this.lblPaidBy.TabIndex = 66;
            this.lblPaidBy.Text = "Paid by";
            this.lblPaidBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPaidByLogic
            // 
            this.cmbPaidByLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaidByLogic.DropDownWidth = 130;
            this.cmbPaidByLogic.FormattingEnabled = true;
            this.cmbPaidByLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPaidByLogic.Location = new System.Drawing.Point(124, 196);
            this.cmbPaidByLogic.Name = "cmbPaidByLogic";
            this.cmbPaidByLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbPaidByLogic.TabIndex = 67;
            this.cmbPaidByLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPaidByLogic_SelectedIndexChanged);
            // 
            // ntbTotalAmountTo
            // 
            this.ntbTotalAmountTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTotalAmountTo.AllowedLength = 0;
            this.ntbTotalAmountTo.AllowLeadingZeros = false;
            this.ntbTotalAmountTo.AllowNegative = false;
            this.ntbTotalAmountTo.Amount = "";
            this.ntbTotalAmountTo.defaultAmount = "0";
            this.ntbTotalAmountTo.Location = new System.Drawing.Point(386, 166);
            this.ntbTotalAmountTo.Name = "ntbTotalAmountTo";
            this.ntbTotalAmountTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTotalAmountTo.ShowThousandSeparetor = true;
            this.ntbTotalAmountTo.Size = new System.Drawing.Size(138, 23);
            this.ntbTotalAmountTo.StandardPrecision = 2;
            this.ntbTotalAmountTo.TabIndex = 65;
            // 
            // ntbTotalAmountFrom
            // 
            this.ntbTotalAmountFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTotalAmountFrom.AllowedLength = 0;
            this.ntbTotalAmountFrom.AllowLeadingZeros = false;
            this.ntbTotalAmountFrom.AllowNegative = false;
            this.ntbTotalAmountFrom.Amount = "";
            this.ntbTotalAmountFrom.defaultAmount = "0";
            this.ntbTotalAmountFrom.Location = new System.Drawing.Point(242, 166);
            this.ntbTotalAmountFrom.Name = "ntbTotalAmountFrom";
            this.ntbTotalAmountFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTotalAmountFrom.ShowThousandSeparetor = true;
            this.ntbTotalAmountFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbTotalAmountFrom.StandardPrecision = 2;
            this.ntbTotalAmountFrom.TabIndex = 64;
            // 
            // ddgInvoice
            // 
            this.ddgInvoice.AutoFilter = true;
            this.ddgInvoice.AutoSize = true;
            this.ddgInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgInvoice.ClearButtonEnabled = true;
            this.ddgInvoice.DataTablePrimaryKey = ((ushort)(0));
            this.ddgInvoice.FindButtonEnabled = true;
            this.ddgInvoice.HiddenColoumns = new int[0];
            this.ddgInvoice.Image = null;
            this.ddgInvoice.Location = new System.Drawing.Point(239, 102);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(377, 31);
            this.ddgInvoice.TabIndex = 63;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            // 
            // ddgCustomers
            // 
            this.ddgCustomers.AutoFilter = true;
            this.ddgCustomers.AutoSize = true;
            this.ddgCustomers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgCustomers.ClearButtonEnabled = true;
            this.ddgCustomers.DataTablePrimaryKey = ((ushort)(0));
            this.ddgCustomers.FindButtonEnabled = true;
            this.ddgCustomers.HiddenColoumns = new int[0];
            this.ddgCustomers.Image = null;
            this.ddgCustomers.Location = new System.Drawing.Point(239, 46);
            this.ddgCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCustomers.Name = "ddgCustomers";
            this.ddgCustomers.NewButtonEnabled = true;
            this.ddgCustomers.RefreshButtonEnabled = true;
            this.ddgCustomers.SelectedColomnIdex = 0;
            this.ddgCustomers.SelectedItem = "";
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.ShowGridFunctions = false;
            this.ddgCustomers.Size = new System.Drawing.Size(377, 31);
            this.ddgCustomers.TabIndex = 62;
            this.ddgCustomers.SelectedItemClicked += new System.EventHandler(this.ddgCustomers_SelectedItemClicked);
            // 
            // lblReceiptAmount
            // 
            this.lblReceiptAmount.Location = new System.Drawing.Point(15, 168);
            this.lblReceiptAmount.Name = "lblReceiptAmount";
            this.lblReceiptAmount.Size = new System.Drawing.Size(103, 19);
            this.lblReceiptAmount.TabIndex = 60;
            this.lblReceiptAmount.Text = "Receipt Amount";
            this.lblReceiptAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbReceiptAmtLogic
            // 
            this.cmbReceiptAmtLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiptAmtLogic.DropDownWidth = 130;
            this.cmbReceiptAmtLogic.FormattingEnabled = true;
            this.cmbReceiptAmtLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbReceiptAmtLogic.Location = new System.Drawing.Point(124, 167);
            this.cmbReceiptAmtLogic.Name = "cmbReceiptAmtLogic";
            this.cmbReceiptAmtLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbReceiptAmtLogic.TabIndex = 61;
            this.cmbReceiptAmtLogic.SelectedIndexChanged += new System.EventHandler(this.cmbReceiptAmtLogic_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(15, 53);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(103, 19);
            this.lblCustomer.TabIndex = 58;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCustomerLogic
            // 
            this.cmbCustomerLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerLogic.DropDownWidth = 130;
            this.cmbCustomerLogic.FormattingEnabled = true;
            this.cmbCustomerLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbCustomerLogic.Location = new System.Drawing.Point(124, 51);
            this.cmbCustomerLogic.Name = "cmbCustomerLogic";
            this.cmbCustomerLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbCustomerLogic.TabIndex = 59;
            this.cmbCustomerLogic.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerLogic_SelectedIndexChanged);
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(181, 269);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 57;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(201, 303);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(226, 28);
            this.cmdSearch.TabIndex = 55;
            this.cmdSearch.Text = "Show Result";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Location = new System.Drawing.Point(15, 25);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(103, 19);
            this.lblDocumentNumber.TabIndex = 41;
            this.lblDocumentNumber.Text = "Document Number";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(124, 239);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(400, 24);
            this.ckAllOrAny.TabIndex = 54;
            this.ckAllOrAny.Text = "Show Movement Records That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            this.ckAllOrAny.CheckedChanged += new System.EventHandler(this.ckAllOrAny_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(15, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(103, 19);
            this.lblDate.TabIndex = 42;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoice
            // 
            this.lblInvoice.Location = new System.Drawing.Point(15, 108);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(103, 19);
            this.lblInvoice.TabIndex = 43;
            this.lblInvoice.Text = "Sales";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDocumentNumberLogic
            // 
            this.cmbDocumentNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentNumberLogic.DropDownWidth = 130;
            this.cmbDocumentNumberLogic.FormattingEnabled = true;
            this.cmbDocumentNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to"});
            this.cmbDocumentNumberLogic.Location = new System.Drawing.Point(124, 25);
            this.cmbDocumentNumberLogic.Name = "cmbDocumentNumberLogic";
            this.cmbDocumentNumberLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDocumentNumberLogic.TabIndex = 45;
            this.cmbDocumentNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentNumberLogic_SelectedIndexChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(451, 79);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(206, 20);
            this.dtpDateTo.TabIndex = 51;
            this.dtpDateTo.Visible = false;
            // 
            // cmbDateLogic
            // 
            this.cmbDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateLogic.DropDownWidth = 130;
            this.cmbDateLogic.FormattingEnabled = true;
            this.cmbDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDateLogic.Location = new System.Drawing.Point(124, 79);
            this.cmbDateLogic.Name = "cmbDateLogic";
            this.cmbDateLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDateLogic.TabIndex = 46;
            this.cmbDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(242, 79);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(204, 20);
            this.dtpDateFrom.TabIndex = 50;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.AcceptsReturn = true;
            this.txtDocumentNumber.Location = new System.Drawing.Point(243, 25);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumber.TabIndex = 49;
            // 
            // cmbInvoiceLogic
            // 
            this.cmbInvoiceLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceLogic.DropDownWidth = 130;
            this.cmbInvoiceLogic.FormattingEnabled = true;
            this.cmbInvoiceLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbInvoiceLogic.Location = new System.Drawing.Point(124, 106);
            this.cmbInvoiceLogic.Name = "cmbInvoiceLogic";
            this.cmbInvoiceLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbInvoiceLogic.TabIndex = 47;
            this.cmbInvoiceLogic.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceLogic_SelectedIndexChanged);
            // 
            // ddgOtherIncome
            // 
            this.ddgOtherIncome.AutoFilter = true;
            this.ddgOtherIncome.AutoSize = true;
            this.ddgOtherIncome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgOtherIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgOtherIncome.ClearButtonEnabled = true;
            this.ddgOtherIncome.DataTablePrimaryKey = ((ushort)(0));
            this.ddgOtherIncome.FindButtonEnabled = true;
            this.ddgOtherIncome.HiddenColoumns = new int[0];
            this.ddgOtherIncome.Image = null;
            this.ddgOtherIncome.Location = new System.Drawing.Point(239, 132);
            this.ddgOtherIncome.Margin = new System.Windows.Forms.Padding(0);
            this.ddgOtherIncome.Name = "ddgOtherIncome";
            this.ddgOtherIncome.NewButtonEnabled = true;
            this.ddgOtherIncome.RefreshButtonEnabled = true;
            this.ddgOtherIncome.SelectedColomnIdex = 0;
            this.ddgOtherIncome.SelectedItem = "";
            this.ddgOtherIncome.SelectedRowKey = null;
            this.ddgOtherIncome.ShowGridFunctions = false;
            this.ddgOtherIncome.Size = new System.Drawing.Size(281, 31);
            this.ddgOtherIncome.TabIndex = 72;
            this.ddgOtherIncome.SelectedItemClicked += new System.EventHandler(this.ddgOtherIncome_SelectedItemClicked);
            // 
            // lblOtherIncome
            // 
            this.lblOtherIncome.Location = new System.Drawing.Point(15, 138);
            this.lblOtherIncome.Name = "lblOtherIncome";
            this.lblOtherIncome.Size = new System.Drawing.Size(103, 19);
            this.lblOtherIncome.TabIndex = 70;
            this.lblOtherIncome.Text = "Other Income";
            this.lblOtherIncome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOtherIncomeLogic
            // 
            this.cmbOtherIncomeLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOtherIncomeLogic.DropDownWidth = 130;
            this.cmbOtherIncomeLogic.FormattingEnabled = true;
            this.cmbOtherIncomeLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbOtherIncomeLogic.Location = new System.Drawing.Point(124, 136);
            this.cmbOtherIncomeLogic.Name = "cmbOtherIncomeLogic";
            this.cmbOtherIncomeLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbOtherIncomeLogic.TabIndex = 71;
            this.cmbOtherIncomeLogic.SelectedIndexChanged += new System.EventHandler(this.cmbOtherIncomeLogic_SelectedIndexChanged);
            // 
            // frmSearchPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 341);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSearchPayment";
            this.Text = "Search Payment";
            this.Load += new System.EventHandler(this.frmSearchPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.ComboBox cmbDateLogic;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.ComboBox cmbInvoiceLogic;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomerLogic;
        private System.Windows.Forms.Label lblReceiptAmount;
        private System.Windows.Forms.ComboBox cmbReceiptAmtLogic;
        private DropDownDataGrid ddgCustomers;
        private DropDownDataGrid ddgInvoice;
        private ctlNumberTextBox ntbTotalAmountTo;
        private ctlNumberTextBox ntbTotalAmountFrom;
        private System.Windows.Forms.Label lblPaidBy;
        private System.Windows.Forms.ComboBox cmbPaidByLogic;
        private System.Windows.Forms.ComboBox cmbTenderType;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private DropDownDataGrid ddgOtherIncome;
        private System.Windows.Forms.Label lblOtherIncome;
        private System.Windows.Forms.ComboBox cmbOtherIncomeLogic;
    }
}