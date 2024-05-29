namespace SRP
{
    partial class frmStorageAccess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        */
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsCommandToolBar = new System.Windows.Forms.ToolStrip();
            this.tlsNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsDelete = new System.Windows.Forms.ToolStripButton();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.ckCanBuy = new System.Windows.Forms.CheckBox();
            this.ckCanUse = new System.Windows.Forms.CheckBox();
            this.ckCanSale = new System.Windows.Forms.CheckBox();
            this.ckCanCount = new System.Windows.Forms.CheckBox();
            this.ckCanMoveFrom = new System.Windows.Forms.CheckBox();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.dtgStorageAccessView = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.ckCanMoveTo = new System.Windows.Forms.CheckBox();
            this.ckCanRead = new System.Windows.Forms.CheckBox();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStorageAccessView)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsCommandToolBar
            // 
            this.tlsCommandToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsCommandToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNew,
            this.tlsSave,
            this.tlsDelete,
            this.tlsSearch,
            this.toolStripSeparator1,
            this.tlsFirstRecord,
            this.tlsPreviousRecord,
            this.tlsNextRecord,
            this.tlsLastRecord});
            this.tlsCommandToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsCommandToolBar.Name = "tlsCommandToolBar";
            this.tlsCommandToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlsCommandToolBar.Size = new System.Drawing.Size(391, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(35, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(35, 22);
            this.tlsSave.Text = "Save";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(44, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Click += new System.EventHandler(this.tlsDelete_Click);
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(46, 22);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(33, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(56, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(35, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.Visible = false;
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.Location = new System.Drawing.Point(53, 47);
            this.lblStation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(40, 15);
            this.lblStation.TabIndex = 1;
            this.lblStation.Text = "Shop";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(56, 74);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(37, 15);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouse.Location = new System.Drawing.Point(14, 103);
            this.lblWarehouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(79, 15);
            this.lblWarehouse.TabIndex = 3;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // ckCanBuy
            // 
            this.ckCanBuy.AutoSize = true;
            this.ckCanBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCanBuy.Location = new System.Drawing.Point(46, 234);
            this.ckCanBuy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckCanBuy.Name = "ckCanBuy";
            this.ckCanBuy.Size = new System.Drawing.Size(103, 19);
            this.ckCanBuy.TabIndex = 4;
            this.ckCanBuy.Text = "Can Buy For";
            this.ckCanBuy.UseVisualStyleBackColor = true;
            // 
            // ckCanUse
            // 
            this.ckCanUse.AutoSize = true;
            this.ckCanUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCanUse.Location = new System.Drawing.Point(254, 261);
            this.ckCanUse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckCanUse.Name = "ckCanUse";
            this.ckCanUse.Size = new System.Drawing.Size(117, 19);
            this.ckCanUse.TabIndex = 5;
            this.ckCanUse.Text = "Can Use From";
            this.ckCanUse.UseVisualStyleBackColor = true;
            // 
            // ckCanSale
            // 
            this.ckCanSale.AutoSize = true;
            this.ckCanSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCanSale.Location = new System.Drawing.Point(46, 261);
            this.ckCanSale.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckCanSale.Name = "ckCanSale";
            this.ckCanSale.Size = new System.Drawing.Size(106, 19);
            this.ckCanSale.TabIndex = 6;
            this.ckCanSale.Text = "Can Sale On";
            this.ckCanSale.UseVisualStyleBackColor = true;
            // 
            // ckCanCount
            // 
            this.ckCanCount.AutoSize = true;
            this.ckCanCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCanCount.Location = new System.Drawing.Point(254, 287);
            this.ckCanCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckCanCount.Name = "ckCanCount";
            this.ckCanCount.Size = new System.Drawing.Size(92, 19);
            this.ckCanCount.TabIndex = 7;
            this.ckCanCount.Text = "Can Count";
            this.ckCanCount.UseVisualStyleBackColor = true;
            // 
            // ckCanMoveFrom
            // 
            this.ckCanMoveFrom.AutoSize = true;
            this.ckCanMoveFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCanMoveFrom.Location = new System.Drawing.Point(254, 234);
            this.ckCanMoveFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckCanMoveFrom.Name = "ckCanMoveFrom";
            this.ckCanMoveFrom.Size = new System.Drawing.Size(126, 19);
            this.ckCanMoveFrom.TabIndex = 8;
            this.ckCanMoveFrom.Text = "Can Move From";
            this.ckCanMoveFrom.UseVisualStyleBackColor = true;
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsActive.Location = new System.Drawing.Point(98, 206);
            this.ckIsActive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(63, 19);
            this.ckIsActive.TabIndex = 9;
            this.ckIsActive.Text = "Active";
            this.ckIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbStation
            // 
            this.cmbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(98, 44);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(195, 21);
            this.cmbStation.TabIndex = 10;
            this.cmbStation.SelectedIndexChanged += new System.EventHandler(this.cmbStation_SelectedIndexChanged);
            this.cmbStation.DropDown += new System.EventHandler(this.cmbStation_DropDown);
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(98, 71);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(195, 21);
            this.cmbUser.TabIndex = 11;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            this.cmbUser.DropDown += new System.EventHandler(this.cmbUser_DropDown);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(98, 99);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(195, 21);
            this.cmbWarehouse.TabIndex = 12;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            this.cmbWarehouse.DropDown += new System.EventHandler(this.cmbWarehouse_DropDown);
            // 
            // dtgStorageAccessView
            // 
            this.dtgStorageAccessView.AllowUserToAddRows = false;
            this.dtgStorageAccessView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgStorageAccessView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgStorageAccessView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgStorageAccessView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgStorageAccessView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgStorageAccessView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgStorageAccessView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgStorageAccessView.Location = new System.Drawing.Point(4, 337);
            this.dtgStorageAccessView.MultiSelect = false;
            this.dtgStorageAccessView.Name = "dtgStorageAccessView";
            this.dtgStorageAccessView.ReadOnly = true;
            this.dtgStorageAccessView.RowHeadersWidth = 21;
            this.dtgStorageAccessView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgStorageAccessView.Size = new System.Drawing.Size(383, 195);
            this.dtgStorageAccessView.TabIndex = 13;
            this.dtgStorageAccessView.SelectionChanged += new System.EventHandler(this.dtgStorageAccessView_SelectionChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(98, 128);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 71);
            this.txtDescription.TabIndex = 14;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 131);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 15);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Description";
            // 
            // ckCanMoveTo
            // 
            this.ckCanMoveTo.AutoSize = true;
            this.ckCanMoveTo.Location = new System.Drawing.Point(46, 287);
            this.ckCanMoveTo.Name = "ckCanMoveTo";
            this.ckCanMoveTo.Size = new System.Drawing.Size(109, 19);
            this.ckCanMoveTo.TabIndex = 16;
            this.ckCanMoveTo.Text = "Can Move To";
            this.ckCanMoveTo.UseVisualStyleBackColor = true;
            // 
            // ckCanRead
            // 
            this.ckCanRead.AutoSize = true;
            this.ckCanRead.Location = new System.Drawing.Point(156, 312);
            this.ckCanRead.Name = "ckCanRead";
            this.ckCanRead.Size = new System.Drawing.Size(85, 19);
            this.ckCanRead.TabIndex = 17;
            this.ckCanRead.Text = "Can View";
            this.ckCanRead.UseVisualStyleBackColor = true;
            this.ckCanRead.CheckedChanged += new System.EventHandler(this.ckCanRead_CheckedChanged);
            // 
            // frmStorageAccess
            // 
            this.Controls.Add(this.ckCanRead);
            this.Controls.Add(this.ckCanMoveTo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dtgStorageAccessView);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.cmbStation);
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.ckCanMoveFrom);
            this.Controls.Add(this.ckCanCount);
            this.Controls.Add(this.ckCanSale);
            this.Controls.Add(this.ckCanUse);
            this.Controls.Add(this.ckCanBuy);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Size = new System.Drawing.Size(391, 539);
            this.Text = "frmStorageAccess";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStorageAccessView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsCommandToolBar;
        private System.Windows.Forms.ToolStripButton tlsNew;
        private System.Windows.Forms.ToolStripButton tlsSave;
        private System.Windows.Forms.ToolStripButton tlsDelete;
        private System.Windows.Forms.ToolStripButton tlsSearch;
        private System.Windows.Forms.ToolStripButton tlsFirstRecord;
        private System.Windows.Forms.ToolStripButton tlsPreviousRecord;
        private System.Windows.Forms.ToolStripButton tlsNextRecord;
        private System.Windows.Forms.ToolStripButton tlsLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.CheckBox ckCanBuy;
        private System.Windows.Forms.CheckBox ckCanUse;
        private System.Windows.Forms.CheckBox ckCanSale;
        private System.Windows.Forms.CheckBox ckCanCount;
        private System.Windows.Forms.CheckBox ckCanMoveFrom;
        private System.Windows.Forms.CheckBox ckIsActive;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.DataGridView dtgStorageAccessView;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox ckCanMoveTo;
        private System.Windows.Forms.CheckBox ckCanRead;

    }
}