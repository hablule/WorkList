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
            this.grbEasyMove = new System.Windows.Forms.GroupBox();
            this.PrinterName = new System.Windows.Forms.ComboBox();
            this.DataBaseType = new System.Windows.Forms.ComboBox();
            this.lblDataBaseType = new System.Windows.Forms.Label();
            this.LogChangeScripts = new System.Windows.Forms.CheckBox();
            this.cmdEasyMoveWarningFolder = new System.Windows.Forms.Button();
            this.DBPort = new System.Windows.Forms.TextBox();
            this.cmdEasyMoveScriptFolder = new System.Windows.Forms.Button();
            this.cmdEasyMoveErrFolder = new System.Windows.Forms.Button();
            this.lblDBPort = new System.Windows.Forms.Label();
            this.cmdSettingSave = new System.Windows.Forms.Button();
            this.cmdSettingTest = new System.Windows.Forms.Button();
            this.WarningDir = new System.Windows.Forms.TextBox();
            this.ErrorDir = new System.Windows.Forms.TextBox();
            this.DBPassword = new System.Windows.Forms.TextBox();
            this.DBUserName = new System.Windows.Forms.TextBox();
            this.DataBaseName = new System.Windows.Forms.TextBox();
            this.DBServerName = new System.Windows.Forms.TextBox();
            this.ScriptDir = new System.Windows.Forms.TextBox();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.lblWarningDir = new System.Windows.Forms.Label();
            this.lblErrorDir = new System.Windows.Forms.Label();
            this.lblScriptDir = new System.Windows.Forms.Label();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.lblDBUserName = new System.Windows.Forms.Label();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.lblDBServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LDAPAuthenticated = new System.Windows.Forms.CheckBox();
            this.grbEasyMove.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEasyMove
            // 
            this.grbEasyMove.Controls.Add(this.LDAPAuthenticated);
            this.grbEasyMove.Controls.Add(this.PrinterName);
            this.grbEasyMove.Controls.Add(this.DataBaseType);
            this.grbEasyMove.Controls.Add(this.lblDataBaseType);
            this.grbEasyMove.Controls.Add(this.LogChangeScripts);
            this.grbEasyMove.Controls.Add(this.cmdEasyMoveWarningFolder);
            this.grbEasyMove.Controls.Add(this.DBPort);
            this.grbEasyMove.Controls.Add(this.cmdEasyMoveScriptFolder);
            this.grbEasyMove.Controls.Add(this.cmdEasyMoveErrFolder);
            this.grbEasyMove.Controls.Add(this.lblDBPort);
            this.grbEasyMove.Controls.Add(this.cmdSettingSave);
            this.grbEasyMove.Controls.Add(this.cmdSettingTest);
            this.grbEasyMove.Controls.Add(this.WarningDir);
            this.grbEasyMove.Controls.Add(this.ErrorDir);
            this.grbEasyMove.Controls.Add(this.DBPassword);
            this.grbEasyMove.Controls.Add(this.DBUserName);
            this.grbEasyMove.Controls.Add(this.DataBaseName);
            this.grbEasyMove.Controls.Add(this.DBServerName);
            this.grbEasyMove.Controls.Add(this.ScriptDir);
            this.grbEasyMove.Controls.Add(this.lblPrinterName);
            this.grbEasyMove.Controls.Add(this.lblWarningDir);
            this.grbEasyMove.Controls.Add(this.lblErrorDir);
            this.grbEasyMove.Controls.Add(this.lblScriptDir);
            this.grbEasyMove.Controls.Add(this.lblDBPassword);
            this.grbEasyMove.Controls.Add(this.lblDBUserName);
            this.grbEasyMove.Controls.Add(this.lblDataBaseName);
            this.grbEasyMove.Controls.Add(this.lblDBServerName);
            this.grbEasyMove.Location = new System.Drawing.Point(2, 5);
            this.grbEasyMove.Name = "grbEasyMove";
            this.grbEasyMove.Size = new System.Drawing.Size(459, 337);
            this.grbEasyMove.TabIndex = 1;
            this.grbEasyMove.TabStop = false;
            this.grbEasyMove.Text = "Easy Move DataBase";
            // 
            // PrinterName
            // 
            this.PrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrinterName.FormattingEnabled = true;
            this.PrinterName.Location = new System.Drawing.Point(130, 279);
            this.PrinterName.Name = "PrinterName";
            this.PrinterName.Size = new System.Drawing.Size(183, 21);
            this.PrinterName.TabIndex = 48;
            // 
            // DataBaseType
            // 
            this.DataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBaseType.FormattingEnabled = true;
            this.DataBaseType.Items.AddRange(new object[] {
            "Oracle",
            "MySql"});
            this.DataBaseType.Location = new System.Drawing.Point(130, 34);
            this.DataBaseType.Name = "DataBaseType";
            this.DataBaseType.Size = new System.Drawing.Size(124, 21);
            this.DataBaseType.TabIndex = 1;
            // 
            // lblDataBaseType
            // 
            this.lblDataBaseType.Location = new System.Drawing.Point(11, 37);
            this.lblDataBaseType.Name = "lblDataBaseType";
            this.lblDataBaseType.Size = new System.Drawing.Size(113, 13);
            this.lblDataBaseType.TabIndex = 100;
            this.lblDataBaseType.Text = "Data Base Type";
            this.lblDataBaseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogChangeScripts
            // 
            this.LogChangeScripts.AutoSize = true;
            this.LogChangeScripts.Checked = true;
            this.LogChangeScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LogChangeScripts.Location = new System.Drawing.Point(27, 308);
            this.LogChangeScripts.Name = "LogChangeScripts";
            this.LogChangeScripts.Size = new System.Drawing.Size(119, 17);
            this.LogChangeScripts.TabIndex = 46;
            this.LogChangeScripts.Text = "Log Change Scripts";
            this.LogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LogChangeScripts.UseVisualStyleBackColor = true;
            // 
            // cmdEasyMoveWarningFolder
            // 
            this.cmdEasyMoveWarningFolder.Location = new System.Drawing.Point(291, 251);
            this.cmdEasyMoveWarningFolder.Name = "cmdEasyMoveWarningFolder";
            this.cmdEasyMoveWarningFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdEasyMoveWarningFolder.TabIndex = 9;
            this.cmdEasyMoveWarningFolder.Text = "...";
            this.cmdEasyMoveWarningFolder.UseVisualStyleBackColor = true;
            this.cmdEasyMoveWarningFolder.Click += new System.EventHandler(this.cmdEasyMoveWarningFolder_Click);
            // 
            // DBPort
            // 
            this.DBPort.Location = new System.Drawing.Point(130, 164);
            this.DBPort.Name = "DBPort";
            this.DBPort.PasswordChar = '|';
            this.DBPort.Size = new System.Drawing.Size(69, 20);
            this.DBPort.TabIndex = 6;
            // 
            // cmdEasyMoveScriptFolder
            // 
            this.cmdEasyMoveScriptFolder.Location = new System.Drawing.Point(291, 201);
            this.cmdEasyMoveScriptFolder.Name = "cmdEasyMoveScriptFolder";
            this.cmdEasyMoveScriptFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdEasyMoveScriptFolder.TabIndex = 7;
            this.cmdEasyMoveScriptFolder.Text = "...";
            this.cmdEasyMoveScriptFolder.UseVisualStyleBackColor = true;
            this.cmdEasyMoveScriptFolder.Click += new System.EventHandler(this.cmdEasyMoveScriptFolder_Click);
            // 
            // cmdEasyMoveErrFolder
            // 
            this.cmdEasyMoveErrFolder.Location = new System.Drawing.Point(291, 226);
            this.cmdEasyMoveErrFolder.Name = "cmdEasyMoveErrFolder";
            this.cmdEasyMoveErrFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdEasyMoveErrFolder.TabIndex = 8;
            this.cmdEasyMoveErrFolder.Text = "...";
            this.cmdEasyMoveErrFolder.UseVisualStyleBackColor = true;
            this.cmdEasyMoveErrFolder.Click += new System.EventHandler(this.cmdEasyMoveErrFolder_Click);
            // 
            // lblDBPort
            // 
            this.lblDBPort.Location = new System.Drawing.Point(26, 167);
            this.lblDBPort.Name = "lblDBPort";
            this.lblDBPort.Size = new System.Drawing.Size(94, 17);
            this.lblDBPort.TabIndex = 106;
            this.lblDBPort.Text = "Port";
            this.lblDBPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdSettingSave
            // 
            this.cmdSettingSave.Location = new System.Drawing.Point(308, 109);
            this.cmdSettingSave.Name = "cmdSettingSave";
            this.cmdSettingSave.Size = new System.Drawing.Size(125, 38);
            this.cmdSettingSave.TabIndex = 16;
            this.cmdSettingSave.Text = "Save";
            this.cmdSettingSave.UseVisualStyleBackColor = true;
            this.cmdSettingSave.Click += new System.EventHandler(this.cmdEasyMoveSettingSave_Click);
            // 
            // cmdSettingTest
            // 
            this.cmdSettingTest.Location = new System.Drawing.Point(291, 59);
            this.cmdSettingTest.Name = "cmdSettingTest";
            this.cmdSettingTest.Size = new System.Drawing.Size(156, 42);
            this.cmdSettingTest.TabIndex = 15;
            this.cmdSettingTest.Text = "Test";
            this.cmdSettingTest.UseVisualStyleBackColor = true;
            this.cmdSettingTest.Click += new System.EventHandler(this.cmdEasyMoveSettingTest_Click);
            // 
            // WarningDir
            // 
            this.WarningDir.Location = new System.Drawing.Point(130, 252);
            this.WarningDir.Name = "WarningDir";
            this.WarningDir.ReadOnly = true;
            this.WarningDir.Size = new System.Drawing.Size(158, 20);
            this.WarningDir.TabIndex = 41;
            this.WarningDir.TabStop = false;
            // 
            // ErrorDir
            // 
            this.ErrorDir.Location = new System.Drawing.Point(130, 227);
            this.ErrorDir.Name = "ErrorDir";
            this.ErrorDir.ReadOnly = true;
            this.ErrorDir.Size = new System.Drawing.Size(158, 20);
            this.ErrorDir.TabIndex = 39;
            this.ErrorDir.TabStop = false;
            // 
            // DBPassword
            // 
            this.DBPassword.Location = new System.Drawing.Point(130, 137);
            this.DBPassword.Name = "DBPassword";
            this.DBPassword.PasswordChar = '*';
            this.DBPassword.Size = new System.Drawing.Size(142, 20);
            this.DBPassword.TabIndex = 5;
            // 
            // DBUserName
            // 
            this.DBUserName.Location = new System.Drawing.Point(130, 111);
            this.DBUserName.Name = "DBUserName";
            this.DBUserName.PasswordChar = '|';
            this.DBUserName.Size = new System.Drawing.Size(142, 20);
            this.DBUserName.TabIndex = 4;
            // 
            // DataBaseName
            // 
            this.DataBaseName.Location = new System.Drawing.Point(130, 85);
            this.DataBaseName.Name = "DataBaseName";
            this.DataBaseName.PasswordChar = '|';
            this.DataBaseName.Size = new System.Drawing.Size(142, 20);
            this.DataBaseName.TabIndex = 3;
            // 
            // DBServerName
            // 
            this.DBServerName.Location = new System.Drawing.Point(130, 59);
            this.DBServerName.Name = "DBServerName";
            this.DBServerName.Size = new System.Drawing.Size(142, 20);
            this.DBServerName.TabIndex = 2;
            this.DBServerName.Text = "localhost";
            // 
            // ScriptDir
            // 
            this.ScriptDir.Location = new System.Drawing.Point(130, 202);
            this.ScriptDir.Name = "ScriptDir";
            this.ScriptDir.ReadOnly = true;
            this.ScriptDir.Size = new System.Drawing.Size(158, 20);
            this.ScriptDir.TabIndex = 37;
            this.ScriptDir.TabStop = false;
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.Location = new System.Drawing.Point(11, 280);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(113, 13);
            this.lblPrinterName.TabIndex = 110;
            this.lblPrinterName.Text = "Printer";
            this.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWarningDir
            // 
            this.lblWarningDir.Location = new System.Drawing.Point(11, 255);
            this.lblWarningDir.Name = "lblWarningDir";
            this.lblWarningDir.Size = new System.Drawing.Size(113, 13);
            this.lblWarningDir.TabIndex = 109;
            this.lblWarningDir.Text = "Warning Log Directory";
            this.lblWarningDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblErrorDir
            // 
            this.lblErrorDir.Location = new System.Drawing.Point(11, 230);
            this.lblErrorDir.Name = "lblErrorDir";
            this.lblErrorDir.Size = new System.Drawing.Size(113, 13);
            this.lblErrorDir.TabIndex = 108;
            this.lblErrorDir.Text = "Error Log Directory";
            this.lblErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScriptDir
            // 
            this.lblScriptDir.Location = new System.Drawing.Point(11, 205);
            this.lblScriptDir.Name = "lblScriptDir";
            this.lblScriptDir.Size = new System.Drawing.Size(113, 13);
            this.lblScriptDir.TabIndex = 107;
            this.lblScriptDir.Text = "Script Log Directory";
            this.lblScriptDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.Location = new System.Drawing.Point(26, 140);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(98, 13);
            this.lblDBPassword.TabIndex = 105;
            this.lblDBPassword.Text = "Password";
            this.lblDBPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBUserName
            // 
            this.lblDBUserName.Location = new System.Drawing.Point(26, 114);
            this.lblDBUserName.Name = "lblDBUserName";
            this.lblDBUserName.Size = new System.Drawing.Size(98, 13);
            this.lblDBUserName.TabIndex = 104;
            this.lblDBUserName.Text = "User Name";
            this.lblDBUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.Location = new System.Drawing.Point(26, 88);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(98, 13);
            this.lblDataBaseName.TabIndex = 103;
            this.lblDataBaseName.Text = "DataBase Name";
            this.lblDataBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBServerName
            // 
            this.lblDBServerName.Location = new System.Drawing.Point(23, 62);
            this.lblDBServerName.Name = "lblDBServerName";
            this.lblDBServerName.Size = new System.Drawing.Size(97, 13);
            this.lblDBServerName.TabIndex = 101;
            this.lblDBServerName.Text = "Server Name";
            this.lblDBServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LDAPAuthenticated
            // 
            this.LDAPAuthenticated.AutoSize = true;
            this.LDAPAuthenticated.Location = new System.Drawing.Point(190, 308);
            this.LDAPAuthenticated.Name = "LDAPAuthenticated";
            this.LDAPAuthenticated.Size = new System.Drawing.Size(123, 17);
            this.LDAPAuthenticated.TabIndex = 115;
            this.LDAPAuthenticated.Text = "LDAP Authenticated";
            this.LDAPAuthenticated.UseVisualStyleBackColor = true;
            this.LDAPAuthenticated.CheckedChanged += new System.EventHandler(this.LDAPAuthenticated_CheckedChanged);
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 343);
            this.Controls.Add(this.grbEasyMove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsettings";
            this.Text = "Data Base and Directory Settings";
            this.Load += new System.EventHandler(this.frmsettings_Load);
            this.grbEasyMove.ResumeLayout(false);
            this.grbEasyMove.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEasyMove;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdEasyMoveWarningFolder;
        private System.Windows.Forms.Button cmdEasyMoveScriptFolder;
        private System.Windows.Forms.Button cmdEasyMoveErrFolder;
        private System.Windows.Forms.TextBox DBPort;
        private System.Windows.Forms.Label lblDBPort;
        private System.Windows.Forms.Button cmdSettingSave;
        private System.Windows.Forms.Button cmdSettingTest;
        private System.Windows.Forms.TextBox WarningDir;
        private System.Windows.Forms.TextBox ErrorDir;
        private System.Windows.Forms.TextBox DBPassword;
        private System.Windows.Forms.TextBox DBUserName;
        private System.Windows.Forms.TextBox DataBaseName;
        private System.Windows.Forms.TextBox DBServerName;
        private System.Windows.Forms.TextBox ScriptDir;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.Label lblWarningDir;
        private System.Windows.Forms.Label lblErrorDir;
        private System.Windows.Forms.Label lblScriptDir;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.Label lblDBUserName;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.Label lblDBServerName;
        private System.Windows.Forms.CheckBox LogChangeScripts;
        private System.Windows.Forms.Label lblDataBaseType;
        private System.Windows.Forms.ComboBox DataBaseType;
        private System.Windows.Forms.ComboBox PrinterName;
        private System.Windows.Forms.CheckBox LDAPAuthenticated;
    }
}