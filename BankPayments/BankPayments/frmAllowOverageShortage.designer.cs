namespace BankPayments
{
    partial class frmAllowOverageShortage
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblEncryptionKey = new System.Windows.Forms.Label();
            this.cmdActivate = new System.Windows.Forms.Button();
            this.ntbEncription = new customControls.ctlNumberTextBox();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(5, 10);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(364, 23);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Customer - - Invoice";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEncryptionKey
            // 
            this.lblEncryptionKey.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptionKey.ForeColor = System.Drawing.Color.Red;
            this.lblEncryptionKey.Location = new System.Drawing.Point(73, 39);
            this.lblEncryptionKey.Name = "lblEncryptionKey";
            this.lblEncryptionKey.Size = new System.Drawing.Size(100, 30);
            this.lblEncryptionKey.TabIndex = 1;
            this.lblEncryptionKey.Text = "0000";
            this.lblEncryptionKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdActivate
            // 
            this.cmdActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdActivate.ForeColor = System.Drawing.Color.Chartreuse;
            this.cmdActivate.Location = new System.Drawing.Point(46, 72);
            this.cmdActivate.Name = "cmdActivate";
            this.cmdActivate.Size = new System.Drawing.Size(270, 35);
            this.cmdActivate.TabIndex = 3;
            this.cmdActivate.Text = "Allow Amount";
            this.cmdActivate.UseVisualStyleBackColor = true;
            this.cmdActivate.Click += new System.EventHandler(this.cmdActivate_Click);
            // 
            // ntbEncription
            // 
            this.ntbEncription.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbEncription.AllowedLength = 0;
            this.ntbEncription.AllowLeadingZeros = true;
            this.ntbEncription.AllowNegative = false;
            this.ntbEncription.Amount = "";
            this.ntbEncription.defaultAmount = "0";
            this.ntbEncription.Location = new System.Drawing.Point(185, 42);
            this.ntbEncription.Name = "ntbEncription";
            this.ntbEncription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbEncription.ShowThousandSeparetor = false;
            this.ntbEncription.Size = new System.Drawing.Size(94, 23);
            this.ntbEncription.StandardPrecision = 0;
            this.ntbEncription.TabIndex = 2;
            // 
            // frmAllowOverageShortage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 113);
            this.Controls.Add(this.cmdActivate);
            this.Controls.Add(this.ntbEncription);
            this.Controls.Add(this.lblEncryptionKey);
            this.Controls.Add(this.lblProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllowOverageShortage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Allow Amount";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAllowOverageShortage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblEncryptionKey;
        private customControls.ctlNumberTextBox ntbEncription;
        private System.Windows.Forms.Button cmdActivate;
    }
}