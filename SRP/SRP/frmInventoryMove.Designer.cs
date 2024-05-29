namespace SRP
{
    partial class frmInventoryMove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryMove));
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
            this.lblMovementDate = new System.Windows.Forms.Label();
            this.lblMoveFrom = new System.Windows.Forms.Label();
            this.lblMoveTo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblMovementQuantity = new System.Windows.Forms.Label();
            this.lblMoveLineDescription = new System.Windows.Forms.Label();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.dtpMoveDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMoveFrom = new System.Windows.Forms.ComboBox();
            this.cmbMoveTo = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdAddMoveLine = new System.Windows.Forms.Button();
            this.txtMoveLineDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgMoveLineGridView = new System.Windows.Forms.DataGridView();
            this.dtgMovementGridView = new System.Windows.Forms.DataGridView();
            this.cmbDetailMovementOtherUOM = new System.Windows.Forms.ComboBox();
            this.ntbMovementQty = new SRP.ctlNumberTextBox();
            this.ddgProduct = new SRP.DropDownDataGrid();
            this.cmdDetailTrxProductImage = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMoveLineGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovementGridView)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(475, 25);
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
            this.lblDocumentNo.Location = new System.Drawing.Point(21, 60);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(88, 13);
            this.lblDocumentNo.TabIndex = 1;
            this.lblDocumentNo.Text = "Document No.";
            // 
            // lblMovementDate
            // 
            this.lblMovementDate.AutoSize = true;
            this.lblMovementDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovementDate.Location = new System.Drawing.Point(13, 83);
            this.lblMovementDate.Name = "lblMovementDate";
            this.lblMovementDate.Size = new System.Drawing.Size(96, 13);
            this.lblMovementDate.TabIndex = 2;
            this.lblMovementDate.Text = "Movement Date";
            // 
            // lblMoveFrom
            // 
            this.lblMoveFrom.AutoSize = true;
            this.lblMoveFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveFrom.Location = new System.Drawing.Point(40, 107);
            this.lblMoveFrom.Name = "lblMoveFrom";
            this.lblMoveFrom.Size = new System.Drawing.Size(69, 13);
            this.lblMoveFrom.TabIndex = 3;
            this.lblMoveFrom.Text = "Move From";
            // 
            // lblMoveTo
            // 
            this.lblMoveTo.AutoSize = true;
            this.lblMoveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveTo.Location = new System.Drawing.Point(272, 107);
            this.lblMoveTo.Name = "lblMoveTo";
            this.lblMoveTo.Size = new System.Drawing.Size(57, 13);
            this.lblMoveTo.TabIndex = 4;
            this.lblMoveTo.Text = "Move To";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(30, 132);
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
            this.lblProduct.Location = new System.Drawing.Point(63, 234);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(51, 13);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product";
            // 
            // lblMovementQuantity
            // 
            this.lblMovementQuantity.AutoSize = true;
            this.lblMovementQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMovementQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovementQuantity.Location = new System.Drawing.Point(46, 262);
            this.lblMovementQuantity.Name = "lblMovementQuantity";
            this.lblMovementQuantity.Size = new System.Drawing.Size(68, 13);
            this.lblMovementQuantity.TabIndex = 7;
            this.lblMovementQuantity.Text = "Qty Moved";
            // 
            // lblMoveLineDescription
            // 
            this.lblMoveLineDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMoveLineDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveLineDescription.Location = new System.Drawing.Point(34, 285);
            this.lblMoveLineDescription.Name = "lblMoveLineDescription";
            this.lblMoveLineDescription.Size = new System.Drawing.Size(81, 35);
            this.lblMoveLineDescription.TabIndex = 9;
            this.lblMoveLineDescription.Text = "Description/Comment";
            this.lblMoveLineDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(114, 56);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(166, 20);
            this.txtDocumentNo.TabIndex = 10;
            // 
            // dtpMoveDate
            // 
            this.dtpMoveDate.Location = new System.Drawing.Point(114, 79);
            this.dtpMoveDate.Name = "dtpMoveDate";
            this.dtpMoveDate.Size = new System.Drawing.Size(217, 20);
            this.dtpMoveDate.TabIndex = 11;
            // 
            // cmbMoveFrom
            // 
            this.cmbMoveFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveFrom.FormattingEnabled = true;
            this.cmbMoveFrom.Location = new System.Drawing.Point(114, 103);
            this.cmbMoveFrom.Name = "cmbMoveFrom";
            this.cmbMoveFrom.Size = new System.Drawing.Size(140, 21);
            this.cmbMoveFrom.TabIndex = 12;
            this.cmbMoveFrom.SelectedIndexChanged += new System.EventHandler(this.cmbMoveFrom_SelectedIndexChanged);
            // 
            // cmbMoveTo
            // 
            this.cmbMoveTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveTo.FormattingEnabled = true;
            this.cmbMoveTo.Location = new System.Drawing.Point(335, 103);
            this.cmbMoveTo.Name = "cmbMoveTo";
            this.cmbMoveTo.Size = new System.Drawing.Size(140, 21);
            this.cmbMoveTo.TabIndex = 13;
            this.cmbMoveTo.SelectedIndexChanged += new System.EventHandler(this.cmbMoveTo_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(114, 128);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(299, 82);
            this.txtDescription.TabIndex = 14;
            // 
            // cmdAddMoveLine
            // 
            this.cmdAddMoveLine.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAddMoveLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddMoveLine.Location = new System.Drawing.Point(400, 256);
            this.cmdAddMoveLine.Name = "cmdAddMoveLine";
            this.cmdAddMoveLine.Size = new System.Drawing.Size(55, 23);
            this.cmdAddMoveLine.TabIndex = 15;
            this.cmdAddMoveLine.Text = "Add";
            this.cmdAddMoveLine.UseVisualStyleBackColor = false;
            this.cmdAddMoveLine.Click += new System.EventHandler(this.cmdAddMoveLine_Click);
            // 
            // txtMoveLineDescription
            // 
            this.txtMoveLineDescription.Location = new System.Drawing.Point(121, 285);
            this.txtMoveLineDescription.Multiline = true;
            this.txtMoveLineDescription.Name = "txtMoveLineDescription";
            this.txtMoveLineDescription.Size = new System.Drawing.Size(276, 70);
            this.txtMoveLineDescription.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(27, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(432, 145);
            this.label10.TabIndex = 19;
            this.label10.Text = "Movement Line";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtgMoveLineGridView
            // 
            this.dtgMoveLineGridView.AllowUserToAddRows = false;
            this.dtgMoveLineGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgMoveLineGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMoveLineGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgMoveLineGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgMoveLineGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgMoveLineGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMoveLineGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMoveLineGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMoveLineGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgMoveLineGridView.Location = new System.Drawing.Point(3, 364);
            this.dtgMoveLineGridView.MultiSelect = false;
            this.dtgMoveLineGridView.Name = "dtgMoveLineGridView";
            this.dtgMoveLineGridView.ReadOnly = true;
            this.dtgMoveLineGridView.RowHeadersVisible = false;
            this.dtgMoveLineGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMoveLineGridView.Size = new System.Drawing.Size(470, 112);
            this.dtgMoveLineGridView.TabIndex = 20;
            this.dtgMoveLineGridView.Sorted += new System.EventHandler(this.dtgMoveLineGridView_Sorted);
            this.dtgMoveLineGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMoveLineGridView_CellClick);
            // 
            // dtgMovementGridView
            // 
            this.dtgMovementGridView.AllowUserToAddRows = false;
            this.dtgMovementGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgMovementGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgMovementGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgMovementGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgMovementGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgMovementGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMovementGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgMovementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMovementGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgMovementGridView.Location = new System.Drawing.Point(5, 26);
            this.dtgMovementGridView.MultiSelect = false;
            this.dtgMovementGridView.Name = "dtgMovementGridView";
            this.dtgMovementGridView.ReadOnly = true;
            this.dtgMovementGridView.RowHeadersWidth = 21;
            this.dtgMovementGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMovementGridView.Size = new System.Drawing.Size(10, 332);
            this.dtgMovementGridView.TabIndex = 21;
            this.dtgMovementGridView.Visible = false;
            this.dtgMovementGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMovementGridView_CellClick);
            // 
            // cmbDetailMovementOtherUOM
            // 
            this.cmbDetailMovementOtherUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailMovementOtherUOM.FormattingEnabled = true;
            this.cmbDetailMovementOtherUOM.Location = new System.Drawing.Point(267, 259);
            this.cmbDetailMovementOtherUOM.Name = "cmbDetailMovementOtherUOM";
            this.cmbDetailMovementOtherUOM.Size = new System.Drawing.Size(82, 21);
            this.cmbDetailMovementOtherUOM.TabIndex = 22;
            this.cmbDetailMovementOtherUOM.SelectedIndexChanged += new System.EventHandler(this.cmbDetailMovementOtherUOM_SelectedIndexChanged);
            // 
            // ntbMovementQty
            // 
            this.ntbMovementQty.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMovementQty.AllowNegative = false;
            this.ntbMovementQty.Amount = "0";
            this.ntbMovementQty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ntbMovementQty.Location = new System.Drawing.Point(120, 258);
            this.ntbMovementQty.Name = "ntbMovementQty";
            this.ntbMovementQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMovementQty.ShowThousandSeparetor = true;
            this.ntbMovementQty.Size = new System.Drawing.Size(133, 23);
            this.ntbMovementQty.StandardPrecision = 2;
            this.ntbMovementQty.TabIndex = 24;
            this.ntbMovementQty.Leave += new System.EventHandler(this.ntbMovementQty_Leave);
            this.ntbMovementQty.Enter += new System.EventHandler(this.ntbMovementQty_Enter);
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
            this.ddgProduct.Location = new System.Drawing.Point(117, 226);
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
            this.cmdDetailTrxProductImage.Location = new System.Drawing.Point(398, 230);
            this.cmdDetailTrxProductImage.Name = "cmdDetailTrxProductImage";
            this.cmdDetailTrxProductImage.Size = new System.Drawing.Size(29, 21);
            this.cmdDetailTrxProductImage.TabIndex = 25;
            this.cmdDetailTrxProductImage.Text = "...";
            this.cmdDetailTrxProductImage.UseVisualStyleBackColor = true;
            this.cmdDetailTrxProductImage.Click += new System.EventHandler(this.cmdDetailTrxProductImage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(475, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(114, 31);
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
            this.lblOrganisation.Location = new System.Drawing.Point(20, 33);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(89, 15);
            this.lblOrganisation.TabIndex = 39;
            this.lblOrganisation.Text = "Organisation";
            // 
            // frmInventoryMove
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(475, 501);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdDetailTrxProductImage);
            this.Controls.Add(this.cmbDetailMovementOtherUOM);
            this.Controls.Add(this.ntbMovementQty);
            this.Controls.Add(this.ddgProduct);
            this.Controls.Add(this.dtgMovementGridView);
            this.Controls.Add(this.dtgMoveLineGridView);
            this.Controls.Add(this.txtMoveLineDescription);
            this.Controls.Add(this.cmdAddMoveLine);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbMoveTo);
            this.Controls.Add(this.cmbMoveFrom);
            this.Controls.Add(this.dtpMoveDate);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblMoveLineDescription);
            this.Controls.Add(this.lblMovementQuantity);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblMoveTo);
            this.Controls.Add(this.lblMoveFrom);
            this.Controls.Add(this.lblMovementDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmInventoryMove";
            this.Text = "frmInventoryMove";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMoveLineGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovementGridView)).EndInit();
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
        private System.Windows.Forms.Label lblMovementDate;
        private System.Windows.Forms.Label lblMoveFrom;
        private System.Windows.Forms.Label lblMoveTo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblMovementQuantity;
        private System.Windows.Forms.Label lblMoveLineDescription;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.DateTimePicker dtpMoveDate;
        private System.Windows.Forms.ComboBox cmbMoveFrom;
        private System.Windows.Forms.ComboBox cmbMoveTo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdAddMoveLine;
        private System.Windows.Forms.TextBox txtMoveLineDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgMoveLineGridView;
        private System.Windows.Forms.DataGridView dtgMovementGridView;
        private System.Windows.Forms.ComboBox cmbDetailMovementOtherUOM;
        private DropDownDataGrid ddgProduct;
        private ctlNumberTextBox ntbMovementQty;
        private System.Windows.Forms.Button cmdDetailTrxProductImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.ToolStripButton tlsPrint;


    }
}