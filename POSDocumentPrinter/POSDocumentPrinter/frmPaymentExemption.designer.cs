namespace POSDocumentPrinter
{
    partial class frmPaymentExemption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentExemption));
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblExemptionType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpDocumentDate = new System.Windows.Forms.DateTimePicker();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.rbtWithHolding = new System.Windows.Forms.RadioButton();
            this.rbtVATExemption = new System.Windows.Forms.RadioButton();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.sbStatusLabel = new System.Windows.Forms.StatusStrip();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgInvoiceAmount = new System.Windows.Forms.DataGridView();
            this.lbltotalExemption = new System.Windows.Forms.Label();
            this.dtgExemptionSummary = new System.Windows.Forms.DataGridView();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.txtOrganisation = new System.Windows.Forms.TextBox();
            this.lblTotalExemptedAmt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddgInvoice = new POSDocumentPrinter.DropDownDataGrid();
            this.ntbExemptedAmount = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbAmount = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbTotalAmount = new POSDocumentPrinter.ctlNumberTextBox();
            this.ddgCustomers = new POSDocumentPrinter.DropDownDataGrid();
            this.tlsCommandToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoiceAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExemptionSummary)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(547, 52);
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
            this.tlsChangeView.Size = new System.Drawing.Size(42, 49);
            this.tlsChangeView.Text = "  Grid  ";
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
            this.menuStrip1.Size = new System.Drawing.Size(547, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(22, 130);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(73, 13);
            this.lblDocumentNo.TabIndex = 2;
            this.lblDocumentNo.Text = "Document No";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(292, 105);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(44, 157);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Customer";
            // 
            // lblExemptionType
            // 
            this.lblExemptionType.AutoSize = true;
            this.lblExemptionType.Location = new System.Drawing.Point(44, 184);
            this.lblExemptionType.Name = "lblExemptionType";
            this.lblExemptionType.Size = new System.Drawing.Size(83, 13);
            this.lblExemptionType.TabIndex = 5;
            this.lblExemptionType.Text = "Exemption Type";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(36, 258);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description";
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.Location = new System.Drawing.Point(327, 102);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDocumentDate.TabIndex = 10;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(102, 127);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(176, 20);
            this.txtDocumentNo.TabIndex = 11;
            this.txtDocumentNo.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            // 
            // rbtWithHolding
            // 
            this.rbtWithHolding.AutoSize = true;
            this.rbtWithHolding.Checked = true;
            this.rbtWithHolding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtWithHolding.Location = new System.Drawing.Point(139, 183);
            this.rbtWithHolding.Name = "rbtWithHolding";
            this.rbtWithHolding.Size = new System.Drawing.Size(96, 20);
            this.rbtWithHolding.TabIndex = 12;
            this.rbtWithHolding.TabStop = true;
            this.rbtWithHolding.Text = "Withholding";
            this.rbtWithHolding.UseVisualStyleBackColor = true;
            this.rbtWithHolding.CheckedChanged += new System.EventHandler(this.rbtWithHolding_CheckedChanged);
            // 
            // rbtVATExemption
            // 
            this.rbtVATExemption.AutoSize = true;
            this.rbtVATExemption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtVATExemption.Location = new System.Drawing.Point(250, 183);
            this.rbtVATExemption.Name = "rbtVATExemption";
            this.rbtVATExemption.Size = new System.Drawing.Size(119, 20);
            this.rbtVATExemption.TabIndex = 13;
            this.rbtVATExemption.Text = "VAT Exemption";
            this.rbtVATExemption.UseVisualStyleBackColor = true;
            this.rbtVATExemption.CheckedChanged += new System.EventHandler(this.rbtVATExemption_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(102, 233);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(397, 65);
            this.txtDescription.TabIndex = 17;
            // 
            // sbStatusLabel
            // 
            this.sbStatusLabel.Location = new System.Drawing.Point(0, 533);
            this.sbStatusLabel.Name = "sbStatusLabel";
            this.sbStatusLabel.Size = new System.Drawing.Size(547, 22);
            this.sbStatusLabel.TabIndex = 19;
            this.sbStatusLabel.Text = "statusStrip1";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(89, 368);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 24;
            this.lblAmount.Text = "Amount";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(61, 333);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(71, 13);
            this.lblInvoice.TabIndex = 23;
            this.lblInvoice.Text = "Sales Invoice";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(280, 363);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(67, 23);
            this.cmdAdd.TabIndex = 0;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgInvoiceAmount);
            this.panel1.Location = new System.Drawing.Point(3, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 134);
            this.panel1.TabIndex = 22;
            // 
            // dtgInvoiceAmount
            // 
            this.dtgInvoiceAmount.AllowUserToAddRows = false;
            this.dtgInvoiceAmount.AllowUserToDeleteRows = false;
            this.dtgInvoiceAmount.AllowUserToResizeColumns = false;
            this.dtgInvoiceAmount.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dtgInvoiceAmount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgInvoiceAmount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgInvoiceAmount.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoiceAmount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgInvoiceAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoiceAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgInvoiceAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgInvoiceAmount.Location = new System.Drawing.Point(0, 0);
            this.dtgInvoiceAmount.MultiSelect = false;
            this.dtgInvoiceAmount.Name = "dtgInvoiceAmount";
            this.dtgInvoiceAmount.ReadOnly = true;
            this.dtgInvoiceAmount.RowHeadersVisible = false;
            this.dtgInvoiceAmount.RowHeadersWidth = 20;
            this.dtgInvoiceAmount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInvoiceAmount.Size = new System.Drawing.Size(542, 134);
            this.dtgInvoiceAmount.TabIndex = 0;
            this.dtgInvoiceAmount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInvoiceAmount_CellClick);
            // 
            // lbltotalExemption
            // 
            this.lbltotalExemption.AutoSize = true;
            this.lbltotalExemption.Location = new System.Drawing.Point(25, 211);
            this.lbltotalExemption.Name = "lbltotalExemption";
            this.lbltotalExemption.Size = new System.Drawing.Size(70, 13);
            this.lbltotalExemption.TabIndex = 21;
            this.lbltotalExemption.Text = "Total Amount";
            // 
            // dtgExemptionSummary
            // 
            this.dtgExemptionSummary.AllowUserToAddRows = false;
            this.dtgExemptionSummary.AllowUserToDeleteRows = false;
            this.dtgExemptionSummary.AllowUserToOrderColumns = true;
            this.dtgExemptionSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgExemptionSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgExemptionSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgExemptionSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgExemptionSummary.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgExemptionSummary.Location = new System.Drawing.Point(3, 80);
            this.dtgExemptionSummary.MultiSelect = false;
            this.dtgExemptionSummary.Name = "dtgExemptionSummary";
            this.dtgExemptionSummary.ReadOnly = true;
            this.dtgExemptionSummary.RowHeadersWidth = 20;
            this.dtgExemptionSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExemptionSummary.Size = new System.Drawing.Size(542, 10);
            this.dtgExemptionSummary.TabIndex = 23;
            this.dtgExemptionSummary.Visible = false;
            this.dtgExemptionSummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgExemptionSummary_ColumnHeaderMouseClick);
            this.dtgExemptionSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExemptionSummary_CellClick);
            this.dtgExemptionSummary.SelectionChanged += new System.EventHandler(this.dtgExemptionSummary_SelectionChanged);
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(101, 102);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(150, 21);
            this.cmbOrganisation.TabIndex = 35;
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Location = new System.Drawing.Point(30, 106);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(66, 13);
            this.lblOrganisation.TabIndex = 34;
            this.lblOrganisation.Text = "Organisation";
            // 
            // txtOrganisation
            // 
            this.txtOrganisation.AcceptsReturn = true;
            this.txtOrganisation.Enabled = false;
            this.txtOrganisation.Location = new System.Drawing.Point(102, 102);
            this.txtOrganisation.Name = "txtOrganisation";
            this.txtOrganisation.Size = new System.Drawing.Size(175, 20);
            this.txtOrganisation.TabIndex = 36;
            this.txtOrganisation.Visible = false;
            // 
            // lblTotalExemptedAmt
            // 
            this.lblTotalExemptedAmt.AutoSize = true;
            this.lblTotalExemptedAmt.Location = new System.Drawing.Point(315, 211);
            this.lblTotalExemptedAmt.Name = "lblTotalExemptedAmt";
            this.lblTotalExemptedAmt.Size = new System.Drawing.Size(75, 13);
            this.lblTotalExemptedAmt.TabIndex = 37;
            this.lblTotalExemptedAmt.Text = "Exempted Amt";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 86);
            this.label1.TabIndex = 38;
            this.label1.Text = "Invoice Detail";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.ddgInvoice.Location = new System.Drawing.Point(135, 326);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(358, 31);
            this.ddgInvoice.TabIndex = 1;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // ntbExemptedAmount
            // 
            this.ntbExemptedAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbExemptedAmount.AllowedLength = 0;
            this.ntbExemptedAmount.AllowLeadingZeros = false;
            this.ntbExemptedAmount.AllowNegative = false;
            this.ntbExemptedAmount.Amount = "";
            this.ntbExemptedAmount.defaultAmount = "0";
            this.ntbExemptedAmount.Enabled = false;
            this.ntbExemptedAmount.Location = new System.Drawing.Point(392, 207);
            this.ntbExemptedAmount.Name = "ntbExemptedAmount";
            this.ntbExemptedAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbExemptedAmount.ShowThousandSeparetor = true;
            this.ntbExemptedAmount.Size = new System.Drawing.Size(107, 23);
            this.ntbExemptedAmount.StandardPrecision = 2;
            this.ntbExemptedAmount.TabIndex = 16;
            // 
            // ntbAmount
            // 
            this.ntbAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmount.AllowedLength = 0;
            this.ntbAmount.AllowLeadingZeros = false;
            this.ntbAmount.AllowNegative = false;
            this.ntbAmount.Amount = "";
            this.ntbAmount.defaultAmount = "0";
            this.ntbAmount.Location = new System.Drawing.Point(136, 363);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmount.ShowThousandSeparetor = true;
            this.ntbAmount.Size = new System.Drawing.Size(138, 23);
            this.ntbAmount.StandardPrecision = 2;
            this.ntbAmount.TabIndex = 21;
            // 
            // ntbTotalAmount
            // 
            this.ntbTotalAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTotalAmount.AllowedLength = 0;
            this.ntbTotalAmount.AllowLeadingZeros = false;
            this.ntbTotalAmount.AllowNegative = false;
            this.ntbTotalAmount.Amount = "";
            this.ntbTotalAmount.defaultAmount = "0";
            this.ntbTotalAmount.Location = new System.Drawing.Point(101, 207);
            this.ntbTotalAmount.Name = "ntbTotalAmount";
            this.ntbTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTotalAmount.ShowThousandSeparetor = true;
            this.ntbTotalAmount.Size = new System.Drawing.Size(138, 23);
            this.ntbTotalAmount.StandardPrecision = 2;
            this.ntbTotalAmount.TabIndex = 22;
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
            this.ddgCustomers.Location = new System.Drawing.Point(97, 148);
            this.ddgCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCustomers.Name = "ddgCustomers";
            this.ddgCustomers.NewButtonEnabled = true;
            this.ddgCustomers.RefreshButtonEnabled = true;
            this.ddgCustomers.SelectedColomnIdex = 0;
            this.ddgCustomers.SelectedItem = "";
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.ShowGridFunctions = false;
            this.ddgCustomers.Size = new System.Drawing.Size(430, 31);
            this.ddgCustomers.TabIndex = 14;
            this.ddgCustomers.SelectedItemClicked += new System.EventHandler(this.ddgCustomers_SelectedItemClicked);
            this.ddgCustomers.selectedItemChanged += new System.EventHandler(this.ddgCustomers_selectedItemChanged);
            // 
            // frmPaymentExemption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 555);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTotalExemptedAmt);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.ddgInvoice);
            this.Controls.Add(this.ntbExemptedAmount);
            this.Controls.Add(this.ntbAmount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.txtOrganisation);
            this.Controls.Add(this.dtgExemptionSummary);
            this.Controls.Add(this.ntbTotalAmount);
            this.Controls.Add(this.lbltotalExemption);
            this.Controls.Add(this.sbStatusLabel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.ddgCustomers);
            this.Controls.Add(this.rbtVATExemption);
            this.Controls.Add(this.rbtWithHolding);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.dtpDocumentDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblExemptionType);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmPaymentExemption";
            this.Text = "Payment Exemption V0.1";
            this.Load += new System.EventHandler(this.frmPaymentExemption_Load);
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoiceAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExemptionSummary)).EndInit();
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
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblExemptionType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtpDocumentDate;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.RadioButton rbtWithHolding;
        private System.Windows.Forms.RadioButton rbtVATExemption;
        private DropDownDataGrid ddgCustomers;
        private ctlNumberTextBox ntbExemptedAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.StatusStrip sbStatusLabel;
        private System.Windows.Forms.Button cmdAdd;
        private DropDownDataGrid ddgInvoice;
        private ctlNumberTextBox ntbAmount;
        private System.Windows.Forms.DataGridView dtgInvoiceAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lbltotalExemption;
        private ctlNumberTextBox ntbTotalAmount;
        private System.Windows.Forms.DataGridView dtgExemptionSummary;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.TextBox txtOrganisation;
        private System.Windows.Forms.ToolStripButton tlsExit;
        private System.Windows.Forms.Label lblTotalExemptedAmt;
        private System.Windows.Forms.Label label1;        

    }
}