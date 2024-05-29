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
    public partial class frmDocPrintPreview : Form
    {
        public frmDocPrintPreview()
        {
            InitializeComponent();
        }


        public bool blPrintDocument = false;
        
        public dtsDocumentData dtsDocumentPrintView = new dtsDocumentData();


        dataBuilder getDataFromDb = new dataBuilder();
            

        private void frmDocPrintPreview_Load(object sender, EventArgs e)
        {            
            if (!System.IO.File.Exists("crptCostSheet.rpt"))
            {
                this.Close();
            }

            this.crptDocumentToPrint.FileName = "crptCostSheet.rpt";
                        
            this.crptDocumentToPrint.SetDataSource(this.dtsDocumentPrintView);
            this.crpvPOSDocumentPrintPrivew.ReportSource = this.crptDocumentToPrint;
            this.crpvPOSDocumentPrintPrivew.Zoom(2);

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
                this.crptDocumentToPrint.PrintOptions.PrinterName =
                    dbSettingInformationHandler.posPrinterNameList;
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }
            if (this.crptDocumentToPrint.PrintOptions.PrinterName == "")
            {
                MessageBox.Show("No printer Found. \n Contact Your Administrator", "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }
                        
            try
            {
                this.crptDocumentToPrint.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception exeception)
            {
                MessageBox.Show("Print Error. \n " + exeception.Message, "Printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }
                        
            this.Enabled = true;
            this.Close();
        }
    

    }
}
