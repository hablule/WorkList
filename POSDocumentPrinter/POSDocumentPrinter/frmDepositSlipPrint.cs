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
    public partial class frmDepositSlipPrint : Form
    {
        public frmDepositSlipPrint()
        {
            InitializeComponent();
        }

        DataTable dtBankAccountList = new DataTable();
        DataTable previousSearchResult = new DataTable();
        
        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();

        
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

        private void establishSearchCriterion()
        {
            this.searchQuery.Rows.Clear();

            if (this.cmbDocumentNumberLogic.SelectedItem.ToString() != "IGNOR" &&
                this.cmbDepositDateLogic.SelectedItem.ToString() != "IGNOR" &&
                this.cmbDepositDateLogic.SelectedItem.ToString() != "IGNOR")
                return;

            if (this.cmbDocumentNumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("NAME", this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumber.Text, "");
            }

            if (this.cmbDepositDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("STATEMENTDATE", this.cmbDepositDateLogic.SelectedItem.ToString(),
                    this.dtpDepositDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpDepositDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbBankAccountLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgBankAccount.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_BANKACCOUNT_ID", this.cmbBankAccountLogic.SelectedItem.ToString(),
                    this.ddgBankAccount.SelectedRowKey.ToString(), "");
            }

            if (this.cmbSourceDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("SOURCEDATE", this.cmbSourceDateLogic.SelectedItem.ToString(),
                    this.dtpSourceDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpSourceDateTo.Value.ToString("yyyy-MM-dd"));
            }

        }


        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }


        private void cmbDocumentNumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                this.txtDocumentNumber);
        }

        private void cmbDepositDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDepositDateLogic.SelectedItem.ToString(),
                this.dtpDepositDateFrom);

            if (this.cmbDepositDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpDepositDateTo.Visible = true;
            else
                this.dtpDepositDateTo.Visible = false;
        }

        private void cmbBankAccountLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbBankAccountLogic.SelectedItem.ToString(),
                this.ddgBankAccount);
        }

        private void cmbSourceDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSourceDateLogic.SelectedItem.ToString(),
                this.dtpSourceDateFrom);

            if (this.cmbSourceDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpSourceDateTo.Visible = true;
            else
                this.dtpSourceDateTo.Visible = false;
        }


        private void cmbSourceTypeLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSourceTypeLogic.SelectedItem.ToString(),
                this.cbcbcmbSourceType);            
        }
        


        private void frmDepositSlipPrint_Load(object sender, EventArgs e)
        {
            generalResultInformation.searchResult.Clear();

            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDepositDateLogic.SelectedItem = "IGNOR";
            this.cmbBankAccountLogic.SelectedItem = "IGNOR";
            this.cmbSourceDateLogic.SelectedItem = "IGNOR";
            this.cmbSourceTypeLogic.SelectedItem = "IGNOR";

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

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


        private void cmdPrintDepositSlip_Click(object sender, EventArgs e)
        {
            string dateRange = "*";

            if (this.cmbDepositDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.dtpDepositDateFrom.Value.ToString("dd-MMM-yyyy");

                dateRange = this.dtpDepositDateTo.Visible ?
                    dateRange + " upTo " + this.dtpDepositDateTo.Value.ToString("dd-MMM-yyyy") :
                    generateEquivalentSymbol(this.cmbDepositDateLogic.SelectedItem.ToString()) + " " + dateRange;

            }

            DataTable dtCashDepositDtl =
                generalResultInformation.searchResult.Copy();

            if (!this.getDataFromDb.checkIfTableContainesData(dtCashDepositDtl))
            {
                MessageBox.Show("No Record Found For Search Query",
                    "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtCashDepositDtl =
                this.getDataFromDb.clearRedundantRow(generalResultInformation.searchResult.Copy(), "",
                            new string[] { "C_CASH_ID", "C_CASHLINE_ID", "C_CASHLINESOURCE_ID" });
            
            if (!this.getDataFromDb.checkIfTableContainesData(dtCashDepositDtl))
                return;

            dtCashDepositDtl = dtCashDepositDtl.AsEnumerable().
                    OrderBy(r=> r.Field<int>("C_BANKACCOUNT_ID")).
                    ThenBy(r=> r.Field<DateTime>("STATEMENTDATE")).
                    ThenBy(r => r.Field<string>("TENDERTYPE")).                    
                    CopyToDataTable();
                        
            if (this.cmbSourceTypeLogic.SelectedItem.ToString() != "IGNOR")
            {
                List<string> CASH_ID_DEL = new List<string>();
                for (int ckListItemsCount = 0; ckListItemsCount <= this.cbcbcmbSourceType.Items.Count - 1; ckListItemsCount++)
                {
                    CASH_ID_DEL.Clear();
                    
                    if (!this.cbcbcmbSourceType.CheckBoxItems[ckListItemsCount].Checked)
                    {
                        for (int rowCounter = dtCashDepositDtl.Rows.Count - 1; rowCounter >= 0; rowCounter-- )
                        {
                            if(CASH_ID_DEL.Contains(dtCashDepositDtl.Rows[rowCounter]["C_CASH_ID"].ToString()))
                            {
                                dtCashDepositDtl.Rows.RemoveAt(rowCounter);
                            }
                            else if (dtCashDepositDtl.Rows[rowCounter]["SOURCETYPE"].ToString() ==
                                this.cbcbcmbSourceType.CheckBoxItems[ckListItemsCount].Text)
                            {
                                CASH_ID_DEL.Add(dtCashDepositDtl.Rows[rowCounter]["C_CASH_ID"].ToString());
                                dtCashDepositDtl.Rows.RemoveAt(rowCounter);
                            }
                        }
                    }
                }
            }

            DataTable dtCashDeposit =
                this.getDataFromDb.clearRedundantRow(dtCashDepositDtl.Copy(), "C_CASH_ID");

            DataTable dtDepositDtl =
                this.getDataFromDb.clearRedundantRow(dtCashDepositDtl.Copy(), "C_CASHLINE_ID");

            DataTable dtDepositDtlScr =
               this.getDataFromDb.clearRedundantRow(dtCashDepositDtl.Copy(),"", new string[] { "C_CASHLINE_ID", "SOURCETYPE" });

            for (int rowCounter = dtDepositDtlScr.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                for (int rowCounter2 = rowCounter - 1; rowCounter2 >= 0; rowCounter2--)
                {
                    if (dtDepositDtlScr.Rows[rowCounter]["C_CASHLINE_ID"].ToString() ==
                        dtDepositDtlScr.Rows[rowCounter2]["C_CASHLINE_ID"].ToString())
                    {
                        dtDepositDtlScr.Rows[rowCounter2]["SOURCETYPE"] =
                            dtDepositDtlScr.Rows[rowCounter2]["SOURCETYPE"].ToString() + "/" +
                            dtDepositDtlScr.Rows[rowCounter]["SOURCETYPE"].ToString();

                        dtDepositDtlScr.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
            }
                        

            generalResultInformation.dtsDocumentPrintView.Tables["dtCashDeposit"].Clear();
            generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDetail"].Clear();
            generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDtlSrc"].Clear();

            string colName = "";

            DataTable dtGeneralInfo;
            DataRow drdtCashDeposit;


            foreach (DataRow dr in dtCashDeposit.Rows)
            {
                drdtCashDeposit =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDeposit"].NewRow();
                foreach (DataColumn dc in 
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDeposit"].Columns)
                {
                    colName = dc.ColumnName;
                    if (dtCashDepositDtl.Columns.Contains(colName))
                        drdtCashDeposit[colName] =
                            dr[colName];                    
                }
                drdtCashDeposit["SN"] = 
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDeposit"].Rows.Count + 1;

                dtGeneralInfo =
                    this.getDataFromDb.getnodesInfo(null, "", "", "",
                            drdtCashDeposit["AD_ORG_ID"].ToString(), triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(dtGeneralInfo))
                {
                    drdtCashDeposit["STORE"] = 
                        dtGeneralInfo.Rows[0]["node"].ToString();
                }
                else
                {
                    drdtCashDeposit["STORE"] = "Not Available";
                }

                dtGeneralInfo =
                    this.getDataFromDb.getC_BANKACCOUNTInfo(null, "",
                            drdtCashDeposit["C_BANKACCOUNT_ID"].ToString(), "", false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(dtGeneralInfo))
                {
                    drdtCashDeposit["BANKACCOUNT"] =
                        dtGeneralInfo.Rows[0]["ACCOUNTNO"].ToString() + " - " +
                        dtGeneralInfo.Rows[0]["BANKNAME"].ToString();
                }
                else
                {
                    drdtCashDeposit["BANKACCOUNT"] = "Not Available";
                }

                decimal cashLineAmt = 0;

                foreach (DataRow drl in dtCashDepositDtl.Rows)
                {
                    if (drl["C_CASH_ID"].ToString() == dr["C_CASH_ID"].ToString())
                        cashLineAmt += decimal.Parse(drl["AMOUNT_LINESOURCE"].ToString() == "" ? "0" : drl["AMOUNT_LINESOURCE"].ToString());
                }

                if (cashLineAmt.CompareTo(Math.Abs(decimal.Parse(dr["ENDINGBALANCE"].ToString()))) != 0)
                {
                    drdtCashDeposit["OVERUNDER"] =
                        Math.Abs(decimal.Parse(dr["ENDINGBALANCE"].ToString())) - cashLineAmt;
                }

                drdtCashDeposit["DateRange"] = dateRange;
                generalResultInformation.dtsDocumentPrintView.Tables["dtCashDeposit"].Rows.Add(drdtCashDeposit);              
                
            }


            foreach (DataRow dr in dtDepositDtl.Rows)
            {
                drdtCashDeposit =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDetail"].NewRow();
                foreach (DataColumn dc in
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDetail"].Columns)
                {
                    colName = dc.ColumnName;
                    if (dtDepositDtl.Columns.Contains(colName))
                        drdtCashDeposit[colName] =
                            dr[colName];
                }

                generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDetail"].Rows.Add(drdtCashDeposit);
            }




            foreach (DataRow dr in dtDepositDtlScr.Rows)
            {
                drdtCashDeposit =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDtlSrc"].NewRow();
                foreach (DataColumn dc in
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDtlSrc"].Columns)
                {
                    colName = dc.ColumnName;
                    if (dtDepositDtlScr.Columns.Contains(colName))
                        drdtCashDeposit[colName] =
                            dr[colName];
                }


                generalResultInformation.dtsDocumentPrintView.Tables["dtCashDepositDtlSrc"].Rows.Add(drdtCashDeposit);
            }

            generalResultInformation.requestedReport = reportType.BankDepositSlip;
            frmDocPrintPreview frmCRVPrintPreview = new frmDocPrintPreview();
            this.Enabled = true;
            frmCRVPrintPreview.ShowDialog();

            this.Close();
        }

        private void cmbSearchAndIncludeToPreviousResult_Click(object sender, EventArgs e)
        {
            DialogResult considerPreviousCriteria =
                MessageBox.Show("Should New Search Result Consider Previous Criterion", "Look Up",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;

            this.Enabled = false;

            previousSearchResult =
                generalResultInformation.searchResult.Copy();

            DataTable currentSearchCriteriaResult = new DataTable();



            this.establishSearchCriterion();

            currentSearchCriteriaResult =
                this.getDataFromDb.getV_DEPOSITDTLInfo(this.searchQuery, "AND", "", "",
                            "", this.dtpDepositDateFrom.Value, false, "", "", "",
                            CashSourceType.ignor, "", "", "",
                            generalResultInformation.Station, true, "AND");

            currentSearchCriteriaResult =
                this.getDataFromDb.clearRedundantRow(currentSearchCriteriaResult, "", 
                            new string[] {"C_CASH_ID", "C_CASHLINE_ID","C_CASHLINESOURCE_ID"});


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
                            currentSearchCriteriaResult, "", true);
            }
            else if (considerPreviousCriteria == DialogResult.No)
            {
                previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "", false);
            }
            generalResultInformation.searchResult =
                previousSearchResult.Copy();
            this.Enabled = true;            
        }

    }
}
