namespace POSDocumentPrinter
{
    partial class frmSearchOpenInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchOpenInvoice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbOpenAmountTo = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbOpenAmountFrom = new POSDocumentPrinter.ctlNumberTextBox();
            this.lblOpenAmount = new System.Windows.Forms.Label();
            this.cmbOpenAmtLogic = new System.Windows.Forms.ComboBox();
            this.ntbSalesAmountTo = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbSalesAmountFrom = new POSDocumentPrinter.ctlNumberTextBox();
            this.ddgCustomers = new POSDocumentPrinter.DropDownDataGrid();
            this.lblSalesAmount = new System.Windows.Forms.Label();
            this.cmbSalesAmtLogic = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomerLogic = new System.Windows.Forms.ComboBox();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbDateLogic = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntbOpenAmountTo);
            this.groupBox1.Controls.Add(this.ntbOpenAmountFrom);
            this.groupBox1.Controls.Add(this.lblOpenAmount);
            this.groupBox1.Controls.Add(this.cmbOpenAmtLogic);
            this.groupBox1.Controls.Add(this.ntbSalesAmountTo);
            this.groupBox1.Controls.Add(this.ntbSalesAmountFrom);
            this.groupBox1.Controls.Add(this.ddgCustomers);
            this.groupBox1.Controls.Add(this.lblSalesAmount);
            this.groupBox1.Controls.Add(this.cmbSalesAmtLogic);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.cmbCustomerLogic);
            this.groupBox1.Controls.Add(this.cmbSearchAndIncludeToPreviousResult);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.lblDocumentNumber);
            this.groupBox1.Controls.Add(this.ckAllOrAny);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.cmbDocumentNumberLogic);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.cmbDateLogic);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.txtDocumentNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 265);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterion";
            // 
            // ntbOpenAmountTo
            // 
            this.ntbOpenAmountTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbOpenAmountTo.AllowedLength = 0;
            this.ntbOpenAmountTo.AllowLeadingZeros = false;
            this.ntbOpenAmountTo.AllowNegative = false;
            this.ntbOpenAmountTo.Amount = "";
            this.ntbOpenAmountTo.defaultAmount = "0";
            this.ntbOpenAmountTo.Location = new System.Drawing.Point(387, 134);
            this.ntbOpenAmountTo.Name = "ntbOpenAmountTo";
            this.ntbOpenAmountTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbOpenAmountTo.ShowThousandSeparetor = true;
            this.ntbOpenAmountTo.Size = new System.Drawing.Size(138, 23);
            this.ntbOpenAmountTo.StandardPrecision = 2;
            this.ntbOpenAmountTo.TabIndex = 69;
            // 
            // ntbOpenAmountFrom
            // 
            this.ntbOpenAmountFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbOpenAmountFrom.AllowedLength = 0;
            this.ntbOpenAmountFrom.AllowLeadingZeros = false;
            this.ntbOpenAmountFrom.AllowNegative = false;
            this.ntbOpenAmountFrom.Amount = "";
            this.ntbOpenAmountFrom.defaultAmount = "0";
            this.ntbOpenAmountFrom.Location = new System.Drawing.Point(243, 134);
            this.ntbOpenAmountFrom.Name = "ntbOpenAmountFrom";
            this.ntbOpenAmountFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbOpenAmountFrom.ShowThousandSeparetor = true;
            this.ntbOpenAmountFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbOpenAmountFrom.StandardPrecision = 2;
            this.ntbOpenAmountFrom.TabIndex = 68;
            // 
            // lblOpenAmount
            // 
            this.lblOpenAmount.Location = new System.Drawing.Point(16, 136);
            this.lblOpenAmount.Name = "lblOpenAmount";
            this.lblOpenAmount.Size = new System.Drawing.Size(103, 19);
            this.lblOpenAmount.TabIndex = 66;
            this.lblOpenAmount.Text = "Unpaid Amount";
            this.lblOpenAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOpenAmtLogic
            // 
            this.cmbOpenAmtLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpenAmtLogic.DropDownWidth = 130;
            this.cmbOpenAmtLogic.FormattingEnabled = true;
            this.cmbOpenAmtLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbOpenAmtLogic.Location = new System.Drawing.Point(125, 135);
            this.cmbOpenAmtLogic.Name = "cmbOpenAmtLogic";
            this.cmbOpenAmtLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbOpenAmtLogic.TabIndex = 67;
            this.cmbOpenAmtLogic.SelectedIndexChanged += new System.EventHandler(this.cmbOpenAmtLogic_SelectedIndexChanged);
            // 
            // ntbSalesAmountTo
            // 
            this.ntbSalesAmountTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbSalesAmountTo.AllowedLength = 0;
            this.ntbSalesAmountTo.AllowLeadingZeros = false;
            this.ntbSalesAmountTo.AllowNegative = false;
            this.ntbSalesAmountTo.Amount = "";
            this.ntbSalesAmountTo.defaultAmount = "0";
            this.ntbSalesAmountTo.Location = new System.Drawing.Point(386, 106);
            this.ntbSalesAmountTo.Name = "ntbSalesAmountTo";
            this.ntbSalesAmountTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSalesAmountTo.ShowThousandSeparetor = true;
            this.ntbSalesAmountTo.Size = new System.Drawing.Size(138, 23);
            this.ntbSalesAmountTo.StandardPrecision = 2;
            this.ntbSalesAmountTo.TabIndex = 65;
            // 
            // ntbSalesAmountFrom
            // 
            this.ntbSalesAmountFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbSalesAmountFrom.AllowedLength = 0;
            this.ntbSalesAmountFrom.AllowLeadingZeros = false;
            this.ntbSalesAmountFrom.AllowNegative = false;
            this.ntbSalesAmountFrom.Amount = "";
            this.ntbSalesAmountFrom.defaultAmount = "0";
            this.ntbSalesAmountFrom.Location = new System.Drawing.Point(242, 106);
            this.ntbSalesAmountFrom.Name = "ntbSalesAmountFrom";
            this.ntbSalesAmountFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSalesAmountFrom.ShowThousandSeparetor = true;
            this.ntbSalesAmountFrom.Size = new System.Drawing.Size(138, 23);
            this.ntbSalesAmountFrom.StandardPrecision = 2;
            this.ntbSalesAmountFrom.TabIndex = 64;
            // 
            // ddgCustomers
            // 
            this.ddgCustomers.AutoFilter = true;
            this.ddgCustomers.AutoSize = true;
            this.ddgCustomers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgCustomers.ClearButtonEnabled = true;
            this.ddgCustomers.DataTablePrimaryKey = ((ushort)(0));
            this.ddgCustomers.FindButtonEnabled = true;
            this.ddgCustomers.HiddenColoumns = new int[0];
            this.ddgCustomers.Image = null;
            this.ddgCustomers.Location = new System.Drawing.Point(239, 46);
            this.ddgCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCustomers.Name = "ddgCustomers";
            this.ddgCustomers.NewButtonEnabled = true;
            this.ddgCustomers.RefreshButtonEnabled = true;
            this.ddgCustomers.SelectedColomnIdex = 0;
            this.ddgCustomers.SelectedItem = "";
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.ShowGridFunctions = false;
            this.ddgCustomers.Size = new System.Drawing.Size(377, 31);
            this.ddgCustomers.TabIndex = 62;
            this.ddgCustomers.SelectedItemClicked += new System.EventHandler(this.ddgCustomers_SelectedItemClicked);
            // 
            // lblSalesAmount
            // 
            this.lblSalesAmount.Location = new System.Drawing.Point(15, 108);
            this.lblSalesAmount.Name = "lblSalesAmount";
            this.lblSalesAmount.Size = new System.Drawing.Size(103, 19);
            this.lblSalesAmount.TabIndex = 60;
            this.lblSalesAmount.Text = "Sales Amount";
            this.lblSalesAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSalesAmtLogic
            // 
            this.cmbSalesAmtLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesAmtLogic.DropDownWidth = 130;
            this.cmbSalesAmtLogic.FormattingEnabled = true;
            this.cmbSalesAmtLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbSalesAmtLogic.Location = new System.Drawing.Point(124, 107);
            this.cmbSalesAmtLogic.Name = "cmbSalesAmtLogic";
            this.cmbSalesAmtLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbSalesAmtLogic.TabIndex = 61;
            this.cmbSalesAmtLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSalesAmtLogic_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(15, 53);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(103, 19);
            this.lblCustomer.TabIndex = 58;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCustomerLogic
            // 
            this.cmbCustomerLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerLogic.DropDownWidth = 130;
            this.cmbCustomerLogic.FormattingEnabled = true;
            this.cmbCustomerLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbCustomerLogic.Location = new System.Drawing.Point(124, 51);
            this.cmbCustomerLogic.Name = "cmbCustomerLogic";
            this.cmbCustomerLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbCustomerLogic.TabIndex = 59;
            this.cmbCustomerLogic.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerLogic_SelectedIndexChanged);
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(181, 196);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 57;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(201, 230);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(226, 28);
            this.cmdSearch.TabIndex = 55;
            this.cmdSearch.Text = "Show Result";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Location = new System.Drawing.Point(15, 25);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(103, 19);
            this.lblDocumentNumber.TabIndex = 41;
            this.lblDocumentNumber.Text = "Document Number";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(105, 166);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(400, 24);
            this.ckAllOrAny.TabIndex = 54;
            this.ckAllOrAny.Text = "Show Sales Records That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            this.ckAllOrAny.CheckedChanged += new System.EventHandler(this.ckAllOrAny_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(15, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(103, 19);
            this.lblDate.TabIndex = 42;
            this.lblDate.Text = "Sold Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDocumentNumberLogic
            // 
            this.cmbDocumentNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentNumberLogic.DropDownWidth = 130;
            this.cmbDocumentNumberLogic.FormattingEnabled = true;
            this.cmbDocumentNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to"});
            this.cmbDocumentNumberLogic.Location = new System.Drawing.Point(124, 25);
            this.cmbDocumentNumberLogic.Name = "cmbDocumentNumberLogic";
            this.cmbDocumentNumberLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDocumentNumberLogic.TabIndex = 45;
            this.cmbDocumentNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentNumberLogic_SelectedIndexChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(451, 79);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(206, 20);
            this.dtpDateTo.TabIndex = 51;
            this.dtpDateTo.Visible = false;
            // 
            // cmbDateLogic
            // 
            this.cmbDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateLogic.DropDownWidth = 130;
            this.cmbDateLogic.FormattingEnabled = true;
            this.cmbDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDateLogic.Location = new System.Drawing.Point(124, 79);
            this.cmbDateLogic.Name = "cmbDateLogic";
            this.cmbDateLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDateLogic.TabIndex = 46;
            this.cmbDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(242, 79);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(204, 20);
            this.dtpDateFrom.TabIndex = 50;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.AcceptsReturn = true;
            this.txtDocumentNumber.Location = new System.Drawing.Point(243, 25);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumber.TabIndex = 49;
            // 
            // frmSearchOpenInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 265);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSearchOpenInvoice";
            this.Text = "Search Payment";
            this.Load += new System.EventHandler(this.frmSearchOpenInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.ComboBox cmbDateLogic;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomerLogic;
        private System.Windows.Forms.Label lblSalesAmount;
        private System.Windows.Forms.ComboBox cmbSalesAmtLogic;
        private DropDownDataGrid ddgCustomers;
        private ctlNumberTextBox ntbSalesAmountTo;
        private ctlNumberTextBox ntbSalesAmountFrom;
        private ctlNumberTextBox ntbOpenAmountTo;
        private ctlNumberTextBox ntbOpenAmountFrom;
        private System.Windows.Forms.Label lblOpenAmount;
        private System.Windows.Forms.ComboBox cmbOpenAmtLogic;
    }
}