namespace SRP
{
    partial class frmSearchMovement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchMovement));
            this.lblMovementDate = new System.Windows.Forms.Label();
            this.cmbMovementLogicDate = new System.Windows.Forms.ComboBox();
            this.dtpMovementDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpMovementDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmdShowPrdImageList = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmbMovementLogicProduct = new System.Windows.Forms.ComboBox();
            this.cmdSearchAndShowResult = new System.Windows.Forms.Button();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblMovedQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.cmbLogicStation = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocNo = new System.Windows.Forms.ComboBox();
            this.cmbLogicCategory = new System.Windows.Forms.ComboBox();
            this.cmbMovementLogicQty = new System.Windows.Forms.ComboBox();
            this.cmbLogicDocStatus = new System.Windows.Forms.ComboBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbDocstatus = new System.Windows.Forms.ComboBox();
            this.cmbLogicWarehouseFrom = new System.Windows.Forms.ComboBox();
            this.cmbWarehouseFrom = new System.Windows.Forms.ComboBox();
            this.lblWareHouseFrom = new System.Windows.Forms.Label();
            this.ntbMovedQtyTo = new SRP.ctlNumberTextBox();
            this.ntbMovedQtyFrom = new SRP.ctlNumberTextBox();
            this.ddgMovedProduct = new SRP.DropDownDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWarehouseTo = new System.Windows.Forms.ComboBox();
            this.cmbLogicWarehouseTo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblMovementDate
            // 
            this.lblMovementDate.AutoSize = true;
            this.lblMovementDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovementDate.Location = new System.Drawing.Point(22, 70);
            this.lblMovementDate.Name = "lblMovementDate";
            this.lblMovementDate.Size = new System.Drawing.Size(107, 15);
            this.lblMovementDate.TabIndex = 0;
            this.lblMovementDate.Text = "Movement Date";
            // 
            // cmbMovementLogicDate
            // 
            this.cmbMovementLogicDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementLogicDate.FormattingEnabled = true;
            this.cmbMovementLogicDate.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbMovementLogicDate.Location = new System.Drawing.Point(134, 67);
            this.cmbMovementLogicDate.Name = "cmbMovementLogicDate";
            this.cmbMovementLogicDate.Size = new System.Drawing.Size(134, 21);
            this.cmbMovementLogicDate.TabIndex = 1;
            this.cmbMovementLogicDate.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // dtpMovementDateFrom
            // 
            this.dtpMovementDateFrom.Location = new System.Drawing.Point(273, 67);
            this.dtpMovementDateFrom.Name = "dtpMovementDateFrom";
            this.dtpMovementDateFrom.Size = new System.Drawing.Size(192, 20);
            this.dtpMovementDateFrom.TabIndex = 2;
            // 
            // dtpMovementDateTo
            // 
            this.dtpMovementDateTo.Location = new System.Drawing.Point(476, 67);
            this.dtpMovementDateTo.Name = "dtpMovementDateTo";
            this.dtpMovementDateTo.Size = new System.Drawing.Size(187, 20);
            this.dtpMovementDateTo.TabIndex = 4;
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
            this.ckAllOrAny.Location = new System.Drawing.Point(252, 281);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.Size = new System.Drawing.Size(85, 19);
            this.ckAllOrAny.TabIndex = 8;
            this.ckAllOrAny.Text = "All or Any";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmbMovementLogicProduct
            // 
            this.cmbMovementLogicProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementLogicProduct.FormattingEnabled = true;
            this.cmbMovementLogicProduct.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbMovementLogicProduct.Location = new System.Drawing.Point(134, 94);
            this.cmbMovementLogicProduct.Name = "cmbMovementLogicProduct";
            this.cmbMovementLogicProduct.Size = new System.Drawing.Size(134, 21);
            this.cmbMovementLogicProduct.TabIndex = 9;
            this.cmbMovementLogicProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProductLogic_SelectedIndexChanged);
            // 
            // cmdSearchAndShowResult
            // 
            this.cmdSearchAndShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchAndShowResult.Location = new System.Drawing.Point(222, 306);
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
            // lblMovedQty
            // 
            this.lblMovedQty.AutoSize = true;
            this.lblMovedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovedQty.Location = new System.Drawing.Point(56, 127);
            this.lblMovedQty.Name = "lblMovedQty";
            this.lblMovedQty.Size = new System.Drawing.Size(73, 15);
            this.lblMovedQty.TabIndex = 19;
            this.lblMovedQty.Text = "Moved Qty";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(66, 202);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Category";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.AutoSize = true;
            this.lblDocStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocStatus.Location = new System.Drawing.Point(13, 228);
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
            this.cmbLogicStation.SelectedIndexChanged += new System.EventHandler(this.cmbLogicStation_SelectedIndexChanged);
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
            this.cmbLogicDocNo.SelectedIndexChanged += new System.EventHandler(this.cmbLogicDocNo_SelectedIndexChanged);
            // 
            // cmbLogicCategory
            // 
            this.cmbLogicCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicCategory.FormattingEnabled = true;
            this.cmbLogicCategory.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicCategory.Location = new System.Drawing.Point(134, 199);
            this.cmbLogicCategory.Name = "cmbLogicCategory";
            this.cmbLogicCategory.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicCategory.TabIndex = 1;
            this.cmbLogicCategory.SelectedIndexChanged += new System.EventHandler(this.cmbLogicCategory_SelectedIndexChanged);
            // 
            // cmbMovementLogicQty
            // 
            this.cmbMovementLogicQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementLogicQty.FormattingEnabled = true;
            this.cmbMovementLogicQty.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbMovementLogicQty.Location = new System.Drawing.Point(134, 124);
            this.cmbMovementLogicQty.Name = "cmbMovementLogicQty";
            this.cmbMovementLogicQty.Size = new System.Drawing.Size(134, 21);
            this.cmbMovementLogicQty.TabIndex = 1;
            this.cmbMovementLogicQty.SelectedIndexChanged += new System.EventHandler(this.cmbMovementLogicMovementQty_SelectedIndexChanged);
            // 
            // cmbLogicDocStatus
            // 
            this.cmbLogicDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDocStatus.FormattingEnabled = true;
            this.cmbLogicDocStatus.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicDocStatus.Location = new System.Drawing.Point(134, 225);
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
            this.cmbCategory.Location = new System.Drawing.Point(272, 199);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(138, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cmbDocstatus
            // 
            this.cmbDocstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocstatus.FormattingEnabled = true;
            this.cmbDocstatus.Location = new System.Drawing.Point(272, 225);
            this.cmbDocstatus.Name = "cmbDocstatus";
            this.cmbDocstatus.Size = new System.Drawing.Size(138, 21);
            this.cmbDocstatus.TabIndex = 1;
            // 
            // cmbLogicWarehouseFrom
            // 
            this.cmbLogicWarehouseFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicWarehouseFrom.FormattingEnabled = true;
            this.cmbLogicWarehouseFrom.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicWarehouseFrom.Location = new System.Drawing.Point(134, 149);
            this.cmbLogicWarehouseFrom.Name = "cmbLogicWarehouseFrom";
            this.cmbLogicWarehouseFrom.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicWarehouseFrom.TabIndex = 1;
            this.cmbLogicWarehouseFrom.SelectedIndexChanged += new System.EventHandler(this.cmbLogicWarehouseFrom_SelectedIndexChanged);
            // 
            // cmbWarehouseFrom
            // 
            this.cmbWarehouseFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseFrom.FormattingEnabled = true;
            this.cmbWarehouseFrom.Location = new System.Drawing.Point(272, 149);
            this.cmbWarehouseFrom.Name = "cmbWarehouseFrom";
            this.cmbWarehouseFrom.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouseFrom.TabIndex = 1;
            // 
            // lblWareHouseFrom
            // 
            this.lblWareHouseFrom.AutoSize = true;
            this.lblWareHouseFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouseFrom.Location = new System.Drawing.Point(43, 152);
            this.lblWareHouseFrom.Name = "lblWareHouseFrom";
            this.lblWareHouseFrom.Size = new System.Drawing.Size(86, 15);
            this.lblWareHouseFrom.TabIndex = 20;
            this.lblWareHouseFrom.Text = "Moved From";
            // 
            // ntbMovedQtyTo
            // 
            this.ntbMovedQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMovedQtyTo.AllowNegative = false;
            this.ntbMovedQtyTo.Amount = "";
            this.ntbMovedQtyTo.Location = new System.Drawing.Point(415, 122);
            this.ntbMovedQtyTo.Name = "ntbMovedQtyTo";
            this.ntbMovedQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMovedQtyTo.ShowThousandSeparetor = true;
            this.ntbMovedQtyTo.Size = new System.Drawing.Size(138, 23);
            this.ntbMovedQtyTo.StandardPrecision = 2;
            this.ntbMovedQtyTo.TabIndex = 25;
            // 
            // ntbMovedQtyFrom
            // 
            this.ntbMovedQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMovedQtyFrom.AllowNegative = false;
            this.ntbMovedQtyFrom.Amount = "";
            this.ntbMovedQtyFrom.Location = new System.Drawing.Point(271, 122);
            this.ntbMovedQtyFrom.Name = "ntbMovedQtyFrom";
            this.ntbMovedQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMovedQtyFrom.ShowThousandSeparetor = true;
            this.ntbMovedQtyFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbMovedQtyFrom.StandardPrecision = 2;
            this.ntbMovedQtyFrom.TabIndex = 25;
            // 
            // ddgMovedProduct
            // 
            this.ddgMovedProduct.AutoFilter = true;
            this.ddgMovedProduct.AutoSize = true;
            this.ddgMovedProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgMovedProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgMovedProduct.ClearButtonEnabled = true;
            this.ddgMovedProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgMovedProduct.FindButtonEnabled = true;
            this.ddgMovedProduct.HiddenColoumns = new int[0];
            this.ddgMovedProduct.Image = null;
            this.ddgMovedProduct.Location = new System.Drawing.Point(270, 90);
            this.ddgMovedProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgMovedProduct.Name = "ddgMovedProduct";
            this.ddgMovedProduct.NewButtonEnabled = true;
            this.ddgMovedProduct.RefreshButtonEnabled = true;
            this.ddgMovedProduct.SelectedColomnIdex = 0;
            this.ddgMovedProduct.SelectedItem = "";
            this.ddgMovedProduct.SelectedRowKey = null;
            this.ddgMovedProduct.ShowGridFunctions = false;
            this.ddgMovedProduct.Size = new System.Drawing.Size(359, 31);
            this.ddgMovedProduct.TabIndex = 6;
            this.ddgMovedProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Moved To";
            // 
            // cmbWarehouseTo
            // 
            this.cmbWarehouseTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseTo.FormattingEnabled = true;
            this.cmbWarehouseTo.Location = new System.Drawing.Point(272, 174);
            this.cmbWarehouseTo.Name = "cmbWarehouseTo";
            this.cmbWarehouseTo.Size = new System.Drawing.Size(138, 21);
            this.cmbWarehouseTo.TabIndex = 27;
            // 
            // cmbLogicWarehouseTo
            // 
            this.cmbLogicWarehouseTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicWarehouseTo.FormattingEnabled = true;
            this.cmbLogicWarehouseTo.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbLogicWarehouseTo.Location = new System.Drawing.Point(134, 174);
            this.cmbLogicWarehouseTo.Name = "cmbLogicWarehouseTo";
            this.cmbLogicWarehouseTo.Size = new System.Drawing.Size(134, 21);
            this.cmbLogicWarehouseTo.TabIndex = 26;
            this.cmbLogicWarehouseTo.SelectedIndexChanged += new System.EventHandler(this.cmbLogicWarehouseTo_SelectedIndexChanged);
            // 
            // frmSearchMovement
            // 
            this.ClientSize = new System.Drawing.Size(684, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbWarehouseTo);
            this.Controls.Add(this.cmbLogicWarehouseTo);
            this.Controls.Add(this.ntbMovedQtyTo);
            this.Controls.Add(this.ntbMovedQtyFrom);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblDocStatus);
            this.Controls.Add(this.lblWareHouseFrom);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblMovedQty);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.cmdSearchAndShowResult);
            this.Controls.Add(this.cmbMovementLogicProduct);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.cmdShowPrdImageList);
            this.Controls.Add(this.ddgMovedProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.dtpMovementDateTo);
            this.Controls.Add(this.dtpMovementDateFrom);
            this.Controls.Add(this.cmbMovementLogicQty);
            this.Controls.Add(this.cmbLogicDocNo);
            this.Controls.Add(this.cmbDocstatus);
            this.Controls.Add(this.cmbWarehouseFrom);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.cmbLogicStation);
            this.Controls.Add(this.cmbLogicDocStatus);
            this.Controls.Add(this.cmbLogicWarehouseFrom);
            this.Controls.Add(this.cmbLogicCategory);
            this.Controls.Add(this.cmbMovementLogicDate);
            this.Controls.Add(this.lblMovementDate);
            this.Name = "frmSearchMovement";
            this.Text = "Search For Movement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovementDate;
        private System.Windows.Forms.ComboBox cmbMovementLogicDate;
        private System.Windows.Forms.DateTimePicker dtpMovementDateFrom;
        private System.Windows.Forms.DateTimePicker dtpMovementDateTo;
        private System.Windows.Forms.Label lblProduct;
        private DropDownDataGrid ddgMovedProduct;
        private System.Windows.Forms.Button cmdShowPrdImageList;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.ComboBox cmbMovementLogicProduct;
        private System.Windows.Forms.Button cmdSearchAndShowResult;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblMovedQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.ComboBox cmbLogicStation;
        private System.Windows.Forms.ComboBox cmbLogicDocNo;
        private System.Windows.Forms.ComboBox cmbLogicCategory;
        private System.Windows.Forms.ComboBox cmbMovementLogicQty;
        private System.Windows.Forms.ComboBox cmbLogicDocStatus;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private ctlNumberTextBox ntbMovedQtyFrom;
        private ctlNumberTextBox ntbMovedQtyTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbDocstatus;
        private System.Windows.Forms.ComboBox cmbLogicWarehouseFrom;
        private System.Windows.Forms.ComboBox cmbWarehouseFrom;
        private System.Windows.Forms.Label lblWareHouseFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWarehouseTo;
        private System.Windows.Forms.ComboBox cmbLogicWarehouseTo;
    }
}