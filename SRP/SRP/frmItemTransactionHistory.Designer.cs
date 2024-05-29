namespace SRP
{
    partial class frmItemTransactionHistory
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
            this.dtgItemTrxHistroy = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItemTrxHistroy)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgItemTrxHistroy
            // 
            this.dtgItemTrxHistroy.AllowUserToAddRows = false;
            this.dtgItemTrxHistroy.AllowUserToDeleteRows = false;
            this.dtgItemTrxHistroy.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgItemTrxHistroy.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgItemTrxHistroy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItemTrxHistroy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgItemTrxHistroy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItemTrxHistroy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgItemTrxHistroy.Location = new System.Drawing.Point(0, 0);
            this.dtgItemTrxHistroy.MultiSelect = false;
            this.dtgItemTrxHistroy.Name = "dtgItemTrxHistroy";
            this.dtgItemTrxHistroy.ReadOnly = true;
            this.dtgItemTrxHistroy.RowHeadersWidth = 20;
            this.dtgItemTrxHistroy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItemTrxHistroy.Size = new System.Drawing.Size(438, 468);
            this.dtgItemTrxHistroy.TabIndex = 0;
            // 
            // frmItemTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 468);
            this.Controls.Add(this.dtgItemTrxHistroy);
            this.Name = "frmItemTransactionHistory";
            this.Text = "Item Transaction History";
            this.Load += new System.EventHandler(this.frmItemTransactionHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItemTrxHistroy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgItemTrxHistroy;
    }
}