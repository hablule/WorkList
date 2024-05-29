namespace SRP
{
    partial class frmPhysicalInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhysicalInventory));
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
            this.tlsReverse = new System.Windows.Forms.ToolStripButton();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.tlsToogleView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsPrint = new System.Windows.Forms.ToolStripButton();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblCountDate = new System.Windows.Forms.Label();
            this.lblCountStore = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblCountQuantity = new System.Windows.Forms.Label();
            this.lblUsageLineDescription = new System.Windows.Forms.Label();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.dtpCountDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCountStore = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdAddCountLine = new System.Windows.Forms.Button();
            this.txtCountLineDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgCountLineGridView = new System.Windows.Forms.DataGridView();
            this.dtgCountGridView = new System.Windows.Forms.DataGridView();
            this.cmbDetailCountOtherUOM = new System.Windows.Forms.ComboBox();
            this.cmdDetailTrxProductImage = new System.Windows.Forms.Button();
            this.lblBookQuantity = new System.Windows.Forms.Label();
            this.cmdCreateInventoryCount = new System.Windows.Forms.Button();
            this.ntbBookQty = new SRP.ctlNumberTextBox();
            this.ntbCountQty = new SRP.ctlNumberTextBox();
            this.ddgProduct = new SRP.DropDownDataGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCountLineGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCountGridView)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(447, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(32, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(48, 22);
            this.tlsSave.Text = "Process";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
            this.tlsReverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsReverse.Name = "tlsReverse";
            this.tlsReverse.Size = new System.Drawing.Size(58, 22);
            this.tlsReverse.Text = "Reverse";
            this.tlsReverse.Click += new System.EventHandler(this.tlsReverse_Click);
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(44, 22);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // tlsToogleView
            // 
            this.tlsToogleView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(52, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(34, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(23, 22);
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNo.Location = new System.Drawing.Point(24, 69);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(88, 13);
            this.lblDocumentNo.TabIndex = 1;
            this.lblDocumentNo.Text = "Document No.";
            // 
            // lblCountDate
            // 
            this.lblCountDate.AutoSize = true;
            this.lblCountDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDate.Location = new System.Drawing.Point(41, 91);
            this.lblCountDate.Name = "lblCountDate";
            this.lblCountDate.Size = new System.Drawing.Size(71, 13);
            this.lblCountDate.TabIndex = 2;
            this.lblCountDate.Text = "Count Date";
            // 
            // lblCountStore
            // 
            this.lblCountStore.AutoSize = true;
            this.lblCountStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountStore.Location = new System.Drawing.Point(75, 116);
            this.lblCountStore.Name = "lblCountStore";
            this.lblCountStore.Size = new System.Drawing.Size(37, 13);
            this.lblCountStore.TabIndex = 3;
            this.lblCountStore.Text = "Store";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(33, 141);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 37);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description/Comment";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(52, 243);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(51, 13);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product";
            // 
            // lblCountQuantity
            // 
            this.lblCountQuantity.AutoSize = true;
            this.lblCountQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblCountQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountQuantity.Location = new System.Drawing.Point(44, 296);
            this.lblCountQuantity.Name = "lblCountQuantity";
            this.lblCountQuantity.Size = new System.Drawing.Size(63, 13);
            this.lblCountQuantity.TabIndex = 7;
            this.lblCountQuantity.Text = "Count Qty";
            // 
            // lblUsageLineDescription
            // 
            this.lblUsageLineDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblUsageLineDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLineDescription.Location = new System.Drawing.Point(22, 322);
            this.lblUsageLineDescription.Name = "lblUsageLineDescription";
            this.lblUsageLineDescription.Size = new System.Drawing.Size(81, 35);
            this.lblUsageLineDescription.TabIndex = 9;
            this.lblUsageLineDescription.Text = "Description/Comment";
            this.lblUsageLineDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(117, 65);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(166, 20);
            this.txtDocumentNo.TabIndex = 10;
            // 
            // dtpCountDate
            // 
            this.dtpCountDate.Location = new System.Drawing.Point(117, 88);
            this.dtpCountDate.Name = "dtpCountDate";
            this.dtpCountDate.Size = new System.Drawing.Size(217, 20);
            this.dtpCountDate.TabIndex = 11;
            // 
            // cmbCountStore
            // 
            this.cmbCountStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountStore.FormattingEnabled = true;
            this.cmbCountStore.Location = new System.Drawing.Point(117, 112);
            this.cmbCountStore.Name = "cmbCountStore";
            this.cmbCountStore.Size = new System.Drawing.Size(140, 21);
            this.cmbCountStore.TabIndex = 12;
            this.cmbCountStore.SelectedIndexChanged += new System.EventHandler(this.cmbCountFrom_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(117, 137);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(299, 82);
            this.txtDescription.TabIndex = 14;
            // 
            // cmdAddCountLine
            // 
            this.cmdAddCountLine.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAddCountLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddCountLine.Location = new System.Drawing.Point(385, 290);
            this.cmdAddCountLine.Name = "cmdAddCountLine";
            this.cmdAddCountLine.Size = new System.Drawing.Size(55, 23);
            this.cmdAddCountLine.TabIndex = 15;
            this.cmdAddCountLine.Text = "Add";
            this.cmdAddCountLine.UseVisualStyleBackColor = false;
            this.cmdAddCountLine.Click += new System.EventHandler(this.cmdAddCountLine_Click);
            // 
            // txtCountLineDescription
            // 
            this.txtCountLineDescription.Location = new System.Drawing.Point(109, 318);
            this.txtCountLineDescription.Multiline = true;
            this.txtCountLineDescription.Name = "txtCountLineDescription";
            this.txtCountLineDescription.Size = new System.Drawing.Size(276, 82);
            this.txtCountLineDescription.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(12, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(432, 181);
            this.label10.TabIndex = 19;
            this.label10.Text = "Usage Line";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtgCountLineGridView
            // 
            this.dtgCountLineGridView.AllowUserToAddRows = false;
            this.dtgCountLineGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgCountLineGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCountLineGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCountLineGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCountLineGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgCountLineGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCountLineGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCountLineGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCountLineGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCountLineGridView.Location = new System.Drawing.Point(2, 406);
            this.dtgCountLineGridView.MultiSelect = false;
            this.dtgCountLineGridView.Name = "dtgCountLineGridView";
            this.dtgCountLineGridView.ReadOnly = true;
            this.dtgCountLineGridView.RowHeadersVisible = false;
            this.dtgCountLineGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCountLineGridView.Size = new System.Drawing.Size(444, 250);
            this.dtgCountLineGridView.TabIndex = 20;
            this.dtgCountLineGridView.Sorted += new System.EventHandler(this.dtgCountLineGridView_Sorted);
            this.dtgCountLineGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCountLineGridView_CellClick);
            // 
            // dtgCountGridView
            // 
            this.dtgCountGridView.AllowUserToAddRows = false;
            this.dtgCountGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgCountGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCountGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCountGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCountGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgCountGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCountGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgCountGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCountGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgCountGridView.Location = new System.Drawing.Point(3, 28);
            this.dtgCountGridView.MultiSelect = false;
            this.dtgCountGridView.Name = "dtgCountGridView";
            this.dtgCountGridView.ReadOnly = true;
            this.dtgCountGridView.RowHeadersWidth = 21;
            this.dtgCountGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCountGridView.Size = new System.Drawing.Size(14, 375);
            this.dtgCountGridView.TabIndex = 21;
            this.dtgCountGridView.Visible = false;
            this.dtgCountGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCountGridView_CellClick);
            // 
            // cmbDetailCountOtherUOM
            // 
            this.cmbDetailCountOtherUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailCountOtherUOM.FormattingEnabled = true;
            this.cmbDetailCountOtherUOM.Location = new System.Drawing.Point(235, 293);
            this.cmbDetailCountOtherUOM.Name = "cmbDetailCountOtherUOM";
            this.cmbDetailCountOtherUOM.Size = new System.Drawing.Size(82, 21);
            this.cmbDetailCountOtherUOM.TabIndex = 22;
            this.cmbDetailCountOtherUOM.SelectedIndexChanged += new System.EventHandler(this.cmbDetailCountOtherUOM_SelectedIndexChanged);
            // 
            // cmdDetailTrxProductImage
            // 
            this.cmdDetailTrxProductImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetailTrxProductImage.Location = new System.Drawing.Point(387, 238);
            this.cmdDetailTrxProductImage.Name = "cmdDetailTrxProductImage";
            this.cmdDetailTrxProductImage.Size = new System.Drawing.Size(30, 23);
            this.cmdDetailTrxProductImage.TabIndex = 25;
            this.cmdDetailTrxProductImage.Text = "...";
            this.cmdDetailTrxProductImage.UseVisualStyleBackColor = true;
            this.cmdDetailTrxProductImage.Click += new System.EventHandler(this.cmdDetailTrxProductImage_Click);
            // 
            // lblBookQuantity
            // 
            this.lblBookQuantity.AutoSize = true;
            this.lblBookQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBookQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookQuantity.Location = new System.Drawing.Point(44, 269);
            this.lblBookQuantity.Name = "lblBookQuantity";
            this.lblBookQuantity.Size = new System.Drawing.Size(59, 13);
            this.lblBookQuantity.TabIndex = 26;
            this.lblBookQuantity.Text = "Book Qty";
            // 
            // cmdCreateInventoryCount
            // 
            this.cmdCreateInventoryCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCreateInventoryCount.Location = new System.Drawing.Point(364, 69);
            this.cmdCreateInventoryCount.Name = "cmdCreateInventoryCount";
            this.cmdCreateInventoryCount.Size = new System.Drawing.Size(80, 57);
            this.cmdCreateInventoryCount.TabIndex = 28;
            this.cmdCreateInventoryCount.Text = "Create Count";
            this.cmdCreateInventoryCount.UseVisualStyleBackColor = true;
            this.cmdCreateInventoryCount.Click += new System.EventHandler(this.cmdCreateInventoryCount_Click);
            // 
            // ntbBookQty
            // 
            this.ntbBookQty.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbBookQty.AllowNegative = true;
            this.ntbBookQty.Amount = "0";
            this.ntbBookQty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ntbBookQty.Enabled = false;
            this.ntbBookQty.Location = new System.Drawing.Point(109, 265);
            this.ntbBookQty.Name = "ntbBookQty";
            this.ntbBookQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbBookQty.ShowThousandSeparetor = true;
            this.ntbBookQty.Size = new System.Drawing.Size(117, 23);
            this.ntbBookQty.StandardPrecision = 2;
            this.ntbBookQty.TabIndex = 27;
            // 
            // ntbCountQty
            // 
            this.ntbCountQty.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCountQty.AllowNegative = false;
            this.ntbCountQty.Amount = "0";
            this.ntbCountQty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ntbCountQty.Location = new System.Drawing.Point(108, 292);
            this.ntbCountQty.Name = "ntbCountQty";
            this.ntbCountQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCountQty.ShowThousandSeparetor = true;
            this.ntbCountQty.Size = new System.Drawing.Size(118, 23);
            this.ntbCountQty.StandardPrecision = 2;
            this.ntbCountQty.TabIndex = 24;
            this.ntbCountQty.Leave += new System.EventHandler(this.ntbCountQty_Leave);
            this.ntbCountQty.Enter += new System.EventHandler(this.ntbCountQty_Enter);
            // 
            // ddgProduct
            // 
            this.ddgProduct.AutoFilter = true;
            this.ddgProduct.AutoSize = true;
            this.ddgProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ddgProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgProduct.ClearButtonEnabled = true;
            this.ddgProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgProduct.FindButtonEnabled = true;
            this.ddgProduct.HiddenColoumns = new int[0];
            this.ddgProduct.Image = null;
            this.ddgProduct.Location = new System.Drawing.Point(105, 235);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(280, 31);
            this.ddgProduct.TabIndex = 23;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            this.ddgProduct.selectedItemChanged += new System.EventHandler(this.ddgProduct_selectedItemChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(447, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(117, 38);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(197, 21);
            this.cmbOrganisation.TabIndex = 40;
            this.cmbOrganisation.SelectedIndexChanged += new System.EventHandler(this.cmbOrganisation_SelectedIndexChanged);
            this.cmbOrganisation.DropDown += new System.EventHandler(this.cmbOrganisation_DropDown);
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganisation.Location = new System.Drawing.Point(23, 40);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(89, 15);
            this.lblOrganisation.TabIndex = 39;
            this.lblOrganisation.Text = "Organisation";
            // 
            // frmPhysicalInventory
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(447, 681);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdCreateInventoryCount);
            this.Controls.Add(this.ntbBookQty);
            this.Controls.Add(this.lblBookQuantity);
            this.Controls.Add(this.cmdDetailTrxProductImage);
            this.Controls.Add(this.cmbDetailCountOtherUOM);
            this.Controls.Add(this.ntbCountQty);
            this.Controls.Add(this.ddgProduct);
            this.Controls.Add(this.dtgCountGridView);
            this.Controls.Add(this.dtgCountLineGridView);
            this.Controls.Add(this.txtCountLineDescription);
            this.Controls.Add(this.cmdAddCountLine);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbCountStore);
            this.Controls.Add(this.dtpCountDate);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblUsageLineDescription);
            this.Controls.Add(this.lblCountQuantity);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCountStore);
            this.Controls.Add(this.lblCountDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPhysicalInventory";
            this.Text = "frmPhysicalInventory";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCountLineGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCountGridView)).EndInit();
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
        private System.Windows.Forms.ToolStripButton tlsToogleView;
        private System.Windows.Forms.ToolStripButton tlsReverse;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblCountDate;
        private System.Windows.Forms.Label lblCountStore;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblCountQuantity;
        private System.Windows.Forms.Label lblUsageLineDescription;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.DateTimePicker dtpCountDate;
        private System.Windows.Forms.ComboBox cmbCountStore;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdAddCountLine;
        private System.Windows.Forms.TextBox txtCountLineDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgCountLineGridView;
        private System.Windows.Forms.DataGridView dtgCountGridView;
        private System.Windows.Forms.ComboBox cmbDetailCountOtherUOM;
        private DropDownDataGrid ddgProduct;
        private ctlNumberTextBox ntbCountQty;
        private System.Windows.Forms.Button cmdDetailTrxProductImage;
        private ctlNumberTextBox ntbBookQty;
        private System.Windows.Forms.Label lblBookQuantity;
        private System.Windows.Forms.Button cmdCreateInventoryCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.ToolStripButton tlsPrint;


    }
}