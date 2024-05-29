namespace POSDocumentPrinter
{
    partial class frmCashReceiptVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashReceiptVoucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsCommandToolBar = new System.Windows.Forms.ToolStrip();
            this.tlsNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlsReject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.tlsChangeView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsPrint = new System.Windows.Forms.ToolStripButton();
            this.tlsExit = new System.Windows.Forms.ToolStripButton();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblUnallocatedAmt = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.lblAmountReceived = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblOverUnderAmount = new System.Windows.Forms.Label();
            this.grbPaymentDetail = new System.Windows.Forms.GroupBox();
            this.lblOtherIncome = new System.Windows.Forms.Label();
            this.ckIsExemption = new System.Windows.Forms.CheckBox();
            this.txtOverUnderAmt = new System.Windows.Forms.TextBox();
            this.txtDescriptionDtl = new System.Windows.Forms.TextBox();
            this.lblDescriptionDtl = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.txtAmountDue = new System.Windows.Forms.TextBox();
            this.sbStatusLabel = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgReceiptDtl = new System.Windows.Forms.DataGridView();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.txtUnAllocatedAmount = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescriptionMain = new System.Windows.Forms.TextBox();
            this.lblDescriptionMain = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dtgReceiptSummary = new System.Windows.Forms.DataGridView();
            this.lblPaidBy = new System.Windows.Forms.Label();
            this.cmbTenderType = new System.Windows.Forms.ComboBox();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.txtOrganisation = new System.Windows.Forms.TextBox();
            this.ckIsBillingPartener = new System.Windows.Forms.CheckBox();
            this.ckIsDownPayment = new System.Windows.Forms.CheckBox();
            this.cmdAllocate = new System.Windows.Forms.Button();
            this.ckIsOtherIncome = new System.Windows.Forms.CheckBox();
            this.ddgOtherIncome = new POSDocumentPrinter.DropDownDataGrid();
            this.ddgCustomers = new POSDocumentPrinter.DropDownDataGrid();
            this.ntbTotalPayedAmount = new POSDocumentPrinter.ctlNumberTextBox();
            this.ddgInvoice = new POSDocumentPrinter.DropDownDataGrid();
            this.ntbAmountPaid = new POSDocumentPrinter.ctlNumberTextBox();
            this.sbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsCommandToolBar.SuspendLayout();
            this.grbPaymentDetail.SuspendLayout();
            this.sbStatusLabel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsCommandToolBar
            // 
            this.tlsCommandToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsCommandToolBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlsCommandToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNew,
            this.tlsSave,
            this.tlsDelete,
            this.toolStripSeparator2,
            this.tlsConfirm,
            this.tlsReject,
            this.toolStripSeparator3,
            this.tlsSearch,
            this.tlsChangeView,
            this.toolStripSeparator1,
            this.tlsFirstRecord,
            this.tlsPreviousRecord,
            this.tlsNextRecord,
            this.tlsLastRecord,
            this.toolStripSeparator4,
            this.tlsPrint,
            this.tlsExit});
            this.tlsCommandToolBar.Location = new System.Drawing.Point(0, 24);
            this.tlsCommandToolBar.Margin = new System.Windows.Forms.Padding(1);
            this.tlsCommandToolBar.Name = "tlsCommandToolBar";
            this.tlsCommandToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tlsCommandToolBar.Size = new System.Drawing.Size(544, 54);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.Image = ((System.Drawing.Image)(resources.GetObject("tlsNew.Image")));
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(36, 51);
            this.tlsNew.Text = "New";
            this.tlsNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.Enabled = false;
            this.tlsSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsSave.Image")));
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(36, 51);
            this.tlsSave.Text = "Save";
            this.tlsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.Enabled = false;
            this.tlsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlsDelete.Image")));
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(44, 51);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tlsConfirm
            // 
            this.tlsConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tlsConfirm.Image")));
            this.tlsConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsConfirm.Name = "tlsConfirm";
            this.tlsConfirm.Size = new System.Drawing.Size(55, 51);
            this.tlsConfirm.Text = "Confirm";
            this.tlsConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsConfirm.Click += new System.EventHandler(this.tlsConfirm_Click);
            // 
            // tlsReject
            // 
            this.tlsReject.Enabled = false;
            this.tlsReject.Image = ((System.Drawing.Image)(resources.GetObject("tlsReject.Image")));
            this.tlsReject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsReject.Name = "tlsReject";
            this.tlsReject.Size = new System.Drawing.Size(43, 51);
            this.tlsReject.Text = "Reject";
            this.tlsReject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // tlsSearch
            // 
            this.tlsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlsSearch.Image")));
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(46, 51);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // tlsChangeView
            // 
            this.tlsChangeView.Image = ((System.Drawing.Image)(resources.GetObject("tlsChangeView.Image")));
            this.tlsChangeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsChangeView.Name = "tlsChangeView";
            this.tlsChangeView.Size = new System.Drawing.Size(36, 51);
            this.tlsChangeView.Text = "Grid";
            this.tlsChangeView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsChangeView.Click += new System.EventHandler(this.tlsChangeView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsFirstRecord.Image")));
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(36, 51);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsFirstRecord.Click += new System.EventHandler(this.tlsFirstRecord_Click);
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsPreviousRecord.Image")));
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(56, 51);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsPreviousRecord.Click += new System.EventHandler(this.tlsPreviousRecord_Click);
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsNextRecord.Image")));
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(36, 51);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsNextRecord.Click += new System.EventHandler(this.tlsNextRecord_Click);
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsLastRecord.Image")));
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(36, 51);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsLastRecord.Click += new System.EventHandler(this.tlsLastRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // tlsPrint
            // 
            this.tlsPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsPrint.Image")));
            this.tlsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPrint.Name = "tlsPrint";
            this.tlsPrint.Size = new System.Drawing.Size(36, 51);
            this.tlsPrint.Text = "Print";
            this.tlsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsPrint.Click += new System.EventHandler(this.tlsPrint_Click);
            // 
            // tlsExit
            // 
            this.tlsExit.Image = ((System.Drawing.Image)(resources.GetObject("tlsExit.Image")));
            this.tlsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsExit.Name = "tlsExit";
            this.tlsExit.Size = new System.Drawing.Size(36, 51);
            this.tlsExit.Text = "Exit";
            this.tlsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsExit.Click += new System.EventHandler(this.tlsExit_Click);
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Location = new System.Drawing.Point(15, 96);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(66, 13);
            this.lblOrganisation.TabIndex = 1;
            this.lblOrganisation.Text = "Organisation";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(25, 119);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(56, 13);
            this.lblDocumentNo.TabIndex = 2;
            this.lblDocumentNo.Text = "Document";
            // 
            // lblUnallocatedAmt
            // 
            this.lblUnallocatedAmt.AutoSize = true;
            this.lblUnallocatedAmt.Location = new System.Drawing.Point(416, 238);
            this.lblUnallocatedAmt.Name = "lblUnallocatedAmt";
            this.lblUnallocatedAmt.Size = new System.Drawing.Size(107, 13);
            this.lblUnallocatedAmt.TabIndex = 3;
            this.lblUnallocatedAmt.Text = "Un Allocated Amount";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(271, 118);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(54, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date Paid";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(30, 144);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(51, 13);
            this.lblCustomers.TabIndex = 5;
            this.lblCustomers.Text = "Customer";
            // 
            // lblAmountReceived
            // 
            this.lblAmountReceived.AutoSize = true;
            this.lblAmountReceived.Location = new System.Drawing.Point(28, 176);
            this.lblAmountReceived.Name = "lblAmountReceived";
            this.lblAmountReceived.Size = new System.Drawing.Size(53, 13);
            this.lblAmountReceived.TabIndex = 6;
            this.lblAmountReceived.Text = "Received";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(46, 24);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(42, 13);
            this.lblInvoice.TabIndex = 7;
            this.lblInvoice.Text = "Invoice";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Location = new System.Drawing.Point(21, 79);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(66, 13);
            this.lblAmountDue.TabIndex = 8;
            this.lblAmountDue.Text = "Amount Due";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Location = new System.Drawing.Point(22, 51);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(67, 13);
            this.lblAmountPaid.TabIndex = 9;
            this.lblAmountPaid.Text = "Amount Paid";
            // 
            // lblOverUnderAmount
            // 
            this.lblOverUnderAmount.AutoSize = true;
            this.lblOverUnderAmount.Location = new System.Drawing.Point(261, 79);
            this.lblOverUnderAmount.Name = "lblOverUnderAmount";
            this.lblOverUnderAmount.Size = new System.Drawing.Size(85, 13);
            this.lblOverUnderAmount.TabIndex = 10;
            this.lblOverUnderAmount.Text = "Over/Under Amt";
            // 
            // grbPaymentDetail
            // 
            this.grbPaymentDetail.BackColor = System.Drawing.SystemColors.Control;
            this.grbPaymentDetail.Controls.Add(this.ckIsExemption);
            this.grbPaymentDetail.Controls.Add(this.txtOverUnderAmt);
            this.grbPaymentDetail.Controls.Add(this.txtDescriptionDtl);
            this.grbPaymentDetail.Controls.Add(this.lblDescriptionDtl);
            this.grbPaymentDetail.Controls.Add(this.cmdAdd);
            this.grbPaymentDetail.Controls.Add(this.ddgInvoice);
            this.grbPaymentDetail.Controls.Add(this.ntbAmountPaid);
            this.grbPaymentDetail.Controls.Add(this.lblInvoice);
            this.grbPaymentDetail.Controls.Add(this.lblOverUnderAmount);
            this.grbPaymentDetail.Controls.Add(this.lblAmountDue);
            this.grbPaymentDetail.Controls.Add(this.txtAmountDue);
            this.grbPaymentDetail.Controls.Add(this.lblAmountPaid);
            this.grbPaymentDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbPaymentDetail.Location = new System.Drawing.Point(17, 317);
            this.grbPaymentDetail.Name = "grbPaymentDetail";
            this.grbPaymentDetail.Size = new System.Drawing.Size(496, 178);
            this.grbPaymentDetail.TabIndex = 11;
            this.grbPaymentDetail.TabStop = false;
            this.grbPaymentDetail.Text = "Customer Pyament Detail";
            // 
            // lblOtherIncome
            // 
            this.lblOtherIncome.AutoSize = true;
            this.lblOtherIncome.Location = new System.Drawing.Point(10, 233);
            this.lblOtherIncome.Name = "lblOtherIncome";
            this.lblOtherIncome.Size = new System.Drawing.Size(71, 13);
            this.lblOtherIncome.TabIndex = 29;
            this.lblOtherIncome.Text = "Other Income";
            // 
            // ckIsExemption
            // 
            this.ckIsExemption.AutoSize = true;
            this.ckIsExemption.Location = new System.Drawing.Point(398, 22);
            this.ckIsExemption.Name = "ckIsExemption";
            this.ckIsExemption.Size = new System.Drawing.Size(86, 17);
            this.ckIsExemption.TabIndex = 28;
            this.ckIsExemption.Text = "Is Exemption";
            this.ckIsExemption.UseVisualStyleBackColor = true;
            this.ckIsExemption.CheckedChanged += new System.EventHandler(this.ckIsExemption_CheckedChanged);
            // 
            // txtOverUnderAmt
            // 
            this.txtOverUnderAmt.Enabled = false;
            this.txtOverUnderAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverUnderAmt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtOverUnderAmt.Location = new System.Drawing.Point(352, 76);
            this.txtOverUnderAmt.Name = "txtOverUnderAmt";
            this.txtOverUnderAmt.Size = new System.Drawing.Size(119, 20);
            this.txtOverUnderAmt.TabIndex = 27;
            this.txtOverUnderAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescriptionDtl
            // 
            this.txtDescriptionDtl.Location = new System.Drawing.Point(84, 108);
            this.txtDescriptionDtl.Multiline = true;
            this.txtDescriptionDtl.Name = "txtDescriptionDtl";
            this.txtDescriptionDtl.Size = new System.Drawing.Size(281, 60);
            this.txtDescriptionDtl.TabIndex = 26;
            // 
            // lblDescriptionDtl
            // 
            this.lblDescriptionDtl.Location = new System.Drawing.Point(19, 110);
            this.lblDescriptionDtl.Name = "lblDescriptionDtl";
            this.lblDescriptionDtl.Size = new System.Drawing.Size(61, 55);
            this.lblDescriptionDtl.TabIndex = 25;
            this.lblDescriptionDtl.Text = "Description/Comment";
            this.lblDescriptionDtl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(375, 111);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(96, 54);
            this.cmdAdd.TabIndex = 24;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.Enabled = false;
            this.txtAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountDue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtAmountDue.Location = new System.Drawing.Point(93, 77);
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.Size = new System.Drawing.Size(152, 20);
            this.txtAmountDue.TabIndex = 17;
            this.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sbStatusLabel
            // 
            this.sbStatusLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbStatus});
            this.sbStatusLabel.Location = new System.Drawing.Point(0, 652);
            this.sbStatusLabel.Name = "sbStatusLabel";
            this.sbStatusLabel.Size = new System.Drawing.Size(544, 22);
            this.sbStatusLabel.TabIndex = 13;
            this.sbStatusLabel.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgReceiptDtl);
            this.panel1.Location = new System.Drawing.Point(8, 499);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 147);
            this.panel1.TabIndex = 14;
            // 
            // dtgReceiptDtl
            // 
            this.dtgReceiptDtl.AllowUserToAddRows = false;
            this.dtgReceiptDtl.AllowUserToDeleteRows = false;
            this.dtgReceiptDtl.AllowUserToResizeColumns = false;
            this.dtgReceiptDtl.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptDtl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgReceiptDtl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptDtl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgReceiptDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptDtl.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgReceiptDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReceiptDtl.Location = new System.Drawing.Point(0, 0);
            this.dtgReceiptDtl.MultiSelect = false;
            this.dtgReceiptDtl.Name = "dtgReceiptDtl";
            this.dtgReceiptDtl.ReadOnly = true;
            this.dtgReceiptDtl.RowHeadersVisible = false;
            this.dtgReceiptDtl.RowHeadersWidth = 20;
            this.dtgReceiptDtl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReceiptDtl.Size = new System.Drawing.Size(529, 147);
            this.dtgReceiptDtl.TabIndex = 0;
            this.dtgReceiptDtl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReceiptDtl_CellClick);
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(86, 92);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(150, 21);
            this.cmbOrganisation.TabIndex = 15;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(86, 116);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(176, 20);
            this.txtDocumentNo.TabIndex = 16;
            this.txtDocumentNo.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            // 
            // txtUnAllocatedAmount
            // 
            this.txtUnAllocatedAmount.Enabled = false;
            this.txtUnAllocatedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnAllocatedAmount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtUnAllocatedAmount.Location = new System.Drawing.Point(409, 254);
            this.txtUnAllocatedAmount.Name = "txtUnAllocatedAmount";
            this.txtUnAllocatedAmount.Size = new System.Drawing.Size(129, 20);
            this.txtUnAllocatedAmount.TabIndex = 18;
            this.txtUnAllocatedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(330, 115);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 23;
            // 
            // txtDescriptionMain
            // 
            this.txtDescriptionMain.Location = new System.Drawing.Point(87, 260);
            this.txtDescriptionMain.Multiline = true;
            this.txtDescriptionMain.Name = "txtDescriptionMain";
            this.txtDescriptionMain.Size = new System.Drawing.Size(257, 54);
            this.txtDescriptionMain.TabIndex = 24;
            // 
            // lblDescriptionMain
            // 
            this.lblDescriptionMain.Location = new System.Drawing.Point(17, 265);
            this.lblDescriptionMain.Name = "lblDescriptionMain";
            this.lblDescriptionMain.Size = new System.Drawing.Size(64, 42);
            this.lblDescriptionMain.TabIndex = 27;
            this.lblDescriptionMain.Text = "Description/Comment";
            this.lblDescriptionMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dtgReceiptSummary
            // 
            this.dtgReceiptSummary.AllowUserToAddRows = false;
            this.dtgReceiptSummary.AllowUserToDeleteRows = false;
            this.dtgReceiptSummary.AllowUserToResizeColumns = false;
            this.dtgReceiptSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.dtgReceiptSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgReceiptSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgReceiptSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptSummary.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgReceiptSummary.Location = new System.Drawing.Point(4, 78);
            this.dtgReceiptSummary.MultiSelect = false;
            this.dtgReceiptSummary.Name = "dtgReceiptSummary";
            this.dtgReceiptSummary.ReadOnly = true;
            this.dtgReceiptSummary.RowHeadersWidth = 20;
            this.dtgReceiptSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReceiptSummary.Size = new System.Drawing.Size(538, 10);
            this.dtgReceiptSummary.TabIndex = 29;
            this.dtgReceiptSummary.Visible = false;
            this.dtgReceiptSummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgReceiptSummary_ColumnHeaderMouseClick);
            this.dtgReceiptSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReceiptSummary_CellClick);
            this.dtgReceiptSummary.SelectionChanged += new System.EventHandler(this.dtgReceiptSummary_SelectionChanged);
            // 
            // lblPaidBy
            // 
            this.lblPaidBy.AutoSize = true;
            this.lblPaidBy.Location = new System.Drawing.Point(38, 200);
            this.lblPaidBy.Name = "lblPaidBy";
            this.lblPaidBy.Size = new System.Drawing.Size(43, 13);
            this.lblPaidBy.TabIndex = 30;
            this.lblPaidBy.Text = "Paid By";
            // 
            // cmbTenderType
            // 
            this.cmbTenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenderType.FormattingEnabled = true;
            this.cmbTenderType.Items.AddRange(new object[] {
            "Cash",
            "Check",
            "CPO"});
            this.cmbTenderType.Location = new System.Drawing.Point(86, 196);
            this.cmbTenderType.Name = "cmbTenderType";
            this.cmbTenderType.Size = new System.Drawing.Size(95, 21);
            this.cmbTenderType.TabIndex = 31;
            this.cmbTenderType.SelectedIndexChanged += new System.EventHandler(this.cmbTenderType_SelectedIndexChanged);
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstrumentNo.Location = new System.Drawing.Point(187, 196);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(176, 20);
            this.txtInstrumentNo.TabIndex = 32;
            this.txtInstrumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInstrumentNo.Visible = false;
            this.txtInstrumentNo.WordWrap = false;
            this.txtInstrumentNo.Leave += new System.EventHandler(this.txtInstrumentNo_Leave);
            // 
            // txtOrganisation
            // 
            this.txtOrganisation.AcceptsReturn = true;
            this.txtOrganisation.Enabled = false;
            this.txtOrganisation.Location = new System.Drawing.Point(87, 92);
            this.txtOrganisation.Name = "txtOrganisation";
            this.txtOrganisation.Size = new System.Drawing.Size(175, 20);
            this.txtOrganisation.TabIndex = 33;
            this.txtOrganisation.Visible = false;
            // 
            // ckIsBillingPartener
            // 
            this.ckIsBillingPartener.AutoSize = true;
            this.ckIsBillingPartener.Location = new System.Drawing.Point(432, 144);
            this.ckIsBillingPartener.Name = "ckIsBillingPartener";
            this.ckIsBillingPartener.Size = new System.Drawing.Size(94, 17);
            this.ckIsBillingPartener.TabIndex = 34;
            this.ckIsBillingPartener.Text = "Paying Person";
            this.ckIsBillingPartener.UseVisualStyleBackColor = true;
            // 
            // ckIsDownPayment
            // 
            this.ckIsDownPayment.AutoSize = true;
            this.ckIsDownPayment.Location = new System.Drawing.Point(306, 175);
            this.ckIsDownPayment.Name = "ckIsDownPayment";
            this.ckIsDownPayment.Size = new System.Drawing.Size(124, 17);
            this.ckIsDownPayment.TabIndex = 35;
            this.ckIsDownPayment.Text = "Is Advance Payment";
            this.ckIsDownPayment.UseVisualStyleBackColor = true;
            this.ckIsDownPayment.CheckedChanged += new System.EventHandler(this.ckIsDownPayment_CheckedChanged);
            // 
            // cmdAllocate
            // 
            this.cmdAllocate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAllocate.ForeColor = System.Drawing.Color.Red;
            this.cmdAllocate.Location = new System.Drawing.Point(409, 195);
            this.cmdAllocate.Name = "cmdAllocate";
            this.cmdAllocate.Size = new System.Drawing.Size(120, 37);
            this.cmdAllocate.TabIndex = 36;
            this.cmdAllocate.Text = "Allocate";
            this.cmdAllocate.UseVisualStyleBackColor = true;
            this.cmdAllocate.Click += new System.EventHandler(this.cmdAllocate_Click);
            // 
            // ckIsOtherIncome
            // 
            this.ckIsOtherIncome.AutoSize = true;
            this.ckIsOtherIncome.Location = new System.Drawing.Point(305, 232);
            this.ckIsOtherIncome.Name = "ckIsOtherIncome";
            this.ckIsOtherIncome.Size = new System.Drawing.Size(90, 17);
            this.ckIsOtherIncome.TabIndex = 37;
            this.ckIsOtherIncome.Text = "Other Income";
            this.ckIsOtherIncome.UseVisualStyleBackColor = true;
            this.ckIsOtherIncome.CheckedChanged += new System.EventHandler(this.ckIsOtherIncome_CheckedChanged);
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
            this.ddgOtherIncome.Location = new System.Drawing.Point(82, 225);
            this.ddgOtherIncome.Margin = new System.Windows.Forms.Padding(0);
            this.ddgOtherIncome.Name = "ddgOtherIncome";
            this.ddgOtherIncome.NewButtonEnabled = true;
            this.ddgOtherIncome.RefreshButtonEnabled = true;
            this.ddgOtherIncome.SelectedColomnIdex = 0;
            this.ddgOtherIncome.SelectedItem = "";
            this.ddgOtherIncome.SelectedRowKey = null;
            this.ddgOtherIncome.ShowGridFunctions = false;
            this.ddgOtherIncome.Size = new System.Drawing.Size(218, 31);
            this.ddgOtherIncome.TabIndex = 30;
            this.ddgOtherIncome.SelectedItemClicked += new System.EventHandler(this.ddgOtherIncome_SelectedItemClicked);
            this.ddgOtherIncome.selectedItemChanged += new System.EventHandler(this.ddgOtherIncome_selectedItemChanged);
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
            this.ddgCustomers.Location = new System.Drawing.Point(82, 136);
            this.ddgCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCustomers.Name = "ddgCustomers";
            this.ddgCustomers.NewButtonEnabled = true;
            this.ddgCustomers.RefreshButtonEnabled = true;
            this.ddgCustomers.SelectedColomnIdex = 0;
            this.ddgCustomers.SelectedItem = "";
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.ShowGridFunctions = false;
            this.ddgCustomers.Size = new System.Drawing.Size(346, 31);
            this.ddgCustomers.TabIndex = 22;
            this.ddgCustomers.SelectedItemClicked += new System.EventHandler(this.ddgCustomer_SelectedItemClicked);
            this.ddgCustomers.selectedItemChanged += new System.EventHandler(this.ddgCustomer_selectedItemChanged);
            // 
            // ntbTotalPayedAmount
            // 
            this.ntbTotalPayedAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTotalPayedAmount.AllowedLength = 0;
            this.ntbTotalPayedAmount.AllowLeadingZeros = false;
            this.ntbTotalPayedAmount.AllowNegative = true;
            this.ntbTotalPayedAmount.Amount = "";
            this.ntbTotalPayedAmount.defaultAmount = "0";
            this.ntbTotalPayedAmount.Location = new System.Drawing.Point(84, 172);
            this.ntbTotalPayedAmount.Name = "ntbTotalPayedAmount";
            this.ntbTotalPayedAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTotalPayedAmount.ShowThousandSeparetor = true;
            this.ntbTotalPayedAmount.Size = new System.Drawing.Size(209, 23);
            this.ntbTotalPayedAmount.StandardPrecision = 2;
            this.ntbTotalPayedAmount.TabIndex = 19;
            this.ntbTotalPayedAmount.Leave += new System.EventHandler(this.ntbTotalPayedAmount_Leave);
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
            this.ddgInvoice.Location = new System.Drawing.Point(91, 16);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(304, 31);
            this.ddgInvoice.TabIndex = 23;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // ntbAmountPaid
            // 
            this.ntbAmountPaid.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmountPaid.AllowedLength = 0;
            this.ntbAmountPaid.AllowLeadingZeros = false;
            this.ntbAmountPaid.AllowNegative = false;
            this.ntbAmountPaid.Amount = "";
            this.ntbAmountPaid.defaultAmount = "0";
            this.ntbAmountPaid.Location = new System.Drawing.Point(93, 48);
            this.ntbAmountPaid.Name = "ntbAmountPaid";
            this.ntbAmountPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmountPaid.ShowThousandSeparetor = true;
            this.ntbAmountPaid.Size = new System.Drawing.Size(152, 23);
            this.ntbAmountPaid.StandardPrecision = 2;
            this.ntbAmountPaid.TabIndex = 22;
            this.ntbAmountPaid.Leave += new System.EventHandler(this.ntbAmountPaid_Leave);
            // 
            // sbStatus
            // 
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmCashReceiptVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 674);
            this.Controls.Add(this.ckIsOtherIncome);
            this.Controls.Add(this.ddgOtherIncome);
            this.Controls.Add(this.lblOtherIncome);
            this.Controls.Add(this.cmdAllocate);
            this.Controls.Add(this.ckIsDownPayment);
            this.Controls.Add(this.ckIsBillingPartener);
            this.Controls.Add(this.txtInstrumentNo);
            this.Controls.Add(this.cmbTenderType);
            this.Controls.Add(this.lblPaidBy);
            this.Controls.Add(this.dtgReceiptSummary);
            this.Controls.Add(this.lblDescriptionMain);
            this.Controls.Add(this.txtDescriptionMain);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.ddgCustomers);
            this.Controls.Add(this.ntbTotalPayedAmount);
            this.Controls.Add(this.txtUnAllocatedAmount);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sbStatusLabel);
            this.Controls.Add(this.grbPaymentDetail);
            this.Controls.Add(this.lblAmountReceived);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblUnallocatedAmt);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtOrganisation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmCashReceiptVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Receipt Voucher V0.1";
            this.Load += new System.EventHandler(this.frmCashReceiptVoucher_Load);
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            this.grbPaymentDetail.ResumeLayout(false);
            this.grbPaymentDetail.PerformLayout();
            this.sbStatusLabel.ResumeLayout(false);
            this.sbStatusLabel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsCommandToolBar;
        private System.Windows.Forms.ToolStripButton tlsNew;
        private System.Windows.Forms.ToolStripButton tlsSave;
        private System.Windows.Forms.ToolStripButton tlsDelete;
        private System.Windows.Forms.ToolStripButton tlsSearch;
        private System.Windows.Forms.ToolStripButton tlsFirstRecord;
        private System.Windows.Forms.ToolStripButton tlsPreviousRecord;
        private System.Windows.Forms.ToolStripButton tlsNextRecord;
        private System.Windows.Forms.ToolStripButton tlsLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlsConfirm;
        private System.Windows.Forms.ToolStripButton tlsReject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlsChangeView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlsPrint;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblUnallocatedAmt;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label lblAmountReceived;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblOverUnderAmount;
        private System.Windows.Forms.GroupBox grbPaymentDetail;
        private System.Windows.Forms.StatusStrip sbStatusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgReceiptDtl;
        private ctlNumberTextBox ntbAmountPaid;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.TextBox txtUnAllocatedAmount;
        private ctlNumberTextBox ntbTotalPayedAmount;
        private POSDocumentPrinter.DropDownDataGrid ddgInvoice;
        private POSDocumentPrinter.DropDownDataGrid ddgCustomers;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtDescriptionDtl;
        private System.Windows.Forms.Label lblDescriptionDtl;
        private System.Windows.Forms.TextBox txtDescriptionMain;
        private System.Windows.Forms.Label lblDescriptionMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtOverUnderAmt;
        private System.Windows.Forms.TextBox txtAmountDue;
        private System.Windows.Forms.CheckBox ckIsExemption;
        private System.Windows.Forms.DataGridView dtgReceiptSummary;
        private System.Windows.Forms.Label lblPaidBy;
        private System.Windows.Forms.ComboBox cmbTenderType;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.TextBox txtOrganisation;
        private System.Windows.Forms.CheckBox ckIsBillingPartener;
        private System.Windows.Forms.ToolStripButton tlsExit;
        private System.Windows.Forms.CheckBox ckIsDownPayment;
        private System.Windows.Forms.Button cmdAllocate;
        private DropDownDataGrid ddgOtherIncome;
        private System.Windows.Forms.Label lblOtherIncome;
        private System.Windows.Forms.CheckBox ckIsOtherIncome;
        private System.Windows.Forms.ToolStripStatusLabel sbStatus;        

    }
}