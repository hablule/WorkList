namespace BuySimple
{
    partial class frmGenerateItemCost
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateItemCost));
            this.dtgDistributableCost = new System.Windows.Forms.DataGridView();
            this.dtgInvoiceLineCost = new System.Windows.Forms.DataGridView();
            this.cmdShowInvoiceLineCost = new System.Windows.Forms.Button();
            this.cmdRecordAndTransferCost = new System.Windows.Forms.Button();
            this.lblCommercialInvoice = new System.Windows.Forms.Label();
            this.lblPerformaInvoice = new System.Windows.Forms.Label();
            this.lblDistributableCost = new System.Windows.Forms.Label();
            this.lblCommercialInoiceCost = new System.Windows.Forms.Label();
            this.dtgInoiceTax = new System.Windows.Forms.DataGridView();
            this.lblInvoiceSubTotal = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblInvoicelineCostDistribution = new System.Windows.Forms.Label();
            this.lblInvoiceTax = new System.Windows.Forms.Label();
            this.cmdShowCostSheet = new System.Windows.Forms.Button();
            this.ddgCommercialInvoice = new BuySimple.DropDownDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDistributableCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoiceLineCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInoiceTax)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDistributableCost
            // 
            this.dtgDistributableCost.AllowUserToAddRows = false;
            this.dtgDistributableCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgDistributableCost.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgDistributableCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDistributableCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgDistributableCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDistributableCost.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgDistributableCost.Location = new System.Drawing.Point(6, 90);
            this.dtgDistributableCost.Name = "dtgDistributableCost";
            this.dtgDistributableCost.ReadOnly = true;
            this.dtgDistributableCost.RowHeadersVisible = false;
            this.dtgDistributableCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDistributableCost.Size = new System.Drawing.Size(575, 128);
            this.dtgDistributableCost.TabIndex = 1;
            this.dtgDistributableCost.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDistributableCost_CellClick);
            // 
            // dtgInvoiceLineCost
            // 
            this.dtgInvoiceLineCost.AllowUserToAddRows = false;
            this.dtgInvoiceLineCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgInvoiceLineCost.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgInvoiceLineCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoiceLineCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgInvoiceLineCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoiceLineCost.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtgInvoiceLineCost.Location = new System.Drawing.Point(7, 378);
            this.dtgInvoiceLineCost.Name = "dtgInvoiceLineCost";
            this.dtgInvoiceLineCost.ReadOnly = true;
            this.dtgInvoiceLineCost.RowHeadersVisible = false;
            this.dtgInvoiceLineCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInvoiceLineCost.Size = new System.Drawing.Size(574, 167);
            this.dtgInvoiceLineCost.TabIndex = 2;
            // 
            // cmdShowInvoiceLineCost
            // 
            this.cmdShowInvoiceLineCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowInvoiceLineCost.Location = new System.Drawing.Point(88, 224);
            this.cmdShowInvoiceLineCost.Name = "cmdShowInvoiceLineCost";
            this.cmdShowInvoiceLineCost.Size = new System.Drawing.Size(411, 36);
            this.cmdShowInvoiceLineCost.TabIndex = 3;
            this.cmdShowInvoiceLineCost.Text = "Show Cost Distribution";
            this.cmdShowInvoiceLineCost.UseVisualStyleBackColor = true;
            this.cmdShowInvoiceLineCost.Click += new System.EventHandler(this.cmdShowInvoiceLineCost_Click);
            this.cmdShowInvoiceLineCost.EnabledChanged += new System.EventHandler(this.cmdShowInvoiceLineCost_EnabledChanged);
            // 
            // cmdRecordAndTransferCost
            // 
            this.cmdRecordAndTransferCost.Enabled = false;
            this.cmdRecordAndTransferCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRecordAndTransferCost.ForeColor = System.Drawing.Color.Red;
            this.cmdRecordAndTransferCost.Location = new System.Drawing.Point(96, 587);
            this.cmdRecordAndTransferCost.Name = "cmdRecordAndTransferCost";
            this.cmdRecordAndTransferCost.Size = new System.Drawing.Size(397, 37);
            this.cmdRecordAndTransferCost.TabIndex = 4;
            this.cmdRecordAndTransferCost.Text = "Record And Transfer Cost";
            this.cmdRecordAndTransferCost.UseVisualStyleBackColor = true;
            this.cmdRecordAndTransferCost.Click += new System.EventHandler(this.cmdRecordAndTransferCost_Click);
            // 
            // lblCommercialInvoice
            // 
            this.lblCommercialInvoice.AutoSize = true;
            this.lblCommercialInvoice.Location = new System.Drawing.Point(12, 15);
            this.lblCommercialInvoice.Name = "lblCommercialInvoice";
            this.lblCommercialInvoice.Size = new System.Drawing.Size(99, 13);
            this.lblCommercialInvoice.TabIndex = 5;
            this.lblCommercialInvoice.Text = "Commercial Invoice";
            // 
            // lblPerformaInvoice
            // 
            this.lblPerformaInvoice.AutoSize = true;
            this.lblPerformaInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerformaInvoice.Location = new System.Drawing.Point(32, 46);
            this.lblPerformaInvoice.Name = "lblPerformaInvoice";
            this.lblPerformaInvoice.Size = new System.Drawing.Size(119, 13);
            this.lblPerformaInvoice.TabIndex = 6;
            this.lblPerformaInvoice.Text = "Performa Invoice :  ";
            // 
            // lblDistributableCost
            // 
            this.lblDistributableCost.AutoSize = true;
            this.lblDistributableCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistributableCost.Location = new System.Drawing.Point(6, 72);
            this.lblDistributableCost.Name = "lblDistributableCost";
            this.lblDistributableCost.Size = new System.Drawing.Size(310, 15);
            this.lblDistributableCost.TabIndex = 7;
            this.lblDistributableCost.Text = "Distributable Payments For Commercial Invoice";
            // 
            // lblCommercialInoiceCost
            // 
            this.lblCommercialInoiceCost.AutoSize = true;
            this.lblCommercialInoiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommercialInoiceCost.Location = new System.Drawing.Point(173, 267);
            this.lblCommercialInoiceCost.Name = "lblCommercialInoiceCost";
            this.lblCommercialInoiceCost.Size = new System.Drawing.Size(243, 15);
            this.lblCommercialInoiceCost.TabIndex = 8;
            this.lblCommercialInoiceCost.Text = "Commercial Invoice Cost Distribution";
            // 
            // dtgInoiceTax
            // 
            this.dtgInoiceTax.AllowUserToAddRows = false;
            this.dtgInoiceTax.AllowUserToDeleteRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgInoiceTax.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dtgInoiceTax.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgInoiceTax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInoiceTax.DefaultCellStyle = dataGridViewCellStyle16;
            this.dtgInoiceTax.Location = new System.Drawing.Point(318, 293);
            this.dtgInoiceTax.MultiSelect = false;
            this.dtgInoiceTax.Name = "dtgInoiceTax";
            this.dtgInoiceTax.ReadOnly = true;
            this.dtgInoiceTax.RowHeadersVisible = false;
            this.dtgInoiceTax.RowHeadersWidth = 25;
            this.dtgInoiceTax.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInoiceTax.Size = new System.Drawing.Size(263, 78);
            this.dtgInoiceTax.TabIndex = 9;
            // 
            // lblInvoiceSubTotal
            // 
            this.lblInvoiceSubTotal.AutoSize = true;
            this.lblInvoiceSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceSubTotal.Location = new System.Drawing.Point(30, 301);
            this.lblInvoiceSubTotal.Name = "lblInvoiceSubTotal";
            this.lblInvoiceSubTotal.Size = new System.Drawing.Size(70, 13);
            this.lblInvoiceSubTotal.TabIndex = 10;
            this.lblInvoiceSubTotal.Text = "Sub-Total: ";
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.Location = new System.Drawing.Point(31, 325);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceTotal.TabIndex = 11;
            this.lblInvoiceTotal.Text = "Grand Total: ";
            // 
            // lblInvoicelineCostDistribution
            // 
            this.lblInvoicelineCostDistribution.AutoSize = true;
            this.lblInvoicelineCostDistribution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoicelineCostDistribution.Location = new System.Drawing.Point(7, 361);
            this.lblInvoicelineCostDistribution.Name = "lblInvoicelineCostDistribution";
            this.lblInvoicelineCostDistribution.Size = new System.Drawing.Size(105, 13);
            this.lblInvoicelineCostDistribution.TabIndex = 12;
            this.lblInvoicelineCostDistribution.Text = "Invoicel LineCost";
            // 
            // lblInvoiceTax
            // 
            this.lblInvoiceTax.AutoSize = true;
            this.lblInvoiceTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTax.Location = new System.Drawing.Point(507, 277);
            this.lblInvoiceTax.Name = "lblInvoiceTax";
            this.lblInvoiceTax.Size = new System.Drawing.Size(74, 13);
            this.lblInvoiceTax.TabIndex = 13;
            this.lblInvoiceTax.Text = "Invoice Tax";
            // 
            // cmdShowCostSheet
            // 
            this.cmdShowCostSheet.Enabled = false;
            this.cmdShowCostSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowCostSheet.Location = new System.Drawing.Point(178, 552);
            this.cmdShowCostSheet.Name = "cmdShowCostSheet";
            this.cmdShowCostSheet.Size = new System.Drawing.Size(232, 29);
            this.cmdShowCostSheet.TabIndex = 14;
            this.cmdShowCostSheet.Text = "Cost Sheet";
            this.cmdShowCostSheet.UseVisualStyleBackColor = true;
            this.cmdShowCostSheet.Click += new System.EventHandler(this.cmdShowCostSheet_Click);
            // 
            // ddgCommercialInvoice
            // 
            this.ddgCommercialInvoice.AutoFilter = true;
            this.ddgCommercialInvoice.AutoSize = true;
            this.ddgCommercialInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgCommercialInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgCommercialInvoice.ClearButtonEnabled = true;
            this.ddgCommercialInvoice.DataTablePrimaryKey = ((ushort)(0));
            this.ddgCommercialInvoice.FindButtonEnabled = true;
            this.ddgCommercialInvoice.HiddenColoumns = new int[0];
            this.ddgCommercialInvoice.Image = null;
            this.ddgCommercialInvoice.Location = new System.Drawing.Point(114, 6);
            this.ddgCommercialInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCommercialInvoice.Name = "ddgCommercialInvoice";
            this.ddgCommercialInvoice.NewButtonEnabled = true;
            this.ddgCommercialInvoice.RefreshButtonEnabled = true;
            this.ddgCommercialInvoice.SelectedColomnIdex = 0;
            this.ddgCommercialInvoice.SelectedItem = "";
            this.ddgCommercialInvoice.SelectedRowKey = null;
            this.ddgCommercialInvoice.ShowGridFunctions = false;
            this.ddgCommercialInvoice.Size = new System.Drawing.Size(464, 31);
            this.ddgCommercialInvoice.TabIndex = 0;
            this.ddgCommercialInvoice.SelectedItemClicked += new System.EventHandler(this.ddgCommercialInvoice_SelectedItemClicked);
            this.ddgCommercialInvoice.selectedItemChanged += new System.EventHandler(this.ddgCommercialInvoice_selectedItemChanged);
            // 
            // frmGenerateItemCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 628);
            this.Controls.Add(this.cmdShowCostSheet);
            this.Controls.Add(this.lblInvoiceTax);
            this.Controls.Add(this.lblInvoicelineCostDistribution);
            this.Controls.Add(this.lblInvoiceTotal);
            this.Controls.Add(this.lblInvoiceSubTotal);
            this.Controls.Add(this.dtgInoiceTax);
            this.Controls.Add(this.lblCommercialInoiceCost);
            this.Controls.Add(this.lblDistributableCost);
            this.Controls.Add(this.lblPerformaInvoice);
            this.Controls.Add(this.lblCommercialInvoice);
            this.Controls.Add(this.cmdRecordAndTransferCost);
            this.Controls.Add(this.cmdShowInvoiceLineCost);
            this.Controls.Add(this.dtgInvoiceLineCost);
            this.Controls.Add(this.dtgDistributableCost);
            this.Controls.Add(this.ddgCommercialInvoice);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateItemCost";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Cost Generatot";
            this.Load += new System.EventHandler(this.frmGenerateItemCost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDistributableCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoiceLineCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInoiceTax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DropDownDataGrid ddgCommercialInvoice;
        private System.Windows.Forms.DataGridView dtgDistributableCost;
        private System.Windows.Forms.DataGridView dtgInvoiceLineCost;
        private System.Windows.Forms.Button cmdShowInvoiceLineCost;
        private System.Windows.Forms.Button cmdRecordAndTransferCost;
        private System.Windows.Forms.Label lblCommercialInvoice;
        private System.Windows.Forms.Label lblPerformaInvoice;
        private System.Windows.Forms.Label lblDistributableCost;
        private System.Windows.Forms.Label lblCommercialInoiceCost;
        private System.Windows.Forms.DataGridView dtgInoiceTax;
        private System.Windows.Forms.Label lblInvoiceSubTotal;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.Label lblInvoicelineCostDistribution;
        private System.Windows.Forms.Label lblInvoiceTax;
        private System.Windows.Forms.Button cmdShowCostSheet;

    }
}