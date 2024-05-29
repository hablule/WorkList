using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EasyMove
{
    public partial class frmBOMChange : Form
    {
        public frmBOMChange()
        {
            InitializeComponent();
        }


        void initControlsRecursive(Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                //c.MouseClick += new MouseEventHandler((sender, e) => { this.userIsActive = true; });
                c.MouseHover += new EventHandler((sender, e) => { this.userIsActive = true; });
                initControlsRecursive(c.Controls);
            }
        }

        bool userIsActive = false;

        bool currentViewIsRecordView = true;
        
        bool userCanCreateBOMChange = false;
        bool usersCanEditRecordDetail = false;
        bool recordCanbeConfirmed = false;
        bool userPrevilageIsReadOnlyForCurrentRecord = false;
        bool currentRecordApproved = false;
        
        bool documentPreviewHidden = true;

        bool mainRecordControlEnableSatus = false;
        bool subRecordControlEanbleStatus = false;

        bool blddgProductControlerOutOfFocus = true;

        int intCurrentRecordNumber = -1;

        const int allowedLineCount = -1;

        string stCurrentRecordId = "";

        string stCurrentDetailRecordLineNumber = "";
        string stCurrentDetailRecordId = "";
        string stQuantyColumnNameToAddOrModify = "";
                
        string stCurrentRecordOrganisationId = "";
        string stCurrentDocumentId = "";
        string stCurrentProductId = "";
        //string stCurrentRecordWareHouseFromId = "";
        //string stCurrentRecordLocatorFromId = "";


        Color clNormalFieldColor = Color.Black;
        Color clMissingFieldColor = Color.Red;
        Color clChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        recordType enmCurrentRecordType = recordType.unkown;
        taskType enmCurrentTask = taskType.Makeup;
        recordStatus enmCurrentRecordStatus = recordStatus.Unknown;
       
        // variables to hold informaion of exising record 
        //...(Request,Movement,Dispute) and their detail data
        //... from search result.
        DataTable dtExistingRecordData = new DataTable();
        DataTable dtExistingRecordDetailData = new DataTable();
        //DataTable dtExistingDetailRecord_DetailData = new DataTable();// M_productionLine

        // variables to hold informaion of new record 
        //...(Request,Movement,Dispute) data to insert.
        DataTable dtRecordMainData = new DataTable();
        DataTable dtRecordDetailData = new DataTable();
        //DataTable dtDetailRecord_DetailData = new DataTable();// M_productionLine

        // variables to hold informaion of new record 
        //...(Request,Movement,Dispute) data to update.
        DataTable dtRecordDataToUpdate = new DataTable();
        DataTable dtRecordDetailDataToUpdate = new DataTable();
        //DataTable dtDetailRecord_DetailDataToUpdate = new DataTable(); // M_productionLine


        DataTable dtAllOrganisation = new DataTable();
        DataTable dtActiveOrganisationsAccessableToUser = new DataTable();

        //DataTable dtAllWareHouses = new DataTable();
        //DataTable dtWareHousesAccessableToUser = new DataTable();

        DataTable dtAllDocuments = new DataTable();
        DataTable dtDocumentsAccessableToUser = new DataTable();

        //DataTable dttransferOrderResultList = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();
        
        //Variables Used to Print Crystal Document from Local Data Set
        dtsMovementInfo dsCurrentMovementInfo = new dtsMovementInfo();

        dtsMovementInfo.dtDocumentSummaryDataTable dtDocumentSummaryTable =
                new dtsMovementInfo.dtDocumentSummaryDataTable();
        dtsMovementInfo.dtDocumentDetailDataTable dtDocumentDetailTabe =
            new dtsMovementInfo.dtDocumentDetailDataTable();

        

        //enable disable toolbar task button (NEW,SAVE,DELETE,CONFIRM,REJECT)
            //... In accordance with user previlage to 
            //... (1)Current record Status and Operation
            //... and (2) Generating Organisation of Current Record

        private void enableToolBarTaskButtons()
        {
            this.enableDisableDeleteButton();
            this.enableDisableConfirmButton();
            //this.enableDisableNewButton();
            this.enableDisableRejectButton();
            this.enableDisableRelatedRecordButton();
            this.enableDisableSaveButton(); 
        }
        
        private void enableDisableRefreshButton()
        {

        }
        
        private void enableDisableNewButton()
        {
            if (userAccessPrevilageInformation.userStationprevilageIsReadOnly)
            {
                this.tscmdNew.Enabled = false;
                return;
            }

            if (this.userCanCreateBOMChange)
                this.tscmdNew.Enabled = true;
            else
                this.tscmdNew.Enabled = false;
        }

        private void enableDisableSaveButton()
        {
            this.tscmdSave.Enabled = false;
            return;            
        }
        
        private void enableDisableDeleteButton()
        {
            this.tscmdDelete.Enabled = false;
            return;                            
        }


        private void enableDisableConfirmButton()
        {
            if (this.enmCurrentRecordType == recordType.New)
            {
                this.tscmdConfirm.Enabled = true;
                return;
            }

            if (this.userPrevilageIsReadOnlyForCurrentRecord ||
                this.currentRecordApproved)
            {
                this.tscmdConfirm.Enabled = false;
                return;
            }

            if (userAccessPrevilageInformation.canApproveProductMakeUPChange)
                this.tscmdConfirm.Enabled = true;
            else
                this.tscmdConfirm.Enabled = false;
        }
        
        private void enableDisableRejectButton()
        {
            if (this.userPrevilageIsReadOnlyForCurrentRecord ||
                this.enmCurrentRecordType != recordType.Existing ||
                this.currentRecordApproved)
            {
                this.tscmdReject.Enabled = false;
                return;
            }

            if (userAccessPrevilageInformation.canApproveProductMakeUPChange)
                this.tscmdReject.Enabled = true;
            else
                this.tscmdReject.Enabled = false;
        }


        private void enableDisableSearchButton()
        {

        }
        
        private void enableDisableToggleButton()
        {

        }


        private void enableDisableFirstRecordButton()
        { 

        }
        
        private void enableDisablePreviousRecordButton()
        {

        }

        private void enableDisableNextRecordButton()
        {

        }

        private void enableDisableLastRecordButton()
        {

        }

        private void enableDisableNavigationButtons()
        {
            if (this.dtgMoveSummary.Rows.Count < 2)
            {
                this.tscmdFirstRecord.Enabled = false;
                this.tscmdPreviousRecord.Enabled = false;
                this.tscmdNextRecord.Enabled = false;
                this.tscmdLastRecord.Enabled = false;
                
            }
            
            else if (this.dtgMoveSummary.SelectedRows[0].Index == 0)
            {
                this.tscmdFirstRecord.Enabled = false;
                this.tscmdPreviousRecord.Enabled = false;
                this.tscmdNextRecord.Enabled = true;
                this.tscmdLastRecord.Enabled = true;
                
            }

            else if (this.dtgMoveSummary.SelectedRows[0].Index ==
                this.dtgMoveSummary.Rows.Count - 1)
            {
                this.tscmdFirstRecord.Enabled = true;
                this.tscmdPreviousRecord.Enabled = true;
                this.tscmdNextRecord.Enabled = false;
                this.tscmdLastRecord.Enabled = false;
                
            }
            else
            {
                this.tscmdFirstRecord.Enabled = true;
                this.tscmdPreviousRecord.Enabled = true;
                this.tscmdNextRecord.Enabled = true;
                this.tscmdLastRecord.Enabled = true;
            }
            
        }
        

        private void enableDisableTaskModeButton()
        {
            
        }

        private void enableDisableRelatedRecordButton()
        {
            
        }


        //enable disable toolbar navigation button in accordance with
        //.. total number of record in search result and current record under view
        private void enableDisableToolNavigationButtons()
        { 

        }


        //fills the current selected record of the grid view to the form
        private void fillCurrentGirdDataToForm()
        {            
            if (this.dtgMoveSummary.SelectedRows.Count < 0)
                return;          
            //fill Variables
            
            this.stCurrentDocumentId =
                this.dtgMoveSummary.SelectedRows[0].Cells["C_DOCTYPE_ID"].Value.ToString();

            //this.stCurrentRecordCurrentStatus =
            //    this.dtgMoveSummary.SelectedRows[0].Cells["DOCSTATUS"].Value.ToString();
                        
            this.stCurrentRecordOrganisationId =
                    this.dtgMoveSummary.SelectedRows[0].Cells["AD_ORG_ID"].Value.ToString();

            this.stCurrentProductId =
                this.dtgMoveSummary.SelectedRows[0].Cells["M_PRODUCT_ID"].Value.ToString();
            this.ddgProduct.SelectedItem =
                    this.dtgMoveSummary.SelectedRows[0].Cells["PRODUCT"].Value.ToString();
            this.ddgProduct.SelectedRowKey = this.stCurrentProductId; 

            //fill Controls.
            this.cmbOrganisation.Text = "";
            this.cmbOrganisation.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["ORGANISATION"].Value.ToString();

            
            this.cmbDocumentType.Text = "";
            this.cmbDocumentType.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["DOCUMENT"].Value.ToString();
            this.lblMoveStatus.Text = 
                this.dtgMoveSummary.SelectedRows[0].Cells["DOCSTATUS"].Value.ToString();

            if (this.dtgMoveSummary.SelectedRows[0].Cells["DOCSTATUS"].Value.ToString() == "Draft" ||
                this.dtgMoveSummary.SelectedRows[0].Cells["DOCSTATUS"].Value.ToString() == "Requested")
            {                
                this.currentRecordApproved = false;
            }
            else
            {                
                this.currentRecordApproved = true;
            }
           
            
            this.dtpMoveDate.Value =
                Convert.ToDateTime(this.dtgMoveSummary.SelectedRows[0].Cells["DATE"].Value);
                        
            this.txtDocumentNumber.Text = "";
            this.txtDocumentNumber.Text =
                this.dtgMoveSummary.SelectedRows[0].Cells["DOCUMENTNO"].Value.ToString();

                        
            this.txtDescriptionOrComment.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["DESCRIPTION"].Value.ToString();            
                                    
        }

        private void getAndfillCurrentRecordDetailTodtRecordDetail()
        { 
            if (this.stCurrentRecordId == "")
                return;
            //this.clearStructureAndDataOfDataTable(this.dtRecordDetailData);
            this.dtRecordDetailData.Clear();

            this.dtRecordDetailData =
                    this.getDataFromDb.getM_BOM_CHANGE_LINEInfo(null, "", "",
                        this.stCurrentRecordId, "", "", false, false, "AND");

            this.changeRecordDetailTableStructure();
            

            if (this.getDataFromDb.checkIfTableContainesData(this.dtRecordDetailData))
            {
                //this.stCurrentRecordLocatorFromId =
                //    this.dtRecordDetailData.Rows[0]["M_LOCATOR_ID"].ToString();

                for (int rowCounter = this.dtRecordDetailData.Rows.Count - 1;
                       rowCounter >= 0; rowCounter--)
                {
                    this.dtRecordDetailData.Rows[rowCounter]["remove"] = "remove";

                    this.dtRecordDetailData.Rows[rowCounter]["PRODUCT"] =
                        this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                             this.dtRecordDetailData.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                             false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["NAME"].ToString();

                    this.dtRecordDetailData.Rows[rowCounter]["UNIT"] =
                        this.getDataFromDb.getEM_C_UOMInfo(null, "",
                                     this.dtRecordDetailData.Rows[rowCounter]["C_UOM_ID"].ToString(),
                                     false, false, "AND")
                                .Rows[0]["NAME"].ToString();                    
                }
            }
        }

        //Changes Current Task Type to the given task Type or 
        //.. from (Request "R"-> Dispatch "M" -> Receipt/Delivery "D" -> Request)

        private void changeCurrentTask(taskType _TaskType)
        {
            this.enmCurrentTask = taskType.Makeup;            
        }
        
        //Changes the interface According to Task
        private void changeInterfaceToCurrentTaskAndRecordMode()
        {
            this.lblDocumentNumber.Text = "Number";
            this.lblDocumentType.Text = "Document";
            this.lblMovementDate.Text = "Date";
            //this.lblWareHouse.Text = "Assembeled In";
            this.lblQuantity.Text = "Quantity";
                      
            if (this.enmCurrentRecordType == recordType.New)
            {
                mainRecordControlEnableSatus = true;
                subRecordControlEanbleStatus = true;
            }           
            else
            {
                mainRecordControlEnableSatus = false;
                subRecordControlEanbleStatus = false;
            }            

            this.cmbOrganisation.Enabled = mainRecordControlEnableSatus;
            
            if (dbSettingInformationHandler.documentNumberAutoGenerated)
                this.txtDocumentNumber.Enabled = false;
            else
                this.txtDocumentNumber.Enabled = mainRecordControlEnableSatus;

            this.cmbDocumentType.Enabled = 
                mainRecordControlEnableSatus;
            this.dtpMoveDate.Enabled = 
                this.txtDocumentNumber.Enabled;

            this.ddgProduct.Enabled = 
                mainRecordControlEnableSatus;

                        
            //this.ddgProductBOM.Enabled = 
            //    subRecordControlEanbleStatus;
            //this.ntbQuantity.Enabled = 
            //    subRecordControlEanbleStatus;
            //this.cmdAddOrModifyRecordDetail.Enabled = 
            //    subRecordControlEanbleStatus;

            this.ddgProductBOM.Enabled = false;
            this.ntbQuantity.Enabled = false;
            this.cmdAddOrModifyRecordDetail.Enabled = false;
            this.txtRecordDetailDescription.Enabled = false;

            this.usersCanEditRecordDetail = 
                subRecordControlEanbleStatus;
            
        }

        //Changes the Type of The Current Record
        private void determineCurrentRecordType(recordType _Recordtype)
        {
            if (_Recordtype != recordType.unkown)
            {
                this.enmCurrentRecordType = _Recordtype;
                return;
            }

            if (this.stCurrentRecordId != "")
                this.enmCurrentRecordType = recordType.Existing;
            else if (this.stCurrentRecordId == "")
                this.enmCurrentRecordType = recordType.New;
            else
                this.enmCurrentRecordType = recordType.unkown;
        }
                
        //Get Task Type from Status
        private taskType determineRecordCurrentTaskType(string _status)
        {
            return taskType.Makeup;            
        }
        
        private void determineUserCurrentRecordPrevilage()
        {
            userAccessPrevilageInformation.canCreateNewProductMakeUPChange =  
                this.canUserCreateInventoryMakeUpChange(false);

            if (userAccessPrevilageInformation.userStationprevilageIsReadOnly)
            {                
                return;
            }

            if (this.enmCurrentRecordType != recordType.Existing)
                return;

            //DataTable currentUserWareHousePrevilage = new DataTable();
            //string stLocatorFromWareHouse = "";
            //string stCurrentTaskConcernedWareHouse = "";

            //stLocatorFromWareHouse =
            //    this.stCurrentRecordWareHouseFromId;

            //stCurrentTaskConcernedWareHouse = stLocatorFromWareHouse;
              
            DataTable currentUserCurrentRecordProcessAcess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                   "", "",
                                   generalResultInformation.userId,
                                   generalResultInformation.Station,
                                   true, false, "AND");

            if(currentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                currentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                    "", "",
                                    generalResultInformation.userId,
                                    generalResultInformation.allStationRepresentativeKey,
                                   true, false, "AND");                      


            if (this.getDataFromDb.checkIfTableContainesData(currentUserCurrentRecordProcessAcess))
            {
                if (currentUserCurrentRecordProcessAcess.Rows[0]["CREATEPRODUCTMAKEUPCHANGE"].ToString() == "N" &&
                    currentUserCurrentRecordProcessAcess.Rows[0]["CONFIRMPRODUCTMAKEUPCHANGE"].ToString() == "N")
                {
                    return;
                }
            }
            else
            {
                return;
            }

            if (currentUserCurrentRecordProcessAcess.Rows[0]["CREATEPRODUCTMAKEUPCHANGE"].ToString() == "Y")
            {
                userAccessPrevilageInformation.canCreateNewProductMakeUPChange = true;
            }
            else
                userAccessPrevilageInformation.canCreateNewProductMakeUPChange = false;


            if (currentUserCurrentRecordProcessAcess.Rows[0]["CONFIRMPRODUCTMAKEUPCHANGE"].ToString() == "Y")
            {
                userAccessPrevilageInformation.canApproveProductMakeUPChange = true;
            }
            else
                userAccessPrevilageInformation.canApproveProductMakeUPChange = false;
        }
        
        private bool canUserCreateInventoryMakeUpChange(bool checkWareHouse)
        {
            if (userAccessPrevilageInformation.userStationprevilageIsReadOnly)
            {
                return false;
            }

            DataTable criterionTable = new DataTable();
            DataTable currentUserProcessAccess = new DataTable();
            criterionTable.Columns.Add("Field");
            criterionTable.Columns.Add("Criterion");
            criterionTable.Columns.Add("Value");

            DataRow drCriterionRow;

            drCriterionRow = criterionTable.NewRow();
            drCriterionRow["Field"] = "CREATEPRODUCTMAKEUPCHANGE";
            drCriterionRow["Criterion"] = "=";
            drCriterionRow["Value"] = "Y";

            criterionTable.Rows.Add(drCriterionRow);

            //string concernedWarehouseId =
            //    checkWareHouse ? this.stCurrentRecordWareHouseFromId : "";

            string concernedWarehouseId = "";

            currentUserProcessAccess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(criterionTable, "AND",
                        concernedWarehouseId, generalResultInformation.userId,
                        generalResultInformation.Station, true, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(currentUserProcessAccess))
            {
                return true;
            }

            currentUserProcessAccess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(criterionTable, "AND",
                                            generalResultInformation.allWarehouseRepresentativeKey,
                                            generalResultInformation.userId,
                                            generalResultInformation.Station,
                                            true, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(currentUserProcessAccess))
            {
                return true;
            }

            currentUserProcessAccess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(criterionTable, "AND",
                                            generalResultInformation.allWarehouseRepresentativeKey,
                                            generalResultInformation.userId,
                                            generalResultInformation.allStationRepresentativeKey,
                                            true, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(currentUserProcessAccess))
            {
                return true;
            }

            return false;
        }
        

        //Checkes if all data exists for insert or Update
        private bool checkExistanceOfAllRequiredInformation()
        {
            bool missingFieldExist = false;
            if (this.cmbOrganisation.Text == "" ||
                this.stCurrentRecordOrganisationId == "")
            {
                this.lblOrganisation.ForeColor = this.clMissingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblOrganisation.ForeColor = this.clNormalFieldColor;


            if (this.txtDocumentNumber.Text == "")
            {
                this.lblDocumentNumber.ForeColor = this.clMissingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblDocumentNumber.ForeColor = this.clNormalFieldColor;

            if (this.cmbDocumentType.Text == "" ||
                this.stCurrentDocumentId == "")
            {
                this.lblDocumentType.ForeColor = this.clMissingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblDocumentType.ForeColor = this.clNormalFieldColor;

            if (this.dtpMoveDate.Value.ToString() == "")
            {
                this.lblMovementDate.ForeColor = this.clMissingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblMovementDate.ForeColor = this.clNormalFieldColor;
                        
            if (this.ddgProduct.SelectedRowKey == null)
            {
                this.lblProduct.ForeColor = this.clMissingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblProduct.ForeColor = this.clNormalFieldColor;
                        
            if (!getDataFromDb.checkIfTableContainesData(this.dtRecordDetailData))
            {
                this.sbStatusLabel.Text = "No movement Line Found.";
                this.dtgMoveLine.BackgroundColor = Color.Red;
                missingFieldExist = true;
            }
            else if (allowedLineCount >= 0 && this.dtRecordDetailData.Rows.Count > allowedLineCount)
            {
                this.sbStatusLabel.Text = "Document Line count Exceed Maximum Allowed number.";
                this.dtgMoveLine.BackgroundColor = Color.Yellow;
                missingFieldExist = true;
            }
            else
            {
                this.dtgMoveLine.BackgroundColor = 
                    System.Drawing.SystemColors.Control;                
            }

            return missingFieldExist;
        }

        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            int arraySize = dataSourceTable.Rows.Count;
            string [] arrayItems = new string[arraySize] ;
            string[] tempArray= {""};
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
            
            if(selectedIndex >= 0 && 
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }

        private DataTable filterDataTable(DataTable tableToFillter, 
            string filterLitral, string columnNameToCompare)
        {

            if (!getDataFromDb.checkIfTableContainesData(tableToFillter))
                return tableToFillter;
            if (!tableToFillter.Columns.Contains(columnNameToCompare))
                return tableToFillter;
            if (filterLitral == "")
                return tableToFillter;

            for (int rowCounter = tableToFillter.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (!tableToFillter.Rows[rowCounter][columnNameToCompare].
                    ToString().ToUpper().Contains(filterLitral.ToUpper()))
                    tableToFillter.Rows.RemoveAt(rowCounter);
            }
            return tableToFillter;                
        }

        private void changeRecordDetailTableStructure()
        {
            if (this.enmCurrentRecordType != recordType.unkown &&
                this.enmCurrentTask != taskType.Unkown)
            {
                DataTable movementLineStructure =
                       getDataFromDb.getM_BOM_CHANGE_LINEInfo(null, "", "", "",
                                           "", "", true, true, "");

                for (int columnCounter = movementLineStructure.Columns.Count - 1;
                    columnCounter >= 0; columnCounter--)
                {
                    if (!this.dtRecordDetailData.Columns.Contains
                            (movementLineStructure.Columns[columnCounter].ColumnName))
                        this.dtRecordDetailData.Columns.Add
                                    (movementLineStructure.Columns[columnCounter].ColumnName,
                                     movementLineStructure.Columns[columnCounter].DataType);
                }

                for (int columnCounter = this.dtRecordDetailData.Columns.Count - 1;
                    columnCounter >= 0; columnCounter--)
                {
                    if (!movementLineStructure.Columns.Contains
                            (this.dtRecordDetailData.Columns[columnCounter].ColumnName))
                        this.dtRecordDetailData.Columns.RemoveAt(columnCounter);

                }       

                this.dtRecordDetailData.Columns.Add("remove");
                this.dtRecordDetailData.Columns.Add("PRODUCT");
                this.dtRecordDetailData.Columns.Add("UNIT");

                this.dtRecordDetailData.Columns["remove"].SetOrdinal(0);
                this.dtRecordDetailData.Columns["LINE"].SetOrdinal(1);
                this.dtRecordDetailData.Columns["PRODUCT"].SetOrdinal(2);
                this.dtRecordDetailData.Columns["UNIT"].SetOrdinal(3);
                this.dtRecordDetailData.Columns["BOMQTY"].SetOrdinal(4);
            }
        }

        private void changeMainRecordTableStructure()
        {
            if (this.enmCurrentRecordType == recordType.New ||
                this.enmCurrentRecordType == recordType.Existing)
            {
                this.dtRecordMainData =
                        getDataFromDb.getM_BOM_CHANGEInfo(null, "", "",
                                "", "", true, true, "");
            }
        }

        private void fillDataToRecordDetailGidView()
        {
            if (this.enmCurrentRecordType != recordType.unkown)
            {
                this.dtgMoveLine.DataSource = this.dtRecordDetailData;

                if (this.dtgMoveLine.Columns.Count < 1)
                    return;

                foreach (DataGridViewColumn columns in this.dtgMoveLine.Columns)
                {
                    columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                    columns.DisplayIndex = columns.Index;
                }

                this.dtgMoveLine.Columns["M_BOM_CHANGE_LINE_ID"].Visible = false;
                this.dtgMoveLine.Columns["M_BOM_CHANGE_ID"].Visible = false;
                this.dtgMoveLine.Columns["EM_STATION_ID"].Visible = false;
                this.dtgMoveLine.Columns["AD_CLIENT_ID"].Visible = false;
                this.dtgMoveLine.Columns["AD_ORG_ID"].Visible = false;
                this.dtgMoveLine.Columns["ISACTIVE"].Visible = false;
                this.dtgMoveLine.Columns["CREATED"].Visible = false;
                this.dtgMoveLine.Columns["CREATEDBY"].Visible = false;
                this.dtgMoveLine.Columns["UPDATED"].Visible = false;
                this.dtgMoveLine.Columns["UPDATEDBY"].Visible = false;
                this.dtgMoveLine.Columns["M_PRODUCT_ID"].Visible = false;
                this.dtgMoveLine.Columns["DESCRIPTION"].Visible = false;
                this.dtgMoveLine.Columns["C_UOM_ID"].Visible = false;
                this.dtgMoveLine.Columns["PROCESSED"].Visible = false;
                this.dtgMoveLine.Columns["remove"].HeaderText = "";
                this.dtgMoveLine.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;
                                

                if (this.enmCurrentRecordType == recordType.Existing)
                {
                    if (
                         this.enmCurrentRecordStatus == recordStatus.Drafted &&
                         this.usersCanEditRecordDetail
                       )
                        this.dtgMoveLine.Columns["remove"].Visible = true;
                    else
                        this.dtgMoveLine.Columns["remove"].Visible = false;
                }
                else if(!this.usersCanEditRecordDetail)
                    this.dtgMoveLine.Columns["remove"].Visible = false;
                else
                    this.dtgMoveLine.Columns["remove"].Visible = true;

                this.dtgMoveLine.Sort(this.dtgMoveLine.Columns["LINE"], ListSortDirection.Ascending);
            }
        }

        private void fillSearchResultToMainRecordGridView()
        {            
            this.dtgMoveSummary.DataSource = this.dtExistingRecordData;

            this.dtgMoveSummary.Columns["EM_STATION_ID"].Visible = false;
            this.dtgMoveSummary.Columns["AD_ORG_ID"].Visible = false;
            this.dtgMoveSummary.Columns["CREATEDBY"].Visible = false;
            this.dtgMoveSummary.Columns["UPDATEDBY"].Visible = false;
            this.dtgMoveSummary.Columns["M_PRODUCT_ID"].Visible = false;

            this.dtgMoveSummary.Columns["M_BOM_CHANGE_ID"].Visible = false;
            this.dtgMoveSummary.Columns["DESCRIPTION"].Visible = false;
            this.dtgMoveSummary.Columns["C_DOCTYPE_ID"].Visible = false;

            if (!this.getDataFromDb.checkIfTableContainesData(this.dtExistingRecordData))
                return;
            if (this.dtgMoveSummary.Columns.Count < 1)
                return;

            foreach (DataGridViewColumn columns in this.dtgMoveSummary.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.Automatic;
                columns.DisplayIndex = columns.Index;
            }
        }

        private void loadSearchResultDataToExistingMainRecord()
        {
            if (!this.getDataFromDb.checkIfTableContainesData
                (generalResultInformation.searchResult))
            {
                if (this.dtExistingRecordData.Columns.Count <= 0)
                {
                    this.dtExistingRecordData.Columns.Add("ORGANISATION");
                    this.dtExistingRecordData.Columns.Add("DOCUMENTNO");
                    this.dtExistingRecordData.Columns.Add("DATE");
                    this.dtExistingRecordData.Columns.Add("DOCUMENT");
                    this.dtExistingRecordData.Columns.Add("PRODUCT");
                    this.dtExistingRecordData.Columns.Add("DOCSTATUS");

                    this.dtExistingRecordData.Columns.Add("EM_STATION_ID");
                    this.dtExistingRecordData.Columns.Add("AD_ORG_ID");
                    this.dtExistingRecordData.Columns.Add("CREATEDBY");
                    this.dtExistingRecordData.Columns.Add("UPDATEDBY");
                    this.dtExistingRecordData.Columns.Add("M_PRODUCT_ID");
                    this.dtExistingRecordData.Columns.Add("M_BOM_CHANGE_ID");
                    this.dtExistingRecordData.Columns.Add("DESCRIPTION");
                    this.dtExistingRecordData.Columns.Add("C_DOCTYPE_ID");
                                        
                    return;
                }
                else
                { 
                    return; 
                }
            }
            else
                this.dtExistingRecordData = generalResultInformation.searchResult.Copy();

            this.dtExistingRecordData.Columns["ORGANISATION"].SetOrdinal(1);
            this.dtExistingRecordData.Columns["DOCUMENTNO"].SetOrdinal(2);
            this.dtExistingRecordData.Columns["DATE"].SetOrdinal(3);
            this.dtExistingRecordData.Columns["DOCUMENT"].SetOrdinal(4);
            this.dtExistingRecordData.Columns["PRODUCT"].SetOrdinal(5);
            this.dtExistingRecordData.Columns["DOCSTATUS"].SetOrdinal(6);
        }

        private int [] searchTableRowIndex(DataTable tableToSearchIn,
            string columnNameToCheck, string criteriaToCheck)
        {
            int[] resultRowIndex = new int[tableToSearchIn.Rows.Count];
            for(int arrayIndexCounter = 0; 
                arrayIndexCounter <= resultRowIndex.Length-1;
                arrayIndexCounter++)
                resultRowIndex[arrayIndexCounter] = -1; 

            int matchingRowCount = 0;

            if (!getDataFromDb.checkIfTableContainesData(tableToSearchIn))
                return resultRowIndex;
            if (!tableToSearchIn.Columns.Contains(columnNameToCheck))
                return resultRowIndex;            
            
            for (int rowCounter = 0; rowCounter <= tableToSearchIn.Rows.Count-1;
                rowCounter++)
            {
                if (tableToSearchIn.Rows[rowCounter][columnNameToCheck].ToString() ==
                    criteriaToCheck)
                    resultRowIndex[matchingRowCount++] = rowCounter;
            }            
            return resultRowIndex.Distinct().ToArray();            
        }


        //When the addOrModify record detail button is clicked
        // this function picks the data and updates the recorddetail data table.

        private void addOrModifyRecordDetail(bool removeReocrd)
        {
            this.changeQuantityColumnNameToAddModify();

            if (this.enmCurrentTask == taskType.Makeup)
            {
                if (this.stCurrentDetailRecordId != "" ||
                    this.stCurrentDetailRecordLineNumber != "")
                {
                    int[] mathcingDetailRecord =
                        this.searchTableRowIndex(this.dtRecordDetailData, "LINE",
                        this.stCurrentDetailRecordLineNumber);

                    if (mathcingDetailRecord[0] < 0)
                        return;

                    if (removeReocrd)
                    {
                        this.dtgMoveLine.SelectedRows[0].Selected = false;
                        this.dtRecordDetailData.Rows.RemoveAt(mathcingDetailRecord[0]);
                        for (int rowCounter = 0; rowCounter <= this.dtRecordDetailData.Rows.Count - 1;
                            rowCounter++)
                        {
                            this.dtRecordDetailData.Rows[rowCounter]["LINE"] = rowCounter + 1;
                        }
                        if (this.dtgMoveLine.SelectedRows.Count > 0)
                            this.dtgMoveLine.SelectedRows[0].Selected = false;
                        goto CheckAllowedLineCount;
                    }

                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["DESCRIPTION"] =
                        this.txtRecordDetailDescription.Text;

                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["M_PRODUCT_ID"] =
                        this.ddgProductBOM.SelectedRowKey.ToString();

                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["PRODUCT"] =
                        this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["M_PRODUCT_ID"].ToString(),
                            false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["NAME"];


                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["BOMQTY"] =
                        Decimal.Parse(this.ntbQuantity.Amount);

                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]][this.stQuantyColumnNameToAddOrModify] =
                        Decimal.Parse(this.ntbQuantity.Amount);

                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["C_UOM_ID"] =
                        this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["M_PRODUCT_ID"].ToString(),
                            false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["C_UOM_ID"];

                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["UNIT"] =
                        this.getDataFromDb.getEM_C_UOMInfo
                                (null, "",
                                    this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["C_UOM_ID"].ToString(),
                                    false, false, "AND")
                               .Rows[0]["NAME"].ToString();

                }
                else
                {
                    DataRow drNewDetailRecordRow = this.dtRecordDetailData.NewRow();

                    drNewDetailRecordRow["DESCRIPTION"] = this.txtRecordDetailDescription.Text;

                    drNewDetailRecordRow["M_PRODUCT_ID"] = this.ddgProductBOM.SelectedRowKey.ToString();

                    drNewDetailRecordRow["LINE"] = this.dtRecordDetailData.Rows.Count + 1;

                    drNewDetailRecordRow["PRODUCT"] =
                        this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            drNewDetailRecordRow["M_PRODUCT_ID"].ToString(),
                            false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["NAME"];

                    drNewDetailRecordRow["BOMQTY"] =
                        Decimal.Parse(this.ntbQuantity.Amount);

                    drNewDetailRecordRow[this.stQuantyColumnNameToAddOrModify] =
                        Decimal.Parse(this.ntbQuantity.Amount);

                    drNewDetailRecordRow["remove"] = "remove";

                    drNewDetailRecordRow["C_UOM_ID"] =
                       this.ddgProductBOM.SelectedRow.Rows[0]["C_UOM_ID"].ToString();

                    drNewDetailRecordRow["UNIT"] =
                        this.getDataFromDb.getEM_C_UOMInfo
                                (null, "",
                                    this.ddgProductBOM.SelectedRow.Rows[0]["C_UOM_ID"].ToString(),
                                    false, false, "AND")
                               .Rows[0]["NAME"].ToString();
                    try
                    {
                        this.dtRecordDetailData.Rows.Add(drNewDetailRecordRow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

       CheckAllowedLineCount:
            if (this.dtgMoveLine.SelectedRows.Count > 0)
                this.dtgMoveLine.SelectedRows[0].Selected = false;
            if (allowedLineCount >= 0 && this.dtRecordDetailData.Rows.Count >= allowedLineCount)
            {
                this.cmdAddOrModifyRecordDetail.Enabled = false;
                this.ddgProductBOM.Enabled = false;
            }
            else
            {
                //this.cmdAddOrModifyRecordDetail.Enabled = false;
                this.ddgProductBOM.Enabled = true;
            }
        }
                
        private void changeQuantityColumnNameToAddModify()
        {
            this.stQuantyColumnNameToAddOrModify = "BOMQTY";            
        }
        
        private DataTable clearStructureAndDataOfDataTable(DataTable tableToClear)
        {
            if (tableToClear != null)
            {
                tableToClear.Clear();
                for (int colCounter = tableToClear.Columns.Count - 1;
                    colCounter >= 0; colCounter--)
                    tableToClear.Columns.RemoveAt(colCounter);
            }
            return tableToClear;
        }

        private void clearFormContent()
        {
            //clear variable contents
            this.stCurrentDetailRecordId = "";
            this.stCurrentDetailRecordLineNumber = "";
            this.stCurrentRecordId = "";
            this.stQuantyColumnNameToAddOrModify = "";

            //Clear Form
            if (this.cmbOrganisation.Items.Count > 0)
            {
                this.cmbOrganisation.SelectedIndex = 0;
                this.cmbOrganisation_DropDownClosed(new object(), new EventArgs());
            }            

            this.txtDocumentNumber.Text = "";

            if (this.cmbDocumentType.Items.Count > 0)
            {
                this.cmbOrganisation.SelectedIndex = 0;
                this.cmbDocumentType_DropDownClosed(new object(), new EventArgs());
            }

            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.DataSource = null;

            this.dtpMoveDate.Value = DateTime.Today;
            
            this.txtDescriptionOrComment.Text = "";

            this.lblUOM.Text = "";
            this.cmdAddOrModifyRecordDetail.Enabled = false;

            //if (allowedLineCount >= 0 && this.dtRecordDetailData.Rows.Count >= allowedLineCount)
            //{
            //    this.ddgProductBOM.Enabled = false;
            //    this.ntbQuantity.Enabled = false;
            //    this.txtRecordDetailDescription.Enabled = false;                
            //}
            //else
            //{
            //    this.ddgProductBOM.Enabled = true;
            //    this.ntbQuantity.Enabled = true;
            //    this.txtRecordDetailDescription.Enabled = true; 
            //}
            
        }

        private void loadDocForCurrentTask()
        {
            this.loadDocForCurrentTask(true);   
        }

        private void loadDocForCurrentTask( bool onlyActiveRecords)
        {
            this.cmbDocumentType.Items.Clear();
            this.dtDocumentsAccessableToUser =
                getDataAccordingToRule.getDocuments(true, onlyActiveRecords, "", true, this.enmCurrentTask);
            this.insetDataIntoComboBox(this.cmbDocumentType, dtDocumentsAccessableToUser,
                dtDocumentsAccessableToUser.Columns.IndexOf("NAME"), -1);
            
            if (this.cmbDocumentType.Items.Count > 0)
                this.cmbDocumentType.SelectedIndex = 0;
        }

        private void prepareForNewTask(taskType _newTask)
        {           
            //this.userPrevilageIsReadOnlyForCurrentRecord = false;
                        
            this.changeCurrentTask(_newTask);

            this.dtRecordDetailData.Clear();
            this.dtRecordMainData.Clear();

            this.changeInterfaceToCurrentTaskAndRecordMode();
            this.changeRecordDetailTableStructure();
            this.changeMainRecordTableStructure();

            this.clearFormContent();

            this.fillDataToRecordDetailGidView();
            this.loadDocForCurrentTask();
            
            this.enableToolBarTaskButtons();            

        }

        private void hidePrintPreview()
        {
            this.documentPreviewHidden = true;
            if (this.currentViewIsRecordView)
            {
                this.ddgProductBOM.BringToFront();
            }
            this.tscmdShowPrintPreview.Checked = false;
            this.crvPrintPreview.Hide();
        }
        

        //Below are Form event procedures.
        //funtions of the form and its control
        
        private void frmBOMChange_Load(object sender, EventArgs e)
        {            
            this.crvPrintPreview.Parent = this;
            this.crvPrintPreview.Dock = DockStyle.Fill;
            this.crvPrintPreview.BringToFront();

            this.ddgProductBOM.Parent = this;
            this.ddgProductBOM.BringToFront();
            this.ddgProductBOM.Location = new Point(122, 308);
            this.ddgProductBOM.Enabled = false;

            this.cmdShowBOM.Enabled = false;
            
            this.dtgMoveSummary.Visible = false;
            
            this.dtAllOrganisation = getDataAccordingToRule.getOrganisations(false, false);            
            this.dtAllDocuments = getDataAccordingToRule.getDocuments(false, false, "", true);

            this.dtActiveOrganisationsAccessableToUser = 
                getDataAccordingToRule.getOrganisations(true, true);
            this.insetDataIntoComboBox(this.cmbOrganisation, dtActiveOrganisationsAccessableToUser,
                dtActiveOrganisationsAccessableToUser.Columns.IndexOf("NAME"), -1);

            
            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);                        
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font = 
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F, 
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           

            if (dbSettingInformationHandler.documentNumberAutoGenerated)
                this.txtDocumentNumber.Enabled = false;
            else
                this.txtDocumentNumber.Enabled = true;

            this.dtpMoveDate.Enabled = 
                this.txtDocumentNumber.Enabled;

            this.enmCurrentTask = taskType.Make;

            this.userCanCreateBOMChange =
                this.canUserCreateInventoryMakeUpChange(false);

            this.prepareForNewTask(this.enmCurrentTask);

            this.loadSearchResultDataToExistingMainRecord();
            this.fillSearchResultToMainRecordGridView();

            this.initControlsRecursive(this.Controls);

            if (this.getDataFromDb.checkIfTableContainesData(this.dtExistingRecordData))
            {
                this.tscmdFirstRecord_Click(sender, e);
                return;
            }

            this.changeInterfaceToCurrentTaskAndRecordMode();

            this.changeRecordDetailTableStructure();
            this.fillDataToRecordDetailGidView();

            this.enableDisableNavigationButtons();
            this.enableToolBarTaskButtons();

            this.enableDisableNewButton();

            if (this.dtExistingRecordData.Rows.Count < 1 &&
                this.tscmdNew.Enabled)
            {
                this.tscmdNew_Click(sender, e);
            }
        }
        
                
        private void tscmdRefresh_Click(object sender, EventArgs e)
        {             
        }

        private void tscmdNew_Click(object sender, EventArgs e)
        {
            this.cmbOrganisation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDocumentType.DropDownStyle = ComboBoxStyle.DropDownList;

            this.hidePrintPreview();
            this.clearFormContent();
                        
            this.enmCurrentRecordType = recordType.New;
            this.enmCurrentTask = taskType.Makeup;
                                    
            if (this.userCanCreateBOMChange)
            {
                this.prepareForNewTask(taskType.Makeup);
            }
        }

        private void tscmdSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.hidePrintPreview();
            DataRow newRecordDatarow;
            DataRow existingReocrdDatarow;

            string mainTableNameToChange = "";
            string detailTableNameToChange = "";
            string changeType = "";
            this.changeMainRecordTableStructure();

            this.recordCanbeConfirmed = false;

            if (this.enmCurrentRecordType == recordType.unkown)
            {
                this.Enabled = true;                
                return;
            }

            if (this.enmCurrentRecordType == recordType.Existing)
            {               
                this.Enabled = true;
                this.recordCanbeConfirmed = true;
                return;
            }

            //check all fields for new record.
            if (this.checkExistanceOfAllRequiredInformation())
            {
                this.Enabled = true;
                MessageBox.Show("Please Correct your data entred fields before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }
            

            if (this.enmCurrentRecordType == recordType.Existing)
                changeType = "UPDATE";
            else if (this.enmCurrentRecordType == recordType.New)
            {
                if (!this.canUserCreateInventoryMakeUpChange(false))
                {
                    MessageBox.Show("You Don't Have Suffiecent Previlage To Create this Record." +
                            "\n Please Consult Your Admin", "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    this.Enabled = true;
                    return;
                }
                changeType = "INSERT";                
            }

            newRecordDatarow = this.dtRecordMainData.NewRow();
            
            if (this.enmCurrentRecordType == recordType.New)
            {
                if (this.enmCurrentRecordType == recordType.New)
                {
                    newRecordDatarow["EM_STATION_ID"] = generalResultInformation.Station;                                        
                }
            }

            if (this.stCurrentRecordId != "" &&
                this.enmCurrentRecordType == recordType.Existing)
            {
                newRecordDatarow["M_BOM_CHANGE_ID"] = 
                    this.stCurrentRecordId;                
            }
            

            newRecordDatarow["AD_CLIENT_ID"] = generalResultInformation.clientId;
            newRecordDatarow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;

            if (this.txtDocumentNumber.Text.Contains("<<") &&
                this.txtDocumentNumber.Text.Contains(">>"))
            {
                newRecordDatarow["DOCUMENTNO"] =
                   getDataFromDb.getNextSequenceId("",
                       getDataFromDb.getEM_C_DOCTYPEInfo
                           (null, "", this.stCurrentDocumentId, false, false, "AND")
                        .Rows[0]["DOCNOSEQUENCE_ID"].ToString(),
                        generalResultInformation.Station, "", true);
            }
            else
                newRecordDatarow["DOCUMENTNO"] = this.txtDocumentNumber.Text;

            newRecordDatarow["DESCRIPTION"] = this.txtDescriptionOrComment.Text;
            newRecordDatarow["C_DOCTYPE_ID"] = this.stCurrentDocumentId;
            newRecordDatarow["ISAPPROVED"] = "N";


            newRecordDatarow["REQUESTDATE"] =
                this.dtpMoveDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

            newRecordDatarow["M_PRODUCT_ID"] = this.stCurrentProductId;
            newRecordDatarow["DOCSTATUS"] = "DR";

            mainTableNameToChange = "M_BOM_CHANGE";
            detailTableNameToChange = "M_BOM_CHANGE_LINE";
            
            this.dtRecordMainData.Rows.Add(newRecordDatarow);

            //Insert Reuest. and Get Id.

            string[] recordId =
                getDataFromDb.changeDataBaseTableData(this.dtRecordMainData,
                mainTableNameToChange, changeType);
            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {                
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                this.Enabled = true;                
                return;
            }

            //Update Request Id for Detail request record.

            string [] mainRecordPrimaryKeyColumnName =
                    getDataFromDb.getEasyMoveDBTablePrimaryKey(mainTableNameToChange);

            string recordTableIdName = "M_BOM_CHANGE_ID";

            string[] newRecordId = new string[(recordId.Length * 2)];

            if (this.stCurrentRecordId == "" &&
                this.enmCurrentRecordType == recordType.New)
            {
                string[] primaryKeySepartor = { " <(", ")>||" };
                for (int arrayIndexCounter = 0;
                    arrayIndexCounter <= recordId.Length - 1;
                    arrayIndexCounter++)
                {
                    recordId[arrayIndexCounter].Split(primaryKeySepartor,
                        StringSplitOptions.RemoveEmptyEntries).
                            CopyTo(newRecordId, (arrayIndexCounter * 2));
                }

                if (newRecordId.Length < 2)
                {
                    this.Enabled = true;
                    this.sbStatusLabel.Text = "Record IS NOT Saved";
                    return;
                }

                foreach (string RecordKey in mainRecordPrimaryKeyColumnName)
                    if (!newRecordId.Contains(RecordKey))
                    {
                        this.Enabled = true;
                        this.sbStatusLabel.Text = "Record IS NOT Saved";
                        return;
                    }

                for (int currentDetailRecord = 0;
                    currentDetailRecord <= dtRecordDetailData.Rows.Count - 1;
                    currentDetailRecord++)
                {

                    dtRecordDetailData.Rows[currentDetailRecord]["EM_STATION_ID"] =
                            generalResultInformation.Station;
                    dtRecordDetailData.Rows[currentDetailRecord]["AD_CLIENT_ID"] =
                        generalResultInformation.clientId;
                    dtRecordDetailData.Rows[currentDetailRecord]["AD_ORG_ID"] =
                        this.stCurrentRecordOrganisationId;
                    

                    for (int arrayIndexCounter = 0;
                            arrayIndexCounter <= newRecordId.Length - 1;
                            arrayIndexCounter+=2)
                    {
                        if (dtRecordDetailData.Rows[currentDetailRecord]
                            [newRecordId[arrayIndexCounter]].ToString() == "")
                            dtRecordDetailData.Rows[currentDetailRecord]
                                [newRecordId[arrayIndexCounter]] =
                                newRecordId[arrayIndexCounter + 1];
                    }                    
                }
            }

            this.dtRecordDetailData.Columns.RemoveAt
                (this.dtRecordDetailData.Columns.IndexOf("remove"));
            this.dtRecordDetailData.Columns.RemoveAt
                (this.dtRecordDetailData.Columns.IndexOf("PRODUCT"));
            this.dtRecordDetailData.Columns.RemoveAt
                (this.dtRecordDetailData.Columns.IndexOf("UNIT"));
            
            recordId =
                getDataFromDb.changeDataBaseTableData(dtRecordDetailData.Copy(),
                    detailTableNameToChange, changeType);                       

            if (this.enmCurrentRecordType == recordType.New)
            {
                existingReocrdDatarow = this.dtExistingRecordData.NewRow();
                existingReocrdDatarow["EM_STATION_ID"] = generalResultInformation.Station;

                existingReocrdDatarow["ORGANISATION"] =
                    this.cmbOrganisation.Text;
                existingReocrdDatarow["DOCUMENTNO"] =
                    this.txtDocumentNumber.Text.Replace("<<","");
                existingReocrdDatarow["DOCUMENTNO"] =
                    existingReocrdDatarow["DOCUMENTNO"].ToString().Replace(">>", "");
                existingReocrdDatarow["DATE"] =
                    this.dtpMoveDate.Value;
                existingReocrdDatarow["DOCUMENT"] =
                    this.cmbDocumentType.Text;               
                existingReocrdDatarow["PRODUCT"] =
                    this.ddgProduct.SelectedItem;
                existingReocrdDatarow["DOCSTATUS"] = "Draft";
                existingReocrdDatarow["AD_ORG_ID"] =
                    this.stCurrentRecordOrganisationId;
                existingReocrdDatarow["M_PRODUCT_ID"] =
                    this.stCurrentProductId;
                existingReocrdDatarow["DESCRIPTION"] =
                    this.txtDescriptionOrComment.Text;
                existingReocrdDatarow["C_DOCTYPE_ID"] =
                    this.stCurrentDocumentId;

                existingReocrdDatarow["CREATEDBY"] = generalResultInformation.userId;
                existingReocrdDatarow["UPDATEDBY"] = generalResultInformation.userId;

                this.stCurrentRecordId = 
                    newRecordId[Array.IndexOf(newRecordId, recordTableIdName) + 1];
                existingReocrdDatarow[recordTableIdName] =
                        this.stCurrentRecordId;

                this.dtExistingRecordData.Rows.Add(existingReocrdDatarow);                
            }
            
            if (this.enmCurrentRecordType == recordType.New)
                this.dtgMoveSummary.Rows[this.dtgMoveSummary.Rows.Count - 1].Selected = true;

            this.dtgMoveSummary_UserClickeCell
                (sender, new DataGridViewCellEventArgs(0,0));

            this.enableToolBarTaskButtons();
            this.recordCanbeConfirmed = true;
            this.Enabled = true;
        }

        private void tscmdDelete_Click(object sender, EventArgs e)
        {
            
        }

        private bool createBOMChangeOrder(string bomChangeRequestID)
        {
            if (bomChangeRequestID == "")
                return false;

            DataTable changeRequestSummary =
                this.getDataFromDb.getM_BOM_CHANGEInfo(null, "", bomChangeRequestID, 
                    "", "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(changeRequestSummary))
            {
                return false;
            }

            DataTable changeRquestDetail =
                this.getDataFromDb.getM_BOM_CHANGE_LINEInfo(null, "", "", 
                    bomChangeRequestID, "", "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(changeRquestDetail))
            {
                return false;
            }

            DataTable currentBOM_Detail = 
                this.getDataFromDb.getM_PRODUCT_BOMInfo(null,"","",
                    changeRequestSummary.Rows[0]["M_PRODUCT_ID"].ToString(), "",false,false,"AND");

            DataTable bomChangeOrder = 
                this.getDataFromDb.getM_BOM_CAHNGE_ORDERInfo(null, "", "", "",
                    "", "", "", "", false, true, "");

            if (!this.getDataFromDb.checkIfTableContainesData(currentBOM_Detail))
            {
                for (int rowCounter = 0; rowCounter <= changeRquestDetail.Rows.Count - 1; rowCounter++)
                {
                    DataRow drNewBOMChangeOrder = bomChangeOrder.NewRow();
                    drNewBOMChangeOrder["EM_STATION_ID"] = generalResultInformation.Station;
                    drNewBOMChangeOrder["AD_CLIENT_ID"] = generalResultInformation.clientId;
                    drNewBOMChangeOrder["AD_ORG_ID"] = changeRequestSummary.Rows[0]["AD_ORG_ID"].ToString();
                    drNewBOMChangeOrder["ISACTIVE"] = "Y";
                    drNewBOMChangeOrder["M_BOM_CHANGE_ID"] = changeRequestSummary.Rows[0]["M_BOM_CHANGE_ID"].ToString();
                    drNewBOMChangeOrder["M_BOM_CHANGE_LINE_ID"] = changeRquestDetail.Rows[rowCounter]["M_BOM_CHANGE_LINE_ID"].ToString();
                    drNewBOMChangeOrder["REQUESTDATE"] = DateTime.Parse(changeRequestSummary.Rows[0]["REQUESTDATE"].ToString());
                    drNewBOMChangeOrder["M_PRODUCT_ID"] = changeRequestSummary.Rows[0]["M_PRODUCT_ID"].ToString();
                    drNewBOMChangeOrder["M_BOM_PRODUCT_ID"] = changeRquestDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                    drNewBOMChangeOrder["C_UOM_ID"] = changeRquestDetail.Rows[rowCounter]["C_UOM_ID"].ToString();
                    drNewBOMChangeOrder["BOMQTY"] = decimal.Parse(changeRquestDetail.Rows[rowCounter]["BOMQTY"].ToString());
                    drNewBOMChangeOrder["CHANGETYPE"] = "ADD";

                    bomChangeOrder.Rows.Add(drNewBOMChangeOrder);
                }                
            }
            else 
            {
                List<string> chngRqstPrdBomId = new List<string>();
                int chngRqstPrdBomIdIndx = -1;

                for(int rowCounter= 0; rowCounter <= changeRquestDetail.Rows.Count-1;rowCounter++)
                {
                    chngRqstPrdBomId.Add(changeRquestDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString());
                }

                List<string> currntPrdBomId = new List<string>();
                for (int rowCounter = 0; rowCounter <= currentBOM_Detail.Rows.Count - 1; rowCounter++)
                {
                    currntPrdBomId.Add(currentBOM_Detail.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString());

                    DataRow drNewBOMChangeOrder = bomChangeOrder.NewRow();
                    drNewBOMChangeOrder["EM_STATION_ID"] = generalResultInformation.Station;
                    drNewBOMChangeOrder["AD_CLIENT_ID"] = generalResultInformation.clientId;
                    drNewBOMChangeOrder["AD_ORG_ID"] = changeRequestSummary.Rows[0]["AD_ORG_ID"].ToString();
                    drNewBOMChangeOrder["ISACTIVE"] = "Y";
                    drNewBOMChangeOrder["M_BOM_CHANGE_ID"] = changeRequestSummary.Rows[0]["M_BOM_CHANGE_ID"].ToString();                    
                    drNewBOMChangeOrder["REQUESTDATE"] = DateTime.Parse(changeRequestSummary.Rows[0]["REQUESTDATE"].ToString());
                    drNewBOMChangeOrder["M_PRODUCT_ID"] = changeRequestSummary.Rows[0]["M_PRODUCT_ID"].ToString();
                                      
                    if (chngRqstPrdBomId.Contains(currentBOM_Detail.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString()))
                    {
                        chngRqstPrdBomIdIndx = 
                            chngRqstPrdBomId.IndexOf(currentBOM_Detail.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString());

                        drNewBOMChangeOrder["M_BOM_CHANGE_LINE_ID"] = changeRquestDetail.Rows[chngRqstPrdBomIdIndx]["M_BOM_CHANGE_LINE_ID"].ToString();
                        drNewBOMChangeOrder["M_BOM_PRODUCT_ID"] = changeRquestDetail.Rows[chngRqstPrdBomIdIndx]["M_PRODUCT_ID"].ToString();
                        drNewBOMChangeOrder["C_UOM_ID"] = changeRquestDetail.Rows[chngRqstPrdBomIdIndx]["C_UOM_ID"].ToString();
                        drNewBOMChangeOrder["BOMQTY"] = decimal.Parse(changeRquestDetail.Rows[chngRqstPrdBomIdIndx]["BOMQTY"].ToString());
                        drNewBOMChangeOrder["CHANGETYPE"] = "MODIFY";
                    }
                    else
                    {
                        drNewBOMChangeOrder["M_BOM_PRODUCT_ID"] = currentBOM_Detail.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString();
                        drNewBOMChangeOrder["C_UOM_ID"] = 0;
                        drNewBOMChangeOrder["BOMQTY"] = 0;
                        drNewBOMChangeOrder["CHANGETYPE"] = "REMOVE";
                    }

                    bomChangeOrder.Rows.Add(drNewBOMChangeOrder);

                }


                for (int rowCounter = 0; rowCounter <= changeRquestDetail.Rows.Count - 1; rowCounter++)
                {
                    if (!currntPrdBomId.Contains(changeRquestDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString()))
                    {
                        DataRow drNewBOMChangeOrder = bomChangeOrder.NewRow();
                        drNewBOMChangeOrder["EM_STATION_ID"] = generalResultInformation.Station;
                        drNewBOMChangeOrder["AD_CLIENT_ID"] = generalResultInformation.clientId;
                        drNewBOMChangeOrder["AD_ORG_ID"] = changeRequestSummary.Rows[0]["AD_ORG_ID"].ToString();
                        drNewBOMChangeOrder["ISACTIVE"] = "Y";
                        drNewBOMChangeOrder["M_BOM_CHANGE_ID"] = changeRequestSummary.Rows[0]["M_BOM_CHANGE_ID"].ToString();
                        drNewBOMChangeOrder["M_BOM_CHANGE_LINE_ID"] = changeRquestDetail.Rows[rowCounter]["M_BOM_CHANGE_LINE_ID"].ToString();
                        drNewBOMChangeOrder["REQUESTDATE"] = DateTime.Parse(changeRequestSummary.Rows[0]["REQUESTDATE"].ToString());
                        drNewBOMChangeOrder["M_PRODUCT_ID"] = changeRequestSummary.Rows[0]["M_PRODUCT_ID"].ToString();

                        drNewBOMChangeOrder["M_BOM_PRODUCT_ID"] = changeRquestDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                        drNewBOMChangeOrder["C_UOM_ID"] = changeRquestDetail.Rows[rowCounter]["C_UOM_ID"].ToString();
                        drNewBOMChangeOrder["BOMQTY"] = decimal.Parse(changeRquestDetail.Rows[rowCounter]["BOMQTY"].ToString());
                        drNewBOMChangeOrder["CHANGETYPE"] = "ADD";

                        bomChangeOrder.Rows.Add(drNewBOMChangeOrder);
                    }
                }

            }

            this.getDataFromDb.changeDataBaseTableData(bomChangeOrder, "M_BOM_CAHNGE_ORDER", "INSERT");
            return true;
        }

        private void tscmdConfirm_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            this.Enabled = false;
            this.tscmdSave_Click(sender, e);
            this.Enabled = false;

            if (!this.recordCanbeConfirmed)
            {
                this.Enabled = true;
                return;
            }
            
            this.changeMainRecordTableStructure();

            string recordStatusName = "DOCSTATUS";
            string recordTableName = "M_BOM_CHANGE";
            string recordTableIdName = "M_BOM_CHANGE_ID";
            string stCurrentRecordNewStatus = "";

            
            int[] recordResult =
                this.searchTableRowIndex(this.dtExistingRecordData,
                                        recordTableIdName, this.stCurrentRecordId);

            if (recordResult.Length > 0)
            {
                if (recordResult[0] > -1)
                {
                    if (this.dtExistingRecordData.Rows[recordResult[0]]["DOCSTATUS"].ToString() == "Draft")
                    {
                        this.dtExistingRecordData.Rows[recordResult[0]]["DOCSTATUS"] = "Requested";
                        stCurrentRecordNewStatus = "RQ";
                    }
                    else
                    {
                        this.dtExistingRecordData.Rows[recordResult[0]]["DOCSTATUS"] = "Approved";
                        stCurrentRecordNewStatus = "AP";
                    }
                }
            }

            DataRow drMainRecordRow = this.dtRecordMainData.NewRow();

            drMainRecordRow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
            drMainRecordRow[recordTableIdName] = this.stCurrentRecordId;
            drMainRecordRow[recordStatusName] = stCurrentRecordNewStatus;

            this.dtRecordMainData.Rows.Add(drMainRecordRow);

            if (stCurrentRecordNewStatus == "AP")
            {
                if(!this.createBOMChangeOrder(this.stCurrentRecordId))
                {
                    this.Enabled = true;
                    return;
                }
            }

            this.getDataFromDb.changeDataBaseTableData(this.dtRecordMainData,
                recordTableName, "UPDATE");
            
            this.dtgMoveSummary_UserClickeCell
                (sender, new DataGridViewCellEventArgs(0,
                    this.dtgMoveLine.SelectedRows[0].Index));

            this.Enabled = true;
        }

        private void tscmdReject_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            this.Enabled = false;
            
            this.changeMainRecordTableStructure();

            string recordStatusName = "DOCSTATUS";
            string recordTableName = "M_BOM_CHANGE";
            string recordTableIdName = "M_BOM_CHANGE_ID";
            string stCurrentRecordNewStatus = "Cancelled";

            DataRow drMainRecordRow = this.dtRecordMainData.NewRow();

            drMainRecordRow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
            drMainRecordRow[recordTableIdName] = this.stCurrentRecordId;
            drMainRecordRow[recordStatusName] = "VO";
            

            this.dtRecordMainData.Rows.Add(drMainRecordRow);

            this.getDataFromDb.changeDataBaseTableData(this.dtRecordMainData,
                recordTableName, "UPDATE");

            int[] recordResult =
                this.searchTableRowIndex(this.dtExistingRecordData,
                                        recordTableIdName, this.stCurrentRecordId);
            if (recordResult.Length > 0)
                if (recordResult[0] > -1)
                    this.dtExistingRecordData.Rows[recordResult[0]]["DOCSTATUS"] =
                        stCurrentRecordNewStatus;

            this.dtgMoveSummary_UserClickeCell
                (sender, new DataGridViewCellEventArgs(0,
                    this.dtgMoveLine.SelectedRows[0].Index));

            this.Enabled = true;
        }


        private void tscmdSearch_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchResult.Columns.Clear();

            frmSearchInventoryMakeUpChange newSearch = new frmSearchInventoryMakeUpChange();
            newSearch.ShowDialog(this);

            this.loadSearchResultDataToExistingMainRecord();
            this.fillSearchResultToMainRecordGridView();

            if (this.dtgMoveSummary.Rows.Count > 0)
            {
                this.dtgMoveSummary.Rows[0].Selected = true;
            }

            this.enmCurrentTask = taskType.Makeup;
           
            this.dtgMoveSummary_UserClickeCell(sender, new DataGridViewCellEventArgs(0, 0));

            this.enableDisableNavigationButtons();
            this.enableToolBarTaskButtons();
        }
        
        private void tscmdToggelView_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            if (this.currentViewIsRecordView)
            {
                this.dtgMoveLine.Dock = DockStyle.Fill;
                this.dtgMoveSummary.Dock = DockStyle.Fill;
                this.dtgMoveSummary.BringToFront();
                this.ddgProductBOM.SendToBack();
                this.dtgMoveSummary.Visible = true;
                
            }
            else
            {
                this.dtgMoveLine.Dock = DockStyle.None;
                this.dtgMoveSummary.Visible = false;
                this.dtgMoveSummary.SendToBack();
                this.ddgProductBOM.BringToFront();
                this.dtgMoveSummary.Dock = DockStyle.None;
            }
            this.currentViewIsRecordView = !this.currentViewIsRecordView;

        }


        private void tscmdFirstRecord_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            if (this.dtgMoveSummary.Rows.Count < 1)
                return;
            this.dtgMoveSummary.Rows[0].Selected = true;
            this.dtgMoveSummary_UserClickeCell(sender, new DataGridViewCellEventArgs(0, 0));            
        }

        private void tscmdPreviousRecord_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            if (this.dtgMoveSummary.Rows.Count < 1)
                return;
            if (this.intCurrentRecordNumber == 0)
                return;
            this.dtgMoveSummary.Rows[this.intCurrentRecordNumber-1].Selected = true;
            this.dtgMoveSummary_UserClickeCell(sender, new DataGridViewCellEventArgs(0,
                this.intCurrentRecordNumber - 1));            
        }

        private void tscmdNextRecord_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            if (this.dtgMoveSummary.Rows.Count < 1)
                return;
            if (this.intCurrentRecordNumber ==
                this.dtgMoveSummary.Rows.Count-1)
                return;
            this.dtgMoveSummary.Rows[this.intCurrentRecordNumber + 1].Selected = true;
            this.dtgMoveSummary_UserClickeCell(sender, new DataGridViewCellEventArgs(0,
                this.intCurrentRecordNumber + 1));            
        }

        private void tscmdLastRecord_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            if (this.dtgMoveSummary.Rows.Count < 1)
                return;
            this.dtgMoveSummary.Rows[this.dtgMoveSummary.Rows.Count - 1].Selected = true;
            this.dtgMoveSummary_UserClickeCell(sender, new DataGridViewCellEventArgs(0,
                this.dtgMoveSummary.Rows.Count - 1));
        }


        private void tscmdPrintDocument_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.tmrCloseWindow.Enabled = false;
            if (this.documentPreviewHidden)
            {
                this.tscmdShowPrintPreview.Checked = true;
                this.tscmdShowPrintPreview_Click(sender, e);
            }

            if (this.documentPreviewHidden)
            {
                this.tscmdShowPrintPreview.Checked = false;
                this.Enabled = true;
                return;
            }
            DialogResult printOrderResponse =
                MessageBox.Show("Are you sure you want to print this Document?", "Printing",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (printOrderResponse == DialogResult.No)
            {
                this.documentPreviewHidden = true;
                this.tscmdShowPrintPreview.Checked = false;
                this.crvPrintPreview.Hide();
                this.Enabled = true;
                return;
            }
            else if (printOrderResponse == DialogResult.Cancel)
            {
                this.Enabled = true;
                return;
            }

            try
            {
                this.crptMaterialMovement.PrintOptions.PrinterName =
                    dbSettingInformationHandler.PrinterName;
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                this.tscmdShowPrintPreview.Checked = false;
                return;
            }
            if (this.crptMaterialMovement.PrintOptions.PrinterName == "")
            {
                MessageBox.Show("No printer Found. \n Contact Your Administrator", "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                this.tscmdShowPrintPreview.Checked = false;
                return;
            }

        printDocument:
            try
            {
                this.crptMaterialMovement.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                this.tscmdShowPrintPreview.Checked = false;
                return;
            }

            if (MessageBox.Show("Did document printed?", "Printing",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Record Print Job.
                DataTable dtNewPrintJob =
                    this.getDataFromDb.getEM_PRINTJOBInfo(null, "", "", "", "", "", true, "");
                if (dtNewPrintJob.Columns.Count <= 0)
                {
                    MessageBox.Show("Print Job Not Recorded. Contac Your Administrator.", "Printing",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.tscmdShowPrintPreview.Checked = false;
                    this.Enabled = true;
                    return;
                }
                string stTableName = "M_BOM_CHANGE";
                
                DataRow drNewPrintJob = dtNewPrintJob.NewRow();
                //drNewPrintJob["EM_PRINTJOB_ID"] = "";
                drNewPrintJob["EM_STATION_ID"] = generalResultInformation.Station;
                drNewPrintJob["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewPrintJob["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
                drNewPrintJob["CREATEDBY"] = generalResultInformation.userId;
                drNewPrintJob["C_DOCTYPE_ID"] = this.stCurrentDocumentId;
                drNewPrintJob["DOCUMENTNO"] = this.txtDocumentNumber.Text;
                drNewPrintJob["RECORD_ID"] = this.stCurrentRecordId;
                drNewPrintJob["RECORDTABLENAME"] = stTableName;
                dtNewPrintJob.Rows.Add(drNewPrintJob);
                this.getDataFromDb.changeDataBaseTableData(dtNewPrintJob, "EM_PRINTJOB", "INSERT");
                this.documentPreviewHidden = true;
                this.tscmdShowPrintPreview.Checked = false;
                this.crvPrintPreview.Hide();
            }
            else
            {
                //Request and execute re-printing.
                if (MessageBox.Show("Do you want RE-TRY printing this Document?", "Printing",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    goto printDocument;
                }
            }
            this.tscmdShowPrintPreview.Checked = false;
            this.tmrCloseWindow.Enabled = true;
            this.Enabled = true;
        }
                
        private void tscmdShowPrintPreview_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.tmrCloseWindow.Enabled = false;
            if (!System.IO.File.Exists("crptInventoryMakeChangeRequest.rpt"))
            {
                this.documentPreviewHidden = true;
                MessageBox.Show("Unable To find Crystal Report. \n Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tscmdShowPrintPreview.Checked = false;
                this.Enabled = true;
                return;
            }

            if (!this.tscmdShowPrintPreview.Checked)
            {
                this.documentPreviewHidden = true;
                this.crvPrintPreview.Hide();
                this.ddgProductBOM.BringToFront();
                this.Enabled = true;
                return;
            }

            if (!this.userCanPrintCurrentRecord())
            {
                this.documentPreviewHidden = true;
                this.crvPrintPreview.Hide();
                this.Enabled = true;
                return;
            }

            this.ddgProductBOM.SendToBack();

            string stTableName = "M_BOM_CHANGE";
            
            string numberOfPrints = "";

            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Clear();// .Rows.Clear();
            this.dsCurrentMovementInfo.Tables["dtDocumentDetail"].Clear();//.Rows.Clear();            

            DataTable dtMovementDetailInfo = new DataTable();

            DataTable dtPrinthistory =
                this.getDataFromDb.getEM_PRINTJOBInfo(null, "", "", stTableName,
                        this.stCurrentRecordId, "", false, "AND");

            if (dtPrinthistory.Rows.Count > 0)
            {
                numberOfPrints = "rePrint " + dtPrinthistory.Rows.Count.ToString();
            }

            DataRow drDocumentSummary =
                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].NewRow();

            dtMovementDetailInfo =
                this.dtRecordDetailData.Copy();

            drDocumentSummary["MovementId"] = this.stCurrentRecordId;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows.Add(drDocumentSummary);

            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentNumber"] =
                this.txtDocumentNumber.Text;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentDate"] =
                this.dtpMoveDate.Value;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentName"] =
                this.cmbDocumentType.Text;

            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["RequestNumber"] =
                    this.ddgProduct.SelectedItem;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["MovementId"] =
                this.stCurrentRecordId;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentNote"] =
                this.txtDescriptionOrComment.Text;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["PreparedBy"] =
                generalResultInformation.userBPName;
            this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["rePrint"] =
                numberOfPrints;


            dtMovementDetailInfo.Columns["LINE"].ColumnName = "Sn.";
            dtMovementDetailInfo.Columns["PRODUCT"].ColumnName = "Description";
            dtMovementDetailInfo.Columns["UNIT"].ColumnName = "Unit";
            dtMovementDetailInfo.Columns["BOMQTY"].ColumnName = "Quantity";
            dtMovementDetailInfo.Columns["DESCRIPTION"].ColumnName = "comment";
            dtMovementDetailInfo.Columns.Add("Remark");

            
            for (int rowCounter = dtMovementDetailInfo.Columns.Count - 1;
                rowCounter >= 0; rowCounter--)
                if (!dtDocumentDetailTabe.Columns.Contains
                        (dtMovementDetailInfo.Columns[rowCounter].ColumnName))
                    dtMovementDetailInfo.Columns.RemoveAt(rowCounter);

            DataRow drMovementDetailInfoForReporting;
            int[] searchResultOfIndexToInsert;
            int rowIndexToInsert;

            for (int rowCounter = 0;
                rowCounter <= dtMovementDetailInfo.Rows.Count - 1; rowCounter++)
            {
                drMovementDetailInfoForReporting =
                    this.dsCurrentMovementInfo.Tables["dtDocumentDetail"].NewRow();

                searchResultOfIndexToInsert = this.searchTableRowIndex(dtMovementDetailInfo,
                                                            "Sn.", (rowCounter + 1).ToString());

                rowIndexToInsert = searchResultOfIndexToInsert[0];
                if (rowIndexToInsert.ToString() == null)
                    continue;

                drMovementDetailInfoForReporting["Sn."] =
                    dtMovementDetailInfo.Rows[rowIndexToInsert]["Sn."];
                drMovementDetailInfoForReporting["Description"] =
                    dtMovementDetailInfo.Rows[rowIndexToInsert]["Description"];
                drMovementDetailInfoForReporting["Unit"] =
                    dtMovementDetailInfo.Rows[rowIndexToInsert]["Unit"];
                drMovementDetailInfoForReporting["Quantity"] =
                    dtMovementDetailInfo.Rows[rowIndexToInsert]["Quantity"];
                drMovementDetailInfoForReporting["comment"] =
                    dtMovementDetailInfo.Rows[rowIndexToInsert]["comment"];

                this.dsCurrentMovementInfo.Tables["dtDocumentDetail"].Rows.Add(drMovementDetailInfoForReporting);
            }

            this.crptMaterialMovement.Refresh();
            this.crptMaterialMovement.FileName = "crptInventoryMakeChangeRequest.rpt";
            
            this.crptMaterialMovement.SetDataSource(this.dsCurrentMovementInfo);

            this.crvPrintPreview.ReportSource = this.crptMaterialMovement;
            this.crvPrintPreview.Zoom(100);
            this.crvPrintPreview.Show();

            this.documentPreviewHidden = false;
            this.tmrCloseWindow.Enabled = true;
            this.Enabled = true;
        }


        private void tscmdTaskMode_Click(object sender, EventArgs e)
        {
            return;
            /*
            this.hidePrintPreview();
            if (this.enmCurrentRecordType != recordType.New)
                return;
            else
            {
                if (this.userCanCreateNewDispatch &&
                    this.userCanCreateNewRequest)
                {
                    this.changeCurrentTask(taskType.Unkown);
                    this.prepareForNewTask(this.enmCurrentTask);
                }
                else if (this.userCanCreateNewRequest)
                {
                    this.prepareForNewTask(taskType.Request);
                }
                else if (this.userCanCreateNewDispatch)
                {
                    this.prepareForNewTask(taskType.Dispatch);
                }
                else
                {
                    this.prepareForNewTask(taskType.Unkown);
                }

                //this.clearStructureAndDataOfDataTable(this.dtRecordDetailData);
                //this.clearStructureAndDataOfDataTable(this.dtRecordMainData);
                //this.dtRecordDetailData.Clear();
                //this.dtRecordMainData.Clear();
                //this.changeRecordDetailTableStructure();
                //this.changeMainRecordTableStructure();
                //this.changeInterfaceToCurrentTaskAndRecordMode();
                //this.fillDataToRecordDetailGidView();
            }*/            
        }

        private void tscmdViewStock_Click(object sender, EventArgs e)
        {
            frmInventory showStock = new frmInventory();
            showStock.ShowDialog();
        }

        private void tscmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdAddOrModifyRecordDetail_Click(object sender, EventArgs e)
        {
            if (allowedLineCount >= 0 && this.dtRecordDetailData.Rows.Count >= allowedLineCount &&
                this.cmdAddOrModifyRecordDetail.Text == "ADD")
            {
                MessageBox.Show("Document Line count Exceed Maximum Allowed number.", "Easy Move",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.sbStatusLabel.Text = "Document Line count Exceed Maximum Allowed number.";
                goto exitAdd;
            }

            if (this.ntbQuantity.Amount == "0" ||
                this.ntbQuantity.Amount == "")
            {
                MessageBox.Show("Please Input Quantity.", "Easy Move", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.ddgProductBOM.SelectedRowKey == null)
            {
                MessageBox.Show("Please Select Product.", "Easy Move",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                        
            this.addOrModifyRecordDetail(false);
            
            exitAdd:

            this.ddgProductBOM.SelectedRowKey = null;
            this.ddgProductBOM.SelectedItem = "";
            this.ddgProductBOM.SelectedRow.Clear();
            this.ddgProductBOM_selectedItemChanged(sender, e);
            
            this.txtRecordDetailDescription.Text = "";
            this.cmdAddOrModifyRecordDetail.Text = "ADD";            

            this.stCurrentDetailRecordId = "";
            this.stCurrentDetailRecordLineNumber = "";
        }
        

        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation = 
                getDataAccordingToRule.getProducts(true, true,triStateBool.ignor,
                                triStateBool.ignor, triStateBool.ignor, triStateBool.yes,
                                triStateBool.No, false, this.ddgProduct.SelectedItem,
                                "", true);

            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey = 
                Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex = 
                productInformation.Columns.IndexOf("NAME");
            this.ddgProduct.HiddenColoumns = new int[]{ productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID")};
            //this.ddgProductBOM.BringToFront();
            
        }
       
        private void ddgProduct_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!this.blddgProductControlerOutOfFocus && 
                this.stCurrentProductId == this.ddgProduct.SelectedRowKey.ToString())
            {
                return;
            }

            this.blddgProductControlerOutOfFocus = false;

            this.dtRecordDetailData.Clear();
            if (this.ddgProduct.SelectedItem == "" || this.ddgProduct.SelectedRowKey == null)
            {
                
                this.stCurrentProductId = "";
                this.cmdShowBOM.Enabled = false;

                this.ddgProductBOM.Enabled = false;
                this.ddgProductBOM.SelectedRowKey = null;
                this.ddgProductBOM.SelectedItem = "";
                this.ntbQuantity.Enabled = false;
                this.txtRecordDetailDescription.Enabled = false;
                this.lblUOM.Text = "";
                this.cmdAddOrModifyRecordDetail.Enabled = false;

                return;
            }

            this.ddgProductBOM.Enabled = true;

            this.cmdShowBOM.Enabled = true;
            this.stCurrentProductId = this.ddgProduct.SelectedRowKey.ToString();

            DataTable dtProductBOM = 
                this.getDataFromDb.getM_PRODUCT_BOMInfo(null, "", "",
                        this.stCurrentProductId, "", true, false, "AND");

            if(!this.getDataFromDb.checkIfTableContainesData(dtProductBOM))
            {
                return;
            }

            int ln = 0;

            DataRow newDetailRw;

            foreach (DataRow prdBOM in dtProductBOM.Rows)
            {
                newDetailRw = this.dtRecordDetailData.NewRow();
                newDetailRw["remove"] = "remove";
                newDetailRw["LINE"] = ++ln;
                newDetailRw["PRODUCT"] =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "", prdBOM["M_PRODUCTBOM_ID"].ToString(),
                            false, triStateBool.ignor, triStateBool.ignor,
                                false, "AND").Rows[0]["NAME"].ToString();
                newDetailRw["C_UOM_ID"] =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "", prdBOM["M_PRODUCTBOM_ID"].ToString(),
                            false, triStateBool.ignor, triStateBool.ignor,
                                false, "AND").Rows[0]["C_UOM_ID"].ToString(); ;
                newDetailRw["UNIT"] =
                    this.getDataFromDb.getEM_C_UOMInfo(null, "", newDetailRw["C_UOM_ID"].ToString(),
                            false, false, "AND").Rows[0]["NAME"].ToString();
                newDetailRw["BOMQTY"] = prdBOM["BOMQTY"];
                newDetailRw["M_PRODUCT_ID"] = prdBOM["M_PRODUCTBOM_ID"];

                this.dtRecordDetailData.Rows.Add(newDetailRw);
            }
            
        }


        private void ddgProductBOM_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation =
                getDataAccordingToRule.getProducts(true, true, triStateBool.ignor,
                                triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                triStateBool.No, false, this.ddgProductBOM.SelectedItem,
                                "", true);

            ddgProductBOM.DataSource = productInformation;
            ddgProductBOM.DataTablePrimaryKey =
                Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProductBOM.SelectedColomnIdex =
                productInformation.Columns.IndexOf("NAME");
            this.ddgProductBOM.HiddenColoumns = new int[]{ productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID")};
        }

        private void ddgProductBOM_selectedItemChanged(object sender, EventArgs e)
        {
            this.ntbQuantity.Amount = "0";
            this.lblInStockQty.Text = "0";
            
            if (ddgProductBOM.SelectedRowKey == null)
            {
                this.ntbQuantity.Enabled = false;
                this.txtRecordDetailDescription.Enabled = false;
                this.lblUOM.Text = "";
                this.cmdAddOrModifyRecordDetail.Enabled = false;
            }
            else
            {
                this.ntbQuantity.Enabled = true;
                this.txtRecordDetailDescription.Enabled = true;
                this.cmdAddOrModifyRecordDetail.Enabled = true;

                if (this.ddgProductBOM.SelectedRow.Rows.Count > 0)
                {
                    this.lblUOM.Text =
                        this.getDataFromDb.getEM_C_UOMInfo(null, "",
                                ddgProductBOM.SelectedRow.Rows[0]["C_UOM_ID"].ToString(),
                                false, false, "AND").Rows[0]["UOMSYMBOL"].ToString();
                    this.ntbQuantity.StandardPrecision =
                        int.Parse(this.getDataFromDb.getEM_C_UOMInfo(null, "",
                        ddgProductBOM.SelectedRow.Rows[0]["C_UOM_ID"].ToString(), false, false, "AND")
                        .Rows[0]["STDPRECISION"].ToString());
                }
                else if (this.ddgProductBOM.SelectedRowKey.ToString() != "")
                {
                    string currentProductUOMId =
                        this.getDataFromDb.getEM_M_PRODUCTInfo(
                                            null, "",
                                            this.ddgProductBOM.SelectedRowKey.ToString(), false,
                                           triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["C_UOM_ID"].ToString();

                    this.lblUOM.Text =
                        this.getDataFromDb.getEM_C_UOMInfo(null, "", currentProductUOMId,
                                    false, false, "AND")
                                 .Rows[0]["UOMSYMBOL"].ToString();

                    this.ntbQuantity.StandardPrecision =
                        int.Parse(this.getDataFromDb.getEM_C_UOMInfo(null, "", currentProductUOMId,
                                false, false, "AND")
                              .Rows[0]["STDPRECISION"].ToString());
                }

                this.ntbQuantity.Enabled = true;
                this.txtRecordDetailDescription.Enabled = true;
                this.cmdAddOrModifyRecordDetail.Enabled = true;
            }
        }
     

        private void cmbOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (this.cmbOrganisation.SelectedIndex >= 0 &&
                this.cmbOrganisation.SelectedIndex <=
                this.dtActiveOrganisationsAccessableToUser.Rows.Count - 1)
            {
                this.stCurrentRecordOrganisationId =
                    this.dtActiveOrganisationsAccessableToUser.
                                    Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
                
                if (this.cmbDocumentType.Items.Count > 0)
                    this.cmbDocumentType.SelectedIndex = 0;
                
            }
            else
            {
                this.stCurrentRecordOrganisationId = "";                
            }
        }

        private void cmbOrganisation_KeyUp(object sender, KeyEventArgs e)
        {   
            dtActiveOrganisationsAccessableToUser.Clear();
            dtActiveOrganisationsAccessableToUser =
                    getDataAccordingToRule.getOrganisations(true, true);
        }

        private void cmbOrganisation_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cmbOrganisation.SelectedItem != null)
                this.cmbOrganisation.Text = this.cmbOrganisation.SelectedItem.ToString();
                        
            this.cmbOrganisation_KeyUp(sender, new KeyEventArgs(Keys.Enter));
            
            this.comboBoxDropDownClosed(this.cmbOrganisation, dtActiveOrganisationsAccessableToUser,
                this.cmbOrganisation_SelectedIndexChanged, sender);            
        }


        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDocumentType.SelectedIndex >= 0 &&
                this.cmbDocumentType.SelectedIndex <= this.dtDocumentsAccessableToUser.Rows.Count - 1)
            {
                string newDocumentNumber = "";
                this.stCurrentDocumentId =
                    this.dtDocumentsAccessableToUser.Rows[this.cmbDocumentType.SelectedIndex]
                    ["C_DOCTYPE_ID"].ToString();
                DataTable sequenceInfoForDocument =
                    getDataFromDb.getEM_C_DOCTYPEInfo(null, "", this.stCurrentDocumentId,
                    true, false, "AND");
                if (getDataFromDb.checkIfTableContainesData(sequenceInfoForDocument))
                {
                    newDocumentNumber = getDataFromDb.getNextSequenceId("",
                        sequenceInfoForDocument.Rows[0]["DOCNOSEQUENCE_ID"].ToString(), generalResultInformation.Station,
                        "", false);
                    if (newDocumentNumber != "")
                        newDocumentNumber = "<<" + newDocumentNumber + ">>";
                }
                this.txtDocumentNumber.Text = newDocumentNumber;
            }
            else
            {
                this.stCurrentDocumentId = "";
                this.txtDocumentNumber.Text = "";
            }
        }

        private void cmbDocumentType_KeyUp(object sender, KeyEventArgs e)
        {
            //this.dtDocumentsAccessableToUser =
            //    getDataAccordingToRule.getDocuments(true, true, "", true, this.enmCurrentTask);
            //this.comboItemFilter(this.cmbDocumentType, dtDocumentsAccessableToUser, e, "NAME");
        }

        private void cmbDocumentType_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cmbDocumentType.SelectedItem != null)
                this.cmbDocumentType.Text = this.cmbDocumentType.SelectedItem.ToString();

            this.cmbDocumentType_KeyUp(sender, new KeyEventArgs(Keys.Enter));

            this.comboBoxDropDownClosed(this.cmbDocumentType, dtDocumentsAccessableToUser,
                this.cmbDocumentType_SelectedIndexChanged, sender);
        }
                

        private void comboItemFilter(ComboBox _comboBoxControl, DataTable tableToFill,
            KeyEventArgs e, string columnNameToInsert)
        {
            if (e.KeyCode != Keys.Enter)
                _comboBoxControl.DroppedDown = true;

            _comboBoxControl.Items.Clear();

            if (_comboBoxControl.Text == "")
            {
                this.insetDataIntoComboBox(_comboBoxControl, tableToFill,
                    tableToFill.Columns.IndexOf(columnNameToInsert), -1);
            }
            else
            {
                for (int currentRowIndex = tableToFill.Rows.Count - 1;
                    currentRowIndex >= 0; currentRowIndex--)
                {
                    if (!tableToFill
                            .Rows[currentRowIndex][columnNameToInsert].ToString().ToUpper().Contains
                                                (_comboBoxControl.Text.ToUpper()))
                        tableToFill.Rows.RemoveAt(currentRowIndex);
                }
                int selectedIndex = -1;
                if (tableToFill.Rows.Count == 1)
                    selectedIndex = 0;

                this.insetDataIntoComboBox(_comboBoxControl, tableToFill,
                    tableToFill.Columns.IndexOf(columnNameToInsert), selectedIndex);
            }
            _comboBoxControl.SelectionStart = _comboBoxControl.Text.Length;
            _comboBoxControl.SelectionLength = 0;
        }

        private void comboBoxDropDownClosed(ComboBox _comboBoxControl, DataTable tableDataFilledWith,
            EventHandler _comboSelectionChanged, object sender)
        {
            if (_comboBoxControl.SelectedIndex >= 0 &&
                _comboBoxControl.SelectedIndex <= _comboBoxControl.Items.Count - 1)
            {
                if (tableDataFilledWith.Rows.Count <=
                    _comboBoxControl.SelectedIndex)
                {
                    _comboBoxControl.Text = "";
                    _comboBoxControl.SelectedIndex = -1;
                    _comboBoxControl.SelectedItem = "";
                }
            }
            else
            {
                _comboBoxControl.Text = "";
                _comboBoxControl.SelectedIndex = -1;
                _comboBoxControl.SelectedItem = "";

            }

            object[] selectionChangedParameters = { new object(), new KeyEventArgs(Keys.Enter) };
            Invoke(_comboSelectionChanged, selectionChangedParameters);
        }


        private void dtgMoveSummary_UserClickeCell(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgMoveSummary.SelectedRows.Count < 1)
                return;


            this.cmbOrganisation.DropDownStyle = ComboBoxStyle.Simple;
            this.cmbDocumentType.DropDownStyle = ComboBoxStyle.Simple;
                        
            this.intCurrentRecordNumber = this.dtgMoveSummary.SelectedRows[0].Index;

            //this.enmCurrentRecordStatus =
            //    this.dtgMoveSummary.SelectedRows[0].Cells["DOCSTATUS"].Value.ToString();
            
            this.enmCurrentTask = taskType.Makeup;
            

            this.stCurrentRecordId =
                               this.dtgMoveSummary.Rows[this.intCurrentRecordNumber].
                                       Cells["M_BOM_CHANGE_ID"].Value.ToString();
            
            this.determineCurrentRecordType(recordType.unkown);

            //Clear Record Detial Info
            this.ddgProductBOM.SelectedItem = "";
            this.ddgProductBOM.SelectedRowKey = null;
            this.ddgProductBOM_selectedItemChanged(sender, e);

            //Fill Main Record Grid Data to form
            this.fillCurrentGirdDataToForm();
            
            this.changeCurrentTask(this.enmCurrentTask);

            //Determine if user can remove or add new item to detail record
            this.determineUserCurrentRecordPrevilage();
            //determine if user can modify product or quantity of detail record
            this.changeInterfaceToCurrentTaskAndRecordMode();
            this.enableDisableNavigationButtons();
            this.enableToolBarTaskButtons();

            
            //Get and Fill Record Detail to Record Detail Grid Data
            this.getAndfillCurrentRecordDetailTodtRecordDetail();
            this.fillDataToRecordDetailGidView();
            
        }

        private void dtgMoveLine_UserClickedCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgMoveLine.SelectedRows.Count < 1 ||
                !this.usersCanEditRecordDetail)
            {
                return;
            }

            this.changeQuantityColumnNameToAddModify();

            if (this.stQuantyColumnNameToAddOrModify == "")
                return;

            int currentSelectedRowIndex = 
                this.dtgMoveLine.SelectedRows[0].Index;

            this.stCurrentDetailRecordLineNumber =
                this.dtgMoveLine.Rows[currentSelectedRowIndex].Cells["LINE"].Value.ToString();

            this.stCurrentDetailRecordId =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["M_BOM_CHANGE_LINE_ID"].Value.ToString();

            if (
                 this.dtgMoveLine.CurrentCell.OwningColumn.Index == 0 &&
                 this.dtgMoveLine.CurrentCell.OwningColumn.Name == "remove" &&
                 this.dtgMoveLine.CurrentCell.Value.ToString() == "remove" &&
                 this.dtgMoveLine.CurrentCell.OwningColumn.HeaderText == ""
               )
            {
                this.addOrModifyRecordDetail(true);
                this.stCurrentDetailRecordLineNumber = "";
                this.stCurrentDetailRecordId = "";
                this.ddgProductBOM.SelectedRowKey = null;
                this.ddgProductBOM.SelectedItem = "";
                this.cmdAddOrModifyRecordDetail.Text = "ADD";
                this.ddgProductBOM.SelectedRow.Clear();
                this.ddgProductBOM_selectedItemChanged(sender, e);
            }
            else
            {
                this.ddgProductBOM.SelectedRowKey =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["M_PRODUCT_ID"].Value.ToString();
                this.ddgProductBOM.SelectedItem =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["PRODUCT"].Value.ToString();

                this.ddgProductBOM_selectedItemChanged(sender, e);

                this.ntbQuantity.Amount =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells[stQuantyColumnNameToAddOrModify].Value.ToString();
                this.txtRecordDetailDescription.Text =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["DESCRIPTION"].Value.ToString();
                this.cmdAddOrModifyRecordDetail.Text = "Modify";
            }
        }


        private void mnuNewMovement_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuNewRequest_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuSaveReocord_Click(object sender, EventArgs e)
        {
            if (this.tscmdSave.Enabled)
                this.tscmdSave_Click(sender, e);
        }

        private void mnuDeleteReocrd_Click(object sender, EventArgs e)
        {
            if(this.tscmdDelete.Enabled)
                this.tscmdDelete_Click(sender,e);
        }

        private void mnuConfirmReocrd_Click(object sender, EventArgs e)
        {
            if (this.tscmdConfirm.Enabled)
                this.tscmdConfirm_Click(sender, e);
        }

        private void mnuRejectRecord_Click(object sender, EventArgs e)
        {
            if (this.tscmdReject.Enabled)
                this.tscmdReject_Click(sender, e);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void mnuSearchRecord_Click(object sender, EventArgs e)
        {
            if (this.tscmdSearch.Enabled)
                this.tscmdSearch_Click(sender, e);
        }

        private void mnuToggleView_Click(object sender, EventArgs e)
        {
            if (this.tscmdToggelView.Enabled)
                this.tscmdToggelView_Click(sender, e);
        }

        private void mnuFirstRecord_Click(object sender, EventArgs e)
        {
            if (this.tscmdFirstRecord.Enabled)
                this.tscmdFirstRecord_Click(sender, e);
        }

        private void mnuPreviousRecord_Click(object sender, EventArgs e)
        {
            if (this.tscmdPreviousRecord.Enabled)
                this.tscmdPreviousRecord_Click(sender, e);
        }

        private void mnuNextRecord_Click(object sender, EventArgs e)
        {
            if (this.tscmdNextRecord.Enabled)
                this.tscmdNextRecord_Click(sender, e);
        }

        private void mnuLastRecord_Click(object sender, EventArgs e)
        {
            if (this.tscmdLastRecord.Enabled)
                this.tscmdLastRecord_Click(sender, e);
        }


        private void mnuDataBaseConnection_Click(object sender, EventArgs e)
        {
            frmsettings frmDbConnection = new frmsettings();
            frmDbConnection.ShowDialog(this);
        }

        private void mnuStationAccess_Click(object sender, EventArgs e)
        {
            //frmUserSationAccess frmUserSationAccess = new frmUserSationAccess();
            //frmUserSationAccess.ShowDialog(this);
        }

        private void mnuProcessAccess_Click(object sender, EventArgs e)
        {
            frmUserProcessAccess frmUserProcessAccess = new frmUserProcessAccess();
            frmUserProcessAccess.ShowDialog(this);
        }

        private void mnuWarehouseAccess_Click(object sender, EventArgs e)
        {
            frmUserWarehouseAccess frmUserWarehouseAccess = new frmUserWarehouseAccess();
            frmUserWarehouseAccess.ShowDialog(this);
        }       

   
        private bool userCanPrintCurrentRecord()
        {
            if (this.enmCurrentRecordType != recordType.Existing)
            {
                return false;
            }

            if (
                (this.dtgMoveSummary.SelectedRows[0].Cells["CREATEDBY"].Value.ToString() !=
                generalResultInformation.userId) &&
                (this.dtgMoveSummary.SelectedRows[0].Cells["UPDATEDBY"].Value.ToString() !=
                generalResultInformation.userId)
               )
            {
                return false;
            }

            string stDocumentInitiatorOrganisation =
                this.dtgMoveSummary.SelectedRows[0].Cells["AD_ORG_ID"].Value.ToString();

            string stDocumentInitiatorWarehouse = "";


            DataTable dtUserOrganisationPrevilage =
                getDataFromDb.getEM_AD_USER_ORGACCESSInfo(null, "",
                        stDocumentInitiatorOrganisation, generalResultInformation.userId,
                        triStateBool.No, true, false, "AND");

            if (dtUserOrganisationPrevilage.Rows.Count <= 0)
                dtUserOrganisationPrevilage =
                    getDataFromDb.getEM_AD_USER_ORGACCESSInfo(null, "",
                                generalResultInformation.allOrganisationRepresentativeKey,
                                generalResultInformation.userId,
                                triStateBool.No, true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtUserOrganisationPrevilage))
            {
                return false;              
            }
            
            DataTable dtcurrentUserCurrentRecordProcessAcess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                   "", stDocumentInitiatorWarehouse, 
                                   generalResultInformation.userId,
                                   generalResultInformation.Station,
                                   true, false, "AND");

            if (dtcurrentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                dtcurrentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                   "OR", stDocumentInitiatorWarehouse,
                                   generalResultInformation.userId,
                                   generalResultInformation.allStationRepresentativeKey,
                                   true, false, "AND");

            if (dtcurrentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                dtcurrentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                   "OR", 
                                   generalResultInformation.allWarehouseRepresentativeKey,
                                   generalResultInformation.userId,
                                   generalResultInformation.Station,
                                   true, false, "AND");

            if (dtcurrentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                dtcurrentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                   "OR", 
                                   generalResultInformation.allWarehouseRepresentativeKey,
                                   generalResultInformation.userId,
                                   generalResultInformation.allStationRepresentativeKey,
                                   true, false, "AND");


            if (!getDataFromDb.checkIfTableContainesData(dtcurrentUserCurrentRecordProcessAcess))
            {
                return false;
            }

            if (dtcurrentUserCurrentRecordProcessAcess.Rows[0]["CreateProductMakeUpChange"].ToString() == "Y")
            {
                return true;
            }
            else
                return false;

        }
                
        private void frmBOMChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }


        private void changeDocumentNumberAndDate()
        {
            generalResultInformation.codeR = codeRequested.ManualDoc;

            if (!dbSettingInformationHandler.documentNumberAutoGenerated ||
                 this.enmCurrentRecordType != recordType.New)
            {
                return;
            }


            new frmValidateSecurityKey().ShowDialog();

            if (generalResultInformation.securityKeyValidityPassed)
            {
                new frmManualDocInfo().ShowDialog();

                if (!generalResultInformation.documentInfoChanged)
                {
                    MessageBox.Show("Document Number and Date not Changed.",
                        "Materials Management",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                this.txtDocumentNumber.Text =
                    generalResultInformation.manualDocumentNumber;
                this.dtpMoveDate.Value =
                    generalResultInformation.manualDocumentDate;

                MessageBox.Show("Document Number and Date has Changed.",
                        "Materials Management",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void lblMovementDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.changeDocumentNumberAndDate();
        }

        private void lblDocumentNumber_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.changeDocumentNumberAndDate();
        }


        private void tmrCloseWindow_Tick(object sender, EventArgs e)
        {
            if (this.userIsActive)
            {
                this.userIsActive = false;
                return;
            }
            this.tscmdExit_Click(sender, e);
        }

        private void cmdShowBOM_Click(object sender, EventArgs e)
        {
            frmProdcutBOM bomPrd = new frmProdcutBOM();
            bomPrd.productID = this.ddgProduct.SelectedRowKey.ToString();
            bomPrd.ShowDialog();
        }


        private void ddgProduct_Enter(object sender, EventArgs e)
        {
            this.ddgProductBOM.SendToBack();
        }

        private void ddgProduct_Leave(object sender, EventArgs e)
        {
            this.ddgProductBOM.BringToFront();
            this.blddgProductControlerOutOfFocus = true;
        }
        
    }
}
