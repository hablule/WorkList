namespace SRP
{
    partial class frmSearchProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchProduct));
            this.lblPrdSrchCode = new System.Windows.Forms.Label();
            this.lblPrdSrchName = new System.Windows.Forms.Label();
            this.lblPrdSrchUPC_EAN = new System.Windows.Forms.Label();
            this.lblPrdSrchCategory = new System.Windows.Forms.Label();
            this.lblPrdSrchUOM = new System.Windows.Forms.Label();
            this.lblPrdSrchType = new System.Windows.Forms.Label();
            this.lblPrdSrchCrrQty = new System.Windows.Forms.Label();
            this.lblPrdSrchCrrCost = new System.Windows.Forms.Label();
            this.lblPrdSrchAccQty = new System.Windows.Forms.Label();
            this.lblPrdSrchAccCost = new System.Windows.Forms.Label();
            this.cmbPrdSrchCodeLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchNameLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchUPC_EANLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchCategoryLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchUOMLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchTypeLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchCrrQtyLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchCrrCostLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchAccQtyLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchAccCostLogic = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchCategory = new System.Windows.Forms.ComboBox();
            this.txtPrdSrchCode = new System.Windows.Forms.TextBox();
            this.txtPrdSrchName = new System.Windows.Forms.TextBox();
            this.txtPrdSrchUPC_EAN = new System.Windows.Forms.TextBox();
            this.cmbPrdSrchType = new System.Windows.Forms.ComboBox();
            this.cmbPrdSrchUOM = new System.Windows.Forms.ComboBox();
            this.ckPrdSrchIsActive = new System.Windows.Forms.CheckBox();
            this.ckPrdSrchAllOrAny = new System.Windows.Forms.CheckBox();
            this.cmdPrdSrchShowResult = new System.Windows.Forms.Button();
            this.cmdPrdSrchShowImages = new System.Windows.Forms.Button();
            this.ntbPrdSrchAccCostTo = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchAccCostFrom = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchAccQtyTo = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchAccQtyFrom = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchCrrCostTo = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchCrrCostFrom = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchCrrQtyTo = new SRP.ctlNumberTextBox();
            this.ntbPrdSrchCrrQtyFrom = new SRP.ctlNumberTextBox();
            this.SuspendLayout();
            // 
            // lblPrdSrchCode
            // 
            this.lblPrdSrchCode.AutoSize = true;
            this.lblPrdSrchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchCode.Location = new System.Drawing.Point(64, 25);
            this.lblPrdSrchCode.Name = "lblPrdSrchCode";
            this.lblPrdSrchCode.Size = new System.Drawing.Size(40, 15);
            this.lblPrdSrchCode.TabIndex = 0;
            this.lblPrdSrchCode.Text = "Code";
            // 
            // lblPrdSrchName
            // 
            this.lblPrdSrchName.AutoSize = true;
            this.lblPrdSrchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchName.Location = new System.Drawing.Point(59, 49);
            this.lblPrdSrchName.Name = "lblPrdSrchName";
            this.lblPrdSrchName.Size = new System.Drawing.Size(45, 15);
            this.lblPrdSrchName.TabIndex = 1;
            this.lblPrdSrchName.Text = "Name";
            // 
            // lblPrdSrchUPC_EAN
            // 
            this.lblPrdSrchUPC_EAN.AutoSize = true;
            this.lblPrdSrchUPC_EAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchUPC_EAN.Location = new System.Drawing.Point(38, 72);
            this.lblPrdSrchUPC_EAN.Name = "lblPrdSrchUPC_EAN";
            this.lblPrdSrchUPC_EAN.Size = new System.Drawing.Size(66, 15);
            this.lblPrdSrchUPC_EAN.TabIndex = 2;
            this.lblPrdSrchUPC_EAN.Text = "UPC/EAN";
            // 
            // lblPrdSrchCategory
            // 
            this.lblPrdSrchCategory.AutoSize = true;
            this.lblPrdSrchCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchCategory.Location = new System.Drawing.Point(41, 96);
            this.lblPrdSrchCategory.Name = "lblPrdSrchCategory";
            this.lblPrdSrchCategory.Size = new System.Drawing.Size(63, 15);
            this.lblPrdSrchCategory.TabIndex = 3;
            this.lblPrdSrchCategory.Text = "Category";
            // 
            // lblPrdSrchUOM
            // 
            this.lblPrdSrchUOM.AutoSize = true;
            this.lblPrdSrchUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchUOM.Location = new System.Drawing.Point(65, 120);
            this.lblPrdSrchUOM.Name = "lblPrdSrchUOM";
            this.lblPrdSrchUOM.Size = new System.Drawing.Size(39, 15);
            this.lblPrdSrchUOM.TabIndex = 4;
            this.lblPrdSrchUOM.Text = "UOM";
            // 
            // lblPrdSrchType
            // 
            this.lblPrdSrchType.AutoSize = true;
            this.lblPrdSrchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchType.Location = new System.Drawing.Point(67, 144);
            this.lblPrdSrchType.Name = "lblPrdSrchType";
            this.lblPrdSrchType.Size = new System.Drawing.Size(37, 15);
            this.lblPrdSrchType.TabIndex = 5;
            this.lblPrdSrchType.Text = "Type";
            // 
            // lblPrdSrchCrrQty
            // 
            this.lblPrdSrchCrrQty.AutoSize = true;
            this.lblPrdSrchCrrQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchCrrQty.Location = new System.Drawing.Point(26, 168);
            this.lblPrdSrchCrrQty.Name = "lblPrdSrchCrrQty";
            this.lblPrdSrchCrrQty.Size = new System.Drawing.Size(78, 15);
            this.lblPrdSrchCrrQty.TabIndex = 6;
            this.lblPrdSrchCrrQty.Text = "Current Qty";
            // 
            // lblPrdSrchCrrCost
            // 
            this.lblPrdSrchCrrCost.AutoSize = true;
            this.lblPrdSrchCrrCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchCrrCost.Location = new System.Drawing.Point(18, 192);
            this.lblPrdSrchCrrCost.Name = "lblPrdSrchCrrCost";
            this.lblPrdSrchCrrCost.Size = new System.Drawing.Size(86, 15);
            this.lblPrdSrchCrrCost.TabIndex = 7;
            this.lblPrdSrchCrrCost.Text = "Current Cost";
            // 
            // lblPrdSrchAccQty
            // 
            this.lblPrdSrchAccQty.AutoSize = true;
            this.lblPrdSrchAccQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchAccQty.Location = new System.Drawing.Point(47, 216);
            this.lblPrdSrchAccQty.Name = "lblPrdSrchAccQty";
            this.lblPrdSrchAccQty.Size = new System.Drawing.Size(57, 15);
            this.lblPrdSrchAccQty.TabIndex = 8;
            this.lblPrdSrchAccQty.Text = "Acc. Qty";
            // 
            // lblPrdSrchAccCost
            // 
            this.lblPrdSrchAccCost.AutoSize = true;
            this.lblPrdSrchAccCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrdSrchAccCost.Location = new System.Drawing.Point(39, 240);
            this.lblPrdSrchAccCost.Name = "lblPrdSrchAccCost";
            this.lblPrdSrchAccCost.Size = new System.Drawing.Size(65, 15);
            this.lblPrdSrchAccCost.TabIndex = 9;
            this.lblPrdSrchAccCost.Text = "Acc. Cost";
            // 
            // cmbPrdSrchCodeLogic
            // 
            this.cmbPrdSrchCodeLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchCodeLogic.FormattingEnabled = true;
            this.cmbPrdSrchCodeLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbPrdSrchCodeLogic.Location = new System.Drawing.Point(117, 21);
            this.cmbPrdSrchCodeLogic.Name = "cmbPrdSrchCodeLogic";
            this.cmbPrdSrchCodeLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchCodeLogic.TabIndex = 10;
            this.cmbPrdSrchCodeLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchCodeLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchNameLogic
            // 
            this.cmbPrdSrchNameLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchNameLogic.FormattingEnabled = true;
            this.cmbPrdSrchNameLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Similar to",
            "Not Similar to"});
            this.cmbPrdSrchNameLogic.Location = new System.Drawing.Point(117, 45);
            this.cmbPrdSrchNameLogic.Name = "cmbPrdSrchNameLogic";
            this.cmbPrdSrchNameLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchNameLogic.TabIndex = 11;
            this.cmbPrdSrchNameLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchNameLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchUPC_EANLogic
            // 
            this.cmbPrdSrchUPC_EANLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchUPC_EANLogic.FormattingEnabled = true;
            this.cmbPrdSrchUPC_EANLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPrdSrchUPC_EANLogic.Location = new System.Drawing.Point(117, 69);
            this.cmbPrdSrchUPC_EANLogic.Name = "cmbPrdSrchUPC_EANLogic";
            this.cmbPrdSrchUPC_EANLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchUPC_EANLogic.TabIndex = 12;
            this.cmbPrdSrchUPC_EANLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchUPC_EANLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchCategoryLogic
            // 
            this.cmbPrdSrchCategoryLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchCategoryLogic.FormattingEnabled = true;
            this.cmbPrdSrchCategoryLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPrdSrchCategoryLogic.Location = new System.Drawing.Point(117, 93);
            this.cmbPrdSrchCategoryLogic.Name = "cmbPrdSrchCategoryLogic";
            this.cmbPrdSrchCategoryLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchCategoryLogic.TabIndex = 13;
            this.cmbPrdSrchCategoryLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchCategoryLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchUOMLogic
            // 
            this.cmbPrdSrchUOMLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchUOMLogic.FormattingEnabled = true;
            this.cmbPrdSrchUOMLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPrdSrchUOMLogic.Location = new System.Drawing.Point(117, 117);
            this.cmbPrdSrchUOMLogic.Name = "cmbPrdSrchUOMLogic";
            this.cmbPrdSrchUOMLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchUOMLogic.TabIndex = 14;
            this.cmbPrdSrchUOMLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchUOMLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchTypeLogic
            // 
            this.cmbPrdSrchTypeLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchTypeLogic.FormattingEnabled = true;
            this.cmbPrdSrchTypeLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to"});
            this.cmbPrdSrchTypeLogic.Location = new System.Drawing.Point(117, 141);
            this.cmbPrdSrchTypeLogic.Name = "cmbPrdSrchTypeLogic";
            this.cmbPrdSrchTypeLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchTypeLogic.TabIndex = 15;
            this.cmbPrdSrchTypeLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchTypeLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchCrrQtyLogic
            // 
            this.cmbPrdSrchCrrQtyLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchCrrQtyLogic.FormattingEnabled = true;
            this.cmbPrdSrchCrrQtyLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbPrdSrchCrrQtyLogic.Location = new System.Drawing.Point(117, 165);
            this.cmbPrdSrchCrrQtyLogic.Name = "cmbPrdSrchCrrQtyLogic";
            this.cmbPrdSrchCrrQtyLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchCrrQtyLogic.TabIndex = 16;
            this.cmbPrdSrchCrrQtyLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchCrrQtyLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchCrrCostLogic
            // 
            this.cmbPrdSrchCrrCostLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchCrrCostLogic.FormattingEnabled = true;
            this.cmbPrdSrchCrrCostLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbPrdSrchCrrCostLogic.Location = new System.Drawing.Point(117, 189);
            this.cmbPrdSrchCrrCostLogic.Name = "cmbPrdSrchCrrCostLogic";
            this.cmbPrdSrchCrrCostLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchCrrCostLogic.TabIndex = 17;
            this.cmbPrdSrchCrrCostLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchCrrCostLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchAccQtyLogic
            // 
            this.cmbPrdSrchAccQtyLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchAccQtyLogic.FormattingEnabled = true;
            this.cmbPrdSrchAccQtyLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbPrdSrchAccQtyLogic.Location = new System.Drawing.Point(117, 213);
            this.cmbPrdSrchAccQtyLogic.Name = "cmbPrdSrchAccQtyLogic";
            this.cmbPrdSrchAccQtyLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchAccQtyLogic.TabIndex = 18;
            this.cmbPrdSrchAccQtyLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchAccQtyLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchAccCostLogic
            // 
            this.cmbPrdSrchAccCostLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchAccCostLogic.FormattingEnabled = true;
            this.cmbPrdSrchAccCostLogic.Items.AddRange(new object[] {
            "IGNOR",
            "Equals to",
            "Not equals to",
            "Greater than",
            "Greater or equals to",
            "Less than",
            "Lesser or equal to",
            "In between of"});
            this.cmbPrdSrchAccCostLogic.Location = new System.Drawing.Point(117, 237);
            this.cmbPrdSrchAccCostLogic.Name = "cmbPrdSrchAccCostLogic";
            this.cmbPrdSrchAccCostLogic.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchAccCostLogic.TabIndex = 19;
            this.cmbPrdSrchAccCostLogic.SelectedIndexChanged += new System.EventHandler(this.cmbPrdSrchAccCostLogic_SelectedIndexChanged);
            // 
            // cmbPrdSrchCategory
            // 
            this.cmbPrdSrchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchCategory.FormattingEnabled = true;
            this.cmbPrdSrchCategory.Location = new System.Drawing.Point(234, 93);
            this.cmbPrdSrchCategory.Name = "cmbPrdSrchCategory";
            this.cmbPrdSrchCategory.Size = new System.Drawing.Size(148, 21);
            this.cmbPrdSrchCategory.TabIndex = 20;
            // 
            // txtPrdSrchCode
            // 
            this.txtPrdSrchCode.Location = new System.Drawing.Point(234, 22);
            this.txtPrdSrchCode.Name = "txtPrdSrchCode";
            this.txtPrdSrchCode.Size = new System.Drawing.Size(185, 20);
            this.txtPrdSrchCode.TabIndex = 21;
            // 
            // txtPrdSrchName
            // 
            this.txtPrdSrchName.Location = new System.Drawing.Point(234, 46);
            this.txtPrdSrchName.Name = "txtPrdSrchName";
            this.txtPrdSrchName.Size = new System.Drawing.Size(226, 20);
            this.txtPrdSrchName.TabIndex = 22;
            // 
            // txtPrdSrchUPC_EAN
            // 
            this.txtPrdSrchUPC_EAN.Location = new System.Drawing.Point(234, 70);
            this.txtPrdSrchUPC_EAN.Name = "txtPrdSrchUPC_EAN";
            this.txtPrdSrchUPC_EAN.Size = new System.Drawing.Size(173, 20);
            this.txtPrdSrchUPC_EAN.TabIndex = 23;
            // 
            // cmbPrdSrchType
            // 
            this.cmbPrdSrchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchType.FormattingEnabled = true;
            this.cmbPrdSrchType.Items.AddRange(new object[] {
            "Item",
            "Service"});
            this.cmbPrdSrchType.Location = new System.Drawing.Point(234, 143);
            this.cmbPrdSrchType.Name = "cmbPrdSrchType";
            this.cmbPrdSrchType.Size = new System.Drawing.Size(83, 21);
            this.cmbPrdSrchType.TabIndex = 24;
            // 
            // cmbPrdSrchUOM
            // 
            this.cmbPrdSrchUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrdSrchUOM.FormattingEnabled = true;
            this.cmbPrdSrchUOM.Location = new System.Drawing.Point(234, 118);
            this.cmbPrdSrchUOM.Name = "cmbPrdSrchUOM";
            this.cmbPrdSrchUOM.Size = new System.Drawing.Size(109, 21);
            this.cmbPrdSrchUOM.TabIndex = 25;
            // 
            // ckPrdSrchIsActive
            // 
            this.ckPrdSrchIsActive.AutoSize = true;
            this.ckPrdSrchIsActive.Checked = true;
            this.ckPrdSrchIsActive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckPrdSrchIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPrdSrchIsActive.Location = new System.Drawing.Point(109, 264);
            this.ckPrdSrchIsActive.Name = "ckPrdSrchIsActive";
            this.ckPrdSrchIsActive.Size = new System.Drawing.Size(78, 19);
            this.ckPrdSrchIsActive.TabIndex = 30;
            this.ckPrdSrchIsActive.Text = "Is Active";
            this.ckPrdSrchIsActive.ThreeState = true;
            this.ckPrdSrchIsActive.UseVisualStyleBackColor = true;
            // 
            // ckPrdSrchAllOrAny
            // 
            this.ckPrdSrchAllOrAny.AutoSize = true;
            this.ckPrdSrchAllOrAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPrdSrchAllOrAny.Location = new System.Drawing.Point(109, 304);
            this.ckPrdSrchAllOrAny.Name = "ckPrdSrchAllOrAny";
            this.ckPrdSrchAllOrAny.Size = new System.Drawing.Size(87, 19);
            this.ckPrdSrchAllOrAny.TabIndex = 31;
            this.ckPrdSrchAllOrAny.Text = "All Or Any";
            this.ckPrdSrchAllOrAny.UseVisualStyleBackColor = true;
            // 
            // cmdPrdSrchShowResult
            // 
            this.cmdPrdSrchShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrdSrchShowResult.Location = new System.Drawing.Point(234, 295);
            this.cmdPrdSrchShowResult.Name = "cmdPrdSrchShowResult";
            this.cmdPrdSrchShowResult.Size = new System.Drawing.Size(109, 36);
            this.cmdPrdSrchShowResult.TabIndex = 32;
            this.cmdPrdSrchShowResult.Text = "Show Result";
            this.cmdPrdSrchShowResult.UseVisualStyleBackColor = true;
            this.cmdPrdSrchShowResult.Click += new System.EventHandler(this.cmdPrdSrchShowResult_Click);
            // 
            // cmdPrdSrchShowImages
            // 
            this.cmdPrdSrchShowImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrdSrchShowImages.Location = new System.Drawing.Point(232, 262);
            this.cmdPrdSrchShowImages.Name = "cmdPrdSrchShowImages";
            this.cmdPrdSrchShowImages.Size = new System.Drawing.Size(64, 27);
            this.cmdPrdSrchShowImages.TabIndex = 34;
            this.cmdPrdSrchShowImages.Text = "Img...";
            this.cmdPrdSrchShowImages.UseVisualStyleBackColor = true;
            this.cmdPrdSrchShowImages.Click += new System.EventHandler(this.cmdPrdSrchShowImages_Click);
            // 
            // ntbPrdSrchAccCostTo
            // 
            this.ntbPrdSrchAccCostTo.Amount = "";
            this.ntbPrdSrchAccCostTo.Location = new System.Drawing.Point(361, 237);
            this.ntbPrdSrchAccCostTo.Name = "ntbPrdSrchAccCostTo";
            this.ntbPrdSrchAccCostTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchAccCostTo.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchAccCostTo.StandardPrecision = 2;
            this.ntbPrdSrchAccCostTo.TabIndex = 29;
            // 
            // ntbPrdSrchAccCostFrom
            // 
            this.ntbPrdSrchAccCostFrom.Amount = "";
            this.ntbPrdSrchAccCostFrom.Location = new System.Drawing.Point(232, 237);
            this.ntbPrdSrchAccCostFrom.Name = "ntbPrdSrchAccCostFrom";
            this.ntbPrdSrchAccCostFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchAccCostFrom.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchAccCostFrom.StandardPrecision = 2;
            this.ntbPrdSrchAccCostFrom.TabIndex = 29;
            // 
            // ntbPrdSrchAccQtyTo
            // 
            this.ntbPrdSrchAccQtyTo.Amount = "";
            this.ntbPrdSrchAccQtyTo.Location = new System.Drawing.Point(361, 213);
            this.ntbPrdSrchAccQtyTo.Name = "ntbPrdSrchAccQtyTo";
            this.ntbPrdSrchAccQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchAccQtyTo.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchAccQtyTo.StandardPrecision = 2;
            this.ntbPrdSrchAccQtyTo.TabIndex = 28;
            // 
            // ntbPrdSrchAccQtyFrom
            // 
            this.ntbPrdSrchAccQtyFrom.Amount = "";
            this.ntbPrdSrchAccQtyFrom.Location = new System.Drawing.Point(232, 213);
            this.ntbPrdSrchAccQtyFrom.Name = "ntbPrdSrchAccQtyFrom";
            this.ntbPrdSrchAccQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchAccQtyFrom.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchAccQtyFrom.StandardPrecision = 2;
            this.ntbPrdSrchAccQtyFrom.TabIndex = 28;
            // 
            // ntbPrdSrchCrrCostTo
            // 
            this.ntbPrdSrchCrrCostTo.Amount = "";
            this.ntbPrdSrchCrrCostTo.Location = new System.Drawing.Point(361, 189);
            this.ntbPrdSrchCrrCostTo.Name = "ntbPrdSrchCrrCostTo";
            this.ntbPrdSrchCrrCostTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchCrrCostTo.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchCrrCostTo.StandardPrecision = 2;
            this.ntbPrdSrchCrrCostTo.TabIndex = 27;
            // 
            // ntbPrdSrchCrrCostFrom
            // 
            this.ntbPrdSrchCrrCostFrom.Amount = "";
            this.ntbPrdSrchCrrCostFrom.Location = new System.Drawing.Point(232, 189);
            this.ntbPrdSrchCrrCostFrom.Name = "ntbPrdSrchCrrCostFrom";
            this.ntbPrdSrchCrrCostFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchCrrCostFrom.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchCrrCostFrom.StandardPrecision = 2;
            this.ntbPrdSrchCrrCostFrom.TabIndex = 27;
            // 
            // ntbPrdSrchCrrQtyTo
            // 
            this.ntbPrdSrchCrrQtyTo.Amount = "";
            this.ntbPrdSrchCrrQtyTo.Location = new System.Drawing.Point(361, 165);
            this.ntbPrdSrchCrrQtyTo.Name = "ntbPrdSrchCrrQtyTo";
            this.ntbPrdSrchCrrQtyTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchCrrQtyTo.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchCrrQtyTo.StandardPrecision = 2;
            this.ntbPrdSrchCrrQtyTo.TabIndex = 26;
            // 
            // ntbPrdSrchCrrQtyFrom
            // 
            this.ntbPrdSrchCrrQtyFrom.Amount = "";
            this.ntbPrdSrchCrrQtyFrom.Location = new System.Drawing.Point(232, 165);
            this.ntbPrdSrchCrrQtyFrom.Name = "ntbPrdSrchCrrQtyFrom";
            this.ntbPrdSrchCrrQtyFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbPrdSrchCrrQtyFrom.Size = new System.Drawing.Size(123, 23);
            this.ntbPrdSrchCrrQtyFrom.StandardPrecision = 2;
            this.ntbPrdSrchCrrQtyFrom.TabIndex = 26;
            // 
            // frmSearchProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 340);
            this.Controls.Add(this.cmdPrdSrchShowImages);
            this.Controls.Add(this.cmdPrdSrchShowResult);
            this.Controls.Add(this.ckPrdSrchAllOrAny);
            this.Controls.Add(this.ckPrdSrchIsActive);
            this.Controls.Add(this.ntbPrdSrchAccCostTo);
            this.Controls.Add(this.ntbPrdSrchAccCostFrom);
            this.Controls.Add(this.ntbPrdSrchAccQtyTo);
            this.Controls.Add(this.ntbPrdSrchAccQtyFrom);
            this.Controls.Add(this.ntbPrdSrchCrrCostTo);
            this.Controls.Add(this.ntbPrdSrchCrrCostFrom);
            this.Controls.Add(this.ntbPrdSrchCrrQtyTo);
            this.Controls.Add(this.ntbPrdSrchCrrQtyFrom);
            this.Controls.Add(this.cmbPrdSrchUOM);
            this.Controls.Add(this.cmbPrdSrchType);
            this.Controls.Add(this.txtPrdSrchUPC_EAN);
            this.Controls.Add(this.txtPrdSrchName);
            this.Controls.Add(this.txtPrdSrchCode);
            this.Controls.Add(this.cmbPrdSrchCategory);
            this.Controls.Add(this.cmbPrdSrchAccCostLogic);
            this.Controls.Add(this.cmbPrdSrchAccQtyLogic);
            this.Controls.Add(this.cmbPrdSrchCrrCostLogic);
            this.Controls.Add(this.cmbPrdSrchCrrQtyLogic);
            this.Controls.Add(this.cmbPrdSrchTypeLogic);
            this.Controls.Add(this.cmbPrdSrchUOMLogic);
            this.Controls.Add(this.cmbPrdSrchCategoryLogic);
            this.Controls.Add(this.cmbPrdSrchUPC_EANLogic);
            this.Controls.Add(this.cmbPrdSrchNameLogic);
            this.Controls.Add(this.cmbPrdSrchCodeLogic);
            this.Controls.Add(this.lblPrdSrchAccCost);
            this.Controls.Add(this.lblPrdSrchAccQty);
            this.Controls.Add(this.lblPrdSrchCrrCost);
            this.Controls.Add(this.lblPrdSrchCrrQty);
            this.Controls.Add(this.lblPrdSrchType);
            this.Controls.Add(this.lblPrdSrchUOM);
            this.Controls.Add(this.lblPrdSrchCategory);
            this.Controls.Add(this.lblPrdSrchUPC_EAN);
            this.Controls.Add(this.lblPrdSrchName);
            this.Controls.Add(this.lblPrdSrchCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchProduct";
            this.Text = "Search Product";
            this.Load += new System.EventHandler(this.frmSearchProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrdSrchCode;
        private System.Windows.Forms.Label lblPrdSrchName;
        private System.Windows.Forms.Label lblPrdSrchUPC_EAN;
        private System.Windows.Forms.Label lblPrdSrchCategory;
        private System.Windows.Forms.Label lblPrdSrchUOM;
        private System.Windows.Forms.Label lblPrdSrchType;
        private System.Windows.Forms.Label lblPrdSrchCrrQty;
        private System.Windows.Forms.Label lblPrdSrchCrrCost;
        private System.Windows.Forms.Label lblPrdSrchAccQty;
        private System.Windows.Forms.Label lblPrdSrchAccCost;
        private System.Windows.Forms.ComboBox cmbPrdSrchCodeLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchNameLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchUPC_EANLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchCategoryLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchUOMLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchTypeLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchCrrQtyLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchCrrCostLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchAccQtyLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchAccCostLogic;
        private System.Windows.Forms.ComboBox cmbPrdSrchCategory;
        private System.Windows.Forms.TextBox txtPrdSrchCode;
        private System.Windows.Forms.TextBox txtPrdSrchName;
        private System.Windows.Forms.TextBox txtPrdSrchUPC_EAN;
        private System.Windows.Forms.ComboBox cmbPrdSrchType;
        private System.Windows.Forms.ComboBox cmbPrdSrchUOM;
        private ctlNumberTextBox ntbPrdSrchCrrQtyFrom;
        private ctlNumberTextBox ntbPrdSrchCrrCostFrom;
        private ctlNumberTextBox ntbPrdSrchAccQtyFrom;
        private ctlNumberTextBox ntbPrdSrchAccCostFrom;
        private System.Windows.Forms.CheckBox ckPrdSrchIsActive;
        private System.Windows.Forms.CheckBox ckPrdSrchAllOrAny;
        private System.Windows.Forms.Button cmdPrdSrchShowResult;
        private System.Windows.Forms.Button cmdPrdSrchShowImages;
        private ctlNumberTextBox ntbPrdSrchCrrQtyTo;
        private ctlNumberTextBox ntbPrdSrchCrrCostTo;
        private ctlNumberTextBox ntbPrdSrchAccQtyTo;
        private ctlNumberTextBox ntbPrdSrchAccCostTo;
    }
}