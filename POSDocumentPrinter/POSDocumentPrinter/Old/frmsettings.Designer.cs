namespace POSDocumentPrinter
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
            this.grbPOS = new System.Windows.Forms.GroupBox();
            this.cmbPOSPrinterNameList = new System.Windows.Forms.ComboBox();
            this.ckPOSAutoStartSynch = new System.Windows.Forms.CheckBox();
            this.cmbPOSDataBaseType = new System.Windows.Forms.ComboBox();
            this.lblPOSDataBaseType = new System.Windows.Forms.Label();
            this.ckPOSLogChangeScripts = new System.Windows.Forms.CheckBox();
            this.cmdPOSWarningFolder = new System.Windows.Forms.Button();
            this.txtPOSPort = new System.Windows.Forms.TextBox();
            this.cmdPOSScriptFolder = new System.Windows.Forms.Button();
            this.cmdPOSErrFolder = new System.Windows.Forms.Button();
            this.lblPOSPort = new System.Windows.Forms.Label();
            this.cmdPOSSettingSave = new System.Windows.Forms.Button();
            this.cmdPOSSettingTest = new System.Windows.Forms.Button();
            this.txtPOSWarningDir = new System.Windows.Forms.TextBox();
            this.txtPOSErrorDir = new System.Windows.Forms.TextBox();
            this.txtPOSPassword = new System.Windows.Forms.TextBox();
            this.txtPOSUserName = new System.Windows.Forms.TextBox();
            this.txtPOSDataBaseName = new System.Windows.Forms.TextBox();
            this.txtPOSServerName = new System.Windows.Forms.TextBox();
            this.txtPOSScriptDir = new System.Windows.Forms.TextBox();
            this.lblPOSDefaultPrinter = new System.Windows.Forms.Label();
            this.lblPOSWarningDir = new System.Windows.Forms.Label();
            this.lblPOSErrorDir = new System.Windows.Forms.Label();
            this.lblPOSScriptDir = new System.Windows.Forms.Label();
            this.lblPOSPassword = new System.Windows.Forms.Label();
            this.lblPOSUserName = new System.Windows.Forms.Label();
            this.lblPOSDataBaseName = new System.Windows.Forms.Label();
            this.lblPOSServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grbPOS.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPOS
            // 
            this.grbPOS.Controls.Add(this.cmbPOSPrinterNameList);
            this.grbPOS.Controls.Add(this.ckPOSAutoStartSynch);
            this.grbPOS.Controls.Add(this.cmbPOSDataBaseType);
            this.grbPOS.Controls.Add(this.lblPOSDataBaseType);
            this.grbPOS.Controls.Add(this.ckPOSLogChangeScripts);
            this.grbPOS.Controls.Add(this.cmdPOSWarningFolder);
            this.grbPOS.Controls.Add(this.txtPOSPort);
            this.grbPOS.Controls.Add(this.cmdPOSScriptFolder);
            this.grbPOS.Controls.Add(this.cmdPOSErrFolder);
            this.grbPOS.Controls.Add(this.lblPOSPort);
            this.grbPOS.Controls.Add(this.cmdPOSSettingSave);
            this.grbPOS.Controls.Add(this.cmdPOSSettingTest);
            this.grbPOS.Controls.Add(this.txtPOSWarningDir);
            this.grbPOS.Controls.Add(this.txtPOSErrorDir);
            this.grbPOS.Controls.Add(this.txtPOSPassword);
            this.grbPOS.Controls.Add(this.txtPOSUserName);
            this.grbPOS.Controls.Add(this.txtPOSDataBaseName);
            this.grbPOS.Controls.Add(this.txtPOSServerName);
            this.grbPOS.Controls.Add(this.txtPOSScriptDir);
            this.grbPOS.Controls.Add(this.lblPOSDefaultPrinter);
            this.grbPOS.Controls.Add(this.lblPOSWarningDir);
            this.grbPOS.Controls.Add(this.lblPOSErrorDir);
            this.grbPOS.Controls.Add(this.lblPOSScriptDir);
            this.grbPOS.Controls.Add(this.lblPOSPassword);
            this.grbPOS.Controls.Add(this.lblPOSUserName);
            this.grbPOS.Controls.Add(this.lblPOSDataBaseName);
            this.grbPOS.Controls.Add(this.lblPOSServerName);
            this.grbPOS.Location = new System.Drawing.Point(2, 3);
            this.grbPOS.Name = "grbPOS";
            this.grbPOS.Size = new System.Drawing.Size(323, 379);
            this.grbPOS.TabIndex = 1;
            this.grbPOS.TabStop = false;
            this.grbPOS.Text = "POS DataBase";
            // 
            // cmbPOSPrinterNameList
            // 
            this.cmbPOSPrinterNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSPrinterNameList.DropDownWidth = 220;
            this.cmbPOSPrinterNameList.FormattingEnabled = true;
            this.cmbPOSPrinterNameList.Location = new System.Drawing.Point(131, 276);
            this.cmbPOSPrinterNameList.Name = "cmbPOSPrinterNameList";
            this.cmbPOSPrinterNameList.Size = new System.Drawing.Size(184, 21);
            this.cmbPOSPrinterNameList.TabIndex = 49;
            // 
            // ckPOSAutoStartSynch
            // 
            this.ckPOSAutoStartSynch.AutoSize = true;
            this.ckPOSAutoStartSynch.Location = new System.Drawing.Point(58, 303);
            this.ckPOSAutoStartSynch.Name = "ckPOSAutoStartSynch";
            this.ckPOSAutoStartSynch.Size = new System.Drawing.Size(106, 17);
            this.ckPOSAutoStartSynch.TabIndex = 48;
            this.ckPOSAutoStartSynch.Text = "Auto Start Synch";
            this.ckPOSAutoStartSynch.UseVisualStyleBackColor = true;
            this.ckPOSAutoStartSynch.Visible = false;
            // 
            // cmbPOSDataBaseType
            // 
            this.cmbPOSDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSDataBaseType.Enabled = false;
            this.cmbPOSDataBaseType.FormattingEnabled = true;
            this.cmbPOSDataBaseType.Items.AddRange(new object[] {
            "Oracle",
            "MySql"});
            this.cmbPOSDataBaseType.Location = new System.Drawing.Point(130, 34);
            this.cmbPOSDataBaseType.Name = "cmbPOSDataBaseType";
            this.cmbPOSDataBaseType.Size = new System.Drawing.Size(124, 21);
            this.cmbPOSDataBaseType.TabIndex = 46;
            // 
            // lblPOSDataBaseType
            // 
            this.lblPOSDataBaseType.Location = new System.Drawing.Point(11, 37);
            this.lblPOSDataBaseType.Name = "lblPOSDataBaseType";
            this.lblPOSDataBaseType.Size = new System.Drawing.Size(113, 13);
            this.lblPOSDataBaseType.TabIndex = 47;
            this.lblPOSDataBaseType.Text = "Data Base Type";
            this.lblPOSDataBaseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckPOSLogChangeScripts
            // 
            this.ckPOSLogChangeScripts.Location = new System.Drawing.Point(191, 298);
            this.ckPOSLogChangeScripts.Name = "ckPOSLogChangeScripts";
            this.ckPOSLogChangeScripts.Size = new System.Drawing.Size(126, 26);
            this.ckPOSLogChangeScripts.TabIndex = 46;
            this.ckPOSLogChangeScripts.Text = "Log Change Scripts";
            this.ckPOSLogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckPOSLogChangeScripts.UseVisualStyleBackColor = true;
            this.ckPOSLogChangeScripts.Visible = false;
            // 
            // cmdPOSWarningFolder
            // 
            this.cmdPOSWarningFolder.Location = new System.Drawing.Point(291, 251);
            this.cmdPOSWarningFolder.Name = "cmdPOSWarningFolder";
            this.cmdPOSWarningFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdPOSWarningFolder.TabIndex = 42;
            this.cmdPOSWarningFolder.Text = "...";
            this.cmdPOSWarningFolder.UseVisualStyleBackColor = true;
            this.cmdPOSWarningFolder.Click += new System.EventHandler(this.cmdPOSWarningFolder_Click);
            // 
            // txtPOSPort
            // 
            this.txtPOSPort.Location = new System.Drawing.Point(130, 164);
            this.txtPOSPort.Name = "txtPOSPort";
            this.txtPOSPort.Size = new System.Drawing.Size(69, 20);
            this.txtPOSPort.TabIndex = 36;
            // 
            // cmdPOSScriptFolder
            // 
            this.cmdPOSScriptFolder.Location = new System.Drawing.Point(291, 201);
            this.cmdPOSScriptFolder.Name = "cmdPOSScriptFolder";
            this.cmdPOSScriptFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdPOSScriptFolder.TabIndex = 38;
            this.cmdPOSScriptFolder.Text = "...";
            this.cmdPOSScriptFolder.UseVisualStyleBackColor = true;
            this.cmdPOSScriptFolder.Click += new System.EventHandler(this.cmdPOSScriptFolder_Click);
            // 
            // cmdPOSErrFolder
            // 
            this.cmdPOSErrFolder.Location = new System.Drawing.Point(291, 226);
            this.cmdPOSErrFolder.Name = "cmdPOSErrFolder";
            this.cmdPOSErrFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdPOSErrFolder.TabIndex = 40;
            this.cmdPOSErrFolder.Text = "...";
            this.cmdPOSErrFolder.UseVisualStyleBackColor = true;
            this.cmdPOSErrFolder.Click += new System.EventHandler(this.cmdPOSErrFolder_Click);
            // 
            // lblPOSPort
            // 
            this.lblPOSPort.Location = new System.Drawing.Point(20, 167);
            this.lblPOSPort.Name = "lblPOSPort";
            this.lblPOSPort.Size = new System.Drawing.Size(100, 17);
            this.lblPOSPort.TabIndex = 27;
            this.lblPOSPort.Text = "Port";
            this.lblPOSPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdPOSSettingSave
            // 
            this.cmdPOSSettingSave.Location = new System.Drawing.Point(7, 330);
            this.cmdPOSSettingSave.Name = "cmdPOSSettingSave";
            this.cmdPOSSettingSave.Size = new System.Drawing.Size(113, 23);
            this.cmdPOSSettingSave.TabIndex = 45;
            this.cmdPOSSettingSave.Text = "Save";
            this.cmdPOSSettingSave.UseVisualStyleBackColor = true;
            this.cmdPOSSettingSave.Click += new System.EventHandler(this.cmdPOSSettingSave_Click);
            // 
            // cmdPOSSettingTest
            // 
            this.cmdPOSSettingTest.Location = new System.Drawing.Point(198, 330);
            this.cmdPOSSettingTest.Name = "cmdPOSSettingTest";
            this.cmdPOSSettingTest.Size = new System.Drawing.Size(117, 23);
            this.cmdPOSSettingTest.TabIndex = 44;
            this.cmdPOSSettingTest.Text = "Test";
            this.cmdPOSSettingTest.UseVisualStyleBackColor = true;
            this.cmdPOSSettingTest.Click += new System.EventHandler(this.cmdPOSSettingTest_Click);
            // 
            // txtPOSWarningDir
            // 
            this.txtPOSWarningDir.Location = new System.Drawing.Point(130, 252);
            this.txtPOSWarningDir.Name = "txtPOSWarningDir";
            this.txtPOSWarningDir.ReadOnly = true;
            this.txtPOSWarningDir.Size = new System.Drawing.Size(158, 20);
            this.txtPOSWarningDir.TabIndex = 41;
            // 
            // txtPOSErrorDir
            // 
            this.txtPOSErrorDir.Location = new System.Drawing.Point(130, 227);
            this.txtPOSErrorDir.Name = "txtPOSErrorDir";
            this.txtPOSErrorDir.ReadOnly = true;
            this.txtPOSErrorDir.Size = new System.Drawing.Size(158, 20);
            this.txtPOSErrorDir.TabIndex = 39;
            // 
            // txtPOSPassword
            // 
            this.txtPOSPassword.Location = new System.Drawing.Point(130, 137);
            this.txtPOSPassword.Name = "txtPOSPassword";
            this.txtPOSPassword.PasswordChar = '*';
            this.txtPOSPassword.Size = new System.Drawing.Size(142, 20);
            this.txtPOSPassword.TabIndex = 35;
            // 
            // txtPOSUserName
            // 
            this.txtPOSUserName.Location = new System.Drawing.Point(130, 111);
            this.txtPOSUserName.Name = "txtPOSUserName";
            this.txtPOSUserName.Size = new System.Drawing.Size(142, 20);
            this.txtPOSUserName.TabIndex = 34;
            // 
            // txtPOSDataBaseName
            // 
            this.txtPOSDataBaseName.Location = new System.Drawing.Point(130, 85);
            this.txtPOSDataBaseName.Name = "txtPOSDataBaseName";
            this.txtPOSDataBaseName.Size = new System.Drawing.Size(142, 20);
            this.txtPOSDataBaseName.TabIndex = 33;
            // 
            // txtPOSServerName
            // 
            this.txtPOSServerName.Location = new System.Drawing.Point(130, 59);
            this.txtPOSServerName.Name = "txtPOSServerName";
            this.txtPOSServerName.Size = new System.Drawing.Size(142, 20);
            this.txtPOSServerName.TabIndex = 32;
            // 
            // txtPOSScriptDir
            // 
            this.txtPOSScriptDir.Location = new System.Drawing.Point(130, 202);
            this.txtPOSScriptDir.Name = "txtPOSScriptDir";
            this.txtPOSScriptDir.ReadOnly = true;
            this.txtPOSScriptDir.Size = new System.Drawing.Size(158, 20);
            this.txtPOSScriptDir.TabIndex = 37;
            // 
            // lblPOSDefaultPrinter
            // 
            this.lblPOSDefaultPrinter.Location = new System.Drawing.Point(11, 280);
            this.lblPOSDefaultPrinter.Name = "lblPOSDefaultPrinter";
            this.lblPOSDefaultPrinter.Size = new System.Drawing.Size(113, 13);
            this.lblPOSDefaultPrinter.TabIndex = 31;
            this.lblPOSDefaultPrinter.Text = "Printer Name";
            this.lblPOSDefaultPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSWarningDir
            // 
            this.lblPOSWarningDir.Location = new System.Drawing.Point(11, 255);
            this.lblPOSWarningDir.Name = "lblPOSWarningDir";
            this.lblPOSWarningDir.Size = new System.Drawing.Size(113, 13);
            this.lblPOSWarningDir.TabIndex = 30;
            this.lblPOSWarningDir.Text = "Warning Log Directory";
            this.lblPOSWarningDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSErrorDir
            // 
            this.lblPOSErrorDir.Location = new System.Drawing.Point(11, 230);
            this.lblPOSErrorDir.Name = "lblPOSErrorDir";
            this.lblPOSErrorDir.Size = new System.Drawing.Size(113, 13);
            this.lblPOSErrorDir.TabIndex = 29;
            this.lblPOSErrorDir.Text = "Error Log Directory";
            this.lblPOSErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSScriptDir
            // 
            this.lblPOSScriptDir.Location = new System.Drawing.Point(11, 205);
            this.lblPOSScriptDir.Name = "lblPOSScriptDir";
            this.lblPOSScriptDir.Size = new System.Drawing.Size(113, 13);
            this.lblPOSScriptDir.TabIndex = 28;
            this.lblPOSScriptDir.Text = "Script Log Directory";
            this.lblPOSScriptDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSPassword
            // 
            this.lblPOSPassword.Location = new System.Drawing.Point(11, 140);
            this.lblPOSPassword.Name = "lblPOSPassword";
            this.lblPOSPassword.Size = new System.Drawing.Size(113, 13);
            this.lblPOSPassword.TabIndex = 26;
            this.lblPOSPassword.Text = "Password";
            this.lblPOSPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSUserName
            // 
            this.lblPOSUserName.Location = new System.Drawing.Point(11, 114);
            this.lblPOSUserName.Name = "lblPOSUserName";
            this.lblPOSUserName.Size = new System.Drawing.Size(113, 13);
            this.lblPOSUserName.TabIndex = 25;
            this.lblPOSUserName.Text = "User Name";
            this.lblPOSUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSDataBaseName
            // 
            this.lblPOSDataBaseName.Location = new System.Drawing.Point(11, 88);
            this.lblPOSDataBaseName.Name = "lblPOSDataBaseName";
            this.lblPOSDataBaseName.Size = new System.Drawing.Size(113, 13);
            this.lblPOSDataBaseName.TabIndex = 24;
            this.lblPOSDataBaseName.Text = "DataBase Name";
            this.lblPOSDataBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSServerName
            // 
            this.lblPOSServerName.Location = new System.Drawing.Point(7, 62);
            this.lblPOSServerName.Name = "lblPOSServerName";
            this.lblPOSServerName.Size = new System.Drawing.Size(113, 13);
            this.lblPOSServerName.TabIndex = 23;
            this.lblPOSServerName.Text = "Server Name";
            this.lblPOSServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 388);
            this.Controls.Add(this.grbPOS);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsettings";
            this.Text = "Data Base and Directory Settings";
            this.Load += new System.EventHandler(this.frmsettings_Load);
            this.grbPOS.ResumeLayout(false);
            this.grbPOS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPOS;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdPOSWarningFolder;
        private System.Windows.Forms.Button cmdPOSScriptFolder;
        private System.Windows.Forms.Button cmdPOSErrFolder;
        private System.Windows.Forms.TextBox txtPOSPort;
        private System.Windows.Forms.Label lblPOSPort;
        private System.Windows.Forms.Button cmdPOSSettingSave;
        private System.Windows.Forms.Button cmdPOSSettingTest;
        private System.Windows.Forms.TextBox txtPOSWarningDir;
        private System.Windows.Forms.TextBox txtPOSErrorDir;
        private System.Windows.Forms.TextBox txtPOSPassword;
        private System.Windows.Forms.TextBox txtPOSUserName;
        private System.Windows.Forms.TextBox txtPOSDataBaseName;
        private System.Windows.Forms.TextBox txtPOSServerName;
        private System.Windows.Forms.TextBox txtPOSScriptDir;
        private System.Windows.Forms.Label lblPOSDefaultPrinter;
        private System.Windows.Forms.Label lblPOSWarningDir;
        private System.Windows.Forms.Label lblPOSErrorDir;
        private System.Windows.Forms.Label lblPOSScriptDir;
        private System.Windows.Forms.Label lblPOSPassword;
        private System.Windows.Forms.Label lblPOSUserName;
        private System.Windows.Forms.Label lblPOSDataBaseName;
        private System.Windows.Forms.Label lblPOSServerName;
        private System.Windows.Forms.CheckBox ckPOSLogChangeScripts;
        private System.Windows.Forms.Label lblPOSDataBaseType;
        private System.Windows.Forms.ComboBox cmbPOSDataBaseType;
        private System.Windows.Forms.CheckBox ckPOSAutoStartSynch;
        private System.Windows.Forms.ComboBox cmbPOSPrinterNameList;
    }
}