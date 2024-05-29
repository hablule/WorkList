using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using dbConnection;


namespace stockActivityReporter
{
    public partial class stockActivityReport : Form
    {
        public stockActivityReport()
        {
            InitializeComponent();
        }

        bool stAllLocatorCheckBoxChecked = false;

        /*
        string stM_Product_ID = "";
        string stLocatorID = "";
        string logicalConnector = "AND";
        */

        string stActivityRange = "";
        string styleName = "";
        
        const float ftMaxHight = 559f;
        const float ftMaxWidth = 215.9f;
        const float ftMinHight = 100f;

        float hight = 0f;
        float width = ftMaxWidth;

        float totalRptHight = 0f;

        float rptHdrHight = 10f; //10
        float pageHdrHight = 30f; //30
        float pageFooterHight = 5f; //5
        float singleRptRecordHight = 4.6694f;

        float pageTopAndBottomMargin = 8.89f; //8.89

        
        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DialogResult blShowPrintPreview;

        DataTable dtProductList = new DataTable();
        DataTable dtAllWarehouse = new DataTable();
        DataTable dtAllLocators = new DataTable();
        DataTable dtsearchQuery = new DataTable();
                
        DataTable dtsearchResult = new DataTable();

        dtsTransactionInfo dtsTrxInfo = new dtsTransactionInfo();

        businessRule getDataAccordingToRule = new businessRule();
        dbConnection.businessRule dbConnectionRule = new dbConnection.businessRule();

        dataBuilder getDataFromDB = new dataBuilder();
        
        checkAndEstablishDbConnectionSettings dbCk =
                new checkAndEstablishDbConnectionSettings();


        private string getNextInterfaceName()
        {
            if (this.styleName == "Aero (Black).vssf")
            {
                this.styleName = "Aero (Blue).vssf";
                return "Skins\\Aero (Blue).vssf";
            }
            else if (this.styleName == "Aero (Blue).vssf")
            {
                this.styleName = "Aero (Silver).vssf";
                return "Skins\\Aero (Silver).vssf";
            }
            else if (this.styleName == "Aero (Silver).vssf")
            {
                this.styleName = "Office2007 (Black).vssf";
                return "Skins\\Office2007 (Black).vssf";
            }
            else if (this.styleName == "Office2007 (Black).vssf")
            {
                this.styleName = "Office2007 (Blue).vssf";
                return "Skins\\Office2007 (Blue).vssf";
            }
            else if (this.styleName == "Office2007 (Blue).vssf")
            {
                this.styleName = "Office2007 (Silver).vssf";
                return "Skins\\Office2007 (Silver).vssf";
            }
            else if (this.styleName == "Office2007 (Silver).vssf")
            {
                this.styleName = "OSX (Aqua).vssf";
                return "Skins\\OSX (Aqua).vssf";
            }
            else if (this.styleName == "OSX (Aqua).vssf")
            {
                this.styleName = "OSX (Brushed).vssf";
                return "Skins\\OSX (Brushed).vssf";
            }
            else if (this.styleName == "OSX (Brushed).vssf")
            {
                this.styleName = "OSX (iTunes).vssf";
                return "Skins\\OSX (iTunes).vssf";
            }
            else if (this.styleName == "OSX (iTunes).vssf")
            {
                this.styleName = "OSX (Leopard).vssf";
                return "Skins\\OSX (Leopard).vssf";
            }
            else if (this.styleName == "OSX (Leopard).vssf")
            {
                this.styleName = "OSX (Panther).vssf";
                return "Skins\\OSX (Panther).vssf";
            }
            else if (this.styleName == "OSX (Panther).vssf")
            {
                this.styleName = "OSX (Tiger).vssf";
                return "Skins\\OSX (Tiger).vssf";
            }
            else if (this.styleName == "OSX (Tiger).vssf")
            {
                this.styleName = "Vista (Aero).vssf";
                return "Skins\\Vista (Aero).vssf";
            }
            else if (this.styleName == "Vista (Aero).vssf")
            {
                this.styleName = "Vista (Basic).vssf";
                return "Skins\\Vista (Basic).vssf";
            }
            else if (this.styleName == "Vista (Basic).vssf")
            {
                this.styleName = "Vista (Black).vssf";
                return "Skins\\Vista (Black).vssf";
            }
            else if (this.styleName == "Vista (Black).vssf")
            {
                this.styleName = "Vista (Blue).vssf";
                return "Skins\\Vista (Blue).vssf";
            }
            else if (this.styleName == "Vista (Blue).vssf")
            {
                this.styleName = "Vista (Green).vssf";
                return "Skins\\Vista (Green).vssf";
            }
            else if (this.styleName == "Vista (Green).vssf")
            {
                this.styleName = "Vista (Silver).vssf";
                return "Skins\\Vista (Silver).vssf";
            }
            else if (this.styleName == "Vista (Silver).vssf")
            {
                this.styleName = "Vista (Teal).vssf";
                return "Skins\\Vista (Teal).vssf";
            }
            else if (this.styleName == "Vista (Teal).vssf")
            {
                this.styleName = "XP (Blue).vssf";
                return "Skins\\XP (Blue).vssf";
            }
            else if (this.styleName == "XP (Blue).vssf")
            {
                this.styleName = "XP (Olive).vssf";
                return "Skins\\XP (Olive).vssf";
            }
            else if (this.styleName == "XP (Olive).vssf")
            {
                this.styleName = "XP (Royale).vssf";
                return "Skins\\XP (Royale).vssf";
            }
            else if (this.styleName == "XP (Royale).vssf")
            {
                this.styleName = "XP (Silver).vssf";
                return "Skins\\XP (Silver).vssf";
            }
            else
            {
                this.styleName = "Aero (Black).vssf";
                return "Skins\\Aero (Black).vssf";
            }
        }
        
