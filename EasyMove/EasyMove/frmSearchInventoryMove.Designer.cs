namespace EasyMove
{
    partial class frmSearchInventoryMove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchInventoryMove));
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblMovementDate = new System.Windows.Forms.Label();
            this.lblMoveFrom = new System.Windows.Forms.Label();
            this.lblMoveTo = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblMoveQuantity = new System.Windows.Forms.Label();
            this.cmbOraganisationLogic = new System.Windows.Forms.ComboBox();
            this.cmbDocumentNumberLogic = new System.Windows.Forms.ComboBox();
            this.cmbDocumentTypeLogic = new System.Windows.Forms.ComboBox();
            this.cmbMovementDateLogic = new System.Windows.Forms.ComboBox();
            this.cmbMoveFromLogic = new System.Windows.Forms.ComboBox();
            this.cmbMoveToLogic = new System.Windows.Forms.ComboBox();
            this.cmbProductLogic = new System.Windows.Forms.ComboBox();
            this.cmbMoveQuantityLogic = new System.Windows.Forms.ComboBox();
            this.cmbMovedTo = new System.Windows.Forms.ComboBox();
            this.cmbMovedFrom = new System.Windows.Forms.ComboBox();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.txtDocumentNumberFrom = new System.Windows.Forms.TextBox();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.dtpMoveDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpMoveDateTo = new System.Windows.Forms.DateTimePicker();
            this.ckIsDraft = new System.Windows.Forms.CheckBox();
            this.ckIsInTrasit = new System.Windows.Forms.CheckBox();
            this.ckIsDelivered = new System.Windows.Forms.CheckBox();
            this.ckOnDispute = new System.Windows.Forms.CheckBox();
            this.ckIsCancelled = new System.Windows.Forms.CheckBox();
            this.ckAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSearchAndIncludeToPreviousResult = new System.Windows.Forms.Button();
            this.ckIsAccepted = new System.Windows.Forms.CheckBox();
            this.ckIsRequest = new System.Windows.Forms.CheckBox();
            this.txtDocumentNumberTo = new System.Windows.Forms.TextBox();
            this.ntbMovementQuantityTo = new EasyMove.ctlNumberTextBox();
            this.ntbMovementQuantityFrom = new EasyMove.ctlNumberTextBox();
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
            // lblMovementDate
            // 
            this.lblMovementDate.Location = new System.Drawing.Point(8, 103);
            this.lblMovementDate.Name = "lblMovementDate";
            this.lblMovementDate.Size = new System.Drawing.Size(103, 19);
            this.lblMovementDate.TabIndex = 3;
            this.lblMovementDate.Text = "Movement Date";
            this.lblMovementDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoveFrom
            // 
            this.lblMoveFrom.Location = new System.Drawing.Point(8, 133);
            this.lblMoveFrom.Name = "lblMoveFrom";
            this.lblMoveFrom.Size = new System.Drawing.Size(103, 19);
            this.lblMoveFrom.TabIndex = 4;
            this.lblMoveFrom.Text = "Moved From";
            this.lblMoveFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoveTo
            // 
            this.lblMoveTo.Location = new System.Drawing.Point(8, 163);
            this.lblMoveTo.Name = "lblMoveTo";
            this.lblMoveTo.Size = new System.Drawing.Size(103, 19);
            this.lblMoveTo.TabIndex = 5;
            this.lblMoveTo.Text = "Moved To";
            this.lblMoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(8, 193);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(103, 19);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoveQuantity
            // 
            this.lblMoveQuantity.Location = new System.Drawing.Point(8, 219);
            this.lblMoveQuantity.Name = "lblMoveQuantity";
            this.lblMoveQuantity.Size = new System.Drawing.Size(103, 19);
            this.lblMoveQuantity.TabIndex = 7;
            this.lblMoveQuantity.Text = "Quantity";
            this.lblMoveQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // cmbMoveFromLogic
            // 
            this.cmbMoveFromLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveFromLogic.DropDownWidth = 130;
            this.cmbMoveFromLogic.FormattingEnabled = true;
            this.cmbMoveFromLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbMoveFromLogic.Location = new System.Drawing.Point(117, 131);
            this.cmbMoveFromLogic.Name = "cmbMoveFromLogic";
            this.cmbMoveFromLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbMoveFromLogic.TabIndex = 14;
            this.cmbMoveFromLogic.SelectedIndexChanged += new System.EventHandler(this.cmbMoveFromLogic_SelectedIndexChanged);
            // 
            // cmbMoveToLogic
            // 
            this.cmbMoveToLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveToLogic.DropDownWidth = 130;
            this.cmbMoveToLogic.FormattingEnabled = true;
            this.cmbMoveToLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbMoveToLogic.Location = new System.Drawing.Point(117, 161);
            this.cmbMoveToLogic.Name = "cmbMoveToLogic";
            this.cmbMoveToLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbMoveToLogic.TabIndex = 15;
            this.cmbMoveToLogic.SelectedIndexChanged += new System.EventHandler(this.cmbMoveToLogic_SelectedIndexChanged);
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
            this.cmbProductLogic.Location = new System.Drawing.Point(117, 191);
            this.cmbProductLogic.Name = "cmbProductLogic";
            this.cmbProductLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbProductLogic.TabIndex = 16;
            this.cmbProductLogic.SelectedIndexChanged += new System.EventHandler(this.cmbProductLogic_SelectedIndexChanged);
            // 
            // cmbMoveQuantityLogic
            // 
            this.cmbMoveQuantityLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveQuantityLogic.DropDownWidth = 130;
            this.cmbMoveQuantityLogic.FormattingEnabled = true;
            this.cmbMoveQuantityLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbMoveQuantityLogic.Location = new System.Drawing.Point(117, 218);
            this.cmbMoveQuantityLogic.Name = "cmbMoveQuantityLogic";
            this.cmbMoveQuantityLogic.Size = new System.Drawing.Size(112, 21);
            this.cmbMoveQuantityLogic.TabIndex = 17;
            this.cmbMoveQuantityLogic.SelectedIndexChanged += new System.EventHandler(this.cmbMoveQuantityLogic_SelectedIndexChanged);
            // 
            // cmbMovedTo
            // 
            this.cmbMovedTo.FormattingEnabled = true;
            this.cmbMovedTo.Location = new System.Drawing.Point(235, 163);
            this.cmbMovedTo.Name = "cmbMovedTo";
            this.cmbMovedTo.Size = new System.Drawing.Size(213, 21);
            this.cmbMovedTo.TabIndex = 19;
            // 
            // cmbMovedFrom
            // 
            this.cmbMovedFrom.FormattingEnabled = true;
            this.cmbMovedFrom.Location = new System.Drawing.Point(235, 131);
            this.cmbMovedFrom.Name = "cmbMovedFrom";
            this.cmbMovedFrom.Size = new System.Drawing.Size(246, 21);
            this.cmbMovedFrom.TabIndex = 20;
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
            // ckIsDraft
            // 
            this.ckIsDraft.AutoSize = true;
            this.ckIsDraft.Checked = true;
            this.ckIsDraft.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsDraft.Location = new System.Drawing.Point(117, 252);
            this.ckIsDraft.Name = "ckIsDraft";
            this.ckIsDraft.Size = new System.Drawing.Size(70, 17);
            this.ckIsDraft.TabIndex = 30;
            this.ckIsDraft.Text = "Is A Draft";
            this.ckIsDraft.ThreeState = true;
            this.ckIsDraft.UseVisualStyleBackColor = true;
            this.ckIsDraft.CheckedChanged += new System.EventHandler(this.ckIsDraft_CheckedChanged);
            // 
            // ckIsInTrasit
            // 
            this.ckIsInTrasit.AutoSize = true;
            this.ckIsInTrasit.Checked = true;
            this.ckIsInTrasit.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsInTrasit.Location = new System.Drawing.Point(117, 276);
            this.ckIsInTrasit.Name = "ckIsInTrasit";
            this.ckIsInTrasit.Size = new System.Drawing.Size(70, 17);
            this.ckIsInTrasit.TabIndex = 31;
            this.ckIsInTrasit.Text = "In Transit";
            this.ckIsInTrasit.ThreeState = true;
            this.ckIsInTrasit.UseVisualStyleBackColor = true;
            this.ckIsInTrasit.CheckedChanged += new System.EventHandler(this.ckIsInTrasit_CheckedChanged);
            // 
            // ckIsDelivered
            // 
            this.ckIsDelivered.AutoSize = true;
            this.ckIsDelivered.Checked = true;
            this.ckIsDelivered.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsDelivered.Location = new System.Drawing.Point(117, 299);
            this.ckIsDelivered.Name = "ckIsDelivered";
            this.ckIsDelivered.Size = new System.Drawing.Size(82, 17);
            this.ckIsDelivered.TabIndex = 32;
            this.ckIsDelivered.Text = "Is Delivered";
            this.ckIsDelivered.ThreeState = true;
            this.ckIsDelivered.UseVisualStyleBackColor = true;
            this.ckIsDelivered.CheckedChanged += new System.EventHandler(this.ckIsReceived_CheckedChanged);
            // 
            // ckOnDispute
            // 
            this.ckOnDispute.AutoSize = true;
            this.ckOnDispute.Checked = true;
            this.ckOnDispute.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckOnDispute.Location = new System.Drawing.Point(235, 276);
            this.ckOnDispute.Name = "ckOnDispute";
            this.ckOnDispute.Size = new System.Drawing.Size(79, 17);
            this.ckOnDispute.TabIndex = 33;
            this.ckOnDispute.Text = "On Dispute";
            this.ckOnDispute.ThreeState = true;
            this.ckOnDispute.UseVisualStyleBackColor = true;
            this.ckOnDispute.CheckedChanged += new System.EventHandler(this.ckOnDispute_CheckedChanged);
            // 
            // ckIsCancelled
            // 
            this.ckIsCancelled.AutoSize = true;
            this.ckIsCancelled.Checked = true;
            this.ckIsCancelled.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsCancelled.Location = new System.Drawing.Point(235, 299);
            this.ckIsCancelled.Name = "ckIsCancelled";
            this.ckIsCancelled.Size = new System.Drawing.Size(84, 17);
            this.ckIsCancelled.TabIndex = 34;
            this.ckIsCancelled.Text = "Is Cancelled";
            this.ckIsCancelled.ThreeState = true;
            this.ckIsCancelled.UseVisualStyleBackColor = true;
            this.ckIsCancelled.CheckedChanged += new System.EventHandler(this.ckIsCancelled_CheckedChanged);
            // 
            // ckAllOrAny
            // 
            this.ckAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAllOrAny.Location = new System.Drawing.Point(117, 340);
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
            this.cmdSearch.Location = new System.Drawing.Point(194, 404);
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
            this.groupBox1.Controls.Add(this.ckIsAccepted);
            this.groupBox1.Controls.Add(this.ckIsRequest);
            this.groupBox1.Controls.Add(this.txtDocumentNumberTo);
            this.groupBox1.Controls.Add(this.lblOrganisation);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.lblDocumentNumber);
            this.groupBox1.Controls.Add(this.ckAllOrAny);
            this.groupBox1.Controls.Add(this.lblDocumentType);
            this.groupBox1.Controls.Add(this.ckIsCancelled);
            this.groupBox1.Controls.Add(this.lblMovementDate);
            this.groupBox1.Controls.Add(this.ckOnDispute);
            this.groupBox1.Controls.Add(this.lblMoveFrom);
            this.groupBox1.Controls.Add(this.ckIsDelivered);
            this.groupBox1.Controls.Add(this.lblMoveTo);
            this.groupBox1.Controls.Add(this.ckIsInTrasit);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.ckIsDraft);
            this.groupBox1.Controls.Add(this.lblMoveQuantity);
            this.groupBox1.Controls.Add(this.ntbMovementQuantityTo);
            this.groupBox1.Controls.Add(this.cmbOraganisationLogic);
            this.groupBox1.Controls.Add(this.ntbMovementQuantityFrom);
            this.groupBox1.Controls.Add(this.cmbDocumentNumberLogic);
            this.groupBox1.Controls.Add(this.ddgProduct);
            this.groupBox1.Controls.Add(this.cmbDocumentTypeLogic);
            this.groupBox1.Controls.Add(this.dtpMoveDateTo);
            this.groupBox1.Controls.Add(this.cmbMovementDateLogic);
            this.groupBox1.Controls.Add(this.dtpMoveDateFrom);
            this.groupBox1.Controls.Add(this.cmbMoveFromLogic);
            this.groupBox1.Controls.Add(this.cmbDocumentType);
            this.groupBox1.Controls.Add(this.cmbMoveToLogic);
            this.groupBox1.Controls.Add(this.txtDocumentNumberFrom);
            this.groupBox1.Controls.Add(this.cmbProductLogic);
            this.groupBox1.Controls.Add(this.cmbOrganisation);
            this.groupBox1.Controls.Add(this.cmbMoveQuantityLogic);
            this.groupBox1.Controls.Add(this.cmbMovedFrom);
            this.groupBox1.Controls.Add(this.cmbMovedTo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 441);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterion";
            // 
            // cmbSearchAndIncludeToPreviousResult
            // 
            this.cmbSearchAndIncludeToPreviousResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchAndIncludeToPreviousResult.Location = new System.Drawing.Point(174, 370);
            this.cmbSearchAndIncludeToPreviousResult.Name = "cmbSearchAndIncludeToPreviousResult";
            this.cmbSearchAndIncludeToPreviousResult.Size = new System.Drawing.Size(294, 28);
            this.cmbSearchAndIncludeToPreviousResult.TabIndex = 40;
            this.cmbSearchAndIncludeToPreviousResult.Text = "Search And Include To Previous Result";
            this.cmbSearchAndIncludeToPreviousResult.UseVisualStyleBackColor = true;
            this.cmbSearchAndIncludeToPreviousResult.Click += new System.EventHandler(this.cmbSearchAndIncludeToPreviousResult_Click);
            // 
            // ckIsAccepted
            // 
            this.ckIsAccepted.AutoSize = true;
            this.ckIsAccepted.Checked = true;
            this.ckIsAccepted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsAccepted.Location = new System.Drawing.Point(236, 253);
            this.ckIsAccepted.Name = "ckIsAccepted";
            this.ckIsAccepted.Size = new System.Drawing.Size(83, 17);
            this.ckIsAccepted.TabIndex = 39;
            this.ckIsAccepted.Text = "Is Accepted";
            this.ckIsAccepted.ThreeState = true;
            this.ckIsAccepted.UseVisualStyleBackColor = true;
            this.ckIsAccepted.CheckedChanged += new System.EventHandler(this.ckIsAccepted_CheckedChanged);
            // 
            // ckIsRequest
            // 
            this.ckIsRequest.AutoSize = true;
            this.ckIsRequest.Location = new System.Drawing.Point(381, 252);
            this.ckIsRequest.Name = "ckIsRequest";
            this.ckIsRequest.Size = new System.Drawing.Size(87, 17);
            this.ckIsRequest.TabIndex = 38;
            this.ckIsRequest.Text = "Is A Request";
            this.ckIsRequest.UseVisualStyleBackColor = true;
            this.ckIsRequest.CheckedChanged += new System.EventHandler(this.ckIsRequest_CheckedChanged);
            // 
            // txtDocumentNumberTo
            // 
            this.txtDocumentNumberTo.Location = new System.Drawing.Point(399, 45);
            this.txtDocumentNumberTo.Name = "txtDocumentNumberTo";
            this.txtDocumentNumberTo.Size = new System.Drawing.Size(145, 20);
            this.txtDocumentNumberTo.TabIndex = 37;
            // 
            // ntbMovementQuantityTo
            // 
            this.ntbMovementQuantityTo.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMovementQuantityTo.AllowedLength = 0;
            this.ntbMovementQuantityTo.AllowLeadingZeros = false;
            this.ntbMovementQuantityTo.AllowNegative = false;
            this.ntbMovementQuantityTo.Amount = "";
            this.ntbMovementQuantityTo.defaultAmount = "0";
            this.ntbMovementQuantityTo.Location = new System.Drawing.Point(381, 217);
            this.ntbMovementQuantityTo.Name = "ntbMovementQuantityTo";
            this.ntbMovementQuantityTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMovementQuantityTo.ShowThousandSeparetor = true;
            this.ntbMovementQuantityTo.Size = new System.Drawing.Size(136, 23);
            this.ntbMovementQuantityTo.StandardPrecision = 0;
            this.ntbMovementQuantityTo.TabIndex = 29;
            this.ntbMovementQuantityTo.Visible = false;
            // 
            // ntbMovementQuantityFrom
            // 
            this.ntbMovementQuantityFrom.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbMovementQuantityFrom.AllowedLength = 0;
            this.ntbMovementQuantityFrom.AllowLeadingZeros = false;
            this.ntbMovementQuantityFrom.AllowNegative = false;
            this.ntbMovementQuantityFrom.Amount = "";
            this.ntbMovementQuantityFrom.defaultAmount = "0";
            this.ntbMovementQuantityFrom.Location = new System.Drawing.Point(233, 217);
            this.ntbMovementQuantityFrom.Name = "ntbMovementQuantityFrom";
            this.ntbMovementQuantityFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbMovementQuantityFrom.ShowThousandSeparetor = true;
            this.ntbMovementQuantityFrom.Size = new System.Drawing.Size(136, 23);
            this.ntbMovementQuantityFrom.StandardPrecision = 0;
            this.ntbMovementQuantityFrom.TabIndex = 28;
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
            this.ddgProduct.Location = new System.Drawing.Point(230, 187);
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
            // frmSearchInventoryMove
            // 
            this.AcceptButton = this.cmbSearchAndIncludeToPreviousResult;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 441);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchInventoryMove";
            this.Text = "Look-up Movement";
            this.Load += new System.EventHandler(this.frmSearchInventoryMove_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblMovementDate;
        private System.Windows.Forms.Label lblMoveFrom;
        private System.Windows.Forms.Label lblMoveTo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblMoveQuantity;
        private System.Windows.Forms.ComboBox cmbOraganisationLogic;
        private System.Windows.Forms.ComboBox cmbDocumentNumberLogic;
        private System.Windows.Forms.ComboBox cmbDocumentTypeLogic;
        private System.Windows.Forms.ComboBox cmbMovementDateLogic;
        private System.Windows.Forms.ComboBox cmbMoveFromLogic;
        private System.Windows.Forms.ComboBox cmbMoveToLogic;
        private System.Windows.Forms.ComboBox cmbProductLogic;
        private System.Windows.Forms.ComboBox cmbMoveQuantityLogic;
        private System.Windows.Forms.ComboBox cmbMovedTo;
        private System.Windows.Forms.ComboBox cmbMovedFrom;
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.TextBox txtDocumentNumberFrom;
        private System.Windows.Forms.ComboBox cmbDocumentType;
        private System.Windows.Forms.DateTimePicker dtpMoveDateFrom;
        private System.Windows.Forms.DateTimePicker dtpMoveDateTo;
        private DropDownDataGrid ddgProduct;
        private ctlNumberTextBox ntbMovementQuantityFrom;
        private ctlNumberTextBox ntbMovementQuantityTo;
        private System.Windows.Forms.CheckBox ckIsDraft;
        private System.Windows.Forms.CheckBox ckIsInTrasit;
        private System.Windows.Forms.CheckBox ckIsDelivered;
        private System.Windows.Forms.CheckBox ckOnDispute;
        private System.Windows.Forms.CheckBox ckIsCancelled;
        private System.Windows.Forms.CheckBox ckAllOrAny;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDocumentNumberTo;
        private System.Windows.Forms.CheckBox ckIsRequest;
        private System.Windows.Forms.CheckBox ckIsAccepted;
        private System.Windows.Forms.Button cmbSearchAndIncludeToPreviousResult;
    }
}