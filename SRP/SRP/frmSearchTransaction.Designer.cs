namespace SRP
{
    partial class frmSearchTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchTransaction));
            this.lblTrxDate = new System.Windows.Forms.Label();
            this.cmbTrxLogicDate = new System.Windows.Forms.ComboBox();
            this.dtpTrxDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTrxDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmdShowPrdImageList = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbTrxLogicProduct = new System.Windows.Forms.ComboBox();
            this.cmdSearchAndShowResult = new System.Windows.Forms.Button();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblBpartner = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTaxtotal = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblOrderPrice = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.cmbTrxLogicStation = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicBpartner = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicDocNo = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicSubTotal = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicGrandTotal = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicTaxTotal = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicCategory = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicPrice = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicQuantity = new System.Windows.Forms.ComboBox();
            this.cmbTrxLogicDocStatus = new System.Windows.Forms.ComboBox();
            this.ckIsTrxSales = new System.Windows.Forms.CheckBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbTrxDocstatus = new System.Windows.Forms.ComboBox();
            this.ntbTrxQtyTo = new SRP.ctlNumberTextBox();
            this.ntbGrandTotalTo = new SRP.ctlNumberTextBox();
            this.ntbTrxPriceTo = new SRP.ctlNumberTextBox();
            this.ntbTaxTotalTo = new SRP.ctlNumberTextBox();
            this.ntbSubTotalTo = new SRP.ctlNumberTextBox();
            this.ntbTrxQtyFrom = new SRP.ctlNumberTextBox();
            this.ntbGrandTotalFrom = new SRP.ctlNumberTextBox();
            this.ntbTrxPriceFrom = new SRP.ctlNumberTextBox();
            this.ntbTaxTotalFrom = new SRP.ctlNumberTextBox();
            this.ntbSubTotalFrom = new SRP.ctlNumberTextBox();
            this.ddgTrxBpartner = new SRP.DropDownDataGrid();
            this.ddgTrxProduct = new SRP.DropDownDataGrid();
            this.cmbTrxLogicWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblWareHouse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTrxDate
            // 
            this.lblTrxDate.AutoSize = true;
            this.lblTrxDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrxDate.Location = new System.Drawing.Point(68, 70);
            this.lblTrxDate.Name = "lblTrxDate";
            this.lblTrxDate.Size = new System.Drawing.Size(61, 15);
            this.lblTrxDate.TabIndex = 0;
            this.lblTrxDate.Text = "Trx Date";
            // 
            // cmbTrxLogicDate
            // 
            this.cmbTrxLogicDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicDate.FormattingEnabled = true;
            this.cmbTrxLogicDate.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxLogicDate.Location = new System.Drawing.Point(134, 67);
            this.cmbTrxLogicDate.Name = "cmbTrxLogicDate";
            this.cmbTrxLogicDate.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicDate.TabIndex = 1;
            this.cmbTrxLogicDate.SelectedIndexChanged += new System.EventHandler(this.cmbTrxDateLogic_SelectedIndexChanged);
            // 
            // dtpTrxDateFrom
            // 
            this.dtpTrxDateFrom.Location = new System.Drawing.Point(273, 67);
            this.dtpTrxDateFrom.Name = "dtpTrxDateFrom";
            this.dtpTrxDateFrom.Size = new System.Drawing.Size(192, 20);
            this.dtpTrxDateFrom.TabIndex = 2;
            // 
            // dtpTrxDateTo
            // 
            this.dtpTrxDateTo.Location = new System.Drawing.Point(476, 67);
            this.dtpTrxDateTo.Name = "dtpTrxDateTo";
            this.dtpTrxDateTo.Size = new System.Drawing.Size(187, 20);
            this.dtpTrxDateTo.TabIndex = 4;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(73, 213);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 15);
            this.lblProduct.TabIndex = 5;
            this.lblProduct.Text = "Product";
            // 
            // cmdShowPrdImageList
            // 
            this.cmdShowPrdImageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowPrdImageList.Location = new System.Drawing.Point(635, 206);
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
            this.ckAllOrAny.Location = new System.Drawing.Point(309, 436);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.Size = new System.Drawing.Size(85, 19);
            this.ckAllOrAny.TabIndex = 8;
            this.ckAllOrAny.Text = "All or Any";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmbTrxLogicProduct
            // 
            this.cmbTrxLogicProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicProduct.FormattingEnabled = true;
            this.cmbTrxLogicProduct.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTrxLogicProduct.Location = new System.Drawing.Point(134, 210);
            this.cmbTrxLogicProduct.Name = "cmbTrxLogicProduct";
            this.cmbTrxLogicProduct.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicProduct.TabIndex = 9;
            this.cmbTrxLogicProduct.SelectedIndexChanged += new System.EventHandler(this.cmbTrxProductLogic_SelectedIndexChanged);
            // 
            // cmdSearchAndShowResult
            // 
            this.cmdSearchAndShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchAndShowResult.Location = new System.Drawing.Point(279, 461);
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
            // lblBpartner
            // 
            this.lblBpartner.AutoSize = true;
            this.lblBpartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBpartner.Location = new System.Drawing.Point(75, 99);
            this.lblBpartner.Name = "lblBpartner";
            this.lblBpartner.Size = new System.Drawing.Size(54, 15);
            this.lblBpartner.TabIndex = 14;
            this.lblBpartner.Text = "Partner";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(61, 132);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(68, 15);
            this.lblSubTotal.TabIndex = 15;
            this.lblSubTotal.Text = "Sub Total";
            // 
            // lblTaxtotal
            // 
            this.lblTaxtotal.AutoSize = true;
            this.lblTaxtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxtotal.Location = new System.Drawing.Point(63, 157);
            this.lblTaxtotal.Name = "lblTaxtotal";
            this.lblTaxtotal.Size = new System.Drawing.Size(66, 15);
            this.lblTaxtotal.TabIndex = 16;
            this.lblTaxtotal.Text = "Tax Total";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(47, 184);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(82, 15);
            this.lblGrandTotal.TabIndex = 17;
            this.lblGrandTotal.Text = "Grand Total";
            // 
            // lblOrderPrice
            // 
            this.lblOrderPrice.AutoSize = true;
            this.lblOrderPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderPrice.Location = new System.Drawing.Point(89, 245);
            this.lblOrderPrice.Name = "lblOrderPrice";
            this.lblOrderPrice.Size = new System.Drawing.Size(40, 15);
            this.lblOrderPrice.TabIndex = 18;
            this.lblOrderPrice.Text = "Price";
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.AutoSize = true;
            this.lblOrderQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQty.Location = new System.Drawing.Point(70, 272);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(59, 15);
            this.lblOrderQty.TabIndex = 19;
            this.lblOrderQty.Text = "Quantity";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(66, 323);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Category";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.AutoSize = true;
            this.lblDocStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocStatus.Location = new System.Drawing.Point(13, 349);
            this.lblDocStatus.Name = "lblDocStatus";
            this.lblDocStatus.Size = new System.Drawing.Size(116, 15);
            this.lblDocStatus.TabIndex = 21;
            this.lblDocStatus.Text = "Document Status";
            // 
            // cmbTrxLogicStation
            // 
            this.cmbTrxLogicStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicStation.FormattingEnabled = true;
            this.cmbTrxLogicStation.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTrxLogicStation.Location = new System.Drawing.Point(134, 19);
            this.cmbTrxLogicStation.Name = "cmbTrxLogicStation";
            this.cmbTrxLogicStation.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicStation.TabIndex = 1;
            this.cmbTrxLogicStation.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicStation_SelectedIndexChanged);
            // 
            // cmbTrxLogicBpartner
            // 
            this.cmbTrxLogicBpartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicBpartner.FormattingEnabled = true;
            this.cmbTrxLogicBpartner.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTrxLogicBpartner.Location = new System.Drawing.Point(134, 96);
            this.cmbTrxLogicBpartner.Name = "cmbTrxLogicBpartner";
            this.cmbTrxLogicBpartner.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicBpartner.TabIndex = 1;
            this.cmbTrxLogicBpartner.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicBpartner_SelectedIndexChanged);
            // 
            // cmbTrxLogicDocNo
            // 
            this.cmbTrxLogicDocNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicDocNo.FormattingEnabled = true;
            this.cmbTrxLogicDocNo.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbTrxLogicDocNo.Location = new System.Drawing.Point(134, 43);
            this.cmbTrxLogicDocNo.Name = "cmbTrxLogicDocNo";
            this.cmbTrxLogicDocNo.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicDocNo.TabIndex = 1;
            this.cmbTrxLogicDocNo.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicDocNo_SelectedIndexChanged);
            // 
            // cmbTrxLogicSubTotal
            // 
            this.cmbTrxLogicSubTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicSubTotal.FormattingEnabled = true;
            this.cmbTrxLogicSubTotal.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxLogicSubTotal.Location = new System.Drawing.Point(134, 129);
            this.cmbTrxLogicSubTotal.Name = "cmbTrxLogicSubTotal";
            this.cmbTrxLogicSubTotal.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicSubTotal.TabIndex = 1;
            this.cmbTrxLogicSubTotal.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicSubTotal_SelectedIndexChanged);
            // 
            // cmbTrxLogicGrandTotal
            // 
            this.cmbTrxLogicGrandTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicGrandTotal.FormattingEnabled = true;
            this.cmbTrxLogicGrandTotal.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxLogicGrandTotal.Location = new System.Drawing.Point(134, 181);
            this.cmbTrxLogicGrandTotal.Name = "cmbTrxLogicGrandTotal";
            this.cmbTrxLogicGrandTotal.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicGrandTotal.TabIndex = 1;
            this.cmbTrxLogicGrandTotal.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicGrandTotal_SelectedIndexChanged);
            // 
            // cmbTrxLogicTaxTotal
            // 
            this.cmbTrxLogicTaxTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicTaxTotal.FormattingEnabled = true;
            this.cmbTrxLogicTaxTotal.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxLogicTaxTotal.Location = new System.Drawing.Point(134, 155);
            this.cmbTrxLogicTaxTotal.Name = "cmbTrxLogicTaxTotal";
            this.cmbTrxLogicTaxTotal.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicTaxTotal.TabIndex = 1;
            this.cmbTrxLogicTaxTotal.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicTaxTotal_SelectedIndexChanged);
            // 
            // cmbTrxLogicCategory
            // 
            this.cmbTrxLogicCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicCategory.FormattingEnabled = true;
            this.cmbTrxLogicCategory.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTrxLogicCategory.Location = new System.Drawing.Point(134, 320);
            this.cmbTrxLogicCategory.Name = "cmbTrxLogicCategory";
            this.cmbTrxLogicCategory.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicCategory.TabIndex = 1;
            this.cmbTrxLogicCategory.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicCategory_SelectedIndexChanged);
            // 
            // cmbTrxLogicPrice
            // 
            this.cmbTrxLogicPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicPrice.FormattingEnabled = true;
            this.cmbTrxLogicPrice.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxLogicPrice.Location = new System.Drawing.Point(134, 242);
            this.cmbTrxLogicPrice.Name = "cmbTrxLogicPrice";
            this.cmbTrxLogicPrice.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicPrice.TabIndex = 1;
            this.cmbTrxLogicPrice.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicPrice_SelectedIndexChanged);
            // 
            // cmbTrxLogicQuantity
            // 
            this.cmbTrxLogicQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicQuantity.FormattingEnabled = true;
            this.cmbTrxLogicQuantity.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxLogicQuantity.Location = new System.Drawing.Point(134, 269);
            this.cmbTrxLogicQuantity.Name = "cmbTrxLogicQuantity";
            this.cmbTrxLogicQuantity.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicQuantity.TabIndex = 1;
            this.cmbTrxLogicQuantity.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicQuantity_SelectedIndexChanged);
            // 
            // cmbTrxLogicDocStatus
            // 
            this.cmbTrxLogicDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicDocStatus.FormattingEnabled = true;
            this.cmbTrxLogicDocStatus.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTrxLogicDocStatus.Location = new System.Drawing.Point(134, 346);
            this.cmbTrxLogicDocStatus.Name = "cmbTrxLogicDocStatus";
            this.cmbTrxLogicDocStatus.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicDocStatus.TabIndex = 1;
            this.cmbTrxLogicDocStatus.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicDocStatus_SelectedIndexChanged);
            // 
            // ckIsTrxSales
            // 
            this.ckIsTrxSales.AutoSize = true;
            this.ckIsTrxSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsTrxSales.Location = new System.Drawing.Point(279, 395);
            this.ckIsTrxSales.Name = "ckIsTrxSales";
            this.ckIsTrxSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckIsTrxSales.Size = new System.Drawing.Size(124, 19);
            this.ckIsTrxSales.TabIndex = 22;
            this.ckIsTrxSales.Text = "Is Inventory Out";
            this.ckIsTrxSales.ThreeState = true;
            this.ckIsTrxSales.UseVisualStyleBackColor = true;
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
            this.cmbCategory.Location = new System.Drawing.Point(272, 320);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(138, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cmbTrxDocstatus
            // 
            this.cmbTrxDocstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxDocstatus.FormattingEnabled = true;
            this.cmbTrxDocstatus.Location = new System.Drawing.Point(272, 346);
            this.cmbTrxDocstatus.Name = "cmbTrxDocstatus";
            this.cmbTrxDocstatus.Size = new System.Drawing.Size(138, 21);
            this.cmbTrxDocstatus.TabIndex = 1;
            // 
            // ntbTrxQtyTo
            // 
            this.ntbTrxQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTrxQtyTo.AllowedLength = 0;
            this.ntbTrxQtyTo.AllowNegative = false;
            this.ntbTrxQtyTo.Amount = "";
            this.ntbTrxQtyTo.defaultAmount = "0";
            this.ntbTrxQtyTo.Location = new System.Drawing.Point(415, 267);
            this.ntbTrxQtyTo.Name = "ntbTrxQtyTo";
            this.ntbTrxQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTrxQtyTo.ShowThousandSeparetor = true;
            this.ntbTrxQtyTo.Size = new System.Drawing.Size(138, 23);
            this.ntbTrxQtyTo.StandardPrecision = 2;
            this.ntbTrxQtyTo.TabIndex = 25;
            // 
            // ntbGrandTotalTo
            // 
            this.ntbGrandTotalTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbGrandTotalTo.AllowedLength = 0;
            this.ntbGrandTotalTo.AllowNegative = false;
            this.ntbGrandTotalTo.Amount = "";
            this.ntbGrandTotalTo.defaultAmount = "0";
            this.ntbGrandTotalTo.Location = new System.Drawing.Point(417, 180);
            this.ntbGrandTotalTo.Name = "ntbGrandTotalTo";
            this.ntbGrandTotalTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbGrandTotalTo.ShowThousandSeparetor = true;
            this.ntbGrandTotalTo.Size = new System.Drawing.Size(138, 23);
            this.ntbGrandTotalTo.StandardPrecision = 2;
            this.ntbGrandTotalTo.TabIndex = 25;
            // 
            // ntbTrxPriceTo
            // 
            this.ntbTrxPriceTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTrxPriceTo.AllowedLength = 0;
            this.ntbTrxPriceTo.AllowNegative = false;
            this.ntbTrxPriceTo.Amount = "";
            this.ntbTrxPriceTo.defaultAmount = "0";
            this.ntbTrxPriceTo.Location = new System.Drawing.Point(415, 241);
            this.ntbTrxPriceTo.Name = "ntbTrxPriceTo";
            this.ntbTrxPriceTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTrxPriceTo.ShowThousandSeparetor = true;
            this.ntbTrxPriceTo.Size = new System.Drawing.Size(138, 23);
            this.ntbTrxPriceTo.StandardPrecision = 2;
            this.ntbTrxPriceTo.TabIndex = 25;
            // 
            // ntbTaxTotalTo
            // 
            this.ntbTaxTotalTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTaxTotalTo.AllowedLength = 0;
            this.ntbTaxTotalTo.AllowNegative = false;
            this.ntbTaxTotalTo.Amount = "";
            this.ntbTaxTotalTo.defaultAmount = "0";
            this.ntbTaxTotalTo.Location = new System.Drawing.Point(417, 154);
            this.ntbTaxTotalTo.Name = "ntbTaxTotalTo";
            this.ntbTaxTotalTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTaxTotalTo.ShowThousandSeparetor = true;
            this.ntbTaxTotalTo.Size = new System.Drawing.Size(138, 23);
            this.ntbTaxTotalTo.StandardPrecision = 2;
            this.ntbTaxTotalTo.TabIndex = 25;
            // 
            // ntbSubTotalTo
            // 
            this.ntbSubTotalTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbSubTotalTo.AllowedLength = 0;
            this.ntbSubTotalTo.AllowNegative = false;
            this.ntbSubTotalTo.Amount = "";
            this.ntbSubTotalTo.defaultAmount = "0";
            this.ntbSubTotalTo.Location = new System.Drawing.Point(417, 128);
            this.ntbSubTotalTo.Name = "ntbSubTotalTo";
            this.ntbSubTotalTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSubTotalTo.ShowThousandSeparetor = true;
            this.ntbSubTotalTo.Size = new System.Drawing.Size(138, 23);
            this.ntbSubTotalTo.StandardPrecision = 2;
            this.ntbSubTotalTo.TabIndex = 25;
            // 
            // ntbTrxQtyFrom
            // 
            this.ntbTrxQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTrxQtyFrom.AllowedLength = 0;
            this.ntbTrxQtyFrom.AllowNegative = false;
            this.ntbTrxQtyFrom.Amount = "";
            this.ntbTrxQtyFrom.defaultAmount = "0";
            this.ntbTrxQtyFrom.Location = new System.Drawing.Point(271, 267);
            this.ntbTrxQtyFrom.Name = "ntbTrxQtyFrom";
            this.ntbTrxQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTrxQtyFrom.ShowThousandSeparetor = true;
            this.ntbTrxQtyFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbTrxQtyFrom.StandardPrecision = 2;
            this.ntbTrxQtyFrom.TabIndex = 25;
            // 
            // ntbGrandTotalFrom
            // 
            this.ntbGrandTotalFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbGrandTotalFrom.AllowedLength = 0;
            this.ntbGrandTotalFrom.AllowNegative = false;
            this.ntbGrandTotalFrom.Amount = "";
            this.ntbGrandTotalFrom.defaultAmount = "0";
            this.ntbGrandTotalFrom.Location = new System.Drawing.Point(273, 180);
            this.ntbGrandTotalFrom.Name = "ntbGrandTotalFrom";
            this.ntbGrandTotalFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbGrandTotalFrom.ShowThousandSeparetor = true;
            this.ntbGrandTotalFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbGrandTotalFrom.StandardPrecision = 2;
            this.ntbGrandTotalFrom.TabIndex = 25;
            // 
            // ntbTrxPriceFrom
            // 
            this.ntbTrxPriceFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTrxPriceFrom.AllowedLength = 0;
            this.ntbTrxPriceFrom.AllowNegative = false;
            this.ntbTrxPriceFrom.Amount = "";
            this.ntbTrxPriceFrom.defaultAmount = "0";
            this.ntbTrxPriceFrom.Location = new System.Drawing.Point(271, 241);
            this.ntbTrxPriceFrom.Name = "ntbTrxPriceFrom";
            this.ntbTrxPriceFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTrxPriceFrom.ShowThousandSeparetor = true;
            this.ntbTrxPriceFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbTrxPriceFrom.StandardPrecision = 2;
            this.ntbTrxPriceFrom.TabIndex = 25;
            // 
            // ntbTaxTotalFrom
            // 
            this.ntbTaxTotalFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTaxTotalFrom.AllowedLength = 0;
            this.ntbTaxTotalFrom.AllowNegative = false;
            this.ntbTaxTotalFrom.Amount = "";
            this.ntbTaxTotalFrom.defaultAmount = "0";
            this.ntbTaxTotalFrom.Location = new System.Drawing.Point(273, 154);
            this.ntbTaxTotalFrom.Name = "ntbTaxTotalFrom";
            this.ntbTaxTotalFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTaxTotalFrom.ShowThousandSeparetor = true;
            this.ntbTaxTotalFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbTaxTotalFrom.StandardPrecision = 2;
            this.ntbTaxTotalFrom.TabIndex = 25;
            // 
            // ntbSubTotalFrom
            // 
            this.ntbSubTotalFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbSubTotalFrom.AllowedLength = 0;
            this.ntbSubTotalFrom.AllowNegative = false;
            this.ntbSubTotalFrom.Amount = "";
            this.ntbSubTotalFrom.defaultAmount = "0";
            this.ntbSubTotalFrom.Location = new System.Drawing.Point(272, 128);
            this.ntbSubTotalFrom.Name = "ntbSubTotalFrom";
            this.ntbSubTotalFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSubTotalFrom.ShowThousandSeparetor = true;
            this.ntbSubTotalFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbSubTotalFrom.StandardPrecision = 2;
            this.ntbSubTotalFrom.TabIndex = 25;
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
            this.ddgTrxBpartner.Location = new System.Drawing.Point(270, 92);
            this.ddgTrxBpartner.Margin = new System.Windows.Forms.Padding(0);
            this.ddgTrxBpartner.Name = "ddgTrxBpartner";
            this.ddgTrxBpartner.NewButtonEnabled = true;
            this.ddgTrxBpartner.RefreshButtonEnabled = true;
            this.ddgTrxBpartner.SelectedColomnIdex = 0;
            this.ddgTrxBpartner.SelectedItem = "";
            this.ddgTrxBpartner.SelectedRowKey = null;
            this.ddgTrxBpartner.ShowGridFunctions = false;
            this.ddgTrxBpartner.Size = new System.Drawing.Size(374, 31);
            this.ddgTrxBpartner.TabIndex = 24;
            this.ddgTrxBpartner.SelectedItemClicked += new System.EventHandler(this.ddgTrxBpartner_SelectedItemClicked);
            // 
            // ddgTrxProduct
            // 
            this.ddgTrxProduct.AutoFilter = true;
            this.ddgTrxProduct.AutoSize = true;
            this.ddgTrxProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgTrxProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgTrxProduct.ClearButtonEnabled = true;
            this.ddgTrxProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgTrxProduct.FindButtonEnabled = true;
            this.ddgTrxProduct.HiddenColoumns = new int[0];
            this.ddgTrxProduct.Image = null;
            this.ddgTrxProduct.Location = new System.Drawing.Point(270, 206);
            this.ddgTrxProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgTrxProduct.Name = "ddgTrxProduct";
            this.ddgTrxProduct.NewButtonEnabled = true;
            this.ddgTrxProduct.RefreshButtonEnabled = true;
            this.ddgTrxProduct.SelectedColomnIdex = 0;
            this.ddgTrxProduct.SelectedItem = "";
            this.ddgTrxProduct.SelectedRowKey = null;
            this.ddgTrxProduct.ShowGridFunctions = false;
            this.ddgTrxProduct.Size = new System.Drawing.Size(359, 31);
            this.ddgTrxProduct.TabIndex = 6;
            this.ddgTrxProduct.SelectedItemClicked += new System.EventHandler(this.ddgTrxProduct_SelectedItemClicked);
            // 
            // cmbTrxLogicWarehouse
            // 
            this.cmbTrxLogicWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxLogicWarehouse.FormattingEnabled = true;
            this.cmbTrxLogicWarehouse.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbTrxLogicWarehouse.Location = new System.Drawing.Point(134, 294);
            this.cmbTrxLogicWarehouse.Name = "cmbTrxLogicWarehouse";
            this.cmbTrxLogicWarehouse.Size = new System.Drawing.Size(134, 21);
            this.cmbTrxLogicWarehouse.TabIndex = 1;
            this.cmbTrxLogicWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbTrxLogicWarehouse_SelectedIndexChanged);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(272, 294);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.AutoSize = true;
            this.lblWareHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouse.Location = new System.Drawing.Point(50, 297);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(79, 15);
            this.lblWareHouse.TabIndex = 20;
            this.lblWareHouse.Text = "Warehouse";
            // 
            // frmSearchTransaction
            // 
            this.ClientSize = new System.Drawing.Size(694, 504);
            this.Controls.Add(this.ntbTrxQtyTo);
            this.Controls.Add(this.ntbGrandTotalTo);
            this.Controls.Add(this.ntbTrxPriceTo);
            this.Controls.Add(this.ntbTaxTotalTo);
            this.Controls.Add(this.ntbSubTotalTo);
            this.Controls.Add(this.ntbTrxQtyFrom);
            this.Controls.Add(this.ntbGrandTotalFrom);
            this.Controls.Add(this.ntbTrxPriceFrom);
            this.Controls.Add(this.ntbTaxTotalFrom);
            this.Controls.Add(this.ntbSubTotalFrom);
            this.Controls.Add(this.ddgTrxBpartner);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.ckIsTrxSales);
            this.Controls.Add(this.lblDocStatus);
            this.Controls.Add(this.lblWareHouse);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblOrderQty);
            this.Controls.Add(this.lblOrderPrice);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTaxtotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblBpartner);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.cmdSearchAndShowResult);
            this.Controls.Add(this.cmbTrxLogicProduct);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.cmdShowPrdImageList);
            this.Controls.Add(this.ddgTrxProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.dtpTrxDateTo);
            this.Controls.Add(this.dtpTrxDateFrom);
            this.Controls.Add(this.cmbTrxLogicTaxTotal);
            this.Controls.Add(this.cmbTrxLogicQuantity);
            this.Controls.Add(this.cmbTrxLogicDocNo);
            this.Controls.Add(this.cmbTrxLogicGrandTotal);
            this.Controls.Add(this.cmbTrxLogicSubTotal);
            this.Controls.Add(this.cmbTrxLogicBpartner);
            this.Controls.Add(this.cmbTrxLogicPrice);
            this.Controls.Add(this.cmbTrxDocstatus);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.cmbTrxLogicStation);
            this.Controls.Add(this.cmbTrxLogicDocStatus);
            this.Controls.Add(this.cmbTrxLogicWarehouse);
            this.Controls.Add(this.cmbTrxLogicCategory);
            this.Controls.Add(this.cmbTrxLogicDate);
            this.Controls.Add(this.lblTrxDate);
            this.Name = "frmSearchTransaction";
            this.Text = "Search For Transaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrxDate;
        private System.Windows.Forms.ComboBox cmbTrxLogicDate;
        private System.Windows.Forms.DateTimePicker dtpTrxDateFrom;
        private System.Windows.Forms.DateTimePicker dtpTrxDateTo;
        private System.Windows.Forms.Label lblProduct;
        private DropDownDataGrid ddgTrxProduct;
        private System.Windows.Forms.Button cmdShowPrdImageList;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbTrxLogicProduct;
        private System.Windows.Forms.Button cmdSearchAndShowResult;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblBpartner;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTaxtotal;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblOrderPrice;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.ComboBox cmbTrxLogicStation;
        private System.Windows.Forms.ComboBox cmbTrxLogicBpartner;
        private System.Windows.Forms.ComboBox cmbTrxLogicDocNo;
        private System.Windows.Forms.ComboBox cmbTrxLogicSubTotal;
        private System.Windows.Forms.ComboBox cmbTrxLogicGrandTotal;
        private System.Windows.Forms.ComboBox cmbTrxLogicTaxTotal;
        private System.Windows.Forms.ComboBox cmbTrxLogicCategory;
        private System.Windows.Forms.ComboBox cmbTrxLogicPrice;
        private System.Windows.Forms.ComboBox cmbTrxLogicQuantity;
        private System.Windows.Forms.ComboBox cmbTrxLogicDocStatus;
        private System.Windows.Forms.CheckBox ckIsTrxSales;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private DropDownDataGrid ddgTrxBpartner;
        private ctlNumberTextBox ntbSubTotalFrom;
        private ctlNumberTextBox ntbSubTotalTo;
        private ctlNumberTextBox ntbTaxTotalFrom;
        private ctlNumberTextBox ntbTaxTotalTo;
        private ctlNumberTextBox ntbGrandTotalFrom;
        private ctlNumberTextBox ntbGrandTotalTo;
        private ctlNumberTextBox ntbTrxPriceFrom;
        private ctlNumberTextBox ntbTrxQtyFrom;
        private ctlNumberTextBox ntbTrxPriceTo;
        private ctlNumberTextBox ntbTrxQtyTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbTrxDocstatus;
        private System.Windows.Forms.ComboBox cmbTrxLogicWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWareHouse;
    }
}