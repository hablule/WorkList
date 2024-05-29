namespace dbConnection
{
    partial class frmsettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsettings));
            this.grbCompiere = new System.Windows.Forms.GroupBox();
            this.ckIsLDAPAuthenticated = new System.Windows.Forms.CheckBox();
            this.lblApprovedAmt = new System.Windows.Forms.Label();
            this.ntbApprovedAmount = new customControls.ctlNumberTextBox();
            this.ckPrintApproveChecksOnly = new System.Windows.Forms.CheckBox();
            this.ckVerifyCheckNumber = new System.Windows.Forms.CheckBox();
            this.cmbCheckPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrinterName = new System.Windows.Forms.ComboBox();
            this.lblPrinterList = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbDataBaseType = new System.Windows.Forms.ComboBox();
            this.lblDataBaseType = new System.Windows.Forms.Label();
            this.ckLogChangeScripts = new System.Windows.Forms.CheckBox();
            this.cmdErrFolder = new System.Windows.Forms.Button();
            this.cmdWarningFolder = new System.Windows.Forms.Button();
            this.cmdScriptFolder = new System.Windows.Forms.Button();
            this.cmdSettingSave = new System.Windows.Forms.Button();
            this.cmdSettingTest = new System.Windows.Forms.Button();
            this.txtWarningDir = new System.Windows.Forms.TextBox();
            this.txtErrorDir = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtScriptDir = new System.Windows.Forms.TextBox();
            this.lblWarningDir = new System.Windows.Forms.Label();
            this.lblErrorDir = new System.Windows.Forms.Label();
            this.lblScriptDir = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ckAllowOverageShortagePassKey = new System.Windows.Forms.CheckBox();
            this.grbCompiere.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCompiere
            // 
            this.grbCompiere.Controls.Add(this.ckIsLDAPAuthenticated);
            this.grbCompiere.Controls.Add(this.lblApprovedAmt);
            this.grbCompiere.Controls.Add(this.ntbApprovedAmount);
            this.grbCompiere.Controls.Add(this.ckPrintApproveChecksOnly);
            this.grbCompiere.Controls.Add(this.ckAllowOverageShortagePassKey);
            this.grbCompiere.Controls.Add(this.ckVerifyCheckNumber);
            this.grbCompiere.Controls.Add(this.cmbCheckPrinter);
            this.grbCompiere.Controls.Add(this.label1);
            this.grbCompiere.Controls.Add(this.cmbPrinterName);
            this.grbCompiere.Controls.Add(this.lblPrinterList);
            this.grbCompiere.Controls.Add(this.txtPort);
            this.grbCompiere.Controls.Add(this.lblPort);
            this.grbCompiere.Controls.Add(this.cmbDataBaseType);
            this.grbCompiere.Controls.Add(this.lblDataBaseType);
            this.grbCompiere.Controls.Add(this.ckLogChangeScripts);
            this.grbCompiere.Controls.Add(this.cmdErrFolder);
            this.grbCompiere.Controls.Add(this.cmdWarningFolder);
            this.grbCompiere.Controls.Add(this.cmdScriptFolder);
            this.grbCompiere.Controls.Add(this.cmdSettingSave);
            this.grbCompiere.Controls.Add(this.cmdSettingTest);
            this.grbCompiere.Controls.Add(this.txtWarningDir);
            this.grbCompiere.Controls.Add(this.txtErrorDir);
            this.grbCompiere.Controls.Add(this.txtPassword);
            this.grbCompiere.Controls.Add(this.txtUserName);
            this.grbCompiere.Controls.Add(this.txtDataBaseName);
            this.grbCompiere.Controls.Add(this.txtServerName);
            this.grbCompiere.Controls.Add(this.txtScriptDir);
            this.grbCompiere.Controls.Add(this.lblWarningDir);
            this.grbCompiere.Controls.Add(this.lblErrorDir);
            this.grbCompiere.Controls.Add(this.lblScriptDir);
            this.grbCompiere.Controls.Add(this.lblPassword);
            this.grbCompiere.Controls.Add(this.lblUserName);
            this.grbCompiere.Controls.Add(this.lblDataBaseName);
            this.grbCompiere.Controls.Add(this.lblServerName);
            this.grbCompiere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCompiere.Location = new System.Drawing.Point(0, 0);
            this.grbCompiere.Name = "grbCompiere";
            this.grbCompiere.Size = new System.Drawing.Size(633, 318);
            this.grbCompiere.TabIndex = 0;
            this.grbCompiere.TabStop = false;
            this.grbCompiere.Text = "Compiere DataBase";
            // 
            // ckIsLDAPAuthenticated
            // 
            this.ckIsLDAPAuthenticated.AutoSize = true;
            this.ckIsLDAPAuthenticated.Location = new System.Drawing.Point(208, 286);
            this.ckIsLDAPAuthenticated.Name = "ckIsLDAPAuthenticated";
            this.ckIsLDAPAuthenticated.Size = new System.Drawing.Size(123, 17);
            this.ckIsLDAPAuthenticated.TabIndex = 57;
            this.ckIsLDAPAuthenticated.Text = "LDAP Authenticated";
            this.ckIsLDAPAuthenticated.UseVisualStyleBackColor = true;
            this.ckIsLDAPAuthenticated.CheckedChanged += new System.EventHandler(this.ckIsLDAPAuthenticated_CheckedChanged);
            // 
            // lblApprovedAmt
            // 
            this.lblApprovedAmt.Location = new System.Drawing.Point(332, 146);
            this.lblApprovedAmt.Name = "lblApprovedAmt";
            this.lblApprovedAmt.Size = new System.Drawing.Size(100, 17);
            this.lblApprovedAmt.TabIndex = 56;
            this.lblApprovedAmt.Text = "Approved Amount";
            this.lblApprovedAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntbApprovedAmount
            // 
            this.ntbApprovedAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbApprovedAmount.AllowedLength = 0;
            this.ntbApprovedAmount.AllowLeadingZeros = false;
            this.ntbApprovedAmount.AllowNegative = false;
            this.ntbApprovedAmount.Amount = "0";
            this.ntbApprovedAmount.defaultAmount = "0";
            this.ntbApprovedAmount.Location = new System.Drawing.Point(438, 143);
            this.ntbApprovedAmount.Name = "ntbApprovedAmount";
            this.ntbApprovedAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbApprovedAmount.ShowThousandSeparetor = true;
            this.ntbApprovedAmount.Size = new System.Drawing.Size(138, 23);
            this.ntbApprovedAmount.StandardPrecision = 2;
            this.ntbApprovedAmount.TabIndex = 55;
            // 
            // ckPrintApproveChecksOnly
            // 
            this.ckPrintApproveChecksOnly.Checked = true;
            this.ckPrintApproveChecksOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckPrintApproveChecksOnly.Location = new System.Drawing.Point(420, 115);
            this.ckPrintApproveChecksOnly.Name = "ckPrintApproveChecksOnly";
            this.ckPrintApproveChecksOnly.Size = new System.Drawing.Size(168, 26);
            this.ckPrintApproveChecksOnly.TabIndex = 54;
            this.ckPrintApproveChecksOnly.Text = "Print Only Approved Checks";
            this.ckPrintApproveChecksOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckPrintApproveChecksOnly.UseVisualStyleBackColor = true;
            // 
            // ckVerifyCheckNumber
            // 
            this.ckVerifyCheckNumber.Checked = true;
            this.ckVerifyCheckNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckVerifyCheckNumber.Location = new System.Drawing.Point(438, 89);
            this.ckVerifyCheckNumber.Name = "ckVerifyCheckNumber";
            this.ckVerifyCheckNumber.Size = new System.Drawing.Size(132, 26);
            this.ckVerifyCheckNumber.TabIndex = 53;
            this.ckVerifyCheckNumber.Text = "Verify Check Number";
            this.ckVerifyCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckVerifyCheckNumber.UseVisualStyleBackColor = true;
            // 
            // cmbCheckPrinter
            // 
            this.cmbCheckPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckPrinter.FormattingEnabled = true;
            this.cmbCheckPrinter.Location = new System.Drawing.Point(437, 58);
            this.cmbCheckPrinter.Name = "cmbCheckPrinter";
            this.cmbCheckPrinter.Size = new System.Drawing.Size(183, 21);
            this.cmbCheckPrinter.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(314, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Check Printer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPrinterName
            // 
            this.cmbPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterName.FormattingEnabled = true;
            this.cmbPrinterName.Location = new System.Drawing.Point(437, 31);
            this.cmbPrinterName.Name = "cmbPrinterName";
            this.cmbPrinterName.Size = new System.Drawing.Size(183, 21);
            this.cmbPrinterName.TabIndex = 50;
            // 
            // lblPrinterList
            // 
            this.lblPrinterList.Location = new System.Drawing.Point(295, 36);
            this.lblPrinterList.Name = "lblPrinterList";
            this.lblPrinterList.Size = new System.Drawing.Size(132, 13);
            this.lblPrinterList.TabIndex = 49;
            this.lblPrinterList.Text = "Paymet Voucher Printer";
            this.lblPrinterList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(132, 164);
            this.txtPort.Name = "txtPort";
            this.txtPort.PasswordChar = '-';
            this.txtPort.Size = new System.Drawing.Size(69, 20);
            this.txtPort.TabIndex = 14;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(22, 167);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(100, 17);
            this.lblPort.TabIndex = 48;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDataBaseType
            // 
            this.cmbDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBaseType.FormattingEnabled = true;
            this.cmbDataBaseType.Items.AddRange(new object[] {
            "Oracle",
            "MySql"});
            this.cmbDataBaseType.Location = new System.Drawing.Point(132, 29);
            this.cmbDataBaseType.Name = "cmbDataBaseType";
            this.cmbDataBaseType.Size = new System.Drawing.Size(124, 21);
            this.cmbDataBaseType.TabIndex = 47;
            // 
            // lblDataBaseType
            // 
            this.lblDataBaseType.Location = new System.Drawing.Point(9, 32);
            this.lblDataBaseType.Name = "lblDataBaseType";
            this.lblDataBaseType.Size = new System.Drawing.Size(113, 13);
            this.lblDataBaseType.TabIndex = 24;
            this.lblDataBaseType.Text = "Data Base Type";
            this.lblDataBaseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckLogChangeScripts
            // 
            this.ckLogChangeScripts.Checked = true;
            this.ckLogChangeScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckLogChangeScripts.Location = new System.Drawing.Point(39, 281);
            this.ckLogChangeScripts.Name = "ckLogChangeScripts";
            this.ckLogChangeScripts.Size = new System.Drawing.Size(132, 26);
            this.ckLogChangeScripts.TabIndex = 23;
            this.ckLogChangeScripts.Text = "Log Change Scripts";
            this.ckLogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckLogChangeScripts.UseVisualStyleBackColor = true;
            // 
            // cmdErrFolder
            // 
            this.cmdErrFolder.Location = new System.Drawing.Point(291, 222);
            this.cmdErrFolder.Name = "cmdErrFolder";
            this.cmdErrFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdErrFolder.TabIndex = 18;
            this.cmdErrFolder.Text = "...";
            this.cmdErrFolder.UseVisualStyleBackColor = true;
            this.cmdErrFolder.Click += new System.EventHandler(this.cmdErrFolder_Click);
            // 
            // cmdWarningFolder
            // 
            this.cmdWarningFolder.Location = new System.Drawing.Point(291, 247);
            this.cmdWarningFolder.Name = "cmdWarningFolder";
            this.cmdWarningFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdWarningFolder.TabIndex = 20;
            this.cmdWarningFolder.Text = "...";
            this.cmdWarningFolder.UseVisualStyleBackColor = true;
            this.cmdWarningFolder.Click += new System.EventHandler(this.cmdWarningFolder_Click);
            // 
            // cmdScriptFolder
            // 
            this.cmdScriptFolder.Location = new System.Drawing.Point(291, 197);
            this.cmdScriptFolder.Name = "cmdScriptFolder";
            this.cmdScriptFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdScriptFolder.TabIndex = 16;
            this.cmdScriptFolder.Text = "...";
            this.cmdScriptFolder.UseVisualStyleBackColor = true;
            this.cmdScriptFolder.Click += new System.EventHandler(this.cmdScriptFolder_Click);
            // 
            // cmdSettingSave
            // 
            this.cmdSettingSave.Location = new System.Drawing.Point(420, 256);
            this.cmdSettingSave.Name = "cmdSettingSave";
            this.cmdSettingSave.Size = new System.Drawing.Size(131, 26);
            this.cmdSettingSave.TabIndex = 22;
            this.cmdSettingSave.Text = "Save";
            this.cmdSettingSave.UseVisualStyleBackColor = true;
            this.cmdSettingSave.Click += new System.EventHandler(this.cmdSettingSave_Click);
            // 
            // cmdSettingTest
            // 
            this.cmdSettingTest.Location = new System.Drawing.Point(401, 212);
            this.cmdSettingTest.Name = "cmdSettingTest";
            this.cmdSettingTest.Size = new System.Drawing.Size(169, 38);
            this.cmdSettingTest.TabIndex = 21;
            this.cmdSettingTest.Text = "Test";
            this.cmdSettingTest.UseVisualStyleBackColor = true;
            this.cmdSettingTest.Click += new System.EventHandler(this.cmdSettingTest_Click);
            // 
            // txtWarningDir
            // 
            this.txtWarningDir.Location = new System.Drawing.Point(132, 247);
            this.txtWarningDir.Name = "txtWarningDir";
            this.txtWarningDir.ReadOnly = true;
            this.txtWarningDir.Size = new System.Drawing.Size(157, 20);
            this.txtWarningDir.TabIndex = 19;
            // 
            // txtErrorDir
            // 
            this.txtErrorDir.Location = new System.Drawing.Point(132, 222);
            this.txtErrorDir.Name = "txtErrorDir";
            this.txtErrorDir.ReadOnly = true;
            this.txtErrorDir.Size = new System.Drawing.Size(157, 20);
            this.txtErrorDir.TabIndex = 17;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(132, 134);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(142, 20);
            this.txtPassword.TabIndex = 13;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(132, 108);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '-';
            this.txtUserName.Size = new System.Drawing.Size(142, 20);
            this.txtUserName.TabIndex = 12;
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(132, 82);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.PasswordChar = '-';
            this.txtDataBaseName.Size = new System.Drawing.Size(142, 20);
            this.txtDataBaseName.TabIndex = 11;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(132, 56);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(142, 20);
            this.txtServerName.TabIndex = 10;
            // 
            // txtScriptDir
            // 
            this.txtScriptDir.Location = new System.Drawing.Point(132, 197);
            this.txtScriptDir.Name = "txtScriptDir";
            this.txtScriptDir.ReadOnly = true;
            this.txtScriptDir.Size = new System.Drawing.Size(157, 20);
            this.txtScriptDir.TabIndex = 15;
            // 
            // lblWarningDir
            // 
            this.lblWarningDir.Location = new System.Drawing.Point(9, 250);
            this.lblWarningDir.Name = "lblWarningDir";
            this.lblWarningDir.Size = new System.Drawing.Size(113, 13);
            this.lblWarningDir.TabIndex = 6;
            this.lblWarningDir.Text = "Warning Log Directory";
            this.lblWarningDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblErrorDir
            // 
            this.lblErrorDir.Location = new System.Drawing.Point(9, 225);
            this.lblErrorDir.Name = "lblErrorDir";
            this.lblErrorDir.Size = new System.Drawing.Size(113, 13);
            this.lblErrorDir.TabIndex = 5;
            this.lblErrorDir.Text = "Error Log Directory";
            this.lblErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScriptDir
            // 
            this.lblScriptDir.Location = new System.Drawing.Point(9, 200);
            this.lblScriptDir.Name = "lblScriptDir";
            this.lblScriptDir.Size = new System.Drawing.Size(113, 13);
            this.lblScriptDir.TabIndex = 4;
            this.lblScriptDir.Text = "Script Log Directory";
            this.lblScriptDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(9, 137);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(113, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(9, 111);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(113, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.Location = new System.Drawing.Point(9, 85);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(113, 13);
            this.lblDataBaseName.TabIndex = 1;
            this.lblDataBaseName.Text = "DataBase Name";
            this.lblDataBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServerName
            // 
            this.lblServerName.Location = new System.Drawing.Point(9, 59);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(113, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name";
            this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckAllowOverageShortagePassKey
            // 
            this.ckAllowOverageShortagePassKey.Checked = true;
            this.ckAllowOverageShortagePassKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAllowOverageShortagePassKey.Location = new System.Drawing.Point(408, 172);
            this.ckAllowOverageShortagePassKey.Name = "ckAllowOverageShortagePassKey";
            this.ckAllowOverageShortagePassKey.Size = new System.Drawing.Size(191, 26);
            this.ckAllowOverageShortagePassKey.TabIndex = 53;
            this.ckAllowOverageShortagePassKey.Text = "Allow Overage Shortage PassKey";
            this.ckAllowOverageShortagePassKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckAllowOverageShortagePassKey.UseVisualStyleBackColor = true;
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 318);
            this.Controls.Add(this.grbCompiere);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsettings";
            this.Text = "Data Base and Directory Settings";
            this.Load += new System.EventHandler(this.frmsettings_Load);
            this.grbCompiere.ResumeLayout(false);
            this.grbCompiere.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCompiere;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblWarningDir;
        private System.Windows.Forms.Label lblErrorDir;
        private System.Windows.Forms.Label lblScriptDir;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtScriptDir;
        private System.Windows.Forms.Button cmdSettingSave;
        private System.Windows.Forms.Button cmdSettingTest;
        private System.Windows.Forms.TextBox txtWarningDir;
        private System.Windows.Forms.TextBox txtErrorDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdErrFolder;
        private System.Windows.Forms.Button cmdWarningFolder;
        private System.Windows.Forms.Button cmdScriptFolder;
        private System.Windows.Forms.CheckBox ckLogChangeScripts;
        private System.Windows.Forms.Label lblDataBaseType;
        private System.Windows.Forms.ComboBox cmbDataBaseType;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbPrinterName;
        private System.Windows.Forms.Label lblPrinterList;
        private System.Windows.Forms.ComboBox cmbCheckPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckVerifyCheckNumber;
        private System.Windows.Forms.CheckBox ckPrintApproveChecksOnly;
        private customControls.ctlNumberTextBox ntbApprovedAmount;
        private System.Windows.Forms.Label lblApprovedAmt;
        private System.Windows.Forms.CheckBox ckIsLDAPAuthenticated;
        private System.Windows.Forms.CheckBox ckAllowOverageShortagePassKey;
    }
}