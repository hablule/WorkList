namespace BuySimple
{
    partial class frmPurchasePaymentInvoice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchasePaymentInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtAccumulatedAmount = new System.Windows.Forms.TextBox();
            this.txtPurchaseOrderDate = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAccumulatedAmount = new System.Windows.Forms.Label();
            this.lblPurchaseOrderDate = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.ckIsEstimateAmount = new System.Windows.Forms.CheckBox();
            this.grbPurchaseOrder = new System.Windows.Forms.GroupBox();
            this.ckSelectAllLines = new System.Windows.Forms.CheckBox();
            this.ddgCommercialInvoice = new BuySimple.DropDownDataGrid();
            this.lblCommercialInvoice = new System.Windows.Forms.Label();
            this.grbSummary = new System.Windows.Forms.GroupBox();
            this.txtNumberOfOrderLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCollactableAmount = new System.Windows.Forms.TextBox();
            this.lblCollecatableAmount = new System.Windows.Forms.Label();
            this.txtPaymentCount = new System.Windows.Forms.TextBox();
            this.lblPyementCount = new System.Windows.Forms.Label();
            this.dtgPaymentItemDetail = new System.Windows.Forms.DataGridView();
            this.ddgPurchaseOrders = new BuySimple.DropDownDataGrid();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.txtDescriptionComment = new System.Windows.Forms.TextBox();
            this.lblDescriptionComment = new System.Windows.Forms.Label();
            this.lblPayedFrom = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblPaymentReason = new System.Windows.Forms.Label();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDistributeRemaining = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintCostSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExist = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecordView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutoggleView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviousRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.previousRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNexRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLastRcord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocumentation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tscmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.tscmdNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdSearch = new System.Windows.Forms.ToolStripButton();
            this.tscmdToggleView = new System.Windows.Forms.ToolStripButton();
            this.tscmdFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdLastRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdHelp = new System.Windows.Forms.ToolStripButton();
            this.tscmdExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtgPaymentGridView = new System.Windows.Forms.DataGridView();
            this.colRowHeading = new System.Windows.Forms.DataGridViewButtonColumn();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckIsAmountDistributed = new System.Windows.Forms.CheckBox();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.lblAmountRemaining = new System.Windows.Forms.Label();
            this.lblPercentageRemaining = new System.Windows.Forms.Label();
            this.txtRemainingDistribution = new System.Windows.Forms.TextBox();
            this.txtRemainingDistributionP_tage = new System.Windows.Forms.TextBox();
            this.ddgVendor = new BuySimple.DropDownDataGrid();
            this.ddgPaymentReason = new BuySimple.DropDownDataGrid();
            this.ddgPayedFrom = new BuySimple.DropDownDataGrid();
            this.ntbAmount = new BuySimple.ctlNumberTextBox();
            this.grbPurchaseOrder.SuspendLayout();
            this.grbSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaymentItemDetail)).BeginInit();
            this.mnuMainMenu.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaymentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVendorName
            // 
            this.lblVendorName.Location = new System.Drawing.Point(21, 141);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(73, 17);
            this.lblVendorName.TabIndex = 0;
            this.lblVendorName.Text = "Vendor Name";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.Location = new System.Drawing.Point(319, 103);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(72, 20);
            this.lblInvoiceDate.TabIndex = 2;
            this.lblInvoiceDate.Text = "Invoice Date";
            this.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.Location = new System.Drawing.Point(13, 320);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(81, 20);
            this.lblPaymentAmount.TabIndex = 3;
            this.lblPaymentAmount.Text = "Amount (ETB)";
            this.lblPaymentAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(42, 20);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(82, 20);
            this.lblOrderNumber.TabIndex = 4;
            this.lblOrderNumber.Text = "Purchase Order";
            this.lblOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(127, 69);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(144, 20);
            this.txtStatus.TabIndex = 24;
            // 
            // txtAccumulatedAmount
            // 
            this.txtAccumulatedAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtAccumulatedAmount.Enabled = false;
            this.txtAccumulatedAmount.Location = new System.Drawing.Point(126, 17);
            this.txtAccumulatedAmount.Multiline = true;
            this.txtAccumulatedAmount.Name = "txtAccumulatedAmount";
            this.txtAccumulatedAmount.ReadOnly = true;
            this.txtAccumulatedAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccumulatedAmount.Size = new System.Drawing.Size(145, 20);
            this.txtAccumulatedAmount.TabIndex = 23;
            this.txtAccumulatedAmount.Text = "0.00";
            // 
            // txtPurchaseOrderDate
            // 
            this.txtPurchaseOrderDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtPurchaseOrderDate.Enabled = false;
            this.txtPurchaseOrderDate.Location = new System.Drawing.Point(127, 95);
            this.txtPurchaseOrderDate.Multiline = true;
            this.txtPurchaseOrderDate.Name = "txtPurchaseOrderDate";
            this.txtPurchaseOrderDate.ReadOnly = true;
            this.txtPurchaseOrderDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPurchaseOrderDate.Size = new System.Drawing.Size(144, 20);
            this.txtPurchaseOrderDate.TabIndex = 22;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(467, 141);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 37);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = ".";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAccumulatedAmount
            // 
            this.lblAccumulatedAmount.Location = new System.Drawing.Point(11, 17);
            this.lblAccumulatedAmount.Name = "lblAccumulatedAmount";
            this.lblAccumulatedAmount.Size = new System.Drawing.Size(114, 20);
            this.lblAccumulatedAmount.TabIndex = 17;
            this.lblAccumulatedAmount.Text = "Accumulated Amount";
            this.lblAccumulatedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPurchaseOrderDate
            // 
            this.lblPurchaseOrderDate.Location = new System.Drawing.Point(48, 94);
            this.lblPurchaseOrderDate.Name = "lblPurchaseOrderDate";
            this.lblPurchaseOrderDate.Size = new System.Drawing.Size(72, 20);
            this.lblPurchaseOrderDate.TabIndex = 16;
            this.lblPurchaseOrderDate.Text = "Dated";
            this.lblPurchaseOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(104, 103);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(151, 20);
            this.txtInvoiceNumber.TabIndex = 12;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Location = new System.Drawing.Point(5, 104);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(93, 17);
            this.lblInvoiceNumber.TabIndex = 5;
            this.lblInvoiceNumber.Text = "Invoice Number";
            this.lblInvoiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckIsEstimateAmount
            // 
            this.ckIsEstimateAmount.AutoSize = true;
            this.ckIsEstimateAmount.Location = new System.Drawing.Point(512, 212);
            this.ckIsEstimateAmount.Name = "ckIsEstimateAmount";
            this.ckIsEstimateAmount.Size = new System.Drawing.Size(77, 17);
            this.ckIsEstimateAmount.TabIndex = 28;
            this.ckIsEstimateAmount.Text = "Is Estimate";
            this.ckIsEstimateAmount.UseVisualStyleBackColor = true;
            this.ckIsEstimateAmount.Visible = false;
            // 
            // grbPurchaseOrder
            // 
            this.grbPurchaseOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbPurchaseOrder.Controls.Add(this.ckSelectAllLines);
            this.grbPurchaseOrder.Controls.Add(this.ddgCommercialInvoice);
            this.grbPurchaseOrder.Controls.Add(this.lblCommercialInvoice);
            this.grbPurchaseOrder.Controls.Add(this.grbSummary);
            this.grbPurchaseOrder.Controls.Add(this.dtgPaymentItemDetail);
            this.grbPurchaseOrder.Controls.Add(this.ddgPurchaseOrders);
            this.grbPurchaseOrder.Controls.Add(this.lblOrderNumber);
            this.grbPurchaseOrder.Location = new System.Drawing.Point(5, 366);
            this.grbPurchaseOrder.Name = "grbPurchaseOrder";
            this.grbPurchaseOrder.Size = new System.Drawing.Size(617, 272);
            this.grbPurchaseOrder.TabIndex = 29;
            this.grbPurchaseOrder.TabStop = false;
            this.grbPurchaseOrder.Text = "Payed In Account Of ";
            // 
            // ckSelectAllLines
            // 
            this.ckSelectAllLines.AutoSize = true;
            this.ckSelectAllLines.Checked = true;
            this.ckSelectAllLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSelectAllLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSelectAllLines.Location = new System.Drawing.Point(10, 248);
            this.ckSelectAllLines.Name = "ckSelectAllLines";
            this.ckSelectAllLines.Size = new System.Drawing.Size(114, 17);
            this.ckSelectAllLines.TabIndex = 33;
            this.ckSelectAllLines.Text = "Select All Lines";
            this.ckSelectAllLines.UseVisualStyleBackColor = true;
            this.ckSelectAllLines.CheckedChanged += new System.EventHandler(this.ckSelectAllLines_CheckedChanged);
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
            this.ddgCommercialInvoice.Location = new System.Drawing.Point(128, 47);
            this.ddgCommercialInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCommercialInvoice.Name = "ddgCommercialInvoice";
            this.ddgCommercialInvoice.NewButtonEnabled = true;
            this.ddgCommercialInvoice.RefreshButtonEnabled = true;
            this.ddgCommercialInvoice.SelectedColomnIdex = 0;
            this.ddgCommercialInvoice.SelectedItem = "";
            this.ddgCommercialInvoice.SelectedRowKey = null;
            this.ddgCommercialInvoice.ShowGridFunctions = false;
            this.ddgCommercialInvoice.Size = new System.Drawing.Size(355, 31);
            this.ddgCommercialInvoice.TabIndex = 32;
            this.ddgCommercialInvoice.SelectedItemClicked += new System.EventHandler(this.ddgCommercialInvoice_SelectedItemClicked);
            this.ddgCommercialInvoice.selectedItemChanged += new System.EventHandler(this.ddgCommercialInvoice_selectedItemChanged);
            // 
            // lblCommercialInvoice
            // 
            this.lblCommercialInvoice.Location = new System.Drawing.Point(31, 52);
            this.lblCommercialInvoice.Name = "lblCommercialInvoice";
            this.lblCommercialInvoice.Size = new System.Drawing.Size(97, 20);
            this.lblCommercialInvoice.TabIndex = 31;
            this.lblCommercialInvoice.Text = "Commercial Invoce";
            this.lblCommercialInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbSummary
            // 
            this.grbSummary.Controls.Add(this.txtNumberOfOrderLine);
            this.grbSummary.Controls.Add(this.label1);
            this.grbSummary.Controls.Add(this.lblAccumulatedAmount);
            this.grbSummary.Controls.Add(this.txtStatus);
            this.grbSummary.Controls.Add(this.txtCollactableAmount);
            this.grbSummary.Controls.Add(this.txtAccumulatedAmount);
            this.grbSummary.Controls.Add(this.lblCollecatableAmount);
            this.grbSummary.Controls.Add(this.txtPaymentCount);
            this.grbSummary.Controls.Add(this.txtPurchaseOrderDate);
            this.grbSummary.Controls.Add(this.lblPyementCount);
            this.grbSummary.Controls.Add(this.lblPurchaseOrderDate);
            this.grbSummary.Location = new System.Drawing.Point(741, 19);
            this.grbSummary.Name = "grbSummary";
            this.grbSummary.Size = new System.Drawing.Size(25, 312);
            this.grbSummary.TabIndex = 30;
            this.grbSummary.TabStop = false;
            this.grbSummary.Text = "Order Summary Info";
            this.grbSummary.Visible = false;
            // 
            // txtNumberOfOrderLine
            // 
            this.txtNumberOfOrderLine.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumberOfOrderLine.Enabled = false;
            this.txtNumberOfOrderLine.Location = new System.Drawing.Point(126, 147);
            this.txtNumberOfOrderLine.Name = "txtNumberOfOrderLine";
            this.txtNumberOfOrderLine.Size = new System.Drawing.Size(145, 20);
            this.txtNumberOfOrderLine.TabIndex = 30;
            this.txtNumberOfOrderLine.Text = "0";
            this.txtNumberOfOrderLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Number Of Lines";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCollactableAmount
            // 
            this.txtCollactableAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtCollactableAmount.Enabled = false;
            this.txtCollactableAmount.Location = new System.Drawing.Point(126, 43);
            this.txtCollactableAmount.Name = "txtCollactableAmount";
            this.txtCollactableAmount.Size = new System.Drawing.Size(145, 20);
            this.txtCollactableAmount.TabIndex = 28;
            this.txtCollactableAmount.Text = "0.00";
            this.txtCollactableAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCollecatableAmount
            // 
            this.lblCollecatableAmount.Location = new System.Drawing.Point(19, 43);
            this.lblCollecatableAmount.Name = "lblCollecatableAmount";
            this.lblCollecatableAmount.Size = new System.Drawing.Size(98, 20);
            this.lblCollecatableAmount.TabIndex = 27;
            this.lblCollecatableAmount.Text = "Collectable Amount";
            this.lblCollecatableAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaymentCount
            // 
            this.txtPaymentCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtPaymentCount.Enabled = false;
            this.txtPaymentCount.Location = new System.Drawing.Point(127, 121);
            this.txtPaymentCount.Multiline = true;
            this.txtPaymentCount.Name = "txtPaymentCount";
            this.txtPaymentCount.ReadOnly = true;
            this.txtPaymentCount.Size = new System.Drawing.Size(144, 20);
            this.txtPaymentCount.TabIndex = 26;
            this.txtPaymentCount.Text = "0";
            // 
            // lblPyementCount
            // 
            this.lblPyementCount.Location = new System.Drawing.Point(41, 121);
            this.lblPyementCount.Name = "lblPyementCount";
            this.lblPyementCount.Size = new System.Drawing.Size(79, 20);
            this.lblPyementCount.TabIndex = 25;
            this.lblPyementCount.Text = "Payment Count";
            this.lblPyementCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtgPaymentItemDetail
            // 
            this.dtgPaymentItemDetail.AllowUserToAddRows = false;
            this.dtgPaymentItemDetail.AllowUserToDeleteRows = false;
            this.dtgPaymentItemDetail.AllowUserToResizeColumns = false;
            this.dtgPaymentItemDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPaymentItemDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPaymentItemDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPaymentItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPaymentItemDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPaymentItemDetail.Location = new System.Drawing.Point(8, 79);
            this.dtgPaymentItemDetail.MultiSelect = false;
            this.dtgPaymentItemDetail.Name = "dtgPaymentItemDetail";
            this.dtgPaymentItemDetail.ReadOnly = true;
            this.dtgPaymentItemDetail.RowHeadersVisible = false;
            this.dtgPaymentItemDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPaymentItemDetail.Size = new System.Drawing.Size(603, 163);
            this.dtgPaymentItemDetail.TabIndex = 29;
            this.dtgPaymentItemDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPaymentItemDetail_CellClick);
            // 
            // ddgPurchaseOrders
            // 
            this.ddgPurchaseOrders.AutoFilter = true;
            this.ddgPurchaseOrders.AutoSize = true;
            this.ddgPurchaseOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPurchaseOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPurchaseOrders.ClearButtonEnabled = true;
            this.ddgPurchaseOrders.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPurchaseOrders.FindButtonEnabled = true;
            this.ddgPurchaseOrders.HiddenColoumns = new int[0];
            this.ddgPurchaseOrders.Image = null;
            this.ddgPurchaseOrders.Location = new System.Drawing.Point(141, 15);
            this.ddgPurchaseOrders.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPurchaseOrders.Name = "ddgPurchaseOrders";
            this.ddgPurchaseOrders.NewButtonEnabled = true;
            this.ddgPurchaseOrders.RefreshButtonEnabled = true;
            this.ddgPurchaseOrders.SelectedColomnIdex = 0;
            this.ddgPurchaseOrders.SelectedItem = "";
            this.ddgPurchaseOrders.SelectedRowKey = null;
            this.ddgPurchaseOrders.ShowGridFunctions = false;
            this.ddgPurchaseOrders.Size = new System.Drawing.Size(302, 31);
            this.ddgPurchaseOrders.TabIndex = 27;
            this.ddgPurchaseOrders.SelectedItemClicked += new System.EventHandler(this.ddgPurchaseOrders_SelectedItemClicked);
            this.ddgPurchaseOrders.selectedItemChanged += new System.EventHandler(this.ddgPurchaseOrders_selectedItemChanged);
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsActive.Location = new System.Drawing.Point(423, 212);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(83, 17);
            this.ckIsActive.TabIndex = 30;
            this.ckIsActive.Text = "Active         ";
            this.ckIsActive.UseVisualStyleBackColor = true;
            // 
            // txtDescriptionComment
            // 
            this.txtDescriptionComment.Location = new System.Drawing.Point(104, 242);
            this.txtDescriptionComment.Multiline = true;
            this.txtDescriptionComment.Name = "txtDescriptionComment";
            this.txtDescriptionComment.Size = new System.Drawing.Size(222, 54);
            this.txtDescriptionComment.TabIndex = 35;
            // 
            // lblDescriptionComment
            // 
            this.lblDescriptionComment.Location = new System.Drawing.Point(30, 242);
            this.lblDescriptionComment.Name = "lblDescriptionComment";
            this.lblDescriptionComment.Size = new System.Drawing.Size(68, 62);
            this.lblDescriptionComment.TabIndex = 36;
            this.lblDescriptionComment.Text = "Description/ Comment";
            this.lblDescriptionComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayedFrom
            // 
            this.lblPayedFrom.Location = new System.Drawing.Point(27, 173);
            this.lblPayedFrom.Name = "lblPayedFrom";
            this.lblPayedFrom.Size = new System.Drawing.Size(67, 20);
            this.lblPayedFrom.TabIndex = 39;
            this.lblPayedFrom.Text = "Payed From";
            this.lblPayedFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Location = new System.Drawing.Point(400, 103);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(196, 20);
            this.dtpInvoiceDate.TabIndex = 42;
            // 
            // lblPaymentReason
            // 
            this.lblPaymentReason.Location = new System.Drawing.Point(5, 212);
            this.lblPaymentReason.Name = "lblPaymentReason";
            this.lblPaymentReason.Size = new System.Drawing.Size(90, 14);
            this.lblPaymentReason.TabIndex = 48;
            this.lblPaymentReason.Text = "Payment Reason";
            this.lblPaymentReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTask,
            this.mnuPayment,
            this.mnuRecordView,
            this.mnuHelp});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Margin = new System.Windows.Forms.Padding(1);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMainMenu.Size = new System.Drawing.Size(624, 24);
            this.mnuMainMenu.TabIndex = 54;
            // 
            // mnuTask
            // 
            this.mnuTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuNewPayment,
            this.mnuRefresh,
            this.mnuDistributeRemaining,
            this.mnuCloseInvoice,
            this.mnuPrintCostSheet,
            this.mnuExist});
            this.mnuTask.Name = "mnuTask";
            this.mnuTask.Size = new System.Drawing.Size(41, 20);
            this.mnuTask.Text = "Task";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(185, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Visible = false;
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuNewPayment
            // 
            this.mnuNewPayment.Name = "mnuNewPayment";
            this.mnuNewPayment.Size = new System.Drawing.Size(185, 22);
            this.mnuNewPayment.Text = "New Payment";
            this.mnuNewPayment.Click += new System.EventHandler(this.tscmdNew_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(185, 22);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.tscmdRefresh_Click);
            // 
            // mnuDistributeRemaining
            // 
            this.mnuDistributeRemaining.Name = "mnuDistributeRemaining";
            this.mnuDistributeRemaining.Size = new System.Drawing.Size(185, 22);
            this.mnuDistributeRemaining.Text = "Distribute Remaining";
            this.mnuDistributeRemaining.Click += new System.EventHandler(this.mnuDistributeRemaining_Click);
            // 
            // mnuCloseInvoice
            // 
            this.mnuCloseInvoice.Enabled = false;
            this.mnuCloseInvoice.Name = "mnuCloseInvoice";
            this.mnuCloseInvoice.Size = new System.Drawing.Size(185, 22);
            this.mnuCloseInvoice.Text = "Close Invoice Cost";
            this.mnuCloseInvoice.Visible = false;
            this.mnuCloseInvoice.Click += new System.EventHandler(this.mnuCloseInvoice_Click);
            // 
            // mnuPrintCostSheet
            // 
            this.mnuPrintCostSheet.Name = "mnuPrintCostSheet";
            this.mnuPrintCostSheet.Size = new System.Drawing.Size(185, 22);
            this.mnuPrintCostSheet.Text = "Print Cost Sheet";
            this.mnuPrintCostSheet.Click += new System.EventHandler(this.mnuPrintCostSheet_Click);
            // 
            // mnuExist
            // 
            this.mnuExist.Name = "mnuExist";
            this.mnuExist.Size = new System.Drawing.Size(185, 22);
            this.mnuExist.Text = "Exit";
            this.mnuExist.Click += new System.EventHandler(this.mnuExist_Click);
            // 
            // mnuPayment
            // 
            this.mnuPayment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSearch,
            this.mnuRecord});
            this.mnuPayment.Name = "mnuPayment";
            this.mnuPayment.Size = new System.Drawing.Size(66, 20);
            this.mnuPayment.Text = "Payment";
            // 
            // mnuSearch
            // 
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Size = new System.Drawing.Size(111, 22);
            this.mnuSearch.Text = "Search";
            this.mnuSearch.Click += new System.EventHandler(this.tscmdSearch_Click);
            // 
            // mnuRecord
            // 
            this.mnuRecord.Name = "mnuRecord";
            this.mnuRecord.Size = new System.Drawing.Size(111, 22);
            this.mnuRecord.Text = "Record";
            this.mnuRecord.Click += new System.EventHandler(this.tscmdRecord_Click);
            // 
            // mnuRecordView
            // 
            this.mnuRecordView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutoggleView,
            this.mnuPreviousRecord,
            this.previousRecordToolStripMenuItem,
            this.mnuNexRecord,
            this.mnuLastRcord});
            this.mnuRecordView.Name = "mnuRecordView";
            this.mnuRecordView.Size = new System.Drawing.Size(84, 20);
            this.mnuRecordView.Text = "Record View";
            // 
            // mnutoggleView
            // 
            this.mnutoggleView.Name = "mnutoggleView";
            this.mnutoggleView.Size = new System.Drawing.Size(156, 22);
            this.mnutoggleView.Text = "Toggle View";
            this.mnutoggleView.Click += new System.EventHandler(this.tscmdToggleView_Click);
            // 
            // mnuPreviousRecord
            // 
            this.mnuPreviousRecord.Name = "mnuPreviousRecord";
            this.mnuPreviousRecord.Size = new System.Drawing.Size(156, 22);
            this.mnuPreviousRecord.Text = "First Record";
            this.mnuPreviousRecord.Click += new System.EventHandler(this.tscmdFirstRecord_Click);
            // 
            // previousRecordToolStripMenuItem
            // 
            this.previousRecordToolStripMenuItem.Name = "previousRecordToolStripMenuItem";
            this.previousRecordToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.previousRecordToolStripMenuItem.Text = "Previous record";
            this.previousRecordToolStripMenuItem.Click += new System.EventHandler(this.tscmdPreviousRecord_Click);
            // 
            // mnuNexRecord
            // 
            this.mnuNexRecord.Name = "mnuNexRecord";
            this.mnuNexRecord.Size = new System.Drawing.Size(156, 22);
            this.mnuNexRecord.Text = "Next record";
            this.mnuNexRecord.Click += new System.EventHandler(this.tscmdNextRecord_Click);
            // 
            // mnuLastRcord
            // 
            this.mnuLastRcord.Name = "mnuLastRcord";
            this.mnuLastRcord.Size = new System.Drawing.Size(156, 22);
            this.mnuLastRcord.Text = "Last record";
            this.mnuLastRcord.Click += new System.EventHandler(this.tscmdLastRecord_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDocumentation});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuDocumentation
            // 
            this.mnuDocumentation.Name = "mnuDocumentation";
            this.mnuDocumentation.Size = new System.Drawing.Size(157, 22);
            this.mnuDocumentation.Text = "Documentation";
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmdRefresh,
            this.tscmdNew,
            this.toolStripSeparator2,
            this.tscmdRecord,
            this.tscmdDelete,
            this.toolStripSeparator1,
            this.tscmdSearch,
            this.tscmdToggleView,
            this.tscmdFirstRecord,
            this.tscmdPreviousRecord,
            this.tscmdNextRecord,
            this.tscmdLastRecord,
            this.toolStripSeparator3,
            this.tscmdHelp,
            this.tscmdExit});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Margin = new System.Windows.Forms.Padding(1);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(624, 52);
            this.tsMain.TabIndex = 55;
            this.tsMain.Text = "toolStrip1";
            // 
            // tscmdRefresh
            // 
            this.tscmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tscmdRefresh.Image")));
            this.tscmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdRefresh.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdRefresh.Name = "tscmdRefresh";
            this.tscmdRefresh.Size = new System.Drawing.Size(50, 49);
            this.tscmdRefresh.Text = "Refresh";
            this.tscmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdRefresh.ToolTipText = "Refresh";
            this.tscmdRefresh.Click += new System.EventHandler(this.tscmdRefresh_Click);
            // 
            // tscmdNew
            // 
            this.tscmdNew.Image = ((System.Drawing.Image)(resources.GetObject("tscmdNew.Image")));
            this.tscmdNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdNew.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdNew.Name = "tscmdNew";
            this.tscmdNew.Size = new System.Drawing.Size(36, 49);
            this.tscmdNew.Text = "New";
            this.tscmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdNew.ToolTipText = "New payment";
            this.tscmdNew.Click += new System.EventHandler(this.tscmdNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdRecord
            // 
            this.tscmdRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdRecord.Image")));
            this.tscmdRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdRecord.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdRecord.Name = "tscmdRecord";
            this.tscmdRecord.Size = new System.Drawing.Size(36, 49);
            this.tscmdRecord.Text = "Save";
            this.tscmdRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdRecord.ToolTipText = "Save Payment Info";
            this.tscmdRecord.Click += new System.EventHandler(this.tscmdRecord_Click);
            // 
            // tscmdDelete
            // 
            this.tscmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("tscmdDelete.Image")));
            this.tscmdDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdDelete.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdDelete.Name = "tscmdDelete";
            this.tscmdDelete.Size = new System.Drawing.Size(44, 49);
            this.tscmdDelete.Text = "Delete";
            this.tscmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdDelete.ToolTipText = "Delete Payment Info";
            this.tscmdDelete.Click += new System.EventHandler(this.tscmdDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdSearch
            // 
            this.tscmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("tscmdSearch.Image")));
            this.tscmdSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdSearch.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdSearch.Name = "tscmdSearch";
            this.tscmdSearch.Size = new System.Drawing.Size(46, 49);
            this.tscmdSearch.Text = "Search";
            this.tscmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdSearch.ToolTipText = "Search Payment Info";
            this.tscmdSearch.Click += new System.EventHandler(this.tscmdSearch_Click);
            // 
            // tscmdToggleView
            // 
            this.tscmdToggleView.Image = ((System.Drawing.Image)(resources.GetObject("tscmdToggleView.Image")));
            this.tscmdToggleView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdToggleView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdToggleView.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdToggleView.Name = "tscmdToggleView";
            this.tscmdToggleView.Size = new System.Drawing.Size(36, 49);
            this.tscmdToggleView.Text = "Grid";
            this.tscmdToggleView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdToggleView.ToolTipText = "Grid/Record View toggle";
            this.tscmdToggleView.Click += new System.EventHandler(this.tscmdToggleView_Click);
            // 
            // tscmdFirstRecord
            // 
            this.tscmdFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdFirstRecord.Image")));
            this.tscmdFirstRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdFirstRecord.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdFirstRecord.Name = "tscmdFirstRecord";
            this.tscmdFirstRecord.Size = new System.Drawing.Size(36, 49);
            this.tscmdFirstRecord.Text = "First";
            this.tscmdFirstRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdFirstRecord.ToolTipText = "First Record";
            this.tscmdFirstRecord.Click += new System.EventHandler(this.tscmdFirstRecord_Click);
            // 
            // tscmdPreviousRecord
            // 
            this.tscmdPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdPreviousRecord.Image")));
            this.tscmdPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdPreviousRecord.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdPreviousRecord.Name = "tscmdPreviousRecord";
            this.tscmdPreviousRecord.Size = new System.Drawing.Size(56, 49);
            this.tscmdPreviousRecord.Text = "Previous";
            this.tscmdPreviousRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdPreviousRecord.ToolTipText = "Previous Record";
            this.tscmdPreviousRecord.Click += new System.EventHandler(this.tscmdPreviousRecord_Click);
            // 
            // tscmdNextRecord
            // 
            this.tscmdNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdNextRecord.Image")));
            this.tscmdNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdNextRecord.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdNextRecord.Name = "tscmdNextRecord";
            this.tscmdNextRecord.Size = new System.Drawing.Size(36, 49);
            this.tscmdNextRecord.Text = "Next";
            this.tscmdNextRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdNextRecord.ToolTipText = "Next Record";
            this.tscmdNextRecord.Click += new System.EventHandler(this.tscmdNextRecord_Click);
            // 
            // tscmdLastRecord
            // 
            this.tscmdLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdLastRecord.Image")));
            this.tscmdLastRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdLastRecord.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdLastRecord.Name = "tscmdLastRecord";
            this.tscmdLastRecord.Size = new System.Drawing.Size(36, 49);
            this.tscmdLastRecord.Text = "Last";
            this.tscmdLastRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdLastRecord.ToolTipText = "Last Record";
            this.tscmdLastRecord.Click += new System.EventHandler(this.tscmdLastRecord_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdHelp
            // 
            this.tscmdHelp.Image = global::BuySimple.Properties.Resources.help;
            this.tscmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdHelp.Margin = new System.Windows.Forms.Padding(7, 1, 7, 2);
            this.tscmdHelp.Name = "tscmdHelp";
            this.tscmdHelp.Size = new System.Drawing.Size(98, 51);
            this.tscmdHelp.Text = "toolStripButton1";
            this.tscmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdHelp.Visible = false;
            // 
            // tscmdExit
            // 
            this.tscmdExit.Image = ((System.Drawing.Image)(resources.GetObject("tscmdExit.Image")));
            this.tscmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdExit.Name = "tscmdExit";
            this.tscmdExit.Size = new System.Drawing.Size(36, 49);
            this.tscmdExit.Text = "Exit";
            this.tscmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdExit.Click += new System.EventHandler(this.tscmdExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 56;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // dtgPaymentGridView
            // 
            this.dtgPaymentGridView.AllowUserToAddRows = false;
            this.dtgPaymentGridView.AllowUserToDeleteRows = false;
            this.dtgPaymentGridView.AllowUserToOrderColumns = true;
            this.dtgPaymentGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPaymentGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgPaymentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPaymentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowHeading});
            this.dtgPaymentGridView.Location = new System.Drawing.Point(0, 78);
            this.dtgPaymentGridView.MultiSelect = false;
            this.dtgPaymentGridView.Name = "dtgPaymentGridView";
            this.dtgPaymentGridView.ReadOnly = true;
            this.dtgPaymentGridView.RowHeadersVisible = false;
            this.dtgPaymentGridView.RowHeadersWidth = 10;
            this.dtgPaymentGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgPaymentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPaymentGridView.Size = new System.Drawing.Size(622, 10);
            this.dtgPaymentGridView.TabIndex = 57;
            this.dtgPaymentGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPaymentGridView_RowEnter);
            this.dtgPaymentGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPaymentGridView_UserClickeCell);
            this.dtgPaymentGridView.SelectionChanged += new System.EventHandler(this.dtgPaymentGridView_SelectionChanged);
            // 
            // colRowHeading
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.colRowHeading.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRowHeading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colRowHeading.Frozen = true;
            this.colRowHeading.HeaderText = "..";
            this.colRowHeading.Name = "colRowHeading";
            this.colRowHeading.ReadOnly = true;
            this.colRowHeading.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRowHeading.UseColumnTextForButtonValue = true;
            this.colRowHeading.Visible = false;
            this.colRowHeading.Width = 25;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            // 
            // ckIsAmountDistributed
            // 
            this.ckIsAmountDistributed.AutoSize = true;
            this.ckIsAmountDistributed.Location = new System.Drawing.Point(244, 322);
            this.ckIsAmountDistributed.Name = "ckIsAmountDistributed";
            this.ckIsAmountDistributed.Size = new System.Drawing.Size(87, 17);
            this.ckIsAmountDistributed.TabIndex = 58;
            this.ckIsAmountDistributed.Text = "Is Distributed";
            this.ckIsAmountDistributed.UseVisualStyleBackColor = true;
            this.ckIsAmountDistributed.CheckedChanged += new System.EventHandler(this.ckIsAmountDistributed_CheckedChanged);
            // 
            // visualStyler1
            // 
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle(null, "Office2007 (Blue).vssf");
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Items.AddRange(new object[] {
            "-- Please Select --",
            "Advice",
            "Invoice",
            "Note",
            "Payment",
            "Collateral",
            "Cancellation"});
            this.cmbPaymentType.Location = new System.Drawing.Point(342, 320);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(118, 21);
            this.cmbPaymentType.TabIndex = 60;
            this.cmbPaymentType.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType_SelectedIndexChanged);
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Location = new System.Drawing.Point(362, 304);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(75, 13);
            this.lblPaymentType.TabIndex = 61;
            this.lblPaymentType.Text = "Payment Type";
            // 
            // lblAmountRemaining
            // 
            this.lblAmountRemaining.AutoSize = true;
            this.lblAmountRemaining.Location = new System.Drawing.Point(506, 283);
            this.lblAmountRemaining.Name = "lblAmountRemaining";
            this.lblAmountRemaining.Size = new System.Drawing.Size(57, 13);
            this.lblAmountRemaining.TabIndex = 63;
            this.lblAmountRemaining.Text = "Remaining";
            // 
            // lblPercentageRemaining
            // 
            this.lblPercentageRemaining.AutoSize = true;
            this.lblPercentageRemaining.Location = new System.Drawing.Point(540, 325);
            this.lblPercentageRemaining.Name = "lblPercentageRemaining";
            this.lblPercentageRemaining.Size = new System.Drawing.Size(36, 13);
            this.lblPercentageRemaining.TabIndex = 63;
            this.lblPercentageRemaining.Text = "%tage";
            // 
            // txtRemainingDistribution
            // 
            this.txtRemainingDistribution.Enabled = false;
            this.txtRemainingDistribution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingDistribution.ForeColor = System.Drawing.Color.Red;
            this.txtRemainingDistribution.Location = new System.Drawing.Point(486, 298);
            this.txtRemainingDistribution.Name = "txtRemainingDistribution";
            this.txtRemainingDistribution.Size = new System.Drawing.Size(96, 20);
            this.txtRemainingDistribution.TabIndex = 64;
            this.txtRemainingDistribution.Text = "0.00";
            this.txtRemainingDistribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRemainingDistribution.Visible = false;
            // 
            // txtRemainingDistributionP_tage
            // 
            this.txtRemainingDistributionP_tage.Enabled = false;
            this.txtRemainingDistributionP_tage.ForeColor = System.Drawing.Color.Red;
            this.txtRemainingDistributionP_tage.Location = new System.Drawing.Point(516, 340);
            this.txtRemainingDistributionP_tage.Name = "txtRemainingDistributionP_tage";
            this.txtRemainingDistributionP_tage.Size = new System.Drawing.Size(64, 20);
            this.txtRemainingDistributionP_tage.TabIndex = 64;
            this.txtRemainingDistributionP_tage.Text = "0.00%";
            this.txtRemainingDistributionP_tage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRemainingDistributionP_tage.Visible = false;
            // 
            // ddgVendor
            // 
            this.ddgVendor.AutoFilter = true;
            this.ddgVendor.AutoSize = true;
            this.ddgVendor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgVendor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgVendor.ClearButtonEnabled = true;
            this.ddgVendor.DataTablePrimaryKey = ((ushort)(0));
            this.ddgVendor.FindButtonEnabled = true;
            this.ddgVendor.HiddenColoumns = new int[0];
            this.ddgVendor.Image = null;
            this.ddgVendor.Location = new System.Drawing.Point(99, 135);
            this.ddgVendor.Margin = new System.Windows.Forms.Padding(0);
            this.ddgVendor.Name = "ddgVendor";
            this.ddgVendor.NewButtonEnabled = true;
            this.ddgVendor.RefreshButtonEnabled = true;
            this.ddgVendor.SelectedColomnIdex = 0;
            this.ddgVendor.SelectedItem = "";
            this.ddgVendor.SelectedRowKey = null;
            this.ddgVendor.ShowGridFunctions = false;
            this.ddgVendor.Size = new System.Drawing.Size(279, 31);
            this.ddgVendor.TabIndex = 62;
            this.ddgVendor.SelectedItemClicked += new System.EventHandler(this.ddgVendor_SelectedItemClicked);
            this.ddgVendor.selectedItemChanged += new System.EventHandler(this.ddgVendor_selectedItemChanged);
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
            this.ddgPaymentReason.Location = new System.Drawing.Point(99, 205);
            this.ddgPaymentReason.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPaymentReason.Name = "ddgPaymentReason";
            this.ddgPaymentReason.NewButtonEnabled = true;
            this.ddgPaymentReason.RefreshButtonEnabled = true;
            this.ddgPaymentReason.SelectedColomnIdex = 0;
            this.ddgPaymentReason.SelectedItem = "";
            this.ddgPaymentReason.SelectedRowKey = null;
            this.ddgPaymentReason.ShowGridFunctions = false;
            this.ddgPaymentReason.Size = new System.Drawing.Size(300, 31);
            this.ddgPaymentReason.TabIndex = 49;
            this.ddgPaymentReason.SelectedItemClicked += new System.EventHandler(this.ddgPaymentReason_SelectedItemClicked);
            this.ddgPaymentReason.selectedItemChanged += new System.EventHandler(this.ddgPaymentReason_selectedItemChanged);
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
            this.ddgPayedFrom.Location = new System.Drawing.Point(99, 169);
            this.ddgPayedFrom.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPayedFrom.Name = "ddgPayedFrom";
            this.ddgPayedFrom.NewButtonEnabled = true;
            this.ddgPayedFrom.RefreshButtonEnabled = true;
            this.ddgPayedFrom.SelectedColomnIdex = 0;
            this.ddgPayedFrom.SelectedItem = "";
            this.ddgPayedFrom.SelectedRowKey = null;
            this.ddgPayedFrom.ShowGridFunctions = false;
            this.ddgPayedFrom.Size = new System.Drawing.Size(332, 31);
            this.ddgPayedFrom.TabIndex = 46;
            this.ddgPayedFrom.SelectedItemClicked += new System.EventHandler(this.ddgPayedFrom_SelectedItemClicked);
            this.ddgPayedFrom.selectedItemChanged += new System.EventHandler(this.ddgPayedFrom_selectedItemChanged);
            // 
            // ntbAmount
            // 
            this.ntbAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmount.AllowedLength = 0;
            this.ntbAmount.AllowLeadingZeros = false;
            this.ntbAmount.AllowNegative = true;
            this.ntbAmount.Amount = "";
            this.ntbAmount.defaultAmount = "0";
            this.ntbAmount.Location = new System.Drawing.Point(104, 319);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmount.ShowThousandSeparetor = true;
            this.ntbAmount.Size = new System.Drawing.Size(128, 23);
            this.ntbAmount.StandardPrecision = 5;
            this.ntbAmount.TabIndex = 44;
            // 
            // frmPurchasePaymentInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 665);
            this.Controls.Add(this.txtRemainingDistributionP_tage);
            this.Controls.Add(this.txtRemainingDistribution);
            this.Controls.Add(this.lblPercentageRemaining);
            this.Controls.Add(this.lblAmountRemaining);
            this.Controls.Add(this.ddgVendor);
            this.Controls.Add(this.lblPaymentType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbPaymentType);
            this.Controls.Add(this.ckIsAmountDistributed);
            this.Controls.Add(this.dtgPaymentGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.ddgPaymentReason);
            this.Controls.Add(this.lblPaymentReason);
            this.Controls.Add(this.ddgPayedFrom);
            this.Controls.Add(this.ntbAmount);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.lblPayedFrom);
            this.Controls.Add(this.lblDescriptionComment);
            this.Controls.Add(this.txtDescriptionComment);
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.grbPurchaseOrder);
            this.Controls.Add(this.lblInvoiceDate);
            this.Controls.Add(this.ckIsEstimateAmount);
            this.Controls.Add(this.lblPaymentAmount);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.mnuMainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPurchasePaymentInvoice";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Invoice (v4.0a)";
            this.Load += new System.EventHandler(this.frmPurchasePaymentInvoice_Load);
            this.DoubleClick += new System.EventHandler(this.frmPurchasePaymentInvoice_DoubleClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchasePaymentInvoice_FormClosing);
            this.grbPurchaseOrder.ResumeLayout(false);
            this.grbPurchaseOrder.PerformLayout();
            this.grbSummary.ResumeLayout(false);
            this.grbSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaymentItemDetail)).EndInit();
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaymentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblPurchaseOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAccumulatedAmount;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtAccumulatedAmount;
        private System.Windows.Forms.TextBox txtPurchaseOrderDate;
        private System.Windows.Forms.CheckBox ckIsEstimateAmount;
        private System.Windows.Forms.GroupBox grbPurchaseOrder;
        private System.Windows.Forms.CheckBox ckIsActive;
        private System.Windows.Forms.TextBox txtDescriptionComment;
        private System.Windows.Forms.Label lblDescriptionComment;
        private System.Windows.Forms.Label lblPayedFrom;
        private System.Windows.Forms.TextBox txtPaymentCount;
        private System.Windows.Forms.Label lblPyementCount;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private ctlNumberTextBox ntbAmount;
        private DropDownDataGrid ddgPurchaseOrders;
        private DropDownDataGrid ddgPayedFrom;
        private System.Windows.Forms.Label lblPaymentReason;
        private DropDownDataGrid ddgPaymentReason;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuTask;
        private System.Windows.Forms.ToolStripMenuItem mnuNewPayment;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripMenuItem mnuExist;
        private System.Windows.Forms.ToolStripMenuItem mnuPayment;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuRecordView;
        private System.Windows.Forms.ToolStripMenuItem mnutoggleView;
        private System.Windows.Forms.ToolStripMenuItem mnuPreviousRecord;
        private System.Windows.Forms.ToolStripMenuItem previousRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNexRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuLastRcord;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripButton tscmdNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tscmdRecord;
        private System.Windows.Forms.ToolStripButton tscmdDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tscmdSearch;
        private System.Windows.Forms.ToolStripButton tscmdToggleView;
        private System.Windows.Forms.ToolStripButton tscmdFirstRecord;
        private System.Windows.Forms.ToolStripButton tscmdPreviousRecord;
        private System.Windows.Forms.ToolStripButton tscmdNextRecord;
        private System.Windows.Forms.ToolStripButton tscmdLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuDocumentation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtCollactableAmount;
        private System.Windows.Forms.Label lblCollecatableAmount;
        private System.Windows.Forms.DataGridView dtgPaymentGridView;
        private System.Windows.Forms.DataGridViewButtonColumn colRowHeading;
        private System.Windows.Forms.DataGridView dtgPaymentItemDetail;
        private System.Windows.Forms.GroupBox grbSummary;
        private System.Windows.Forms.TextBox txtNumberOfOrderLine;
        private DropDownDataGrid ddgCommercialInvoice;
        private System.Windows.Forms.Label lblCommercialInvoice;
        private System.Windows.Forms.ToolStripButton tscmdRefresh;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tscmdHelp;
        private System.Windows.Forms.CheckBox ckIsAmountDistributed;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseInvoice;
        private System.Windows.Forms.CheckBox ckSelectAllLines;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripButton tscmdExit;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintCostSheet;
        private DropDownDataGrid ddgVendor;
        private System.Windows.Forms.Label lblAmountRemaining;
        private System.Windows.Forms.Label lblPercentageRemaining;
        private System.Windows.Forms.TextBox txtRemainingDistribution;
        private System.Windows.Forms.TextBox txtRemainingDistributionP_tage;
        private System.Windows.Forms.ToolStripMenuItem mnuDistributeRemaining;
        private System.Windows.Forms.Label label1;
    }
}

