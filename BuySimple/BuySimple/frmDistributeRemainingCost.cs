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
    public partial class frmDistributeRemainingCost : Form
    {
        public frmDistributeRemainingCost()
        {
            InitializeComponent();
        }

        int intCurrentPaymentRowIndex = -1;

        decimal remainingDistributableAMT = 0;

        string stPURCHASEPAYMENT_ID = "";
        string stORDER_ID = "";

        DataTable dtInvoiceOrderDistributablePayments = new DataTable(); 
        DataTable dtPMCommercialInvoicesList = new DataTable();

        dataBuilder getDataFromDB = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();


        private void getDistributablePMWithOpenBalance()
        {
            this.dtInvoiceOrderDistributablePayments =
                this.getDataFromDB.getOpenPM_C_PURCHASEPAYMENTInfo(null, "", 
                                    generalResultInformation.organiztionId, "",
                                    "", "", "", "", "", "", "", "", "", triaStateBool.Ignor, 
                                    triaStateBool.Ignor, triaStateBool.yes, "AND");


            this.dtgDistributableCost.DataSource = this.dtInvoiceOrderDistributablePayments;
            this.dtgDistributableCost.Columns["PM_C_PURCHASEPAYMENT_ID"].Visible = false;
            this.dtgDistributableCost.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgDistributableCost.Columns["AD_ORG_ID"].Visible = false;
            this.dtgDistributableCost.Columns["CREATED"].Visible = false;
            this.dtgDistributableCost.Columns["CREATEDBY"].Visible = false;
            this.dtgDistributableCost.Columns["UPDATED"].Visible = false;
            this.dtgDistributableCost.Columns["UPDATEDBY"].Visible = false;
            this.dtgDistributableCost.Columns["ISACTIVE"].Visible = false;
            this.dtgDistributableCost.Columns["ISAMOUNTESTIMATE"].Visible = false;
            this.dtgDistributableCost.Columns["DESCRIPTION"].Visible = false;
            this.dtgDistributableCost.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgDistributableCost.Columns["USERINSERTED"].Visible = false;
            this.dtgDistributableCost.Columns["ISAMOUNTDISTRIBUTABLE"].Visible = false;
            this.dtgDistributableCost.Columns["COSTCLOSED"].Visible = false;
            this.dtgDistributableCost.Columns["PROCESSING"].Visible = false;
            this.dtgDistributableCost.Columns["PROCESSED"].Visible = false;

            this.dtgDistributableCost.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_BANKACCOUNT_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_CASHBOOK_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_TAX_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgDistributableCost.Columns["C_ORDER_ID"].Visible = false;

            this.dtgDistributableCost.Columns["DOCUMENTNO"].HeaderText = "Document";
            this.dtgDistributableCost.Columns["DATEINVOICED"].HeaderText = "Date";
            this.dtgDistributableCost.Columns["INVOICEAMOUNT"].HeaderText = "Amount";
            this.dtgDistributableCost.Columns["PAYMENTTYPE"].HeaderText = "Type";
            this.dtgDistributableCost.Columns["PAYEDFROM"].HeaderText = "Payed From";
            this.dtgDistributableCost.Columns["PAYEDFOR"].HeaderText = "Payed For";

            this.dtgDistributableCost.Columns["ORDER_DOC"].HeaderText = "Order";
            this.dtgDistributableCost.Columns["AMOUNTSHARED"].HeaderText = "Shared";
            this.dtgDistributableCost.Columns["REMAINING"].HeaderText = "Remained";
            this.dtgDistributableCost.Columns["PRCNTG"].HeaderText = "%tage Remained";


            this.dtgDistributableCost.Columns["INVOICEAMOUNT"].DefaultCellStyle.Format = "N2";
            this.dtgDistributableCost.Columns["AMOUNTSHARED"].DefaultCellStyle.Format = "N2";
            this.dtgDistributableCost.Columns["REMAINING"].DefaultCellStyle.Format = "N2";
            this.dtgDistributableCost.Columns["PRCNTG"].DefaultCellStyle.Format = "N2";

            this.dtgDistributableCost.Columns["INVOICEAMOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgDistributableCost.Columns["AMOUNTSHARED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgDistributableCost.Columns["REMAINING"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgDistributableCost.Columns["PRCNTG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            this.dtgDistributableCost.ClearSelection();


        }

        private void getPM_CommInvlist()
        {           
            this.dtPMCommercialInvoicesList = 
                this.getDataFromDB.getC_INVOICEInfo(null, "", "", "",
                            stORDER_ID, "", "", "", "", "CO", "", 
                            triaStateBool.no, triaStateBool.yes, true, this.stORDER_ID == "", "AND");

            this.dtPMCommercialInvoicesList.Columns.Add("Vendor");
            this.dtPMCommercialInvoicesList.Columns.Add("Order");
            this.dtPMCommercialInvoicesList.Columns.Add("Check", Type.GetType("System.Boolean"));

            DataTable dtBpartner;
            DataTable dtOrder;

            for (int rowCounter = 0; rowCounter <= this.dtPMCommercialInvoicesList.Rows.Count - 1; rowCounter++)
            {
                dtBpartner = 
                    this.getDataFromDB.getC_BPARTNERInfo(null, "", "",
                        this.dtPMCommercialInvoicesList.Rows[rowCounter]["C_BPARTNER_ID"].ToString(), 
                        "", triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor, 
                        triaStateBool.Ignor, false, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtBpartner))
                {
                    this.dtPMCommercialInvoicesList.Rows[rowCounter]["Vendor"] = dtBpartner.Rows[0]["NAME"].ToString(); 
                }

                dtOrder =
                        this.getDataFromDB.getC_ORDERInfo(null, "", "", 
                            this.dtPMCommercialInvoicesList.Rows[rowCounter]["C_ORDER_ID"].ToString(), 
                            "", "", "", "", "", "", triaStateBool.Ignor, triaStateBool.Ignor, false, 
                            false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtOrder))
                {
                    this.dtPMCommercialInvoicesList.Rows[rowCounter]["Order"] = dtOrder.Rows[0]["DOCUMENTNO"].ToString();
                }

                this.dtPMCommercialInvoicesList.Rows[rowCounter]["Check"] = false;                
            }

            this.dtPMCommercialInvoicesList.Columns["Check"].SetOrdinal(0);
            this.dtPMCommercialInvoicesList.Columns["DOCUMENTNO"].SetOrdinal(1);
            this.dtPMCommercialInvoicesList.Columns["DATEINVOICED"].SetOrdinal(2);
            this.dtPMCommercialInvoicesList.Columns["Vendor"].SetOrdinal(3);
            this.dtPMCommercialInvoicesList.Columns["Order"].SetOrdinal(4);
            this.dtPMCommercialInvoicesList.Columns["GRANDTOTAL"].SetOrdinal(5);


            this.dtgCommercialInvoice.DataSource = this.dtPMCommercialInvoicesList;

            this.dtgCommercialInvoice.Columns["Check"].HeaderText = "";
            this.dtgCommercialInvoice.Columns["DOCUMENTNO"].HeaderText = "Invoice";
            this.dtgCommercialInvoice.Columns["DATEINVOICED"].HeaderText = "Date";
            this.dtgCommercialInvoice.Columns["GRANDTOTAL"].HeaderText = "Amount";


            foreach (DataGridViewColumn columns in this.dtgCommercialInvoice.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            this.dtgCommercialInvoice.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["AD_ORG_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISACTIVE"].Visible = false;
            this.dtgCommercialInvoice.Columns["CREATED"].Visible = false;
            this.dtgCommercialInvoice.Columns["CREATEDBY"].Visible = false;
            this.dtgCommercialInvoice.Columns["UPDATED"].Visible = false;
            this.dtgCommercialInvoice.Columns["UPDATEDBY"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISSOTRX"].Visible = false;
            this.dtgCommercialInvoice.Columns["DOCSTATUS"].Visible = false;
            this.dtgCommercialInvoice.Columns["DOCACTION"].Visible = false;
            this.dtgCommercialInvoice.Columns["PROCESSING"].Visible = false;
            this.dtgCommercialInvoice.Columns["PROCESSED"].Visible = false;
            this.dtgCommercialInvoice.Columns["POSTED"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_DOCTYPE_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_DOCTYPETARGET_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_ORDER_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["DESCRIPTION"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISAPPROVED"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISTRANSFERRED"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISPRINTED"].Visible = false;
            this.dtgCommercialInvoice.Columns["SALESREP_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["DATEPRINTED"].Visible = false;
            this.dtgCommercialInvoice.Columns["DATEACCT"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_BPARTNER_LOCATION_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["POREFERENCE"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISDISCOUNTPRINTED"].Visible = false;
            this.dtgCommercialInvoice.Columns["DATEORDERED"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_CURRENCY_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["PAYMENTRULE"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_PAYMENTTERM_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["CHARGEAMT"].Visible = false;
            this.dtgCommercialInvoice.Columns["TOTALLINES"].Visible = false;
            this.dtgCommercialInvoice.Columns["M_PRICELIST_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISTAXINCLUDED"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_CAMPAIGN_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_PROJECT_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_ACTIVITY_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISPAID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_PAYMENT_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_CASHLINE_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["CREATEFROM"].Visible = false;
            this.dtgCommercialInvoice.Columns["GENERATETO"].Visible = false;
            this.dtgCommercialInvoice.Columns["SENDEMAIL"].Visible = false;
            this.dtgCommercialInvoice.Columns["AD_USER_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["COPYFROM"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISSELFSERVICE"].Visible = false;
            this.dtgCommercialInvoice.Columns["AD_ORGTRX_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["USER1_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["USER2_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_CONVERSIONTYPE_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISPAYSCHEDULEVALID"].Visible = false;
            this.dtgCommercialInvoice.Columns["REF_INVOICE_ID"].Visible = false;
            this.dtgCommercialInvoice.Columns["ISINDISPUTE"].Visible = false;
            this.dtgCommercialInvoice.Columns["INVOICECOLLECTIONTYPE"].Visible = false;
            this.dtgCommercialInvoice.Columns["MATCHREQUIREMENTI"].Visible = false;
            this.dtgCommercialInvoice.Columns["FISCALNUMBER"].Visible = false;
            this.dtgCommercialInvoice.Columns["C_BP_FISCAL_MACHINE_ID"].Visible = false;

            this.dtgCommercialInvoice.Columns["GRANDTOTAL"].DefaultCellStyle.Format = "N2";
            this.dtgCommercialInvoice.Columns["GRANDTOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            this.dtgCommercialInvoice.ClearSelection();

        }

        private void recordPMInvoicelineShare(string C_INVOICE_ID, decimal INV_AMT, decimal AMTSHARED)
        {

            DataTable dtPMPAYMENT_INVOCESHARE =
                this.getDataFromDB.getPM_PAYMENT_INVOCESHAREInfo(null, "", "", "", 
                            "", "", "", "", triaStateBool.Ignor, false, true, "AND");


            DataRow drPInv = dtPMPAYMENT_INVOCESHARE.NewRow();
            //drPInv["PM_PAYMENT_INVOCESHARE_ID"] = null;
            drPInv["PM_C_PURCHASEPAYMENT_ID"] = this.stPURCHASEPAYMENT_ID;
            drPInv["C_INVOICE_ID"] = C_INVOICE_ID;
            drPInv["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drPInv["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drPInv["ISACTIVE"] = "Y";
            drPInv["ISAMOUNTESTIMATE"] = this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["ISAMOUNTESTIMATE"].Value.ToString();
            drPInv["AMOUNTSHARED"] = decimal.Parse(AMTSHARED.ToString("0.####"));
            if (this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_TAX_ID"].Value.ToString() != "")
            {
                drPInv["C_TAX_ID"] = this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_TAX_ID"].Value.ToString();
            }
            if (this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_CHARGE_ID"].Value.ToString() != "")
            {
                drPInv["C_CHARGE_ID"] = this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_CHARGE_ID"].Value.ToString();
            }
            drPInv["COSTCLOSED"] = "Y";
            drPInv["ISGENERATED"] = "Y";

            dtPMPAYMENT_INVOCESHARE.Rows.Add(drPInv);
            
            this.getDataFromDB.changeDataBaseTableData(dtPMPAYMENT_INVOCESHARE, "PM_PAYMENT_INVOCESHARE", "INSERT");


            DataTable dtPM_C_PPAYMENT_INVOCELINE =
                this.getDataFromDB.getPM_C_PPAYMENT_INVOCELINEInfo(null, "", "", "", 
                            "", "", "", "", "", triaStateBool.Ignor, false, 
                            triaStateBool.Ignor, true, "AND");

            DataTable dtC_INVOICELINE =
                this.getDataFromDB.getC_INVOICELINEInfo(null, "", "", C_INVOICE_ID, "", 
                        "", "",  triaStateBool.Ignor, triaStateBool.Ignor, false, false, "AND");
            

            DataRow drPInv_LN;
            decimal invLnAmtShared = 0;

            for (int rowCounter = 0; rowCounter <= dtC_INVOICELINE.Rows.Count - 1; rowCounter++)
            {
                invLnAmtShared = decimal.Parse((Math.Round(((decimal.Parse(dtC_INVOICELINE.Rows[rowCounter]["LINETOTALAMT"].ToString()) / INV_AMT) * AMTSHARED), 4)).ToString("0.####"));

                drPInv_LN = dtPM_C_PPAYMENT_INVOCELINE.NewRow();
                //drPInv_LN["PM_C_PPAYMENT_INVOCELINE_ID"] = null;
                drPInv_LN["PM_C_PURCHASEPAYMENT_ID"] = this.stPURCHASEPAYMENT_ID;
                drPInv_LN["C_INVOICELINE_ID"] = dtC_INVOICELINE.Rows[rowCounter]["C_INVOICELINE_ID"].ToString();
                drPInv_LN["C_INVOICE_ID"] = C_INVOICE_ID;
                drPInv_LN["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drPInv_LN["AD_ORG_ID"] = generalResultInformation.organiztionId;
                drPInv_LN["ISACTIVE"] = "Y";
                drPInv_LN["ISAMOUNTESTIMATE"] = this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["ISAMOUNTESTIMATE"].Value.ToString();
                drPInv_LN["AMOUNTSHARED"] = invLnAmtShared;
                if (this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_TAX_ID"].Value.ToString() != "")
                {
                    drPInv_LN["C_TAX_ID"] = this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_TAX_ID"].Value.ToString();
                }
                if (this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_CHARGE_ID"].Value.ToString() != "")
                {
                    drPInv_LN["C_CHARGE_ID"] = this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_CHARGE_ID"].Value.ToString();
                }
                drPInv_LN["COSTCLOSED"] = "N";
                drPInv_LN["ISGENERATED"] = "Y";

                dtPM_C_PPAYMENT_INVOCELINE.Rows.Add(drPInv_LN);
            }

            this.getDataFromDB.changeDataBaseTableData(dtPM_C_PPAYMENT_INVOCELINE, "PM_C_PPAYMENT_INVOCELINE", "INSERT"); 


        }


        private void frmDistributeRemainingCost_Load(object sender, EventArgs e)
        {
            //Get All PM with Open Balance
            this.getDistributablePMWithOpenBalance();

            this.TopMost = true;
            this.TopMost = false;
            this.Activate();
        }



        private void dtgDistributableCost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.stPURCHASEPAYMENT_ID = "";
            this.stORDER_ID = "";
            this.intCurrentPaymentRowIndex = -1;
            this.remainingDistributableAMT = 0;
            
            this.intCurrentPaymentRowIndex = 
                this.dtgDistributableCost.SelectedRows[0].Index;

            if (this.intCurrentPaymentRowIndex != -1)
            {
                this.stPURCHASEPAYMENT_ID =
                    this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString();

                this.stORDER_ID =
                    this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["C_ORDER_ID"].Value.ToString();

                this.remainingDistributableAMT =
                   decimal.Parse(this.dtgDistributableCost.Rows[intCurrentPaymentRowIndex].Cells["REMAINING"].Value.ToString()); 

                this.getPM_CommInvlist();
            }

        }

        private void dtgCommercialInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCommercialInvoice.SelectedRows.Count < 1)
                return;


            int currentSelectedRowIndex = this.dtgCommercialInvoice.SelectedRows[0].Index;

            if (this.dtgCommercialInvoice.CurrentCell.OwningColumn.Index == 0 &&
                this.dtgCommercialInvoice.CurrentCell.OwningColumn.Name == "Check" &&
                this.dtgCommercialInvoice.CurrentCell.OwningColumn.HeaderText == "")
            {
                this.dtgCommercialInvoice.CurrentCell.Value =
                        !(Convert.ToBoolean(this.dtgCommercialInvoice.CurrentCell.Value.ToString()));
                this.dtPMCommercialInvoicesList.Rows[currentSelectedRowIndex]["Check"] =
                    (Convert.ToBoolean(this.dtgCommercialInvoice.CurrentCell.Value.ToString()));
            }

        }



        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (this.stPURCHASEPAYMENT_ID == "")
            {
                return;
            }

            if (MessageBox.Show("Are you sure you what to close this payment without distributing", 
                "Buy Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            DataTable dtPMRecord =
                this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "", "",
                        this.stPURCHASEPAYMENT_ID, "", "", "", "", "", "", "",
                        "", "", triaStateBool.no, triaStateBool.Ignor,
                        triaStateBool.Ignor, triaStateBool.Ignor,
                        triaStateBool.Ignor, false, "AND");

            if (this.getDataFromDB.checkIfTableContainesData(dtPMRecord))
            {
                dtPMRecord.Rows[0]["COSTCLOSED"] = "Y";
                dtPMRecord.Rows[0]["PROCESSING"] = "N";
                dtPMRecord.Rows[0]["PROCESSED"] = "Y";
                this.getDataFromDB.changeDataBaseTableData(dtPMRecord, "PM_C_PURCHASEPAYMENT", "UPDATE");
            }

            this.dtInvoiceOrderDistributablePayments.AsEnumerable()
                .Where(r => r.Field<decimal>("PM_C_PURCHASEPAYMENT_ID") == decimal.Parse(this.stPURCHASEPAYMENT_ID))
                .ToList().ForEach(row => row.Delete());
            this.dtInvoiceOrderDistributablePayments.AcceptChanges();

            this.dtgDistributableCost.ClearSelection();

            this.dtPMCommercialInvoicesList.Rows.Clear();

            MessageBox.Show("Cancellation completed successfully", "Buy Simple", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void cmdDistribute_Click(object sender, EventArgs e)
        {

            if (this.dtPMCommercialInvoicesList.AsEnumerable().Where(r => r.Field<Boolean>("Check")== true).Count() == 0)
            {
                return;
            }
               

            if (MessageBox.Show("Are you sure you would like to distribute the remaining cost according to selection",
                "Buy Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            decimal INV_SUM = 
                this.dtPMCommercialInvoicesList.AsEnumerable()
                    .Where(r => r.Field<Boolean>("Check") == true)
                    .Sum(r => r.Field<decimal>("GRANDTOTAL"));

            this.dtPMCommercialInvoicesList.AsEnumerable()
                .Where(r => r.Field<Boolean>("Check")== true)
                .ToList()
                .ForEach( row =>
                    recordPMInvoicelineShare(row["C_INVOICE_ID"].ToString(), decimal.Parse(row["GRANDTOTAL"].ToString()), 
                                             Math.Round(((decimal.Parse(row["GRANDTOTAL"].ToString()) / INV_SUM) * this.remainingDistributableAMT), 4)));
            

            DataTable dtPMRecord =
                this.getDataFromDB.getPM_C_PURCHASEPAYMENTInfo(null, "", "",
                        this.stPURCHASEPAYMENT_ID, "", "", "", "", "", "", "",
                        "", "", triaStateBool.no, triaStateBool.Ignor,
                        triaStateBool.Ignor, triaStateBool.Ignor,
                        triaStateBool.Ignor, false, "AND");

            if (this.getDataFromDB.checkIfTableContainesData(dtPMRecord))
            {
                dtPMRecord.Rows[0]["COSTCLOSED"] = "Y";
                this.getDataFromDB.changeDataBaseTableData(dtPMRecord, "PM_C_PURCHASEPAYMENT", "UPDATE");
            }

            this.dtInvoiceOrderDistributablePayments.AsEnumerable()
                .Where(r => r.Field<decimal>("PM_C_PURCHASEPAYMENT_ID") == decimal.Parse(this.stPURCHASEPAYMENT_ID))
                .ToList().ForEach(row => row.Delete());
            this.dtInvoiceOrderDistributablePayments.AcceptChanges();

            this.dtgDistributableCost.ClearSelection();

            this.dtPMCommercialInvoicesList.Rows.Clear();
            
            MessageBox.Show("Distribution completed successfully", "Buy Simple", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    
    }
}
