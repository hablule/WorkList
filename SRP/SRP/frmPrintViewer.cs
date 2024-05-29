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
    public partial class frmPrintViewer : Form
    {
        public frmPrintViewer()
        {
            InitializeComponent();
        }

        public void setUpThePreviewArea(string fileName, DataSet dataSource)
        {
            this.crptReportContent.Refresh();
            this.crptReportContent.FileName = fileName;
            this.crptReportContent.SetDataSource(dataSource);

            this.crvPrintPreview.ReportSource = this.crptReportContent;
            this.crvPrintPreview.Zoom(2);
            this.crvPrintPreview.Show();            
        }
    }
}
