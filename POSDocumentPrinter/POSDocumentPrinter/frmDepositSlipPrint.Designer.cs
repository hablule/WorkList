namespace POSDocumentPrinter
{
    partial class frmDepositSlipPrint
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
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepositSlipPrint));
            this.lblDepositDate = new System.Windows.Forms.Label();
            this.dtpDepositDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cmdPrintDepositSlip = new System.Windows.Forms.Button();
            this.dtpDepositDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbDepositDateLogic = new System.Windows.Forms.ComboBox();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmbSourceTypeLogic = new System.Windows.Forms.ComboBox();
            this.cbcbcmbSourceType = new PresentationControls.CheckBoxComboBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.cmbBankAccountLogic = new System.Windows.Forms.ComboBox();
            this.lblSourceDate = new System.Windows.Forms.Label();
            this.dtpSourceDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbSourceDateLogic = new System.Windows.Forms.ComboBox();
            this.dtpSourceDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.ddgBankAccount = new POSDocumentPrinter.DropDownDataGrid();
            this.SuspendLayout();
            // 
            // lblDepositDate
            // 
            this.lblDepositDate.Location = new System.Drawing.Point(26, 36);
            this.lblDepositDate.Name = "lblDepositDate";
            this.lblDepositDate.Size = new System.Drawing.Size(85, 19);
            this.lblDepositDate.TabIndex = 52;
            this.lblDepositDate.Text = "Deposit Date";
            this.lblDepositDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDepositDateFrom
            // 
            this.dtpDepositDateFrom.Location = new System.Drawing.Point(235, 35);
            this.dtpDepositDateFrom.Name = "dtpDepositDateFrom";
            this.dtpDepositDateFrom.Size = new System.Drawing.Size(198, 20);
            this.dtpDepositDateFrom.TabIndex = 54;
            // 
            // cmdPrintDepositSlip
            // 
            this.cmdPrintDepositSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintDepositSlip.Location = new System.Drawing.Point(112, 223);
            this.cmdPrintDepositSlip.Name = "cmdPrintDepositSlip";
            this.cmdPrintDepositSlip.Size = new System.Drawing.Size(458, 50);
            this.cmdPrintDepositSlip.TabIndex = 56;
            this.cmdPrintDepositSlip.Text = "Print Deposit Slip";
            this.cmdPrintDepositSlip.UseVisualStyleBackColor = true;
            this.cmdPrintDepositSlip.Click += new System.EventHandler(this.cmdPrintDepositSlip_Click);
            // 
            // dtpDepositDateTo
            // 
            this.dtpDepositDateTo.Location = new System.Drawing.Point(440, 35);
            this.dtpDepositDateTo.Name = "dtpDepositDateTo";
            this.dtpDepositDateTo.Size = new System.Drawing.Size(209, 20);
            this.dtpDepositDateTo.TabIndex = 57;
            // 
            // cmbDepositDateLogic
            // 
            this.cmbDepositDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepositDateLogic.DropDownWidth = 130;
            this.cmbDepositDateLogic.FormattingEnabled = true;
            this.cmbDepositDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDepositDateLogic.Location = new System.Drawing.Point(117, 35);
            this.cmbDepositDateLogic.Name = "cmbDepositDateLogic";
            this.cmbDepositDateLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDepositDateLogic.TabIndex = 58;
            this.cmbDepositDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDepositDateLogic_SelectedIndexChanged);
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Location = new System.Drawing.Point(7, 9);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(103, 19);
            this.lblDocumentNumber.TabIndex = 59;
            this.lblDocumentNumber.Text = "Document Number";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbDocumentNumberLogic.Location = new System.Drawing.Point(116, 9);
            this.cmbDocumentNumberLogic.Name = "cmbDocumentNumberLogic";
            this.cmbDocumentNumberLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDocumentNumberLogic.TabIndex = 60;
            this.cmbDocumentNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentNumberLogic_SelectedIndexChanged);
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.AcceptsReturn = true;
            this.txtDocumentNumber.Location = new System.Drawing.Point(235, 9);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumber.TabIndex = 61;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(8, 120);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(103, 19);
            this.lblSource.TabIndex = 70;
            this.lblSource.Text = "Source Type";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSourceTypeLogic
            // 
            this.cmbSourceTypeLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceTypeLogic.DropDownWidth = 130;
            this.cmbSourceTypeLogic.FormattingEnabled = true;
            this.cmbSourceTypeLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbSourceTypeLogic.Location = new System.Drawing.Point(117, 118);
            this.cmbSourceTypeLogic.Name = "cmbSourceTypeLogic";
            this.cmbSourceTypeLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbSourceTypeLogic.TabIndex = 71;
            this.cmbSourceTypeLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSourceTypeLogic_SelectedIndexChanged);
            // 
            // cbcbcmbSourceType
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcbcmbSourceType.CheckBoxProperties = checkBoxProperties2;
            this.cbcbcmbSourceType.DisplayMemberSingleItem = "";
            this.cbcbcmbSourceType.FormattingEnabled = true;
            this.cbcbcmbSourceType.Items.AddRange(new object[] {
            "Sales",
            "CRV",
            "Exemption",
            "Refund"});
            this.cbcbcmbSourceType.Location = new System.Drawing.Point(235, 118);
            this.cbcbcmbSourceType.Name = "cbcbcmbSourceType";
            this.cbcbcmbSourceType.Size = new System.Drawing.Size(228, 21);
            this.cbcbcmbSourceType.TabIndex = 73;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(8, 66);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(103, 19);
            this.lblBankAccount.TabIndex = 74;
            this.lblBankAccount.Text = "Bank Account";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBankAccountLogic
            // 
            this.cmbBankAccountLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAccountLogic.DropDownWidth = 130;
            this.cmbBankAccountLogic.FormattingEnabled = true;
            this.cmbBankAccountLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbBankAccountLogic.Location = new System.Drawing.Point(117, 64);
            this.cmbBankAccountLogic.Name = "cmbBankAccountLogic";
            this.cmbBankAccountLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbBankAccountLogic.TabIndex = 75;
            this.cmbBankAccountLogic.SelectedIndexChanged += new System.EventHandler(this.cmbBankAccountLogic_SelectedIndexChanged);
            // 
            // lblSourceDate
            // 
            this.lblSourceDate.Location = new System.Drawing.Point(8, 93);
            this.lblSourceDate.Name = "lblSourceDate";
            this.lblSourceDate.Size = new System.Drawing.Size(103, 19);
            this.lblSourceDate.TabIndex = 77;
            this.lblSourceDate.Text = "Source Date";
            this.lblSourceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpSourceDateTo
            // 
            this.dtpSourceDateTo.Location = new System.Drawing.Point(444, 91);
            this.dtpSourceDateTo.Name = "dtpSourceDateTo";
            this.dtpSourceDateTo.Size = new System.Drawing.Size(206, 20);
            this.dtpSourceDateTo.TabIndex = 80;
            this.dtpSourceDateTo.Visible = false;
            // 
            // cmbSourceDateLogic
            // 
            this.cmbSourceDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceDateLogic.DropDownWidth = 130;
            this.cmbSourceDateLogic.FormattingEnabled = true;
            this.cmbSourceDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbSourceDateLogic.Location = new System.Drawing.Point(117, 91);
            this.cmbSourceDateLogic.Name = "cmbSourceDateLogic";
            this.cmbSourceDateLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbSourceDateLogic.TabIndex = 78;
            this.cmbSourceDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSourceDateLogic_SelectedIndexChanged);
            // 
            // dtpSourceDateFrom
            // 
            this.dtpSourceDateFrom.Location = new System.Drawing.Point(235, 91);
            this.dtpSourceDateFrom.Name = "dtpSourceDateFrom";
            this.dtpSourceDateFrom.Size = new System.Drawing.Size(204, 20);
            this.dtpSourceDateFrom.TabIndex = 79;
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(194, 189);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 82;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(173, 159);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(326, 24);
            this.ckAllOrAny.TabIndex = 81;
            this.ckAllOrAny.Text = "Show Deposits That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            // 
            // ddgBankAccount
            // 
            this.ddgBankAccount.AutoFilter = true;
            this.ddgBankAccount.AutoSize = true;
            this.ddgBankAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBankAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBankAccount.ClearButtonEnabled = true;
            this.ddgBankAccount.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBankAccount.FindButtonEnabled = true;
            this.ddgBankAccount.HiddenColoumns = new int[0];
            this.ddgBankAccount.Image = null;
            this.ddgBankAccount.Location = new System.Drawing.Point(232, 59);
            this.ddgBankAccount.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBankAccount.Name = "ddgBankAccount";
            this.ddgBankAccount.NewButtonEnabled = true;
            this.ddgBankAccount.RefreshButtonEnabled = true;
            this.ddgBankAccount.SelectedColomnIdex = 0;
            this.ddgBankAccount.SelectedItem = "";
            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.ShowGridFunctions = false;
            this.ddgBankAccount.Size = new System.Drawing.Size(377, 31);
            this.ddgBankAccount.TabIndex = 76;
            // 
            // frmDepositSlipPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 279);
            this.Controls.Add(this.cmbSearchAndIncludeToPreviousResult);
            this.Controls.Add(this.ckAllOrAny);
            this.Controls.Add(this.lblSourceDate);
            this.Controls.Add(this.dtpSourceDateTo);
            this.Controls.Add(this.cmbSourceDateLogic);
            this.Controls.Add(this.dtpSourceDateFrom);
            this.Controls.Add(this.ddgBankAccount);
            this.Controls.Add(this.lblBankAccount);
            this.Controls.Add(this.cmbBankAccountLogic);
            this.Controls.Add(this.cbcbcmbSourceType);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.cmbSourceTypeLogic);
            this.Controls.Add(this.lblDocumentNumber);
            this.Controls.Add(this.cmbDocumentNumberLogic);
            this.Controls.Add(this.txtDocumentNumber);
            this.Controls.Add(this.cmbDepositDateLogic);
            this.Controls.Add(this.dtpDepositDateTo);
            this.Controls.Add(this.cmdPrintDepositSlip);
            this.Controls.Add(this.lblDepositDate);
            this.Controls.Add(this.dtpDepositDateFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepositSlipPrint";
            this.Text = "Deposit Slip";
            this.Load += new System.EventHandler(this.frmDepositSlipPrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepositDate;
        private System.Windows.Forms.DateTimePicker dtpDepositDateFrom;
        private System.Windows.Forms.Button cmdPrintDepositSlip;
        private System.Windows.Forms.DateTimePicker dtpDepositDateTo;
        private System.Windows.Forms.ComboBox cmbDepositDateLogic;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ComboBox cmbSourceTypeLogic;
        private PresentationControls.CheckBoxComboBox cbcbcmbSourceType;
        private DropDownDataGrid ddgBankAccount;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.ComboBox cmbBankAccountLogic;
        private System.Windows.Forms.Label lblSourceDate;
        private System.Windows.Forms.DateTimePicker dtpSourceDateTo;
        private System.Windows.Forms.ComboBox cmbSourceDateLogic;
        private System.Windows.Forms.DateTimePicker dtpSourceDateFrom;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
        private System.Windows.Forms.CheckBox ckAllOrAny;
    }
}