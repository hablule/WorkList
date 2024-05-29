namespace BuySimple
{
    partial class frmDistributeRemainingCost
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDistributableCost = new System.Windows.Forms.Label();
            this.dtgDistributableCost = new System.Windows.Forms.DataGridView();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dtgCommercialInvoice = new System.Windows.Forms.DataGridView();
            this.cmdDistribute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDistributableCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommercialInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDistributableCost
            // 
            this.lblDistributableCost.AutoSize = true;
            this.lblDistributableCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistributableCost.Location = new System.Drawing.Point(12, 14);
            this.lblDistributableCost.Name = "lblDistributableCost";
            this.lblDistributableCost.Size = new System.Drawing.Size(155, 15);
            this.lblDistributableCost.TabIndex = 9;
            this.lblDistributableCost.Text = "Distributable Payments";
            // 
            // dtgDistributableCost
            // 
            this.dtgDistributableCost.AllowUserToAddRows = false;
            this.dtgDistributableCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgDistributableCost.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgDistributableCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDistributableCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgDistributableCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDistributableCost.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgDistributableCost.Location = new System.Drawing.Point(12, 32);
            this.dtgDistributableCost.MultiSelect = false;
            this.dtgDistributableCost.Name = "dtgDistributableCost";
            this.dtgDistributableCost.ReadOnly = true;
            this.dtgDistributableCost.RowHeadersWidth = 10;
            this.dtgDistributableCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDistributableCost.Size = new System.Drawing.Size(649, 233);
            this.dtgDistributableCost.TabIndex = 8;
            this.dtgDistributableCost.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDistributableCost_CellClick);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(246, 275);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(195, 36);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dtgCommercialInvoice
            // 
            this.dtgCommercialInvoice.AllowUserToAddRows = false;
            this.dtgCommercialInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgCommercialInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgCommercialInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCommercialInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgCommercialInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCommercialInvoice.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgCommercialInvoice.Location = new System.Drawing.Point(12, 329);
            this.dtgCommercialInvoice.Name = "dtgCommercialInvoice";
            this.dtgCommercialInvoice.ReadOnly = true;
            this.dtgCommercialInvoice.RowHeadersWidth = 20;
            this.dtgCommercialInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCommercialInvoice.Size = new System.Drawing.Size(649, 132);
            this.dtgCommercialInvoice.TabIndex = 8;
            this.dtgCommercialInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCommercialInvoice_CellClick);
            // 
            // cmdDistribute
            // 
            this.cmdDistribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDistribute.Location = new System.Drawing.Point(202, 471);
            this.cmdDistribute.Name = "cmdDistribute";
            this.cmdDistribute.Size = new System.Drawing.Size(270, 36);
            this.cmdDistribute.TabIndex = 10;
            this.cmdDistribute.Text = "Distribute";
            this.cmdDistribute.UseVisualStyleBackColor = true;
            this.cmdDistribute.Click += new System.EventHandler(this.cmdDistribute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Invoice List";
            // 
            // frmDistributeRemainingCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 519);
            this.Controls.Add(this.cmdDistribute);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDistributableCost);
            this.Controls.Add(this.dtgCommercialInvoice);
            this.Controls.Add(this.dtgDistributableCost);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDistributeRemainingCost";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribute Remaining Cost";
            this.Load += new System.EventHandler(this.frmDistributeRemainingCost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDistributableCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommercialInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDistributableCost;
        private System.Windows.Forms.DataGridView dtgDistributableCost;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.DataGridView dtgCommercialInvoice;
        private System.Windows.Forms.Button cmdDistribute;
        private System.Windows.Forms.Label label1;
    }
}