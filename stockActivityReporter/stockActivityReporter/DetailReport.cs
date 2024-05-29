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
    class DetailReport
    {
        public string logicalConnector = "AND";
        public string stProductID = "";

        public string stActivityRange = "";
        
        public string stDateLogicSelectedItem = "";

        public string cmbDateLogic;
        public string cmbProductLogic;

        public string ddgProduct;
        public string[] cbcbStoreList;

        public bool ckAllOrAny;
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


        private void establishStockActivtiyDtl(string ProductID, string storeID)
        {
            this.dtsearchResult.Clear();

            this.establishSearchCriterion();

            this.dtsearchResult =
                getDataFromDB.getRV_DETAIL_STOCK_ACTIVITY_RPT(this.dtsearchQuery, logicalConnector,
                    ProductID, storeID, false, false, "AND");


            dtsearchResult.Columns.Add("Purchases");
            dtsearchResult.Columns.Add("Transfers");
            dtsearchResult.Columns.Add("TrsfStore");
            dtsearchResult.Columns.Add("Sales");
            dtsearchResult.Columns.Add("Others");
            dtsearchResult.Columns.Add("Balance");

            DataRow drSearchResultNewRow;

            string stDateLogicSelectedItem =
                    this.cmbDateLogic.ToString();

            if (stDateLogicSelectedItem != "IGNOR")
            {
                if (stDateLogicSelectedItem == "In between of")
                {
                    this.stActivityRange = this.dtpFromDate.ToString("MM/dd/yyyy") + " - " +
                        this.dtpToDate.ToString("MM/dd/yyyy");

                }
                else
                    this.stActivityRange = this.generateEquivalentSymbol(stDateLogicSelectedItem) + " " +
                        this.dtpFromDate.ToString("MM/dd/yyyy");
            }
            else
                this.stActivityRange = "All";


            if (stDateLogicSelectedItem != "IGNOR" &&
                stDateLogicSelectedItem != "Less than" &&
                stDateLogicSelectedItem != "Lesser or equal to")
            {
                decimal BBFqty = 0;

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
                    BBFqty = decimal.Parse(dtBBFQty.Rows[0][0].ToString());
                
                if (BBFqty != 0)
                {
                    drSearchResultNewRow = dtsearchResult.NewRow();

                    drSearchResultNewRow["MOVEMENTDATE"] = BBFDate.ToString("MM/dd/yyyy");
                    drSearchResultNewRow["DOCUMENTNO"] = "BBF";
                    drSearchResultNewRow["Balance"] = BBFqty;

                    if (this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
                    {
                        drSearchResultNewRow["VALUE"] = 
                            this.dtsearchResult.Rows[0]["VALUE"].ToString();
                        drSearchResultNewRow["NAME"] = 
                            this.dtsearchResult.Rows[0]["NAME"].ToString();
                    }
                    else
                    {
                        DataTable prdInfo =
                            this.getDataFromDB.getM_PRODUCTInfo(null, "", 
                                ProductID, false, false, "AND");
                        DataTable storeInfo =
                            this.getDataFromDB.getM_LOCATORInfo(null, "",
                                storeID, "", false, false, "AND");

                        if (this.getDataFromDB.checkIfTableContainesData(prdInfo))
                        {
                            drSearchResultNewRow["NAME"] =
                                prdInfo.Rows[0]["NAME"].ToString();
                        }

                        if (this.getDataFromDB.checkIfTableContainesData(storeInfo))
                        {
                            drSearchResultNewRow["VALUE"] =
                                storeInfo.Rows[0]["VALUE"].ToString();
                        }
 
                    }

                    dtsearchResult.Rows.InsertAt(drSearchResultNewRow, 0);
                }

            }

            decimal ENDqty = 0;

            DateTime endDate =
                (
                     stDateLogicSelectedItem == "IGNOR" ||
                     stDateLogicSelectedItem == "Greater or equals to" ||
                     stDateLogicSelectedItem == "Greater than"
                   ) ? DateTime.Now :
                (
                     stDateLogicSelectedItem == "Equals to" ||
                     stDateLogicSelectedItem == "Lesser or equal to" ||
                     stDateLogicSelectedItem == "In between of"
                   ) ? this.dtpToDate : this.dtpToDate;


            string stENDDate = endDate.ToString(generalResultInformation.dateFormat);

            string getENDqty = "SELECT STOCK_BALANCETODATE(" +
                                    ProductID + "," + storeID + ",'" + stENDDate +
                                "') FROM DUAL";

            DataTable dtENDQty = (DataTable)this.getDataFromDB.executeSqlOnDB(getENDqty);
            if (this.getDataFromDB.checkIfTableContainesData(dtENDQty))
                ENDqty = decimal.Parse(dtENDQty.Rows[0][0].ToString());

            drSearchResultNewRow = dtsearchResult.NewRow();
            drSearchResultNewRow["MOVEMENTDATE"] = endDate.ToString("MM/dd/yyyy");
            drSearchResultNewRow["DOCUMENTNO"] = "Ending Balance";
            drSearchResultNewRow["Balance"] = ENDqty;

            if (this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
            {
                drSearchResultNewRow["VALUE"] =
                    this.dtsearchResult.Rows[0]["VALUE"].ToString();
                drSearchResultNewRow["NAME"] =
                    this.dtsearchResult.Rows[0]["NAME"].ToString();
            }
            else
            {
                DataTable prdInfo =
                    this.getDataFromDB.getM_PRODUCTInfo(null, "",
                        ProductID, false, false, "AND");
                DataTable storeInfo =
                    this.getDataFromDB.getM_LOCATORInfo(null, "",
                        storeID, "", false, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(prdInfo))
                {
                    drSearchResultNewRow["NAME"] =
                        prdInfo.Rows[0]["NAME"].ToString();
                }

                if (this.getDataFromDB.checkIfTableContainesData(storeInfo))
                {
                    drSearchResultNewRow["VALUE"] =
                        storeInfo.Rows[0]["VALUE"].ToString();
                }
            }

            dtsearchResult.Rows.Add(drSearchResultNewRow);

            decimal dcBalance = 0;

            for (int serchRsltCounter = 0; serchRsltCounter <= this.dtsearchResult.Rows.Count - 1; serchRsltCounter++)
            {
                string stMOVEMENTTYPE =
                    this.dtsearchResult.Rows[serchRsltCounter]["MOVEMENTTYPE"].ToString();

                dcBalance =
                    stMOVEMENTTYPE != "" ?
                        dcBalance +
                        decimal.Parse(this.dtsearchResult.Rows[serchRsltCounter]["MOVEMENTQTY"].ToString()) :
                    this.dtsearchResult.Rows[serchRsltCounter]["DOCUMENTNO"].ToString() == "BBF"
                    ?
                    decimal.Parse(this.dtsearchResult.Rows[serchRsltCounter]["Balance"].ToString()) :
                    dcBalance;
                if (stMOVEMENTTYPE == "" &&
                    this.dtsearchResult.Rows[serchRsltCounter]["DOCUMENTNO"].ToString() == "Ending Balance" &&
                    dcBalance != decimal.Parse(this.dtsearchResult.Rows[serchRsltCounter]["Balance"].ToString()))
                {
                    MessageBox.Show("Ending Balance Conflict",
                        "Balance Calculation", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                this.dtsearchResult.Rows[serchRsltCounter]["Balance"] = dcBalance;


                if (stMOVEMENTTYPE == "")
                    continue;
                else if (stMOVEMENTTYPE == "M+" || stMOVEMENTTYPE == "M-")
                {
                    this.dtsearchResult.Rows[serchRsltCounter]["Transfers"] =
                        this.dtsearchResult.Rows[serchRsltCounter]["MOVEMENTQTY"];

                    string stCoStore = "NA";
                    string stCoStoreID = "";

                    if (dbSettingInformationHandler.DataBaseType == "Oracle")
                    {
                        DataTable dtMovementLine =
                            this.getDataFromDB.getM_MOVEMENTLINEInfo(null, "",
                                this.dtsearchResult.Rows[serchRsltCounter]["M_MOVEMENTLINE_ID"].ToString(),
                                "", false, false, "AND");

                        if (this.getDataFromDB.checkIfTableContainesData(dtMovementLine))
                        {
                            stCoStoreID = stMOVEMENTTYPE == "M+" ?
                                dtMovementLine.Rows[0]["M_LOCATOR_ID"].ToString() :
                                dtMovementLine.Rows[0]["M_LOCATORTO_ID"].ToString();
                        }
                    }
                    else if (dbSettingInformationHandler.DataBaseType == "MySql")
                    {
                        stCoStoreID =
                            this.dtsearchResult.Rows[serchRsltCounter]["M_LOCATORTO_ID"].ToString();
                    }

                    if (stCoStoreID != "")
                    {
                        DataTable dtCoLocator =
                                this.getDataFromDB.getM_LOCATORInfo(null, "", stCoStoreID, "", false, false, "AND");

                        if (this.getDataFromDB.checkIfTableContainesData(dtCoLocator))
                        {
                            DataTable dtCoStore =
                                this.getDataFromDB.getM_WAREHOUSEInfo(null, "", "",
                                    dtCoLocator.Rows[0]["M_WAREHOUSE_ID"].ToString(),
                                    false, false, "AND");

                            if (this.getDataFromDB.checkIfTableContainesData(dtCoStore))
                            {
                                stCoStore =
                                    dtCoStore.Rows[0]["DESCRIPTION"].ToString() == "" ?
                                        "NA" :
                                    dtCoStore.Rows[0]["DESCRIPTION"].ToString().Length > 4 ?
                                    dtCoStore.Rows[0]["DESCRIPTION"].ToString().Substring(0, 4) :
                                        dtCoStore.Rows[0]["DESCRIPTION"].ToString();
                            }
                        }
                    }
                    
                    this.dtsearchResult.Rows[serchRsltCounter]["TrsfStore"] =
                        stCoStore;
                }
                else if (stMOVEMENTTYPE == "C+" || stMOVEMENTTYPE == "C-")
                {
                    this.dtsearchResult.Rows[serchRsltCounter]["Sales"] =
                        this.dtsearchResult.Rows[serchRsltCounter]["MOVEMENTQTY"];
                }
                else if (stMOVEMENTTYPE == "I+" || stMOVEMENTTYPE == "I-"|| 
                         stMOVEMENTTYPE == "P+" || stMOVEMENTTYPE == "P-")
                {
                    this.dtsearchResult.Rows[serchRsltCounter]["Others"] =
                        this.dtsearchResult.Rows[serchRsltCounter]["MOVEMENTQTY"];
                }
                else if (stMOVEMENTTYPE == "V+" || stMOVEMENTTYPE == "V-")
                {
                    this.dtsearchResult.Rows[serchRsltCounter]["Purchases"] =
                        this.dtsearchResult.Rows[serchRsltCounter]["MOVEMENTQTY"];
                }
            }

        }
      

        public void generateDetailStockActivityReport(object sender, DoWorkEventArgs e)
        {
            generalResultInformation.dtsSerachResult.Clear();

            if (this.ckAllOrAny)
                this.logicalConnector = "OR";
            else
                this.logicalConnector = "AND";

            this.dtsearchQuery.Columns.Add("Field");
            this.dtsearchQuery.Columns.Add("Criterion");
            this.dtsearchQuery.Columns.Add("Value");

            this.dtsearchQuery.Rows.Clear();

            if (this.cmbProductLogic != "IGNOR" &&
                this.ddgProduct != "")
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic,
                    this.ddgProduct, "");
            }
            foreach(string stLocatorID in this.cbcbStoreList)                    
            {
                    // Get Product list of query ordered by there name
                    // To enable the print of stock activity in alphabetic order of Products.
                DataTable searchProductListResult =
                    getDataFromDB.getRV_DETAIL_STOCK_ACTIVITY_RPTproductList
                        (this.dtsearchQuery, logicalConnector, this.ddgProduct,
                                                    stLocatorID, false, false, "AND");                

                    if (!getDataFromDB.checkIfTableContainesData(searchProductListResult))
                        continue;

                    for (int prdListCounter = 0;
                        prdListCounter <= searchProductListResult.Rows.Count - 1;
                        prdListCounter++)
                    {
                        string stM_Product_ID =
                            searchProductListResult.Rows[prdListCounter]["M_Product_ID"].ToString();
                                                

                        this.establishStockActivtiyDtl(stM_Product_ID, stLocatorID);
                                                

                        if (!this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
                            continue;

                        DataTable dtDataTabl = new DataTable();
                        dtDataTabl = this.dtsearchResult.Copy();
                        dtDataTabl.TableName = 
                            (generalResultInformation.dtsSerachResult.Tables.Count + 1).ToString();

                        generalResultInformation.dtsSerachResult.Tables.Add(dtDataTabl);

                        //Report Progress

                        //this.fillDetialActivityReport();
                        //this.showDtlRptPrintPreview();

                    }
            }

        }
        

    }
}
