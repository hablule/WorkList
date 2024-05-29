namespace SRP
{
    partial class frmSummaryReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        */

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTrxDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbTrxDateLogic = new System.Windows.Forms.ComboBox();
            this.dtpTrxDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValueRefundedPurchase = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblValueRefundedSales = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grbCategoryBreakDown = new System.Windows.Forms.GroupBox();
            this.dtgReportBreakDown = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalTurnOver = new System.Windows.Forms.Label();
            this.lblValueTotalPurchase = new System.Windows.Forms.Label();
            this.lblValueTotalSales = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbCategoryBreakDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportBreakDown)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.cmdSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dtpTrxDateTo);
            this.splitContainer1.Panel1.Controls.Add(this.cmbTrxDateLogic);
            this.splitContainer1.Panel1.Controls.Add(this.dtpTrxDateFrom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.lblValueRefundedPurchase);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblValueRefundedSales);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.grbCategoryBreakDown);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalTurnOver);
            this.splitContainer1.Panel2.Controls.Add(this.lblValueTotalPurchase);
            this.splitContainer1.Panel2.Controls.Add(this.lblValueTotalSales);
            this.splitContainer1.Size = new System.Drawing.Size(706, 496);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(640, 16);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(56, 23);
            this.cmdSearch.TabIndex = 5;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // dtpTrxDateTo
            // 
            this.dtpTrxDateTo.Location = new System.Drawing.Point(450, 18);
            this.dtpTrxDateTo.Name = "dtpTrxDateTo";
            this.dtpTrxDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtpTrxDateTo.TabIndex = 3;
            // 
            // cmbTrxDateLogic
            // 
            this.cmbTrxDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrxDateLogic.FormattingEnabled = true;
            this.cmbTrxDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbTrxDateLogic.Location = new System.Drawing.Point(120, 17);
            this.cmbTrxDateLogic.Name = "cmbTrxDateLogic";
            this.cmbTrxDateLogic.Size = new System.Drawing.Size(121, 21);
            this.cmbTrxDateLogic.TabIndex = 2;
            this.cmbTrxDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbTrxDate_SelectedIndexChanged);
            // 
            // dtpTrxDateFrom
            // 
            this.dtpTrxDateFrom.Location = new System.Drawing.Point(246, 18);
            this.dtpTrxDateFrom.Name = "dtpTrxDateFrom";
            this.dtpTrxDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtpTrxDateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Date";
            // 
            // lblValueRefundedPurchase
            // 
            this.lblValueRefundedPurchase.AutoSize = true;
            this.lblValueRefundedPurchase.ForeColor = System.Drawing.Color.Red;
            this.lblValueRefundedPurchase.Location = new System.Drawing.Point(353, 104);
            this.lblValueRefundedPurchase.Name = "lblValueRefundedPurchase";
            this.lblValueRefundedPurchase.Size = new System.Drawing.Size(28, 13);
            this.lblValueRefundedPurchase.TabIndex = 19;
            this.lblValueRefundedPurchase.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(244, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Refunded Purchase";
            // 
            // lblValueRefundedSales
            // 
            this.lblValueRefundedSales.AutoSize = true;
            this.lblValueRefundedSales.ForeColor = System.Drawing.Color.Red;
            this.lblValueRefundedSales.Location = new System.Drawing.Point(353, 57);
            this.lblValueRefundedSales.Name = "lblValueRefundedSales";
            this.lblValueRefundedSales.Size = new System.Drawing.Size(28, 13);
            this.lblValueRefundedSales.TabIndex = 17;
            this.lblValueRefundedSales.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(263, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Refunded Sales";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(270, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "Turn Over";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(233, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Total Purchase";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbCategoryBreakDown
            // 
            this.grbCategoryBreakDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCategoryBreakDown.Controls.Add(this.dtgReportBreakDown);
            this.grbCategoryBreakDown.Location = new System.Drawing.Point(7, 174);
            this.grbCategoryBreakDown.Name = "grbCategoryBreakDown";
            this.grbCategoryBreakDown.Size = new System.Drawing.Size(690, 256);
            this.grbCategoryBreakDown.TabIndex = 10;
            this.grbCategoryBreakDown.TabStop = false;
            this.grbCategoryBreakDown.Text = "Break Down Report";
            // 
            // dtgReportBreakDown
            // 
            this.dtgReportBreakDown.AllowUserToAddRows = false;
            this.dtgReportBreakDown.AllowUserToDeleteRows = false;
            this.dtgReportBreakDown.AllowUserToResizeColumns = false;
            this.dtgReportBreakDown.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgReportBreakDown.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgReportBreakDown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgReportBreakDown.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgReportBreakDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReportBreakDown.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgReportBreakDown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReportBreakDown.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgReportBreakDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReportBreakDown.GridColor = System.Drawing.SystemColors.Control;
            this.dtgReportBreakDown.Location = new System.Drawing.Point(3, 16);
            this.dtgReportBreakDown.MultiSelect = false;
            this.dtgReportBreakDown.Name = "dtgReportBreakDown";
            this.dtgReportBreakDown.ReadOnly = true;
            this.dtgReportBreakDown.RowHeadersVisible = false;
            this.dtgReportBreakDown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReportBreakDown.Size = new System.Drawing.Size(684, 237);
            this.dtgReportBreakDown.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(258, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Sales";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTurnOver
            // 
            this.lblTotalTurnOver.AutoSize = true;
            this.lblTotalTurnOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTurnOver.Location = new System.Drawing.Point(353, 137);
            this.lblTotalTurnOver.Name = "lblTotalTurnOver";
            this.lblTotalTurnOver.Size = new System.Drawing.Size(32, 16);
            this.lblTotalTurnOver.TabIndex = 7;
            this.lblTotalTurnOver.Text = "0.00";
            // 
            // lblValueTotalPurchase
            // 
            this.lblValueTotalPurchase.AutoSize = true;
            this.lblValueTotalPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueTotalPurchase.Location = new System.Drawing.Point(353, 85);
            this.lblValueTotalPurchase.Name = "lblValueTotalPurchase";
            this.lblValueTotalPurchase.Size = new System.Drawing.Size(32, 16);
            this.lblValueTotalPurchase.TabIndex = 6;
            this.lblValueTotalPurchase.Text = "0.00";
            // 
            // lblValueTotalSales
            // 
            this.lblValueTotalSales.AutoSize = true;
            this.lblValueTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueTotalSales.Location = new System.Drawing.Point(353, 34);
            this.lblValueTotalSales.Name = "lblValueTotalSales";
            this.lblValueTotalSales.Size = new System.Drawing.Size(32, 16);
            this.lblValueTotalSales.TabIndex = 5;
            this.lblValueTotalSales.Text = "0.00";
            // 
            // frmSummaryReport
            // 
            this.ClientSize = new System.Drawing.Size(706, 496);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSummaryReport";
            this.Text = "frmSummaryReport";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.grbCategoryBreakDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportBreakDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTrxDateTo;
        private System.Windows.Forms.ComboBox cmbTrxDateLogic;
        private System.Windows.Forms.DateTimePicker dtpTrxDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalTurnOver;
        private System.Windows.Forms.Label lblValueTotalPurchase;
        private System.Windows.Forms.Label lblValueTotalSales;
        private System.Windows.Forms.GroupBox grbCategoryBreakDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dtgReportBreakDown;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblValueRefundedPurchase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblValueRefundedSales;
        private System.Windows.Forms.Label label3;
    }
}