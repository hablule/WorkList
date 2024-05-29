namespace BankPayments
{
    partial class frmNewBpartner
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckIsVendor = new System.Windows.Forms.CheckBox();
            this.ckIsCustomer = new System.Windows.Forms.CheckBox();
            this.ckIsEmployee = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.cmdSaveAndUse = new System.Windows.Forms.Button();
            this.ntbTIN = new customControls.ctlNumberTextBox();
            this.cmbCashBook = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "TIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fax";
            // 
            // ckIsVendor
            // 
            this.ckIsVendor.AutoSize = true;
            this.ckIsVendor.Location = new System.Drawing.Point(48, 137);
            this.ckIsVendor.Name = "ckIsVendor";
            this.ckIsVendor.Size = new System.Drawing.Size(71, 17);
            this.ckIsVendor.TabIndex = 4;
            this.ckIsVendor.Text = "Is Vendor";
            this.ckIsVendor.UseVisualStyleBackColor = true;
            // 
            // ckIsCustomer
            // 
            this.ckIsCustomer.AutoSize = true;
            this.ckIsCustomer.Location = new System.Drawing.Point(162, 137);
            this.ckIsCustomer.Name = "ckIsCustomer";
            this.ckIsCustomer.Size = new System.Drawing.Size(81, 17);
            this.ckIsCustomer.TabIndex = 5;
            this.ckIsCustomer.Text = "Is Customer";
            this.ckIsCustomer.UseVisualStyleBackColor = true;
            // 
            // ckIsEmployee
            // 
            this.ckIsEmployee.AutoSize = true;
            this.ckIsEmployee.Location = new System.Drawing.Point(285, 137);
            this.ckIsEmployee.Name = "ckIsEmployee";
            this.ckIsEmployee.Size = new System.Drawing.Size(83, 17);
            this.ckIsEmployee.TabIndex = 6;
            this.ckIsEmployee.Text = "Is Employee";
            this.ckIsEmployee.UseVisualStyleBackColor = true;
            this.ckIsEmployee.CheckedChanged += new System.EventHandler(this.ckIsEmployee_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(317, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(76, 39);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(221, 20);
            this.txtPhone.TabIndex = 1;
            // 
            // txtFax
            // 
            this.txtFax.AcceptsReturn = true;
            this.txtFax.Location = new System.Drawing.Point(76, 94);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(230, 20);
            this.txtFax.TabIndex = 3;
            // 
            // cmdSaveAndUse
            // 
            this.cmdSaveAndUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveAndUse.Location = new System.Drawing.Point(114, 212);
            this.cmdSaveAndUse.Name = "cmdSaveAndUse";
            this.cmdSaveAndUse.Size = new System.Drawing.Size(203, 50);
            this.cmdSaveAndUse.TabIndex = 8;
            this.cmdSaveAndUse.Text = "Save and Use";
            this.cmdSaveAndUse.UseVisualStyleBackColor = true;
            this.cmdSaveAndUse.Click += new System.EventHandler(this.cmdSaveAndUse_Click);
            // 
            // ntbTIN
            // 
            this.ntbTIN.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTIN.AllowedLength = 10;
            this.ntbTIN.AllowLeadingZeros = false;
            this.ntbTIN.AllowNegative = false;
            this.ntbTIN.Amount = "";
            this.ntbTIN.defaultAmount = "0";
            this.ntbTIN.Location = new System.Drawing.Point(75, 64);
            this.ntbTIN.Name = "ntbTIN";
            this.ntbTIN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTIN.ShowThousandSeparetor = true;
            this.ntbTIN.Size = new System.Drawing.Size(138, 23);
            this.ntbTIN.StandardPrecision = 2;
            this.ntbTIN.TabIndex = 2;
            // 
            // cmbCashBook
            // 
            this.cmbCashBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashBook.FormattingEnabled = true;
            this.cmbCashBook.Location = new System.Drawing.Point(94, 173);
            this.cmbCashBook.Name = "cmbCashBook";
            this.cmbCashBook.Size = new System.Drawing.Size(241, 21);
            this.cmbCashBook.TabIndex = 7;
            this.cmbCashBook.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cash Book";
            this.label5.Visible = false;
            // 
            // frmNewBpartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 276);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCashBook);
            this.Controls.Add(this.ntbTIN);
            this.Controls.Add(this.cmdSaveAndUse);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.ckIsEmployee);
            this.Controls.Add(this.ckIsCustomer);
            this.Controls.Add(this.ckIsVendor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewBpartner";
            this.Text = "New Business partner";
            this.Load += new System.EventHandler(this.frmNewBpartner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckIsVendor;
        private System.Windows.Forms.CheckBox ckIsCustomer;
        private System.Windows.Forms.CheckBox ckIsEmployee;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Button cmdSaveAndUse;
        private customControls.ctlNumberTextBox ntbTIN;
        private System.Windows.Forms.ComboBox cmbCashBook;
        private System.Windows.Forms.Label label5;
    }
}