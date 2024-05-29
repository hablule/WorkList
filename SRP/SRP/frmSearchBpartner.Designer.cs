namespace SRP
{
    partial class frmSearchBpartner
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
            this.cmdSrchShowResult = new System.Windows.Forms.Button();
            this.ckSrchAllOrAny = new System.Windows.Forms.CheckBox();
            this.ckIsVendor = new System.Windows.Forms.CheckBox();
            this.ckIsCustomer = new System.Windows.Forms.CheckBox();
            this.ckSrchIsActive = new System.Windows.Forms.CheckBox();
            this.txtSrchName2 = new System.Windows.Forms.TextBox();
            this.txtSrchName = new System.Windows.Forms.TextBox();
            this.cmbSrchVATLogic = new System.Windows.Forms.ComboBox();
            this.cmbSrchTINLogic = new System.Windows.Forms.ComboBox();
            this.cmbSrchName2Logic = new System.Windows.Forms.ComboBox();
            this.cmbSrchNameLogic = new System.Windows.Forms.ComboBox();
            this.lblSrchVatRegNo = new System.Windows.Forms.Label();
            this.lblSrchTIN = new System.Windows.Forms.Label();
            this.lblSrchName2 = new System.Windows.Forms.Label();
            this.lblSrchName = new System.Windows.Forms.Label();
            this.ntbSrchVAT = new SRP.ctlNumberTextBox();
            this.ntbSrchTIN = new SRP.ctlNumberTextBox();
            this.SuspendLayout();
            // 
            // cmdSrchShowResult
            // 
            this.cmdSrchShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSrchShowResult.Location = new System.Drawing.Point(218, 184);
            this.cmdSrchShowResult.Name = "cmdSrchShowResult";
            this.cmdSrchShowResult.Size = new System.Drawing.Size(109, 36);
            this.cmdSrchShowResult.TabIndex = 49;
            this.cmdSrchShowResult.Text = "Show Result";
            this.cmdSrchShowResult.UseVisualStyleBackColor = true;
            this.cmdSrchShowResult.Click += new System.EventHandler(this.cmdSrchShowResult_Click);
            // 
            // ckSrchAllOrAny
            // 
            this.ckSrchAllOrAny.AutoSize = true;
            this.ckSrchAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSrchAllOrAny.Location = new System.Drawing.Point(125, 193);
            this.ckSrchAllOrAny.Name = "ckSrchAllOrAny";
            this.ckSrchAllOrAny.Size = new System.Drawing.Size(87, 19);
            this.ckSrchAllOrAny.TabIndex = 48;
            this.ckSrchAllOrAny.Text = "All Or Any";
            this.ckSrchAllOrAny.UseVisualStyleBackColor = true;
            // 
            // ckIsVendor
            // 
            this.ckIsVendor.AutoSize = true;
            this.ckIsVendor.Checked = true;
            this.ckIsVendor.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsVendor.Location = new System.Drawing.Point(126, 111);
            this.ckIsVendor.Name = "ckIsVendor";
            this.ckIsVendor.Size = new System.Drawing.Size(86, 19);
            this.ckIsVendor.TabIndex = 45;
            this.ckIsVendor.Text = "Is Vendor";
            this.ckIsVendor.ThreeState = true;
            this.ckIsVendor.UseVisualStyleBackColor = true;
            // 
            // ckIsCustomer
            // 
            this.ckIsCustomer.AutoSize = true;
            this.ckIsCustomer.Checked = true;
            this.ckIsCustomer.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsCustomer.Location = new System.Drawing.Point(237, 111);
            this.ckIsCustomer.Name = "ckIsCustomer";
            this.ckIsCustomer.Size = new System.Drawing.Size(102, 19);
            this.ckIsCustomer.TabIndex = 46;
            this.ckIsCustomer.Text = "Is Customer";
            this.ckIsCustomer.ThreeState = true;
            this.ckIsCustomer.UseVisualStyleBackColor = true;
            // 
            // ckSrchIsActive
            // 
            this.ckSrchIsActive.AutoSize = true;
            this.ckSrchIsActive.Checked = true;
            this.ckSrchIsActive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckSrchIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSrchIsActive.Location = new System.Drawing.Point(185, 145);
            this.ckSrchIsActive.Name = "ckSrchIsActive";
            this.ckSrchIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckSrchIsActive.TabIndex = 47;
            this.ckSrchIsActive.Text = "Is Active";
            this.ckSrchIsActive.ThreeState = true;
            this.ckSrchIsActive.UseVisualStyleBackColor = true;
            // 
            // txtSrchName2
            // 
            this.txtSrchName2.Location = new System.Drawing.Point(216, 38);
            this.txtSrchName2.Name = "txtSrchName2";
            this.txtSrchName2.Size = new System.Drawing.Size(249, 20);
            this.txtSrchName2.TabIndex = 44;
            // 
            // txtSrchName
            // 
            this.txtSrchName.Location = new System.Drawing.Point(216, 14);
            this.txtSrchName.Name = "txtSrchName";
            this.txtSrchName.Size = new System.Drawing.Size(249, 20);
            this.txtSrchName.TabIndex = 43;
            // 
            // cmbSrchVATLogic
            // 
            this.cmbSrchVATLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchVATLogic.FormattingEnabled = true;
            this.cmbSrchVATLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbSrchVATLogic.Location = new System.Drawing.Point(103, 84);
            this.cmbSrchVATLogic.Name = "cmbSrchVATLogic";
            this.cmbSrchVATLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbSrchVATLogic.TabIndex = 41;
            this.cmbSrchVATLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSrchVATLogic_SelectedIndexChanged);
            // 
            // cmbSrchTINLogic
            // 
            this.cmbSrchTINLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchTINLogic.FormattingEnabled = true;
            this.cmbSrchTINLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbSrchTINLogic.Location = new System.Drawing.Point(103, 61);
            this.cmbSrchTINLogic.Name = "cmbSrchTINLogic";
            this.cmbSrchTINLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbSrchTINLogic.TabIndex = 42;
            this.cmbSrchTINLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSrchTINLogic_SelectedIndexChanged);
            // 
            // cmbSrchName2Logic
            // 
            this.cmbSrchName2Logic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchName2Logic.FormattingEnabled = true;
            this.cmbSrchName2Logic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbSrchName2Logic.Location = new System.Drawing.Point(103, 37);
            this.cmbSrchName2Logic.Name = "cmbSrchName2Logic";
            this.cmbSrchName2Logic.Size = new System.Drawing.Size(109, 21);
            this.cmbSrchName2Logic.TabIndex = 40;
            this.cmbSrchName2Logic.SelectedIndexChanged += new System.EventHandler(this.cmbSrchName2Logic_SelectedIndexChanged);
            // 
            // cmbSrchNameLogic
            // 
            this.cmbSrchNameLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchNameLogic.FormattingEnabled = true;
            this.cmbSrchNameLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbSrchNameLogic.Location = new System.Drawing.Point(103, 13);
            this.cmbSrchNameLogic.Name = "cmbSrchNameLogic";
            this.cmbSrchNameLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbSrchNameLogic.TabIndex = 39;
            this.cmbSrchNameLogic.SelectedIndexChanged += new System.EventHandler(this.cmbSrchNameLogic_SelectedIndexChanged);
            // 
            // lblSrchVatRegNo
            // 
            this.lblSrchVatRegNo.AutoSize = true;
            this.lblSrchVatRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchVatRegNo.Location = new System.Drawing.Point(11, 87);
            this.lblSrchVatRegNo.Name = "lblSrchVatRegNo";
            this.lblSrchVatRegNo.Size = new System.Drawing.Size(87, 15);
            this.lblSrchVatRegNo.TabIndex = 37;
            this.lblSrchVatRegNo.Text = "VAT Reg No.";
            // 
            // lblSrchTIN
            // 
            this.lblSrchTIN.AutoSize = true;
            this.lblSrchTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchTIN.Location = new System.Drawing.Point(69, 64);
            this.lblSrchTIN.Name = "lblSrchTIN";
            this.lblSrchTIN.Size = new System.Drawing.Size(29, 15);
            this.lblSrchTIN.TabIndex = 38;
            this.lblSrchTIN.Text = "TIN";
            // 
            // lblSrchName2
            // 
            this.lblSrchName2.AutoSize = true;
            this.lblSrchName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchName2.Location = new System.Drawing.Point(46, 40);
            this.lblSrchName2.Name = "lblSrchName2";
            this.lblSrchName2.Size = new System.Drawing.Size(53, 15);
            this.lblSrchName2.TabIndex = 36;
            this.lblSrchName2.Text = "Name2";
            // 
            // lblSrchName
            // 
            this.lblSrchName.AutoSize = true;
            this.lblSrchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchName.Location = new System.Drawing.Point(54, 15);
            this.lblSrchName.Name = "lblSrchName";
            this.lblSrchName.Size = new System.Drawing.Size(45, 15);
            this.lblSrchName.TabIndex = 35;
            this.lblSrchName.Text = "Name";
            // 
            // ntbSrchVAT
            // 
            this.ntbSrchVAT.Align = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbSrchVAT.AllowedLength = 0;
            this.ntbSrchVAT.AllowLeadingZeros = true;
            this.ntbSrchVAT.AllowNegative = false;
            this.ntbSrchVAT.Amount = "";
            this.ntbSrchVAT.defaultAmount = "0";
            this.ntbSrchVAT.Location = new System.Drawing.Point(214, 84);
            this.ntbSrchVAT.Name = "ntbSrchVAT";
            this.ntbSrchVAT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSrchVAT.ShowThousandSeparetor = false;
            this.ntbSrchVAT.Size = new System.Drawing.Size(168, 23);
            this.ntbSrchVAT.StandardPrecision = 0;
            this.ntbSrchVAT.TabIndex = 51;
            // 
            // ntbSrchTIN
            // 
            this.ntbSrchTIN.Align = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbSrchTIN.AllowedLength = 10;
            this.ntbSrchTIN.AllowLeadingZeros = true;
            this.ntbSrchTIN.AllowNegative = false;
            this.ntbSrchTIN.Amount = "";
            this.ntbSrchTIN.defaultAmount = "0";
            this.ntbSrchTIN.Location = new System.Drawing.Point(214, 59);
            this.ntbSrchTIN.Name = "ntbSrchTIN";
            this.ntbSrchTIN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbSrchTIN.ShowThousandSeparetor = false;
            this.ntbSrchTIN.Size = new System.Drawing.Size(168, 23);
            this.ntbSrchTIN.StandardPrecision = 0;
            this.ntbSrchTIN.TabIndex = 50;
            // 
            // frmSearchBpartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 225);
            this.Controls.Add(this.ntbSrchVAT);
            this.Controls.Add(this.ntbSrchTIN);
            this.Controls.Add(this.cmdSrchShowResult);
            this.Controls.Add(this.ckSrchAllOrAny);
            this.Controls.Add(this.ckIsVendor);
            this.Controls.Add(this.ckIsCustomer);
            this.Controls.Add(this.ckSrchIsActive);
            this.Controls.Add(this.txtSrchName2);
            this.Controls.Add(this.txtSrchName);
            this.Controls.Add(this.cmbSrchVATLogic);
            this.Controls.Add(this.cmbSrchTINLogic);
            this.Controls.Add(this.cmbSrchName2Logic);
            this.Controls.Add(this.cmbSrchNameLogic);
            this.Controls.Add(this.lblSrchVatRegNo);
            this.Controls.Add(this.lblSrchTIN);
            this.Controls.Add(this.lblSrchName2);
            this.Controls.Add(this.lblSrchName);
            this.Name = "frmSearchBpartner";
            this.Text = "frmSearchBpartner";
            this.Load += new System.EventHandler(this.frmSearchBpartner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlNumberTextBox ntbSrchVAT;
        private ctlNumberTextBox ntbSrchTIN;
        private System.Windows.Forms.Button cmdSrchShowResult;
        private System.Windows.Forms.CheckBox ckSrchAllOrAny;
        private System.Windows.Forms.CheckBox ckIsVendor;
        private System.Windows.Forms.CheckBox ckIsCustomer;
        private System.Windows.Forms.CheckBox ckSrchIsActive;
        private System.Windows.Forms.TextBox txtSrchName2;
        private System.Windows.Forms.TextBox txtSrchName;
        private System.Windows.Forms.ComboBox cmbSrchVATLogic;
        private System.Windows.Forms.ComboBox cmbSrchTINLogic;
        private System.Windows.Forms.ComboBox cmbSrchName2Logic;
        private System.Windows.Forms.ComboBox cmbSrchNameLogic;
        private System.Windows.Forms.Label lblSrchVatRegNo;
        private System.Windows.Forms.Label lblSrchTIN;
        private System.Windows.Forms.Label lblSrchName2;
        private System.Windows.Forms.Label lblSrchName;
    }
}