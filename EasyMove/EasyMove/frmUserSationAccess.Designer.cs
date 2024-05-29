namespace EasyMove
{
    partial class frmUserSationAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserSationAccess));
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.ckIsReadOnlyAccess = new System.Windows.Forms.CheckBox();
            this.cmdSetUserSationAccess = new System.Windows.Forms.Button();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.ddgUserName = new EasyMove.DropDownDataGrid();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(12, 51);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(40, 13);
            this.lblStation.TabIndex = 1;
            this.lblStation.Text = "Station";
            // 
            // cmbStations
            // 
            this.cmbStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(78, 48);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(163, 21);
            this.cmbStations.TabIndex = 4;
            this.cmbStations.SelectedIndexChanged += new System.EventHandler(this.cmbStations_SelectedIndexChanged);
            // 
            // ckIsReadOnlyAccess
            // 
            this.ckIsReadOnlyAccess.AutoSize = true;
            this.ckIsReadOnlyAccess.Location = new System.Drawing.Point(33, 108);
            this.ckIsReadOnlyAccess.Name = "ckIsReadOnlyAccess";
            this.ckIsReadOnlyAccess.Size = new System.Drawing.Size(87, 17);
            this.ckIsReadOnlyAccess.TabIndex = 5;
            this.ckIsReadOnlyAccess.Text = "Is Read Only";
            this.ckIsReadOnlyAccess.UseVisualStyleBackColor = true;
            // 
            // cmdSetUserSationAccess
            // 
            this.cmdSetUserSationAccess.Location = new System.Drawing.Point(96, 139);
            this.cmdSetUserSationAccess.Name = "cmdSetUserSationAccess";
            this.cmdSetUserSationAccess.Size = new System.Drawing.Size(125, 23);
            this.cmdSetUserSationAccess.TabIndex = 6;
            this.cmdSetUserSationAccess.Text = "Set User Access";
            this.cmdSetUserSationAccess.UseVisualStyleBackColor = true;
            this.cmdSetUserSationAccess.Click += new System.EventHandler(this.cmdSetUserSationAccess_Click);
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsActive.Location = new System.Drawing.Point(33, 85);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(56, 17);
            this.ckIsActive.TabIndex = 8;
            this.ckIsActive.Text = "Active";
            this.ckIsActive.UseVisualStyleBackColor = true;
            this.ckIsActive.CheckedChanged += new System.EventHandler(this.ckIsActive_CheckedChanged);
            // 
            // ddgUserName
            // 
            this.ddgUserName.AutoFilter = true;
            this.ddgUserName.AutoSize = true;
            this.ddgUserName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgUserName.ClearButtonEnabled = true;
            this.ddgUserName.DataTablePrimaryKey = ((ushort)(0));
            this.ddgUserName.FindButtonEnabled = true;
            this.ddgUserName.HiddenColoumns = new int[0];
            this.ddgUserName.Image = null;
            this.ddgUserName.Location = new System.Drawing.Point(74, 16);
            this.ddgUserName.Margin = new System.Windows.Forms.Padding(0);
            this.ddgUserName.Name = "ddgUserName";
            this.ddgUserName.NewButtonEnabled = true;
            this.ddgUserName.RefreshButtonEnabled = true;
            this.ddgUserName.SelectedColomnIdex = 0;
            this.ddgUserName.SelectedItem = "";
            this.ddgUserName.SelectedRowKey = null;
            this.ddgUserName.ShowGridFunctions = false;
            this.ddgUserName.Size = new System.Drawing.Size(226, 31);
            this.ddgUserName.TabIndex = 7;
            this.ddgUserName.SelectedItemClicked += new System.EventHandler(this.ddgUserName_SelectedItemClicked);
            this.ddgUserName.selectedItemChanged += new System.EventHandler(this.ddgUserName_selectedItemChanged);
            // 
            // frmUserSationAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(303, 174);
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.ddgUserName);
            this.Controls.Add(this.cmdSetUserSationAccess);
            this.Controls.Add(this.ckIsReadOnlyAccess);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserSationAccess";
            this.Text = "User Sation Access";
            this.Load += new System.EventHandler(this.frmUserSationAccess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.CheckBox ckIsReadOnlyAccess;
        private System.Windows.Forms.Button cmdSetUserSationAccess;
        private DropDownDataGrid ddgUserName;
        private System.Windows.Forms.CheckBox ckIsActive;
    }
}