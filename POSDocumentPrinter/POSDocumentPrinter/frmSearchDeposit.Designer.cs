namespace POSDocumentPrinter
{
    partial class frmSearchDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchDeposit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckIsRefund = new System.Windows.Forms.CheckBox();
            this.ddgPayment = new POSDocumentPrinter.DropDownDataGrid();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPaymentLogic = new System.Windows.Forms.ComboBox();
            this.ddgExemption = new POSDocumentPrinter.DropDownDataGrid();
            this.lblExemption = new System.Windows.Forms.Label();
            this.cmbExemptionLogic = new System.Windows.Forms.ComboBox();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.cmbTenderType = new System.Windows.Forms.ComboBox();
            this.lblTender = new System.Windows.Forms.Label();
            this.cmbTenderLogic = new System.Windows.Forms.ComboBox();
            this.ntbAmountTo = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbAmountFrom = new POSDocumentPrinter.ctlNumberTextBox();
            this.ddgInvoice = new POSDocumentPrinter.DropDownDataGrid();
            this.ddgBankAccount = new POSDocumentPrinter.DropDownDataGrid();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbAmountLogic = new System.Windows.Forms.ComboBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.cmbBankAccountLogic = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckIsRefund);
            this.groupBox1.Controls.Add(this.ddgPayment);
            this.groupBox1.Controls.Add(this.lblPayment);
            this.groupBox1.Controls.Add(this.cmbPaymentLogic);
            this.groupBox1.Controls.Add(this.ddgExemption);
            this.groupBox1.Controls.Add(this.lblExemption);
            this.groupBox1.Controls.Add(this.cmbExemptionLogic);
            this.groupBox1.Controls.Add(this.txtInstrumentNo);
            this.groupBox1.Controls.Add(this.cmbTenderType);
            this.groupBox1.Controls.Add(this.lblTender);
            this.groupBox1.Controls.Add(this.cmbTenderLogic);
            this.groupBox1.Controls.Add(this.ntbAmountTo);
            this.groupBox1.Controls.Add(this.ntbAmountFrom);
            this.groupBox1.Controls.Add(this.ddgInvoice);
            this.groupBox1.Controls.Add(this.ddgBankAccount);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.cmbAmountLogic);
            this.groupBox1.Controls.Add(this.lblBankAccount);
            this.groupBox1.Controls.Add(this.cmbBankAccountLogic);
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
            this.groupBox1.Size = new System.Drawing.Size(683, 352);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterion";
            // 
            // ckIsRefund
            // 
            this.ckIsRefund.AutoSize = true;
            this.ckIsRefund.Location = new System.Drawing.Point(582, 108);
            this.ckIsRefund.Name = "ckIsRefund";
            this.ckIsRefund.Size = new System.Drawing.Size(72, 17);
            this.ckIsRefund.TabIndex = 76;
            this.ckIsRefund.Text = "Is Refund";
            this.ckIsRefund.UseVisualStyleBackColor = true;
            // 
            // ddgPayment
            // 
            this.ddgPayment.AutoFilter = true;
            this.ddgPayment.AutoSize = true;
            this.ddgPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPayment.ClearButtonEnabled = true;
            this.ddgPayment.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPayment.FindButtonEnabled = true;
            this.ddgPayment.HiddenColoumns = new int[0];
            this.ddgPayment.Image = null;
            this.ddgPayment.Location = new System.Drawing.Point(239, 129);
            this.ddgPayment.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPayment.Name = "ddgPayment";
            this.ddgPayment.NewButtonEnabled = true;
            this.ddgPayment.RefreshButtonEnabled = true;
            this.ddgPayment.SelectedColomnIdex = 0;
            this.ddgPayment.SelectedItem = "";
            this.ddgPayment.SelectedRowKey = null;
            this.ddgPayment.ShowGridFunctions = false;
            this.ddgPayment.Size = new System.Drawing.Size(313, 31);
            this.ddgPayment.TabIndex = 75;
            this.ddgPayment.SelectedItemClicked += new System.EventHandler(this.ddgPayment_SelectedItemClicked);
            // 
            // lblPayment
            // 
            this.lblPayment.Location = new System.Drawing.Point(15, 135);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(103, 19);
            this.lblPayment.TabIndex = 73;
            this.lblPayment.Text = "Payment";
            this.lblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPaymentLogic
            // 
            this.cmbPaymentLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentLogic.DropDownWidth = 130;
            this.cmbPaymentLogic.FormattingEnabled = true;
            this.cmbPaymentLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPaymentLogic.Location = new System.Drawing.Point(124, 133);
            this.cmbPaymentLogic.Name = "cmbPaymentLogic";
            this.cmbPaymentLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbPaymentLogic.TabIndex = 74;
            this.cmbPaymentLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentLogic_SelectedIndexChanged);
            // 
            // ddgExemption
            // 
            this.ddgExemption.AutoFilter = true;
            this.ddgExemption.AutoSize = true;
            this.ddgExemption.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgExemption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgExemption.ClearButtonEnabled = true;
            this.ddgExemption.DataTablePrimaryKey = ((ushort)(0));
            this.ddgExemption.FindButtonEnabled = true;
            this.ddgExemption.HiddenColoumns = new int[0];
            this.ddgExemption.Image = null;
            this.ddgExemption.Location = new System.Drawing.Point(239, 158);
            this.ddgExemption.Margin = new System.Windows.Forms.Padding(0);
            this.ddgExemption.Name = "ddgExemption";
            this.ddgExemption.NewButtonEnabled = true;
            this.ddgExemption.RefreshButtonEnabled = true;
            this.ddgExemption.SelectedColomnIdex = 0;
            this.ddgExemption.SelectedItem = "";
            this.ddgExemption.SelectedRowKey = null;
            this.ddgExemption.ShowGridFunctions = false;
            this.ddgExemption.Size = new System.Drawing.Size(285, 31);
            this.ddgExemption.TabIndex = 72;
            this.ddgExemption.SelectedItemClicked += new System.EventHandler(this.ddgExemption_SelectedItemClicked);
            // 
            // lblExemption
            // 
            this.lblExemption.Location = new System.Drawing.Point(15, 164);
            this.lblExemption.Name = "lblExemption";
            this.lblExemption.Size = new System.Drawing.Size(103, 19);
            this.lblExemption.TabIndex = 70;
            this.lblExemption.Text = "Exemption";
            this.lblExemption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbExemptionLogic
            // 
            this.cmbExemptionLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExemptionLogic.DropDownWidth = 130;
            this.cmbExemptionLogic.FormattingEnabled = true;
            this.cmbExemptionLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbExemptionLogic.Location = new System.Drawing.Point(124, 162);
            this.cmbExemptionLogic.Name = "cmbExemptionLogic";
            this.cmbExemptionLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbExemptionLogic.TabIndex = 71;
            this.cmbExemptionLogic.SelectedIndexChanged += new System.EventHandler(this.cmbExemptionLogic_SelectedIndexChanged);
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstrumentNo.Location = new System.Drawing.Point(344, 218);
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
            this.cmbTenderType.Location = new System.Drawing.Point(243, 218);
            this.cmbTenderType.Name = "cmbTenderType";
            this.cmbTenderType.Size = new System.Drawing.Size(95, 21);
            this.cmbTenderType.TabIndex = 68;
            this.cmbTenderType.SelectedIndexChanged += new System.EventHandler(this.cmbTenderType_SelectedIndexChanged);
            // 
            // lblTender
            // 
            this.lblTender.Location = new System.Drawing.Point(15, 220);
            this.lblTender.Name = "lblTender";
            this.lblTender.Size = new System.Drawing.Size(103, 19);
            this.lblTender.TabIndex = 66;
            this.lblTender.Text = "Tender Type";
            this.lblTender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTenderLogic
            // 
            this.cmbTenderLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenderLogic.DropDownWidth = 130;
            this.cmbTenderLogic.FormattingEnabled = true;
            this.cmbTenderLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTenderLogic.Location = new System.Drawing.Point(124, 218);
            this.cmbTenderLogic.Name = "cmbTenderLogic";
            this.cmbTenderLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbTenderLogic.TabIndex = 67;
            this.cmbTenderLogic.SelectedIndexChanged += new System.EventHandler(this.cmbTenderLogic_SelectedIndexChanged);
            // 
            // ntbAmountTo
            // 
            this.ntbAmountTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmountTo.AllowedLength = 0;
            this.ntbAmountTo.AllowLeadingZeros = false;
            this.ntbAmountTo.AllowNegative = false;
            this.ntbAmountTo.Amount = "";
            this.ntbAmountTo.defaultAmount = "0";
            this.ntbAmountTo.Location = new System.Drawing.Point(407, 188);
            this.ntbAmountTo.Name = "ntbAmountTo";
            this.ntbAmountTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmountTo.ShowThousandSeparetor = true;
            this.ntbAmountTo.Size = new System.Drawing.Size(158, 23);
            this.ntbAmountTo.StandardPrecision = 2;
            this.ntbAmountTo.TabIndex = 65;
            // 
            // ntbAmountFrom
            // 
            this.ntbAmountFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmountFrom.AllowedLength = 0;
            this.ntbAmountFrom.AllowLeadingZeros = false;
            this.ntbAmountFrom.AllowNegative = false;
            this.ntbAmountFrom.Amount = "";
            this.ntbAmountFrom.defaultAmount = "0";
            this.ntbAmountFrom.Location = new System.Drawing.Point(242, 188);
            this.ntbAmountFrom.Name = "ntbAmountFrom";
            this.ntbAmountFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmountFrom.ShowThousandSeparetor = true;
            this.ntbAmountFrom.Size = new System.Drawing.Size(158, 23);
            this.ntbAmountFrom.StandardPrecision = 2;
            this.ntbAmountFrom.TabIndex = 64;
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
            this.ddgInvoice.Size = new System.Drawing.Size(339, 31);
            this.ddgInvoice.TabIndex = 63;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            // 
            // ddgBankAccount
            // 
            this.ddgBankAccount.AutoFilter = true;
            this.ddgBankAccount.AutoSize = true;
            this.ddgBankAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBankAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBankAccount.ClearButtonEnabled = true;
            this.ddgBankAccount.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBankAccount.FindButtonEnabled = true;
            this.ddgBankAccount.HiddenColoumns = new int[0];
            this.ddgBankAccount.Image = null;
            this.ddgBankAccount.Location = new System.Drawing.Point(239, 46);
            this.ddgBankAccount.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBankAccount.Name = "ddgBankAccount";
            this.ddgBankAccount.NewButtonEnabled = true;
            this.ddgBankAccount.RefreshButtonEnabled = true;
            this.ddgBankAccount.SelectedColomnIdex = 0;
            this.ddgBankAccount.SelectedItem = "";
            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.ShowGridFunctions = false;
            this.ddgBankAccount.Size = new System.Drawing.Size(377, 31);
            this.ddgBankAccount.TabIndex = 62;
            this.ddgBankAccount.SelectedItemClicked += new System.EventHandler(this.ddgBankAccount_SelectedItemClicked);
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(15, 190);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(103, 19);
            this.lblAmount.TabIndex = 60;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAmountLogic
            // 
            this.cmbAmountLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmountLogic.DropDownWidth = 130;
            this.cmbAmountLogic.FormattingEnabled = true;
            this.cmbAmountLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbAmountLogic.Location = new System.Drawing.Point(124, 189);
            this.cmbAmountLogic.Name = "cmbAmountLogic";
            this.cmbAmountLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbAmountLogic.TabIndex = 61;
            this.cmbAmountLogic.SelectedIndexChanged += new System.EventHandler(this.cmbAmountLogic_SelectedIndexChanged);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(15, 53);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(103, 19);
            this.lblBankAccount.TabIndex = 58;
            this.lblBankAccount.Text = "Bank Account";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBankAccountLogic
            // 
            this.cmbBankAccountLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAccountLogic.DropDownWidth = 130;
            this.cmbBankAccountLogic.FormattingEnabled = true;
            this.cmbBankAccountLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbBankAccountLogic.Location = new System.Drawing.Point(124, 51);
            this.cmbBankAccountLogic.Name = "cmbBankAccountLogic";
            this.cmbBankAccountLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbBankAccountLogic.TabIndex = 59;
            this.cmbBankAccountLogic.SelectedIndexChanged += new System.EventHandler(this.cmbBankAccountLogic_SelectedIndexChanged);
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(181, 283);
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
            this.cmdSearch.Location = new System.Drawing.Point(216, 317);
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
            this.ckAllOrAny.Location = new System.Drawing.Point(124, 253);
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
            this.dtpDateTo.Location = new System.Drawing.Point(462, 79);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(209, 20);
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
            this.dtpDateFrom.Size = new System.Drawing.Size(207, 20);
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
            // frmSearchDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 352);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSearchDeposit";
            this.Text = "Search Deposit";
            this.Load += new System.EventHandler(this.frmSearchDeposit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.ComboBox cmbTenderType;
        private System.Windows.Forms.Label lblTender;
        private System.Windows.Forms.ComboBox cmbTenderLogic;
        private ctlNumberTextBox ntbAmountTo;
        private ctlNumberTextBox ntbAmountFrom;
        private DropDownDataGrid ddgInvoice;
        private DropDownDataGrid ddgBankAccount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbAmountLogic;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.ComboBox cmbBankAccountLogic;
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
        private DropDownDataGrid ddgPayment;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPaymentLogic;
        private DropDownDataGrid ddgExemption;
        private System.Windows.Forms.Label lblExemption;
        private System.Windows.Forms.ComboBox cmbExemptionLogic;
        private System.Windows.Forms.CheckBox ckIsRefund;
    }
}