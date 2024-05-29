namespace BuySimple
{
    partial class frmDocPrintPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocPrintPreview));
            this.crpvPOSDocumentPrintPrivew = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmdPrintDocument = new System.Windows.Forms.Button();
            this.crptDocumentToPrint = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.SuspendLayout();
            // 
            // crpvPOSDocumentPrintPrivew
            // 
            this.crpvPOSDocumentPrintPrivew.ActiveViewIndex = -1;
            this.crpvPOSDocumentPrintPrivew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpvPOSDocumentPrintPrivew.DisplayBackgroundEdge = false;
            this.crpvPOSDocumentPrintPrivew.DisplayGroupTree = false;
            this.crpvPOSDocumentPrintPrivew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpvPOSDocumentPrintPrivew.EnableDrillDown = false;
            this.crpvPOSDocumentPrintPrivew.Location = new System.Drawing.Point(0, 0);
            this.crpvPOSDocumentPrintPrivew.Name = "crpvPOSDocumentPrintPrivew";
            this.crpvPOSDocumentPrintPrivew.SelectionFormula = "";
            this.crpvPOSDocumentPrintPrivew.ShowCloseButton = false;
            this.crpvPOSDocumentPrintPrivew.ShowGotoPageButton = false;
            this.crpvPOSDocumentPrintPrivew.ShowGroupTreeButton = false;
            this.crpvPOSDocumentPrintPrivew.ShowPrintButton = false;
            this.crpvPOSDocumentPrintPrivew.ShowRefreshButton = false;
            this.crpvPOSDocumentPrintPrivew.ShowTextSearchButton = false;
            this.crpvPOSDocumentPrintPrivew.Size = new System.Drawing.Size(477, 488);
            this.crpvPOSDocumentPrintPrivew.TabIndex = 0;
            this.crpvPOSDocumentPrintPrivew.ViewTimeSelectionFormula = "";
            // 
            // cmdPrintDocument
            // 
            this.cmdPrintDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrintDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintDocument.ForeColor = System.Drawing.Color.Red;
            this.cmdPrintDocument.Location = new System.Drawing.Point(402, 0);
            this.cmdPrintDocument.Name = "cmdPrintDocument";
            this.cmdPrintDocument.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintDocument.TabIndex = 1;
            this.cmdPrintDocument.Text = "Print";
            this.cmdPrintDocument.UseVisualStyleBackColor = true;
            this.cmdPrintDocument.Click += new System.EventHandler(this.cmdPrintDocument_Click);
            // 
            // frmDocPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 488);
            this.Controls.Add(this.cmdPrintDocument);
            this.Controls.Add(this.crpvPOSDocumentPrintPrivew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDocPrintPreview";
            this.Text = "Print Preview";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDocPrintPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpvPOSDocumentPrintPrivew;
        private System.Windows.Forms.Button cmdPrintDocument;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument crptDocumentToPrint;


    }
}