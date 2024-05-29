namespace stockActivityReporter
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
            this.crpvDetailStockActivity = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptDetailStockActivity = new stockActivityReporter.rptDetailStockActivity();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.rptSummarizedStockActivity = new stockActivityReporter.rptSummarizedStockActivity();
            this.rptCountSheet = new stockActivityReporter.rptCountSheet();
            this.SuspendLayout();
            // 
            // crpvDetailStockActivity
            // 
            this.crpvDetailStockActivity.ActiveViewIndex = -1;
            this.crpvDetailStockActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpvDetailStockActivity.DisplayGroupTree = false;
            this.crpvDetailStockActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpvDetailStockActivity.Location = new System.Drawing.Point(0, 0);
            this.crpvDetailStockActivity.Name = "crpvDetailStockActivity";
            this.crpvDetailStockActivity.SelectionFormula = "";
            this.crpvDetailStockActivity.ShowCloseButton = false;
            this.crpvDetailStockActivity.ShowGroupTreeButton = false;
            this.crpvDetailStockActivity.ShowPrintButton = false;
            this.crpvDetailStockActivity.ShowRefreshButton = false;
            this.crpvDetailStockActivity.ShowTextSearchButton = false;
            this.crpvDetailStockActivity.Size = new System.Drawing.Size(498, 459);
            this.crpvDetailStockActivity.TabIndex = 0;
            this.crpvDetailStockActivity.ViewTimeSelectionFormula = "";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Location = new System.Drawing.Point(457, 0);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(41, 23);
            this.cmdPrint.TabIndex = 1;
            this.cmdPrint.Text = "print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // frmPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 459);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.crpvDetailStockActivity);
            this.Name = "frmPrintPreview";
            this.Text = "Print Preview";
            this.Load += new System.EventHandler(this.frmPrintPreview_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrintPreview_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpvDetailStockActivity;
        private rptDetailStockActivity rptDetailStockActivity;
        private System.Windows.Forms.Button cmdPrint;
        private rptSummarizedStockActivity rptSummarizedStockActivity;
        private rptCountSheet rptCountSheet;

    }
}