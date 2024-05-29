namespace EasyMove
{
    partial class frmUserProcessAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserProcessAccess));
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.ckCanCreateNewRequest = new System.Windows.Forms.CheckBox();
            this.ckCanConfirmRequest = new System.Windows.Forms.CheckBox();
            this.ckCanApproveRequest = new System.Windows.Forms.CheckBox();
            this.ckCanRejectRequest = new System.Windows.Forms.CheckBox();
            this.ckCanCreateNewDispatch = new System.Windows.Forms.CheckBox();
            this.ckCanConfirmDispatch = new System.Windows.Forms.CheckBox();
            this.ckCanRefuseDispatch = new System.Windows.Forms.CheckBox();
            this.ckCanAcceptDelivery = new System.Windows.Forms.CheckBox();
            this.ckCanConfirmRecipt = new System.Windows.Forms.CheckBox();
            this.ckCanRejectDelivery = new System.Windows.Forms.CheckBox();
            this.ckCanDisputeDelivery = new System.Windows.Forms.CheckBox();
            this.ckCanAcceptDispute = new System.Windows.Forms.CheckBox();
            this.ckCanRejectDispute = new System.Windows.Forms.CheckBox();
            this.cmdSetUserPrevilage = new System.Windows.Forms.Button();
            this.grbRequest = new System.Windows.Forms.GroupBox();
            this.ckCanViewRequest = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckCanViewDispatch = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckCanViewDelivery = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckCanViewDispute = new System.Windows.Forms.CheckBox();
            this.ckIsActive = new System.Windows.Forms.CheckBox();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.ckCanViewOrder = new System.Windows.Forms.CheckBox();
            this.ckCanCreateNewOrder = new System.Windows.Forms.CheckBox();
            this.ckCanApproveOrder = new System.Windows.Forms.CheckBox();
            this.grbIn = new System.Windows.Forms.GroupBox();
            this.ckCanViewInventoryIn = new System.Windows.Forms.CheckBox();
            this.ckCanCreateInventoryIn = new System.Windows.Forms.CheckBox();
            this.ckCanApproveInventoryIn = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckCanViewInventoryOut = new System.Windows.Forms.CheckBox();
            this.ckCanCreateInventoryOut = new System.Windows.Forms.CheckBox();
            this.ckCanApproveInventoryOut = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ckCanViewInventoryMake = new System.Windows.Forms.CheckBox();
            this.ckCanCreateInventoryMake = new System.Windows.Forms.CheckBox();
            this.ckCanApproveInventoryMake = new System.Windows.Forms.CheckBox();
            this.ddgUserName = new EasyMove.DropDownDataGrid();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckCanViewProductMakeUpChange = new System.Windows.Forms.CheckBox();
            this.ckCanCreateProductMakeUpChange = new System.Windows.Forms.CheckBox();
            this.ckCanApproveProductMakeUpChange = new System.Windows.Forms.CheckBox();
            this.grbRequest.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grbOrder.SuspendLayout();
            this.grbIn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(12, 19);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(70, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(12, 45);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(70, 16);
            this.lblWarehouse.TabIndex = 1;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // lblStation
            // 
            this.lblStation.Location = new System.Drawing.Point(12, 72);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(70, 16);
            this.lblStation.TabIndex = 2;
            this.lblStation.Text = "Staion";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(90, 42);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(269, 21);
            this.cmbWarehouse.TabIndex = 4;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            // 
            // cmbStations
            // 
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(89, 69);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(221, 21);
            this.cmbStations.TabIndex = 5;
            this.cmbStations.SelectedIndexChanged += new System.EventHandler(this.cmbStations_SelectedIndexChanged);
            // 
            // ckCanCreateNewRequest
            // 
            this.ckCanCreateNewRequest.AutoSize = true;
            this.ckCanCreateNewRequest.Location = new System.Drawing.Point(9, 47);
            this.ckCanCreateNewRequest.Name = "ckCanCreateNewRequest";
            this.ckCanCreateNewRequest.Size = new System.Drawing.Size(98, 17);
            this.ckCanCreateNewRequest.TabIndex = 6;
            this.ckCanCreateNewRequest.Text = "Can Creat New";
            this.ckCanCreateNewRequest.UseVisualStyleBackColor = true;
            this.ckCanCreateNewRequest.CheckedChanged += new System.EventHandler(this.ckCanCreateNewRequest_CheckedChanged);
            // 
            // ckCanConfirmRequest
            // 
            this.ckCanConfirmRequest.AutoSize = true;
            this.ckCanConfirmRequest.Location = new System.Drawing.Point(9, 70);
            this.ckCanConfirmRequest.Name = "ckCanConfirmRequest";
            this.ckCanConfirmRequest.Size = new System.Drawing.Size(83, 17);
            this.ckCanConfirmRequest.TabIndex = 7;
            this.ckCanConfirmRequest.Text = "Can Confirm";
            this.ckCanConfirmRequest.UseVisualStyleBackColor = true;
            this.ckCanConfirmRequest.CheckedChanged += new System.EventHandler(this.ckCanConfirmRequest_CheckedChanged);
            // 
            // ckCanApproveRequest
            // 
            this.ckCanApproveRequest.AutoSize = true;
            this.ckCanApproveRequest.Location = new System.Drawing.Point(9, 93);
            this.ckCanApproveRequest.Name = "ckCanApproveRequest";
            this.ckCanApproveRequest.Size = new System.Drawing.Size(88, 17);
            this.ckCanApproveRequest.TabIndex = 8;
            this.ckCanApproveRequest.Text = "Can Approve";
            this.ckCanApproveRequest.UseVisualStyleBackColor = true;
            this.ckCanApproveRequest.CheckedChanged += new System.EventHandler(this.ckCanApproveRequest_CheckedChanged);
            // 
            // ckCanRejectRequest
            // 
            this.ckCanRejectRequest.AutoSize = true;
            this.ckCanRejectRequest.Location = new System.Drawing.Point(9, 116);
            this.ckCanRejectRequest.Name = "ckCanRejectRequest";
            this.ckCanRejectRequest.Size = new System.Drawing.Size(79, 17);
            this.ckCanRejectRequest.TabIndex = 9;
            this.ckCanRejectRequest.Text = "Can Reject";
            this.ckCanRejectRequest.UseVisualStyleBackColor = true;
            this.ckCanRejectRequest.CheckedChanged += new System.EventHandler(this.ckCanRejectRequest_CheckedChanged);
            // 
            // ckCanCreateNewDispatch
            // 
            this.ckCanCreateNewDispatch.AutoSize = true;
            this.ckCanCreateNewDispatch.Location = new System.Drawing.Point(8, 46);
            this.ckCanCreateNewDispatch.Name = "ckCanCreateNewDispatch";
            this.ckCanCreateNewDispatch.Size = new System.Drawing.Size(104, 17);
            this.ckCanCreateNewDispatch.TabIndex = 10;
            this.ckCanCreateNewDispatch.Text = "Can Create New";
            this.ckCanCreateNewDispatch.UseVisualStyleBackColor = true;
            this.ckCanCreateNewDispatch.CheckedChanged += new System.EventHandler(this.ckCanCreateNewDispatch_CheckedChanged);
            // 
            // ckCanConfirmDispatch
            // 
            this.ckCanConfirmDispatch.AutoSize = true;
            this.ckCanConfirmDispatch.Location = new System.Drawing.Point(8, 69);
            this.ckCanConfirmDispatch.Name = "ckCanConfirmDispatch";
            this.ckCanConfirmDispatch.Size = new System.Drawing.Size(83, 17);
            this.ckCanConfirmDispatch.TabIndex = 11;
            this.ckCanConfirmDispatch.Text = "Can Confirm";
            this.ckCanConfirmDispatch.UseVisualStyleBackColor = true;
            this.ckCanConfirmDispatch.CheckedChanged += new System.EventHandler(this.ckCanConfirmDispatch_CheckedChanged);
            // 
            // ckCanRefuseDispatch
            // 
            this.ckCanRefuseDispatch.AutoSize = true;
            this.ckCanRefuseDispatch.Location = new System.Drawing.Point(8, 92);
            this.ckCanRefuseDispatch.Name = "ckCanRefuseDispatch";
            this.ckCanRefuseDispatch.Size = new System.Drawing.Size(82, 17);
            this.ckCanRefuseDispatch.TabIndex = 12;
            this.ckCanRefuseDispatch.Text = "Can Refuse";
            this.ckCanRefuseDispatch.UseVisualStyleBackColor = true;
            this.ckCanRefuseDispatch.CheckedChanged += new System.EventHandler(this.ckCanRefuseDispatch_CheckedChanged);
            // 
            // ckCanAcceptDelivery
            // 
            this.ckCanAcceptDelivery.AutoSize = true;
            this.ckCanAcceptDelivery.Location = new System.Drawing.Point(9, 43);
            this.ckCanAcceptDelivery.Name = "ckCanAcceptDelivery";
            this.ckCanAcceptDelivery.Size = new System.Drawing.Size(82, 17);
            this.ckCanAcceptDelivery.TabIndex = 13;
            this.ckCanAcceptDelivery.Text = "Can Accept";
            this.ckCanAcceptDelivery.UseVisualStyleBackColor = true;
            this.ckCanAcceptDelivery.CheckedChanged += new System.EventHandler(this.ckCanAcceptDelivery_CheckedChanged);
            // 
            // ckCanConfirmRecipt
            // 
            this.ckCanConfirmRecipt.AutoSize = true;
            this.ckCanConfirmRecipt.Location = new System.Drawing.Point(9, 66);
            this.ckCanConfirmRecipt.Name = "ckCanConfirmRecipt";
            this.ckCanConfirmRecipt.Size = new System.Drawing.Size(117, 17);
            this.ckCanConfirmRecipt.TabIndex = 14;
            this.ckCanConfirmRecipt.Text = "Can Confirm Recipt";
            this.ckCanConfirmRecipt.UseVisualStyleBackColor = true;
            this.ckCanConfirmRecipt.CheckedChanged += new System.EventHandler(this.ckCanConfirmRecipt_CheckedChanged);
            // 
            // ckCanRejectDelivery
            // 
            this.ckCanRejectDelivery.AutoSize = true;
            this.ckCanRejectDelivery.Location = new System.Drawing.Point(9, 89);
            this.ckCanRejectDelivery.Name = "ckCanRejectDelivery";
            this.ckCanRejectDelivery.Size = new System.Drawing.Size(79, 17);
            this.ckCanRejectDelivery.TabIndex = 15;
            this.ckCanRejectDelivery.Text = "Can Reject";
            this.ckCanRejectDelivery.UseVisualStyleBackColor = true;
            this.ckCanRejectDelivery.CheckedChanged += new System.EventHandler(this.ckCanRejectDelivery_CheckedChanged);
            // 
            // ckCanDisputeDelivery
            // 
            this.ckCanDisputeDelivery.AutoSize = true;
            this.ckCanDisputeDelivery.Location = new System.Drawing.Point(9, 112);
            this.ckCanDisputeDelivery.Name = "ckCanDisputeDelivery";
            this.ckCanDisputeDelivery.Size = new System.Drawing.Size(84, 17);
            this.ckCanDisputeDelivery.TabIndex = 16;
            this.ckCanDisputeDelivery.Text = "Can Dispute";
            this.ckCanDisputeDelivery.UseVisualStyleBackColor = true;
            this.ckCanDisputeDelivery.CheckedChanged += new System.EventHandler(this.ckCanDisputeDelivery_CheckedChanged);
            // 
            // ckCanAcceptDispute
            // 
            this.ckCanAcceptDispute.AutoSize = true;
            this.ckCanAcceptDispute.Location = new System.Drawing.Point(10, 42);
            this.ckCanAcceptDispute.Name = "ckCanAcceptDispute";
            this.ckCanAcceptDispute.Size = new System.Drawing.Size(82, 17);
            this.ckCanAcceptDispute.TabIndex = 17;
            this.ckCanAcceptDispute.Text = "Can Accept";
            this.ckCanAcceptDispute.UseVisualStyleBackColor = true;
            this.ckCanAcceptDispute.CheckedChanged += new System.EventHandler(this.ckCanAcceptDispute_CheckedChanged);
            // 
            // ckCanRejectDispute
            // 
            this.ckCanRejectDispute.AutoSize = true;
            this.ckCanRejectDispute.Location = new System.Drawing.Point(10, 65);
            this.ckCanRejectDispute.Name = "ckCanRejectDispute";
            this.ckCanRejectDispute.Size = new System.Drawing.Size(79, 17);
            this.ckCanRejectDispute.TabIndex = 18;
            this.ckCanRejectDispute.Text = "Can Reject";
            this.ckCanRejectDispute.UseVisualStyleBackColor = true;
            this.ckCanRejectDispute.CheckedChanged += new System.EventHandler(this.ckCanRejectDispute_CheckedChanged);
            // 
            // cmdSetUserPrevilage
            // 
            this.cmdSetUserPrevilage.Location = new System.Drawing.Point(51, 467);
            this.cmdSetUserPrevilage.Name = "cmdSetUserPrevilage";
            this.cmdSetUserPrevilage.Size = new System.Drawing.Size(348, 40);
            this.cmdSetUserPrevilage.TabIndex = 19;
            this.cmdSetUserPrevilage.Text = "Set Previlage";
            this.cmdSetUserPrevilage.UseVisualStyleBackColor = true;
            this.cmdSetUserPrevilage.Click += new System.EventHandler(this.cmdSetUserPrevilage_Click);
            // 
            // grbRequest
            // 
            this.grbRequest.Controls.Add(this.ckCanViewRequest);
            this.grbRequest.Controls.Add(this.ckCanCreateNewRequest);
            this.grbRequest.Controls.Add(this.ckCanConfirmRequest);
            this.grbRequest.Controls.Add(this.ckCanApproveRequest);
            this.grbRequest.Controls.Add(this.ckCanRejectRequest);
            this.grbRequest.Location = new System.Drawing.Point(12, 140);
            this.grbRequest.Name = "grbRequest";
            this.grbRequest.Size = new System.Drawing.Size(147, 143);
            this.grbRequest.TabIndex = 20;
            this.grbRequest.TabStop = false;
            this.grbRequest.Text = "Requests";
            // 
            // ckCanViewRequest
            // 
            this.ckCanViewRequest.AutoSize = true;
            this.ckCanViewRequest.Location = new System.Drawing.Point(9, 24);
            this.ckCanViewRequest.Name = "ckCanViewRequest";
            this.ckCanViewRequest.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewRequest.TabIndex = 17;
            this.ckCanViewRequest.Text = "Can View";
            this.ckCanViewRequest.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckCanViewDispatch);
            this.groupBox2.Controls.Add(this.ckCanCreateNewDispatch);
            this.groupBox2.Controls.Add(this.ckCanConfirmDispatch);
            this.groupBox2.Controls.Add(this.ckCanRefuseDispatch);
            this.groupBox2.Location = new System.Drawing.Point(167, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 117);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dispatch";
            // 
            // ckCanViewDispatch
            // 
            this.ckCanViewDispatch.AutoSize = true;
            this.ckCanViewDispatch.Location = new System.Drawing.Point(8, 23);
            this.ckCanViewDispatch.Name = "ckCanViewDispatch";
            this.ckCanViewDispatch.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewDispatch.TabIndex = 17;
            this.ckCanViewDispatch.Text = "Can View";
            this.ckCanViewDispatch.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckCanViewDelivery);
            this.groupBox3.Controls.Add(this.ckCanAcceptDelivery);
            this.groupBox3.Controls.Add(this.ckCanConfirmRecipt);
            this.groupBox3.Controls.Add(this.ckCanRejectDelivery);
            this.groupBox3.Controls.Add(this.ckCanDisputeDelivery);
            this.groupBox3.Location = new System.Drawing.Point(12, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(147, 139);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delivery";
            // 
            // ckCanViewDelivery
            // 
            this.ckCanViewDelivery.AutoSize = true;
            this.ckCanViewDelivery.Location = new System.Drawing.Point(9, 20);
            this.ckCanViewDelivery.Name = "ckCanViewDelivery";
            this.ckCanViewDelivery.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewDelivery.TabIndex = 17;
            this.ckCanViewDelivery.Text = "Can View";
            this.ckCanViewDelivery.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckCanViewDispute);
            this.groupBox4.Controls.Add(this.ckCanAcceptDispute);
            this.groupBox4.Controls.Add(this.ckCanRejectDispute);
            this.groupBox4.Location = new System.Drawing.Point(165, 367);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 89);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dispute";
            // 
            // ckCanViewDispute
            // 
            this.ckCanViewDispute.AutoSize = true;
            this.ckCanViewDispute.Location = new System.Drawing.Point(10, 19);
            this.ckCanViewDispute.Name = "ckCanViewDispute";
            this.ckCanViewDispute.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewDispute.TabIndex = 17;
            this.ckCanViewDispute.Text = "Can View";
            this.ckCanViewDispute.UseVisualStyleBackColor = true;
            // 
            // ckIsActive
            // 
            this.ckIsActive.AutoSize = true;
            this.ckIsActive.Checked = true;
            this.ckIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsActive.Location = new System.Drawing.Point(88, 102);
            this.ckIsActive.Name = "ckIsActive";
            this.ckIsActive.Size = new System.Drawing.Size(56, 17);
            this.ckIsActive.TabIndex = 25;
            this.ckIsActive.Text = "Active";
            this.ckIsActive.UseVisualStyleBackColor = true;
            this.ckIsActive.CheckedChanged += new System.EventHandler(this.ckIsActive_CheckedChanged);
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.ckCanViewOrder);
            this.grbOrder.Controls.Add(this.ckCanCreateNewOrder);
            this.grbOrder.Controls.Add(this.ckCanApproveOrder);
            this.grbOrder.Location = new System.Drawing.Point(166, 130);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Size = new System.Drawing.Size(132, 97);
            this.grbOrder.TabIndex = 23;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Dispatch Order";
            // 
            // ckCanViewOrder
            // 
            this.ckCanViewOrder.AutoSize = true;
            this.ckCanViewOrder.Location = new System.Drawing.Point(10, 24);
            this.ckCanViewOrder.Name = "ckCanViewOrder";
            this.ckCanViewOrder.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewOrder.TabIndex = 17;
            this.ckCanViewOrder.Text = "Can View";
            this.ckCanViewOrder.UseVisualStyleBackColor = true;
            // 
            // ckCanCreateNewOrder
            // 
            this.ckCanCreateNewOrder.AutoSize = true;
            this.ckCanCreateNewOrder.Location = new System.Drawing.Point(10, 47);
            this.ckCanCreateNewOrder.Name = "ckCanCreateNewOrder";
            this.ckCanCreateNewOrder.Size = new System.Drawing.Size(79, 17);
            this.ckCanCreateNewOrder.TabIndex = 17;
            this.ckCanCreateNewOrder.Text = "Can Create";
            this.ckCanCreateNewOrder.UseVisualStyleBackColor = true;
            this.ckCanCreateNewOrder.CheckedChanged += new System.EventHandler(this.ckCanCreateNewOrder_CheckedChanged);
            // 
            // ckCanApproveOrder
            // 
            this.ckCanApproveOrder.AutoSize = true;
            this.ckCanApproveOrder.Location = new System.Drawing.Point(10, 70);
            this.ckCanApproveOrder.Name = "ckCanApproveOrder";
            this.ckCanApproveOrder.Size = new System.Drawing.Size(88, 17);
            this.ckCanApproveOrder.TabIndex = 18;
            this.ckCanApproveOrder.Text = "Can Approve";
            this.ckCanApproveOrder.UseVisualStyleBackColor = true;
            this.ckCanApproveOrder.CheckedChanged += new System.EventHandler(this.ckCanApproveOrder_CheckedChanged);
            // 
            // grbIn
            // 
            this.grbIn.Controls.Add(this.ckCanViewInventoryIn);
            this.grbIn.Controls.Add(this.ckCanCreateInventoryIn);
            this.grbIn.Controls.Add(this.ckCanApproveInventoryIn);
            this.grbIn.Location = new System.Drawing.Point(304, 141);
            this.grbIn.Name = "grbIn";
            this.grbIn.Size = new System.Drawing.Size(132, 89);
            this.grbIn.TabIndex = 24;
            this.grbIn.TabStop = false;
            this.grbIn.Text = "Inventory In";
            // 
            // ckCanViewInventoryIn
            // 
            this.ckCanViewInventoryIn.AutoSize = true;
            this.ckCanViewInventoryIn.Location = new System.Drawing.Point(9, 19);
            this.ckCanViewInventoryIn.Name = "ckCanViewInventoryIn";
            this.ckCanViewInventoryIn.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewInventoryIn.TabIndex = 17;
            this.ckCanViewInventoryIn.Text = "Can View";
            this.ckCanViewInventoryIn.UseVisualStyleBackColor = true;
            // 
            // ckCanCreateInventoryIn
            // 
            this.ckCanCreateInventoryIn.AutoSize = true;
            this.ckCanCreateInventoryIn.Location = new System.Drawing.Point(9, 41);
            this.ckCanCreateInventoryIn.Name = "ckCanCreateInventoryIn";
            this.ckCanCreateInventoryIn.Size = new System.Drawing.Size(79, 17);
            this.ckCanCreateInventoryIn.TabIndex = 17;
            this.ckCanCreateInventoryIn.Text = "Can Create";
            this.ckCanCreateInventoryIn.UseVisualStyleBackColor = true;
            this.ckCanCreateInventoryIn.CheckedChanged += new System.EventHandler(this.ckCanCreateInventoryIn_CheckedChanged);
            // 
            // ckCanApproveInventoryIn
            // 
            this.ckCanApproveInventoryIn.AutoSize = true;
            this.ckCanApproveInventoryIn.Location = new System.Drawing.Point(9, 64);
            this.ckCanApproveInventoryIn.Name = "ckCanApproveInventoryIn";
            this.ckCanApproveInventoryIn.Size = new System.Drawing.Size(88, 17);
            this.ckCanApproveInventoryIn.TabIndex = 18;
            this.ckCanApproveInventoryIn.Text = "Can Approve";
            this.ckCanApproveInventoryIn.UseVisualStyleBackColor = true;
            this.ckCanApproveInventoryIn.CheckedChanged += new System.EventHandler(this.ckCanApproveInventoryIn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckCanViewInventoryOut);
            this.groupBox1.Controls.Add(this.ckCanCreateInventoryOut);
            this.groupBox1.Controls.Add(this.ckCanApproveInventoryOut);
            this.groupBox1.Location = new System.Drawing.Point(304, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 90);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Out";
            // 
            // ckCanViewInventoryOut
            // 
            this.ckCanViewInventoryOut.AutoSize = true;
            this.ckCanViewInventoryOut.Location = new System.Drawing.Point(9, 19);
            this.ckCanViewInventoryOut.Name = "ckCanViewInventoryOut";
            this.ckCanViewInventoryOut.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewInventoryOut.TabIndex = 17;
            this.ckCanViewInventoryOut.Text = "Can View";
            this.ckCanViewInventoryOut.UseVisualStyleBackColor = true;
            // 
            // ckCanCreateInventoryOut
            // 
            this.ckCanCreateInventoryOut.AutoSize = true;
            this.ckCanCreateInventoryOut.Location = new System.Drawing.Point(9, 42);
            this.ckCanCreateInventoryOut.Name = "ckCanCreateInventoryOut";
            this.ckCanCreateInventoryOut.Size = new System.Drawing.Size(79, 17);
            this.ckCanCreateInventoryOut.TabIndex = 17;
            this.ckCanCreateInventoryOut.Text = "Can Create";
            this.ckCanCreateInventoryOut.UseVisualStyleBackColor = true;
            this.ckCanCreateInventoryOut.CheckedChanged += new System.EventHandler(this.ckCanCreateInventoryOut_CheckedChanged);
            // 
            // ckCanApproveInventoryOut
            // 
            this.ckCanApproveInventoryOut.AutoSize = true;
            this.ckCanApproveInventoryOut.Location = new System.Drawing.Point(9, 65);
            this.ckCanApproveInventoryOut.Name = "ckCanApproveInventoryOut";
            this.ckCanApproveInventoryOut.Size = new System.Drawing.Size(88, 17);
            this.ckCanApproveInventoryOut.TabIndex = 18;
            this.ckCanApproveInventoryOut.Text = "Can Approve";
            this.ckCanApproveInventoryOut.UseVisualStyleBackColor = true;
            this.ckCanApproveInventoryOut.CheckedChanged += new System.EventHandler(this.ckCanApproveInventoryOut_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ckCanViewInventoryMake);
            this.groupBox5.Controls.Add(this.ckCanCreateInventoryMake);
            this.groupBox5.Controls.Add(this.ckCanApproveInventoryMake);
            this.groupBox5.Location = new System.Drawing.Point(304, 346);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(132, 93);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Inventory Make";
            // 
            // ckCanViewInventoryMake
            // 
            this.ckCanViewInventoryMake.AutoSize = true;
            this.ckCanViewInventoryMake.Location = new System.Drawing.Point(9, 22);
            this.ckCanViewInventoryMake.Name = "ckCanViewInventoryMake";
            this.ckCanViewInventoryMake.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewInventoryMake.TabIndex = 17;
            this.ckCanViewInventoryMake.Text = "Can View";
            this.ckCanViewInventoryMake.UseVisualStyleBackColor = true;
            // 
            // ckCanCreateInventoryMake
            // 
            this.ckCanCreateInventoryMake.AutoSize = true;
            this.ckCanCreateInventoryMake.Location = new System.Drawing.Point(9, 46);
            this.ckCanCreateInventoryMake.Name = "ckCanCreateInventoryMake";
            this.ckCanCreateInventoryMake.Size = new System.Drawing.Size(79, 17);
            this.ckCanCreateInventoryMake.TabIndex = 17;
            this.ckCanCreateInventoryMake.Text = "Can Create";
            this.ckCanCreateInventoryMake.UseVisualStyleBackColor = true;
            this.ckCanCreateInventoryMake.CheckedChanged += new System.EventHandler(this.ckCanCreateInventoryMake_CheckedChanged);
            // 
            // ckCanApproveInventoryMake
            // 
            this.ckCanApproveInventoryMake.AutoSize = true;
            this.ckCanApproveInventoryMake.Location = new System.Drawing.Point(9, 70);
            this.ckCanApproveInventoryMake.Name = "ckCanApproveInventoryMake";
            this.ckCanApproveInventoryMake.Size = new System.Drawing.Size(88, 17);
            this.ckCanApproveInventoryMake.TabIndex = 18;
            this.ckCanApproveInventoryMake.Text = "Can Approve";
            this.ckCanApproveInventoryMake.UseVisualStyleBackColor = true;
            this.ckCanApproveInventoryMake.CheckedChanged += new System.EventHandler(this.ckCanApproveInventoryMake_CheckedChanged);
            // 
            // ddgUserName
            // 
            this.ddgUserName.AutoFilter = true;
            this.ddgUserName.AutoSize = true;
            this.ddgUserName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgUserName.ClearButtonEnabled = true;
            this.ddgUserName.DataTablePrimaryKey = ((ushort)(0));
            this.ddgUserName.FindButtonEnabled = true;
            this.ddgUserName.HiddenColoumns = new int[0];
            this.ddgUserName.Image = null;
            this.ddgUserName.Location = new System.Drawing.Point(86, 10);
            this.ddgUserName.Margin = new System.Windows.Forms.Padding(0);
            this.ddgUserName.Name = "ddgUserName";
            this.ddgUserName.NewButtonEnabled = true;
            this.ddgUserName.RefreshButtonEnabled = true;
            this.ddgUserName.SelectedColomnIdex = 0;
            this.ddgUserName.SelectedItem = "";
            this.ddgUserName.SelectedRowKey = null;
            this.ddgUserName.ShowGridFunctions = false;
            this.ddgUserName.Size = new System.Drawing.Size(350, 31);
            this.ddgUserName.TabIndex = 24;
            this.ddgUserName.SelectedItemClicked += new System.EventHandler(this.ddgUserName_SelectedItemClicked);
            this.ddgUserName.selectedItemChanged += new System.EventHandler(this.ddgUserName_selectedItemChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckCanViewProductMakeUpChange);
            this.groupBox6.Controls.Add(this.ckCanCreateProductMakeUpChange);
            this.groupBox6.Controls.Add(this.ckCanApproveProductMakeUpChange);
            this.groupBox6.Location = new System.Drawing.Point(443, 134);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(132, 116);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Product MakeUp Change";
            // 
            // ckCanViewProductMakeUpChange
            // 
            this.ckCanViewProductMakeUpChange.AutoSize = true;
            this.ckCanViewProductMakeUpChange.Location = new System.Drawing.Point(9, 39);
            this.ckCanViewProductMakeUpChange.Name = "ckCanViewProductMakeUpChange";
            this.ckCanViewProductMakeUpChange.Size = new System.Drawing.Size(71, 17);
            this.ckCanViewProductMakeUpChange.TabIndex = 17;
            this.ckCanViewProductMakeUpChange.Text = "Can View";
            this.ckCanViewProductMakeUpChange.UseVisualStyleBackColor = true;
            // 
            // ckCanCreateProductMakeUpChange
            // 
            this.ckCanCreateProductMakeUpChange.AutoSize = true;
            this.ckCanCreateProductMakeUpChange.Location = new System.Drawing.Point(9, 63);
            this.ckCanCreateProductMakeUpChange.Name = "ckCanCreateProductMakeUpChange";
            this.ckCanCreateProductMakeUpChange.Size = new System.Drawing.Size(79, 17);
            this.ckCanCreateProductMakeUpChange.TabIndex = 17;
            this.ckCanCreateProductMakeUpChange.Text = "Can Create";
            this.ckCanCreateProductMakeUpChange.UseVisualStyleBackColor = true;
            // 
            // ckCanApproveProductMakeUpChange
            // 
            this.ckCanApproveProductMakeUpChange.AutoSize = true;
            this.ckCanApproveProductMakeUpChange.Location = new System.Drawing.Point(9, 87);
            this.ckCanApproveProductMakeUpChange.Name = "ckCanApproveProductMakeUpChange";
            this.ckCanApproveProductMakeUpChange.Size = new System.Drawing.Size(88, 17);
            this.ckCanApproveProductMakeUpChange.TabIndex = 18;
            this.ckCanApproveProductMakeUpChange.Text = "Can Approve";
            this.ckCanApproveProductMakeUpChange.UseVisualStyleBackColor = true;
            // 
            // frmUserProcessAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 519);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbIn);
            this.Controls.Add(this.ckIsActive);
            this.Controls.Add(this.ddgUserName);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbRequest);
            this.Controls.Add(this.cmdSetUserPrevilage);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserProcessAccess";
            this.Text = "User Process Access";
            this.Load += new System.EventHandler(this.frmUserProcessAccess_Load);
            this.grbRequest.ResumeLayout(false);
            this.grbRequest.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            this.grbIn.ResumeLayout(false);
            this.grbIn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.CheckBox ckCanCreateNewRequest;
        private System.Windows.Forms.CheckBox ckCanConfirmRequest;
        private System.Windows.Forms.CheckBox ckCanApproveRequest;
        private System.Windows.Forms.CheckBox ckCanRejectRequest;
        private System.Windows.Forms.CheckBox ckCanCreateNewDispatch;
        private System.Windows.Forms.CheckBox ckCanConfirmDispatch;
        private System.Windows.Forms.CheckBox ckCanRefuseDispatch;
        private System.Windows.Forms.CheckBox ckCanAcceptDelivery;
        private System.Windows.Forms.CheckBox ckCanConfirmRecipt;
        private System.Windows.Forms.CheckBox ckCanRejectDelivery;
        private System.Windows.Forms.CheckBox ckCanDisputeDelivery;
        private System.Windows.Forms.CheckBox ckCanAcceptDispute;
        private System.Windows.Forms.CheckBox ckCanRejectDispute;
        private System.Windows.Forms.Button cmdSetUserPrevilage;
        private System.Windows.Forms.GroupBox grbRequest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private DropDownDataGrid ddgUserName;
        private System.Windows.Forms.CheckBox ckIsActive;
        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.CheckBox ckCanCreateNewOrder;
        private System.Windows.Forms.CheckBox ckCanApproveOrder;
        private System.Windows.Forms.GroupBox grbIn;
        private System.Windows.Forms.CheckBox ckCanCreateInventoryIn;
        private System.Windows.Forms.CheckBox ckCanApproveInventoryIn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckCanCreateInventoryOut;
        private System.Windows.Forms.CheckBox ckCanApproveInventoryOut;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ckCanCreateInventoryMake;
        private System.Windows.Forms.CheckBox ckCanApproveInventoryMake;
        private System.Windows.Forms.CheckBox ckCanViewInventoryMake;
        private System.Windows.Forms.CheckBox ckCanViewInventoryOut;
        private System.Windows.Forms.CheckBox ckCanViewInventoryIn;
        private System.Windows.Forms.CheckBox ckCanViewDispatch;
        private System.Windows.Forms.CheckBox ckCanViewDispute;
        private System.Windows.Forms.CheckBox ckCanViewOrder;
        private System.Windows.Forms.CheckBox ckCanViewRequest;
        private System.Windows.Forms.CheckBox ckCanViewDelivery;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox ckCanViewProductMakeUpChange;
        private System.Windows.Forms.CheckBox ckCanCreateProductMakeUpChange;
        private System.Windows.Forms.CheckBox ckCanApproveProductMakeUpChange;
    }
}