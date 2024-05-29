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
    public partial class frmItemTransactionHistory : Form
    {
        public frmItemTransactionHistory()
        {
            InitializeComponent();
        }

        DataTable dtProductTrxHistory = new DataTable();
        private dataBuilder getDatafromDataBase = new dataBuilder();


        private void frmItemTransactionHistory_Load(object sender, EventArgs e)
        {
            
            if(generalResultInformation.selectedProductId != "")
                this.dtProductTrxHistory =
                    this.getDatafromDataBase.getT_TRXDETAILInfo(null, "",
                        "", "", "", new DateTime(), false, triStateBool.ignor,
                            generalResultInformation.selectedProductId,
                            triStateBool.ignor, false, "AND");
            else
                this.dtProductTrxHistory =
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "",
                        "", "", "", new DateTime(), false, triStateBool.ignor,
                            "", triStateBool.ignor, true, "");

            this.dtProductTrxHistory.Columns.Add("DOCUMENT NO.");
            this.dtProductTrxHistory.Columns.Add("BUISNESS PARTNER");
            this.dtProductTrxHistory.Columns.Add("UNIT");
            this.dtProductTrxHistory.Columns.Add("STATUS");

            this.dtProductTrxHistory.Columns.Remove("T_TRXDETAIL_ID");
            this.dtProductTrxHistory.Columns.Remove("CREATED");
            this.dtProductTrxHistory.Columns.Remove("UPDATED");
            this.dtProductTrxHistory.Columns.Remove("ISACTIVE");
            this.dtProductTrxHistory.Columns.Remove("M_PRODUCT_ID");
            this.dtProductTrxHistory.Columns.Remove("DESCRIPTION");


            DataTable dtUOMInfo = new DataTable();
            DataTable dtBpartnerInfo = new DataTable();
            DataTable dtTransactionInfo = new DataTable();

            for (int rowCounter = 0; rowCounter < this.dtProductTrxHistory.Rows.Count; rowCounter++)
            {
                dtTransactionInfo =
                    this.getDatafromDataBase.getT_TRANSACTIONInfo(null,"",
                        this.dtProductTrxHistory.Rows[rowCounter]["T_TRANSACTION_ID"].ToString(),
                        "","",new DateTime(),false,triStateBool.ignor,
                        triStateBool.ignor,triStateBool.ignor,transactionStatus.ignor
                            ,false,"AND");

                if (dtTransactionInfo.Rows.Count > 0)
                    this.dtProductTrxHistory.Rows[rowCounter]["DOCUMENT NO."] =
                        dtTransactionInfo.Rows[0]["DOCUMENTNO"].ToString();

                dtUOMInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        this.dtProductTrxHistory.Rows[rowCounter]["M_UOM_ID"].ToString(),
                        "", "", triStateBool.ignor, false, "AND");
                if (dtUOMInfo.Rows.Count > 0)
                    this.dtProductTrxHistory.Rows[rowCounter]["UNIT"] =
                        dtUOMInfo.Rows[0]["NAME"].ToString();

                dtBpartnerInfo =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                        this.dtProductTrxHistory.Rows[rowCounter]["M_BPARTNER_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (dtBpartnerInfo.Rows.Count > 0)
                    this.dtProductTrxHistory.Rows[rowCounter]["BUISNESS PARTNER"] =
                        dtBpartnerInfo.Rows[0]["NAME"].ToString();

                if (dtTransactionInfo.Rows[0]["DOCSTATUS"].ToString() == "DR")
                    dtProductTrxHistory.Rows[rowCounter]["STATUS"] = "Drafted";
                else if (dtTransactionInfo.Rows[0]["DOCSTATUS"].ToString() == "CO")
                    dtProductTrxHistory.Rows[rowCounter]["STATUS"] = "Completed";
                else if (dtTransactionInfo.Rows[0]["DOCSTATUS"].ToString() == "RE")
                    dtProductTrxHistory.Rows[rowCounter]["STATUS"] = "Reversed";

            }
            this.dtProductTrxHistory.Columns["TRXDATE"].ColumnName = "DATE";
            this.dtProductTrxHistory.Columns["ISSALESTRX"].ColumnName = "IS SALES";
            this.dtProductTrxHistory.Columns["TRXQUANTITY"].ColumnName = "QUANTITY";
            this.dtProductTrxHistory.Columns["UNITPRICE"].ColumnName = "UNIT PRICE";
            this.dtProductTrxHistory.Columns["DISCOUNTRATE"].ColumnName = "DISCOUNT RATE";
            this.dtProductTrxHistory.Columns["DISCOUNTAMT"].ColumnName = "DISCOUNT AMT";
            this.dtProductTrxHistory.Columns["LINENETAMT"].ColumnName = "NET AMOUNT";
            this.dtProductTrxHistory.Columns["LINETAXAMOUNT"].ColumnName = "TAX AMOUNT";

            this.dtProductTrxHistory.Columns.Remove("M_BPARTNER_ID");
            this.dtProductTrxHistory.Columns.Remove("M_UOM_ID");
            this.dtProductTrxHistory.Columns.Remove("T_TRANSACTION_ID");

            this.dtProductTrxHistory.Columns["DOCUMENT NO."].SetOrdinal(1);
            this.dtProductTrxHistory.Columns["BUISNESS PARTNER"].SetOrdinal(2);
            this.dtProductTrxHistory.Columns["UNIT"].SetOrdinal(
                    this.dtProductTrxHistory.Columns.IndexOf("QUANTITY")+1);
            this.dtgItemTrxHistroy.DataSource = this.dtProductTrxHistory;
        }
    }
}
