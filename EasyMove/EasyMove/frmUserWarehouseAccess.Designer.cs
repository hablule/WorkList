namespace EasyMove
{
    partial class frmUserWarehouseAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserWarehouseAccess));
            this.lblUserName = new System.Windows.Forms.Label();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.ckIsReadOnlyAccess = new System.Windows.Forms.CheckBox();
            this.txtWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.cmdSetUserWarehouseAccess = new System.Windows.Forms.Button();
            this.ddgUserName = new EasyMove.DropDownDataGrid();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(14, 17);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "User Name";
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsActive.Location = new System.Drawing.Point(31, 81);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(56, 17);
            this.ckIsActive.TabIndex = 11;
            this.ckIsActive.Text = "Active";
            this.ckIsActive.UseVisualStyleBackColor = true;
            this.ckIsActive.CheckedChanged += new System.EventHandler(this.ckIsActive_CheckedChanged);
            // 
            // ckIsReadOnlyAccess
            // 
            this.ckIsReadOnlyAccess.AutoSize = true;
            this.ckIsReadOnlyAccess.Location = new System.Drawing.Point(31, 104);
            this.ckIsReadOnlyAccess.Name = "ckIsReadOnlyAccess";
            this.ckIsReadOnlyAccess.Size = new System.Drawing.Size(87, 17);
            this.ckIsReadOnlyAccess.TabIndex = 10;
            this.ckIsReadOnlyAccess.Text = "Is Read Only";
            this.ckIsReadOnlyAccess.UseVisualStyleBackColor = true;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.AutoSize = true;
            this.txtWarehouse.Location = new System.Drawing.Point(12, 46);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(62, 13);
            this.txtWarehouse.TabIndex = 12;
            this.txtWarehouse.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(79, 42);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(193, 21);
            this.cmbWarehouse.TabIndex = 13;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            // 
            // cmdSetUserWarehouseAccess
            // 
            this.cmdSetUserWarehouseAccess.Location = new System.Drawing.Point(91, 127);
            this.cmdSetUserWarehouseAccess.Name = "cmdSetUserWarehouseAccess";
            this.cmdSetUserWarehouseAccess.Size = new System.Drawing.Size(125, 23);
            this.cmdSetUserWarehouseAccess.TabIndex = 15;
            this.cmdSetUserWarehouseAccess.Text = "Set User Access";
            this.cmdSetUserWarehouseAccess.UseVisualStyleBackColor = true;
            this.cmdSetUserWarehouseAccess.Click += new System.EventHandler(this.cmdSetUserWarehouseAccess_Click);
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
            this.ddgUserName.Location = new System.Drawing.Point(74, 9);
            this.ddgUserName.Margin = new System.Windows.Forms.Padding(0);
            this.ddgUserName.Name = "ddgUserName";
            this.ddgUserName.NewButtonEnabled = true;
            this.ddgUserName.RefreshButtonEnabled = true;
            this.ddgUserName.SelectedColomnIdex = 0;
            this.ddgUserName.SelectedItem = "";
            this.ddgUserName.SelectedRowKey = null;
            this.ddgUserName.ShowGridFunctions = false;
            this.ddgUserName.Size = new System.Drawing.Size(254, 31);
            this.ddgUserName.TabIndex = 9;
            this.ddgUserName.SelectedItemClicked += new System.EventHandler(this.ddgUserName_SelectedItemClicked);
            // 
            // frmUserWarehouseAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(329, 156);
            this.Controls.Add(this.cmdSetUserWarehouseAccess);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.ckIsReadOnlyAccess);
            this.Controls.Add(this.ddgUserName);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserWarehouseAccess";
            this.Text = "User Warehouse Access";
            this.Load += new System.EventHandler(this.frmUserWarehouseAccess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DropDownDataGrid ddgUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.CheckBox ckIsActive;
        private System.Windows.Forms.CheckBox ckIsReadOnlyAccess;
        private System.Windows.Forms.Label txtWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Button cmdSetUserWarehouseAccess;
    }
}