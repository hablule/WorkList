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
    public partial class frmInventoryTransferOrder : Form
    {
        public frmInventoryTransferOrder()
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


        bool userPrevilageIsReadOnlyForCurrentRecord = false;
        
        bool currentViewIsRecordView = true;
        bool userCanCreateNewOrder = false;
        bool usersCanEditRecordDetail = false;
        bool recordCanbeConfirmed = false;
        bool recordCanbeRejected = false;
        bool documentPreviewHidden = true;

        bool mainRecordControlEnableSatus = false;
        bool subRecordControlEanbleStatus = false;

        int intCurrentRecordNumber = -1;

        const int allowedLineCount = 15;
        const int numberOfRequestRecordToDisplayAtOnce = 15;

        string styleName = "";

        string stCurrentRecordId = "";

        string stCurrentDetailRecordLineNumber = "";
        string stCurrentDetailRecordId = "";
        string stQuantyColumnNameToAddOrModify = "";

        string stCurrentRecordCurrentStatus = "";
        string stCurrentRecordNewStatus = "";

        string stCurrentRecordOrganisationId = "";
        string stCurrentRecordMoveRequestId = "";
        string stCurrentDocumentId = "";
        string stCurrentRecordLocatorFromId = "";
        string stCurrentRecordLocatorToId = "";

        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();
              
        recordType enmCurrentRecordType = recordType.unkown;
        taskType enmCurrentTask = taskType.Unkown;
        recordStatus enmCurrentRecordStatus = recordStatus.Unknown;
        actionTake enmCurrentActionTaken = actionTake.unknown;

        // variables to hold informaion of exising record 
        //...(Request,Movement,Dispute) and their detail data
        //... from search result.
        DataTable dtExistingRecordData = new DataTable();
        DataTable dtExistingRecordDetailData = new DataTable();

        // variables to hold informaion of new record 
        //...(Request,Movement,Dispute) data to insert.
        DataTable dtRecordMainData = new DataTable();
        DataTable dtRecordDetailData = new DataTable();

        // variables to hold informaion of new record 
        //...(Request,Movement,Dispute) data to update.
        DataTable dtRecordDataToUpdate = new DataTable();
        DataTable dtRecordDetailDataToUpdate = new DataTable();


        DataTable dtAllOrganisation = new DataTable();
        DataTable dtActiveOrganisationsAccessableToUser = new DataTable();

        DataTable dtAllLocators = new DataTable();
        DataTable dtLocatorsAccessableToUser = new DataTable();
        DataTable dtLocatorsToWhichMoved = new DataTable();

        DataTable dtAllDocuments = new DataTable();
        DataTable dtDocumentsAccessableToUser = new DataTable();

        DataTable dtrequestResultList = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();
        
        //Variables Used to Print Crystal Document from Local Data Set
        dtsMovementInfo dsCurrentMovementInfo = new dtsMovementInfo();

        dtsMovementInfo.dtDocumentSummaryDataTable dtDocumentSummaryTable =
                new dtsMovementInfo.dtDocumentSummaryDataTable();
        dtsMovementInfo.dtDocumentDetailDataTable dtDocumentDetailTabe =
            new dtsMovementInfo.dtDocumentDetailDataTable();


        private string getNextInterfaceName()
        {
            if (this.styleName == "Aero (Black).vssf")
            {
                this.styleName = "Aero (Blue).vssf";
                return "Skins\\Aero (Blue).vssf";
            }
            else if (this.styleName == "Aero (Blue).vssf")
            {
                this.styleName = "Aero (Silver).vssf";
                return "Skins\\Aero (Silver).vssf";
            }
            else if (this.styleName == "Aero (Silver).vssf")
            {
                this.styleName = "Office2007 (Black).vssf";
                return "Skins\\Office2007 (Black).vssf";
            }
            else if (this.styleName == "Office2007 (Black).vssf")
            {
                this.styleName = "Office2007 (Blue).vssf";
                return "Skins\\Office2007 (Blue).vssf";
            }
            else if (this.styleName == "Office2007 (Blue).vssf")
            {
                this.styleName = "Office2007 (Silver).vssf";
                return "Skins\\Office2007 (Silver).vssf";
            }
            else if (this.styleName == "Office2007 (Silver).vssf")
            {
                this.styleName = "OSX (Aqua).vssf";
                return "Skins\\OSX (Aqua).vssf";
            }
            else if (this.styleName == "OSX (Aqua).vssf")
            {
                this.styleName = "OSX (Brushed).vssf";
                return "Skins\\OSX (Brushed).vssf";
            }
            else if (this.styleName == "OSX (Brushed).vssf")
            {
                this.styleName = "OSX (iTunes).vssf";
                return "Skins\\OSX (iTunes).vssf";
            }
            else if (this.styleName == "OSX (iTunes).vssf")
            {
                this.styleName = "OSX (Leopard).vssf";
                return "Skins\\OSX (Leopard).vssf";
            }
            else if (this.styleName == "OSX (Leopard).vssf")
            {
                this.styleName = "OSX (Panther).vssf";
                return "Skins\\OSX (Panther).vssf";
            }
            else if (this.styleName == "OSX (Panther).vssf")
            {
                this.styleName = "OSX (Tiger).vssf";
                return "Skins\\OSX (Tiger).vssf";
            }
            else if (this.styleName == "OSX (Tiger).vssf")
            {
                this.styleName = "Vista (Aero).vssf";
                return "Skins\\Vista (Aero).vssf";
            }
            else if (this.styleName == "Vista (Aero).vssf")
            {
                this.styleName = "Vista (Basic).vssf";
                return "Skins\\Vista (Basic).vssf";
            }
            else if (this.styleName == "Vista (Basic).vssf")
            {
                this.styleName = "Vista (Black).vssf";
                return "Skins\\Vista (Black).vssf";
            }
            else if (this.styleName == "Vista (Black).vssf")
            {
                this.styleName = "Vista (Blue).vssf";
                return "Skins\\Vista (Blue).vssf";
            }
            else if (this.styleName == "Vista (Blue).vssf")
            {
                this.styleName = "Vista (Green).vssf";
                return "Skins\\Vista (Green).vssf";
            }
            else if (this.styleName == "Vista (Green).vssf")
            {
                this.styleName = "Vista (Silver).vssf";
                return "Skins\\Vista (Silver).vssf";
            }
            else if (this.styleName == "Vista (Silver).vssf")
            {
                this.styleName = "Vista (Teal).vssf";
                return "Skins\\Vista (Teal).vssf";
            }
            else if (this.styleName == "Vista (Teal).vssf")
            {
                this.styleName = "XP (Blue).vssf";
                return "Skins\\XP (Blue).vssf";
            }
            else if (this.styleName == "XP (Blue).vssf")
            {
                this.styleName = "XP (Olive).vssf";
                return "Skins\\XP (Olive).vssf";
            }
            else if (this.styleName == "XP (Olive).vssf")
            {
                this.styleName = "XP (Royale).vssf";
                return "Skins\\XP (Royale).vssf";
            }
            else if (this.styleName == "XP (Royale).vssf")
            {
                this.styleName = "XP (Silver).vssf";
                return "Skins\\XP (Silver).vssf";
            }
            else
            {
                this.styleName = "Aero (Black).vssf";
                return "Skins\\Aero (Black).vssf";
            }
        }

        private void changeUserInterface()
        {
            this.visualStyler2.LoadVisualStyle(this.getNextInterfaceName());
            dbSettingInformationHandler.theme = this.styleName;
        }

        

        //enable disable toolbar task button (NEW,SAVE,DELETE,CONFIRM,REJECT)
            //... In accordance with user previlage to 
            //... (1)Current record Status and Operation
            //... and (2) Generating Organisation of Current Record

        private void enableToolBarTaskButtons()
        {
            this.enableDisableDeleteButton();
            this.enableDisableConfirmButton();
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

            if (this.userCanCreateNewOrder)
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

            if (this.userPrevilageIsReadOnlyForCurrentRecord 
                //|| this.enmCurrentRecordType == recordType.Existing
                )
            {
                this.tscmdConfirm.Enabled = false;
                return;
            }

            if (userAccessPrevilageInformation.canConfirmOrder)
                this.tscmdConfirm.Enabled = true;
            else
                this.tscmdConfirm.Enabled = false;
        }
        
        private void enableDisableRejectButton()
        {
            this.tscmdReject.Enabled = false;
            return;
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
            //if (this.userPrevilageIsReadOnlyForCurrentRecord)
            //{
            //    this.tscmdRelatedRecord.Enabled = false;
            //    return;
            //}

            //if (this.enmCurrentRecordType == recordType.New)
            //{
            //    this.tscmdRelatedRecord.Enabled = false;
            //    return;
            //}

            //if (this.enmCurrentTask == taskType.Request)
            //{
            //    if (this.enmCurrentRecordStatus == recordStatus.Drafted)
            //        this.tscmdRelatedRecord.Enabled = false;
            //    else
            //        this.tscmdRelatedRecord.Enabled = true;
            //}
            //else if (this.enmCurrentTask == taskType.Dispatch ||
            //            this.enmCurrentTask == taskType.Receive)
            //    this.tscmdRelatedRecord.Enabled = true;
            //else
            //    this.tscmdRelatedRecord.Enabled = false;
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

            this.stCurrentRecordCurrentStatus =
                this.dtgMoveSummary.SelectedRows[0].Cells["STATUS"].Value.ToString();

            this.stCurrentRecordLocatorFromId =
                    this.dtgMoveSummary.SelectedRows[0].Cells["M_LOCATOR_ID"].Value.ToString();

            this.stCurrentRecordLocatorToId =
                    this.dtgMoveSummary.SelectedRows[0].Cells["M_LOCATORTO_ID"].Value.ToString();

            this.stCurrentRecordMoveRequestId =
                    this.dtgMoveSummary.SelectedRows[0].Cells["M_MOVEREQUEST_ID"].Value.ToString();

            this.stCurrentRecordOrganisationId =
                    this.dtgMoveSummary.SelectedRows[0].Cells["AD_ORG_ID"].Value.ToString();


            //fill Controls.
            this.cmbOrganisation.Text = "";
            this.cmbOrganisation.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["ORGANISATION"].Value.ToString();

            
            this.cmbDocumentType.Text = "";
            this.cmbDocumentType.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["DOCUMENT"].Value.ToString();
                        
            this.lblMoveStatus.Text =
                this.dtgMoveSummary.SelectedRows[0].Cells["STATUS"].Value.ToString();

            this.dtpMoveDate.Value =
                Convert.ToDateTime(this.dtgMoveSummary.SelectedRows[0].Cells["DATE"].Value);
                        
            this.txtDocumentNumber.Text = "";
            this.txtDocumentNumber.Text =
                this.dtgMoveSummary.SelectedRows[0].Cells["DOCUMENTNO"].Value.ToString();
                        
            this.cmbMoveFrom.Text = "";
            this.cmbMoveFrom.Text =
                   this.dtgMoveSummary.SelectedRows[0].Cells["STORE FROM"].Value.ToString();

            this.cmbMoveTo.Text = "";
            this.cmbMoveTo.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["STORE TO"].Value.ToString();            

            this.txtDescriptionOrComment.Text =
                    this.dtgMoveSummary.SelectedRows[0].Cells["DESCRIPTION"].Value.ToString();

            this.ddgRequestNumber.SelectedItem =
                    this.dtgMoveSummary.SelectedRows[0].Cells["REQUEST NO"].Value.ToString();
            //if (this.ddgRequestNumber.SelectedItem != "" &&
            //    this.stCurrentRecordMoveRequestId != "")
            //    this.usersCanEditRecordDetail = false;
        }

        private void getAndfillCurrentRecordDetailTodtRecordDetail()
        { 
            if (this.stCurrentRecordId == "")
                return;
            //this.clearStructureAndDataOfDataTable(this.dtRecordDetailData);
            this.dtRecordDetailData.Clear();

            this.dtRecordDetailData =
                    this.getDataFromDb.getM_MOVEORDERLINEInfo(
                        null, "", "", this.stCurrentRecordId, "", "", false, false, "AND");                        

            this.changeRecordDetailTableStructure();

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

       
        //Changes the interface According to Task
        private void changeInterfaceToCurrentTaskAndRecordMode()
        {
            this.lblDocumentNumber.Text = "Order Number";
            this.lblMoveDate.Text = "Order Date";
            this.lblDocumentType.Text = "Order Doc.";
            this.lblMoveFrom.Text = "Order For";
            this.lblMoveTo.Text = "Order From";
            this.lblQuantity.Text = "Quantity";
            this.tmrRequestWrng.Enabled = true;
                        
            if (this.enmCurrentRecordType == recordType.New)
            {
                this.mainRecordControlEnableSatus = true;
                this.subRecordControlEanbleStatus = true;
            }            
            else
            {
                mainRecordControlEnableSatus = false;
                subRecordControlEanbleStatus = false;
            }

            this.cmbOrganisation.Enabled = mainRecordControlEnableSatus;
            this.ddgRequestNumber.Enabled = mainRecordControlEnableSatus;

            if (dbSettingInformationHandler.documentNumberAutoGenerated)
                this.txtDocumentNumber.Enabled = false;
            else
                this.txtDocumentNumber.Enabled = mainRecordControlEnableSatus;

            this.cmbDocumentType.Enabled = mainRecordControlEnableSatus;
            this.dtpMoveDate.Enabled = 
                this.txtDocumentNumber.Enabled;

            this.cmbMoveFrom.Enabled = mainRecordControlEnableSatus;
            this.cmbMoveTo.Enabled = mainRecordControlEnableSatus;


            this.ddgProduct.Enabled = subRecordControlEanbleStatus;
            this.ntbQuantity.Enabled = subRecordControlEanbleStatus;
            this.cmdAddOrModifyRecordDetail.Enabled = subRecordControlEanbleStatus;
            this.usersCanEditRecordDetail = subRecordControlEanbleStatus;

            if (this.ddgRequestNumber.SelectedItem != "" ||
                this.stCurrentRecordMoveRequestId != "")
                this.cmbMoveTo.Enabled = false;        
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

        //Gets record Record Status
        private recordStatus determineRecordStatus(string _status)
        {            
            if(_status == transactionStatusInformation.approvedOrder)
                return recordStatus.Approved;

            return recordStatus.Unknown;
            
        }
                        
        //Gets record transaction Status
        private string determineTransactionStatus(recordStatus _RecordStatus)
        {
            if (_RecordStatus == recordStatus.Approved)
                return transactionStatusInformation.approvedOrder;
            
            return "";            
        }

        private void determineUserCurrentRecordPrevilage()
        {
            userAccessPrevilageInformation.canConfirmOrder = false;
            userAccessPrevilageInformation.canCreateNewOrder = 
                this.canUserCreateNewOrder();

            if (userAccessPrevilageInformation.userStationprevilageIsReadOnly)
            {
                this.userPrevilageIsReadOnlyForCurrentRecord = true;
                return;
            }
            if (this.enmCurrentRecordType == recordType.Existing)
                return;

            DataTable currentUserWareHousePrevilage = new DataTable();            
            string stLocatorToWareHouse = "";
            string stCurrentTaskConcernedWareHouse = "";

            stLocatorToWareHouse =
                    this.getDataFromDb.getEM_M_LOCATORInfo(null, "",
                            this.stCurrentRecordLocatorToId, false, false, "AND")
                        .Rows[0]["M_WAREHOUSE_ID"].ToString();
                        

            stCurrentTaskConcernedWareHouse = stLocatorToWareHouse;
            

            DataTable currentUserCurrentRecordProcessAcess =
                getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                   "", stCurrentTaskConcernedWareHouse,
                                   generalResultInformation.userId,
                                   generalResultInformation.Station,
                                   true, false, "AND");

            if (currentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                currentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                    "", stCurrentTaskConcernedWareHouse,
                                    generalResultInformation.userId,
                                    generalResultInformation.allStationRepresentativeKey,
                                   true, false, "AND");

            if (currentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                currentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                    "", generalResultInformation.allWarehouseRepresentativeKey,
                                    generalResultInformation.userId,
                                    generalResultInformation.Station,
                                   true, false, "AND");

            if (currentUserCurrentRecordProcessAcess.Rows.Count <= 0)
                currentUserCurrentRecordProcessAcess =
                    getDataFromDb.getEM_PROCESS_ACCESSInfo(null,
                                    "", generalResultInformation.allWarehouseRepresentativeKey,
                                    generalResultInformation.userId,
                                    generalResultInformation.allStationRepresentativeKey,
                                   true, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(currentUserCurrentRecordProcessAcess))
            {
                if (currentUserCurrentRecordProcessAcess.Rows[0]["CREATEDISPATCHORDER"].ToString() == "N" &&
                    currentUserCurrentRecordProcessAcess.Rows[0]["CONFIRMDISPATCHORDER"].ToString() == "N")
                {
                    this.userPrevilageIsReadOnlyForCurrentRecord = true;
                    return;
                }
                else
                    this.userPrevilageIsReadOnlyForCurrentRecord = false;
            }
            else
            {
                this.userPrevilageIsReadOnlyForCurrentRecord = true;
                return;
            }   

            if (currentUserCurrentRecordProcessAcess.Rows[0]["CREATEDISPATCHORDER"].ToString() == "Y")
            {
                userAccessPrevilageInformation.canConfirmOrder = true;
            }
            else
                userAccessPrevilageInformation.canConfirmOrder = false;                        

        }

        private bool canUserCreateNewOrder()
        {
            return this.canUserCreateNewOrder(this.enmCurrentRecordType == recordType.Existing);
        }

        private bool canUserCreateNewOrder(bool checkWareHouse)
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
            drCriterionRow["Field"] = "CREATEDISPATCHORDER";
            drCriterionRow["Criterion"] = "=";
            drCriterionRow["Value"] = "Y";

            criterionTable.Rows.Add(drCriterionRow);

            string concernedWarehouseId = 
                checkWareHouse ? this.stCurrentRecordLocatorToId : "";
            
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
                this.lblOrganisation.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblOrganisation.ForeColor = this.normalFieldColor;

            if (this.ddgRequestNumber.SelectedItem != "" &&
                (this.ddgRequestNumber.SelectedRowKey == null ||
                 this.stCurrentRecordMoveRequestId == "")
                )
            {
                this.lblTransferRequest.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
            { this.lblTransferRequest.ForeColor = this.normalFieldColor; }

            if (this.txtDocumentNumber.Text == "")
            {
                this.lblDocumentNumber.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblDocumentNumber.ForeColor = this.normalFieldColor;

            if (this.cmbDocumentType.Text == "" ||
                this.stCurrentDocumentId == "")
            {
                this.lblDocumentType.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblDocumentType.ForeColor = this.normalFieldColor;

            if (this.dtpMoveDate.Value.ToString() == "")
            {
                this.lblMoveDate.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblMoveDate.ForeColor = this.normalFieldColor;

            if (this.cmbMoveFrom.Text == "" ||
                this.stCurrentRecordLocatorFromId == "")
            {
                this.lblMoveFrom.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblMoveFrom.ForeColor = this.normalFieldColor;

            if (this.cmbMoveTo.Text == "" ||
                this.stCurrentRecordLocatorToId == "")
            {
                this.lblMoveTo.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblMoveTo.ForeColor = this.normalFieldColor;

            if (!getDataFromDb.checkIfTableContainesData(this.dtRecordDetailData))
            {
                this.sbStatusLabel.Text = "No movement Line Found.";
                this.dtgMoveLine.BackgroundColor = Color.Red;
                missingFieldExist = true;
            }
            else if (this.dtRecordDetailData.Rows.Count > allowedLineCount)
            {
                this.sbStatusLabel.Text = "Document Line count Exceed Maximum Allowed number.";
                this.dtgMoveLine.BackgroundColor = Color.Yellow;
                missingFieldExist = true;
            }
            else
            {
                this.dtgMoveLine.BackgroundColor = 
                    System.Drawing.SystemColors.Control;
                this.sbStatusLabel.Text = "";
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
            if (this.enmCurrentRecordType != recordType.unkown)
            {
                DataTable movementOrderLineStructure =
                        getDataFromDb.getM_MOVEORDERLINEInfo(null, "", "",
                                "", "", "", true, true, "");

                for (int columnCounter = movementOrderLineStructure.Columns.Count - 1;
                    columnCounter >= 0; columnCounter--)
                {
                    if (!this.dtRecordDetailData.Columns.Contains
                            (movementOrderLineStructure.Columns[columnCounter].ColumnName))
                        this.dtRecordDetailData.Columns.Add
                                    (movementOrderLineStructure.Columns[columnCounter].ColumnName,
                                    movementOrderLineStructure.Columns[columnCounter].DataType);

                }

                for (int columnCounter = this.dtRecordDetailData.Columns.Count - 1;
                    columnCounter >= 0; columnCounter--)
                {
                    if (!movementOrderLineStructure.Columns.Contains
                            (this.dtRecordDetailData.Columns[columnCounter].ColumnName))
                        this.dtRecordDetailData.Columns.RemoveAt(columnCounter);

                }
                //}

                this.dtRecordDetailData.Columns["REQUESTQTY"].SetOrdinal(3);
                this.dtRecordDetailData.Columns["APPROVEDQTY"].SetOrdinal(4);
                this.dtRecordDetailData.Columns["CONFIRMEDQTY"].SetOrdinal(6);

                this.dtRecordDetailData.Columns.Add("remove");
                this.dtRecordDetailData.Columns.Add("PRODUCT");
                this.dtRecordDetailData.Columns.Add("UNIT");

                this.dtRecordDetailData.Columns["remove"].SetOrdinal(0);
                this.dtRecordDetailData.Columns["LINE"].SetOrdinal(1);
                this.dtRecordDetailData.Columns["PRODUCT"].SetOrdinal(2);
                this.dtRecordDetailData.Columns["UNIT"].SetOrdinal(7);
            }
        }

        private void changeMainRecordTableStructure()
        {
            if (this.enmCurrentRecordType == recordType.New ||
                this.enmCurrentRecordType == recordType.Existing)
            {
                //this.clearStructureAndDataOfDataTable(this.dtRecordMainData);
                this.dtRecordMainData.Clear();

                this.dtRecordMainData =
                    getDataFromDb.getM_MOVEORDERInfo(null, "", "", 
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
                                
                this.dtgMoveLine.Columns["EM_STATION_ID"].Visible = false;
                this.dtgMoveLine.Columns["AD_CLIENT_ID"].Visible = false;
                this.dtgMoveLine.Columns["AD_ORG_ID"].Visible = false;
                this.dtgMoveLine.Columns["ISACTIVE"].Visible = false;
                this.dtgMoveLine.Columns["CREATED"].Visible = false;
                this.dtgMoveLine.Columns["CREATEDBY"].Visible = false;
                this.dtgMoveLine.Columns["UPDATED"].Visible = false;
                this.dtgMoveLine.Columns["UPDATEDBY"].Visible = false;
                this.dtgMoveLine.Columns["M_MOVEREQUESTLINE_ID"].Visible = false;
                this.dtgMoveLine.Columns["M_LOCATOR_ID"].Visible = false;
                this.dtgMoveLine.Columns["M_LOCATORTO_ID"].Visible = false;
                this.dtgMoveLine.Columns["M_PRODUCT_ID"].Visible = false;
                this.dtgMoveLine.Columns["DESCRIPTION"].Visible = false;
                this.dtgMoveLine.Columns["C_UOM_ID"].Visible = false;
                this.dtgMoveLine.Columns["remove"].HeaderText = "";
                this.dtgMoveLine.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

                this.dtgMoveLine.Columns["M_MOVEORDERLINE_ID"].Visible = false;
                this.dtgMoveLine.Columns["M_MOVEORDER_ID"].Visible = false;

                if (this.enmCurrentRecordType == recordType.Existing)
                {
                    if (
                           (
                             this.enmCurrentRecordStatus == recordStatus.Drafted ||
                             (this.enmCurrentRecordStatus == recordStatus.Requested &&
                              userAccessPrevilageInformation.canApproveRequest)
                            )  &&
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
            this.dtgMoveSummary.Columns["M_MOVEREQUEST_ID"].Visible = false;
            this.dtgMoveSummary.Columns["M_LOCATOR_ID"].Visible = false;
            this.dtgMoveSummary.Columns["M_LOCATORTO_ID"].Visible = false;            
            this.dtgMoveSummary.Columns["DESCRIPTION"].Visible = false;
            this.dtgMoveSummary.Columns["C_DOCTYPE_ID"].Visible = false;

            this.dtgMoveSummary.Columns["M_MOVEORDER_ID"].Visible = false;

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
                    this.dtExistingRecordData.Columns.Add("REQUEST NO");
                    this.dtExistingRecordData.Columns.Add("STATUS");
                    this.dtExistingRecordData.Columns.Add("IS REQUEST", Type.GetType("System.Boolean"));
                    this.dtExistingRecordData.Columns.Add("STORE FROM");
                    this.dtExistingRecordData.Columns.Add("STORE TO");

                    this.dtExistingRecordData.Columns.Add("EM_STATION_ID");
                    this.dtExistingRecordData.Columns.Add("AD_ORG_ID");
                    this.dtExistingRecordData.Columns.Add("CREATEDBY");
                    this.dtExistingRecordData.Columns.Add("UPDATEDBY");
                    this.dtExistingRecordData.Columns.Add("M_MOVEREQUEST_ID");
                    this.dtExistingRecordData.Columns.Add("M_LOCATOR_ID");
                    this.dtExistingRecordData.Columns.Add("M_LOCATORTO_ID");
                    this.dtExistingRecordData.Columns.Add("M_MOVEORDER_ID");
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
            this.dtExistingRecordData.Columns["REQUEST NO"].SetOrdinal(5);
            this.dtExistingRecordData.Columns["STATUS"].SetOrdinal(6);
            this.dtExistingRecordData.Columns["IS REQUEST"].SetOrdinal(7);
            this.dtExistingRecordData.Columns["STORE FROM"].SetOrdinal(8);
            this.dtExistingRecordData.Columns["STORE TO"].SetOrdinal(9);
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

        private decimal getCurrentProductAvailableQty(string Product_ID, string locator_ID)
        {
            decimal prodcutAvailableQty = 0;
            decimal samePrdQtyInCurrentTrx = 0;
            decimal prdInStockQty =
                this.getDataAccordingToRule.getInStockQty(Product_ID,
                                         locator_ID);

            if(this.enmCurrentTask == taskType.Request)
                return prdInStockQty;

            int[] samePrdIndexs =
                this.searchTableRowIndex(this.dtRecordDetailData, "M_PRODUCT_ID",
                        this.ddgProduct.SelectedRowKey.ToString());

            foreach (int samePrdIndex in samePrdIndexs)
            {
                if (samePrdIndex > 0 && samePrdIndex < this.dtRecordDetailData.Rows.Count)
                {
                    samePrdQtyInCurrentTrx +=
                        decimal.Parse(this.dtRecordDetailData.Rows[samePrdIndex]["APPROVEDQTY"].ToString());
                }
            }

            prodcutAvailableQty = prdInStockQty - samePrdQtyInCurrentTrx;
            return prodcutAvailableQty;
        }


        private decimal getCurrentProductAvailableQty()
        {
            return this.getCurrentProductAvailableQty
                (this.ddgProduct.SelectedRowKey.ToString(), 
                this.stCurrentRecordLocatorFromId);
        }

        private bool isCurrentProductHasEnoughQty()
        {
            if (this.enmCurrentTask != taskType.Dispatch)
            {
                return true;
            }
            bool qtyIsAvailable = false;

            decimal samePrdQtyInCurrentTrx = 0;
            decimal prdRequiredStck = 0;

            int[] samePrdIndexs =
                this.searchTableRowIndex(this.dtRecordDetailData, "M_PRODUCT_ID",
                        this.ddgProduct.SelectedRowKey.ToString());

            foreach (int samePrdIndex in samePrdIndexs)
            {
                if (samePrdIndex > 0 && samePrdIndex < this.dtRecordDetailData.Rows.Count)
                {
                    samePrdQtyInCurrentTrx +=
                        decimal.Parse(this.dtRecordDetailData.Rows[samePrdIndex]["MOVEMENTQTY"].ToString());
                }
            }

            prdRequiredStck = samePrdQtyInCurrentTrx + decimal.Parse(this.ntbQuantity.Amount);

            qtyIsAvailable = 
                this.getDataAccordingToRule.
                        isStockAvailable(this.ddgProduct.SelectedRowKey.ToString(), 
                                         this.stCurrentRecordLocatorFromId, 
                                         prdRequiredStck);

            return qtyIsAvailable;
        }

        private bool isCurrentTransferExceedApprovedQty()
        {
            if (this.enmCurrentTask != taskType.Dispatch ||
                this.stCurrentRecordMoveRequestId == "")
            {
                return false;
            }

            int currentSelectedRowIndex = this.dtgMoveLine.SelectedRows[0].Index;

            return decimal.Parse(this.ntbQuantity.Amount) >
                        decimal.Parse(this.dtRecordDetailData.Rows[currentSelectedRowIndex]["TARGETQTY"].ToString());            
        }
            

        //When the addOrModify record detail button is clicked
        // this function picks the data and updates the recorddetail data table.

        private void addOrModifyRecordDetail(bool removeReocrd)
        {
            this.changeQuantityColumnNameToAddModify();

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
                    return;
                }

                this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["DESCRIPTION"] =
                    this.txtRecordDetailDescription.Text;

                this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["M_PRODUCT_ID"] =
                    this.ddgProduct.SelectedRowKey.ToString();

                this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["PRODUCT"] =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                        this.dtRecordDetailData.Rows[mathcingDetailRecord[0]]["M_PRODUCT_ID"].ToString(),
                        false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["NAME"];

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
                DataRow drNewDetailRecordRow = 
                    this.dtRecordDetailData.NewRow();

                drNewDetailRecordRow["DESCRIPTION"] = 
                    this.txtRecordDetailDescription.Text;

                drNewDetailRecordRow["M_PRODUCT_ID"] = 
                    this.ddgProduct.SelectedRowKey.ToString();

                drNewDetailRecordRow["LINE"] = 
                    this.dtRecordDetailData.Rows.Count + 1;

                drNewDetailRecordRow["PRODUCT"] =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                        drNewDetailRecordRow["M_PRODUCT_ID"].ToString(),
                        false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["NAME"];
                               
                drNewDetailRecordRow["REQUESTQTY"] = 0;

                drNewDetailRecordRow[this.stQuantyColumnNameToAddOrModify] =
                    Decimal.Parse(this.ntbQuantity.Amount);

                drNewDetailRecordRow["remove"] = "remove";

                drNewDetailRecordRow["C_UOM_ID"] =
                   this.ddgProduct.SelectedRow.Rows[0]["C_UOM_ID"].ToString();

                drNewDetailRecordRow["UNIT"] =
                    this.getDataFromDb.getEM_C_UOMInfo
                            (null, "",
                                this.ddgProduct.SelectedRow.Rows[0]["C_UOM_ID"].ToString(),
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

            if (this.dtgMoveLine.SelectedRows.Count > 0)
                this.dtgMoveLine.SelectedRows[0].Selected = false;
        }
                
        private void changeQuantityColumnNameToAddModify()
        {
            this.stQuantyColumnNameToAddOrModify = "APPROVEDQTY";
        }

        private void determineNewStatsuForRecord()
        {
            if (this.enmCurrentActionTaken == actionTake.saved)
                this.stCurrentRecordNewStatus =
                    transactionStatusInformation.newOrder;

            else if (this.enmCurrentActionTaken == actionTake.confirmed)
                this.stCurrentRecordNewStatus =
                    transactionStatusInformation.approvedOrder;
            else
                this.stCurrentRecordNewStatus = "";     
        }

        private void filldtRequsestList()
        {
            DataRow criteriaValue;

            DataTable approvedRequestCriterion = new DataTable();
            approvedRequestCriterion.Columns.Add("Field");
            approvedRequestCriterion.Columns.Add("Criterion");
            approvedRequestCriterion.Columns.Add("Value");                       

            approvedRequestCriterion.Clear();

            for (int locatorRowCounter = this.dtLocatorsAccessableToUser.Rows.Count - 1;
                locatorRowCounter >= 0; locatorRowCounter--)
            {
                criteriaValue = approvedRequestCriterion.NewRow();
                criteriaValue["Field"] = "M_LOCATOR_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = this.dtLocatorsAccessableToUser.
                                                Rows[locatorRowCounter]["M_LOCATOR_ID"].ToString();
                approvedRequestCriterion.Rows.Add(criteriaValue);
            }

            DataTable requestListForOrganisation =
                this.getDataFromDb.getV_REQUESTDETAILInfo(approvedRequestCriterion, "OR", "", "", "",
                    this.ddgRequestNumber.SelectedItem, transactionStatusInformation.approvedRequest,
                    true, false, "AND", "", "");

            if (requestListForOrganisation.Rows.Count < 1)
                return;

            for (int requestListRowCounter = requestListForOrganisation.Rows.Count - 1; 
                requestListRowCounter >= 0; requestListRowCounter--)
            {
                if ((requestListForOrganisation.Rows[requestListRowCounter]["M_LOCATORTO_ID"].ToString() != "") ||
                    decimal.Parse(requestListForOrganisation.Rows[requestListRowCounter]["REQUESTQTY"].ToString()) <=
                    decimal.Parse(requestListForOrganisation.Rows[requestListRowCounter]["APPROVEDQTY"].ToString())
                    )
                {
                    requestListForOrganisation.Rows.RemoveAt(requestListRowCounter);
                }
            }

            if (requestListForOrganisation.Rows.Count < 1)
                return;

            requestListForOrganisation = 
                this.getDataFromDb.clearRedundantRow(requestListForOrganisation, "M_MOVEREQUEST_ID");
                       
            this.dtrequestResultList = requestListForOrganisation.Copy();

            approvedRequestCriterion.Clear();
            

            for (int requestListRowCounter = this.dtrequestResultList.Rows.Count - 1;
                requestListRowCounter >= 0; requestListRowCounter--)
            {
                criteriaValue = approvedRequestCriterion.NewRow();

                criteriaValue["Field"] = "M_MOVEREQUEST_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] =
                    dtrequestResultList.Rows[requestListRowCounter]["M_MOVEREQUEST_ID"].ToString();
                approvedRequestCriterion.Rows.Add(criteriaValue);
            }

            this.dtrequestResultList.Clear();

            if (!this.getDataFromDb.checkIfTableContainesData(approvedRequestCriterion))
                return;

            this.dtrequestResultList = this.getDataAccordingToRule.
                    getMovementRequestListInAccordanceWithSearchCriteria(approvedRequestCriterion, "OR", "");

            for (int approvedRequestListRowCounter = this.dtrequestResultList.Rows.Count - 1;
                   approvedRequestListRowCounter >= numberOfRequestRecordToDisplayAtOnce;
                   approvedRequestListRowCounter--)
                this.dtrequestResultList.Rows.RemoveAt(approvedRequestListRowCounter);

            for (int requestListColumnCounter = dtrequestResultList.Columns.Count - 1;
                requestListColumnCounter >= 0; requestListColumnCounter--)
            {
                if (dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "M_MOVEREQUEST_ID" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "DOCUMENTNO" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "REQUESTDATE" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "M_LOCATOR_ID" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "M_LOCATORTO_ID" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "C_DOCTYPE_ID" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "DOCUMENT" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "DATE" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "STORE FROM" &&
                    dtrequestResultList.Columns[requestListColumnCounter].ColumnName != "STORE TO")

                    dtrequestResultList.Columns.RemoveAt(requestListColumnCounter);
            }

            if (dtrequestResultList.Columns.Contains("DOCUMENTNO"))
                dtrequestResultList.Columns["DOCUMENTNO"].ColumnName = "NUMBER";

            if (dtrequestResultList.Columns.Contains("REQUESTDATE"))
                dtrequestResultList.Columns["REQUESTDATE"].ColumnName = "Date";
        }

        private DataTable clearStructureAndDataOfDataTable(DataTable tableToClear)
        {
            if (tableToClear != null)
            {
                tableToClear.Clear();
                tableToClear.Columns.Clear();
            }
            return tableToClear;
        }

        private void clearFormContent()
        {
            //clear variable contents
            this.stCurrentDetailRecordId = "";
            this.stCurrentDetailRecordLineNumber = "";
            this.stCurrentRecordCurrentStatus = "";
            this.stCurrentRecordId = "";
            this.stCurrentRecordMoveRequestId = "";
            this.stCurrentRecordNewStatus = "";
            this.stQuantyColumnNameToAddOrModify = "";

            //Clear Form
            if (this.cmbOrganisation.Items.Count > 0)
            {
                this.cmbOrganisation.SelectedIndex = 0;
                this.cmbOrganisation_DropDownClosed(new object(), new EventArgs());
            }
            this.ddgRequestNumber.SelectedItem = "";
            if (this.ddgRequestNumber.SelectedRowKey != null)
            {
                this.ddgRequestNumber.SelectedRowKey = null;
                this.ddgRequestNumber_selectedItemChanged(new object(), new EventArgs());
            }

            this.txtDocumentNumber.Text = "";
            if (this.cmbDocumentType.Items.Count > 0)
            {
                this.cmbOrganisation.SelectedIndex = 0;
                this.cmbDocumentType_DropDownClosed(new object(), new EventArgs());
            }
            this.dtpMoveDate.Value = DateTime.Today;
            
            this.txtDescriptionOrComment.Text = "";
            this.lblMoveStatus.Text = "";

            
        }

        private void loadDocForCurrentTask()
        {
            this.loadDocForCurrentTask(true);   
        }

        private void loadDocForCurrentTask( bool onlyActiveRecords)
        {
            this.cmbDocumentType.Items.Clear();
            this.dtDocumentsAccessableToUser =
                getDataAccordingToRule.getDocuments(true, onlyActiveRecords, "", true, taskType.Order);
            this.insetDataIntoComboBox(this.cmbDocumentType, dtDocumentsAccessableToUser,
                dtDocumentsAccessableToUser.Columns.IndexOf("NAME"), -1);

            if (this.cmbDocumentType.Items.Count > 0)
                this.cmbDocumentType.SelectedIndex = 0;
        }

        private void prepareForNewTask()
        {
            this.userPrevilageIsReadOnlyForCurrentRecord = false;
            
            this.clearFormContent();
            this.dtRecordDetailData.Clear();
            this.dtRecordMainData.Clear();
            this.changeRecordDetailTableStructure();
            this.changeMainRecordTableStructure();
            this.changeInterfaceToCurrentTaskAndRecordMode();
            this.fillDataToRecordDetailGidView();
            this.loadDocForCurrentTask();
            
            this.enableToolBarTaskButtons();            

        }

        private void hidePrintPreview()
        {
            this.documentPreviewHidden = true;
            if(this.currentViewIsRecordView)
                this.ddgProduct.BringToFront();
            this.tscmdShowPrintPreview.Checked = false;
            this.crvPrintPreview.Hide();
        }

        
        private void getOpenMoveOrderRecord()
        {
            DataRow criteriaValue;

            DataTable openMoveOrderCriterion = new DataTable();

            openMoveOrderCriterion.Columns.Add("Field");
            openMoveOrderCriterion.Columns.Add("Criterion");
            openMoveOrderCriterion.Columns.Add("Value");
            
            criteriaValue = openMoveOrderCriterion.NewRow();
            criteriaValue["Field"] = "ORDERSTATUS";
            criteriaValue["Criterion"] = "=";
            criteriaValue["Value"] = transactionStatusInformation.approvedOrder;
            openMoveOrderCriterion.Rows.Add(criteriaValue);

            string query = 
                this.getDataFromDb.createTheCriteriaClause(openMoveOrderCriterion,
                        "AND" , "");

            openMoveOrderCriterion.Rows.Clear();

            for (int locatorRowCounter = this.dtLocatorsAccessableToUser.Rows.Count - 1;
                locatorRowCounter >= 0; locatorRowCounter--)
            {
                criteriaValue = openMoveOrderCriterion.NewRow();
                criteriaValue["Field"] = "M_LOCATORTO_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = this.dtLocatorsAccessableToUser.
                                                Rows[locatorRowCounter]["M_LOCATOR_ID"].ToString();
                openMoveOrderCriterion.Rows.Add(criteriaValue);

                criteriaValue = openMoveOrderCriterion.NewRow();
                criteriaValue["Field"] = "M_LOCATOR_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = this.dtLocatorsAccessableToUser.
                                                Rows[locatorRowCounter]["M_LOCATOR_ID"].ToString();
                openMoveOrderCriterion.Rows.Add(criteriaValue);
            }

            query = query + this.getDataFromDb.createTheCriteriaClause(openMoveOrderCriterion, "OR", "AND");

            DataTable openMoveOrder =
                this.getDataFromDb.getV_MOVEORDERDETAILInfo(null, "", "", "", "", "", "", "", "", 
                        true, false, "AND", query, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(openMoveOrder))
                return;

            for (int rowCounter = openMoveOrder.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (openMoveOrder.Rows[rowCounter]["CONFIRMEDQTY"].ToString() == "")
                { 
                    continue; 
                }

                if (decimal.Parse(openMoveOrder.Rows[rowCounter]["APPROVEDQTY"].ToString()) <=
                    decimal.Parse(openMoveOrder.Rows[rowCounter]["CONFIRMEDQTY"].ToString()))
                {
                    openMoveOrder.Rows.RemoveAt(rowCounter);
                }
            }

            openMoveOrder =
                this.getDataFromDb.clearRedundantRow(openMoveOrder, "M_MOVEORDER_ID");

            if (!this.getDataFromDb.checkIfTableContainesData(openMoveOrder))
                return;

            openMoveOrderCriterion.Rows.Clear();

            for (int openMovementRowCounter = openMoveOrder.Rows.Count - 1;
                openMovementRowCounter >= 0; openMovementRowCounter--)
            {
                criteriaValue = openMoveOrderCriterion.NewRow();
                criteriaValue["Field"] = "M_MOVEORDER_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = openMoveOrder.
                                                Rows[openMovementRowCounter]["M_MOVEORDER_ID"].ToString();
                openMoveOrderCriterion.Rows.Add(criteriaValue);
            }

            openMoveOrder =
                this.getDataFromDb.getM_MOVEORDERInfo(openMoveOrderCriterion, 
                    "OR", "", "", "", false, false, "AND");
            
            openMoveOrder = 
                this.getDataAccordingToRule.compileResult(openMoveOrder, taskType.Order);
            
            DataView dv = openMoveOrder.DefaultView;
            dv.Sort = "DATE ASC, DOCUMENTNO ASC";
            openMoveOrder = dv.ToTable();
            
            generalResultInformation.searchResult = openMoveOrder.Copy();

            openMoveOrder.Dispose();            
        }



        private bool createBomTransferOrder(string ProductId, decimal quantity)
        {
            if (!this.canUserCreateNewOrder())
            {
                MessageBox.Show("You Don't Have Suffiecent Previlage To Create this Record." +
                        "\n Please Consult Your Admin", "Save record", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return false;
            }

            if (this.checkRequiredInformationForAutoTrx())
            {
                MessageBox.Show("Please Correct the error before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return false;
            }

            if (ProductId == "")
            {
                MessageBox.Show("No BOM product info found",
                        "Easy Move", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return false;
            }

            DataTable productInfo =
                this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                                    ProductId, true, triStateBool.ignor,
                                    triStateBool.yes, triStateBool.yes,
                                    false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(productInfo))
            {
                MessageBox.Show("No BOM product info found",
                        "Easy Move", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return false;
            }
            
            DataTable dtProductBOM =
                this.getDataFromDb.getM_PRODUCT_BOMInfo(null, "", "",
                            ProductId, "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtProductBOM))
            {
                MessageBox.Show("No BOM Found", "EasyMove",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            frmProdcutBOM prdBOM = new frmProdcutBOM();
            prdBOM.productID = ProductId;
            prdBOM.qtyProduced = quantity;

            prdBOM.ShowDialog();

            if (MessageBox.Show("Are you sure to create request for the items showed",
                "Easy Move", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == DialogResult.No)
            {
                prdBOM.Close();
                prdBOM.Dispose();
                return false;
            }

            dtProductBOM.Columns.Remove("M_PRODUCT_BOM_ID");
            dtProductBOM.Columns.Remove("AD_CLIENT_ID");
            dtProductBOM.Columns.Remove("AD_ORG_ID");
            dtProductBOM.Columns.Remove("ISACTIVE");
            dtProductBOM.Columns.Remove("CREATED");
            dtProductBOM.Columns.Remove("CREATEDBY");
            dtProductBOM.Columns.Remove("UPDATED");
            dtProductBOM.Columns.Remove("UPDATEDBY");
            dtProductBOM.Columns.Remove("LINE");
            dtProductBOM.Columns.Remove("M_PRODUCT_ID");
            dtProductBOM.Columns.Remove("DESCRIPTION");
            dtProductBOM.Columns.Remove("BOMTYPE");

            dtProductBOM.Columns["M_PRODUCTBOM_ID"].ColumnName = "M_PRODUCT_ID";
            dtProductBOM.Columns["BOMQTY"].ColumnName = "QUANTITY";

            DataTable dtTrxDtl = new DataTable();
            dtTrxDtl = dtProductBOM.Clone();
            DataRow drTrxDtl;

            List<String> newTrxId = new List<string>();

            bool trxRecordingFailed = false;

            for (int rowCounter = 0; rowCounter <= dtProductBOM.Rows.Count - 1; rowCounter++)
            {
                drTrxDtl = dtTrxDtl.NewRow();
                drTrxDtl["M_PRODUCT_ID"] =
                    dtProductBOM.Rows[rowCounter]["M_PRODUCT_ID"];
                drTrxDtl["QUANTITY"] =
                    decimal.Parse(dtProductBOM.Rows[rowCounter]["QUANTITY"].ToString()) *
                                quantity;

                dtTrxDtl.Rows.Add(drTrxDtl);

                if (((rowCounter + 1) % allowedLineCount == 0) ||
                    (rowCounter + 1) > dtProductBOM.Rows.Count - 1)
                {
                    string newTrx_ID = this.createNewTransferOrder();
                    if (newTrx_ID != "")
                    {
                        bool lineInserted =
                            this.createTransferOrderLine(newTrx_ID, dtTrxDtl);
                        if (lineInserted)
                        {
                            newTrxId.Add(newTrx_ID);
                            dtTrxDtl.Rows.Clear();
                        }
                        else
                        {
                            trxRecordingFailed = true;
                            break;
                        }
                    }
                    else
                    {
                        trxRecordingFailed = true;
                        break;
                    }
                }
            }

            if (trxRecordingFailed)
            {
                this.deleteTransferOrder(newTrxId);
                return false;
            }
            else
            {
                this.insertNewTransferOrderToExisitingRecord(newTrxId);
                this.displayDocumentNo(newTrxId);
                return true;
            }
        }

        private bool checkRequiredInformationForAutoTrx()
        {
            bool missingFieldExist = false;
            if (this.cmbOrganisation.Text == "" ||
                this.stCurrentRecordOrganisationId == "")
            {
                this.lblOrganisation.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblOrganisation.ForeColor = this.normalFieldColor;

            if (this.cmbDocumentType.Text == "" ||
                this.stCurrentDocumentId == "")
            {
                this.lblDocumentType.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblDocumentType.ForeColor = this.normalFieldColor;

            if (this.cmbMoveFrom.Text == "" ||
                this.stCurrentRecordLocatorFromId == "")
            {
                this.lblMoveFrom.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblMoveFrom.ForeColor = this.normalFieldColor;

            if (this.cmbMoveTo.Text == "" ||
                    this.stCurrentRecordLocatorToId == "")
            {
                this.lblMoveTo.ForeColor = this.missingFieldColor;
                missingFieldExist = true;
            }
            else
                this.lblMoveTo.ForeColor = this.normalFieldColor;

            if (getDataFromDb.checkIfTableContainesData(this.dtRecordDetailData))
            {
                if (MessageBox.Show("There are Other Items in the list. " +
                    "\nIf you proceed you will loose current records. " +
                    "\nWould you like to continue", "Easy Move",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    this.dtgMoveLine.BackgroundColor = Color.Red;
                    missingFieldExist = true;
                }
            }
            else
            {
                this.dtgMoveLine.BackgroundColor =
                    System.Drawing.SystemColors.Control;
            }

            return missingFieldExist;
        }

        private string createNewTransferOrder()
        {
            string mainTableNameToChange = "M_MOVEORDER";
            string changeType = "INSERT";

            DataRow newRecordDatarow;

            this.changeMainRecordTableStructure();


            newRecordDatarow = this.dtRecordMainData.NewRow();

            newRecordDatarow["EM_STATION_ID"] = generalResultInformation.Station;
            newRecordDatarow["ORDERSTATUS"] = transactionStatusInformation.approvedOrder;
            newRecordDatarow["AD_CLIENT_ID"] = generalResultInformation.clientId;
            newRecordDatarow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
            newRecordDatarow["DOCUMENTNO"] =
                    getDataFromDb.getNextSequenceId("",
                           getDataFromDb.getEM_C_DOCTYPEInfo
                               (null, "", this.stCurrentDocumentId, false, false, "AND")
                            .Rows[0]["DOCNOSEQUENCE_ID"].ToString(),
                            generalResultInformation.Station, "", true);

            newRecordDatarow["DESCRIPTION"] = this.txtDescriptionOrComment.Text;
            newRecordDatarow["C_DOCTYPE_ID"] = this.stCurrentDocumentId;
            newRecordDatarow["ISAPPROVED"] = "Y";
            newRecordDatarow["CREATEDBY"] = generalResultInformation.userId;
            newRecordDatarow["UPDATEDBY"] = generalResultInformation.userId;
            newRecordDatarow["ORDERDATE"] = DateTime.Now.ToString("yyyy-MM-dd");

            this.dtRecordMainData.Rows.Add(newRecordDatarow);

            //Insert Reuest. and Get Id.

            string[] recordId =
                getDataFromDb.changeDataBaseTableData(this.dtRecordMainData,
                        mainTableNameToChange, changeType);
            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                return "";
            }

            string[] mainRecordPrimaryKeyColumnName =
                        getDataFromDb.getEasyMoveDBTablePrimaryKey(mainTableNameToChange);

            string[] newRecordId = new string[(recordId.Length * 2)];

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
                return "";
            }

            foreach (string RecordKey in mainRecordPrimaryKeyColumnName)
            {
                if (!newRecordId.Contains(RecordKey))
                {
                    return "";
                }
            }

            return newRecordId[1];
        }

        private bool createTransferOrderLine(string TransferOrderID, DataTable TransferOrderDtl)
        {
            if (TransferOrderID == "")
            {
                return false;
            }

            DataTable transferOrderInfo =
                this.getDataFromDb.getM_MOVEORDERInfo(null, "",
                        TransferOrderID, "", "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(transferOrderInfo))
            {
                return false;
            }

            string detailTableNameToChange = "M_MOVEORDERLINE";
            string changeType = "INSERT";

            DataTable newTransferOrderLine =
                this.getDataFromDb.getM_MOVEORDERLINEInfo(null, "",
                        "", "", "", "", false, true, "");

            DataRow drMoveOrd;

            DataTable productInfo = new DataTable();

            for (int rowCounter = 0; rowCounter <= TransferOrderDtl.Rows.Count - 1; rowCounter++)
            {
                drMoveOrd = newTransferOrderLine.NewRow();


                drMoveOrd["EM_STATION_ID"] = generalResultInformation.Station;
                drMoveOrd["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drMoveOrd["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
                drMoveOrd["ISACTIVE"] = "Y";
                drMoveOrd["CREATEDBY"] = generalResultInformation.userId;
                drMoveOrd["UPDATEDBY"] = generalResultInformation.userId;

                drMoveOrd["M_MOVEORDER_ID"] = TransferOrderID;
                drMoveOrd["M_LOCATOR_ID"] = this.stCurrentRecordLocatorFromId;
                drMoveOrd["M_LOCATORTO_ID"] = this.stCurrentRecordLocatorToId;
                drMoveOrd["M_PRODUCT_ID"] = TransferOrderDtl.Rows[rowCounter]["M_PRODUCT_ID"];
                drMoveOrd["LINE"] = rowCounter + 1;
                drMoveOrd["REQUESTQTY"] = TransferOrderDtl.Rows[rowCounter]["QUANTITY"];
                drMoveOrd["APPROVEDQTY"] = "0";
                drMoveOrd["CONFIRMEDQTY"] = "0";
                productInfo =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                        TransferOrderDtl.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                        false, triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(productInfo))
                {
                    drMoveOrd["C_UOM_ID"] = productInfo.Rows[0]["C_UOM_ID"].ToString();
                }
                else
                {
                    return false;
                }

                newTransferOrderLine.Rows.Add(drMoveOrd);
            }

            if (this.getDataFromDb.checkIfTableContainesData(newTransferOrderLine))
            {
                string[] recordId =
                        this.getDataFromDb.changeDataBaseTableData(newTransferOrderLine,
                                        detailTableNameToChange, changeType);

                if (recordId.Length <= 0)
                {
                    this.sbStatusLabel.Text = "Record Has been Saved";
                    return false;
                }
            }

            return true;
        }

        private void deleteTransferOrder(List<String> TransferOrderID)
        {
            DataTable moveOrderInfo = new DataTable();
            DataTable moveOrderLineInfo = new DataTable();

            foreach (string trxID in TransferOrderID)
            {
                moveOrderInfo = this.getDataFromDb.getM_MOVEORDERInfo(null, "",
                        trxID, "", "", false, false, "AND");
                moveOrderLineInfo = this.getDataFromDb.getM_MOVEORDERLINEInfo(null, "",
                        "", trxID, "", "", false, false, "AND");

                this.getDataFromDb.changeDataBaseTableData(moveOrderLineInfo, "M_MOVEORDERLINE", "DELETE");
                this.getDataFromDb.changeDataBaseTableData(moveOrderInfo, "M_MOVEORDER", "DELETE");
            }
        }

        private void displayDocumentNo(List<String> TransferOrderID)
        {
            DataTable moveOrderInfo = new DataTable();
            string newDocList = "";


            foreach (string trxID in TransferOrderID)
            {
                moveOrderInfo = this.getDataFromDb.getM_MOVEORDERInfo(null, "",
                        trxID, "", "", false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(moveOrderInfo))
                {
                    newDocList = newDocList + moveOrderInfo.Rows[0]["DOCUMENTNO"].ToString() + "\n";
                }
            }

            if (newDocList != "")
            {
                MessageBox.Show("Operation Compeleted Successfully.\n" +
                    "The Documents List Below has been generated Automatically.\n" +
                    newDocList, "Easy Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertNewTransferOrderToExisitingRecord(List<String> TransferOrderID)
        {

            string recordTableIdName = "M_MOVEORDER_ID";

            DataTable moveOrderInfo = new DataTable();
            DataRow existingReocrdDatarow;


            foreach (string trxID in TransferOrderID)
            {
                moveOrderInfo = this.getDataFromDb.getM_MOVEORDERInfo(null, "",
                        trxID, "", "", false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(moveOrderInfo))
                {
                    existingReocrdDatarow = this.dtExistingRecordData.NewRow();
                    existingReocrdDatarow["EM_STATION_ID"] = generalResultInformation.Station;
                    existingReocrdDatarow["ORGANISATION"] = this.cmbOrganisation.Text;
                    existingReocrdDatarow["DOCUMENTNO"] = moveOrderInfo.Rows[0]["DOCUMENTNO"].ToString();
                    existingReocrdDatarow["DATE"] = DateTime.Parse(moveOrderInfo.Rows[0]["ORDERDATE"].ToString());
                    existingReocrdDatarow["DOCUMENT"] = this.cmbDocumentType.Text;
                    existingReocrdDatarow["STATUS"] = transactionStatusInformation.approvedOrder;
                    existingReocrdDatarow["STORE FROM"] = this.cmbMoveFrom.Text;
                    existingReocrdDatarow["STORE TO"] = this.cmbMoveTo.Text;
                    existingReocrdDatarow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
                    existingReocrdDatarow["M_LOCATOR_ID"] = this.stCurrentRecordLocatorFromId;
                    existingReocrdDatarow["M_LOCATORTO_ID"] = this.stCurrentRecordLocatorToId;
                    existingReocrdDatarow["DESCRIPTION"] = this.txtDescriptionOrComment.Text;
                    existingReocrdDatarow["C_DOCTYPE_ID"] = this.stCurrentDocumentId;
                    existingReocrdDatarow["CREATEDBY"] = generalResultInformation.userId;
                    existingReocrdDatarow["UPDATEDBY"] = generalResultInformation.userId;
                    this.stCurrentRecordId = trxID;
                    existingReocrdDatarow[recordTableIdName] = this.stCurrentRecordId;

                    this.dtExistingRecordData.Rows.Add(existingReocrdDatarow);
                }
            }
            this.tscmdLastRecord_Click(new object(), new EventArgs());
        }


        //Below are Form event procedures.
        //funtions of the form and its control
        
        private void frmInventoryTransferOrder_Load(object sender, EventArgs e)
        {            
            //this.visualStyler2.LoadVisualStyle(dbSettingInformationHandler.theme);
            
            this.crvPrintPreview.Parent = this;
            this.crvPrintPreview.Dock = DockStyle.Fill;
            this.crvPrintPreview.BringToFront();

            this.ddgProduct.Parent = this;
            this.ddgProduct.BringToFront();
            this.ddgProduct.Location = new Point(160, 322);

            this.dtgMoveSummary.Visible = false;            
            
            this.dtAllOrganisation = getDataAccordingToRule.getOrganisations(false, false);
            this.dtAllLocators = getDataAccordingToRule.getLocators(false, true, "", true);
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

            this.enmCurrentTask = taskType.Order;
           
            this.userCanCreateNewOrder = 
                this.canUserCreateNewOrder(false);
            
            this.prepareForNewTask();

            this.getOpenMoveOrderRecord();
            
            this.loadSearchResultDataToExistingMainRecord();
            this.fillSearchResultToMainRecordGridView();

            this.initControlsRecursive(this.Controls);            

            if (this.getDataFromDb.checkIfTableContainesData(this.dtExistingRecordData))
            {
                this.tscmdFirstRecord_Click(sender, e);
                return;
            }
            
            this.enableDisableNewButton();

            if (this.dtExistingRecordData.Rows.Count < 1 &&
                this.tscmdNew.Enabled)
            {                
                this.tscmdNew_Click(sender, e);
            }
            
            this.changeRecordDetailTableStructure();
            this.changeInterfaceToCurrentTaskAndRecordMode();
            
            this.fillDataToRecordDetailGidView();

            this.determineUserCurrentRecordPrevilage();
            this.enableDisableNavigationButtons();
            this.enableToolBarTaskButtons();
            
        }
        

        private void tscmdNew_Click(object sender, EventArgs e)
        {

            this.cmbDocumentType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMoveFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMoveTo.DropDownStyle = ComboBoxStyle.DropDownList;

            this.hidePrintPreview();
            this.clearFormContent();
                        
            this.enmCurrentRecordType = recordType.New;

            this.prepareForNewTask();
        }
        
        private void tscmdSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.hidePrintPreview();
            DataRow newRecordDatarow;
            DataRow existingReocrdDatarow;
            this.enmCurrentActionTaken = actionTake.saved;

            string mainTableNameToChange = "M_MOVEORDER";
            string detailTableNameToChange = "M_MOVEORDERLINE";

            string changeType = "";
            this.changeMainRecordTableStructure();

            this.recordCanbeConfirmed = false;
            this.recordCanbeRejected = false;
            
            //check all fields for new record.
            if (this.checkExistanceOfAllRequiredInformation())
            {
                this.Enabled = true;
                MessageBox.Show("Please Insert the missing fields before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                this.Enabled = true;
                return;
            }
            

            if (this.enmCurrentRecordType == recordType.Existing)
                changeType = "UPDATE";
            else if (this.enmCurrentRecordType == recordType.New)
            {
                if (!this.canUserCreateNewOrder(true))
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
                newRecordDatarow["EM_STATION_ID"] = generalResultInformation.Station;

                determineNewStatsuForRecord();

                newRecordDatarow["ORDERSTATUS"] =
                        this.stCurrentRecordNewStatus;
            }
            else
            {
                this.stCurrentRecordNewStatus = "";
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
            if(this.enmCurrentRecordType == recordType.New)
                newRecordDatarow["ISAPPROVED"] = "N";

            if (this.stCurrentRecordMoveRequestId != "")
                newRecordDatarow["M_MOVEREQUEST_ID"] =
                    Convert.ToInt32(this.stCurrentRecordMoveRequestId);

            newRecordDatarow["ORDERDATE"] =
                this.dtpMoveDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

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

            string recordTableIdName = "M_MOVEORDER_ID";
            string recordDetailTableIdName = "M_MOVEORDERLINE_ID";
                        

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
                    dtRecordDetailData.Rows[currentDetailRecord]["M_LOCATOR_ID"] =
                        this.stCurrentRecordLocatorFromId;
                    dtRecordDetailData.Rows[currentDetailRecord]["M_LOCATORTO_ID"] =
                        this.stCurrentRecordLocatorToId;

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

            else if(this.stCurrentRecordId != "" &&
                this.enmCurrentRecordType == recordType.Existing)
            {
                DataTable dtExistingRecordDetailDataForCurrentRecord = new DataTable();
                dtExistingRecordDetailDataForCurrentRecord =
                        this.getDataFromDb.getM_MOVEORDERLINEInfo(null, "", "",
                        this.stCurrentRecordId, "", "", false, false, "AND");
                                   
                     
                for (int currentDetailRecord = 0; 
                        currentDetailRecord <= dtRecordDetailData.Rows.Count - 1;
                        currentDetailRecord++)
                {                    
                    dtRecordDetailData.Rows[currentDetailRecord]["AD_CLIENT_ID"] =
                        generalResultInformation.clientId;
                    dtRecordDetailData.Rows[currentDetailRecord]["AD_ORG_ID"] =
                        this.stCurrentRecordOrganisationId;                    

                    dtRecordDetailData.Rows[currentDetailRecord]["M_LOCATOR_ID"] =
                        this.stCurrentRecordLocatorFromId;
                    dtRecordDetailData.Rows[currentDetailRecord]["M_LOCATORTO_ID"] =
                        this.stCurrentRecordLocatorToId;

                    if (this.dtRecordDetailData.Rows[currentDetailRecord][recordTableIdName].ToString() == "" ||
                        this.dtRecordDetailData.Rows[currentDetailRecord][recordTableIdName].ToString() == "0")
                        this.dtRecordDetailData.Rows[currentDetailRecord][recordTableIdName] =
                                    this.stCurrentRecordId;

                    if (this.dtRecordDetailData.Rows[currentDetailRecord]["EM_STATION_ID"].ToString() == "" ||
                        this.dtRecordDetailData.Rows[currentDetailRecord]["EM_STATION_ID"].ToString() == "0")
                        this.dtRecordDetailData.Rows[currentDetailRecord]["EM_STATION_ID"] =
                            generalResultInformation.Station;

                    if (this.dtRecordDetailData.Rows[currentDetailRecord]
                            [recordDetailTableIdName].ToString() != "" &&
                        dtExistingRecordDetailDataForCurrentRecord.Rows.Count > 0)
                    {
                        int[] resultingRow =
                            this.searchTableRowIndex(dtExistingRecordDetailDataForCurrentRecord, 
                                                        recordDetailTableIdName,
                            this.dtRecordDetailData.Rows[currentDetailRecord]
                                [recordDetailTableIdName].ToString());
                        if (resultingRow.Length > 0)
                            if (resultingRow[0] != -1)
                            {
                                dtExistingRecordDetailDataForCurrentRecord.Rows.RemoveAt(resultingRow[0]);
                            }
                    }
                }
                if (dtExistingRecordDetailDataForCurrentRecord.Rows.Count > 0)
                {
                    getDataFromDb.changeDataBaseTableData(dtExistingRecordDetailDataForCurrentRecord,
                        detailTableNameToChange,
                        "DELETE");
                }
            }

            this.dtRecordDetailData.Columns.RemoveAt
                (this.dtRecordDetailData.Columns.IndexOf("remove"));
            this.dtRecordDetailData.Columns.RemoveAt
                (this.dtRecordDetailData.Columns.IndexOf("PRODUCT"));
            this.dtRecordDetailData.Columns.RemoveAt
                (this.dtRecordDetailData.Columns.IndexOf("UNIT"));

            recordId =
                getDataFromDb.changeDataBaseTableData(dtRecordDetailData,
                detailTableNameToChange, changeType);
            if (recordId.Length > 0)
                this.sbStatusLabel.Text = "Record Has been Saved";

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
                existingReocrdDatarow["REQUEST NO"] =
                    this.ddgRequestNumber.SelectedItem;
                existingReocrdDatarow["STATUS"] =
                    this.stCurrentRecordNewStatus;
                existingReocrdDatarow["STORE FROM"] =
                    this.cmbMoveFrom.Text;
                existingReocrdDatarow["STORE TO"] =
                    this.cmbMoveTo.Text;
                existingReocrdDatarow["AD_ORG_ID"] =
                    this.stCurrentRecordOrganisationId;
                if(this.stCurrentRecordMoveRequestId != "")
                    existingReocrdDatarow["M_MOVEREQUEST_ID"] =
                        Convert.ToInt32(this.stCurrentRecordMoveRequestId);
                existingReocrdDatarow["M_LOCATOR_ID"] =
                    this.stCurrentRecordLocatorFromId;
                existingReocrdDatarow["M_LOCATORTO_ID"] =
                    this.stCurrentRecordLocatorToId;
                existingReocrdDatarow["DESCRIPTION"] =
                    this.txtDescriptionOrComment.Text;
                existingReocrdDatarow["C_DOCTYPE_ID"] =
                    this.stCurrentDocumentId;

                existingReocrdDatarow["CREATEDBY"] = generalResultInformation.userId;
                existingReocrdDatarow["UPDATEDBY"] = generalResultInformation.userId;


                this.stCurrentRecordId = newRecordId[Array.IndexOf(newRecordId, recordTableIdName) + 1];
                existingReocrdDatarow[recordTableIdName] =
                        this.stCurrentRecordId;
                
                existingReocrdDatarow["IS REQUEST"] = true;

                this.dtExistingRecordData.Rows.Add(existingReocrdDatarow);                
            }
            else if (this.enmCurrentRecordType == recordType.Existing &&
                this.stCurrentRecordNewStatus != "")
            { 
                int [] rowIndex = 
                    this.searchTableRowIndex(this.dtExistingRecordData,
                    recordTableIdName, this.stCurrentRecordId);
                if (rowIndex.Length > 0)
                    if (rowIndex[0] != -1)
                        this.dtExistingRecordData.Rows[rowIndex[0]]["STATUS"] =
                            this.stCurrentRecordNewStatus;
                this.dtgMoveSummary.SelectedRows[0].Cells["STATUS"].Value =
                    this.stCurrentRecordNewStatus;                
            }
            
            if(this.enmCurrentRecordType == recordType.Existing)
            { 
                int [] rowIndex = 
                    this.searchTableRowIndex(this.dtExistingRecordData,
                    recordTableIdName, this.stCurrentRecordId);
                if (rowIndex.Length > 0)
                    if (rowIndex[0] != -1)
                    {
                        this.dtExistingRecordData.Rows[rowIndex[0]]["ORGANISATION"] =
                            this.cmbOrganisation.Text;
                        this.dtExistingRecordData.Rows[rowIndex[0]]["DOCUMENTNO"] =
                         this.txtDocumentNumber.Text;
                        this.dtExistingRecordData.Rows[rowIndex[0]]["DATE"] =
                         this.dtpMoveDate.Value;
                        this.dtExistingRecordData.Rows[rowIndex[0]]["DOCUMENT"] =
                         this.cmbDocumentType.Text;
                        this.dtExistingRecordData.Rows[rowIndex[0]]["REQUEST NO"] =
                         this.ddgRequestNumber.SelectedItem;
                        this.dtExistingRecordData.Rows[rowIndex[0]]["STORE FROM"] =
                         this.cmbMoveFrom.Text;
                        this.dtExistingRecordData.Rows[rowIndex[0]]["STORE TO"] =
                         this.cmbMoveTo.Text;                        
                        this.dtExistingRecordData.Rows[rowIndex[0]]["DESCRIPTION"] =
                            this.txtDescriptionOrComment.Text;
                    }
            }

            if (this.enmCurrentRecordType == recordType.New)
                this.dtgMoveSummary.Rows[this.dtgMoveSummary.Rows.Count - 1].Selected = true;

            this.dtgMoveSummary_UserClickeCell
                (sender, new DataGridViewCellEventArgs(0, 
                    this.dtgMoveLine.SelectedRows[this.dtgMoveLine.Rows.Count-1].Index));

            this.enableToolBarTaskButtons();
            this.recordCanbeConfirmed = true;
            this.recordCanbeRejected = true;
            this.Enabled = true;
        }

        private void tscmdDelete_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            if (this.dtgMoveSummary.SelectedRows.Count != 1)
                return;
            DialogResult deleteRecord = 
                MessageBox.Show("Are You Sure You want to delete current Record?",
                "Inventory Move", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteRecord == DialogResult.No)
                return;

            
            this.Enabled = false;
            //Delete All Detail For Current Record Id According To Record Type
            string mainTableName = "M_MOVEORDER";
            string mainRecordTableId = "M_MOVEORDERLINE";
            
            DataTable recordDetailTable =
                this.getDataFromDb.getM_MOVEORDERLINEInfo(null, "", "",
                                this.stCurrentRecordId, "",
                                generalResultInformation.Station,
                                false, false, "AND");

            this.getDataFromDb.changeDataBaseTableData
                (recordDetailTable, "M_MOVEORDERLINE", "DELETE");
           
            //Delete Record According To Record Type
            this.changeMainRecordTableStructure();

            DataRow drMainRecord = this.dtRecordMainData.NewRow();
            drMainRecord[mainRecordTableId] = this.stCurrentRecordId;
            this.dtRecordMainData.Rows.Add(drMainRecord);

            this.getDataFromDb.changeDataBaseTableData
                    (this.dtRecordMainData, mainTableName, "DELETE");

            int[] rowIndex = 
                this.searchTableRowIndex(this.dtExistingRecordData, 
                mainRecordTableId, this.stCurrentRecordId);
            if(rowIndex.Length > 0)
                if(rowIndex[0] != -1)
                    this.dtExistingRecordData.Rows.RemoveAt(rowIndex[0]);
            if (((this.intCurrentRecordNumber-1) < this.dtgMoveSummary.Rows.Count) &&
                ((this.intCurrentRecordNumber - 1) > -1))
            {
                this.dtgMoveSummary.Rows[this.intCurrentRecordNumber-1].Selected = true;
                this.dtgMoveSummary_UserClickeCell(sender,
                    new DataGridViewCellEventArgs(0, this.intCurrentRecordNumber));
            }
            else if (this.dtgMoveSummary.Rows.Count > 0)
            {
                this.dtgMoveSummary.Rows[0].Selected = true;
                this.dtgMoveSummary_UserClickeCell(sender,
                    new DataGridViewCellEventArgs(0, this.intCurrentRecordNumber));

            }
            else
            {
                if (this.tscmdNew.Enabled)
                    this.tscmdNew_Click(sender, e);
                else
                {
                    this.cmbOrganisation.Text = "";
                    this.ddgRequestNumber.SelectedItem = "";
                    this.txtDocumentNumber.Text = "";
                    this.cmbDocumentType.Text = "";
                    this.dtpMoveDate.Value = DateTime.Today;
                    this.cmbMoveFrom.Text = "";
                    this.cmbMoveTo.Text = "";
                    this.txtDescriptionOrComment.Text = "";
                    this.lblMoveStatus.Text = "";

                    this.ddgProduct.SelectedItem = "";
                    this.ddgProduct.SelectedRow.Clear();
                    this.ddgProduct.SelectedRowKey = null;
                    this.ddgProduct_selectedItemChanged(sender, e);

                    this.dtRecordDetailData.Clear();
                    this.changeRecordDetailTableStructure();
                    this.fillDataToRecordDetailGidView();
                    this.enmCurrentRecordType = recordType.unkown;
                    this.changeInterfaceToCurrentTaskAndRecordMode();
                    this.determineUserCurrentRecordPrevilage();
                }

            }  
            this.determineUserCurrentRecordPrevilage();
            this.enableToolBarTaskButtons();
            this.Enabled = true;
        }


        private void tscmdConfirm_Click(object sender, EventArgs e)
        {
            this.determineUserCurrentRecordPrevilage();
            if (!userAccessPrevilageInformation.canConfirmOrder)
            {
                MessageBox.Show("You Don't Have Suffiecent Previlage To Create this Record." +
                            "\n Please Consult Your Admin", "Confirm record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                this.Enabled = true;
                return;
            }

            this.hidePrintPreview();
            this.Enabled = false;
            this.tscmdSave_Click(sender, e);
            this.Enabled = false;

            if (!this.recordCanbeConfirmed)
            {
                this.Enabled = true;
                return;
            }

            this.enmCurrentActionTaken = actionTake.confirmed;
            this.determineNewStatsuForRecord();
            this.changeMainRecordTableStructure();

            string recordStatusName = "ORDERSTATUS";
            string recordTableName = "M_MOVEORDER";
            string recordDetailTableName = "M_MOVEORDERLINE";
            string recordTableIdName = "M_MOVEORDER_ID";

            DataRow drMainRecordRow = this.dtRecordMainData.NewRow();

            drMainRecordRow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
            if (this.stCurrentRecordMoveRequestId != "")
                drMainRecordRow["M_MOVEREQUEST_ID"] = this.stCurrentRecordMoveRequestId;
            else
                drMainRecordRow["M_MOVEREQUEST_ID"] = DBNull.Value;

            drMainRecordRow[recordTableIdName] = this.stCurrentRecordId;
            drMainRecordRow[recordStatusName] = this.stCurrentRecordNewStatus;                  
            
            this.dtRecordMainData.Rows.Add(drMainRecordRow);

            this.getDataFromDb.changeDataBaseTableData(this.dtRecordMainData, 
                recordTableName, "UPDATE");
            this.getDataFromDb.changeDataBaseTableData(this.dtRecordDetailData, 
                recordDetailTableName, "UPDATE");

            int [] recordResult =
                this.searchTableRowIndex(this.dtExistingRecordData, 
                                        recordTableIdName, this.stCurrentRecordId);
            if (recordResult.Length > 0)
                if (recordResult[0] > -1)
                    this.dtExistingRecordData.Rows[recordResult[0]]["STATUS"] =
                        this.stCurrentRecordNewStatus;

            this.dtgMoveSummary_UserClickeCell
                (sender, new DataGridViewCellEventArgs(0,
                    this.dtgMoveLine.SelectedRows[0].Index));            
            
            this.Enabled = true;
        }

        private void tscmdReject_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            this.Enabled = false;
            this.tscmdSave_Click(sender, e);
            if (!this.recordCanbeRejected)
                return;
            this.enmCurrentActionTaken = actionTake.rejected;
            this.determineNewStatsuForRecord();
            this.changeMainRecordTableStructure();
            

            string recordStatusName = "ORDERSTATUS";
            string recordTableName = "M_MOVEORDER";
            string recordDetailTableName = "M_MOVEORDERLINE";
            string recordTableIdName = "M_MOVEORDER_ID";

            DataRow drMainRecordRow = this.dtRecordMainData.NewRow();
            if(this.stCurrentRecordMoveRequestId != "")
                drMainRecordRow["M_MOVEREQUEST_ID"] = this.stCurrentRecordMoveRequestId;
            drMainRecordRow["AD_ORG_ID"] = this.stCurrentRecordOrganisationId;
            drMainRecordRow[recordTableIdName] = this.stCurrentRecordId;
            drMainRecordRow[recordStatusName] = this.stCurrentRecordNewStatus;
            
            this.dtRecordMainData.Rows.Add(drMainRecordRow);

            this.getDataFromDb.changeDataBaseTableData(this.dtRecordMainData,
                recordTableName, "UPDATE");
            this.getDataFromDb.changeDataBaseTableData(this.dtRecordDetailData,
                recordDetailTableName, "UPDATE");

            int[] recordResult =
                this.searchTableRowIndex(this.dtExistingRecordData, recordTableIdName, this.stCurrentRecordId);
            if (recordResult.Length > 0)
                if (recordResult[0] > -1)
                    this.dtExistingRecordData.Rows[recordResult[0]]["STATUS"] =
                        this.stCurrentRecordNewStatus;

            this.dtgMoveSummary_UserClickeCell
               (sender, new DataGridViewCellEventArgs(0,
                   this.dtgMoveLine.SelectedRows[0].Index));            
            
            this.Enabled = true;
        }


        private void tscmdSearch_Click(object sender, EventArgs e)
        {
            this.hidePrintPreview();
            frmSearchInventoryMove newSearch = new frmSearchInventoryMove();
            newSearch.enmTaskType = taskType.Order;
            newSearch.ShowDialog(this);

            this.loadSearchResultDataToExistingMainRecord();
            this.fillSearchResultToMainRecordGridView();

            if (this.dtgMoveSummary.Rows.Count > 0)
            {
                this.dtgMoveSummary.Rows[0].Selected = true;
                this.dtgMoveSummary_UserClickeCell(sender, new DataGridViewCellEventArgs(0, 0));
            }


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
                this.ddgProduct.SendToBack();
                this.dtgMoveSummary.Visible = true;
                
            }
            else
            {
                this.dtgMoveLine.Dock = DockStyle.None;
                this.dtgMoveSummary.Visible = false;
                this.dtgMoveSummary.SendToBack();
                this.ddgProduct.BringToFront();
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

            //this.crptMaterialMovement.PrintOptions.PaperSize = 
        //    CrystalDecisions.Shared.PaperSize.PaperA4;
        //this.crptMaterialMovement.PrintOptions.PaperOrientation = 
        //    CrystalDecisions.Shared.PaperOrientation.Landscape;
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
                string stTableName = "";
                if (this.enmCurrentTask == taskType.Dispatch ||
                    this.enmCurrentTask == taskType.Receive)
                    stTableName = "EM_M_MOVEMENT";
                else if (this.enmCurrentTask == taskType.Request)
                    stTableName = "EM_M_MOVEREQUEST";

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
            if (!System.IO.File.Exists("crptMaterialTransferOrder.rpt"))
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
                this.ddgProduct.BringToFront();
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

            this.ddgProduct.SendToBack();

            string stTableName = "M_MOVEORDER";

            if (stTableName == "")
            {
                this.documentPreviewHidden = true;
                this.crvPrintPreview.Hide();
                this.Enabled = true;
                return;
            }

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

            if (this.enmCurrentTask == taskType.Receive ||
                this.enmCurrentTask == taskType.Order ||
                this.enmCurrentTask == taskType.Request)
            {
                drDocumentSummary["MovementId"] = this.stCurrentRecordId;
                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows.Add(drDocumentSummary);

                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentNumber"] =
                    this.txtDocumentNumber.Text;
                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentDate"] =
                    this.dtpMoveDate.Value;
                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["DocumentName"] =
                    this.cmbDocumentType.Text;

                if (this.enmCurrentTask == taskType.Order || this.enmCurrentTask == taskType.Receive)
                {
                    this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["RequestNumber"] =
                        this.ddgRequestNumber.SelectedItem;
                }

                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["StoreFrom"] =
                    this.cmbMoveFrom.Text;
                this.dsCurrentMovementInfo.Tables["dtDocumentSummary"].Rows[0]["StoreTo"] =
                    this.cmbMoveTo.Text;
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
                dtMovementDetailInfo.Columns["APPROVEDQTY"].ColumnName = "Quantity";

                dtMovementDetailInfo.Columns["DESCRIPTION"].ColumnName = "comment";
                dtMovementDetailInfo.Columns.Add("Remark");

                for (int rowCounter = dtMovementDetailInfo.Columns.Count - 1;
                    rowCounter >= 0; rowCounter--)
                    if (!dtDocumentDetailTabe.Columns.Contains
                            (dtMovementDetailInfo.Columns[rowCounter].ColumnName))
                        dtMovementDetailInfo.Columns.RemoveAt(rowCounter);
            }

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
            if (this.enmCurrentTask == taskType.Receive)
            {
                this.crptMaterialMovement.FileName = "crptMaterialMovement.rpt";
            }

            if (this.enmCurrentTask == taskType.Request)
            {
                this.crptMaterialMovement.FileName = "crptMaterialRequest.rpt";
            }

            if (this.enmCurrentTask == taskType.Order)
            {
                this.crptMaterialMovement.FileName = "crptMaterialTransferOrder.rpt";
            }
            
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
            if (this.dtRecordDetailData.Rows.Count >= allowedLineCount &&
                !(this.txtDocumentNumber.Text.StartsWith("<<") || this.txtDocumentNumber.Text.EndsWith(">>")) &&
                this.cmdAddOrModifyRecordDetail.Text == "ADD")
            {
                this.sbStatusLabel.Text = "Document Line count Exceed Maximum Allowed number.";
                goto exitAdd;
            }

            if ((this.ntbQuantity.Amount == "0" ||
                this.ntbQuantity.Amount == "" ) && 
                (this.enmCurrentRecordStatus != recordStatus.Requested))
            {
                MessageBox.Show("Please Input Quantity.", "Easy Move", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.ddgProduct.SelectedRowKey == null)
            {
                MessageBox.Show("Please Select Product.", "Easy Move",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.cmdAddOrModifyRecordDetail.Text == "ADD" &&
                this.ddgProduct.SelectedRow.Rows[0]["ISBOM"].ToString() == "Y" &&
                generalResultInformation.automateComponentDispatch)
            {
                if (MessageBox.Show("The item you selected has componenets." +
                        "\nWould you like to created order for its componenets.",
                        "Easy Move", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.createBomTransferOrder(this.ddgProduct.SelectedRowKey.ToString(), Decimal.Parse(this.ntbQuantity.Amount));
                }
                else
                {
                    this.addOrModifyRecordDetail(false);
                }
            }
            else
            {
                this.addOrModifyRecordDetail(false);
            }
         

         exitAdd:

            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.SelectedItem = "";            
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct_selectedItemChanged(sender, e);
            this.ddgProduct.Enabled = this.subRecordControlEanbleStatus;

            this.txtRecordDetailDescription.Text = "";
            this.cmdAddOrModifyRecordDetail.Text = "ADD";
            this.stCurrentDetailRecordId = "";
            this.stCurrentDetailRecordLineNumber = "";
        }
        

        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation = 
                getDataAccordingToRule.getProducts(true, true,triStateBool.ignor, triStateBool.ignor, triStateBool.yes, triStateBool.No, true,
                                    this.ddgProduct.SelectedItem, "", true);
            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey = 
                Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex = 
                productInformation.Columns.IndexOf("NAME");            
            this.ddgProduct.HiddenColoumns = new int[]{ productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID")};
        }
       
        private void ddgProduct_selectedItemChanged(object sender, EventArgs e)
        {
            this.ntbQuantity.Amount = "0";
            this.lblInStockQty.Text = "0";
            if (ddgProduct.SelectedRowKey == null)
            {
                this.ntbQuantity.Enabled = false;
                this.txtRecordDetailDescription.Enabled = false;
                this.lblUOM.Text = "";
                this.cmdAddOrModifyRecordDetail.Enabled = false;             
            }
            else
            {
                if (this.ddgProduct.SelectedRow.Rows.Count > 0)
                {
                    this.lblUOM.Text =
                        this.getDataFromDb.getEM_C_UOMInfo(null, "",
                        ddgProduct.SelectedRow.Rows[0]["C_UOM_ID"].ToString(), false, false, "AND")
                        .Rows[0]["UOMSYMBOL"].ToString();
                    this.ntbQuantity.StandardPrecision =
                        int.Parse(this.getDataFromDb.getEM_C_UOMInfo(null, "",
                        ddgProduct.SelectedRow.Rows[0]["C_UOM_ID"].ToString(), false, false, "AND")
                        .Rows[0]["STDPRECISION"].ToString());

                    this.lblInStockQty.Text =
                        this.getCurrentProductAvailableQty(ddgProduct.SelectedRow.Rows[0]["M_PRODUCT_ID"].ToString(),
                                        this.stCurrentRecordLocatorFromId).ToString();
                }
                else if(this.ddgProduct.SelectedRowKey.ToString() != "")
                { 
                    string currentProductUOMId = 
                        this.getDataFromDb.getEM_M_PRODUCTInfo(
                                            null,"",
                                            this.ddgProduct.SelectedRowKey.ToString(),false, triStateBool.ignor, triStateBool.ignor, false, "AND")
                                    .Rows[0]["C_UOM_ID"].ToString();

                    this.lblUOM.Text =
                        this.getDataFromDb.getEM_C_UOMInfo(null, "", currentProductUOMId,
                                    false, false, "AND")
                                 .Rows[0]["UOMSYMBOL"].ToString();

                    this.ntbQuantity.StandardPrecision =
                        int.Parse(this.getDataFromDb.getEM_C_UOMInfo(null, "", currentProductUOMId,
                                false, false, "AND")
                              .Rows[0]["STDPRECISION"].ToString());

                    this.lblInStockQty.Text =
                        this.getCurrentProductAvailableQty().ToString();
                }

                this.ntbQuantity.Enabled = true;
                this.txtRecordDetailDescription.Enabled = true;
                this.cmdAddOrModifyRecordDetail.Enabled = true;
            }
        }


        private void ddgRequestNumber_SelectedItemClicked(object sender, EventArgs e)
        {
            if (!this.userCanCreateNewOrder)
                return;

            if (this.stCurrentRecordOrganisationId != "")
            {
                this.dtLocatorsAccessableToUser =
                        getDataAccordingToRule.getUserAccessableLocators("", triStateBool.No, taskType.Order);

                this.filldtRequsestList();
                if (this.dtrequestResultList.Rows.Count > 0)
                {
                    this.ddgRequestNumber.DataSource = this.dtrequestResultList;
                    this.ddgRequestNumber.DataTablePrimaryKey =
                        Convert.ToUInt16(this.dtrequestResultList.Columns.IndexOf("M_MOVEREQUEST_ID"));
                    this.ddgRequestNumber.SelectedColomnIdex =
                        this.dtrequestResultList.Columns.IndexOf("Number");

                    this.ddgRequestNumber.HiddenColoumns = new int[] {this.dtrequestResultList.Columns.IndexOf("M_LOCATOR_ID"),
                                            this.dtrequestResultList.Columns.IndexOf("M_LOCATORTO_ID"),
                                            this.dtrequestResultList.Columns.IndexOf("C_DOCTYPE_ID")};
                }
            }
        }

        private void ddgRequestNumber_selectedItemChanged(object sender, EventArgs e)
        {
            if (!this.userCanCreateNewOrder || 
                this.ddgRequestNumber.Enabled == false)
                return;

            if (this.ddgRequestNumber.SelectedRowKey != null &&
                     this.ddgRequestNumber.SelectedRow.Rows.Count > 0 &&
                     this.ddgRequestNumber.SelectedItem != "")
            {
                this.stCurrentRecordMoveRequestId = 
                    this.ddgRequestNumber.SelectedRowKey.ToString();
                
                this.stCurrentRecordLocatorFromId =
                    this.ddgRequestNumber.SelectedRow.Rows[0]["M_LOCATOR_ID"].ToString();

                this.cmbMoveFrom.Text =
                    this.ddgRequestNumber.SelectedRow.Rows[0]["STORE FROM"].ToString();

                this.cmbMoveTo.Text = "";
                
                this.cmbMoveFrom.Enabled = false;
                
                this.dtRecordDetailData.Clear();

                this.dtRecordDetailData = this.getDataFromDb.
                    getEM_M_MOVEREQUESTLINEInfo(null, "", "",
                        this.ddgRequestNumber.SelectedRowKey.ToString(), 
                        "", true, false, "AND");                

                this.dtRecordDetailData.Columns.RemoveAt(
                    this.dtRecordDetailData.Columns.IndexOf("M_MOVEREQUEST_ID"));

                //this.dtRecordDetailData.Columns.RemoveAt(
                //    this.dtRecordDetailData.Columns.IndexOf("CONFIRMEDQTY"));

                //this.dtRecordDetailData.Columns.RemoveAt(
                //    this.dtRecordDetailData.Columns.IndexOf("REQUESTQTY"));

                //this.dtRecordDetailData.Columns["APPROVEDQTY"].ColumnName = "TARGETQTY";
                
                this.changeRecordDetailTableStructure();
                                
                DataTable dtOrderLineInfo;                

                for (int rowCounter = this.dtRecordDetailData.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {                    
                    //Adjust Approved Qty to exclude Qty which already have Movement Or Order

                    if (decimal.Parse(this.dtRecordDetailData.Rows[rowCounter]["REQUESTQTY"].ToString()) <=
                        decimal.Parse(this.dtRecordDetailData.Rows[rowCounter]["APPROVEDQTY"].ToString()))
                    {
                        this.dtRecordDetailData.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                    
                    dtOrderLineInfo =
                        this.getDataFromDb.getV_MOVEORDERDETAILInfo(null, "", "", "", "", "",
                            this.dtRecordDetailData.Rows[rowCounter]["M_MOVEREQUESTLINE_ID"].ToString(),
                            "", "", false, false, "AND", "", "AND");

                    this.dtRecordDetailData.Rows[rowCounter]["APPROVEDQTY"] =
                        decimal.Parse(this.dtRecordDetailData.Rows[rowCounter]["REQUESTQTY"].ToString());

                    if (this.getDataFromDb.checkIfTableContainesData(dtOrderLineInfo))
                    {
                        for (int rowCounter2 = 0; rowCounter2 <= dtOrderLineInfo.Rows.Count - 1; rowCounter2++)
                        {
                            this.dtRecordDetailData.Rows[rowCounter]["APPROVEDQTY"] =
                                decimal.Parse(this.dtRecordDetailData.Rows[rowCounter]["APPROVEDQTY"].ToString()) -
                                decimal.Parse(dtOrderLineInfo.Rows[rowCounter2]["APPROVEDQTY"].ToString());
                        }                        
                    }

                    if (decimal.Parse(this.dtRecordDetailData.Rows[rowCounter]["APPROVEDQTY"].ToString()) <= 0)
                    {
                        this.dtRecordDetailData.Rows.RemoveAt(rowCounter);
                        continue;
                    }

                    this.dtRecordDetailData.Rows[rowCounter]["LINE"] = rowCounter + 1;
                    this.dtRecordDetailData.Rows[rowCounter]["remove"] = "remove";// "remove";

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

                //this.usersCanEditRecordDetail = false;
                this.fillDataToRecordDetailGidView();
                //this.ddgProduct.Enabled = false;
            }
            else
            {
                if (this.stCurrentRecordMoveRequestId != "")
                {
                    this.dtRecordDetailData.Clear();
                    this.changeRecordDetailTableStructure();
                    this.stCurrentRecordLocatorFromId = "";
                    this.stCurrentRecordLocatorToId = "";
                    this.cmbOrganisation_SelectedIndexChanged(sender, e);
                    this.fillDataToRecordDetailGidView();
                }

                this.stCurrentRecordMoveRequestId = "";                
                this.cmbMoveFrom.Enabled = true;                                
                //this.usersCanEditRecordDetail = true;                
                this.ddgProduct.Enabled = true;
            }
        }
               

        private void cmbOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dtrequestResultList.Clear();
            this.ddgRequestNumber.SelectedItem = "";
            this.ddgRequestNumber.SelectedRowKey = null;
            this.ddgRequestNumber.SelectedRow.Clear();
            this.cmbMoveTo.Enabled = true;

            if (this.cmbOrganisation.SelectedIndex >= 0 &&
                this.cmbOrganisation.SelectedIndex <=
                this.dtActiveOrganisationsAccessableToUser.Rows.Count - 1)
            {
                this.stCurrentRecordOrganisationId =
                    this.dtActiveOrganisationsAccessableToUser.
                                    Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
                this.dtLocatorsAccessableToUser =
                    getDataAccordingToRule.getUserAccessableLocators("", triStateBool.No, taskType.Order);
                this.cmbMoveFrom.Items.Clear();
                if (this.stCurrentRecordLocatorToId != "" &&
                    !this.cmbMoveTo.Enabled)
                {
                    for(int rowIndex= this.dtLocatorsAccessableToUser.Rows.Count -1;
                        rowIndex >= 0; rowIndex--)
                    {
                        if (this.dtLocatorsAccessableToUser.Rows[rowIndex]["M_LOCATOR_ID"].ToString() ==
                            this.stCurrentRecordLocatorToId)
                        {
                            this.dtLocatorsAccessableToUser.Rows.RemoveAt(rowIndex);
                            break;
                        }
                    }
                }
                this.insetDataIntoComboBox(this.cmbMoveFrom, dtLocatorsAccessableToUser,
                    this.dtLocatorsAccessableToUser.Columns.IndexOf("VALUE"), 0);
                if (this.cmbDocumentType.Items.Count > 0)
                    this.cmbDocumentType.SelectedIndex = 0;
                
            }
            else
            {
                this.stCurrentRecordOrganisationId = "";
                this.dtLocatorsAccessableToUser.Clear();
                this.cmbMoveFrom.Items.Clear();
                this.cmbMoveFrom.SelectedIndex = -1;
                this.cmbMoveFrom.Text = "";
                this.cmbMoveFrom_SelectedIndexChanged(sender, e);
            }
        }

        private void cmbOrganisation_KeyUp(object sender, KeyEventArgs e)
        {   
            dtActiveOrganisationsAccessableToUser.Clear();
            dtActiveOrganisationsAccessableToUser =
                    getDataAccordingToRule.getOrganisations(true, true);
            //this.comboItemFilter(this.cmbOrganisation, dtActiveOrganisationsAccessableToUser, e,"NAME");
        }

        private void cmbOrganisation_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cmbOrganisation.SelectedItem != null)
                this.cmbOrganisation.Text = this.cmbOrganisation.SelectedItem.ToString();
                        
            this.cmbOrganisation_KeyUp(sender, new KeyEventArgs(Keys.Enter));
            
            this.comboBoxDropDownClosed(this.cmbOrganisation, dtActiveOrganisationsAccessableToUser,
                this.cmbOrganisation_SelectedIndexChanged, sender);            
        }


        private void cmbMoveFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbMoveFrom.SelectedIndex >= 0 &&
                this.cmbMoveFrom.SelectedIndex <= this.dtLocatorsAccessableToUser.Rows.Count - 1)
            {
                this.stCurrentRecordLocatorFromId =
                    this.dtLocatorsAccessableToUser.Rows[this.cmbMoveFrom.SelectedIndex]["M_LOCATOR_ID"].ToString();
                dtLocatorsToWhichMoved = dtAllLocators.Copy();
                for (int rowCounter = dtLocatorsToWhichMoved.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    if (dtLocatorsToWhichMoved.Rows[rowCounter]["M_LOCATOR_ID"].ToString() ==
                        this.stCurrentRecordLocatorFromId)
                    {
                        dtLocatorsToWhichMoved.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
                if (this.cmbMoveTo.Enabled == true)
                {
                    this.cmbMoveTo.Items.Clear();
                    this.insetDataIntoComboBox(this.cmbMoveTo, dtLocatorsToWhichMoved,
                        dtLocatorsToWhichMoved.Columns.IndexOf("VALUE"), 0);
                }
            }
            else
            {
                this.stCurrentRecordLocatorFromId = "";
                dtLocatorsToWhichMoved.Clear();
                this.cmbMoveTo.Items.Clear();
                this.cmbMoveTo.SelectedIndex = -1;
                this.cmbMoveTo.Text = "";
                this.cmbMoveTo_SelectedIndexChanged(sender, e);
            }
        }
                        
        private void cmbMoveFrom_KeyUp(object sender, KeyEventArgs e)
        {
            dtLocatorsAccessableToUser.Clear();
            if(this.stCurrentRecordOrganisationId != "")
                this.dtLocatorsAccessableToUser =
                    getDataAccordingToRule.getUserAccessableLocators("", triStateBool.No, taskType.Order);
            
            if (this.stCurrentRecordLocatorToId != "" && 
                !this.cmbMoveTo.Enabled)
            {
                for (int rowIndex = this.dtLocatorsAccessableToUser.Rows.Count - 1;
                    rowIndex >= 0; rowIndex--)
                {
                    if (this.dtLocatorsAccessableToUser.Rows[rowIndex]["M_LOCATOR_ID"].ToString() ==
                        this.stCurrentRecordLocatorToId)
                    {
                        this.dtLocatorsAccessableToUser.Rows.RemoveAt(rowIndex);
                        break;
                    }
                }
            }

            //this.comboItemFilter(this.cmbMoveFrom, dtLocatorsAccessableToUser, e, "VALUE");
        }

        private void cmbMoveFrom_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cmbMoveFrom.SelectedItem != null)
                this.cmbMoveFrom.Text = this.cmbMoveFrom.SelectedItem.ToString();

            this.cmbMoveFrom_KeyUp(sender, new KeyEventArgs(Keys.Enter));

            this.comboBoxDropDownClosed(this.cmbMoveFrom, dtLocatorsAccessableToUser,
                this.cmbMoveFrom_SelectedIndexChanged, sender);
        }


        private void cmbMoveTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbMoveTo.SelectedIndex >= 0 &&
                this.cmbMoveTo.SelectedIndex <= this.dtLocatorsToWhichMoved.Rows.Count - 1)
            {
                this.stCurrentRecordLocatorToId =
                    this.dtLocatorsToWhichMoved.Rows[this.cmbMoveTo.SelectedIndex]["M_LOCATOR_ID"].ToString();
            }
            else
            {
                this.stCurrentRecordLocatorToId = "";
            }
        }
        
        private void cmbMoveTo_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.stCurrentRecordLocatorFromId != "")
            {
                dtLocatorsToWhichMoved = dtAllLocators.Copy();
                for (int rowCounter = dtLocatorsToWhichMoved.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    if (dtLocatorsToWhichMoved.Rows[rowCounter]["M_LOCATOR_ID"].ToString() ==
                        this.stCurrentRecordLocatorFromId)
                    {
                        dtLocatorsToWhichMoved.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
                //this.comboItemFilter(this.cmbMoveTo, dtLocatorsToWhichMoved, e, "VALUE");
            }
        }

        private void cmbMoveTo_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cmbMoveTo.SelectedItem != null)
                this.cmbMoveTo.Text = this.cmbMoveTo.SelectedItem.ToString();

            this.cmbMoveTo_KeyUp(sender, new KeyEventArgs(Keys.Enter));

            this.comboBoxDropDownClosed(this.cmbMoveTo, dtLocatorsToWhichMoved,
                this.cmbMoveTo_SelectedIndexChanged, sender);
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


            this.cmbDocumentType.DropDownStyle = ComboBoxStyle.Simple;
            this.cmbMoveFrom.DropDownStyle = ComboBoxStyle.Simple;
            this.cmbMoveTo.DropDownStyle = ComboBoxStyle.Simple;

                        
            this.intCurrentRecordNumber = this.dtgMoveSummary.SelectedRows[0].Index;

            this.enmCurrentRecordStatus = 
                this.determineRecordStatus(
                    this.dtgMoveSummary.SelectedRows[0].Cells["STATUS"].
                                        Value.ToString());

            this.stCurrentRecordId =
                    this.dtgMoveSummary.Rows[this.intCurrentRecordNumber].
                                Cells["M_MOVEORDER_ID"].Value.ToString();
            
            
            this.determineCurrentRecordType(recordType.unkown);

            //Clear Record Detial Info
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct_selectedItemChanged(sender, e);

            //Fill Main Record Grid Data to form
            this.fillCurrentGirdDataToForm();

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

            int currentSelectedRowIndex = this.dtgMoveLine.SelectedRows[0].Index;

            this.stCurrentDetailRecordLineNumber =
                this.dtgMoveLine.Rows[currentSelectedRowIndex].Cells["LINE"].Value.ToString();
                        
            this.stCurrentDetailRecordId =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["M_MOVEORDERLINE_ID"].Value.ToString();
            
            string requestLineId =
                this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["M_MOVEREQUESTLINE_ID"].Value.ToString();


            if (
                (
                  this.dtgMoveLine.CurrentCell.OwningColumn.Index == 0 &&
                  this.dtgMoveLine.CurrentCell.OwningColumn.Name == "remove" &&
                  this.dtgMoveLine.CurrentCell.Value.ToString() == "remove" &&
                  this.dtgMoveLine.CurrentCell.OwningColumn.HeaderText == ""                  
                ) &&
                (
                  this.enmCurrentRecordStatus == recordStatus.Drafted ||                  
                  this.enmCurrentRecordType == recordType.New
                )
               )                
            {
                this.addOrModifyRecordDetail(true);
                this.stCurrentDetailRecordLineNumber = "";
                this.stCurrentDetailRecordId = "";
                this.ddgProduct.SelectedRowKey = null;
                this.ddgProduct.SelectedItem = "";
                this.cmdAddOrModifyRecordDetail.Text = "ADD";
                this.cmdAddOrModifyRecordDetail.Enabled =
                    this.dtRecordDetailData.Rows.Count <= allowedLineCount;

                this.ddgProduct.SelectedRow.Clear();
                this.ddgProduct_selectedItemChanged(sender, e);
            }
            else
            {
                this.ddgProduct.SelectedRowKey =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["M_PRODUCT_ID"].Value.ToString();
                this.ddgProduct.SelectedItem =
                    this.dtgMoveLine.Rows[currentSelectedRowIndex].
                        Cells["PRODUCT"].Value.ToString();

                this.ddgProduct_selectedItemChanged(sender, e);
                if (requestLineId != "")
                    this.ddgProduct.Enabled = false;

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

            if (this.enmCurrentRecordStatus != recordStatus.Dispatched &&
                this.enmCurrentRecordStatus != recordStatus.Requested &&
                this.enmCurrentRecordStatus != recordStatus.Approved)
            {
                return false;
            }

            if (this.tscmdSave.Enabled)
            {
                return false;
            }

            string stDocumentInitiatorOrganisation =
                    this.getDataFromDb.getEM_M_LOCATORInfo(null, "",
                            this.stCurrentRecordLocatorFromId, false, false, "AND")
                        .Rows[0]["AD_ORG_ID"].ToString();

            string stDocumentInitiatorWarehouse =
                    this.getDataFromDb.getEM_M_LOCATORInfo(null, "",
                            this.stCurrentRecordLocatorFromId, false, false, "AND")
                        .Rows[0]["M_WAREHOUSE_ID"].ToString();

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

            if (dtcurrentUserCurrentRecordProcessAcess.Rows[0]["CONFIRMREQUEST"].ToString() == "Y" ||
                dtcurrentUserCurrentRecordProcessAcess.Rows[0]["ConfirmDispatch"].ToString() == "Y" ||
                dtcurrentUserCurrentRecordProcessAcess.Rows[0]["CREATEDISPATCHORDER"].ToString() == "Y")
            {
                return true;
            }
            else
                return false;

        }

        private void tmrRequestWrng_Tick(object sender, EventArgs e)
        {
            this.lblRequestAlert.Visible = !this.lblRequestAlert.Visible;
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

        private void lblDocumentNumber_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.changeDocumentNumberAndDate();
        }

        private void lblMoveDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.changeDocumentNumberAndDate();
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
        
                
    }
}
