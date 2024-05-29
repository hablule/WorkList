namespace POSDocumentPrinter
{
    partial class frmAllocatePayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllocatePayment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgReceiptDtl = new System.Windows.Forms.DataGridView();
            this.grbPaymentDetail = new System.Windows.Forms.GroupBox();
            this.ckIsExemption = new System.Windows.Forms.CheckBox();
            this.txtOverUnderAmt = new System.Windows.Forms.TextBox();
            this.txtDescriptionDtl = new System.Windows.Forms.TextBox();
            this.lblDescriptionDtl = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblOverUnderAmount = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.txtAmountDue = new System.Windows.Forms.TextBox();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.cmdConfirm = new System.Windows.Forms.Button();
            this.cmdShowAllocation = new System.Windows.Forms.Button();
            this.txtUnAllocatedAmount = new System.Windows.Forms.TextBox();
            this.lblUnallocatedAmt = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ddgInvoice = new POSDocumentPrinter.DropDownDataGrid();
            this.ntbAmountPaid = new POSDocumentPrinter.ctlNumberTextBox();
            this.sbStatusLabel = new System.Windows.Forms.StatusStrip();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptDtl)).BeginInit();
            this.grbPaymentDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dtgReceiptDtl);
            this.panel1.Location = new System.Drawing.Point(4, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 143);
            this.panel1.TabIndex = 16;
            // 
            // dtgReceiptDtl
            // 
            this.dtgReceiptDtl.AllowUserToAddRows = false;
            this.dtgReceiptDtl.AllowUserToDeleteRows = false;
            this.dtgReceiptDtl.AllowUserToResizeColumns = false;
            this.dtgReceiptDtl.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptDtl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgReceiptDtl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptDtl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgReceiptDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceiptDtl.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgReceiptDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReceiptDtl.Location = new System.Drawing.Point(0, 0);
            this.dtgReceiptDtl.MultiSelect = false;
            this.dtgReceiptDtl.Name = "dtgReceiptDtl";
            this.dtgReceiptDtl.ReadOnly = true;
            this.dtgReceiptDtl.RowHeadersVisible = false;
            this.dtgReceiptDtl.RowHeadersWidth = 20;
            this.dtgReceiptDtl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReceiptDtl.Size = new System.Drawing.Size(513, 143);
            this.dtgReceiptDtl.TabIndex = 0;
            this.dtgReceiptDtl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReceiptDtl_CellClick);
            // 
            // grbPaymentDetail
            // 
            this.grbPaymentDetail.BackColor = System.Drawing.SystemColors.Control;
            this.grbPaymentDetail.Controls.Add(this.ckIsExemption);
            this.grbPaymentDetail.Controls.Add(this.txtOverUnderAmt);
            this.grbPaymentDetail.Controls.Add(this.txtDescriptionDtl);
            this.grbPaymentDetail.Controls.Add(this.lblDescriptionDtl);
            this.grbPaymentDetail.Controls.Add(this.cmdAdd);
            this.grbPaymentDetail.Controls.Add(this.ddgInvoice);
            this.grbPaymentDetail.Controls.Add(this.ntbAmountPaid);
            this.grbPaymentDetail.Controls.Add(this.lblInvoice);
            this.grbPaymentDetail.Controls.Add(this.lblOverUnderAmount);
            this.grbPaymentDetail.Controls.Add(this.lblAmountDue);
            this.grbPaymentDetail.Controls.Add(this.txtAmountDue);
            this.grbPaymentDetail.Controls.Add(this.lblAmountPaid);
            this.grbPaymentDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbPaymentDetail.Location = new System.Drawing.Point(12, 52);
            this.grbPaymentDetail.Name = "grbPaymentDetail";
            this.grbPaymentDetail.Size = new System.Drawing.Size(496, 182);
            this.grbPaymentDetail.TabIndex = 15;
            this.grbPaymentDetail.TabStop = false;
            this.grbPaymentDetail.Text = "Customer Pyament Detail";
            // 
            // ckIsExemption
            // 
            this.ckIsExemption.AutoSize = true;
            this.ckIsExemption.Location = new System.Drawing.Point(398, 22);
            this.ckIsExemption.Name = "ckIsExemption";
            this.ckIsExemption.Size = new System.Drawing.Size(86, 17);
            this.ckIsExemption.TabIndex = 28;
            this.ckIsExemption.Text = "Is Exemption";
            this.ckIsExemption.UseVisualStyleBackColor = true;
            // 
            // txtOverUnderAmt
            // 
            this.txtOverUnderAmt.Enabled = false;
            this.txtOverUnderAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverUnderAmt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtOverUnderAmt.Location = new System.Drawing.Point(345, 85);
            this.txtOverUnderAmt.Name = "txtOverUnderAmt";
            this.txtOverUnderAmt.Size = new System.Drawing.Size(119, 20);
            this.txtOverUnderAmt.TabIndex = 27;
            this.txtOverUnderAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescriptionDtl
            // 
            this.txtDescriptionDtl.Location = new System.Drawing.Point(84, 110);
            this.txtDescriptionDtl.Multiline = true;
            this.txtDescriptionDtl.Name = "txtDescriptionDtl";
            this.txtDescriptionDtl.Size = new System.Drawing.Size(281, 60);
            this.txtDescriptionDtl.TabIndex = 26;
            // 
            // lblDescriptionDtl
            // 
            this.lblDescriptionDtl.Location = new System.Drawing.Point(19, 115);
            this.lblDescriptionDtl.Name = "lblDescriptionDtl";
            this.lblDescriptionDtl.Size = new System.Drawing.Size(61, 55);
            this.lblDescriptionDtl.TabIndex = 25;
            this.lblDescriptionDtl.Text = "Description/Comment";
            this.lblDescriptionDtl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(375, 113);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(96, 54);
            this.cmdAdd.TabIndex = 24;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(46, 24);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(42, 13);
            this.lblInvoice.TabIndex = 7;
            this.lblInvoice.Text = "Invoice";
            // 
            // lblOverUnderAmount
            // 
            this.lblOverUnderAmount.AutoSize = true;
            this.lblOverUnderAmount.Location = new System.Drawing.Point(254, 88);
            this.lblOverUnderAmount.Name = "lblOverUnderAmount";
            this.lblOverUnderAmount.Size = new System.Drawing.Size(85, 13);
            this.lblOverUnderAmount.TabIndex = 10;
            this.lblOverUnderAmount.Text = "Over/Under Amt";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Location = new System.Drawing.Point(48, 87);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(66, 13);
            this.lblAmountDue.TabIndex = 8;
            this.lblAmountDue.Text = "Amount Due";
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.Enabled = false;
            this.txtAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountDue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtAmountDue.Location = new System.Drawing.Point(120, 84);
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.Size = new System.Drawing.Size(119, 20);
            this.txtAmountDue.TabIndex = 17;
            this.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Location = new System.Drawing.Point(22, 53);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(67, 13);
            this.lblAmountPaid.TabIndex = 9;
            this.lblAmountPaid.Text = "Amount Paid";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConfirm.Image = ((System.Drawing.Image)(resources.GetObject("cmdConfirm.Image")));
            this.cmdConfirm.Location = new System.Drawing.Point(84, 393);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Size = new System.Drawing.Size(212, 49);
            this.cmdConfirm.TabIndex = 17;
            this.cmdConfirm.UseVisualStyleBackColor = true;
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // cmdShowAllocation
            // 
            this.cmdShowAllocation.FlatAppearance.BorderSize = 0;
            this.cmdShowAllocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdShowAllocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdShowAllocation.Image = ((System.Drawing.Image)(resources.GetObject("cmdShowAllocation.Image")));
            this.cmdShowAllocation.Location = new System.Drawing.Point(460, 397);
            this.cmdShowAllocation.Name = "cmdShowAllocation";
            this.cmdShowAllocation.Size = new System.Drawing.Size(56, 40);
            this.cmdShowAllocation.TabIndex = 18;
            this.cmdShowAllocation.UseVisualStyleBackColor = true;
            this.cmdShowAllocation.Click += new System.EventHandler(this.cmdShowAllocation_Click);
            // 
            // txtUnAllocatedAmount
            // 
            this.txtUnAllocatedAmount.Enabled = false;
            this.txtUnAllocatedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnAllocatedAmount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtUnAllocatedAmount.Location = new System.Drawing.Point(357, 14);
            this.txtUnAllocatedAmount.Name = "txtUnAllocatedAmount";
            this.txtUnAllocatedAmount.Size = new System.Drawing.Size(150, 20);
            this.txtUnAllocatedAmount.TabIndex = 20;
            this.txtUnAllocatedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUnallocatedAmt
            // 
            this.lblUnallocatedAmt.AutoSize = true;
            this.lblUnallocatedAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnallocatedAmt.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblUnallocatedAmt.Location = new System.Drawing.Point(198, 16);
            this.lblUnallocatedAmt.Name = "lblUnallocatedAmt";
            this.lblUnallocatedAmt.Size = new System.Drawing.Size(152, 16);
            this.lblUnallocatedAmt.TabIndex = 19;
            this.lblUnallocatedAmt.Text = "Un Allocated Amount";
            // 
            // cmdCancel
            // 
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Location = new System.Drawing.Point(302, 393);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(122, 49);
            this.cmdCancel.TabIndex = 17;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
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
            this.ddgInvoice.Location = new System.Drawing.Point(91, 16);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(304, 31);
            this.ddgInvoice.TabIndex = 23;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // ntbAmountPaid
            // 
            this.ntbAmountPaid.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmountPaid.AllowedLength = 0;
            this.ntbAmountPaid.AllowLeadingZeros = false;
            this.ntbAmountPaid.AllowNegative = false;
            this.ntbAmountPaid.Amount = "";
            this.ntbAmountPaid.defaultAmount = "0";
            this.ntbAmountPaid.Location = new System.Drawing.Point(93, 49);
            this.ntbAmountPaid.Name = "ntbAmountPaid";
            this.ntbAmountPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmountPaid.ShowThousandSeparetor = true;
            this.ntbAmountPaid.Size = new System.Drawing.Size(132, 23);
            this.ntbAmountPaid.StandardPrecision = 2;
            this.ntbAmountPaid.TabIndex = 22;
            this.ntbAmountPaid.Leave += new System.EventHandler(this.ntbAmountPaid_Leave);
            // 
            // sbStatusLabel
            // 
            this.sbStatusLabel.Location = new System.Drawing.Point(0, 449);
            this.sbStatusLabel.Name = "sbStatusLabel";
            this.sbStatusLabel.Size = new System.Drawing.Size(520, 22);
            this.sbStatusLabel.TabIndex = 21;
            this.sbStatusLabel.Text = "statusStrip1";
            // 
            // frmAllocatePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 471);
            this.Controls.Add(this.sbStatusLabel);
            this.Controls.Add(this.txtUnAllocatedAmount);
            this.Controls.Add(this.lblUnallocatedAmt);
            this.Controls.Add(this.cmdShowAllocation);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbPaymentDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAllocatePayment";
            this.Text = "Allocate Payment";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAllocatePayment_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptDtl)).EndInit();
            this.grbPaymentDetail.ResumeLayout(false);
            this.grbPaymentDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgReceiptDtl;
        private System.Windows.Forms.GroupBox grbPaymentDetail;
        private System.Windows.Forms.CheckBox ckIsExemption;
        private System.Windows.Forms.TextBox txtOverUnderAmt;
        private System.Windows.Forms.TextBox txtDescriptionDtl;
        private System.Windows.Forms.Label lblDescriptionDtl;
        private System.Windows.Forms.Button cmdAdd;
        private DropDownDataGrid ddgInvoice;
        private ctlNumberTextBox ntbAmountPaid;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblOverUnderAmount;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.TextBox txtAmountDue;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Button cmdConfirm;
        private System.Windows.Forms.Button cmdShowAllocation;
        private System.Windows.Forms.TextBox txtUnAllocatedAmount;
        private System.Windows.Forms.Label lblUnallocatedAmt;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.StatusStrip sbStatusLabel;
    }
}