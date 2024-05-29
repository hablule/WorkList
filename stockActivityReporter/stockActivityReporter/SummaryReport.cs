using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using dbConnection;
using System.Windows.Forms;

namespace stockActivityReporter
{
    class SummaryReport
    {
        public string logicalConnector = "AND";
        public string stProductID = "";

        public string stActivityRange = "";
        //public string stLocatorID = "";
        
        
        public string stDateLogicSelectedItem = "";

        public string cmbDateLogic;
        public string cmbProductLogic;

        public string ddgProduct = "";
        public string[] cbcbStoreList;

        public bool ckAllOrAny;
        public bool ckShowCountSheet;
        public bool ckShowDormentStock;

        public DateTime dtpFromDate;
        public DateTime dtpToDate;


        public DataTable dtsearchResult = new DataTable();
        public DataTable dtsearchQuery = new DataTable();
        public DataTable dtAllLocators;

        dataBuilder getDataFromDB = new dataBuilder();

        dtsTransactionInfo dtsTrxInfo = new dtsTransactionInfo();


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
                DataRow criteriaValue = this.dtsearchQuery.NewRow();

                criteriaValue["Field"] = field;
                criteriaValue["Criterion"] = this.generateEquivalentSymbol(criterion);
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.dtsearchQuery.Rows.Add(criteriaValue);
            }

        }
        
        private void establishSearchCriterion()
        {
            this.dtsearchQuery.Rows.Clear();
            

            if (this.cmbProductLogic != "IGNOR" &&
                this.ddgProduct != "")
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic,
                    this.ddgProduct, "");
            }


            if (this.cmbDateLogic != "IGNOR")
            {
                this.addMoreCriteria("MOVEMENTDATE", this.cmbDateLogic,
                    this.dtpFromDate.ToString(generalResultInformation.dateFormat),
                    this.dtpToDate.ToString(generalResultInformation.dateFormat));
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



        private DataTable establishDeadStockSummary(string stProductID, string stStoreId)
        {
            DataTable dtResult = new DataTable();

            string stDateLogicSelectedItem =
                    this.cmbDateLogic;

            if (stDateLogicSelectedItem == "IGNOR" ||
                stDateLogicSelectedItem == "Less than" ||
                stDateLogicSelectedItem == "Lesser or equal to")
            {
                return dtResult;
            }

            DateTime endDate =
                    (
                         //stDateLogicSelectedItem == "IGNOR" ||
                         stDateLogicSelectedItem == "Greater or equals to" ||
                         stDateLogicSelectedItem == "Greater than"
                       ) ? DateTime.Now :
                    (
                         stDateLogicSelectedItem == "Equals to" //||
                         //stDateLogicSelectedItem == "Lesser or equal to" ||
                         //stDateLogicSelectedItem == "In between of"
                       ) ? this.dtpFromDate : this.dtpToDate;
           

            //Get Items To be Include In Each

            //Get All Active Stock Items Prior to begging of Activity AND
            //Get All Active Stock Items During Period

            DataTable dtIntrimResult =
                        this.getDataFromDB.getRV_STOCK_BALANCE_RPT(stProductID, stStoreId, endDate, false, "AND");

            dtResult.Merge(dtIntrimResult, true, MissingSchemaAction.Add);
            
            if (!this.getDataFromDB.checkIfTableContainesData(dtResult))
                return dtResult;


            dtResult.Columns.Add("BBF");
            dtResult.Columns.Add("Purchases");
            dtResult.Columns.Add("TRF_IN");
            dtResult.Columns.Add("TRF_OUT");
            dtResult.Columns.Add("Sales");
            dtResult.Columns.Add("Others");
            dtResult.Columns.Add("Balance");

            
            this.dtsearchQuery.Rows.Clear();

            if (this.cmbDateLogic != "IGNOR")
            {
                this.addMoreCriteria("MOVEMENTDATE", this.cmbDateLogic,
                    this.dtpFromDate.ToString(generalResultInformation.dateFormat),
                    this.dtpToDate.ToString(generalResultInformation.dateFormat));
            }

            for (int rowCounter = dtResult.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                //if (decimal.Parse(dtResult.Rows[rowCounter]["ENDBALANCE"].ToString()) == 0)
                //{
                //    dtResult.Rows.RemoveAt(rowCounter);
                //    continue;
                //}

                string storeID = dtResult.Rows[rowCounter]["M_LOCATOR_ID"].ToString();
                string ProductID = dtResult.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                DataTable dtTrxDetail =
                    this.getDataFromDB.getRV_SUMMARY_STOCK_ACTIVITY_RPT(this.dtsearchQuery, "AND",
                           ProductID, storeID, false, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtTrxDetail))
                {
                    dtResult.Rows.RemoveAt(rowCounter);
                    continue;
                }

                dtResult.Rows[rowCounter]["TRF_IN"] = 0;
                dtResult.Rows[rowCounter]["TRF_OUT"] = 0;
                dtResult.Rows[rowCounter]["Purchases"] = 0;
                dtResult.Rows[rowCounter]["Sales"] = 0;
                dtResult.Rows[rowCounter]["Others"] = 0;

                dtResult.Rows[rowCounter]["BBF"] = dtResult.Rows[rowCounter]["ENDBALANCE"];
                dtResult.Rows[rowCounter]["Balance"] = dtResult.Rows[rowCounter]["ENDBALANCE"];

            }

            dtResult.Columns.Remove("ENDBALANCE");
            return dtResult;
        }

        private void establishStockActivtiySummary()
        {
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
                return;

            if (!this.dtsearchResult.Columns.Contains("MOVEMENTTYPE"))
                return;

            if (!this.dtsearchResult.Columns.Contains("MOVEMENTQTY"))
                return;

            if (!this.dtsearchResult.Columns.Contains("BBF"))
                this.dtsearchResult.Columns.Add("BBF");
            if (!this.dtsearchResult.Columns.Contains("Purchases"))
                this.dtsearchResult.Columns.Add("Purchases");
            if (!this.dtsearchResult.Columns.Contains("TRF_IN"))
                this.dtsearchResult.Columns.Add("TRF_IN");
            if (!this.dtsearchResult.Columns.Contains("TRF_OUT"))
                this.dtsearchResult.Columns.Add("TRF_OUT");
            if (!this.dtsearchResult.Columns.Contains("Sales"))
                this.dtsearchResult.Columns.Add("Sales");
            if (!this.dtsearchResult.Columns.Contains("Others"))
                this.dtsearchResult.Columns.Add("Others");
            if (!this.dtsearchResult.Columns.Contains("Balance"))
                this.dtsearchResult.Columns.Add("Balance");

            for (int rowCounter = 0; rowCounter <= this.dtsearchResult.Rows.Count - 1; rowCounter++)
            {
                string storeID = this.dtsearchResult.Rows[rowCounter]["M_LOCATOR_ID"].ToString();
                string ProductID = this.dtsearchResult.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                this.dtsearchResult.Rows[rowCounter]["TRF_IN"] = 0;
                this.dtsearchResult.Rows[rowCounter]["TRF_OUT"] = 0;
                this.dtsearchResult.Rows[rowCounter]["Purchases"] = 0;
                this.dtsearchResult.Rows[rowCounter]["Sales"] = 0;
                this.dtsearchResult.Rows[rowCounter]["Others"] = 0;

                string stMOVEMENTTYPE =
                            this.dtsearchResult.Rows[rowCounter]["MOVEMENTTYPE"].ToString();

                if (stMOVEMENTTYPE == "")
                {
                    continue;
                }

                if (stMOVEMENTTYPE == "M+")
                {
                    this.dtsearchResult.Rows[rowCounter]["TRF_IN"] =
                        double.Parse(this.dtsearchResult.Rows[rowCounter]["MOVEMENTQTY"].ToString());

                }
                else if (stMOVEMENTTYPE == "M-")
                {
                    this.dtsearchResult.Rows[rowCounter]["TRF_OUT"] =
                        double.Parse(this.dtsearchResult.Rows[rowCounter]["MOVEMENTQTY"].ToString());
                }
                else if (stMOVEMENTTYPE == "V+" || stMOVEMENTTYPE == "V-")
                {
                    this.dtsearchResult.Rows[rowCounter]["Purchases"] =
                        double.Parse(this.dtsearchResult.Rows[rowCounter]["MOVEMENTQTY"].ToString());
                }
                else if (stMOVEMENTTYPE == "C+" || stMOVEMENTTYPE == "C-")
                {
                    this.dtsearchResult.Rows[rowCounter]["Sales"] =
                        double.Parse(this.dtsearchResult.Rows[rowCounter]["MOVEMENTQTY"].ToString());
                }
                else if (stMOVEMENTTYPE == "I+" || stMOVEMENTTYPE == "I-" || 
                         stMOVEMENTTYPE == "P+" || stMOVEMENTTYPE == "P-")
                {
                    this.dtsearchResult.Rows[rowCounter]["Others"] =
                        double.Parse(this.dtsearchResult.Rows[rowCounter]["MOVEMENTQTY"].ToString());
                }



                for (int rowCounter2 = this.dtsearchResult.Rows.Count - 1; rowCounter2 > rowCounter; rowCounter2--)
                {

                    if (this.dtsearchResult.Rows[rowCounter]["M_PRODUCT_ID"].ToString() ==
                        this.dtsearchResult.Rows[rowCounter2]["M_PRODUCT_ID"].ToString() &&
                        this.dtsearchResult.Rows[rowCounter]["M_LOCATOR_ID"].ToString() ==
                        this.dtsearchResult.Rows[rowCounter2]["M_LOCATOR_ID"].ToString())
                    {
                        stMOVEMENTTYPE =
                            this.dtsearchResult.Rows[rowCounter2]["MOVEMENTTYPE"].ToString();

                        if (stMOVEMENTTYPE == "M+")
                        {
                            this.dtsearchResult.Rows[rowCounter]["TRF_IN"] =
                                double.Parse(this.dtsearchResult.Rows[rowCounter]["TRF_IN"].ToString()) +
                                double.Parse(this.dtsearchResult.Rows[rowCounter2]["MOVEMENTQTY"].ToString());

                        }
                        else if (stMOVEMENTTYPE == "M-")
                        {
                            this.dtsearchResult.Rows[rowCounter]["TRF_OUT"] =
                                double.Parse(this.dtsearchResult.Rows[rowCounter]["TRF_OUT"].ToString()) +
                                double.Parse(this.dtsearchResult.Rows[rowCounter2]["MOVEMENTQTY"].ToString());
                        }
                        else if (stMOVEMENTTYPE == "V+" || stMOVEMENTTYPE == "V-")
                        {
                            this.dtsearchResult.Rows[rowCounter]["Purchases"] =
                                double.Parse(this.dtsearchResult.Rows[rowCounter]["Purchases"].ToString()) +
                                double.Parse(this.dtsearchResult.Rows[rowCounter2]["MOVEMENTQTY"].ToString());
                        }
                        else if (stMOVEMENTTYPE == "C+" || stMOVEMENTTYPE == "C-")
                        {
                            this.dtsearchResult.Rows[rowCounter]["Sales"] =
                                double.Parse(this.dtsearchResult.Rows[rowCounter]["Sales"].ToString()) +
                                double.Parse(this.dtsearchResult.Rows[rowCounter2]["MOVEMENTQTY"].ToString());
                        }
                        else if (stMOVEMENTTYPE == "I+" || stMOVEMENTTYPE == "I-"|| 
                                 stMOVEMENTTYPE == "P+" || stMOVEMENTTYPE == "P-")
                        {
                            this.dtsearchResult.Rows[rowCounter]["Others"] =
                                double.Parse(this.dtsearchResult.Rows[rowCounter]["Others"].ToString()) +
                                double.Parse(this.dtsearchResult.Rows[rowCounter2]["MOVEMENTQTY"].ToString());
                        }
                        this.dtsearchResult.Rows.RemoveAt(rowCounter2);
                    }
                }

                //Determine Record Starting And Ending Balance

                string stDateLogicSelectedItem =
                    this.cmbDateLogic.ToString();

                if (stDateLogicSelectedItem != "IGNOR")
                {
                    if (stDateLogicSelectedItem == "In between of")
                    {
                        this.stActivityRange = 
                            this.dtpFromDate.ToString("MM/dd/yyyy") + " - " +
                            this.dtpToDate.ToString("MM/dd/yyyy");

                    }
                    else
                        this.stActivityRange = this.generateEquivalentSymbol(stDateLogicSelectedItem) + " " +
                            this.dtpFromDate.ToString("MM/dd/yyyy");
                }
                else
                    this.stActivityRange = "All";

                double BBFqty = 0;

                if (stDateLogicSelectedItem != "IGNOR" &&
                    stDateLogicSelectedItem != "Less than" &&
                    stDateLogicSelectedItem != "Lesser or equal to")
                {
                    DateTime BBFDate =
                        (stDateLogicSelectedItem == "Equals to" ||
                            stDateLogicSelectedItem == "Greater or equals to" ||
                            stDateLogicSelectedItem == "In between of"
                         ) ? this.dtpFromDate.AddDays(-1) : this.dtpFromDate;

                    string stBBFDate = BBFDate.ToString(generalResultInformation.dateFormat);

                    string getBBFqty = "SELECT STOCK_BALANCETODATE(" +
                                            ProductID + "," + storeID + ",'" + stBBFDate +
                                        "') FROM DUAL";

                    DataTable dtBBFQty = (DataTable)this.getDataFromDB.executeSqlOnDB(getBBFqty);
                    if (this.getDataFromDB.checkIfTableContainesData(dtBBFQty))
                        BBFqty = double.Parse(dtBBFQty.Rows[0][0].ToString());
                }


                double ENDqty = 0;

                DateTime endDate =
                    (
                         stDateLogicSelectedItem == "IGNOR" ||
                         stDateLogicSelectedItem == "Greater or equals to" ||
                         stDateLogicSelectedItem == "Greater than"
                       ) ? DateTime.Now :
                    (
                         stDateLogicSelectedItem == "Equals to" ||
                         stDateLogicSelectedItem == "Lesser or equal to"                         
                       ) ? this.dtpFromDate : 
                    (
                       stDateLogicSelectedItem == "In between of"
                       ) ? this.dtpToDate : this.dtpFromDate.AddDays(-1);


                string stENDDate = endDate.ToString(generalResultInformation.dateFormat);

                string getENDqty = "SELECT STOCK_BALANCETODATE(" +
                                        ProductID + "," + storeID + ",'" + stENDDate +
                                    "') FROM DUAL";

                DataTable dtENDQty = (DataTable)this.getDataFromDB.executeSqlOnDB(getENDqty);
                if (this.getDataFromDB.checkIfTableContainesData(dtENDQty))
                    ENDqty = double.Parse(dtENDQty.Rows[0][0].ToString());


                this.dtsearchResult.Rows[rowCounter]["BBF"] = BBFqty;
                this.dtsearchResult.Rows[rowCounter]["Balance"] = ENDqty;
            }

            if (this.ckShowCountSheet)
            {
                for (int rowCounter = this.dtsearchResult.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if (double.Parse(this.dtsearchResult.Rows[rowCounter]["Balance"].ToString()).Equals(0))
                    {
                        this.dtsearchResult.Rows.RemoveAt(rowCounter);
                    }
                } 
            }

            this.dtsearchResult.Columns.Remove("MOVEMENTTYPE");
            this.dtsearchResult.Columns.Remove("MOVEMENTQTY");

            DataView dtvSortResult = new DataView(this.dtsearchResult);
            dtvSortResult.Sort = "VALUE ASC, NAME ASC";
            this.dtsearchResult = dtvSortResult.ToTable();

            /*this.dtsearchResult = 
                this.getDataFromDB.mergeTables(this.dtsearchResult, 
                this.establishDeadStockSummary(), "", false);*/

        }
               

        public void generateSummarisedStockActivityReport(object sender, DoWorkEventArgs e)
        {
            generalResultInformation.searchResult.Clear();
            if (this.ckAllOrAny)
                this.logicalConnector = "OR";
            else
                this.logicalConnector = "AND";

            this.dtsearchQuery.Columns.Add("Field");
            this.dtsearchQuery.Columns.Add("Criterion");
            this.dtsearchQuery.Columns.Add("Value");

            this.dtsearchResult.Clear();

            this.establishSearchCriterion();

            DataTable searchQuery = this.dtsearchQuery;

            foreach(string stLocatorID in this.cbcbStoreList)                    
            {
                DataTable searchResult =
                    getDataFromDB.
                        getRV_SUMMARY_STOCK_ACTIVITY_RPT(searchQuery, logicalConnector, "",
                                                    stLocatorID, false, false, "AND");

                    this.dtsearchResult.Merge(searchResult, true, MissingSchemaAction.Add);

                    if (ckShowDormentStock)
                    {
                        searchResult = this.establishDeadStockSummary(this.ddgProduct, stLocatorID);

                        this.dtsearchResult.Merge(searchResult, true, MissingSchemaAction.Add);
                    }
            }

            if (!this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
            {
                MessageBox.Show("No Data Found For Your query", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            this.establishStockActivtiySummary();
                        
            generalResultInformation.searchResult = this.dtsearchResult;
            
        }
        

    }
}
