namespace SRP
{
    partial class frmTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransaction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsCommandToolBar = new System.Windows.Forms.ToolStrip();
            this.tlsNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsDelete = new System.Windows.Forms.ToolStripButton();
            this.tlsReverse = new System.Windows.Forms.ToolStripButton();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.tlsToogleView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsPrint = new System.Windows.Forms.ToolStripButton();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.dtgTransactionGridView = new System.Windows.Forms.DataGridView();
            this.lblTrxDocumentNo = new System.Windows.Forms.Label();
            this.lblTrxDescription = new System.Windows.Forms.Label();
            this.lblTrxDate = new System.Windows.Forms.Label();
            this.lblTrxBpartner = new System.Windows.Forms.Label();
            this.lblDetailTrxProduct = new System.Windows.Forms.Label();
            this.lblDetailTrxQuantity = new System.Windows.Forms.Label();
            this.lblDetailTrxDescription = new System.Windows.Forms.Label();
            this.txtTrxDocumentNo = new System.Windows.Forms.TextBox();
            this.txtTrxDescription = new System.Windows.Forms.TextBox();
            this.txtDetailTrxDescription = new System.Windows.Forms.TextBox();
            this.dtpTrxDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactionSubTotal = new System.Windows.Forms.Label();
            this.lblDetailTrxUnit = new System.Windows.Forms.Label();
            this.cmdDetailTrxProductImage = new System.Windows.Forms.Button();
            this.cmdDetailTrxAddLine = new System.Windows.Forms.Button();
            this.ckDetailTrxLinePrctage = new System.Windows.Forms.CheckBox();
            this.txtDetailTrxLineTotal = new System.Windows.Forms.TextBox();
            this.lblDetailTrxLineTotal = new System.Windows.Forms.Label();
            this.cmbDetailTrxOtherUOM = new System.Windows.Forms.ComboBox();
            this.lblDetailTrxLineTax = new System.Windows.Forms.Label();
            this.lblDetailTrxPrice = new System.Windows.Forms.Label();
            this.dtgTransactionDetail = new System.Windows.Forms.DataGridView();
            this.lblTransactionTax = new System.Windows.Forms.Label();
            this.lblTransactionGrandTotal = new System.Windows.Forms.Label();
            this.lblTrxTaxTotal = new System.Windows.Forms.Label();
            this.lblTrxSubTotal = new System.Windows.Forms.Label();
            this.lblTrxGrandTotal = new System.Windows.Forms.Label();
            this.cmdDetailTrxNewProduct = new System.Windows.Forms.Button();
            this.lblDetailTrxWarehouse = new System.Windows.Forms.Label();
            this.cmbDetailTrxDispatchingStore = new System.Windows.Forms.ComboBox();
            this.cmdNewBpartner = new System.Windows.Forms.Button();
            this.lblDetailTrxStockQty = new System.Windows.Forms.Label();
            this.txtDetailTrxStockQty = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.ntbDetailTrxTax = new SRP.ctlNumberTextBox();
            this.ntbDetailTrxUnitPrice = new SRP.ctlNumberTextBox();
            this.ddgTrxBpartner = new SRP.DropDownDataGrid();
            this.ntbDetailTrxQuantity = new SRP.ctlNumberTextBox();
            this.ddgDetailProduct = new SRP.DropDownDataGrid();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactionDetail)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsCommandToolBar
            // 
            this.tlsCommandToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsCommandToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNew,
            this.tlsSave,
            this.tlsDelete,
            this.tlsReverse,
            this.tlsSearch,
            this.tlsToogleView,
            this.toolStripSeparator1,
            this.tlsPrint,
            this.tlsFirstRecord,
            this.tlsPreviousRecord,
            this.tlsNextRecord,
            this.tlsLastRecord});
            this.tlsCommandToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsCommandToolBar.Name = "tlsCommandToolBar";
            this.tlsCommandToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlsCommandToolBar.Size = new System.Drawing.Size(741, 25);
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
            this.tlsSave.Size = new System.Drawing.Size(48, 22);
            this.tlsSave.Text = "Process";
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
            this.tlsDelete.Click += new System.EventHandler(this.tlsDelete_Click);
            // 
            // tlsReverse
            // 
            this.tlsReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsReverse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsReverse.ForeColor = System.Drawing.Color.Red;
            this.tlsReverse.Image = ((System.Drawing.Image)(resources.GetObject("tlsReverse.Image")));
            this.tlsReverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsReverse.Name = "tlsReverse";
            this.tlsReverse.Size = new System.Drawing.Size(58, 22);
            this.tlsReverse.Text = "Reverse";
            this.tlsReverse.Click += new System.EventHandler(this.tlsReverse_Click);
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
            // tlsToogleView
            // 
            this.tlsToogleView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsToogleView.Image = ((System.Drawing.Image)(resources.GetObject("tlsToogleView.Image")));
            this.tlsToogleView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsToogleView.Name = "tlsToogleView";
            this.tlsToogleView.Size = new System.Drawing.Size(55, 22);
            this.tlsToogleView.Text = "Grid View";
            this.tlsToogleView.Click += new System.EventHandler(this.tlsToogleView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsPrint
            // 
            this.tlsPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsPrint.Image")));
            this.tlsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPrint.Name = "tlsPrint";
            this.tlsPrint.Size = new System.Drawing.Size(33, 22);
            this.tlsPrint.Text = "Print";
            this.tlsPrint.Click += new System.EventHandler(this.tlsPrint_Click);
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
            this.tlsLastRecord.Size = new System.Drawing.Size(23, 22);
            // 
            // dtgTransactionGridView
            // 
            this.dtgTransactionGridView.AllowUserToAddRows = false;
            this.dtgTransactionGridView.AllowUserToDeleteRows = false;
            this.dtgTransactionGridView.AllowUserToResizeColumns = false;
            this.dtgTransactionGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgTransactionGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgTransactionGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgTransactionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgTransactionGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgTransactionGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTransactionGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dtgTransactionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTransactionGridView.Location = new System.Drawing.Point(2, 26);
            this.dtgTransactionGridView.MultiSelect = false;
            this.dtgTransactionGridView.Name = "dtgTransactionGridView";
            this.dtgTransactionGridView.ReadOnly = true;
            this.dtgTransactionGridView.RowHeadersWidth = 20;
            this.dtgTransactionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTransactionGridView.Size = new System.Drawing.Size(10, 339);
            this.dtgTransactionGridView.TabIndex = 1;
            this.dtgTransactionGridView.Visible = false;
            this.dtgTransactionGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTransactionGridView_CellClick);
            // 
            // lblTrxDocumentNo
            // 
            this.lblTrxDocumentNo.AutoSize = true;
            this.lblTrxDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxDocumentNo.Location = new System.Drawing.Point(38, 65);
            this.lblTrxDocumentNo.Name = "lblTrxDocumentNo";
            this.lblTrxDocumentNo.Size = new System.Drawing.Size(72, 15);
            this.lblTrxDocumentNo.TabIndex = 2;
            this.lblTrxDocumentNo.Text = "Document";
            this.lblTrxDocumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrxDescription
            // 
            this.lblTrxDescription.AutoSize = true;
            this.lblTrxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxDescription.Location = new System.Drawing.Point(30, 119);
            this.lblTrxDescription.Name = "lblTrxDescription";
            this.lblTrxDescription.Size = new System.Drawing.Size(80, 15);
            this.lblTrxDescription.TabIndex = 3;
            this.lblTrxDescription.Text = "Description";
            this.lblTrxDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrxDate
            // 
            this.lblTrxDate.AutoSize = true;
            this.lblTrxDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxDate.Location = new System.Drawing.Point(74, 91);
            this.lblTrxDate.Name = "lblTrxDate";
            this.lblTrxDate.Size = new System.Drawing.Size(37, 15);
            this.lblTrxDate.TabIndex = 4;
            this.lblTrxDate.Text = "Date";
            this.lblTrxDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrxBpartner
            // 
            this.lblTrxBpartner.AutoSize = true;
            this.lblTrxBpartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxBpartner.Location = new System.Drawing.Point(349, 45);
            this.lblTrxBpartner.Name = "lblTrxBpartner";
            this.lblTrxBpartner.Size = new System.Drawing.Size(68, 15);
            this.lblTrxBpartner.TabIndex = 5;
            this.lblTrxBpartner.Text = "Customer";
            // 
            // lblDetailTrxProduct
            // 
            this.lblDetailTrxProduct.AutoSize = true;
            this.lblDetailTrxProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxProduct.Location = new System.Drawing.Point(62, 15);
            this.lblDetailTrxProduct.Name = "lblDetailTrxProduct";
            this.lblDetailTrxProduct.Size = new System.Drawing.Size(56, 15);
            this.lblDetailTrxProduct.TabIndex = 6;
            this.lblDetailTrxProduct.Text = "Product";
            this.lblDetailTrxProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetailTrxQuantity
            // 
            this.lblDetailTrxQuantity.AutoSize = true;
            this.lblDetailTrxQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxQuantity.Location = new System.Drawing.Point(42, 65);
            this.lblDetailTrxQuantity.Name = "lblDetailTrxQuantity";
            this.lblDetailTrxQuantity.Size = new System.Drawing.Size(76, 15);
            this.lblDetailTrxQuantity.TabIndex = 7;
            this.lblDetailTrxQuantity.Text = "Qty Bought";
            this.lblDetailTrxQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetailTrxDescription
            // 
            this.lblDetailTrxDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxDescription.Location = new System.Drawing.Point(41, 113);
            this.lblDetailTrxDescription.Name = "lblDetailTrxDescription";
            this.lblDetailTrxDescription.Size = new System.Drawing.Size(80, 35);
            this.lblDetailTrxDescription.TabIndex = 8;
            this.lblDetailTrxDescription.Text = "Description/Comment";
            this.lblDetailTrxDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTrxDocumentNo
            // 
            this.txtTrxDocumentNo.Location = new System.Drawing.Point(115, 63);
            this.txtTrxDocumentNo.Name = "txtTrxDocumentNo";
            this.txtTrxDocumentNo.Size = new System.Drawing.Size(163, 20);
            this.txtTrxDocumentNo.TabIndex = 10;
            // 
            // txtTrxDescription
            // 
            this.txtTrxDescription.Location = new System.Drawing.Point(115, 114);
            this.txtTrxDescription.Multiline = true;
            this.txtTrxDescription.Name = "txtTrxDescription";
            this.txtTrxDescription.Size = new System.Drawing.Size(561, 61);
            this.txtTrxDescription.TabIndex = 11;
            // 
            // txtDetailTrxDescription
            // 
            this.txtDetailTrxDescription.Location = new System.Drawing.Point(123, 112);
            this.txtDetailTrxDescription.Multiline = true;
            this.txtDetailTrxDescription.Name = "txtDetailTrxDescription";
            this.txtDetailTrxDescription.Size = new System.Drawing.Size(218, 69);
            this.txtDetailTrxDescription.TabIndex = 12;
            // 
            // dtpTrxDate
            // 
            this.dtpTrxDate.Location = new System.Drawing.Point(115, 88);
            this.dtpTrxDate.Name = "dtpTrxDate";
            this.dtpTrxDate.Size = new System.Drawing.Size(197, 20);
            this.dtpTrxDate.TabIndex = 13;
            // 
            // lblTransactionSubTotal
            // 
            this.lblTransactionSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransactionSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionSubTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTransactionSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionSubTotal.Location = new System.Drawing.Point(572, 603);
            this.lblTransactionSubTotal.Name = "lblTransactionSubTotal";
            this.lblTransactionSubTotal.Size = new System.Drawing.Size(164, 22);
            this.lblTransactionSubTotal.TabIndex = 14;
            this.lblTransactionSubTotal.Text = "0.00";
            this.lblTransactionSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetailTrxUnit
            // 
            this.lblDetailTrxUnit.AutoSize = true;
            this.lblDetailTrxUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxUnit.Location = new System.Drawing.Point(443, 134);
            this.lblDetailTrxUnit.Name = "lblDetailTrxUnit";
            this.lblDetailTrxUnit.Size = new System.Drawing.Size(19, 15);
            this.lblDetailTrxUnit.TabIndex = 18;
            this.lblDetailTrxUnit.Text = "---";
            this.lblDetailTrxUnit.Visible = false;
            // 
            // cmdDetailTrxProductImage
            // 
            this.cmdDetailTrxProductImage.Location = new System.Drawing.Point(509, 17);
            this.cmdDetailTrxProductImage.Name = "cmdDetailTrxProductImage";
            this.cmdDetailTrxProductImage.Size = new System.Drawing.Size(16, 15);
            this.cmdDetailTrxProductImage.TabIndex = 19;
            this.cmdDetailTrxProductImage.Text = "...";
            this.cmdDetailTrxProductImage.UseVisualStyleBackColor = true;
            this.cmdDetailTrxProductImage.Click += new System.EventHandler(this.cmdDetailTrxProductImage_Click);
            // 
            // cmdDetailTrxAddLine
            // 
            this.cmdDetailTrxAddLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetailTrxAddLine.Location = new System.Drawing.Point(359, 81);
            this.cmdDetailTrxAddLine.Name = "cmdDetailTrxAddLine";
            this.cmdDetailTrxAddLine.Size = new System.Drawing.Size(84, 45);
            this.cmdDetailTrxAddLine.TabIndex = 20;
            this.cmdDetailTrxAddLine.Text = "Add";
            this.cmdDetailTrxAddLine.UseVisualStyleBackColor = true;
            this.cmdDetailTrxAddLine.Click += new System.EventHandler(this.cmdDetailTrxAddLine_Click);
            // 
            // ckDetailTrxLinePrctage
            // 
            this.ckDetailTrxLinePrctage.AutoSize = true;
            this.ckDetailTrxLinePrctage.BackColor = System.Drawing.Color.LightGray;
            this.ckDetailTrxLinePrctage.Checked = true;
            this.ckDetailTrxLinePrctage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDetailTrxLinePrctage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDetailTrxLinePrctage.Location = new System.Drawing.Point(365, 155);
            this.ckDetailTrxLinePrctage.Name = "ckDetailTrxLinePrctage";
            this.ckDetailTrxLinePrctage.Size = new System.Drawing.Size(53, 19);
            this.ckDetailTrxLinePrctage.TabIndex = 28;
            this.ckDetailTrxLinePrctage.Text = "Is %";
            this.ckDetailTrxLinePrctage.UseVisualStyleBackColor = false;
            this.ckDetailTrxLinePrctage.Visible = false;
            // 
            // txtDetailTrxLineTotal
            // 
            this.txtDetailTrxLineTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDetailTrxLineTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailTrxLineTotal.ForeColor = System.Drawing.Color.Red;
            this.txtDetailTrxLineTotal.Location = new System.Drawing.Point(552, 93);
            this.txtDetailTrxLineTotal.Name = "txtDetailTrxLineTotal";
            this.txtDetailTrxLineTotal.ReadOnly = true;
            this.txtDetailTrxLineTotal.Size = new System.Drawing.Size(89, 21);
            this.txtDetailTrxLineTotal.TabIndex = 27;
            this.txtDetailTrxLineTotal.Text = "0.00";
            this.txtDetailTrxLineTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDetailTrxLineTotal
            // 
            this.lblDetailTrxLineTotal.AutoSize = true;
            this.lblDetailTrxLineTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxLineTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxLineTotal.Location = new System.Drawing.Point(456, 93);
            this.lblDetailTrxLineTotal.Name = "lblDetailTrxLineTotal";
            this.lblDetailTrxLineTotal.Size = new System.Drawing.Size(87, 15);
            this.lblDetailTrxLineTotal.TabIndex = 26;
            this.lblDetailTrxLineTotal.Text = "Line Amount";
            // 
            // cmbDetailTrxOtherUOM
            // 
            this.cmbDetailTrxOtherUOM.BackColor = System.Drawing.Color.White;
            this.cmbDetailTrxOtherUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailTrxOtherUOM.DropDownWidth = 100;
            this.cmbDetailTrxOtherUOM.FormattingEnabled = true;
            this.cmbDetailTrxOtherUOM.Location = new System.Drawing.Point(265, 65);
            this.cmbDetailTrxOtherUOM.Name = "cmbDetailTrxOtherUOM";
            this.cmbDetailTrxOtherUOM.Size = new System.Drawing.Size(73, 21);
            this.cmbDetailTrxOtherUOM.TabIndex = 25;
            this.cmbDetailTrxOtherUOM.SelectedIndexChanged += new System.EventHandler(this.cmbDetailTrxOtherUOM_SelectedIndexChanged);
            // 
            // lblDetailTrxLineTax
            // 
            this.lblDetailTrxLineTax.AutoSize = true;
            this.lblDetailTrxLineTax.BackColor = System.Drawing.Color.LightGray;
            this.lblDetailTrxLineTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxLineTax.Location = new System.Drawing.Point(362, 134);
            this.lblDetailTrxLineTax.Name = "lblDetailTrxLineTax";
            this.lblDetailTrxLineTax.Size = new System.Drawing.Size(30, 15);
            this.lblDetailTrxLineTax.TabIndex = 22;
            this.lblDetailTrxLineTax.Text = "Tax";
            this.lblDetailTrxLineTax.Visible = false;
            // 
            // lblDetailTrxPrice
            // 
            this.lblDetailTrxPrice.AutoSize = true;
            this.lblDetailTrxPrice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxPrice.Location = new System.Drawing.Point(78, 88);
            this.lblDetailTrxPrice.Name = "lblDetailTrxPrice";
            this.lblDetailTrxPrice.Size = new System.Drawing.Size(40, 15);
            this.lblDetailTrxPrice.TabIndex = 21;
            this.lblDetailTrxPrice.Text = "Price";
            // 
            // dtgTransactionDetail
            // 
            this.dtgTransactionDetail.AllowUserToAddRows = false;
            this.dtgTransactionDetail.AllowUserToDeleteRows = false;
            this.dtgTransactionDetail.AllowUserToResizeColumns = false;
            this.dtgTransactionDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgTransactionDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgTransactionDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgTransactionDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgTransactionDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgTransactionDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = null;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTransactionDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dtgTransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTransactionDetail.DefaultCellStyle = dataGridViewCellStyle20;
            this.dtgTransactionDetail.Location = new System.Drawing.Point(3, 368);
            this.dtgTransactionDetail.MultiSelect = false;
            this.dtgTransactionDetail.Name = "dtgTransactionDetail";
            this.dtgTransactionDetail.ReadOnly = true;
            this.dtgTransactionDetail.RowHeadersVisible = false;
            this.dtgTransactionDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTransactionDetail.Size = new System.Drawing.Size(734, 232);
            this.dtgTransactionDetail.TabIndex = 23;
            this.dtgTransactionDetail.Sorted += new System.EventHandler(this.dtgTransactionDetail_Sorted);
            this.dtgTransactionDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTransactionDetail_CellClick);
            // 
            // lblTransactionTax
            // 
            this.lblTransactionTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransactionTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTransactionTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionTax.Location = new System.Drawing.Point(572, 626);
            this.lblTransactionTax.Name = "lblTransactionTax";
            this.lblTransactionTax.Size = new System.Drawing.Size(164, 22);
            this.lblTransactionTax.TabIndex = 24;
            this.lblTransactionTax.Text = "0.00";
            this.lblTransactionTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTransactionGrandTotal
            // 
            this.lblTransactionGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransactionGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionGrandTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTransactionGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionGrandTotal.ForeColor = System.Drawing.Color.Brown;
            this.lblTransactionGrandTotal.Location = new System.Drawing.Point(572, 649);
            this.lblTransactionGrandTotal.Name = "lblTransactionGrandTotal";
            this.lblTransactionGrandTotal.Size = new System.Drawing.Size(164, 22);
            this.lblTransactionGrandTotal.TabIndex = 25;
            this.lblTransactionGrandTotal.Text = "0.00";
            this.lblTransactionGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrxTaxTotal
            // 
            this.lblTrxTaxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrxTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrxTaxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxTaxTotal.Location = new System.Drawing.Point(477, 626);
            this.lblTrxTaxTotal.Name = "lblTrxTaxTotal";
            this.lblTrxTaxTotal.Size = new System.Drawing.Size(100, 22);
            this.lblTrxTaxTotal.TabIndex = 26;
            this.lblTrxTaxTotal.Text = "Tax Total";
            this.lblTrxTaxTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrxSubTotal
            // 
            this.lblTrxSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrxSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrxSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxSubTotal.Location = new System.Drawing.Point(477, 603);
            this.lblTrxSubTotal.Name = "lblTrxSubTotal";
            this.lblTrxSubTotal.Size = new System.Drawing.Size(100, 22);
            this.lblTrxSubTotal.TabIndex = 26;
            this.lblTrxSubTotal.Text = "Line Total";
            this.lblTrxSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrxGrandTotal
            // 
            this.lblTrxGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrxGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrxGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxGrandTotal.Location = new System.Drawing.Point(477, 649);
            this.lblTrxGrandTotal.Name = "lblTrxGrandTotal";
            this.lblTrxGrandTotal.Size = new System.Drawing.Size(100, 22);
            this.lblTrxGrandTotal.TabIndex = 26;
            this.lblTrxGrandTotal.Text = "Grand Total";
            this.lblTrxGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdDetailTrxNewProduct
            // 
            this.cmdDetailTrxNewProduct.Font = new System.Drawing.Font("Papyrus", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetailTrxNewProduct.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.cmdDetailTrxNewProduct.Location = new System.Drawing.Point(541, 13);
            this.cmdDetailTrxNewProduct.Name = "cmdDetailTrxNewProduct";
            this.cmdDetailTrxNewProduct.Size = new System.Drawing.Size(43, 23);
            this.cmdDetailTrxNewProduct.TabIndex = 30;
            this.cmdDetailTrxNewProduct.Text = "New";
            this.cmdDetailTrxNewProduct.UseVisualStyleBackColor = true;
            this.cmdDetailTrxNewProduct.Click += new System.EventHandler(this.cmdDetailTrxNewProduct_Click);
            // 
            // lblDetailTrxWarehouse
            // 
            this.lblDetailTrxWarehouse.AutoSize = true;
            this.lblDetailTrxWarehouse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxWarehouse.Location = new System.Drawing.Point(14, 43);
            this.lblDetailTrxWarehouse.Name = "lblDetailTrxWarehouse";
            this.lblDetailTrxWarehouse.Size = new System.Drawing.Size(104, 15);
            this.lblDetailTrxWarehouse.TabIndex = 31;
            this.lblDetailTrxWarehouse.Text = "Despatch From";
            this.lblDetailTrxWarehouse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDetailTrxDispatchingStore
            // 
            this.cmbDetailTrxDispatchingStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailTrxDispatchingStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetailTrxDispatchingStore.FormattingEnabled = true;
            this.cmbDetailTrxDispatchingStore.Location = new System.Drawing.Point(124, 43);
            this.cmbDetailTrxDispatchingStore.Name = "cmbDetailTrxDispatchingStore";
            this.cmbDetailTrxDispatchingStore.Size = new System.Drawing.Size(214, 21);
            this.cmbDetailTrxDispatchingStore.TabIndex = 32;
            this.cmbDetailTrxDispatchingStore.SelectedIndexChanged += new System.EventHandler(this.cmbDetailTrxDispatchingStore_SelectedIndexChanged);
            // 
            // cmdNewBpartner
            // 
            this.cmdNewBpartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewBpartner.ForeColor = System.Drawing.Color.Tomato;
            this.cmdNewBpartner.Location = new System.Drawing.Point(688, 42);
            this.cmdNewBpartner.Name = "cmdNewBpartner";
            this.cmdNewBpartner.Size = new System.Drawing.Size(41, 23);
            this.cmdNewBpartner.TabIndex = 33;
            this.cmdNewBpartner.Text = "New...";
            this.cmdNewBpartner.UseVisualStyleBackColor = true;
            this.cmdNewBpartner.Click += new System.EventHandler(this.cmdNewBpartner_Click);
            // 
            // lblDetailTrxStockQty
            // 
            this.lblDetailTrxStockQty.AutoSize = true;
            this.lblDetailTrxStockQty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDetailTrxStockQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTrxStockQty.Location = new System.Drawing.Point(443, 163);
            this.lblDetailTrxStockQty.Name = "lblDetailTrxStockQty";
            this.lblDetailTrxStockQty.Size = new System.Drawing.Size(42, 15);
            this.lblDetailTrxStockQty.TabIndex = 35;
            this.lblDetailTrxStockQty.Text = "Stock";
            this.lblDetailTrxStockQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDetailTrxStockQty.Visible = false;
            // 
            // txtDetailTrxStockQty
            // 
            this.txtDetailTrxStockQty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDetailTrxStockQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailTrxStockQty.ForeColor = System.Drawing.Color.Black;
            this.txtDetailTrxStockQty.Location = new System.Drawing.Point(344, 42);
            this.txtDetailTrxStockQty.Name = "txtDetailTrxStockQty";
            this.txtDetailTrxStockQty.ReadOnly = true;
            this.txtDetailTrxStockQty.Size = new System.Drawing.Size(100, 21);
            this.txtDetailTrxStockQty.TabIndex = 27;
            this.txtDetailTrxStockQty.Text = "0";
            this.txtDetailTrxStockQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(741, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganisation.Location = new System.Drawing.Point(22, 41);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(89, 15);
            this.lblOrganisation.TabIndex = 37;
            this.lblOrganisation.Text = "Organisation";
            this.lblOrganisation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(115, 38);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(197, 21);
            this.cmbOrganisation.TabIndex = 38;
            this.cmbOrganisation.SelectedIndexChanged += new System.EventHandler(this.cmbOrganisation_SelectedIndexChanged);
            this.cmbOrganisation.DropDown += new System.EventHandler(this.cmbOrganisation_DropDown);
            // 
            // ntbDetailTrxTax
            // 
            this.ntbDetailTrxTax.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbDetailTrxTax.AllowedLength = 0;
            this.ntbDetailTrxTax.AllowLeadingZeros = false;
            this.ntbDetailTrxTax.AllowNegative = false;
            this.ntbDetailTrxTax.Amount = "15";
            this.ntbDetailTrxTax.BackColor = System.Drawing.Color.LightGray;
            this.ntbDetailTrxTax.defaultAmount = "0";
            this.ntbDetailTrxTax.Enabled = false;
            this.ntbDetailTrxTax.Location = new System.Drawing.Point(228, 87);
            this.ntbDetailTrxTax.Name = "ntbDetailTrxTax";
            this.ntbDetailTrxTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbDetailTrxTax.ShowThousandSeparetor = true;
            this.ntbDetailTrxTax.Size = new System.Drawing.Size(29, 23);
            this.ntbDetailTrxTax.StandardPrecision = 2;
            this.ntbDetailTrxTax.TabIndex = 24;
            this.ntbDetailTrxTax.Visible = false;
            // 
            // ntbDetailTrxUnitPrice
            // 
            this.ntbDetailTrxUnitPrice.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbDetailTrxUnitPrice.AllowedLength = 0;
            this.ntbDetailTrxUnitPrice.AllowLeadingZeros = false;
            this.ntbDetailTrxUnitPrice.AllowNegative = false;
            this.ntbDetailTrxUnitPrice.Amount = "";
            this.ntbDetailTrxUnitPrice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ntbDetailTrxUnitPrice.defaultAmount = "0";
            this.ntbDetailTrxUnitPrice.Location = new System.Drawing.Point(122, 87);
            this.ntbDetailTrxUnitPrice.Name = "ntbDetailTrxUnitPrice";
            this.ntbDetailTrxUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbDetailTrxUnitPrice.ShowThousandSeparetor = true;
            this.ntbDetailTrxUnitPrice.Size = new System.Drawing.Size(105, 23);
            this.ntbDetailTrxUnitPrice.StandardPrecision = 2;
            this.ntbDetailTrxUnitPrice.TabIndex = 23;
            this.ntbDetailTrxUnitPrice.Leave += new System.EventHandler(this.ntbDetailTrxUnitPrice_Leave);
            // 
            // ddgTrxBpartner
            // 
            this.ddgTrxBpartner.AutoFilter = true;
            this.ddgTrxBpartner.AutoSize = true;
            this.ddgTrxBpartner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgTrxBpartner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgTrxBpartner.ClearButtonEnabled = true;
            this.ddgTrxBpartner.DataTablePrimaryKey = ((ushort)(0));
            this.ddgTrxBpartner.FindButtonEnabled = true;
            this.ddgTrxBpartner.HiddenColoumns = new int[0];
            this.ddgTrxBpartner.Image = null;
            this.ddgTrxBpartner.Location = new System.Drawing.Point(418, 38);
            this.ddgTrxBpartner.Margin = new System.Windows.Forms.Padding(0);
            this.ddgTrxBpartner.Name = "ddgTrxBpartner";
            this.ddgTrxBpartner.NewButtonEnabled = true;
            this.ddgTrxBpartner.RefreshButtonEnabled = true;
            this.ddgTrxBpartner.SelectedColomnIdex = 0;
            this.ddgTrxBpartner.SelectedItem = "";
            this.ddgTrxBpartner.SelectedRowKey = null;
            this.ddgTrxBpartner.ShowGridFunctions = false;
            this.ddgTrxBpartner.Size = new System.Drawing.Size(267, 31);
            this.ddgTrxBpartner.TabIndex = 15;
            this.ddgTrxBpartner.SelectedItemClicked += new System.EventHandler(this.ddgTrxBpartner_SelectedItemClicked);
            this.ddgTrxBpartner.selectedItemChanged += new System.EventHandler(this.ddgTrxBpartner_selectedItemChanged);
            // 
            // ntbDetailTrxQuantity
            // 
            this.ntbDetailTrxQuantity.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbDetailTrxQuantity.AllowedLength = 0;
            this.ntbDetailTrxQuantity.AllowLeadingZeros = false;
            this.ntbDetailTrxQuantity.AllowNegative = false;
            this.ntbDetailTrxQuantity.Amount = "";
            this.ntbDetailTrxQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ntbDetailTrxQuantity.defaultAmount = "0";
            this.ntbDetailTrxQuantity.Location = new System.Drawing.Point(122, 65);
            this.ntbDetailTrxQuantity.Name = "ntbDetailTrxQuantity";
            this.ntbDetailTrxQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbDetailTrxQuantity.ShowThousandSeparetor = true;
            this.ntbDetailTrxQuantity.Size = new System.Drawing.Size(140, 23);
            this.ntbDetailTrxQuantity.StandardPrecision = 2;
            this.ntbDetailTrxQuantity.TabIndex = 17;
            this.ntbDetailTrxQuantity.Leave += new System.EventHandler(this.ntbDetailTrxQuantity_Leave);
            this.ntbDetailTrxQuantity.Enter += new System.EventHandler(this.ntbDetailTrxQuantity_Enter);
            // 
            // ddgDetailProduct
            // 
            this.ddgDetailProduct.AutoFilter = true;
            this.ddgDetailProduct.AutoSize = true;
            this.ddgDetailProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgDetailProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ddgDetailProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgDetailProduct.ClearButtonEnabled = true;
            this.ddgDetailProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgDetailProduct.Enabled = false;
            this.ddgDetailProduct.FindButtonEnabled = true;
            this.ddgDetailProduct.HiddenColoumns = new int[0];
            this.ddgDetailProduct.Image = null;
            this.ddgDetailProduct.Location = new System.Drawing.Point(118, 9);
            this.ddgDetailProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgDetailProduct.Name = "ddgDetailProduct";
            this.ddgDetailProduct.NewButtonEnabled = true;
            this.ddgDetailProduct.RefreshButtonEnabled = true;
            this.ddgDetailProduct.SelectedColomnIdex = 0;
            this.ddgDetailProduct.SelectedItem = "";
            this.ddgDetailProduct.SelectedRowKey = null;
            this.ddgDetailProduct.ShowGridFunctions = false;
            this.ddgDetailProduct.Size = new System.Drawing.Size(386, 31);
            this.ddgDetailProduct.TabIndex = 16;
            this.ddgDetailProduct.SelectedItemClicked += new System.EventHandler(this.ddgDetailProduct_SelectedItemClicked);
            this.ddgDetailProduct.selectedItemChanged += new System.EventHandler(this.ddgDetailProduct_selectedItemChanged);
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlDetail.Controls.Add(this.lblDetailTrxProduct);
            this.pnlDetail.Controls.Add(this.ddgDetailProduct);
            this.pnlDetail.Controls.Add(this.txtDetailTrxDescription);
            this.pnlDetail.Controls.Add(this.lblDetailTrxLineTotal);
            this.pnlDetail.Controls.Add(this.lblDetailTrxDescription);
            this.pnlDetail.Controls.Add(this.cmbDetailTrxOtherUOM);
            this.pnlDetail.Controls.Add(this.ntbDetailTrxTax);
            this.pnlDetail.Controls.Add(this.lblDetailTrxStockQty);
            this.pnlDetail.Controls.Add(this.txtDetailTrxLineTotal);
            this.pnlDetail.Controls.Add(this.lblDetailTrxQuantity);
            this.pnlDetail.Controls.Add(this.ntbDetailTrxUnitPrice);
            this.pnlDetail.Controls.Add(this.ntbDetailTrxQuantity);
            this.pnlDetail.Controls.Add(this.txtDetailTrxStockQty);
            this.pnlDetail.Controls.Add(this.cmbDetailTrxDispatchingStore);
            this.pnlDetail.Controls.Add(this.lblDetailTrxLineTax);
            this.pnlDetail.Controls.Add(this.lblDetailTrxUnit);
            this.pnlDetail.Controls.Add(this.lblDetailTrxPrice);
            this.pnlDetail.Controls.Add(this.lblDetailTrxWarehouse);
            this.pnlDetail.Controls.Add(this.ckDetailTrxLinePrctage);
            this.pnlDetail.Controls.Add(this.cmdDetailTrxAddLine);
            this.pnlDetail.Controls.Add(this.cmdDetailTrxProductImage);
            this.pnlDetail.Controls.Add(this.cmdDetailTrxNewProduct);
            this.pnlDetail.Location = new System.Drawing.Point(59, 181);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(654, 184);
            this.pnlDetail.TabIndex = 40;
            // 
            // frmTransaction
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(741, 696);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdNewBpartner);
            this.Controls.Add(this.lblTrxGrandTotal);
            this.Controls.Add(this.lblTrxSubTotal);
            this.Controls.Add(this.lblTrxTaxTotal);
            this.Controls.Add(this.lblTransactionGrandTotal);
            this.Controls.Add(this.lblTransactionTax);
            this.Controls.Add(this.dtgTransactionDetail);
            this.Controls.Add(this.ddgTrxBpartner);
            this.Controls.Add(this.lblTransactionSubTotal);
            this.Controls.Add(this.dtpTrxDate);
            this.Controls.Add(this.txtTrxDescription);
            this.Controls.Add(this.txtTrxDocumentNo);
            this.Controls.Add(this.lblTrxBpartner);
            this.Controls.Add(this.lblTrxDate);
            this.Controls.Add(this.lblTrxDescription);
            this.Controls.Add(this.lblTrxDocumentNo);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.dtgTransactionGridView);
            this.Name = "frmTransaction";
            this.Text = "frmTransaction";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactionDetail)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
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
        private System.Windows.Forms.DataGridView dtgTransactionGridView;
        private System.Windows.Forms.ToolStripButton tlsToogleView;
        private System.Windows.Forms.Label lblTrxDocumentNo;
        private System.Windows.Forms.Label lblTrxDescription;
        private System.Windows.Forms.Label lblTrxDate;
        private System.Windows.Forms.Label lblTrxBpartner;
        private System.Windows.Forms.Label lblDetailTrxProduct;
        private System.Windows.Forms.Label lblDetailTrxQuantity;
        private System.Windows.Forms.Label lblDetailTrxDescription;
        private System.Windows.Forms.TextBox txtTrxDocumentNo;
        private System.Windows.Forms.TextBox txtTrxDescription;
        private System.Windows.Forms.TextBox txtDetailTrxDescription;
        private System.Windows.Forms.DateTimePicker dtpTrxDate;
        private System.Windows.Forms.Label lblTransactionSubTotal;
        private DropDownDataGrid ddgTrxBpartner;
        private DropDownDataGrid ddgDetailProduct;
        private ctlNumberTextBox ntbDetailTrxQuantity;
        private System.Windows.Forms.Label lblDetailTrxUnit;
        private System.Windows.Forms.Button cmdDetailTrxProductImage;
        private System.Windows.Forms.Button cmdDetailTrxAddLine;
        private System.Windows.Forms.DataGridView dtgTransactionDetail;
        private System.Windows.Forms.Label lblTransactionTax;
        private System.Windows.Forms.Label lblTransactionGrandTotal;
        private System.Windows.Forms.Label lblDetailTrxPrice;
        private ctlNumberTextBox ntbDetailTrxTax;
        private ctlNumberTextBox ntbDetailTrxUnitPrice;
        private System.Windows.Forms.Label lblDetailTrxLineTax;
        private System.Windows.Forms.ComboBox cmbDetailTrxOtherUOM;
        private System.Windows.Forms.TextBox txtDetailTrxLineTotal;
        private System.Windows.Forms.Label lblDetailTrxLineTotal;
        private System.Windows.Forms.Label lblTrxTaxTotal;
        private System.Windows.Forms.Label lblTrxSubTotal;
        private System.Windows.Forms.Label lblTrxGrandTotal;
        private System.Windows.Forms.CheckBox ckDetailTrxLinePrctage;
        private System.Windows.Forms.ToolStripButton tlsReverse;
        private System.Windows.Forms.Button cmdDetailTrxNewProduct;
        private System.Windows.Forms.Label lblDetailTrxWarehouse;
        private System.Windows.Forms.ComboBox cmbDetailTrxDispatchingStore;
        private System.Windows.Forms.Button cmdNewBpartner;
        private System.Windows.Forms.ToolStripButton tlsPrint;
        private System.Windows.Forms.Label lblDetailTrxStockQty;
        private System.Windows.Forms.TextBox txtDetailTrxStockQty;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Panel pnlDetail;
    }
}