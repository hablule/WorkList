using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuySimple
{
    public partial class frmGenerateItemCost : Form
    {
        public frmGenerateItemCost()
        {
            InitializeComponent();
        }

        decimal dcInvoiceSubTotal = 0;
        decimal dcInvoiceTaxTotal = 0;
        //decimal dcInvoiceGrandTotal = 0;
        
        DataTable dtValidCommercialInvoicesToClose = new DataTable();

        DataTable searchQuery = new DataTable();        
        DataTable dtInvoiceOrderDistributablePayments = new DataTable();        
        DataTable dtCommercialInvoiceLineCost = new DataTable();

        //VARIABLE THAT UPDATE COMPIERE TABLES.
        DataTable dtCommercialInvoiceUpdate = new DataTable();
        DataTable dtCommercialInvoiceLineUpdate = new DataTable();
        DataTable dtNewCommercialInvoiceTax = new DataTable();
        DataTable dtNewInvoicePOmatching = new DataTable();

        //VARIABLE THAT UPDATE PURCHASE MANAGEMENT TABLES
        DataTable dtCommercialInvoiceCostShare = new DataTable();
        DataTable dtNewPaymentInvoiceLines = new DataTable();
        DataTable dtChangedPaymentInvoiceLines = new DataTable();
        
        dataBuilder getDataFromDB = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();

        dtsDocumentData dtsDocData = new dtsDocumentData();

        ctlNumberTextBox commaSeparatedNumber = new ctlNumberTextBox();


        private decimal roundOff(decimal number, uint precision)
        {
            string stNumber = number.ToString();
            if (!stNumber.Contains("."))
                return number;

            string[] numberSplited = stNumber.Split(new string[]{"."}, StringSplitOptions.RemoveEmptyEntries);
            string intNumber = numberSplited[0];
            string floatNumber = numberSplited[1];
            if (precision >= floatNumber.Length)
                return number;
            string stroundedNumber = "";
            string truncatedfloatNumber = "";
            if (precision > 0)
            {
                truncatedfloatNumber = floatNumber.Substring(Convert.ToInt16(precision));                
                stroundedNumber = stNumber.Remove((intNumber.Length + Convert.ToInt16(precision) + 1));
            }
            else
            {
                truncatedfloatNumber = floatNumber;
                stroundedNumber = intNumber;
            }
            string theRoundOffIndex = truncatedfloatNumber.Substring(0, 1);

            int roundoffIndex = Convert.ToInt16(theRoundOffIndex);
            decimal roundedNumber = Convert.ToDecimal(stroundedNumber);

            if (roundoffIndex < 5)
                return roundedNumber;
            return (roundedNumber + Convert.ToDecimal(1/Math.Pow(10,Convert.ToDouble(precision))));            
        }

        private string translateBoolToCharacter(bool _boolean)
        {
            if (_boolean)
                return "Y";
            else
                return "N";
        }

        private int[] searchTableRowIndex(DataTable tableToSearchIn,
           string columnNameToCheck, string criteriaToCheck)
        {
            int[] resultRowIndex = new int[tableToSearchIn.Rows.Count];
            for (int arrayIndexCounter = 0;
                arrayIndexCounter <= resultRowIndex.Length - 1;
                arrayIndexCounter++)
                resultRowIndex[arrayIndexCounter] = -1;

            int matchingRowCount = 0;

            if (!this.getDataFromDB.checkIfTableContainesData(tableToSearchIn))
                return resultRowIndex;
            if (!tableToSearchIn.Columns.Contains(columnNameToCheck))
                return resultRowIndex;

            for (int rowCounter = 0; rowCounter <= tableToSearchIn.Rows.Count - 1;
                rowCounter++)
            {
                if (tableToSearchIn.Rows[rowCounter][columnNameToCheck].ToString() ==
                    criteriaToCheck)
                    resultRowIndex[matchingRowCount++] = rowCounter;
            }
            return resultRowIndex.Distinct().ToArray();
        }
                
        public DataTable establishValidCommercialInvoices(string C_ORDER_ID)
        {
            DataTable dtCommercilInvoices =
                    this.getDataFromDB.getC_INVOICEInfo(null, "", generalResultInformation.organiztionId,
                                "", C_ORDER_ID, "", "", "", "CO", "DR", "", triaStateBool.no, triaStateBool.no,
                                true, false, "AND");

            for (int columnCounter = dtCommercilInvoices.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (dtCommercilInvoices.Columns[columnCounter].ColumnName != "C_INVOICE_ID" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "DOCUMENTNO" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "DATEINVOICED" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "TOTALLINES" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "GRANDTOTAL" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "C_BPARTNER_ID" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "C_ORDER_ID")
                    dtCommercilInvoices.Columns.RemoveAt(columnCounter);
            }
            dtCommercilInvoices.Columns.Add("PAYED TO");
            for (int rowCounter = dtCommercilInvoices.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (dtCommercilInvoices.Rows[rowCounter]["C_ORDER_ID"].ToString() == "")
                {
                    dtCommercilInvoices.Rows.RemoveAt(rowCounter);
                    continue;
                }
                dtCommercilInvoices.Rows[rowCounter]["PAYED TO"] =
                    this.getDataFromDB.getC_BPARTNERInfo(null, "", "",
                              dtCommercilInvoices.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                              "", triaStateBool.yes, triaStateBool.Ignor, triaStateBool.Ignor,
                              triaStateBool.Ignor, false, false, "AND").Rows[0]["NAME"].ToString();
            }

            dtCommercilInvoices.Columns.RemoveAt(
                dtCommercilInvoices.Columns.IndexOf("C_BPARTNER_ID"));
            return dtCommercilInvoices;
        }

        public DataTable establishCommercialInvoeceDetail(string C_INVOICE_ID)
        {
            DataTable commercialInvoceLine = new DataTable();
            if (C_INVOICE_ID == "")
            {
                commercialInvoceLine.Columns.Add("LINE");
                commercialInvoceLine.Columns.Add("ITEM");
                commercialInvoceLine.Columns.Add("UNIT");
                commercialInvoceLine.Columns.Add("C_CHARGE_ID");
                commercialInvoceLine.Columns.Add("C_INVOICE_ID");
                commercialInvoceLine.Columns.Add("C_INVOICELINE_ID");
                commercialInvoceLine.Columns.Add("C_UOM_ID");                
                commercialInvoceLine.Columns.Add("M_PRODUCT_ID");
                commercialInvoceLine.Columns.Add("PRICEENTERED");
                commercialInvoceLine.Columns.Add("QTYENTERED");
                commercialInvoceLine.Columns.Add("LINENETAMT");
                commercialInvoceLine.Columns.Add("TAXAMT");
                commercialInvoceLine.Columns.Add("LINETOTALAMT");
                goto establishOrder;
            }

            commercialInvoceLine =
                    this.getDataFromDB.getC_INVOICELINEInfo(null, "", "",
                            C_INVOICE_ID, "", "", "", triaStateBool.no, triaStateBool.Ignor,
                            true, false, "AND");
            for (int columnCounter = commercialInvoceLine.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (commercialInvoceLine.Columns[columnCounter].ColumnName != "C_CHARGE_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_INVOICE_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_INVOICELINE_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_UOM_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "LINE" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "M_PRODUCT_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "PRICEENTERED" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "QTYENTERED" &&                    
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "LINENETAMT" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "TAXAMT" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "LINETOTALAMT")
                    commercialInvoceLine.Columns.RemoveAt(columnCounter);
            }
            
            commercialInvoceLine.Columns.Add("ITEM");
            commercialInvoceLine.Columns.Add("UNIT");
            
            for (int rowCounter = 0; rowCounter <= commercialInvoceLine.Rows.Count - 1;
                rowCounter++)
            {
                if (commercialInvoceLine.Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "")
                {
                    try
                    {
                        commercialInvoceLine.Rows[rowCounter]["ITEM"] =
                            this.getDataFromDB.getM_PRODUCTInfo(null, "",
                                commercialInvoceLine.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                                        false, false, "AND").Rows[0]["NAME"];
                    }
                    catch
                    { }
                }
                else if (commercialInvoceLine.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    try
                    {
                        commercialInvoceLine.Rows[rowCounter]["ITEM"] =
                            this.getDataFromDB.getC_CHARGEInfo(null, "", "",
                                    commercialInvoceLine.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                                    "", false, false, "AND").Rows[0]["NAME"];
                    }
                    catch
                    { }
                }
                if (commercialInvoceLine.Rows[rowCounter]["C_UOM_ID"].ToString() != "")
                {
                    try
                    {
                        commercialInvoceLine.Rows[rowCounter]["UNIT"] =
                            this.getDataFromDB.getC_UOMInfo(null, "",
                                commercialInvoceLine.Rows[rowCounter]["C_UOM_ID"].ToString(),
                                false, false, "AND").Rows[0]["NAME"].ToString();
                    }
                    catch
                    { }
                }
            }

            establishOrder :
            commercialInvoceLine.Columns["LINE"].SetOrdinal(0);
            commercialInvoceLine.Columns["ITEM"].SetOrdinal(1);
            commercialInvoceLine.Columns["QTYENTERED"].SetOrdinal(2);
            commercialInvoceLine.Columns["UNIT"].SetOrdinal(3);
            commercialInvoceLine.Columns["PRICEENTERED"].SetOrdinal(4);

            //commercialInvoceLine.Columns["C_CHARGE_ID"].SetOrdinal(5);
            //commercialInvoceLine.Columns["M_PRODUCT_ID"].SetOrdinal(6);
            //commercialInvoceLine.Columns["C_UOM_ID"].SetOrdinal(7);
            //commercialInvoceLine.Columns["LINENETAMT"].SetOrdinal(8);
            //commercialInvoceLine.Columns["C_INVOICELINE_ID"].SetOrdinal(9);
            //commercialInvoceLine.Columns["C_INVOICE_ID"].SetOrdinal(10);


            return commercialInvoceLine;
        }

        public DataTable establishInvoiceTaxData()
        {
            DataTable dtTaxInfo = new DataTable();
            DataTable dtInvoiceTax = new DataTable();
            //this.dtNewCommercialInvoiceTax.Copy();
           
            if (this.dtNewCommercialInvoiceTax.Columns.Count > 0)
            {                
                dtInvoiceTax =
                    this.dtNewCommercialInvoiceTax.Copy();

                for (int columnCounter = dtInvoiceTax.Columns.Count - 1;
                    columnCounter >= 0; columnCounter--)
                {
                    if (dtInvoiceTax.Columns[columnCounter].ColumnName != "C_TAX_ID" &&
                        dtInvoiceTax.Columns[columnCounter].ColumnName != "TAXAMT")
                        dtInvoiceTax.Columns.RemoveAt(columnCounter);
                }
                dtInvoiceTax.Columns.Add("NAME");
                dtInvoiceTax.Columns.Add("AMOUNT");

                for (int rowCounter = dtInvoiceTax.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    dtTaxInfo =
                        this.getDataFromDB.getC_TAXInfo(null, "", "",
                            dtInvoiceTax.Rows[rowCounter]["C_TAX_ID"].ToString(),
                            "", "", false, triaStateBool.Ignor, triaStateBool.Ignor, false, "AND");
                    if (dtTaxInfo.Rows.Count > 0)
                        dtInvoiceTax.Rows[rowCounter]["NAME"] =
                            dtTaxInfo.Rows[0]["NAME"].ToString();
                    this.commaSeparatedNumber.Amount =
                        dtInvoiceTax.Rows[rowCounter]["TAXAMT"].ToString();

                    dtInvoiceTax.Rows[rowCounter]["AMOUNT"] =
                        this.commaSeparatedNumber.Amount;


                }
                dtInvoiceTax.Columns["NAME"].SetOrdinal(0);
                dtInvoiceTax.Columns["AMOUNT"].SetOrdinal(1);
                dtInvoiceTax.Columns.RemoveAt(dtInvoiceTax.Columns.IndexOf("C_TAX_ID"));
                dtInvoiceTax.Columns.RemoveAt(dtInvoiceTax.Columns.IndexOf("TAXAMT"));

                return dtInvoiceTax;
            }
            else
            {
                dtInvoiceTax.Columns.Add("NAME");
                dtInvoiceTax.Columns.Add("AMOUNT");
                dtInvoiceTax.Columns["NAME"].SetOrdinal(0);
                dtInvoiceTax.Columns["AMOUNT"].SetOrdinal(1);
                return dtInvoiceTax;
            }

        }

        public void createInvoiceDisturbuatblePayment(string C_ORDER_ID)
        {
            this.dtInvoiceOrderDistributablePayments.Clear();
            this.searchQuery.Rows.Clear();
            if (C_ORDER_ID != "")
             {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "C_ORDER_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = C_ORDER_ID;
                this.searchQuery.Rows.Add(criteriaValue);

                criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "ISAMOUNTDISTRIBUTABLE";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = "Y";
                this.searchQuery.Rows.Add(criteriaValue);

                criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "ISACTIVE";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = "Y";
                this.searchQuery.Rows.Add(criteriaValue);

                this.dtInvoiceOrderDistributablePayments = 
                    this.getDataAccordingToRule.
                            getPaymentRecordAccordingToCriterion(this.searchQuery, false);

                this.dtInvoiceOrderDistributablePayments.Columns.
                    Add("INCLUDE", Type.GetType("System.Boolean"));
                this.dtInvoiceOrderDistributablePayments.Columns.
                    Add("REMAING AMOUNT", Type.GetType("System.Boolean"));
                this.dtInvoiceOrderDistributablePayments.Columns.Add("COSTCLOSED");
            }
            else
            {
                if (this.dtInvoiceOrderDistributablePayments.Columns.Count <= 0)
                {
                    this.dtInvoiceOrderDistributablePayments =
                        this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "", "", "",
                                "", "", "", "", "", "", "", "", "", triaStateBool.no,
                                triaStateBool.yes, triaStateBool.Ignor, triaStateBool.Ignor,
                                triaStateBool.Ignor, true, "AND");

                    //if(!this.dtInvoiceOrderDistributablePayments.Columns.Contains(""))
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("INCLUDE", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains(""))
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("REMAING AMOUNT", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("ACTIVE", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains(""))
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("ESTIMATE", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("DISTRIBUTED", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("IS A BANK", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("IS A COST", 
                            Type.GetType("System.Boolean"));
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("VENDOR");
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("AMOUNT");
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("PAYED FROM");
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("PAYED FOR");
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("ORDER");
                    //if (!this.dtInvoiceOrderDistributablePayments.Columns.Contains("")) 
                        this.dtInvoiceOrderDistributablePayments.Columns.Add("INVOICE");
                    
                    
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("INVOICEAMOUNT"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("ISACTIVE"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("ISAMOUNTDISTRIBUTABLE"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("ISAMOUNTESTIMATE"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("UPDATED"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("UPDATEDBY"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("USERINSERTED"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("CREATED"));
                    this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                        this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("CREATEDBY"));
                }
            }

            this.dtInvoiceOrderDistributablePayments.Columns["INCLUDE"].SetOrdinal(0);
            this.dtInvoiceOrderDistributablePayments.Columns["REMAING AMOUNT"].SetOrdinal(1);
            this.dtInvoiceOrderDistributablePayments.Columns["DOCUMENTNO"].SetOrdinal(2);
            this.dtInvoiceOrderDistributablePayments.Columns["VENDOR"].SetOrdinal(5);
            this.dtInvoiceOrderDistributablePayments.Columns["DATEINVOICED"].SetOrdinal(4);
            this.dtInvoiceOrderDistributablePayments.Columns["AMOUNT"].SetOrdinal(3);
            this.dtInvoiceOrderDistributablePayments.Columns["ACTIVE"].SetOrdinal(6);
            this.dtInvoiceOrderDistributablePayments.Columns["ESTIMATE"].SetOrdinal(7);
            this.dtInvoiceOrderDistributablePayments.Columns["DISTRIBUTED"].SetOrdinal(8);
            this.dtInvoiceOrderDistributablePayments.Columns["PAYED FROM"].SetOrdinal(9);
            this.dtInvoiceOrderDistributablePayments.Columns["IS A BANK"].SetOrdinal(10);
            this.dtInvoiceOrderDistributablePayments.Columns["PAYED FOR"].SetOrdinal(11);
            this.dtInvoiceOrderDistributablePayments.Columns["IS A COST"].SetOrdinal(12);
            this.dtInvoiceOrderDistributablePayments.Columns["ORDER"].SetOrdinal(13);
            this.dtInvoiceOrderDistributablePayments.Columns["INVOICE"].SetOrdinal(14);            

            for (int rowCounter = this.dtInvoiceOrderDistributablePayments.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]["INCLUDE"] = true;
                this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]["REMAING AMOUNT"] = false;
                this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]["COSTCLOSED"] = "Y";
            }
            if(this.dtInvoiceOrderDistributablePayments.Columns.Contains("COST CLOSED"))
                this.dtInvoiceOrderDistributablePayments.Columns.RemoveAt(
                    this.dtInvoiceOrderDistributablePayments.Columns.IndexOf("COST CLOSED"));
        }

        public void fillDistributableCostGridView()
        {
            this.dtgDistributableCost.DataSource =
                this.dtInvoiceOrderDistributablePayments;

            foreach (DataGridViewColumn columns in this.dtgDistributableCost.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            this.dtgDistributableCost.Columns["PM_C_PURCHASEPAYMENT_ID"].Visible = false;
            this.dtgDistributableCost.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgDistributableCost.Columns["AD_ORG_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_BANKACCOUNT_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_CASHBOOK_ID"].Visible = false;
            this.dtgDistributableCost.Columns["DESCRIPTION"].Visible = false;
            this.dtgDistributableCost.Columns["C_TAX_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_ORDER_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgDistributableCost.Columns["ACTIVE"].Visible = false;
            this.dtgDistributableCost.Columns["DISTRIBUTED"].Visible = false;
            this.dtgDistributableCost.Columns["COSTCLOSED"].Visible = false;
            this.dtgDistributableCost.Columns["INVOICE"].Visible = false;
            this.dtgDistributableCost.Columns["COSTCLOSED"].Visible = false;
            //this.dtgDistributableCost.Columns["CREATED"].Visible = false;
            //this.dtgDistributableCost.Columns["CREATEDBY"].Visible = false;
            
        }

        public void fillInvoiceLineCostGridView()
        {
            if (this.dtCommercialInvoiceLineCost.Rows.Count == 0)
            {
                this.dtgInvoiceLineCost.DataSource =
                    this.establishCommercialInvoeceDetail("");                
            }
            else
            {                   
                this.dtgInvoiceLineCost.DataSource =
                        this.dtCommercialInvoiceLineCost;
                this.dtgInvoiceLineCost.Columns["INV. PRICE"].DisplayIndex =
                this.dtgInvoiceLineCost.Columns["PRICEENTERED"].DisplayIndex;
                this.dtgInvoiceLineCost.Columns["ACT. PRICE"].DisplayIndex =
                    this.dtgInvoiceLineCost.Columns["PRICEENTERED"].DisplayIndex + 1;
                this.dtgInvoiceLineCost.Columns["PRICE"].Visible = false;
            }

            foreach (DataGridViewColumn columns in this.dtgInvoiceLineCost.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.Automatic;
                columns.DisplayIndex = columns.Index;
            }

            this.dtgInvoiceLineCost.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgInvoiceLineCost.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgInvoiceLineCost.Columns["C_INVOICELINE_ID"].Visible = false;
            this.dtgInvoiceLineCost.Columns["C_UOM_ID"].Visible = false;            
            this.dtgInvoiceLineCost.Columns["M_PRODUCT_ID"].Visible = false;            
            this.dtgInvoiceLineCost.Columns["LINENETAMT"].Visible = false;
            this.dtgInvoiceLineCost.Columns["PRICEENTERED"].Visible = false;

            this.dtgInvoiceLineCost.Columns["LINETOTALAMT"].Visible = false;
            this.dtgInvoiceLineCost.Columns["TAXAMT"].Visible = false;
                        
            this.dtgInvoiceLineCost.Columns["QTYENTERED"].HeaderText = "QTY";
            
            
        }
        
        public void determineInvoiceShareFromEachDistributablePayment()
        {
            decimal sharedPaymentAmount = 0;
            decimal invoicepaymentShare = 0;
            decimal utilisedAmountOnSharedPayment = 0;
            DataTable orderOrInvoiceInfo =
                this.getDataFromDB.getC_ORDERInfo(null,"","",
                        this.ddgCommercialInvoice.SelectedRow.Rows[0]["C_ORDER_ID"].ToString(),
                        "","","","","","",triaStateBool.no,triaStateBool.yes,true,false,"AND");
            if (orderOrInvoiceInfo.Rows.Count <= 0)
                return;

            decimal performaOrderTotal =
                Convert.ToDecimal(orderOrInvoiceInfo.Rows[0]["TOTALLINES"]);

            if (performaOrderTotal == 0)
                return;

            orderOrInvoiceInfo =
                this.getDataFromDB.getC_INVOICEInfo(null, "", "",
                        this.ddgCommercialInvoice.SelectedRowKey.ToString(), "", "", "", "",
                        "", "", "", triaStateBool.Ignor, triaStateBool.no, false, false, "AND");

            if (orderOrInvoiceInfo.Rows.Count <= 0)
                return;

            decimal invoiceTotal =
                    Convert.ToDecimal(orderOrInvoiceInfo.Rows[0]["TOTALLINES"]);
            
            string paymentId = "";
            DataTable existingPaymentShare = new DataTable();
            DataRow drNewShareAmount;

            this.dtCommercialInvoiceCostShare =
                this.getDataFromDB.getPM_PAYMENT_INVOCESHAREInfo(null, "", "", "", "", 
                                this.ddgCommercialInvoice.SelectedRowKey.ToString(),
                                "","",triaStateBool.Ignor,false, false, "AND");
            
            for (int rowCounter = this.dtInvoiceOrderDistributablePayments.Rows.Count-1; 
                rowCounter >= 0; rowCounter--)
            {
                if (!
                        (Convert.ToBoolean
                            (this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]["INCLUDE"])
                        )
                    )
                    continue;

                invoicepaymentShare = 0;
                utilisedAmountOnSharedPayment = 0;
                sharedPaymentAmount = Convert.ToDecimal(this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["AMOUNT"]);

                drNewShareAmount = this.dtCommercialInvoiceCostShare.NewRow();
                paymentId = this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["PM_C_PURCHASEPAYMENT_ID"].ToString();

                drNewShareAmount["PM_C_PURCHASEPAYMENT_ID"] = paymentId;
                    
                drNewShareAmount["C_INVOICE_ID"] =
                    this.ddgCommercialInvoice.SelectedRowKey.ToString();
                drNewShareAmount["AD_CLIENT_ID"] = 
                    generalResultInformation.clientId;
                drNewShareAmount["AD_ORG_ID"] = 
                    generalResultInformation.organiztionId;                
                drNewShareAmount["CREATEDBY"] = 
                    generalResultInformation.userId;
                
                drNewShareAmount["ISACTIVE"] = 
                    this.translateBoolToCharacter(Convert.ToBoolean(
                        this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["ACTIVE"].ToString())); 

                drNewShareAmount["ISAMOUNTESTIMATE"] = 
                    this.translateBoolToCharacter(Convert.ToBoolean(
                            this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["ESTIMATE"].ToString()));
                if(Convert.ToBoolean(
                    this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["IS A COST"]))
                    drNewShareAmount["C_CHARGE_ID"] =                    
                        this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["C_CHARGE_ID"].ToString();
                else
                    drNewShareAmount["C_TAX_ID"] =
                        this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]
                                            ["C_TAX_ID"].ToString();

                drNewShareAmount["COSTCLOSED"] = "Y";

                existingPaymentShare =
                        this.getDataFromDB.getPM_PAYMENT_INVOCESHAREInfo(null, "", "", "", 
                                paymentId, "", "", "", triaStateBool.Ignor, false, false, "AND");
                for (int rowCounter2 = existingPaymentShare.Rows.Count - 1;
                    rowCounter2 >= 0; rowCounter2--)
                {
                    utilisedAmountOnSharedPayment +=
                        Convert.ToDecimal(existingPaymentShare.Rows[rowCounter2]["AMOUNTSHARED"]);
                }
                
                if (Convert.ToBoolean(
                        this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]["REMAING AMOUNT"]
                                      ))
                {                    
                    invoicepaymentShare = sharedPaymentAmount - utilisedAmountOnSharedPayment;
                }
                else
                {
                    invoicepaymentShare = 
                        (invoiceTotal / performaOrderTotal) * sharedPaymentAmount;
                }
                invoicepaymentShare = this.roundOff(invoicepaymentShare, 4);
                if (invoicepaymentShare < 0 ||
                    sharedPaymentAmount < this.roundOff(invoicepaymentShare + utilisedAmountOnSharedPayment,4))
                {
                    invoicepaymentShare = 0;
                    string reasonOfPayment = 
                        this.dtInvoiceOrderDistributablePayments.Rows[rowCounter]["PAYED FOR"].ToString();

                    if (MessageBox.Show("Current Invoice does not have any share from " + reasonOfPayment +
                                "\n \t\t Are you sure you want to proceed.",
                                "Cost Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;                    
                }
                drNewShareAmount["AMOUNTSHARED"] = this.roundOff(invoicepaymentShare,5);
                    //decimal.Round(invoicepaymentShare,5,MidpointRounding.AwayFromZero);
                this.dtCommercialInvoiceCostShare.Rows.Add(drNewShareAmount);
            }
        }        

        public void determineInoiceLineCost()
        {
            
            this.dcInvoiceSubTotal = 0;
            this.dcInvoiceTaxTotal = 0;

            string paymentId = "";
            string invoiceLineId = "";
                        
            int[] paymentRowIndex;
            int[] invoiceLineIndex;
            
            decimal dcPaymentAmount = 0;
            decimal dcAllInvoiceLineAmount = 0;
            decimal dcConcernedInvoiceLineAmount = 0;
            decimal dcInvoicelineAmount = 0;
            decimal dcInvoiceLineTaxAmount = 0;
            decimal dcInvoicelineShare = 0;
            
            DataRow drNewPayment_InvoiceDetail;
            DataRow drNewPOInoviceLineMatch;

            DataTable dtPaymentInfo = new DataTable();
            DataTable dtNewPaymentListForInvoice = new DataTable();
            DataTable dtPaymentListForInvoice = new DataTable();
            DataTable dtInvoiceInfo = new DataTable();
            DataTable dtcurrentInvoiceDetail = new DataTable();
            
            DBNull nullValue = DBNull.Value;
                        
            dtPaymentListForInvoice =
                this.getDataFromDB.getPM_C_PPAYMENT_INVOCELINEInfo(null, "",
                        "", "", "", "", this.ddgCommercialInvoice.SelectedRowKey.ToString(),
                        "", "", triaStateBool.no,true, triaStateBool.Ignor,
                        false, "AND");

            dtNewPaymentListForInvoice = dtPaymentListForInvoice.Copy();
            
            dtInvoiceInfo =
                this.getDataFromDB.getC_INVOICEInfo(null, "", "",
                    this.ddgCommercialInvoice.SelectedRowKey.ToString(), "",
                    "", "", "", "", "", "", triaStateBool.Ignor, triaStateBool.Ignor, false, false, "AND");

             if (!this.getDataFromDB.checkIfTableContainesData(dtInvoiceInfo))
                return;
            
            dcAllInvoiceLineAmount = Convert.ToDecimal(dtInvoiceInfo.Rows[0]["TOTALLINES"]);

            dtcurrentInvoiceDetail =
                this.establishCommercialInvoeceDetail(this.ddgCommercialInvoice.SelectedRowKey.ToString());

            if (!this.getDataFromDB.checkIfTableContainesData(dtcurrentInvoiceDetail))
                return;
            dtcurrentInvoiceDetail.Columns.Add("PRICE");
            dtcurrentInvoiceDetail.Columns.Add("INV. PRICE");
            dtcurrentInvoiceDetail.Columns.Add("ACT. PRICE");
            dtcurrentInvoiceDetail.Columns.Add("TAX AMT");

            #region "Compiere Update Tables"
            //Establish Tables That Update Compiere Main Table.
            this.dtCommercialInvoiceUpdate =
                this.getDataFromDB.getC_INVOICEInfo(null, "", "",
                        this.ddgCommercialInvoice.SelectedRowKey.ToString(),
                        "", "", "", "", "", "", "", triaStateBool.Ignor, triaStateBool.Ignor,
                        false, false, "AND");
            if (this.dtCommercialInvoiceUpdate.Rows.Count == 0)
                return;

            this.dtCommercialInvoiceLineUpdate =
                this.getDataFromDB.getC_INVOICELINEInfo(null, "", "",
                            this.ddgCommercialInvoice.SelectedRowKey.ToString(),
                            "", "", "", triaStateBool.Ignor,
                            triaStateBool.Ignor, false, false, "AND");

            if (this.dtCommercialInvoiceLineUpdate.Rows.Count == 0)
                return;

            this.dtNewCommercialInvoiceTax =
                this.getDataFromDB.getC_INVOICETAXInfo(null, "", "", "", "",
                    triaStateBool.Ignor, triaStateBool.Ignor, false, true, "AND");

            this.dtNewInvoicePOmatching =
                this.getDataFromDB.getM_MATCHPOInfo(null, "", "",
                            "", "", "", "", false, true, "AND");


            #endregion
            
            #region "Distribute Commercial Invoice Based Payments to their concerned Invoice Lines "

            for (int rowCounter = dtPaymentListForInvoice.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dcConcernedInvoiceLineAmount = 0;
                paymentId =
                    dtPaymentListForInvoice.Rows[rowCounter]["PM_C_PURCHASEPAYMENT_ID"].ToString();
                if (paymentId == "")
                    continue;

                dtPaymentInfo =
                    this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "", "",
                        paymentId, "", "", "", "", "", "", "", "", "",
                        triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                        triaStateBool.Ignor, triaStateBool.yes, false, "AND");

                if (dtPaymentInfo.Rows.Count <= 0)
                    continue;

                //if (dtPaymentInfo.Rows[0]["C_CHARGE_ID"].ToString() == "")
                //    continue;
                
                dcPaymentAmount = Convert.ToDecimal(dtPaymentInfo.Rows[0]["INVOICEAMOUNT"]);

                paymentRowIndex = this.searchTableRowIndex(dtPaymentListForInvoice,
                                        "PM_C_PURCHASEPAYMENT_ID", paymentId);
                if (paymentRowIndex.Length <= 0)
                    continue;
                else if (paymentRowIndex[0] == -1)
                    continue;

                foreach (int rowIndex in paymentRowIndex)
                {
                    if (rowIndex < 0 ||
                        rowIndex >= dtPaymentListForInvoice.Rows.Count)
                        continue;
                    invoiceLineId = "";
                    invoiceLineId =
                        dtPaymentListForInvoice.Rows[rowIndex]["C_INVOICELINE_ID"].ToString();

                    invoiceLineIndex =
                        this.searchTableRowIndex(dtcurrentInvoiceDetail,
                                    "C_INVOICELINE_ID", invoiceLineId);

                    if (invoiceLineIndex.Length <= 0)
                        continue;
                    else if (invoiceLineIndex[0] == -1)
                        continue;

                    dcConcernedInvoiceLineAmount +=
                        Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["LINENETAMT"]);
                }

                foreach (int rowIndex in paymentRowIndex)
                {
                    if (rowIndex < 0 ||
                        rowIndex >= dtPaymentListForInvoice.Rows.Count)
                        continue;

                    invoiceLineId = "";
                    invoiceLineId =
                        dtPaymentListForInvoice.Rows[rowIndex]["C_INVOICELINE_ID"].ToString();

                    invoiceLineIndex =
                        this.searchTableRowIndex(dtcurrentInvoiceDetail,
                                        "C_INVOICELINE_ID", invoiceLineId);

                    if (invoiceLineIndex.Length <= 0)
                        continue;
                    else if (invoiceLineIndex[0] == -1)
                        continue;

                    dcInvoicelineAmount =
                        Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["LINENETAMT"]);
                    dcInvoicelineShare =
                        (dcInvoicelineAmount / dcConcernedInvoiceLineAmount) * dcPaymentAmount;

                    if (dtPaymentListForInvoice.Rows[rowIndex]["C_CHARGE_ID"].ToString() != "" &&
                        dtPaymentListForInvoice.Rows[rowIndex]["C_TAX_ID"].ToString() == "")
                    {
                        if (dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["PRICE"].ToString() != "")
                            dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["PRICE"] = 
                                dcInvoicelineShare +
                                Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["PRICE"]);
                        else
                            dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["PRICE"] = 
                                this.roundOff(dcInvoicelineShare,5);
                            //decimal.Round(dcInvoicelineShare, 5);
                    }
                    else if (dtPaymentListForInvoice.Rows[rowIndex]["C_CHARGE_ID"].ToString() == "" &&
                             dtPaymentListForInvoice.Rows[rowIndex]["C_TAX_ID"].ToString() != "")
                    {
                        if (dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["TAX AMT"].ToString() != "")
                            dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["TAX AMT"] = 
                                dcInvoicelineShare +
                                Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["TAX AMT"]);
                        else
                            dtcurrentInvoiceDetail.Rows[invoiceLineIndex[0]]["TAX AMT"] =
                                this.roundOff(dcInvoicelineShare, 5);
                    }

                    dtNewPaymentListForInvoice.Rows[rowIndex]["AMOUNTSHARED"] = 
                        this.roundOff(dcInvoicelineShare,5);
                        //decimal.Round(dcInvoicelineShare, 5);
                    dtNewPaymentListForInvoice.Rows[rowIndex]["COSTCLOSED"] = "Y";
                }

                foreach (int rowIndex in paymentRowIndex)
                {
                    if (rowIndex < 0 ||
                        rowIndex >= dtPaymentListForInvoice.Rows.Count)
                        continue;
                    dtPaymentListForInvoice.Rows[rowIndex]["PM_C_PURCHASEPAYMENT_ID"] = nullValue;
                    dtPaymentListForInvoice.Rows[rowIndex]["C_INVOICELINE_ID"] = nullValue;
                    dtPaymentListForInvoice.Rows[rowIndex]["C_INVOICE_ID"] = nullValue;                    
                }                
            }
            this.dtChangedPaymentInvoiceLines =
                dtNewPaymentListForInvoice.Copy();
            dtNewPaymentListForInvoice.Clear();
            dtPaymentListForInvoice.Clear();

            #endregion

            #region "Distribute Performa Invoice Based Payments to their concerned Commercial Invoice Lines"

            for (int rowCounter = this.dtCommercialInvoiceCostShare.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dcPaymentAmount =
                    Convert.ToDecimal(this.dtCommercialInvoiceCostShare.Rows[rowCounter]["AMOUNTSHARED"]);

                for (int rowCounter2 = dtcurrentInvoiceDetail.Rows.Count - 1;
                    rowCounter2 >= 0; rowCounter2--)
                {
                    dcInvoicelineAmount =
                        Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[rowCounter2]["LINENETAMT"]);
                    dcInvoicelineShare = (dcInvoicelineAmount / dcAllInvoiceLineAmount) * dcPaymentAmount;

                    if (this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "" &&
                        this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_TAX_ID"].ToString() == "")
                    {
                        if (dtcurrentInvoiceDetail.Rows[rowCounter2]["PRICE"].ToString() != "")
                            dtcurrentInvoiceDetail.Rows[rowCounter2]["PRICE"] = 
                                dcInvoicelineShare +
                                Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[rowCounter2]["PRICE"]);
                        else
                            dtcurrentInvoiceDetail.Rows[rowCounter2]["PRICE"] = 
                                this.roundOff(dcInvoicelineShare,5);
                            //decimal.Round(dcInvoicelineShare, 5);
                    }
                    else if (this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_CHARGE_ID"].ToString() == "" &&
                        this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                    {
                        if (dtcurrentInvoiceDetail.Rows[rowCounter2]["TAX AMT"].ToString() != "")
                            dtcurrentInvoiceDetail.Rows[rowCounter2]["TAX AMT"] = 
                                dcInvoicelineShare +
                                Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[rowCounter2]["TAX AMT"]);
                        else
                            dtcurrentInvoiceDetail.Rows[rowCounter2]["TAX AMT"] =
                                this.roundOff(dcInvoicelineShare, 5);
                        //decimal.Round(dcInvoicelineShare, 5);
                    }

                    drNewPayment_InvoiceDetail = dtNewPaymentListForInvoice.NewRow();
                    
                    drNewPayment_InvoiceDetail["PM_C_PURCHASEPAYMENT_ID"] =
                        this.dtCommercialInvoiceCostShare.Rows[rowCounter]["PM_C_PURCHASEPAYMENT_ID"];

                    drNewPayment_InvoiceDetail["C_INVOICELINE_ID"] =
                       dtcurrentInvoiceDetail.Rows[rowCounter2]["C_INVOICELINE_ID"].ToString();
                    
                    drNewPayment_InvoiceDetail["C_INVOICE_ID"] =
                        this.ddgCommercialInvoice.SelectedRowKey.ToString();
                    
                    drNewPayment_InvoiceDetail["AD_CLIENT_ID"] = 
                        generalResultInformation.clientId;

                    drNewPayment_InvoiceDetail["AD_ORG_ID"] =
                        generalResultInformation.organiztionId;
                    
                    drNewPayment_InvoiceDetail["CREATEDBY"] = 
                        generalResultInformation.userId;
                    
                    drNewPayment_InvoiceDetail["UPDATEDBY"] =
                        generalResultInformation.userId;

                    drNewPayment_InvoiceDetail["ISACTIVE"] =
                        this.dtCommercialInvoiceCostShare.Rows[rowCounter]["ISACTIVE"];
                    
                    drNewPayment_InvoiceDetail["ISAMOUNTESTIMATE"] =
                        this.dtCommercialInvoiceCostShare.Rows[rowCounter]["ISAMOUNTESTIMATE"];

                    drNewPayment_InvoiceDetail["AMOUNTSHARED"] =
                        this.roundOff(dcInvoicelineShare, 5);
                        //decimal.Round(dcInvoicelineShare, 2);

                    if(this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                        drNewPayment_InvoiceDetail["C_TAX_ID"] =
                            this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_TAX_ID"];
                    else
                        drNewPayment_InvoiceDetail["C_CHARGE_ID"] =
                            this.dtCommercialInvoiceCostShare.Rows[rowCounter]["C_CHARGE_ID"];

                    drNewPayment_InvoiceDetail["COSTCLOSED"] = "Y";

                    dtNewPaymentListForInvoice.Rows.Add(drNewPayment_InvoiceDetail);
                }
            }
            this.dtNewPaymentInvoiceLines =
                dtNewPaymentListForInvoice.Copy();
            dtNewPaymentListForInvoice.Clear();
            #endregion

            #region "Compiere Update Table Data"
            //Fill the Update Data That Update Compiere Transaction

            this.UpdateCompiereInvoiceTaxAndInvoicelineInfo(this.dtChangedPaymentInvoiceLines);
            this.UpdateCompiereInvoiceTaxAndInvoicelineInfo(this.dtNewPaymentInvoiceLines);
                        
            for (int rowCounter = dtcurrentInvoiceDetail.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dcInvoicelineAmount = 0;
                if(dtcurrentInvoiceDetail.Rows[rowCounter]["PRICE"].ToString() != "")
                    dcInvoicelineAmount =
                        Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[rowCounter]["PRICE"]);

                dcInvoicelineAmount /=
                    Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[rowCounter]["QTYENTERED"]);

                dcInvoicelineAmount = this.roundOff(dcInvoicelineAmount, 5);
                    //decimal.Round(dcInvoicelineAmount,5);
                                
                commaSeparatedNumber.Amount = dcInvoicelineAmount.ToString();

                dtcurrentInvoiceDetail.Rows[rowCounter]["ACT. PRICE"] =
                    commaSeparatedNumber.Amount;

                commaSeparatedNumber.Amount =
                    dtcurrentInvoiceDetail.Rows[rowCounter]["PRICEENTERED"].ToString();

                dtcurrentInvoiceDetail.Rows[rowCounter]["INV. PRICE"] =
                    commaSeparatedNumber.Amount;
                if (dtcurrentInvoiceDetail.Rows[rowCounter]["TAX AMT"].ToString() != "")
                    dcInvoiceLineTaxAmount =
                        Convert.ToDecimal(dtcurrentInvoiceDetail.Rows[rowCounter]["TAX AMT"].ToString());
                dcInvoiceLineTaxAmount = this.roundOff(dcInvoiceLineTaxAmount, 3);
                commaSeparatedNumber.Amount =
                    dcInvoiceLineTaxAmount.ToString();
                dtcurrentInvoiceDetail.Rows[rowCounter]["TAX AMT"] = 
                    commaSeparatedNumber.Amount;

                invoiceLineIndex =
                    this.searchTableRowIndex(this.dtCommercialInvoiceLineUpdate, "C_INVOICELINE_ID",
                       dtcurrentInvoiceDetail.Rows[rowCounter]["C_INVOICELINE_ID"].ToString());

                if (invoiceLineIndex.Length > 0)
                {
                    if (invoiceLineIndex[0] != -1)
                    {
                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["PRICELIST"] =
                            dcInvoicelineAmount;
                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["PRICEACTUAL"] =
                            dcInvoicelineAmount;
                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["PRICELIMIT"] =
                            dcInvoicelineAmount;
                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["PRICEENTERED"] =
                            dcInvoicelineAmount;

                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["PROCESSED"] = "Y";

                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["LINENETAMT"] =
                            dcInvoicelineAmount *
                           Convert.ToDecimal(this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]
                                            ["QTYENTERED"]);

                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["TAXAMT"] =
                            dcInvoiceLineTaxAmount;

                        this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["LINETOTALAMT"] =
                            Convert.ToDecimal(this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["LINENETAMT"]) +
                            Convert.ToDecimal(this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["TAXAMT"]);

                        this.dcInvoiceSubTotal +=
                            Convert.ToDecimal(
                                this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["LINENETAMT"]);
                        continue;
                    }
                }
                return;
            }

            for (int rowCounter = this.dtCommercialInvoiceLineUpdate.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (this.dtCommercialInvoiceLineUpdate.Rows[rowCounter]["C_ORDERLINE_ID"].ToString() == "")
                    continue;
                drNewPOInoviceLineMatch = this.dtNewInvoicePOmatching.NewRow();
                               
                drNewPOInoviceLineMatch["AD_CLIENT_ID"] = 
                    generalResultInformation.clientId;
                drNewPOInoviceLineMatch["AD_ORG_ID"] = 
                    generalResultInformation.organiztionId;
                drNewPOInoviceLineMatch["ISACTIVE"] = "Y";
                drNewPOInoviceLineMatch["C_ORDERLINE_ID"] =
                    this.dtCommercialInvoiceLineUpdate.Rows[rowCounter]["C_ORDERLINE_ID"].ToString();
                drNewPOInoviceLineMatch["M_PRODUCT_ID"] =
                    this.dtCommercialInvoiceLineUpdate.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                drNewPOInoviceLineMatch["C_INVOICELINE_ID"] =
                    this.dtCommercialInvoiceLineUpdate.Rows[rowCounter]["C_INVOICELINE_ID"].ToString();
                drNewPOInoviceLineMatch["DATETRX"] =
                    Convert.ToDateTime(this.dtCommercialInvoiceUpdate.Rows[0]["DATEINVOICED"]);
                drNewPOInoviceLineMatch["QTY"] =
                    this.dtCommercialInvoiceLineUpdate.Rows[rowCounter]["QTYENTERED"].ToString();
                drNewPOInoviceLineMatch["PROCESSING"] = "N";
                drNewPOInoviceLineMatch["PROCESSED"] = "Y";
                drNewPOInoviceLineMatch["POSTED"] = "N";
                drNewPOInoviceLineMatch["DOCUMENTNO"] =
                    this.dtCommercialInvoiceUpdate.Rows[0]["DOCUMENTNO"].ToString();
                drNewPOInoviceLineMatch["DATEACCT"] =
                    Convert.ToDateTime(this.dtCommercialInvoiceUpdate.Rows[0]["DATEACCT"]);
                drNewPOInoviceLineMatch["ISAPPROVED"] = "Y";

                this.dtNewInvoicePOmatching.Rows.Add(drNewPOInoviceLineMatch);
            }


            for (int rowCounter = this.dtNewCommercialInvoiceTax.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                this.dtNewCommercialInvoiceTax.Rows[rowCounter]["TAXBASEAMT"] =
                    this.roundOff(this.dcInvoiceSubTotal, 2);
                    //decimal.Round(this.dcInvoiceSubTotal, 2);
            }

            this.dtCommercialInvoiceUpdate.Rows[0]["TOTALLINES"] =
                this.roundOff(this.dcInvoiceSubTotal, 2);
                //decimal.Round(this.dcInvoiceSubTotal,2) ;
            this.dtCommercialInvoiceUpdate.Rows[0]["GRANDTOTAL"] =
                this.roundOff((this.dcInvoiceSubTotal + this.dcInvoiceTaxTotal), 2);
                //decimal.Round((this.dcInvoiceSubTotal + this.dcInvoiceTaxTotal),2);
            this.dtCommercialInvoiceUpdate.Rows[0]["UPDATEDBY"] = 
                generalResultInformation.userId;
            this.dtCommercialInvoiceUpdate.Rows[0]["DOCSTATUS"] = 
                documentInformation.documentStatusAfterClosing;
            this.dtCommercialInvoiceUpdate.Rows[0]["DOCACTION"] = 
                documentInformation.documentActionAfterClosing;
            this.dtCommercialInvoiceUpdate.Rows[0]["C_DOCTYPE_ID"] =
                this.dtCommercialInvoiceUpdate.Rows[0]["C_DOCTYPETARGET_ID"];
            this.dtCommercialInvoiceUpdate.Rows[0]["ISAPPROVED"] = "Y";
            this.dtCommercialInvoiceUpdate.Columns.RemoveAt(
                this.dtCommercialInvoiceUpdate.Columns.IndexOf("UPDATED"));
            this.dtCommercialInvoiceUpdate.Rows[0]["PROCESSING"] = "N";
            this.dtCommercialInvoiceUpdate.Rows[0]["PROCESSED"] = "Y";

            #endregion
                        
            this.dtCommercialInvoiceLineCost =
                dtcurrentInvoiceDetail.Copy();
            dtcurrentInvoiceDetail.Clear();

            #region "fill Report Tables"

            this.dtsDocData.Tables["dtDocInfo"].Rows.Clear();
            DataRow dr2 = this.dtsDocData.Tables["dtDocInfo"].NewRow();
            dr2["documentName"] = this.ddgCommercialInvoice.SelectedItem.ToString();

            this.dtsDocData.Tables["dtDocInfo"].Rows.Add(dr2);

            this.copyCostCostList();

            decimal dcTotalInvoiceValue = 0;

            this.dtsDocData.Tables["dtCostDistribution"].Rows.Clear();

            DataRow dr;

            DataView dv = this.dtCommercialInvoiceLineCost.DefaultView;
            dv.Sort = "LINE ASC";
            this.dtCommercialInvoiceLineCost = dv.ToTable();

            for (int rowCounter = 0; rowCounter <= this.dtCommercialInvoiceLineCost.Rows.Count - 1; rowCounter++)
            {
                dr = this.dtsDocData.Tables["dtCostDistribution"].NewRow();

                dr["C_INVOICELINE_ID"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["C_INVOICELINE_ID"];
                dr["LINE"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["LINE"];
                dr["M_PRODUCT_ID"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["M_PRODUCT_ID"];
                dr["NAME"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["ITEM"];
                dr["QTYENTERED"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["QTYENTERED"];
                dr["PRICEENTERED"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["INV. PRICE"];
                dr["LINENETAMT"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["LINENETAMT"];
                dr["PRICEACTUAL"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["ACT. PRICE"];
                dr["TAXAMOUNT"] = this.dtCommercialInvoiceLineCost.Rows[rowCounter]["TAXAMT"];
                dr["TOTALAMOUNT"] = 
                    decimal.Parse(this.dtCommercialInvoiceLineCost.Rows[rowCounter]["ACT. PRICE"].ToString()) *
                    decimal.Parse(this.dtCommercialInvoiceLineCost.Rows[rowCounter]["QTYENTERED"].ToString());
                
                this.dtsDocData.Tables["dtCostDistribution"].Rows.Add(dr);

                dcTotalInvoiceValue += decimal.Parse(this.dtCommercialInvoiceLineCost.Rows[rowCounter]["LINENETAMT"].ToString());
            }

            for (int rowCounter = 0; rowCounter <= this.dtsDocData.Tables["dtCostDistribution"].Rows.Count - 1; rowCounter++)
            {
                this.dtsDocData.Tables["dtCostDistribution"].Rows[rowCounter]["Ratio"] =
                    Math.Round((decimal.Parse(this.dtsDocData.Tables["dtCostDistribution"].Rows[rowCounter]["LINENETAMT"].ToString()) /
                        dcTotalInvoiceValue) * 100,2);
            }
            
            #endregion

        }


        private void copyCostCostList()
        {
            this.dtsDocData.Tables["dtCostList"].Rows.Clear();
            
            int[] costChargeIndex;
            int costTaxID = -1;


            DataRow dr;

            for (int rowCounter = 0; rowCounter <= this.dtChangedPaymentInvoiceLines.Rows.Count - 1; rowCounter++)
            {                
                costTaxID = -1;

                if (this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    costTaxID =
                        int.Parse(this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"].ToString());

                    costChargeIndex =
                        this.searchTableRowIndex(this.dtsDocData.Tables["dtCostList"],
                                        "C_TAX_ID", costTaxID.ToString());

                    if (costChargeIndex.Length > 0)
                        if (costChargeIndex[0] != -1)
                        {
                            this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"] =
                                decimal.Parse(this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"].ToString()) +
                                decimal.Parse(this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["AMOUNTSHARED"].ToString());

                        continue;
                        }
                }
                else if (this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    costTaxID =
                        int.Parse(this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"].ToString());

                    costChargeIndex =
                        this.searchTableRowIndex(this.dtsDocData.Tables["dtCostList"],
                                        "C_CHARGE_ID", costTaxID.ToString());

                    if (costChargeIndex.Length > 0)
                        if (costChargeIndex[0] != -1)
                        {
                            this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"] =
                                    decimal.Parse(this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"].ToString()) +
                                    decimal.Parse(this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["AMOUNTSHARED"].ToString());

                            continue;
                        }
                }
                else
                    continue;

                dr = this.dtsDocData.Tables["dtCostList"].NewRow();

                if (this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    dr["C_TAX_ID"] = this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"];
                    dr["IsCost"] = "N";
                }
                else if (this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")                
                {
                    dr["C_CHARGE_ID"] = this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"];
                    dr["IsCost"] = "Y";
                }

                dr["AMOUNTSHARED"] = this.dtChangedPaymentInvoiceLines.Rows[rowCounter]["AMOUNTSHARED"];

                this.dtsDocData.Tables["dtCostList"].Rows.Add(dr);

            }
            

            for (int rowCounter = 0; rowCounter <= this.dtNewPaymentInvoiceLines.Rows.Count - 1; rowCounter++)
            {                
                costTaxID = -1;

                if (this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    costTaxID =
                        int.Parse(this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"].ToString());

                    costChargeIndex =
                        this.searchTableRowIndex(this.dtsDocData.Tables["dtCostList"],
                                        "C_TAX_ID", costTaxID.ToString());

                    if (costChargeIndex.Length > 0)
                        if (costChargeIndex[0] != -1)
                        {
                            this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"] =
                                    decimal.Parse(this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"].ToString()) +
                                    decimal.Parse(this.dtNewPaymentInvoiceLines.Rows[rowCounter]["AMOUNTSHARED"].ToString());

                            continue;
                        }
                }
                else if (this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    costTaxID =
                        int.Parse(this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"].ToString());

                    costChargeIndex =
                        this.searchTableRowIndex(this.dtsDocData.Tables["dtCostList"],
                                        "C_CHARGE_ID", costTaxID.ToString());

                    if (costChargeIndex.Length > 0)
                        if (costChargeIndex[0] != -1)
                        {
                            this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"] =
                                    decimal.Parse(this.dtsDocData.Tables["dtCostList"].Rows[costChargeIndex[0]]["AMOUNTSHARED"].ToString()) +
                                    decimal.Parse(this.dtNewPaymentInvoiceLines.Rows[rowCounter]["AMOUNTSHARED"].ToString());

                            continue;
                        }
                }
                else
                    continue;

                dr = this.dtsDocData.Tables["dtCostList"].NewRow();

                if (this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    dr["C_TAX_ID"] = this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_TAX_ID"];
                    dr["IsCost"] = "N";
                }
                else if (this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")                
                {
                    dr["C_CHARGE_ID"] = this.dtNewPaymentInvoiceLines.Rows[rowCounter]["C_CHARGE_ID"];
                    dr["IsCost"] = "Y";
                }

                dr["AMOUNTSHARED"] = this.dtNewPaymentInvoiceLines.Rows[rowCounter]["AMOUNTSHARED"];

                this.dtsDocData.Tables["dtCostList"].Rows.Add(dr);

            }


            DataTable dtNameInfo;

            for (int rowCounter = 0; rowCounter <= this.dtsDocData.Tables["dtCostList"].Rows.Count - 1; rowCounter++)
            {
                if (this.dtsDocData.Tables["dtCostList"].Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    dtNameInfo = this.getDataFromDB.getC_TAXInfo(null, "", "",
                        this.dtsDocData.Tables["dtCostList"].Rows[rowCounter]["C_TAX_ID"].ToString(), "", "",
                        false, triaStateBool.Ignor, triaStateBool.Ignor, false, "AND");

                }
                else if (this.dtsDocData.Tables["dtCostList"].Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    dtNameInfo = this.getDataFromDB.getC_CHARGEInfo(null, "", "",
                        this.dtsDocData.Tables["dtCostList"].Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                        "", false, false, "AND");
                }
                else
                
                    continue;
                

                if (this.getDataFromDB.checkIfTableContainesData(dtNameInfo))
                {
                    this.dtsDocData.Tables["dtCostList"].Rows[rowCounter]["NAME"] = 
                        dtNameInfo.Rows[0]["NAME"].ToString();
                    dtNameInfo.Rows.Clear();
                }
                else
                    this.dtsDocData.Tables["dtCostList"].Rows[rowCounter]["NAME"] = "Not Available";
            }

        }

        private void UpdateCompiereInvoiceTaxAndInvoicelineInfo(DataTable paymentInvoiceLine)
        {            
            //string invoiceLineDescription = "";
                     
            //int[] invoiceLineIndex;
            int[] invoiceTaxIndex;
                        
            decimal dcTaxAmount = 0;

            DataTable dtPayementResonInfo = new DataTable();

            DataRow drNewInvoiceTax;

            for (int rowCounter = paymentInvoiceLine.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dcTaxAmount = 0;
                if (paymentInvoiceLine.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    this.dcInvoiceTaxTotal +=
                        Convert.ToDecimal(paymentInvoiceLine.Rows[rowCounter]["AMOUNTSHARED"]);

                    invoiceTaxIndex =
                        this.searchTableRowIndex(this.dtNewCommercialInvoiceTax,
                                        "C_TAX_ID",
                                  paymentInvoiceLine.Rows[rowCounter]["C_TAX_ID"].ToString());

                    if (invoiceTaxIndex.Length > 0)
                    {
                        if (invoiceTaxIndex[0] != -1)
                        {
                            dcTaxAmount =
                                Convert.ToDecimal(this.dtNewCommercialInvoiceTax.Rows[invoiceTaxIndex[0]]
                                                        ["TAXAMT"]);

                            //this.dcInvoiceTaxTotal += dcTaxAmount;

                            dcTaxAmount +=
                                Convert.ToDecimal(paymentInvoiceLine.Rows[rowCounter]
                                                    ["AMOUNTSHARED"]);

                            this.dtNewCommercialInvoiceTax.Rows[invoiceTaxIndex[0]]["TAXAMT"] =
                               this.roundOff(dcTaxAmount, 2);
                                //decimal.Round(dcTaxAmount,3);
                            goto paymentReason;
                        }
                    }

                    drNewInvoiceTax = this.dtNewCommercialInvoiceTax.NewRow();

                    drNewInvoiceTax["C_TAX_ID"] =
                        paymentInvoiceLine.Rows[rowCounter]["C_TAX_ID"].ToString();
                    drNewInvoiceTax["C_INVOICE_ID"] =
                        this.ddgCommercialInvoice.SelectedRowKey.ToString();
                    drNewInvoiceTax["AD_CLIENT_ID"] =
                        generalResultInformation.clientId;
                    drNewInvoiceTax["AD_ORG_ID"] =
                        generalResultInformation.organiztionId;
                    drNewInvoiceTax["ISACTIVE"] = "Y";
                    drNewInvoiceTax["CREATEDBY"] =
                        generalResultInformation.userId;
                    drNewInvoiceTax["UPDATEDBY"] =
                            generalResultInformation.userId;

                    //drNewInvoiceTax["TAXBASEAMT"] = 0;

                    drNewInvoiceTax["TAXAMT"] = 
                       this.roundOff(Convert.ToDecimal(paymentInvoiceLine.Rows[rowCounter]["AMOUNTSHARED"]),2);
                        //decimal.Round(Convert.ToDecimal(paymentInvoiceLine.Rows[rowCounter]["AMOUNTSHARED"]),2);
                    drNewInvoiceTax["PROCESSED"] = "Y";
                    drNewInvoiceTax["ISTAXINCLUDED"] = "N";

                    //this.dcInvoiceTaxTotal +=
                    //    Convert.ToDecimal(paymentInvoiceLine.Rows[rowCounter]["AMOUNTSHARED"]);

                    this.dtNewCommercialInvoiceTax.Rows.Add(drNewInvoiceTax);

                paymentReason:
                    dtPayementResonInfo =
                        this.getDataFromDB.getC_TAXInfo(null, "", "",
                            paymentInvoiceLine.Rows[rowCounter]["C_TAX_ID"].ToString(),
                            "", "", false, triaStateBool.Ignor, triaStateBool.Ignor, false, "AND");
                }

                else
                {
                    dtPayementResonInfo =
                        this.getDataFromDB.getC_CHARGEInfo(null, "", "",
                            paymentInvoiceLine.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                            "", false, false, "AND");
                }

                //invoiceLineIndex =
                //    this.searchTableRowIndex(this.dtCommercialInvoiceLineUpdate, "C_INVOICELINE_ID",
                //        paymentInvoiceLine.Rows[rowCounter]["C_INVOICELINE_ID"].ToString());

                //if (invoiceLineIndex.Length > 0)
                //{
                //    if (invoiceLineIndex[0] != -1)
                //    {
                //        invoiceLineDescription =
                //            this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]
                //                    ["DESCRIPTION"].ToString();
                //        if (!invoiceLineDescription.Contains(" SUBJECTED TO :- "))
                //            invoiceLineDescription = invoiceLineDescription +
                //                        " SUBJECTED TO :- ";


                //        if (dtPayeResonInfo.Rows.Count > 0)
                //        {
                //            invoiceLineDescription = invoiceLineDescription +
                //                    dtPayeResonInfo.Rows[0]["NAME"].ToString();
                //            this.commaSeparatedNumber.Amount =
                //                decimal.Round(Convert.ToDecimal(paymentInvoiceLine.Rows[rowCounter]
                //                                ["AMOUNTSHARED"]),2).ToString();

                //            invoiceLineDescription = invoiceLineDescription + " - " +
                //                this.commaSeparatedNumber.Amount + "; ";
                //        }

                //        //this.dtCommercialInvoiceLineUpdate.Rows[invoiceLineIndex[0]]["DESCRIPTION"] =
                //        //    invoiceLineDescription;
                //    }
                //}
            }

        }

        private bool InvoiceContainsInActiveOrEstimatePayments(string C_ORDER_ID, 
            bool checkInActivePayments)
        {
            if (C_ORDER_ID == "")
                return true;
            DataTable paymentResult = new DataTable();
            if (checkInActivePayments)
            {
                paymentResult =
                    this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "",
                                generalResultInformation.organiztionId, "", "", "", C_ORDER_ID,
                                "", "", "", "", "", "", triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.no, false, "AND");
                if (paymentResult.Rows.Count > 0)
                    return true;
                else
                    return false;
            }

            paymentResult =
                    this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "",
                                generalResultInformation.organiztionId, "", "", "", C_ORDER_ID,
                                "", "", "", "", "", "", triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor,
                                triaStateBool.yes, triaStateBool.Ignor, false, "AND");

            if (paymentResult.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private triaStateBool checkIfInvoicePeriodIsOpen(string C_INVOICE_ID)
        {
            if (C_INVOICE_ID == "")
                return triaStateBool.no;

            DataTable dtInvoiceInformation = 
                this.getDataFromDB.getC_INVOICEInfo(null, "", "", C_INVOICE_ID, 
                    "", "", "", "", "", "", "", triaStateBool.no, triaStateBool.no, 
                    false, false, "AND");
            if (!this.getDataFromDB.checkIfTableContainesData(dtInvoiceInformation))
                return triaStateBool.Ignor;
            string stDocumetId = dtInvoiceInformation.Rows[0]["C_DOCTYPETARGET_ID"].ToString();
            DateTime InvoiceDate = Convert.ToDateTime(dtInvoiceInformation.Rows[0]["DATEINVOICED"]);

            DataTable dtInvoiceDocumentInformation =
                this.getDataFromDB.getC_DOCTYPEInfo(null, "", stDocumetId, "", "", false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtInvoiceDocumentInformation))
                return triaStateBool.Ignor;

            string stDocumentBaseType = dtInvoiceDocumentInformation.Rows[0]["DOCBASETYPE"].ToString();

            DataTable dtDocPeriodInfo =
                this.getDataFromDB.getC_PERIODInfo(null, "", "", InvoiceDate, true, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtDocPeriodInfo))
                return triaStateBool.no;

            string stDocPeriodId = dtDocPeriodInfo.Rows[0]["C_PERIOD_ID"].ToString();

            DataTable dtDocBasePeriodControlInfo =
                getDataFromDB.getC_PERIODCONTROLInfo(null, "", "", 
                    stDocPeriodId, stDocumentBaseType, true, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtDocBasePeriodControlInfo))
                return triaStateBool.no;
            else
            {
                if (dtDocBasePeriodControlInfo.Rows[0]["PERIODSTATUS"].ToString() != "O")
                    return triaStateBool.no;
                else
                    return triaStateBool.yes;
            }
        }

        private void freezUnfreezForm(bool freezForm)
        {
            this.cmdShowInvoiceLineCost.Enabled = freezForm;
            this.cmdRecordAndTransferCost.Enabled = freezForm;
            this.cmdShowCostSheet.Enabled = freezForm;
            this.ddgCommercialInvoice.Enabled = freezForm;
            this.dtgDistributableCost.Enabled = freezForm;
        }   
            
        
        //procedures of the form and its control
        private void frmGenerateItemCost_Load(object sender, EventArgs e)
        {   
            this.WindowState = FormWindowState.Normal;
            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.createInvoiceDisturbuatblePayment("");
            this.fillDistributableCostGridView();
            this.fillInvoiceLineCostGridView();            
            this.dtgInoiceTax.DataSource = this.establishInvoiceTaxData();

            this.dtValidCommercialInvoicesToClose = 
                this.establishValidCommercialInvoices("");            

            this.cmdRecordAndTransferCost.Enabled = false;
            this.cmdShowCostSheet.Enabled = false;
            this.cmdShowInvoiceLineCost.Enabled = false;
            this.TopMost = true;
            this.TopMost = false;
            this.Activate();
        }
        

        private void ddgCommercialInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            this.cmdShowInvoiceLineCost.Enabled = false;
            this.ddgCommercialInvoice.DataSource =
                 this.dtValidCommercialInvoicesToClose.Copy();

            if (this.ddgCommercialInvoice.DataSource.Rows.Count > 0)
            {
                this.ddgCommercialInvoice.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgCommercialInvoice.DataSource.Columns.IndexOf("C_INVOICE_ID"));
                this.ddgCommercialInvoice.SelectedColomnIdex =
                    this.ddgCommercialInvoice.DataSource.Columns.IndexOf("DOCUMENTNO");
                this.ddgCommercialInvoice.HiddenColoumns =
                    new int[] { this.ddgCommercialInvoice.DataSource.Columns.IndexOf("C_ORDER_ID") };
            }
        }

        private void ddgCommercialInvoice_selectedItemChanged(object sender, EventArgs e)
        {            
            string orderNumber = "";
            this.cmdRecordAndTransferCost.Enabled = false;
            this.cmdShowCostSheet.Enabled = false;

            this.lblPerformaInvoice.Text = "Performa Invoice: ";
            orderNumber = "";

            this.lblInvoiceSubTotal.Text = "Sub-Total: ";
            this.lblInvoiceTotal.Text = "Grand Total: ";

            this.dtNewInvoicePOmatching.Clear();
            this.dtNewCommercialInvoiceTax.Clear();
            this.dtCommercialInvoiceLineUpdate.Clear();
            this.dtCommercialInvoiceUpdate.Clear();

            this.dtNewPaymentInvoiceLines.Clear();
            this.dtChangedPaymentInvoiceLines.Clear();

            this.createInvoiceDisturbuatblePayment("");
            this.fillDistributableCostGridView();
            this.dtCommercialInvoiceLineCost.Clear();
            this.fillInvoiceLineCostGridView();
            this.dtgInoiceTax.DataSource =
                this.establishInvoiceTaxData();


            if (this.ddgCommercialInvoice.SelectedRow.Rows.Count > 0 ||
                this.ddgCommercialInvoice.SelectedRowKey != null)
            {
                orderNumber = 
                    this.ddgCommercialInvoice.SelectedRow.Rows[0]["C_ORDER_ID"].ToString();                

                this.lblPerformaInvoice.Text ="Performa Invoice: " +
                        this.getDataFromDB.getC_ORDERInfo(null, "", "", orderNumber,"",
                                        "", "", "", "", "", triaStateBool.no, triaStateBool.yes,
                                        false, false, "AND")
                              .Rows[0]["DOCUMENTNO"].ToString();
                this.createInvoiceDisturbuatblePayment(orderNumber);
                this.fillDistributableCostGridView();
                this.cmdShowInvoiceLineCost.Focus();
            }
            this.cmdShowInvoiceLineCost.Enabled = true;
        }


        private void dtgDistributableCost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgDistributableCost.SelectedRows.Count < 1)
                return;

            this.cmdRecordAndTransferCost.Enabled = false;
            this.cmdShowCostSheet.Enabled = false;

            int currentSelectedRowIndex = 
                this.dtgDistributableCost.SelectedRows[0].Index;

            if (this.dtgDistributableCost.CurrentCell.OwningColumn.Index == 0 &&
                this.dtgDistributableCost.CurrentCell.OwningColumn.Name == "INCLUDE")
            {
                this.dtgDistributableCost.CurrentCell.Value =
                    !(Convert.ToBoolean(this.dtgDistributableCost.CurrentCell.Value.ToString()));
                this.dtInvoiceOrderDistributablePayments.Rows[currentSelectedRowIndex]["INCLUDE"] =
                    (Convert.ToBoolean(this.dtgDistributableCost.CurrentCell.Value.ToString()));
                this.dtInvoiceOrderDistributablePayments.Rows[currentSelectedRowIndex]["COSTCLOSED"] =
                    this.translateBoolToCharacter(
                        (Convert.ToBoolean(this.dtgDistributableCost.CurrentCell.Value.ToString())));
            }

            else if(this.dtgDistributableCost.CurrentCell.OwningColumn.Index == 1 &&
                    this.dtgDistributableCost.CurrentCell.OwningColumn.Name == "REMAING AMOUNT")
            {
                this.dtgDistributableCost.CurrentCell.Value =
                    !(Convert.ToBoolean(this.dtgDistributableCost.CurrentCell.Value.ToString()));
                this.dtInvoiceOrderDistributablePayments.Rows[currentSelectedRowIndex]["REMAING AMOUNT"] =
                    (Convert.ToBoolean(this.dtgDistributableCost.CurrentCell.Value.ToString()));
            }
        }


        private void cmdShowInvoiceLineCost_Click(object sender, EventArgs e)
        {
            if (this.ddgCommercialInvoice.SelectedRowKey == null)
                return;

            string orderNumber =
                    this.ddgCommercialInvoice.SelectedRow.Rows[0]["C_ORDER_ID"].ToString();
            if (orderNumber == "")
                return;
            if (this.InvoiceContainsInActiveOrEstimatePayments(orderNumber, true))
            {
                DialogResult result =
                    MessageBox.Show("This Invoice contains InActive Payment which will" +
                                    " Not be considered for Costing.\n" +
                                    "Do You like to proceed", "Cost Closing",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    //this.ddgCommercialInvoice.SelectedRow.Clear();
                    //this.ddgCommercialInvoice.SelectedRowKey = null;
                    //this.ddgCommercialInvoice.SelectedItem = "";
                    return;
                }
            }

            if (this.InvoiceContainsInActiveOrEstimatePayments(orderNumber, false))
            {
                DialogResult result =
                    MessageBox.Show("This Invoice contains Estimate Payments.\n" +
                                    "Do You like to proceed", "Cost Closing",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    //this.ddgCommercialInvoice.SelectedRow.Clear();
                    //this.ddgCommercialInvoice.SelectedRowKey = null;
                    //this.ddgCommercialInvoice.SelectedItem = "";
                    return;
                }
            }



            
            this.lblInvoiceSubTotal.Text = "Sub-Total: ";
            this.lblInvoiceTotal.Text = "Grand Total: ";

            this.determineInvoiceShareFromEachDistributablePayment();
            this.determineInoiceLineCost();

            this.fillInvoiceLineCostGridView();
            if (this.dtCommercialInvoiceLineCost.Rows.Count <= 0)
            {
                this.freezUnfreezForm(true);
                return;
            }

            this.dtgInoiceTax.DataSource =
                this.establishInvoiceTaxData();

            this.commaSeparatedNumber.Amount =
                decimal.Round(this.dcInvoiceSubTotal,2).ToString();
                //this.roundOff(this.dcInvoiceSubTotal, 2).ToString();
                

            this.lblInvoiceSubTotal.Text +=
                this.commaSeparatedNumber.Amount;

            this.commaSeparatedNumber.Amount =
                this.roundOff((this.dcInvoiceSubTotal + this.dcInvoiceTaxTotal), 2).ToString();
                //decimal.Round((this.dcInvoiceSubTotal + this.dcInvoiceTaxTotal),2).ToString();

            this.lblInvoiceTotal.Text +=
                this.commaSeparatedNumber.Amount;            
            this.cmdRecordAndTransferCost.Enabled = true;
            this.cmdShowCostSheet.Enabled = true;
            this.freezUnfreezForm(true);
        }

        private void cmdShowInvoiceLineCost_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.cmdShowInvoiceLineCost.Enabled)
            {
                this.cmdRecordAndTransferCost.Enabled = false;
                this.cmdShowCostSheet.Enabled = false;
                this.dtgInoiceTax.DataSource = this.establishInvoiceTaxData();
                this.createInvoiceDisturbuatblePayment("");
                this.dtCommercialInvoiceLineCost.Clear();
                this.dtgInvoiceLineCost.DataSource =
                    this.dtCommercialInvoiceLineCost;                
            }
        }
       

        private void cmdRecordAndTransferCost_Click(object sender, EventArgs e)
        {
            
            if (this.dtCommercialInvoiceLineCost.Rows.Count == 0)
                return;

            if (MessageBox.Show("This Will Close Current Invoice and Any Relevant Payment" + 
                    " From any further modification.\n \t\t\tAre you sure you want to proceed.",
                    "Cost Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            triaStateBool tsDocumentPeriodStatus = 
                this.checkIfInvoicePeriodIsOpen(this.ddgCommercialInvoice.SelectedRowKey.ToString());

            if (tsDocumentPeriodStatus != triaStateBool.yes)
            {
                //if (MessageBox.Show("Period Is Closed For Commercial Invoice. \n" +
                //         " Are you sure you want to proceed.", "Cost Transfer",
                //         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                MessageBox.Show("Period Is Closed For Commercial Invoice. \n" +
                         " Please correct period before you proceed.", "Cost Transfer",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto ClearData;
            }

            this.freezUnfreezForm(false);
            
            try
            {
                //Adjuct The Costed Status To "Y" to all Included Payments.
                //FOR COMMERCIAL INVOICE PAYMENTS WHICH ARE ACTIVE.

                string dmlChangeCostStatusForActivePaymentOfCurrentInvoice =
                    "UPDATE PM_C_PURCHASEPAYMENT SET COSTCLOSED = 'Y' " +
                    "WHERE C_INVOICE_ID = " + this.ddgCommercialInvoice.SelectedRowKey.ToString() +
                    " AND ISACTIVE = 'Y'";

                this.getDataFromDB.executeSqlOnCompiere(dmlChangeCostStatusForActivePaymentOfCurrentInvoice);

                //FOR DISTRIBUTABLE PAYMENTS WHICH ARE INCLUDED.
                this.getDataFromDB.changeDataBaseTableData(this.dtInvoiceOrderDistributablePayments.Copy(),
                    "PM_C_PURCHASEPAYMENT", "UPDATE");
                this.dtInvoiceOrderDistributablePayments.Clear();

                //Record New Payment Invoice Cost Share If exist Any.
                this.getDataFromDB.changeDataBaseTableData(this.dtCommercialInvoiceCostShare,
                    "PM_PAYMENT_INVOCESHARE", "INSERT");
                this.dtCommercialInvoiceCostShare.Clear();

                //Update Share Amount Of Inoice Line for Existing Commercial Invoice Payment
                this.getDataFromDB.changeDataBaseTableData(this.dtChangedPaymentInvoiceLines,
                            "PM_C_PPAYMENT_INVOCELINE", "UPDATE");
                this.dtChangedPaymentInvoiceLines.Clear();

                //Insert New Payment Invoice Line For distributed cost of Invoice.
                this.getDataFromDB.changeDataBaseTableData(this.dtNewPaymentInvoiceLines,
                    "PM_C_PPAYMENT_INVOCELINE", "INSERT");
                this.dtNewPaymentInvoiceLines.Clear();

                //UPDATE COMPIERE INVOICE LINE COST
                for (int rowCounter = this.dtCommercialInvoiceLineUpdate.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    this.dtCommercialInvoiceLineUpdate.Rows[rowCounter]["TAXAMT"] = 0;
                }
                this.getDataFromDB.changeDataBaseTableData(this.dtCommercialInvoiceLineUpdate,
                    "C_INVOICELINE", "UPDATE");
                this.dtCommercialInvoiceLineUpdate.Clear();

                //UPADATE COMPIERE ORDER LINE INVOICED QUANTITY
                DataTable dtInvoiceLineInfo =
                    this.getDataFromDB.getC_INVOICELINEInfo(null, "", "",
                            this.ddgCommercialInvoice.SelectedRowKey.ToString(), 
                            "", "", "", triaStateBool.no, triaStateBool.Ignor, true, false, "AND");
                DataTable dtOrderLineInfo = new DataTable();
                string stInvoiceLineOrderLineId = "";
                for (int invoiceLineRowCounter = dtInvoiceLineInfo.Rows.Count - 1;
                    invoiceLineRowCounter >= 0; invoiceLineRowCounter--)
                {
                    stInvoiceLineOrderLineId =
                        dtInvoiceLineInfo.Rows[invoiceLineRowCounter]["C_ORDERLINE_ID"].ToString();
                    dtOrderLineInfo = this.getDataFromDB.getC_ORDERLINEInfo(null, "", "", "", 
                        stInvoiceLineOrderLineId, "", "", triaStateBool.Ignor, 
                        triaStateBool.Ignor, false, false, "AND");
                    if (!this.getDataFromDB.checkIfTableContainesData(dtOrderLineInfo))
                    {
                        MessageBox.Show("Unable to find orderLine. Closing can not procceed. "+
                            "\nPlease Contact Your Administrator", "Cost Transfer");
                        goto ClearData;                        
                    }
                    dtOrderLineInfo.Rows[0]["QTYINVOICED"] =
                        Convert.ToDecimal(dtOrderLineInfo.Rows[0]["QTYINVOICED"]) +
                        Convert.ToDecimal(dtInvoiceLineInfo.Rows[invoiceLineRowCounter]["QTYINVOICED"]);
                    this.getDataFromDB.changeDataBaseTableData(dtOrderLineInfo,
                        "C_ORDERLINE", "UPDATE");
                    stInvoiceLineOrderLineId = "";
                }

                //CLEAR COMPIERE INOICE TAX AND CREATE NEW TAX
                DataTable invoiceTax =
                    this.getDataFromDB.getC_INVOICETAXInfo(null, "", "",
                        this.ddgCommercialInvoice.SelectedRowKey.ToString(), "",
                        triaStateBool.Ignor, triaStateBool.Ignor, false, false, "AND");
                this.getDataFromDB.changeDataBaseTableData(invoiceTax,
                    "C_INVOICETAX", "DELETE");
                invoiceTax.Dispose();

                this.getDataFromDB.changeDataBaseTableData(this.dtNewCommercialInvoiceTax,
                    "C_INVOICETAX", "INSERT");
                this.dtNewCommercialInvoiceTax.Clear();


                //UPDATE COMPIERE INOICE SUMMARY
                this.getDataFromDB.changeDataBaseTableData(this.dtCommercialInvoiceUpdate,
                    "C_INVOICE", "UPDATE");
                this.dtCommercialInvoiceUpdate.Clear();

                //CREATE COMPIERE PO INVOICE MATHCING
                this.getDataFromDB.changeDataBaseTableData(this.dtNewInvoicePOmatching,
                    "M_MATCHPO", "INSERT");
                this.dtNewInvoicePOmatching.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Occured While Closing. Error Message " +
                    "{ " + ex.Message + " } \n. Please Contact Your Administrator Before Proceeding",
                    "Cost Transfer",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            //Clear For to Normal state;            
            ClearData :
            this.dtValidCommercialInvoicesToClose =
                this.establishValidCommercialInvoices("");

            this.ddgCommercialInvoice.SelectedRow.Clear();
            this.ddgCommercialInvoice.SelectedRowKey = null;
            this.ddgCommercialInvoice.SelectedItem = "";
            this.ddgCommercialInvoice_selectedItemChanged(sender, e);

            this.freezUnfreezForm(true);
        }

        private void cmdShowCostSheet_Click(object sender, EventArgs e)
        {
            frmDocPrintPreview frmDocPrv = new frmDocPrintPreview();
            frmDocPrv.dtsDocumentPrintView = this.dtsDocData;

            frmDocPrv.ShowDialog();
        }


        
    }
}
