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


namespace SecurityGuardScheduling
{
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview()
        {
            InitializeComponent();
        }

        
        
        

        public dtsSchedule scheduleInformation = new dtsSchedule();

        private void showReport()
        {

            this.rptSchedule1.Refresh();

            this.rptSchedule1.SetDataSource(this.scheduleInformation);

            this.rptSchedule1.PrintOptions.PaperSize =
                CrystalDecisions.Shared.PaperSize.PaperA4;

            this.rptSchedule1.Refresh();

            this.crpvSchedule.ReportSource = this.rptSchedule1;
            this.crpvSchedule.Zoom(2);
        }


        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            this.showReport();
        }


        private void frmPrintPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rptSchedule1.Close();
        }

                

        
       
        

        
        

        

    }
}
