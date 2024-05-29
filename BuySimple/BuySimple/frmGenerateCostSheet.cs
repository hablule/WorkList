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
    public partial class frmGenerateCostSheet : Form
    {
        public frmGenerateCostSheet()
        {
            InitializeComponent();
        }

        decimal invoiceTotal = 0;

        DataTable searchQuery = new DataTable();
        DataTable dtCommercialInvoiceLineCost = new DataTable();

        dataBuilder getDataFromDB = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();

        dtsDocumentData dtsDocData = new dtsDocumentData();
        

        private DataTable establishValidCommercialInvoices(string C_ORDER_ID, string DOCUMENTNO)
        {
            DataTable dtCommercilInvoices =
                    this.getDataFromDB.getC_INVOICEInfo(null, "", generalResultInformation.organiztionId,
                                "", C_ORDER_ID, "", "", "", "", "CO", DOCUMENTNO, triaStateBool.no, triaStateBool.yes,
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


        public void getCostSheetData()
        {
            invoiceTotal = Convert.ToDecimal(this.ddgCommercialInvoice.SelectedRow.Rows[0]["TOTALLINES"]);
            string isCost = "";
            string chargeTaxnName = "";
            //string TAX_ID = "";
            //string CHARGE_ID = "";

            DataTable dtInvoiceLineShare;
            DataTable dtPurchasePayment;
            DataTable dtPurchasePaymentInvoiceShare;
            DataTable dtCostList;
            DataTable dtCostDistr;
            DataTable dtsCostList;
            DataTable dtTaxChargeName;
            DataTable dtInvoiceline;
            DataTable dtProductName;
            DataTable dtOtherInvoiceLinePrice;
            DataTable costDtl;            


            this.dtsDocData.Tables["dtDocInfo"].Rows.Clear();
            this.dtsDocData.Tables["dtCostList"].Rows.Clear();
            this.dtsDocData.Tables["dtCostDistribution"].Rows.Clear();

            dtsCostList = this.dtsDocData.Tables["dtCostList"].Copy();
            costDtl = this.dtsDocData.Tables["dtCostDistribution"].Copy();


            this.dtsDocData.Tables["dtDocInfo"].Rows.Add(new[] { this.ddgCommercialInvoice.SelectedItem.ToString() });

            dtInvoiceLineShare =
                this.getDataFromDB.getPM_C_PPAYMENT_INVOCELINEInfo(null, "", "", "", "", "",
                                    this.ddgCommercialInvoice.SelectedRowKey.ToString(), "", "",
                                    triaStateBool.Ignor, true, triaStateBool.Ignor, false, "AND");

            dtPurchasePayment = 
                this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "", "", "", "", "", "", 
                            this.ddgCommercialInvoice.SelectedRowKey.ToString(), "", "", "", 
                            "", "", triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor, 
                            triaStateBool.Ignor, triaStateBool.yes, false, "AND");


            dtCostList = dtPurchasePayment.Copy().AsEnumerable()
                            .GroupBy(col => new
                            {
                                C_TAX_ID = col["C_TAX_ID"],
                                C_CHARGE_ID = col["C_CHARGE_ID"]
                            })
                            .Select(g =>
                            {
                                var drCstLst = dtPurchasePayment.NewRow();
                                drCstLst["C_TAX_ID"] = g.Key.C_TAX_ID;
                                drCstLst["C_CHARGE_ID"] = g.Key.C_CHARGE_ID;
                                drCstLst["INVOICEAMOUNT"] = g.Sum(r => r.Field<decimal>("INVOICEAMOUNT"));
                                return drCstLst;
                            })
                            .Where(w=> w.Field<string>("PAYMENTTYPE")!="Cancellation")
                            .CopyToDataTable();

            dtCostDistr = dtInvoiceLineShare.AsEnumerable()
                .Where(w=> !w.IsNull("C_CHARGE_ID")).CopyToDataTable();

            dtCostDistr = dtCostDistr.AsEnumerable()
                            .GroupBy(col => new
                            {
                                C_INVOICELINE_ID = col["C_INVOICELINE_ID"]
                            })
                            .Select(g =>
                            {
                                var drCstDistr = dtInvoiceLineShare.NewRow();
                                drCstDistr["C_INVOICELINE_ID"] = g.Key.C_INVOICELINE_ID;
                                drCstDistr["AMOUNTSHARED"] = g.Sum(r => r.Field<decimal>("AMOUNTSHARED"));
                                return drCstDistr;
                            }).CopyToDataTable();

                        
            for (int rowCounter = 0; rowCounter <= dtCostList.Rows.Count - 1; rowCounter++)
            {

                if (Convert.ToString(dtCostList.Rows[rowCounter]["C_TAX_ID"]) != "")
                {
                    dtTaxChargeName =
                        this.getDataFromDB.getC_TAXInfo(null, "", "",
                            dtCostList.Rows[rowCounter]["C_TAX_ID"].ToString(),
                            "", "", false, triaStateBool.Ignor, triaStateBool.Ignor,
                            false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtTaxChargeName))
                    {
                        chargeTaxnName = dtTaxChargeName.Rows[0]["NAME"].ToString();
                        isCost = "N";
                    }
                    else
                    {
                        chargeTaxnName = "";
                        isCost = "";
                    }
                }
                else if (Convert.ToString(dtCostList.Rows[rowCounter]["C_CHARGE_ID"]) != "")
                {
                    dtTaxChargeName =
                        this.getDataFromDB.getC_CHARGEInfo(null, "", "",
                            dtCostList.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                            "", false, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtTaxChargeName))
                    {
                        chargeTaxnName = dtTaxChargeName.Rows[0]["NAME"].ToString();
                        isCost = "Y";
                    }
                    else
                    {
                        chargeTaxnName = "";
                        isCost = "";
                    }
                }
                else
                {
                    chargeTaxnName = "";
                    isCost = "";
                }


                dtsCostList.Rows.Add(new object[]{
                    dtCostList.Rows[rowCounter]["C_TAX_ID"].ToString(),
                    dtCostList.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                    chargeTaxnName,
                    isCost,
                    dtCostList.Rows[rowCounter]["INVOICEAMOUNT"].ToString()
                });
            }

            dtPurchasePaymentInvoiceShare = 
                this.getDataFromDB.getPM_PAYMENT_INVOCESHAREInfo(null, "", "", "", "", 
                            this.ddgCommercialInvoice.SelectedRowKey.ToString(), "", "", 
                            triaStateBool.Ignor, true, false, "AND");

            if (this.getDataFromDB.checkIfTableContainesData(dtPurchasePaymentInvoiceShare))
            {
                dtPurchasePaymentInvoiceShare = 
                    dtPurchasePaymentInvoiceShare.AsEnumerable()
                            .GroupBy(col => new
                            {
                                C_CHARGE_ID = col["C_CHARGE_ID"],
                                C_TAX_ID = col["C_TAX_ID"]
                            })
                            .Select(g =>
                            {
                                var drCstInvShareDistr = dtPurchasePaymentInvoiceShare.NewRow();
                                drCstInvShareDistr["C_CHARGE_ID"] = g.Key.C_CHARGE_ID;
                                drCstInvShareDistr["C_TAX_ID"] = g.Key.C_TAX_ID;
                                drCstInvShareDistr["AMOUNTSHARED"] = g.Sum(r => r.Field<decimal>("AMOUNTSHARED"));
                                return drCstInvShareDistr;
                            }).CopyToDataTable();

                for (int rowCounter = 0; rowCounter <= dtPurchasePaymentInvoiceShare.Rows.Count - 1; rowCounter++)
                {
                    if (Convert.ToString(dtPurchasePaymentInvoiceShare.Rows[rowCounter]["C_TAX_ID"]) != "")
                    {
                        dtTaxChargeName =
                            this.getDataFromDB.getC_TAXInfo(null, "", "",
                                dtPurchasePaymentInvoiceShare.Rows[rowCounter]["C_TAX_ID"].ToString(),
                                "", "", false, triaStateBool.Ignor, triaStateBool.Ignor,
                                false, "AND");

                        if (this.getDataFromDB.checkIfTableContainesData(dtTaxChargeName))
                        {
                            chargeTaxnName = dtTaxChargeName.Rows[0]["NAME"].ToString();
                            isCost = "N";
                        }
                        else
                        {
                            chargeTaxnName = "";
                            isCost = "";
                        }
                    }
                    else if (Convert.ToString(dtPurchasePaymentInvoiceShare.Rows[rowCounter]["C_CHARGE_ID"]) != "")
                    {
                        dtTaxChargeName =
                            this.getDataFromDB.getC_CHARGEInfo(null, "", "",
                                dtPurchasePaymentInvoiceShare.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                                "", false, false, "AND");

                        if (this.getDataFromDB.checkIfTableContainesData(dtTaxChargeName))
                        {
                            chargeTaxnName = dtTaxChargeName.Rows[0]["NAME"].ToString();
                            isCost = "Y";
                        }
                        else
                        {
                            chargeTaxnName = "";
                            isCost = "";
                        }
                    }
                    else
                    {
                        chargeTaxnName = "";
                        isCost = "";
                    }


                    dtsCostList.Rows.Add(new object[]{
                            dtPurchasePaymentInvoiceShare.Rows[rowCounter]["C_TAX_ID"].ToString(),
                            dtPurchasePaymentInvoiceShare.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                            chargeTaxnName,
                            isCost,
                            dtPurchasePaymentInvoiceShare.Rows[rowCounter]["AMOUNTSHARED"].ToString()
                    });
                }
            }


            dtsCostList =
                    dtsCostList.AsEnumerable()
                            .GroupBy(col => new
                            {
                                C_CHARGE_ID = col["C_CHARGE_ID"],
                                C_TAX_ID = col["C_TAX_ID"],
                                NAME = col["NAME"],
                                isCost = col["isCost"]
                            })
                            .Select(g =>
                            {
                                var drCstInvShareDistr = dtsCostList.NewRow();
                                drCstInvShareDistr["C_CHARGE_ID"] = g.Key.C_CHARGE_ID;
                                drCstInvShareDistr["C_TAX_ID"] = g.Key.C_TAX_ID;
                                drCstInvShareDistr["NAME"] = g.Key.NAME;
                                drCstInvShareDistr["isCost"] = g.Key.isCost;
                                drCstInvShareDistr["AMOUNTSHARED"] = g.Sum(r => r.Field<decimal>("AMOUNTSHARED"));
                                return drCstInvShareDistr;
                            }).CopyToDataTable();


            DataView dv1 = new DataView(dtsCostList);
            dv1.Sort = "NAME Asc";
            dtsCostList = dv1.ToTable();


            if (this.getDataFromDB.checkIfTableContainesData(dtsCostList))
            {
                for (int rowCounter = 0; rowCounter <= dtsCostList.Rows.Count - 1; rowCounter++)
                {

                    this.dtsDocData.Tables["dtCostList"].Rows.Add(new object[]{
                            dtsCostList.Rows[rowCounter]["C_TAX_ID"].ToString(),
                            dtsCostList.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                            dtsCostList.Rows[rowCounter]["NAME"].ToString(),                            
                            dtsCostList.Rows[rowCounter]["isCost"].ToString(),
                            dtsCostList.Rows[rowCounter]["AMOUNTSHARED"].ToString()
                    });
                } 
            }            


            decimal ratio = 0;
            decimal price = 0;
            decimal priceOther = 0;
            bool recordISrecent = true;


            costDtl.Columns.Add("Ln", typeof(int));

            for (int rowCounter = 0; rowCounter <= dtCostDistr.Rows.Count - 1; rowCounter++)
            {
                ratio = 0;
                priceOther = 0;
                price = 0;
                recordISrecent = true;

                dtInvoiceline = 
                    this.getDataFromDB.getC_INVOICELINEInfo(null, "", "", "",
                            dtCostDistr.Rows[rowCounter]["C_INVOICELINE_ID"].ToString(),
                            "", "", triaStateBool.no, triaStateBool.Ignor, false, false, "AND");

                if (!this.getDataFromDB.checkIfTableContainesData(dtInvoiceline))
                    continue;

                dtProductName = this.getDataFromDB.getM_PRODUCTInfo(null, "",
                            dtInvoiceline.Rows[0]["M_PRODUCT_ID"].ToString(), 
                            false, false, "AND");

                if (!this.getDataFromDB.checkIfTableContainesData(dtProductName))
                    continue;

                dtOtherInvoiceLinePrice =
                    this.getDataFromDB.getC_INVOICELINE_PRICESInfo(null, "", "",
                        dtInvoiceline.Rows[0]["C_INVOICELINE_ID"].ToString(),
                        false, false, "AND");

                if (!this.getDataFromDB.checkIfTableContainesData(dtOtherInvoiceLinePrice))
                {
                    dtOtherInvoiceLinePrice =
                        this.getDataFromDB.getC_ORDERLINEInfo(null, "", "", "",
                                    dtInvoiceline.Rows[0]["C_ORDERLINE_ID"].ToString(),
                                    "", "", triaStateBool.no, triaStateBool.Ignor, false, false, "AND");
                    recordISrecent = false;                    
                }

                if (this.getDataFromDB.checkIfTableContainesData(dtOtherInvoiceLinePrice))
                {
                    priceOther = Convert.ToDecimal(dtOtherInvoiceLinePrice.Rows[0]["PRICEACTUAL"]);
                }

                if (!recordISrecent)
                {
                    price = Convert.ToDecimal(dtInvoiceline.Rows[0]["PRICEENTERED"]);
                }
                else
                {
                    price = Convert.ToDecimal(dtInvoiceline.Rows[0]["PRICEENTERED"]) +
                        (Convert.ToDecimal(dtCostDistr.Rows[rowCounter]["AMOUNTSHARED"]) / 
                            Convert.ToDecimal(dtInvoiceline.Rows[0]["QTYENTERED"].ToString())); 
                }

                ratio = Math.Round(((Convert.ToDecimal(dtCostDistr.Rows[rowCounter]["AMOUNTSHARED"])) / invoiceTotal) * 100, 2);


                costDtl.Rows.Add(new object[]{
                                dtInvoiceline.Rows[0]["C_INVOICELINE_ID"].ToString(),
                                dtInvoiceline.Rows[0]["LINE"].ToString(),
                                dtProductName.Rows[0]["M_PRODUCT_ID"].ToString(),
                                dtProductName.Rows[0]["NAME"].ToString(),
                                Math.Round(Convert.ToDecimal(dtInvoiceline.Rows[0]["QTYENTERED"].ToString()),2),
                                Math.Round(priceOther,2),
                                Math.Round((Convert.ToDecimal(dtInvoiceline.Rows[0]["QTYENTERED"].ToString()) * priceOther), 2),
                                Math.Round(price,2),
                                0,
                                Math.Round((Convert.ToDecimal(dtInvoiceline.Rows[0]["QTYENTERED"].ToString()) * price), 2),
                                ratio,
                                Convert.ToInt16(dtInvoiceline.Rows[0]["LINE"])
                    });
            }

            DataView dv = new DataView(costDtl);
            dv.Sort = "Ln Asc";
            costDtl = dv.ToTable();

            costDtl.Columns.Remove("Ln");

            foreach (DataRow dr in costDtl.Rows)
            {
                this.dtsDocData.Tables["dtCostDistribution"].Rows.Add(dr.ItemArray); 
            }

        }


        private void frmGenerateCostSheet_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.TopMost = true;
            this.TopMost = false;
            this.Activate();
        }

        private void ddgCommercialInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            
            this.ddgCommercialInvoice.DataSource =
                 this.establishValidCommercialInvoices("", ddgCommercialInvoice.SelectedItem);

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
            if (this.ddgCommercialInvoice.SelectedRow.Rows.Count > 0 ||
                this.ddgCommercialInvoice.SelectedRowKey != null)
            {
                this.cmdShowCostSheet.Enabled = true;
            }
            else
                this.cmdShowCostSheet.Enabled = false;
        }

        private void cmdShowCostSheet_Click(object sender, EventArgs e)
        {
            frmDocPrintPreview frmDocPrv = new frmDocPrintPreview();
            this.getCostSheetData();
            frmDocPrv.dtsDocumentPrintView = this.dtsDocData;

            frmDocPrv.ShowDialog();
        }


    }
}
