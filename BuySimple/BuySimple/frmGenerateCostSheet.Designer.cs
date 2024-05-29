namespace BuySimple
{
    partial class frmGenerateCostSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateCostSheet));
            this.lblCommercialInvoice = new System.Windows.Forms.Label();
            this.cmdShowCostSheet = new System.Windows.Forms.Button();
            this.ddgCommercialInvoice = new BuySimple.DropDownDataGrid();
            this.SuspendLayout();
            // 
            // lblCommercialInvoice
            // 
            this.lblCommercialInvoice.AutoSize = true;
            this.lblCommercialInvoice.Location = new System.Drawing.Point(12, 30);
            this.lblCommercialInvoice.Name = "lblCommercialInvoice";
            this.lblCommercialInvoice.Size = new System.Drawing.Size(99, 13);
            this.lblCommercialInvoice.TabIndex = 7;
            this.lblCommercialInvoice.Text = "Commercial Invoice";
            // 
            // cmdShowCostSheet
            // 
            this.cmdShowCostSheet.Enabled = false;
            this.cmdShowCostSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowCostSheet.Location = new System.Drawing.Point(149, 102);
            this.cmdShowCostSheet.Name = "cmdShowCostSheet";
            this.cmdShowCostSheet.Size = new System.Drawing.Size(232, 29);
            this.cmdShowCostSheet.TabIndex = 15;
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
            this.ddgCommercialInvoice.Location = new System.Drawing.Point(114, 21);
            this.ddgCommercialInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgCommercialInvoice.Name = "ddgCommercialInvoice";
            this.ddgCommercialInvoice.NewButtonEnabled = true;
            this.ddgCommercialInvoice.RefreshButtonEnabled = true;
            this.ddgCommercialInvoice.SelectedColomnIdex = 0;
            this.ddgCommercialInvoice.SelectedItem = "";
            this.ddgCommercialInvoice.SelectedRowKey = null;
            this.ddgCommercialInvoice.ShowGridFunctions = false;
            this.ddgCommercialInvoice.Size = new System.Drawing.Size(372, 31);
            this.ddgCommercialInvoice.TabIndex = 6;
            this.ddgCommercialInvoice.SelectedItemClicked += new System.EventHandler(this.ddgCommercialInvoice_SelectedItemClicked);
            this.ddgCommercialInvoice.selectedItemChanged += new System.EventHandler(this.ddgCommercialInvoice_selectedItemChanged);
            // 
            // frmGenerateCostSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 188);
            this.Controls.Add(this.cmdShowCostSheet);
            this.Controls.Add(this.lblCommercialInvoice);
            this.Controls.Add(this.ddgCommercialInvoice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateCostSheet";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate CostSheet";
            this.Load += new System.EventHandler(this.frmGenerateCostSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCommercialInvoice;
        private DropDownDataGrid ddgCommercialInvoice;
        private System.Windows.Forms.Button cmdShowCostSheet;
    }
}