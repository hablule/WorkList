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
    public partial class frmSearchInventoryMove : Form
    {
        public frmSearchInventoryMove()
        {
            InitializeComponent();
        }

        public taskType enmTaskType = taskType.Unkown;

        businessRule getData = new businessRule();
        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();
        DataTable accessableOrganisations = new DataTable();
        DataTable accessableLocators = new DataTable();
        DataTable accessableDocuments = new DataTable();

        string stSearchQuery = "";
        string logicalConnector = "AND";

        List<String> stAccessableLocatorList = new List<string>();
                

        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            if (!getDataFromDb.checkIfTableContainesData(dataSourceTable))
                return;

            if (!dataSourceTable.Columns.Contains("_Index"))
                dataSourceTable.Columns.Add("_Index", System.Type.GetType("System.Int16"));

            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                dataSourceTable.Rows[rowCounter]["_Index"] = rowCounter;
            }
            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                _comboBoxContorl.Items.Insert(Convert.ToInt16(dataSourceTable.Rows[rowCounter]["_Index"]),
                    dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString());
            }
            if (selectedIndex >= 0 &&
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }
        
        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }

        private void enableDisableCheckBoxStatus(CheckBox _checkBoxControl)
        {
            if (!this.ckAllOrAny.Checked &&
                _checkBoxControl.CheckState == CheckState.Checked)
            {
                CheckState _currentCheckBoxState = _checkBoxControl.CheckState;
                if(this.ckIsDraft.CheckState == CheckState.Checked)
                    this.ckIsDraft.CheckState = CheckState.Indeterminate;
                if (this.ckIsInTrasit.CheckState == CheckState.Checked)
                    this.ckIsInTrasit.CheckState = CheckState.Indeterminate;
                if (this.ckIsDelivered.CheckState == CheckState.Checked)
                    this.ckIsDelivered.CheckState = CheckState.Indeterminate;
                if (this.ckIsAccepted.CheckState == CheckState.Checked)
                    this.ckIsAccepted.CheckState = CheckState.Indeterminate;
                if (this.ckIsCancelled.CheckState == CheckState.Checked)
                    this.ckIsCancelled.CheckState = CheckState.Indeterminate;
                if (this.ckOnDispute.CheckState == CheckState.Checked)
                    this.ckOnDispute.CheckState = CheckState.Indeterminate;
                _checkBoxControl.CheckState = _currentCheckBoxState;
            }
        }
                
        private void addMoreCriteria(string field, string criterion, string valueFrom, string valueTo)
        {
            if(field == "" || criterion == "" || valueFrom == "")
                return;
            if (criterion == "In between of")
            {
                this.addMoreCriteria(field, "Greater or equals to", valueFrom,"");
                this.addMoreCriteria(field, "Lesser or equal to", valueTo,"");
            }
            else
            {
                DataRow criteriaValue = this.searchQuery.NewRow();

                criteriaValue["Field"] = field;
                criteriaValue["Criterion"] = this.generateEquivalentSymbol(criterion);
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.searchQuery.Rows.Add(criteriaValue); 
            }
                 
        }

        private void establishSearchCriterion()
        {
            this.searchQuery.Clear();
            string transactionType = "MOVEMENT";
            if (this.ckIsRequest.Checked)
            {
                if (this.enmTaskType == taskType.Order)
                    transactionType = "ORDER";
                else
                    transactionType = "REQUEST";
            }

            if (this.cmbOraganisationLogic.SelectedItem.ToString() != "IGNOR")
            {                
                this.addMoreCriteria("AD_ORG_ID", this.cmbOraganisationLogic.SelectedItem.ToString(),
                    this.accessableOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString(),
                    "");                               
            }
            
            if(this.cmbDocumentNumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DOCUMENTNO", this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumberFrom.Text, this.txtDocumentNumberTo.Text);
            }

            if (this.cmbDocumentTypeLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("C_DOCTYPE_ID", this.cmbDocumentTypeLogic.SelectedItem.ToString(),
                    this.accessableDocuments.Rows[this.cmbDocumentType.SelectedIndex]["C_DOCTYPE_ID"].ToString(),
                    "");
            }

            if (this.cmbMovementDateLogic.SelectedItem.ToString() != "IGNOR")
            {                
                this.addMoreCriteria(transactionType + "DATE", this.cmbMovementDateLogic.SelectedItem.ToString(),
                    this.dtpMoveDateFrom.Value.ToString("yyyy-MM-dd"), 
                    this.dtpMoveDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbMoveFromLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_LOCATOR_ID", this.cmbMoveFromLogic.SelectedItem.ToString(),
                    this.accessableLocators.Rows[this.cmbMovedFrom.SelectedIndex]["M_LOCATOR_ID"].ToString(),
                    "");
            }

            if (this.cmbMoveToLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_LOCATORTO_ID", this.cmbMoveToLogic.SelectedItem.ToString(),
                    this.accessableLocators.Rows[this.cmbMovedTo.SelectedIndex]["M_LOCATOR_ID"].ToString(),
                    "");
            }

            if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgProduct.SelectedRowKey != null)
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic.SelectedItem.ToString(),
                    this.ddgProduct.SelectedRowKey.ToString(),"");
            }

            if (this.cmbMoveQuantityLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria(transactionType + "QTY", this.cmbMoveQuantityLogic.SelectedItem.ToString(),
                    this.ntbMovementQuantityFrom.Amount, this.ntbMovementQuantityTo.Amount);
            }

            if (!this.ckIsRequest.Checked)
                transactionType = "MOVE";

            string status = "";

            if (this.ckIsDraft.CheckState != CheckState.Indeterminate)
            {
                if(this.ckIsRequest.Checked)
                    status = this.enmTaskType == taskType.Order ? 
                        transactionStatusInformation.newOrder : 
                        transactionStatusInformation.newRequest;
                else
                    status = transactionStatusInformation.newDispatch;
                
                if(this.ckIsDraft.CheckState == CheckState.Checked)
                    this.addMoreCriteria(transactionType + "STATUS", "Equals to", status, "");
                else if(this.ckIsDraft.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria(transactionType + "STATUS", "Not equals to", status, "");
            }

            if (this.ckIsInTrasit.CheckState != CheckState.Indeterminate)
            {
                if (this.ckIsRequest.Checked)
                    status = this.enmTaskType == taskType.Order ? 
                        transactionStatusInformation.approvedOrder : 
                        transactionStatusInformation.confirmedRequest;
                else
                    status = transactionStatusInformation.confirmedDispatch;

                if (this.ckIsInTrasit.CheckState == CheckState.Checked)
                    this.addMoreCriteria(transactionType + "STATUS", "Equals to", status, "");
                else if (this.ckIsInTrasit.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria(transactionType + "STATUS", "Not equals to", status, "");
            }

            if (this.ckIsDelivered.CheckState != CheckState.Indeterminate)
            {
                status = transactionStatusInformation.deliveryReceived;

                if (this.ckIsDelivered.CheckState == CheckState.Checked)
                    this.addMoreCriteria(transactionType + "STATUS", "Equals to", status, "");
                else if (this.ckIsDelivered.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria(transactionType + "STATUS", "Not equals to", status, "");
            }

            if (this.ckIsAccepted.CheckState != CheckState.Indeterminate)
            {
                if (this.ckIsRequest.Checked)
                    status = this.enmTaskType == taskType.Order ?
                        transactionStatusInformation.satisfiedOrder :
                        transactionStatusInformation.satisfiedRequest;
                else
                    status = transactionStatusInformation.deliveryAccepted;

                if (this.ckIsAccepted.CheckState == CheckState.Checked)
                    this.addMoreCriteria(transactionType + "STATUS", "Equals to", status, "");
                else if (this.ckIsAccepted.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria(transactionType + "STATUS", "Not equals to", status, "");
            }

            string criterion = "";
            if (this.ckOnDispute.CheckState != CheckState.Indeterminate)
            {
                
                if (this.ckOnDispute.CheckState == CheckState.Checked)
                    criterion = " IN ";
                else if (this.ckOnDispute.CheckState == CheckState.Unchecked)
                    criterion = " NOT IN ";

                this.stSearchQuery = transactionType + "STATUS " + criterion +
                        "('" + transactionStatusInformation.deliveryDisputed +
                        "', '" + transactionStatusInformation.disputeRejected + "')";
            }
                        
            if (this.ckIsCancelled.CheckState != CheckState.Indeterminate)
            {
                if (this.ckIsRequest.Checked)
                    status = this.enmTaskType == taskType.Order ?
                        transactionStatusInformation.closedOrder :
                        transactionStatusInformation.closedRequest;
                else
                    status = transactionStatusInformation.disputeAccepted;

                if (this.ckIsCancelled.CheckState == CheckState.Checked)
                    this.addMoreCriteria(transactionType + "STATUS", "Equals to", status, "");
                else if (this.ckIsCancelled.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria(transactionType + "STATUS", "Not equals to", status, "");
            }                        
        }
        
        private string generateEquivalentSymbol(string symbolInText)
        {
            if (symbolInText == "Equals to")
                return "=";
            if (symbolInText == "Not equals to")
                return "!=";
            if (symbolInText == "Similar to")
                return "like";
            if (symbolInText == "Not similar to")
                return "not like";
            if (symbolInText == "Greater than")
                return ">";
            if (symbolInText == "Greater or equals to")
                return ">=";
            if (symbolInText == "Less than")
                return "<";
            if (symbolInText == "Lesser or equal to")
                return "<=";
            return "";
        }

        private void changeInterface()
        {
            if (this.ckIsRequest.Checked)
            {
                this.lblMovementDate.Text =
                    this.enmTaskType == taskType.Order ? "Order Date" : "Request Date";
                this.lblMoveFrom.Text =
                    this.enmTaskType == taskType.Order ? "Dispatching Store" : "Requesting Store";
                this.lblMoveTo.Text =
                    this.enmTaskType == taskType.Order ? "Receiving Store" : "Requested From";

                this.ckIsInTrasit.Text =
                    this.enmTaskType == taskType.Order ? "On Order" : "On Request";
            }
            else
            {
                this.lblMovementDate.Text = "Movement Date ";
                this.lblMoveFrom.Text = "Move From";
                this.lblMoveTo.Text = "Move To";

                this.ckIsInTrasit.Text = "In Transit";
            }
        }

        private void frmSearchInventoryMove_Load(object sender, EventArgs e)
        {
            this.cmbOraganisationLogic.SelectedItem = "IGNOR";
            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDocumentTypeLogic.SelectedItem = "IGNOR";
            this.cmbMovementDateLogic.SelectedItem = "IGNOR";            
            this.cmbMoveFromLogic.SelectedItem = "IGNOR";
            this.cmbMoveToLogic.SelectedItem = "IGNOR";
            this.cmbProductLogic.SelectedItem = "IGNOR";
            this.cmbMoveQuantityLogic.SelectedItem = "IGNOR";

            this.dtpMoveDateFrom.Value = DateTime.Today;
            this.dtpMoveDateTo.Value = DateTime.Today;

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");


            this.ckIsRequest.Enabled = false;
            this.ckIsRequest.Checked =
                this.enmTaskType == taskType.Request || this.enmTaskType == taskType.Order
                    ? true : false;
            this.ckIsRequest.Text =
                this.enmTaskType == taskType.Request ? "Is Request" : "Is Order";

            this.accessableOrganisations = getData.getOrganisations(true,true);
            this.insetDataIntoComboBox(this.cmbOrganisation, this.accessableOrganisations,
                this.accessableOrganisations.Columns.IndexOf("NAME"), 0);

            if (this.ckIsRequest.Checked)
            {
                this.accessableLocators =
                    this.getData.getUserAccessableLocators("", triStateBool.ignor,
                                                taskType.Request);
            }
            else
            {
                this.accessableLocators =
                    this.getData.getUserAccessableLocators("", triStateBool.ignor,
                                                taskType.Dispatch);
                if (this.getDataFromDb.checkIfTableContainesData(this.accessableLocators))
                {
                    this.accessableLocators =
                        this.getDataFromDb.mergeTables(
                                    this.accessableLocators,
                                    this.getData.getUserAccessableLocators("", 
                                                triStateBool.ignor, taskType.Receive),
                                    "M_LOCATOR_ID", false);
                }
                else
                {
                    this.accessableLocators =
                        this.getData.getUserAccessableLocators("", triStateBool.ignor,
                                                taskType.Receive);
                }
            }

            this.accessableLocators = 
                this.getDataFromDb.clearRedundantRow(this.accessableLocators, 
                    "M_LOCATOR_ID");

            this.stAccessableLocatorList = 
                this.accessableLocators.AsEnumerable()
                        .Select(r => (r.Field<int>("M_LOCATOR_ID")).ToString())
                        .ToList();
            this.stAccessableLocatorList.Sort();

            this.accessableLocators = 
                this.getData.getLocators(false, true, "",false);

            this.insetDataIntoComboBox(this.cmbMovedFrom, this.accessableLocators,
                this.accessableLocators.Columns.IndexOf("VALUE"), 0);
            this.insetDataIntoComboBox(this.cmbMovedTo, this.accessableLocators,
                this.accessableLocators.Columns.IndexOf("VALUE"), 0);

            this.accessableDocuments = getData.getDocuments(true, false, "", true);
            this.insetDataIntoComboBox(this.cmbDocumentType, this.accessableDocuments,
                this.accessableDocuments.Columns.IndexOf("NAME"), 0);

            //this.ckAllOrAny.Checked = true;
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();

            
        }
                        
        private void cmbOraganisationLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbOraganisationLogic.SelectedItem.ToString(),
                this.cmbOrganisation);            
        }

        private void cmbDocumentNumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                this.txtDocumentNumberFrom);

            if (cmbDocumentNumberLogic.SelectedItem.ToString() == "In between of")
                this.txtDocumentNumberTo.Visible = true;
            else
                this.txtDocumentNumberTo.Visible = false;
        }

        private void cmbDocumentTypeLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDocumentTypeLogic.SelectedItem.ToString(),
                this.cmbDocumentType);
        }

        private void cmbMovementDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMovementDateLogic.SelectedItem.ToString(),
                this.dtpMoveDateFrom);

            if (this.cmbMovementDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpMoveDateTo.Visible = true;
            else
                this.dtpMoveDateTo.Visible = false;
        }

        private void cmbMoveFromLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMoveFromLogic.SelectedItem.ToString(),
                this.cmbMovedFrom);
        }

        private void cmbMoveToLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMoveToLogic.SelectedItem.ToString(),
                this.cmbMovedTo);
        }

        private void cmbProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbProductLogic.SelectedItem.ToString(),
                this.ddgProduct);
        }

        private void cmbMoveQuantityLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMoveQuantityLogic.SelectedItem.ToString(),
                this.ntbMovementQuantityFrom);

            if (this.cmbMoveQuantityLogic.SelectedItem.ToString() == "In between of")
                this.ntbMovementQuantityTo.Visible = true;
            else
                this.ntbMovementQuantityTo.Visible = false;
        }
        
        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation = 
                getData.getProducts(true, false, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                            true,this.ddgProduct.SelectedItem, "", true);
            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey = Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex = productInformation.Columns.IndexOf("NAME");
            int[] hiddenProductColumns = { productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID") };
            ddgProduct.HiddenColoumns = hiddenProductColumns;

        }
        
        private void ckAllOrAny_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckAllOrAny.Checked)
                this.logicalConnector = "OR";
            else
                this.logicalConnector = "AND";
            if (logicalConnector == "AND")
            {
                this.ckIsInTrasit.CheckState = CheckState.Checked;
                this.ckIsInTrasit_CheckedChanged(sender, e);
            }
        }
               
        private void ckIsRequest_CheckedChanged(object sender, EventArgs e)
        {
            this.ckIsDelivered.CheckState = CheckState.Indeterminate;
            this.ckOnDispute.CheckState = CheckState.Indeterminate;
            this.ckIsCancelled.CheckState = CheckState.Indeterminate;
            this.ckIsAccepted.CheckState = CheckState.Indeterminate;

            this.changeInterface();

            if (ckIsRequest.Checked)
            {
                this.ckIsDelivered.Enabled = false;
                this.ckOnDispute.Enabled = false;
                //this.ckIsCancelled.Enabled = false;
                //this.ckIsAccepted.Enabled = false;
            }
            else
            {
                this.ckIsDelivered.Enabled = true;
                this.ckOnDispute.Enabled = true;
                this.ckIsCancelled.Enabled = true;
                this.ckIsAccepted.Enabled = true;
            }
        }

        private void ckIsDraft_CheckedChanged(object sender, EventArgs e)
        {
            this.enableDisableCheckBoxStatus(this.ckIsDraft);            
        }

        private void ckIsInTrasit_CheckedChanged(object sender, EventArgs e)
        {
            this.enableDisableCheckBoxStatus(this.ckIsInTrasit);            
        }

        private void ckIsReceived_CheckedChanged(object sender, EventArgs e)
        {
            this.enableDisableCheckBoxStatus(this.ckIsDelivered);            
        }

        private void ckIsAccepted_CheckedChanged(object sender, EventArgs e)
        {
            this.enableDisableCheckBoxStatus(this.ckIsAccepted);            
        }

        private void ckIsCancelled_CheckedChanged(object sender, EventArgs e)
        {
            this.enableDisableCheckBoxStatus(this.ckIsCancelled);            
        }

        private void ckOnDispute_CheckedChanged(object sender, EventArgs e)
        {
            this.enableDisableCheckBoxStatus(this.ckOnDispute);            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //this.establishSearchCriterion();
            generalResultInformation.searchCritrion = this.searchQuery;
            generalResultInformation.logicConnector = this.logicalConnector;
            generalResultInformation.isRequest = this.ckIsRequest.Checked;           
            
            if (!this.getDataFromDb.checkIfTableContainesData
                (generalResultInformation.searchResult))
            {
                MessageBox.Show("No Record Found For Search Query",
                    "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;                
            }
            else
            {
                this.Enabled = true;
                this.Close();
            }            
        }

        private void cmbSearchAndIncludeToPreviousResult_Click(object sender, EventArgs e)
        {
            if (this.cmbMoveFromLogic.SelectedIndex != 0 &&
                this.cmbMoveToLogic.SelectedIndex != 0)
            {
                if (
                    (
                     !this.stAccessableLocatorList.Contains(this.accessableLocators.Rows[this.cmbMovedFrom.SelectedIndex]["M_LOCATOR_ID"].ToString()) &&
                     !this.stAccessableLocatorList.Contains(this.accessableLocators.Rows[this.cmbMovedTo.SelectedIndex]["M_LOCATOR_ID"].ToString())
                    )
                    ||
                    this.accessableLocators.Rows[this.cmbMovedFrom.SelectedIndex]["M_LOCATOR_ID"].ToString() ==
                    this.accessableLocators.Rows[this.cmbMovedTo.SelectedIndex]["M_LOCATOR_ID"].ToString()
                    )
                {
                    MessageBox.Show("Search Query contains unobtainable requirment.",
                            "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DialogResult considerPreviousCriteria = 
                MessageBox.Show("Should New Search Result Consider Previous Criterion",
                        "Look Up", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;
            
            this.Enabled = false;

            DataTable currentSearchCriteriaResult = new DataTable();
            string columnNameToCompareWith = "M_MOVEMENT_ID";
            if (this.ckIsRequest.Checked)
            {
                columnNameToCompareWith =
                    this.enmTaskType == taskType.Request ? "M_MOVEREQUEST_ID" : "M_MOVEORDER_ID";
            }
            
            this.establishSearchCriterion();
            
            currentSearchCriteriaResult =
                getData.getMovementRequestResult
                (this.searchQuery, this.logicalConnector, this.ckIsRequest.Checked, 
                            this.enmTaskType == taskType.Order, this.stSearchQuery);

            if (considerPreviousCriteria == DialogResult.Yes)
            {
                if (!this.getDataFromDb.checkIfTableContainesData
                (currentSearchCriteriaResult))
                {
                    MessageBox.Show("No Record Found For Search Query",
                        "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generalResultInformation.searchResult.Clear();
                    this.Enabled = true;
                    return;
                }
                generalResultInformation.searchResult =
                    this.getDataFromDb.mergeTables(generalResultInformation.searchResult,
                    currentSearchCriteriaResult, columnNameToCompareWith, true);
            }

            else if (considerPreviousCriteria == DialogResult.No)
            {
                generalResultInformation.searchResult =
                    this.getDataFromDb.mergeTables(generalResultInformation.searchResult,
                    currentSearchCriteriaResult, columnNameToCompareWith, false);
            }
            this.Enabled = true;        
        }              
    
}
}
