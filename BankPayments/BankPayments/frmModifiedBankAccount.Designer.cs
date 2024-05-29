namespace BankPayments
{
    partial class frmModifiedBankAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifiedBankAccount));
            this.cmdChange = new System.Windows.Forms.Button();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.ddgBankAccount = new customControls.DropDownDataGrid();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.ddgInvoice = new customControls.DropDownDataGrid();
            this.ckIsCustomer = new System.Windows.Forms.CheckBox();
            this.cmdNew = new System.Windows.Forms.Button();
            this.ntbAmount = new customControls.ctlNumberTextBox();
            this.lblPayee = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.ddgPayee = new customControls.DropDownDataGrid();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdChange
            // 
            this.cmdChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChange.ForeColor = System.Drawing.Color.Red;
            this.cmdChange.Location = new System.Drawing.Point(41, 336);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(401, 38);
            this.cmdChange.TabIndex = 0;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(38, 178);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(75, 13);
            this.lblBankAccount.TabIndex = 7;
            this.lblBankAccount.Text = "Bank Account";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddgBankAccount
            // 
            this.ddgBankAccount.AutoFilter = true;
            this.ddgBankAccount.AutoSize = true;
            this.ddgBankAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBankAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBankAccount.ClearButtonEnabled = true;
            this.ddgBankAccount.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBankAccount.Enabled = false;
            this.ddgBankAccount.FindButtonEnabled = true;
            this.ddgBankAccount.HiddenColoumns = new int[0];
            this.ddgBankAccount.Image = null;
            this.ddgBankAccount.Location = new System.Drawing.Point(116, 170);
            this.ddgBankAccount.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBankAccount.Name = "ddgBankAccount";
            this.ddgBankAccount.NewButtonEnabled = true;
            this.ddgBankAccount.RefreshButtonEnabled = true;
            this.ddgBankAccount.SelectedColomnIdex = 0;
            this.ddgBankAccount.SelectedItem = "";
            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.ShowGridFunctions = false;
            this.ddgBankAccount.Size = new System.Drawing.Size(316, 31);
            this.ddgBankAccount.TabIndex = 6;
            this.ddgBankAccount.SelectedItemClicked += new System.EventHandler(this.ddgBankAccount_SelectedItemClicked);
            this.ddgBankAccount.selectedItemChanged += new System.EventHandler(this.ddgBankAccount_selectedItemChanged);
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Enabled = false;
            this.txtCheckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckNo.Location = new System.Drawing.Point(119, 209);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(210, 21);
            this.txtCheckNo.TabIndex = 8;
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.Location = new System.Drawing.Point(58, 213);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(55, 13);
            this.lblCheckNo.TabIndex = 9;
            this.lblCheckNo.Text = "Check No";
            this.lblCheckNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(160, 15);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(73, 13);
            this.lblDocumentNo.TabIndex = 18;
            this.lblDocumentNo.Text = "Document No";
            this.lblDocumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Enabled = false;
            this.txtDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentNo.Location = new System.Drawing.Point(238, 12);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.ReadOnly = true;
            this.txtDocumentNo.Size = new System.Drawing.Size(163, 22);
            this.txtDocumentNo.TabIndex = 19;
            this.txtDocumentNo.TabStop = false;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Enabled = false;
            this.lblInvoice.Location = new System.Drawing.Point(193, 101);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(71, 13);
            this.lblInvoice.TabIndex = 32;
            this.lblInvoice.Text = "Sales Invoice";
            this.lblInvoice.Visible = false;
            // 
            // ddgInvoice
            // 
            this.ddgInvoice.AutoFilter = true;
            this.ddgInvoice.AutoSize = true;
            this.ddgInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgInvoice.ClearButtonEnabled = true;
            this.ddgInvoice.DataTablePrimaryKey = ((ushort)(0));
            this.ddgInvoice.Enabled = false;
            this.ddgInvoice.FindButtonEnabled = true;
            this.ddgInvoice.HiddenColoumns = new int[0];
            this.ddgInvoice.Image = null;
            this.ddgInvoice.Location = new System.Drawing.Point(267, 93);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(191, 31);
            this.ddgInvoice.TabIndex = 31;
            this.ddgInvoice.Visible = false;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // ckIsCustomer
            // 
            this.ckIsCustomer.AutoSize = true;
            this.ckIsCustomer.Enabled = false;
            this.ckIsCustomer.Location = new System.Drawing.Point(75, 97);
            this.ckIsCustomer.Name = "ckIsCustomer";
            this.ckIsCustomer.Size = new System.Drawing.Size(81, 17);
            this.ckIsCustomer.TabIndex = 30;
            this.ckIsCustomer.Text = "Is Customer";
            this.ckIsCustomer.ThreeState = true;
            this.ckIsCustomer.UseVisualStyleBackColor = true;
            this.ckIsCustomer.CheckStateChanged += new System.EventHandler(this.ckIsCustomer_CheckStateChanged);
            this.ckIsCustomer.CheckedChanged += new System.EventHandler(this.ckIsCustomer_CheckedChanged);
            // 
            // cmdNew
            // 
            this.cmdNew.Enabled = false;
            this.cmdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Location = new System.Drawing.Point(429, 63);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(40, 23);
            this.cmdNew.TabIndex = 29;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // ntbAmount
            // 
            this.ntbAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmount.AllowedLength = 0;
            this.ntbAmount.AllowLeadingZeros = false;
            this.ntbAmount.AllowNegative = false;
            this.ntbAmount.Amount = "0";
            this.ntbAmount.defaultAmount = "0";
            this.ntbAmount.Enabled = false;
            this.ntbAmount.Location = new System.Drawing.Point(77, 133);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmount.ShowThousandSeparetor = true;
            this.ntbAmount.Size = new System.Drawing.Size(187, 23);
            this.ntbAmount.StandardPrecision = 2;
            this.ntbAmount.TabIndex = 26;
            // 
            // lblPayee
            // 
            this.lblPayee.AutoSize = true;
            this.lblPayee.Location = new System.Drawing.Point(9, 68);
            this.lblPayee.Name = "lblPayee";
            this.lblPayee.Size = new System.Drawing.Size(37, 13);
            this.lblPayee.TabIndex = 27;
            this.lblPayee.Text = "Payee";
            this.lblPayee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(29, 137);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 28;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddgPayee
            // 
            this.ddgPayee.AutoFilter = true;
            this.ddgPayee.AutoSize = true;
            this.ddgPayee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPayee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPayee.ClearButtonEnabled = true;
            this.ddgPayee.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPayee.Enabled = false;
            this.ddgPayee.FindButtonEnabled = true;
            this.ddgPayee.HiddenColoumns = new int[0];
            this.ddgPayee.Image = null;
            this.ddgPayee.Location = new System.Drawing.Point(46, 60);
            this.ddgPayee.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPayee.Name = "ddgPayee";
            this.ddgPayee.NewButtonEnabled = true;
            this.ddgPayee.RefreshButtonEnabled = true;
            this.ddgPayee.SelectedColomnIdex = 0;
            this.ddgPayee.SelectedItem = "";
            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.ShowGridFunctions = false;
            this.ddgPayee.Size = new System.Drawing.Size(380, 31);
            this.ddgPayee.TabIndex = 25;
            this.ddgPayee.SelectedItemClicked += new System.EventHandler(this.ddgPayee_SelectedItemClicked);
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(61, 248);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(397, 67);
            this.txtDescription.TabIndex = 33;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(5, 262);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(51, 13);
            this.lblDescription.TabIndex = 34;
            this.lblDescription.Text = "Comment";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmModifiedBankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 381);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.ddgInvoice);
            this.Controls.Add(this.ckIsCustomer);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.ntbAmount);
            this.Controls.Add(this.lblPayee);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.ddgPayee);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.lblCheckNo);
            this.Controls.Add(this.lblBankAccount);
            this.Controls.Add(this.ddgBankAccount);
            this.Controls.Add(this.cmdChange);
            this.Name = "frmModifiedBankAccount";
            this.Text = "Bank Account Check";
            this.Load += new System.EventHandler(this.frmModifiedBankAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.Label lblBankAccount;
        private customControls.DropDownDataGrid ddgBankAccount;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label lblCheckNo;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.Label lblInvoice;
        private customControls.DropDownDataGrid ddgInvoice;
        private System.Windows.Forms.CheckBox ckIsCustomer;
        private System.Windows.Forms.Button cmdNew;
        private customControls.ctlNumberTextBox ntbAmount;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.Label lblAmount;
        private customControls.DropDownDataGrid ddgPayee;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}