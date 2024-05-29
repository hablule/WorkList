namespace SRP
{
    partial class frmCitiesAndLocalities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCitiesAndLocalities));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tbcCityAndLocality = new System.Windows.Forms.TabControl();
            this.tbpCountry = new System.Windows.Forms.TabPage();
            this.dtgCountryGridView = new System.Windows.Forms.DataGridView();
            this.txtCountryISOCode = new System.Windows.Forms.TextBox();
            this.txtCountryName = new System.Windows.Forms.TextBox();
            this.txtCountryDescription = new System.Windows.Forms.TextBox();
            this.lblCounrtyDescription = new System.Windows.Forms.Label();
            this.lblCounrtyISOCode = new System.Windows.Forms.Label();
            this.ckCounrtyIsActive = new System.Windows.Forms.CheckBox();
            this.lblCountryName = new System.Windows.Forms.Label();
            this.tbpCity = new System.Windows.Forms.TabPage();
            this.dtgCityGrid = new System.Windows.Forms.DataGridView();
            this.txtCityCountry = new System.Windows.Forms.TextBox();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.txtCityDescription = new System.Windows.Forms.TextBox();
            this.lblCityDescription = new System.Windows.Forms.Label();
            this.ckCityIsActive = new System.Windows.Forms.CheckBox();
            this.lblCityCountry = new System.Windows.Forms.Label();
            this.lblCityName = new System.Windows.Forms.Label();
            this.tbpLocality = new System.Windows.Forms.TabPage();
            this.cmdLacalityParentLocality = new System.Windows.Forms.ComboBox();
            this.ckLocalityIsActive = new System.Windows.Forms.CheckBox();
            this.ckLocalityIsSummary = new System.Windows.Forms.CheckBox();
            this.txtLocalityDescritpion = new System.Windows.Forms.TextBox();
            this.txtLocalityName = new System.Windows.Forms.TextBox();
            this.txtLocalityCity = new System.Windows.Forms.TextBox();
            this.lblLocalityParentLocality = new System.Windows.Forms.Label();
            this.lblLocalityDescription = new System.Windows.Forms.Label();
            this.lblLocalityName = new System.Windows.Forms.Label();
            this.lblLocalityCity = new System.Windows.Forms.Label();
            this.dtgLocalityGridView = new System.Windows.Forms.DataGridView();
            this.tbpSubLocality = new System.Windows.Forms.TabPage();
            this.dtgSubLocalityGridView = new System.Windows.Forms.DataGridView();
            this.cmdSubLocalityParentSubLocality = new System.Windows.Forms.ComboBox();
            this.lblSubLocalityParentSubLocality = new System.Windows.Forms.Label();
            this.txtSubLocalityDescritption = new System.Windows.Forms.TextBox();
            this.txtSubLocalityName = new System.Windows.Forms.TextBox();
            this.txtSubLocalityLocality = new System.Windows.Forms.TextBox();
            this.ckSubLocalityIsActive = new System.Windows.Forms.CheckBox();
            this.ckSubLocalityIsSummary = new System.Windows.Forms.CheckBox();
            this.lblSubLocalityDescritption = new System.Windows.Forms.Label();
            this.lblSubLocalityName = new System.Windows.Forms.Label();
            this.lblSubLocalityLocaltiy = new System.Windows.Forms.Label();
            this.tlsCommandToolBar.SuspendLayout();
            this.tbcCityAndLocality.SuspendLayout();
            this.tbpCountry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCountryGridView)).BeginInit();
            this.tbpCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCityGrid)).BeginInit();
            this.tbpLocality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLocalityGridView)).BeginInit();
            this.tbpSubLocality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubLocalityGridView)).BeginInit();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(474, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.Image = ((System.Drawing.Image)(resources.GetObject("tlsNew.Image")));
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(35, 22);
            this.tlsNew.Text = "New";
            this.tlsNew.Click += new System.EventHandler(this.tlsNew_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsSave.Image")));
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(35, 22);
            this.tlsSave.Text = "Save";
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsDelete
            // 
            this.tlsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlsDelete.Image")));
            this.tlsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(44, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Visible = false;
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlsSearch.Image")));
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
            this.tlsFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsFirstRecord.Image")));
            this.tlsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsFirstRecord.Name = "tlsFirstRecord";
            this.tlsFirstRecord.Size = new System.Drawing.Size(33, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsPreviousRecord.Image")));
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(56, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsNextRecord.Image")));
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(35, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsLastRecord.Image")));
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.Visible = false;
            // 
            // tbcCityAndLocality
            // 
            this.tbcCityAndLocality.Controls.Add(this.tbpCountry);
            this.tbcCityAndLocality.Controls.Add(this.tbpCity);
            this.tbcCityAndLocality.Controls.Add(this.tbpLocality);
            this.tbcCityAndLocality.Controls.Add(this.tbpSubLocality);
            this.tbcCityAndLocality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcCityAndLocality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcCityAndLocality.HotTrack = true;
            this.tbcCityAndLocality.Location = new System.Drawing.Point(0, 25);
            this.tbcCityAndLocality.Multiline = true;
            this.tbcCityAndLocality.Name = "tbcCityAndLocality";
            this.tbcCityAndLocality.SelectedIndex = 0;
            this.tbcCityAndLocality.Size = new System.Drawing.Size(474, 381);
            this.tbcCityAndLocality.TabIndex = 1;
            this.tbcCityAndLocality.SelectedIndexChanged += new System.EventHandler(this.tbcCityAndLocality_SelectedIndexChanged);
            // 
            // tbpCountry
            // 
            this.tbpCountry.Controls.Add(this.dtgCountryGridView);
            this.tbpCountry.Controls.Add(this.txtCountryISOCode);
            this.tbpCountry.Controls.Add(this.txtCountryName);
            this.tbpCountry.Controls.Add(this.txtCountryDescription);
            this.tbpCountry.Controls.Add(this.lblCounrtyDescription);
            this.tbpCountry.Controls.Add(this.lblCounrtyISOCode);
            this.tbpCountry.Controls.Add(this.ckCounrtyIsActive);
            this.tbpCountry.Controls.Add(this.lblCountryName);
            this.tbpCountry.Location = new System.Drawing.Point(4, 24);
            this.tbpCountry.Name = "tbpCountry";
            this.tbpCountry.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCountry.Size = new System.Drawing.Size(466, 353);
            this.tbpCountry.TabIndex = 3;
            this.tbpCountry.Text = "Country";
            this.tbpCountry.UseVisualStyleBackColor = true;
            // 
            // dtgCountryGridView
            // 
            this.dtgCountryGridView.AllowUserToAddRows = false;
            this.dtgCountryGridView.AllowUserToDeleteRows = false;
            this.dtgCountryGridView.AllowUserToOrderColumns = true;
            this.dtgCountryGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgCountryGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCountryGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCountryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCountryGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgCountryGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCountryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCountryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCountryGridView.Location = new System.Drawing.Point(4, 189);
            this.dtgCountryGridView.MultiSelect = false;
            this.dtgCountryGridView.Name = "dtgCountryGridView";
            this.dtgCountryGridView.ReadOnly = true;
            this.dtgCountryGridView.RowHeadersWidth = 20;
            this.dtgCountryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCountryGridView.Size = new System.Drawing.Size(459, 158);
            this.dtgCountryGridView.TabIndex = 13;
            this.dtgCountryGridView.SelectionChanged += new System.EventHandler(this.dtgCountryGridView_SelectionChanged);
            // 
            // txtCountryISOCode
            // 
            this.txtCountryISOCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountryISOCode.Location = new System.Drawing.Point(114, 41);
            this.txtCountryISOCode.Name = "txtCountryISOCode";
            this.txtCountryISOCode.Size = new System.Drawing.Size(178, 21);
            this.txtCountryISOCode.TabIndex = 12;
            // 
            // txtCountryName
            // 
            this.txtCountryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountryName.Location = new System.Drawing.Point(114, 14);
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(178, 21);
            this.txtCountryName.TabIndex = 12;
            // 
            // txtCountryDescription
            // 
            this.txtCountryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountryDescription.Location = new System.Drawing.Point(114, 71);
            this.txtCountryDescription.Multiline = true;
            this.txtCountryDescription.Name = "txtCountryDescription";
            this.txtCountryDescription.Size = new System.Drawing.Size(265, 77);
            this.txtCountryDescription.TabIndex = 11;
            // 
            // lblCounrtyDescription
            // 
            this.lblCounrtyDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounrtyDescription.Location = new System.Drawing.Point(17, 71);
            this.lblCounrtyDescription.Name = "lblCounrtyDescription";
            this.lblCounrtyDescription.Size = new System.Drawing.Size(91, 34);
            this.lblCounrtyDescription.TabIndex = 10;
            this.lblCounrtyDescription.Text = "Description /Comment";
            this.lblCounrtyDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCounrtyISOCode
            // 
            this.lblCounrtyISOCode.AutoSize = true;
            this.lblCounrtyISOCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounrtyISOCode.Location = new System.Drawing.Point(63, 44);
            this.lblCounrtyISOCode.Name = "lblCounrtyISOCode";
            this.lblCounrtyISOCode.Size = new System.Drawing.Size(45, 15);
            this.lblCounrtyISOCode.TabIndex = 8;
            this.lblCounrtyISOCode.Text = "Name";
            this.lblCounrtyISOCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckCounrtyIsActive
            // 
            this.ckCounrtyIsActive.AutoSize = true;
            this.ckCounrtyIsActive.Checked = true;
            this.ckCounrtyIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckCounrtyIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCounrtyIsActive.Location = new System.Drawing.Point(114, 161);
            this.ckCounrtyIsActive.Name = "ckCounrtyIsActive";
            this.ckCounrtyIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckCounrtyIsActive.TabIndex = 9;
            this.ckCounrtyIsActive.Text = "Is Active";
            this.ckCounrtyIsActive.UseVisualStyleBackColor = true;
            // 
            // lblCountryName
            // 
            this.lblCountryName.AutoSize = true;
            this.lblCountryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryName.Location = new System.Drawing.Point(63, 17);
            this.lblCountryName.Name = "lblCountryName";
            this.lblCountryName.Size = new System.Drawing.Size(45, 15);
            this.lblCountryName.TabIndex = 8;
            this.lblCountryName.Text = "Name";
            this.lblCountryName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbpCity
            // 
            this.tbpCity.AutoScroll = true;
            this.tbpCity.Controls.Add(this.dtgCityGrid);
            this.tbpCity.Controls.Add(this.txtCityCountry);
            this.tbpCity.Controls.Add(this.txtCityName);
            this.tbpCity.Controls.Add(this.txtCityDescription);
            this.tbpCity.Controls.Add(this.lblCityDescription);
            this.tbpCity.Controls.Add(this.ckCityIsActive);
            this.tbpCity.Controls.Add(this.lblCityCountry);
            this.tbpCity.Controls.Add(this.lblCityName);
            this.tbpCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpCity.Location = new System.Drawing.Point(4, 24);
            this.tbpCity.Name = "tbpCity";
            this.tbpCity.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCity.Size = new System.Drawing.Size(466, 353);
            this.tbpCity.TabIndex = 0;
            this.tbpCity.Text = "City";
            this.tbpCity.UseVisualStyleBackColor = true;
            // 
            // dtgCityGrid
            // 
            this.dtgCityGrid.AllowUserToAddRows = false;
            this.dtgCityGrid.AllowUserToDeleteRows = false;
            this.dtgCityGrid.AllowUserToOrderColumns = true;
            this.dtgCityGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgCityGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCityGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCityGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCityGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgCityGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCityGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCityGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCityGrid.Location = new System.Drawing.Point(4, 200);
            this.dtgCityGrid.MultiSelect = false;
            this.dtgCityGrid.Name = "dtgCityGrid";
            this.dtgCityGrid.ReadOnly = true;
            this.dtgCityGrid.RowHeadersWidth = 20;
            this.dtgCityGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCityGrid.Size = new System.Drawing.Size(459, 150);
            this.dtgCityGrid.TabIndex = 7;
            this.dtgCityGrid.SelectionChanged += new System.EventHandler(this.dtgCityGrid_SelectionChanged);
            // 
            // txtCityCountry
            // 
            this.txtCityCountry.Enabled = false;
            this.txtCityCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCityCountry.Location = new System.Drawing.Point(114, 20);
            this.txtCityCountry.Name = "txtCityCountry";
            this.txtCityCountry.Size = new System.Drawing.Size(178, 21);
            this.txtCityCountry.TabIndex = 5;
            this.txtCityCountry.TextChanged += new System.EventHandler(this.txtCityCountry_TextChanged);
            // 
            // txtCityName
            // 
            this.txtCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCityName.Location = new System.Drawing.Point(114, 50);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(178, 21);
            this.txtCityName.TabIndex = 5;
            // 
            // txtCityDescription
            // 
            this.txtCityDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCityDescription.Location = new System.Drawing.Point(114, 86);
            this.txtCityDescription.Multiline = true;
            this.txtCityDescription.Name = "txtCityDescription";
            this.txtCityDescription.Size = new System.Drawing.Size(265, 77);
            this.txtCityDescription.TabIndex = 4;
            // 
            // lblCityDescription
            // 
            this.lblCityDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityDescription.Location = new System.Drawing.Point(17, 86);
            this.lblCityDescription.Name = "lblCityDescription";
            this.lblCityDescription.Size = new System.Drawing.Size(91, 34);
            this.lblCityDescription.TabIndex = 3;
            this.lblCityDescription.Text = "Description /Comment";
            this.lblCityDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckCityIsActive
            // 
            this.ckCityIsActive.AutoSize = true;
            this.ckCityIsActive.Checked = true;
            this.ckCityIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckCityIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCityIsActive.Location = new System.Drawing.Point(114, 172);
            this.ckCityIsActive.Name = "ckCityIsActive";
            this.ckCityIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckCityIsActive.TabIndex = 2;
            this.ckCityIsActive.Text = "Is Active";
            this.ckCityIsActive.UseVisualStyleBackColor = true;
            // 
            // lblCityCountry
            // 
            this.lblCityCountry.AutoSize = true;
            this.lblCityCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityCountry.Location = new System.Drawing.Point(53, 23);
            this.lblCityCountry.Name = "lblCityCountry";
            this.lblCityCountry.Size = new System.Drawing.Size(55, 15);
            this.lblCityCountry.TabIndex = 1;
            this.lblCityCountry.Text = "Country";
            this.lblCityCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCityName
            // 
            this.lblCityName.AutoSize = true;
            this.lblCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityName.Location = new System.Drawing.Point(63, 53);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(45, 15);
            this.lblCityName.TabIndex = 0;
            this.lblCityName.Text = "Name";
            this.lblCityName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbpLocality
            // 
            this.tbpLocality.AutoScroll = true;
            this.tbpLocality.Controls.Add(this.cmdLacalityParentLocality);
            this.tbpLocality.Controls.Add(this.ckLocalityIsActive);
            this.tbpLocality.Controls.Add(this.ckLocalityIsSummary);
            this.tbpLocality.Controls.Add(this.txtLocalityDescritpion);
            this.tbpLocality.Controls.Add(this.txtLocalityName);
            this.tbpLocality.Controls.Add(this.txtLocalityCity);
            this.tbpLocality.Controls.Add(this.lblLocalityParentLocality);
            this.tbpLocality.Controls.Add(this.lblLocalityDescription);
            this.tbpLocality.Controls.Add(this.lblLocalityName);
            this.tbpLocality.Controls.Add(this.lblLocalityCity);
            this.tbpLocality.Controls.Add(this.dtgLocalityGridView);
            this.tbpLocality.Location = new System.Drawing.Point(4, 24);
            this.tbpLocality.Name = "tbpLocality";
            this.tbpLocality.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLocality.Size = new System.Drawing.Size(466, 353);
            this.tbpLocality.TabIndex = 1;
            this.tbpLocality.Text = "Locaity";
            this.tbpLocality.UseVisualStyleBackColor = true;
            // 
            // cmdLacalityParentLocality
            // 
            this.cmdLacalityParentLocality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdLacalityParentLocality.FormattingEnabled = true;
            this.cmdLacalityParentLocality.Location = new System.Drawing.Point(277, 143);
            this.cmdLacalityParentLocality.Name = "cmdLacalityParentLocality";
            this.cmdLacalityParentLocality.Size = new System.Drawing.Size(181, 23);
            this.cmdLacalityParentLocality.TabIndex = 10;
            this.cmdLacalityParentLocality.DropDown += new System.EventHandler(this.cmdLacalityParentLocality_DropDown);
            // 
            // ckLocalityIsActive
            // 
            this.ckLocalityIsActive.AutoSize = true;
            this.ckLocalityIsActive.Checked = true;
            this.ckLocalityIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckLocalityIsActive.Location = new System.Drawing.Point(58, 168);
            this.ckLocalityIsActive.Name = "ckLocalityIsActive";
            this.ckLocalityIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckLocalityIsActive.TabIndex = 9;
            this.ckLocalityIsActive.Text = "Is Active";
            this.ckLocalityIsActive.UseVisualStyleBackColor = true;
            // 
            // ckLocalityIsSummary
            // 
            this.ckLocalityIsSummary.AutoSize = true;
            this.ckLocalityIsSummary.Location = new System.Drawing.Point(58, 142);
            this.ckLocalityIsSummary.Name = "ckLocalityIsSummary";
            this.ckLocalityIsSummary.Size = new System.Drawing.Size(101, 19);
            this.ckLocalityIsSummary.TabIndex = 8;
            this.ckLocalityIsSummary.Text = "Is Summary";
            this.ckLocalityIsSummary.UseVisualStyleBackColor = true;
            this.ckLocalityIsSummary.CheckedChanged += new System.EventHandler(this.ckLocalityIsSummary_CheckedChanged);
            // 
            // txtLocalityDescritpion
            // 
            this.txtLocalityDescritpion.Location = new System.Drawing.Point(100, 72);
            this.txtLocalityDescritpion.Multiline = true;
            this.txtLocalityDescritpion.Name = "txtLocalityDescritpion";
            this.txtLocalityDescritpion.Size = new System.Drawing.Size(358, 64);
            this.txtLocalityDescritpion.TabIndex = 7;
            // 
            // txtLocalityName
            // 
            this.txtLocalityName.Location = new System.Drawing.Point(100, 44);
            this.txtLocalityName.Name = "txtLocalityName";
            this.txtLocalityName.Size = new System.Drawing.Size(209, 21);
            this.txtLocalityName.TabIndex = 6;
            // 
            // txtLocalityCity
            // 
            this.txtLocalityCity.Enabled = false;
            this.txtLocalityCity.Location = new System.Drawing.Point(100, 16);
            this.txtLocalityCity.Name = "txtLocalityCity";
            this.txtLocalityCity.Size = new System.Drawing.Size(194, 21);
            this.txtLocalityCity.TabIndex = 5;
            this.txtLocalityCity.TextChanged += new System.EventHandler(this.txtLocalityCity_TextChanged);
            // 
            // lblLocalityParentLocality
            // 
            this.lblLocalityParentLocality.AutoSize = true;
            this.lblLocalityParentLocality.Location = new System.Drawing.Point(169, 146);
            this.lblLocalityParentLocality.Name = "lblLocalityParentLocality";
            this.lblLocalityParentLocality.Size = new System.Drawing.Size(102, 15);
            this.lblLocalityParentLocality.TabIndex = 4;
            this.lblLocalityParentLocality.Text = "Parent Locality";
            // 
            // lblLocalityDescription
            // 
            this.lblLocalityDescription.Location = new System.Drawing.Point(8, 72);
            this.lblLocalityDescription.Name = "lblLocalityDescription";
            this.lblLocalityDescription.Size = new System.Drawing.Size(86, 38);
            this.lblLocalityDescription.TabIndex = 3;
            this.lblLocalityDescription.Text = "Description/Comment";
            this.lblLocalityDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalityName
            // 
            this.lblLocalityName.AutoSize = true;
            this.lblLocalityName.Location = new System.Drawing.Point(43, 46);
            this.lblLocalityName.Name = "lblLocalityName";
            this.lblLocalityName.Size = new System.Drawing.Size(45, 15);
            this.lblLocalityName.TabIndex = 2;
            this.lblLocalityName.Text = "Name";
            // 
            // lblLocalityCity
            // 
            this.lblLocalityCity.AutoSize = true;
            this.lblLocalityCity.Location = new System.Drawing.Point(55, 18);
            this.lblLocalityCity.Name = "lblLocalityCity";
            this.lblLocalityCity.Size = new System.Drawing.Size(30, 15);
            this.lblLocalityCity.TabIndex = 1;
            this.lblLocalityCity.Text = "City";
            // 
            // dtgLocalityGridView
            // 
            this.dtgLocalityGridView.AllowUserToAddRows = false;
            this.dtgLocalityGridView.AllowUserToDeleteRows = false;
            this.dtgLocalityGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgLocalityGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgLocalityGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgLocalityGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgLocalityGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgLocalityGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgLocalityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLocalityGridView.Location = new System.Drawing.Point(3, 200);
            this.dtgLocalityGridView.MultiSelect = false;
            this.dtgLocalityGridView.Name = "dtgLocalityGridView";
            this.dtgLocalityGridView.ReadOnly = true;
            this.dtgLocalityGridView.RowHeadersWidth = 20;
            this.dtgLocalityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLocalityGridView.Size = new System.Drawing.Size(460, 150);
            this.dtgLocalityGridView.TabIndex = 0;
            this.dtgLocalityGridView.SelectionChanged += new System.EventHandler(this.dtgLocalityGridView_SelectionChanged);
            // 
            // tbpSubLocality
            // 
            this.tbpSubLocality.AutoScroll = true;
            this.tbpSubLocality.Controls.Add(this.dtgSubLocalityGridView);
            this.tbpSubLocality.Controls.Add(this.cmdSubLocalityParentSubLocality);
            this.tbpSubLocality.Controls.Add(this.lblSubLocalityParentSubLocality);
            this.tbpSubLocality.Controls.Add(this.txtSubLocalityDescritption);
            this.tbpSubLocality.Controls.Add(this.txtSubLocalityName);
            this.tbpSubLocality.Controls.Add(this.txtSubLocalityLocality);
            this.tbpSubLocality.Controls.Add(this.ckSubLocalityIsActive);
            this.tbpSubLocality.Controls.Add(this.ckSubLocalityIsSummary);
            this.tbpSubLocality.Controls.Add(this.lblSubLocalityDescritption);
            this.tbpSubLocality.Controls.Add(this.lblSubLocalityName);
            this.tbpSubLocality.Controls.Add(this.lblSubLocalityLocaltiy);
            this.tbpSubLocality.Location = new System.Drawing.Point(4, 24);
            this.tbpSubLocality.Name = "tbpSubLocality";
            this.tbpSubLocality.Size = new System.Drawing.Size(466, 353);
            this.tbpSubLocality.TabIndex = 2;
            this.tbpSubLocality.Text = "Sub Locality";
            this.tbpSubLocality.UseVisualStyleBackColor = true;
            // 
            // dtgSubLocalityGridView
            // 
            this.dtgSubLocalityGridView.AllowUserToAddRows = false;
            this.dtgSubLocalityGridView.AllowUserToDeleteRows = false;
            this.dtgSubLocalityGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgSubLocalityGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgSubLocalityGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSubLocalityGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgSubLocalityGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSubLocalityGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgSubLocalityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSubLocalityGridView.Location = new System.Drawing.Point(3, 200);
            this.dtgSubLocalityGridView.MultiSelect = false;
            this.dtgSubLocalityGridView.Name = "dtgSubLocalityGridView";
            this.dtgSubLocalityGridView.ReadOnly = true;
            this.dtgSubLocalityGridView.RowHeadersWidth = 20;
            this.dtgSubLocalityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSubLocalityGridView.Size = new System.Drawing.Size(460, 150);
            this.dtgSubLocalityGridView.TabIndex = 10;
            this.dtgSubLocalityGridView.SelectionChanged += new System.EventHandler(this.dtgSubLocalityGridView_SelectionChanged);
            // 
            // cmdSubLocalityParentSubLocality
            // 
            this.cmdSubLocalityParentSubLocality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdSubLocalityParentSubLocality.FormattingEnabled = true;
            this.cmdSubLocalityParentSubLocality.Location = new System.Drawing.Point(261, 149);
            this.cmdSubLocalityParentSubLocality.Name = "cmdSubLocalityParentSubLocality";
            this.cmdSubLocalityParentSubLocality.Size = new System.Drawing.Size(185, 23);
            this.cmdSubLocalityParentSubLocality.TabIndex = 9;
            this.cmdSubLocalityParentSubLocality.DropDown += new System.EventHandler(this.cmdSubLocalityParentSubLocality_DropDown);
            // 
            // lblSubLocalityParentSubLocality
            // 
            this.lblSubLocalityParentSubLocality.AutoSize = true;
            this.lblSubLocalityParentSubLocality.Location = new System.Drawing.Point(139, 153);
            this.lblSubLocalityParentSubLocality.Name = "lblSubLocalityParentSubLocality";
            this.lblSubLocalityParentSubLocality.Size = new System.Drawing.Size(117, 15);
            this.lblSubLocalityParentSubLocality.TabIndex = 8;
            this.lblSubLocalityParentSubLocality.Text = "Parent Sub Local";
            // 
            // txtSubLocalityDescritption
            // 
            this.txtSubLocalityDescritption.Location = new System.Drawing.Point(93, 77);
            this.txtSubLocalityDescritption.Multiline = true;
            this.txtSubLocalityDescritption.Name = "txtSubLocalityDescritption";
            this.txtSubLocalityDescritption.Size = new System.Drawing.Size(354, 66);
            this.txtSubLocalityDescritption.TabIndex = 7;
            // 
            // txtSubLocalityName
            // 
            this.txtSubLocalityName.Location = new System.Drawing.Point(92, 49);
            this.txtSubLocalityName.Name = "txtSubLocalityName";
            this.txtSubLocalityName.Size = new System.Drawing.Size(217, 21);
            this.txtSubLocalityName.TabIndex = 6;
            // 
            // txtSubLocalityLocality
            // 
            this.txtSubLocalityLocality.Enabled = false;
            this.txtSubLocalityLocality.Location = new System.Drawing.Point(93, 22);
            this.txtSubLocalityLocality.Name = "txtSubLocalityLocality";
            this.txtSubLocalityLocality.Size = new System.Drawing.Size(181, 21);
            this.txtSubLocalityLocality.TabIndex = 5;
            this.txtSubLocalityLocality.TextChanged += new System.EventHandler(this.txtSubLocalityLocality_TextChanged);
            // 
            // ckSubLocalityIsActive
            // 
            this.ckSubLocalityIsActive.AutoSize = true;
            this.ckSubLocalityIsActive.Checked = true;
            this.ckSubLocalityIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSubLocalityIsActive.Location = new System.Drawing.Point(24, 175);
            this.ckSubLocalityIsActive.Name = "ckSubLocalityIsActive";
            this.ckSubLocalityIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckSubLocalityIsActive.TabIndex = 4;
            this.ckSubLocalityIsActive.Text = "Is Active";
            this.ckSubLocalityIsActive.UseVisualStyleBackColor = true;
            // 
            // ckSubLocalityIsSummary
            // 
            this.ckSubLocalityIsSummary.AutoSize = true;
            this.ckSubLocalityIsSummary.Location = new System.Drawing.Point(24, 149);
            this.ckSubLocalityIsSummary.Name = "ckSubLocalityIsSummary";
            this.ckSubLocalityIsSummary.Size = new System.Drawing.Size(101, 19);
            this.ckSubLocalityIsSummary.TabIndex = 3;
            this.ckSubLocalityIsSummary.Text = "Is Summary";
            this.ckSubLocalityIsSummary.UseVisualStyleBackColor = true;
            this.ckSubLocalityIsSummary.CheckedChanged += new System.EventHandler(this.ckSubLocalityIsSummary_CheckedChanged);
            // 
            // lblSubLocalityDescritption
            // 
            this.lblSubLocalityDescritption.Location = new System.Drawing.Point(6, 77);
            this.lblSubLocalityDescritption.Name = "lblSubLocalityDescritption";
            this.lblSubLocalityDescritption.Size = new System.Drawing.Size(87, 34);
            this.lblSubLocalityDescritption.TabIndex = 2;
            this.lblSubLocalityDescritption.Text = "Description /Comment";
            this.lblSubLocalityDescritption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubLocalityName
            // 
            this.lblSubLocalityName.AutoSize = true;
            this.lblSubLocalityName.Location = new System.Drawing.Point(30, 49);
            this.lblSubLocalityName.Name = "lblSubLocalityName";
            this.lblSubLocalityName.Size = new System.Drawing.Size(45, 15);
            this.lblSubLocalityName.TabIndex = 1;
            this.lblSubLocalityName.Text = "Name";
            // 
            // lblSubLocalityLocaltiy
            // 
            this.lblSubLocalityLocaltiy.AutoSize = true;
            this.lblSubLocalityLocaltiy.Location = new System.Drawing.Point(22, 24);
            this.lblSubLocalityLocaltiy.Name = "lblSubLocalityLocaltiy";
            this.lblSubLocalityLocaltiy.Size = new System.Drawing.Size(56, 15);
            this.lblSubLocalityLocaltiy.TabIndex = 0;
            this.lblSubLocalityLocaltiy.Text = "Locality";
            // 
            // frmCitiesAndLocalities
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(474, 406);
            this.Controls.Add(this.tbcCityAndLocality);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Name = "frmCitiesAndLocalities";
            this.Text = "City and Locality";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            this.tbcCityAndLocality.ResumeLayout(false);
            this.tbpCountry.ResumeLayout(false);
            this.tbpCountry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCountryGridView)).EndInit();
            this.tbpCity.ResumeLayout(false);
            this.tbpCity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCityGrid)).EndInit();
            this.tbpLocality.ResumeLayout(false);
            this.tbpLocality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLocalityGridView)).EndInit();
            this.tbpSubLocality.ResumeLayout(false);
            this.tbpSubLocality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubLocalityGridView)).EndInit();
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
        private System.Windows.Forms.TabControl tbcCityAndLocality;
        private System.Windows.Forms.TabPage tbpCity;
        private System.Windows.Forms.TabPage tbpLocality;
        private System.Windows.Forms.TabPage tbpSubLocality;
        private System.Windows.Forms.TextBox txtCityDescription;
        private System.Windows.Forms.Label lblCityDescription;
        private System.Windows.Forms.CheckBox ckCityIsActive;
        private System.Windows.Forms.Label lblCityCountry;
        private System.Windows.Forms.Label lblCityName;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.DataGridView dtgCityGrid;
        private System.Windows.Forms.ToolStripButton tlsLastRecord;
        private System.Windows.Forms.CheckBox ckLocalityIsActive;
        private System.Windows.Forms.CheckBox ckLocalityIsSummary;
        private System.Windows.Forms.TextBox txtLocalityDescritpion;
        private System.Windows.Forms.TextBox txtLocalityName;
        private System.Windows.Forms.Label lblLocalityParentLocality;
        private System.Windows.Forms.Label lblLocalityDescription;
        private System.Windows.Forms.Label lblLocalityName;
        private System.Windows.Forms.Label lblLocalityCity;
        private System.Windows.Forms.DataGridView dtgLocalityGridView;
        private System.Windows.Forms.ComboBox cmdLacalityParentLocality;
        private System.Windows.Forms.TextBox txtSubLocalityDescritption;
        private System.Windows.Forms.TextBox txtSubLocalityName;
        private System.Windows.Forms.TextBox txtSubLocalityLocality;
        private System.Windows.Forms.CheckBox ckSubLocalityIsActive;
        private System.Windows.Forms.CheckBox ckSubLocalityIsSummary;
        private System.Windows.Forms.Label lblSubLocalityDescritption;
        private System.Windows.Forms.Label lblSubLocalityName;
        private System.Windows.Forms.Label lblSubLocalityLocaltiy;
        private System.Windows.Forms.DataGridView dtgSubLocalityGridView;
        private System.Windows.Forms.ComboBox cmdSubLocalityParentSubLocality;
        private System.Windows.Forms.Label lblSubLocalityParentSubLocality;
        private System.Windows.Forms.TextBox txtLocalityCity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tbpCountry;
        private System.Windows.Forms.DataGridView dtgCountryGridView;
        private System.Windows.Forms.TextBox txtCountryISOCode;
        private System.Windows.Forms.TextBox txtCountryName;
        private System.Windows.Forms.TextBox txtCountryDescription;
        private System.Windows.Forms.Label lblCounrtyDescription;
        private System.Windows.Forms.Label lblCounrtyISOCode;
        private System.Windows.Forms.CheckBox ckCounrtyIsActive;
        private System.Windows.Forms.Label lblCountryName;
        private System.Windows.Forms.TextBox txtCityCountry;
    }
}