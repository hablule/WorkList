using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSDocumentPrinter
{
    public partial class frmSearchOpenInvoice : Form
    {
        public frmSearchOpenInvoice()
        {
            InitializeComponent();
        }

        dataBuilder getDataFromDb = new dataBuilder();
        
        DataTable searchQuery = new DataTable();

        DataTable dtCustomerList = new DataTable();
        DataTable dtCustomerSalesList = new DataTable();

        string logicalConnector = "AND";

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
            
            if (this.cmbDocumentNumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("ref_no", this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumber.Text, "");
            }

            if (this.cmbDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("sold_date", this.cmbDateLogic.SelectedItem.ToString(),
                    this.dtpDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbCustomerLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgCustomers.SelectedRowKey != null)
            {
                this.addMoreCriteria("customer_id", this.cmbCustomerLogic.SelectedItem.ToString(),
                    this.ddgCustomers.SelectedRowKey.ToString(), "");
            }

            if (this.cmbSalesAmtLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("total_amount", this.cmbSalesAmtLogic.SelectedItem.ToString(),
                    this.ntbSalesAmountFrom.Amount, this.ntbSalesAmountTo.Amount);
            }

            if (this.cmbOpenAmtLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DUE", this.cmbOpenAmtLogic.SelectedItem.ToString(),
                    this.ntbOpenAmountFrom.Amount, this.ntbOpenAmountTo.Amount);
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


        private void frmSearchOpenInvoice_Load(object sender, EventArgs e)
        {
            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDateLogic.SelectedItem = "IGNOR";
            this.cmbCustomerLogic.SelectedItem = "IGNOR";
            this.cmbSalesAmtLogic.SelectedItem = "IGNOR";
            this.cmbOpenAmtLogic.SelectedItem = "IGNOR";
            

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
                       
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();
        }


        private void cmbDocumentNumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                this.txtDocumentNumber);
        }

        private void cmbDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDateLogic.SelectedItem.ToString(),
                this.dtpDateFrom);

            if (this.cmbDateLogic.SelectedItem.ToString() == "In between of")
            {
                this.dtpDateTo.Visible = true;
                this.ckAllOrAny.Checked = false;
                this.ckAllOrAny.Enabled = false;
            }
            else
            {               
                this.dtpDateTo.Visible = false;
                this.ckAllOrAny.Enabled = true;
            }
        }

        private void cmbCustomerLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbCustomerLogic.SelectedItem.ToString(),
                this.ddgCustomers);
        }

        private void cmbSalesAmtLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSalesAmtLogic.SelectedItem.ToString(),
                this.ntbSalesAmountFrom);

            if (this.cmbSalesAmtLogic.SelectedItem.ToString() == "In between of")
            {
                this.ntbSalesAmountTo.Visible = true;
                this.ckAllOrAny.Checked = false;
                this.ckAllOrAny.Enabled = false;            
            }
            else
            {
                this.ntbSalesAmountTo.Visible = false;
                this.ckAllOrAny.Enabled = true;
            }
        }

        private void cmbOpenAmtLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbOpenAmtLogic.SelectedItem.ToString(),
                this.ntbOpenAmountFrom);

            if (this.cmbOpenAmtLogic.SelectedItem.ToString() == "In between of")
            {
                this.ntbOpenAmountTo.Visible = true;
                this.ckAllOrAny.Checked = false;
                this.ckAllOrAny.Enabled = false;
            }
            else
            {
                this.ntbOpenAmountTo.Visible = false;
                this.ckAllOrAny.Enabled = true;
            }
        }



        private void ddgCustomers_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtCustomerList = 
                this.getDataFromDb.getCustomersInfo(null, "", "",
                    generalResultInformation.Station, generalResultInformation.concernedNode,
                    this.ddgCustomers.SelectedItem, triaStateBool.yes, false, "AND");

            this.dtCustomerList.Columns.Remove("email");
            this.dtCustomerList.Columns.Remove("country");
            this.dtCustomerList.Columns.Remove("city");
            this.dtCustomerList.Columns.Remove("sub_city");
            this.dtCustomerList.Columns.Remove("kebele");
            this.dtCustomerList.Columns.Remove("house_number");
            this.dtCustomerList.Columns.Remove("is_regular");
            this.dtCustomerList.Columns.Remove("insert_user_id");
            this.dtCustomerList.Columns.Remove("update_user_id");
            this.dtCustomerList.Columns.Remove("insert_date");
            this.dtCustomerList.Columns.Remove("update_date");
            this.dtCustomerList.Columns.Remove("is_active");
            this.dtCustomerList.Columns.Remove("station");
            this.dtCustomerList.Columns.Remove("node");
            this.dtCustomerList.Columns.Remove("customerID");
            this.dtCustomerList.Columns.Remove("customer_category");
            this.dtCustomerList.Columns.Remove("account_no");
            this.dtCustomerList.Columns.Remove("customer_group");
            this.dtCustomerList.Columns.Remove("customer_department");
            this.dtCustomerList.Columns.Remove("comment");

            this.ddgCustomers.DataSource = this.dtCustomerList;
            this.ddgCustomers.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtCustomerList.Columns.IndexOf("id"));
            this.ddgCustomers.SelectedColomnIdex =
                this.dtCustomerList.Columns.IndexOf("customer_name");
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
                "Look Up",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;

            this.Enabled = false;

            DataTable previousSearchResult = new DataTable();
            DataTable currentSearchCriteriaResult = new DataTable();

            this.establishSearchCriterion();
            currentSearchCriteriaResult =
                this.getDataFromDb.getV_INVOICEDUEAMOUNTInfo(
                            this.searchQuery, this.logicalConnector, "", 
                            generalResultInformation.Station, "",
                            generalResultInformation.concernedNode,"",
                            triaStateBool.Ignor,
                            0, triaStateBool.yes, "AND");

            currentSearchCriteriaResult =
                this.getDataFromDb.clearRedundantRow(currentSearchCriteriaResult, "ID");
            

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

                if (previousSearchResult.Columns.Count <= 0)
                {
                    previousSearchResult = currentSearchCriteriaResult.Copy();
                }
                else
                    previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "ID", true);
            }
            else if (considerPreviousCriteria == DialogResult.No)
            {
                previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "ID", false);                
            }
            generalResultInformation.searchResult = 
                previousSearchResult.Copy();
            this.Enabled = true;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;            
            generalResultInformation.searchCritrion = this.searchQuery;
            generalResultInformation.logicConnector = this.logicalConnector;
            
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

        

        

    }
}
