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
            this.txtMapDataTiming = new System.Windows.Forms.TextBox();
            this.txtWarningDir = new System.Windows.Forms.TextBox();
            this.txtErrorDir = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtScriptDir = new System.Windows.Forms.TextBox();
            this.lblMapDataTiming = new System.Windows.Forms.Label();
            this.lblWarningDir = new System.Windows.Forms.Label();
            this.lblErrorDir = new System.Windows.Forms.Label();
            this.lblScriptDir = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grbCompiere.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCompiere
            // 
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
            this.grbCompiere.Controls.Add(this.txtMapDataTiming);
            this.grbCompiere.Controls.Add(this.txtWarningDir);
            this.grbCompiere.Controls.Add(this.txtErrorDir);
            this.grbCompiere.Controls.Add(this.txtPassword);
            this.grbCompiere.Controls.Add(this.txtUserName);
            this.grbCompiere.Controls.Add(this.txtDataBaseName);
            this.grbCompiere.Controls.Add(this.txtServerName);
            this.grbCompiere.Controls.Add(this.txtScriptDir);
            this.grbCompiere.Controls.Add(this.lblMapDataTiming);
            this.grbCompiere.Controls.Add(this.lblWarningDir);
            this.grbCompiere.Controls.Add(this.lblErrorDir);
            this.grbCompiere.Controls.Add(this.lblScriptDir);
            this.grbCompiere.Controls.Add(this.lblPassword);
            this.grbCompiere.Controls.Add(this.lblUserName);
            this.grbCompiere.Controls.Add(this.lblDataBaseName);
            this.grbCompiere.Controls.Add(this.lblServerName);
            this.grbCompiere.Location = new System.Drawing.Point(3, 3);
            this.grbCompiere.Name = "grbCompiere";
            this.grbCompiere.Size = new System.Drawing.Size(323, 393);
            this.grbCompiere.TabIndex = 0;
            this.grbCompiere.TabStop = false;
            this.grbCompiere.Text = "Compiere DataBase";
            // 
            // cmbPrinterName
            // 
            this.cmbPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterName.FormattingEnabled = true;
            this.cmbPrinterName.Location = new System.Drawing.Point(132, 298);
            this.cmbPrinterName.Name = "cmbPrinterName";
            this.cmbPrinterName.Size = new System.Drawing.Size(183, 21);
            this.cmbPrinterName.TabIndex = 50;
            // 
            // lblPrinterList
            // 
            this.lblPrinterList.Location = new System.Drawing.Point(9, 303);
            this.lblPrinterList.Name = "lblPrinterList";
            this.lblPrinterList.Size = new System.Drawing.Size(113, 13);
            this.lblPrinterList.TabIndex = 49;
            this.lblPrinterList.Text = "Printer";
            this.lblPrinterList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(132, 164);
            this.txtPort.Name = "txtPort";
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
            this.ckLogChangeScripts.Location = new System.Drawing.Point(185, 324);
            this.ckLogChangeScripts.Name = "ckLogChangeScripts";
            this.ckLogChangeScripts.Size = new System.Drawing.Size(132, 26);
            this.ckLogChangeScripts.TabIndex = 23;
            this.ckLogChangeScripts.Text = "Log Change Scripts";
            this.ckLogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmdSettingSave.Location = new System.Drawing.Point(9, 356);
            this.cmdSettingSave.Name = "cmdSettingSave";
            this.cmdSettingSave.Size = new System.Drawing.Size(113, 23);
            this.cmdSettingSave.TabIndex = 22;
            this.cmdSettingSave.Text = "Save";
            this.cmdSettingSave.UseVisualStyleBackColor = true;
            this.cmdSettingSave.Click += new System.EventHandler(this.cmdSettingSave_Click);
            // 
            // cmdSettingTest
            // 
            this.cmdSettingTest.Location = new System.Drawing.Point(200, 356);
            this.cmdSettingTest.Name = "cmdSettingTest";
            this.cmdSettingTest.Size = new System.Drawing.Size(117, 23);
            this.cmdSettingTest.TabIndex = 21;
            this.cmdSettingTest.Text = "Test";
            this.cmdSettingTest.UseVisualStyleBackColor = true;
            this.cmdSettingTest.Click += new System.EventHandler(this.cmdSettingTest_Click);
            // 
            // txtMapDataTiming
            // 
            this.txtMapDataTiming.Location = new System.Drawing.Point(132, 272);
            this.txtMapDataTiming.Name = "txtMapDataTiming";
            this.txtMapDataTiming.Size = new System.Drawing.Size(79, 20);
            this.txtMapDataTiming.TabIndex = 20;
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
            this.txtUserName.Size = new System.Drawing.Size(142, 20);
            this.txtUserName.TabIndex = 12;
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(132, 82);
            this.txtDataBaseName.Name = "txtDataBaseName";
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
            // lblMapDataTiming
            // 
            this.lblMapDataTiming.Location = new System.Drawing.Point(9, 275);
            this.lblMapDataTiming.Name = "lblMapDataTiming";
            this.lblMapDataTiming.Size = new System.Drawing.Size(113, 13);
            this.lblMapDataTiming.TabIndex = 7;
            this.lblMapDataTiming.Text = "Map Data Every (min.)";
            this.lblMapDataTiming.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 400);
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
        private System.Windows.Forms.Label lblMapDataTiming;
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
        private System.Windows.Forms.TextBox txtMapDataTiming;
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
    }
}