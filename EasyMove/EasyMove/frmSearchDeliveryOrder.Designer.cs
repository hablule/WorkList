namespace EasyMove
{
    partial class frmSearchDeliveryOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchDeliveryOrder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPendingQty = new System.Windows.Forms.Label();
            this.lblDeliveredQty = new System.Windows.Forms.Label();
            this.ntbPendingQtyTo = new EasyMove.ctlNumberTextBox();
            this.ntbDeliveredQtyTo = new EasyMove.ctlNumberTextBox();
            this.ntbPendingQtyFrom = new EasyMove.ctlNumberTextBox();
            this.ntbDeliveredQtyFrom = new EasyMove.ctlNumberTextBox();
            this.cmbPendingQtyLogic = new System.Windows.Forms.ComboBox();
            this.cmbDeliveredQtyLogic = new System.Windows.Forms.ComboBox();
            this.lblSalesOrder = new System.Windows.Forms.Label();
            this.lblBpartner = new System.Windows.Forms.Label();
            this.ddgSalesOrder = new EasyMove.DropDownDataGrid();
            this.cmbSalesOrderLogic = new System.Windows.Forms.ComboBox();
            this.ddgBPartner = new EasyMove.DropDownDataGrid();
            this.cmbBPartnerLogic = new System.Windows.Forms.ComboBox();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.txtDONumberTo = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblDONumber = new System.Windows.Forms.Label();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblDeliveredFrom = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblOrdered = new System.Windows.Forms.Label();
            this.ntbOrderedQtyTo = new EasyMove.ctlNumberTextBox();
            this.ntbOrderedQtyFrom = new EasyMove.ctlNumberTextBox();
            this.cmbDONumberLogic = new System.Windows.Forms.ComboBox();
            this.ddgProduct = new EasyMove.DropDownDataGrid();
            this.dtpOrderDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbOrderDateLogic = new System.Windows.Forms.ComboBox();
            this.dtpOrderDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbDeliveredFromLogic = new System.Windows.Forms.ComboBox();
            this.txtDONumberFrom = new System.Windows.Forms.TextBox();
            this.cmbProductLogic = new System.Windows.Forms.ComboBox();
            this.cmbOrderedQtyLogic = new System.Windows.Forms.ComboBox();
            this.cmbDeliveredFrom = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPendingQty);
            this.groupBox1.Controls.Add(this.lblDeliveredQty);
            this.groupBox1.Controls.Add(this.ntbPendingQtyTo);
            this.groupBox1.Controls.Add(this.ntbDeliveredQtyTo);
            this.groupBox1.Controls.Add(this.ntbPendingQtyFrom);
            this.groupBox1.Controls.Add(this.ntbDeliveredQtyFrom);
            this.groupBox1.Controls.Add(this.cmbPendingQtyLogic);
            this.groupBox1.Controls.Add(this.cmbDeliveredQtyLogic);
            this.groupBox1.Controls.Add(this.lblSalesOrder);
            this.groupBox1.Controls.Add(this.lblBpartner);
            this.groupBox1.Controls.Add(this.ddgSalesOrder);
            this.groupBox1.Controls.Add(this.cmbSalesOrderLogic);
            this.groupBox1.Controls.Add(this.ddgBPartner);
            this.groupBox1.Controls.Add(this.cmbBPartnerLogic);
            this.groupBox1.Controls.Add(this.cmbSearchAndIncludeToPreviousResult);
            this.groupBox1.Controls.Add(this.txtDONumberTo);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.lblDONumber);
            this.groupBox1.Controls.Add(this.ckAllOrAny);
            this.groupBox1.Controls.Add(this.lblOrderDate);
            this.groupBox1.Controls.Add(this.lblDeliveredFrom);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.lblOrdered);
            this.groupBox1.Controls.Add(this.ntbOrderedQtyTo);
            this.groupBox1.Controls.Add(this.ntbOrderedQtyFrom);
            this.groupBox1.Controls.Add(this.cmbDONumberLogic);
            this.groupBox1.Controls.Add(this.ddgProduct);
            this.groupBox1.Controls.Add(this.dtpOrderDateTo);
            this.groupBox1.Controls.Add(this.cmbOrderDateLogic);
            this.groupBox1.Controls.Add(this.dtpOrderDateFrom);
            this.groupBox1.Controls.Add(this.cmbDeliveredFromLogic);
            this.groupBox1.Controls.Add(this.txtDONumberFrom);
            this.groupBox1.Controls.Add(this.cmbProductLogic);
            this.groupBox1.Controls.Add(this.cmbOrderedQtyLogic);
            this.groupBox1.Controls.Add(this.cmbDeliveredFrom);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 401);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterion";
            // 
            // lblPendingQty
            // 
            this.lblPendingQty.Location = new System.Drawing.Point(9, 251);
            this.lblPendingQty.Name = "lblPendingQty";
            this.lblPendingQty.Size = new System.Drawing.Size(103, 19);
            this.lblPendingQty.TabIndex = 44;
            this.lblPendingQty.Text = "Pending Qty";
            this.lblPendingQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeliveredQty
            // 
            this.lblDeliveredQty.Location = new System.Drawing.Point(9, 224);
            this.lblDeliveredQty.Name = "lblDeliveredQty";
            this.lblDeliveredQty.Size = new System.Drawing.Size(103, 19);
            this.lblDeliveredQty.TabIndex = 44;
            this.lblDeliveredQty.Text = "Delivered Qty";
            this.lblDeliveredQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntbPendingQtyTo
            // 
            this.ntbPendingQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbPendingQtyTo.AllowedLength = 0;
            this.ntbPendingQtyTo.AllowLeadingZeros = false;
            this.ntbPendingQtyTo.AllowNegative = false;
            this.ntbPendingQtyTo.Amount = "";
            this.ntbPendingQtyTo.defaultAmount = "0";
            this.ntbPendingQtyTo.Location = new System.Drawing.Point(382, 249);
            this.ntbPendingQtyTo.Name = "ntbPendingQtyTo";
            this.ntbPendingQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPendingQtyTo.ShowThousandSeparetor = true;
            this.ntbPendingQtyTo.Size = new System.Drawing.Size(136, 23);
            this.ntbPendingQtyTo.StandardPrecision = 0;
            this.ntbPendingQtyTo.TabIndex = 47;
            this.ntbPendingQtyTo.Visible = false;
            // 
            // ntbDeliveredQtyTo
            // 
            this.ntbDeliveredQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbDeliveredQtyTo.AllowedLength = 0;
            this.ntbDeliveredQtyTo.AllowLeadingZeros = false;
            this.ntbDeliveredQtyTo.AllowNegative = false;
            this.ntbDeliveredQtyTo.Amount = "";
            this.ntbDeliveredQtyTo.defaultAmount = "0";
            this.ntbDeliveredQtyTo.Location = new System.Drawing.Point(382, 222);
            this.ntbDeliveredQtyTo.Name = "ntbDeliveredQtyTo";
            this.ntbDeliveredQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbDeliveredQtyTo.ShowThousandSeparetor = true;
            this.ntbDeliveredQtyTo.Size = new System.Drawing.Size(136, 23);
            this.ntbDeliveredQtyTo.StandardPrecision = 0;
            this.ntbDeliveredQtyTo.TabIndex = 47;
            this.ntbDeliveredQtyTo.Visible = false;
            // 
            // ntbPendingQtyFrom
            // 
            this.ntbPendingQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbPendingQtyFrom.AllowedLength = 0;
            this.ntbPendingQtyFrom.AllowLeadingZeros = false;
            this.ntbPendingQtyFrom.AllowNegative = false;
            this.ntbPendingQtyFrom.Amount = "";
            this.ntbPendingQtyFrom.defaultAmount = "0";
            this.ntbPendingQtyFrom.Location = new System.Drawing.Point(234, 249);
            this.ntbPendingQtyFrom.Name = "ntbPendingQtyFrom";
            this.ntbPendingQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPendingQtyFrom.ShowThousandSeparetor = true;
            this.ntbPendingQtyFrom.Size = new System.Drawing.Size(136, 23);
            this.ntbPendingQtyFrom.StandardPrecision = 0;
            this.ntbPendingQtyFrom.TabIndex = 46;
            // 
            // ntbDeliveredQtyFrom
            // 
            this.ntbDeliveredQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbDeliveredQtyFrom.AllowedLength = 0;
            this.ntbDeliveredQtyFrom.AllowLeadingZeros = false;
            this.ntbDeliveredQtyFrom.AllowNegative = false;
            this.ntbDeliveredQtyFrom.Amount = "";
            this.ntbDeliveredQtyFrom.defaultAmount = "0";
            this.ntbDeliveredQtyFrom.Location = new System.Drawing.Point(234, 222);
            this.ntbDeliveredQtyFrom.Name = "ntbDeliveredQtyFrom";
            this.ntbDeliveredQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbDeliveredQtyFrom.ShowThousandSeparetor = true;
            this.ntbDeliveredQtyFrom.Size = new System.Drawing.Size(136, 23);
            this.ntbDeliveredQtyFrom.StandardPrecision = 0;
            this.ntbDeliveredQtyFrom.TabIndex = 46;
            // 
            // cmbPendingQtyLogic
            // 
            this.cmbPendingQtyLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPendingQtyLogic.DropDownWidth = 130;
            this.cmbPendingQtyLogic.FormattingEnabled = true;
            this.cmbPendingQtyLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbPendingQtyLogic.Location = new System.Drawing.Point(118, 250);
            this.cmbPendingQtyLogic.Name = "cmbPendingQtyLogic";
            this.cmbPendingQtyLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbPendingQtyLogic.TabIndex = 45;
            this.cmbPendingQtyLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPendingQtyLogic_SelectedIndexChanged);
            // 
            // cmbDeliveredQtyLogic
            // 
            this.cmbDeliveredQtyLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveredQtyLogic.DropDownWidth = 130;
            this.cmbDeliveredQtyLogic.FormattingEnabled = true;
            this.cmbDeliveredQtyLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDeliveredQtyLogic.Location = new System.Drawing.Point(118, 223);
            this.cmbDeliveredQtyLogic.Name = "cmbDeliveredQtyLogic";
            this.cmbDeliveredQtyLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDeliveredQtyLogic.TabIndex = 45;
            this.cmbDeliveredQtyLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveredQtyLogic_SelectedIndexChanged);
            // 
            // lblSalesOrder
            // 
            this.lblSalesOrder.Location = new System.Drawing.Point(8, 58);
            this.lblSalesOrder.Name = "lblSalesOrder";
            this.lblSalesOrder.Size = new System.Drawing.Size(103, 19);
            this.lblSalesOrder.TabIndex = 41;
            this.lblSalesOrder.Text = "Sales Order";
            this.lblSalesOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBpartner
            // 
            this.lblBpartner.Location = new System.Drawing.Point(7, 116);
            this.lblBpartner.Name = "lblBpartner";
            this.lblBpartner.Size = new System.Drawing.Size(103, 19);
            this.lblBpartner.TabIndex = 41;
            this.lblBpartner.Text = "Customer";
            this.lblBpartner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddgSalesOrder
            // 
            this.ddgSalesOrder.AutoFilter = true;
            this.ddgSalesOrder.AutoSize = true;
            this.ddgSalesOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgSalesOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgSalesOrder.ClearButtonEnabled = true;
            this.ddgSalesOrder.DataTablePrimaryKey = ((ushort)(0));
            this.ddgSalesOrder.FindButtonEnabled = true;
            this.ddgSalesOrder.HiddenColoumns = new int[0];
            this.ddgSalesOrder.Image = null;
            this.ddgSalesOrder.Location = new System.Drawing.Point(230, 52);
            this.ddgSalesOrder.Margin = new System.Windows.Forms.Padding(0);
            this.ddgSalesOrder.Name = "ddgSalesOrder";
            this.ddgSalesOrder.NewButtonEnabled = true;
            this.ddgSalesOrder.RefreshButtonEnabled = true;
            this.ddgSalesOrder.SelectedColomnIdex = 0;
            this.ddgSalesOrder.SelectedItem = "";
            this.ddgSalesOrder.SelectedRowKey = null;
            this.ddgSalesOrder.ShowGridFunctions = false;
            this.ddgSalesOrder.Size = new System.Drawing.Size(383, 31);
            this.ddgSalesOrder.TabIndex = 43;
            this.ddgSalesOrder.SelectedItemClicked += new System.EventHandler(this.ddgSalesOrder_SelectedItemClicked);
            // 
            // cmbSalesOrderLogic
            // 
            this.cmbSalesOrderLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesOrderLogic.DropDownWidth = 130;
            this.cmbSalesOrderLogic.FormattingEnabled = true;
            this.cmbSalesOrderLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbSalesOrderLogic.Location = new System.Drawing.Point(117, 56);
            this.cmbSalesOrderLogic.Name = "cmbSalesOrderLogic";
            this.cmbSalesOrderLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbSalesOrderLogic.TabIndex = 42;
            this.cmbSalesOrderLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSalesOrderLogic_SelectedIndexChanged);
            // 
            // ddgBPartner
            // 
            this.ddgBPartner.AutoFilter = true;
            this.ddgBPartner.AutoSize = true;
            this.ddgBPartner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBPartner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBPartner.ClearButtonEnabled = true;
            this.ddgBPartner.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBPartner.FindButtonEnabled = true;
            this.ddgBPartner.HiddenColoumns = new int[0];
            this.ddgBPartner.Image = null;
            this.ddgBPartner.Location = new System.Drawing.Point(229, 110);
            this.ddgBPartner.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBPartner.Name = "ddgBPartner";
            this.ddgBPartner.NewButtonEnabled = true;
            this.ddgBPartner.RefreshButtonEnabled = true;
            this.ddgBPartner.SelectedColomnIdex = 0;
            this.ddgBPartner.SelectedItem = "";
            this.ddgBPartner.SelectedRowKey = null;
            this.ddgBPartner.ShowGridFunctions = false;
            this.ddgBPartner.Size = new System.Drawing.Size(383, 31);
            this.ddgBPartner.TabIndex = 43;
            this.ddgBPartner.SelectedItemClicked += new System.EventHandler(this.ddgBPartner_SelectedItemClicked);
            // 
            // cmbBPartnerLogic
            // 
            this.cmbBPartnerLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBPartnerLogic.DropDownWidth = 130;
            this.cmbBPartnerLogic.FormattingEnabled = true;
            this.cmbBPartnerLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbBPartnerLogic.Location = new System.Drawing.Point(116, 114);
            this.cmbBPartnerLogic.Name = "cmbBPartnerLogic";
            this.cmbBPartnerLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbBPartnerLogic.TabIndex = 42;
            this.cmbBPartnerLogic.SelectedIndexChanged += new System.EventHandler(this.cmbBPartnerLogic_SelectedIndexChanged);
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(174, 318);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 40;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // txtDONumberTo
            // 
            this.txtDONumberTo.Location = new System.Drawing.Point(399, 29);
            this.txtDONumberTo.Name = "txtDONumberTo";
            this.txtDONumberTo.Size = new System.Drawing.Size(145, 20);
            this.txtDONumberTo.TabIndex = 37;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(199, 352);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(226, 28);
            this.cmdSearch.TabIndex = 36;
            this.cmdSearch.Text = "Show Result";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblDONumber
            // 
            this.lblDONumber.Location = new System.Drawing.Point(8, 29);
            this.lblDONumber.Name = "lblDONumber";
            this.lblDONumber.Size = new System.Drawing.Size(103, 19);
            this.lblDONumber.TabIndex = 1;
            this.lblDONumber.Text = "Document Number";
            this.lblDONumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(117, 288);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(400, 24);
            this.ckAllOrAny.TabIndex = 35;
            this.ckAllOrAny.Text = "Show Movement Records That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            this.ckAllOrAny.CheckedChanged += new System.EventHandler(this.ckAllOrAny_CheckedChanged);
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Location = new System.Drawing.Point(8, 87);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(103, 19);
            this.lblOrderDate.TabIndex = 3;
            this.lblOrderDate.Text = "Order Date";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeliveredFrom
            // 
            this.lblDeliveredFrom.Location = new System.Drawing.Point(8, 143);
            this.lblDeliveredFrom.Name = "lblDeliveredFrom";
            this.lblDeliveredFrom.Size = new System.Drawing.Size(103, 19);
            this.lblDeliveredFrom.TabIndex = 4;
            this.lblDeliveredFrom.Text = "Delivered From";
            this.lblDeliveredFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(8, 170);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(103, 19);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrdered
            // 
            this.lblOrdered.Location = new System.Drawing.Point(8, 197);
            this.lblOrdered.Name = "lblOrdered";
            this.lblOrdered.Size = new System.Drawing.Size(103, 19);
            this.lblOrdered.TabIndex = 7;
            this.lblOrdered.Text = "Ordered Qty";
            this.lblOrdered.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntbOrderedQtyTo
            // 
            this.ntbOrderedQtyTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbOrderedQtyTo.AllowedLength = 0;
            this.ntbOrderedQtyTo.AllowLeadingZeros = false;
            this.ntbOrderedQtyTo.AllowNegative = false;
            this.ntbOrderedQtyTo.Amount = "";
            this.ntbOrderedQtyTo.defaultAmount = "0";
            this.ntbOrderedQtyTo.Location = new System.Drawing.Point(381, 195);
            this.ntbOrderedQtyTo.Name = "ntbOrderedQtyTo";
            this.ntbOrderedQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbOrderedQtyTo.ShowThousandSeparetor = true;
            this.ntbOrderedQtyTo.Size = new System.Drawing.Size(136, 23);
            this.ntbOrderedQtyTo.StandardPrecision = 0;
            this.ntbOrderedQtyTo.TabIndex = 29;
            this.ntbOrderedQtyTo.Visible = false;
            // 
            // ntbOrderedQtyFrom
            // 
            this.ntbOrderedQtyFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbOrderedQtyFrom.AllowedLength = 0;
            this.ntbOrderedQtyFrom.AllowLeadingZeros = false;
            this.ntbOrderedQtyFrom.AllowNegative = false;
            this.ntbOrderedQtyFrom.Amount = "";
            this.ntbOrderedQtyFrom.defaultAmount = "0";
            this.ntbOrderedQtyFrom.Location = new System.Drawing.Point(233, 195);
            this.ntbOrderedQtyFrom.Name = "ntbOrderedQtyFrom";
            this.ntbOrderedQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbOrderedQtyFrom.ShowThousandSeparetor = true;
            this.ntbOrderedQtyFrom.Size = new System.Drawing.Size(136, 23);
            this.ntbOrderedQtyFrom.StandardPrecision = 0;
            this.ntbOrderedQtyFrom.TabIndex = 28;
            // 
            // cmbDONumberLogic
            // 
            this.cmbDONumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDONumberLogic.DropDownWidth = 130;
            this.cmbDONumberLogic.FormattingEnabled = true;
            this.cmbDONumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDONumberLogic.Location = new System.Drawing.Point(117, 29);
            this.cmbDONumberLogic.Name = "cmbDONumberLogic";
            this.cmbDONumberLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDONumberLogic.TabIndex = 11;
            this.cmbDONumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDONumberLogic_SelectedIndexChanged);
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
            this.ddgProduct.Location = new System.Drawing.Point(230, 164);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(383, 31);
            this.ddgProduct.TabIndex = 27;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            // 
            // dtpOrderDateTo
            // 
            this.dtpOrderDateTo.Location = new System.Drawing.Point(437, 85);
            this.dtpOrderDateTo.Name = "dtpOrderDateTo";
            this.dtpOrderDateTo.Size = new System.Drawing.Size(198, 20);
            this.dtpOrderDateTo.TabIndex = 26;
            this.dtpOrderDateTo.Visible = false;
            // 
            // cmbOrderDateLogic
            // 
            this.cmbOrderDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderDateLogic.DropDownWidth = 130;
            this.cmbOrderDateLogic.FormattingEnabled = true;
            this.cmbOrderDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbOrderDateLogic.Location = new System.Drawing.Point(117, 85);
            this.cmbOrderDateLogic.Name = "cmbOrderDateLogic";
            this.cmbOrderDateLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbOrderDateLogic.TabIndex = 13;
            this.cmbOrderDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbOrderDateLogic_SelectedIndexChanged);
            // 
            // dtpOrderDateFrom
            // 
            this.dtpOrderDateFrom.Location = new System.Drawing.Point(235, 85);
            this.dtpOrderDateFrom.Name = "dtpOrderDateFrom";
            this.dtpOrderDateFrom.Size = new System.Drawing.Size(196, 20);
            this.dtpOrderDateFrom.TabIndex = 25;
            // 
            // cmbDeliveredFromLogic
            // 
            this.cmbDeliveredFromLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveredFromLogic.DropDownWidth = 130;
            this.cmbDeliveredFromLogic.FormattingEnabled = true;
            this.cmbDeliveredFromLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbDeliveredFromLogic.Location = new System.Drawing.Point(117, 141);
            this.cmbDeliveredFromLogic.Name = "cmbDeliveredFromLogic";
            this.cmbDeliveredFromLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDeliveredFromLogic.TabIndex = 14;
            this.cmbDeliveredFromLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveredFromLogic_SelectedIndexChanged);
            // 
            // txtDONumberFrom
            // 
            this.txtDONumberFrom.Location = new System.Drawing.Point(236, 29);
            this.txtDONumberFrom.Name = "txtDONumberFrom";
            this.txtDONumberFrom.Size = new System.Drawing.Size(145, 20);
            this.txtDONumberFrom.TabIndex = 23;
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
            this.cmbProductLogic.Location = new System.Drawing.Point(117, 168);
            this.cmbProductLogic.Name = "cmbProductLogic";
            this.cmbProductLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbProductLogic.TabIndex = 16;
            this.cmbProductLogic.SelectedIndexChanged += new System.EventHandler(this.cmbProductLogic_SelectedIndexChanged);
            // 
            // cmbOrderedQtyLogic
            // 
            this.cmbOrderedQtyLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderedQtyLogic.DropDownWidth = 130;
            this.cmbOrderedQtyLogic.FormattingEnabled = true;
            this.cmbOrderedQtyLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbOrderedQtyLogic.Location = new System.Drawing.Point(117, 196);
            this.cmbOrderedQtyLogic.Name = "cmbOrderedQtyLogic";
            this.cmbOrderedQtyLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbOrderedQtyLogic.TabIndex = 17;
            this.cmbOrderedQtyLogic.SelectedIndexChanged += new System.EventHandler(this.cmbOrderedQtyLogic_SelectedIndexChanged);
            // 
            // cmbDeliveredFrom
            // 
            this.cmbDeliveredFrom.FormattingEnabled = true;
            this.cmbDeliveredFrom.Location = new System.Drawing.Point(235, 141);
            this.cmbDeliveredFrom.Name = "cmbDeliveredFrom";
            this.cmbDeliveredFrom.Size = new System.Drawing.Size(213, 21);
            this.cmbDeliveredFrom.TabIndex = 20;
            // 
            // frmSearchDeliveryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 401);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchDeliveryOrder";
            this.Text = "frmSearchDeliveryOrder";
            this.Load += new System.EventHandler(this.frmSearchDeliveryOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPendingQty;
        private System.Windows.Forms.Label lblDeliveredQty;
        private ctlNumberTextBox ntbPendingQtyTo;
        private ctlNumberTextBox ntbDeliveredQtyTo;
        private ctlNumberTextBox ntbPendingQtyFrom;
        private ctlNumberTextBox ntbDeliveredQtyFrom;
        private System.Windows.Forms.ComboBox cmbPendingQtyLogic;
        private System.Windows.Forms.ComboBox cmbDeliveredQtyLogic;
        private System.Windows.Forms.Label lblBpartner;
        private DropDownDataGrid ddgBPartner;
        private System.Windows.Forms.ComboBox cmbBPartnerLogic;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
        private System.Windows.Forms.TextBox txtDONumberTo;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblDONumber;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblDeliveredFrom;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblOrdered;
        private ctlNumberTextBox ntbOrderedQtyTo;
        private ctlNumberTextBox ntbOrderedQtyFrom;
        private System.Windows.Forms.ComboBox cmbDONumberLogic;
        private DropDownDataGrid ddgProduct;
        private System.Windows.Forms.DateTimePicker dtpOrderDateTo;
        private System.Windows.Forms.ComboBox cmbOrderDateLogic;
        private System.Windows.Forms.DateTimePicker dtpOrderDateFrom;
        private System.Windows.Forms.ComboBox cmbDeliveredFromLogic;
        private System.Windows.Forms.TextBox txtDONumberFrom;
        private System.Windows.Forms.ComboBox cmbProductLogic;
        private System.Windows.Forms.ComboBox cmbOrderedQtyLogic;
        private System.Windows.Forms.ComboBox cmbDeliveredFrom;
        private System.Windows.Forms.Label lblSalesOrder;
        private DropDownDataGrid ddgSalesOrder;
        private System.Windows.Forms.ComboBox cmbSalesOrderLogic;
    }
}