namespace SRP
{
    partial class frmSearchCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchCount));
            this.lblCountDate = new System.Windows.Forms.Label();
            this.cmbCountLogicDate = new System.Windows.Forms.ComboBox();
            this.dtpCountDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCountDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmdShowPrdImageList = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbCountLogicProduct = new System.Windows.Forms.ComboBox();
            this.cmdSearchAndShowResult = new System.Windows.Forms.Button();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblCountCountQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.cmbLogicStation = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocNo = new System.Windows.Forms.ComboBox();
            this.cmbLogicCategory = new System.Windows.Forms.ComboBox();
            this.cmbCountLogicCountQty = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocStatus = new System.Windows.Forms.ComboBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbDocstatus = new System.Windows.Forms.ComboBox();
            this.cmbLogicWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblWareHouse = new System.Windows.Forms.Label();
            this.ntbCountCountQtyTo = new SRP.ctlNumberTextBox();
            this.ntbCountCountQtyFrom = new SRP.ctlNumberTextBox();
            this.ddgCountProduct = new SRP.DropDownDataGrid();
            this.ntbCountBookQtyTo = new SRP.ctlNumberTextBox();
            this.ntbCountBookQtyFrom = new SRP.ctlNumberTextBox();
            this.lblCountBookQty = new System.Windows.Forms.Label();
            this.cmbCountLogicBookQty = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCountDate
            // 
            this.lblCountDate.AutoSize = true;
            this.lblCountDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDate.Location = new System.Drawing.Point(68, 70);
            this.lblCountDate.Name = "lblCountDate";
            this.lblCountDate.Size = new System.Drawing.Size(61, 15);
            this.lblCountDate.TabIndex = 0;
            this.lblCountDate.Text = "Trx Date";
            // 
            // cmbCountLogicDate
            // 
            this.cmbCountLogicDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountLogicDate.FormattingEnabled = true;
            this.cmbCountLogicDate.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbCountLogicDate.Location = new System.Drawing.Point(134, 67);
            this.cmbCountLogicDate.Name = "cmbCountLogicDate";
            this.cmbCountLogicDate.Size = new System.Drawing.Size(134, 21);
            this.cmbCountLogicDate.TabIndex = 1;
            this.cmbCountLogicDate.SelectedIndexChanged += new System.EventHandler(this.cmbTrxDateLogic_SelectedIndexChanged);
            // 
            // dtpCountDateFrom
            // 
            this.dtpCountDateFrom.Location = new System.Drawing.Point(273, 67);
            this.dtpCountDateFrom.Name = "dtpCountDateFrom";
            this.dtpCountDateFrom.Size = new System.Drawing.Size(192, 20);
            this.dtpCountDateFrom.TabIndex = 2;
            // 
            // dtpCountDateTo
            // 
            this.dtpCountDateTo.Location = new System.Drawing.Point(476, 67);
            this.dtpCountDateTo.Name = "dtpCountDateTo";
            this.dtpCountDateTo.Size = new System.Drawing.Size(187, 20);
            this.dtpCountDateTo.TabIndex = 4;
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
            this.ckAllOrAny.Location = new System.Drawing.Point(246, 271);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.Size = new System.Drawing.Size(85, 19);
            this.ckAllOrAny.TabIndex = 8;
            this.ckAllOrAny.Text = "All or Any";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmbCountLogicProduct
            // 
            this.cmbCountLogicProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountLogicProduct.FormattingEnabled = true;
            this.cmbCountLogicProduct.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbCountLogicProduct.Location = new System.Drawing.Point(134, 94);
            this.cmbCountLogicProduct.Name = "cmbCountLogicProduct";
            this.cmbCountLogicProduct.Size = new System.Drawing.Size(134, 21);
            this.cmbCountLogicProduct.TabIndex = 9;
            this.cmbCountLogicProduct.SelectedIndexChanged += new System.EventHandler(this.cmbTrxProductLogic_SelectedIndexChanged);
            // 
            // cmdSearchAndShowResult
            // 
            this.cmdSearchAndShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchAndShowResult.Location = new System.Drawing.Point(216, 296);
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
            // lblCountCountQty
            // 
            this.lblCountCountQty.AutoSize = true;
            this.lblCountCountQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountCountQty.Location = new System.Drawing.Point(29, 156);
            this.lblCountCountQty.Name = "lblCountCountQty";
            this.lblCountCountQty.Size = new System.Drawing.Size(100, 15);
            this.lblCountCountQty.TabIndex = 19;
            this.lblCountCountQty.Text = "Count Quantity";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(66, 207);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Category";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.AutoSize = true;
            this.lblDocStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocStatus.Location = new System.Drawing.Point(13, 233);
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
            this.cmbLogicCategory.Location = new System.Drawing.Point(134, 204);
            this.cmbLogicCategory.Name = "cmbLogicCategory";
            this.cmbLogicCategory.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicCategory.TabIndex = 1;
            this.cmbLogicCategory.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicCategory_SelectedIndexChanged);
            // 
            // cmbCountLogicCountQty
            // 
            this.cmbCountLogicCountQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountLogicCountQty.FormattingEnabled = true;
            this.cmbCountLogicCountQty.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbCountLogicCountQty.Location = new System.Drawing.Point(134, 153);
            this.cmbCountLogicCountQty.Name = "cmbCountLogicCountQty";
            this.cmbCountLogicCountQty.Size = new System.Drawing.Size(134, 21);
            this.cmbCountLogicCountQty.TabIndex = 1;
            this.cmbCountLogicCountQty.SelectedIndexChanged += new System.EventHandler(this.cmbCountLogicCountQty_SelectedIndexChanged);
            // 
            // cmbLogicDocStatus
            // 
            this.cmbLogicDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDocStatus.FormattingEnabled = true;
            this.cmbLogicDocStatus.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicDocStatus.Location = new System.Drawing.Point(134, 230);
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
            this.cmbCategory.Location = new System.Drawing.Point(272, 204);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(138, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cmbDocstatus
            // 
            this.cmbDocstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocstatus.FormattingEnabled = true;
            this.cmbDocstatus.Location = new System.Drawing.Point(272, 230);
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
            this.cmbLogicWarehouse.Location = new System.Drawing.Point(134, 178);
            this.cmbLogicWarehouse.Name = "cmbLogicWarehouse";
            this.cmbLogicWarehouse.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicWarehouse.TabIndex = 1;
            this.cmbLogicWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicWarehouse_SelectedIndexChanged);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(272, 178);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.AutoSize = true;
            this.lblWareHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouse.Location = new System.Drawing.Point(50, 181);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(79, 15);
            this.lblWareHouse.TabIndex = 20;
            this.lblWareHouse.Text = "Warehouse";
            // 
            // ntbCountCountQtyTo
            // 
            this.ntbCountCountQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCountCountQtyTo.AllowNegative = false;
            this.ntbCountCountQtyTo.Amount = "";
            this.ntbCountCountQtyTo.Location = new System.Drawing.Point(415, 151);
            this.ntbCountCountQtyTo.Name = "ntbCountCountQtyTo";
            this.ntbCountCountQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCountCountQtyTo.ShowThousandSeparetor = true;
            this.ntbCountCountQtyTo.Size = new System.Drawing.Size(138, 23);
            this.ntbCountCountQtyTo.StandardPrecision = 2;
            this.ntbCountCountQtyTo.TabIndex = 25;
            // 
            // ntbCountCountQtyFrom
            // 
            this.ntbCountCountQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCountCountQtyFrom.AllowNegative = false;
            this.ntbCountCountQtyFrom.Amount = "";
            this.ntbCountCountQtyFrom.Location = new System.Drawing.Point(271, 151);
            this.ntbCountCountQtyFrom.Name = "ntbCountCountQtyFrom";
            this.ntbCountCountQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCountCountQtyFrom.ShowThousandSeparetor = true;
            this.ntbCountCountQtyFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbCountCountQtyFrom.StandardPrecision = 2;
            this.ntbCountCountQtyFrom.TabIndex = 25;
            // 
            // ddgCountProduct
            // 
            this.ddgCountProduct.AutoFilter = true;
            this.ddgCountProduct.AutoSize = true;
            this.ddgCountProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgCountProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgCountProduct.ClearButtonEnabled = true;
            this.ddgCountProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgCountProduct.FindButtonEnabled = true;
            this.ddgCountProduct.HiddenColoumns = new int[0];
            this.ddgCountProduct.Image = null;
            this.ddgCountProduct.Location = new System.Drawing.Point(270, 90);
            this.ddgCountProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCountProduct.Name = "ddgCountProduct";
            this.ddgCountProduct.NewButtonEnabled = true;
            this.ddgCountProduct.RefreshButtonEnabled = true;
            this.ddgCountProduct.SelectedColomnIdex = 0;
            this.ddgCountProduct.SelectedItem = "";
            this.ddgCountProduct.SelectedRowKey = null;
            this.ddgCountProduct.ShowGridFunctions = false;
            this.ddgCountProduct.Size = new System.Drawing.Size(359, 31);
            this.ddgCountProduct.TabIndex = 6;
            this.ddgCountProduct.SelectedItemClicked += new System.EventHandler(this.ddgTrxProduct_SelectedItemClicked);
            // 
            // ntbCountBookQtyTo
            // 
            this.ntbCountBookQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCountBookQtyTo.AllowNegative = false;
            this.ntbCountBookQtyTo.Amount = "";
            this.ntbCountBookQtyTo.Location = new System.Drawing.Point(415, 124);
            this.ntbCountBookQtyTo.Name = "ntbCountBookQtyTo";
            this.ntbCountBookQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCountBookQtyTo.ShowThousandSeparetor = true;
            this.ntbCountBookQtyTo.Size = new System.Drawing.Size(138, 23);
            this.ntbCountBookQtyTo.StandardPrecision = 2;
            this.ntbCountBookQtyTo.TabIndex = 28;
            // 
            // ntbCountBookQtyFrom
            // 
            this.ntbCountBookQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCountBookQtyFrom.AllowNegative = false;
            this.ntbCountBookQtyFrom.Amount = "";
            this.ntbCountBookQtyFrom.Location = new System.Drawing.Point(271, 124);
            this.ntbCountBookQtyFrom.Name = "ntbCountBookQtyFrom";
            this.ntbCountBookQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCountBookQtyFrom.ShowThousandSeparetor = true;
            this.ntbCountBookQtyFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbCountBookQtyFrom.StandardPrecision = 2;
            this.ntbCountBookQtyFrom.TabIndex = 29;
            // 
            // lblCountBookQty
            // 
            this.lblCountBookQty.AutoSize = true;
            this.lblCountBookQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountBookQty.Location = new System.Drawing.Point(34, 129);
            this.lblCountBookQty.Name = "lblCountBookQty";
            this.lblCountBookQty.Size = new System.Drawing.Size(95, 15);
            this.lblCountBookQty.TabIndex = 27;
            this.lblCountBookQty.Text = "Book Quantity";
            // 
            // cmbCountLogicBookQty
            // 
            this.cmbCountLogicBookQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountLogicBookQty.FormattingEnabled = true;
            this.cmbCountLogicBookQty.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbCountLogicBookQty.Location = new System.Drawing.Point(134, 126);
            this.cmbCountLogicBookQty.Name = "cmbCountLogicBookQty";
            this.cmbCountLogicBookQty.Size = new System.Drawing.Size(134, 21);
            this.cmbCountLogicBookQty.TabIndex = 26;
            this.cmbCountLogicBookQty.SelectedIndexChanged += new System.EventHandler(this.cmbCountLogicBookQty_SelectedIndexChanged);
            // 
            // frmSearchCount
            // 
            this.ClientSize = new System.Drawing.Size(684, 344);
            this.Controls.Add(this.ntbCountBookQtyTo);
            this.Controls.Add(this.ntbCountBookQtyFrom);
            this.Controls.Add(this.lblCountBookQty);
            this.Controls.Add(this.cmbCountLogicBookQty);
            this.Controls.Add(this.ntbCountCountQtyTo);
            this.Controls.Add(this.ntbCountCountQtyFrom);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblDocStatus);
            this.Controls.Add(this.lblWareHouse);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblCountCountQty);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.cmdSearchAndShowResult);
            this.Controls.Add(this.cmbCountLogicProduct);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.cmdShowPrdImageList);
            this.Controls.Add(this.ddgCountProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.dtpCountDateTo);
            this.Controls.Add(this.dtpCountDateFrom);
            this.Controls.Add(this.cmbCountLogicCountQty);
            this.Controls.Add(this.cmbLogicDocNo);
            this.Controls.Add(this.cmbDocstatus);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.cmbLogicStation);
            this.Controls.Add(this.cmbLogicDocStatus);
            this.Controls.Add(this.cmbLogicWarehouse);
            this.Controls.Add(this.cmbLogicCategory);
            this.Controls.Add(this.cmbCountLogicDate);
            this.Controls.Add(this.lblCountDate);
            this.Name = "frmSearchCount";
            this.Text = "Search For Count";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCountDate;
        private System.Windows.Forms.ComboBox cmbCountLogicDate;
        private System.Windows.Forms.DateTimePicker dtpCountDateFrom;
        private System.Windows.Forms.DateTimePicker dtpCountDateTo;
        private System.Windows.Forms.Label lblProduct;
        private DropDownDataGrid ddgCountProduct;
        private System.Windows.Forms.Button cmdShowPrdImageList;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbCountLogicProduct;
        private System.Windows.Forms.Button cmdSearchAndShowResult;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblCountCountQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.ComboBox cmbLogicStation;
        private System.Windows.Forms.ComboBox cmbLogicDocNo;
        private System.Windows.Forms.ComboBox cmbLogicCategory;
        private System.Windows.Forms.ComboBox cmbCountLogicCountQty;
        private System.Windows.Forms.ComboBox cmbLogicDocStatus;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private ctlNumberTextBox ntbCountCountQtyFrom;
        private ctlNumberTextBox ntbCountCountQtyTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbDocstatus;
        private System.Windows.Forms.ComboBox cmbLogicWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWareHouse;
        private ctlNumberTextBox ntbCountBookQtyTo;
        private ctlNumberTextBox ntbCountBookQtyFrom;
        private System.Windows.Forms.Label lblCountBookQty;
        private System.Windows.Forms.ComboBox cmbCountLogicBookQty;
    }
}