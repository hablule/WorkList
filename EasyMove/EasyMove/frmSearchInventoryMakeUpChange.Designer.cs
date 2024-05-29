namespace EasyMove
{
    partial class frmSearchInventoryMakeUpChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchInventoryMakeUpChange));
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbOraganisationLogic = new System.Windows.Forms.ComboBox();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.cmbDocumentTypeLogic = new System.Windows.Forms.ComboBox();
            this.cmbMovementDateLogic = new System.Windows.Forms.ComboBox();
            this.cmbProductLogic = new System.Windows.Forms.ComboBox();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.txtDocumentNumberFrom = new System.Windows.Forms.TextBox();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.dtpMoveDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpMoveDateTo = new System.Windows.Forms.DateTimePicker();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.txtDocumentNumberTo = new System.Windows.Forms.TextBox();
            this.ddgProduct = new EasyMove.DropDownDataGrid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.Location = new System.Drawing.Point(8, 16);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(103, 19);
            this.lblOrganisation.TabIndex = 0;
            this.lblOrganisation.Text = "Organisation";
            this.lblOrganisation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Location = new System.Drawing.Point(8, 45);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(103, 19);
            this.lblDocumentNumber.TabIndex = 1;
            this.lblDocumentNumber.Text = "Document Number";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.Location = new System.Drawing.Point(8, 74);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(103, 19);
            this.lblDocumentType.TabIndex = 2;
            this.lblDocumentType.Text = "Document Type";
            this.lblDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.Location = new System.Drawing.Point(8, 103);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(103, 19);
            this.lblReceiptDate.TabIndex = 3;
            this.lblReceiptDate.Text = "Date Assembeled";
            this.lblReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(8, 130);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(103, 19);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOraganisationLogic
            // 
            this.cmbOraganisationLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOraganisationLogic.DropDownWidth = 130;
            this.cmbOraganisationLogic.FormattingEnabled = true;
            this.cmbOraganisationLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbOraganisationLogic.Location = new System.Drawing.Point(117, 14);
            this.cmbOraganisationLogic.Name = "cmbOraganisationLogic";
            this.cmbOraganisationLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbOraganisationLogic.TabIndex = 10;
            this.cmbOraganisationLogic.SelectedIndexChanged += new System.EventHandler(this.cmbOraganisationLogic_SelectedIndexChanged);
            // 
            // cmbDocumentNumberLogic
            // 
            this.cmbDocumentNumberLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentNumberLogic.DropDownWidth = 130;
            this.cmbDocumentNumberLogic.FormattingEnabled = true;
            this.cmbDocumentNumberLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not similar to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbDocumentNumberLogic.Location = new System.Drawing.Point(117, 45);
            this.cmbDocumentNumberLogic.Name = "cmbDocumentNumberLogic";
            this.cmbDocumentNumberLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDocumentNumberLogic.TabIndex = 11;
            this.cmbDocumentNumberLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentNumberLogic_SelectedIndexChanged);
            // 
            // cmbDocumentTypeLogic
            // 
            this.cmbDocumentTypeLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentTypeLogic.DropDownWidth = 130;
            this.cmbDocumentTypeLogic.FormattingEnabled = true;
            this.cmbDocumentTypeLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbDocumentTypeLogic.Location = new System.Drawing.Point(117, 72);
            this.cmbDocumentTypeLogic.Name = "cmbDocumentTypeLogic";
            this.cmbDocumentTypeLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbDocumentTypeLogic.TabIndex = 12;
            this.cmbDocumentTypeLogic.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentTypeLogic_SelectedIndexChanged);
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
            this.cmbMovementDateLogic.Location = new System.Drawing.Point(117, 101);
            this.cmbMovementDateLogic.Name = "cmbMovementDateLogic";
            this.cmbMovementDateLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbMovementDateLogic.TabIndex = 13;
            this.cmbMovementDateLogic.SelectedIndexChanged += new System.EventHandler(this.cmbMovementDateLogic_SelectedIndexChanged);
            // 
            // cmbProductLogic
            // 
            this.cmbProductLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductLogic.DropDownWidth = 130;
            this.cmbProductLogic.FormattingEnabled = true;
            this.cmbProductLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbProductLogic.Location = new System.Drawing.Point(117, 128);
            this.cmbProductLogic.Name = "cmbProductLogic";
            this.cmbProductLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbProductLogic.TabIndex = 16;
            this.cmbProductLogic.SelectedIndexChanged += new System.EventHandler(this.cmbProductLogic_SelectedIndexChanged);
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(235, 14);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(213, 21);
            this.cmbOrganisation.TabIndex = 22;
            // 
            // txtDocumentNumberFrom
            // 
            this.txtDocumentNumberFrom.Location = new System.Drawing.Point(236, 45);
            this.txtDocumentNumberFrom.Name = "txtDocumentNumberFrom";
            this.txtDocumentNumberFrom.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumberFrom.TabIndex = 23;
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(236, 71);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(162, 21);
            this.cmbDocumentType.TabIndex = 24;
            // 
            // dtpMoveDateFrom
            // 
            this.dtpMoveDateFrom.Location = new System.Drawing.Point(235, 101);
            this.dtpMoveDateFrom.Name = "dtpMoveDateFrom";
            this.dtpMoveDateFrom.Size = new System.Drawing.Size(196, 20);
            this.dtpMoveDateFrom.TabIndex = 25;
            // 
            // dtpMoveDateTo
            // 
            this.dtpMoveDateTo.Location = new System.Drawing.Point(437, 101);
            this.dtpMoveDateTo.Name = "dtpMoveDateTo";
            this.dtpMoveDateTo.Size = new System.Drawing.Size(198, 20);
            this.dtpMoveDateTo.TabIndex = 26;
            this.dtpMoveDateTo.Visible = false;
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(117, 165);
            this.ckAllOrAny.Name = "ckAllOrAny";
            this.ckAllOrAny.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAllOrAny.Size = new System.Drawing.Size(400, 24);
            this.ckAllOrAny.TabIndex = 35;
            this.ckAllOrAny.Text = "Show Movement Records That fullifil One Or All Criterion";
            this.ckAllOrAny.UseVisualStyleBackColor = true;
            this.ckAllOrAny.CheckedChanged += new System.EventHandler(this.ckAllOrAny_CheckedChanged);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(194, 229);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(226, 28);
            this.cmdSearch.TabIndex = 36;
            this.cmdSearch.Text = "Show Result";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSearchAndIncludeToPreviousResult);
            this.groupBox1.Controls.Add(this.txtDocumentNumberTo);
            this.groupBox1.Controls.Add(this.lblOrganisation);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.lblDocumentNumber);
            this.groupBox1.Controls.Add(this.ckAllOrAny);
            this.groupBox1.Controls.Add(this.lblDocumentType);
            this.groupBox1.Controls.Add(this.lblReceiptDate);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.cmbOraganisationLogic);
            this.groupBox1.Controls.Add(this.cmbDocumentNumberLogic);
            this.groupBox1.Controls.Add(this.ddgProduct);
            this.groupBox1.Controls.Add(this.cmbDocumentTypeLogic);
            this.groupBox1.Controls.Add(this.dtpMoveDateTo);
            this.groupBox1.Controls.Add(this.cmbMovementDateLogic);
            this.groupBox1.Controls.Add(this.dtpMoveDateFrom);
            this.groupBox1.Controls.Add(this.cmbDocumentType);
            this.groupBox1.Controls.Add(this.txtDocumentNumberFrom);
            this.groupBox1.Controls.Add(this.cmbProductLogic);
            this.groupBox1.Controls.Add(this.cmbOrganisation);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 268);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterion";
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(174, 195);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 40;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // txtDocumentNumberTo
            // 
            this.txtDocumentNumberTo.Location = new System.Drawing.Point(399, 45);
            this.txtDocumentNumberTo.Name = "txtDocumentNumberTo";
            this.txtDocumentNumberTo.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumberTo.TabIndex = 37;
            // 
            // ddgProduct
            // 
            this.ddgProduct.AutoFilter = true;
            this.ddgProduct.AutoSize = true;
            this.ddgProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgProduct.ClearButtonEnabled = true;
            this.ddgProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgProduct.FindButtonEnabled = true;
            this.ddgProduct.HiddenColoumns = new int[0];
            this.ddgProduct.Image = null;
            this.ddgProduct.Location = new System.Drawing.Point(230, 124);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(383, 31);
            this.ddgProduct.TabIndex = 27;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            // 
            // frmSearchInventoryMakeUpChange
            // 
            this.AcceptButton = this.cmbSearchAndIncludeToPreviousResult;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 268);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchInventoryMakeUpChange";
            this.Text = "Look-up Movement";
            this.Load += new System.EventHandler(this.frmSearchInventoryMakeUpChange_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbOraganisationLogic;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.ComboBox cmbDocumentTypeLogic;
        private System.Windows.Forms.ComboBox cmbMovementDateLogic;
        private System.Windows.Forms.ComboBox cmbProductLogic;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.TextBox txtDocumentNumberFrom;
        private System.Windows.Forms.ComboBox cmbDocumentType;
        private System.Windows.Forms.DateTimePicker dtpMoveDateFrom;
        private System.Windows.Forms.DateTimePicker dtpMoveDateTo;
        private DropDownDataGrid ddgProduct;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDocumentNumberTo;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
    }
}