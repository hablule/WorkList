namespace SRP
{
    partial class frmSearchUsage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchUsage));
            this.lblUsageDate = new System.Windows.Forms.Label();
            this.cmbUsageLogicDate = new System.Windows.Forms.ComboBox();
            this.dtpUsageDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpUsageDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmdShowPrdImageList = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbUsageLogicProduct = new System.Windows.Forms.ComboBox();
            this.cmdSearchAndShowResult = new System.Windows.Forms.Button();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblUsedQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.cmbLogicStation = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocNo = new System.Windows.Forms.ComboBox();
            this.cmbLogicCategory = new System.Windows.Forms.ComboBox();
            this.cmbUsageLogicUsedQty = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocStatus = new System.Windows.Forms.ComboBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbDocstatus = new System.Windows.Forms.ComboBox();
            this.cmbLogicWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblWareHouse = new System.Windows.Forms.Label();
            this.ntbUsedQtyTo = new SRP.ctlNumberTextBox();
            this.ntbUsedQtyFrom = new SRP.ctlNumberTextBox();
            this.ddgUsedProduct = new SRP.DropDownDataGrid();
            this.SuspendLayout();
            // 
            // lblUsageDate
            // 
            this.lblUsageDate.AutoSize = true;
            this.lblUsageDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageDate.Location = new System.Drawing.Point(47, 70);
            this.lblUsageDate.Name = "lblUsageDate";
            this.lblUsageDate.Size = new System.Drawing.Size(82, 15);
            this.lblUsageDate.TabIndex = 0;
            this.lblUsageDate.Text = "Usage Date";
            // 
            // cmbUsageLogicDate
            // 
            this.cmbUsageLogicDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsageLogicDate.FormattingEnabled = true;
            this.cmbUsageLogicDate.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbUsageLogicDate.Location = new System.Drawing.Point(134, 67);
            this.cmbUsageLogicDate.Name = "cmbUsageLogicDate";
            this.cmbUsageLogicDate.Size = new System.Drawing.Size(134, 21);
            this.cmbUsageLogicDate.TabIndex = 1;
            this.cmbUsageLogicDate.SelectedIndexChanged += new System.EventHandler(this.cmbTrxDateLogic_SelectedIndexChanged);
            // 
            // dtpUsageDateFrom
            // 
            this.dtpUsageDateFrom.Location = new System.Drawing.Point(273, 67);
            this.dtpUsageDateFrom.Name = "dtpUsageDateFrom";
            this.dtpUsageDateFrom.Size = new System.Drawing.Size(192, 20);
            this.dtpUsageDateFrom.TabIndex = 2;
            // 
            // dtpUsageDateTo
            // 
            this.dtpUsageDateTo.Location = new System.Drawing.Point(476, 67);
            this.dtpUsageDateTo.Name = "dtpUsageDateTo";
            this.dtpUsageDateTo.Size = new System.Drawing.Size(187, 20);
            this.dtpUsageDateTo.TabIndex = 4;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(73, 97);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 15);
            this.lblProduct.TabIndex = 5;
            this.lblProduct.Text = "Product";
            // 
            // cmdShowPrdImageList
            // 
            this.cmdShowPrdImageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowPrdImageList.Location = new System.Drawing.Point(634, 91);
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
            this.ckAllOrAny.Location = new System.Drawing.Point(246, 244);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.Size = new System.Drawing.Size(85, 19);
            this.ckAllOrAny.TabIndex = 8;
            this.ckAllOrAny.Text = "All or Any";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmbUsageLogicProduct
            // 
            this.cmbUsageLogicProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsageLogicProduct.FormattingEnabled = true;
            this.cmbUsageLogicProduct.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbUsageLogicProduct.Location = new System.Drawing.Point(134, 94);
            this.cmbUsageLogicProduct.Name = "cmbUsageLogicProduct";
            this.cmbUsageLogicProduct.Size = new System.Drawing.Size(134, 21);
            this.cmbUsageLogicProduct.TabIndex = 9;
            this.cmbUsageLogicProduct.SelectedIndexChanged += new System.EventHandler(this.cmbTrxProductLogic_SelectedIndexChanged);
            // 
            // cmdSearchAndShowResult
            // 
            this.cmdSearchAndShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchAndShowResult.Location = new System.Drawing.Point(216, 269);
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
            this.lblDocumentNo.Location = new System.Drawing.Point(43, 46);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(86, 15);
            this.lblDocumentNo.TabIndex = 13;
            this.lblDocumentNo.Text = "Documet No";
            // 
            // lblUsedQty
            // 
            this.lblUsedQty.AutoSize = true;
            this.lblUsedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedQty.Location = new System.Drawing.Point(33, 127);
            this.lblUsedQty.Name = "lblUsedQty";
            this.lblUsedQty.Size = new System.Drawing.Size(96, 15);
            this.lblUsedQty.TabIndex = 19;
            this.lblUsedQty.Text = "Used Quantity";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(66, 178);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Category";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.AutoSize = true;
            this.lblDocStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocStatus.Location = new System.Drawing.Point(13, 204);
            this.lblDocStatus.Name = "lblDocStatus";
            this.lblDocStatus.Size = new System.Drawing.Size(116, 15);
            this.lblDocStatus.TabIndex = 21;
            this.lblDocStatus.Text = "Document Status";
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
            this.cmbLogicDocNo.Location = new System.Drawing.Point(134, 43);
            this.cmbLogicDocNo.Name = "cmbLogicDocNo";
            this.cmbLogicDocNo.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicDocNo.TabIndex = 1;
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
            this.cmbLogicCategory.Location = new System.Drawing.Point(134, 175);
            this.cmbLogicCategory.Name = "cmbLogicCategory";
            this.cmbLogicCategory.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicCategory.TabIndex = 1;
            this.cmbLogicCategory.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicCategory_SelectedIndexChanged);
            // 
            // cmbUsageLogicUsedQty
            // 
            this.cmbUsageLogicUsedQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsageLogicUsedQty.FormattingEnabled = true;
            this.cmbUsageLogicUsedQty.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbUsageLogicUsedQty.Location = new System.Drawing.Point(134, 124);
            this.cmbUsageLogicUsedQty.Name = "cmbUsageLogicUsedQty";
            this.cmbUsageLogicUsedQty.Size = new System.Drawing.Size(134, 21);
            this.cmbUsageLogicUsedQty.TabIndex = 1;
            this.cmbUsageLogicUsedQty.SelectedIndexChanged += new System.EventHandler(this.cmbUsageLogicUsageQty_SelectedIndexChanged);
            // 
            // cmbLogicDocStatus
            // 
            this.cmbLogicDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDocStatus.FormattingEnabled = true;
            this.cmbLogicDocStatus.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicDocStatus.Location = new System.Drawing.Point(134, 201);
            this.cmbLogicDocStatus.Name = "cmbLogicDocStatus";
            this.cmbLogicDocStatus.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicDocStatus.TabIndex = 1;
            this.cmbLogicDocStatus.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicDocStatus_SelectedIndexChanged);
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
            this.txtDocumentNo.Location = new System.Drawing.Point(273, 43);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(177, 20);
            this.txtDocumentNo.TabIndex = 23;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(272, 175);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(138, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cmbDocstatus
            // 
            this.cmbDocstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocstatus.FormattingEnabled = true;
            this.cmbDocstatus.Location = new System.Drawing.Point(272, 201);
            this.cmbDocstatus.Name = "cmbDocstatus";
            this.cmbDocstatus.Size = new System.Drawing.Size(138, 21);
            this.cmbDocstatus.TabIndex = 1;
            // 
            // cmbLogicWarehouse
            // 
            this.cmbLogicWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicWarehouse.FormattingEnabled = true;
            this.cmbLogicWarehouse.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicWarehouse.Location = new System.Drawing.Point(134, 149);
            this.cmbLogicWarehouse.Name = "cmbLogicWarehouse";
            this.cmbLogicWarehouse.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicWarehouse.TabIndex = 1;
            this.cmbLogicWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicWarehouse_SelectedIndexChanged);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(272, 149);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.AutoSize = true;
            this.lblWareHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouse.Location = new System.Drawing.Point(50, 152);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(79, 15);
            this.lblWareHouse.TabIndex = 20;
            this.lblWareHouse.Text = "Warehouse";
            // 
            // ntbUsedQtyTo
            // 
            this.ntbUsedQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbUsedQtyTo.AllowNegative = false;
            this.ntbUsedQtyTo.Amount = "";
            this.ntbUsedQtyTo.Location = new System.Drawing.Point(415, 122);
            this.ntbUsedQtyTo.Name = "ntbUsedQtyTo";
            this.ntbUsedQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbUsedQtyTo.ShowThousandSeparetor = true;
            this.ntbUsedQtyTo.Size = new System.Drawing.Size(138, 23);
            this.ntbUsedQtyTo.StandardPrecision = 2;
            this.ntbUsedQtyTo.TabIndex = 25;
            // 
            // ntbUsedQtyFrom
            // 
            this.ntbUsedQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbUsedQtyFrom.AllowNegative = false;
            this.ntbUsedQtyFrom.Amount = "";
            this.ntbUsedQtyFrom.Location = new System.Drawing.Point(271, 122);
            this.ntbUsedQtyFrom.Name = "ntbUsedQtyFrom";
            this.ntbUsedQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbUsedQtyFrom.ShowThousandSeparetor = true;
            this.ntbUsedQtyFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbUsedQtyFrom.StandardPrecision = 2;
            this.ntbUsedQtyFrom.TabIndex = 25;
            // 
            // ddgUsedProduct
            // 
            this.ddgUsedProduct.AutoFilter = true;
            this.ddgUsedProduct.AutoSize = true;
            this.ddgUsedProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgUsedProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgUsedProduct.ClearButtonEnabled = true;
            this.ddgUsedProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgUsedProduct.FindButtonEnabled = true;
            this.ddgUsedProduct.HiddenColoumns = new int[0];
            this.ddgUsedProduct.Image = null;
            this.ddgUsedProduct.Location = new System.Drawing.Point(270, 90);
            this.ddgUsedProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgUsedProduct.Name = "ddgUsedProduct";
            this.ddgUsedProduct.NewButtonEnabled = true;
            this.ddgUsedProduct.RefreshButtonEnabled = true;
            this.ddgUsedProduct.SelectedColomnIdex = 0;
            this.ddgUsedProduct.SelectedItem = "";
            this.ddgUsedProduct.SelectedRowKey = null;
            this.ddgUsedProduct.ShowGridFunctions = false;
            this.ddgUsedProduct.Size = new System.Drawing.Size(359, 31);
            this.ddgUsedProduct.TabIndex = 6;
            this.ddgUsedProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            // 
            // frmSearchUsage
            // 
            this.ClientSize = new System.Drawing.Size(684, 321);
            this.Controls.Add(this.ntbUsedQtyTo);
            this.Controls.Add(this.ntbUsedQtyFrom);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblDocStatus);
            this.Controls.Add(this.lblWareHouse);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblUsedQty);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.cmdSearchAndShowResult);
            this.Controls.Add(this.cmbUsageLogicProduct);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.cmdShowPrdImageList);
            this.Controls.Add(this.ddgUsedProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.dtpUsageDateTo);
            this.Controls.Add(this.dtpUsageDateFrom);
            this.Controls.Add(this.cmbUsageLogicUsedQty);
            this.Controls.Add(this.cmbLogicDocNo);
            this.Controls.Add(this.cmbDocstatus);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.cmbLogicStation);
            this.Controls.Add(this.cmbLogicDocStatus);
            this.Controls.Add(this.cmbLogicWarehouse);
            this.Controls.Add(this.cmbLogicCategory);
            this.Controls.Add(this.cmbUsageLogicDate);
            this.Controls.Add(this.lblUsageDate);
            this.Name = "frmSearchUsage";
            this.Text = "Search For Usage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsageDate;
        private System.Windows.Forms.ComboBox cmbUsageLogicDate;
        private System.Windows.Forms.DateTimePicker dtpUsageDateFrom;
        private System.Windows.Forms.DateTimePicker dtpUsageDateTo;
        private System.Windows.Forms.Label lblProduct;
        private DropDownDataGrid ddgUsedProduct;
        private System.Windows.Forms.Button cmdShowPrdImageList;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbUsageLogicProduct;
        private System.Windows.Forms.Button cmdSearchAndShowResult;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblUsedQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.ComboBox cmbLogicStation;
        private System.Windows.Forms.ComboBox cmbLogicDocNo;
        private System.Windows.Forms.ComboBox cmbLogicCategory;
        private System.Windows.Forms.ComboBox cmbUsageLogicUsedQty;
        private System.Windows.Forms.ComboBox cmbLogicDocStatus;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private ctlNumberTextBox ntbUsedQtyFrom;
        private ctlNumberTextBox ntbUsedQtyTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbDocstatus;
        private System.Windows.Forms.ComboBox cmbLogicWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWareHouse;
    }
}