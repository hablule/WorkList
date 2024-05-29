namespace BuySimple
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
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblPayedFrom = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblPurchaseOrder = new System.Windows.Forms.Label();
            this.lblPaymentReason = new System.Windows.Forms.Label();
            this.txtInvoiceNumberFrom = new System.Windows.Forms.TextBox();
            this.grbSearchCriterion = new System.Windows.Forms.GroupBox();
            this.cmbShowRestult = new System.Windows.Forms.Button();
            this.ckIsDistributable = new System.Windows.Forms.CheckBox();
            this.ckIsEstimate = new System.Windows.Forms.CheckBox();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.cmbVendors = new System.Windows.Forms.ComboBox();
            this.cmbCommercialInvoiceLogic = new System.Windows.Forms.ComboBox();
            this.lblCommercialInvoice = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.txtInvoiceNumberTo = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpInvoiceDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbPaymentReasonLogic = new System.Windows.Forms.ComboBox();
            this.cmbPurchaseOrderLogic = new System.Windows.Forms.ComboBox();
            this.cmbAmountPaidLogic = new System.Windows.Forms.ComboBox();
            this.cmbPayedFromLogic = new System.Windows.Forms.ComboBox();
            this.cmbInvoiceDateLogic = new System.Windows.Forms.ComboBox();
            this.cmbVendorNameLogic = new System.Windows.Forms.ComboBox();
            this.cmbInvoiceNumberLogic = new System.Windows.Forms.ComboBox();
            this.ddgCommercialInvoice = new BuySimple.DropDownDataGrid();
            this.ntbInvoiceAmountTo = new BuySimple.ctlNumberTextBox();
            this.ntbInvoiceAmountFrom = new BuySimple.ctlNumberTextBox();
            this.ddgPayedFrom = new BuySimple.DropDownDataGrid();
            this.ddgPurchaseOrder = new BuySimple.DropDownDataGrid();
            this.ddgPaymentReason = new BuySimple.DropDownDataGrid();
            this.grbSearchCriterion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Location = new System.Drawing.Point(11, 25);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(91, 16);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Invoice Number";
            this.lblInvoiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendorName
            // 
            this.lblVendorName.Location = new System.Drawing.Point(11, 54);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(91, 16);
            this.lblVendorName.TabIndex = 1;
            this.lblVendorName.Text = "Vendor Name";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.Location = new System.Drawing.Point(11, 82);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(91, 16);
            this.lblInvoiceDate.TabIndex = 2;
            this.lblInvoiceDate.Text = "Invoice Date";
            this.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayedFrom
            // 
            this.lblPayedFrom.Location = new System.Drawing.Point(11, 110);
            this.lblPayedFrom.Name = "lblPayedFrom";
            this.lblPayedFrom.Size = new System.Drawing.Size(91, 16);
            this.lblPayedFrom.TabIndex = 3;
            this.lblPayedFrom.Text = "Payed From";
            this.lblPayedFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.Location = new System.Drawing.Point(11, 139);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(91, 16);
            this.lblAmountPaid.TabIndex = 4;
            this.lblAmountPaid.Text = "Amount Paid";
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPurchaseOrder
            // 
            this.lblPurchaseOrder.Location = new System.Drawing.Point(9, 201);
            this.lblPurchaseOrder.Name = "lblPurchaseOrder";
            this.lblPurchaseOrder.Size = new System.Drawing.Size(91, 16);
            this.lblPurchaseOrder.TabIndex = 5;
            this.lblPurchaseOrder.Text = "Purchase Order";
            this.lblPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentReason
            // 
            this.lblPaymentReason.Location = new System.Drawing.Point(8, 257);
            this.lblPaymentReason.Name = "lblPaymentReason";
            this.lblPaymentReason.Size = new System.Drawing.Size(91, 16);
            this.lblPaymentReason.TabIndex = 6;
            this.lblPaymentReason.Text = "Payment Reason";
            this.lblPaymentReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceNumberFrom
            // 
            this.txtInvoiceNumberFrom.Location = new System.Drawing.Point(236, 24);
            this.txtInvoiceNumberFrom.Name = "txtInvoiceNumberFrom";
            this.txtInvoiceNumberFrom.Size = new System.Drawing.Size(124, 20);
            this.txtInvoiceNumberFrom.TabIndex = 15;
            // 
            // grbSearchCriterion
            // 
            this.grbSearchCriterion.AutoSize = true;
            this.grbSearchCriterion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbSearchCriterion.Controls.Add(this.cmbShowRestult);
            this.grbSearchCriterion.Controls.Add(this.ckIsDistributable);
            this.grbSearchCriterion.Controls.Add(this.ckIsEstimate);
            this.grbSearchCriterion.Controls.Add(this.ckIsActive);
            this.grbSearchCriterion.Controls.Add(this.cmbVendors);
            this.grbSearchCriterion.Controls.Add(this.ddgCommercialInvoice);
            this.grbSearchCriterion.Controls.Add(this.cmbCommercialInvoiceLogic);
            this.grbSearchCriterion.Controls.Add(this.lblCommercialInvoice);
            this.grbSearchCriterion.Controls.Add(this.cmdSearch);
            this.grbSearchCriterion.Controls.Add(this.ckAllOrAny);
            this.grbSearchCriterion.Controls.Add(this.txtInvoiceNumberTo);
            this.grbSearchCriterion.Controls.Add(this.dtpInvoiceDateTo);
            this.grbSearchCriterion.Controls.Add(this.dtpInvoiceDateFrom);
            this.grbSearchCriterion.Controls.Add(this.ntbInvoiceAmountTo);
            this.grbSearchCriterion.Controls.Add(this.ntbInvoiceAmountFrom);
            this.grbSearchCriterion.Controls.Add(this.ddgPayedFrom);
            this.grbSearchCriterion.Controls.Add(this.ddgPurchaseOrder);
            this.grbSearchCriterion.Controls.Add(this.ddgPaymentReason);
            this.grbSearchCriterion.Controls.Add(this.cmbPaymentReasonLogic);
            this.grbSearchCriterion.Controls.Add(this.cmbPurchaseOrderLogic);
            this.grbSearchCriterion.Controls.Add(this.cmbAmountPaidLogic);
            this.grbSearchCriterion.Controls.Add(this.cmbPayedFromLogic);
            this.grbSearchCriterion.Controls.Add(this.cmbInvoiceDateLogic);
            this.grbSearchCriterion.Controls.Add(this.cmbVendorNameLogic);
            this.grbSearchCriterion.Controls.Add(this.cmbInvoiceNumberLogic);
            this.grbSearchCriterion.Controls.Add(this.lblPayedFrom);
            this.grbSearchCriterion.Controls.Add(this.txtInvoiceNumberFrom);
            this.grbSearchCriterion.Controls.Add(this.lblInvoiceNumber);
            this.grbSearchCriterion.Controls.Add(this.lblPaymentReason);
            this.grbSearchCriterion.Controls.Add(this.lblVendorName);
            this.grbSearchCriterion.Controls.Add(this.lblPurchaseOrder);
            this.grbSearchCriterion.Controls.Add(this.lblInvoiceDate);
            this.grbSearchCriterion.Controls.Add(this.lblAmountPaid);
            this.grbSearchCriterion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSearchCriterion.Location = new System.Drawing.Point(0, 0);
            this.grbSearchCriterion.Name = "grbSearchCriterion";
            this.grbSearchCriterion.Size = new System.Drawing.Size(574, 388);
            this.grbSearchCriterion.TabIndex = 16;
            this.grbSearchCriterion.TabStop = false;
            this.grbSearchCriterion.Text = "Search Criterion";
            // 
            // cmbShowRestult
            // 
            this.cmbShowRestult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShowRestult.Location = new System.Drawing.Point(187, 355);
            this.cmbShowRestult.Name = "cmbShowRestult";
            this.cmbShowRestult.Size = new System.Drawing.Size(172, 23);
            this.cmbShowRestult.TabIndex = 47;
            this.cmbShowRestult.Text = "Show Result";
            this.cmbShowRestult.UseVisualStyleBackColor = true;
            this.cmbShowRestult.Click += new System.EventHandler(this.cmbShowRestult_Click);
            // 
            // ckIsDistributable
            // 
            this.ckIsDistributable.AutoSize = true;
            this.ckIsDistributable.Checked = true;
            this.ckIsDistributable.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsDistributable.Location = new System.Drawing.Point(343, 168);
            this.ckIsDistributable.Name = "ckIsDistributable";
            this.ckIsDistributable.Size = new System.Drawing.Size(101, 17);
            this.ckIsDistributable.TabIndex = 46;
            this.ckIsDistributable.Text = "Is Distuributable";
            this.ckIsDistributable.ThreeState = true;
            this.ckIsDistributable.UseVisualStyleBackColor = true;
            // 
            // ckIsEstimate
            // 
            this.ckIsEstimate.AutoSize = true;
            this.ckIsEstimate.Checked = true;
            this.ckIsEstimate.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsEstimate.Location = new System.Drawing.Point(232, 168);
            this.ckIsEstimate.Name = "ckIsEstimate";
            this.ckIsEstimate.Size = new System.Drawing.Size(77, 17);
            this.ckIsEstimate.TabIndex = 45;
            this.ckIsEstimate.Text = "Is Estimate";
            this.ckIsEstimate.ThreeState = true;
            this.ckIsEstimate.UseVisualStyleBackColor = true;
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsActive.Location = new System.Drawing.Point(109, 168);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(67, 17);
            this.ckIsActive.TabIndex = 44;
            this.ckIsActive.Text = "Is Active";
            this.ckIsActive.ThreeState = true;
            this.ckIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbVendors
            // 
            this.cmbVendors.FormattingEnabled = true;
            this.cmbVendors.Location = new System.Drawing.Point(239, 53);
            this.cmbVendors.Name = "cmbVendors";
            this.cmbVendors.Size = new System.Drawing.Size(167, 21);
            this.cmbVendors.TabIndex = 43;
            this.cmbVendors.SelectedIndexChanged += new System.EventHandler(this.cmbVendors_SelectedIndexChanged);
            this.cmbVendors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbVendors_KeyUp);
            this.cmbVendors.DropDownClosed += new System.EventHandler(this.cmbVendors_DropDownClosed);
            // 
            // cmbCommercialInvoiceLogic
            // 
            this.cmbCommercialInvoiceLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommercialInvoiceLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbCommercialInvoiceLogic.Location = new System.Drawing.Point(107, 228);
            this.cmbCommercialInvoiceLogic.Name = "cmbCommercialInvoiceLogic";
            this.cmbCommercialInvoiceLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbCommercialInvoiceLogic.TabIndex = 40;
            this.cmbCommercialInvoiceLogic.SelectedIndexChanged += new System.EventHandler(this.cmbCommercialInvoiceLogic_SelectedIndexChanged);
            // 
            // lblCommercialInvoice
            // 
            this.lblCommercialInvoice.Location = new System.Drawing.Point(5, 231);
            this.lblCommercialInvoice.Name = "lblCommercialInvoice";
            this.lblCommercialInvoice.Size = new System.Drawing.Size(100, 16);
            this.lblCommercialInvoice.TabIndex = 41;
            this.lblCommercialInvoice.Text = "Commercial Invoice";
            this.lblCommercialInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(168, 324);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(216, 23);
            this.cmdSearch.TabIndex = 35;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(106, 291);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(320, 24);
            this.ckAllOrAny.TabIndex = 34;
            this.ckAllOrAny.Text = "Display Results That fully fills Any Criteria ";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // txtInvoiceNumberTo
            // 
            this.txtInvoiceNumberTo.Location = new System.Drawing.Point(368, 24);
            this.txtInvoiceNumberTo.Name = "txtInvoiceNumberTo";
            this.txtInvoiceNumberTo.Size = new System.Drawing.Size(124, 20);
            this.txtInvoiceNumberTo.TabIndex = 31;
            this.txtInvoiceNumberTo.Visible = false;
            // 
            // dtpInvoiceDateTo
            // 
            this.dtpInvoiceDateTo.CustomFormat = "dd-MM-yyyy";
            this.dtpInvoiceDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDateTo.Location = new System.Drawing.Point(366, 82);
            this.dtpInvoiceDateTo.Name = "dtpInvoiceDateTo";
            this.dtpInvoiceDateTo.Size = new System.Drawing.Size(126, 20);
            this.dtpInvoiceDateTo.TabIndex = 30;
            this.dtpInvoiceDateTo.Visible = false;
            // 
            // dtpInvoiceDateFrom
            // 
            this.dtpInvoiceDateFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpInvoiceDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDateFrom.Location = new System.Drawing.Point(236, 82);
            this.dtpInvoiceDateFrom.Name = "dtpInvoiceDateFrom";
            this.dtpInvoiceDateFrom.Size = new System.Drawing.Size(122, 20);
            this.dtpInvoiceDateFrom.TabIndex = 29;
            this.dtpInvoiceDateFrom.Value = new System.DateTime(2009, 12, 27, 0, 0, 0, 0);
            // 
            // cmbPaymentReasonLogic
            // 
            this.cmbPaymentReasonLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentReasonLogic.FormattingEnabled = true;
            this.cmbPaymentReasonLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPaymentReasonLogic.Location = new System.Drawing.Point(107, 256);
            this.cmbPaymentReasonLogic.Name = "cmbPaymentReasonLogic";
            this.cmbPaymentReasonLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbPaymentReasonLogic.TabIndex = 22;
            this.cmbPaymentReasonLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentReasonLogic_SelectedIndexChanged);
            // 
            // cmbPurchaseOrderLogic
            // 
            this.cmbPurchaseOrderLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPurchaseOrderLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPurchaseOrderLogic.Location = new System.Drawing.Point(107, 200);
            this.cmbPurchaseOrderLogic.Name = "cmbPurchaseOrderLogic";
            this.cmbPurchaseOrderLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbPurchaseOrderLogic.TabIndex = 0;
            this.cmbPurchaseOrderLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPurchaseOrderLogic_SelectedIndexChanged);
            // 
            // cmbAmountPaidLogic
            // 
            this.cmbAmountPaidLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmountPaidLogic.FormattingEnabled = true;
            this.cmbAmountPaidLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbAmountPaidLogic.Location = new System.Drawing.Point(107, 138);
            this.cmbAmountPaidLogic.Name = "cmbAmountPaidLogic";
            this.cmbAmountPaidLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbAmountPaidLogic.TabIndex = 20;
            this.cmbAmountPaidLogic.SelectedIndexChanged += new System.EventHandler(this.cmbAmountPaidLogic_SelectedIndexChanged);
            // 
            // cmbPayedFromLogic
            // 
            this.cmbPayedFromLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayedFromLogic.FormattingEnabled = true;
            this.cmbPayedFromLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPayedFromLogic.Location = new System.Drawing.Point(107, 109);
            this.cmbPayedFromLogic.Name = "cmbPayedFromLogic";
            this.cmbPayedFromLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbPayedFromLogic.TabIndex = 19;
            this.cmbPayedFromLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPayedFromLogic_SelectedIndexChanged);
            // 
            // cmbInvoiceDateLogic
            // 
            this.cmbInvoiceDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceDateLogic.FormattingEnabled = true;
            this.cmbInvoiceDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbInvoiceDateLogic.Location = new System.Drawing.Point(107, 81);
            this.cmbInvoiceDateLogic.Name = "cmbInvoiceDateLogic";
            this.cmbInvoiceDateLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbInvoiceDateLogic.TabIndex = 18;
            this.cmbInvoiceDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceDateLogic_SelectedIndexChanged);
            // 
            // cmbVendorNameLogic
            // 
            this.cmbVendorNameLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendorNameLogic.FormattingEnabled = true;
            this.cmbVendorNameLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbVendorNameLogic.Location = new System.Drawing.Point(107, 53);
            this.cmbVendorNameLogic.Name = "cmbVendorNameLogic";
            this.cmbVendorNameLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbVendorNameLogic.TabIndex = 17;
            this.cmbVendorNameLogic.SelectedIndexChanged += new System.EventHandler(this.cmbVendorNameLogic_SelectedIndexChanged);
            // 
            // cmbInvoiceNumberLogic
            // 
            this.cmbInvoiceNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceNumberLogic.FormattingEnabled = true;
            this.cmbInvoiceNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbInvoiceNumberLogic.Location = new System.Drawing.Point(107, 24);
            this.cmbInvoiceNumberLogic.Name = "cmbInvoiceNumberLogic";
            this.cmbInvoiceNumberLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbInvoiceNumberLogic.TabIndex = 16;
            this.cmbInvoiceNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceNumberLogic_SelectedIndexChanged);
            // 
            // ddgCommercialInvoice
            // 
            this.ddgCommercialInvoice.AutoFilter = true;
            this.ddgCommercialInvoice.AutoSize = true;
            this.ddgCommercialInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgCommercialInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgCommercialInvoice.ClearButtonEnabled = true;
            this.ddgCommercialInvoice.DataTablePrimaryKey = ((ushort)(0));
            this.ddgCommercialInvoice.FindButtonEnabled = true;
            this.ddgCommercialInvoice.HiddenColoumns = new int[0];
            this.ddgCommercialInvoice.Image = null;
            this.ddgCommercialInvoice.Location = new System.Drawing.Point(232, 223);
            this.ddgCommercialInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCommercialInvoice.Name = "ddgCommercialInvoice";
            this.ddgCommercialInvoice.NewButtonEnabled = true;
            this.ddgCommercialInvoice.RefreshButtonEnabled = true;
            this.ddgCommercialInvoice.SelectedColomnIdex = 0;
            this.ddgCommercialInvoice.SelectedItem = "";
            this.ddgCommercialInvoice.SelectedRowKey = null;
            this.ddgCommercialInvoice.ShowGridFunctions = false;
            this.ddgCommercialInvoice.Size = new System.Drawing.Size(332, 31);
            this.ddgCommercialInvoice.TabIndex = 42;
            this.ddgCommercialInvoice.SelectedItemClicked += new System.EventHandler(this.ddgCommercialInvoice_SelectedItemClicked);
            // 
            // ntbInvoiceAmountTo
            // 
            this.ntbInvoiceAmountTo.Amount = "";
            this.ntbInvoiceAmountTo.Location = new System.Drawing.Point(378, 137);
            this.ntbInvoiceAmountTo.Name = "ntbInvoiceAmountTo";
            this.ntbInvoiceAmountTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbInvoiceAmountTo.Size = new System.Drawing.Size(138, 23);
            this.ntbInvoiceAmountTo.TabIndex = 28;
            this.ntbInvoiceAmountTo.Visible = false;
            // 
            // ntbInvoiceAmountFrom
            // 
            this.ntbInvoiceAmountFrom.Amount = "";
            this.ntbInvoiceAmountFrom.Location = new System.Drawing.Point(234, 137);
            this.ntbInvoiceAmountFrom.Name = "ntbInvoiceAmountFrom";
            this.ntbInvoiceAmountFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbInvoiceAmountFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbInvoiceAmountFrom.TabIndex = 27;
            // 
            // ddgPayedFrom
            // 
            this.ddgPayedFrom.AutoFilter = true;
            this.ddgPayedFrom.AutoSize = true;
            this.ddgPayedFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPayedFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPayedFrom.ClearButtonEnabled = true;
            this.ddgPayedFrom.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPayedFrom.FindButtonEnabled = true;
            this.ddgPayedFrom.HiddenColoumns = new int[0];
            this.ddgPayedFrom.Image = null;
            this.ddgPayedFrom.Location = new System.Drawing.Point(232, 105);
            this.ddgPayedFrom.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPayedFrom.Name = "ddgPayedFrom";
            this.ddgPayedFrom.NewButtonEnabled = true;
            this.ddgPayedFrom.RefreshButtonEnabled = true;
            this.ddgPayedFrom.SelectedColomnIdex = 0;
            this.ddgPayedFrom.SelectedItem = "";
            this.ddgPayedFrom.SelectedRowKey = null;
            this.ddgPayedFrom.ShowGridFunctions = false;
            this.ddgPayedFrom.Size = new System.Drawing.Size(319, 31);
            this.ddgPayedFrom.TabIndex = 25;
            this.ddgPayedFrom.SelectedItemClicked += new System.EventHandler(this.ddgPayedFrom_SelectedItemClicked);
            // 
            // ddgPurchaseOrder
            // 
            this.ddgPurchaseOrder.AutoFilter = true;
            this.ddgPurchaseOrder.AutoSize = true;
            this.ddgPurchaseOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPurchaseOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPurchaseOrder.ClearButtonEnabled = true;
            this.ddgPurchaseOrder.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPurchaseOrder.FindButtonEnabled = true;
            this.ddgPurchaseOrder.HiddenColoumns = new int[0];
            this.ddgPurchaseOrder.Image = null;
            this.ddgPurchaseOrder.Location = new System.Drawing.Point(232, 195);
            this.ddgPurchaseOrder.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPurchaseOrder.Name = "ddgPurchaseOrder";
            this.ddgPurchaseOrder.NewButtonEnabled = true;
            this.ddgPurchaseOrder.RefreshButtonEnabled = true;
            this.ddgPurchaseOrder.SelectedColomnIdex = 0;
            this.ddgPurchaseOrder.SelectedItem = "";
            this.ddgPurchaseOrder.SelectedRowKey = null;
            this.ddgPurchaseOrder.ShowGridFunctions = false;
            this.ddgPurchaseOrder.Size = new System.Drawing.Size(332, 31);
            this.ddgPurchaseOrder.TabIndex = 24;
            this.ddgPurchaseOrder.SelectedItemClicked += new System.EventHandler(this.ddgPurchaseOrder_SelectedItemClicked);
            // 
            // ddgPaymentReason
            // 
            this.ddgPaymentReason.AutoFilter = true;
            this.ddgPaymentReason.AutoSize = true;
            this.ddgPaymentReason.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPaymentReason.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPaymentReason.ClearButtonEnabled = true;
            this.ddgPaymentReason.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPaymentReason.FindButtonEnabled = true;
            this.ddgPaymentReason.HiddenColoumns = new int[0];
            this.ddgPaymentReason.Image = null;
            this.ddgPaymentReason.Location = new System.Drawing.Point(233, 251);
            this.ddgPaymentReason.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPaymentReason.Name = "ddgPaymentReason";
            this.ddgPaymentReason.NewButtonEnabled = true;
            this.ddgPaymentReason.RefreshButtonEnabled = true;
            this.ddgPaymentReason.SelectedColomnIdex = 0;
            this.ddgPaymentReason.SelectedItem = "";
            this.ddgPaymentReason.SelectedRowKey = null;
            this.ddgPaymentReason.ShowGridFunctions = false;
            this.ddgPaymentReason.Size = new System.Drawing.Size(190, 31);
            this.ddgPaymentReason.TabIndex = 23;
            this.ddgPaymentReason.SelectedItemClicked += new System.EventHandler(this.ddgPaymentReason_SelectedItemClicked);
            // 
            // frmSearchPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(574, 388);
            this.Controls.Add(this.grbSearchCriterion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchPayment";
            this.Text = "Lookup Payment Records";
            this.Load += new System.EventHandler(this.frmSearchPayment_Load);
            this.grbSearchCriterion.ResumeLayout(false);
            this.grbSearchCriterion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblPayedFrom;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblPurchaseOrder;
        private System.Windows.Forms.Label lblPaymentReason;
        private System.Windows.Forms.TextBox txtInvoiceNumberFrom;
        private System.Windows.Forms.GroupBox grbSearchCriterion;
        private System.Windows.Forms.ComboBox cmbInvoiceNumberLogic;
        private System.Windows.Forms.ComboBox cmbPaymentReasonLogic;
        private System.Windows.Forms.ComboBox cmbPurchaseOrderLogic;
        private System.Windows.Forms.ComboBox cmbAmountPaidLogic;
        private System.Windows.Forms.ComboBox cmbPayedFromLogic;
        private System.Windows.Forms.ComboBox cmbInvoiceDateLogic;
        private System.Windows.Forms.ComboBox cmbVendorNameLogic;
        private DropDownDataGrid ddgPayedFrom;
        private DropDownDataGrid ddgPurchaseOrder;
        private DropDownDataGrid ddgPaymentReason;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDateFrom;
        private ctlNumberTextBox ntbInvoiceAmountTo;
        private ctlNumberTextBox ntbInvoiceAmountFrom;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.TextBox txtInvoiceNumberTo;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDateTo;
        private System.Windows.Forms.Button cmdSearch;
        private DropDownDataGrid ddgCommercialInvoice;
        private System.Windows.Forms.ComboBox cmbCommercialInvoiceLogic;
        private System.Windows.Forms.Label lblCommercialInvoice;
        private System.Windows.Forms.ComboBox cmbVendors;
        private System.Windows.Forms.CheckBox ckIsEstimate;
        private System.Windows.Forms.CheckBox ckIsActive;
        private System.Windows.Forms.CheckBox ckIsDistributable;
        private System.Windows.Forms.Button cmbShowRestult;
    }
}