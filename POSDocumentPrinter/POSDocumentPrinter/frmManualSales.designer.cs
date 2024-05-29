namespace POSDocumentPrinter
{
    partial class frmManualSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualSales));
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.grbPaymentDetail = new System.Windows.Forms.GroupBox();
            this.cmbStores = new System.Windows.Forms.ComboBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDescriptionDtl = new System.Windows.Forms.TextBox();
            this.lblDescriptionDtl = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ddgProduct = new POSDocumentPrinter.DropDownDataGrid();
            this.ntbUnitPrice = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbQtySold = new POSDocumentPrinter.ctlNumberTextBox();
            this.txtQtyInStock = new System.Windows.Forms.TextBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.sbStatusLabel = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgSalesDtl = new System.Windows.Forms.DataGridView();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescriptionMain = new System.Windows.Forms.TextBox();
            this.lblDescriptionMain = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dtgReceiptSummary = new System.Windows.Forms.DataGridView();
            this.txtOrganisation = new System.Windows.Forms.TextBox();
            this.txtSoldDate = new System.Windows.Forms.TextBox();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbCredit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblTaxTotal = new System.Windows.Forms.Label();
            this.txtVatTotal = new System.Windows.Forms.TextBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.ddgCustomers = new POSDocumentPrinter.DropDownDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNewCustomer = new System.Windows.Forms.Button();
            this.tlsCommandToolBar.SuspendLayout();
            this.grbPaymentDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSalesDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptSummary)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(616, 52);
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
            this.tlsSearch.Enabled = false;
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
            this.tlsChangeView.Enabled = false;
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
            this.tlsFirstRecord.Enabled = false;
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
            this.tlsPreviousRecord.Enabled = false;
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
            this.tlsNextRecord.Enabled = false;
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
            this.tlsLastRecord.Enabled = false;
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
            this.tlsPrint.Enabled = false;
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
            this.lblDocumentNo.Location = new System.Drawing.Point(25, 124);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(56, 13);
            this.lblDocumentNo.TabIndex = 2;
            this.lblDocumentNo.Text = "Document";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(356, 124);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(54, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date Sold";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(25, 154);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(51, 13);
            this.lblCustomers.TabIndex = 5;
            this.lblCustomers.Text = "Customer";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(47, 24);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 7;
            this.lblProduct.Text = "Product";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(161, 54);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(42, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "U.Price";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(18, 54);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(47, 13);
            this.lblQty.TabIndex = 9;
            this.lblQty.Text = "Qty Sold";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(107, 83);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(70, 13);
            this.lblTotalAmount.TabIndex = 10;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // grbPaymentDetail
            // 
            this.grbPaymentDetail.BackColor = System.Drawing.SystemColors.Control;
            this.grbPaymentDetail.Controls.Add(this.cmbStores);
            this.grbPaymentDetail.Controls.Add(this.txtTotalAmount);
            this.grbPaymentDetail.Controls.Add(this.txtDescriptionDtl);
            this.grbPaymentDetail.Controls.Add(this.lblDescriptionDtl);
            this.grbPaymentDetail.Controls.Add(this.cmdAdd);
            this.grbPaymentDetail.Controls.Add(this.ddgProduct);
            this.grbPaymentDetail.Controls.Add(this.ntbUnitPrice);
            this.grbPaymentDetail.Controls.Add(this.ntbQtySold);
            this.grbPaymentDetail.Controls.Add(this.lblProduct);
            this.grbPaymentDetail.Controls.Add(this.lblTotalAmount);
            this.grbPaymentDetail.Controls.Add(this.lblPrice);
            this.grbPaymentDetail.Controls.Add(this.txtQtyInStock);
            this.grbPaymentDetail.Controls.Add(this.lblStore);
            this.grbPaymentDetail.Controls.Add(this.lblQty);
            this.grbPaymentDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbPaymentDetail.Location = new System.Drawing.Point(12, 255);
            this.grbPaymentDetail.Name = "grbPaymentDetail";
            this.grbPaymentDetail.Size = new System.Drawing.Size(596, 183);
            this.grbPaymentDetail.TabIndex = 11;
            this.grbPaymentDetail.TabStop = false;
            this.grbPaymentDetail.Text = "Customer Pyament Detail";
            // 
            // cmbStores
            // 
            this.cmbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStores.DropDownWidth = 200;
            this.cmbStores.FormattingEnabled = true;
            this.cmbStores.Location = new System.Drawing.Point(392, 50);
            this.cmbStores.Name = "cmbStores";
            this.cmbStores.Size = new System.Drawing.Size(121, 21);
            this.cmbStores.TabIndex = 28;
            this.cmbStores.SelectedIndexChanged += new System.EventHandler(this.cmbStores_SelectedIndexChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTotalAmount.Location = new System.Drawing.Point(182, 80);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(119, 20);
            this.txtTotalAmount.TabIndex = 27;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescriptionDtl
            // 
            this.txtDescriptionDtl.Location = new System.Drawing.Point(84, 110);
            this.txtDescriptionDtl.Multiline = true;
            this.txtDescriptionDtl.Name = "txtDescriptionDtl";
            this.txtDescriptionDtl.Size = new System.Drawing.Size(324, 67);
            this.txtDescriptionDtl.TabIndex = 26;
            // 
            // lblDescriptionDtl
            // 
            this.lblDescriptionDtl.Location = new System.Drawing.Point(19, 115);
            this.lblDescriptionDtl.Name = "lblDescriptionDtl";
            this.lblDescriptionDtl.Size = new System.Drawing.Size(61, 55);
            this.lblDescriptionDtl.TabIndex = 25;
            this.lblDescriptionDtl.Text = "Description/Comment";
            this.lblDescriptionDtl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(447, 91);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(126, 59);
            this.cmdAdd.TabIndex = 24;
            this.cmdAdd.Text = "ADD to Sales";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAkdd_Click);
            // 
            // ddgProduct
            // 
            this.ddgProduct.AutoFilter = true;
            this.ddgProduct.AutoSize = true;
            this.ddgProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgProduct.ClearButtonEnabled = true;
            this.ddgProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgProduct.FindButtonEnabled = true;
            this.ddgProduct.HiddenColoumns = new int[0];
            this.ddgProduct.Image = null;
            this.ddgProduct.Location = new System.Drawing.Point(92, 16);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(452, 31);
            this.ddgProduct.TabIndex = 23;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            this.ddgProduct.selectedItemChanged += new System.EventHandler(this.ddgProduct_selectedItemChanged);
            // 
            // ntbUnitPrice
            // 
            this.ntbUnitPrice.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbUnitPrice.AllowedLength = 0;
            this.ntbUnitPrice.AllowLeadingZeros = false;
            this.ntbUnitPrice.AllowNegative = false;
            this.ntbUnitPrice.Amount = "";
            this.ntbUnitPrice.defaultAmount = "0";
            this.ntbUnitPrice.Location = new System.Drawing.Point(209, 51);
            this.ntbUnitPrice.Name = "ntbUnitPrice";
            this.ntbUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbUnitPrice.ShowThousandSeparetor = true;
            this.ntbUnitPrice.Size = new System.Drawing.Size(78, 23);
            this.ntbUnitPrice.StandardPrecision = 2;
            this.ntbUnitPrice.TabIndex = 22;
            this.ntbUnitPrice.Leave += new System.EventHandler(this.ntbAmountPaid_Leave);
            // 
            // ntbQtySold
            // 
            this.ntbQtySold.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbQtySold.AllowedLength = 0;
            this.ntbQtySold.AllowLeadingZeros = false;
            this.ntbQtySold.AllowNegative = false;
            this.ntbQtySold.Amount = "";
            this.ntbQtySold.defaultAmount = "0";
            this.ntbQtySold.Location = new System.Drawing.Point(67, 49);
            this.ntbQtySold.Name = "ntbQtySold";
            this.ntbQtySold.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbQtySold.ShowThousandSeparetor = true;
            this.ntbQtySold.Size = new System.Drawing.Size(78, 23);
            this.ntbQtySold.StandardPrecision = 2;
            this.ntbQtySold.TabIndex = 22;
            this.ntbQtySold.Leave += new System.EventHandler(this.ntbQtySold_Leave);
            // 
            // txtQtyInStock
            // 
            this.txtQtyInStock.Enabled = false;
            this.txtQtyInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyInStock.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtQtyInStock.Location = new System.Drawing.Point(519, 50);
            this.txtQtyInStock.Name = "txtQtyInStock";
            this.txtQtyInStock.Size = new System.Drawing.Size(70, 20);
            this.txtQtyInStock.TabIndex = 17;
            this.txtQtyInStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(311, 55);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(75, 13);
            this.lblStore.TabIndex = 9;
            this.lblStore.Text = "Dispatch From";
            // 
            // sbStatusLabel
            // 
            this.sbStatusLabel.Location = new System.Drawing.Point(0, 647);
            this.sbStatusLabel.Name = "sbStatusLabel";
            this.sbStatusLabel.Size = new System.Drawing.Size(616, 22);
            this.sbStatusLabel.TabIndex = 13;
            this.sbStatusLabel.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgSalesDtl);
            this.panel1.Location = new System.Drawing.Point(6, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 132);
            this.panel1.TabIndex = 14;
            // 
            // dtgSalesDtl
            // 
            this.dtgSalesDtl.AllowUserToAddRows = false;
            this.dtgSalesDtl.AllowUserToDeleteRows = false;
            this.dtgSalesDtl.AllowUserToResizeColumns = false;
            this.dtgSalesDtl.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSalesDtl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSalesDtl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSalesDtl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgSalesDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSalesDtl.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgSalesDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSalesDtl.Location = new System.Drawing.Point(0, 0);
            this.dtgSalesDtl.MultiSelect = false;
            this.dtgSalesDtl.Name = "dtgSalesDtl";
            this.dtgSalesDtl.ReadOnly = true;
            this.dtgSalesDtl.RowHeadersVisible = false;
            this.dtgSalesDtl.RowHeadersWidth = 20;
            this.dtgSalesDtl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSalesDtl.Size = new System.Drawing.Size(608, 132);
            this.dtgSalesDtl.TabIndex = 0;
            this.dtgSalesDtl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSalesDtl_CellClick);
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
            this.txtDocumentNo.Location = new System.Drawing.Point(86, 121);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(176, 20);
            this.txtDocumentNo.TabIndex = 16;
            this.txtDocumentNo.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(541, 121);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(21, 20);
            this.dtpDate.TabIndex = 23;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // txtDescriptionMain
            // 
            this.txtDescriptionMain.Location = new System.Drawing.Point(102, 181);
            this.txtDescriptionMain.Multiline = true;
            this.txtDescriptionMain.Name = "txtDescriptionMain";
            this.txtDescriptionMain.Size = new System.Drawing.Size(235, 64);
            this.txtDescriptionMain.TabIndex = 24;
            // 
            // lblDescriptionMain
            // 
            this.lblDescriptionMain.Location = new System.Drawing.Point(32, 187);
            this.lblDescriptionMain.Name = "lblDescriptionMain";
            this.lblDescriptionMain.Size = new System.Drawing.Size(64, 55);
            this.lblDescriptionMain.TabIndex = 27;
            this.lblDescriptionMain.Text = "Description/Comment";
            this.lblDescriptionMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
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
            this.dtgReceiptSummary.Enabled = false;
            this.dtgReceiptSummary.Location = new System.Drawing.Point(4, 78);
            this.dtgReceiptSummary.MultiSelect = false;
            this.dtgReceiptSummary.Name = "dtgReceiptSummary";
            this.dtgReceiptSummary.ReadOnly = true;
            this.dtgReceiptSummary.RowHeadersWidth = 20;
            this.dtgReceiptSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReceiptSummary.Size = new System.Drawing.Size(610, 10);
            this.dtgReceiptSummary.TabIndex = 29;
            this.dtgReceiptSummary.Visible = false;
            this.dtgReceiptSummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgReceiptSummary_ColumnHeaderMouseClick);
            this.dtgReceiptSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReceiptSummary_CellClick);
            this.dtgReceiptSummary.SelectionChanged += new System.EventHandler(this.dtgReceiptSummary_SelectionChanged);
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
            // txtSoldDate
            // 
            this.txtSoldDate.Enabled = false;
            this.txtSoldDate.Location = new System.Drawing.Point(415, 121);
            this.txtSoldDate.Name = "txtSoldDate";
            this.txtSoldDate.Size = new System.Drawing.Size(125, 20);
            this.txtSoldDate.TabIndex = 34;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Checked = true;
            this.rdbCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCash.Location = new System.Drawing.Point(24, 19);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(57, 19);
            this.rdbCash.TabIndex = 35;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "Cash";
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // rdbCredit
            // 
            this.rdbCredit.AutoSize = true;
            this.rdbCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCredit.Location = new System.Drawing.Point(133, 19);
            this.rdbCredit.Name = "rdbCredit";
            this.rdbCredit.Size = new System.Drawing.Size(63, 19);
            this.rdbCredit.TabIndex = 36;
            this.rdbCredit.TabStop = true;
            this.rdbCredit.Text = "Credit";
            this.rdbCredit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCash);
            this.groupBox1.Controls.Add(this.rdbCredit);
            this.groupBox1.Location = new System.Drawing.Point(362, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 48);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Type";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(390, 579);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(62, 13);
            this.lblSubTotal.TabIndex = 10;
            this.lblSubTotal.Text = "Sub Total";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSubTotal.Location = new System.Drawing.Point(456, 576);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(156, 20);
            this.txtSubTotal.TabIndex = 27;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTaxTotal
            // 
            this.lblTaxTotal.AutoSize = true;
            this.lblTaxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxTotal.Location = new System.Drawing.Point(393, 602);
            this.lblTaxTotal.Name = "lblTaxTotal";
            this.lblTaxTotal.Size = new System.Drawing.Size(59, 13);
            this.lblTaxTotal.TabIndex = 10;
            this.lblTaxTotal.Text = "Vat Total";
            this.lblTaxTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVatTotal
            // 
            this.txtVatTotal.Enabled = false;
            this.txtVatTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtVatTotal.Location = new System.Drawing.Point(456, 599);
            this.txtVatTotal.Name = "txtVatTotal";
            this.txtVatTotal.Size = new System.Drawing.Size(156, 20);
            this.txtVatTotal.TabIndex = 27;
            this.txtVatTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(365, 625);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(87, 13);
            this.lblGrandTotal.TabIndex = 10;
            this.lblGrandTotal.Text = "Grand Amount";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.AcceptsReturn = true;
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtGrandTotal.Location = new System.Drawing.Point(456, 622);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(156, 20);
            this.txtGrandTotal.TabIndex = 27;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.ddgCustomers.Location = new System.Drawing.Point(76, 146);
            this.ddgCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCustomers.Name = "ddgCustomers";
            this.ddgCustomers.NewButtonEnabled = true;
            this.ddgCustomers.RefreshButtonEnabled = true;
            this.ddgCustomers.SelectedColomnIdex = 0;
            this.ddgCustomers.SelectedItem = "";
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.ShowGridFunctions = false;
            this.ddgCustomers.Size = new System.Drawing.Size(367, 31);
            this.ddgCustomers.TabIndex = 22;
            this.ddgCustomers.SelectedItemClicked += new System.EventHandler(this.ddgCustomer_SelectedItemClicked);
            this.ddgCustomers.selectedItemChanged += new System.EventHandler(this.ddgCustomer_selectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 38;
            // 
            // cmdNewCustomer
            // 
            this.cmdNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewCustomer.Location = new System.Drawing.Point(444, 149);
            this.cmdNewCustomer.Name = "cmdNewCustomer";
            this.cmdNewCustomer.Size = new System.Drawing.Size(44, 23);
            this.cmdNewCustomer.TabIndex = 39;
            this.cmdNewCustomer.Text = "New";
            this.cmdNewCustomer.UseVisualStyleBackColor = true;
            this.cmdNewCustomer.Click += new System.EventHandler(this.cmdNewCustomer_Click);
            // 
            // frmManualSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 669);
            this.Controls.Add(this.cmdNewCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.txtVatTotal);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtSoldDate);
            this.Controls.Add(this.dtgReceiptSummary);
            this.Controls.Add(this.lblDescriptionMain);
            this.Controls.Add(this.txtDescriptionMain);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.ddgCustomers);
            this.Controls.Add(this.lblTaxTotal);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sbStatusLabel);
            this.Controls.Add(this.grbPaymentDetail);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtOrganisation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmManualSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Receipt Voucher V0.1";
            this.Load += new System.EventHandler(this.frmManualSales_Load);
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            this.grbPaymentDetail.ResumeLayout(false);
            this.grbPaymentDetail.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSalesDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptSummary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.GroupBox grbPaymentDetail;
        private System.Windows.Forms.StatusStrip sbStatusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgSalesDtl;
        private ctlNumberTextBox ntbQtySold;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private POSDocumentPrinter.DropDownDataGrid ddgProduct;
        private POSDocumentPrinter.DropDownDataGrid ddgCustomers;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtDescriptionDtl;
        private System.Windows.Forms.Label lblDescriptionDtl;
        private System.Windows.Forms.TextBox txtDescriptionMain;
        private System.Windows.Forms.Label lblDescriptionMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtQtyInStock;
        private System.Windows.Forms.DataGridView dtgReceiptSummary;
        private System.Windows.Forms.TextBox txtOrganisation;
        private System.Windows.Forms.ToolStripButton tlsExit;
        private System.Windows.Forms.TextBox txtSoldDate;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbCredit;
        private ctlNumberTextBox ntbUnitPrice;
        private System.Windows.Forms.ComboBox cmbStores;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblTaxTotal;
        private System.Windows.Forms.TextBox txtVatTotal;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdNewCustomer;        

    }
}