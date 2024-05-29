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
    public partial class frmSearchInventoryIn : Form
    {
        public frmSearchInventoryIn()
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
                this.addMoreCriteria("MOVEMENTDATE", this.cmbMovementDateLogic.SelectedItem.ToString(),
                    this.dtpMoveDateFrom.Value.ToString("yyyy-MM-dd"), 
                    this.dtpMoveDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbMoveFromLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_LOCATOR_ID", this.cmbMoveFromLogic.SelectedItem.ToString(),
                    this.accessableLocators.Rows[this.cmbMovedFrom.SelectedIndex]["M_LOCATOR_ID"].ToString(),
                    "");
            }

            if (this.cmbBPartnerLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgBPartner.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_BPARTNER_ID", this.cmbBPartnerLogic.SelectedItem.ToString(),
                    this.ddgBPartner.SelectedRowKey.ToString(), "");
            }

            if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgProduct.SelectedRowKey != null)
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic.SelectedItem.ToString(),
                    this.ddgProduct.SelectedRowKey.ToString(),"");
            }

            if (this.cmbMoveQuantityLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("QTYENTERED", this.cmbMoveQuantityLogic.SelectedItem.ToString(),
                    this.ntbMovementQuantityFrom.Amount, this.ntbMovementQuantityTo.Amount);
            }



            if (this.cmbPurchaseInvoiceLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgPurchaseInvoice.SelectedRowKey != null)
            {
                this.addMoreCriteria(this.enmTaskType == taskType.In ? "C_INVOICE_ID" : "C_ORDER_ID",
                        this.cmbPurchaseInvoiceLogic.SelectedItem.ToString(),
                        this.ddgPurchaseInvoice.SelectedRowKey.ToString(), "");
            }


            if (this.cmbDeliveryOrderLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgDeliveryOrder.SelectedRowKey != null)
            {
                this.addMoreCriteria("POREFERENCE", this.cmbDeliveryOrderLogic.SelectedItem.ToString(),
                    this.ddgDeliveryOrder.SelectedItem, "");
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

        
        private void frmSearchInventoryIn_Load(object sender, EventArgs e)
        {
            if (this.enmTaskType == taskType.Out)
            {
                this.lblReceiptDate.Text = "Dispatch Date";
                this.lblBpartner.Text = "Customer";
                this.lblReceivedTo.Text = "Dispatched From";
                this.lblPurchaseInvoice.Text = "Sales Order";

                this.lblDeliveryOrder.Visible = true;
                this.cmbDeliveryOrderLogic.Visible = true;
                this.ddgDeliveryOrder.Visible = true; 
            }

            this.cmbOraganisationLogic.SelectedItem = "IGNOR";
            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDocumentTypeLogic.SelectedItem = "IGNOR";
            this.cmbMovementDateLogic.SelectedItem = "IGNOR";            
            this.cmbMoveFromLogic.SelectedItem = "IGNOR";
            this.cmbProductLogic.SelectedItem = "IGNOR";
            this.cmbBPartnerLogic.SelectedItem = "IGNOR";
            this.cmbMoveQuantityLogic.SelectedItem = "IGNOR";
            this.cmbPurchaseInvoiceLogic.SelectedItem = "IGNOR";
            this.cmbDeliveryOrderLogic.SelectedItem = "IGNOR";

            this.dtpMoveDateFrom.Value = DateTime.Today;
            this.dtpMoveDateTo.Value = DateTime.Today;

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.accessableOrganisations = getData.getOrganisations(true,true);
            this.insetDataIntoComboBox(this.cmbOrganisation, this.accessableOrganisations,
                this.accessableOrganisations.Columns.IndexOf("NAME"), 0);

            this.accessableLocators = this.getData.getUserAccessableLocators("", triStateBool.ignor, taskType.In);
            this.insetDataIntoComboBox(this.cmbMovedFrom, this.accessableLocators,
                this.accessableLocators.Columns.IndexOf("VALUE"), 0);

            this.accessableDocuments = getData.getDocuments(true, false, "", true, this.enmTaskType);
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

        private void cmbBPartnerLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbBPartnerLogic.SelectedItem.ToString(),
                this.ddgBPartner);
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
        
        private void cmbPurchaseInvoiceLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPurchaseInvoiceLogic.SelectedItem.ToString(),
                this.ddgPurchaseInvoice);
        }

        private void cmbDeliveryOrderLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDeliveryOrderLogic.SelectedItem.ToString(),
                this.ddgDeliveryOrder);
        }              
    


        private void ddgBpartner_SelectedItemClicked(object sender, EventArgs e)
        {            
            this.ddgBPartner.DataSource =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                        this.ddgBPartner.SelectedItem, 
                        this.enmTaskType == taskType.In ? triStateBool.yes: triStateBool.ignor,
                        this.enmTaskType == taskType.Out ? triStateBool.yes : triStateBool.ignor,
                        false, false, "AND");

            this.ddgBPartner.DataTablePrimaryKey =
                Convert.ToUInt16(this.ddgBPartner.DataSource.Columns.IndexOf("C_BPARTNER_ID"));
            this.ddgBPartner.SelectedColomnIdex =
                this.ddgBPartner.DataSource.Columns.IndexOf("NAME");

            this.ddgBPartner.HiddenColoumns =
                new int[] { this.ddgBPartner.DataSource.Columns.IndexOf("C_BPARTNER_LOCATION_ID") };
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


        private void ddgPurchaseInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            if (this.enmTaskType == taskType.In)
            {
                DataTable dtBPInvoiceList =
                    this.getDataFromDb.getINVOICEDETAILInfo(null, "", "", this.ddgPurchaseInvoice.SelectedItem, 
                        "", "", "", "", true, false, "AND", "", "AND");

                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("ISACTIVE"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("DOCSTATUS"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("PROCESSING"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("PROCESSED"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("C_ORDER_ID"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("ORDERNO"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("DATEORDERED"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("C_ORDERLINE_ID"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("C_INVOICELINE_ID"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("LINE"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("M_PRODUCT_ID"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("C_UOM_ID"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("QTYENTERED"));
                dtBPInvoiceList.Columns.RemoveAt(dtBPInvoiceList.Columns.IndexOf("QTYRECEIVED"));

                dtBPInvoiceList =
                    this.getDataFromDb.clearRedundantRow(dtBPInvoiceList, "C_INVOICE_ID");

                this.ddgPurchaseInvoice.DataSource = dtBPInvoiceList;

                this.ddgPurchaseInvoice.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgPurchaseInvoice.DataSource.Columns.IndexOf("C_INVOICE_ID"));
                this.ddgPurchaseInvoice.SelectedColomnIdex =
                    this.ddgPurchaseInvoice.DataSource.Columns.IndexOf("DOCUMENTNO");
                
                this.ddgPurchaseInvoice.HiddenColoumns = new int[]{
                    dtBPInvoiceList.Columns.IndexOf("C_INVOICE_ID"),
                    dtBPInvoiceList.Columns.IndexOf("C_BPARTNER_ID")};

            }
            else if (this.enmTaskType == taskType.Out)
            {
                this.ddgPurchaseInvoice.DataSource =
                this.getDataFromDb.getV_SALESORDERDETAIL_SUMMARYInfo(null, "",
                    "", "", this.ddgPurchaseInvoice.SelectedItem, false, false, "AND", "", "");

                this.ddgPurchaseInvoice.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgPurchaseInvoice.DataSource.Columns.IndexOf("C_ORDER_ID"));
                this.ddgPurchaseInvoice.SelectedColomnIdex =
                    this.ddgPurchaseInvoice.DataSource.Columns.IndexOf("DOCUMENTNO");
            }

        }

        private void ddgDeliveryOrder_SelectedItemClicked(object sender, EventArgs e)
        {
            if (this.enmTaskType == taskType.Out)
            {
                this.ddgDeliveryOrder.DataSource =
                this.getDataFromDb.getV_SALESORDERDELIVERYORDER_SUMMARYInfo(null, "",
                    "", "", this.ddgDeliveryOrder.SelectedItem, false, false, "AND", "", "");

                this.ddgDeliveryOrder.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgDeliveryOrder.DataSource.Columns.IndexOf("C_ORDER_ID"));
                this.ddgDeliveryOrder.SelectedColomnIdex =
                    this.ddgDeliveryOrder.DataSource.Columns.IndexOf("DELIVERYORDERNO");
            }
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
                this.getDataFromDb.clearRedundantRow(generalResultInformation.searchResult, "M_INOUT_ID");

            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("AD_CLIENT_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("ISACTIVE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATED"));
            //generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATEDBY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UPDATED"));
            //generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UPDATEDBY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("ISSOTRX"));
            if (this.enmTaskType == taskType.In)
            {
                generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("POREFERENCE"));
            }
            else
            {
                generalResultInformation.searchResult.Columns["POREFERENCE"].ColumnName = "DOREFERENCE";
                generalResultInformation.searchResult.Columns["VENDOR"].ColumnName = "CUSTOMER";
            }
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DOCACTION"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DOCSTATUS"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PROCESSING"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PROCESSED"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("MOVEMENTTYPE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CODE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DELIVERYRULE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("FREIGHTCOSTRULE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DELIVERYVIARULE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PRIORITYRULE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATEFROM"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("GENERATETO"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("NOPACKAGES"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATECONFIRM"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATEPACKAGE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_INOUTLINE_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("LINE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DESCRIPTION_DTL"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("C_ORDERLINE_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("C_INVOICELINE_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_LOCATOR_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_PRODUCT_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("C_UOM_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("MOVEMENTQTY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("QTYENTERED"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("NAME"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UOMSYMBOL"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("RECEIVING_STORE"));

            generalResultInformation.searchResult.Columns["MOVEMENTDATE"].ColumnName = "DATE";

            generalResultInformation.searchResult.Columns.Add("DOCUMENT");
            generalResultInformation.searchResult.Columns.Add("ORGANISATION");
            generalResultInformation.searchResult.Columns.Add("STORE FROM");

            DataTable inventoryInInfo;
            for (int rowCounter = 0; rowCounter <= generalResultInformation.searchResult.Rows.Count - 1; rowCounter++)
            {
                if (generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENT"].ToString() != "" &&
                    generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"].ToString() != "" &&
                    generalResultInformation.searchResult.Rows[rowCounter]["STORE FROM"].ToString() != "")
                {
                    continue;
                }

                if (generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENT"].ToString() == "")
                {
                    inventoryInInfo =
                        this.getDataFromDb.getEM_C_DOCTYPEInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["C_DOCTYPE_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(inventoryInInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENT"] =
                            inventoryInInfo.Rows[0]["NAME"].ToString();
 
                    }
                }

                if (generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"].ToString() == "")
                {
                    inventoryInInfo =
                        this.getDataFromDb.getEM_AD_ORGInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(inventoryInInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["ORGANISATION"] =
                            inventoryInInfo.Rows[0]["NAME"].ToString();

                    }
                }


                if (generalResultInformation.searchResult.Rows[rowCounter]["STORE FROM"].ToString() == "")
                {
                    inventoryInInfo =
                        this.getDataFromDb.getEM_M_WAREHOUSEInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(inventoryInInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["STORE FROM"] =
                            inventoryInInfo.Rows[0]["NAME"].ToString();

                    }
                }

                for (int rowCounter2 = rowCounter + 1; rowCounter2 <= generalResultInformation.searchResult.Rows.Count - 1; rowCounter2++)
                {
                    if (generalResultInformation.searchResult.Rows[rowCounter2]["DOCUMENT"].ToString() != "" &&
                        generalResultInformation.searchResult.Rows[rowCounter2]["ORGANISATION"].ToString() != "" &&
                        generalResultInformation.searchResult.Rows[rowCounter2]["STORE FROM"].ToString() != "")
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

                    if (generalResultInformation.searchResult.Rows[rowCounter2]["STORE FROM"].ToString() == "" &&
                        (generalResultInformation.searchResult.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString() ==
                        generalResultInformation.searchResult.Rows[rowCounter2]["M_WAREHOUSE_ID"].ToString()))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter2]["STORE FROM"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["STORE FROM"];
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
            string columnNameToCompareWith = "M_INOUT_ID";
                        
            this.establishSearchCriterion();

            currentSearchCriteriaResult =
                this.getDataFromDb.getV_INOUTDETAILInfo(this.searchQuery, this.logicalConnector, "",
                        "", "", "", "", 
                        this.enmTaskType == taskType.Out ? triStateBool.yes : triStateBool.No,
                        false, false, "AND", "", "");
                

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
