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
    public partial class frmMatchInvoices : Form
    {
        public frmMatchInvoices()
        {
            InitializeComponent();
        }

        string stSearchQuery = "";
        string logicalConnector = "AND";

        string stBPaternerID = "";
        string stGRNID = "";
        string stWarehouseID = "";

        decimal matchedQty = 0;
        decimal remainingQty = 0;
        

        DataTable dtInvoiceRecordData = new DataTable();
        DataTable dtGRNRecordData = new DataTable();
        DataTable dtUnmatchedIncomingInventoryDetailData = new DataTable();
        DataTable dtUnmatchedIncomingMatchingInvoiceData = new DataTable();


        public taskType enmTaskType = taskType.Unkown;

        businessRule getData = new businessRule();
        dataBuilder getDataFromDb = new dataBuilder();
        DataTable searchQuery = new DataTable();

        DataTable accessableLocators = new DataTable();
        DataTable dtSearchAccessableLocators = new DataTable();
                
        

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
                        
            if (this.cmbMovementDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("MOVEMENTDATE", this.cmbMovementDateLogic.SelectedItem.ToString(),
                    this.dtpMoveDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpMoveDateTo.Value.ToString("yyyy-MM-dd"));
            }            

            if (this.stBPaternerID != "")
            {
                this.addMoreCriteria("C_BPARTNER_ID", "Equals to",
                    stBPaternerID, "");
            }

            if (this.stGRNID != "")
            {
                this.addMoreCriteria("M_INOUT_ID", "Equals to",
                    stGRNID, "");
            }

            if (this.cmbMoveFromLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_LOCATOR_ID", this.cmbMoveFromLogic.SelectedItem.ToString(),
                    this.accessableLocators.Rows[this.cmbMovedFrom.SelectedIndex]["M_LOCATOR_ID"].ToString(),
                    "");
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

        private void createGRNRecord()
        { 
            this.dtGRNRecordData =
                this.getDataFromDb.getV_UNMATCHEDRECEIPTSInfo(this.dtSearchAccessableLocators, "OR", "",
                        generalResultInformation.Station, this.stBPaternerID,
                        "", this.stWarehouseID, "", "", true, false, "AND", "", "");


            this.dtGRNRecordData.Columns.Remove("EM_STATION_ID");
            this.dtGRNRecordData.Columns.Remove("AD_ORG_ID");
            this.dtGRNRecordData.Columns.Remove("M_INOUTLINE_ID");
            this.dtGRNRecordData.Columns.Remove("ISACTIVE");
            this.dtGRNRecordData.Columns.Remove("M_LOCATOR_ID");
            this.dtGRNRecordData.Columns.Remove("M_PRODUCT_ID");
            this.dtGRNRecordData.Columns.Remove("C_BPARTNER_ID");
            this.dtGRNRecordData.Columns.Remove("Line");
            this.dtGRNRecordData.Columns.Remove("Product");
            this.dtGRNRecordData.Columns.Remove("Warehouse");
            this.dtGRNRecordData.Columns.Remove("Received");
            this.dtGRNRecordData.Columns.Remove("UOM");
            this.dtGRNRecordData.Columns.Remove("Invoiced");

            this.dtGRNRecordData = 
                this.getDataFromDb.clearRedundantRow(this.dtGRNRecordData, "M_INOUT_ID");

        }

        private void formDataGridHeader()
        {
            this.dtUnmatchedIncomingInventoryDetailData =
                this.getDataFromDb.getV_UNMATCHEDRECEIPTSInfo(null, "", "",
                        generalResultInformation.Station, "0", "", "", "", "",
                        true, false, "AND", "", "");

            this.dtgIncomingInventory.DataSource = 
                this.dtUnmatchedIncomingInventoryDetailData;
            
            this.dtgIncomingInventory.Columns["EM_STATION_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["AD_ORG_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["M_INOUT_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["ISACTIVE"].Visible = false;
            this.dtgIncomingInventory.Columns["M_INOUTLINE_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["M_LOCATOR_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["M_PRODUCT_ID"].Visible = false;

            this.dtUnmatchedIncomingMatchingInvoiceData =
                this.getDataFromDb.getV_UNMATCHEDINVOICEInfo(null, "", "",
                    "0", "", "", "", true, false, "AND", "", "");

            this.dtgInvoice.DataSource = this.dtUnmatchedIncomingMatchingInvoiceData;

            this.dtgInvoice.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgInvoice.Columns["ISACTIVE"].Visible = false;
            this.dtgInvoice.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgInvoice.Columns["C_INVOICELINE_ID"].Visible = false;
            this.dtgInvoice.Columns["M_PRODUCT_ID"].Visible = false;

        }

        private void formMatchingQty()
        {
            if (this.dtgIncomingInventory.SelectedRows.Count != 1 ||
                this.dtgInvoice.SelectedRows.Count != 1)
            {                
                this.matchedQty = 0;
                this.remainingQty = 0;

                this.txtMathcedQty.Text = this.matchedQty.ToString("N2");
                this.txtRemainingQty.Text = this.remainingQty.ToString("N2");

                this.cmdProcessMatching.Enabled = false;
                return;
            }

            this.matchedQty =
                Math.Min(
                decimal.Parse(this.dtUnmatchedIncomingInventoryDetailData.Rows[this.dtgIncomingInventory.SelectedRows[0].Index]["Received"].ToString()), 
                decimal.Parse(this.dtUnmatchedIncomingMatchingInvoiceData.Rows[this.dtgInvoice.SelectedRows[0].Index]["Invoiced"].ToString())
                );

            this.remainingQty =
                decimal.Parse(this.dtUnmatchedIncomingInventoryDetailData.Rows[this.dtgIncomingInventory.SelectedRows[0].Index]["Received"].ToString()) - this.matchedQty;

            this.txtMathcedQty.Text = this.matchedQty.ToString("N2");
            this.txtRemainingQty.Text = this.remainingQty.ToString("N2");

            this.cmdProcessMatching.Enabled = true;
 
        }
        

        private void frmMatchInvoices_Load(object sender, EventArgs e)
        {
            this.cmbMovementDateLogic.SelectedItem = "IGNOR";
            this.cmbMoveFromLogic.SelectedItem = "IGNOR";
            
            this.dtpMoveDateFrom.Value = DateTime.Today;
            this.dtpMoveDateTo.Value = DateTime.Today;

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
                        
            this.accessableLocators = 
                this.getData.getUserAccessableLocators("", triStateBool.ignor, taskType.In);
            this.insetDataIntoComboBox(this.cmbMovedFrom, this.accessableLocators,
                this.accessableLocators.Columns.IndexOf("VALUE"), 0);

            this.dtSearchAccessableLocators.Columns.Add("Field");
            this.dtSearchAccessableLocators.Columns.Add("Criterion");
            this.dtSearchAccessableLocators.Columns.Add("Value");

            for (int rowCounter = 0; rowCounter <= this.accessableLocators.Rows.Count - 1; rowCounter++)
            {
                this.dtSearchAccessableLocators.Rows.Add(new object[]{ "M_LOCATOR_ID", "=", 
                    this.accessableLocators.Rows[rowCounter]["M_LOCATOR_ID"].ToString()}); 
            }

            this.createGRNRecord();
            this.formDataGridHeader();

            this.formMatchingQty();

            //this.ckAllOrAny.Checked = true;
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();            

        }


        private void ddgBpartner_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgBpartner.DataSource =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                        this.ddgBpartner.SelectedItem,
                        triStateBool.yes, triStateBool.ignor,
                        true, false, "AND");

            this.ddgBpartner.DataTablePrimaryKey =
                Convert.ToUInt16(this.ddgBpartner.DataSource.Columns.IndexOf("C_BPARTNER_ID"));
            this.ddgBpartner.SelectedColomnIdex =
                this.ddgBpartner.DataSource.Columns.IndexOf("NAME");

            this.ddgBpartner.HiddenColoumns =
                new int[] { this.ddgBpartner.DataSource.Columns.IndexOf("C_BPARTNER_LOCATION_ID") };
        }

        private void ddgBpartner_selectedItemChanged(object sender, EventArgs e)
        {
            this.dtGRNRecordData.Clear();
            
            if (this.ddgBpartner.SelectedRowKey != null &&
                     this.ddgBpartner.SelectedRow.Rows.Count > 0 &&
                     this.ddgBpartner.SelectedItem != "")
            {
                this.stBPaternerID =
                    this.ddgBpartner.SelectedRowKey.ToString();
            }
            else
            {
                this.stBPaternerID = "";
            }

            this.createGRNRecord();
        }
        

        private void ddgGRN_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgGRN.DataSource = this.dtGRNRecordData.Copy();
            this.ddgGRN.DataTablePrimaryKey =
                Convert.ToUInt16(this.ddgGRN.DataSource.Columns.IndexOf("M_INOUT_ID"));
            ddgGRN.SelectedColomnIdex =
                this.ddgGRN.DataSource.Columns.IndexOf("Document");
        }

        private void ddgGRN_selectedItemChanged(object sender, EventArgs e)
        {            
            if (this.ddgGRN.SelectedRowKey != null &&
                     this.ddgGRN.SelectedRow.Rows.Count > 0 &&
                     this.ddgGRN.SelectedItem != "")
            {
                this.stGRNID =
                    this.ddgGRN.SelectedRowKey.ToString();

                this.cmbMovementDateLogic.SelectedItem = "IGNOR";
                this.cmbMoveFromLogic.SelectedItem = "IGNOR";

                this.cmbMovementDateLogic.Enabled = false;
                this.cmbMoveFromLogic.Enabled = false;
            }
            else
            {
                this.stGRNID = "";
                this.cmbMovementDateLogic.Enabled = true;
                this.cmbMoveFromLogic.Enabled = true;
            }
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
            if (this.cmbMoveFromLogic.SelectedItem.ToString() == "IGNOR")
                this.stWarehouseID = "";
        }

        private void cmbMovedFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.getDataFromDb.checkIfTableContainesData(this.accessableLocators) &&
                this.cmbMoveFromLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.stWarehouseID =
                    this.accessableLocators.Rows[this.cmbMovedFrom.SelectedIndex]["M_LOCATOR_ID"].ToString();
                
                this.createGRNRecord();
            }
        }


        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            this.establishSearchCriterion();
            this.dtUnmatchedIncomingInventoryDetailData =
                this.getDataFromDb.getV_UNMATCHEDRECEIPTSInfo(this.searchQuery, "AND", "",
                        generalResultInformation.Station, "", "", "", "", "",
                        true, false, "AND", "", "");

            this.dtgIncomingInventory.DataSource = this.dtUnmatchedIncomingInventoryDetailData;

            this.dtgIncomingInventory.Columns["EM_STATION_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["M_INOUT_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["ISACTIVE"].Visible = false;
            this.dtgIncomingInventory.Columns["M_INOUTLINE_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["M_LOCATOR_ID"].Visible = false;
            this.dtgIncomingInventory.Columns["M_PRODUCT_ID"].Visible = false;

            this.dtgIncomingInventory.Columns["Received"].DefaultCellStyle.Format = "N2";
            this.dtgIncomingInventory.Columns["Invoiced"].DefaultCellStyle.Format = "N2";

            if (!this.getDataFromDb.checkIfTableContainesData(this.dtUnmatchedIncomingInventoryDetailData))
                return;
            if (this.dtgIncomingInventory.Columns.Count < 1)
                return;

            foreach (DataGridViewColumn columns in this.dtgIncomingInventory.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.Automatic;
                columns.DisplayIndex = columns.Index;
            }

            this.dtUnmatchedIncomingMatchingInvoiceData.Clear();
            this.dtgIncomingInventory.ClearSelection();

            this.formMatchingQty();

        }
        
        private void dtgIncomingInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtUnmatchedIncomingMatchingInvoiceData.Clear();

            int currentSelectedUnmatchedIncomingRow =
                this.dtgIncomingInventory.SelectedRows[0].Index;

            this.dtUnmatchedIncomingMatchingInvoiceData =
                this.getDataFromDb.getV_UNMATCHEDINVOICEInfo(null, "", "",
                    this.dtUnmatchedIncomingInventoryDetailData.Rows[currentSelectedUnmatchedIncomingRow]["C_BPARTNER_ID"].ToString(),
                    "",
                    this.dtUnmatchedIncomingInventoryDetailData.Rows[currentSelectedUnmatchedIncomingRow]["M_PRODUCT_ID"].ToString(),
                    "", true, false, "AND", "", "");

            this.dtgInvoice.DataSource = this.dtUnmatchedIncomingMatchingInvoiceData;

            this.dtgInvoice.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgInvoice.Columns["ISACTIVE"].Visible = false;
            this.dtgInvoice.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgInvoice.Columns["C_INVOICELINE_ID"].Visible = false;
            this.dtgInvoice.Columns["M_PRODUCT_ID"].Visible = false;

            this.dtgInvoice.Columns["Received"].DefaultCellStyle.Format = "N2";
            this.dtgInvoice.Columns["Invoiced"].DefaultCellStyle.Format = "N2";

            this.dtgInvoice.ClearSelection();
            
            this.formMatchingQty();


        }

        private void dtgInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.formMatchingQty();
        }
        

        private void cmdProcessMatching_Click(object sender, EventArgs e)
        {
            int currentSelectedUnmatchedIncomingRow =
                this.dtgIncomingInventory.SelectedRows[0].Index;
            int currentSelectedMatchingInvoiceRow =
                this.dtgInvoice.SelectedRows[0].Index;

            string newMatchInvDoc =
                this.getDataFromDb.getNextSequenceId("Match Invoice", "",
                        generalResultInformation.Station, "", true);

            string newMatchDate = 
                new DateTime(
                        Math.Max(
                                    DateTime.Parse(this.dtUnmatchedIncomingInventoryDetailData.Rows[currentSelectedUnmatchedIncomingRow]["Dated"].ToString()).Ticks,
                                    DateTime.Parse(this.dtUnmatchedIncomingMatchingInvoiceData.Rows[currentSelectedMatchingInvoiceRow]["Dated"].ToString()).Ticks
                                )
                    ).ToString("yyyy-MM-dd HH:mm:ss");

            DataTable dtNewMatchInvoice =
                this.getDataFromDb.getM_MATCHINVInfo(null, "", "", "", "", "", false, true, "");

            dtNewMatchInvoice.Rows.Add(
                new object[] {
                    null,
                    generalResultInformation.Station,
                    generalResultInformation.clientId,
                    this.dtUnmatchedIncomingInventoryDetailData.Rows[currentSelectedUnmatchedIncomingRow]["AD_ORG_ID"].ToString(),
                    "Y",
                    DateTime.Now,
                    generalResultInformation.userId,
                    DateTime.Now,
                    generalResultInformation.userId,
                    this.dtUnmatchedIncomingInventoryDetailData.Rows[currentSelectedUnmatchedIncomingRow]["M_INOUTLINE_ID"].ToString(),
                    this.dtUnmatchedIncomingMatchingInvoiceData.Rows[currentSelectedMatchingInvoiceRow]["C_INVOICELINE_ID"].ToString(),
                    this.dtUnmatchedIncomingInventoryDetailData.Rows[currentSelectedUnmatchedIncomingRow]["M_PRODUCT_ID"].ToString(),
                    newMatchDate,
                    this.matchedQty,
                    "N",
                    "Y",
                    "N",
                    newMatchInvDoc,
                    newMatchDate,
                    "0",
                    ""
                });

            string[] result = 
                this.getDataFromDb.changeDataBaseTableData(dtNewMatchInvoice, "M_MATCHINV", "INSERT");

            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError || result.Length < 1)
            {
                MessageBox.Show("Record IS NOT Saved", "Matching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.cmdDisplay_Click(new object(), new EventArgs());

        }
                
         
    }
}
