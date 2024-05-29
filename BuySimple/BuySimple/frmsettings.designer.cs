namespace BuySimple
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
            this.cmbPOSPrinterNameList = new System.Windows.Forms.ComboBox();
            this.lblPOSDefaultPrinter = new System.Windows.Forms.Label();
            this.txtCompPort = new System.Windows.Forms.TextBox();
            this.lblCompPort = new System.Windows.Forms.Label();
            this.cmbCompDataBaseType = new System.Windows.Forms.ComboBox();
            this.lblComplDataBaseType = new System.Windows.Forms.Label();
            this.ckCompLogChangeScripts = new System.Windows.Forms.CheckBox();
            this.cmdCompErrFolder = new System.Windows.Forms.Button();
            this.cmdCompWarningFolder = new System.Windows.Forms.Button();
            this.cmdCompScriptFolder = new System.Windows.Forms.Button();
            this.cmdCompSettingSave = new System.Windows.Forms.Button();
            this.cmdCompSettingTest = new System.Windows.Forms.Button();
            this.txtCompMapDataTiming = new System.Windows.Forms.TextBox();
            this.txtCompWarningDir = new System.Windows.Forms.TextBox();
            this.txtCompErrorDir = new System.Windows.Forms.TextBox();
            this.txtCompPassword = new System.Windows.Forms.TextBox();
            this.txtCompUserName = new System.Windows.Forms.TextBox();
            this.txtCompDataBaseName = new System.Windows.Forms.TextBox();
            this.txtCompServerName = new System.Windows.Forms.TextBox();
            this.txtCompScriptDir = new System.Windows.Forms.TextBox();
            this.lblCompMapDataTiming = new System.Windows.Forms.Label();
            this.lblCompWarningDir = new System.Windows.Forms.Label();
            this.lblCompErrorDir = new System.Windows.Forms.Label();
            this.lblCompScriptDir = new System.Windows.Forms.Label();
            this.lblCompPassword = new System.Windows.Forms.Label();
            this.lblCompUserName = new System.Windows.Forms.Label();
            this.lblCompDataBaseName = new System.Windows.Forms.Label();
            this.lblCompServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ckCompIsLDAPAuthenticated = new System.Windows.Forms.CheckBox();
            this.grbCompiere.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCompiere
            // 
            this.grbCompiere.Controls.Add(this.ckCompIsLDAPAuthenticated);
            this.grbCompiere.Controls.Add(this.cmbPOSPrinterNameList);
            this.grbCompiere.Controls.Add(this.lblPOSDefaultPrinter);
            this.grbCompiere.Controls.Add(this.txtCompPort);
            this.grbCompiere.Controls.Add(this.lblCompPort);
            this.grbCompiere.Controls.Add(this.cmbCompDataBaseType);
            this.grbCompiere.Controls.Add(this.lblComplDataBaseType);
            this.grbCompiere.Controls.Add(this.ckCompLogChangeScripts);
            this.grbCompiere.Controls.Add(this.cmdCompErrFolder);
            this.grbCompiere.Controls.Add(this.cmdCompWarningFolder);
            this.grbCompiere.Controls.Add(this.cmdCompScriptFolder);
            this.grbCompiere.Controls.Add(this.cmdCompSettingSave);
            this.grbCompiere.Controls.Add(this.cmdCompSettingTest);
            this.grbCompiere.Controls.Add(this.txtCompMapDataTiming);
            this.grbCompiere.Controls.Add(this.txtCompWarningDir);
            this.grbCompiere.Controls.Add(this.txtCompErrorDir);
            this.grbCompiere.Controls.Add(this.txtCompPassword);
            this.grbCompiere.Controls.Add(this.txtCompUserName);
            this.grbCompiere.Controls.Add(this.txtCompDataBaseName);
            this.grbCompiere.Controls.Add(this.txtCompServerName);
            this.grbCompiere.Controls.Add(this.txtCompScriptDir);
            this.grbCompiere.Controls.Add(this.lblCompMapDataTiming);
            this.grbCompiere.Controls.Add(this.lblCompWarningDir);
            this.grbCompiere.Controls.Add(this.lblCompErrorDir);
            this.grbCompiere.Controls.Add(this.lblCompScriptDir);
            this.grbCompiere.Controls.Add(this.lblCompPassword);
            this.grbCompiere.Controls.Add(this.lblCompUserName);
            this.grbCompiere.Controls.Add(this.lblCompDataBaseName);
            this.grbCompiere.Controls.Add(this.lblCompServerName);
            this.grbCompiere.Location = new System.Drawing.Point(3, 3);
            this.grbCompiere.Name = "grbCompiere";
            this.grbCompiere.Size = new System.Drawing.Size(323, 401);
            this.grbCompiere.TabIndex = 0;
            this.grbCompiere.TabStop = false;
            this.grbCompiere.Text = "Compiere DataBase";
            // 
            // cmbPOSPrinterNameList
            // 
            this.cmbPOSPrinterNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSPrinterNameList.DropDownWidth = 220;
            this.cmbPOSPrinterNameList.FormattingEnabled = true;
            this.cmbPOSPrinterNameList.Location = new System.Drawing.Point(131, 273);
            this.cmbPOSPrinterNameList.Name = "cmbPOSPrinterNameList";
            this.cmbPOSPrinterNameList.Size = new System.Drawing.Size(184, 21);
            this.cmbPOSPrinterNameList.TabIndex = 51;
            // 
            // lblPOSDefaultPrinter
            // 
            this.lblPOSDefaultPrinter.Location = new System.Drawing.Point(11, 277);
            this.lblPOSDefaultPrinter.Name = "lblPOSDefaultPrinter";
            this.lblPOSDefaultPrinter.Size = new System.Drawing.Size(113, 13);
            this.lblPOSDefaultPrinter.TabIndex = 50;
            this.lblPOSDefaultPrinter.Text = "Printer Name";
            this.lblPOSDefaultPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCompPort
            // 
            this.txtCompPort.Location = new System.Drawing.Point(136, 164);
            this.txtCompPort.Name = "txtCompPort";
            this.txtCompPort.Size = new System.Drawing.Size(69, 20);
            this.txtCompPort.TabIndex = 14;
            // 
            // lblCompPort
            // 
            this.lblCompPort.Location = new System.Drawing.Point(22, 167);
            this.lblCompPort.Name = "lblCompPort";
            this.lblCompPort.Size = new System.Drawing.Size(100, 17);
            this.lblCompPort.TabIndex = 48;
            this.lblCompPort.Text = "Port";
            this.lblCompPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCompDataBaseType
            // 
            this.cmbCompDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompDataBaseType.Enabled = false;
            this.cmbCompDataBaseType.FormattingEnabled = true;
            this.cmbCompDataBaseType.Items.AddRange(new object[] {
            "Oracle",
            "MySql"});
            this.cmbCompDataBaseType.Location = new System.Drawing.Point(132, 29);
            this.cmbCompDataBaseType.Name = "cmbCompDataBaseType";
            this.cmbCompDataBaseType.Size = new System.Drawing.Size(124, 21);
            this.cmbCompDataBaseType.TabIndex = 47;
            // 
            // lblComplDataBaseType
            // 
            this.lblComplDataBaseType.Location = new System.Drawing.Point(9, 37);
            this.lblComplDataBaseType.Name = "lblComplDataBaseType";
            this.lblComplDataBaseType.Size = new System.Drawing.Size(113, 13);
            this.lblComplDataBaseType.TabIndex = 24;
            this.lblComplDataBaseType.Text = "Data Base Type";
            this.lblComplDataBaseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckCompLogChangeScripts
            // 
            this.ckCompLogChangeScripts.AutoSize = true;
            this.ckCompLogChangeScripts.Checked = true;
            this.ckCompLogChangeScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckCompLogChangeScripts.Location = new System.Drawing.Point(27, 335);
            this.ckCompLogChangeScripts.Name = "ckCompLogChangeScripts";
            this.ckCompLogChangeScripts.Size = new System.Drawing.Size(119, 17);
            this.ckCompLogChangeScripts.TabIndex = 23;
            this.ckCompLogChangeScripts.Text = "Log Change Scripts";
            this.ckCompLogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckCompLogChangeScripts.UseVisualStyleBackColor = true;
            // 
            // cmdCompErrFolder
            // 
            this.cmdCompErrFolder.Location = new System.Drawing.Point(291, 222);
            this.cmdCompErrFolder.Name = "cmdCompErrFolder";
            this.cmdCompErrFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdCompErrFolder.TabIndex = 18;
            this.cmdCompErrFolder.Text = "...";
            this.cmdCompErrFolder.UseVisualStyleBackColor = true;
            this.cmdCompErrFolder.Click += new System.EventHandler(this.cmdCompErrFolder_Click);
            // 
            // cmdCompWarningFolder
            // 
            this.cmdCompWarningFolder.Location = new System.Drawing.Point(291, 247);
            this.cmdCompWarningFolder.Name = "cmdCompWarningFolder";
            this.cmdCompWarningFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdCompWarningFolder.TabIndex = 20;
            this.cmdCompWarningFolder.Text = "...";
            this.cmdCompWarningFolder.UseVisualStyleBackColor = true;
            this.cmdCompWarningFolder.Click += new System.EventHandler(this.cmdCompWarningFolder_Click);
            // 
            // cmdCompScriptFolder
            // 
            this.cmdCompScriptFolder.Location = new System.Drawing.Point(291, 198);
            this.cmdCompScriptFolder.Name = "cmdCompScriptFolder";
            this.cmdCompScriptFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdCompScriptFolder.TabIndex = 16;
            this.cmdCompScriptFolder.Text = "...";
            this.cmdCompScriptFolder.UseVisualStyleBackColor = true;
            this.cmdCompScriptFolder.Click += new System.EventHandler(this.cmdCompScriptFolder_Click);
            // 
            // cmdCompSettingSave
            // 
            this.cmdCompSettingSave.Location = new System.Drawing.Point(176, 368);
            this.cmdCompSettingSave.Name = "cmdCompSettingSave";
            this.cmdCompSettingSave.Size = new System.Drawing.Size(113, 23);
            this.cmdCompSettingSave.TabIndex = 22;
            this.cmdCompSettingSave.Text = "Save";
            this.cmdCompSettingSave.UseVisualStyleBackColor = true;
            this.cmdCompSettingSave.Click += new System.EventHandler(this.cmdCompSettingSave_Click);
            // 
            // cmdCompSettingTest
            // 
            this.cmdCompSettingTest.Location = new System.Drawing.Point(37, 368);
            this.cmdCompSettingTest.Name = "cmdCompSettingTest";
            this.cmdCompSettingTest.Size = new System.Drawing.Size(117, 23);
            this.cmdCompSettingTest.TabIndex = 21;
            this.cmdCompSettingTest.Text = "Test";
            this.cmdCompSettingTest.UseVisualStyleBackColor = true;
            this.cmdCompSettingTest.Click += new System.EventHandler(this.cmdCompSettingTest_Click);
            // 
            // txtCompMapDataTiming
            // 
            this.txtCompMapDataTiming.Location = new System.Drawing.Point(132, 305);
            this.txtCompMapDataTiming.Name = "txtCompMapDataTiming";
            this.txtCompMapDataTiming.Size = new System.Drawing.Size(79, 20);
            this.txtCompMapDataTiming.TabIndex = 20;
            // 
            // txtCompWarningDir
            // 
            this.txtCompWarningDir.Location = new System.Drawing.Point(132, 247);
            this.txtCompWarningDir.Name = "txtCompWarningDir";
            this.txtCompWarningDir.ReadOnly = true;
            this.txtCompWarningDir.Size = new System.Drawing.Size(157, 20);
            this.txtCompWarningDir.TabIndex = 19;
            // 
            // txtCompErrorDir
            // 
            this.txtCompErrorDir.Location = new System.Drawing.Point(132, 222);
            this.txtCompErrorDir.Name = "txtCompErrorDir";
            this.txtCompErrorDir.ReadOnly = true;
            this.txtCompErrorDir.Size = new System.Drawing.Size(157, 20);
            this.txtCompErrorDir.TabIndex = 17;
            // 
            // txtCompPassword
            // 
            this.txtCompPassword.Location = new System.Drawing.Point(132, 134);
            this.txtCompPassword.Name = "txtCompPassword";
            this.txtCompPassword.PasswordChar = '*';
            this.txtCompPassword.Size = new System.Drawing.Size(142, 20);
            this.txtCompPassword.TabIndex = 13;
            // 
            // txtCompUserName
            // 
            this.txtCompUserName.Location = new System.Drawing.Point(132, 108);
            this.txtCompUserName.Name = "txtCompUserName";
            this.txtCompUserName.Size = new System.Drawing.Size(142, 20);
            this.txtCompUserName.TabIndex = 12;
            // 
            // txtCompDataBaseName
            // 
            this.txtCompDataBaseName.Location = new System.Drawing.Point(132, 82);
            this.txtCompDataBaseName.Name = "txtCompDataBaseName";
            this.txtCompDataBaseName.Size = new System.Drawing.Size(142, 20);
            this.txtCompDataBaseName.TabIndex = 11;
            // 
            // txtCompServerName
            // 
            this.txtCompServerName.Location = new System.Drawing.Point(132, 56);
            this.txtCompServerName.Name = "txtCompServerName";
            this.txtCompServerName.Size = new System.Drawing.Size(142, 20);
            this.txtCompServerName.TabIndex = 10;
            // 
            // txtCompScriptDir
            // 
            this.txtCompScriptDir.Location = new System.Drawing.Point(132, 197);
            this.txtCompScriptDir.Name = "txtCompScriptDir";
            this.txtCompScriptDir.ReadOnly = true;
            this.txtCompScriptDir.Size = new System.Drawing.Size(153, 20);
            this.txtCompScriptDir.TabIndex = 15;
            // 
            // lblCompMapDataTiming
            // 
            this.lblCompMapDataTiming.Location = new System.Drawing.Point(13, 308);
            this.lblCompMapDataTiming.Name = "lblCompMapDataTiming";
            this.lblCompMapDataTiming.Size = new System.Drawing.Size(113, 13);
            this.lblCompMapDataTiming.TabIndex = 7;
            this.lblCompMapDataTiming.Text = "Map Data Every (min.)";
            this.lblCompMapDataTiming.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompWarningDir
            // 
            this.lblCompWarningDir.Location = new System.Drawing.Point(13, 250);
            this.lblCompWarningDir.Name = "lblCompWarningDir";
            this.lblCompWarningDir.Size = new System.Drawing.Size(113, 13);
            this.lblCompWarningDir.TabIndex = 6;
            this.lblCompWarningDir.Text = "Warning Log Directory";
            this.lblCompWarningDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompErrorDir
            // 
            this.lblCompErrorDir.Location = new System.Drawing.Point(13, 225);
            this.lblCompErrorDir.Name = "lblCompErrorDir";
            this.lblCompErrorDir.Size = new System.Drawing.Size(113, 13);
            this.lblCompErrorDir.TabIndex = 5;
            this.lblCompErrorDir.Text = "Error Log Directory";
            this.lblCompErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompScriptDir
            // 
            this.lblCompScriptDir.Location = new System.Drawing.Point(13, 200);
            this.lblCompScriptDir.Name = "lblCompScriptDir";
            this.lblCompScriptDir.Size = new System.Drawing.Size(113, 13);
            this.lblCompScriptDir.TabIndex = 4;
            this.lblCompScriptDir.Text = "Script Log Directory";
            this.lblCompScriptDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompPassword
            // 
            this.lblCompPassword.Location = new System.Drawing.Point(9, 137);
            this.lblCompPassword.Name = "lblCompPassword";
            this.lblCompPassword.Size = new System.Drawing.Size(113, 13);
            this.lblCompPassword.TabIndex = 3;
            this.lblCompPassword.Text = "Password";
            this.lblCompPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompUserName
            // 
            this.lblCompUserName.Location = new System.Drawing.Point(9, 111);
            this.lblCompUserName.Name = "lblCompUserName";
            this.lblCompUserName.Size = new System.Drawing.Size(113, 13);
            this.lblCompUserName.TabIndex = 2;
            this.lblCompUserName.Text = "User Name";
            this.lblCompUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompDataBaseName
            // 
            this.lblCompDataBaseName.Location = new System.Drawing.Point(9, 85);
            this.lblCompDataBaseName.Name = "lblCompDataBaseName";
            this.lblCompDataBaseName.Size = new System.Drawing.Size(113, 13);
            this.lblCompDataBaseName.TabIndex = 1;
            this.lblCompDataBaseName.Text = "DataBase Name";
            this.lblCompDataBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompServerName
            // 
            this.lblCompServerName.Location = new System.Drawing.Point(9, 59);
            this.lblCompServerName.Name = "lblCompServerName";
            this.lblCompServerName.Size = new System.Drawing.Size(113, 13);
            this.lblCompServerName.TabIndex = 0;
            this.lblCompServerName.Text = "Server Name";
            this.lblCompServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckCompIsLDAPAuthenticated
            // 
            this.ckCompIsLDAPAuthenticated.AutoSize = true;
            this.ckCompIsLDAPAuthenticated.Location = new System.Drawing.Point(191, 334);
            this.ckCompIsLDAPAuthenticated.Name = "ckCompIsLDAPAuthenticated";
            this.ckCompIsLDAPAuthenticated.Size = new System.Drawing.Size(123, 17);
            this.ckCompIsLDAPAuthenticated.TabIndex = 58;
            this.ckCompIsLDAPAuthenticated.Text = "LDAP Authenticated";
            this.ckCompIsLDAPAuthenticated.UseVisualStyleBackColor = true;
            this.ckCompIsLDAPAuthenticated.CheckedChanged += new System.EventHandler(this.ckIsLDAPAuthenticated_CheckedChanged);
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 406);
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
        private System.Windows.Forms.Label lblCompDataBaseName;
        private System.Windows.Forms.Label lblCompServerName;
        private System.Windows.Forms.Label lblCompMapDataTiming;
        private System.Windows.Forms.Label lblCompWarningDir;
        private System.Windows.Forms.Label lblCompErrorDir;
        private System.Windows.Forms.Label lblCompScriptDir;
        private System.Windows.Forms.Label lblCompPassword;
        private System.Windows.Forms.Label lblCompUserName;
        private System.Windows.Forms.TextBox txtCompPassword;
        private System.Windows.Forms.TextBox txtCompUserName;
        private System.Windows.Forms.TextBox txtCompDataBaseName;
        private System.Windows.Forms.TextBox txtCompServerName;
        private System.Windows.Forms.TextBox txtCompScriptDir;
        private System.Windows.Forms.Button cmdCompSettingSave;
        private System.Windows.Forms.Button cmdCompSettingTest;
        private System.Windows.Forms.TextBox txtCompMapDataTiming;
        private System.Windows.Forms.TextBox txtCompWarningDir;
        private System.Windows.Forms.TextBox txtCompErrorDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdCompErrFolder;
        private System.Windows.Forms.Button cmdCompWarningFolder;
        private System.Windows.Forms.Button cmdCompScriptFolder;
        private System.Windows.Forms.CheckBox ckCompLogChangeScripts;
        private System.Windows.Forms.Label lblComplDataBaseType;
        private System.Windows.Forms.ComboBox cmbCompDataBaseType;
        private System.Windows.Forms.TextBox txtCompPort;
        private System.Windows.Forms.Label lblCompPort;
        private System.Windows.Forms.ComboBox cmbPOSPrinterNameList;
        private System.Windows.Forms.Label lblPOSDefaultPrinter;
        private System.Windows.Forms.CheckBox ckCompIsLDAPAuthenticated;
    }
}