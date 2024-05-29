using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbConnection;
using System.Drawing.Printing;
using System.Collections.Specialized;
using System.Management;
using System.Printing;
using System.Runtime.InteropServices;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace stockActivityReporter
{
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview()
        {
            InitializeComponent();
        }


        public bool isDetailReport = true;
        public bool isCountReport = false;
        
        public dtsTransactionInfo trxInformation = new dtsTransactionInfo();
        public string stPrinterName = "";
        public string stPaperName = "";

        

        private bool setReportSourceAndPageType()
        {
            if (this.isDetailReport)
            {                 
                this.crpvDetailStockActivity.ShowExportButton = false;
                this.rptDetailStockActivity.Refresh();

                try
                {
                    this.rptDetailStockActivity.PrintOptions.PrinterName =
                    this.stPrinterName;
                }
                catch (Exception exeception)
                {
                    MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                this.rptDetailStockActivity.SetDataSource(this.trxInformation);

                PrintDocument printer = new System.Drawing.Printing.PrintDocument();
                printer.PrinterSettings.PrinterName = this.stPrinterName;

                foreach (System.Drawing.Printing.PaperSize paperSize in printer.PrinterSettings.PaperSizes)
                {
                    if (paperSize.PaperName == this.stPaperName)
                    {
                        try
                        {
                            this.rptDetailStockActivity.PrintOptions.PaperSize =
                                (CrystalDecisions.Shared.PaperSize)paperSize.RawKind;
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("Exception: " + Ex);
                            return false;
                        }
                        break;
                    }
                }


                this.rptDetailStockActivity.Refresh();

                this.crpvDetailStockActivity.ReportSource = this.rptDetailStockActivity;
                this.crpvDetailStockActivity.Zoom(100);            
            
            }
            else
            {
                if(this.isCountReport)
                {
                    this.cmdPrint.Visible = true;
                    this.rptCountSheet.Refresh();
                    
                    try
                    {
                        this.rptCountSheet.PrintOptions.PrinterName =
                        this.stPrinterName;
                    }
                    catch (Exception exeception)
                    {
                        MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    this.rptCountSheet.SetDataSource(this.trxInformation);

                    this.rptCountSheet.PrintOptions.PaperSize =
                        CrystalDecisions.Shared.PaperSize.PaperLetter;

                    this.rptCountSheet.Refresh();
                    this.crpvDetailStockActivity.ReportSource = this.rptCountSheet;
                }
                else
                {
                    this.cmdPrint.Visible = false;
                    this.rptSummarizedStockActivity.Refresh();

                    try
                    {
                        this.rptSummarizedStockActivity.PrintOptions.PrinterName =
                        this.stPrinterName;
                    }
                    catch (Exception exeception)
                    {
                        MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    this.rptSummarizedStockActivity.SetDataSource(this.trxInformation);

                    this.rptSummarizedStockActivity.PrintOptions.PaperSize =
                        CrystalDecisions.Shared.PaperSize.PaperA4;

                    this.rptSummarizedStockActivity.Refresh();
                    this.crpvDetailStockActivity.ReportSource = this.rptSummarizedStockActivity;
                }
                this.crpvDetailStockActivity.Zoom(100);
            }
            this.WindowState = FormWindowState.Maximized;
            return true;
        }

        public void printRpt(object sender, EventArgs e)
        {
            if(this.setReportSourceAndPageType())
                this.cmdPrint_Click(sender, e);
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {            
            this.setReportSourceAndPageType();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.isDetailReport)
            {
                try
                {
                    //this.printText();
                    this.rptDetailStockActivity.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception exeception)
                {
                    MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
                this.rptDetailStockActivity.Close();
            }
            else
            {
                if (this.isCountReport)
                {
                    try
                    {
                        //this.printText();
                        this.rptCountSheet.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception exeception)
                    {
                        MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }
                    this.rptCountSheet.Close();
                }
                else
                {
                    try
                    {
                        //this.printText();
                        this.rptSummarizedStockActivity.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception exeception)
                    {
                        MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }
                    this.rptSummarizedStockActivity.Close();
                }                
            }                        
        }


        private void printText()
        {
            ReportDocument myReport = this.rptDetailStockActivity;
            if (this.isDetailReport)
            {
                myReport = this.rptDetailStockActivity;
            }
            else
            {
                if (this.isCountReport)
                {
                    myReport = this.rptCountSheet;
                }
                else
                {
                    myReport = this.rptSummarizedStockActivity; 
                } 
            }

            string txtReportContent = null;
            using (MemoryStream ms = (MemoryStream)myReport.ExportToStream(ExportFormatType.WordForWindows))
            {
                txtReportContent = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }

            RawPrinterHelper.SendStringToPrinter(this.stPrinterName, txtReportContent);
        }


        private static StringCollection GetPrintersCollection()
        {
            StringCollection printerNameCollection = new StringCollection();
            string searchQuery = "SELECT * FROM Win32_Printer";
            ManagementObjectSearcher searchPrinters =
                  new ManagementObjectSearcher(searchQuery);
            ManagementObjectCollection printerCollection = searchPrinters.Get();
            foreach (ManagementObject printer in printerCollection)
            {
                printerNameCollection.Add(printer.Properties["Name"].Value.ToString());
            }
            return printerNameCollection;
        }

        private static StringCollection GetPrintJobsCollection(string printerName)
        {
            StringCollection printJobCollection = new StringCollection();
            string searchQuery = "SELECT * FROM Win32_PrintJob";

            /*searchQuery can also be mentioned with where Attribute,
                but this is not working in Windows 2000 / ME / 98 machines 
                and throws Invalid query error*/
            ManagementObjectSearcher searchPrintJobs =
                      new ManagementObjectSearcher(searchQuery);
            ManagementObjectCollection prntJobCollection = searchPrintJobs.Get();

            List<PrintSystemJobInfo> prntJbs = new List<PrintSystemJobInfo>();
            
            foreach (ManagementObject prntJob in prntJobCollection)
            {
                System.String jobName = prntJob.Properties["Name"].Value.ToString();
                
                //Job name would be of the format [Printer name], [Job ID]
                char[] splitArr = new char[1];
                splitArr[0] = Convert.ToChar(",");
                string prnterName = jobName.Split(splitArr)[0];
                string documentName = prntJob.Properties["Document"].Value.ToString();
                if (String.Compare(prnterName, printerName, true) == 0)
                {
                    printJobCollection.Add(documentName);
                }
            }
            return printJobCollection;
        }

        private static bool PausePrintJob(string printerName, int printJobID)
        {
            bool isActionPerformed = false;
            string searchQuery = "SELECT * FROM Win32_PrintJob";
            ManagementObjectSearcher searchPrintJobs =
                     new ManagementObjectSearcher(searchQuery);
            ManagementObjectCollection prntJobCollection = searchPrintJobs.Get();
            foreach (ManagementObject prntJob in prntJobCollection)
            {
                System.String jobName = prntJob.Properties["Name"].Value.ToString();
                //Job name would be of the format [Printer name], [Job ID]
                char[] splitArr = new char[1];
                splitArr[0] = Convert.ToChar(",");
                string prnterName = jobName.Split(splitArr)[0];
                int prntJobID = Convert.ToInt32(jobName.Split(splitArr)[1]);
                string documentName = prntJob.Properties["Document"].Value.ToString();
                if (String.Compare(prnterName, printerName, true) == 0)
                {
                    if (prntJobID == printJobID)
                    {
                        prntJob.InvokeMethod("Pause", null);
                        isActionPerformed = true;
                        break;
                    }
                }
            }
            return isActionPerformed;
        }

        private static bool CancelPrintJob(string printerName, int printJobID)
        {
            bool isActionPerformed = false;
            string searchQuery = "SELECT * FROM Win32_PrintJob";
            ManagementObjectSearcher searchPrintJobs =
                   new ManagementObjectSearcher(searchQuery);
            ManagementObjectCollection prntJobCollection = searchPrintJobs.Get();
            foreach (ManagementObject prntJob in prntJobCollection)
            {
                System.String jobName = prntJob.Properties["Name"].Value.ToString();
                //Job name would be of the format [Printer name], [Job ID]
                char[] splitArr = new char[1];
                splitArr[0] = Convert.ToChar(",");
                string prnterName = jobName.Split(splitArr)[0];
                int prntJobID = Convert.ToInt32(jobName.Split(splitArr)[1]);
                string documentName = prntJob.Properties["Document"].Value.ToString();
                if (String.Compare(prnterName, printerName, true) == 0)
                {
                    if (prntJobID == printJobID)
                    {
                        //performs a action similar to the cancel 
                        //operation of windows print console
                        prntJob.Delete();
                        isActionPerformed = true;
                        break;
                    }
                }
            }
            return isActionPerformed;
        }

        private void frmPrintPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isDetailReport)
            {
                this.rptDetailStockActivity.Close();
            }
            else
            {
                this.rptSummarizedStockActivity.Close();
            }
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
