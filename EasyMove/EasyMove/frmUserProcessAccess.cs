using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyMove
{
    public partial class frmUserProcessAccess : Form
    {
        public frmUserProcessAccess()
        {
            InitializeComponent();
        }

        string stCurrentUserID = "";
        string stCurrentStationID = "";
        string stCurrentWarehouseID = "";
        

        DataTable dtAllUserNames = new DataTable();
        DataTable dtAllWarehouse = new DataTable();
        DataTable dtAllStations = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();


        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            int arraySize = dataSourceTable.Rows.Count;
            string[] arrayItems = new string[arraySize];
            string[] tempArray = { "" };
            if (!getDataFromDb.checkIfTableContainesData(dataSourceTable))
                return;

            if (!dataSourceTable.Columns.Contains("_Index"))
            {
                dataSourceTable.Columns.Add("_Index", System.Type.GetType("System.Int16"));

                for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
                {
                    dataSourceTable.Rows[rowCounter]["_Index"] = rowCounter;
                    //tempArray[0] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();
                    //Array.Copy(tempArray, 0, arrayItems, rowCounter, 1);
                }
            }

            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                arrayItems[rowCounter] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();
                //Array.Copy(tempArray, 0, arrayItems, rowCounter, 1);
            }
            _comboBoxContorl.Items.AddRange(arrayItems);

            if (selectedIndex >= 0 &&
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }

        private void fillUserPrevilage() 
        {
            if (this.ddgUserName.SelectedRow.Rows.Count <= 0 ||
                this.dtAllStations.Rows.Count <= 0 ||
                this.dtAllWarehouse.Rows.Count <= 0)
            {
                return;
            }

            if (this.ddgUserName.SelectedRowKey.ToString() == "" ||
                this.cmbStations.SelectedIndex >= this.dtAllStations.Rows.Count ||
                this.cmbStations.SelectedIndex < 0 ||
                this.cmbWarehouse.SelectedIndex >= this.dtAllWarehouse.Rows.Count ||
                this.cmbWarehouse.SelectedIndex < 0)
            {
                goto clearForm;
            }
           
            DataTable userProcessAccess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(null, "",
                                                        this.dtAllWarehouse.Rows
                                                                [this.cmbWarehouse.SelectedIndex]
                                                                ["M_WAREHOUSE_ID"].ToString(),
                                                        this.ddgUserName.SelectedRowKey.ToString(),
                                                        this.dtAllStations.Rows
                                                                [this.cmbStations.SelectedIndex]
                                                                ["EM_STATION_ID"].ToString(),
                                                        false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(userProcessAccess))
            {

                this.ckIsActive.Checked =
                        userProcessAccess.Rows[0]["ISACTIVE"].ToString() == "Y";

                this.ckCanViewRequest.Checked =
                    userProcessAccess.Rows[0]["VIEWREQUEST"].ToString() == "Y";
                this.ckCanCreateNewRequest.Checked =
                    userProcessAccess.Rows[0]["CREATEREQUEST"].ToString() == "Y";
                this.ckCanConfirmRequest.Checked =
                    userProcessAccess.Rows[0]["CONFIRMREQUEST"].ToString() == "Y";
                this.ckCanApproveRequest.Checked =
                    userProcessAccess.Rows[0]["APPROVEREQUEST"].ToString() == "Y";
                this.ckCanRejectRequest.Checked =
                    userProcessAccess.Rows[0]["REJECTREQUEST"].ToString() == "Y";


                this.ckCanViewOrder.Checked =
                    userProcessAccess.Rows[0]["VIEWDISPATCHORDER"].ToString() == "Y";
                this.ckCanCreateNewOrder.Checked =
                    userProcessAccess.Rows[0]["CREATEDISPATCHORDER"].ToString() == "Y";
                this.ckCanApproveOrder.Checked =
                    userProcessAccess.Rows[0]["CONFIRMDISPATCHORDER"].ToString() == "Y";


                this.ckCanViewDispatch.Checked =
                    userProcessAccess.Rows[0]["VIEWDISPATCH"].ToString() == "Y";
                this.ckCanCreateNewDispatch.Checked =
                    userProcessAccess.Rows[0]["CREATEDISPATCH"].ToString() == "Y";
                this.ckCanConfirmDispatch.Checked =
                    userProcessAccess.Rows[0]["CONFIRMDISPATCH"].ToString() == "Y";
                this.ckCanRefuseDispatch.Checked =
                    userProcessAccess.Rows[0]["REFUSEDISPATCH"].ToString() == "Y";


                this.ckCanViewDelivery.Checked =
                    userProcessAccess.Rows[0]["VIEWDELIVERY"].ToString() == "Y";
                this.ckCanAcceptDelivery.Checked =
                    userProcessAccess.Rows[0]["ACCEPTDELIVERY"].ToString() == "Y";
                this.ckCanConfirmRecipt.Checked =
                    userProcessAccess.Rows[0]["CONFIRMRECIPT"].ToString() == "Y";
                this.ckCanRejectDelivery.Checked =
                    userProcessAccess.Rows[0]["REJECTDELIVERY"].ToString() == "Y";
                this.ckCanDisputeDelivery.Checked =
                    userProcessAccess.Rows[0]["DISPUTEDELIVERY"].ToString() == "Y";


                this.ckCanViewDispute.Checked =
                   userProcessAccess.Rows[0]["VIEWDISPUTE"].ToString() == "Y";
                this.ckCanAcceptDispute.Checked =
                    userProcessAccess.Rows[0]["ACCEPTDISPUTE"].ToString() == "Y";
                this.ckCanRejectDispute.Checked =
                    userProcessAccess.Rows[0]["REJECTDISPUTE"].ToString() == "Y";


                this.ckCanViewInventoryIn.Checked =
                    userProcessAccess.Rows[0]["VIEWINVENTORYIN"].ToString() == "Y";
                this.ckCanCreateInventoryIn.Checked =
                    userProcessAccess.Rows[0]["CREATEINVENTORYIN"].ToString() == "Y";
                this.ckCanApproveInventoryIn.Checked =
                    userProcessAccess.Rows[0]["CONFIRMINVENTORYIN"].ToString() == "Y";


                this.ckCanViewInventoryOut.Checked =
                    userProcessAccess.Rows[0]["VIEWINVENTORYOUT"].ToString() == "Y";
                this.ckCanCreateInventoryOut.Checked =
                    userProcessAccess.Rows[0]["CREATEINVENTORYOUT"].ToString() == "Y";
                this.ckCanApproveInventoryOut.Checked =
                    userProcessAccess.Rows[0]["CONFIRMINVENTORYOUT"].ToString() == "Y";


                this.ckCanViewInventoryMake.Checked =
                    userProcessAccess.Rows[0]["VIEWINVENTORYMAKE"].ToString() == "Y";
                this.ckCanCreateInventoryMake.Checked =
                    userProcessAccess.Rows[0]["CREATEINVENTORYMAKE"].ToString() == "Y";
                this.ckCanApproveInventoryMake.Checked =
                    userProcessAccess.Rows[0]["CONFIRMINVENTORYMAKE"].ToString() == "Y";

                this.ckCanViewProductMakeUpChange.Checked =
                    userProcessAccess.Rows[0]["VIEWPRODUCTMAKEUPCHANGE"].ToString() == "Y";
                this.ckCanCreateProductMakeUpChange.Checked =
                    userProcessAccess.Rows[0]["CREATEPRODUCTMAKEUPCHANGE"].ToString() == "Y";
                this.ckCanApproveProductMakeUpChange.Checked =
                    userProcessAccess.Rows[0]["CONFIRMPRODUCTMAKEUPCHANGE"].ToString() == "Y";

                return;
            }

          clearForm:

            this.ckIsActive.Checked = true;
            this.ckCanViewRequest.Checked = false;
            this.ckCanCreateNewRequest.Checked = false;
            this.ckCanConfirmRequest.Checked = false;
            this.ckCanApproveRequest.Checked = false;
            this.ckCanRejectRequest.Checked = false;
            this.ckCanViewOrder.Checked = false;
            this.ckCanCreateNewOrder.Checked = false;
            this.ckCanApproveOrder.Checked = false;
            this.ckCanViewDispatch.Checked = false;
            this.ckCanCreateNewDispatch.Checked = false;
            this.ckCanConfirmDispatch.Checked = false;
            this.ckCanRefuseDispatch.Checked = false;
            this.ckCanViewDelivery.Checked = false;
            this.ckCanAcceptDelivery.Checked = false;
            this.ckCanConfirmRecipt.Checked = false;
            this.ckCanRejectDelivery.Checked = false;
            this.ckCanDisputeDelivery.Checked = false;
            this.ckCanViewDispute.Checked = false;
            this.ckCanAcceptDispute.Checked = false;
            this.ckCanRejectDispute.Checked = false;
            this.ckCanViewInventoryIn.Checked = false;
            this.ckCanCreateInventoryIn.Checked = false;
            this.ckCanApproveInventoryIn.Checked = false;
            this.ckCanViewInventoryOut.Checked = false;
            this.ckCanCreateInventoryOut.Checked = false;
            this.ckCanApproveInventoryOut.Checked = false;
            this.ckCanViewInventoryMake.Checked = false;
            this.ckCanCreateInventoryMake.Checked = false;
            this.ckCanApproveInventoryMake.Checked = false;
            this.ckCanViewProductMakeUpChange.Checked = false;
            this.ckCanCreateProductMakeUpChange.Checked = false;
            this.ckCanApproveProductMakeUpChange.Checked = false;

        }

        private void frmUserProcessAccess_Load(object sender, EventArgs e)
        {

            this.dtAllStations =
                this.getDataFromDb.getEM_STATIONInfo(null, "", "", true, false, "AND");
            DataRow drSation = this.dtAllStations.NewRow();

            drSation["EM_STATION_ID"] = 
                generalResultInformation.allStationRepresentativeKey;
            drSation["ISACTIVE"] = 'Y';
            drSation["CREATEDBY"] = 1000000;
            drSation["UPDATEDBY"] = 1000000;
            drSation["VALUE"] = "*";
            drSation["NAME"] = "*";

            this.dtAllStations.Rows.InsertAt(drSation, 0);
            
            this.insetDataIntoComboBox(this.cmbStations, this.dtAllStations,
                                        this.dtAllStations.Columns.IndexOf("NAME"), 0);

            this.dtAllWarehouse =
                this.getDataFromDb.getEM_M_WAREHOUSEInfo(null, "", "", true, false, "AND");

            DataRow drOrganisation = this.dtAllWarehouse.NewRow();
            drOrganisation["M_WAREHOUSE_ID"] = 
                generalResultInformation.allWarehouseRepresentativeKey;
            drOrganisation["CREATEDBY"] = 1000000;
            drOrganisation["UPDATEDBY"] = 1000000;
            drOrganisation["VALUE"] = "*";
            drOrganisation["NAME"] = "*";

            this.dtAllWarehouse.Rows.InsertAt(drOrganisation, 0);
            this.insetDataIntoComboBox(this.cmbWarehouse, this.dtAllWarehouse,
                                        this.dtAllWarehouse.Columns.IndexOf("NAME"), 0);

            this.cmdSetUserPrevilage.Enabled = false;

        }

        private void ddgUserName_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgUserName.SelectedRowKey == null)
            { 
                this.cmdSetUserPrevilage.Enabled = false;
                this.stCurrentUserID =
                        this.ddgUserName.SelectedRowKey.ToString();
                this.fillUserPrevilage();
            }
            else if (this.cmbStations.SelectedIndex >= 0 &&
                     this.cmbStations.SelectedIndex <= this.cmbStations.Items.Count - 1 &&
                     this.cmbWarehouse.SelectedIndex >= 0 &&
                     this.cmbWarehouse.SelectedIndex <= this.cmbWarehouse.Items.Count - 1)
            {
                this.cmdSetUserPrevilage.Enabled = true;
                if (this.stCurrentUserID != this.ddgUserName.SelectedRowKey.ToString())
                {
                    this.stCurrentUserID =
                        this.ddgUserName.SelectedRowKey.ToString();
                    this.fillUserPrevilage();
                }
            }
        }

        private void ddgUserName_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtAllUserNames =
               this.getDataFromDb.getEM_AD_USERInfo(null, "", "", "", "", true, false, "AND");

            this.ddgUserName.DataSource = this.dtAllUserNames;
            this.ddgUserName.HiddenColoumns = new int[]{this.dtAllUserNames.Columns.IndexOf("AD_CLIENT_ID"),
                                                        this.dtAllUserNames.Columns.IndexOf("AD_ORG_ID"),
                                                        this.dtAllUserNames.Columns.IndexOf("ISACTIVE"),
                                                        this.dtAllUserNames.Columns.IndexOf("CREATED"),
                                                        this.dtAllUserNames.Columns.IndexOf("CREATEDBY"),
                                                        this.dtAllUserNames.Columns.IndexOf("UPDATED"),
                                                        this.dtAllUserNames.Columns.IndexOf("UPDATEDBY"),
                                                        this.dtAllUserNames.Columns.IndexOf("PASSWORD")};
            this.ddgUserName.SelectedColomnIdex = this.dtAllUserNames.Columns.IndexOf("NAME");
            this.ddgUserName.DataTablePrimaryKey =
                 Convert.ToUInt16(this.dtAllUserNames.Columns.IndexOf("AD_USER_ID"));
        }

        private void ckIsActive_CheckedChanged(object sender, EventArgs e)
        {
                        
            this.ckCanViewRequest.Checked = this.ckIsActive.Checked;
            this.ckCanCreateNewRequest.Checked = this.ckIsActive.Checked;
            this.ckCanConfirmRequest.Checked = this.ckIsActive.Checked;
            this.ckCanApproveRequest.Checked = this.ckIsActive.Checked;
            this.ckCanRejectRequest.Checked = this.ckIsActive.Checked;
            this.ckCanViewOrder.Checked = this.ckIsActive.Checked;
            this.ckCanCreateNewOrder.Checked = this.ckIsActive.Checked;
            this.ckCanApproveOrder.Checked = this.ckIsActive.Checked;
            this.ckCanViewDispatch.Checked = this.ckIsActive.Checked;
            this.ckCanCreateNewDispatch.Checked = this.ckIsActive.Checked;
            this.ckCanConfirmDispatch.Checked = this.ckIsActive.Checked;
            this.ckCanRefuseDispatch.Checked = this.ckIsActive.Checked;
            this.ckCanViewDelivery.Checked = this.ckIsActive.Checked;
            this.ckCanAcceptDelivery.Checked = this.ckIsActive.Checked;
            this.ckCanConfirmRecipt.Checked = this.ckIsActive.Checked;
            this.ckCanRejectDelivery.Checked = this.ckIsActive.Checked;
            this.ckCanDisputeDelivery.Checked = this.ckIsActive.Checked;
            this.ckCanViewDispute.Checked = this.ckIsActive.Checked;
            this.ckCanAcceptDispute.Checked = this.ckIsActive.Checked;
            this.ckCanRejectDispute.Checked = this.ckIsActive.Checked;
            this.ckCanViewInventoryIn.Checked = this.ckIsActive.Checked;
            this.ckCanCreateInventoryIn.Checked = this.ckIsActive.Checked;
            this.ckCanApproveInventoryIn.Checked = this.ckIsActive.Checked;
            this.ckCanViewInventoryOut.Checked = this.ckIsActive.Checked;
            this.ckCanCreateInventoryOut.Checked = this.ckIsActive.Checked;
            this.ckCanApproveInventoryOut.Checked = this.ckIsActive.Checked;
            this.ckCanViewInventoryMake.Checked = this.ckIsActive.Checked;
            this.ckCanCreateInventoryMake.Checked = this.ckIsActive.Checked;
            this.ckCanApproveInventoryMake.Checked = this.ckIsActive.Checked;
        }

        private void cmdSetUserPrevilage_Click(object sender, EventArgs e)
        {
            DataTable userProcessAccess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(null, "",
                                                        this.dtAllWarehouse.Rows
                                                                [this.cmbWarehouse.SelectedIndex]
                                                                ["M_WAREHOUSE_ID"].ToString(),
                                                        this.ddgUserName.SelectedRowKey.ToString(),
                                                        this.dtAllStations.Rows
                                                                [this.cmbStations.SelectedIndex]
                                                                ["EM_STATION_ID"].ToString(),
                                                        false, false, "AND");
            if (!this.getDataFromDb.checkIfTableContainesData(userProcessAccess))
            {
                DataRow drUserProcessAccess = userProcessAccess.NewRow();
                drUserProcessAccess["AD_USER_ID"] = this.ddgUserName.SelectedRowKey.ToString();
                drUserProcessAccess["EM_STATION_ID"] =
                    this.dtAllStations.Rows[this.cmbStations.SelectedIndex]["EM_STATION_ID"].ToString();
                drUserProcessAccess["M_WAREHOUSE_ID"] =
                    this.dtAllWarehouse.Rows[this.cmbWarehouse.SelectedIndex]["M_WAREHOUSE_ID"].ToString();
                
                                                
                drUserProcessAccess["CREATEDBY"] = generalResultInformation.userId;

                drUserProcessAccess["UPDATEDBY"] = generalResultInformation.userId;

                drUserProcessAccess["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWREQUEST"] = this.ckCanViewRequest.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEREQUEST"] = this.ckCanCreateNewRequest.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMREQUEST"] = this.ckCanConfirmRequest.Checked ? "Y" : "N";
                drUserProcessAccess["APPROVEREQUEST"] = this.ckCanApproveRequest.Checked ? "Y" : "N";
                drUserProcessAccess["REJECTREQUEST"] = this.ckCanRejectRequest.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWDISPATCHORDER"] = this.ckCanViewOrder.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEDISPATCHORDER"] = this.ckCanCreateNewOrder.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMDISPATCHORDER"] = this.ckCanApproveOrder.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWDISPATCH"] = this.ckCanViewDispatch.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEDISPATCH"] = this.ckCanCreateNewDispatch.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMDISPATCH"] = this.ckCanConfirmDispatch.Checked ? "Y" : "N";
                drUserProcessAccess["REFUSEDISPATCH"] = this.ckCanRefuseDispatch.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWDELIVERY"] = this.ckCanViewDelivery.Checked ? "Y" : "N";
                drUserProcessAccess["ACCEPTDELIVERY"] = this.ckCanAcceptDelivery.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMRECIPT"] = this.ckCanConfirmRecipt.Checked ? "Y" : "N";
                drUserProcessAccess["REJECTDELIVERY"] = this.ckCanRejectDelivery.Checked ? "Y" : "N";
                drUserProcessAccess["DISPUTEDELIVERY"] = this.ckCanDisputeDelivery.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWDISPUTE"] = this.ckCanViewDispute.Checked ? "Y" : "N";
                drUserProcessAccess["ACCEPTDISPUTE"] = this.ckCanAcceptDispute.Checked ? "Y" : "N";
                drUserProcessAccess["REJECTDISPUTE"] = this.ckCanRejectDispute.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWINVENTORYIN"] = this.ckCanViewInventoryIn.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEINVENTORYIN"] = this.ckCanCreateInventoryIn.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMINVENTORYIN"] = this.ckCanApproveInventoryIn.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWINVENTORYOUT"] = this.ckCanViewInventoryOut.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEINVENTORYOUT"] = this.ckCanCreateInventoryOut.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMINVENTORYOUT"] = this.ckCanApproveInventoryOut.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWINVENTORYMAKE"] = this.ckCanViewInventoryMake.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEINVENTORYMAKE"] = this.ckCanCreateInventoryMake.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMINVENTORYMAKE"] = this.ckCanApproveInventoryMake.Checked ? "Y" : "N";
                drUserProcessAccess["VIEWPRODUCTMAKEUPCHANGE"] = this.ckCanViewProductMakeUpChange.Checked ? "Y" : "N";
                drUserProcessAccess["CREATEPRODUCTMAKEUPCHANGE"] = this.ckCanCreateProductMakeUpChange.Checked ? "Y" : "N";
                drUserProcessAccess["CONFIRMPRODUCTMAKEUPCHANGE"] = this.ckCanApproveProductMakeUpChange.Checked ? "Y" : "N";


                userProcessAccess.Rows.Add(drUserProcessAccess);
                string[] result = 
                    this.getDataFromDb.changeDataBaseTableData(userProcessAccess, "EM_PROCESS_ACCESS", "INSERT");

                if (result.Length > 0)
                    if (result[0] != "")
                        MessageBox.Show("Update Successfull", "Easy Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                userProcessAccess.Rows[0]["CREATEDBY"] = generalResultInformation.userId;

                userProcessAccess.Rows[0]["UPDATEDBY"] = generalResultInformation.userId;

                userProcessAccess.Rows[0]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWREQUEST"] = this.ckCanViewRequest.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEREQUEST"] = this.ckCanCreateNewRequest.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMREQUEST"] = this.ckCanConfirmRequest.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["APPROVEREQUEST"] = this.ckCanApproveRequest.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["REJECTREQUEST"] = this.ckCanRejectRequest.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWDISPATCHORDER"] = this.ckCanViewOrder.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEDISPATCHORDER"] = this.ckCanCreateNewOrder.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMDISPATCHORDER"] = this.ckCanApproveOrder.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWDISPATCH"] = this.ckCanViewDispatch.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEDISPATCH"] = this.ckCanCreateNewDispatch.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMDISPATCH"] = this.ckCanConfirmDispatch.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["REFUSEDISPATCH"] = this.ckCanRefuseDispatch.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWDELIVERY"] = this.ckCanViewDelivery.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["ACCEPTDELIVERY"] = this.ckCanAcceptDelivery.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMRECIPT"] = this.ckCanConfirmRecipt.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["REJECTDELIVERY"] = this.ckCanRejectDelivery.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["DISPUTEDELIVERY"] = this.ckCanDisputeDelivery.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWDISPUTE"] = this.ckCanViewDispute.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["ACCEPTDISPUTE"] = this.ckCanAcceptDispute.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["REJECTDISPUTE"] = this.ckCanRejectDispute.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWINVENTORYIN"] = this.ckCanViewInventoryIn.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEINVENTORYIN"] = this.ckCanCreateInventoryIn.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMINVENTORYIN"] = this.ckCanApproveInventoryIn.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWINVENTORYOUT"] = this.ckCanViewInventoryOut.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEINVENTORYOUT"] = this.ckCanCreateInventoryOut.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMINVENTORYOUT"] = this.ckCanApproveInventoryOut.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWINVENTORYMAKE"] = this.ckCanViewInventoryMake.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEINVENTORYMAKE"] = this.ckCanCreateInventoryMake.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMINVENTORYMAKE"] = this.ckCanApproveInventoryMake.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["VIEWPRODUCTMAKEUPCHANGE"] = this.ckCanViewProductMakeUpChange.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CREATEPRODUCTMAKEUPCHANGE"] = this.ckCanCreateProductMakeUpChange.Checked ? "Y" : "N";
                userProcessAccess.Rows[0]["CONFIRMPRODUCTMAKEUPCHANGE"] = this.ckCanApproveProductMakeUpChange.Checked ? "Y" : "N";

                
                string [] result = 
                    this.getDataFromDb.changeDataBaseTableData(userProcessAccess, "EM_PROCESS_ACCESS", "UPDATE");

                if (result.Length > 0)
                    if (result[0] != "")
                        MessageBox.Show("Update Successfull", "Easy Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                                                            
        }


        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {                        
            if(this.dtAllWarehouse.Rows[this.cmbWarehouse.SelectedIndex]
                ["M_WAREHOUSE_ID"].ToString() !=
                this.stCurrentWarehouseID)
            {
                this.stCurrentWarehouseID = 
                    this.dtAllWarehouse.Rows[this.cmbWarehouse.SelectedIndex]
                    ["M_WAREHOUSE_ID"].ToString();
                this.fillUserPrevilage();
            }
        }

        private void cmbStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dtAllStations.Rows[this.cmbStations.SelectedIndex]
                ["EM_STATION_ID"].ToString() !=
                this.stCurrentStationID)
            {
                this.stCurrentStationID =
                    this.dtAllStations.Rows[this.cmbStations.SelectedIndex]
                    ["EM_STATION_ID"].ToString();
                this.fillUserPrevilage();
            }
        }




        private void ckCanCreateNewRequest_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanCreateNewRequest.Checked)
                this.ckCanViewRequest.Checked = true;                
        }

        private void ckCanConfirmRequest_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanConfirmRequest.Checked)
                this.ckCanViewRequest.Checked = true;
        }

        private void ckCanApproveRequest_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanApproveRequest.Checked)
                this.ckCanViewRequest.Checked = true;
        }

        private void ckCanRejectRequest_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanRejectRequest.Checked)
                this.ckCanViewRequest.Checked = true;
        }

        

        private void ckCanAcceptDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanAcceptDelivery.Checked)
                this.ckCanViewDelivery.Checked = true;
        }

        private void ckCanConfirmRecipt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanConfirmRecipt.Checked)
                this.ckCanViewDelivery.Checked = true;
        }

        private void ckCanRejectDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanRejectDelivery.Checked)
                this.ckCanViewDelivery.Checked = true;
        }

        private void ckCanDisputeDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanDisputeDelivery.Checked)
                this.ckCanViewDelivery.Checked = true;
        }



        private void ckCanCreateNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanDisputeDelivery.Checked)
                this.ckCanViewOrder.Checked = true;
        }

        private void ckCanApproveOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanApproveOrder.Checked)
                this.ckCanViewOrder.Checked = true;
        }
        

        private void ckCanCreateNewDispatch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanCreateNewDispatch.Checked)
                this.ckCanViewDispatch.Checked = true;
        }

        private void ckCanConfirmDispatch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanConfirmDispatch.Checked)
                this.ckCanViewDispatch.Checked = true;
        }

        private void ckCanRefuseDispatch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanRefuseDispatch.Checked)
                this.ckCanViewDispatch.Checked = true;
        }
        

        private void ckCanAcceptDispute_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanAcceptDispute.Checked)
                this.ckCanViewDispute.Checked = true;
        }

        private void ckCanRejectDispute_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanRejectDispute.Checked)
                this.ckCanViewDispute.Checked = true;
        }


        private void ckCanCreateInventoryIn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanCreateInventoryIn.Checked)
                this.ckCanViewInventoryIn.Checked = true;
        }

        private void ckCanApproveInventoryIn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanApproveInventoryIn.Checked)
                this.ckCanViewInventoryIn.Checked = true;
        }


        private void ckCanCreateInventoryOut_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanCreateInventoryOut.Checked)
                this.ckCanViewInventoryOut.Checked = true;
        }

        private void ckCanApproveInventoryOut_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanApproveInventoryOut.Checked)
                this.ckCanViewInventoryOut.Checked = true;
        }


        private void ckCanCreateInventoryMake_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanCreateInventoryMake.Checked)
                this.ckCanViewInventoryMake.Checked = true;
        }

        private void ckCanApproveInventoryMake_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCanApproveInventoryMake.Checked)
                this.ckCanViewInventoryMake.Checked = true;
        }
        
        

        
    }
}
