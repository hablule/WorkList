namespace POSDocumentPrinter
{
    partial class frmNewCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgCustomerList = new System.Windows.Forms.DataGridView();
            this.cmdSaveCustomer = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTIN = new System.Windows.Forms.Label();
            this.lblMobilePhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblRegularPhone = new System.Windows.Forms.Label();
            this.ntbTIN = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbRegularPhone = new POSDocumentPrinter.ctlNumberTextBox();
            this.ntbMobilePhone = new POSDocumentPrinter.ctlNumberTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomerList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtgCustomerList);
            this.groupBox1.Location = new System.Drawing.Point(4, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Result";
            // 
            // dtgCustomerList
            // 
            this.dtgCustomerList.AllowUserToAddRows = false;
            this.dtgCustomerList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCustomerList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCustomerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCustomerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCustomerList.Location = new System.Drawing.Point(3, 16);
            this.dtgCustomerList.MultiSelect = false;
            this.dtgCustomerList.Name = "dtgCustomerList";
            this.dtgCustomerList.ReadOnly = true;
            this.dtgCustomerList.RowHeadersWidth = 20;
            this.dtgCustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCustomerList.Size = new System.Drawing.Size(683, 235);
            this.dtgCustomerList.TabIndex = 0;
            this.dtgCustomerList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCustomerList_CellClick);
            // 
            // cmdSaveCustomer
            // 
            this.cmdSaveCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveCustomer.ForeColor = System.Drawing.Color.Lime;
            this.cmdSaveCustomer.Location = new System.Drawing.Point(220, 104);
            this.cmdSaveCustomer.Name = "cmdSaveCustomer";
            this.cmdSaveCustomer.Size = new System.Drawing.Size(245, 46);
            this.cmdSaveCustomer.TabIndex = 5;
            this.cmdSaveCustomer.Text = "Save and Use";
            this.cmdSaveCustomer.UseVisualStyleBackColor = true;
            this.cmdSaveCustomer.Click += new System.EventHandler(this.cmdSaveCustomer_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(64, 15);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 9;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblTIN
            // 
            this.lblTIN.AutoSize = true;
            this.lblTIN.Location = new System.Drawing.Point(335, 16);
            this.lblTIN.Name = "lblTIN";
            this.lblTIN.Size = new System.Drawing.Size(25, 13);
            this.lblTIN.TabIndex = 5;
            this.lblTIN.Text = "TIN";
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.AutoSize = true;
            this.lblMobilePhone.Location = new System.Drawing.Point(553, 15);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(72, 13);
            this.lblMobilePhone.TabIndex = 7;
            this.lblMobilePhone.Text = "Mobile Phone";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(7, 32);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(224, 20);
            this.txtCustomerName.TabIndex = 1;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // lblRegularPhone
            // 
            this.lblRegularPhone.AutoSize = true;
            this.lblRegularPhone.Location = new System.Drawing.Point(553, 62);
            this.lblRegularPhone.Name = "lblRegularPhone";
            this.lblRegularPhone.Size = new System.Drawing.Size(78, 13);
            this.lblRegularPhone.TabIndex = 8;
            this.lblRegularPhone.Text = "Regular Phone";
            // 
            // ntbTIN
            // 
            this.ntbTIN.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbTIN.AllowedLength = 10;
            this.ntbTIN.AllowLeadingZeros = true;
            this.ntbTIN.AllowNegative = false;
            this.ntbTIN.Amount = "";
            this.ntbTIN.defaultAmount = "";
            this.ntbTIN.Location = new System.Drawing.Point(262, 31);
            this.ntbTIN.Name = "ntbTIN";
            this.ntbTIN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTIN.ShowThousandSeparetor = false;
            this.ntbTIN.Size = new System.Drawing.Size(193, 23);
            this.ntbTIN.StandardPrecision = 0;
            this.ntbTIN.TabIndex = 2;
            this.ntbTIN.Leave += new System.EventHandler(this.ntbTIN_Leave);
            this.ntbTIN.contentChanged += new System.EventHandler(this.ntbTIN_Leave);
            // 
            // ntbRegularPhone
            // 
            this.ntbRegularPhone.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbRegularPhone.AllowedLength = 0;
            this.ntbRegularPhone.AllowLeadingZeros = true;
            this.ntbRegularPhone.AllowNegative = false;
            this.ntbRegularPhone.Amount = "";
            this.ntbRegularPhone.defaultAmount = "";
            this.ntbRegularPhone.Location = new System.Drawing.Point(495, 78);
            this.ntbRegularPhone.Name = "ntbRegularPhone";
            this.ntbRegularPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbRegularPhone.ShowThousandSeparetor = false;
            this.ntbRegularPhone.Size = new System.Drawing.Size(196, 23);
            this.ntbRegularPhone.StandardPrecision = 0;
            this.ntbRegularPhone.TabIndex = 4;
            this.ntbRegularPhone.Leave += new System.EventHandler(this.ntbRegularPhone_Leave);
            this.ntbRegularPhone.contentChanged += new System.EventHandler(this.ntbRegularPhone_Leave);
            // 
            // ntbMobilePhone
            // 
            this.ntbMobilePhone.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMobilePhone.AllowedLength = 0;
            this.ntbMobilePhone.AllowLeadingZeros = true;
            this.ntbMobilePhone.AllowNegative = false;
            this.ntbMobilePhone.Amount = "";
            this.ntbMobilePhone.defaultAmount = "";
            this.ntbMobilePhone.Location = new System.Drawing.Point(495, 31);
            this.ntbMobilePhone.Name = "ntbMobilePhone";
            this.ntbMobilePhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMobilePhone.ShowThousandSeparetor = false;
            this.ntbMobilePhone.Size = new System.Drawing.Size(196, 23);
            this.ntbMobilePhone.StandardPrecision = 0;
            this.ntbMobilePhone.TabIndex = 3;
            this.ntbMobilePhone.Leave += new System.EventHandler(this.ntbMobilePhone_Leave);
            this.ntbMobilePhone.contentChanged += new System.EventHandler(this.ntbMobilePhone_Leave);
            // 
            // frmNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 414);
            this.Controls.Add(this.ntbTIN);
            this.Controls.Add(this.ntbRegularPhone);
            this.Controls.Add(this.ntbMobilePhone);
            this.Controls.Add(this.lblRegularPhone);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblMobilePhone);
            this.Controls.Add(this.lblTIN);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.cmdSaveCustomer);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewCustomer";
            this.Text = "New Customer";
            this.Load += new System.EventHandler(this.frmNewCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSaveCustomer;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTIN;
        private System.Windows.Forms.Label lblMobilePhone;
        private System.Windows.Forms.TextBox txtCustomerName;
        private ctlNumberTextBox ntbMobilePhone;
        private ctlNumberTextBox ntbTIN;
        private System.Windows.Forms.DataGridView dtgCustomerList;
        private System.Windows.Forms.Label lblRegularPhone;
        private ctlNumberTextBox ntbRegularPhone;
    }
}