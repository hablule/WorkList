namespace POSDocumentPrinter
{
    partial class ctlNumberTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNumberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNumberTextBox
            // 
            this.txtNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumberTextBox.Location = new System.Drawing.Point(2, 1);
            this.txtNumberTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.txtNumberTextBox.Name = "txtNumberTextBox";
            this.txtNumberTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumberTextBox.Size = new System.Drawing.Size(136, 20);
            this.txtNumberTextBox.TabIndex = 0;
            this.txtNumberTextBox.WordWrap = false;
            this.txtNumberTextBox.TextChanged += new System.EventHandler(this.txtNumberTextBox_TextChanged);
            this.txtNumberTextBox.Leave += new System.EventHandler(this.txtNumberTextBox_LostFocus);
            this.txtNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberTextBox_UserKeyedText);
            this.txtNumberTextBox.Enter += new System.EventHandler(this.txtNumberTextBox_GotFocus);
            // 
            // ctlNumberTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNumberTextBox);
            this.Name = "ctlNumberTextBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(138, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumberTextBox;
    }
}
