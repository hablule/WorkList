namespace POSDocumentPrinter
{
    partial class frmPaymentAllocation
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
            this.dtgReceiptDtl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptDtl)).BeginInit();
            this.SuspendLayout();
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
            this.dtgReceiptDtl.Size = new System.Drawing.Size(673, 275);
            this.dtgReceiptDtl.TabIndex = 1;
            // 
            // frmPaymentAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 275);
            this.Controls.Add(this.dtgReceiptDtl);
            this.Name = "frmPaymentAllocation";
            this.Text = "Payment Allocation";
            this.Load += new System.EventHandler(this.frmPaymentAllocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceiptDtl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgReceiptDtl;
    }
}