        private void changeUserInterface()
        {
            this.visualStyler1.LoadVisualStyle(this.getNextInterfaceName());
            dbSettingInformationHandler.theme = this.styleName;
        }


        private void fillForm()
        { 

        }
        
        private bool checkExistanceOfAllRequiredInformation()
        {
            bool missingFieldExist = false;


            List<string> strList = new List<string>();
        
            for (int ckListItemsCounter = 1;
                ckListItemsCounter <= this.cbcbStoreList.Items.Count - 1;
                ckListItemsCounter++)
            {
                if (this.cbcbStoreList.CheckBoxItems[ckListItemsCounter].Checked)
                {
                    strList.Add(this.dtAllLocators.Rows[ckListItemsCounter - 1]["M_LOCATOR_ID"].ToString());
                }
            }

            if (this.cbcbStoreList.Text == "" || this.cbcbStoreList.Text == "ALL" ||
                strList.Count <= 0)
            {
                missingFieldExist = true;
                this.lblStore.ForeColor = this.missingFieldColor;
            }
            else
                this.lblStore.ForeColor = this.normalFieldColor;


            if (this.cmbProductLogic.Text == "IGNOR" && this.ckDetailReport.Checked)
            {
                missingFieldExist = true;
                this.lblProduct.ForeColor = this.missingFieldColor;
                this.ckDetailReport.ForeColor = this.missingFieldColor;
            }
            else
            {
                this.lblProduct.ForeColor = this.normalFieldColor;
                this.ckDetailReport.ForeColor = this.normalFieldColor;
            }


            if (this.cmbDateLogic.Text == "IGNOR")
            {
                missingFieldExist = true;
                this.lblDate.ForeColor = this.missingFieldColor;                
            }
            else
            {
                this.lblDate.ForeColor = this.normalFieldColor;                
            }


            if (this.dtpFromDate.Value.Date.CompareTo(DateTime.Now.Date) == 1 ||
                this.dtpToDate.Value.Date.CompareTo(DateTime.Now.Date) == 1 ||
                (this.dtpFromDate.Value.Date.CompareTo(this.dtpToDate.Value.Date) == 1 && this.dtpToDate.Visible))
            {
                missingFieldExist = true;
                this.lblDate.ForeColor = this.missingFieldColor;
            }
            else
            {
                this.lblDate.ForeColor = this.normalFieldColor;
            }            

            if (missingFieldExist)
                MessageBox.Show("Please Input Mandatory Field", "Missing Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

            return missingFieldExist;
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

            if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgProduct.SelectedRowKey != null)
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic.SelectedItem.ToString(),
                    this.ddgProduct.SelectedRowKey.ToString(), "");
            }


