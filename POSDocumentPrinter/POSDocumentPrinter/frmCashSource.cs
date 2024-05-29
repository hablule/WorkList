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
    public partial class frmCashSource : Form
    {
        public frmCashSource()
        {
            InitializeComponent();
        }

        string logicalConnector = "AND";

        int intCurrDepositDtlSourceSelectedRowIndex = -1;

        decimal dcCurrentSourceOnhandAmt = 0;
        decimal dcCurrentSourceCrrDepositAmt = 0;

        DataTable searchQuery = new DataTable();

        DataTable dtSearchResult = new DataTable();
        DataTable dtNewDepositSource = new DataTable();


        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        dataBuilder getDataFromDb = new dataBuilder();



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
            string dateColName = "sold_date";
            //string docColName = "ref_no";
            string docColName = "COALESCE(CASE `ref_note` WHEN '' THEN NULL ELSE `ref_note` END , REF_NO )";

            if (this.cmbSourceType.SelectedItem.ToString() == "CRV")
            {
                dateColName = "DATETRX";
                docColName = "DOCUMENTNO";
            }
            else if (this.cmbSourceType.SelectedItem.ToString() == "Exemption")
            {
                dateColName = "DATEINVOICED";
                docColName = "DOCUMENTNO";
            }

            if (this.cmbDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria(dateColName, this.cmbDateLogic.SelectedItem.ToString(),
                    this.dtpDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbDocumentNumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria(docColName, this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumber.Text, "");
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


        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }


        private void setRemainingAmount()
        {
            decimal sourceAmount = 0;
            

            for (int soruceRowCounter = this.dtNewDepositSource.Rows.Count - 1;
                soruceRowCounter >= 0;
                soruceRowCounter--)
            {
                sourceAmount +=
                    decimal.Parse(this.dtNewDepositSource.Rows[soruceRowCounter]["AMOUNT"].ToString() == "" ?
                    "0" : this.dtNewDepositSource.Rows[soruceRowCounter]["AMOUNT"].ToString());
            }
            this.txtAmountRemaining.Text =
                (generalResultInformation.cashLineAmt - sourceAmount).ToString("N02"); ;
        }


        private void setRemainingAmount(decimal alterByAmount)
        {
            this.txtAmountRemaining.Text =
                (decimal.Parse(this.txtAmountRemaining.Text) + alterByAmount).ToString("N02");            
        }


        private void getOnhandSales()
        {
            
            DataTable onHandSales = 
                this.getDataFromDb.getSalesInfo(this.searchQuery, this.logicalConnector,
                    "", generalResultInformation.Station, "", generalResultInformation.concernedNode, 
                    "", triaStateBool.no, PAYMENTRULE.Cash, 100000, false, false, false, "AND");

            onHandSales.Columns.Add("TOTALDEPOSITED");
            onHandSales.Columns.Add("ONHANDAMT");

            
                for (int onhandSalesRC = onHandSales.Rows.Count - 1; onhandSalesRC >= 0; onhandSalesRC--)
                {
                    onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"] = "0";
                    onHandSales.Rows[onhandSalesRC]["ONHANDAMT"] = "0";
                    if (generalResultInformation.newCashSource.Rows.Count - 1 >= 0)
                    {

                        for (int newDepositRC = 0; newDepositRC <= generalResultInformation.newCashSource.Rows.Count - 1; newDepositRC++)
                        {
                            if (generalResultInformation.newCashSource.Rows[newDepositRC]["C_INVOICE_ID"].ToString() ==
                                onHandSales.Rows[onhandSalesRC]["ID"].ToString() &&
                                generalResultInformation.newCashSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                                onHandSales.Rows[onhandSalesRC]["STATION"].ToString() &&
                                generalResultInformation.newCashSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                                this.cmbSourceType.SelectedItem.ToString())
                            {
                                onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"] =
                                    decimal.Parse(onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"].ToString()) +
                                    decimal.Parse(generalResultInformation.newCashSource.Rows[newDepositRC]["AMOUNT"].ToString());

                                if (decimal.Parse(onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"].ToString()) ==
                                    decimal.Parse(onHandSales.Rows[onhandSalesRC]["total_amount"].ToString()) -
                                    decimal.Parse(onHandSales.Rows[onhandSalesRC]["with_holding"].ToString()))
                                {
                                    onHandSales.Rows.RemoveAt(onhandSalesRC);
                                    break;
                                }
                            }
                        }
                    }
                }

            
            for (int newDepositRC = 0; newDepositRC <= this.dtNewDepositSource.Rows.Count - 1; newDepositRC++)
            {       
                for(int onhandSalesRC = onHandSales.Rows.Count - 1; onhandSalesRC >= 0; onhandSalesRC--)
                {
                    if (this.dtNewDepositSource.Rows[newDepositRC]["C_INVOICE_ID"].ToString() ==
                        onHandSales.Rows[onhandSalesRC]["ID"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandSales.Rows[onhandSalesRC]["STATION"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {
                        onHandSales.Rows.RemoveAt(onhandSalesRC);
                        break;                        
                    }
                }
            }

            DataTable existingDeposit = new DataTable();
            DataTable customerInfo = new DataTable();
            string customerName = "";

            for (int onhandSalesRC = onHandSales.Rows.Count - 1; onhandSalesRC >= 0; onhandSalesRC--)
            {
                existingDeposit =
                    this.getDataFromDb.getC_CASHLINESOURCEInfo(null, "", "", "",  CashSourceType.Sales, "",
                        onHandSales.Rows[onhandSalesRC]["ID"].ToString(), "",
                        onHandSales.Rows[onhandSalesRC]["STATION"].ToString(), false,
                        false, "AND");
                
                
                for (int rowCounter = 0; rowCounter <= existingDeposit.Rows.Count - 1; rowCounter++)
                {
                    
                    onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"] =
                        decimal.Parse(onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"].ToString()) +
                        decimal.Parse(existingDeposit.Rows[rowCounter]["AMOUNT"].ToString());                    
                }

                if (Math.Abs(decimal.Parse(onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"].ToString()) - 
                        (
                         decimal.Parse(onHandSales.Rows[onhandSalesRC]["total_amount"].ToString()) -
                         decimal.Parse(onHandSales.Rows[onhandSalesRC]["with_holding"].ToString())
                         )
                        ) < decimal.Parse("0.01"))
                {
                    onHandSales.Rows.RemoveAt(onhandSalesRC);
                    continue;
                }


                onHandSales.Rows[onhandSalesRC]["ONHANDAMT"] =
                    decimal.Parse(onHandSales.Rows[onhandSalesRC]["total_amount"].ToString()) -
                        decimal.Parse(onHandSales.Rows[onhandSalesRC]["with_holding"].ToString()) - 
                    decimal.Parse(onHandSales.Rows[onhandSalesRC]["TOTALDEPOSITED"].ToString());

                customerName = onHandSales.Rows[onhandSalesRC]["customer_name"].ToString();

                if (customerName.Replace(" ","") == "")
                {
                    customerInfo =
                        this.getDataFromDb.getCustomersInfo(null, "",
                            onHandSales.Rows[onhandSalesRC]["id"].ToString(),
                            onHandSales.Rows[onhandSalesRC]["station"].ToString(),
                            "", "", triaStateBool.Ignor, false, "AND");

                    if (this.getDataFromDb.checkIfTableContainesData(customerInfo))
                    {
                        customerName = customerInfo.Rows[0]["customer_name"].ToString();
                    }
                    else                    
                    {
                        customerName = "Not Available";
                    }
                }

                DataRow drNewSearchResult = this.dtSearchResult.NewRow();

                drNewSearchResult["C_CASHLINE_ID"] = generalResultInformation.C_CASHLINE_ID;
                drNewSearchResult["DESCRIPTION"] = "";
                drNewSearchResult["SOURCETYPE"] = this.cmbSourceType.SelectedItem.ToString();
                drNewSearchResult["Customer"] = customerName;
                drNewSearchResult["C_INVOICE_ID"] = onHandSales.Rows[onhandSalesRC]["ID"].ToString();
                drNewSearchResult["ONHANDAMT"] = decimal.Parse(onHandSales.Rows[onhandSalesRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["AMOUNT"] = "0.00";
                drNewSearchResult["OVERUNDERAMT"] = decimal.Parse(onHandSales.Rows[onhandSalesRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["Document No"] = onHandSales.Rows[onhandSalesRC]["ref_no"];
                drNewSearchResult["Dated"] = DateTime.Parse(onHandSales.Rows[onhandSalesRC]["sold_date"].ToString()).ToString("dd-MMM-yyyy");
                drNewSearchResult["Invoiced"] = 
                    (decimal.Parse(onHandSales.Rows[onhandSalesRC]["total_amount"].ToString()) -
                        decimal.Parse(onHandSales.Rows[onhandSalesRC]["with_holding"].ToString())).ToString("N02");

                drNewSearchResult["STATION_ID"] = onHandSales.Rows[onhandSalesRC]["STATION"].ToString();

                drNewSearchResult["Sn"] = this.dtSearchResult.Rows.Count + 1;
                drNewSearchResult["Select"] = false;
                                

                this.dtSearchResult.Rows.Add(drNewSearchResult);
            }

        }

        private void getOnHandCRV()
        {
            DataTable onHandCRV =
                this.getDataFromDb.getC_PAYMENTInfo(this.searchQuery, this.logicalConnector,
                    "", "", "", DateTime.Now, false, tenderType.ignor, "", 
                    generalResultInformation.Station, false, false, "AND");

            onHandCRV.Columns.Add("TOTALDEPOSITED");
            onHandCRV.Columns.Add("ONHANDAMT");

            for (int onhandCRVRC = onHandCRV.Rows.Count - 1; onhandCRVRC >= 0; onhandCRVRC--)
            {
                onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"] = "0";
                onHandCRV.Rows[onhandCRVRC]["ONHANDAMT"] = "0";

                for (int newDepositRC = 0; newDepositRC <= generalResultInformation.newCashSource.Rows.Count - 1; newDepositRC++)
                {
                    if (generalResultInformation.newCashSource.Rows[newDepositRC]["C_PAYMENT_ID"].ToString() ==
                        onHandCRV.Rows[onhandCRVRC]["C_PAYMENT_ID"].ToString() &&
                        generalResultInformation.newCashSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandCRV.Rows[onhandCRVRC]["STATION_ID"].ToString() &&
                        generalResultInformation.newCashSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {
                        onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"] =
                            decimal.Parse(onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"].ToString()) +
                            decimal.Parse(generalResultInformation.newCashSource.Rows[newDepositRC]["AMOUNT"].ToString());

                        if (decimal.Parse(onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"].ToString()) ==
                            decimal.Parse(onHandCRV.Rows[onhandCRVRC]["PAYAMT"].ToString()))
                        {
                            onHandCRV.Rows.RemoveAt(onhandCRVRC);
                            break;
                        }
                    }
                }
            }


            for (int newDepositRC = 0; newDepositRC <= this.dtNewDepositSource.Rows.Count - 1; newDepositRC++)
            {
                for (int onhandCRVRC = onHandCRV.Rows.Count - 1; onhandCRVRC >= 0; onhandCRVRC--)
                {
                    if (this.dtNewDepositSource.Rows[newDepositRC]["C_PAYMENT_ID"].ToString() ==
                        onHandCRV.Rows[onhandCRVRC]["C_PAYMENT_ID"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandCRV.Rows[onhandCRVRC]["STATION_ID"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {
                        onHandCRV.Rows.RemoveAt(onhandCRVRC);
                        break;
                    }
                }
            }

            DataTable existingDeposit = new DataTable();
            DataTable customerInfo = new DataTable();
            string customerName = "";

            for (int onhandCRVRC = onHandCRV.Rows.Count - 1; onhandCRVRC >= 0; onhandCRVRC--)
            {
                existingDeposit =
                    this.getDataFromDb.getC_CASHLINESOURCEInfo(null, "", "", "", CashSourceType.CRV,
                        onHandCRV.Rows[onhandCRVRC]["C_PAYMENT_ID"].ToString(), "", "",
                        onHandCRV.Rows[onhandCRVRC]["STATION_ID"].ToString(), false,
                        false, "AND");


                for (int rowCounter = 0; rowCounter <= existingDeposit.Rows.Count - 1; rowCounter++)
                {

                    onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"] =
                        decimal.Parse(onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"].ToString()) +
                        decimal.Parse(existingDeposit.Rows[rowCounter]["AMOUNT"].ToString());
                }

                if (decimal.Parse(onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"].ToString()) ==
                        decimal.Parse(onHandCRV.Rows[onhandCRVRC]["PAYAMT"].ToString()))
                {
                    onHandCRV.Rows.RemoveAt(onhandCRVRC);
                    continue;
                }

                onHandCRV.Rows[onhandCRVRC]["ONHANDAMT"] =
                    decimal.Parse(onHandCRV.Rows[onhandCRVRC]["PAYAMT"].ToString()) -
                    decimal.Parse(onHandCRV.Rows[onhandCRVRC]["TOTALDEPOSITED"].ToString());

                customerInfo = 
                    this.getDataFromDb.getCustomersInfo(null, "",
                        onHandCRV.Rows[onhandCRVRC]["C_BPARTNER_ID"].ToString(),
                        onHandCRV.Rows[onhandCRVRC]["STATION_ID"].ToString(),
                        "", "", triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(customerInfo))
                {
                    customerName = customerInfo.Rows[0]["customer_name"].ToString();
                }
                else
                {
                    customerName = "Not Available";
                }

                DataRow drNewSearchResult = this.dtSearchResult.NewRow();

                drNewSearchResult["C_CASHLINE_ID"] = generalResultInformation.C_CASHLINE_ID;
                drNewSearchResult["DESCRIPTION"] = "";
                drNewSearchResult["SOURCETYPE"] = this.cmbSourceType.SelectedItem.ToString();
                drNewSearchResult["Customer"] = customerName;
                drNewSearchResult["C_PAYMENT_ID"] = onHandCRV.Rows[onhandCRVRC]["C_PAYMENT_ID"].ToString();
                drNewSearchResult["ONHANDAMT"] = decimal.Parse(onHandCRV.Rows[onhandCRVRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["AMOUNT"] = "0.00";
                drNewSearchResult["OVERUNDERAMT"] = decimal.Parse(onHandCRV.Rows[onhandCRVRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["Document No"] = onHandCRV.Rows[onhandCRVRC]["DOCUMENTNO"];
                drNewSearchResult["Dated"] = DateTime.Parse(onHandCRV.Rows[onhandCRVRC]["DATETRX"].ToString()).ToString("dd-MMM-yyyy");
                drNewSearchResult["Invoiced"] =
                    (decimal.Parse(onHandCRV.Rows[onhandCRVRC]["PAYAMT"].ToString())).ToString("N02");

                drNewSearchResult["STATION_ID"] = onHandCRV.Rows[onhandCRVRC]["STATION_ID"].ToString();

                drNewSearchResult["Sn"] = this.dtSearchResult.Rows.Count + 1;
                drNewSearchResult["Select"] = false;


                this.dtSearchResult.Rows.Add(drNewSearchResult);
            }
        }

        private void getOnHandExemption()
        {
            DataTable onHandExempiton =
                this.getDataFromDb.getC_EXEMPTIONInfo(this.searchQuery, this.logicalConnector,
                    "", "", "", DateTime.Now, false, exemptionType.ignor,
                    generalResultInformation.Station, false, false, "AND");

            onHandExempiton.Columns.Add("TOTALDEPOSITED");
            onHandExempiton.Columns.Add("ONHANDAMT");

            for (int onhandExpRC = onHandExempiton.Rows.Count - 1; onhandExpRC >= 0; onhandExpRC--)
            {
                onHandExempiton.Rows[onhandExpRC]["TOTALDEPOSITED"] = "0";
                onHandExempiton.Rows[onhandExpRC]["ONHANDAMT"] = "0";

                for (int newDepositRC = 0; newDepositRC <= generalResultInformation.newCashSource.Rows.Count - 1; newDepositRC++)
                {
                    if (generalResultInformation.newCashSource.Rows[newDepositRC]["C_EXEMPTION_ID"].ToString() ==
                        onHandExempiton.Rows[onhandExpRC]["C_EXEMPTION_ID"].ToString() &&
                        generalResultInformation.newCashSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandExempiton.Rows[onhandExpRC]["STATION_ID"].ToString() &&
                        generalResultInformation.newCashSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {   
                        onHandExempiton.Rows.RemoveAt(onhandExpRC);
                        break;
                    }
                }
            }


            for (int newDepositRC = 0; newDepositRC <= this.dtNewDepositSource.Rows.Count - 1; newDepositRC++)
            {
                for (int onhandExpRC = onHandExempiton.Rows.Count - 1; onhandExpRC >= 0; onhandExpRC--)
                {
                    if (this.dtNewDepositSource.Rows[newDepositRC]["C_EXEMPTION_ID"].ToString() ==
                        onHandExempiton.Rows[onhandExpRC]["C_EXEMPTION_ID"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandExempiton.Rows[onhandExpRC]["STATION_ID"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {
                        onHandExempiton.Rows.RemoveAt(onhandExpRC);
                        break;
                    }
                }
            }

            DataTable inCRVExempiton = new DataTable();
            for (int onhandExpRC = onHandExempiton.Rows.Count - 1; onhandExpRC >= 0; onhandExpRC--)
            {
                inCRVExempiton =
                    this.getDataFromDb.getC_PAYMENTALLOCATEInfo(null, "", "", "", 
                        onHandExempiton.Rows[onhandExpRC]["C_EXEMPTION_ID"].ToString(), triaStateBool.yes,
                        generalResultInformation.Station, false, false, "AND");
                if(this.getDataFromDb.checkIfTableContainesData(inCRVExempiton))
                    onHandExempiton.Rows.RemoveAt(onhandExpRC);                
            }

            DataTable existingDeposit = new DataTable();
            DataTable customerInfo = new DataTable();
            string customerName = "";

            for (int onhandExpRC = onHandExempiton.Rows.Count - 1; onhandExpRC >= 0; onhandExpRC--)
            {
                existingDeposit =
                    this.getDataFromDb.getC_CASHLINESOURCEInfo(null, "", "", "", CashSourceType.Exemption,"","",
                        onHandExempiton.Rows[onhandExpRC]["C_EXEMPTION_ID"].ToString(),
                        onHandExempiton.Rows[onhandExpRC]["STATION_ID"].ToString(), false,
                        false, "AND");


                if (this.getDataFromDb.checkIfTableContainesData(existingDeposit))
                {
                    onHandExempiton.Rows.RemoveAt(onhandExpRC);
                    continue;
                }

                onHandExempiton.Rows[onhandExpRC]["ONHANDAMT"] =
                    decimal.Parse(onHandExempiton.Rows[onhandExpRC]["EXEMPTEDAMT"].ToString()) * -1;

                customerInfo =
                        this.getDataFromDb.getCustomersInfo(null, "",
                            onHandExempiton.Rows[onhandExpRC]["C_BPARTNER_ID"].ToString(),
                            onHandExempiton.Rows[onhandExpRC]["STATION_ID"].ToString(),
                            "", "", triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(customerInfo))
                {
                    customerName = customerInfo.Rows[0]["customer_name"].ToString();
                }
                else
                {
                    customerName = "Not Available";
                }

                DataRow drNewSearchResult = this.dtSearchResult.NewRow();

                drNewSearchResult["C_CASHLINE_ID"] = generalResultInformation.C_CASHLINE_ID;
                drNewSearchResult["DESCRIPTION"] = "";
                drNewSearchResult["SOURCETYPE"] = this.cmbSourceType.SelectedItem.ToString();
                drNewSearchResult["Customer"] = customerName;
                drNewSearchResult["C_EXEMPTION_ID"] = onHandExempiton.Rows[onhandExpRC]["C_EXEMPTION_ID"].ToString();
                drNewSearchResult["ONHANDAMT"] = decimal.Parse(onHandExempiton.Rows[onhandExpRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["AMOUNT"] = "0.00";
                drNewSearchResult["OVERUNDERAMT"] = decimal.Parse(onHandExempiton.Rows[onhandExpRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["Document No"] = onHandExempiton.Rows[onhandExpRC]["DOCUMENTNO"];
                drNewSearchResult["Dated"] = DateTime.Parse(onHandExempiton.Rows[onhandExpRC]["DATEINVOICED"].ToString()).ToString("dd-MMM-yyyy");
                drNewSearchResult["Invoiced"] =
                    (decimal.Parse(onHandExempiton.Rows[onhandExpRC]["EXEMPTEDAMT"].ToString()) * -1).ToString("N02");

                drNewSearchResult["STATION_ID"] = onHandExempiton.Rows[onhandExpRC]["STATION_ID"].ToString();

                drNewSearchResult["Sn"] = this.dtSearchResult.Rows.Count + 1;
                drNewSearchResult["Select"] = false;


                this.dtSearchResult.Rows.Add(drNewSearchResult);
            }
        }

        private void getOnHandRefunds()
        {

            DataTable onHandRefunds =
                this.getDataFromDb.getRefundsInfo(this.searchQuery, this.logicalConnector,
                    "", generalResultInformation.Station, "", generalResultInformation.concernedNode,
                    "", false, false, "AND");

            onHandRefunds.Columns.Add("TOTALDEPOSITED");
            onHandRefunds.Columns.Add("ONHANDAMT");

            for (int onhandRefundsRC = onHandRefunds.Rows.Count - 1; onhandRefundsRC >= 0; onhandRefundsRC--)
            {
                onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"] = "0";
                onHandRefunds.Rows[onhandRefundsRC]["ONHANDAMT"] = "0";

                for (int newDepositRC = 0; newDepositRC <= generalResultInformation.newCashSource.Rows.Count - 1; newDepositRC++)
                {
                    if (generalResultInformation.newCashSource.Rows[newDepositRC]["C_INVOICE_ID"].ToString() ==
                        onHandRefunds.Rows[onhandRefundsRC]["ID"].ToString() &&
                        generalResultInformation.newCashSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandRefunds.Rows[onhandRefundsRC]["STATION"].ToString() &&
                        generalResultInformation.newCashSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {
                        onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"] =
                            decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"].ToString()) +
                            decimal.Parse(generalResultInformation.newCashSource.Rows[newDepositRC]["AMOUNT"].ToString());

                        if (decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"].ToString()) ==
                            decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["total_amount"].ToString()) -
                            decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["with_holding"].ToString()))
                        {
                            onHandRefunds.Rows.RemoveAt(onhandRefundsRC);
                            break;
                        }
                    }
                }
            }


            for (int newDepositRC = 0; newDepositRC <= this.dtNewDepositSource.Rows.Count - 1; newDepositRC++)
            {
                for (int onhandRefundsRC = onHandRefunds.Rows.Count - 1; onhandRefundsRC >= 0; onhandRefundsRC--)
                {
                    if (this.dtNewDepositSource.Rows[newDepositRC]["C_INVOICE_ID"].ToString() ==
                        onHandRefunds.Rows[onhandRefundsRC]["ID"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["STATION_ID"].ToString() ==
                        onHandRefunds.Rows[onhandRefundsRC]["STATION"].ToString() &&
                        this.dtNewDepositSource.Rows[newDepositRC]["SOURCETYPE"].ToString() ==
                        this.cmbSourceType.SelectedItem.ToString())
                    {
                        onHandRefunds.Rows.RemoveAt(onhandRefundsRC);
                        break;
                    }
                }
            }

            DataTable existingDeposit = new DataTable();
            DataTable customerInfo = new DataTable();
            string customerName = "";

            for (int onhandRefundsRC = onHandRefunds.Rows.Count - 1; onhandRefundsRC >= 0; onhandRefundsRC--)
            {
                existingDeposit =
                    this.getDataFromDb.getC_CASHLINESOURCEInfo(null, "", "", "", CashSourceType.Refund, "",
                        onHandRefunds.Rows[onhandRefundsRC]["ID"].ToString(), "",
                        onHandRefunds.Rows[onhandRefundsRC]["STATION"].ToString(), false,
                        false, "AND");


                for (int rowCounter = 0; rowCounter <= existingDeposit.Rows.Count - 1; rowCounter++)
                {

                    onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"] =
                        decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"].ToString()) +
                        decimal.Parse(existingDeposit.Rows[rowCounter]["AMOUNT"].ToString());
                }

                if (decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"].ToString()) ==
                        ((decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["total_amount"].ToString()) -
                        decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["with_holding"].ToString()))) * -1)
                {
                    onHandRefunds.Rows.RemoveAt(onhandRefundsRC);
                    continue;
                }

                onHandRefunds.Rows[onhandRefundsRC]["ONHANDAMT"] =
                    (decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["total_amount"].ToString()) -
                        decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["with_holding"].ToString()) -
                    decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["TOTALDEPOSITED"].ToString())) * -1;

                customerName = onHandRefunds.Rows[onhandRefundsRC]["customer_name"].ToString();

                if (customerName.Replace(" ", "") == "")
                {
                    customerInfo = 
                        this.getDataFromDb.getCustomersInfo(null, "",
                            onHandRefunds.Rows[onhandRefundsRC]["id"].ToString(),
                            onHandRefunds.Rows[onhandRefundsRC]["station"].ToString(),
                            "", "", triaStateBool.Ignor, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(customerInfo))
                    {
                        customerName = customerInfo.Rows[0]["customer_name"].ToString();
                    }
                    else
                    {
                        customerName = "Not Available";
                    }
                }

                DataRow drNewSearchResult = this.dtSearchResult.NewRow();

                drNewSearchResult["C_CASHLINE_ID"] = generalResultInformation.C_CASHLINE_ID;
                drNewSearchResult["DESCRIPTION"] = "";
                drNewSearchResult["SOURCETYPE"] = this.cmbSourceType.SelectedItem.ToString();
                drNewSearchResult["Customer"] = customerName;
                drNewSearchResult["C_INVOICE_ID"] = onHandRefunds.Rows[onhandRefundsRC]["ID"].ToString();
                drNewSearchResult["ONHANDAMT"] = decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["AMOUNT"] = "0.00";
                drNewSearchResult["OVERUNDERAMT"] = decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["ONHANDAMT"].ToString()).ToString("N02");
                drNewSearchResult["Document No"] = onHandRefunds.Rows[onhandRefundsRC]["ref_no"];
                drNewSearchResult["Dated"] = DateTime.Parse(onHandRefunds.Rows[onhandRefundsRC]["sold_date"].ToString()).ToString("dd-MMM-yyyy");
                drNewSearchResult["Invoiced"] =
                    ((decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["total_amount"].ToString()) -
                        decimal.Parse(onHandRefunds.Rows[onhandRefundsRC]["with_holding"].ToString())) * -1).ToString("N02");

                drNewSearchResult["STATION_ID"] = onHandRefunds.Rows[onhandRefundsRC]["STATION"].ToString();

                drNewSearchResult["Sn"] = this.dtSearchResult.Rows.Count + 1;
                drNewSearchResult["Select"] = false;


                this.dtSearchResult.Rows.Add(drNewSearchResult);
            }

        }



        private void frmCashSource_Load(object sender, EventArgs e)
        {
            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            if (generalResultInformation.C_CASHLINE_ID == "")
                this.Close();

            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDateLogic.SelectedItem = "IGNOR";            
            this.cmbSourceType.SelectedIndex = 0;

            this.dtSearchResult =
                generalResultInformation.newCashSource.Clone();

            this.dtSearchResult.Columns.
                    Add("Select", Type.GetType("System.Boolean"));

            this.dtSearchResult.Columns.
                    Add("Customer", Type.GetType("System.String"));

            this.dtSearchResult.Columns["Select"].SetOrdinal(0);

            this.dtgSearchResult.DataSource = this.dtSearchResult;

            this.dtgSearchResult.Columns["C_CASHLINESOURCE_ID"].Visible = false;
            this.dtgSearchResult.Columns["C_CASHLINE_ID"].Visible = false;
            this.dtgSearchResult.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgSearchResult.Columns["AD_ORG_ID"].Visible = false;
            this.dtgSearchResult.Columns["ISACTIVE"].Visible = false;
            this.dtgSearchResult.Columns["CREATED"].Visible = false;
            this.dtgSearchResult.Columns["CREATEDBY"].Visible = false;
            this.dtgSearchResult.Columns["UPDATED"].Visible = false;
            this.dtgSearchResult.Columns["UPDATEDBY"].Visible = false;
            this.dtgSearchResult.Columns["DESCRIPTION"].Visible = false;
            this.dtgSearchResult.Columns["SOURCETYPE"].Visible = false;
            this.dtgSearchResult.Columns["C_PAYMENT_ID"].Visible = false;
            this.dtgSearchResult.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgSearchResult.Columns["C_EXEMPTION_ID"].Visible = false;
            this.dtgSearchResult.Columns["AMOUNT"].Visible = false;
            this.dtgSearchResult.Columns["OVERUNDERAMT"].Visible = false;
            this.dtgSearchResult.Columns["STATION_ID"].Visible = false;

            this.dtgSearchResult.Columns["Select"].HeaderText = "";
            this.dtgSearchResult.Columns["ONHANDAMT"].HeaderText = "On Hand";


            this.dtNewDepositSource =
                generalResultInformation.newCashSource.Clone();

            for (int rowCounter = 0; rowCounter <= generalResultInformation.newCashSource.Rows.Count - 1; rowCounter++)
            {
                if (generalResultInformation.newCashSource.Rows[rowCounter]["C_CASHLINE_ID"].ToString() ==
                    generalResultInformation.C_CASHLINE_ID)
                {
                    DataRow drDepositSource = this.dtNewDepositSource.NewRow();
                    foreach (DataColumn dtCol in this.dtNewDepositSource.Columns)
                    {
                        string colName = dtCol.ColumnName;
                        drDepositSource[dtCol] =
                            generalResultInformation.newCashSource.Rows[rowCounter][dtCol.ColumnName];
                    }
                    this.dtNewDepositSource.Rows.Add(drDepositSource);
                }
            }

            for (int rowCounter = generalResultInformation.newCashSource.Rows.Count - 1; rowCounter >=0 ; rowCounter--)
            {
                if (generalResultInformation.newCashSource.Rows[rowCounter]["C_CASHLINE_ID"].ToString() ==
                    generalResultInformation.C_CASHLINE_ID)
                {
                    generalResultInformation.newCashSource.Rows.RemoveAt(rowCounter);
                }
            }


            this.dtNewDepositSource.Columns.Add("remove");
            this.dtNewDepositSource.Columns["remove"].SetOrdinal(0);

            this.dtgNewCashSource.DataSource =
                this.dtNewDepositSource;


            this.dtgNewCashSource.Columns["C_CASHLINESOURCE_ID"].Visible = false;
            this.dtgNewCashSource.Columns["C_CASHLINE_ID"].Visible = false;
            this.dtgNewCashSource.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgNewCashSource.Columns["AD_ORG_ID"].Visible = false;
            this.dtgNewCashSource.Columns["ISACTIVE"].Visible = false;
            this.dtgNewCashSource.Columns["CREATED"].Visible = false;
            this.dtgNewCashSource.Columns["CREATEDBY"].Visible = false;
            this.dtgNewCashSource.Columns["UPDATED"].Visible = false;
            this.dtgNewCashSource.Columns["UPDATEDBY"].Visible = false;
            this.dtgNewCashSource.Columns["DESCRIPTION"].Visible = false;            
            this.dtgNewCashSource.Columns["C_PAYMENT_ID"].Visible = false;
            this.dtgNewCashSource.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgNewCashSource.Columns["C_EXEMPTION_ID"].Visible = false;                        
            this.dtgNewCashSource.Columns["STATION_ID"].Visible = false;

            this.dtgNewCashSource.Columns["remove"].HeaderText = "";
            this.dtgNewCashSource.Columns["ONHANDAMT"].HeaderText = "On hand";
            this.dtgNewCashSource.Columns["AMOUNT"].HeaderText = "Deposited";
            this.dtgNewCashSource.Columns["OVERUNDERAMT"].HeaderText = "Remaining";
            this.dtgNewCashSource.Columns["SOURCETYPE"].HeaderText = "Type";

            this.dtgNewCashSource.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

            foreach (Control cntl in this.Controls)
            {
                cntl.Enabled = !generalResultInformation.isCashLineProcessed && cntl.Enabled;
            }

            this.groupBox1.Enabled = true;
            this.dtgNewCashSource.Enabled = true;

            this.setRemainingAmount();

            foreach (DataGridViewColumn columns in this.dtgSearchResult.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            foreach (DataGridViewColumn columns in this.dtgNewCashSource.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            this.ControlBox = generalResultInformation.isCashLineProcessed;
            
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
                this.dtpDateTo.Visible = true;
            else
                this.dtpDateTo.Visible = false;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            this.establishSearchCriterion();
            this.dtSearchResult.Rows.Clear();
            this.ckSelectAll.Checked = false;

            if (this.cmbSourceType.SelectedItem.ToString() == "Sales")
            { 
                this.getOnhandSales(); 
            }
            else if (this.cmbSourceType.SelectedItem.ToString() == "CRV")
            {
                this.getOnHandCRV();
            }
            else if (this.cmbSourceType.SelectedItem.ToString() == "Exemption")
            {
                this.getOnHandExemption();
            }
            else if (this.cmbSourceType.SelectedItem.ToString() == "Refund")
            {
                this.getOnHandRefunds();
            }
        }


        private void dtgSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgSearchResult.SelectedRows.Count < 1 )
                return;

            int currentSelectedRowIndex = 
                this.dtgSearchResult.SelectedRows[0].Index;

            if (this.dtgSearchResult.CurrentCell.OwningColumn.Index == 0 &&
                this.dtgSearchResult.CurrentCell.OwningColumn.Name == "Select" &&
                this.dtgSearchResult.CurrentCell.OwningColumn.HeaderText == "")
            {
                this.dtgSearchResult.CurrentCell.Value =
                        !(Convert.ToBoolean(this.dtgSearchResult.CurrentCell.Value.ToString()));
                this.dtSearchResult.Rows[currentSelectedRowIndex]["Select"] =
                    (Convert.ToBoolean(this.dtgSearchResult.CurrentCell.Value.ToString()));
            }
        }


        private void ckSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int rowCounter = 0; rowCounter <= this.dtSearchResult.Rows.Count - 1; rowCounter++)
            { 
                this.dtSearchResult.Rows[rowCounter]["Select"] =
                    !(Convert.ToBoolean(this.dtSearchResult.Rows[rowCounter]["Select"].ToString()));
            }
        }

        private bool isSourceConsistant()
        {            
            //Row to pick as Index to compare with the rest
            int rowIndexToCompare = -1;

            //Select the first row which is selected
            for (int rowCounter = 0; rowCounter <= this.dtSearchResult.Rows.Count - 1; rowCounter++)
            {
                if (Convert.ToBoolean(this.dtSearchResult.Rows[rowCounter]["Select"].ToString()))
                {
                    rowIndexToCompare = rowCounter;
                    break;
                }
            }

            //If NO row selected return Fasle "Inconsistant Source"
            if (rowIndexToCompare == -1)
            {
                return false;
            }

            //Check if selected row is refund AND fetch its Original sales.

            DateTime sourceDate;
            string sourceType = 
                this.dtSearchResult.Rows[rowIndexToCompare]["SOURCETYPE"].ToString();

            if (sourceType == "Refund")
            {
                DataTable refundInfo =
                    this.getDataFromDb.getRefundsInfo(null, "",
                                this.dtSearchResult.Rows[rowIndexToCompare]["C_INVOICE_ID"].ToString(),
                                this.dtSearchResult.Rows[rowIndexToCompare]["STATION_ID"].ToString(),
                                "", "", "", false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(refundInfo))
                {
                    MessageBox.Show("No Infomation found for Refund " +
                        this.dtSearchResult.Rows[rowIndexToCompare]["Document No"].ToString(),
                        "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (refundInfo.Rows[0]["SALES_ID"].ToString() == "" ||
                    refundInfo.Rows[0]["SALES_ID"].ToString() == "0")
                {
                    MessageBox.Show("No Sales Infomation found for Refund " +
                        this.dtSearchResult.Rows[rowIndexToCompare]["Document No"].ToString(),
                        "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }                
                
                DataTable salesInfo =
                    this.getDataFromDb.getSalesInfo(null, "",
                        refundInfo.Rows[0]["SALES_ID"].ToString(),
                        refundInfo.Rows[0]["STATION"].ToString(),
                        "",
                        refundInfo.Rows[0]["NODE"].ToString(),
                        "", triaStateBool.Ignor, false, false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(salesInfo))
                {
                    MessageBox.Show("No Sales Infomation found for Refund " +
                        this.dtSearchResult.Rows[rowIndexToCompare]["Document No"].ToString(),
                        "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                sourceDate = DateTime.Parse(salesInfo.Rows[0]["sold_date"].ToString());

            }
            else
            {
                sourceDate =
                    DateTime.Parse(this.dtSearchResult.Rows[rowIndexToCompare]["Dated"].ToString());
            }

            for (int rowCounter = rowIndexToCompare + 1; rowCounter <= this.dtSearchResult.Rows.Count - 1; rowCounter++)
            {
                if (!Convert.ToBoolean(this.dtSearchResult.Rows[rowCounter]["Select"].ToString()))
                {
                    continue;
                }

                // If Source is Exemption Skip
                if (this.dtSearchResult.Rows[rowCounter]["SOURCETYPE"].ToString() == "Exemption")
                 {
                     continue;
                 }

                //Source is [Sales/Refun XNOR CRV]
                /**
                 * if (
                        !(
                            (this.dtSearchResult.Rows[rowCounter]["SOURCETYPE"].ToString() == "Sales" ||
                            this.dtSearchResult.Rows[rowCounter]["SOURCETYPE"].ToString() == "Refund") 
                            ^
                            (sourceType == "CRV")
                        )
                    )
                {
                    MessageBox.Show("CRV and Sales Could not be accepted simultaneously.",
                        "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
                 */

                // If Source is CRV Skip...Source Date Does not matter
                if (this.dtSearchResult.Rows[rowCounter]["SOURCETYPE"].ToString() == "CRV")
                {
                    continue;
                }

                if (this.dtSearchResult.Rows[rowCounter]["SOURCETYPE"].ToString() == "Refund")
                {
                    DataTable refundInfo =
                    this.getDataFromDb.getRefundsInfo(null, "",
                                this.dtSearchResult.Rows[rowCounter]["C_INVOICE_ID"].ToString(),
                                this.dtSearchResult.Rows[rowCounter]["STATION_ID"].ToString(),
                                "", "", "", false, false, "AND");

                    if (!this.getDataFromDb.checkIfTableContainesData(refundInfo))
                    {
                        MessageBox.Show("No Refund Infomation found for Refund " +
                                this.dtSearchResult.Rows[rowIndexToCompare]["Document No"].ToString(),
                                "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (refundInfo.Rows[0]["SALES_ID"].ToString() == "" ||
                        refundInfo.Rows[0]["SALES_ID"].ToString() == "0")
                    {
                        MessageBox.Show("No Sales Infomation found for Refund " +
                           this.dtSearchResult.Rows[rowIndexToCompare]["Document No"].ToString(),
                           "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    DataTable salesInfo =
                        this.getDataFromDb.getSalesInfo(null, "",
                            refundInfo.Rows[0]["SALES_ID"].ToString(),
                            refundInfo.Rows[0]["STATION"].ToString(),
                            "",
                            refundInfo.Rows[0]["NODE"].ToString(),
                            "", triaStateBool.Ignor, false, false, false, "AND");

                    if (!this.getDataFromDb.checkIfTableContainesData(salesInfo))
                    {
                        MessageBox.Show("No Sales Infomation found for Refund " +
                           this.dtSearchResult.Rows[rowIndexToCompare]["Document No"].ToString(),
                           "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (sourceDate.Date.CompareTo(DateTime.Parse(salesInfo.Rows[0]["sold_date"].ToString()).Date) != 0)
                    {
                        MessageBox.Show("Sales/Refunds with Different date Could not be accepted simultaneously.",
                           "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; 
                    }

                }
                else
                {
                    if (sourceDate.Date.CompareTo(DateTime.Parse(this.dtSearchResult.Rows[rowCounter]["Dated"].ToString()).Date) != 0)
                    {
                        MessageBox.Show("Sales/Refunds with Different date Could not be accepted simultaneously.",
                           "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    } 
                }
            }

            //Check if Source type and date confirm with already selected sources.
            //Checking the first entry sufice since the rest of the entry is already consistent with the first one.
            // If Source is Exemption Skip

            if (this.getDataFromDb.checkIfTableContainesData(this.dtNewDepositSource) && sourceType != "Exemption")
            {
                for (int rowCounter = 0; rowCounter <= this.dtNewDepositSource.Rows.Count - 1; rowCounter++)
                {
                    if (this.dtNewDepositSource.Rows[rowCounter]["SOURCETYPE"].ToString() == "Exemption")
                    {
                        continue;
                    }

                    //Source is [Sales/Refun XNOR CRV]
                    if (
                            !(
                                (this.dtNewDepositSource.Rows[rowCounter]["SOURCETYPE"].ToString() == "Sales" ||
                                this.dtNewDepositSource.Rows[rowCounter]["SOURCETYPE"].ToString() == "Refund")
                                ^
                                (sourceType == "CRV")
                            )
                        )
                    {
                        MessageBox.Show("CRV and Sales Could not be accepted simultaneously.",
                            "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // If Source is CRV Skip...Source Date Does not matter
                    if (this.dtNewDepositSource.Rows[rowCounter]["SOURCETYPE"].ToString() == "CRV")
                    {
                        break;
                    }

                    if (this.dtNewDepositSource.Rows[rowCounter]["SOURCETYPE"].ToString() == "Refund")
                    {
                        DataTable refundInfo =
                        this.getDataFromDb.getRefundsInfo(null, "",
                                    this.dtNewDepositSource.Rows[rowCounter]["C_INVOICE_ID"].ToString(),
                                    this.dtNewDepositSource.Rows[rowCounter]["STATION_ID"].ToString(),
                                    "", "", "", false, false, "AND");

                        DataTable salesInfo =
                            this.getDataFromDb.getSalesInfo(null, "",
                                refundInfo.Rows[0]["SALES_ID"].ToString(),
                                refundInfo.Rows[0]["STATION"].ToString(),
                                "",
                                refundInfo.Rows[0]["NODE"].ToString(),
                                "", triaStateBool.Ignor, false, false, false, "AND");

                        if (sourceDate.Date.CompareTo(DateTime.Parse(salesInfo.Rows[0]["sold_date"].ToString()).Date) != 0)
                        {
                            MessageBox.Show("Sales/Refunds with Different date Could not be accepted simultaneously.",
                               "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        if (sourceDate.Date.CompareTo(DateTime.Parse(this.dtNewDepositSource.Rows[rowCounter]["Dated"].ToString()).Date) != 0)
                        {
                            MessageBox.Show("Sales/Refunds with Different date Could not be accepted simultaneously.",
                               "POS Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    //Checking the first entry sufice since the rest of the entry is already consistent with the first one.
                    break;
                }
            }
            return true;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (dbSettingInformationHandler.ControlDepositSourceConsistency)
            {
                if (!this.isSourceConsistant())
                {
                    return;
                }
            }

            for (int rowCounter = this.dtSearchResult.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (Convert.ToBoolean(this.dtSearchResult.Rows[rowCounter]["Select"].ToString()))
                {
                    DataRow drNewCashSource = this.dtNewDepositSource.NewRow();
                    foreach (DataColumn dtCol in this.dtNewDepositSource.Columns)
                    {
                        if (this.dtSearchResult.Columns.Contains(dtCol.ColumnName))
                            drNewCashSource[dtCol] = this.dtSearchResult.Rows[rowCounter][dtCol.ColumnName];
                    }
                    drNewCashSource["Sn"] = this.dtNewDepositSource.Rows.Count + 1;
                    drNewCashSource["remove"] = "remove";
                    drNewCashSource["AMOUNT"] = drNewCashSource["ONHANDAMT"];
                    drNewCashSource["OVERUNDERAMT"] = "0.00";

                    this.dtNewDepositSource.Rows.Add(drNewCashSource);
                    this.dtSearchResult.Rows.RemoveAt(rowCounter);
                }
            }
            this.setRemainingAmount();
            if(this.dtgNewCashSource.SelectedRows.Count > 0)
                this.dtgNewCashSource.Rows[this.dtgNewCashSource.SelectedRows[0].Index].Selected = false;
        }


        private void dtgNewCashSource_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dcCurrentSourceOnhandAmt = 0;
            this.dcCurrentSourceCrrDepositAmt = 0;
            this.ntbDeposited.Amount = "0";
            this.txtOnHand.Text = "0";
            this.txtDescriptionSrc.Text = "";

            this.cmdModify.Enabled = false;

            
            if (this.dtgNewCashSource.SelectedRows.Count < 1 ||
                generalResultInformation.isCashLineProcessed)
            {
                return;
            }

            this.intCurrDepositDtlSourceSelectedRowIndex =
                this.dtgNewCashSource.SelectedRows[0].Index;


            if (this.dtgNewCashSource.CurrentCell != null)
            {
                if (this.dtgNewCashSource.CurrentCell.OwningColumn.Index == 0 &&
                    this.dtgNewCashSource.CurrentCell.OwningColumn.Name == "remove" &&
                    this.dtgNewCashSource.CurrentCell.Value.ToString() == "remove" &&
                    this.dtgNewCashSource.CurrentCell.OwningColumn.HeaderText == "")
                {
                    decimal removedDepositAmount =
                        decimal.Parse(this.dtNewDepositSource.Rows[intCurrDepositDtlSourceSelectedRowIndex]["AMOUNT"].ToString());

                    this.dtNewDepositSource.Rows.RemoveAt(intCurrDepositDtlSourceSelectedRowIndex);

                    this.setRemainingAmount(removedDepositAmount);
                    
                    this.intCurrDepositDtlSourceSelectedRowIndex = -1;
                }
                else
                {
                    if (this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].
                            Cells["SOURCETYPE"].Value.ToString() == "Exemption" ||
                        this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].
                            Cells["SOURCETYPE"].Value.ToString() == "Refund")
                        return;

                    this.dcCurrentSourceCrrDepositAmt =
                        decimal.Parse(this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].
                            Cells["AMOUNT"].Value.ToString());

                    this.dcCurrentSourceOnhandAmt =
                        decimal.Parse(this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].
                            Cells["ONHANDAMT"].Value.ToString());

                    this.ntbDeposited.Amount =
                        this.dcCurrentSourceCrrDepositAmt.ToString();

                    this.txtDescriptionSrc.Text =
                        this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].
                            Cells["DESCRIPTION"].Value.ToString();
                    
                    this.txtOnHand.Text =
                        decimal.Parse(this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].
                            Cells["OVERUNDERAMT"].Value.ToString()).ToString("N02");
                    
                    this.cmdModify.Enabled = true;
                }
            }

        }


        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(this.txtOnHand.Text).CompareTo(generalResultInformation.overAmtLimit) == -1)
            {
                if (
                   MessageBox.Show("Amount Exceeds Maximum Payment amount allowable." +
                       "\n Enter pass key to proceed.", "New Deposit",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (!generalResultInformation.securityPassKeyCorrect)
                    {
                        MessageBox.Show("Amount Exceeds Maximum Payment amount allowable.",
                        "New Deposit", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {                    
                    return;
                }
            }
            else if (decimal.Parse(this.txtOnHand.Text).CompareTo(new decimal(-0.5)) == -1)
            {
                if(MessageBox.Show("Amount Is Over sales. Do you like to proceed.",
                    "New Deposit", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.No)
                    return;
            }
           

            this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].Cells["AMOUNT"].Value = 
                            this.ntbDeposited.Amount;
            
            this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].Cells["DESCRIPTION"].Value = 
                this.txtDescriptionSrc.Text;

            this.dtgNewCashSource.Rows[intCurrDepositDtlSourceSelectedRowIndex].Cells["OVERUNDERAMT"].Value =
                    decimal.Parse(this.txtOnHand.Text);

            this.setRemainingAmount(this.dcCurrentSourceCrrDepositAmt);
            this.setRemainingAmount(decimal.Parse(this.ntbDeposited.Amount) * -1);
            
            this.dcCurrentSourceOnhandAmt = 0;
            this.dcCurrentSourceCrrDepositAmt = 0;
            this.ntbDeposited.Amount = "0";
            this.txtOnHand.Text = "0";
            this.txtDescriptionSrc.Text = "";

            this.cmdModify.Enabled = false;
        }


        private void ntbDeposited_Leave(object sender, EventArgs e)
        {

            this.txtOnHand.Text =
                (this.dcCurrentSourceOnhandAmt - decimal.Parse(this.ntbDeposited.Amount)).ToString("N02");
        }


        private void cmdComplete_Click(object sender, EventArgs e)
        {
            decimal depositCommission =
                generalResultInformation.cashLineAmt / 
                    ((generalResultInformation.cardCommissionRate / 100) + 1) * 
                (generalResultInformation.cardCommissionRate / 100);

            decimal cashOverShort = 
                decimal.Parse(this.txtAmountRemaining.Text) - depositCommission;

            
            if (cashOverShort.CompareTo(generalResultInformation.overAmtLimit) == -1 ||
                cashOverShort.CompareTo(generalResultInformation.shortAmtLimit) == 1)
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

                    blAllowAmount =
                        generalResultInformation.securityPassKeyCorrect;
                }

                if (!blAllowAmount)
                {
                    if (this.dtgNewCashSource.SelectedRows.Count > 0)
                        this.dtgNewCashSource.Rows[this.dtgNewCashSource.SelectedRows[0].Index].Selected = false;

                    this.dcCurrentSourceOnhandAmt = 0;
                    this.dcCurrentSourceCrrDepositAmt = 0;
                    this.ntbDeposited.Amount = "0";
                    this.txtOnHand.Text = "0";
                    this.txtDescriptionSrc.Text = "";

                    this.cmdModify.Enabled = false;

                    MessageBox.Show("Source Amount Does Not Match.",
                        "New Deposit", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return;
                }
            }
            else if (cashOverShort.CompareTo(new decimal(-0.5)) == -1 ||
                cashOverShort.CompareTo(new decimal(0.5)) == 1)
            {
                if (MessageBox.Show("Source Amount Does Not Match. Do you Want To proceed.",
                    "New Deposit", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.No)
                {
                    if (this.dtgNewCashSource.SelectedRows.Count > 0)
                        this.dtgNewCashSource.Rows[this.dtgNewCashSource.SelectedRows[0].Index].Selected = false;

                    this.dcCurrentSourceOnhandAmt = 0;
                    this.dcCurrentSourceCrrDepositAmt = 0;
                    this.ntbDeposited.Amount = "0";
                    this.txtOnHand.Text = "0";
                    this.txtDescriptionSrc.Text = "";

                    this.cmdModify.Enabled = false;


                    return;
                }
            }

            for (int rowCounter = 0; rowCounter <= this.dtNewDepositSource.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewCashSource = generalResultInformation.newCashSource.NewRow();
                foreach (DataColumn dtCol in generalResultInformation.newCashSource.Columns)
                {
                    if (this.dtNewDepositSource.Columns.Contains(dtCol.ColumnName))
                        drNewCashSource[dtCol] = this.dtNewDepositSource.Rows[rowCounter][dtCol.ColumnName];
                }

                generalResultInformation.newCashSource.Rows.Add(drNewCashSource);                
            }

            //generalResultInformation.securityPassKeyCorrect = true;

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Some Changes Have been made to your current Source. \n Are you sure you want to leave.",
                    "New Deposit", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                generalResultInformation.securityPassKeyCorrect = false;
                this.Close();
            }
        }

        
    }
}
