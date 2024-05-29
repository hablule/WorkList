namespace BankPayments
{
    partial class frmAllocate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllocate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgAllocationLine = new System.Windows.Forms.DataGridView();
            this.lblInoice = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbCharge = new System.Windows.Forms.ComboBox();
            this.ckIsGIT = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblCheckAmount = new System.Windows.Forms.Label();
            this.lbloverUnderAmt = new System.Windows.Forms.Label();
            this.cmdComplete = new System.Windows.Forms.Button();
            this.ntbCheckAmount = new customControls.ctlNumberTextBox();
            this.ntbOverUnderAmt = new customControls.ctlNumberTextBox();
            this.ntbAmount = new customControls.ctlNumberTextBox();
            this.ddgInvoice = new customControls.DropDownDataGrid();
            this.ckIsBillingPartener = new System.Windows.Forms.CheckBox();
            this.lblInvoiceAmt = new System.Windows.Forms.Label();
            this.ntbInvoiceAmt = new customControls.ctlNumberTextBox();
            this.lblChargeDate = new System.Windows.Forms.Label();
            this.dtpChargeDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAllocationLine)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgAllocationLine);
            this.groupBox1.Location = new System.Drawing.Point(6, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtgAllocationLine
            // 
            this.dtgAllocationLine.AllowUserToAddRows = false;
            this.dtgAllocationLine.AllowUserToDeleteRows = false;
            this.dtgAllocationLine.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAllocationLine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAllocationLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgAllocationLine.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgAllocationLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAllocationLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgAllocationLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAllocationLine.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgAllocationLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAllocationLine.Location = new System.Drawing.Point(3, 16);
            this.dtgAllocationLine.MultiSelect = false;
            this.dtgAllocationLine.Name = "dtgAllocationLine";
            this.dtgAllocationLine.ReadOnly = true;
            this.dtgAllocationLine.RowHeadersVisible = false;
            this.dtgAllocationLine.RowHeadersWidth = 20;
            this.dtgAllocationLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAllocationLine.Size = new System.Drawing.Size(515, 151);
            this.dtgAllocationLine.TabIndex = 6;
            this.dtgAllocationLine.TabStop = false;
            this.dtgAllocationLine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAllocationLine_CellClick);
            // 
            // lblInoice
            // 
            this.lblInoice.AutoSize = true;
            this.lblInoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInoice.Location = new System.Drawing.Point(33, 52);
            this.lblInoice.Name = "lblInoice";
            this.lblInoice.Size = new System.Drawing.Size(47, 18);
            this.lblInoice.TabIndex = 1;
            this.lblInoice.Text = "Inoice";
            this.lblInoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharge.Location = new System.Drawing.Point(23, 82);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(56, 18);
            this.lblCharge.TabIndex = 2;
            this.lblCharge.Text = "Charge";
            this.lblCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(63, 144);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(59, 18);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(31, 230);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 18);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Comment";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCharge
            // 
            this.cmbCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharge.FormattingEnabled = true;
            this.cmbCharge.Location = new System.Drawing.Point(84, 80);
            this.cmbCharge.Name = "cmbCharge";
            this.cmbCharge.Size = new System.Drawing.Size(262, 21);
            this.cmbCharge.TabIndex = 2;
            this.cmbCharge.SelectedIndexChanged += new System.EventHandler(this.cmbCharge_SelectedIndexChanged);
            // 
            // ckIsGIT
            // 
            this.ckIsGIT.AutoSize = true;
            this.ckIsGIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsGIT.Location = new System.Drawing.Point(352, 79);
            this.ckIsGIT.Name = "ckIsGIT";
            this.ckIsGIT.Size = new System.Drawing.Size(66, 22);
            this.ckIsGIT.TabIndex = 8;
            this.ckIsGIT.Text = "Is GIT";
            this.ckIsGIT.UseVisualStyleBackColor = true;
            this.ckIsGIT.CheckedChanged += new System.EventHandler(this.ckIsGIT_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(111, 200);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(278, 80);
            this.txtDescription.TabIndex = 4;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(395, 217);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(91, 44);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblCheckAmount
            // 
            this.lblCheckAmount.AutoSize = true;
            this.lblCheckAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckAmount.Location = new System.Drawing.Point(146, 15);
            this.lblCheckAmount.Name = "lblCheckAmount";
            this.lblCheckAmount.Size = new System.Drawing.Size(106, 18);
            this.lblCheckAmount.TabIndex = 13;
            this.lblCheckAmount.Text = "Check Amount";
            this.lblCheckAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbloverUnderAmt
            // 
            this.lbloverUnderAmt.AutoSize = true;
            this.lbloverUnderAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloverUnderAmt.Location = new System.Drawing.Point(247, 172);
            this.lbloverUnderAmt.Name = "lbloverUnderAmt";
            this.lbloverUnderAmt.Size = new System.Drawing.Size(114, 18);
            this.lbloverUnderAmt.TabIndex = 15;
            this.lbloverUnderAmt.Text = "Over/Under Amt";
            this.lbloverUnderAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdComplete
            // 
            this.cmdComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdComplete.ForeColor = System.Drawing.Color.Red;
            this.cmdComplete.Location = new System.Drawing.Point(147, 462);
            this.cmdComplete.Name = "cmdComplete";
            this.cmdComplete.Size = new System.Drawing.Size(228, 51);
            this.cmdComplete.TabIndex = 20;
            this.cmdComplete.Text = "Complete";
            this.cmdComplete.UseVisualStyleBackColor = true;
            this.cmdComplete.Click += new System.EventHandler(this.cmdComplete_Click);
            // 
            // ntbCheckAmount
            // 
            this.ntbCheckAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbCheckAmount.AllowedLength = 0;
            this.ntbCheckAmount.AllowLeadingZeros = false;
            this.ntbCheckAmount.AllowNegative = true;
            this.ntbCheckAmount.Amount = "";
            this.ntbCheckAmount.defaultAmount = "0";
            this.ntbCheckAmount.Enabled = false;
            this.ntbCheckAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbCheckAmount.Location = new System.Drawing.Point(254, 11);
            this.ntbCheckAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ntbCheckAmount.Name = "ntbCheckAmount";
            this.ntbCheckAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbCheckAmount.ShowThousandSeparetor = true;
            this.ntbCheckAmount.Size = new System.Drawing.Size(232, 32);
            this.ntbCheckAmount.StandardPrecision = 2;
            this.ntbCheckAmount.TabIndex = 19;
            // 
            // ntbOverUnderAmt
            // 
            this.ntbOverUnderAmt.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbOverUnderAmt.AllowedLength = 0;
            this.ntbOverUnderAmt.AllowLeadingZeros = false;
            this.ntbOverUnderAmt.AllowNegative = true;
            this.ntbOverUnderAmt.Amount = "0";
            this.ntbOverUnderAmt.defaultAmount = "0";
            this.ntbOverUnderAmt.Enabled = false;
            this.ntbOverUnderAmt.Location = new System.Drawing.Point(365, 170);
            this.ntbOverUnderAmt.Name = "ntbOverUnderAmt";
            this.ntbOverUnderAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbOverUnderAmt.ShowThousandSeparetor = true;
            this.ntbOverUnderAmt.Size = new System.Drawing.Size(140, 23);
            this.ntbOverUnderAmt.StandardPrecision = 2;
            this.ntbOverUnderAmt.TabIndex = 18;
            // 
            // ntbAmount
            // 
            this.ntbAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmount.AllowedLength = 0;
            this.ntbAmount.AllowLeadingZeros = false;
            this.ntbAmount.AllowNegative = true;
            this.ntbAmount.Amount = "0";
            this.ntbAmount.defaultAmount = "0";
            this.ntbAmount.Location = new System.Drawing.Point(126, 142);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmount.ShowThousandSeparetor = true;
            this.ntbAmount.Size = new System.Drawing.Size(140, 23);
            this.ntbAmount.StandardPrecision = 2;
            this.ntbAmount.TabIndex = 3;
            this.ntbAmount.Leave += new System.EventHandler(this.ntbAmount_Leave);
            // 
            // ddgInvoice
            // 
            this.ddgInvoice.AutoFilter = true;
            this.ddgInvoice.AutoSize = true;
            this.ddgInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgInvoice.ClearButtonEnabled = true;
            this.ddgInvoice.DataTablePrimaryKey = ((ushort)(0));
            this.ddgInvoice.FindButtonEnabled = true;
            this.ddgInvoice.HiddenColoumns = new int[0];
            this.ddgInvoice.Image = null;
            this.ddgInvoice.Location = new System.Drawing.Point(80, 46);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(338, 31);
            this.ddgInvoice.TabIndex = 1;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // ckIsBillingPartener
            // 
            this.ckIsBillingPartener.AutoSize = true;
            this.ckIsBillingPartener.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsBillingPartener.Location = new System.Drawing.Point(422, 49);
            this.ckIsBillingPartener.Name = "ckIsBillingPartener";
            this.ckIsBillingPartener.Size = new System.Drawing.Size(102, 22);
            this.ckIsBillingPartener.TabIndex = 35;
            this.ckIsBillingPartener.Text = "Only Payee";
            this.ckIsBillingPartener.UseVisualStyleBackColor = true;
            // 
            // lblInvoiceAmt
            // 
            this.lblInvoiceAmt.AutoSize = true;
            this.lblInvoiceAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAmt.Location = new System.Drawing.Point(18, 173);
            this.lblInvoiceAmt.Name = "lblInvoiceAmt";
            this.lblInvoiceAmt.Size = new System.Drawing.Size(84, 18);
            this.lblInvoiceAmt.TabIndex = 36;
            this.lblInvoiceAmt.Text = "Invoice Amt";
            // 
            // ntbInvoiceAmt
            // 
            this.ntbInvoiceAmt.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbInvoiceAmt.AllowedLength = 0;
            this.ntbInvoiceAmt.AllowLeadingZeros = false;
            this.ntbInvoiceAmt.AllowNegative = true;
            this.ntbInvoiceAmt.Amount = "0";
            this.ntbInvoiceAmt.defaultAmount = "0";
            this.ntbInvoiceAmt.Enabled = false;
            this.ntbInvoiceAmt.Location = new System.Drawing.Point(103, 171);
            this.ntbInvoiceAmt.Name = "ntbInvoiceAmt";
            this.ntbInvoiceAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbInvoiceAmt.ShowThousandSeparetor = true;
            this.ntbInvoiceAmt.Size = new System.Drawing.Size(116, 23);
            this.ntbInvoiceAmt.StandardPrecision = 2;
            this.ntbInvoiceAmt.TabIndex = 18;
            // 
            // lblChargeDate
            // 
            this.lblChargeDate.AutoSize = true;
            this.lblChargeDate.Location = new System.Drawing.Point(84, 110);
            this.lblChargeDate.Name = "lblChargeDate";
            this.lblChargeDate.Size = new System.Drawing.Size(67, 13);
            this.lblChargeDate.TabIndex = 37;
            this.lblChargeDate.Text = "Charge Date";
            // 
            // dtpChargeDate
            // 
            this.dtpChargeDate.Location = new System.Drawing.Point(157, 107);
            this.dtpChargeDate.Name = "dtpChargeDate";
            this.dtpChargeDate.Size = new System.Drawing.Size(208, 20);
            this.dtpChargeDate.TabIndex = 38;
            // 
            // frmAllocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 519);
            this.Controls.Add(this.dtpChargeDate);
            this.Controls.Add(this.lblChargeDate);
            this.Controls.Add(this.lblInvoiceAmt);
            this.Controls.Add(this.ckIsBillingPartener);
            this.Controls.Add(this.cmdComplete);
            this.Controls.Add(this.ntbCheckAmount);
            this.Controls.Add(this.ntbInvoiceAmt);
            this.Controls.Add(this.ntbOverUnderAmt);
            this.Controls.Add(this.ntbAmount);
            this.Controls.Add(this.ddgInvoice);
            this.Controls.Add(this.lbloverUnderAmt);
            this.Controls.Add(this.lblCheckAmount);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.ckIsGIT);
            this.Controls.Add(this.cmbCharge);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblCharge);
            this.Controls.Add(this.lblInoice);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAllocate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Allocate";
            this.Load += new System.EventHandler(this.frmAllocate_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAllocate_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAllocationLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgAllocationLine;
        private System.Windows.Forms.Label lblInoice;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbCharge;
        private System.Windows.Forms.CheckBox ckIsGIT;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblCheckAmount;
        private System.Windows.Forms.Label lbloverUnderAmt;
        private customControls.DropDownDataGrid ddgInvoice;
        private customControls.ctlNumberTextBox ntbAmount;
        private customControls.ctlNumberTextBox ntbOverUnderAmt;
        private customControls.ctlNumberTextBox ntbCheckAmount;
        private System.Windows.Forms.Button cmdComplete;
        private System.Windows.Forms.CheckBox ckIsBillingPartener;
        private System.Windows.Forms.Label lblInvoiceAmt;
        private customControls.ctlNumberTextBox ntbInvoiceAmt;
        private System.Windows.Forms.Label lblChargeDate;
        private System.Windows.Forms.DateTimePicker dtpChargeDate;
    }
}