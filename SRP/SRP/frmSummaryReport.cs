using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRP
{
    public partial class frmSummaryReport : Panel
    {
        public frmSummaryReport()
        {
            InitializeComponent();
        }

        DataTable searchQuery = new DataTable();
        DataTable dtReportBrakDown = new DataTable();

        ctlNumberTextBox commaConverter = new ctlNumberTextBox();

        private dataBuilder getDatafromDataBase = new dataBuilder();


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

            if (this.cmbTrxDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TRXDATE", this.cmbTrxDateLogic.SelectedItem.ToString(),
                    this.dtpTrxDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpTrxDateTo.Value.ToString("yyyy-MM-dd"));
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

        

        public void frmSummaryReport_Load(object sender, EventArgs e)
        {
            this.cmbTrxDateLogic.SelectedItem = "IGNOR";

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.dtReportBrakDown.Columns.Add("Category");
            this.dtReportBrakDown.Columns.Add("Total Sales");
            this.dtReportBrakDown.Columns.Add("Negated Sales");
            this.dtReportBrakDown.Columns.Add("Total Purchase");
            this.dtReportBrakDown.Columns.Add("Negated Purchase");
            this.dtReportBrakDown.Columns.Add("Turn Over");
            this.dtReportBrakDown.Columns.Add("M_PRODUCTCATEGORY_ID");

            this.dtgReportBreakDown.DataSource = this.dtReportBrakDown;
            this.dtgReportBreakDown.Columns["M_PRODUCTCATEGORY_ID"].Visible = false;
        }

        private void cmbTrxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxDateLogic.SelectedItem.ToString(),
                this.dtpTrxDateFrom);

            if (this.cmbTrxDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpTrxDateTo.Visible = true;
            else
                this.dtpTrxDateTo.Visible = false;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.establishSearchCriterion();
            this.dtReportBrakDown.Rows.Clear();
            DataTable dtPrdCategoryInfo = new DataTable();
            
            DataTable dtTrxReportList =
                this.getDatafromDataBase.getT_TRXDETAILInfo
                            (this.searchQuery, "AND", "", "", "", new DateTime(),
                                false, triStateBool.ignor, "", triStateBool.ignor,
                                false, "AND");

            string stTypeOfAmount = "";            
            string stProductId = "";

            decimal intTotalSales = 0;
            decimal intTotalPurchase = 0;
            decimal intNegatedSales = 0;
            decimal intNegatedPurchase = 0;

            bool categoryFound = false;

            for (int rowResultCounter = 0;
                rowResultCounter <= dtTrxReportList.Rows.Count - 1; rowResultCounter++)
            {
                if (dtTrxReportList.Rows[rowResultCounter]["ISSALESTRX"].ToString() == "Y")
                    stTypeOfAmount = "Total Sales";
                else
                    stTypeOfAmount = "Total Purchase";

                DataTable dtTrxInfo =
                    this.getDatafromDataBase.getT_TRANSACTIONInfo(null, "",
                            dtTrxReportList.Rows[rowResultCounter]["T_TRANSACTION_ID"].ToString(),
                            "", "", new DateTime(), false, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor,
                            transactionStatus.Reversed, false, "AND");

                if (dtTrxInfo.Rows.Count > 0)
                {
                    stTypeOfAmount = stTypeOfAmount.Replace("Total", "Negated");
                }


                stProductId = 
                    dtTrxReportList.Rows[rowResultCounter]["M_PRODUCT_ID"].ToString();
                if(stProductId == "")
                    continue;

                dtPrdCategoryInfo =
                    this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, "",
                            stProductId, "", triStateBool.ignor, false, "AND");
                
                if(dtPrdCategoryInfo.Rows.Count < 1)
                    continue;

                categoryFound = false;
                for (int rowRptBrkDwnCnt = 0; 
                        this.dtReportBrakDown.Rows.Count > rowRptBrkDwnCnt;
                        rowRptBrkDwnCnt++)
                {
                    if (this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["M_PRODUCTCATEGORY_ID"].ToString() !=
                        dtPrdCategoryInfo.Rows[0]["M_PRODUCTCATEGORY_ID"].ToString())
                        continue;
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt][stTypeOfAmount] =
                        decimal.Parse(this.dtReportBrakDown.Rows[rowRptBrkDwnCnt][stTypeOfAmount].ToString()) +
                        decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    if (stTypeOfAmount == "Total Sales")
                        intTotalSales +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    else if (stTypeOfAmount == "Total Purchase")
                        intTotalPurchase +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    else if (stTypeOfAmount == "Negated Sales")
                        intNegatedSales +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    else if (stTypeOfAmount == "Negated Purchase")
                        intNegatedPurchase +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    categoryFound = true;
                    break;
                }
                if (!categoryFound)
                {
                    DataRow drNewBrkDwnRptRw = dtReportBrakDown.NewRow();
                    drNewBrkDwnRptRw["Category"] = 
                        dtPrdCategoryInfo.Rows[0]["NAME"].ToString();
                    drNewBrkDwnRptRw["M_PRODUCTCATEGORY_ID"] = 
                        dtPrdCategoryInfo.Rows[0]["M_PRODUCTCATEGORY_ID"].ToString();
                    if (stTypeOfAmount == "Total Sales")
                    {
                        drNewBrkDwnRptRw["Total Sales"] =
                            dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString();
                        drNewBrkDwnRptRw["Total Purchase"] = "0";
                        drNewBrkDwnRptRw["Negated Sales"] = "0";
                        drNewBrkDwnRptRw["Negated Purchase"] = "0";
                        intTotalSales +=
                           decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    }
                    else if (stTypeOfAmount == "Total Purchase")
                    {
                        drNewBrkDwnRptRw["Total Purchase"] =
                           dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString();
                        drNewBrkDwnRptRw["Total Sales"] = "0";                        
                        drNewBrkDwnRptRw["Negated Sales"] = "0";
                        drNewBrkDwnRptRw["Negated Purchase"] = "0";
                        intTotalPurchase +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    }
                    else if (stTypeOfAmount == "Negated Sales")
                    {
                        drNewBrkDwnRptRw["Negated Sales"] =
                           dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString();
                        drNewBrkDwnRptRw["Negated Purchase"] = "0";
                        drNewBrkDwnRptRw["Total Purchase"] = "0";
                        drNewBrkDwnRptRw["Total Sales"] = "0";
                        intNegatedSales +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    }
                    else if (stTypeOfAmount == "Negated Purchase")
                    {
                        drNewBrkDwnRptRw["Negated Purchase"] =
                           dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString();
                        drNewBrkDwnRptRw["Negated Sales"] = "0";
                        drNewBrkDwnRptRw["Total Purchase"] = "0";
                        drNewBrkDwnRptRw["Total Sales"] = "0";
                        intNegatedPurchase +=
                            decimal.Parse(dtTrxReportList.Rows[rowResultCounter]["LINENETAMT"].ToString());
                    }
                    this.dtReportBrakDown.Rows.Add(drNewBrkDwnRptRw);
                }                
            }
            commaConverter.Amount = intTotalSales.ToString();
            this.lblValueTotalSales.Text = commaConverter.Value;
            commaConverter.Amount = intTotalPurchase.ToString();
            this.lblValueTotalPurchase.Text = commaConverter.Value;

            commaConverter.Amount = intNegatedSales.ToString();
            this.lblValueRefundedSales.Text = commaConverter.Value;
            commaConverter.Amount = intNegatedPurchase.ToString();
            this.lblValueRefundedPurchase.Text = commaConverter.Value; 

            commaConverter.Amount = (intTotalSales - intTotalPurchase).ToString();
            this.lblTotalTurnOver.Text = commaConverter.Value;

            for (int rowRptBrkDwnCnt = 0;
                        this.dtReportBrakDown.Rows.Count > rowRptBrkDwnCnt;
                        rowRptBrkDwnCnt++)
            {
                this.commaConverter.Amount =
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Sales"].ToString();
                this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Sales"] =
                    this.commaConverter.Value;
                this.commaConverter.Amount =
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Purchase"].ToString();
                this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Purchase"] =
                    this.commaConverter.Value;

                this.commaConverter.Amount =
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Negated Sales"].ToString();
                this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Negated Sales"] =
                    this.commaConverter.Value;
                this.commaConverter.Amount =
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Negated Purchase"].ToString();
                this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Negated Purchase"] =
                    this.commaConverter.Value;

                this.commaConverter.Amount =
                    (decimal.Parse(this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Sales"].ToString()) -
                    decimal.Parse(this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Purchase"].ToString())).ToString();
                if((decimal.Parse(this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Sales"].ToString()) -
                    decimal.Parse(this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Total Purchase"].ToString())) < 0)
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Turn Over"] = 
                        "-" + this.commaConverter.Value;
                else
                    this.dtReportBrakDown.Rows[rowRptBrkDwnCnt]["Turn Over"] =
                        this.commaConverter.Value;

            }

        }

    }
}