            if (this.cmbDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("MOVEMENTDATE", this.cmbDateLogic.SelectedItem.ToString(),
                    this.dtpFromDate.Value.ToString(generalResultInformation.dateFormat),
                    this.dtpToDate.Value.ToString(generalResultInformation.dateFormat));
            }

        }


        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }
                        

        private void fillDetialActivityReport()
        {
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
                return;

            string stStoreName = "";
            string stProductName = "";
            string stActivtiyDate = "";

            string stDateLogicSelectedItem =
                    this.cmbDateLogic.SelectedItem.ToString();

            if (stDateLogicSelectedItem != "IGNOR")
            {
                if (stDateLogicSelectedItem == "In between of")
                {
                    stActivtiyDate = this.dtpFromDate.Value.ToString("MM/dd/yyyy") + " - " +
                        this.dtpToDate.Value.ToString("MM/dd/yyyy");

                }
                else
                    stActivtiyDate = this.generateEquivalentSymbol(stDateLogicSelectedItem) + " " +
                        this.dtpFromDate.Value.ToString("MM/dd/yyyy");
            }
            else
                stActivtiyDate = "All";

            stStoreName = this.dtsearchResult.Rows[0]["VALUE"].ToString();
            stProductName = this.dtsearchResult.Rows[0]["NAME"].ToString();  

            //if (this.dtsearchResult.Rows[0]["MOVEMENTTYPE"].ToString() == "")
            //{
            //    stStoreName = this.dtsearchResult.Rows[1]["VALUE"].ToString();
            //    stProductName = this.dtsearchResult.Rows[1]["NAME"].ToString();
            //}
            //else
            //{
            //    stStoreName = this.dtsearchResult.Rows[0]["VALUE"].ToString();
            //    stProductName = this.dtsearchResult.Rows[0]["NAME"].ToString();
            //}            

            dtsTrxInfo.Tables["dtDetailStockActivity"].Rows.Clear();
            dtsTrxInfo.Tables["dtDetailStockActivityHDr"].Rows.Clear();

            DataRow drDetailStockActivityHDr =
                dtsTrxInfo.Tables["dtDetailStockActivityHDr"].NewRow();

            drDetailStockActivityHDr["Store"] = stStoreName;
            drDetailStockActivityHDr["Product"] = stProductName;
            drDetailStockActivityHDr["Activity Range"] = stActivtiyDate;

            dtsTrxInfo.Tables["dtDetailStockActivityHDr"].Rows.Add(drDetailStockActivityHDr);

            DataRow drDetailStockActivity;

            string stColumnName = "";

            for (int rowCounter = 0; rowCounter <= this.dtsearchResult.Rows.Count - 1; rowCounter++)
            {
                drDetailStockActivity =
                        dtsTrxInfo.Tables["dtDetailStockActivity"].NewRow();

                for (int columnCounter = 0; 
                    columnCounter <= 
                        dtsTrxInfo.Tables["dtDetailStockActivity"].Columns.Count - 1; 
                        columnCounter++)
                {
                    stColumnName =
                        dtsTrxInfo.Tables["dtDetailStockActivity"].Columns[columnCounter].ColumnName;

                    drDetailStockActivity[stColumnName] =
                        this.dtsearchResult.Rows[rowCounter][stColumnName];
                }

                dtsTrxInfo.Tables["dtDetailStockActivity"].Rows.Add(drDetailStockActivity);
            }

        }

        private void fillSummaryActivityReport()
        {
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
                return;

            string stActivtiyDate = "";

            string stDateLogicSelectedItem =
                    this.cmbDateLogic.SelectedItem.ToString();

            if (this.ckCountSheetRpt.Checked)
            {
                stActivtiyDate = "Physical Taking On " + this.dtpFromDate.Value.ToString("MM/dd/yyyy");
            }
            else
            {
                if (stDateLogicSelectedItem != "IGNOR")
                {
                    if (stDateLogicSelectedItem == "In between of")
                    {
                        stActivtiyDate = this.dtpFromDate.Value.ToString("MM/dd/yyyy") + " - " +
                            this.dtpToDate.Value.ToString("MM/dd/yyyy");

                    }
                    else
                        stActivtiyDate = this.generateEquivalentSymbol(stDateLogicSelectedItem) + " " +
                            this.dtpFromDate.Value.ToString("MM/dd/yyyy");
                }
                else
                    stActivtiyDate = "All";
            }
                       
            dtsTrxInfo.Tables["dtSummaryStockActivity"].Rows.Clear();
            dtsTrxInfo.Tables["dtSummaryStockActivityHDr"].Rows.Clear();

            DataRow drSummaryStockActivityHDr =
                dtsTrxInfo.Tables["dtSummaryStockActivityHDr"].NewRow();

            drSummaryStockActivityHDr["Activity Range"] = stActivtiyDate;

            dtsTrxInfo.Tables["dtSummaryStockActivityHDr"].Rows.Add(drSummaryStockActivityHDr);

            DataRow drSummaryStockActivity;
            decimal defaultZero = 0;

            string stColumnName = "";

            for (int rowCounter = 0; rowCounter <= this.dtsearchResult.Rows.Count - 1; rowCounter++)
            {
                drSummaryStockActivity =
                        dtsTrxInfo.Tables["dtSummaryStockActivity"].NewRow();

                for (int columnCounter = 0;
                    columnCounter <=
                        dtsTrxInfo.Tables["dtSummaryStockActivity"].Columns.Count - 1;
                        columnCounter++)
                {
                    stColumnName =
                        dtsTrxInfo.Tables["dtSummaryStockActivity"].Columns[columnCounter].ColumnName;

                    if (dtsTrxInfo.Tables["dtSummaryStockActivity"].Columns[columnCounter].DataType == typeof(decimal))
                    {
                        drSummaryStockActivity[stColumnName] =
                            decimal.Parse(this.dtsearchResult.Rows[rowCounter][stColumnName].ToString(),
                                    NumberStyles.Any, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        drSummaryStockActivity[stColumnName] = this.dtsearchResult.Rows[rowCounter][stColumnName]; 
                    }                    
                    
                }

                dtsTrxInfo.Tables["dtSummaryStockActivity"].Rows.Add(drSummaryStockActivity);
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


        private void deleteDetailRptPaperSize()
        {
            //CustomPrintForm.CustomPrintForm.AddCustomPaperSize(
            //    otherSettings.defaultPrinterName, otherSettings.stPaperName, 1, 1, true);
        }

        private void setDetailRptPaperSize()
        {            

            DataView dvDateColumn = new DataView (this.dtsearchResult);
            DataTable dtcDate = dvDateColumn.ToTable(true, "MOVEMENTDATE");

            float groupSeparatorLineThickness = 0.3306f;
            float totalGroupSepartor = groupSeparatorLineThickness * dtcDate.Rows.Count;


            int numberOfRecord = this.dtsearchResult.Rows.Count;

            float dataRecordHight = (numberOfRecord * singleRptRecordHight) + totalGroupSepartor;
            dataRecordHight += rptHdrHight;

            int numberOfPage = 0;

            if ((dataRecordHight + pageHdrHight + pageFooterHight + pageTopAndBottomMargin) > ftMaxHight)
            {
                numberOfPage = (int)Math.Ceiling((dataRecordHight / ftMaxHight));

                do
                {
                    totalRptHight = dataRecordHight + ((pageTopAndBottomMargin +
                        pageHdrHight + pageFooterHight) * numberOfPage);

                    if (numberOfPage != (int)Math.Ceiling((totalRptHight / ftMaxHight)))
                        numberOfPage = (int)Math.Ceiling((totalRptHight / ftMaxHight));
                    else
                        break;
                }
                while (true);

                hight = totalRptHight / numberOfPage;

            }
            else
                hight = dataRecordHight + pageHdrHight + pageFooterHight + pageTopAndBottomMargin;

            hight = (float)Math.Floor(hight);

            hight = hight < ftMinHight ? ftMinHight : hight;

            CustomPrintForm.CustomPrintForm.AddCustomPaperSize(
                otherSettings.PrinterName, otherSettings.stPaperName, width, hight, false);
        }


        private void showDtlRptPrintPreview()
        {
            //this.setDetailRptPaperSize();

            if (!System.IO.File.Exists("rptDetailStockActivity.rpt"))
            {
                MessageBox.Show("Unable To find Crystal Report. \n Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frmPrintPreview frmPrintView = new frmPrintPreview();
            frmPrintView.trxInformation = (dtsTransactionInfo)this.dtsTrxInfo.Copy();
            frmPrintView.isDetailReport = true;

            

            frmPrintView.stPaperName = otherSettings.stPaperName;
            frmPrintView.stPrinterName = otherSettings.PrinterName;

            

            if (this.blShowPrintPreview == DialogResult.Yes)
            {
                frmPrintView.ShowDialog();
                //this.deleteDetailRptPaperSize();
                return;
            }                
        }
        
        private void showSummaryRptPrintPreview()
        {

            if (!System.IO.File.Exists("rptSummarizedStockActivity.rpt") ||
                !System.IO.File.Exists("rptCountSheet.rpt"))
            {
                MessageBox.Show("Unable To find Crystal Report. \n Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frmPrintPreview frmPrintView = new frmPrintPreview();
            frmPrintView.trxInformation = (dtsTransactionInfo)this.dtsTrxInfo.Copy();
            frmPrintView.isDetailReport = false;
            frmPrintView.isCountReport = this.ckCountSheetRpt.Checked;

            frmPrintView.stPaperName = "";
            frmPrintView.stPrinterName =
                otherSettings.PrinterName;

            frmPrintView.ShowDialog();

        }
        

        private void stockActivityReport_Load(object sender, EventArgs e)
        {

            this.visualStyler1.LoadVisualStyle(dbSettingInformationHandler.theme);

            this.dtAllWarehouse =
                generalResultInformation.AccessableWarehouse.Copy();

            this.mnuSettings.Visible = generalResultInformation.userCanEditSettings;                

            this.dtAllLocators =
                generalResultInformation.AccessableLocators.Copy();

            if(this.getDataFromDB.checkIfTableContainesData(this.dtAllLocators))
            {
                DataView dvAllLocators = this.dtAllLocators.DefaultView;
                
                if (dvAllLocators.Table.Columns.Contains("VALUE"))
                    dvAllLocators.Sort = "VALUE ASC";

                this.dtAllLocators = dvAllLocators.ToTable();
            }
            

            this.cbcbStoreList.Items.Insert(0, "ALL");

            for (int locatorCounter = 0; locatorCounter <= this.dtAllLocators.Rows.Count - 1; locatorCounter++)
            {
                this.cbcbStoreList.Items.Insert(locatorCounter + 1, 
                    this.dtAllLocators.Rows[locatorCounter]["VALUE"].ToString());
            }
            this.cbcbStoreList.CheckBoxItems[0].Checked = true;

            this.cmbDateLogic.SelectedItem = "In between of";
            this.cmbProductLogic.SelectedItem = "IGNOR";

            this.dtpFromDate.Value = DateTime.Today;
            this.dtpToDate.Value = DateTime.Today;

            this.dtsearchQuery.Columns.Add("Field");
            this.dtsearchQuery.Columns.Add("Criterion");
            this.dtsearchQuery.Columns.Add("Value");

            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();
            
        }


        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation =
                getDataAccordingToRule.getProducts(false,triStateBool.Ignor,triStateBool.Ignor, false, 
                    this.ddgProduct.SelectedItem, "", true);

            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey =
                Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex =
                productInformation.Columns.IndexOf("NAME");
            this.ddgProduct.HiddenColoumns = new int[]{ productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID")};
        }
        
        
        private void cbcbStoreList_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (this.cbcbStoreList.CheckBoxItems[0].Checked == this.stAllLocatorCheckBoxChecked)
                return;

            this.stAllLocatorCheckBoxChecked = this.cbcbStoreList.CheckBoxItems[0].Checked;
            
            
            for (int ckListItemsCount = 1; ckListItemsCount <= this.cbcbStoreList.Items.Count - 1; ckListItemsCount++)
            {
                this.cbcbStoreList.CheckBoxItems[ckListItemsCount].Checked =
                    this.stAllLocatorCheckBoxChecked;
            }
            
        }

        private void cmbDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDateLogic.SelectedItem.ToString(),
                this.dtpFromDate);

            if (this.cmbDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpToDate.Visible = true;
            else
                this.dtpToDate.Visible = false;
        }

        private void cmbProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbProductLogic.SelectedItem.ToString(),
                this.ddgProduct);
        }

        
        private void cmdGenerateReport_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            generalResultInformation.dtsSerachResult.Tables.Clear();

            if (checkExistanceOfAllRequiredInformation())
            {
                this.Enabled = true;
                return;
            }
            
            if (
                  (
                    this.cmbDateLogic.SelectedItem.ToString() == "Less than" ||
                    this.cmbDateLogic.SelectedItem.ToString() == "Lesser or equal to"
                   ) ||
                  (
                    (this.cmbDateLogic.SelectedItem.ToString() == "Greater than" ||
                    this.cmbDateLogic.SelectedItem.ToString() == "Greater or equals to") &&
                    ((DateTime.Now.Year != this.dtpFromDate.Value.Year) ||
                     (DateTime.Now.DayOfYear - this.dtpFromDate.Value.DayOfYear > 31))
                   ) ||
                 (
                    (this.cmbDateLogic.SelectedItem.ToString() == "In between of") &&
                    ((this.dtpToDate.Value.Year != this.dtpFromDate.Value.Year) ||
                    (this.dtpToDate.Value.DayOfYear - this.dtpFromDate.Value.DayOfYear > 31))
                  )
                &&
                !this.ckCountSheetRpt.Checked
                )
            {
                if (MessageBox.Show("The date Range you chose is more than a month. \n " +
                "This might cause a delay of result. Do you like to proceed.", "Missing Entry",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    this.Enabled = true;
                    return; 
                }
            }
                        

            BackgroundWorker bkgWrker = new BackgroundWorker();
            

            if (this.ckDetailReport.Checked)
            {
                this.blShowPrintPreview = 
                    MessageBox.Show("Display Print Preview", "Print", 
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (this.blShowPrintPreview == DialogResult.Cancel)
                {
                    this.Enabled = true;
                    return;
                }

                this.blShowPrintPreview = DialogResult.Yes;

                DetailReport clsRptDetail = new DetailReport();
                List<string> strList = new List<string>();

                for (int ckListItemsCounter = 1;
                ckListItemsCounter <= this.cbcbStoreList.Items.Count - 1;
                ckListItemsCounter++)
                {
                    if (this.cbcbStoreList.CheckBoxItems[ckListItemsCounter].Checked)
                    {
                        strList.Add(this.dtAllLocators.Rows[ckListItemsCounter - 1]["M_LOCATOR_ID"].ToString());
                    }
                }

                clsRptDetail.cbcbStoreList = strList.ToArray();
                clsRptDetail.ckAllOrAny = this.ckAllOrAny.Checked;
                clsRptDetail.cmbDateLogic = this.cmbDateLogic.SelectedItem.ToString();
                clsRptDetail.cmbProductLogic = this.cmbProductLogic.SelectedItem.ToString();
                if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                    this.ddgProduct.SelectedRowKey != null)
                {
                    clsRptDetail.ddgProduct = this.ddgProduct.SelectedRowKey.ToString();
                }
                clsRptDetail.dtAllLocators = this.dtAllLocators;
                clsRptDetail.dtpFromDate = this.dtpFromDate.Value;
                clsRptDetail.dtpToDate = this.dtpToDate.Value;

                

                bkgWrker.DoWork +=
                    new System.ComponentModel.DoWorkEventHandler(clsRptDetail.generateDetailStockActivityReport);
                bkgWrker.RunWorkerCompleted += 
                    new RunWorkerCompletedEventHandler(bkgWrker_RunWorkerCompleted);
                bkgWrker.RunWorkerAsync();
            }
            else
            {
                SummaryReport clsRptSummary = new SummaryReport();
                List<string> strList = new List<string>();

                for (int ckListItemsCounter = 1;
                ckListItemsCounter <= this.cbcbStoreList.Items.Count - 1;
                ckListItemsCounter++)
                {
                    if (this.cbcbStoreList.CheckBoxItems[ckListItemsCounter].Checked)
                    {
                        strList.Add(this.dtAllLocators.Rows[ckListItemsCounter - 1]["M_LOCATOR_ID"].ToString());

                    }
                }

                clsRptSummary.cbcbStoreList = strList.ToArray();
                clsRptSummary.ckAllOrAny = this.ckAllOrAny.Checked;
                clsRptSummary.ckShowCountSheet = this.ckCountSheetRpt.Checked;
                clsRptSummary.ckShowDormentStock = this.ckShowDormentStock.Checked;
                clsRptSummary.cmbDateLogic = this.cmbDateLogic.SelectedItem.ToString();
                clsRptSummary.cmbProductLogic = this.cmbProductLogic.SelectedItem.ToString();

                if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                    this.ddgProduct.SelectedRowKey != null)
                {
                    clsRptSummary.ddgProduct = this.ddgProduct.SelectedRowKey.ToString();
                }
                
                clsRptSummary.dtAllLocators = this.dtAllLocators;
                clsRptSummary.dtpFromDate = this.dtpFromDate.Value;
                clsRptSummary.dtpToDate = this.dtpToDate.Value;
                
                bkgWrker.DoWork +=
                    new System.ComponentModel.DoWorkEventHandler(clsRptSummary.generateSummarisedStockActivityReport);
                bkgWrker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkgWrker_RunWorkerCompleted);
                bkgWrker.RunWorkerAsync();                                  
            }

        }

        
        private void bkgWrker_RunWorkerCompleted(object s, RunWorkerCompletedEventArgs e)
        {

            if (this.ckDetailReport.Checked)
            {
                if (generalResultInformation.dtsSerachResult.Tables.Count > 0)
                {
                    if (this.blShowPrintPreview == DialogResult.No)
                    {
                        printDtl prnt = new printDtl();

                        prnt.cmbDateLogic = this.cmbDateLogic.SelectedItem.ToString();
                        prnt.dtpFromDate = this.dtpFromDate.Value;
                        prnt.dtpToDate = this.dtpToDate.Value;
                                                
                        BackgroundWorker bkgPrntWrk = new BackgroundWorker();
                        bkgPrntWrk.DoWork +=
                            new DoWorkEventHandler(prnt.bkgPrntWrk_DoWork);
                        
                        
                        bkgPrntWrk.RunWorkerAsync();
                        bkgPrntWrk.RunWorkerCompleted +=
                            new RunWorkerCompletedEventHandler(prnt.deleteDetailRptPaperSize);
                    }
                    else
                    {
                        for (int tableCounter = 0; tableCounter <=
                        generalResultInformation.dtsSerachResult.Tables.Count - 1; tableCounter++)
                        {
                            DataTable dtData =
                                generalResultInformation.dtsSerachResult.Tables[tableCounter];

                            if (!this.getDataFromDB.checkIfTableContainesData(dtData))
                            {
                                continue;
                            }

                            this.dtsearchResult = dtData;

                            this.fillDetialActivityReport();

                            
                            this.showDtlRptPrintPreview();
                        }
                    }                                      
                }
                else
                {
                    MessageBox.Show("No Report Record Found", "Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (this.getDataFromDB.checkIfTableContainesData(generalResultInformation.searchResult))
                {
                    this.dtsearchResult =
                        generalResultInformation.searchResult;

                    this.fillSummaryActivityReport();
                    this.showSummaryRptPrintPreview();
                }
                else
                {
                    MessageBox.Show("No Report Record Found", "Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            this.Enabled = true;
        }
        
        
        private void ckDetailReport_CheckedChanged(object sender, EventArgs e)
        {            
            this.ckShowDormentStock.Enabled = !this.ckDetailReport.Checked;
            this.ckShowDormentStock.Checked = false;

            this.ckCountSheetRpt.Visible = !this.ckDetailReport.Checked;
            this.ckCountSheetRpt.Checked = false;
            
        }
        
        private void ckCountSheetRpt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCountSheetRpt.Checked)
            {
                this.cmbDateLogic.SelectedIndex = 5;
                this.cmbDateLogic.Visible = false;
                this.cmbProductLogic.SelectedIndex = 0;
                this.cmbProductLogic.Enabled = false;
                this.ckShowDormentStock.Checked = true;
                this.ckShowDormentStock.Enabled = false;
                this.ckDetailReport.Checked = false;
                this.ckDetailReport.Enabled = false;
            }
            else
            {
                this.cmbDateLogic.SelectedIndex = this.cmbDateLogic.Items.Count - 1;
                this.cmbDateLogic.Visible = true;
                this.cmbProductLogic.SelectedIndex = 0;
                this.cmbProductLogic.Enabled = true;
                this.ckShowDormentStock.Checked = false;
                this.ckShowDormentStock.Enabled = true;
                this.ckDetailReport.Enabled = true;
            }
        }


        private void mnuSettings_Click(object sender, EventArgs e)
        {
            dbCk.setSettings();
        }

        private void stockActivityReport_DoubleClick(object sender, EventArgs e)
        {
            this.changeUserInterface();
        }

        private void stockActivityReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dtSettingsTable = new DataTable();
            string settingFile = dbSettingInformationHandler.settingFilePath;
            bool settingFound = false;

            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");

            if (File.Exists(settingFile))
            {
                try
                {
                    dtSettingsTable =
                        this.dbConnectionRule.readEncryptedXmlSettingFile(settingFile);
            
                    foreach (DataRow dr in dtSettingsTable.Rows)
                    {
                        if (dr["Parameter_Name"].ToString() == "theme")
                        {
                            dr["Parameter_Value"] = dbSettingInformationHandler.theme;
                            settingFound = true;
                            break;
                        }
                    }
                    if (!settingFound)
                    {
                        DataRow dr = dtSettingsTable.NewRow();
                        dr["Parameter_Name"] = "theme";
                        dr["Parameter_Value"] = dbSettingInformationHandler.theme;
                        dtSettingsTable.Rows.Add(dr);
                    }
                    this.dbConnectionRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);
            
                }
                catch
                {
                }
            }
        }



    }
}
