namespace EasyMove
{
    partial class frmMatchInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatchInvoices));
            this.grbParameter = new System.Windows.Forms.GroupBox();
            this.lblReceivedTo = new System.Windows.Forms.Label();
            this.cmbMoveFromLogic = new System.Windows.Forms.ComboBox();
            this.cmbMovedFrom = new System.Windows.Forms.ComboBox();
            this.cmbMovementDateLogic = new System.Windows.Forms.ComboBox();
            this.cmdDisplay = new System.Windows.Forms.Button();
            this.dtpMoveDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpMoveDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblGRN = new System.Windows.Forms.Label();
            this.lblDated = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.grbIncomingInventory = new System.Windows.Forms.GroupBox();
            this.dtgIncomingInventory = new System.Windows.Forms.DataGridView();
            this.grbmatchingInvoice = new System.Windows.Forms.GroupBox();
            this.dtgInvoice = new System.Windows.Forms.DataGridView();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMatchedQty = new System.Windows.Forms.Label();
            this.cmdProcessMatching = new System.Windows.Forms.Button();
            this.txtRemainingQty = new System.Windows.Forms.TextBox();
            this.txtMathcedQty = new System.Windows.Forms.TextBox();
            this.ddgGRN = new EasyMove.DropDownDataGrid();
            this.ddgBpartner = new EasyMove.DropDownDataGrid();
            this.grbParameter.SuspendLayout();
            this.grbIncomingInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncomingInventory)).BeginInit();
            this.grbmatchingInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoice)).BeginInit();
            this.grbProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbParameter
            // 
            this.grbParameter.Controls.Add(this.lblReceivedTo);
            this.grbParameter.Controls.Add(this.cmbMoveFromLogic);
            this.grbParameter.Controls.Add(this.cmbMovedFrom);
            this.grbParameter.Controls.Add(this.cmbMovementDateLogic);
            this.grbParameter.Controls.Add(this.cmdDisplay);
            this.grbParameter.Controls.Add(this.dtpMoveDateTo);
            this.grbParameter.Controls.Add(this.dtpMoveDateFrom);
            this.grbParameter.Controls.Add(this.ddgGRN);
            this.grbParameter.Controls.Add(this.ddgBpartner);
            this.grbParameter.Controls.Add(this.lblGRN);
            this.grbParameter.Controls.Add(this.lblDated);
            this.grbParameter.Controls.Add(this.lblVendor);
            this.grbParameter.Location = new System.Drawing.Point(15, 2);
            this.grbParameter.Name = "grbParameter";
            this.grbParameter.Size = new System.Drawing.Size(625, 185);
            this.grbParameter.TabIndex = 0;
            this.grbParameter.TabStop = false;
            this.grbParameter.Text = "Search";
            // 
            // lblReceivedTo
            // 
            this.lblReceivedTo.Location = new System.Drawing.Point(18, 117);
            this.lblReceivedTo.Name = "lblReceivedTo";
            this.lblReceivedTo.Size = new System.Drawing.Size(73, 19);
            this.lblReceivedTo.TabIndex = 21;
            this.lblReceivedTo.Text = "Received to";
            this.lblReceivedTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMoveFromLogic
            // 
            this.cmbMoveFromLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveFromLogic.DropDownWidth = 130;
            this.cmbMoveFromLogic.FormattingEnabled = true;
            this.cmbMoveFromLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbMoveFromLogic.Location = new System.Drawing.Point(96, 115);
            this.cmbMoveFromLogic.Name = "cmbMoveFromLogic";
            this.cmbMoveFromLogic.Size = new System.Drawing.Size(97, 21);
            this.cmbMoveFromLogic.TabIndex = 22;
            this.cmbMoveFromLogic.SelectedIndexChanged += new System.EventHandler(this.cmbMoveFromLogic_SelectedIndexChanged);
            // 
            // cmbMovedFrom
            // 
            this.cmbMovedFrom.Enabled = false;
            this.cmbMovedFrom.FormattingEnabled = true;
            this.cmbMovedFrom.Location = new System.Drawing.Point(199, 115);
            this.cmbMovedFrom.Name = "cmbMovedFrom";
            this.cmbMovedFrom.Size = new System.Drawing.Size(213, 21);
            this.cmbMovedFrom.TabIndex = 23;
            this.cmbMovedFrom.SelectedIndexChanged += new System.EventHandler(this.cmbMovedFrom_SelectedIndexChanged);
            // 
            // cmbMovementDateLogic
            // 
            this.cmbMovementDateLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementDateLogic.DropDownWidth = 130;
            this.cmbMovementDateLogic.FormattingEnabled = true;
            this.cmbMovementDateLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbMovementDateLogic.Location = new System.Drawing.Point(96, 85);
            this.cmbMovementDateLogic.Name = "cmbMovementDateLogic";
            this.cmbMovementDateLogic.Size = new System.Drawing.Size(97, 21);
            this.cmbMovementDateLogic.TabIndex = 7;
            this.cmbMovementDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbMovementDateLogic_SelectedIndexChanged);
            // 
            // cmdDisplay
            // 
            this.cmdDisplay.Location = new System.Drawing.Point(199, 142);
            this.cmdDisplay.Name = "cmdDisplay";
            this.cmdDisplay.Size = new System.Drawing.Size(249, 35);
            this.cmdDisplay.TabIndex = 6;
            this.cmdDisplay.Text = "Display";
            this.cmdDisplay.UseVisualStyleBackColor = true;
            this.cmdDisplay.Click += new System.EventHandler(this.cmdDisplay_Click);
            // 
            // dtpMoveDateTo
            // 
            this.dtpMoveDateTo.Location = new System.Drawing.Point(398, 85);
            this.dtpMoveDateTo.Name = "dtpMoveDateTo";
            this.dtpMoveDateTo.Size = new System.Drawing.Size(188, 20);
            this.dtpMoveDateTo.TabIndex = 5;
            this.dtpMoveDateTo.Visible = false;
            // 
            // dtpMoveDateFrom
            // 
            this.dtpMoveDateFrom.Enabled = false;
            this.dtpMoveDateFrom.Location = new System.Drawing.Point(199, 85);
            this.dtpMoveDateFrom.Name = "dtpMoveDateFrom";
            this.dtpMoveDateFrom.Size = new System.Drawing.Size(188, 20);
            this.dtpMoveDateFrom.TabIndex = 5;
            // 
            // lblGRN
            // 
            this.lblGRN.Location = new System.Drawing.Point(18, 54);
            this.lblGRN.Name = "lblGRN";
            this.lblGRN.Size = new System.Drawing.Size(73, 19);
            this.lblGRN.TabIndex = 2;
            this.lblGRN.Text = "GRN";
            this.lblGRN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDated
            // 
            this.lblDated.Location = new System.Drawing.Point(18, 86);
            this.lblDated.Name = "lblDated";
            this.lblDated.Size = new System.Drawing.Size(73, 19);
            this.lblDated.TabIndex = 1;
            this.lblDated.Text = "Dated";
            this.lblDated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendor
            // 
            this.lblVendor.Location = new System.Drawing.Point(18, 20);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(73, 19);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Vendor";
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbIncomingInventory
            // 
            this.grbIncomingInventory.Controls.Add(this.dtgIncomingInventory);
            this.grbIncomingInventory.Location = new System.Drawing.Point(2, 194);
            this.grbIncomingInventory.Name = "grbIncomingInventory";
            this.grbIncomingInventory.Size = new System.Drawing.Size(655, 150);
            this.grbIncomingInventory.TabIndex = 0;
            this.grbIncomingInventory.TabStop = false;
            this.grbIncomingInventory.Text = "Incoming Inventory";
            // 
            // dtgIncomingInventory
            // 
            this.dtgIncomingInventory.AllowUserToAddRows = false;
            this.dtgIncomingInventory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgIncomingInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgIncomingInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgIncomingInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgIncomingInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgIncomingInventory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgIncomingInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIncomingInventory.GridColor = System.Drawing.SystemColors.ControlText;
            this.dtgIncomingInventory.Location = new System.Drawing.Point(3, 16);
            this.dtgIncomingInventory.Margin = new System.Windows.Forms.Padding(0);
            this.dtgIncomingInventory.MultiSelect = false;
            this.dtgIncomingInventory.Name = "dtgIncomingInventory";
            this.dtgIncomingInventory.ReadOnly = true;
            this.dtgIncomingInventory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgIncomingInventory.RowHeadersWidth = 20;
            this.dtgIncomingInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIncomingInventory.Size = new System.Drawing.Size(649, 131);
            this.dtgIncomingInventory.TabIndex = 4;
            this.dtgIncomingInventory.TabStop = false;
            this.dtgIncomingInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIncomingInventory_CellClick);
            // 
            // grbmatchingInvoice
            // 
            this.grbmatchingInvoice.Controls.Add(this.dtgInvoice);
            this.grbmatchingInvoice.Location = new System.Drawing.Point(2, 349);
            this.grbmatchingInvoice.Name = "grbmatchingInvoice";
            this.grbmatchingInvoice.Size = new System.Drawing.Size(655, 146);
            this.grbmatchingInvoice.TabIndex = 0;
            this.grbmatchingInvoice.TabStop = false;
            this.grbmatchingInvoice.Text = "Matching Invoice";
            // 
            // dtgInvoice
            // 
            this.dtgInvoice.AllowUserToAddRows = false;
            this.dtgInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgInvoice.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgInvoice.GridColor = System.Drawing.SystemColors.ControlText;
            this.dtgInvoice.Location = new System.Drawing.Point(3, 16);
            this.dtgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.dtgInvoice.MultiSelect = false;
            this.dtgInvoice.Name = "dtgInvoice";
            this.dtgInvoice.ReadOnly = true;
            this.dtgInvoice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgInvoice.RowHeadersWidth = 20;
            this.dtgInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInvoice.Size = new System.Drawing.Size(649, 127);
            this.dtgInvoice.TabIndex = 5;
            this.dtgInvoice.TabStop = false;
            this.dtgInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInvoice_CellClick);
            // 
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.label6);
            this.grbProcess.Controls.Add(this.lblMatchedQty);
            this.grbProcess.Controls.Add(this.cmdProcessMatching);
            this.grbProcess.Controls.Add(this.txtRemainingQty);
            this.grbProcess.Controls.Add(this.txtMathcedQty);
            this.grbProcess.Location = new System.Drawing.Point(2, 504);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(649, 59);
            this.grbProcess.TabIndex = 1;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "Process";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Remaining Quantity";
            // 
            // lblMatchedQty
            // 
            this.lblMatchedQty.AutoSize = true;
            this.lblMatchedQty.Location = new System.Drawing.Point(66, 25);
            this.lblMatchedQty.Name = "lblMatchedQty";
            this.lblMatchedQty.Size = new System.Drawing.Size(91, 13);
            this.lblMatchedQty.TabIndex = 2;
            this.lblMatchedQty.Text = "Matched Quantity";
            // 
            // cmdProcessMatching
            // 
            this.cmdProcessMatching.Enabled = false;
            this.cmdProcessMatching.Location = new System.Drawing.Point(488, 20);
            this.cmdProcessMatching.Name = "cmdProcessMatching";
            this.cmdProcessMatching.Size = new System.Drawing.Size(103, 23);
            this.cmdProcessMatching.TabIndex = 1;
            this.cmdProcessMatching.Text = "Process";
            this.cmdProcessMatching.UseVisualStyleBackColor = true;
            this.cmdProcessMatching.Click += new System.EventHandler(this.cmdProcessMatching_Click);
            // 
            // txtRemainingQty
            // 
            this.txtRemainingQty.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtRemainingQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRemainingQty.Location = new System.Drawing.Point(376, 22);
            this.txtRemainingQty.Name = "txtRemainingQty";
            this.txtRemainingQty.ReadOnly = true;
            this.txtRemainingQty.Size = new System.Drawing.Size(100, 20);
            this.txtRemainingQty.TabIndex = 0;
            this.txtRemainingQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMathcedQty
            // 
            this.txtMathcedQty.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtMathcedQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMathcedQty.Location = new System.Drawing.Point(161, 22);
            this.txtMathcedQty.Name = "txtMathcedQty";
            this.txtMathcedQty.ReadOnly = true;
            this.txtMathcedQty.Size = new System.Drawing.Size(100, 20);
            this.txtMathcedQty.TabIndex = 0;
            this.txtMathcedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ddgGRN
            // 
            this.ddgGRN.AutoFilter = true;
            this.ddgGRN.AutoSize = true;
            this.ddgGRN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgGRN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgGRN.ClearButtonEnabled = true;
            this.ddgGRN.DataTablePrimaryKey = ((ushort)(0));
            this.ddgGRN.FindButtonEnabled = true;
            this.ddgGRN.HiddenColoumns = new int[0];
            this.ddgGRN.Image = null;
            this.ddgGRN.Location = new System.Drawing.Point(90, 49);
            this.ddgGRN.Margin = new System.Windows.Forms.Padding(0);
            this.ddgGRN.Name = "ddgGRN";
            this.ddgGRN.NewButtonEnabled = true;
            this.ddgGRN.RefreshButtonEnabled = true;
            this.ddgGRN.SelectedColomnIdex = 0;
            this.ddgGRN.SelectedItem = "";
            this.ddgGRN.SelectedRowKey = null;
            this.ddgGRN.ShowGridFunctions = false;
            this.ddgGRN.Size = new System.Drawing.Size(265, 31);
            this.ddgGRN.TabIndex = 4;
            this.ddgGRN.SelectedItemClicked += new System.EventHandler(this.ddgGRN_SelectedItemClicked);
            this.ddgGRN.selectedItemChanged += new System.EventHandler(this.ddgGRN_selectedItemChanged);
            // 
            // ddgBpartner
            // 
            this.ddgBpartner.AutoFilter = true;
            this.ddgBpartner.AutoSize = true;
            this.ddgBpartner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBpartner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBpartner.ClearButtonEnabled = true;
            this.ddgBpartner.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBpartner.FindButtonEnabled = true;
            this.ddgBpartner.HiddenColoumns = new int[0];
            this.ddgBpartner.Image = null;
            this.ddgBpartner.Location = new System.Drawing.Point(90, 16);
            this.ddgBpartner.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBpartner.Name = "ddgBpartner";
            this.ddgBpartner.NewButtonEnabled = true;
            this.ddgBpartner.RefreshButtonEnabled = true;
            this.ddgBpartner.SelectedColomnIdex = 0;
            this.ddgBpartner.SelectedItem = "";
            this.ddgBpartner.SelectedRowKey = null;
            this.ddgBpartner.ShowGridFunctions = false;
            this.ddgBpartner.Size = new System.Drawing.Size(322, 31);
            this.ddgBpartner.TabIndex = 4;
            this.ddgBpartner.SelectedItemClicked += new System.EventHandler(this.ddgBpartner_SelectedItemClicked);
            this.ddgBpartner.selectedItemChanged += new System.EventHandler(this.ddgBpartner_selectedItemChanged);
            // 
            // frmMatchInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 569);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbmatchingInvoice);
            this.Controls.Add(this.grbIncomingInventory);
            this.Controls.Add(this.grbParameter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMatchInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMatchInvoices";
            this.Load += new System.EventHandler(this.frmMatchInvoices_Load);
            this.grbParameter.ResumeLayout(false);
            this.grbParameter.PerformLayout();
            this.grbIncomingInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncomingInventory)).EndInit();
            this.grbmatchingInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoice)).EndInit();
            this.grbProcess.ResumeLayout(false);
            this.grbProcess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbParameter;
        private System.Windows.Forms.GroupBox grbIncomingInventory;
        private System.Windows.Forms.GroupBox grbmatchingInvoice;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.DateTimePicker dtpMoveDateTo;
        private System.Windows.Forms.DateTimePicker dtpMoveDateFrom;
        private DropDownDataGrid ddgGRN;
        private DropDownDataGrid ddgBpartner;
        private System.Windows.Forms.Label lblGRN;
        private System.Windows.Forms.Label lblDated;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Button cmdDisplay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMatchedQty;
        private System.Windows.Forms.Button cmdProcessMatching;
        private System.Windows.Forms.TextBox txtRemainingQty;
        private System.Windows.Forms.TextBox txtMathcedQty;
        private System.Windows.Forms.ComboBox cmbMovementDateLogic;
        private System.Windows.Forms.Label lblReceivedTo;
        private System.Windows.Forms.ComboBox cmbMoveFromLogic;
        private System.Windows.Forms.ComboBox cmbMovedFrom;
        private System.Windows.Forms.DataGridView dtgIncomingInventory;
        private System.Windows.Forms.DataGridView dtgInvoice;
    }
}