namespace SecurityGuardScheduling
{
    partial class frmMainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.cmdGaruds = new System.Windows.Forms.Button();
            this.cmdPosts = new System.Windows.Forms.Button();
            this.cmdShifts = new System.Windows.Forms.Button();
            this.cmdExclusions = new System.Windows.Forms.Button();
            this.cmdGenerateGaurdSchedule = new System.Windows.Forms.Button();
            this.ckRegenerate = new System.Windows.Forms.CheckBox();
            this.dtpSchedulEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpSchedulStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prgbScheduleGeranated = new System.Windows.Forms.ProgressBar();
            this.cmdShow = new System.Windows.Forms.Button();
            this.cmdSaveReportToFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrGarbageCollector = new System.Windows.Forms.Timer(this.components);
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGaruds
            // 
            this.cmdGaruds.Location = new System.Drawing.Point(176, 12);
            this.cmdGaruds.Name = "cmdGaruds";
            this.cmdGaruds.Size = new System.Drawing.Size(93, 23);
            this.cmdGaruds.TabIndex = 0;
            this.cmdGaruds.Text = "Gaurds";
            this.cmdGaruds.UseVisualStyleBackColor = true;
            this.cmdGaruds.Click += new System.EventHandler(this.cmdGaruds_Click);
            // 
            // cmdPosts
            // 
            this.cmdPosts.Location = new System.Drawing.Point(138, 39);
            this.cmdPosts.Name = "cmdPosts";
            this.cmdPosts.Size = new System.Drawing.Size(168, 23);
            this.cmdPosts.TabIndex = 1;
            this.cmdPosts.Text = "Posts";
            this.cmdPosts.UseVisualStyleBackColor = true;
            this.cmdPosts.Click += new System.EventHandler(this.cmdPosts_Click);
            // 
            // cmdShifts
            // 
            this.cmdShifts.Location = new System.Drawing.Point(113, 66);
            this.cmdShifts.Name = "cmdShifts";
            this.cmdShifts.Size = new System.Drawing.Size(219, 23);
            this.cmdShifts.TabIndex = 2;
            this.cmdShifts.Text = "Shifts";
            this.cmdShifts.UseVisualStyleBackColor = true;
            this.cmdShifts.Click += new System.EventHandler(this.cmdShifts_Click);
            // 
            // cmdExclusions
            // 
            this.cmdExclusions.Location = new System.Drawing.Point(82, 93);
            this.cmdExclusions.Name = "cmdExclusions";
            this.cmdExclusions.Size = new System.Drawing.Size(281, 23);
            this.cmdExclusions.TabIndex = 3;
            this.cmdExclusions.Text = "Exclusions";
            this.cmdExclusions.UseVisualStyleBackColor = true;
            this.cmdExclusions.Click += new System.EventHandler(this.cmdExclusions_Click);
            // 
            // cmdGenerateGaurdSchedule
            // 
            this.cmdGenerateGaurdSchedule.Location = new System.Drawing.Point(138, 84);
            this.cmdGenerateGaurdSchedule.Name = "cmdGenerateGaurdSchedule";
            this.cmdGenerateGaurdSchedule.Size = new System.Drawing.Size(168, 65);
            this.cmdGenerateGaurdSchedule.TabIndex = 4;
            this.cmdGenerateGaurdSchedule.Text = "Generate Schedule For Period";
            this.cmdGenerateGaurdSchedule.UseVisualStyleBackColor = true;
            this.cmdGenerateGaurdSchedule.Click += new System.EventHandler(this.cmdGenerateGaurdSchedule_Click);
            // 
            // ckRegenerate
            // 
            this.ckRegenerate.Location = new System.Drawing.Point(136, 52);
            this.ckRegenerate.Name = "ckRegenerate";
            this.ckRegenerate.Size = new System.Drawing.Size(156, 31);
            this.ckRegenerate.TabIndex = 5;
            this.ckRegenerate.Text = "Re-Generate Schedule";
            this.ckRegenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckRegenerate.UseVisualStyleBackColor = true;
            // 
            // dtpSchedulEnd
            // 
            this.dtpSchedulEnd.Location = new System.Drawing.Point(230, 27);
            this.dtpSchedulEnd.Name = "dtpSchedulEnd";
            this.dtpSchedulEnd.Size = new System.Drawing.Size(187, 20);
            this.dtpSchedulEnd.TabIndex = 6;
            // 
            // dtpSchedulStart
            // 
            this.dtpSchedulStart.Location = new System.Drawing.Point(23, 27);
            this.dtpSchedulStart.Name = "dtpSchedulStart";
            this.dtpSchedulStart.Size = new System.Drawing.Size(187, 20);
            this.dtpSchedulStart.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prgbScheduleGeranated);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.cmdSaveReportToFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckRegenerate);
            this.groupBox1.Controls.Add(this.cmdGenerateGaurdSchedule);
            this.groupBox1.Controls.Add(this.dtpSchedulStart);
            this.groupBox1.Controls.Add(this.dtpSchedulEnd);
            this.groupBox1.Location = new System.Drawing.Point(14, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 190);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Schedule";
            // 
            // prgbScheduleGeranated
            // 
            this.prgbScheduleGeranated.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.prgbScheduleGeranated.Location = new System.Drawing.Point(6, 155);
            this.prgbScheduleGeranated.MarqueeAnimationSpeed = 10;
            this.prgbScheduleGeranated.Name = "prgbScheduleGeranated";
            this.prgbScheduleGeranated.Size = new System.Drawing.Size(432, 25);
            this.prgbScheduleGeranated.Step = 1;
            this.prgbScheduleGeranated.TabIndex = 11;
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(312, 116);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(67, 20);
            this.cmdShow.TabIndex = 10;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // cmdSaveReportToFile
            // 
            this.cmdSaveReportToFile.Location = new System.Drawing.Point(312, 93);
            this.cmdSaveReportToFile.Name = "cmdSaveReportToFile";
            this.cmdSaveReportToFile.Size = new System.Drawing.Size(67, 20);
            this.cmdSaveReportToFile.TabIndex = 9;
            this.cmdSaveReportToFile.Text = "Save";
            this.cmdSaveReportToFile.UseVisualStyleBackColor = true;
            this.cmdSaveReportToFile.Click += new System.EventHandler(this.cmdSaveReportToFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "-";
            // 
            // tmrGarbageCollector
            // 
            this.tmrGarbageCollector.Interval = 30000;
            this.tmrGarbageCollector.Tick += new System.EventHandler(this.tmrGarbageCollector_Tick);
            // 
            // visualStyler1
            // 
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle(null, "OSX (Brushed).vssf");
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 314);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdExclusions);
            this.Controls.Add(this.cmdShifts);
            this.Controls.Add(this.cmdPosts);
            this.Controls.Add(this.cmdGaruds);
            this.Name = "frmMainMenu";
            this.Text = "Security Gaurd Schedule (v1.2j)";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.DoubleClick += new System.EventHandler(this.frmMainMenu_DoubleClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdGaruds;
        private System.Windows.Forms.Button cmdPosts;
        private System.Windows.Forms.Button cmdShifts;
        private System.Windows.Forms.Button cmdExclusions;
        private System.Windows.Forms.Button cmdGenerateGaurdSchedule;
        private System.Windows.Forms.CheckBox ckRegenerate;
        private System.Windows.Forms.DateTimePicker dtpSchedulEnd;
        private System.Windows.Forms.DateTimePicker dtpSchedulStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrGarbageCollector;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Button cmdSaveReportToFile;
        private System.Windows.Forms.ProgressBar prgbScheduleGeranated;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
    }
}