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
    public partial class frmSearchInventoryMakeUpChange : Form
    {
        public frmSearchInventoryMakeUpChange()
        {
            InitializeComponent();
        }

        public taskType enmTaskType = taskType.Unkown;

        businessRule getData = new businessRule();
        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();
        DataTable accessableOrganisations = new DataTable();
        DataTable accessableDocuments = new DataTable();

        string stSearchQuery = "";
        string logicalConnector = "AND";
                

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
                this.addMoreCriteria("REQUESTDATE", this.cmbMovementDateLogic.SelectedItem.ToString(),
                    this.dtpMoveDateFrom.Value.ToString("yyyy-MM-dd"), 
                    this.dtpMoveDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgProduct.SelectedRowKey != null)
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic.SelectedItem.ToString(),
                    this.ddgProduct.SelectedRowKey.ToString(),"");
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

        
        private void frmSearchInventoryMakeUpChange_Load(object sender, EventArgs e)
        {
            this.cmbOraganisationLogic.SelectedItem = "IGNOR";
            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDocumentTypeLogic.SelectedItem = "IGNOR";
            this.cmbMovementDateLogic.SelectedItem = "IGNOR";
            this.cmbProductLogic.SelectedItem = "IGNOR";

            this.dtpMoveDateFrom.Value = DateTime.Today;
            this.dtpMoveDateTo.Value = DateTime.Today;

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.accessableOrganisations = getData.getOrganisations(true,true);
            this.insetDataIntoComboBox(this.cmbOrganisation, this.accessableOrganisations,
                this.accessableOrganisations.Columns.IndexOf("NAME"), 0);

            this.accessableDocuments =
                getData.getDocuments(true, false, "", true, taskType.Makeup);
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

        private void cmbProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbProductLogic.SelectedItem.ToString(),
                this.ddgProduct);
        }


        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation = 
                getData.getProducts(true, false, triStateBool.ignor, triStateBool.ignor,
                        triStateBool.ignor, triStateBool.ignor,
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
        }
               
        
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //this.establishSearchCriterion();
            generalResultInformation.searchCritrion = this.searchQuery;
            generalResultInformation.logicConnector = this.logicalConnector;
            
            if (!this.getDataFromDb.checkIfTableContainesData
                (generalResultInformation.searchResult))
            {
                MessageBox.Show("No Record Found For Search Query",
                    "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;
                return;
            }

            generalResultInformation.searchResult =
                this.getDataFromDb.clearRedundantRow(generalResultInformation.searchResult, "M_BOM_CHANGE_ID");


            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("AD_CLIENT_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("ISACTIVE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATED"));
            //generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATEDBY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UPDATED"));
            //generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UPDATEDBY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DOCACTION"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PROCESSED"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PROCESSING"));

            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("ISAPPROVED"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_BOM_CHANGE_LINE_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("LINE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_BOM_PRODUCT_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("BOMQTY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DESCRIPTION_DTL"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("C_UOM_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("BOM_NAME"));


            generalResultInformation.searchResult.Columns["REQUESTDATE"].ColumnName = "DATE";

            generalResultInformation.searchResult.Columns.Add("DOCUMENT");
            generalResultInformation.searchResult.Columns.Add("ORGANISATION");

            DataTable inventoryMakeUpChangeInfo;
            for (int rowCounter = 0; rowCounter <= generalResultInformation.searchResult.Rows.Count - 1; rowCounter++)
            {
                if (generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENT"].ToString() != "" &&
                    generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"].ToString() != "")
                {
                    continue;
                }

                if (generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENT"].ToString() == "")
                {
                    inventoryMakeUpChangeInfo =
                        this.getDataFromDb.getEM_C_DOCTYPEInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["C_DOCTYPE_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(inventoryMakeUpChangeInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENTNO"] =
                            inventoryMakeUpChangeInfo.Rows[0]["NAME"].ToString();
 
                    }
                }               
                
                if (generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"].ToString() == "")
                {
                    inventoryMakeUpChangeInfo =
                        this.getDataFromDb.getEM_AD_ORGInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(inventoryMakeUpChangeInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"] =
                            inventoryMakeUpChangeInfo.Rows[0]["NAME"].ToString();

                    }
                }

                if (generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"].ToString() == "DR")
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"] = "Draft";
                }
                else if (generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"].ToString() == "RQ")
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"] = "Requested";
                }
                else if (generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"].ToString() == "AP")
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"] = "Approved";
                }
                else if (generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"].ToString() == "VO")
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"] = "Cancelled";
                }
                else if (generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"].ToString() == "CL")
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"] = "Closed";
                }

                for (int rowCounter2 = rowCounter + 1; rowCounter2 <= generalResultInformation.searchResult.Rows.Count - 1; rowCounter2++)
                {
                    if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCUMENT"].ToString() != "" &&
                        generalResultInformation.searchResult.Rows[rowCounter2]["ORGANISATION"].ToString() != "")
                    {
                        continue;
                    }

                    if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCUMENT"].ToString() == "" &&
                        (generalResultInformation.searchResult.Rows[rowCounter]["C_DOCTYPE_ID"].ToString() ==
                        generalResultInformation.searchResult.Rows[rowCounter2]["C_DOCTYPE_ID"].ToString()))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["DOCUMENT"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENT"];
                    }

                    if (generalResultInformation.searchResult.Rows[rowCounter2]["ORGANISATION"].ToString() == "" &&
                        (generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString() ==
                        generalResultInformation.searchResult.Rows[rowCounter2]["AD_ORG_ID"].ToString()))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["ORGANISATION"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"];
                    }

                    if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"].ToString() == "DR")
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"] = "Draft";
                    }
                    else if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"].ToString() == "RQ")
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"] = "Requested";
                    }
                    else if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"].ToString() == "AP")
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"] = "Approved";
                    }
                    else if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"].ToString() == "VO")
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"] = "Cancelled";
                    }
                    else if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"].ToString() == "CL")
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["DOCSTATUS"] = "Closed";
                    }
                } 
            }

            this.Enabled = true;
            this.Close();          
        }

        private void cmbSearchAndIncludeToPreviousResult_Click(object sender, EventArgs e)
        {
            DialogResult considerPreviousCriteria = 
                MessageBox.Show("Should New Search Result Consider Previous Criterion",
                        "Look Up", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;
            
            this.Enabled = false;

            DataTable currentSearchCriteriaResult = new DataTable();
            string columnNameToCompareWith = "M_BOM_CHANGE_ID";
                        
            this.establishSearchCriterion();

            currentSearchCriteriaResult =
                this.getDataFromDb.getV_BOMCHANGEDETAILInfo(this.searchQuery, this.logicalConnector, "",
                        "", "", "", "", "", triStateBool.ignor, false, false, "AND", "", "");
                

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
