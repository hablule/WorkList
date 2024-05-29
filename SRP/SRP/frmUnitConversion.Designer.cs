namespace SRP
{
    partial class frmUnitConversion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnitConversion));
            this.tlsCommandToolBar = new System.Windows.Forms.ToolStrip();
            this.tlsNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsDelete = new System.Windows.Forms.ToolStripButton();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.lblUCBaseUOM = new System.Windows.Forms.Label();
            this.lblUCDrivedUnit = new System.Windows.Forms.Label();
            this.lblUCMulitplier = new System.Windows.Forms.Label();
            this.lblUCProduct = new System.Windows.Forms.Label();
            this.lblUCDescription = new System.Windows.Forms.Label();
            this.cmbUCBaseUOM = new System.Windows.Forms.ComboBox();
            this.cmbUCDrivedUOM = new System.Windows.Forms.ComboBox();
            this.txtUCDescripton = new System.Windows.Forms.TextBox();
            this.cmdUCShowImage = new System.Windows.Forms.Button();
            this.dtgUCGridView = new System.Windows.Forms.DataGridView();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.ddgUCProduct = new SRP.DropDownDataGrid();
            this.ntbMultiplier = new SRP.ctlNumberTextBox();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUCGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsCommandToolBar
            // 
            this.tlsCommandToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsCommandToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNew,
            this.tlsSave,
            this.tlsDelete,
            this.tlsSearch,
            this.toolStripSeparator1,
            this.tlsFirstRecord,
            this.tlsPreviousRecord,
            this.tlsNextRecord,
            this.tlsLastRecord});
            this.tlsCommandToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsCommandToolBar.Name = "tlsCommandToolBar";
            this.tlsCommandToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlsCommandToolBar.Size = new System.Drawing.Size(451, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(35, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(35, 22);
            this.tlsSave.Text = "Save";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(44, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Visible = false;
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(46, 22);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(33, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(56, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(35, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.Visible = false;
            // 
            // lblUCBaseUOM
            // 
            this.lblUCBaseUOM.AutoSize = true;
            this.lblUCBaseUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCBaseUOM.Location = new System.Drawing.Point(71, 44);
            this.lblUCBaseUOM.Name = "lblUCBaseUOM";
            this.lblUCBaseUOM.Size = new System.Drawing.Size(69, 15);
            this.lblUCBaseUOM.TabIndex = 0;
            this.lblUCBaseUOM.Text = "Base Unit";
            this.lblUCBaseUOM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUCDrivedUnit
            // 
            this.lblUCDrivedUnit.AutoSize = true;
            this.lblUCDrivedUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCDrivedUnit.Location = new System.Drawing.Point(62, 70);
            this.lblUCDrivedUnit.Name = "lblUCDrivedUnit";
            this.lblUCDrivedUnit.Size = new System.Drawing.Size(78, 15);
            this.lblUCDrivedUnit.TabIndex = 1;
            this.lblUCDrivedUnit.Text = "Drived Unit";
            this.lblUCDrivedUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUCMulitplier
            // 
            this.lblUCMulitplier.AutoSize = true;
            this.lblUCMulitplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCMulitplier.Location = new System.Drawing.Point(72, 96);
            this.lblUCMulitplier.Name = "lblUCMulitplier";
            this.lblUCMulitplier.Size = new System.Drawing.Size(68, 15);
            this.lblUCMulitplier.TabIndex = 2;
            this.lblUCMulitplier.Text = "Multiplier";
            this.lblUCMulitplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUCProduct
            // 
            this.lblUCProduct.AutoSize = true;
            this.lblUCProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCProduct.Location = new System.Drawing.Point(13, 148);
            this.lblUCProduct.Name = "lblUCProduct";
            this.lblUCProduct.Size = new System.Drawing.Size(127, 15);
            this.lblUCProduct.TabIndex = 3;
            this.lblUCProduct.Text = "Product Applicable";
            this.lblUCProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUCDescription
            // 
            this.lblUCDescription.AutoSize = true;
            this.lblUCDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCDescription.Location = new System.Drawing.Point(60, 179);
            this.lblUCDescription.Name = "lblUCDescription";
            this.lblUCDescription.Size = new System.Drawing.Size(80, 15);
            this.lblUCDescription.TabIndex = 4;
            this.lblUCDescription.Text = "Description";
            this.lblUCDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbUCBaseUOM
            // 
            this.cmbUCBaseUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUCBaseUOM.FormattingEnabled = true;
            this.cmbUCBaseUOM.Location = new System.Drawing.Point(146, 41);
            this.cmbUCBaseUOM.Name = "cmbUCBaseUOM";
            this.cmbUCBaseUOM.Size = new System.Drawing.Size(121, 21);
            this.cmbUCBaseUOM.TabIndex = 5;
            this.cmbUCBaseUOM.SelectedIndexChanged += new System.EventHandler(this.cmbUCBaseUOM_SelectedIndexChanged);
            this.cmbUCBaseUOM.DropDown += new System.EventHandler(this.cmbUCBaseUOM_DropDown);
            // 
            // cmbUCDrivedUOM
            // 
            this.cmbUCDrivedUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUCDrivedUOM.FormattingEnabled = true;
            this.cmbUCDrivedUOM.Location = new System.Drawing.Point(146, 67);
            this.cmbUCDrivedUOM.Name = "cmbUCDrivedUOM";
            this.cmbUCDrivedUOM.Size = new System.Drawing.Size(144, 21);
            this.cmbUCDrivedUOM.TabIndex = 6;
            this.cmbUCDrivedUOM.DropDown += new System.EventHandler(this.cmbUCDrivedUOM_DropDown);
            // 
            // txtUCDescripton
            // 
            this.txtUCDescripton.Location = new System.Drawing.Point(146, 175);
            this.txtUCDescripton.Multiline = true;
            this.txtUCDescripton.Name = "txtUCDescripton";
            this.txtUCDescripton.Size = new System.Drawing.Size(220, 86);
            this.txtUCDescripton.TabIndex = 8;
            // 
            // cmdUCShowImage
            // 
            this.cmdUCShowImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUCShowImage.Location = new System.Drawing.Point(367, 144);
            this.cmdUCShowImage.Name = "cmdUCShowImage";
            this.cmdUCShowImage.Size = new System.Drawing.Size(45, 23);
            this.cmdUCShowImage.TabIndex = 11;
            this.cmdUCShowImage.Text = "Img...";
            this.cmdUCShowImage.UseVisualStyleBackColor = true;
            this.cmdUCShowImage.Click += new System.EventHandler(this.cmdUCShowImage_Click);
            // 
            // dtgUCGridView
            // 
            this.dtgUCGridView.AllowUserToAddRows = false;
            this.dtgUCGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgUCGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgUCGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgUCGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgUCGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgUCGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgUCGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUCGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgUCGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUCGridView.Location = new System.Drawing.Point(2, 267);
            this.dtgUCGridView.MultiSelect = false;
            this.dtgUCGridView.Name = "dtgUCGridView";
            this.dtgUCGridView.ReadOnly = true;
            this.dtgUCGridView.RowHeadersWidth = 21;
            this.dtgUCGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUCGridView.Size = new System.Drawing.Size(448, 154);
            this.dtgUCGridView.TabIndex = 12;
            this.dtgUCGridView.SelectionChanged += new System.EventHandler(this.dtgUCGridView_SelectionChanged);
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsActive.Location = new System.Drawing.Point(150, 119);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(69, 19);
            this.ckIsActive.TabIndex = 13;
            this.ckIsActive.Text = "Is Active";
            this.ckIsActive.UseVisualStyleBackColor = true;
            // 
            // ddgUCProduct
            // 
            this.ddgUCProduct.AutoFilter = true;
            this.ddgUCProduct.AutoSize = true;
            this.ddgUCProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgUCProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgUCProduct.ClearButtonEnabled = true;
            this.ddgUCProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgUCProduct.FindButtonEnabled = true;
            this.ddgUCProduct.HiddenColoumns = new int[0];
            this.ddgUCProduct.Image = null;
            this.ddgUCProduct.Location = new System.Drawing.Point(142, 141);
            this.ddgUCProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgUCProduct.Name = "ddgUCProduct";
            this.ddgUCProduct.NewButtonEnabled = true;
            this.ddgUCProduct.RefreshButtonEnabled = true;
            this.ddgUCProduct.SelectedColomnIdex = 0;
            this.ddgUCProduct.SelectedItem = "";
            this.ddgUCProduct.SelectedRowKey = null;
            this.ddgUCProduct.ShowGridFunctions = false;
            this.ddgUCProduct.Size = new System.Drawing.Size(224, 31);
            this.ddgUCProduct.TabIndex = 10;
            this.ddgUCProduct.SelectedItemClicked += new System.EventHandler(this.ddgUCProduct_SelectedItemClicked);
            this.ddgUCProduct.selectedItemChanged += new System.EventHandler(this.ddgUCProduct_selectedItemChanged);
            // 
            // ntbMultiplier
            // 
            this.ntbMultiplier.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMultiplier.AllowNegative = false;
            this.ntbMultiplier.Amount = "0";
            this.ntbMultiplier.Location = new System.Drawing.Point(143, 92);
            this.ntbMultiplier.Name = "ntbMultiplier";
            this.ntbMultiplier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMultiplier.ShowThousandSeparetor = true;
            this.ntbMultiplier.Size = new System.Drawing.Size(163, 23);
            this.ntbMultiplier.StandardPrecision = 2;
            this.ntbMultiplier.TabIndex = 7;
            // 
            // frmUnitConversion
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.dtgUCGridView);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.cmdUCShowImage);
            this.Controls.Add(this.ddgUCProduct);
            this.Controls.Add(this.txtUCDescripton);
            this.Controls.Add(this.ntbMultiplier);
            this.Controls.Add(this.cmbUCDrivedUOM);
            this.Controls.Add(this.cmbUCBaseUOM);
            this.Controls.Add(this.lblUCDescription);
            this.Controls.Add(this.lblUCProduct);
            this.Controls.Add(this.lblUCMulitplier);
            this.Controls.Add(this.lblUCDrivedUnit);
            this.Controls.Add(this.lblUCBaseUOM);
            this.Size = new System.Drawing.Size(451, 423);
            this.Text = "Unit Conversion";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUCGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsCommandToolBar;
        private System.Windows.Forms.ToolStripButton tlsNew;
        private System.Windows.Forms.ToolStripButton tlsSave;
        private System.Windows.Forms.ToolStripButton tlsDelete;
        private System.Windows.Forms.ToolStripButton tlsSearch;
        private System.Windows.Forms.ToolStripButton tlsFirstRecord;
        private System.Windows.Forms.ToolStripButton tlsPreviousRecord;
        private System.Windows.Forms.ToolStripButton tlsNextRecord;
        private System.Windows.Forms.ToolStripButton tlsLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblUCBaseUOM;
        private System.Windows.Forms.Label lblUCDrivedUnit;
        private System.Windows.Forms.Label lblUCMulitplier;
        private System.Windows.Forms.Label lblUCProduct;
        private System.Windows.Forms.Label lblUCDescription;
        private System.Windows.Forms.ComboBox cmbUCBaseUOM;
        private System.Windows.Forms.ComboBox cmbUCDrivedUOM;
        private ctlNumberTextBox ntbMultiplier;
        private System.Windows.Forms.TextBox txtUCDescripton;
        private DropDownDataGrid ddgUCProduct;
        private System.Windows.Forms.Button cmdUCShowImage;
        private System.Windows.Forms.DataGridView dtgUCGridView;
        private System.Windows.Forms.CheckBox ckIsActive;
    }
}