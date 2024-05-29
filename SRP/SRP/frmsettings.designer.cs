namespace SRP
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
            this.grbSRP = new System.Windows.Forms.GroupBox();
            this.cmbSRPDataBaseType = new System.Windows.Forms.ComboBox();
            this.lblSRPDataBaseType = new System.Windows.Forms.Label();
            this.ckSRPLogChangeScripts = new System.Windows.Forms.CheckBox();
            this.cmdSRPWarningFolder = new System.Windows.Forms.Button();
            this.txtSRPPort = new System.Windows.Forms.TextBox();
            this.cmdSRPScriptFolder = new System.Windows.Forms.Button();
            this.cmdSRPErrFolder = new System.Windows.Forms.Button();
            this.lblSRPPort = new System.Windows.Forms.Label();
            this.cmdSRPSettingSave = new System.Windows.Forms.Button();
            this.cmdSRPSettingTest = new System.Windows.Forms.Button();
            this.txtSRPWarningDir = new System.Windows.Forms.TextBox();
            this.txtSRPErrorDir = new System.Windows.Forms.TextBox();
            this.txtSRPPassword = new System.Windows.Forms.TextBox();
            this.txtSRPUserName = new System.Windows.Forms.TextBox();
            this.txtSRPDataBaseName = new System.Windows.Forms.TextBox();
            this.txtSRPServerName = new System.Windows.Forms.TextBox();
            this.txtSRPScriptDir = new System.Windows.Forms.TextBox();
            this.lblSRPPrinterList = new System.Windows.Forms.Label();
            this.lblSRPWarningDir = new System.Windows.Forms.Label();
            this.lblSRPErrorDir = new System.Windows.Forms.Label();
            this.lblSRPScriptDir = new System.Windows.Forms.Label();
            this.lblSRPPassword = new System.Windows.Forms.Label();
            this.lblSRPUserName = new System.Windows.Forms.Label();
            this.lblSRPDataBaseName = new System.Windows.Forms.Label();
            this.lblSRPServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmbSRPPrinterName = new System.Windows.Forms.ComboBox();
            this.grbSRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSRP
            // 
            this.grbSRP.Controls.Add(this.cmbSRPPrinterName);
            this.grbSRP.Controls.Add(this.cmbSRPDataBaseType);
            this.grbSRP.Controls.Add(this.lblSRPDataBaseType);
            this.grbSRP.Controls.Add(this.ckSRPLogChangeScripts);
            this.grbSRP.Controls.Add(this.cmdSRPWarningFolder);
            this.grbSRP.Controls.Add(this.txtSRPPort);
            this.grbSRP.Controls.Add(this.cmdSRPScriptFolder);
            this.grbSRP.Controls.Add(this.cmdSRPErrFolder);
            this.grbSRP.Controls.Add(this.lblSRPPort);
            this.grbSRP.Controls.Add(this.cmdSRPSettingSave);
            this.grbSRP.Controls.Add(this.cmdSRPSettingTest);
            this.grbSRP.Controls.Add(this.txtSRPWarningDir);
            this.grbSRP.Controls.Add(this.txtSRPErrorDir);
            this.grbSRP.Controls.Add(this.txtSRPPassword);
            this.grbSRP.Controls.Add(this.txtSRPUserName);
            this.grbSRP.Controls.Add(this.txtSRPDataBaseName);
            this.grbSRP.Controls.Add(this.txtSRPServerName);
            this.grbSRP.Controls.Add(this.txtSRPScriptDir);
            this.grbSRP.Controls.Add(this.lblSRPPrinterList);
            this.grbSRP.Controls.Add(this.lblSRPWarningDir);
            this.grbSRP.Controls.Add(this.lblSRPErrorDir);
            this.grbSRP.Controls.Add(this.lblSRPScriptDir);
            this.grbSRP.Controls.Add(this.lblSRPPassword);
            this.grbSRP.Controls.Add(this.lblSRPUserName);
            this.grbSRP.Controls.Add(this.lblSRPDataBaseName);
            this.grbSRP.Controls.Add(this.lblSRPServerName);
            this.grbSRP.Location = new System.Drawing.Point(2, 5);
            this.grbSRP.Name = "grbSRP";
            this.grbSRP.Size = new System.Drawing.Size(323, 379);
            this.grbSRP.TabIndex = 1;
            this.grbSRP.TabStop = false;
            this.grbSRP.Text = "Easy Move DataBase";
            // 
            // cmbSRPDataBaseType
            // 
            this.cmbSRPDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSRPDataBaseType.Enabled = false;
            this.cmbSRPDataBaseType.FormattingEnabled = true;
            this.cmbSRPDataBaseType.Items.AddRange(new object[] {
            "Oracle",
            "MySql"});
            this.cmbSRPDataBaseType.Location = new System.Drawing.Point(130, 34);
            this.cmbSRPDataBaseType.Name = "cmbSRPDataBaseType";
            this.cmbSRPDataBaseType.Size = new System.Drawing.Size(124, 21);
            this.cmbSRPDataBaseType.TabIndex = 46;
            // 
            // lblSRPDataBaseType
            // 
            this.lblSRPDataBaseType.Location = new System.Drawing.Point(11, 37);
            this.lblSRPDataBaseType.Name = "lblSRPDataBaseType";
            this.lblSRPDataBaseType.Size = new System.Drawing.Size(113, 13);
            this.lblSRPDataBaseType.TabIndex = 47;
            this.lblSRPDataBaseType.Text = "Data Base Type";
            this.lblSRPDataBaseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckSRPLogChangeScripts
            // 
            this.ckSRPLogChangeScripts.Checked = true;
            this.ckSRPLogChangeScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSRPLogChangeScripts.Location = new System.Drawing.Point(191, 298);
            this.ckSRPLogChangeScripts.Name = "ckSRPLogChangeScripts";
            this.ckSRPLogChangeScripts.Size = new System.Drawing.Size(126, 26);
            this.ckSRPLogChangeScripts.TabIndex = 46;
            this.ckSRPLogChangeScripts.Text = "Log Change Scripts";
            this.ckSRPLogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckSRPLogChangeScripts.UseVisualStyleBackColor = true;
            // 
            // cmdSRPWarningFolder
            // 
            this.cmdSRPWarningFolder.Location = new System.Drawing.Point(291, 251);
            this.cmdSRPWarningFolder.Name = "cmdSRPWarningFolder";
            this.cmdSRPWarningFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdSRPWarningFolder.TabIndex = 42;
            this.cmdSRPWarningFolder.Text = "...";
            this.cmdSRPWarningFolder.UseVisualStyleBackColor = true;
            this.cmdSRPWarningFolder.Click += new System.EventHandler(this.cmdSRPWarningFolder_Click);
            // 
            // txtSRPPort
            // 
            this.txtSRPPort.Location = new System.Drawing.Point(130, 164);
            this.txtSRPPort.Name = "txtSRPPort";
            this.txtSRPPort.Size = new System.Drawing.Size(69, 20);
            this.txtSRPPort.TabIndex = 36;
            // 
            // cmdSRPScriptFolder
            // 
            this.cmdSRPScriptFolder.Location = new System.Drawing.Point(291, 201);
            this.cmdSRPScriptFolder.Name = "cmdSRPScriptFolder";
            this.cmdSRPScriptFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdSRPScriptFolder.TabIndex = 38;
            this.cmdSRPScriptFolder.Text = "...";
            this.cmdSRPScriptFolder.UseVisualStyleBackColor = true;
            this.cmdSRPScriptFolder.Click += new System.EventHandler(this.cmdSRPScriptFolder_Click);
            // 
            // cmdSRPErrFolder
            // 
            this.cmdSRPErrFolder.Location = new System.Drawing.Point(291, 226);
            this.cmdSRPErrFolder.Name = "cmdSRPErrFolder";
            this.cmdSRPErrFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdSRPErrFolder.TabIndex = 40;
            this.cmdSRPErrFolder.Text = "...";
            this.cmdSRPErrFolder.UseVisualStyleBackColor = true;
            this.cmdSRPErrFolder.Click += new System.EventHandler(this.cmdSRPErrFolder_Click);
            // 
            // lblSRPPort
            // 
            this.lblSRPPort.Location = new System.Drawing.Point(20, 167);
            this.lblSRPPort.Name = "lblSRPPort";
            this.lblSRPPort.Size = new System.Drawing.Size(100, 17);
            this.lblSRPPort.TabIndex = 27;
            this.lblSRPPort.Text = "Port";
            this.lblSRPPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdSRPSettingSave
            // 
            this.cmdSRPSettingSave.Location = new System.Drawing.Point(7, 330);
            this.cmdSRPSettingSave.Name = "cmdSRPSettingSave";
            this.cmdSRPSettingSave.Size = new System.Drawing.Size(113, 23);
            this.cmdSRPSettingSave.TabIndex = 45;
            this.cmdSRPSettingSave.Text = "Save";
            this.cmdSRPSettingSave.UseVisualStyleBackColor = true;
            this.cmdSRPSettingSave.Click += new System.EventHandler(this.cmdSRPSettingSave_Click);
            // 
            // cmdSRPSettingTest
            // 
            this.cmdSRPSettingTest.Location = new System.Drawing.Point(198, 330);
            this.cmdSRPSettingTest.Name = "cmdSRPSettingTest";
            this.cmdSRPSettingTest.Size = new System.Drawing.Size(117, 23);
            this.cmdSRPSettingTest.TabIndex = 44;
            this.cmdSRPSettingTest.Text = "Test";
            this.cmdSRPSettingTest.UseVisualStyleBackColor = true;
            this.cmdSRPSettingTest.Click += new System.EventHandler(this.cmdSRPSettingTest_Click);
            // 
            // txtSRPWarningDir
            // 
            this.txtSRPWarningDir.Location = new System.Drawing.Point(130, 252);
            this.txtSRPWarningDir.Name = "txtSRPWarningDir";
            this.txtSRPWarningDir.ReadOnly = true;
            this.txtSRPWarningDir.Size = new System.Drawing.Size(158, 20);
            this.txtSRPWarningDir.TabIndex = 41;
            // 
            // txtSRPErrorDir
            // 
            this.txtSRPErrorDir.Location = new System.Drawing.Point(130, 227);
            this.txtSRPErrorDir.Name = "txtSRPErrorDir";
            this.txtSRPErrorDir.ReadOnly = true;
            this.txtSRPErrorDir.Size = new System.Drawing.Size(158, 20);
            this.txtSRPErrorDir.TabIndex = 39;
            // 
            // txtSRPPassword
            // 
            this.txtSRPPassword.Location = new System.Drawing.Point(130, 137);
            this.txtSRPPassword.Name = "txtSRPPassword";
            this.txtSRPPassword.PasswordChar = '*';
            this.txtSRPPassword.Size = new System.Drawing.Size(142, 20);
            this.txtSRPPassword.TabIndex = 35;
            // 
            // txtSRPUserName
            // 
            this.txtSRPUserName.Location = new System.Drawing.Point(130, 111);
            this.txtSRPUserName.Name = "txtSRPUserName";
            this.txtSRPUserName.Size = new System.Drawing.Size(142, 20);
            this.txtSRPUserName.TabIndex = 34;
            // 
            // txtSRPDataBaseName
            // 
            this.txtSRPDataBaseName.Location = new System.Drawing.Point(130, 85);
            this.txtSRPDataBaseName.Name = "txtSRPDataBaseName";
            this.txtSRPDataBaseName.Size = new System.Drawing.Size(142, 20);
            this.txtSRPDataBaseName.TabIndex = 33;
            // 
            // txtSRPServerName
            // 
            this.txtSRPServerName.Location = new System.Drawing.Point(130, 59);
            this.txtSRPServerName.Name = "txtSRPServerName";
            this.txtSRPServerName.Size = new System.Drawing.Size(142, 20);
            this.txtSRPServerName.TabIndex = 32;
            // 
            // txtSRPScriptDir
            // 
            this.txtSRPScriptDir.Location = new System.Drawing.Point(130, 202);
            this.txtSRPScriptDir.Name = "txtSRPScriptDir";
            this.txtSRPScriptDir.ReadOnly = true;
            this.txtSRPScriptDir.Size = new System.Drawing.Size(158, 20);
            this.txtSRPScriptDir.TabIndex = 37;
            // 
            // lblSRPPrinterList
            // 
            this.lblSRPPrinterList.Location = new System.Drawing.Point(11, 280);
            this.lblSRPPrinterList.Name = "lblSRPPrinterList";
            this.lblSRPPrinterList.Size = new System.Drawing.Size(113, 13);
            this.lblSRPPrinterList.TabIndex = 31;
            this.lblSRPPrinterList.Text = "Printer";
            this.lblSRPPrinterList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPWarningDir
            // 
            this.lblSRPWarningDir.Location = new System.Drawing.Point(11, 255);
            this.lblSRPWarningDir.Name = "lblSRPWarningDir";
            this.lblSRPWarningDir.Size = new System.Drawing.Size(113, 13);
            this.lblSRPWarningDir.TabIndex = 30;
            this.lblSRPWarningDir.Text = "Warning Log Directory";
            this.lblSRPWarningDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPErrorDir
            // 
            this.lblSRPErrorDir.Location = new System.Drawing.Point(11, 230);
            this.lblSRPErrorDir.Name = "lblSRPErrorDir";
            this.lblSRPErrorDir.Size = new System.Drawing.Size(113, 13);
            this.lblSRPErrorDir.TabIndex = 29;
            this.lblSRPErrorDir.Text = "Error Log Directory";
            this.lblSRPErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPScriptDir
            // 
            this.lblSRPScriptDir.Location = new System.Drawing.Point(11, 205);
            this.lblSRPScriptDir.Name = "lblSRPScriptDir";
            this.lblSRPScriptDir.Size = new System.Drawing.Size(113, 13);
            this.lblSRPScriptDir.TabIndex = 28;
            this.lblSRPScriptDir.Text = "Script Log Directory";
            this.lblSRPScriptDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPPassword
            // 
            this.lblSRPPassword.Location = new System.Drawing.Point(11, 140);
            this.lblSRPPassword.Name = "lblSRPPassword";
            this.lblSRPPassword.Size = new System.Drawing.Size(113, 13);
            this.lblSRPPassword.TabIndex = 26;
            this.lblSRPPassword.Text = "Password";
            this.lblSRPPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPUserName
            // 
            this.lblSRPUserName.Location = new System.Drawing.Point(11, 114);
            this.lblSRPUserName.Name = "lblSRPUserName";
            this.lblSRPUserName.Size = new System.Drawing.Size(113, 13);
            this.lblSRPUserName.TabIndex = 25;
            this.lblSRPUserName.Text = "User Name";
            this.lblSRPUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPDataBaseName
            // 
            this.lblSRPDataBaseName.Location = new System.Drawing.Point(11, 88);
            this.lblSRPDataBaseName.Name = "lblSRPDataBaseName";
            this.lblSRPDataBaseName.Size = new System.Drawing.Size(113, 13);
            this.lblSRPDataBaseName.TabIndex = 24;
            this.lblSRPDataBaseName.Text = "DataBase Name";
            this.lblSRPDataBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSRPServerName
            // 
            this.lblSRPServerName.Location = new System.Drawing.Point(7, 62);
            this.lblSRPServerName.Name = "lblSRPServerName";
            this.lblSRPServerName.Size = new System.Drawing.Size(113, 13);
            this.lblSRPServerName.TabIndex = 23;
            this.lblSRPServerName.Text = "Server Name";
            this.lblSRPServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSRPPrinterName
            // 
            this.cmbSRPPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSRPPrinterName.FormattingEnabled = true;
            this.cmbSRPPrinterName.Location = new System.Drawing.Point(130, 279);
            this.cmbSRPPrinterName.Name = "cmbSRPPrinterName";
            this.cmbSRPPrinterName.Size = new System.Drawing.Size(183, 21);
            this.cmbSRPPrinterName.TabIndex = 48;
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 388);
            this.Controls.Add(this.grbSRP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsettings";
            this.Text = "Data Base and Directory Settings";
            this.Load += new System.EventHandler(this.frmsettings_Load);
            this.grbSRP.ResumeLayout(false);
            this.grbSRP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSRP;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdSRPWarningFolder;
        private System.Windows.Forms.Button cmdSRPScriptFolder;
        private System.Windows.Forms.Button cmdSRPErrFolder;
        private System.Windows.Forms.TextBox txtSRPPort;
        private System.Windows.Forms.Label lblSRPPort;
        private System.Windows.Forms.Button cmdSRPSettingSave;
        private System.Windows.Forms.Button cmdSRPSettingTest;
        private System.Windows.Forms.TextBox txtSRPWarningDir;
        private System.Windows.Forms.TextBox txtSRPErrorDir;
        private System.Windows.Forms.TextBox txtSRPPassword;
        private System.Windows.Forms.TextBox txtSRPUserName;
        private System.Windows.Forms.TextBox txtSRPDataBaseName;
        private System.Windows.Forms.TextBox txtSRPServerName;
        private System.Windows.Forms.TextBox txtSRPScriptDir;
        private System.Windows.Forms.Label lblSRPPrinterList;
        private System.Windows.Forms.Label lblSRPWarningDir;
        private System.Windows.Forms.Label lblSRPErrorDir;
        private System.Windows.Forms.Label lblSRPScriptDir;
        private System.Windows.Forms.Label lblSRPPassword;
        private System.Windows.Forms.Label lblSRPUserName;
        private System.Windows.Forms.Label lblSRPDataBaseName;
        private System.Windows.Forms.Label lblSRPServerName;
        private System.Windows.Forms.CheckBox ckSRPLogChangeScripts;
        private System.Windows.Forms.Label lblSRPDataBaseType;
        private System.Windows.Forms.ComboBox cmbSRPDataBaseType;
        private System.Windows.Forms.ComboBox cmbSRPPrinterName;
    }
}