namespace EasyMove
{
    partial class frmManualDocInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManualDocumentNumber = new System.Windows.Forms.TextBox();
            this.dtpManualDocumentDate = new System.Windows.Forms.DateTimePicker();
            this.cmdChange = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Document Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtManualDocumentNumber
            // 
            this.txtManualDocumentNumber.Location = new System.Drawing.Point(98, 24);
            this.txtManualDocumentNumber.Name = "txtManualDocumentNumber";
            this.txtManualDocumentNumber.Size = new System.Drawing.Size(163, 20);
            this.txtManualDocumentNumber.TabIndex = 2;
            // 
            // dtpManualDocumentDate
            // 
            this.dtpManualDocumentDate.Location = new System.Drawing.Point(98, 53);
            this.dtpManualDocumentDate.Name = "dtpManualDocumentDate";
            this.dtpManualDocumentDate.Size = new System.Drawing.Size(200, 20);
            this.dtpManualDocumentDate.TabIndex = 3;
            // 
            // cmdChange
            // 
            this.cmdChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChange.ForeColor = System.Drawing.Color.GreenYellow;
            this.cmdChange.Location = new System.Drawing.Point(64, 96);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(208, 47);
            this.cmdChange.TabIndex = 4;
            this.cmdChange.Text = "Change Document";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.Red;
            this.cmdCancel.Location = new System.Drawing.Point(99, 150);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(128, 30);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmManualDocInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 200);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdChange);
            this.Controls.Add(this.dtpManualDocumentDate);
            this.Controls.Add(this.txtManualDocumentNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmManualDocInfo";
            this.Text = "Manual Document Info";
            this.Load += new System.EventHandler(this.frmManualDocInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManualDocumentNumber;
        private System.Windows.Forms.DateTimePicker dtpManualDocumentDate;
        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.Button cmdCancel;
    }
}