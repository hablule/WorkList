namespace SRP
{
    partial class frmSearchMaterialTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchMaterialTransaction));
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbLogicDate = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmdShowPrdImageList = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbLogicProduct = new System.Windows.Forms.ComboBox();
            this.cmdSearchAndShowResult = new System.Windows.Forms.Button();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbLogicStation = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocNo = new System.Windows.Forms.ComboBox();
            this.cmbLogicCategory = new System.Windows.Forms.ComboBox();
            this.cmbLogicQuantity = new System.Windows.Forms.ComboBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbLogicWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblWareHouse = new System.Windows.Forms.Label();
            this.ntbQtyTo = new SRP.ctlNumberTextBox();
            this.ntbQtyFrom = new SRP.ctlNumberTextBox();
            this.ddgProduct = new SRP.DropDownDataGrid();
            this.cmbLogicMovementType = new System.Windows.Forms.ComboBox();
            this.cmbMovmentType = new System.Windows.Forms.ComboBox();
            this.lblMovementType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(92, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 15);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // cmbLogicDate
            // 
            this.cmbLogicDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDate.FormattingEnabled = true;
            this.cmbLogicDate.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbLogicDate.Location = new System.Drawing.Point(134, 45);
            this.cmbLogicDate.Name = "cmbLogicDate";
            this.cmbLogicDate.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicDate.TabIndex = 1;
            this.cmbLogicDate.SelectedIndexChanged += new System.EventHandler(this.cmbTrxDateLogic_SelectedIndexChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(273, 45);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(192, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(472, 45);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(187, 20);
            this.dtpDateTo.TabIndex = 4;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(73, 101);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 15);
            this.lblProduct.TabIndex = 5;
            this.lblProduct.Text = "Product";
            // 
            // cmdShowPrdImageList
            // 
            this.cmdShowPrdImageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowPrdImageList.Location = new System.Drawing.Point(632, 94);
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
            this.ckAllOrAny.Location = new System.Drawing.Point(251, 214);
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
            this.cmbLogicProduct.Location = new System.Drawing.Point(134, 98);
            this.cmbLogicProduct.Name = "cmbLogicProduct";
            this.cmbLogicProduct.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicProduct.TabIndex = 9;
            this.cmbLogicProduct.SelectedIndexChanged += new System.EventHandler(this.cmbTrxProductLogic_SelectedIndexChanged);
            // 
            // cmdSearchAndShowResult
            // 
            this.cmdSearchAndShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchAndShowResult.Location = new System.Drawing.Point(221, 239);
            this.cmdSearchAndShowResult.Name = "cmdSearchAndShowResult";
            this.cmdSearchAndShowResult.Size = new System.Drawing.Size(149, 38);
            this.cmdSearchAndShowResult.TabIndex = 11;
            this.cmdSearchAndShowResult.Text = "Show Result";
            this.cmdSearchAndShowResult.UseVisualStyleBackColor = true;
            this.cmdSearchAndShowResult.Click += new System.EventHandler(this.cmdSearchAndShowResult_Click);
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.Location = new System.Drawing.Point(77, 22);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(52, 15);
            this.lblStation.TabIndex = 12;
            this.lblStation.Text = "Station";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNo.Location = new System.Drawing.Point(36, 284);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(86, 15);
            this.lblDocumentNo.TabIndex = 13;
            this.lblDocumentNo.Text = "Documet No";
            this.lblDocumentNo.Visible = false;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(70, 130);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(59, 15);
            this.lblQuantity.TabIndex = 19;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(66, 181);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Category";
            // 
            // cmbLogicStation
            // 
            this.cmbLogicStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicStation.FormattingEnabled = true;
            this.cmbLogicStation.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicStation.Location = new System.Drawing.Point(134, 19);
            this.cmbLogicStation.Name = "cmbLogicStation";
            this.cmbLogicStation.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicStation.TabIndex = 1;
            this.cmbLogicStation.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicStation_SelectedIndexChanged);
            // 
            // cmbLogicDocNo
            // 
            this.cmbLogicDocNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDocNo.FormattingEnabled = true;
            this.cmbLogicDocNo.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbLogicDocNo.Location = new System.Drawing.Point(127, 281);
            this.cmbLogicDocNo.Name = "cmbLogicDocNo";
            this.cmbLogicDocNo.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicDocNo.TabIndex = 1;
            this.cmbLogicDocNo.Visible = false;
            this.cmbLogicDocNo.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicDocNo_SelectedIndexChanged);
            // 
            // cmbLogicCategory
            // 
            this.cmbLogicCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicCategory.FormattingEnabled = true;
            this.cmbLogicCategory.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicCategory.Location = new System.Drawing.Point(134, 178);
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
            this.cmbLogicQuantity.Location = new System.Drawing.Point(134, 127);
            this.cmbLogicQuantity.Name = "cmbLogicQuantity";
            this.cmbLogicQuantity.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicQuantity.TabIndex = 1;
            this.cmbLogicQuantity.SelectedIndexChanged += new System.EventHandler(this.cmbUsageLogicUsageQty_SelectedIndexChanged);
            // 
            // cmbStations
            // 
            this.cmbStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(273, 19);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(138, 21);
            this.cmbStations.TabIndex = 1;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(266, 281);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(177, 20);
            this.txtDocumentNo.TabIndex = 23;
            this.txtDocumentNo.Visible = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(272, 178);
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
            this.cmbLogicWarehouse.Location = new System.Drawing.Point(134, 152);
            this.cmbLogicWarehouse.Name = "cmbLogicWarehouse";
            this.cmbLogicWarehouse.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicWarehouse.TabIndex = 1;
            this.cmbLogicWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicWarehouse_SelectedIndexChanged);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(272, 152);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.AutoSize = true;
            this.lblWareHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouse.Location = new System.Drawing.Point(50, 155);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(79, 15);
            this.lblWareHouse.TabIndex = 20;
            this.lblWareHouse.Text = "Warehouse";
            // 
            // ntbQtyTo
            // 
            this.ntbQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbQtyTo.AllowedLength = 0;
            this.ntbQtyTo.AllowLeadingZeros = false;
            this.ntbQtyTo.AllowNegative = false;
            this.ntbQtyTo.Amount = "";
            this.ntbQtyTo.defaultAmount = "0";
            this.ntbQtyTo.Location = new System.Drawing.Point(415, 125);
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
            this.ntbQtyFrom.AllowedLength = 0;
            this.ntbQtyFrom.AllowLeadingZeros = false;
            this.ntbQtyFrom.AllowNegative = false;
            this.ntbQtyFrom.Amount = "";
            this.ntbQtyFrom.defaultAmount = "0";
            this.ntbQtyFrom.Location = new System.Drawing.Point(271, 125);
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
            this.ddgProduct.Location = new System.Drawing.Point(270, 93);
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
            // cmbLogicMovementType
            // 
            this.cmbLogicMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicMovementType.FormattingEnabled = true;
            this.cmbLogicMovementType.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicMovementType.Location = new System.Drawing.Point(135, 70);
            this.cmbLogicMovementType.Name = "cmbLogicMovementType";
            this.cmbLogicMovementType.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicMovementType.TabIndex = 1;
            this.cmbLogicMovementType.SelectedIndexChanged += new System.EventHandler(this.cmbLogicMovementType_SelectedIndexChanged);
            // 
            // cmbMovmentType
            // 
            this.cmbMovmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovmentType.FormattingEnabled = true;
            this.cmbMovmentType.Location = new System.Drawing.Point(273, 70);
            this.cmbMovmentType.Name = "cmbMovmentType";
            this.cmbMovmentType.Size = new System.Drawing.Size(138, 21);
            this.cmbMovmentType.TabIndex = 1;
            // 
            // lblMovementType
            // 
            this.lblMovementType.AutoSize = true;
            this.lblMovementType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovementType.Location = new System.Drawing.Point(22, 73);
            this.lblMovementType.Name = "lblMovementType";
            this.lblMovementType.Size = new System.Drawing.Size(107, 15);
            this.lblMovementType.TabIndex = 20;
            this.lblMovementType.Text = "Movement Type";
            // 
            // frmSearchMaterialTransaction
            // 
            this.ClientSize = new System.Drawing.Size(684, 306);
            this.Controls.Add(this.ntbQtyTo);
            this.Controls.Add(this.ntbQtyFrom);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblWareHouse);
            this.Controls.Add(this.lblMovementType);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.cmdSearchAndShowResult);
            this.Controls.Add(this.cmbLogicProduct);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.cmdShowPrdImageList);
            this.Controls.Add(this.ddgProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.cmbLogicQuantity);
            this.Controls.Add(this.cmbLogicDocNo);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbMovmentType);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.cmbLogicStation);
            this.Controls.Add(this.cmbLogicMovementType);
            this.Controls.Add(this.cmbLogicWarehouse);
            this.Controls.Add(this.cmbLogicCategory);
            this.Controls.Add(this.cmbLogicDate);
            this.Controls.Add(this.lblDate);
            this.Name = "frmSearchMaterialTransaction";
            this.Text = "Search For Material Transaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbLogicDate;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblProduct;
        private DropDownDataGrid ddgProduct;
        private System.Windows.Forms.Button cmdShowPrdImageList;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbLogicProduct;
        private System.Windows.Forms.Button cmdSearchAndShowResult;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbLogicStation;
        private System.Windows.Forms.ComboBox cmbLogicDocNo;
        private System.Windows.Forms.ComboBox cmbLogicCategory;
        private System.Windows.Forms.ComboBox cmbLogicQuantity;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private ctlNumberTextBox ntbQtyFrom;
        private ctlNumberTextBox ntbQtyTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbLogicWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWareHouse;
        private System.Windows.Forms.ComboBox cmbLogicMovementType;
        private System.Windows.Forms.ComboBox cmbMovmentType;
        private System.Windows.Forms.Label lblMovementType;
    }
}