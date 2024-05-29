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
            this.cmdDataFileLocation = new System.Windows.Forms.Button();
            this.txtDBPort = new System.Windows.Forms.TextBox();
            this.lblDBPort = new System.Windows.Forms.Label();
            this.cmbDBType = new System.Windows.Forms.ComboBox();
            this.lblDBType = new System.Windows.Forms.Label();
            this.ckDBLogChangeScripts = new System.Windows.Forms.CheckBox();
            this.cmdDBErrFolder = new System.Windows.Forms.Button();
            this.cmdDBWarningFolder = new System.Windows.Forms.Button();
            this.cmdDBScriptFolder = new System.Windows.Forms.Button();
            this.cmdDBSettingSave = new System.Windows.Forms.Button();
            this.cmdDBSettingTest = new System.Windows.Forms.Button();
            this.txtDBMapDataTiming = new System.Windows.Forms.TextBox();
            this.txtDBWarningDir = new System.Windows.Forms.TextBox();
            this.txtDBErrorDir = new System.Windows.Forms.TextBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtDBServerName = new System.Windows.Forms.TextBox();
            this.txtDBScriptDir = new System.Windows.Forms.TextBox();
            this.lblDBMapDataTiming = new System.Windows.Forms.Label();
            this.lblDBWarningDir = new System.Windows.Forms.Label();
            this.lblDBErrorDir = new System.Windows.Forms.Label();
            this.lblDBScriptDir = new System.Windows.Forms.Label();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.lblDBUserName = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblDBServerName = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbCompiere.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCompiere
            // 
            this.grbCompiere.Controls.Add(this.cmdDataFileLocation);
            this.grbCompiere.Controls.Add(this.txtDBPort);
            this.grbCompiere.Controls.Add(this.lblDBPort);
            this.grbCompiere.Controls.Add(this.cmbDBType);
            this.grbCompiere.Controls.Add(this.lblDBType);
            this.grbCompiere.Controls.Add(this.ckDBLogChangeScripts);
            this.grbCompiere.Controls.Add(this.cmdDBErrFolder);
            this.grbCompiere.Controls.Add(this.cmdDBWarningFolder);
            this.grbCompiere.Controls.Add(this.cmdDBScriptFolder);
            this.grbCompiere.Controls.Add(this.cmdDBSettingSave);
            this.grbCompiere.Controls.Add(this.cmdDBSettingTest);
            this.grbCompiere.Controls.Add(this.txtDBMapDataTiming);
            this.grbCompiere.Controls.Add(this.txtDBWarningDir);
            this.grbCompiere.Controls.Add(this.txtDBErrorDir);
            this.grbCompiere.Controls.Add(this.txtDBPassword);
            this.grbCompiere.Controls.Add(this.txtDBUserName);
            this.grbCompiere.Controls.Add(this.txtDBName);
            this.grbCompiere.Controls.Add(this.txtDBServerName);
            this.grbCompiere.Controls.Add(this.txtDBScriptDir);
            this.grbCompiere.Controls.Add(this.lblDBMapDataTiming);
            this.grbCompiere.Controls.Add(this.lblDBWarningDir);
            this.grbCompiere.Controls.Add(this.lblDBErrorDir);
            this.grbCompiere.Controls.Add(this.lblDBScriptDir);
            this.grbCompiere.Controls.Add(this.lblDBPassword);
            this.grbCompiere.Controls.Add(this.lblDBUserName);
            this.grbCompiere.Controls.Add(this.lblDBName);
            this.grbCompiere.Controls.Add(this.lblDBServerName);
            this.grbCompiere.Location = new System.Drawing.Point(3, 3);
            this.grbCompiere.Name = "grbCompiere";
            this.grbCompiere.Size = new System.Drawing.Size(323, 364);
            this.grbCompiere.TabIndex = 0;
            this.grbCompiere.TabStop = false;
            this.grbCompiere.Text = "Compiere DataBase";
            // 
            // cmdDataFileLocation
            // 
            this.cmdDataFileLocation.Location = new System.Drawing.Point(280, 82);
            this.cmdDataFileLocation.Name = "cmdDataFileLocation";
            this.cmdDataFileLocation.Size = new System.Drawing.Size(26, 20);
            this.cmdDataFileLocation.TabIndex = 49;
            this.cmdDataFileLocation.Text = "...";
            this.cmdDataFileLocation.UseVisualStyleBackColor = true;
            this.cmdDataFileLocation.Click += new System.EventHandler(this.cmdDataFileLocation_Click);
            // 
            // txtDBPort
            // 
            this.txtDBPort.Location = new System.Drawing.Point(132, 164);
            this.txtDBPort.Name = "txtDBPort";
            this.txtDBPort.Size = new System.Drawing.Size(69, 20);
            this.txtDBPort.TabIndex = 14;
            // 
            // lblDBPort
            // 
            this.lblDBPort.Location = new System.Drawing.Point(26, 167);
            this.lblDBPort.Name = "lblDBPort";
            this.lblDBPort.Size = new System.Drawing.Size(100, 13);
            this.lblDBPort.TabIndex = 48;
            this.lblDBPort.Text = "Port";
            this.lblDBPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDBType
            // 
            this.cmbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBType.FormattingEnabled = true;
            this.cmbDBType.Location = new System.Drawing.Point(132, 29);
            this.cmbDBType.Name = "cmbDBType";
            this.cmbDBType.Size = new System.Drawing.Size(124, 21);
            this.cmbDBType.Sorted = true;
            this.cmbDBType.TabIndex = 47;
            this.cmbDBType.SelectedIndexChanged += new System.EventHandler(this.cmbDBType_SelectedIndexChanged);
            // 
            // lblDBType
            // 
            this.lblDBType.Location = new System.Drawing.Point(13, 33);
            this.lblDBType.Name = "lblDBType";
            this.lblDBType.Size = new System.Drawing.Size(113, 13);
            this.lblDBType.TabIndex = 24;
            this.lblDBType.Text = "Data Base Type";
            this.lblDBType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckDBLogChangeScripts
            // 
            this.ckDBLogChangeScripts.Checked = true;
            this.ckDBLogChangeScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDBLogChangeScripts.Location = new System.Drawing.Point(185, 303);
            this.ckDBLogChangeScripts.Name = "ckDBLogChangeScripts";
            this.ckDBLogChangeScripts.Size = new System.Drawing.Size(132, 17);
            this.ckDBLogChangeScripts.TabIndex = 23;
            this.ckDBLogChangeScripts.Text = "Log Change Scripts";
            this.ckDBLogChangeScripts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDBLogChangeScripts.UseVisualStyleBackColor = true;
            // 
            // cmdDBErrFolder
            // 
            this.cmdDBErrFolder.Location = new System.Drawing.Point(291, 222);
            this.cmdDBErrFolder.Name = "cmdDBErrFolder";
            this.cmdDBErrFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdDBErrFolder.TabIndex = 18;
            this.cmdDBErrFolder.Text = "...";
            this.cmdDBErrFolder.UseVisualStyleBackColor = true;
            this.cmdDBErrFolder.Click += new System.EventHandler(this.cmdDBErrFolder_Click);
            // 
            // cmdDBWarningFolder
            // 
            this.cmdDBWarningFolder.Location = new System.Drawing.Point(291, 247);
            this.cmdDBWarningFolder.Name = "cmdDBWarningFolder";
            this.cmdDBWarningFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdDBWarningFolder.TabIndex = 20;
            this.cmdDBWarningFolder.Text = "...";
            this.cmdDBWarningFolder.UseVisualStyleBackColor = true;
            this.cmdDBWarningFolder.Click += new System.EventHandler(this.cmdDBWarningFolder_Click);
            // 
            // cmdDBScriptFolder
            // 
            this.cmdDBScriptFolder.Location = new System.Drawing.Point(291, 198);
            this.cmdDBScriptFolder.Name = "cmdDBScriptFolder";
            this.cmdDBScriptFolder.Size = new System.Drawing.Size(26, 20);
            this.cmdDBScriptFolder.TabIndex = 16;
            this.cmdDBScriptFolder.Text = "...";
            this.cmdDBScriptFolder.UseVisualStyleBackColor = true;
            this.cmdDBScriptFolder.Click += new System.EventHandler(this.cmdDBScriptFolder_Click);
            // 
            // cmdDBSettingSave
            // 
            this.cmdDBSettingSave.Location = new System.Drawing.Point(9, 330);
            this.cmdDBSettingSave.Name = "cmdDBSettingSave";
            this.cmdDBSettingSave.Size = new System.Drawing.Size(113, 23);
            this.cmdDBSettingSave.TabIndex = 22;
            this.cmdDBSettingSave.Text = "Save";
            this.cmdDBSettingSave.UseVisualStyleBackColor = true;
            this.cmdDBSettingSave.Click += new System.EventHandler(this.cmdDBSettingSave_Click);
            // 
            // cmdDBSettingTest
            // 
            this.cmdDBSettingTest.Location = new System.Drawing.Point(200, 330);
            this.cmdDBSettingTest.Name = "cmdDBSettingTest";
            this.cmdDBSettingTest.Size = new System.Drawing.Size(117, 23);
            this.cmdDBSettingTest.TabIndex = 21;
            this.cmdDBSettingTest.Text = "Test";
            this.cmdDBSettingTest.UseVisualStyleBackColor = true;
            this.cmdDBSettingTest.Click += new System.EventHandler(this.cmdDBSettingTest_Click);
            // 
            // txtDBMapDataTiming
            // 
            this.txtDBMapDataTiming.Location = new System.Drawing.Point(132, 272);
            this.txtDBMapDataTiming.Name = "txtDBMapDataTiming";
            this.txtDBMapDataTiming.Size = new System.Drawing.Size(79, 20);
            this.txtDBMapDataTiming.TabIndex = 20;
            // 
            // txtDBWarningDir
            // 
            this.txtDBWarningDir.Location = new System.Drawing.Point(132, 247);
            this.txtDBWarningDir.Name = "txtDBWarningDir";
            this.txtDBWarningDir.ReadOnly = true;
            this.txtDBWarningDir.Size = new System.Drawing.Size(157, 20);
            this.txtDBWarningDir.TabIndex = 19;
            // 
            // txtDBErrorDir
            // 
            this.txtDBErrorDir.Location = new System.Drawing.Point(132, 222);
            this.txtDBErrorDir.Name = "txtDBErrorDir";
            this.txtDBErrorDir.ReadOnly = true;
            this.txtDBErrorDir.Size = new System.Drawing.Size(157, 20);
            this.txtDBErrorDir.TabIndex = 17;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(132, 134);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(142, 20);
            this.txtDBPassword.TabIndex = 13;
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Location = new System.Drawing.Point(132, 108);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(142, 20);
            this.txtDBUserName.TabIndex = 12;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(132, 82);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(142, 20);
            this.txtDBName.TabIndex = 11;
            // 
            // txtDBServerName
            // 
            this.txtDBServerName.Location = new System.Drawing.Point(132, 56);
            this.txtDBServerName.Name = "txtDBServerName";
            this.txtDBServerName.Size = new System.Drawing.Size(142, 20);
            this.txtDBServerName.TabIndex = 10;
            // 
            // txtDBScriptDir
            // 
            this.txtDBScriptDir.Location = new System.Drawing.Point(132, 197);
            this.txtDBScriptDir.Name = "txtDBScriptDir";
            this.txtDBScriptDir.ReadOnly = true;
            this.txtDBScriptDir.Size = new System.Drawing.Size(153, 20);
            this.txtDBScriptDir.TabIndex = 15;
            // 
            // lblDBMapDataTiming
            // 
            this.lblDBMapDataTiming.Location = new System.Drawing.Point(13, 275);
            this.lblDBMapDataTiming.Name = "lblDBMapDataTiming";
            this.lblDBMapDataTiming.Size = new System.Drawing.Size(113, 13);
            this.lblDBMapDataTiming.TabIndex = 7;
            this.lblDBMapDataTiming.Text = "Map Data Every (min.)";
            this.lblDBMapDataTiming.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBWarningDir
            // 
            this.lblDBWarningDir.Location = new System.Drawing.Point(13, 250);
            this.lblDBWarningDir.Name = "lblDBWarningDir";
            this.lblDBWarningDir.Size = new System.Drawing.Size(113, 13);
            this.lblDBWarningDir.TabIndex = 6;
            this.lblDBWarningDir.Text = "Warning Log Directory";
            this.lblDBWarningDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBErrorDir
            // 
            this.lblDBErrorDir.Location = new System.Drawing.Point(13, 225);
            this.lblDBErrorDir.Name = "lblDBErrorDir";
            this.lblDBErrorDir.Size = new System.Drawing.Size(113, 13);
            this.lblDBErrorDir.TabIndex = 5;
            this.lblDBErrorDir.Text = "Error Log Directory";
            this.lblDBErrorDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBScriptDir
            // 
            this.lblDBScriptDir.Location = new System.Drawing.Point(13, 200);
            this.lblDBScriptDir.Name = "lblDBScriptDir";
            this.lblDBScriptDir.Size = new System.Drawing.Size(113, 13);
            this.lblDBScriptDir.TabIndex = 4;
            this.lblDBScriptDir.Text = "Script Log Directory";
            this.lblDBScriptDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.Location = new System.Drawing.Point(13, 137);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(113, 13);
            this.lblDBPassword.TabIndex = 3;
            this.lblDBPassword.Text = "Password";
            this.lblDBPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBUserName
            // 
            this.lblDBUserName.Location = new System.Drawing.Point(13, 111);
            this.lblDBUserName.Name = "lblDBUserName";
            this.lblDBUserName.Size = new System.Drawing.Size(113, 13);
            this.lblDBUserName.TabIndex = 2;
            this.lblDBUserName.Text = "User Name";
            this.lblDBUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBName
            // 
            this.lblDBName.Location = new System.Drawing.Point(13, 85);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(113, 13);
            this.lblDBName.TabIndex = 1;
            this.lblDBName.Text = "DataBase Name";
            this.lblDBName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDBServerName
            // 
            this.lblDBServerName.Location = new System.Drawing.Point(13, 59);
            this.lblDBServerName.Name = "lblDBServerName";
            this.lblDBServerName.Size = new System.Drawing.Size(113, 13);
            this.lblDBServerName.TabIndex = 0;
            this.lblDBServerName.Text = "Server Name";
            this.lblDBServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 371);
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
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblDBServerName;
        private System.Windows.Forms.Label lblDBMapDataTiming;
        private System.Windows.Forms.Label lblDBWarningDir;
        private System.Windows.Forms.Label lblDBErrorDir;
        private System.Windows.Forms.Label lblDBScriptDir;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.Label lblDBUserName;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.TextBox txtDBUserName;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtDBServerName;
        private System.Windows.Forms.TextBox txtDBScriptDir;
        private System.Windows.Forms.Button cmdDBSettingSave;
        private System.Windows.Forms.Button cmdDBSettingTest;
        private System.Windows.Forms.TextBox txtDBMapDataTiming;
        private System.Windows.Forms.TextBox txtDBWarningDir;
        private System.Windows.Forms.TextBox txtDBErrorDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdDBErrFolder;
        private System.Windows.Forms.Button cmdDBWarningFolder;
        private System.Windows.Forms.Button cmdDBScriptFolder;
        private System.Windows.Forms.CheckBox ckDBLogChangeScripts;
        private System.Windows.Forms.Label lblDBType;
        private System.Windows.Forms.ComboBox cmbDBType;
        private System.Windows.Forms.TextBox txtDBPort;
        private System.Windows.Forms.Label lblDBPort;
        private System.Windows.Forms.Button cmdDataFileLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}