using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbConnection;

namespace BankPayments
{
    public partial class frmDocPrintPreview : Form
    {
        public frmDocPrintPreview()
        {
            InitializeComponent();
        }


        public bool blPrintDocument = false;
        
        public dtsDocumentData dtsDocumentPrintView = new dtsDocumentData();

        dataBuilder getDataFromDb = new dataBuilder();
        string stPrintTableName = "";
        string stRecordReference = "";        

        private void frmDocPrintPreview_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.requestedPrintDocType == printDocType.UNKOWN)
            {
                this.Close();
            }

            if (!System.IO.File.Exists("crptPaymentVoucher.rpt"))
            {
                this.Close();
            }

            if (generalResultInformation.requestedPrintDocType == printDocType.paymentVoucher)
            {
                this.crptPOSDocumentToPrint.FileName = "crptPaymentVoucher.rpt";
                this.stPrintTableName = "C_BANKCHECK";
                this.stRecordReference =
                    this.dtsDocumentPrintView.Tables["dtPaymentVoucher"].
                        Rows[0]["C_BANKCHECK_ID"].ToString();                
            }
            else if (generalResultInformation.requestedPrintDocType == printDocType.check)
            {
                this.crptPOSDocumentToPrint.FileName = "crptBankPhysicalCheck.rpt";
                stPrintTableName = "PHYSICAL_CHECK";
                this.stRecordReference =
                    this.dtsDocumentPrintView.Tables["dtPaymentVoucher"].
                            Rows[0]["CHECKNO"].ToString();                
            }
            else if (generalResultInformation.requestedPrintDocType == printDocType.confirmation)
            {
                this.crptPOSDocumentToPrint.FileName = "crptBankCheckConfirmation.rpt";
                stPrintTableName = "CHECK_CONFIRMATION";
                this.stRecordReference =
                    this.dtsDocumentPrintView.Tables["dtPaymentVoucher"].
                            Rows[0]["CHECKNO"].ToString();
            }

            this.crptPOSDocumentToPrint.SetDataSource(this.dtsDocumentPrintView);
            this.crpvPOSDocumentPrintPrivew.ReportSource = this.crptPOSDocumentToPrint;
            this.crpvPOSDocumentPrintPrivew.Zoom(75);
            this.WindowState = FormWindowState.Maximized;

            if (this.blPrintDocument)
                this.cmdPrintDocument_Click(sender, e);
        }

        private void cmdPrintDocument_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult printDialogResutl = 
                MessageBox.Show("Are you sure you want to print this Document?", "Printing",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (printDialogResutl != DialogResult.Yes)
                return;
            
            this.Enabled = false;
            try
            {
                this.crptPOSDocumentToPrint.PrintOptions.PrinterName =
                otherSettings.defaultPrinterName;
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }
            if (this.crptPOSDocumentToPrint.PrintOptions.PrinterName == "")
            {
                MessageBox.Show("No printer Found. \n Contact Your Administrator", "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }

            //this.crptMaterialMovement.PrintOptions.PaperSize = 
            //    CrystalDecisions.Shared.PaperSize.PaperA4;
            //this.crptMaterialMovement.PrintOptions.PaperOrientation = 
            //    CrystalDecisions.Shared.PaperOrientation.Landscape;
                        
            try
            {
                this.crptPOSDocumentToPrint.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }

            //if (MessageBox.Show("Did Document printed?", "Printing",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    //Record Print Job.

            //    DataTable dtPrintJob =
            //        this.getDataFromDb.getPrintJobInfo(null, "", "", "", "", "", "", true, "");
            //    if (dtPrintJob.Columns.Count <= 0)
            //    {
            //        MessageBox.Show("Print Job Not Recorded. Contac Your Administrator.", "Printing",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.Enabled = true;
            //        return;
            //    }
            //    DataRow drNewPrintJob = dtPrintJob.NewRow();
            //    drNewPrintJob["TABLENAME"] = stPrintTableName;
            //    drNewPrintJob["RECORDREFERENCE"] = stRecordReference;
            //    drNewPrintJob["PRINTED"] = DateTime.Now;
            //    //drNewPrintJob["PRINTEDBY"] = "";
            //    //drNewPrintJob["ID"] = "";
            //    drNewPrintJob["STATION"] = stStaion;
            //    drNewPrintJob["NODE"] = stNode;
            //    dtPrintJob.Rows.Add(drNewPrintJob);
            //    this.getDataFromDb.changeDataBaseTableData(dtPrintJob, "PRINT_JOB", "INSERT", true);                    
            //}
            //else
            //{
            //    //Request and execute re-printing.
            //    if (MessageBox.Show("Do you want RE-TRY printing this Document?", "Printing",
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        goto printDocument;
            //    }
            //}
            this.Enabled = true;
            this.Close();
        }
        

    }
}
