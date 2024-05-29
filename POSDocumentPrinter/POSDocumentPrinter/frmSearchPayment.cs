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
    public partial class frmSearchPayment : Form
    {
        public frmSearchPayment()
        {
            InitializeComponent();
        }

        dataBuilder getDataFromDb = new dataBuilder();
        
        DataTable searchQuery = new DataTable();

        DataTable dtCustomerList = new DataTable();
        DataTable dtOtherIncomeList = new DataTable();
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
                this.addMoreCriteria("DOCUMENTNO", this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumber.Text, "");
            }

            if (this.cmbDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DATETRX", this.cmbDateLogic.SelectedItem.ToString(),
                    this.dtpDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbCustomerLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgCustomers.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_BPARTNER_ID", this.cmbCustomerLogic.SelectedItem.ToString(),
                    this.ddgCustomers.SelectedRowKey.ToString(), "");
            }


            if (this.cmbOtherIncomeLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgOtherIncome.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_CHARGE_ID", this.cmbOtherIncomeLogic.SelectedItem.ToString(),
                    this.ddgOtherIncome.SelectedRowKey.ToString(), "");
            }

            if (this.cmbReceiptAmtLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("PAYAMT", this.cmbReceiptAmtLogic.SelectedItem.ToString(),
                    this.ntbTotalAmountFrom.Amount, this.ntbTotalAmountTo.Amount);
            }

            if (this.cmbInvoiceLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgInvoice.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_INVOICE_ID", this.cmbInvoiceLogic.SelectedItem.ToString(),
                    this.ddgInvoice.SelectedRowKey.ToString(), "");
            }

            if (this.cmbPaidByLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TENDERTYPE", this.cmbPaidByLogic.SelectedItem.ToString(),
                    this.cmbTenderType.SelectedItem.ToString(), "");

                if (this.txtInstrumentNo.Text != "")
                {
                    this.addMoreCriteria("CHECKNO", this.cmbPaidByLogic.SelectedItem.ToString(),
                        this.txtInstrumentNo.Text, "");
                }
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


        private void frmSearchPayment_Load(object sender, EventArgs e)
        {
            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDateLogic.SelectedItem = "IGNOR";
            this.cmbCustomerLogic.SelectedItem = "IGNOR";
            this.cmbOtherIncomeLogic.SelectedItem = "IGNOR";
            this.cmbReceiptAmtLogic.SelectedItem = "IGNOR";
            this.cmbInvoiceLogic.SelectedItem = "IGNOR";
            this.cmbPaidByLogic.SelectedItem = "IGNOR";
            

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
                       
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();
        }


        private void cmbTenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTenderType.SelectedItem.ToString() == "Cash")
                this.txtInstrumentNo.Visible = false;
            else
                this.txtInstrumentNo.Visible = true;
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

        private void cmbOtherIncomeLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbOtherIncomeLogic.SelectedItem.ToString(),
                this.ddgOtherIncome);
        }

        private void cmbReceiptAmtLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbReceiptAmtLogic.SelectedItem.ToString(),
                this.ntbTotalAmountFrom);

            if (this.cmbReceiptAmtLogic.SelectedItem.ToString() == "In between of")
                this.ntbTotalAmountTo.Visible = true;
            else
                this.ntbTotalAmountTo.Visible = false;
        }

        private void cmbInvoiceLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbInvoiceLogic.SelectedItem.ToString(),
                this.ddgInvoice);
        }

        private void cmbPaidByLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPaidByLogic.SelectedItem.ToString(),
                this.cmbTenderType);
            this.cmbTenderType.SelectedIndex = 0;
            this.txtInstrumentNo.Text = "";               
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

        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtCustomerSalesList =
                this.getDataFromDb.getSalesInfo(null, "", "", generalResultInformation.Station,
                    this.ddgInvoice.SelectedItem, generalResultInformation.concernedNode, "",
                    triaStateBool.Ignor, false, false, false, "AND");

            this.dtCustomerSalesList.Columns.Remove("flag");
            this.dtCustomerSalesList.Columns.Remove("date");
            this.dtCustomerSalesList.Columns.Remove("time");
            this.dtCustomerSalesList.Columns.Remove("customer_id");
            this.dtCustomerSalesList.Columns.Remove("customer_name");
            this.dtCustomerSalesList.Columns.Remove("customer_tin");
            this.dtCustomerSalesList.Columns.Remove("discount");
            this.dtCustomerSalesList.Columns.Remove("discount_percent");
            this.dtCustomerSalesList.Columns.Remove("add_on");
            this.dtCustomerSalesList.Columns.Remove("add_on_percent");
            this.dtCustomerSalesList.Columns.Remove("disc_or_add");
            this.dtCustomerSalesList.Columns.Remove("comm_witholding");
            this.dtCustomerSalesList.Columns.Remove("payment_type_id");
            this.dtCustomerSalesList.Columns.Remove("amount_recieved");
            this.dtCustomerSalesList.Columns.Remove("void_count");
            this.dtCustomerSalesList.Columns.Remove("cashier_id");
            this.dtCustomerSalesList.Columns.Remove("cashier_name");
            this.dtCustomerSalesList.Columns.Remove("sales_rep_id");
            this.dtCustomerSalesList.Columns.Remove("bill_no");
            this.dtCustomerSalesList.Columns.Remove("table_no");
            this.dtCustomerSalesList.Columns.Remove("is_paid");
            this.dtCustomerSalesList.Columns.Remove("cheque_number");
            this.dtCustomerSalesList.Columns.Remove("cheque_date");
            this.dtCustomerSalesList.Columns.Remove("cash_ref_no");
            this.dtCustomerSalesList.Columns.Remove("credit_ref_no");
            this.dtCustomerSalesList.Columns.Remove("reference");
            this.dtCustomerSalesList.Columns.Remove("voucher_type");
            this.dtCustomerSalesList.Columns.Remove("ref_note");
            this.dtCustomerSalesList.Columns.Remove("cash_credit");
            this.dtCustomerSalesList.Columns.Remove("is_refunded");
            this.dtCustomerSalesList.Columns.Remove("transfer_id");
            this.dtCustomerSalesList.Columns.Remove("comment");
            this.dtCustomerSalesList.Columns.Remove("is_canceled");
            this.dtCustomerSalesList.Columns.Remove("station");
            this.dtCustomerSalesList.Columns.Remove("node");
            this.dtCustomerSalesList.Columns.Remove("sold_date");

            this.dtCustomerSalesList.Columns["ref_no"].SetOrdinal(0);
            this.dtCustomerSalesList.Columns["salesDateTime"].SetOrdinal(1);
            this.dtCustomerSalesList.Columns["fs_no"].SetOrdinal(2);
            this.dtCustomerSalesList.Columns["sub_total"].SetOrdinal(3);
            this.dtCustomerSalesList.Columns["total_tax"].SetOrdinal(4);
            this.dtCustomerSalesList.Columns["total_amount"].SetOrdinal(5);
            this.dtCustomerSalesList.Columns["with_holding"].SetOrdinal(6);
            this.dtCustomerSalesList.Columns["items_sold"].SetOrdinal(7);

            this.dtCustomerSalesList.Columns["salesDateTime"].ColumnName = "Date Sold";
            this.dtCustomerSalesList.Columns["sub_total"].ColumnName = "Sub Total";
            this.dtCustomerSalesList.Columns["total_tax"].ColumnName = "VAT";
            this.dtCustomerSalesList.Columns["total_amount"].ColumnName = "Grand Total";
            this.dtCustomerSalesList.Columns["with_holding"].ColumnName = "Withholding";
            this.dtCustomerSalesList.Columns["ref_no"].ColumnName = "Reference";
            this.dtCustomerSalesList.Columns["items_sold"].ColumnName = "Item Count";
            this.dtCustomerSalesList.Columns["fs_no"].ColumnName = "FS Number";


            this.ddgInvoice.DataSource =
                this.dtCustomerSalesList;

            this.ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtCustomerSalesList.Columns.IndexOf("id"));
            this.ddgInvoice.SelectedColomnIdex =
                this.dtCustomerSalesList.Columns.IndexOf("Reference");
        }
        
        private void ddgOtherIncome_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtOtherIncomeList =
                this.getDataFromDb.getC_CHARGEInfo(null, "", "",
                                this.ddgOtherIncome.SelectedItem,
                                generalResultInformation.centralStation, true, false, "AND");

            this.dtOtherIncomeList.Columns.Remove("AD_CLIENT_ID");
            this.dtOtherIncomeList.Columns.Remove("AD_ORG_ID");
            this.dtOtherIncomeList.Columns.Remove("ISACTIVE");
            this.dtOtherIncomeList.Columns.Remove("CREATED");
            this.dtOtherIncomeList.Columns.Remove("CREATEDBY");
            this.dtOtherIncomeList.Columns.Remove("UPDATED");
            this.dtOtherIncomeList.Columns.Remove("UPDATEDBY");
            this.dtOtherIncomeList.Columns.Remove("DESCRIPTION");
            this.dtOtherIncomeList.Columns.Remove("CHARGEAMT");
            this.dtOtherIncomeList.Columns.Remove("ISSAMETAX");
            this.dtOtherIncomeList.Columns.Remove("ISSAMECURRENCY");
            this.dtOtherIncomeList.Columns.Remove("C_TAXCATEGORY_ID");
            this.dtOtherIncomeList.Columns.Remove("ISTAXINCLUDED");
            this.dtOtherIncomeList.Columns.Remove("C_BPARTNER_ID");
            this.dtOtherIncomeList.Columns.Remove("ISCOST");
            this.dtOtherIncomeList.Columns.Remove("C_TAX_ID");
            this.dtOtherIncomeList.Columns.Remove("STATION_ID");

            this.ddgOtherIncome.DataSource = this.dtOtherIncomeList;
            this.ddgOtherIncome.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtOtherIncomeList.Columns.IndexOf("C_CHARGE_ID"));
            this.ddgOtherIncome.SelectedColomnIdex =
                this.dtOtherIncomeList.Columns.IndexOf("NAME");
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
                MessageBox.Show("Should New Search Result Consider Previous Criterion", "Look Up",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;

            this.Enabled = false;

            DataTable previousSearchResult = new DataTable();
            DataTable currentSearchCriteriaResult = new DataTable();

            this.establishSearchCriterion();
            currentSearchCriteriaResult =
                this.getDataFromDb.getV_PAYMENTDTLInfo
                    (this.searchQuery, this.logicalConnector, "", "", "",
                     DateTime.Now, false, tenderType.ignor, "", "", 
                     false, "AND");

            currentSearchCriteriaResult =
                this.getDataFromDb.clearRedundantRow(currentSearchCriteriaResult, "C_PAYMENT_ID");
            

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
                            currentSearchCriteriaResult, "C_PAYMENT_ID", true);
            }
            else if (considerPreviousCriteria == DialogResult.No)
            {
                previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "C_PAYMENT_ID", false);                
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
