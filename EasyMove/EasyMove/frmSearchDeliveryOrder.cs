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
    public partial class frmSearchDeliveryOrder : Form
    {
        public frmSearchDeliveryOrder()
        {
            InitializeComponent();
        }


        businessRule getData = new businessRule();
        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();
        DataTable accessableWarehouses = new DataTable();

        string stAccessableWarehouses = "";
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
            if (field == "" || criterion == "" || valueFrom == "")
                return;
            if (criterion == "In between of")
            {
                this.addMoreCriteria(field, "Greater or equals to", valueFrom, "");
                this.addMoreCriteria(field, "Lesser or equal to", valueTo, "");
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

            if (this.cmbDONumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DELIVERYORDERNO", this.cmbDONumberLogic.SelectedItem.ToString(),
                    this.txtDONumberFrom.Text, this.txtDONumberTo.Text);
            }

            if (this.cmbSalesOrderLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgSalesOrder.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_ORDER_ID", this.cmbSalesOrderLogic.SelectedItem.ToString(),
                    this.ddgSalesOrder.SelectedRowKey.ToString(), "");
            }

            if (this.cmbOrderDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DATEORDERED", this.cmbOrderDateLogic.SelectedItem.ToString(),
                    this.dtpOrderDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpOrderDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbDeliveredFromLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_WAREHOUSE_ID", this.cmbDeliveredFromLogic.SelectedItem.ToString(),
                    this.accessableWarehouses.Rows[this.cmbDeliveredFrom.SelectedIndex]["M_WAREHOUSE_ID"].ToString(),
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
                    this.ddgProduct.SelectedRowKey.ToString(), "");
            }

            if (this.cmbOrderedQtyLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("QTYORDERED", this.cmbOrderedQtyLogic.SelectedItem.ToString(),
                    this.ntbOrderedQtyFrom.Amount, this.ntbOrderedQtyTo.Amount);
            }

            if (this.cmbDeliveredQtyLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("QTYDELIVERED", this.cmbDeliveredQtyLogic.SelectedItem.ToString(),
                    this.ntbDeliveredQtyFrom.Amount, this.ntbDeliveredQtyTo.Amount);
            }

            if (this.cmbPendingQtyLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("QTYRESERVED", this.cmbPendingQtyLogic.SelectedItem.ToString(),
                    this.ntbPendingQtyFrom.Amount, this.ntbPendingQtyTo.Amount);
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



        private void frmSearchDeliveryOrder_Load(object sender, EventArgs e)
        {
            this.cmbDONumberLogic.SelectedItem = "IGNOR";
            this.cmbSalesOrderLogic.SelectedItem = "IGNOR";
            this.cmbOrderDateLogic.SelectedItem = "IGNOR";
            this.cmbDeliveredFromLogic.SelectedItem = "IGNOR";
            this.cmbProductLogic.SelectedItem = "IGNOR";
            this.cmbBPartnerLogic.SelectedItem = "IGNOR";
            this.cmbOrderedQtyLogic.SelectedItem = "IGNOR";
            this.cmbDeliveredQtyLogic.SelectedItem = "IGNOR";
            this.cmbPendingQtyLogic.SelectedItem = "IGNOR";

            this.dtpOrderDateFrom.Value = DateTime.Today;
            this.dtpOrderDateTo.Value = DateTime.Today;

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
                        
            this.accessableWarehouses =
                this.getData.getUserAccessableWarehouses("", triStateBool.ignor, taskType.Out, false);
            this.insetDataIntoComboBox(this.cmbDeliveredFrom, this.accessableWarehouses,
                this.accessableWarehouses.Columns.IndexOf("NAME"), 0);

            if (this.cmbDeliveredFrom.Items.Count > 0)
            {
                foreach (DataRow dr in this.accessableWarehouses.Rows)
                {
                    this.stAccessableWarehouses = this.stAccessableWarehouses + 
                            dr["M_WAREHOUSE_ID"].ToString() + ", ";
                }
                this.stAccessableWarehouses = 
                    this.stAccessableWarehouses.Remove(this.stAccessableWarehouses.Length - 2, 2);
            }


            //this.ckAllOrAny.Checked = true;
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();

        }

        private void cmbDONumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDONumberLogic.SelectedItem.ToString(),
                this.txtDONumberFrom);

            if (this.cmbDONumberLogic.SelectedItem.ToString() == "In between of")
                this.txtDONumberTo.Visible = true;
            else
                this.txtDONumberTo.Visible = false;
        }

        private void cmbSalesOrderLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSalesOrderLogic.SelectedItem.ToString(),
                this.ddgSalesOrder);
        }

        private void cmbOrderDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbOrderDateLogic.SelectedItem.ToString(),
                this.dtpOrderDateFrom);

            if (this.cmbOrderDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpOrderDateTo.Visible = true;
            else
                this.dtpOrderDateTo.Visible = false;
        }

        private void cmbBPartnerLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbBPartnerLogic.SelectedItem.ToString(),
                this.ddgBPartner);
        }

        private void cmbDeliveredFromLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDeliveredFromLogic.SelectedItem.ToString(),
                this.cmbDeliveredFrom);
        }

        private void cmbProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbProductLogic.SelectedItem.ToString(),
                this.ddgProduct);
        }

        private void cmbOrderedQtyLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbOrderedQtyLogic.SelectedItem.ToString(),
                this.ntbOrderedQtyFrom);

            if (this.cmbOrderedQtyLogic.SelectedItem.ToString() == "In between of")
                this.ntbOrderedQtyTo.Visible = true;
            else
                this.ntbOrderedQtyTo.Visible = false;

        }

        private void cmbDeliveredQtyLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDeliveredQtyLogic.SelectedItem.ToString(),
                this.ntbDeliveredQtyFrom);

            if (this.cmbDeliveredQtyLogic.SelectedItem.ToString() == "In between of")
                this.ntbDeliveredQtyTo.Visible = true;
            else
                this.ntbDeliveredQtyTo.Visible = false;

        }

        private void cmbPendingQtyLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPendingQtyLogic.SelectedItem.ToString(),
                this.ntbPendingQtyFrom);

            if (this.cmbPendingQtyLogic.SelectedItem.ToString() == "In between of")
                this.ntbPendingQtyTo.Visible = true;
            else
                this.ntbPendingQtyTo.Visible = false;
        }

        private void ddgBPartner_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgBPartner.DataSource =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                        this.ddgBPartner.SelectedItem, triStateBool.ignor, triStateBool.yes,
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
                           true, this.ddgProduct.SelectedItem, "", true);
            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey = Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex = productInformation.Columns.IndexOf("NAME");
            int[] hiddenProductColumns = { productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID") };
            ddgProduct.HiddenColoumns = hiddenProductColumns;
        }

        private void ddgSalesOrder_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgSalesOrder.DataSource =
                this.getDataFromDb.getV_SALESORDERDETAIL_SUMMARYInfo(null, "",
                    "", "", this.ddgSalesOrder.SelectedItem, false, false, "AND", "", "");

            this.ddgSalesOrder.DataTablePrimaryKey =
                Convert.ToUInt16(this.ddgSalesOrder.DataSource.Columns.IndexOf("C_ORDER_ID"));
            this.ddgSalesOrder.SelectedColomnIdex =
                this.ddgSalesOrder.DataSource.Columns.IndexOf("DOCUMENTNO");
        }


        private void ckAllOrAny_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckAllOrAny.Checked)
                this.logicalConnector = "OR";
            else
                this.logicalConnector = "AND"; 
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
            string columnNameToCompareWith = "C_ORDERLINE_ID";

            this.establishSearchCriterion();

            currentSearchCriteriaResult =
                this.getDataFromDb.getV_SALESORDERDETAILInfo(this.searchQuery, this.logicalConnector,
                        "", "", "", "", "", "", "", "",
                        false, false, "AND", "M_WAREHOUSE_ID IN (" + this.stAccessableWarehouses + ")", "AND");


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
                this.getDataFromDb.clearRedundantRow(generalResultInformation.searchResult, "C_ORDERLINE_ID");

            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("C_BPARTNER_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("ISACTIVE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DOCSTATUS"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PROCESSING"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("PROCESSED"));

            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_PRODUCT_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("C_UOM_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_WAREHOUSE_ID"));

            this.Enabled = true;
            this.Close();

        }
               






    
    }
}
