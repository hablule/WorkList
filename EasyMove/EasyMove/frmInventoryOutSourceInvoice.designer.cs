namespace EasyMove
{
    partial class frmInventoryOutSourceInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryOutSourceInvoice));
            this.grbInvoiceItems = new System.Windows.Forms.GroupBox();
            this.dtgInvoiceItems = new System.Windows.Forms.DataGridView();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.Invoice = new System.Windows.Forms.Label();
            this.ckSelectAll = new System.Windows.Forms.CheckBox();
            this.ddgInvoice = new EasyMove.DropDownDataGrid();
            this.grbInvoiceItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoiceItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grbInvoiceItems
            // 
            this.grbInvoiceItems.Controls.Add(this.dtgInvoiceItems);
            this.grbInvoiceItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInvoiceItems.Location = new System.Drawing.Point(7, 54);
            this.grbInvoiceItems.Name = "grbInvoiceItems";
            this.grbInvoiceItems.Size = new System.Drawing.Size(663, 358);
            this.grbInvoiceItems.TabIndex = 1;
            this.grbInvoiceItems.TabStop = false;
            this.grbInvoiceItems.Text = "Delivery Order Detail Info";
            // 
            // dtgInvoiceItems
            // 
            this.dtgInvoiceItems.AllowUserToAddRows = false;
            this.dtgInvoiceItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgInvoiceItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgInvoiceItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgInvoiceItems.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoiceItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoiceItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgInvoiceItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgInvoiceItems.GridColor = System.Drawing.SystemColors.ControlText;
            this.dtgInvoiceItems.Location = new System.Drawing.Point(3, 18);
            this.dtgInvoiceItems.Margin = new System.Windows.Forms.Padding(0);
            this.dtgInvoiceItems.MultiSelect = false;
            this.dtgInvoiceItems.Name = "dtgInvoiceItems";
            this.dtgInvoiceItems.ReadOnly = true;
            this.dtgInvoiceItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgInvoiceItems.RowHeadersVisible = false;
            this.dtgInvoiceItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInvoiceItems.Size = new System.Drawing.Size(657, 337);
            this.dtgInvoiceItems.TabIndex = 4;
            this.dtgInvoiceItems.TabStop = false;
            this.dtgInvoiceItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInvoiceItems_CellClick);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(193, 419);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(277, 54);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add to Receipt";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // Invoice
            // 
            this.Invoice.AutoSize = true;
            this.Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Invoice.Location = new System.Drawing.Point(60, 21);
            this.Invoice.Name = "Invoice";
            this.Invoice.Size = new System.Drawing.Size(95, 16);
            this.Invoice.TabIndex = 3;
            this.Invoice.Text = "Delivery Order";
            // 
            // ckSelectAll
            // 
            this.ckSelectAll.AutoSize = true;
            this.ckSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSelectAll.ForeColor = System.Drawing.Color.Green;
            this.ckSelectAll.Location = new System.Drawing.Point(16, 419);
            this.ckSelectAll.Name = "ckSelectAll";
            this.ckSelectAll.Size = new System.Drawing.Size(93, 20);
            this.ckSelectAll.TabIndex = 4;
            this.ckSelectAll.Text = "Select All";
            this.ckSelectAll.UseVisualStyleBackColor = true;
            this.ckSelectAll.CheckedChanged += new System.EventHandler(this.ckSelectAll_CheckedChanged);
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
            this.ddgInvoice.Location = new System.Drawing.Point(160, 15);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(383, 31);
            this.ddgInvoice.TabIndex = 0;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // frmInventoryOutSourceInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 485);
            this.Controls.Add(this.ckSelectAll);
            this.Controls.Add(this.Invoice);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.grbInvoiceItems);
            this.Controls.Add(this.ddgInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventoryOutSourceInvoice";
            this.Text = "Customer Sales Order";
            this.Load += new System.EventHandler(this.frmInventoryOutSourceInvoice_Load);
            this.grbInvoiceItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoiceItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DropDownDataGrid ddgInvoice;
        private System.Windows.Forms.GroupBox grbInvoiceItems;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label Invoice;
        private System.Windows.Forms.CheckBox ckSelectAll;
        private System.Windows.Forms.DataGridView dtgInvoiceItems;
    }
}