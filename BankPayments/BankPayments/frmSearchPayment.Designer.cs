namespace BankPayments
{
    partial class frmSearchPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPayment));
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbPayeeLogic = new System.Windows.Forms.ComboBox();
            this.cmbCheckNumberLogic = new System.Windows.Forms.ComboBox();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.ntbAmountPaidTo = new customControls.ctlNumberTextBox();
            this.cmbAmountPaidLogic = new System.Windows.Forms.ComboBox();
            this.cmbBankAcctLogic = new System.Windows.Forms.ComboBox();
            this.cmbDateLogic = new System.Windows.Forms.ComboBox();
            this.txtCheckNumber = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.ntbAmountPaidFrom = new customControls.ctlNumberTextBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPayee = new System.Windows.Forms.Label();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.ddgBankAcct = new customControls.DropDownDataGrid();
            this.lblAmount = new System.Windows.Forms.Label();
            this.ddgPayee = new customControls.DropDownDataGrid();
            this.ckAllocated = new System.Windows.Forms.CheckBox();
            this.ckIssued = new System.Windows.Forms.CheckBox();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(12, 22);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(73, 13);
            this.lblDocumentNo.TabIndex = 3;
            this.lblDocumentNo.Text = "Document No";
            this.lblDocumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckAllOrAny);
            this.groupBox1.Controls.Add(this.cmbSearchAndIncludeToPreviousResult);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.cmbPayeeLogic);
            this.groupBox1.Controls.Add(this.cmbCheckNumberLogic);
            this.groupBox1.Controls.Add(this.cmbDocumentNumberLogic);
            this.groupBox1.Controls.Add(this.ntbAmountPaidTo);
            this.groupBox1.Controls.Add(this.cmbAmountPaidLogic);
            this.groupBox1.Controls.Add(this.cmbBankAcctLogic);
            this.groupBox1.Controls.Add(this.cmbDateLogic);
            this.groupBox1.Controls.Add(this.lblDocumentNo);
            this.groupBox1.Controls.Add(this.txtCheckNumber);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.ntbAmountPaidFrom);
            this.groupBox1.Controls.Add(this.lblBankAccount);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.lblPayee);
            this.groupBox1.Controls.Add(this.txtDocumentNumber);
            this.groupBox1.Controls.Add(this.lblCheckNo);
            this.groupBox1.Controls.Add(this.ddgBankAcct);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.ddgPayee);
            this.groupBox1.Controls.Add(this.ckAllocated);
            this.groupBox1.Controls.Add(this.ckIssued);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 313);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(140, 242);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 59;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(174, 276);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(226, 28);
            this.cmdSearch.TabIndex = 58;
            this.cmdSearch.Text = "Show Result";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(409, 42);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(189, 20);
            this.dtpDateTo.TabIndex = 27;
            // 
            // cmbPayeeLogic
            // 
            this.cmbPayeeLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeLogic.FormattingEnabled = true;
            this.cmbPayeeLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPayeeLogic.Location = new System.Drawing.Point(90, 65);
            this.cmbPayeeLogic.Name = "cmbPayeeLogic";
            this.cmbPayeeLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbPayeeLogic.TabIndex = 26;
            this.cmbPayeeLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPayeeLogic_SelectedIndexChanged);
            // 
            // cmbCheckNumberLogic
            // 
            this.cmbCheckNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckNumberLogic.FormattingEnabled = true;
            this.cmbCheckNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to"});
            this.cmbCheckNumberLogic.Location = new System.Drawing.Point(90, 142);
            this.cmbCheckNumberLogic.Name = "cmbCheckNumberLogic";
            this.cmbCheckNumberLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbCheckNumberLogic.TabIndex = 25;
            this.cmbCheckNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbCheckNumberLogic_SelectedIndexChanged);
            // 
            // cmbDocumentNumberLogic
            // 
            this.cmbDocumentNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentNumberLogic.FormattingEnabled = true;
            this.cmbDocumentNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to"});
            this.cmbDocumentNumberLogic.Location = new System.Drawing.Point(90, 18);
            this.cmbDocumentNumberLogic.Name = "cmbDocumentNumberLogic";
            this.cmbDocumentNumberLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbDocumentNumberLogic.TabIndex = 24;
            this.cmbDocumentNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentNumberLogic_SelectedIndexChanged);
            // 
            // ntbAmountPaidTo
            // 
            this.ntbAmountPaidTo.Amount = "";
            this.ntbAmountPaidTo.Location = new System.Drawing.Point(364, 90);
            this.ntbAmountPaidTo.Name = "ntbAmountPaidTo";
            this.ntbAmountPaidTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmountPaidTo.Size = new System.Drawing.Size(143, 23);
            this.ntbAmountPaidTo.StandardPrecision = 2;
            this.ntbAmountPaidTo.TabIndex = 23;
            // 
            // cmbAmountPaidLogic
            // 
            this.cmbAmountPaidLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmountPaidLogic.FormattingEnabled = true;
            this.cmbAmountPaidLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbAmountPaidLogic.Location = new System.Drawing.Point(91, 91);
            this.cmbAmountPaidLogic.Name = "cmbAmountPaidLogic";
            this.cmbAmountPaidLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbAmountPaidLogic.TabIndex = 22;
            this.cmbAmountPaidLogic.SelectedIndexChanged += new System.EventHandler(this.cmbAmountPaidLogic_SelectedIndexChanged);
            // 
            // cmbBankAcctLogic
            // 
            this.cmbBankAcctLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAcctLogic.FormattingEnabled = true;
            this.cmbBankAcctLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbBankAcctLogic.Location = new System.Drawing.Point(90, 115);
            this.cmbBankAcctLogic.Name = "cmbBankAcctLogic";
            this.cmbBankAcctLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbBankAcctLogic.TabIndex = 21;
            this.cmbBankAcctLogic.SelectedIndexChanged += new System.EventHandler(this.cmbBankAcctLogic_SelectedIndexChanged);
            // 
            // cmbDateLogic
            // 
            this.cmbDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbDateLogic.Location = new System.Drawing.Point(90, 42);
            this.cmbDateLogic.Name = "cmbDateLogic";
            this.cmbDateLogic.Size = new System.Drawing.Size(123, 21);
            this.cmbDateLogic.TabIndex = 20;
            this.cmbDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // txtCheckNumber
            // 
            this.txtCheckNumber.Location = new System.Drawing.Point(216, 142);
            this.txtCheckNumber.Name = "txtCheckNumber";
            this.txtCheckNumber.Size = new System.Drawing.Size(164, 20);
            this.txtCheckNumber.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(55, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // ntbAmountPaidFrom
            // 
            this.ntbAmountPaidFrom.Amount = "";
            this.ntbAmountPaidFrom.Location = new System.Drawing.Point(215, 90);
            this.ntbAmountPaidFrom.Name = "ntbAmountPaidFrom";
            this.ntbAmountPaidFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmountPaidFrom.Size = new System.Drawing.Size(143, 23);
            this.ntbAmountPaidFrom.StandardPrecision = 2;
            this.ntbAmountPaidFrom.TabIndex = 2;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(10, 119);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(75, 13);
            this.lblBankAccount.TabIndex = 5;
            this.lblBankAccount.Text = "Bank Account";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(217, 42);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(189, 20);
            this.dtpDateFrom.TabIndex = 18;
            // 
            // lblPayee
            // 
            this.lblPayee.AutoSize = true;
            this.lblPayee.Location = new System.Drawing.Point(48, 74);
            this.lblPayee.Name = "lblPayee";
            this.lblPayee.Size = new System.Drawing.Size(37, 13);
            this.lblPayee.TabIndex = 6;
            this.lblPayee.Text = "Payee";
            this.lblPayee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.Location = new System.Drawing.Point(217, 19);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(141, 20);
            this.txtDocumentNumber.TabIndex = 17;
            this.txtDocumentNumber.TabStop = false;
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.Location = new System.Drawing.Point(30, 146);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(55, 13);
            this.lblCheckNo.TabIndex = 7;
            this.lblCheckNo.Text = "Check No";
            this.lblCheckNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddgBankAcct
            // 
            this.ddgBankAcct.AutoFilter = true;
            this.ddgBankAcct.AutoSize = true;
            this.ddgBankAcct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBankAcct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBankAcct.ClearButtonEnabled = true;
            this.ddgBankAcct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBankAcct.FindButtonEnabled = true;
            this.ddgBankAcct.HiddenColoumns = new int[0];
            this.ddgBankAcct.Image = null;
            this.ddgBankAcct.Location = new System.Drawing.Point(212, 111);
            this.ddgBankAcct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBankAcct.Name = "ddgBankAcct";
            this.ddgBankAcct.NewButtonEnabled = true;
            this.ddgBankAcct.RefreshButtonEnabled = true;
            this.ddgBankAcct.SelectedColomnIdex = 0;
            this.ddgBankAcct.SelectedItem = "";
            this.ddgBankAcct.SelectedRowKey = null;
            this.ddgBankAcct.ShowGridFunctions = false;
            this.ddgBankAcct.Size = new System.Drawing.Size(294, 31);
            this.ddgBankAcct.TabIndex = 3;
            this.ddgBankAcct.SelectedItemClicked += new System.EventHandler(this.ddgBankAccount_SelectedItemClicked);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(42, 100);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddgPayee
            // 
            this.ddgPayee.AutoFilter = true;
            this.ddgPayee.AutoSize = true;
            this.ddgPayee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPayee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPayee.ClearButtonEnabled = true;
            this.ddgPayee.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPayee.FindButtonEnabled = true;
            this.ddgPayee.HiddenColoumns = new int[0];
            this.ddgPayee.Image = null;
            this.ddgPayee.Location = new System.Drawing.Point(213, 61);
            this.ddgPayee.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPayee.Name = "ddgPayee";
            this.ddgPayee.NewButtonEnabled = true;
            this.ddgPayee.RefreshButtonEnabled = true;
            this.ddgPayee.SelectedColomnIdex = 0;
            this.ddgPayee.SelectedItem = "";
            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.ShowGridFunctions = false;
            this.ddgPayee.Size = new System.Drawing.Size(366, 31);
            this.ddgPayee.TabIndex = 1;
            this.ddgPayee.SelectedItemClicked += new System.EventHandler(this.ddgPayee_SelectedItemClicked);
            // 
            // ckAllocated
            // 
            this.ckAllocated.AutoSize = true;
            this.ckAllocated.Checked = true;
            this.ckAllocated.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckAllocated.Location = new System.Drawing.Point(101, 179);
            this.ckAllocated.Name = "ckAllocated";
            this.ckAllocated.Size = new System.Drawing.Size(70, 17);
            this.ckAllocated.TabIndex = 10;
            this.ckAllocated.TabStop = false;
            this.ckAllocated.Text = "Allocated";
            this.ckAllocated.ThreeState = true;
            this.ckAllocated.UseVisualStyleBackColor = true;
            // 
            // ckIssued
            // 
            this.ckIssued.AutoSize = true;
            this.ckIssued.Checked = true;
            this.ckIssued.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIssued.Location = new System.Drawing.Point(205, 179);
            this.ckIssued.Name = "ckIssued";
            this.ckIssued.Size = new System.Drawing.Size(57, 17);
            this.ckIssued.TabIndex = 11;
            this.ckIssued.TabStop = false;
            this.ckIssued.Text = "Issued";
            this.ckIssued.ThreeState = true;
            this.ckIssued.UseVisualStyleBackColor = true;
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(90, 212);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(400, 24);
            this.ckAllOrAny.TabIndex = 60;
            this.ckAllOrAny.Text = "Show Movement Records That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            this.ckAllOrAny.CheckedChanged += new System.EventHandler(this.ckAllOrAny_CheckedChanged);
            // 
            // frmSearchPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 313);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSearchPayment";
            this.Text = "Search Payment";
            this.Load += new System.EventHandler(this.frmSearchPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCheckNumber;
        private System.Windows.Forms.Label lblDate;
        private customControls.ctlNumberTextBox ntbAmountPaidFrom;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.Label lblCheckNo;
        private customControls.DropDownDataGrid ddgBankAcct;
        private System.Windows.Forms.Label lblAmount;
        private customControls.DropDownDataGrid ddgPayee;
        private System.Windows.Forms.CheckBox ckAllocated;
        private System.Windows.Forms.CheckBox ckIssued;
        private System.Windows.Forms.ComboBox cmbBankAcctLogic;
        private System.Windows.Forms.ComboBox cmbDateLogic;
        private customControls.ctlNumberTextBox ntbAmountPaidTo;
        private System.Windows.Forms.ComboBox cmbAmountPaidLogic;
        private System.Windows.Forms.ComboBox cmbCheckNumberLogic;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.ComboBox cmbPayeeLogic;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.CheckBox ckAllOrAny;

    }
}