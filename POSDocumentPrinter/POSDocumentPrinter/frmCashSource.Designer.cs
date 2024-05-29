namespace POSDocumentPrinter
{
    partial class frmCashSource
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbSourceType = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbDateLogic = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgNewCashSource = new System.Windows.Forms.DataGridView();
            this.dtgSearchResult = new System.Windows.Forms.DataGridView();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ckSelectAll = new System.Windows.Forms.CheckBox();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdComplete = new System.Windows.Forms.Button();
            this.txtAmountRemaining = new System.Windows.Forms.TextBox();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.cmdShow = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblOnHand = new System.Windows.Forms.Label();
            this.txtOnHand = new System.Windows.Forms.TextBox();
            this.lblSourceType = new System.Windows.Forms.Label();
            this.txtDescriptionSrc = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.ntbDeposited = new POSDocumentPrinter.ctlNumberTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNewCashSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearchResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSourceType
            // 
            this.cmbSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceType.FormattingEnabled = true;
            this.cmbSourceType.Items.AddRange(new object[] {
            "Sales",
            "CRV",
            "Exemption",
            "Refund"});
            this.cmbSourceType.Location = new System.Drawing.Point(114, 65);
            this.cmbSourceType.Name = "cmbSourceType";
            this.cmbSourceType.Size = new System.Drawing.Size(97, 21);
            this.cmbSourceType.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(29, 39);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(79, 19);
            this.lblDate.TabIndex = 52;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(440, 38);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(194, 20);
            this.dtpDateTo.TabIndex = 55;
            this.dtpDateTo.Visible = false;
            // 
            // cmbDateLogic
            // 
            this.cmbDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateLogic.DropDownWidth = 130;
            this.cmbDateLogic.FormattingEnabled = true;
            this.cmbDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDateLogic.Location = new System.Drawing.Point(114, 38);
            this.cmbDateLogic.Name = "cmbDateLogic";
            this.cmbDateLogic.Size = new System.Drawing.Size(122, 21);
            this.cmbDateLogic.TabIndex = 53;
            this.cmbDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDateLogic_SelectedIndexChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(242, 38);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(192, 20);
            this.dtpDateFrom.TabIndex = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgNewCashSource);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(3, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cash Source Detail";
            // 
            // dtgNewCashSource
            // 
            this.dtgNewCashSource.AllowUserToAddRows = false;
            this.dtgNewCashSource.AllowUserToDeleteRows = false;
            this.dtgNewCashSource.AllowUserToResizeColumns = false;
            this.dtgNewCashSource.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dtgNewCashSource.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgNewCashSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgNewCashSource.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgNewCashSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgNewCashSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNewCashSource.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgNewCashSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNewCashSource.Location = new System.Drawing.Point(3, 17);
            this.dtgNewCashSource.MultiSelect = false;
            this.dtgNewCashSource.Name = "dtgNewCashSource";
            this.dtgNewCashSource.ReadOnly = true;
            this.dtgNewCashSource.RowHeadersVisible = false;
            this.dtgNewCashSource.RowHeadersWidth = 20;
            this.dtgNewCashSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNewCashSource.Size = new System.Drawing.Size(613, 182);
            this.dtgNewCashSource.TabIndex = 0;
            this.dtgNewCashSource.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgNewCashSource_CellClick);
            // 
            // dtgSearchResult
            // 
            this.dtgSearchResult.AllowUserToAddRows = false;
            this.dtgSearchResult.AllowUserToDeleteRows = false;
            this.dtgSearchResult.AllowUserToResizeColumns = false;
            this.dtgSearchResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.dtgSearchResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSearchResult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSearchResult.Location = new System.Drawing.Point(3, 16);
            this.dtgSearchResult.MultiSelect = false;
            this.dtgSearchResult.Name = "dtgSearchResult";
            this.dtgSearchResult.ReadOnly = true;
            this.dtgSearchResult.RowHeadersVisible = false;
            this.dtgSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSearchResult.Size = new System.Drawing.Size(517, 174);
            this.dtgSearchResult.TabIndex = 1;
            this.dtgSearchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSearchResult_CellClick);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(531, 275);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(88, 30);
            this.cmdAdd.TabIndex = 57;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // ckSelectAll
            // 
            this.ckSelectAll.AutoSize = true;
            this.ckSelectAll.Location = new System.Drawing.Point(532, 252);
            this.ckSelectAll.Name = "ckSelectAll";
            this.ckSelectAll.Size = new System.Drawing.Size(70, 17);
            this.ckSelectAll.TabIndex = 58;
            this.ckSelectAll.Text = "Select All";
            this.ckSelectAll.UseVisualStyleBackColor = true;
            this.ckSelectAll.CheckedChanged += new System.EventHandler(this.ckSelectAll_CheckedChanged);
            // 
            // cmdModify
            // 
            this.cmdModify.Enabled = false;
            this.cmdModify.Location = new System.Drawing.Point(667, 340);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(75, 23);
            this.cmdModify.TabIndex = 59;
            this.cmdModify.Text = "Modify";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdComplete
            // 
            this.cmdComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdComplete.Location = new System.Drawing.Point(643, 152);
            this.cmdComplete.Name = "cmdComplete";
            this.cmdComplete.Size = new System.Drawing.Size(210, 48);
            this.cmdComplete.TabIndex = 60;
            this.cmdComplete.Text = "Complete";
            this.cmdComplete.UseVisualStyleBackColor = true;
            this.cmdComplete.Click += new System.EventHandler(this.cmdComplete_Click);
            // 
            // txtAmountRemaining
            // 
            this.txtAmountRemaining.Enabled = false;
            this.txtAmountRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountRemaining.Location = new System.Drawing.Point(660, 126);
            this.txtAmountRemaining.Name = "txtAmountRemaining";
            this.txtAmountRemaining.Size = new System.Drawing.Size(177, 20);
            this.txtAmountRemaining.TabIndex = 61;
            this.txtAmountRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.AutoSize = true;
            this.lblRemainingAmount.Location = new System.Drawing.Point(700, 107);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.Size = new System.Drawing.Size(96, 13);
            this.lblRemainingAmount.TabIndex = 62;
            this.lblRemainingAmount.Text = "Amount Remaining";
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(262, 78);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(299, 31);
            this.cmdShow.TabIndex = 63;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(775, 316);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(55, 13);
            this.lblAmount.TabIndex = 64;
            this.lblAmount.Text = "Deposited";
            // 
            // lblOnHand
            // 
            this.lblOnHand.AutoSize = true;
            this.lblOnHand.Location = new System.Drawing.Point(777, 376);
            this.lblOnHand.Name = "lblOnHand";
            this.lblOnHand.Size = new System.Drawing.Size(57, 13);
            this.lblOnHand.TabIndex = 66;
            this.lblOnHand.Text = "Remaining";
            // 
            // txtOnHand
            // 
            this.txtOnHand.Enabled = false;
            this.txtOnHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnHand.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtOnHand.Location = new System.Drawing.Point(641, 373);
            this.txtOnHand.Name = "txtOnHand";
            this.txtOnHand.Size = new System.Drawing.Size(126, 20);
            this.txtOnHand.TabIndex = 68;
            this.txtOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSourceType
            // 
            this.lblSourceType.AutoSize = true;
            this.lblSourceType.Location = new System.Drawing.Point(40, 70);
            this.lblSourceType.Name = "lblSourceType";
            this.lblSourceType.Size = new System.Drawing.Size(68, 13);
            this.lblSourceType.TabIndex = 69;
            this.lblSourceType.Text = "Source Type";
            // 
            // txtDescriptionSrc
            // 
            this.txtDescriptionSrc.Location = new System.Drawing.Point(634, 432);
            this.txtDescriptionSrc.Multiline = true;
            this.txtDescriptionSrc.Name = "txtDescriptionSrc";
            this.txtDescriptionSrc.Size = new System.Drawing.Size(202, 81);
            this.txtDescriptionSrc.TabIndex = 70;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(637, 413);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(109, 13);
            this.lblDescription.TabIndex = 71;
            this.lblDescription.Text = "Description/Comment";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.Red;
            this.cmdCancel.Location = new System.Drawing.Point(660, 206);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(176, 35);
            this.cmdCancel.TabIndex = 72;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgSearchResult);
            this.groupBox2.Location = new System.Drawing.Point(3, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 193);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Result";
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Location = new System.Drawing.Point(12, 12);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(96, 19);
            this.lblDocumentNumber.TabIndex = 74;
            this.lblDocumentNumber.Text = "Document Number";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDocumentNumberLogic
            // 
            this.cmbDocumentNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentNumberLogic.DropDownWidth = 130;
            this.cmbDocumentNumberLogic.FormattingEnabled = true;
            this.cmbDocumentNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to"});
            this.cmbDocumentNumberLogic.Location = new System.Drawing.Point(114, 12);
            this.cmbDocumentNumberLogic.Name = "cmbDocumentNumberLogic";
            this.cmbDocumentNumberLogic.Size = new System.Drawing.Size(122, 21);
            this.cmbDocumentNumberLogic.TabIndex = 75;
            this.cmbDocumentNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentNumberLogic_SelectedIndexChanged);
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.AcceptsReturn = true;
            this.txtDocumentNumber.Location = new System.Drawing.Point(242, 12);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumber.TabIndex = 76;
            // 
            // ntbDeposited
            // 
            this.ntbDeposited.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbDeposited.AllowedLength = 0;
            this.ntbDeposited.AllowLeadingZeros = false;
            this.ntbDeposited.AllowNegative = false;
            this.ntbDeposited.Amount = "";
            this.ntbDeposited.defaultAmount = "0";
            this.ntbDeposited.Location = new System.Drawing.Point(638, 312);
            this.ntbDeposited.Name = "ntbDeposited";
            this.ntbDeposited.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbDeposited.ShowThousandSeparetor = true;
            this.ntbDeposited.Size = new System.Drawing.Size(132, 23);
            this.ntbDeposited.StandardPrecision = 2;
            this.ntbDeposited.TabIndex = 65;
            this.ntbDeposited.Leave += new System.EventHandler(this.ntbDeposited_Leave);
            // 
            // frmCashSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 522);
            this.ControlBox = false;
            this.Controls.Add(this.lblDocumentNumber);
            this.Controls.Add(this.cmbDocumentNumberLogic);
            this.Controls.Add(this.txtDocumentNumber);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescriptionSrc);
            this.Controls.Add(this.lblSourceType);
            this.Controls.Add(this.lblOnHand);
            this.Controls.Add(this.txtOnHand);
            this.Controls.Add(this.ntbDeposited);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.lblRemainingAmount);
            this.Controls.Add(this.txtAmountRemaining);
            this.Controls.Add(this.cmdComplete);
            this.Controls.Add(this.cmdModify);
            this.Controls.Add(this.ckSelectAll);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.cmbDateLogic);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.cmbSourceType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashSource";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Source";
            this.Load += new System.EventHandler(this.frmCashSource_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNewCashSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearchResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSourceType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.ComboBox cmbDateLogic;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgNewCashSource;
        private System.Windows.Forms.DataGridView dtgSearchResult;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.CheckBox ckSelectAll;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdComplete;
        private System.Windows.Forms.TextBox txtAmountRemaining;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.Button cmdShow;
        private ctlNumberTextBox ntbDeposited;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblOnHand;
        private System.Windows.Forms.TextBox txtOnHand;
        private System.Windows.Forms.Label lblSourceType;
        private System.Windows.Forms.TextBox txtDescriptionSrc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.TextBox txtDocumentNumber;
    }
}