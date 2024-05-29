namespace SRP
{
    partial class frmSearchInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchInventory));
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmdShowPrdImageList = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbLogicProduct = new System.Windows.Forms.ComboBox();
            this.cmdSearchAndShowResult = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbLogicCategory = new System.Windows.Forms.ComboBox();
            this.cmbLogicQuantity = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbLogicWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblWareHouse = new System.Windows.Forms.Label();
            this.ntbQtyTo = new SRP.ctlNumberTextBox();
            this.ntbQtyFrom = new SRP.ctlNumberTextBox();
            this.ddgProduct = new SRP.DropDownDataGrid();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(36, 27);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 15);
            this.lblProduct.TabIndex = 5;
            this.lblProduct.Text = "Product";
            // 
            // cmdShowPrdImageList
            // 
            this.cmdShowPrdImageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowPrdImageList.Location = new System.Drawing.Point(595, 19);
            this.cmdShowPrdImageList.Name = "cmdShowPrdImageList";
            this.cmdShowPrdImageList.Size = new System.Drawing.Size(46, 28);
            this.cmdShowPrdImageList.TabIndex = 7;
            this.cmdShowPrdImageList.Text = "img";
            this.cmdShowPrdImageList.UseVisualStyleBackColor = true;
            this.cmdShowPrdImageList.Click += new System.EventHandler(this.cmdShowPrdImageList_Click);
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.AutoSize = true;
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(265, 153);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.Size = new System.Drawing.Size(85, 19);
            this.ckAllOrAny.TabIndex = 8;
            this.ckAllOrAny.Text = "All or Any";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmbLogicProduct
            // 
            this.cmbLogicProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicProduct.FormattingEnabled = true;
            this.cmbLogicProduct.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicProduct.Location = new System.Drawing.Point(97, 24);
            this.cmbLogicProduct.Name = "cmbLogicProduct";
            this.cmbLogicProduct.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicProduct.TabIndex = 9;
            this.cmbLogicProduct.SelectedIndexChanged += new System.EventHandler(this.cmbTrxProductLogic_SelectedIndexChanged);
            // 
            // cmdSearchAndShowResult
            // 
            this.cmdSearchAndShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchAndShowResult.Location = new System.Drawing.Point(235, 178);
            this.cmdSearchAndShowResult.Name = "cmdSearchAndShowResult";
            this.cmdSearchAndShowResult.Size = new System.Drawing.Size(149, 38);
            this.cmdSearchAndShowResult.TabIndex = 11;
            this.cmdSearchAndShowResult.Text = "Show Result";
            this.cmdSearchAndShowResult.UseVisualStyleBackColor = true;
            this.cmdSearchAndShowResult.Click += new System.EventHandler(this.cmdSearchAndShowResult_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(33, 56);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(59, 15);
            this.lblQuantity.TabIndex = 19;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(29, 81);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Category";
            // 
            // cmbLogicCategory
            // 
            this.cmbLogicCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicCategory.FormattingEnabled = true;
            this.cmbLogicCategory.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicCategory.Location = new System.Drawing.Point(97, 78);
            this.cmbLogicCategory.Name = "cmbLogicCategory";
            this.cmbLogicCategory.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicCategory.TabIndex = 1;
            this.cmbLogicCategory.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicCategory_SelectedIndexChanged);
            // 
            // cmbLogicQuantity
            // 
            this.cmbLogicQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicQuantity.FormattingEnabled = true;
            this.cmbLogicQuantity.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbLogicQuantity.Location = new System.Drawing.Point(97, 53);
            this.cmbLogicQuantity.Name = "cmbLogicQuantity";
            this.cmbLogicQuantity.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicQuantity.TabIndex = 1;
            this.cmbLogicQuantity.SelectedIndexChanged += new System.EventHandler(this.cmbLogicQuantity_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(235, 78);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(138, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cmbLogicWarehouse
            // 
            this.cmbLogicWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicWarehouse.FormattingEnabled = true;
            this.cmbLogicWarehouse.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicWarehouse.Location = new System.Drawing.Point(97, 105);
            this.cmbLogicWarehouse.Name = "cmbLogicWarehouse";
            this.cmbLogicWarehouse.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicWarehouse.TabIndex = 1;
            this.cmbLogicWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicWarehouse_SelectedIndexChanged);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(235, 105);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.AutoSize = true;
            this.lblWareHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouse.Location = new System.Drawing.Point(13, 108);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(79, 15);
            this.lblWareHouse.TabIndex = 20;
            this.lblWareHouse.Text = "Warehouse";
            // 
            // ntbQtyTo
            // 
            this.ntbQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbQtyTo.AllowNegative = false;
            this.ntbQtyTo.Amount = "";
            this.ntbQtyTo.Location = new System.Drawing.Point(378, 51);
            this.ntbQtyTo.Name = "ntbQtyTo";
            this.ntbQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbQtyTo.ShowThousandSeparetor = true;
            this.ntbQtyTo.Size = new System.Drawing.Size(138, 23);
            this.ntbQtyTo.StandardPrecision = 2;
            this.ntbQtyTo.TabIndex = 25;
            // 
            // ntbQtyFrom
            // 
            this.ntbQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbQtyFrom.AllowNegative = false;
            this.ntbQtyFrom.Amount = "";
            this.ntbQtyFrom.Location = new System.Drawing.Point(234, 51);
            this.ntbQtyFrom.Name = "ntbQtyFrom";
            this.ntbQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbQtyFrom.ShowThousandSeparetor = true;
            this.ntbQtyFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbQtyFrom.StandardPrecision = 2;
            this.ntbQtyFrom.TabIndex = 25;
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
            this.ddgProduct.Location = new System.Drawing.Point(233, 19);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(359, 31);
            this.ddgProduct.TabIndex = 6;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            // 
            // frmSearchInventory
            // 
            this.ClientSize = new System.Drawing.Size(647, 225);
            this.Controls.Add(this.ntbQtyTo);
            this.Controls.Add(this.ntbQtyFrom);
            this.Controls.Add(this.lblWareHouse);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmdSearchAndShowResult);
            this.Controls.Add(this.cmbLogicProduct);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.cmdShowPrdImageList);
            this.Controls.Add(this.ddgProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbLogicQuantity);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbLogicWarehouse);
            this.Controls.Add(this.cmbLogicCategory);
            this.Name = "frmSearchInventory";
            this.Text = "Search For Inventory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private DropDownDataGrid ddgProduct;
        private System.Windows.Forms.Button cmdShowPrdImageList;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbLogicProduct;
        private System.Windows.Forms.Button cmdSearchAndShowResult;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbLogicCategory;
        private System.Windows.Forms.ComboBox cmbLogicQuantity;
        private ctlNumberTextBox ntbQtyFrom;
        private ctlNumberTextBox ntbQtyTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbLogicWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWareHouse;
    }
}