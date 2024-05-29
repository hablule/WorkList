namespace SRP
{
    partial class frmUOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUOM));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblUOMName = new System.Windows.Forms.Label();
            this.lblUOMDescription = new System.Windows.Forms.Label();
            this.lblUOMStdPrecision = new System.Windows.Forms.Label();
            this.lblUOMAbbreviation = new System.Windows.Forms.Label();
            this.ckUOMIsActive = new System.Windows.Forms.CheckBox();
            this.txtUOMName = new System.Windows.Forms.TextBox();
            this.txtUOMDescription = new System.Windows.Forms.TextBox();
            this.txtUOMAbbreviation = new System.Windows.Forms.TextBox();
            this.dtgUOMGridView = new System.Windows.Forms.DataGridView();
            this.ntbUOMStdPrecision = new SRP.ctlNumberTextBox();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUOMGridView)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(448, 25);
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
            // lblUOMName
            // 
            this.lblUOMName.AutoSize = true;
            this.lblUOMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOMName.Location = new System.Drawing.Point(25, 49);
            this.lblUOMName.Name = "lblUOMName";
            this.lblUOMName.Size = new System.Drawing.Size(45, 15);
            this.lblUOMName.TabIndex = 1;
            this.lblUOMName.Text = "Name";
            // 
            // lblUOMDescription
            // 
            this.lblUOMDescription.AutoSize = true;
            this.lblUOMDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOMDescription.Location = new System.Drawing.Point(18, 103);
            this.lblUOMDescription.Name = "lblUOMDescription";
            this.lblUOMDescription.Size = new System.Drawing.Size(80, 15);
            this.lblUOMDescription.TabIndex = 2;
            this.lblUOMDescription.Text = "Description";
            // 
            // lblUOMStdPrecision
            // 
            this.lblUOMStdPrecision.AutoSize = true;
            this.lblUOMStdPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOMStdPrecision.Location = new System.Drawing.Point(14, 185);
            this.lblUOMStdPrecision.Name = "lblUOMStdPrecision";
            this.lblUOMStdPrecision.Size = new System.Drawing.Size(87, 15);
            this.lblUOMStdPrecision.TabIndex = 3;
            this.lblUOMStdPrecision.Text = "Std Pecision";
            // 
            // lblUOMAbbreviation
            // 
            this.lblUOMAbbreviation.AutoSize = true;
            this.lblUOMAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOMAbbreviation.Location = new System.Drawing.Point(206, 186);
            this.lblUOMAbbreviation.Name = "lblUOMAbbreviation";
            this.lblUOMAbbreviation.Size = new System.Drawing.Size(86, 15);
            this.lblUOMAbbreviation.TabIndex = 4;
            this.lblUOMAbbreviation.Text = "Abbreviation";
            // 
            // ckUOMIsActive
            // 
            this.ckUOMIsActive.AutoSize = true;
            this.ckUOMIsActive.Checked = true;
            this.ckUOMIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckUOMIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckUOMIsActive.Location = new System.Drawing.Point(107, 75);
            this.ckUOMIsActive.Name = "ckUOMIsActive";
            this.ckUOMIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckUOMIsActive.TabIndex = 5;
            this.ckUOMIsActive.Text = "Is Active";
            this.ckUOMIsActive.UseVisualStyleBackColor = true;
            // 
            // txtUOMName
            // 
            this.txtUOMName.Location = new System.Drawing.Point(103, 49);
            this.txtUOMName.Name = "txtUOMName";
            this.txtUOMName.Size = new System.Drawing.Size(198, 20);
            this.txtUOMName.TabIndex = 6;
            // 
            // txtUOMDescription
            // 
            this.txtUOMDescription.Location = new System.Drawing.Point(103, 99);
            this.txtUOMDescription.Multiline = true;
            this.txtUOMDescription.Name = "txtUOMDescription";
            this.txtUOMDescription.Size = new System.Drawing.Size(316, 73);
            this.txtUOMDescription.TabIndex = 7;
            // 
            // txtUOMAbbreviation
            // 
            this.txtUOMAbbreviation.Location = new System.Drawing.Point(298, 183);
            this.txtUOMAbbreviation.Name = "txtUOMAbbreviation";
            this.txtUOMAbbreviation.Size = new System.Drawing.Size(100, 20);
            this.txtUOMAbbreviation.TabIndex = 8;
            // 
            // dtgUOMGridView
            // 
            this.dtgUOMGridView.AllowUserToAddRows = false;
            this.dtgUOMGridView.AllowUserToDeleteRows = false;
            this.dtgUOMGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgUOMGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgUOMGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgUOMGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgUOMGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgUOMGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUOMGridView.Location = new System.Drawing.Point(0, 223);
            this.dtgUOMGridView.MultiSelect = false;
            this.dtgUOMGridView.Name = "dtgUOMGridView";
            this.dtgUOMGridView.ReadOnly = true;
            this.dtgUOMGridView.RowHeadersWidth = 20;
            this.dtgUOMGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUOMGridView.Size = new System.Drawing.Size(448, 190);
            this.dtgUOMGridView.TabIndex = 10;
            this.dtgUOMGridView.SelectionChanged += new System.EventHandler(this.dtgUOMGridView_SelectionChanged);
            // 
            // ntbUOMStdPrecision
            // 
            this.ntbUOMStdPrecision.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbUOMStdPrecision.AllowNegative = false;
            this.ntbUOMStdPrecision.Amount = "2";
            this.ntbUOMStdPrecision.Location = new System.Drawing.Point(103, 182);
            this.ntbUOMStdPrecision.Name = "ntbUOMStdPrecision";
            this.ntbUOMStdPrecision.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbUOMStdPrecision.ShowThousandSeparetor = true;
            this.ntbUOMStdPrecision.Size = new System.Drawing.Size(82, 23);
            this.ntbUOMStdPrecision.StandardPrecision = 0;
            this.ntbUOMStdPrecision.TabIndex = 9;
            // 
            // frmUOM
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.dtgUOMGridView);
            this.Controls.Add(this.ntbUOMStdPrecision);
            this.Controls.Add(this.txtUOMAbbreviation);
            this.Controls.Add(this.txtUOMDescription);
            this.Controls.Add(this.txtUOMName);
            this.Controls.Add(this.ckUOMIsActive);
            this.Controls.Add(this.lblUOMAbbreviation);
            this.Controls.Add(this.lblUOMStdPrecision);
            this.Controls.Add(this.lblUOMDescription);
            this.Controls.Add(this.lblUOMName);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Size = new System.Drawing.Size(448, 414);
            this.Text = "frmUOM";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUOMGridView)).EndInit();
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
        private System.Windows.Forms.Label lblUOMName;
        private System.Windows.Forms.Label lblUOMDescription;
        private System.Windows.Forms.Label lblUOMStdPrecision;
        private System.Windows.Forms.Label lblUOMAbbreviation;
        private System.Windows.Forms.CheckBox ckUOMIsActive;
        private System.Windows.Forms.TextBox txtUOMName;
        private System.Windows.Forms.TextBox txtUOMDescription;
        private System.Windows.Forms.TextBox txtUOMAbbreviation;
        private SRP.ctlNumberTextBox ntbUOMStdPrecision;
        private System.Windows.Forms.DataGridView dtgUOMGridView;
    }
}