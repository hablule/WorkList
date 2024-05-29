namespace SRP
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        */

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsCommandToolBar = new System.Windows.Forms.ToolStrip();
            this.tlsNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsDelete = new System.Windows.Forms.ToolStripButton();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsShowCrruntItemTransaction = new System.Windows.Forms.ToolStripButton();
            this.tlsConductPurchase = new System.Windows.Forms.ToolStripButton();
            this.tlsConductSales = new System.Windows.Forms.ToolStripButton();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.lblProductUOM = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblProductUPCEAC = new System.Windows.Forms.Label();
            this.lblProductCurrentQty = new System.Windows.Forms.Label();
            this.lblProductCurrentCost = new System.Windows.Forms.Label();
            this.lblProductAccumulatedCost = new System.Windows.Forms.Label();
            this.lblProductAccumulatedQty = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.cmbProductUOM = new System.Windows.Forms.ComboBox();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.txtProductUPCEAN = new System.Windows.Forms.TextBox();
            this.txtProductAccumulatedQty = new System.Windows.Forms.TextBox();
            this.txtProductCurrentQty = new System.Windows.Forms.TextBox();
            this.txtProductCurrentCost = new System.Windows.Forms.TextBox();
            this.txtProductAccumulatedCost = new System.Windows.Forms.TextBox();
            this.ckProductIsActive = new System.Windows.Forms.CheckBox();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.dtgProductGridView = new System.Windows.Forms.DataGridView();
            this.ofdLoadItemImage = new System.Windows.Forms.OpenFileDialog();
            this.cmdProductUOMConversion = new System.Windows.Forms.Button();
            this.lblProductPurchasePrice = new System.Windows.Forms.Label();
            this.lblProductSellingPrice = new System.Windows.Forms.Label();
            this.lblProductImageBox = new System.Windows.Forms.Label();
            this.pnlUnitConversionPanel = new System.Windows.Forms.Panel();
            this.cmdShowUnitConversion = new System.Windows.Forms.Button();
            this.dtgUnitConversionView = new System.Windows.Forms.DataGridView();
            this.ntbPurchasePrice = new SRP.ctlNumberTextBox();
            this.ntbSellingPrice = new SRP.ctlNumberTextBox();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.lblVendorCode = new System.Windows.Forms.Label();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductGridView)).BeginInit();
            this.pnlUnitConversionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUnitConversionView)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsCommandToolBar
            // 
            this.tlsCommandToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsCommandToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNew,
            this.tlsSave,
            this.tlsDelete,
            this.tlsSearch,
            this.toolStripSeparator1,
            this.tlsShowCrruntItemTransaction,
            this.tlsConductPurchase,
            this.tlsConductSales,
            this.tlsFirstRecord,
            this.tlsPreviousRecord,
            this.tlsNextRecord,
            this.tlsLastRecord});
            this.tlsCommandToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsCommandToolBar.Name = "tlsCommandToolBar";
            this.tlsCommandToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlsCommandToolBar.Size = new System.Drawing.Size(600, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.Image = ((System.Drawing.Image)(resources.GetObject("tlsNew.Image")));
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(32, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsSave.Image")));
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(35, 22);
            this.tlsSave.Text = "Save";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlsDelete.Image")));
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(42, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Visible = false;
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlsSearch.Image")));
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(44, 22);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsShowCrruntItemTransaction
            // 
            this.tlsShowCrruntItemTransaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsShowCrruntItemTransaction.Image = ((System.Drawing.Image)(resources.GetObject("tlsShowCrruntItemTransaction.Image")));
            this.tlsShowCrruntItemTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsShowCrruntItemTransaction.Name = "tlsShowCrruntItemTransaction";
            this.tlsShowCrruntItemTransaction.Size = new System.Drawing.Size(121, 22);
            this.tlsShowCrruntItemTransaction.Text = "Show Item Transaction";
            this.tlsShowCrruntItemTransaction.Click += new System.EventHandler(this.tlsShowCrruntItemTransaction_Click);
            // 
            // tlsConductPurchase
            // 
            this.tlsConductPurchase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsConductPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsConductPurchase.Image = ((System.Drawing.Image)(resources.GetObject("tlsConductPurchase.Image")));
            this.tlsConductPurchase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsConductPurchase.Name = "tlsConductPurchase";
            this.tlsConductPurchase.Size = new System.Drawing.Size(103, 22);
            this.tlsConductPurchase.Text = "Purchase Item";
            this.tlsConductPurchase.Click += new System.EventHandler(this.tlsConductPurchase_Click);
            // 
            // tlsConductSales
            // 
            this.tlsConductSales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsConductSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsConductSales.ForeColor = System.Drawing.Color.Red;
            this.tlsConductSales.Image = ((System.Drawing.Image)(resources.GetObject("tlsConductSales.Image")));
            this.tlsConductSales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsConductSales.Name = "tlsConductSales";
            this.tlsConductSales.Size = new System.Drawing.Size(72, 22);
            this.tlsConductSales.Text = "Sale Item";
            this.tlsConductSales.Click += new System.EventHandler(this.tlsConductSales_Click);
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsFirstRecord.Image")));
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsPreviousRecord.Image")));
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(52, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsNextRecord.Image")));
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(34, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsLastRecord.Image")));
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(31, 22);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.Visible = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(29, 94);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(41, 15);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Name";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(36, 43);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(36, 15);
            this.lblProductCode.TabIndex = 2;
            this.lblProductCode.Text = "Code";
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDescription.Location = new System.Drawing.Point(7, 124);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(69, 15);
            this.lblProductDescription.TabIndex = 3;
            this.lblProductDescription.Text = "Description";
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.AutoSize = true;
            this.lblProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCategory.Location = new System.Drawing.Point(16, 252);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(55, 15);
            this.lblProductCategory.TabIndex = 4;
            this.lblProductCategory.Text = "Category";
            // 
            // lblProductUOM
            // 
            this.lblProductUOM.AutoSize = true;
            this.lblProductUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductUOM.Location = new System.Drawing.Point(204, 253);
            this.lblProductUOM.Name = "lblProductUOM";
            this.lblProductUOM.Size = new System.Drawing.Size(29, 15);
            this.lblProductUOM.TabIndex = 5;
            this.lblProductUOM.Text = "Unit";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductType.Location = new System.Drawing.Point(39, 224);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(33, 15);
            this.lblProductType.TabIndex = 6;
            this.lblProductType.Text = "Type";
            // 
            // lblProductUPCEAC
            // 
            this.lblProductUPCEAC.AutoSize = true;
            this.lblProductUPCEAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductUPCEAC.Location = new System.Drawing.Point(13, 194);
            this.lblProductUPCEAC.Name = "lblProductUPCEAC";
            this.lblProductUPCEAC.Size = new System.Drawing.Size(59, 15);
            this.lblProductUPCEAC.TabIndex = 7;
            this.lblProductUPCEAC.Text = "UPC/EAN";
            // 
            // lblProductCurrentQty
            // 
            this.lblProductCurrentQty.AutoSize = true;
            this.lblProductCurrentQty.Enabled = false;
            this.lblProductCurrentQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCurrentQty.Location = new System.Drawing.Point(24, 329);
            this.lblProductCurrentQty.Name = "lblProductCurrentQty";
            this.lblProductCurrentQty.Size = new System.Drawing.Size(78, 15);
            this.lblProductCurrentQty.TabIndex = 8;
            this.lblProductCurrentQty.Text = "Current Qty";
            // 
            // lblProductCurrentCost
            // 
            this.lblProductCurrentCost.AutoSize = true;
            this.lblProductCurrentCost.Enabled = false;
            this.lblProductCurrentCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCurrentCost.Location = new System.Drawing.Point(16, 354);
            this.lblProductCurrentCost.Name = "lblProductCurrentCost";
            this.lblProductCurrentCost.Size = new System.Drawing.Size(86, 15);
            this.lblProductCurrentCost.TabIndex = 9;
            this.lblProductCurrentCost.Text = "Current Cost";
            this.lblProductCurrentCost.Visible = false;
            // 
            // lblProductAccumulatedCost
            // 
            this.lblProductAccumulatedCost.AutoSize = true;
            this.lblProductAccumulatedCost.Enabled = false;
            this.lblProductAccumulatedCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductAccumulatedCost.Location = new System.Drawing.Point(256, 327);
            this.lblProductAccumulatedCost.Name = "lblProductAccumulatedCost";
            this.lblProductAccumulatedCost.Size = new System.Drawing.Size(121, 15);
            this.lblProductAccumulatedCost.TabIndex = 10;
            this.lblProductAccumulatedCost.Text = "Accumulated Cost";
            this.lblProductAccumulatedCost.Visible = false;
            // 
            // lblProductAccumulatedQty
            // 
            this.lblProductAccumulatedQty.AutoSize = true;
            this.lblProductAccumulatedQty.Enabled = false;
            this.lblProductAccumulatedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductAccumulatedQty.Location = new System.Drawing.Point(264, 352);
            this.lblProductAccumulatedQty.Name = "lblProductAccumulatedQty";
            this.lblProductAccumulatedQty.Size = new System.Drawing.Size(113, 15);
            this.lblProductAccumulatedQty.TabIndex = 11;
            this.lblProductAccumulatedQty.Text = "Accumulated Qty";
            this.lblProductAccumulatedQty.Visible = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(77, 92);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(277, 21);
            this.txtProductName.TabIndex = 13;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(78, 40);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(195, 21);
            this.txtProductCode.TabIndex = 14;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductDescription.Location = new System.Drawing.Point(77, 118);
            this.txtProductDescription.Multiline = true;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(250, 67);
            this.txtProductDescription.TabIndex = 15;
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCategory.DropDownWidth = 150;
            this.cmbProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(78, 249);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(119, 23);
            this.cmbProductCategory.TabIndex = 16;
            this.cmbProductCategory.DropDown += new System.EventHandler(this.cmbProductCategory_DropDown);
            // 
            // cmbProductUOM
            // 
            this.cmbProductUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductUOM.DropDownWidth = 135;
            this.cmbProductUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductUOM.FormattingEnabled = true;
            this.cmbProductUOM.Location = new System.Drawing.Point(239, 249);
            this.cmbProductUOM.Name = "cmbProductUOM";
            this.cmbProductUOM.Size = new System.Drawing.Size(109, 23);
            this.cmbProductUOM.TabIndex = 17;
            this.cmbProductUOM.SelectedIndexChanged += new System.EventHandler(this.cmbProductUOM_SelectedIndexChanged);
            this.cmbProductUOM.DropDown += new System.EventHandler(this.cmbProductUOM_DropDown);
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Items.AddRange(new object[] {
            "Item",
            "Service"});
            this.cmbProductType.Location = new System.Drawing.Point(79, 220);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(101, 23);
            this.cmbProductType.TabIndex = 18;
            // 
            // txtProductUPCEAN
            // 
            this.txtProductUPCEAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductUPCEAN.Location = new System.Drawing.Point(78, 191);
            this.txtProductUPCEAN.Name = "txtProductUPCEAN";
            this.txtProductUPCEAN.Size = new System.Drawing.Size(218, 21);
            this.txtProductUPCEAN.TabIndex = 19;
            // 
            // txtProductAccumulatedQty
            // 
            this.txtProductAccumulatedQty.Enabled = false;
            this.txtProductAccumulatedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductAccumulatedQty.Location = new System.Drawing.Point(381, 349);
            this.txtProductAccumulatedQty.Name = "txtProductAccumulatedQty";
            this.txtProductAccumulatedQty.Size = new System.Drawing.Size(159, 21);
            this.txtProductAccumulatedQty.TabIndex = 20;
            this.txtProductAccumulatedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProductAccumulatedQty.Visible = false;
            // 
            // txtProductCurrentQty
            // 
            this.txtProductCurrentQty.Enabled = false;
            this.txtProductCurrentQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCurrentQty.Location = new System.Drawing.Point(106, 326);
            this.txtProductCurrentQty.Name = "txtProductCurrentQty";
            this.txtProductCurrentQty.Size = new System.Drawing.Size(142, 21);
            this.txtProductCurrentQty.TabIndex = 21;
            this.txtProductCurrentQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProductCurrentCost
            // 
            this.txtProductCurrentCost.Enabled = false;
            this.txtProductCurrentCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCurrentCost.Location = new System.Drawing.Point(106, 351);
            this.txtProductCurrentCost.Name = "txtProductCurrentCost";
            this.txtProductCurrentCost.Size = new System.Drawing.Size(142, 21);
            this.txtProductCurrentCost.TabIndex = 22;
            this.txtProductCurrentCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProductCurrentCost.Visible = false;
            // 
            // txtProductAccumulatedCost
            // 
            this.txtProductAccumulatedCost.Enabled = false;
            this.txtProductAccumulatedCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductAccumulatedCost.Location = new System.Drawing.Point(381, 324);
            this.txtProductAccumulatedCost.Name = "txtProductAccumulatedCost";
            this.txtProductAccumulatedCost.Size = new System.Drawing.Size(159, 21);
            this.txtProductAccumulatedCost.TabIndex = 23;
            this.txtProductAccumulatedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProductAccumulatedCost.Visible = false;
            // 
            // ckProductIsActive
            // 
            this.ckProductIsActive.AutoSize = true;
            this.ckProductIsActive.Checked = true;
            this.ckProductIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProductIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckProductIsActive.Location = new System.Drawing.Point(255, 222);
            this.ckProductIsActive.Name = "ckProductIsActive";
            this.ckProductIsActive.Size = new System.Drawing.Size(69, 19);
            this.ckProductIsActive.TabIndex = 24;
            this.ckProductIsActive.Text = "Is Active";
            this.ckProductIsActive.UseVisualStyleBackColor = true;
            // 
            // pbProductImage
            // 
            this.pbProductImage.BackColor = System.Drawing.Color.LightGray;
            this.pbProductImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbProductImage.Location = new System.Drawing.Point(387, 54);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(204, 168);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 25;
            this.pbProductImage.TabStop = false;
            this.pbProductImage.Click += new System.EventHandler(this.pbProductImage_Click);
            // 
            // dtgProductGridView
            // 
            this.dtgProductGridView.AllowUserToAddRows = false;
            this.dtgProductGridView.AllowUserToDeleteRows = false;
            this.dtgProductGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgProductGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgProductGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgProductGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgProductGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgProductGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgProductGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgProductGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductGridView.Location = new System.Drawing.Point(3, 385);
            this.dtgProductGridView.MultiSelect = false;
            this.dtgProductGridView.Name = "dtgProductGridView";
            this.dtgProductGridView.ReadOnly = true;
            this.dtgProductGridView.RowHeadersWidth = 20;
            this.dtgProductGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProductGridView.Size = new System.Drawing.Size(593, 161);
            this.dtgProductGridView.TabIndex = 26;
            this.dtgProductGridView.SelectionChanged += new System.EventHandler(this.dtgProductGridView_SelectionChanged);
            // 
            // ofdLoadItemImage
            // 
            this.ofdLoadItemImage.Filter = "Image File (*.bmp;*.jpg;*.jpeg;*.tiff;*.tif;*.psd;*.gif;*.png) |*.bmp;*.jpg;*.jpe" +
                "g;*.tiff;*.tif;*.psd;*.gif;*.png";
            // 
            // cmdProductUOMConversion
            // 
            this.cmdProductUOMConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProductUOMConversion.Location = new System.Drawing.Point(353, 249);
            this.cmdProductUOMConversion.Name = "cmdProductUOMConversion";
            this.cmdProductUOMConversion.Size = new System.Drawing.Size(79, 23);
            this.cmdProductUOMConversion.TabIndex = 27;
            this.cmdProductUOMConversion.Text = "Conversion";
            this.cmdProductUOMConversion.UseVisualStyleBackColor = true;
            this.cmdProductUOMConversion.Click += new System.EventHandler(this.cmdProductUOMConversion_Click);
            // 
            // lblProductPurchasePrice
            // 
            this.lblProductPurchasePrice.AutoSize = true;
            this.lblProductPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPurchasePrice.Location = new System.Drawing.Point(16, 292);
            this.lblProductPurchasePrice.Name = "lblProductPurchasePrice";
            this.lblProductPurchasePrice.Size = new System.Drawing.Size(104, 15);
            this.lblProductPurchasePrice.TabIndex = 28;
            this.lblProductPurchasePrice.Text = "Purchase Price";
            this.lblProductPurchasePrice.Visible = false;
            // 
            // lblProductSellingPrice
            // 
            this.lblProductSellingPrice.AutoSize = true;
            this.lblProductSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductSellingPrice.Location = new System.Drawing.Point(218, 292);
            this.lblProductSellingPrice.Name = "lblProductSellingPrice";
            this.lblProductSellingPrice.Size = new System.Drawing.Size(89, 15);
            this.lblProductSellingPrice.TabIndex = 29;
            this.lblProductSellingPrice.Text = "Selling Price";
            // 
            // lblProductImageBox
            // 
            this.lblProductImageBox.AutoSize = true;
            this.lblProductImageBox.BackColor = System.Drawing.Color.White;
            this.lblProductImageBox.Location = new System.Drawing.Point(419, 225);
            this.lblProductImageBox.Name = "lblProductImageBox";
            this.lblProductImageBox.Size = new System.Drawing.Size(150, 13);
            this.lblProductImageBox.TabIndex = 32;
            this.lblProductImageBox.Text = "Product Image -click to Modify";
            // 
            // pnlUnitConversionPanel
            // 
            this.pnlUnitConversionPanel.Controls.Add(this.cmdShowUnitConversion);
            this.pnlUnitConversionPanel.Controls.Add(this.dtgUnitConversionView);
            this.pnlUnitConversionPanel.Location = new System.Drawing.Point(435, 249);
            this.pnlUnitConversionPanel.Name = "pnlUnitConversionPanel";
            this.pnlUnitConversionPanel.Size = new System.Drawing.Size(161, 25);
            this.pnlUnitConversionPanel.TabIndex = 33;
            this.pnlUnitConversionPanel.Visible = false;
            // 
            // cmdShowUnitConversion
            // 
            this.cmdShowUnitConversion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdShowUnitConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowUnitConversion.ForeColor = System.Drawing.Color.Red;
            this.cmdShowUnitConversion.Location = new System.Drawing.Point(3, 0);
            this.cmdShowUnitConversion.Name = "cmdShowUnitConversion";
            this.cmdShowUnitConversion.Size = new System.Drawing.Size(154, 24);
            this.cmdShowUnitConversion.TabIndex = 1;
            this.cmdShowUnitConversion.Text = "show";
            this.cmdShowUnitConversion.UseVisualStyleBackColor = true;
            this.cmdShowUnitConversion.Click += new System.EventHandler(this.cmdShowUnitConversion_Click);
            // 
            // dtgUnitConversionView
            // 
            this.dtgUnitConversionView.AllowUserToAddRows = false;
            this.dtgUnitConversionView.AllowUserToDeleteRows = false;
            this.dtgUnitConversionView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgUnitConversionView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgUnitConversionView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUnitConversionView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgUnitConversionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUnitConversionView.Location = new System.Drawing.Point(3, 0);
            this.dtgUnitConversionView.MultiSelect = false;
            this.dtgUnitConversionView.Name = "dtgUnitConversionView";
            this.dtgUnitConversionView.RowHeadersVisible = false;
            this.dtgUnitConversionView.Size = new System.Drawing.Size(158, 25);
            this.dtgUnitConversionView.TabIndex = 0;
            this.dtgUnitConversionView.Visible = false;
            // 
            // ntbPurchasePrice
            // 
            this.ntbPurchasePrice.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbPurchasePrice.AllowedLength = 0;
            this.ntbPurchasePrice.AllowLeadingZeros = false;
            this.ntbPurchasePrice.AllowNegative = false;
            this.ntbPurchasePrice.Amount = "0.00";
            this.ntbPurchasePrice.defaultAmount = "0";
            this.ntbPurchasePrice.Location = new System.Drawing.Point(125, 289);
            this.ntbPurchasePrice.Name = "ntbPurchasePrice";
            this.ntbPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPurchasePrice.ShowThousandSeparetor = true;
            this.ntbPurchasePrice.Size = new System.Drawing.Size(87, 23);
            this.ntbPurchasePrice.StandardPrecision = 2;
            this.ntbPurchasePrice.TabIndex = 30;
            this.ntbPurchasePrice.Visible = false;
            // 
            // ntbSellingPrice
            // 
            this.ntbSellingPrice.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbSellingPrice.AllowedLength = 0;
            this.ntbSellingPrice.AllowLeadingZeros = false;
            this.ntbSellingPrice.AllowNegative = false;
            this.ntbSellingPrice.Amount = "0.00";
            this.ntbSellingPrice.defaultAmount = "0";
            this.ntbSellingPrice.Location = new System.Drawing.Point(309, 289);
            this.ntbSellingPrice.Name = "ntbSellingPrice";
            this.ntbSellingPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSellingPrice.ShowThousandSeparetor = true;
            this.ntbSellingPrice.Size = new System.Drawing.Size(93, 23);
            this.ntbSellingPrice.StandardPrecision = 2;
            this.ntbSellingPrice.TabIndex = 30;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorCode.Location = new System.Drawing.Point(77, 66);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(219, 21);
            this.txtVendorCode.TabIndex = 35;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.AutoSize = true;
            this.lblVendorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCode.Location = new System.Drawing.Point(26, 69);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(46, 15);
            this.lblVendorCode.TabIndex = 34;
            this.lblVendorCode.Text = "Code 2";
            // 
            // frmProduct
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.lblVendorCode);
            this.Controls.Add(this.lblProductImageBox);
            this.Controls.Add(this.ntbPurchasePrice);
            this.Controls.Add(this.ntbSellingPrice);
            this.Controls.Add(this.lblProductSellingPrice);
            this.Controls.Add(this.lblProductPurchasePrice);
            this.Controls.Add(this.cmdProductUOMConversion);
            this.Controls.Add(this.dtgProductGridView);
            this.Controls.Add(this.pbProductImage);
            this.Controls.Add(this.ckProductIsActive);
            this.Controls.Add(this.txtProductAccumulatedCost);
            this.Controls.Add(this.txtProductCurrentCost);
            this.Controls.Add(this.txtProductCurrentQty);
            this.Controls.Add(this.txtProductAccumulatedQty);
            this.Controls.Add(this.txtProductUPCEAN);
            this.Controls.Add(this.cmbProductType);
            this.Controls.Add(this.cmbProductUOM);
            this.Controls.Add(this.cmbProductCategory);
            this.Controls.Add(this.txtProductDescription);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductAccumulatedQty);
            this.Controls.Add(this.lblProductAccumulatedCost);
            this.Controls.Add(this.lblProductCurrentCost);
            this.Controls.Add(this.lblProductCurrentQty);
            this.Controls.Add(this.lblProductUPCEAC);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.lblProductUOM);
            this.Controls.Add(this.lblProductCategory);
            this.Controls.Add(this.lblProductDescription);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.pnlUnitConversionPanel);
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductGridView)).EndInit();
            this.pnlUnitConversionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUnitConversionView)).EndInit();
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
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.Label lblProductUOM;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblProductUPCEAC;
        private System.Windows.Forms.Label lblProductCurrentQty;
        private System.Windows.Forms.Label lblProductCurrentCost;
        private System.Windows.Forms.Label lblProductAccumulatedCost;
        private System.Windows.Forms.Label lblProductAccumulatedQty;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.ComboBox cmbProductUOM;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.TextBox txtProductUPCEAN;
        private System.Windows.Forms.TextBox txtProductAccumulatedQty;
        private System.Windows.Forms.TextBox txtProductCurrentQty;
        private System.Windows.Forms.TextBox txtProductCurrentCost;
        private System.Windows.Forms.TextBox txtProductAccumulatedCost;
        private System.Windows.Forms.CheckBox ckProductIsActive;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.DataGridView dtgProductGridView;
        private System.Windows.Forms.OpenFileDialog ofdLoadItemImage;
        private System.Windows.Forms.ToolStripButton tlsConductSales;
        private System.Windows.Forms.ToolStripButton tlsConductPurchase;
        private System.Windows.Forms.Button cmdProductUOMConversion;
        private System.Windows.Forms.Label lblProductPurchasePrice;
        private System.Windows.Forms.Label lblProductSellingPrice;
        private ctlNumberTextBox ntbSellingPrice;
        private System.Windows.Forms.ToolStripButton tlsShowCrruntItemTransaction;
        private ctlNumberTextBox ntbPurchasePrice;
        private System.Windows.Forms.Label lblProductImageBox;
        private System.Windows.Forms.Panel pnlUnitConversionPanel;
        private System.Windows.Forms.Button cmdShowUnitConversion;
        private System.Windows.Forms.DataGridView dtgUnitConversionView;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.Label lblVendorCode;
    }
}