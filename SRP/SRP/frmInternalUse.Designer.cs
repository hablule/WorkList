namespace SRP
{
    partial class frmInternalUse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInternalUse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsCommandToolBar = new System.Windows.Forms.ToolStrip();
            this.tlsNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsDelete = new System.Windows.Forms.ToolStripButton();
            this.tlsReverse = new System.Windows.Forms.ToolStripButton();
            this.tlsSearch = new System.Windows.Forms.ToolStripButton();
            this.tlsToogleView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsPrint = new System.Windows.Forms.ToolStripButton();
            this.tlsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tlsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblUsedDate = new System.Windows.Forms.Label();
            this.lblUsedFrom = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblUsedQuantity = new System.Windows.Forms.Label();
            this.lblUsageLineDescription = new System.Windows.Forms.Label();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.dtpUsedDate = new System.Windows.Forms.DateTimePicker();
            this.cmbUsedFrom = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdAddUsageLine = new System.Windows.Forms.Button();
            this.txtUsageLineDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgUsageLineGridView = new System.Windows.Forms.DataGridView();
            this.dtgUsageGridView = new System.Windows.Forms.DataGridView();
            this.cmbDetailUsageOtherUOM = new System.Windows.Forms.ComboBox();
            this.ntbUsedQty = new SRP.ctlNumberTextBox();
            this.ddgProduct = new SRP.DropDownDataGrid();
            this.cmdDetailTrxProductImage = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsageLineGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsageGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsCommandToolBar
            // 
            this.tlsCommandToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsCommandToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNew,
            this.tlsSave,
            this.tlsDelete,
            this.tlsReverse,
            this.tlsSearch,
            this.tlsToogleView,
            this.toolStripSeparator1,
            this.tlsPrint,
            this.tlsFirstRecord,
            this.tlsPreviousRecord,
            this.tlsNextRecord,
            this.tlsLastRecord});
            this.tlsCommandToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsCommandToolBar.Name = "tlsCommandToolBar";
            this.tlsCommandToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlsCommandToolBar.Size = new System.Drawing.Size(462, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(32, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(48, 22);
            this.tlsSave.Text = "Process";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(42, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Click += new System.EventHandler(this.tlsDelete_Click);
            // 
            // tlsReverse
            // 
            this.tlsReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsReverse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsReverse.ForeColor = System.Drawing.Color.Red;
            this.tlsReverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsReverse.Name = "tlsReverse";
            this.tlsReverse.Size = new System.Drawing.Size(58, 22);
            this.tlsReverse.Text = "Reverse";
            this.tlsReverse.Click += new System.EventHandler(this.tlsReverse_Click);
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(44, 22);
            this.tlsSearch.Text = "Search";
            this.tlsSearch.Click += new System.EventHandler(this.tlsSearch_Click);
            // 
            // tlsToogleView
            // 
            this.tlsToogleView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsToogleView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsToogleView.Name = "tlsToogleView";
            this.tlsToogleView.Size = new System.Drawing.Size(55, 22);
            this.tlsToogleView.Text = "Grid View";
            this.tlsToogleView.Click += new System.EventHandler(this.tlsToogleView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsPrint
            // 
            this.tlsPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsPrint.Image")));
            this.tlsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPrint.Name = "tlsPrint";
            this.tlsPrint.Size = new System.Drawing.Size(33, 22);
            this.tlsPrint.Text = "Print";
            this.tlsPrint.Click += new System.EventHandler(this.tlsPrint_Click);
            // 
            // tlsFirstRecord
            // 
            this.tlsFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(52, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(34, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(23, 22);
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNo.Location = new System.Drawing.Point(15, 63);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(88, 13);
            this.lblDocumentNo.TabIndex = 1;
            this.lblDocumentNo.Text = "Document No.";
            // 
            // lblUsedDate
            // 
            this.lblUsedDate.AutoSize = true;
            this.lblUsedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedDate.Location = new System.Drawing.Point(34, 86);
            this.lblUsedDate.Name = "lblUsedDate";
            this.lblUsedDate.Size = new System.Drawing.Size(67, 13);
            this.lblUsedDate.TabIndex = 2;
            this.lblUsedDate.Text = "Used Date";
            // 
            // lblUsedFrom
            // 
            this.lblUsedFrom.AutoSize = true;
            this.lblUsedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedFrom.Location = new System.Drawing.Point(34, 110);
            this.lblUsedFrom.Name = "lblUsedFrom";
            this.lblUsedFrom.Size = new System.Drawing.Size(67, 13);
            this.lblUsedFrom.TabIndex = 3;
            this.lblUsedFrom.Text = "Used From";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(24, 135);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 37);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description/Comment";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(57, 237);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(51, 13);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product";
            // 
            // lblUsedQuantity
            // 
            this.lblUsedQuantity.AutoSize = true;
            this.lblUsedQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblUsedQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedQuantity.Location = new System.Drawing.Point(40, 264);
            this.lblUsedQuantity.Name = "lblUsedQuantity";
            this.lblUsedQuantity.Size = new System.Drawing.Size(59, 13);
            this.lblUsedQuantity.TabIndex = 7;
            this.lblUsedQuantity.Text = "Qty Used";
            // 
            // lblUsageLineDescription
            // 
            this.lblUsageLineDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblUsageLineDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLineDescription.Location = new System.Drawing.Point(28, 288);
            this.lblUsageLineDescription.Name = "lblUsageLineDescription";
            this.lblUsageLineDescription.Size = new System.Drawing.Size(81, 35);
            this.lblUsageLineDescription.TabIndex = 9;
            this.lblUsageLineDescription.Text = "Description/Comment";
            this.lblUsageLineDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(108, 59);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(166, 20);
            this.txtDocumentNo.TabIndex = 10;
            // 
            // dtpUsedDate
            // 
            this.dtpUsedDate.Location = new System.Drawing.Point(108, 82);
            this.dtpUsedDate.Name = "dtpUsedDate";
            this.dtpUsedDate.Size = new System.Drawing.Size(217, 20);
            this.dtpUsedDate.TabIndex = 11;
            // 
            // cmbUsedFrom
            // 
            this.cmbUsedFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsedFrom.FormattingEnabled = true;
            this.cmbUsedFrom.Location = new System.Drawing.Point(108, 106);
            this.cmbUsedFrom.Name = "cmbUsedFrom";
            this.cmbUsedFrom.Size = new System.Drawing.Size(140, 21);
            this.cmbUsedFrom.TabIndex = 12;
            this.cmbUsedFrom.SelectedIndexChanged += new System.EventHandler(this.cmbUseFrom_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(108, 131);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(299, 82);
            this.txtDescription.TabIndex = 14;
            // 
            // cmdAddUsageLine
            // 
            this.cmdAddUsageLine.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAddUsageLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddUsageLine.Location = new System.Drawing.Point(394, 260);
            this.cmdAddUsageLine.Name = "cmdAddUsageLine";
            this.cmdAddUsageLine.Size = new System.Drawing.Size(55, 23);
            this.cmdAddUsageLine.TabIndex = 15;
            this.cmdAddUsageLine.Text = "Add";
            this.cmdAddUsageLine.UseVisualStyleBackColor = false;
            this.cmdAddUsageLine.Click += new System.EventHandler(this.cmdAddUseLine_Click);
            // 
            // txtUsageLineDescription
            // 
            this.txtUsageLineDescription.Location = new System.Drawing.Point(115, 288);
            this.txtUsageLineDescription.Multiline = true;
            this.txtUsageLineDescription.Name = "txtUsageLineDescription";
            this.txtUsageLineDescription.Size = new System.Drawing.Size(276, 70);
            this.txtUsageLineDescription.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(21, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(432, 145);
            this.label10.TabIndex = 19;
            this.label10.Text = "Usage Line";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtgUsageLineGridView
            // 
            this.dtgUsageLineGridView.AllowUserToAddRows = false;
            this.dtgUsageLineGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgUsageLineGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgUsageLineGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgUsageLineGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgUsageLineGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgUsageLineGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUsageLineGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgUsageLineGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUsageLineGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgUsageLineGridView.Location = new System.Drawing.Point(4, 367);
            this.dtgUsageLineGridView.MultiSelect = false;
            this.dtgUsageLineGridView.Name = "dtgUsageLineGridView";
            this.dtgUsageLineGridView.ReadOnly = true;
            this.dtgUsageLineGridView.RowHeadersVisible = false;
            this.dtgUsageLineGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUsageLineGridView.Size = new System.Drawing.Size(456, 150);
            this.dtgUsageLineGridView.TabIndex = 20;
            this.dtgUsageLineGridView.Sorted += new System.EventHandler(this.dtgUsageLineGridView_Sorted);
            this.dtgUsageLineGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUseLineGridView_CellClick);
            // 
            // dtgUsageGridView
            // 
            this.dtgUsageGridView.AllowUserToAddRows = false;
            this.dtgUsageGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgUsageGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgUsageGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgUsageGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgUsageGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgUsageGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUsageGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgUsageGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUsageGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgUsageGridView.Location = new System.Drawing.Point(2, 28);
            this.dtgUsageGridView.MultiSelect = false;
            this.dtgUsageGridView.Name = "dtgUsageGridView";
            this.dtgUsageGridView.ReadOnly = true;
            this.dtgUsageGridView.RowHeadersWidth = 21;
            this.dtgUsageGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUsageGridView.Size = new System.Drawing.Size(10, 333);
            this.dtgUsageGridView.TabIndex = 21;
            this.dtgUsageGridView.Visible = false;
            this.dtgUsageGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUsageGridView_CellClick);
            // 
            // cmbDetailUsageOtherUOM
            // 
            this.cmbDetailUsageOtherUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailUsageOtherUOM.FormattingEnabled = true;
            this.cmbDetailUsageOtherUOM.Location = new System.Drawing.Point(261, 261);
            this.cmbDetailUsageOtherUOM.Name = "cmbDetailUsageOtherUOM";
            this.cmbDetailUsageOtherUOM.Size = new System.Drawing.Size(82, 21);
            this.cmbDetailUsageOtherUOM.TabIndex = 22;
            this.cmbDetailUsageOtherUOM.SelectedIndexChanged += new System.EventHandler(this.cmbDetailUsageOtherUOM_SelectedIndexChanged);
            // 
            // ntbUsedQty
            // 
            this.ntbUsedQty.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbUsedQty.AllowNegative = false;
            this.ntbUsedQty.Amount = "0";
            this.ntbUsedQty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ntbUsedQty.Location = new System.Drawing.Point(114, 260);
            this.ntbUsedQty.Name = "ntbUsedQty";
            this.ntbUsedQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbUsedQty.ShowThousandSeparetor = true;
            this.ntbUsedQty.Size = new System.Drawing.Size(133, 23);
            this.ntbUsedQty.StandardPrecision = 2;
            this.ntbUsedQty.TabIndex = 24;
            this.ntbUsedQty.Leave += new System.EventHandler(this.ntbUsageQty_Leave);
            this.ntbUsedQty.Enter += new System.EventHandler(this.ntbUsageQty_Enter);
            // 
            // ddgProduct
            // 
            this.ddgProduct.AutoFilter = true;
            this.ddgProduct.AutoSize = true;
            this.ddgProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ddgProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgProduct.ClearButtonEnabled = true;
            this.ddgProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgProduct.FindButtonEnabled = true;
            this.ddgProduct.HiddenColoumns = new int[0];
            this.ddgProduct.Image = null;
            this.ddgProduct.Location = new System.Drawing.Point(111, 229);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(280, 31);
            this.ddgProduct.TabIndex = 23;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            this.ddgProduct.selectedItemChanged += new System.EventHandler(this.ddgProduct_selectedItemChanged);
            // 
            // cmdDetailTrxProductImage
            // 
            this.cmdDetailTrxProductImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetailTrxProductImage.Location = new System.Drawing.Point(393, 232);
            this.cmdDetailTrxProductImage.Name = "cmdDetailTrxProductImage";
            this.cmdDetailTrxProductImage.Size = new System.Drawing.Size(30, 23);
            this.cmdDetailTrxProductImage.TabIndex = 25;
            this.cmdDetailTrxProductImage.Text = "...";
            this.cmdDetailTrxProductImage.UseVisualStyleBackColor = true;
            this.cmdDetailTrxProductImage.Click += new System.EventHandler(this.cmdDetailTrxProductImage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(462, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(108, 34);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(197, 21);
            this.cmbOrganisation.TabIndex = 40;
            this.cmbOrganisation.SelectedIndexChanged += new System.EventHandler(this.cmbOrganisation_SelectedIndexChanged);
            this.cmbOrganisation.DropDown += new System.EventHandler(this.cmbOrganisation_DropDown);
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganisation.Location = new System.Drawing.Point(14, 37);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(89, 15);
            this.lblOrganisation.TabIndex = 39;
            this.lblOrganisation.Text = "Organisation";
            // 
            // frmInternalUse
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(462, 542);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdDetailTrxProductImage);
            this.Controls.Add(this.cmbDetailUsageOtherUOM);
            this.Controls.Add(this.ntbUsedQty);
            this.Controls.Add(this.ddgProduct);
            this.Controls.Add(this.dtgUsageGridView);
            this.Controls.Add(this.dtgUsageLineGridView);
            this.Controls.Add(this.txtUsageLineDescription);
            this.Controls.Add(this.cmdAddUsageLine);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbUsedFrom);
            this.Controls.Add(this.dtpUsedDate);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblUsageLineDescription);
            this.Controls.Add(this.lblUsedQuantity);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUsedFrom);
            this.Controls.Add(this.lblUsedDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmInternalUse";
            this.Text = "frmInternalUse";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsageLineGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsageGridView)).EndInit();
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
        private System.Windows.Forms.ToolStripButton tlsToogleView;
        private System.Windows.Forms.ToolStripButton tlsReverse;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblUsedDate;
        private System.Windows.Forms.Label lblUsedFrom;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblUsedQuantity;
        private System.Windows.Forms.Label lblUsageLineDescription;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.DateTimePicker dtpUsedDate;
        private System.Windows.Forms.ComboBox cmbUsedFrom;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdAddUsageLine;
        private System.Windows.Forms.TextBox txtUsageLineDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgUsageLineGridView;
        private System.Windows.Forms.DataGridView dtgUsageGridView;
        private System.Windows.Forms.ComboBox cmbDetailUsageOtherUOM;
        private DropDownDataGrid ddgProduct;
        private ctlNumberTextBox ntbUsedQty;
        private System.Windows.Forms.Button cmdDetailTrxProductImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.ToolStripButton tlsPrint;


    }
}