namespace POSDocumentPrinter
{
    partial class frmBankDepositSlips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankDepositSlips));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.txtOrganisation = new System.Windows.Forms.TextBox();
            this.lblDescriptionMain = new System.Windows.Forms.Label();
            this.txtDescriptionMain = new System.Windows.Forms.TextBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.grbDepositDetail = new System.Windows.Forms.GroupBox();
            this.cmdSelectSource = new System.Windows.Forms.Button();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.cmbTenderType = new System.Windows.Forms.ComboBox();
            this.lblTenderType = new System.Windows.Forms.Label();
            this.txtDescriptionDtl = new System.Windows.Forms.TextBox();
            this.lblDescriptionDtl = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ntbAmount = new POSDocumentPrinter.ctlNumberTextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgDepositDetail = new System.Windows.Forms.DataGridView();
            this.dtgDepositSummary = new System.Windows.Forms.DataGridView();
            this.sbStatusLabel = new System.Windows.Forms.StatusStrip();
            this.ckIsPaymentCard = new System.Windows.Forms.CheckBox();
            this.lblCardlCommissionRate = new System.Windows.Forms.Label();
            this.lblPrcnt = new System.Windows.Forms.Label();
            this.ntbCardCommissionRate = new POSDocumentPrinter.ctlNumberTextBox();
            this.ddgBankAccount = new POSDocumentPrinter.DropDownDataGrid();
            this.tlsCommandToolBar.SuspendLayout();
            this.grbDepositDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDepositDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDepositSummary)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(545, 52);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.Image = ((System.Drawing.Image)(resources.GetObject("tlsNew.Image")));
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(36, 49);
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
            this.tlsSave.Size = new System.Drawing.Size(36, 49);
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
            this.tlsDelete.Size = new System.Drawing.Size(42, 49);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // tlsConfirm
            // 
            this.tlsConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tlsConfirm.Image")));
            this.tlsConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsConfirm.Name = "tlsConfirm";
            this.tlsConfirm.Size = new System.Drawing.Size(48, 49);
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
            this.tlsReject.Size = new System.Drawing.Size(42, 49);
            this.tlsReject.Text = "Reject";
            this.tlsReject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // tlsSearch
            // 
            this.tlsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlsSearch.Image")));
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(44, 49);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // tlsChangeView
            // 
            this.tlsChangeView.Image = ((System.Drawing.Image)(resources.GetObject("tlsChangeView.Image")));
            this.tlsChangeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsChangeView.Name = "tlsChangeView";
            this.tlsChangeView.Size = new System.Drawing.Size(36, 49);
            this.tlsChangeView.Text = "Grid";
            this.tlsChangeView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsChangeView.Click += new System.EventHandler(this.tlsChangeView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsFirstRecord.Image")));
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(36, 49);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsFirstRecord.Click += new System.EventHandler(this.tlsFirstRecord_Click);
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsPreviousRecord.Image")));
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(52, 49);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsPreviousRecord.Click += new System.EventHandler(this.tlsPreviousRecord_Click);
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsNextRecord.Image")));
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(36, 49);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsNextRecord.Click += new System.EventHandler(this.tlsNextRecord_Click);
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsLastRecord.Image")));
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(36, 49);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsLastRecord.Click += new System.EventHandler(this.tlsLastRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // tlsPrint
            // 
            this.tlsPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsPrint.Image")));
            this.tlsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPrint.Name = "tlsPrint";
            this.tlsPrint.Size = new System.Drawing.Size(36, 49);
            this.tlsPrint.Text = "Print";
            this.tlsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsPrint.Click += new System.EventHandler(this.tlsPrint_Click);
            // 
            // tlsExit
            // 
            this.tlsExit.Image = ((System.Drawing.Image)(resources.GetObject("tlsExit.Image")));
            this.tlsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsExit.Name = "tlsExit";
            this.tlsExit.Size = new System.Drawing.Size(36, 49);
            this.tlsExit.Text = "Exit";
            this.tlsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsExit.Click += new System.EventHandler(this.tlsExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(342, 118);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 39;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(87, 118);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(150, 20);
            this.txtDocumentNo.TabIndex = 38;
            this.txtDocumentNo.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(87, 94);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(150, 21);
            this.cmbOrganisation.TabIndex = 37;
            this.cmbOrganisation.SelectedIndexChanged += new System.EventHandler(this.cmbOrganisation_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(255, 121);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(81, 13);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "Date Deposited";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(25, 121);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(56, 13);
            this.lblDocumentNo.TabIndex = 35;
            this.lblDocumentNo.Text = "Document";
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Location = new System.Drawing.Point(15, 98);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(66, 13);
            this.lblOrganisation.TabIndex = 34;
            this.lblOrganisation.Text = "Organisation";
            // 
            // txtOrganisation
            // 
            this.txtOrganisation.AcceptsReturn = true;
            this.txtOrganisation.Enabled = false;
            this.txtOrganisation.Location = new System.Drawing.Point(88, 94);
            this.txtOrganisation.Name = "txtOrganisation";
            this.txtOrganisation.Size = new System.Drawing.Size(175, 20);
            this.txtOrganisation.TabIndex = 40;
            this.txtOrganisation.Visible = false;
            // 
            // lblDescriptionMain
            // 
            this.lblDescriptionMain.Location = new System.Drawing.Point(17, 203);
            this.lblDescriptionMain.Name = "lblDescriptionMain";
            this.lblDescriptionMain.Size = new System.Drawing.Size(64, 58);
            this.lblDescriptionMain.TabIndex = 44;
            this.lblDescriptionMain.Text = "Description/Comment";
            this.lblDescriptionMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescriptionMain
            // 
            this.txtDescriptionMain.Location = new System.Drawing.Point(87, 203);
            this.txtDescriptionMain.Multiline = true;
            this.txtDescriptionMain.Name = "txtDescriptionMain";
            this.txtDescriptionMain.Size = new System.Drawing.Size(395, 58);
            this.txtDescriptionMain.TabIndex = 43;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(24, 149);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(57, 13);
            this.lblBankAccount.TabIndex = 41;
            this.lblBankAccount.Text = "Bank Acct";
            // 
            // grbDepositDetail
            // 
            this.grbDepositDetail.BackColor = System.Drawing.SystemColors.Control;
            this.grbDepositDetail.Controls.Add(this.cmdSelectSource);
            this.grbDepositDetail.Controls.Add(this.txtInstrumentNo);
            this.grbDepositDetail.Controls.Add(this.cmbTenderType);
            this.grbDepositDetail.Controls.Add(this.lblTenderType);
            this.grbDepositDetail.Controls.Add(this.txtDescriptionDtl);
            this.grbDepositDetail.Controls.Add(this.lblDescriptionDtl);
            this.grbDepositDetail.Controls.Add(this.cmdAdd);
            this.grbDepositDetail.Controls.Add(this.ntbAmount);
            this.grbDepositDetail.Controls.Add(this.lblAmount);
            this.grbDepositDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbDepositDetail.Location = new System.Drawing.Point(45, 267);
            this.grbDepositDetail.Name = "grbDepositDetail";
            this.grbDepositDetail.Size = new System.Drawing.Size(444, 185);
            this.grbDepositDetail.TabIndex = 45;
            this.grbDepositDetail.TabStop = false;
            this.grbDepositDetail.Text = "Deposit Detail";
            // 
            // cmdSelectSource
            // 
            this.cmdSelectSource.Location = new System.Drawing.Point(6, 74);
            this.cmdSelectSource.Name = "cmdSelectSource";
            this.cmdSelectSource.Size = new System.Drawing.Size(432, 39);
            this.cmdSelectSource.TabIndex = 36;
            this.cmdSelectSource.Text = "Select Cash Source";
            this.cmdSelectSource.UseVisualStyleBackColor = true;
            this.cmdSelectSource.Click += new System.EventHandler(this.cmdSelectSource_Click);
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstrumentNo.Location = new System.Drawing.Point(191, 19);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(176, 20);
            this.txtInstrumentNo.TabIndex = 35;
            this.txtInstrumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInstrumentNo.Visible = false;
            this.txtInstrumentNo.WordWrap = false;
            this.txtInstrumentNo.Leave += new System.EventHandler(this.txtInstrumentNo_Leave);
            // 
            // cmbTenderType
            // 
            this.cmbTenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenderType.FormattingEnabled = true;
            this.cmbTenderType.Items.AddRange(new object[] {
            "Cash",
            "Check",
            "CPO"});
            this.cmbTenderType.Location = new System.Drawing.Point(90, 19);
            this.cmbTenderType.Name = "cmbTenderType";
            this.cmbTenderType.Size = new System.Drawing.Size(95, 21);
            this.cmbTenderType.TabIndex = 34;
            this.cmbTenderType.SelectedIndexChanged += new System.EventHandler(this.cmbTenderType_SelectedIndexChanged);
            // 
            // lblTenderType
            // 
            this.lblTenderType.AutoSize = true;
            this.lblTenderType.Location = new System.Drawing.Point(17, 22);
            this.lblTenderType.Name = "lblTenderType";
            this.lblTenderType.Size = new System.Drawing.Size(68, 13);
            this.lblTenderType.TabIndex = 33;
            this.lblTenderType.Text = "Tender Type";
            // 
            // txtDescriptionDtl
            // 
            this.txtDescriptionDtl.Location = new System.Drawing.Point(90, 119);
            this.txtDescriptionDtl.Multiline = true;
            this.txtDescriptionDtl.Name = "txtDescriptionDtl";
            this.txtDescriptionDtl.Size = new System.Drawing.Size(267, 60);
            this.txtDescriptionDtl.TabIndex = 26;
            // 
            // lblDescriptionDtl
            // 
            this.lblDescriptionDtl.Location = new System.Drawing.Point(25, 124);
            this.lblDescriptionDtl.Name = "lblDescriptionDtl";
            this.lblDescriptionDtl.Size = new System.Drawing.Size(61, 55);
            this.lblDescriptionDtl.TabIndex = 25;
            this.lblDescriptionDtl.Text = "Description/Comment";
            this.lblDescriptionDtl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(363, 130);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(74, 42);
            this.cmdAdd.TabIndex = 24;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // ntbAmount
            // 
            this.ntbAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmount.AllowedLength = 0;
            this.ntbAmount.AllowLeadingZeros = false;
            this.ntbAmount.AllowNegative = false;
            this.ntbAmount.Amount = "";
            this.ntbAmount.defaultAmount = "0";
            this.ntbAmount.Location = new System.Drawing.Point(90, 45);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmount.ShowThousandSeparetor = true;
            this.ntbAmount.Size = new System.Drawing.Size(132, 23);
            this.ntbAmount.StandardPrecision = 2;
            this.ntbAmount.TabIndex = 22;
            this.ntbAmount.Leave += new System.EventHandler(this.ntbAmount_Leave);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(43, 49);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "Amount";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgDepositDetail);
            this.panel1.Location = new System.Drawing.Point(3, 452);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 129);
            this.panel1.TabIndex = 46;
            // 
            // dtgDepositDetail
            // 
            this.dtgDepositDetail.AllowUserToAddRows = false;
            this.dtgDepositDetail.AllowUserToDeleteRows = false;
            this.dtgDepositDetail.AllowUserToResizeColumns = false;
            this.dtgDepositDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.dtgDepositDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgDepositDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDepositDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgDepositDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDepositDetail.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgDepositDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDepositDetail.Location = new System.Drawing.Point(0, 0);
            this.dtgDepositDetail.MultiSelect = false;
            this.dtgDepositDetail.Name = "dtgDepositDetail";
            this.dtgDepositDetail.ReadOnly = true;
            this.dtgDepositDetail.RowHeadersVisible = false;
            this.dtgDepositDetail.RowHeadersWidth = 20;
            this.dtgDepositDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDepositDetail.Size = new System.Drawing.Size(541, 129);
            this.dtgDepositDetail.TabIndex = 0;
            this.dtgDepositDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDepositDetail_CellClick);
            // 
            // dtgDepositSummary
            // 
            this.dtgDepositSummary.AllowUserToAddRows = false;
            this.dtgDepositSummary.AllowUserToDeleteRows = false;
            this.dtgDepositSummary.AllowUserToResizeColumns = false;
            this.dtgDepositSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Silver;
            this.dtgDepositSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgDepositSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDepositSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgDepositSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDepositSummary.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgDepositSummary.Location = new System.Drawing.Point(3, 78);
            this.dtgDepositSummary.MultiSelect = false;
            this.dtgDepositSummary.Name = "dtgDepositSummary";
            this.dtgDepositSummary.ReadOnly = true;
            this.dtgDepositSummary.RowHeadersWidth = 20;
            this.dtgDepositSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDepositSummary.Size = new System.Drawing.Size(541, 10);
            this.dtgDepositSummary.TabIndex = 47;
            this.dtgDepositSummary.Visible = false;
            this.dtgDepositSummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgDepositSummary_ColumnHeaderMouseClick);
            this.dtgDepositSummary.SelectionChanged += new System.EventHandler(this.dtgDepositSummary_SelectionChanged);
            // 
            // sbStatusLabel
            // 
            this.sbStatusLabel.Location = new System.Drawing.Point(0, 585);
            this.sbStatusLabel.Name = "sbStatusLabel";
            this.sbStatusLabel.Size = new System.Drawing.Size(545, 22);
            this.sbStatusLabel.TabIndex = 48;
            this.sbStatusLabel.Text = "statusStrip1";
            // 
            // ckIsPaymentCard
            // 
            this.ckIsPaymentCard.AutoSize = true;
            this.ckIsPaymentCard.Location = new System.Drawing.Point(124, 178);
            this.ckIsPaymentCard.Name = "ckIsPaymentCard";
            this.ckIsPaymentCard.Size = new System.Drawing.Size(103, 17);
            this.ckIsPaymentCard.TabIndex = 49;
            this.ckIsPaymentCard.Text = "Is Payment Card";
            this.ckIsPaymentCard.UseVisualStyleBackColor = true;
            this.ckIsPaymentCard.CheckedChanged += new System.EventHandler(this.ckIsPaymentCard_CheckedChanged);
            // 
            // lblCardlCommissionRate
            // 
            this.lblCardlCommissionRate.AutoSize = true;
            this.lblCardlCommissionRate.Location = new System.Drawing.Point(278, 178);
            this.lblCardlCommissionRate.Name = "lblCardlCommissionRate";
            this.lblCardlCommissionRate.Size = new System.Drawing.Size(30, 13);
            this.lblCardlCommissionRate.TabIndex = 51;
            this.lblCardlCommissionRate.Text = "Rate";
            this.lblCardlCommissionRate.Visible = false;
            // 
            // lblPrcnt
            // 
            this.lblPrcnt.AutoSize = true;
            this.lblPrcnt.Location = new System.Drawing.Point(403, 179);
            this.lblPrcnt.Name = "lblPrcnt";
            this.lblPrcnt.Size = new System.Drawing.Size(15, 13);
            this.lblPrcnt.TabIndex = 52;
            this.lblPrcnt.Text = "%";
            this.lblPrcnt.Visible = false;
            // 
            // ntbCardCommissionRate
            // 
            this.ntbCardCommissionRate.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ntbCardCommissionRate.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCardCommissionRate.AllowedLength = 0;
            this.ntbCardCommissionRate.AllowLeadingZeros = false;
            this.ntbCardCommissionRate.AllowNegative = false;
            this.ntbCardCommissionRate.Amount = "0";
            this.ntbCardCommissionRate.defaultAmount = "0";
            this.ntbCardCommissionRate.Location = new System.Drawing.Point(312, 174);
            this.ntbCardCommissionRate.Name = "ntbCardCommissionRate";
            this.ntbCardCommissionRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCardCommissionRate.ShowThousandSeparetor = false;
            this.ntbCardCommissionRate.Size = new System.Drawing.Size(87, 23);
            this.ntbCardCommissionRate.StandardPrecision = 4;
            this.ntbCardCommissionRate.TabIndex = 50;
            this.ntbCardCommissionRate.Visible = false;
            this.ntbCardCommissionRate.Leave += new System.EventHandler(this.ntbCardCommissionRate_Leave);
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
            this.ddgBankAccount.Location = new System.Drawing.Point(83, 141);
            this.ddgBankAccount.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBankAccount.Name = "ddgBankAccount";
            this.ddgBankAccount.NewButtonEnabled = true;
            this.ddgBankAccount.RefreshButtonEnabled = true;
            this.ddgBankAccount.SelectedColomnIdex = 0;
            this.ddgBankAccount.SelectedItem = "";
            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.ShowGridFunctions = false;
            this.ddgBankAccount.Size = new System.Drawing.Size(406, 31);
            this.ddgBankAccount.TabIndex = 42;
            this.ddgBankAccount.SelectedItemClicked += new System.EventHandler(this.ddgBankAccount_SelectedItemClicked);
            this.ddgBankAccount.selectedItemChanged += new System.EventHandler(this.ddgBankAccount_selectedItemChanged);
            // 
            // frmBankDepositSlips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 607);
            this.Controls.Add(this.lblPrcnt);
            this.Controls.Add(this.lblCardlCommissionRate);
            this.Controls.Add(this.ntbCardCommissionRate);
            this.Controls.Add(this.ckIsPaymentCard);
            this.Controls.Add(this.sbStatusLabel);
            this.Controls.Add(this.dtgDepositSummary);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbDepositDetail);
            this.Controls.Add(this.lblDescriptionMain);
            this.Controls.Add(this.txtDescriptionMain);
            this.Controls.Add(this.ddgBankAccount);
            this.Controls.Add(this.lblBankAccount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.txtOrganisation);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmBankDepositSlips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Deposit Slips V.3.2";
            this.Load += new System.EventHandler(this.frmBankDepositSlips_Load);
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            this.grbDepositDetail.ResumeLayout(false);
            this.grbDepositDetail.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDepositDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDepositSummary)).EndInit();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.TextBox txtOrganisation;
        private System.Windows.Forms.Label lblDescriptionMain;
        private System.Windows.Forms.TextBox txtDescriptionMain;
        private DropDownDataGrid ddgBankAccount;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.GroupBox grbDepositDetail;
        private System.Windows.Forms.TextBox txtDescriptionDtl;
        private System.Windows.Forms.Label lblDescriptionDtl;
        private System.Windows.Forms.Button cmdAdd;
        private ctlNumberTextBox ntbAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.ComboBox cmbTenderType;
        private System.Windows.Forms.Label lblTenderType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgDepositDetail;
        private System.Windows.Forms.DataGridView dtgDepositSummary;
        private System.Windows.Forms.Button cmdSelectSource;
        private System.Windows.Forms.StatusStrip sbStatusLabel;
        private System.Windows.Forms.CheckBox ckIsPaymentCard;
        private ctlNumberTextBox ntbCardCommissionRate;
        private System.Windows.Forms.Label lblCardlCommissionRate;
        private System.Windows.Forms.Label lblPrcnt;
        private System.Windows.Forms.ToolStripButton tlsExit;        

    }
}