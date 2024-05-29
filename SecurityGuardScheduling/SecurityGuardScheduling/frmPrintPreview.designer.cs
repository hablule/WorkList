namespace SecurityGuardScheduling
{
    partial class frmPrintPreview
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
            this.crpvSchedule = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptSchedule1 = new SecurityGuardScheduling.rptSchedule();
            this.SuspendLayout();
            // 
            // crpvSchedule
            // 
            this.crpvSchedule.ActiveViewIndex = 0;
            this.crpvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpvSchedule.DisplayGroupTree = false;
            this.crpvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpvSchedule.Location = new System.Drawing.Point(0, 0);
            this.crpvSchedule.Name = "crpvSchedule";
            this.crpvSchedule.ReportSource = this.rptSchedule1;
            this.crpvSchedule.ShowCloseButton = false;
            this.crpvSchedule.ShowGroupTreeButton = false;
            this.crpvSchedule.ShowPrintButton = false;
            this.crpvSchedule.ShowRefreshButton = false;
            this.crpvSchedule.ShowTextSearchButton = false;
            this.crpvSchedule.Size = new System.Drawing.Size(498, 459);
            this.crpvSchedule.TabIndex = 0;
            // 
            // frmPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 459);
            this.Controls.Add(this.crpvSchedule);
            this.Name = "frmPrintPreview";
            this.Text = "Print Preview";
            this.Load += new System.EventHandler(this.frmPrintPreview_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrintPreview_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpvSchedule;
        private rptSchedule rptSchedule1;
        

    }
}