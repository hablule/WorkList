namespace SecurityGuardScheduling
{
    partial class frmExclusion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExclusion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbDateLogic = new System.Windows.Forms.ComboBox();
            this.ckAndOr = new System.Windows.Forms.CheckBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.clbDaysOfWeek = new System.Windows.Forms.CheckedListBox();
            this.lblDaysOfWeek = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckIsShiftExclusion = new System.Windows.Forms.CheckBox();
            this.ckIsPostExclusion = new System.Windows.Forms.CheckBox();
            this.clbShiftsExcluded = new System.Windows.Forms.CheckedListBox();
            this.clbPostsExcluded = new System.Windows.Forms.CheckedListBox();
            this.clbGaurdsExcluded = new System.Windows.Forms.CheckedListBox();
            this.ckIsGaurdExclusion = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtgExclusion = new System.Windows.Forms.DataGridView();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExclusion)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.searchToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton,
            this.exitToolStripButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(860, 66);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.newToolStripButton.Size = new System.Drawing.Size(60, 53);
            this.newToolStripButton.Text = "    &New    ";
            this.newToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(59, 53);
            this.saveToolStripButton.Text = "    &Save    ";
            this.saveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 56);
            // 
            // searchToolStripButton
            // 
            this.searchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripButton.Image")));
            this.searchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchToolStripButton.Name = "searchToolStripButton";
            this.searchToolStripButton.Size = new System.Drawing.Size(71, 53);
            this.searchToolStripButton.Text = "      &Search   ";
            this.searchToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.searchToolStripButton.Click += new System.EventHandler(this.searchToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(68, 53);
            this.helpToolStripButton.Text = "      &Help      ";
            this.helpToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripButton.Image")));
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(68, 53);
            this.exitToolStripButton.Text = "      E&xit       ";
            this.exitToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitToolStripButton.Click += new System.EventHandler(this.exitToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 656);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(860, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.cmbDateLogic);
            this.groupBox1.Controls.Add(this.ckAndOr);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.clbDaysOfWeek);
            this.groupBox1.Controls.Add(this.lblDaysOfWeek);
            this.groupBox1.Location = new System.Drawing.Point(8, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 326);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Period-Rule Excluded";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(93, 188);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 13);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Apply to Date";
            // 
            // cmbDateLogic
            // 
            this.cmbDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateLogic.FormattingEnabled = true;
            this.cmbDateLogic.Items.AddRange(new object[] {
            "Not Applicable",
            "Equals to",
            "Greater or equals to",
            "Lesser or equal to",
            "In between of"});
            this.cmbDateLogic.Location = new System.Drawing.Point(6, 204);
            this.cmbDateLogic.Name = "cmbDateLogic";
            this.cmbDateLogic.Size = new System.Drawing.Size(244, 21);
            this.cmbDateLogic.TabIndex = 8;
            this.cmbDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // ckAndOr
            // 
            this.ckAndOr.AutoSize = true;
            this.ckAndOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAndOr.Location = new System.Drawing.Point(84, 161);
            this.ckAndOr.Name = "ckAndOr";
            this.ckAndOr.Size = new System.Drawing.Size(80, 17);
            this.ckAndOr.TabIndex = 7;
            this.ckAndOr.Text = "And / OR";
            this.ckAndOr.UseVisualStyleBackColor = true;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(35, 294);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(187, 20);
            this.dtpToDate.TabIndex = 6;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(118, 276);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(28, 13);
            this.lblDateTo.TabIndex = 5;
            this.lblDateTo.Text = "Until";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(35, 247);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(187, 20);
            this.dtpFromDate.TabIndex = 4;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(113, 231);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(30, 13);
            this.lblDateFrom.TabIndex = 3;
            this.lblDateFrom.Text = "From";
            // 
            // clbDaysOfWeek
            // 
            this.clbDaysOfWeek.CheckOnClick = true;
            this.clbDaysOfWeek.FormattingEnabled = true;
            this.clbDaysOfWeek.Items.AddRange(new object[] {
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri",
            "Sat",
            "Sun"});
            this.clbDaysOfWeek.Location = new System.Drawing.Point(71, 40);
            this.clbDaysOfWeek.Name = "clbDaysOfWeek";
            this.clbDaysOfWeek.Size = new System.Drawing.Size(114, 109);
            this.clbDaysOfWeek.TabIndex = 2;
            // 
            // lblDaysOfWeek
            // 
            this.lblDaysOfWeek.Location = new System.Drawing.Point(71, 16);
            this.lblDaysOfWeek.Name = "lblDaysOfWeek";
            this.lblDaysOfWeek.Size = new System.Drawing.Size(114, 21);
            this.lblDaysOfWeek.TabIndex = 0;
            this.lblDaysOfWeek.Text = "Days Of Week";
            this.lblDaysOfWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckIsShiftExclusion);
            this.groupBox2.Controls.Add(this.ckIsPostExclusion);
            this.groupBox2.Controls.Add(this.clbShiftsExcluded);
            this.groupBox2.Controls.Add(this.clbPostsExcluded);
            this.groupBox2.Controls.Add(this.clbGaurdsExcluded);
            this.groupBox2.Controls.Add(this.ckIsGaurdExclusion);
            this.groupBox2.Location = new System.Drawing.Point(270, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 211);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rull Applicable To Combination Of";
            // 
            // ckIsShiftExclusion
            // 
            this.ckIsShiftExclusion.AutoSize = true;
            this.ckIsShiftExclusion.Location = new System.Drawing.Point(441, 27);
            this.ckIsShiftExclusion.Name = "ckIsShiftExclusion";
            this.ckIsShiftExclusion.Size = new System.Drawing.Size(52, 17);
            this.ckIsShiftExclusion.TabIndex = 0;
            this.ckIsShiftExclusion.Text = "Shifts";
            this.ckIsShiftExclusion.UseVisualStyleBackColor = true;
            this.ckIsShiftExclusion.CheckedChanged += new System.EventHandler(this.ckIsShiftExclusion_CheckedChanged);
            // 
            // ckIsPostExclusion
            // 
            this.ckIsPostExclusion.AutoSize = true;
            this.ckIsPostExclusion.Location = new System.Drawing.Point(298, 27);
            this.ckIsPostExclusion.Name = "ckIsPostExclusion";
            this.ckIsPostExclusion.Size = new System.Drawing.Size(52, 17);
            this.ckIsPostExclusion.TabIndex = 0;
            this.ckIsPostExclusion.Text = "Posts";
            this.ckIsPostExclusion.UseVisualStyleBackColor = true;
            this.ckIsPostExclusion.CheckedChanged += new System.EventHandler(this.ckIsPostExclusion_CheckedChanged);
            // 
            // clbShiftsExcluded
            // 
            this.clbShiftsExcluded.CheckOnClick = true;
            this.clbShiftsExcluded.FormattingEnabled = true;
            this.clbShiftsExcluded.HorizontalScrollbar = true;
            this.clbShiftsExcluded.Location = new System.Drawing.Point(416, 52);
            this.clbShiftsExcluded.Name = "clbShiftsExcluded";
            this.clbShiftsExcluded.Size = new System.Drawing.Size(160, 154);
            this.clbShiftsExcluded.TabIndex = 1;
            // 
            // clbPostsExcluded
            // 
            this.clbPostsExcluded.CheckOnClick = true;
            this.clbPostsExcluded.FormattingEnabled = true;
            this.clbPostsExcluded.HorizontalScrollbar = true;
            this.clbPostsExcluded.Location = new System.Drawing.Point(249, 52);
            this.clbPostsExcluded.Name = "clbPostsExcluded";
            this.clbPostsExcluded.Size = new System.Drawing.Size(161, 154);
            this.clbPostsExcluded.TabIndex = 1;
            // 
            // clbGaurdsExcluded
            // 
            this.clbGaurdsExcluded.CheckOnClick = true;
            this.clbGaurdsExcluded.FormattingEnabled = true;
            this.clbGaurdsExcluded.HorizontalScrollbar = true;
            this.clbGaurdsExcluded.Location = new System.Drawing.Point(6, 52);
            this.clbGaurdsExcluded.Name = "clbGaurdsExcluded";
            this.clbGaurdsExcluded.Size = new System.Drawing.Size(237, 154);
            this.clbGaurdsExcluded.TabIndex = 1;
            // 
            // ckIsGaurdExclusion
            // 
            this.ckIsGaurdExclusion.AutoSize = true;
            this.ckIsGaurdExclusion.Location = new System.Drawing.Point(44, 28);
            this.ckIsGaurdExclusion.Name = "ckIsGaurdExclusion";
            this.ckIsGaurdExclusion.Size = new System.Drawing.Size(60, 17);
            this.ckIsGaurdExclusion.TabIndex = 0;
            this.ckIsGaurdExclusion.Text = "Gaurds";
            this.ckIsGaurdExclusion.UseVisualStyleBackColor = true;
            this.ckIsGaurdExclusion.CheckedChanged += new System.EventHandler(this.ckIsGaurdExclusion_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtgExclusion);
            this.groupBox5.Location = new System.Drawing.Point(0, 421);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(857, 232);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Exclusions";
            // 
            // dtgExclusion
            // 
            this.dtgExclusion.AllowUserToAddRows = false;
            this.dtgExclusion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgExclusion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgExclusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgExclusion.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgExclusion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgExclusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExclusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgExclusion.Location = new System.Drawing.Point(3, 16);
            this.dtgExclusion.MultiSelect = false;
            this.dtgExclusion.Name = "dtgExclusion";
            this.dtgExclusion.ReadOnly = true;
            this.dtgExclusion.RowHeadersWidth = 21;
            this.dtgExclusion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExclusion.Size = new System.Drawing.Size(851, 213);
            this.dtgExclusion.TabIndex = 0;
            this.dtgExclusion.SelectionChanged += new System.EventHandler(this.dtgExclusion_SelectionChanged);
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Location = new System.Drawing.Point(659, 85);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(56, 17);
            this.ckIsActive.TabIndex = 19;
            this.ckIsActive.Text = "Active";
            this.ckIsActive.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(276, 157);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(51, 13);
            this.lblDescription.TabIndex = 20;
            this.lblDescription.Text = "Comment";
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Location = new System.Drawing.Point(333, 138);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(493, 56);
            this.txtDescription.TabIndex = 21;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(295, 89);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 22;
            this.lblCode.Text = "Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(292, 115);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "Name";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(333, 86);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(196, 20);
            this.txtCode.TabIndex = 24;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(333, 112);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 20);
            this.txtName.TabIndex = 25;
            // 
            // frmExclusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 678);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmExclusion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exclusions";
            this.Load += new System.EventHandler(this.frmExclusion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExclusion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton searchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbDaysOfWeek;
        private System.Windows.Forms.Label lblDaysOfWeek;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.CheckBox ckAndOr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbGaurdsExcluded;
        private System.Windows.Forms.CheckedListBox clbPostsExcluded;
        private System.Windows.Forms.CheckBox ckIsPostExclusion;
        private System.Windows.Forms.CheckedListBox clbShiftsExcluded;
        private System.Windows.Forms.CheckBox ckIsShiftExclusion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtgExclusion;
        private System.Windows.Forms.CheckBox ckIsActive;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbDateLogic;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox ckIsGaurdExclusion;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
    }
}