namespace SRP
{
    partial class frmPrintViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintViewer));
            this.crvPrintPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crptReportContent = new SRP.crptAttachmentInvoice();
            this.SuspendLayout();
            // 
            // crvPrintPreview
            // 
            this.crvPrintPreview.ActiveViewIndex = -1;
            this.crvPrintPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrintPreview.DisplayGroupTree = false;
            this.crvPrintPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPrintPreview.Location = new System.Drawing.Point(0, 0);
            this.crvPrintPreview.Name = "crvPrintPreview";
            this.crvPrintPreview.Size = new System.Drawing.Size(444, 489);
            this.crvPrintPreview.TabIndex = 0;
            // 
            // frmPrintViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 489);
            this.Controls.Add(this.crvPrintPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrintViewer";
            this.Text = "Print Preview";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrintPreview;
        private crptAttachmentInvoice crptReportContent;
    }
}