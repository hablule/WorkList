namespace SRP
{
    partial class frmProductImage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsMainToolBar = new System.Windows.Forms.ToolStrip();
            this.tlscmbProductCategory = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlscmbStockStatus = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstxtProductCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstxtProductCode2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstxtUPC_EAN = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstxtProductName = new System.Windows.Forms.ToolStripTextBox();
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.sstMainStatusBar = new System.Windows.Forms.StatusStrip();
            this.tssInventoryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtgItemDetailInfo = new System.Windows.Forms.DataGridView();
            this.lbItemNameList = new System.Windows.Forms.ListBox();
            this.spltMainHolder = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tmrRequestEnded = new System.Windows.Forms.Timer(this.components);
            this.tlsMainToolBar.SuspendLayout();
            this.sstMainStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItemDetailInfo)).BeginInit();
            this.spltMainHolder.Panel1.SuspendLayout();
            this.spltMainHolder.Panel2.SuspendLayout();
            this.spltMainHolder.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsMainToolBar
            // 
            this.tlsMainToolBar.BackColor = System.Drawing.Color.Transparent;
            this.tlsMainToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlscmbProductCategory,
            this.toolStripSeparator1,
            this.tlscmbStockStatus,
            this.toolStripSeparator2,
            this.tlstxtProductCode,
            this.toolStripSeparator3,
            this.tlstxtProductCode2,
            this.toolStripSeparator4,
            this.tlstxtUPC_EAN,
            this.toolStripSeparator5,
            this.tlstxtProductName});
            this.tlsMainToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsMainToolBar.Name = "tlsMainToolBar";
            this.tlsMainToolBar.Size = new System.Drawing.Size(870, 25);
            this.tlsMainToolBar.TabIndex = 1;
            this.tlsMainToolBar.Text = "toolStrip1";
            // 
            // tlscmbProductCategory
            // 
            this.tlscmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlscmbProductCategory.Name = "tlscmbProductCategory";
            this.tlscmbProductCategory.Size = new System.Drawing.Size(121, 25);
            this.tlscmbProductCategory.ToolTipText = "Displayed Category";
            this.tlscmbProductCategory.SelectedIndexChanged += new System.EventHandler(this.tlsProductCategory_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlscmbStockStatus
            // 
            this.tlscmbStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlscmbStockStatus.Items.AddRange(new object[] {
            "All Items",
            "Stock Equals Zero",
            "Stock Not Zero",
            "Stock Above Zero",
            "Stock Below Zero"});
            this.tlscmbStockStatus.Name = "tlscmbStockStatus";
            this.tlscmbStockStatus.Size = new System.Drawing.Size(121, 25);
            this.tlscmbStockStatus.ToolTipText = "Displayes Item Stock Status";
            this.tlscmbStockStatus.SelectedIndexChanged += new System.EventHandler(this.tlscmbStockStatus_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstxtProductCode
            // 
            this.tlstxtProductCode.Name = "tlstxtProductCode";
            this.tlstxtProductCode.Size = new System.Drawing.Size(115, 25);
            this.tlstxtProductCode.ToolTipText = "Product Code";
            this.tlstxtProductCode.TextChanged += new System.EventHandler(this.tlstxtProductCode_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstxtProductCode2
            // 
            this.tlstxtProductCode2.Name = "tlstxtProductCode2";
            this.tlstxtProductCode2.Size = new System.Drawing.Size(115, 25);
            this.tlstxtProductCode2.ToolTipText = "Vendor Code";
            this.tlstxtProductCode2.TextChanged += new System.EventHandler(this.tlstxtProductCode2_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstxtUPC_EAN
            // 
            this.tlstxtUPC_EAN.Name = "tlstxtUPC_EAN";
            this.tlstxtUPC_EAN.Size = new System.Drawing.Size(120, 25);
            this.tlstxtUPC_EAN.ToolTipText = "Bar Code";
            this.tlstxtUPC_EAN.TextChanged += new System.EventHandler(this.tlstxtUPC_EAN_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstxtProductName
            // 
            this.tlstxtProductName.Name = "tlstxtProductName";
            this.tlstxtProductName.Size = new System.Drawing.Size(200, 25);
            this.tlstxtProductName.ToolTipText = "Product Name";
            this.tlstxtProductName.TextChanged += new System.EventHandler(this.tlstxtProductName_TextChanged);
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlImageContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(680, 348);
            this.pnlImageContainer.TabIndex = 2;
            this.pnlImageContainer.SizeChanged += new System.EventHandler(this.pnlImageContainer_SizeChanged);
            // 
            // sstMainStatusBar
            // 
            this.sstMainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssInventoryStatusLabel});
            this.sstMainStatusBar.Location = new System.Drawing.Point(0, 482);
            this.sstMainStatusBar.Name = "sstMainStatusBar";
            this.sstMainStatusBar.Size = new System.Drawing.Size(870, 22);
            this.sstMainStatusBar.TabIndex = 3;
            // 
            // tssInventoryStatusLabel
            // 
            this.tssInventoryStatusLabel.AutoToolTip = true;
            this.tssInventoryStatusLabel.Name = "tssInventoryStatusLabel";
            this.tssInventoryStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.tssInventoryStatusLabel.ToolTipText = "stock Status information";
            // 
            // dtgItemDetailInfo
            // 
            this.dtgItemDetailInfo.AllowUserToAddRows = false;
            this.dtgItemDetailInfo.AllowUserToDeleteRows = false;
            this.dtgItemDetailInfo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgItemDetailInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgItemDetailInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgItemDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItemDetailInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgItemDetailInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItemDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgItemDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.dtgItemDetailInfo.MultiSelect = false;
            this.dtgItemDetailInfo.Name = "dtgItemDetailInfo";
            this.dtgItemDetailInfo.ReadOnly = true;
            this.dtgItemDetailInfo.RowHeadersWidth = 20;
            this.dtgItemDetailInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItemDetailInfo.Size = new System.Drawing.Size(870, 99);
            this.dtgItemDetailInfo.TabIndex = 3;
            this.dtgItemDetailInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItemDetailInfo_CellDoubleClick);
            // 
            // lbItemNameList
            // 
            this.lbItemNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItemNameList.FormattingEnabled = true;
            this.lbItemNameList.HorizontalScrollbar = true;
            this.lbItemNameList.Location = new System.Drawing.Point(0, 0);
            this.lbItemNameList.Name = "lbItemNameList";
            this.lbItemNameList.Size = new System.Drawing.Size(180, 342);
            this.lbItemNameList.TabIndex = 4;
            this.lbItemNameList.DoubleClick += new System.EventHandler(this.lbItemNameList_DoubleClick);
            this.lbItemNameList.Click += new System.EventHandler(this.lbItemNameList_Click);
            // 
            // spltMainHolder
            // 
            this.spltMainHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMainHolder.Location = new System.Drawing.Point(0, 25);
            this.spltMainHolder.Name = "spltMainHolder";
            this.spltMainHolder.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMainHolder.Panel1
            // 
            this.spltMainHolder.Panel1.Controls.Add(this.splitContainer2);
            // 
            // spltMainHolder.Panel2
            // 
            this.spltMainHolder.Panel2.Controls.Add(this.dtgItemDetailInfo);
            this.spltMainHolder.Size = new System.Drawing.Size(870, 457);
            this.spltMainHolder.SplitterDistance = 348;
            this.spltMainHolder.SplitterWidth = 10;
            this.spltMainHolder.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbItemNameList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnlImageContainer);
            this.splitContainer2.Size = new System.Drawing.Size(870, 348);
            this.splitContainer2.SplitterDistance = 180;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 0;
            // 
            // tmrRequestEnded
            // 
            this.tmrRequestEnded.Enabled = true;
            this.tmrRequestEnded.Interval = 500;
            this.tmrRequestEnded.Tick += new System.EventHandler(this.tmrRequestEnded_Tick);
            // 
            // frmProductImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(870, 504);
            this.Controls.Add(this.spltMainHolder);
            this.Controls.Add(this.sstMainStatusBar);
            this.Controls.Add(this.tlsMainToolBar);
            this.Name = "frmProductImage";
            this.Text = "Items";
            this.Load += new System.EventHandler(this.frmProductImage_Load);
            this.tlsMainToolBar.ResumeLayout(false);
            this.tlsMainToolBar.PerformLayout();
            this.sstMainStatusBar.ResumeLayout(false);
            this.sstMainStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItemDetailInfo)).EndInit();
            this.spltMainHolder.Panel1.ResumeLayout(false);
            this.spltMainHolder.Panel2.ResumeLayout(false);
            this.spltMainHolder.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMainToolBar;
        private System.Windows.Forms.ToolStripComboBox tlscmbProductCategory;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.StatusStrip sstMainStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tssInventoryStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox tlscmbStockStatus;
        private System.Windows.Forms.DataGridView dtgItemDetailInfo;
        private System.Windows.Forms.ListBox lbItemNameList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tlstxtProductName;
        private System.Windows.Forms.SplitContainer spltMainHolder;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripTextBox tlstxtProductCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Timer tmrRequestEnded;
        private System.Windows.Forms.ToolStripTextBox tlstxtProductCode2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox tlstxtUPC_EAN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}