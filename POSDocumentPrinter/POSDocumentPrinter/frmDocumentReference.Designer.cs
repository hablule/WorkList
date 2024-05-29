namespace POSDocumentPrinter
{
    partial class frmDocumentReference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentReference));
            this.cmdRecordDocumentReferecne = new System.Windows.Forms.Button();
            this.lblReferenceNumber = new System.Windows.Forms.Label();
            this.lblDocumentNote = new System.Windows.Forms.Label();
            this.txtDocumentNote = new System.Windows.Forms.TextBox();
            this.lblSalesReference = new System.Windows.Forms.Label();
            this.ctlSalesReferenceNumber = new POSDocumentPrinter.ctlNumberTextBox();
            this.ctlReferenceNumber = new POSDocumentPrinter.ctlNumberTextBox();
            this.SuspendLayout();
            // 
            // cmdRecordDocumentReferecne
            // 
            this.cmdRecordDocumentReferecne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRecordDocumentReferecne.Location = new System.Drawing.Point(16, 177);
            this.cmdRecordDocumentReferecne.Name = "cmdRecordDocumentReferecne";
            this.cmdRecordDocumentReferecne.Size = new System.Drawing.Size(326, 36);
            this.cmdRecordDocumentReferecne.TabIndex = 0;
            this.cmdRecordDocumentReferecne.Text = "Record";
            this.cmdRecordDocumentReferecne.UseVisualStyleBackColor = true;
            this.cmdRecordDocumentReferecne.Click += new System.EventHandler(this.cmdRecordDocumentReferecne_Click);
            // 
            // lblReferenceNumber
            // 
            this.lblReferenceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNumber.Location = new System.Drawing.Point(10, 9);
            this.lblReferenceNumber.Name = "lblReferenceNumber";
            this.lblReferenceNumber.Size = new System.Drawing.Size(115, 17);
            this.lblReferenceNumber.TabIndex = 1;
            this.lblReferenceNumber.Text = "Reference Number";
            this.lblReferenceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentNote
            // 
            this.lblDocumentNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNote.Location = new System.Drawing.Point(10, 87);
            this.lblDocumentNote.Name = "lblDocumentNote";
            this.lblDocumentNote.Size = new System.Drawing.Size(95, 64);
            this.lblDocumentNote.TabIndex = 2;
            this.lblDocumentNote.Text = "Document Note";
            this.lblDocumentNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNote
            // 
            this.txtDocumentNote.Location = new System.Drawing.Point(111, 73);
            this.txtDocumentNote.Multiline = true;
            this.txtDocumentNote.Name = "txtDocumentNote";
            this.txtDocumentNote.Size = new System.Drawing.Size(239, 93);
            this.txtDocumentNote.TabIndex = 4;
            // 
            // lblSalesReference
            // 
            this.lblSalesReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesReference.Location = new System.Drawing.Point(16, 44);
            this.lblSalesReference.Name = "lblSalesReference";
            this.lblSalesReference.Size = new System.Drawing.Size(111, 17);
            this.lblSalesReference.TabIndex = 6;
            this.lblSalesReference.Text = "Sales Ref Number";
            this.lblSalesReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctlSalesReferenceNumber
            // 
            this.ctlSalesReferenceNumber.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlSalesReferenceNumber.AllowedLength = 0;
            this.ctlSalesReferenceNumber.AllowLeadingZeros = false;
            this.ctlSalesReferenceNumber.AllowNegative = false;
            this.ctlSalesReferenceNumber.Amount = "";
            this.ctlSalesReferenceNumber.defaultAmount = "0";
            this.ctlSalesReferenceNumber.Location = new System.Drawing.Point(131, 42);
            this.ctlSalesReferenceNumber.Name = "ctlSalesReferenceNumber";
            this.ctlSalesReferenceNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctlSalesReferenceNumber.ShowThousandSeparetor = true;
            this.ctlSalesReferenceNumber.Size = new System.Drawing.Size(155, 23);
            this.ctlSalesReferenceNumber.StandardPrecision = 0;
            this.ctlSalesReferenceNumber.TabIndex = 7;
            // 
            // ctlReferenceNumber
            // 
            this.ctlReferenceNumber.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlReferenceNumber.AllowedLength = 0;
            this.ctlReferenceNumber.AllowLeadingZeros = false;
            this.ctlReferenceNumber.AllowNegative = false;
            this.ctlReferenceNumber.Amount = "";
            this.ctlReferenceNumber.defaultAmount = "0";
            this.ctlReferenceNumber.Location = new System.Drawing.Point(131, 9);
            this.ctlReferenceNumber.Name = "ctlReferenceNumber";
            this.ctlReferenceNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctlReferenceNumber.ShowThousandSeparetor = true;
            this.ctlReferenceNumber.Size = new System.Drawing.Size(102, 23);
            this.ctlReferenceNumber.StandardPrecision = 0;
            this.ctlReferenceNumber.TabIndex = 5;
            // 
            // frmDocumentReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 220);
            this.Controls.Add(this.ctlSalesReferenceNumber);
            this.Controls.Add(this.lblSalesReference);
            this.Controls.Add(this.ctlReferenceNumber);
            this.Controls.Add(this.txtDocumentNote);
            this.Controls.Add(this.lblDocumentNote);
            this.Controls.Add(this.lblReferenceNumber);
            this.Controls.Add(this.cmdRecordDocumentReferecne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocumentReference";
            this.Text = "Document Reference";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDocumentReference_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocumentReference_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRecordDocumentReferecne;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.Label lblDocumentNote;
        private System.Windows.Forms.TextBox txtDocumentNote;
        private ctlNumberTextBox ctlReferenceNumber;
        private ctlNumberTextBox ctlSalesReferenceNumber;
        private System.Windows.Forms.Label lblSalesReference;
    }
}