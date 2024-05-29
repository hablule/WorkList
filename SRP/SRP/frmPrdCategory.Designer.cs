namespace SRP
{
    partial class frmPrdCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrdCategory));
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
            this.lblPrdCategoryName = new System.Windows.Forms.Label();
            this.lblPrdCategoryDescription = new System.Windows.Forms.Label();
            this.ckPrdCategoryIsActive = new System.Windows.Forms.CheckBox();
            this.dtgPrdCategoryGridView = new System.Windows.Forms.DataGridView();
            this.txtPrdCategoryName = new System.Windows.Forms.TextBox();
            this.txtPrdCategoryDescritpion = new System.Windows.Forms.TextBox();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrdCategoryGridView)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(367, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.Image = ((System.Drawing.Image)(resources.GetObject("tlsNew.Image")));
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(35, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsSave.Image")));
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(35, 22);
            this.tlsSave.Text = "Save";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlsDelete.Image")));
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(44, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Visible = false;
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlsSearch.Image")));
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
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsFirstRecord.Image")));
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(33, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsPreviousRecord.Image")));
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(56, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsNextRecord.Image")));
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(35, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsLastRecord.Image")));
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.Visible = false;
            // 
            // lblPrdCategoryName
            // 
            this.lblPrdCategoryName.AutoSize = true;
            this.lblPrdCategoryName.Location = new System.Drawing.Point(30, 40);
            this.lblPrdCategoryName.Name = "lblPrdCategoryName";
            this.lblPrdCategoryName.Size = new System.Drawing.Size(35, 13);
            this.lblPrdCategoryName.TabIndex = 1;
            this.lblPrdCategoryName.Text = "Name";
            // 
            // lblPrdCategoryDescription
            // 
            this.lblPrdCategoryDescription.AutoSize = true;
            this.lblPrdCategoryDescription.Location = new System.Drawing.Point(8, 68);
            this.lblPrdCategoryDescription.Name = "lblPrdCategoryDescription";
            this.lblPrdCategoryDescription.Size = new System.Drawing.Size(60, 13);
            this.lblPrdCategoryDescription.TabIndex = 2;
            this.lblPrdCategoryDescription.Text = "Description";
            // 
            // ckPrdCategoryIsActive
            // 
            this.ckPrdCategoryIsActive.AutoSize = true;
            this.ckPrdCategoryIsActive.Checked = true;
            this.ckPrdCategoryIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckPrdCategoryIsActive.Location = new System.Drawing.Point(71, 153);
            this.ckPrdCategoryIsActive.Name = "ckPrdCategoryIsActive";
            this.ckPrdCategoryIsActive.Size = new System.Drawing.Size(67, 17);
            this.ckPrdCategoryIsActive.TabIndex = 3;
            this.ckPrdCategoryIsActive.Text = "Is Active";
            this.ckPrdCategoryIsActive.UseVisualStyleBackColor = true;
            // 
            // dtgPrdCategoryGridView
            // 
            this.dtgPrdCategoryGridView.AllowUserToAddRows = false;
            this.dtgPrdCategoryGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgPrdCategoryGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPrdCategoryGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgPrdCategoryGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgPrdCategoryGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPrdCategoryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPrdCategoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrdCategoryGridView.Location = new System.Drawing.Point(0, 187);
            this.dtgPrdCategoryGridView.MultiSelect = false;
            this.dtgPrdCategoryGridView.Name = "dtgPrdCategoryGridView";
            this.dtgPrdCategoryGridView.ReadOnly = true;
            this.dtgPrdCategoryGridView.RowHeadersWidth = 20;
            this.dtgPrdCategoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrdCategoryGridView.Size = new System.Drawing.Size(367, 154);
            this.dtgPrdCategoryGridView.TabIndex = 4;
            this.dtgPrdCategoryGridView.SelectionChanged += new System.EventHandler(this.dtgPrdCategoryGridView_SelectionChanged);
            // 
            // txtPrdCategoryName
            // 
            this.txtPrdCategoryName.Location = new System.Drawing.Point(71, 36);
            this.txtPrdCategoryName.Name = "txtPrdCategoryName";
            this.txtPrdCategoryName.Size = new System.Drawing.Size(144, 20);
            this.txtPrdCategoryName.TabIndex = 5;
            // 
            // txtPrdCategoryDescritpion
            // 
            this.txtPrdCategoryDescritpion.Location = new System.Drawing.Point(71, 65);
            this.txtPrdCategoryDescritpion.Multiline = true;
            this.txtPrdCategoryDescritpion.Name = "txtPrdCategoryDescritpion";
            this.txtPrdCategoryDescritpion.Size = new System.Drawing.Size(253, 80);
            this.txtPrdCategoryDescritpion.TabIndex = 6;
            // 
            // frmPrdCategory
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.txtPrdCategoryDescritpion);
            this.Controls.Add(this.txtPrdCategoryName);
            this.Controls.Add(this.dtgPrdCategoryGridView);
            this.Controls.Add(this.ckPrdCategoryIsActive);
            this.Controls.Add(this.lblPrdCategoryDescription);
            this.Controls.Add(this.lblPrdCategoryName);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Size = new System.Drawing.Size(367, 341);
            this.Text = "frmPrdCategory";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrdCategoryGridView)).EndInit();
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
        private System.Windows.Forms.Label lblPrdCategoryName;
        private System.Windows.Forms.Label lblPrdCategoryDescription;
        private System.Windows.Forms.CheckBox ckPrdCategoryIsActive;
        private System.Windows.Forms.DataGridView dtgPrdCategoryGridView;
        private System.Windows.Forms.TextBox txtPrdCategoryName;
        private System.Windows.Forms.TextBox txtPrdCategoryDescritpion;
    }
}