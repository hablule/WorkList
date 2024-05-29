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
    public partial class frmSearchDeposit : Form
    {
        public frmSearchDeposit()
        {
            InitializeComponent();
        }


        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();

        DataTable dtCustomerSalesList = new DataTable();
        DataTable dtBankAccountList = new DataTable();
        DataTable dtPaymentList = new DataTable();
        DataTable dtExemptionList = new DataTable();
        
        

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
                this.addMoreCriteria("NAME", this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumber.Text, "");
            }

            if (this.cmbDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("STATEMENTDATE", this.cmbDateLogic.SelectedItem.ToString(),
                    this.dtpDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbBankAccountLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgBankAccount.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_BANKACCOUNT_ID", this.cmbBankAccountLogic.SelectedItem.ToString(),
                    this.ddgBankAccount.SelectedRowKey.ToString(), "");
            }

            if (this.cmbAmountLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("AMOUNT_CASHLINE", this.cmbAmountLogic.SelectedItem.ToString(),
                    this.ntbAmountFrom.Amount, this.ntbAmountTo.Amount);
            }

            if (this.cmbInvoiceLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgInvoice.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_INVOICE_ID", this.cmbInvoiceLogic.SelectedItem.ToString(),
                    this.ddgInvoice.SelectedRowKey.ToString(), "");

                this.addMoreCriteria("SOURCETYPE", "Equals to",
                    this.ckIsRefund.Checked ? CashSourceType.Refund.ToString() : 
                        CashSourceType.Sales.ToString(), "");
            }


            if (this.cmbPaymentLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgPayment.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_PAYMENT_ID", this.cmbPaymentLogic.SelectedItem.ToString(),
                    this.ddgPayment.SelectedRowKey.ToString(), "");
            }


            if (this.cmbExemptionLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgExemption.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_EXEMPTION_ID", this.cmbExemptionLogic.SelectedItem.ToString(),
                    this.ddgExemption.SelectedRowKey.ToString(), "");
            }

            if (this.cmbTenderLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TENDERTYPE", this.cmbTenderLogic.SelectedItem.ToString(),
                    this.cmbTenderType.SelectedItem.ToString(), "");

                if (this.txtInstrumentNo.Text != "")
                {
                    this.addMoreCriteria("CHECKNO", this.cmbTenderLogic.SelectedItem.ToString(),
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
        


        private void frmSearchDeposit_Load(object sender, EventArgs e)
        {
            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDateLogic.SelectedItem = "IGNOR";
            this.cmbBankAccountLogic.SelectedItem = "IGNOR";
            this.cmbAmountLogic.SelectedItem = "IGNOR";
            this.cmbInvoiceLogic.SelectedItem = "IGNOR";
            this.cmbPaymentLogic.SelectedItem = "IGNOR";
            this.cmbExemptionLogic.SelectedItem = "IGNOR";
            this.cmbTenderLogic.SelectedItem = "IGNOR";


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

        private void cmbBankAccountLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbBankAccountLogic.SelectedItem.ToString(),
                this.ddgBankAccount);
        }

        private void cmbAmountLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbAmountLogic.SelectedItem.ToString(),
                this.ntbAmountFrom);

            if (this.cmbAmountLogic.SelectedItem.ToString() == "In between of")
            {
                this.ntbAmountTo.Visible = true;
                this.ckAllOrAny.Checked = false;
                this.ckAllOrAny.Enabled = false;
            }
            else
            {
                this.ntbAmountTo.Visible = false;
                this.ckAllOrAny.Enabled = true;
            }
        }

        private void cmbInvoiceLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbInvoiceLogic.SelectedItem.ToString(),
                this.ddgInvoice);
            this.ckIsRefund.Enabled = this.ddgInvoice.Enabled;
        }


        private void cmbPaymentLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPaymentLogic.SelectedItem.ToString(),
                this.ddgPayment);
        }


        private void cmbExemptionLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbExemptionLogic.SelectedItem.ToString(),
                this.ddgExemption);
        }

        private void cmbTenderLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTenderLogic.SelectedItem.ToString(),
                this.cmbTenderType);
            this.cmbTenderType.SelectedIndex = 0;
            this.txtInstrumentNo.Text = "";
        }
        
        private void cmbTenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTenderType.SelectedItem.ToString() == "Cash")
                this.txtInstrumentNo.Visible = false;
            else
                this.txtInstrumentNo.Visible = true;
        }



        private void ddgBankAccount_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtBankAccountList =
                this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "",
                    this.ddgBankAccount.SelectedItem, false, false, "AND");
                        
            this.ddgBankAccount.DataSource = this.dtBankAccountList;
            this.ddgBankAccount.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtBankAccountList.Columns.IndexOf("C_BANKACCOUNT_ID"));
            this.ddgBankAccount.SelectedColomnIdex =
                this.dtBankAccountList.Columns.IndexOf("ACCOUNTNO");
        }

        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            if (!this.ckIsRefund.Checked)
            {
                this.dtCustomerSalesList =
                    this.getDataFromDb.getSalesInfo(null, "", "", generalResultInformation.Station,
                        this.ddgInvoice.SelectedItem, generalResultInformation.concernedNode, "",
                        triaStateBool.Ignor, false, false, false, "AND");
                this.dtCustomerSalesList.Columns.Remove("flag");
            }
            else
                this.dtCustomerSalesList =
                    this.getDataFromDb.getRefundsInfo(null, "", "", generalResultInformation.Station,
                        this.ddgInvoice.SelectedItem, generalResultInformation.concernedNode, "",
                        false, false, "AND");            
            
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
            if(!this.ckIsRefund.Checked)
                this.dtCustomerSalesList.Columns["salesDateTime"].SetOrdinal(1);
            else
                this.dtCustomerSalesList.Columns["refundDateTime"].SetOrdinal(1);

            this.dtCustomerSalesList.Columns["fs_no"].SetOrdinal(2);
            this.dtCustomerSalesList.Columns["sub_total"].SetOrdinal(3);
            this.dtCustomerSalesList.Columns["total_tax"].SetOrdinal(4);
            this.dtCustomerSalesList.Columns["total_amount"].SetOrdinal(5);
            this.dtCustomerSalesList.Columns["with_holding"].SetOrdinal(6);
            this.dtCustomerSalesList.Columns["items_sold"].SetOrdinal(7);

            if (!this.ckIsRefund.Checked)
                this.dtCustomerSalesList.Columns["salesDateTime"].ColumnName = "Date Refunded";
            else
                this.dtCustomerSalesList.Columns["refundDateTime"].ColumnName = "Date Sold";

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


        private void ddgPayment_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtPaymentList =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "",
                    this.ddgPayment.SelectedItem,
                    "", DateTime.Now, false, tenderType.ignor, "", "", false, false, "AND");

            this.dtPaymentList.Columns.Add("Customer").DataType = 
                System.Type.GetType("System.String");
            this.dtPaymentList.Columns.Add("Organization").DataType = 
                System.Type.GetType("System.String");

            DataTable custInfo;
            DataTable orgInfo;

            for (int rowCounter = 0; rowCounter <= this.dtPaymentList.Rows.Count - 1; rowCounter++)
            {
                custInfo = this.getDataFromDb.getCustomersInfo(null, "",
                        this.dtPaymentList.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                            this.dtPaymentList.Rows[rowCounter]["STATION_ID"].ToString(), 
                                "", "", triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(custInfo))
                {
                    this.dtPaymentList.Rows[rowCounter]["Customer"] =
                        custInfo.Rows[0]["customer_name"].ToString();

                }
                else
                {
                    this.dtPaymentList.Rows[rowCounter]["Customer"] = "";
                }


                orgInfo = this.getDataFromDb.getnodesInfo(null, "", "", "",
                    this.dtPaymentList.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                       triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(orgInfo))
                {
                    this.dtPaymentList.Rows[rowCounter]["Organization"] =
                        orgInfo.Rows[0]["node"].ToString();
                }
                else
                {
                    this.dtPaymentList.Rows[rowCounter]["Organization"] = "";
                }
            }

            this.dtPaymentList.Columns.Remove("CREATED");
            this.dtPaymentList.Columns.Remove("CREATEDBY");
            this.dtPaymentList.Columns.Remove("UPDATED");
            this.dtPaymentList.Columns.Remove("UPDATEDBY");
            this.dtPaymentList.Columns.Remove("ISACTIVE");
            this.dtPaymentList.Columns.Remove("DESCRIPTION");
            this.dtPaymentList.Columns.Remove("PROCESSED");
            this.dtPaymentList.Columns.Remove("STATION_ID");
            this.dtPaymentList.Columns.Remove("AD_ORG_ID");
            this.dtPaymentList.Columns.Remove("C_BPARTNER_ID");

            this.dtPaymentList.Columns["Organization"].SetOrdinal(0);
            this.dtPaymentList.Columns["DOCUMENTNO"].SetOrdinal(1);
            this.dtPaymentList.Columns["DATETRX"].SetOrdinal(2);
            this.dtPaymentList.Columns["PAYAMT"].SetOrdinal(3);
            this.dtPaymentList.Columns["Customer"].SetOrdinal(4);
            this.dtPaymentList.Columns["TENDERTYPE"].SetOrdinal(5);
            this.dtPaymentList.Columns["CHECKNO"].SetOrdinal(6);

                        
            this.dtPaymentList.Columns["DOCUMENTNO"].ColumnName = "Document";
            this.dtPaymentList.Columns["DATETRX"].ColumnName = "Date";
            this.dtPaymentList.Columns["PAYAMT"].ColumnName = "Amount";            
            this.dtPaymentList.Columns["TENDERTYPE"].ColumnName = "Tender";
            this.dtPaymentList.Columns["CHECKNO"].ColumnName = "Check/CPO";
            


            this.ddgPayment.DataSource =
                this.dtPaymentList;

            this.ddgPayment.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtPaymentList.Columns.IndexOf("C_PAYMENT_ID"));
            this.ddgPayment.SelectedColomnIdex =
                this.dtPaymentList.Columns.IndexOf("Document");
        }

        private void ddgExemption_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtExemptionList =
                this.getDataFromDb.getC_EXEMPTIONInfo(null, "", "",
                    this.ddgExemption.SelectedItem,
                    "", DateTime.Now, false, exemptionType.ignor, "", false, false, "AND");

            this.dtExemptionList.Columns.Add("Customer").DataType =
                System.Type.GetType("System.String");
            this.dtExemptionList.Columns.Add("Organization").DataType =
                System.Type.GetType("System.String");

            DataTable custInfo;
            DataTable orgInfo;

            for (int rowCounter = 0; rowCounter <= this.dtExemptionList.Rows.Count - 1; rowCounter++)
            {
                custInfo = this.getDataFromDb.getCustomersInfo(null, "",
                        this.dtExemptionList.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                            this.dtExemptionList.Rows[rowCounter]["STATION_ID"].ToString(),
                                "", "", triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(custInfo))
                {
                    this.dtExemptionList.Rows[rowCounter]["Customer"] =
                        custInfo.Rows[0]["customer_name"].ToString();

                }
                else
                {
                    this.dtExemptionList.Rows[rowCounter]["Customer"] = "";
                }


                orgInfo = this.getDataFromDb.getnodesInfo(null, "", "", "",
                    this.dtExemptionList.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                       triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(orgInfo))
                {
                    this.dtExemptionList.Rows[rowCounter]["Organization"] =
                        orgInfo.Rows[0]["node"].ToString();
                }
                else
                {
                    this.dtExemptionList.Rows[rowCounter]["Organization"] = "";
                }
            }

            this.dtExemptionList.Columns.Remove("CREATED");
            this.dtExemptionList.Columns.Remove("CREATEDBY");
            this.dtExemptionList.Columns.Remove("UPDATED");
            this.dtExemptionList.Columns.Remove("UPDATEDBY");
            this.dtExemptionList.Columns.Remove("ISACTIVE");
            this.dtExemptionList.Columns.Remove("DESCRIPTION");
            this.dtExemptionList.Columns.Remove("PROCESSED");
            this.dtExemptionList.Columns.Remove("STATION_ID");
            this.dtExemptionList.Columns.Remove("AD_ORG_ID");
            this.dtExemptionList.Columns.Remove("C_BPARTNER_ID");

            
            this.dtExemptionList.Columns["DOCUMENTNO"].SetOrdinal(1);
            this.dtExemptionList.Columns["DATEINVOICED"].SetOrdinal(2);
            this.dtExemptionList.Columns["EXEMPTEDAMT"].SetOrdinal(3);            
            this.dtExemptionList.Columns["EXEMPTIONTYPE"].SetOrdinal(5);
            this.dtExemptionList.Columns["BASEAMOUNT"].SetOrdinal(6);


            
            this.dtExemptionList.Columns["DOCUMENTNO"].ColumnName = "Document";
            this.dtExemptionList.Columns["DATEINVOICED"].ColumnName = "Date";
            this.dtExemptionList.Columns["EXEMPTEDAMT"].ColumnName = "Amount";            
            this.dtExemptionList.Columns["EXEMPTIONTYPE"].ColumnName = "Tender";
            this.dtExemptionList.Columns["BASEAMOUNT"].ColumnName = "Base Amt";



            this.ddgExemption.DataSource =
                this.dtExemptionList;

            this.ddgExemption.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExemptionList.Columns.IndexOf("C_EXEMPTION_ID"));
            this.ddgExemption.SelectedColomnIdex =
                this.dtExemptionList.Columns.IndexOf("Document");
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
                this.getDataFromDb.getV_DEPOSITDTLInfo(
                    this.searchQuery, this.logicalConnector, "", "", "",
                     DateTime.Now, false, "", "", "", CashSourceType.ignor, "", "",
                     "", "", false, "AND");

            currentSearchCriteriaResult = 
                this.getDataFromDb.clearRedundantRow(currentSearchCriteriaResult, "C_CASH_ID");


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
                            currentSearchCriteriaResult, "C_CASHLINESOURCE_ID", true);
            }
            else if (considerPreviousCriteria == DialogResult.No)
            {
                previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "C_CASHLINESOURCE_ID", false);
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
