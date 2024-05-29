using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POSDocumentPrinter
{
    public partial class frmBankDepositSlips : Form
    {
        public frmBankDepositSlips()
        {
            InitializeComponent();
        }


        # region "Top Level Variables"
        /// <Top Level Variables>
        /// variable to be used accross this form
        /// <\Top Level Variables>
        /// 

        // bool
        bool recordView = true;

        // int
        int intCurrDepositSelectedRowIndex = -1;
        int intCurrDepositDtlSelectedRowIndex = -1;

        // Strings
        string stStationID = "";
        string stDepositID = "";
        string stDepositDetailID = "";
        string stBankAccountID = "";

        // Decimals        
        decimal dcCurrDepositDetailAmt = 0;
        decimal dcCurrDepositCommissionRate = 0;
        decimal dcDepositDetailTotal = 0; 
                

        // Tables
        DataTable dtExistingDeposit = new DataTable();
        DataTable dtNewDepositDetail = new DataTable();
        DataTable dtNewDepositDetailSource = new DataTable();


        DataTable dtBankAccountList = new DataTable();
        
        DataTable dtActiveOrganisations = new DataTable();

        // Others
        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        dataBuilder getDataFromDb = new dataBuilder();


        #endregion

        private void newForm()
        {
            this.intCurrDepositSelectedRowIndex = -1;
            this.intCurrDepositDtlSelectedRowIndex = -1;
                        
            this.dcCurrDepositDetailAmt = 0;
            this.dcCurrDepositCommissionRate = 0;
            this.dcDepositDetailTotal = 0;
            
            
            this.stDepositID = "";
            this.stStationID = generalResultInformation.Station;
            this.stDepositDetailID = "";
            this.stBankAccountID = "";
            

            this.txtOrganisation.Text = "";
            if (this.cmbOrganisation.Items.Count > 0)
                this.cmbOrganisation.SelectedIndex = 0;
            this.txtDocumentNo.Text = 
                this.getDepositSlipNumber(false);
            this.dtpDate.Value = DateTime.Now;

            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.SelectedRow.Clear();
            this.ddgBankAccount.SelectedItem = "";

            this.ckIsPaymentCard.Checked = false;                        

            this.cmbTenderType.SelectedIndex = 0;
            this.txtInstrumentNo.Text = "";

            this.txtDescriptionMain.Text = "";
            
            this.ntbAmount.Amount = "0";                        
            this.txtDescriptionDtl.Text = "";
            this.cmdAdd.Text = "ADD";


            this.lblDocumentNo.ForeColor = normalFieldColor;
            this.lblBankAccount.ForeColor = this.normalFieldColor;
            this.lblTenderType.ForeColor = this.normalFieldColor;
            

            this.dtNewDepositDetail.Rows.Clear();
            this.dtNewDepositDetailSource.Rows.Clear();

            this.dtgDepositDetail.Columns["remove"].Visible = true;

            this.txtOrganisation.Visible = false;
            this.cmbOrganisation.Visible = true;

            this.dtpDate.Enabled = true;
            this.txtDocumentNo.Enabled = true;            
            this.txtInstrumentNo.Enabled = true;
            this.txtDescriptionMain.Enabled = true;

            this.ddgBankAccount.Enabled = true;

            this.ckIsPaymentCard.Enabled = true;
            this.ntbCardCommissionRate.Enabled = true;

            this.enableDepositDetail(true);

            this.tlsConfirm.Enabled = true;

        }

        private bool isFormComplete()
        {
            bool formIsComplete = true;

            if (this.txtDocumentNo.Text == "")
            {
                this.lblDocumentNo.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblDocumentNo.ForeColor = normalFieldColor;

            
            if (this.ddgBankAccount.SelectedRowKey == null ||
                this.ddgBankAccount.SelectedItem == "")
            {
                this.lblBankAccount.ForeColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblBankAccount.ForeColor = this.normalFieldColor;


            if (this.dtgDepositDetail.Rows.Count <= 0)
            {
                this.dtgDepositDetail.BackgroundColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.dtgDepositDetail.BackgroundColor = SystemColors.Control;
                        
            
            return formIsComplete;
        }

        private bool tenderTypeInCurrentDetail(string tenderTyp, string tenderNo)
        {            
            foreach (DataRow dr in this.dtNewDepositDetail.Rows)
            {
                if (dr["TENDERTYPE"].ToString() == tenderTyp &&
                    dr["CHECKNO"].ToString() == tenderNo)
                    return true;
            }
            return false;
        }

        private void enableNavigationButton()
        {
            if (this.dtgDepositSummary.Rows.Count <= 1)
            {
                this.tlsFirstRecord.Enabled = false;
                this.tlsPreviousRecord.Enabled = false;
                this.tlsNextRecord.Enabled = false;
                this.tlsLastRecord.Enabled = false;
                return;
            }

            if (this.dtgDepositSummary.SelectedRows[0].Index ==
                this.dtgDepositSummary.Rows.Count - 1)
            {
                this.tlsFirstRecord.Enabled = true;
                this.tlsPreviousRecord.Enabled = true;
                this.tlsNextRecord.Enabled = false;
                this.tlsLastRecord.Enabled = false;
                return;
            }

            if (this.dtgDepositSummary.SelectedRows[0].Index == 0)
            {
                this.tlsFirstRecord.Enabled = false;
                this.tlsPreviousRecord.Enabled = false;
                this.tlsNextRecord.Enabled = true;
                this.tlsLastRecord.Enabled = true;
                return;
            }

            this.tlsFirstRecord.Enabled = true;
            this.tlsPreviousRecord.Enabled = true;
            this.tlsNextRecord.Enabled = true;
            this.tlsLastRecord.Enabled = true;
        }

        private void enableDepositDetail(bool enabled)
        {            
            this.dtgDepositDetail.Enabled = enabled;
            this.cmbTenderType.Enabled = enabled;
            this.txtInstrumentNo.Enabled = enabled;
            this.ntbAmount.Enabled = enabled;
            this.txtDescriptionDtl.Enabled = enabled;
            this.cmdAdd.Enabled = enabled;
            this.cmdSelectSource.Enabled = enabled;
        }

        private void removeDepositDetailSource()
        {
            if (this.dtgDepositDetail.SelectedRows.Count < 1 ||
                this.dtgDepositDetail.Enabled == false ||
                this.intCurrDepositDtlSelectedRowIndex == -1)
            {
                return;
            }

            string detailRowKey =
                this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                            Cells["LINE"].Value.ToString();

            for (int soruceRowCounter = this.dtNewDepositDetailSource.Rows.Count - 1;
                soruceRowCounter >= 0;
                soruceRowCounter--)
            {
                if (this.dtNewDepositDetailSource.Rows[soruceRowCounter]["C_CASHLINE_ID"].ToString() !=
                    detailRowKey)
                    continue;
                else
                    this.dtNewDepositDetailSource.Rows.RemoveAt(soruceRowCounter);
            }
        }


        private decimal getDepositDetailSourceAmount()
        {
            if (this.stDepositDetailID == "")
            {
                return 0;
            }

            decimal sourceAmount = 0;
            
            for (int soruceRowCounter = this.dtNewDepositDetailSource.Rows.Count - 1;
                soruceRowCounter >= 0;
                soruceRowCounter--)
            {
                if (this.dtNewDepositDetailSource.Rows[soruceRowCounter]["C_CASHLINE_ID"].ToString() !=
                    this.stDepositDetailID)
                    continue;
                else
                    sourceAmount +=
                        decimal.Parse(this.dtNewDepositDetailSource.Rows[soruceRowCounter]["AMOUNT"].ToString());
            }
            return sourceAmount;
        }

        private string getDepositSlipNumber(bool updateToNextVal)
        {
            string stSequenceInfo =
                this.getDataFromDb.getNextSequenceId("DEPOSIT_SLIP", "", 
                    generalResultInformation.Station, "", updateToNextVal);

            if (stSequenceInfo == "")
                return "";
            else
                return "<<" + stSequenceInfo + ">>";
        }

        private void createDetailDepositTable()
        {
            this.dtNewDepositDetail =
                this.getDataFromDb.getC_CASHLINEInfo(null, "", "", "", "",
                    generalResultInformation.Station, false, true, "AND");

            this.dtNewDepositDetail.Columns.Add("remove");
            

            this.dtNewDepositDetail.Columns["remove"].SetOrdinal(0);
            this.dtNewDepositDetail.Columns["LINE"].SetOrdinal(1);
            this.dtNewDepositDetail.Columns["TENDERTYPE"].SetOrdinal(2);
            this.dtNewDepositDetail.Columns["CHECKNO"].SetOrdinal(3);
            this.dtNewDepositDetail.Columns["AMOUNT"].SetOrdinal(4);            


            this.dtgDepositDetail.DataSource =
                this.dtNewDepositDetail;

            this.dtgDepositDetail.Columns["C_CASHLINE_ID"].Visible = false;
            this.dtgDepositDetail.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgDepositDetail.Columns["AD_ORG_ID"].Visible = false;
            this.dtgDepositDetail.Columns["C_CASH_ID"].Visible = false;
            this.dtgDepositDetail.Columns["CREATED"].Visible = false;
            this.dtgDepositDetail.Columns["CREATEDBY"].Visible = false;
            this.dtgDepositDetail.Columns["UPDATED"].Visible = false;
            this.dtgDepositDetail.Columns["UPDATEDBY"].Visible = false;
            this.dtgDepositDetail.Columns["ISACTIVE"].Visible = false;
            this.dtgDepositDetail.Columns["CASHTYPE"].Visible = false;
            this.dtgDepositDetail.Columns["C_CURRENCY_ID"].Visible = false;
            this.dtgDepositDetail.Columns["C_BANKACCOUNT_ID"].Visible = false;
            this.dtgDepositDetail.Columns["PROCESSED"].Visible = false;
            this.dtgDepositDetail.Columns["DESCRIPTION"].Visible = false;
            this.dtgDepositDetail.Columns["STATION_ID"].Visible = false;


            this.dtgDepositDetail.Columns["remove"].HeaderText = "";
            this.dtgDepositDetail.Columns["LINE"].HeaderText = "Sn";
            this.dtgDepositDetail.Columns["TENDERTYPE"].HeaderText = "Tender";
            this.dtgDepositDetail.Columns["CHECKNO"].HeaderText = "CPO/Check No";
            this.dtgDepositDetail.Columns["AMOUNT"].HeaderText = "Amount";

            this.dtgDepositDetail.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

            foreach (DataGridViewColumn columns in this.dtgDepositDetail.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }
        }

        private void fillDetailDepositSourceTable(string C_CASH_ID)
        {
            if (C_CASH_ID == "")
                return;
            this.dtNewDepositDetailSource.Rows.Clear();

            DataTable dtCashSource =
                this.getDataFromDb.getV_DEPOSITDTLInfo(null, "", C_CASH_ID, "", "",
                        DateTime.Now, false, "", "", "", CashSourceType.ignor, "", "", "",
                        this.stStationID, false, "AND");

            dtCashSource.Columns.Remove("C_CASH_ID");
            dtCashSource.Columns.Remove("AD_ORG_ID");
            dtCashSource.Columns.Remove("C_CASHBOOK_ID");
            dtCashSource.Columns.Remove("NAME");
            dtCashSource.Columns.Remove("DESCRIPTION");
            dtCashSource.Columns.Remove("STATEMENTDATE");
            dtCashSource.Columns.Remove("ENDINGBALANCE");
            dtCashSource.Columns.Remove("STATEMENTDIFFERENCE");
            dtCashSource.Columns.Remove("PROCESSED");
            dtCashSource.Columns.Remove("STATION_ID");
            dtCashSource.Columns.Remove("LINE");
            dtCashSource.Columns.Remove("DES_CASHLINE");
            dtCashSource.Columns.Remove("AMOUNT_CASHLINE");
            dtCashSource.Columns.Remove("C_BANKACCOUNT_ID");
            dtCashSource.Columns.Remove("TENDERTYPE");
            dtCashSource.Columns.Remove("CHECKNO");


            dtCashSource.Columns["AMOUNT_LINESOURCE"].ColumnName = "AMOUNT";

            DataTable dataInfo = new DataTable();

            string casLnID = "";
            int srNo = 1;

            foreach (DataRow dr in dtCashSource.Rows)
            {
                DataRow depstDtl = this.dtNewDepositDetailSource.NewRow();
                foreach (DataColumn dc in dtCashSource.Columns)
                {
                    string colName = dc.ColumnName;
                    if(this.dtNewDepositDetailSource.Columns.Contains(colName))
                        depstDtl[colName] = dr[colName];
                }

                if (depstDtl["C_CASHLINE_ID"].ToString() == casLnID)
                {
                    srNo++;
                    depstDtl["Sn"] = srNo;                    
                }
                else
                {
                    casLnID = depstDtl["C_CASHLINE_ID"].ToString();
                    srNo = 1;
                    depstDtl["Sn"] = srNo;
                }

                if (depstDtl["SOURCETYPE"].ToString() == CashSourceType.Sales.ToString())
                {
                    dataInfo =
                        this.getDataFromDb.getSalesInfo(null, "",
                                depstDtl["C_INVOICE_ID"].ToString(), depstDtl["STATION_ID"].ToString(), "", "", 
                                "", triaStateBool.Ignor, false, false, false, "AND");

                    if (this.getDataFromDb.checkIfTableContainesData(dataInfo))
                    {
                        depstDtl["Document No"] =
                            dataInfo.Rows[0]["ref_no"].ToString();
                        depstDtl["Dated"] =
                            DateTime.Parse(dataInfo.Rows[0]["sold_date"].ToString()).ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] =
                            (decimal.Parse(dataInfo.Rows[0]["total_amount"].ToString()) -
                            decimal.Parse(dataInfo.Rows[0]["with_holding"].ToString())).ToString("N02");
                    }
                    else
                    {
                        depstDtl["Document No"] = "0";
                        depstDtl["Dated"] = DateTime.Now.ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] = "0";
                    }
                }
                else if (depstDtl["SOURCETYPE"].ToString() == CashSourceType.CRV.ToString())
                {
                    dataInfo =
                        this.getDataFromDb.getC_PAYMENTInfo(null,"",
                                    depstDtl["C_PAYMENT_ID"].ToString(), "", "", DateTime.Now, false, tenderType.ignor, "",
                                    depstDtl["STATION_ID"].ToString(), false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(dataInfo))
                    {
                        depstDtl["Document No"] =
                            dataInfo.Rows[0]["DOCUMENTNO"].ToString();
                        depstDtl["Dated"] =
                            DateTime.Parse(dataInfo.Rows[0]["DATETRX"].ToString()).ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] =
                            (decimal.Parse(dataInfo.Rows[0]["PAYAMT"].ToString())).ToString("N02");
                    }
                    else
                    {
                        depstDtl["Document No"] = "0";
                        depstDtl["Dated"] = DateTime.Now.ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] = "0";
                    }
                }
                else if (depstDtl["SOURCETYPE"].ToString() == CashSourceType.Exemption.ToString())
                {
                    dataInfo =
                        this.getDataFromDb.getC_EXEMPTIONInfo(null, "",
                                depstDtl["C_EXEMPTION_ID"].ToString(), "", "", DateTime.Now, false, exemptionType.ignor,
                                depstDtl["STATION_ID"].ToString(), false, false, "AND");

                    if (this.getDataFromDb.checkIfTableContainesData(dataInfo))
                    {
                        depstDtl["Document No"] =
                            dataInfo.Rows[0]["DOCUMENTNO"].ToString();
                        depstDtl["Dated"] =
                            DateTime.Parse(dataInfo.Rows[0]["DATEINVOICED"].ToString()).ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] =
                            (decimal.Parse(dataInfo.Rows[0]["EXEMPTEDAMT"].ToString()) * -1).ToString("N02");
                    }
                    else
                    {
                        depstDtl["Document No"] = "0";
                        depstDtl["Dated"] = DateTime.Now.ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] = "0";
                    }
                }
                else if (depstDtl["SOURCETYPE"].ToString() == CashSourceType.Refund.ToString())
                {
                    dataInfo =
                        this.getDataFromDb.getRefundsInfo(null, "",
                                depstDtl["C_INVOICE_ID"].ToString(), depstDtl["STATION_ID"].ToString(), "", "",
                                "", false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(dataInfo))
                    {
                        depstDtl["Document No"] =
                            dataInfo.Rows[0]["ref_no"].ToString();
                        depstDtl["Dated"] =
                            DateTime.Parse(dataInfo.Rows[0]["sold_date"].ToString()).ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] =
                            (decimal.Parse(dataInfo.Rows[0]["total_amount"].ToString()) -
                            decimal.Parse(dataInfo.Rows[0]["with_holding"].ToString())).ToString("N02");
                    }
                    else
                    {
                        depstDtl["Document No"] = "0";
                        depstDtl["Dated"] = DateTime.Now.ToString("dd-MMM-yyyy");
                        depstDtl["Invoiced"] = "0";
                    }
                }

                this.dtNewDepositDetailSource.Rows.Add(depstDtl);
            }
            
        }

        private void fillDetailDepositTable(string C_CASH_ID)
        {
            if (C_CASH_ID == "")
                return;

            DataTable depositDtlInfo =
                this.getDataFromDb.getC_CASHLINEInfo(null, "", "",
                    "", C_CASH_ID, this.stStationID, false, false, "AND");
                        
            this.dtNewDepositDetail.Rows.Clear();


            foreach (DataRow dr in depositDtlInfo.Rows)
            {
                DataRow depstDtl = this.dtNewDepositDetail.NewRow();
                foreach (DataColumn dc in depositDtlInfo.Columns)
                {
                    string colName = dc.ColumnName;
                    depstDtl[colName] = dr[colName];
                }
                depstDtl["remove"] = "";

                this.dtNewDepositDetail.Rows.Add(depstDtl);
            }
        }

        private void loadSearchResultDataToExistingMainRecord()
        {
            this.dtExistingDeposit.Rows.Clear();
            DataRow drExistingDeposit;
            for (int rowCounter = 0;
                    rowCounter <= generalResultInformation.searchResult.Rows.Count - 1;
                    rowCounter++)
            {
                drExistingDeposit = this.dtExistingDeposit.NewRow();

                drExistingDeposit["C_CASH_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_CASH_ID"].ToString();                
                drExistingDeposit["AD_ORG_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString();                
                drExistingDeposit["NAME"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["NAME"].ToString();
                drExistingDeposit["ISCARDPAYMENT"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["ISCARDPAYMENT"].ToString();
                drExistingDeposit["COMMISSIONRATE"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["COMMISSIONRATE"].ToString();              
                drExistingDeposit["STATEMENTDATE"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["STATEMENTDATE"].ToString();               
                drExistingDeposit["DESCRIPTION"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DESCRIPTION"].ToString();
                drExistingDeposit["ENDINGBALANCE"] =
                   decimal.Parse(generalResultInformation.searchResult.Rows[rowCounter]["ENDINGBALANCE"].ToString()) * -1;                
                drExistingDeposit["PROCESSED"] =
                     generalResultInformation.searchResult.Rows[rowCounter]["PROCESSED"].ToString();
                drExistingDeposit["C_BANKACCOUNT_ID"] =
                     generalResultInformation.searchResult.Rows[rowCounter]["C_BANKACCOUNT_ID"].ToString();

                DataTable BankAccountInfo =
                    this.getDataFromDb.getC_BANKACCOUNTInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["C_BANKACCOUNT_ID"].ToString(),
                            "", false, false, "AND");                    

                if (!this.getDataFromDb.checkIfTableContainesData(BankAccountInfo))
                {
                    drExistingDeposit["Bank Account"] = "NOT AVAILABLE";
                }
                else
                    drExistingDeposit["Bank Account"] = BankAccountInfo.Rows[0]["ACCOUNTNO"].ToString();

                DataTable OrgInfo = 
                    this.getDataFromDb.getnodesInfo(null, "", "",
                        "",
                        generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                        triaStateBool.Ignor, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(OrgInfo))
                {
                    drExistingDeposit["Organisation"] = "NOT AVAILABLE";
                }
                else
                    drExistingDeposit["Organisation"] = OrgInfo.Rows[0]["node"].ToString();
                
                
                drExistingDeposit["STATION_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString();

                this.dtExistingDeposit.Rows.Add(drExistingDeposit);
            }
        }
        




        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.newForm();
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (!this.isFormComplete())
            {
                this.Enabled = true;
                if (!this.recordView)
                    this.tlsChangeView_Click(sender, e);
                MessageBox.Show("Please Insert the missing fields before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }


            DataTable newDepositSummary =
                this.getDataFromDb.getC_CASHInfo(null, "", "", "", "", DateTime.Now, false,
                         "", false, true, "AND");

            DataRow drNewDepositDetail = newDepositSummary.NewRow();

            drNewDepositDetail["AD_ORG_ID"] =
                this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            if (this.txtDocumentNo.Text.StartsWith("<<") &&
                this.txtDocumentNo.Text.EndsWith(">>"))
                drNewDepositDetail["NAME"] = 
                    this.getDepositSlipNumber(true).Replace("<<","").Replace(">>","");
            else
                drNewDepositDetail["NAME"] = this.txtDocumentNo.Text;
            drNewDepositDetail["ISCARDPAYMENT"] = this.ckIsPaymentCard.Checked ? "Y" : "N";
            drNewDepositDetail["COMMISSIONRATE"] = this.dcCurrDepositCommissionRate.ToString();
            drNewDepositDetail["STATEMENTDATE"] = this.dtpDate.Value.ToString("yyyy-MM-dd");
            drNewDepositDetail["DATEACCT"] = this.dtpDate.Value.ToString("yyyy-MM-dd");
            drNewDepositDetail["DESCRIPTION"] = this.txtDescriptionMain.Text;            
            drNewDepositDetail["ENDINGBALANCE"] = (this.dcDepositDetailTotal * -1).ToString();
            drNewDepositDetail["STATEMENTDIFFERENCE"] = (this.dcDepositDetailTotal * -1).ToString();
            drNewDepositDetail["STATION_ID"] = generalResultInformation.Station;

            newDepositSummary.Rows.Add(drNewDepositDetail);

            string[] recordId =
                this.getDataFromDb.changeDataBaseTableData(newDepositSummary, "C_CASH", "INSERT", true);

            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                this.Enabled = true;
                return;
            }

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
                this.Enabled = true;
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                return;
            }

            for (int currentDetailRecord = 0;
                 currentDetailRecord <= this.dtNewDepositDetail.Rows.Count - 1;
                 currentDetailRecord++)
            {
                this.dtNewDepositDetail.Rows[currentDetailRecord]["C_CASH_ID"] =
                    newRecordId[1];
                this.dtNewDepositDetail.Rows[currentDetailRecord]["AD_ORG_ID"] =
                    this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
                this.dtNewDepositDetail.Rows[currentDetailRecord]["STATION_ID"] =
                    generalResultInformation.Station;
                this.dtNewDepositDetail.Rows[currentDetailRecord]["C_BANKACCOUNT_ID"] =
                    this.stBankAccountID;
            }

            string[] recordDetailId =
                this.getDataFromDb.changeDataBaseTableData(this.dtNewDepositDetail.Copy(), 
                "C_CASHLINE", "INSERT", true);

            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                string deleteC_Cashline = "DELETE FROM C_CASHLINE WHERE C_CASH_ID = " + newRecordId[1];
                this.getDataFromDb.executeSqlOnPOS(deleteC_Cashline);
                string deleteC_Cash = "DELETE FROM C_CASH WHERE C_CASH_ID = " + newRecordId[1];
                this.getDataFromDb.executeSqlOnPOS(deleteC_Cash);                
                this.Enabled = true;
                return;
            }

            string[] newRecordDetailId = new string[(recordDetailId.Length * 2)];


            for (int arrayIndexCounter = 0;
                 arrayIndexCounter <= recordDetailId.Length - 1;
                 arrayIndexCounter++)
            {
                recordDetailId[arrayIndexCounter].Split(primaryKeySepartor,
                    StringSplitOptions.RemoveEmptyEntries).
                        CopyTo(newRecordDetailId, (arrayIndexCounter * 2));
            }

            if (newRecordDetailId.Length < 2)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                string deleteC_Cashline = "DELETE FROM C_CASHLINE WHERE C_CASH_ID = " + newRecordId[1];
                this.getDataFromDb.executeSqlOnPOS(deleteC_Cashline);
                string deleteC_Cash = "DELETE FROM C_CASH WHERE C_CASH_ID = " + newRecordId[1];
                this.getDataFromDb.executeSqlOnPOS(deleteC_Cash);                
                this.Enabled = true;
                return;
            }

            int detailRowKeyIndex = 0;

            if (this.dtNewDepositDetailSource.Rows.Count > 0)
            {

                try
                {
                    for (int soruceRowCounter = 0;
                        soruceRowCounter <= this.dtNewDepositDetailSource.Rows.Count - 1;
                        soruceRowCounter++)
                    {
                        detailRowKeyIndex =
                            int.Parse(this.dtNewDepositDetailSource.Rows[soruceRowCounter]["C_CASHLINE_ID"].ToString()) - 1;

                        detailRowKeyIndex = detailRowKeyIndex * 2 + 1;

                        this.dtNewDepositDetailSource.Rows[soruceRowCounter]["C_CASHLINE_ID"] =
                            newRecordDetailId[detailRowKeyIndex];
                        this.dtNewDepositDetailSource.Rows[soruceRowCounter]["AD_ORG_ID"] =
                            this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
                        this.dtNewDepositDetailSource.Rows[soruceRowCounter]["STATION_ID"] =
                            generalResultInformation.Station;
                    }

                    string[] recordDetailSourceId =
                        this.getDataFromDb.changeDataBaseTableData(this.dtNewDepositDetailSource.Copy(),
                                "C_CASHLINESOURCE", "INSERT", true);

                    if (recordDetailSourceId.Length < 1)
                    {
                        this.sbStatusLabel.Text = "Record IS NOT Saved";
                        string deleteC_Cash = "DELETE FROM C_CASH WHERE C_CASH_ID = " + newRecordId[1];
                        this.getDataFromDb.executeSqlOnPOS(deleteC_Cash);
                        string deleteC_Cashline = "DELETE FROM C_CASHLINE WHERE C_CASH_ID = " + newRecordId[1];
                        this.getDataFromDb.executeSqlOnPOS(deleteC_Cashline);
                        this.Enabled = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Save Record with error message { " + ex.Message +
                        " }.\n Contact Your Admin.");

                    this.sbStatusLabel.Text = "Record IS NOT Saved";
                    string deleteC_Cash = "DELETE FROM C_CASH WHERE C_CASH_ID = " + newRecordId[1];
                    this.getDataFromDb.executeSqlOnPOS(deleteC_Cash);
                    string deleteC_Cashline = "DELETE FROM C_CASHLINE WHERE C_CASH_ID = " + newRecordId[1];
                    this.getDataFromDb.executeSqlOnPOS(deleteC_Cashline);
                    this.Enabled = true;
                    return;
                }
            }
            
            //for (int currentDetailRecord = 0;
            //     currentDetailRecord <= this.dtNewDepositDetail.Rows.Count - 1;
            //     currentDetailRecord++)
            //{
            //    detailRowKeyIndex = currentDetailRecord * 2 + 1;
            //    for (int soruceRowCounter = 0; 
            //        soruceRowCounter <= this.dtNewDepositDetailSource.Rows.Count - 1; 
            //        soruceRowCounter++)
            //    {
            //        if (this.dtNewDepositDetailSource.Rows[soruceRowCounter]["C_CASHLINE_ID"].ToString() != "")
            //            continue;

            //        this.dtNewDepositDetailSource.Rows[soruceRowCounter]["C_CASHLINE_ID"] = 
            //            newRecordDetailId[detailRowKeyIndex];                    
            //        this.dtNewDepositDetailSource.Rows[soruceRowCounter]["AD_ORG_ID"] =
            //            this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            //        this.dtNewDepositDetailSource.Rows[soruceRowCounter]["STATION_ID"] =
            //            generalResultInformation.Station;
            //    }
            //}

            

            DataRow drExistingDeposit = this.dtExistingDeposit.NewRow();

            drExistingDeposit["C_CASH_ID"] = newRecordId[1];
            drExistingDeposit["AD_ORG_ID"] =
                this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            drExistingDeposit["Organisation"] = this.cmbOrganisation.SelectedItem.ToString();
            drExistingDeposit["NAME"] = this.txtDocumentNo.Text;
            drExistingDeposit["ISCARDPAYMENT"] = this.ckIsPaymentCard.Checked ? "Y" : "N";
            drExistingDeposit["COMMISSIONRATE"] = this.dcCurrDepositCommissionRate.ToString();
            drExistingDeposit["STATEMENTDATE"] = this.dtpDate.Value.ToString("yyyy-MM-dd");
            drExistingDeposit["DESCRIPTION"] = this.txtDescriptionMain.Text;
            drExistingDeposit["Bank Account"] = this.ddgBankAccount.SelectedItem;
            drExistingDeposit["STATEMENTDIFFERENCE"] = this.dcDepositDetailTotal * -1;
            drExistingDeposit["STATION_ID"] = generalResultInformation.Station;

            this.dtExistingDeposit.Rows.Add(drExistingDeposit);

            MessageBox.Show("New Record Saved Successfully.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Enabled = true;
            this.tlsLastRecord_Click(sender, e);
            this.dtgDepositSummary_CellClick(sender, new DataGridViewCellEventArgs(0,0));

        }

        private void tlsConfirm_Click(object sender, EventArgs e)
        {
            this.tlsSave_Click(sender, e);
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            frmSearchDeposit newSearch = new frmSearchDeposit();
            newSearch.ShowDialog(this);
            this.loadSearchResultDataToExistingMainRecord();
            if (this.dtgDepositSummary.Rows.Count > 0)
                this.dtgDepositSummary.Rows[0].Selected = true;
            this.dtgDepositSummary_SelectionChanged(sender, e);
        }

        private void tlsChangeView_Click(object sender, EventArgs e)
        {
            if (this.recordView)
            {
                this.recordView = false;
                this.dtgDepositSummary.Size = new System.Drawing.Size(541, 368);
                this.dtgDepositSummary.Visible = true;
                this.dtgDepositSummary.BringToFront();
            }
            else
            {
                this.dtgDepositSummary.Visible = false;
                this.dtgDepositSummary.Size = new System.Drawing.Size(541, 10);
                this.recordView = true;
            }
        }


        private void tlsFirstRecord_Click(object sender, EventArgs e)
        {
            this.dtgDepositSummary.Rows[0].Selected = true;
        }

        private void tlsPreviousRecord_Click(object sender, EventArgs e)
        {
            if (this.intCurrDepositSelectedRowIndex == -1)
            {
                if (this.dtgDepositSummary.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                    this.intCurrDepositSelectedRowIndex =
                        this.dtgDepositSummary.SelectedRows[0].Index;
            }

            this.dtgDepositSummary.Rows[this.intCurrDepositSelectedRowIndex - 1].Selected = true;
        }

        private void tlsNextRecord_Click(object sender, EventArgs e)
        {
            if (this.intCurrDepositSelectedRowIndex == -1)
            {
                if (this.dtgDepositSummary.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                    this.intCurrDepositSelectedRowIndex =
                        this.dtgDepositSummary.SelectedRows[0].Index;
            }

            this.dtgDepositSummary.Rows[this.intCurrDepositSelectedRowIndex + 1].Selected = true;
        }

        private void tlsLastRecord_Click(object sender, EventArgs e)
        {
            this.dtgDepositSummary.Rows[this.dtgDepositSummary.Rows.Count - 1].Selected = true;
        }



        private void tlsPrint_Click(object sender, EventArgs e)
        {
            frmDepositSlipPrint printDpSlip = new frmDepositSlipPrint();
            printDpSlip.TopMost = true;
            printDpSlip.ShowDialog();
        }

        private void tlsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void frmBankDepositSlips_Load(object sender, EventArgs e)
        {
            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            this.createDetailDepositTable();

            this.enableDepositDetail(true);


            this.dtExistingDeposit =
                this.getDataFromDb.getC_CASHInfo(null, "", "", "", "", DateTime.Now, false,
                         "", false, true, "AND");

            this.dtExistingDeposit.Columns.Add("Bank Account");
            this.dtExistingDeposit.Columns.Add("C_BANKACCOUNT_ID");
            this.dtExistingDeposit.Columns.Add("Organisation");

            this.dtgDepositSummary.DataSource =
                this.dtExistingDeposit;

            this.dtgDepositSummary.Columns["C_CASH_ID"].Visible = false;
            this.dtgDepositSummary.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgDepositSummary.Columns["AD_ORG_ID"].Visible = false;
            this.dtgDepositSummary.Columns["CREATED"].Visible = false;
            this.dtgDepositSummary.Columns["CREATEDBY"].Visible = false;
            this.dtgDepositSummary.Columns["UPDATED"].Visible = false;
            this.dtgDepositSummary.Columns["UPDATEDBY"].Visible = false;
            this.dtgDepositSummary.Columns["ISACTIVE"].Visible = false;
            this.dtgDepositSummary.Columns["DESCRIPTION"].Visible = false;
            this.dtgDepositSummary.Columns["C_CASHBOOK_ID"].Visible = false;
            this.dtgDepositSummary.Columns["PROCESSED"].Visible = false;
            this.dtgDepositSummary.Columns["STATION_ID"].Visible = false;
            this.dtgDepositSummary.Columns["DATEACCT"].Visible = false;
            this.dtgDepositSummary.Columns["STATEMENTDIFFERENCE"].Visible = false;
            this.dtgDepositSummary.Columns["PROCESSING"].Visible = false;
            this.dtgDepositSummary.Columns["DOCSTATUS"].Visible = false;
            this.dtgDepositSummary.Columns["DOCACTION"].Visible = false;
            this.dtgDepositSummary.Columns["C_BANKACCOUNT_ID"].Visible = false;

            this.dtExistingDeposit.Columns["Organisation"].SetOrdinal(0);
            this.dtExistingDeposit.Columns["NAME"].SetOrdinal(1);
            this.dtExistingDeposit.Columns["STATEMENTDATE"].SetOrdinal(2);
            this.dtExistingDeposit.Columns["Bank Account"].SetOrdinal(3);
            this.dtExistingDeposit.Columns["ISCARDPAYMENT"].SetOrdinal(4);
            this.dtExistingDeposit.Columns["COMMISSIONRATE"].SetOrdinal(5);
            this.dtExistingDeposit.Columns["ENDINGBALANCE"].SetOrdinal(6);


            this.dtgDepositSummary.Columns["NAME"].HeaderText = "Document No";
            this.dtgDepositSummary.Columns["ISCARDPAYMENT"].HeaderText = "Is Card";
            this.dtgDepositSummary.Columns["COMMISSIONRATE"].HeaderText = "Rate";
            this.dtgDepositSummary.Columns["STATEMENTDATE"].HeaderText = "Date";
            this.dtgDepositSummary.Columns["ENDINGBALANCE"].HeaderText = "Total Amount";
            
            this.enableNavigationButton();

            this.dtActiveOrganisations =
                this.getDataFromDb.getnodesInfo(null, "", "",
                    generalResultInformation.Station, triaStateBool.yes, false, "AND");

            for (int rowCounter = 0; rowCounter <= this.dtActiveOrganisations.Rows.Count - 1; rowCounter++)
            {
                this.cmbOrganisation.Items.Add(
                    this.dtActiveOrganisations.Rows[rowCounter]["node"].ToString());
            }

            if (this.dtActiveOrganisations.Rows.Count > 0)
                this.cmbOrganisation.SelectedIndex = 0;



            generalResultInformation.newCashSource =
                this.getDataFromDb.getC_CASHLINESOURCEInfo(null, "", "", "", CashSourceType.ignor, 
                    "", "", "", "", false, true, "AND");

            generalResultInformation.newCashSource.Columns.Add("Sn");
            generalResultInformation.newCashSource.Columns.Add("Document No");
            generalResultInformation.newCashSource.Columns.Add("Dated");
            generalResultInformation.newCashSource.Columns.Add("Invoiced");

            generalResultInformation.newCashSource.Columns["Sn"].SetOrdinal(0);
            generalResultInformation.newCashSource.Columns["Document No"].SetOrdinal(1);
            generalResultInformation.newCashSource.Columns["SOURCETYPE"].SetOrdinal(2);
            generalResultInformation.newCashSource.Columns["Dated"].SetOrdinal(3);
            generalResultInformation.newCashSource.Columns["Invoiced"].SetOrdinal(4);
            generalResultInformation.newCashSource.Columns["ONHANDAMT"].SetOrdinal(5);
            generalResultInformation.newCashSource.Columns["AMOUNT"].SetOrdinal(6);
            generalResultInformation.newCashSource.Columns["OVERUNDERAMT"].SetOrdinal(7);

            this.dtNewDepositDetailSource =
                generalResultInformation.newCashSource.Clone();


            this.newForm();
        }

        

        private void cmbOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddgBankAccount_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtBankAccountList = 
                this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "",
                    this.ddgBankAccount.SelectedItem, true, false, "AND");

            this.dtBankAccountList.Columns.Remove("ISACTIVE");
            this.ddgBankAccount.DataSource = this.dtBankAccountList;
            this.ddgBankAccount.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtBankAccountList.Columns.IndexOf("C_BANKACCOUNT_ID"));
            this.ddgBankAccount.SelectedColomnIdex =
                this.dtBankAccountList.Columns.IndexOf("ACCOUNTNO");
            
        }

        private void ddgBankAccount_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgBankAccount.SelectedRow != null &&
                this.ddgBankAccount.SelectedItem != "")
            {
                this.stBankAccountID =
                    this.ddgBankAccount.SelectedRowKey.ToString();                
            }
            else
            {
                this.stBankAccountID = "";                
            }
        }

        private void ckIsPaymentCard_CheckedChanged(object sender, EventArgs e)
        {
            this.ntbCardCommissionRate.Amount = "0";

            this.lblCardlCommissionRate.Visible = this.ckIsPaymentCard.Checked;
            this.ntbCardCommissionRate.Visible = this.ckIsPaymentCard.Checked;
            this.lblPrcnt.Visible = this.ckIsPaymentCard.Checked;

            this.ntbCardCommissionRate.Enabled = this.ckIsPaymentCard.Enabled;

        }



        private void cmbTenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTenderType.SelectedItem.ToString() == "Cash")
                this.txtInstrumentNo.Visible = false;
            else
                this.txtInstrumentNo.Visible = true;
            this.txtInstrumentNo.Text = "";
        }
        
        private void cmdSelectSource_Click(object sender, EventArgs e)
        {
            if (this.dcCurrDepositDetailAmt <= 0)
                return;
            

            generalResultInformation.C_CASHLINE_ID = 
                this.stDepositID != "" ? this.stDepositDetailID : this.cmdAdd.Text == "Modify" ? 
                    this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                    Cells["LINE"].Value.ToString() : (this.dtNewDepositDetail.Rows.Count + 1).ToString();

            generalResultInformation.isCashLineProcessed = 
                this.stDepositID == "" ? false : true;

            generalResultInformation.cashLineAmt = this.dcCurrDepositDetailAmt;
            generalResultInformation.cardCommissionRate = this.dcCurrDepositCommissionRate;
            generalResultInformation.securityPassKeyCorrect = false;

            frmCashSource frmCashSource = new frmCashSource();

            generalResultInformation.newCashSource =
                this.dtNewDepositDetailSource.Copy();

            frmCashSource.TopMost = true;
            frmCashSource.ShowDialog();

            if(this.stDepositID == "")
                this.dtNewDepositDetailSource =
                    generalResultInformation.newCashSource.Copy();

            generalResultInformation.newCashSource.Rows.Clear();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (this.cmdAdd.Text != "Modify" &&
                this.tenderTypeInCurrentDetail(this.cmbTenderType.SelectedItem.ToString(),
                        this.txtInstrumentNo.Text))
            {
                MessageBox.Show("Duplicate Tender Not Allowed.",
                    "New Receipt", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);                
                return;
            }

            this.stDepositDetailID = this.cmdAdd.Text != "Modify" ?
                (this.dtNewDepositDetail.Rows.Count + 1).ToString() :
                (this.intCurrDepositDtlSelectedRowIndex + 1).ToString();

            //if (this.dcCurrDepositDetailAmt == 0 && 
            //    !generalResultInformation.allowAmountOverageShortage)
            //{
            //    MessageBox.Show("Amount Invalid.",
            //        "New Deposit", MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);
            //    return;
            //}
                        
            if (this.txtInstrumentNo.Visible &&
                this.txtInstrumentNo.Text == "")
            {
                MessageBox.Show("Invalid Check/CPO Number.",
                     "New Deposit", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                return;
            }

            //if (this.dtNewDepositDetailSource.Rows.Count <= 0 &&
            //    !generalResultInformation.allowAmountOverageShortage)
            //{
            //    MessageBox.Show("Please Select Source.",
            //         "New Deposit", MessageBoxButtons.OK,
            //                 MessageBoxIcon.Information);
            //    this.cmdSelectSource.ForeColor = this.missingFieldColor;                
            //    return;
            //}
            //else
            //    this.cmdSelectSource.ForeColor = this.normalFieldColor;

            decimal depositCommission =
                this.dcCurrDepositDetailAmt /
                    ((this.dcCurrDepositCommissionRate / 100) + 1) *
                (this.dcCurrDepositCommissionRate / 100);

            decimal cashOverShort =
                this.getDepositDetailSourceAmount() + 
                    depositCommission - this.dcCurrDepositDetailAmt;



            if ((cashOverShort.CompareTo(generalResultInformation.overAmtLimit) == -1 ||
                cashOverShort.CompareTo(generalResultInformation.shortAmtLimit) == 1) &&
                !generalResultInformation.securityPassKeyCorrect)
            {
                bool blAllowAmount = false;

                if (
                   MessageBox.Show("Source Amount Does Not Match." +
                       "\n Enter pass key to proceed.", "New Deposit",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (generalResultInformation.securityPassKeyCorrect)
                    {
                        blAllowAmount = true;
                    }
                }
                if (!blAllowAmount)
                {
                    MessageBox.Show("Please Correct Selected Source.",
                         "New Deposit", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    this.cmdSelectSource.ForeColor = this.missingFieldColor;
                    return;
                }
            }
            else
                this.cmdSelectSource.ForeColor = this.normalFieldColor;
            

            if (this.cmdAdd.Text == "Modify")
            {
                this.dcDepositDetailTotal -=
                    this.dcCurrDepositDetailAmt;                    

                this.dtNewDepositDetail.Rows[this.intCurrDepositDtlSelectedRowIndex]["TENDERTYPE"] =
                    this.cmbTenderType.SelectedItem.ToString();

                this.dtNewDepositDetail.Rows[this.intCurrDepositDtlSelectedRowIndex]["CHECKNO"] =
                    this.txtInstrumentNo.Text;

                this.dtNewDepositDetail.Rows[this.intCurrDepositDtlSelectedRowIndex]["AMOUNT"] =
                    this.dcCurrDepositDetailAmt.ToString("N02");

                this.dtNewDepositDetail.Rows[this.intCurrDepositDtlSelectedRowIndex]["DESCRIPTION"] =
                    this.txtDescriptionDtl.Text;
            }
            else
            {
                DataRow drNewDepositDetail = this.dtNewDepositDetail.NewRow();

                drNewDepositDetail["remove"] = "remove";

                drNewDepositDetail["LINE"] =
                    this.dtNewDepositDetail.Rows.Count + 1;
                                
                drNewDepositDetail["TENDERTYPE"] =
                    this.cmbTenderType.SelectedItem.ToString();
                drNewDepositDetail["CHECKNO"] =
                    this.txtInstrumentNo.Text;
                drNewDepositDetail["AMOUNT"] =
                    this.dcCurrDepositDetailAmt.ToString("N02");
                drNewDepositDetail["DESCRIPTION"] =                
                    this.txtDescriptionDtl.Text;

                this.dtNewDepositDetail.Rows.Add(drNewDepositDetail);
            }

            this.dcDepositDetailTotal +=
                this.dcCurrDepositDetailAmt;

            this.cmdAdd.Text = "ADD";
            this.cmbTenderType.SelectedIndex = 0;
            this.ntbAmount.Amount = "0";
            this.txtInstrumentNo.Text = "";
            this.txtDescriptionDtl.Text = "";
            generalResultInformation.securityPassKeyCorrect = false;

        }


        private void dtgDepositSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgDepositSummary_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgDepositSummary.SelectedRows.Count < 1)
            {
                return;
            }

            this.intCurrDepositSelectedRowIndex =
                this.dtgDepositSummary.SelectedRows[0].Index;
            this.enableNavigationButton();

            this.tlsConfirm.Enabled = false;

            this.cmbOrganisation.Visible = false;
            this.txtOrganisation.Visible = true;

            this.dtpDate.Enabled = false;
            this.txtDocumentNo.Enabled = false;
            this.txtDescriptionMain.Enabled = false;
            this.ddgBankAccount.Enabled = false;

            this.ckIsPaymentCard.Enabled = false;
            this.ntbCardCommissionRate.Enabled = false;


            this.enableDepositDetail(false);
            this.cmdSelectSource.Enabled = true;
            this.dtgDepositDetail.Enabled = true;

            this.stDepositID =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["C_CASH_ID"].ToString();

            this.stBankAccountID =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["C_BANKACCOUNT_ID"].ToString();

            this.dcCurrDepositCommissionRate =
               decimal.Parse(this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["COMMISSIONRATE"].ToString());

            this.stStationID =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["STATION_ID"].ToString();

            this.txtOrganisation.Text =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["Organisation"].ToString();

            this.dtpDate.Value =
                DateTime.Parse(this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["STATEMENTDATE"].ToString());

            this.txtDocumentNo.Text =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["NAME"].ToString();

            this.ddgBankAccount.SelectedRowKey =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["C_BANKACCOUNT_ID"].ToString();
            this.ddgBankAccount.SelectedItem =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["Bank Account"].ToString();

            this.ckIsPaymentCard.Checked =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["ISCARDPAYMENT"].ToString() == "Y" ? true : false;

            this.ntbCardCommissionRate.Amount =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["COMMISSIONRATE"].ToString();

            this.txtDescriptionMain.Text =
                this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["DESCRIPTION"].ToString();

            this.fillDetailDepositTable(this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["C_CASH_ID"].ToString());
            this.fillDetailDepositSourceTable(this.dtExistingDeposit.Rows[this.intCurrDepositSelectedRowIndex]["C_CASH_ID"].ToString());

            if (this.dtgDepositDetail.Rows.Count > 0)
                this.dtgDepositDetail.Rows[0].Selected = true;
            this.dtgDepositDetail_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void dtgDepositSummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
            string colName = dtgDepositSummary.Columns[e.ColumnIndex].Name;
            DataView dtView = this.dtExistingDeposit.DefaultView;

            if (dtgDepositSummary.SortOrder == SortOrder.Ascending)
            {
                dtView.Sort = colName + " ASC";
            }
            else
            {
                dtView.Sort = colName + " DESC";
            }

            this.dtExistingDeposit = dtView.ToTable();

            this.dtgDepositSummary_SelectionChanged(sender, new EventArgs());
        }



        private void dtgDepositDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (this.dtgDepositDetail.SelectedRows.Count < 1 ||
                this.dtgDepositDetail.Enabled == false)
            {
                this.stDepositDetailID = "";
                this.intCurrDepositDtlSelectedRowIndex = -1;
                return;
            }

            this.intCurrDepositDtlSelectedRowIndex =
                this.dtgDepositDetail.SelectedRows[0].Index;

            this.stDepositDetailID =
                this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                            Cells["C_CASHLINE_ID"].Value.ToString();

            if (this.dtgDepositDetail.CurrentCell != null)
            {
                if (this.dtgDepositDetail.CurrentCell.OwningColumn.Index == 0 &&
                    this.dtgDepositDetail.CurrentCell.OwningColumn.Name == "remove" &&
                    this.dtgDepositDetail.CurrentCell.Value.ToString() == "remove" &&
                    this.dtgDepositDetail.CurrentCell.OwningColumn.HeaderText == "")
                {
                    decimal removedDepositAmount =
                        decimal.Parse(this.dtNewDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex]["AMOUNT"].ToString());

                    this.removeDepositDetailSource();

                    //this.dtgInvoiceAmount.Rows[intCurrExemptionDtlSelectedRowIndex].
                    //        Cells["ISEXEMPTION"].Value.ToString() == "Y" ?
                    //        this.dcCurrePaymentDetailTotal += removedExemptionAmount :
                    this.dcDepositDetailTotal -= removedDepositAmount;
                                        
                    this.dtNewDepositDetail.Rows.RemoveAt(intCurrDepositDtlSelectedRowIndex);
                                        
                    this.cmdAdd.Text = "ADD";                    
                    this.intCurrDepositDtlSelectedRowIndex = -1;
                }
                else
                {
                    this.cmdAdd.Text = "Modify";

                    this.dcCurrDepositDetailAmt =
                        decimal.Parse(this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                            Cells["AMOUNT"].Value.ToString());

                    this.ntbAmount.Amount =
                        this.dcCurrDepositDetailAmt.ToString();

                    this.txtDescriptionDtl.Text =
                        this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                            Cells["DESCRIPTION"].Value.ToString();

                    this.cmbTenderType.SelectedItem =
                        this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                            Cells["TENDERTYPE"].Value.ToString();

                    this.txtInstrumentNo.Text =
                        this.dtgDepositDetail.Rows[intCurrDepositDtlSelectedRowIndex].
                            Cells["CHECKNO"].Value.ToString();
                                        

                    this.cmdAdd.Enabled = true;
                }
            }
        }


        private void ntbAmount_Leave(object sender, EventArgs e)
        {
            this.dcCurrDepositDetailAmt =
                decimal.Parse(this.ntbAmount.Amount);
            if (this.dcCurrDepositDetailAmt != generalResultInformation.cashLineAmt)
                generalResultInformation.securityPassKeyCorrect = false;
        }

        
        private void ntbCardCommissionRate_Leave(object sender, EventArgs e)
        {
            this.dcCurrDepositCommissionRate =
                decimal.Parse(this.ntbCardCommissionRate.Amount); 
        }

        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            //this.txtDocumentNo.Text =
            //    Regex.Replace(this.txtDocumentNo.Text.ToUpper(), @"\s+", "");
            this.txtDocumentNo.Text =
                Regex.Replace(this.txtDocumentNo.Text.ToUpper(), @"[^0-9a-zA-Z\-<>]+", "");

            DataTable depositInfo = this.getDataFromDb.getC_CASHInfo(null, "", "",
                    "", this.txtDocumentNo.Text, DateTime.Now,
                    false, generalResultInformation.Station, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(depositInfo))
            {
                MessageBox.Show("Document Number  -- " +
                                depositInfo.Rows[0]["NAME"].ToString() +
                                " -- is already in use on Deposite dated " +
                                DateTime.Parse(depositInfo.Rows[0]["STATEMENTDATE"].ToString()).ToString("dd-MMM-yyyy") +
                                "\n Please use different Document number",
                        "Deposit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDocumentNo.Text = "";
                return;
            }
        }

        private void txtInstrumentNo_Leave(object sender, EventArgs e)
        {
            this.txtInstrumentNo.Text =
                Regex.Replace(
                    Regex.Replace(this.txtInstrumentNo.Text.ToUpper().Trim(), @"\s+", " "),
                    @"\s+", "-");

            this.txtInstrumentNo.Text =
                Regex.Replace(this.txtInstrumentNo.Text.ToUpper(), @"[^0-9a-zA-Z\-]+", "");

            DataTable depositInfo = this.getDataFromDb.getC_CASHLINEInfo(null, "", "",
                    "", "", this.txtInstrumentNo.Text,
                    generalResultInformation.Station, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(depositInfo))
            {
                MessageBox.Show("Cheque Number  -- " +
                                depositInfo.Rows[0]["CHECKNO"].ToString() +
                                " -- is already in use." +
                                " \n Please use different Document number",
                        "Deposit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtInstrumentNo.Text = "";
                return;
            }

        }

        
        

        
        
    }
}
