using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace POSDocumentPrinter
{
    public partial class frmDocPrintPreview : Form
    {
        public frmDocPrintPreview()
        {
            InitializeComponent();
        }


        dataBuilder getDataFromDb = new dataBuilder();
        string stPrintTableName = "";
        string stRecordReference = "";
        string stStaion = "";
        string stNode = "";
        
        private void frmDocPrintPreview_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.requestedReport == reportType.UNKOWN)
            {
                this.Close();
            }

            if (!System.IO.File.Exists("crptAttachmentInvoice.rpt") ||
                !System.IO.File.Exists("crptDeliveryOrder.rpt") ||
                !System.IO.File.Exists("crptRefundBook.rpt") ||
                !System.IO.File.Exists("crptCashReceiptVoucher.rpt") ||
                !System.IO.File.Exists("crptCashDepositSlip.rpt") ||
                !System.IO.File.Exists("crptOpenInvoice.rpt"))
            {
                this.Close();
            }
                        
            if (generalResultInformation.requestedReport == reportType.attachment)
            {
                this.crptPOSDocumentToPrint.FileName = "crptAttachmentInvoice.rpt";
                this.stPrintTableName = "SALES";
                this.stRecordReference =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtAttachmentSummary"].
                        Rows[0]["ReferenceNumber"].ToString();
                this.stStaion = generalResultInformation.Station;
                this.stNode = generalResultInformation.concernedNode;
            }
            else if (generalResultInformation.requestedReport == reportType.deliveryOrder)
            {
                this.crptPOSDocumentToPrint.FileName = "crptDeliveryOrder.rpt";
                stPrintTableName = "CUSTOMER_DISPATCH";
                this.stRecordReference =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtDispatchSummary"].
                            Rows[0]["DeliveryOrderNumber"].ToString();
                this.stStaion = generalResultInformation.Station;
                this.stNode = generalResultInformation.concernedNode;
            }
            else if (generalResultInformation.requestedReport == reportType.refundBook)
            {
                this.crptPOSDocumentToPrint.FileName = "crptRefundBook.rpt";
                stPrintTableName = "REFUNDS";
                this.stRecordReference =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtRefundSummary"].
                            Rows[0]["refundNumber"].ToString();
                this.stStaion = generalResultInformation.Station;
                this.stNode = generalResultInformation.concernedNode;
            }
            else if (generalResultInformation.requestedReport == reportType.CashReceiptVoucher)
            {
                this.crptPOSDocumentToPrint.FileName = "crptCashReceiptVoucher.rpt";
                stPrintTableName = "C_PAYMENT";
                this.stRecordReference =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentSummary"].
                            Rows[0]["Reference"].ToString();
                this.stStaion = generalResultInformation.Station;
                this.stNode = generalResultInformation.concernedNode;
                //this.cmdPrintDocument.Enabled = false;
            }
            else if (generalResultInformation.requestedReport == reportType.BankDepositSlip)
            {
                this.crptPOSDocumentToPrint.FileName = "crptCashDepositSlip.rpt";
                stPrintTableName = "C_CASH";
                this.stRecordReference =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtCashDeposit"].
                            Rows[0]["C_CASH_ID"].ToString();
                this.stStaion = generalResultInformation.Station;
                this.stNode = generalResultInformation.concernedNode;                
            }
            else if (generalResultInformation.requestedReport == reportType.OpenInvoice)
            {
                this.crptPOSDocumentToPrint.FileName = "crptOpenInvoice.rpt";
                stPrintTableName = "V_OPENINVOICE";
                this.stRecordReference =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtOpenInvoice"].
                            Rows[0]["ID"].ToString();
                this.stStaion = generalResultInformation.Station;
                this.stNode = generalResultInformation.concernedNode;
            }
            else
            {
                return;
            }
            this.crptPOSDocumentToPrint.SetDataSource(generalResultInformation.dtsDocumentPrintView);
            this.crpvPOSDocumentPrintPrivew.ReportSource = this.crptPOSDocumentToPrint;
            this.crpvPOSDocumentPrintPrivew.Zoom(75);
            this.WindowState = FormWindowState.Maximized;
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
                dbSettingInformationHandler.PrinterName;
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

            printDocument :
            try
            {
                //this.printText();
                this.crptPOSDocumentToPrint.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }

            if (MessageBox.Show("Did Document printed?", "Printing",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Record Print Job.

                DataTable dtPrintJob =
                    this.getDataFromDb.getPrintJobInfo(null, "", "", "", "", "", "", true, "");
                if (dtPrintJob.Columns.Count <= 0)
                {
                    MessageBox.Show("Print Job Not Recorded. Contac Your Administrator.", "Printing",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
                DataRow drNewPrintJob = dtPrintJob.NewRow();
                drNewPrintJob["TABLENAME"] = stPrintTableName;
                drNewPrintJob["RECORDREFERENCE"] = stRecordReference;
                drNewPrintJob["PRINTED"] = DateTime.Now;
                //drNewPrintJob["PRINTEDBY"] = "";
                //drNewPrintJob["ID"] = "";
                drNewPrintJob["STATION"] = stStaion;
                drNewPrintJob["NODE"] = stNode;
                dtPrintJob.Rows.Add(drNewPrintJob);
                this.getDataFromDb.changeDataBaseTableData(dtPrintJob, "PRINT_JOB", "INSERT", true);                    
            }
            else
            {
                //Request and execute re-printing.
                if (MessageBox.Show("Do you want RE-TRY printing this Document?", "Printing",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    goto printDocument;
                }
            }
            this.Enabled = true;
            this.Close();
        }

        private void printText()
        {
            ReportDocument myReport = new ReportDocument();
            myReport.Load("crptDeliveryOrder.rpt");

            string txtReportContent = null;
            using (MemoryStream ms = (MemoryStream)myReport.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                txtReportContent = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            File.WriteAllText("rptOutPut", txtReportContent);
            //RawPrinterHelper.SendStringToPrinter(dbSettingInformationHandler.PrinterName, txtReportContent);
        }


    
    }


    #region Crystal Report As Txt Printer

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
    #endregion


}
