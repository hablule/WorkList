namespace SRP
{
    partial class frmBpartner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBpartner));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblBpartnerName = new System.Windows.Forms.Label();
            this.lblBpartnerDescription = new System.Windows.Forms.Label();
            this.ckBpartnerIsActive = new System.Windows.Forms.CheckBox();
            this.ckBpartnerIsCustomer = new System.Windows.Forms.CheckBox();
            this.ckBpartnerIsVendor = new System.Windows.Forms.CheckBox();
            this.txtBpartnerName = new System.Windows.Forms.TextBox();
            this.txtBpartnerDescription = new System.Windows.Forms.TextBox();
            this.dtgBpartnerGridView = new System.Windows.Forms.DataGridView();
            this.lblBpartnerName2 = new System.Windows.Forms.Label();
            this.grbBpartnerAddressBox = new System.Windows.Forms.GroupBox();
            this.cmbBpartnerCountry = new System.Windows.Forms.ComboBox();
            this.cmbBpartnerCity = new System.Windows.Forms.ComboBox();
            this.cmbBpartnerLocality = new System.Windows.Forms.ComboBox();
            this.cmbBpartnerSubLocality = new System.Windows.Forms.ComboBox();
            this.txtBpartnerPostal = new System.Windows.Forms.TextBox();
            this.txtBpartnerFax = new System.Windows.Forms.TextBox();
            this.txtBpartnerPhone = new System.Windows.Forms.TextBox();
            this.txtBpartnerPhone2 = new System.Windows.Forms.TextBox();
            this.txtBpartnerCityName = new System.Windows.Forms.TextBox();
            this.txtBpartnerLocalityName = new System.Windows.Forms.TextBox();
            this.txtBpartnerAdd4 = new System.Windows.Forms.TextBox();
            this.txtBpartnerAdd3 = new System.Windows.Forms.TextBox();
            this.txtBpartnerAdd2 = new System.Windows.Forms.TextBox();
            this.txtBpartnerAdd1 = new System.Windows.Forms.TextBox();
            this.lblBpartnerPostal = new System.Windows.Forms.Label();
            this.lblBpartnerFax = new System.Windows.Forms.Label();
            this.lblBpartnerPhone2 = new System.Windows.Forms.Label();
            this.lblBpartnerPhone = new System.Windows.Forms.Label();
            this.lblBpartnerCityName = new System.Windows.Forms.Label();
            this.lblBpartnerLocalityName = new System.Windows.Forms.Label();
            this.lblBpartnerCountry = new System.Windows.Forms.Label();
            this.lblBpartnerCity = new System.Windows.Forms.Label();
            this.lblBpartnerLocality = new System.Windows.Forms.Label();
            this.lblBpartnerSubLocality = new System.Windows.Forms.Label();
            this.lblBpartnerAdd4 = new System.Windows.Forms.Label();
            this.lblBpartnerAdd3 = new System.Windows.Forms.Label();
            this.lblBpartnerAdd2 = new System.Windows.Forms.Label();
            this.lblBpartnerAdd1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBpartnerName2 = new System.Windows.Forms.TextBox();
            this.lblBpartnerTIN = new System.Windows.Forms.Label();
            this.lblBpartnerVATRegNo = new System.Windows.Forms.Label();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.ntbTIN = new SRP.ctlNumberTextBox();
            this.ntbVATRegNo = new SRP.ctlNumberTextBox();
            this.tlsCommandToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBpartnerGridView)).BeginInit();
            this.grbBpartnerAddressBox.SuspendLayout();
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
            this.tlsCommandToolBar.Size = new System.Drawing.Size(729, 25);
            this.tlsCommandToolBar.TabIndex = 0;
            this.tlsCommandToolBar.Text = "toolStrip1";
            // 
            // tlsNew
            // 
            this.tlsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNew.Image = ((System.Drawing.Image)(resources.GetObject("tlsNew.Image")));
            this.tlsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNew.Name = "tlsNew";
            this.tlsNew.Size = new System.Drawing.Size(32, 22);
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
            this.tlsDelete.Size = new System.Drawing.Size(42, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Visible = false;
            // 
            // tlsSearch
            // 
            this.tlsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlsSearch.Image")));
            this.tlsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearch.Name = "tlsSearch";
            this.tlsSearch.Size = new System.Drawing.Size(44, 22);
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
            this.tlsFirstRecord.Size = new System.Drawing.Size(32, 22);
            this.tlsFirstRecord.Text = "First";
            this.tlsFirstRecord.Visible = false;
            // 
            // tlsPreviousRecord
            // 
            this.tlsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsPreviousRecord.Image")));
            this.tlsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPreviousRecord.Name = "tlsPreviousRecord";
            this.tlsPreviousRecord.Size = new System.Drawing.Size(52, 22);
            this.tlsPreviousRecord.Text = "Previous";
            this.tlsPreviousRecord.Visible = false;
            // 
            // tlsNextRecord
            // 
            this.tlsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsNextRecord.Image")));
            this.tlsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsNextRecord.Name = "tlsNextRecord";
            this.tlsNextRecord.Size = new System.Drawing.Size(34, 22);
            this.tlsNextRecord.Text = "Next";
            this.tlsNextRecord.Visible = false;
            // 
            // tlsLastRecord
            // 
            this.tlsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tlsLastRecord.Image")));
            this.tlsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsLastRecord.Name = "tlsLastRecord";
            this.tlsLastRecord.Size = new System.Drawing.Size(31, 22);
            this.tlsLastRecord.Text = "Last";
            this.tlsLastRecord.Visible = false;
            // 
            // lblBpartnerName
            // 
            this.lblBpartnerName.AutoSize = true;
            this.lblBpartnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBpartnerName.Location = new System.Drawing.Point(61, 80);
            this.lblBpartnerName.Name = "lblBpartnerName";
            this.lblBpartnerName.Size = new System.Drawing.Size(41, 15);
            this.lblBpartnerName.TabIndex = 1;
            this.lblBpartnerName.Text = "Name";
            // 
            // lblBpartnerDescription
            // 
            this.lblBpartnerDescription.AutoSize = true;
            this.lblBpartnerDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBpartnerDescription.Location = new System.Drawing.Point(33, 127);
            this.lblBpartnerDescription.Name = "lblBpartnerDescription";
            this.lblBpartnerDescription.Size = new System.Drawing.Size(69, 15);
            this.lblBpartnerDescription.TabIndex = 2;
            this.lblBpartnerDescription.Text = "Description";
            // 
            // ckBpartnerIsActive
            // 
            this.ckBpartnerIsActive.AutoSize = true;
            this.ckBpartnerIsActive.Checked = true;
            this.ckBpartnerIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBpartnerIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBpartnerIsActive.Location = new System.Drawing.Point(55, 215);
            this.ckBpartnerIsActive.Name = "ckBpartnerIsActive";
            this.ckBpartnerIsActive.Size = new System.Drawing.Size(69, 19);
            this.ckBpartnerIsActive.TabIndex = 3;
            this.ckBpartnerIsActive.Text = "Is Active";
            this.ckBpartnerIsActive.UseVisualStyleBackColor = true;
            // 
            // ckBpartnerIsCustomer
            // 
            this.ckBpartnerIsCustomer.AutoSize = true;
            this.ckBpartnerIsCustomer.Checked = true;
            this.ckBpartnerIsCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBpartnerIsCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBpartnerIsCustomer.Location = new System.Drawing.Point(55, 241);
            this.ckBpartnerIsCustomer.Name = "ckBpartnerIsCustomer";
            this.ckBpartnerIsCustomer.Size = new System.Drawing.Size(91, 19);
            this.ckBpartnerIsCustomer.TabIndex = 4;
            this.ckBpartnerIsCustomer.Text = "Is Customer";
            this.ckBpartnerIsCustomer.UseVisualStyleBackColor = true;
            // 
            // ckBpartnerIsVendor
            // 
            this.ckBpartnerIsVendor.AutoSize = true;
            this.ckBpartnerIsVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBpartnerIsVendor.Location = new System.Drawing.Point(199, 241);
            this.ckBpartnerIsVendor.Name = "ckBpartnerIsVendor";
            this.ckBpartnerIsVendor.Size = new System.Drawing.Size(77, 19);
            this.ckBpartnerIsVendor.TabIndex = 5;
            this.ckBpartnerIsVendor.Text = "Is Vendor";
            this.ckBpartnerIsVendor.UseVisualStyleBackColor = true;
            // 
            // txtBpartnerName
            // 
            this.txtBpartnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBpartnerName.Location = new System.Drawing.Point(107, 77);
            this.txtBpartnerName.Name = "txtBpartnerName";
            this.txtBpartnerName.Size = new System.Drawing.Size(173, 21);
            this.txtBpartnerName.TabIndex = 6;
            // 
            // txtBpartnerDescription
            // 
            this.txtBpartnerDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBpartnerDescription.Location = new System.Drawing.Point(107, 124);
            this.txtBpartnerDescription.Multiline = true;
            this.txtBpartnerDescription.Name = "txtBpartnerDescription";
            this.txtBpartnerDescription.Size = new System.Drawing.Size(198, 85);
            this.txtBpartnerDescription.TabIndex = 7;
            // 
            // dtgBpartnerGridView
            // 
            this.dtgBpartnerGridView.AllowUserToAddRows = false;
            this.dtgBpartnerGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgBpartnerGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBpartnerGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgBpartnerGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgBpartnerGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBpartnerGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgBpartnerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBpartnerGridView.Location = new System.Drawing.Point(6, 337);
            this.dtgBpartnerGridView.MultiSelect = false;
            this.dtgBpartnerGridView.Name = "dtgBpartnerGridView";
            this.dtgBpartnerGridView.ReadOnly = true;
            this.dtgBpartnerGridView.RowHeadersWidth = 20;
            this.dtgBpartnerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBpartnerGridView.Size = new System.Drawing.Size(717, 112);
            this.dtgBpartnerGridView.TabIndex = 8;
            this.dtgBpartnerGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBpartnerGridView_CellDoubleClick);
            this.dtgBpartnerGridView.SelectionChanged += new System.EventHandler(this.dtgBpartnerGridView_SelectionChanged);
            // 
            // lblBpartnerName2
            // 
            this.lblBpartnerName2.AutoSize = true;
            this.lblBpartnerName2.Location = new System.Drawing.Point(51, 103);
            this.lblBpartnerName2.Name = "lblBpartnerName2";
            this.lblBpartnerName2.Size = new System.Drawing.Size(51, 15);
            this.lblBpartnerName2.TabIndex = 9;
            this.lblBpartnerName2.Text = "Name 2";
            // 
            // grbBpartnerAddressBox
            // 
            this.grbBpartnerAddressBox.Controls.Add(this.cmbBpartnerCountry);
            this.grbBpartnerAddressBox.Controls.Add(this.cmbBpartnerCity);
            this.grbBpartnerAddressBox.Controls.Add(this.cmbBpartnerLocality);
            this.grbBpartnerAddressBox.Controls.Add(this.cmbBpartnerSubLocality);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerPostal);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerFax);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerPhone);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerPhone2);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerCityName);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerLocalityName);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerAdd4);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerAdd3);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerAdd2);
            this.grbBpartnerAddressBox.Controls.Add(this.txtBpartnerAdd1);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerPostal);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerFax);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerPhone2);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerPhone);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerCityName);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerLocalityName);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerCountry);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerCity);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerLocality);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerSubLocality);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerAdd4);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerAdd3);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerAdd2);
            this.grbBpartnerAddressBox.Controls.Add(this.lblBpartnerAdd1);
            this.grbBpartnerAddressBox.Controls.Add(this.label4);
            this.grbBpartnerAddressBox.Location = new System.Drawing.Point(313, 43);
            this.grbBpartnerAddressBox.Name = "grbBpartnerAddressBox";
            this.grbBpartnerAddressBox.Size = new System.Drawing.Size(410, 288);
            this.grbBpartnerAddressBox.TabIndex = 10;
            this.grbBpartnerAddressBox.TabStop = false;
            this.grbBpartnerAddressBox.Text = "Partner Address";
            // 
            // cmbBpartnerCountry
            // 
            this.cmbBpartnerCountry.FormattingEnabled = true;
            this.cmbBpartnerCountry.Location = new System.Drawing.Point(156, 200);
            this.cmbBpartnerCountry.Name = "cmbBpartnerCountry";
            this.cmbBpartnerCountry.Size = new System.Drawing.Size(121, 23);
            this.cmbBpartnerCountry.TabIndex = 29;
            this.cmbBpartnerCountry.SelectedIndexChanged += new System.EventHandler(this.cmbBpartnerCountry_SelectedIndexChanged);
            // 
            // cmbBpartnerCity
            // 
            this.cmbBpartnerCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBpartnerCity.FormattingEnabled = true;
            this.cmbBpartnerCity.Location = new System.Drawing.Point(64, 169);
            this.cmbBpartnerCity.Name = "cmbBpartnerCity";
            this.cmbBpartnerCity.Size = new System.Drawing.Size(135, 23);
            this.cmbBpartnerCity.TabIndex = 28;
            this.cmbBpartnerCity.SelectedIndexChanged += new System.EventHandler(this.cmbBpartnerCity_SelectedIndexChanged);
            // 
            // cmbBpartnerLocality
            // 
            this.cmbBpartnerLocality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBpartnerLocality.FormattingEnabled = true;
            this.cmbBpartnerLocality.Location = new System.Drawing.Point(64, 144);
            this.cmbBpartnerLocality.Name = "cmbBpartnerLocality";
            this.cmbBpartnerLocality.Size = new System.Drawing.Size(148, 23);
            this.cmbBpartnerLocality.TabIndex = 27;
            this.cmbBpartnerLocality.SelectedIndexChanged += new System.EventHandler(this.cmbBpartnerLocality_SelectedIndexChanged);
            // 
            // cmbBpartnerSubLocality
            // 
            this.cmbBpartnerSubLocality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBpartnerSubLocality.FormattingEnabled = true;
            this.cmbBpartnerSubLocality.Location = new System.Drawing.Point(64, 119);
            this.cmbBpartnerSubLocality.Name = "cmbBpartnerSubLocality";
            this.cmbBpartnerSubLocality.Size = new System.Drawing.Size(163, 23);
            this.cmbBpartnerSubLocality.TabIndex = 26;
            this.cmbBpartnerSubLocality.SelectedIndexChanged += new System.EventHandler(this.cmbBpartnerSubLocality_SelectedIndexChanged);
            // 
            // txtBpartnerPostal
            // 
            this.txtBpartnerPostal.Location = new System.Drawing.Point(266, 256);
            this.txtBpartnerPostal.Name = "txtBpartnerPostal";
            this.txtBpartnerPostal.Size = new System.Drawing.Size(138, 21);
            this.txtBpartnerPostal.TabIndex = 25;
            // 
            // txtBpartnerFax
            // 
            this.txtBpartnerFax.Location = new System.Drawing.Point(266, 233);
            this.txtBpartnerFax.Name = "txtBpartnerFax";
            this.txtBpartnerFax.Size = new System.Drawing.Size(138, 21);
            this.txtBpartnerFax.TabIndex = 24;
            // 
            // txtBpartnerPhone
            // 
            this.txtBpartnerPhone.Location = new System.Drawing.Point(81, 232);
            this.txtBpartnerPhone.Name = "txtBpartnerPhone";
            this.txtBpartnerPhone.Size = new System.Drawing.Size(131, 21);
            this.txtBpartnerPhone.TabIndex = 23;
            // 
            // txtBpartnerPhone2
            // 
            this.txtBpartnerPhone2.Location = new System.Drawing.Point(81, 256);
            this.txtBpartnerPhone2.Name = "txtBpartnerPhone2";
            this.txtBpartnerPhone2.Size = new System.Drawing.Size(132, 21);
            this.txtBpartnerPhone2.TabIndex = 22;
            // 
            // txtBpartnerCityName
            // 
            this.txtBpartnerCityName.Location = new System.Drawing.Point(274, 166);
            this.txtBpartnerCityName.Name = "txtBpartnerCityName";
            this.txtBpartnerCityName.Size = new System.Drawing.Size(130, 21);
            this.txtBpartnerCityName.TabIndex = 21;
            // 
            // txtBpartnerLocalityName
            // 
            this.txtBpartnerLocalityName.Location = new System.Drawing.Point(274, 143);
            this.txtBpartnerLocalityName.Name = "txtBpartnerLocalityName";
            this.txtBpartnerLocalityName.Size = new System.Drawing.Size(130, 21);
            this.txtBpartnerLocalityName.TabIndex = 20;
            // 
            // txtBpartnerAdd4
            // 
            this.txtBpartnerAdd4.Location = new System.Drawing.Point(82, 93);
            this.txtBpartnerAdd4.Name = "txtBpartnerAdd4";
            this.txtBpartnerAdd4.Size = new System.Drawing.Size(145, 21);
            this.txtBpartnerAdd4.TabIndex = 18;
            // 
            // txtBpartnerAdd3
            // 
            this.txtBpartnerAdd3.Location = new System.Drawing.Point(82, 70);
            this.txtBpartnerAdd3.Name = "txtBpartnerAdd3";
            this.txtBpartnerAdd3.Size = new System.Drawing.Size(145, 21);
            this.txtBpartnerAdd3.TabIndex = 17;
            // 
            // txtBpartnerAdd2
            // 
            this.txtBpartnerAdd2.Location = new System.Drawing.Point(82, 47);
            this.txtBpartnerAdd2.Name = "txtBpartnerAdd2";
            this.txtBpartnerAdd2.Size = new System.Drawing.Size(145, 21);
            this.txtBpartnerAdd2.TabIndex = 16;
            // 
            // txtBpartnerAdd1
            // 
            this.txtBpartnerAdd1.Location = new System.Drawing.Point(82, 24);
            this.txtBpartnerAdd1.Name = "txtBpartnerAdd1";
            this.txtBpartnerAdd1.Size = new System.Drawing.Size(145, 21);
            this.txtBpartnerAdd1.TabIndex = 15;
            // 
            // lblBpartnerPostal
            // 
            this.lblBpartnerPostal.AutoSize = true;
            this.lblBpartnerPostal.Location = new System.Drawing.Point(221, 259);
            this.lblBpartnerPostal.Name = "lblBpartnerPostal";
            this.lblBpartnerPostal.Size = new System.Drawing.Size(41, 15);
            this.lblBpartnerPostal.TabIndex = 14;
            this.lblBpartnerPostal.Text = "Postal";
            // 
            // lblBpartnerFax
            // 
            this.lblBpartnerFax.AutoSize = true;
            this.lblBpartnerFax.Location = new System.Drawing.Point(235, 236);
            this.lblBpartnerFax.Name = "lblBpartnerFax";
            this.lblBpartnerFax.Size = new System.Drawing.Size(27, 15);
            this.lblBpartnerFax.TabIndex = 13;
            this.lblBpartnerFax.Text = "Fax";
            // 
            // lblBpartnerPhone2
            // 
            this.lblBpartnerPhone2.AutoSize = true;
            this.lblBpartnerPhone2.Location = new System.Drawing.Point(9, 259);
            this.lblBpartnerPhone2.Name = "lblBpartnerPhone2";
            this.lblBpartnerPhone2.Size = new System.Drawing.Size(67, 15);
            this.lblBpartnerPhone2.TabIndex = 12;
            this.lblBpartnerPhone2.Text = "2nd Phone";
            // 
            // lblBpartnerPhone
            // 
            this.lblBpartnerPhone.AutoSize = true;
            this.lblBpartnerPhone.Location = new System.Drawing.Point(32, 235);
            this.lblBpartnerPhone.Name = "lblBpartnerPhone";
            this.lblBpartnerPhone.Size = new System.Drawing.Size(43, 15);
            this.lblBpartnerPhone.TabIndex = 11;
            this.lblBpartnerPhone.Text = "Phone";
            // 
            // lblBpartnerCityName
            // 
            this.lblBpartnerCityName.AutoSize = true;
            this.lblBpartnerCityName.Location = new System.Drawing.Point(243, 169);
            this.lblBpartnerCityName.Name = "lblBpartnerCityName";
            this.lblBpartnerCityName.Size = new System.Drawing.Size(26, 15);
            this.lblBpartnerCityName.TabIndex = 10;
            this.lblBpartnerCityName.Text = "City";
            // 
            // lblBpartnerLocalityName
            // 
            this.lblBpartnerLocalityName.AutoSize = true;
            this.lblBpartnerLocalityName.Location = new System.Drawing.Point(234, 146);
            this.lblBpartnerLocalityName.Name = "lblBpartnerLocalityName";
            this.lblBpartnerLocalityName.Size = new System.Drawing.Size(35, 15);
            this.lblBpartnerLocalityName.TabIndex = 9;
            this.lblBpartnerLocalityName.Text = "Zone";
            // 
            // lblBpartnerCountry
            // 
            this.lblBpartnerCountry.AutoSize = true;
            this.lblBpartnerCountry.Location = new System.Drawing.Point(103, 204);
            this.lblBpartnerCountry.Name = "lblBpartnerCountry";
            this.lblBpartnerCountry.Size = new System.Drawing.Size(48, 15);
            this.lblBpartnerCountry.TabIndex = 8;
            this.lblBpartnerCountry.Text = "Country";
            // 
            // lblBpartnerCity
            // 
            this.lblBpartnerCity.AutoSize = true;
            this.lblBpartnerCity.Location = new System.Drawing.Point(33, 174);
            this.lblBpartnerCity.Name = "lblBpartnerCity";
            this.lblBpartnerCity.Size = new System.Drawing.Size(26, 15);
            this.lblBpartnerCity.TabIndex = 7;
            this.lblBpartnerCity.Text = "City";
            // 
            // lblBpartnerLocality
            // 
            this.lblBpartnerLocality.AutoSize = true;
            this.lblBpartnerLocality.Location = new System.Drawing.Point(9, 148);
            this.lblBpartnerLocality.Name = "lblBpartnerLocality";
            this.lblBpartnerLocality.Size = new System.Drawing.Size(51, 15);
            this.lblBpartnerLocality.TabIndex = 6;
            this.lblBpartnerLocality.Text = "Sub City";
            // 
            // lblBpartnerSubLocality
            // 
            this.lblBpartnerSubLocality.AutoSize = true;
            this.lblBpartnerSubLocality.Location = new System.Drawing.Point(16, 123);
            this.lblBpartnerSubLocality.Name = "lblBpartnerSubLocality";
            this.lblBpartnerSubLocality.Size = new System.Drawing.Size(44, 15);
            this.lblBpartnerSubLocality.TabIndex = 5;
            this.lblBpartnerSubLocality.Text = "kebele";
            // 
            // lblBpartnerAdd4
            // 
            this.lblBpartnerAdd4.AutoSize = true;
            this.lblBpartnerAdd4.Location = new System.Drawing.Point(17, 96);
            this.lblBpartnerAdd4.Name = "lblBpartnerAdd4";
            this.lblBpartnerAdd4.Size = new System.Drawing.Size(61, 15);
            this.lblBpartnerAdd4.TabIndex = 4;
            this.lblBpartnerAdd4.Text = "Address 4";
            // 
            // lblBpartnerAdd3
            // 
            this.lblBpartnerAdd3.AutoSize = true;
            this.lblBpartnerAdd3.Location = new System.Drawing.Point(17, 73);
            this.lblBpartnerAdd3.Name = "lblBpartnerAdd3";
            this.lblBpartnerAdd3.Size = new System.Drawing.Size(61, 15);
            this.lblBpartnerAdd3.TabIndex = 3;
            this.lblBpartnerAdd3.Text = "Address 3";
            // 
            // lblBpartnerAdd2
            // 
            this.lblBpartnerAdd2.AutoSize = true;
            this.lblBpartnerAdd2.Location = new System.Drawing.Point(17, 50);
            this.lblBpartnerAdd2.Name = "lblBpartnerAdd2";
            this.lblBpartnerAdd2.Size = new System.Drawing.Size(61, 15);
            this.lblBpartnerAdd2.TabIndex = 2;
            this.lblBpartnerAdd2.Text = "Address 2";
            // 
            // lblBpartnerAdd1
            // 
            this.lblBpartnerAdd1.AutoSize = true;
            this.lblBpartnerAdd1.Location = new System.Drawing.Point(17, 27);
            this.lblBpartnerAdd1.Name = "lblBpartnerAdd1";
            this.lblBpartnerAdd1.Size = new System.Drawing.Size(61, 15);
            this.lblBpartnerAdd1.TabIndex = 1;
            this.lblBpartnerAdd1.Text = "Address 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, -20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // txtBpartnerName2
            // 
            this.txtBpartnerName2.Location = new System.Drawing.Point(107, 100);
            this.txtBpartnerName2.Name = "txtBpartnerName2";
            this.txtBpartnerName2.Size = new System.Drawing.Size(198, 21);
            this.txtBpartnerName2.TabIndex = 11;
            // 
            // lblBpartnerTIN
            // 
            this.lblBpartnerTIN.AutoSize = true;
            this.lblBpartnerTIN.Location = new System.Drawing.Point(77, 282);
            this.lblBpartnerTIN.Name = "lblBpartnerTIN";
            this.lblBpartnerTIN.Size = new System.Drawing.Size(26, 15);
            this.lblBpartnerTIN.TabIndex = 12;
            this.lblBpartnerTIN.Text = "TIN";
            // 
            // lblBpartnerVATRegNo
            // 
            this.lblBpartnerVATRegNo.AutoSize = true;
            this.lblBpartnerVATRegNo.Location = new System.Drawing.Point(26, 306);
            this.lblBpartnerVATRegNo.Name = "lblBpartnerVATRegNo";
            this.lblBpartnerVATRegNo.Size = new System.Drawing.Size(76, 15);
            this.lblBpartnerVATRegNo.TabIndex = 13;
            this.lblBpartnerVATRegNo.Text = "VAT Reg No.";
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(107, 48);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(162, 23);
            this.cmbOrganisation.TabIndex = 40;
            this.cmbOrganisation.SelectedIndexChanged += new System.EventHandler(this.cmbOrganisation_SelectedIndexChanged);
            this.cmbOrganisation.DropDown += new System.EventHandler(this.cmbOrganisation_DropDown);
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganisation.Location = new System.Drawing.Point(13, 50);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(89, 15);
            this.lblOrganisation.TabIndex = 39;
            this.lblOrganisation.Text = "Organisation";
            // 
            // ntbTIN
            // 
            this.ntbTIN.Align = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbTIN.AllowedLength = 10;
            this.ntbTIN.AllowLeadingZeros = true;
            this.ntbTIN.AllowNegative = false;
            this.ntbTIN.Amount = "";
            this.ntbTIN.defaultAmount = "";
            this.ntbTIN.Location = new System.Drawing.Point(107, 278);
            this.ntbTIN.Name = "ntbTIN";
            this.ntbTIN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbTIN.ShowThousandSeparetor = false;
            this.ntbTIN.Size = new System.Drawing.Size(164, 23);
            this.ntbTIN.StandardPrecision = 0;
            this.ntbTIN.TabIndex = 14;
            // 
            // ntbVATRegNo
            // 
            this.ntbVATRegNo.Align = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbVATRegNo.AllowedLength = 0;
            this.ntbVATRegNo.AllowLeadingZeros = true;
            this.ntbVATRegNo.AllowNegative = false;
            this.ntbVATRegNo.Amount = "";
            this.ntbVATRegNo.defaultAmount = "";
            this.ntbVATRegNo.Location = new System.Drawing.Point(107, 302);
            this.ntbVATRegNo.Name = "ntbVATRegNo";
            this.ntbVATRegNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbVATRegNo.ShowThousandSeparetor = false;
            this.ntbVATRegNo.Size = new System.Drawing.Size(164, 23);
            this.ntbVATRegNo.StandardPrecision = 0;
            this.ntbVATRegNo.TabIndex = 15;
            // 
            // frmBpartner
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(729, 455);
            this.Controls.Add(this.cmbOrganisation);
            this.Controls.Add(this.lblOrganisation);
            this.Controls.Add(this.ntbTIN);
            this.Controls.Add(this.ntbVATRegNo);
            this.Controls.Add(this.lblBpartnerVATRegNo);
            this.Controls.Add(this.lblBpartnerTIN);
            this.Controls.Add(this.txtBpartnerName2);
            this.Controls.Add(this.grbBpartnerAddressBox);
            this.Controls.Add(this.lblBpartnerName2);
            this.Controls.Add(this.dtgBpartnerGridView);
            this.Controls.Add(this.txtBpartnerDescription);
            this.Controls.Add(this.txtBpartnerName);
            this.Controls.Add(this.ckBpartnerIsVendor);
            this.Controls.Add(this.ckBpartnerIsCustomer);
            this.Controls.Add(this.ckBpartnerIsActive);
            this.Controls.Add(this.lblBpartnerDescription);
            this.Controls.Add(this.lblBpartnerName);
            this.Controls.Add(this.tlsCommandToolBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBpartner";
            this.Text = "frmBpartner";
            this.tlsCommandToolBar.ResumeLayout(false);
            this.tlsCommandToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBpartnerGridView)).EndInit();
            this.grbBpartnerAddressBox.ResumeLayout(false);
            this.grbBpartnerAddressBox.PerformLayout();
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
        private System.Windows.Forms.Label lblBpartnerName;
        private System.Windows.Forms.Label lblBpartnerDescription;
        private System.Windows.Forms.CheckBox ckBpartnerIsActive;
        private System.Windows.Forms.CheckBox ckBpartnerIsCustomer;
        private System.Windows.Forms.CheckBox ckBpartnerIsVendor;
        private System.Windows.Forms.TextBox txtBpartnerName;
        private System.Windows.Forms.TextBox txtBpartnerDescription;
        private System.Windows.Forms.DataGridView dtgBpartnerGridView;
        private System.Windows.Forms.Label lblBpartnerName2;
        private System.Windows.Forms.GroupBox grbBpartnerAddressBox;
        private System.Windows.Forms.TextBox txtBpartnerName2;
        private System.Windows.Forms.Label lblBpartnerAdd3;
        private System.Windows.Forms.Label lblBpartnerAdd2;
        private System.Windows.Forms.Label lblBpartnerAdd1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBpartnerTIN;
        private System.Windows.Forms.Label lblBpartnerVATRegNo;
        private System.Windows.Forms.Label lblBpartnerPhone2;
        private System.Windows.Forms.Label lblBpartnerPhone;
        private System.Windows.Forms.Label lblBpartnerCityName;
        private System.Windows.Forms.Label lblBpartnerLocalityName;
        private System.Windows.Forms.Label lblBpartnerCountry;
        private System.Windows.Forms.Label lblBpartnerCity;
        private System.Windows.Forms.Label lblBpartnerLocality;
        private System.Windows.Forms.Label lblBpartnerSubLocality;
        private System.Windows.Forms.Label lblBpartnerAdd4;
        private System.Windows.Forms.Label lblBpartnerPostal;
        private System.Windows.Forms.Label lblBpartnerFax;
        private System.Windows.Forms.TextBox txtBpartnerPostal;
        private System.Windows.Forms.TextBox txtBpartnerFax;
        private System.Windows.Forms.TextBox txtBpartnerPhone;
        private System.Windows.Forms.TextBox txtBpartnerPhone2;
        private System.Windows.Forms.TextBox txtBpartnerCityName;
        private System.Windows.Forms.TextBox txtBpartnerLocalityName;
        private System.Windows.Forms.TextBox txtBpartnerAdd4;
        private System.Windows.Forms.TextBox txtBpartnerAdd3;
        private System.Windows.Forms.TextBox txtBpartnerAdd2;
        private System.Windows.Forms.TextBox txtBpartnerAdd1;
        private System.Windows.Forms.ComboBox cmbBpartnerCountry;
        private System.Windows.Forms.ComboBox cmbBpartnerCity;
        private System.Windows.Forms.ComboBox cmbBpartnerLocality;
        private System.Windows.Forms.ComboBox cmbBpartnerSubLocality;
        private ctlNumberTextBox ntbTIN;
        private ctlNumberTextBox ntbVATRegNo;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblOrganisation;
    }
}