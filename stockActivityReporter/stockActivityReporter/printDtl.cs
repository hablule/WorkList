using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using dbConnection;

namespace stockActivityReporter
{
    class printDtl
    {

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


        public string cmbDateLogic;

        public DateTime dtpFromDate;
        public DateTime dtpToDate;

        DataTable dtsearchResult = new DataTable();


        dtsTransactionInfo dtsTrxInfo = new dtsTransactionInfo();


        dataBuilder getDataFromDB = new dataBuilder();


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

        public void deleteDetailRptPaperSize(object sender, RunWorkerCompletedEventArgs e)
        {
            CustomPrintForm.CustomPrintForm.AddCustomPaperSize(
                otherSettings.PrinterName, otherSettings.stPaperName, width, hight, true);
        }


        private void setDetailRptPaperSize()
        {
            DataView dvDateColumn = new DataView(this.dtsearchResult);
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
            try
            {
                CustomPrintForm.CustomPrintForm.AddCustomPaperSize(
                    otherSettings.PrinterName, otherSettings.stPaperName, width, hight, false);
            }
            finally
            { 

            }            
        }

        private void fillDetialActivityReport()
        {
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtsearchResult))
                return;

            string stStoreName = "";
            string stProductName = "";
            string stActivtiyDate = "";

            string stDateLogicSelectedItem =
                    this.cmbDateLogic;

            if (stDateLogicSelectedItem != "IGNOR")
            {
                if (stDateLogicSelectedItem == "In between of")
                {
                    stActivtiyDate = this.dtpFromDate.ToString("MM/dd/yyyy") + " - " +
                        this.dtpToDate.ToString("MM/dd/yyyy");

                }
                else
                    stActivtiyDate = this.generateEquivalentSymbol(stDateLogicSelectedItem) + " " +
                        this.dtpFromDate.ToString("MM/dd/yyyy");
            }
            else
                stActivtiyDate = "All";


            if (this.dtsearchResult.Rows[0]["MOVEMENTTYPE"].ToString() == "")
            {
                stStoreName = this.dtsearchResult.Rows[1]["VALUE"].ToString();
                stProductName = this.dtsearchResult.Rows[1]["NAME"].ToString();
            }
            else
            {
                stStoreName = this.dtsearchResult.Rows[0]["VALUE"].ToString();
                stProductName = this.dtsearchResult.Rows[0]["NAME"].ToString();
            }

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


        public void bkgPrntWrk_DoWork(object sender, DoWorkEventArgs e)
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
                this.setDetailRptPaperSize();

                frmPrintPreview frmPrintView = new frmPrintPreview();
                frmPrintView.trxInformation = (dtsTransactionInfo)this.dtsTrxInfo.Copy();
                frmPrintView.isDetailReport = true;

                frmPrintView.stPaperName = otherSettings.stPaperName;
                frmPrintView.stPrinterName = otherSettings.PrinterName;

                frmPrintView.printRpt(this, new EventArgs());
            }
        }


    }
}
