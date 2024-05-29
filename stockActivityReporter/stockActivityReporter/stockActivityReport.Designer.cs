namespace stockActivityReporter
{
    partial class stockActivityReport
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockActivityReport));
            this.cbcbStoreList = new PresentationControls.CheckBoxComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbDateLogic = new System.Windows.Forms.ComboBox();
            this.cmdGenerateReport = new System.Windows.Forms.Button();
            this.ckDetailReport = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.schedulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbProductLogic = new System.Windows.Forms.ComboBox();
            this.ckShowDormentStock = new System.Windows.Forms.CheckBox();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.ddgProduct = new customControls.DropDownDataGrid();
            this.ckCountSheetRpt = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbcbStoreList
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcbStoreList.CheckBoxProperties = checkBoxProperties1;
            this.cbcbStoreList.DisplayMemberSingleItem = "";
            this.cbcbStoreList.FormattingEnabled = true;
            this.cbcbStoreList.Location = new System.Drawing.Point(172, 110);
            this.cbcbStoreList.Name = "cbcbStoreList";
            this.cbcbStoreList.Size = new System.Drawing.Size(277, 21);
            this.cbcbStoreList.TabIndex = 0;
            this.cbcbStoreList.CheckBoxCheckedChanged += new System.EventHandler(this.cbcbStoreList_CheckBoxCheckedChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(173, 79);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(195, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(374, 79);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(208, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(4, 50);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Product";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(101, 114);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(62, 13);
            this.lblStore.TabIndex = 5;
            this.lblStore.Text = "Warehouse";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(18, 82);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date";
            // 
            // cmbDateLogic
            // 
            this.cmbDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateLogic.FormattingEnabled = true;
            this.cmbDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDateLogic.Location = new System.Drawing.Point(53, 78);
            this.cmbDateLogic.Name = "cmbDateLogic";
            this.cmbDateLogic.Size = new System.Drawing.Size(113, 21);
            this.cmbDateLogic.TabIndex = 7;
            this.cmbDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // cmdGenerateReport
            // 
            this.cmdGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerateReport.Location = new System.Drawing.Point(54, 201);
            this.cmdGenerateReport.Name = "cmdGenerateReport";
            this.cmdGenerateReport.Size = new System.Drawing.Size(239, 65);
            this.cmdGenerateReport.TabIndex = 9;
            this.cmdGenerateReport.Text = "Generate Report";
            this.cmdGenerateReport.UseVisualStyleBackColor = true;
            this.cmdGenerateReport.Click += new System.EventHandler(this.cmdGenerateReport_Click);
            // 
            // ckDetailReport
            // 
            this.ckDetailReport.AutoSize = true;
            this.ckDetailReport.Checked = true;
            this.ckDetailReport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDetailReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDetailReport.Location = new System.Drawing.Point(399, 194);
            this.ckDetailReport.Name = "ckDetailReport";
            this.ckDetailReport.Size = new System.Drawing.Size(150, 19);
            this.ckDetailReport.TabIndex = 10;
            this.ckDetailReport.Text = "Show Detail Report";
            this.ckDetailReport.UseVisualStyleBackColor = true;
            this.ckDetailReport.CheckedChanged += new System.EventHandler(this.ckDetailReport_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 284);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedulToolStripMenuItem,
            this.mnuSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // schedulToolStripMenuItem
            // 
            this.schedulToolStripMenuItem.Name = "schedulToolStripMenuItem";
            this.schedulToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.schedulToolStripMenuItem.Text = "Schedule";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(126, 160);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.Size = new System.Drawing.Size(319, 24);
            this.ckAllOrAny.TabIndex = 36;
            this.ckAllOrAny.Text = "Show Records That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmbProductLogic
            // 
            this.cmbProductLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductLogic.DropDownWidth = 130;
            this.cmbProductLogic.FormattingEnabled = true;
            this.cmbProductLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbProductLogic.Location = new System.Drawing.Point(54, 47);
            this.cmbProductLogic.Name = "cmbProductLogic";
            this.cmbProductLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbProductLogic.TabIndex = 37;
            this.cmbProductLogic.SelectedIndexChanged += new System.EventHandler(this.cmbProductLogic_SelectedIndexChanged);
            // 
            // ckShowDormentStock
            // 
            this.ckShowDormentStock.AutoSize = true;
            this.ckShowDormentStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckShowDormentStock.Location = new System.Drawing.Point(390, 247);
            this.ckShowDormentStock.Name = "ckShowDormentStock";
            this.ckShowDormentStock.Size = new System.Drawing.Size(159, 19);
            this.ckShowDormentStock.TabIndex = 38;
            this.ckShowDormentStock.Text = "Show Dorment Stock";
            this.ckShowDormentStock.UseVisualStyleBackColor = true;
            // 
            // visualStyler1
            // 
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle(null, "Office2007 (Blue).vssf");
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
            this.ddgProduct.Location = new System.Drawing.Point(169, 43);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(402, 31);
            this.ddgProduct.TabIndex = 1;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            // 
            // ckCountSheetRpt
            // 
            this.ckCountSheetRpt.AutoSize = true;
            this.ckCountSheetRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCountSheetRpt.Location = new System.Drawing.Point(418, 222);
            this.ckCountSheetRpt.Name = "ckCountSheetRpt";
            this.ckCountSheetRpt.Size = new System.Drawing.Size(131, 17);
            this.ckCountSheetRpt.TabIndex = 39;
            this.ckCountSheetRpt.Text = "Show Count Sheet";
            this.ckCountSheetRpt.UseVisualStyleBackColor = true;
            this.ckCountSheetRpt.CheckedChanged += new System.EventHandler(this.ckCountSheetRpt_CheckedChanged);
            // 
            // stockActivityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 306);
            this.Controls.Add(this.ckCountSheetRpt);
            this.Controls.Add(this.ckShowDormentStock);
            this.Controls.Add(this.cmbProductLogic);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ckDetailReport);
            this.Controls.Add(this.cmdGenerateReport);
            this.Controls.Add(this.cmbDateLogic);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.ddgProduct);
            this.Controls.Add(this.cbcbStoreList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "stockActivityReport";
            this.Text = "Stock Activity Report v5.0a";
            this.Load += new System.EventHandler(this.stockActivityReport_Load);
            this.DoubleClick += new System.EventHandler(this.stockActivityReport_DoubleClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.stockActivityReport_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PresentationControls.CheckBoxComboBox cbcbStoreList;
        private customControls.DropDownDataGrid ddgProduct;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbDateLogic;
        private System.Windows.Forms.Button cmdGenerateReport;
        private System.Windows.Forms.CheckBox ckDetailReport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem schedulToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbProductLogic;
        private System.Windows.Forms.CheckBox ckShowDormentStock;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
        private System.Windows.Forms.CheckBox ckCountSheetRpt;
    }
}