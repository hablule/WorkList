using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbConnection;

namespace SecurityGuardScheduling
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        bool blSchedulGenerating = false;

        string styleName = "";

        DataTable dtSchedulInfo = new DataTable();

        GenerateSchedule gnrtSchul = new GenerateSchedule();

        BackgroundWorker bkgWrkr = new BackgroundWorker();


        dataBuilder getDataFromDB = new dataBuilder();

        checkAndEstablishDbConnectionSettings dbCk =
                new checkAndEstablishDbConnectionSettings();

        dtsSchedule dtsScheduleInfo = new dtsSchedule();


        private void changeUserInterface()
        {
            if (this.styleName == "Aero (Black).vssf")
            {
                this.styleName = "Aero (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Aero (Blue).vssf");
            }
            else if (this.styleName == "Aero (Blue).vssf")
            {
                this.styleName = "Aero (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Aero (Silver).vssf");
            }
            else if (this.styleName == "Aero (Silver).vssf")
            {
                this.styleName = "Office2007 (Black).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Office2007 (Black).vssf");
            }
            else if (this.styleName == "Office2007 (Black).vssf")
            {
                this.styleName = "Office2007 (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Office2007 (Blue).vssf");
            }
            else if (this.styleName == "Office2007 (Blue).vssf")
            {
                this.styleName = "Office2007 (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Office2007 (Silver).vssf");
            }
            else if (this.styleName == "Office2007 (Silver).vssf")
            {
                this.styleName = "OSX (Aqua).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Aqua).vssf");
            }
            else if (this.styleName == "OSX (Aqua).vssf")
            {
                this.styleName = "OSX (Brushed).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Brushed).vssf");
            }
            else if (this.styleName == "OSX (Brushed).vssf")
            {
                this.styleName = "OSX (iTunes).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (iTunes).vssf");
            }
            else if (this.styleName == "OSX (iTunes).vssf")
            {
                this.styleName = "OSX (Leopard).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Leopard).vssf");
            }
            else if (this.styleName == "OSX (Leopard).vssf")
            {
                this.styleName = "OSX (Panther).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Panther).vssf");
            }
            else if (this.styleName == "OSX (Panther).vssf")
            {
                this.styleName = "OSX (Tiger).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Tiger).vssf");
            }
            else if (this.styleName == "OSX (Tiger).vssf")
            {
                this.styleName = "Vista (Aero).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Aero).vssf");
            }
            else if (this.styleName == "Vista (Aero).vssf")
            {
                this.styleName = "Vista (Basic).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Basic).vssf");
            }
            else if (this.styleName == "Vista (Basic).vssf")
            {
                this.styleName = "Vista (Black).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Black).vssf");
            }
            else if (this.styleName == "Vista (Black).vssf")
            {
                this.styleName = "Vista (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Blue).vssf");
            }
            else if (this.styleName == "Vista (Blue).vssf")
            {
                this.styleName = "Vista (Green).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Green).vssf");
            }
            else if (this.styleName == "Vista (Green).vssf")
            {
                this.styleName = "Vista (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Silver).vssf");
            }
            else if (this.styleName == "Vista (Silver).vssf")
            {
                this.styleName = "Vista (Teal).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Teal).vssf");
            }
            else if (this.styleName == "Vista (Teal).vssf")
            {
                this.styleName = "XP (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Blue).vssf");
            }
            else if (this.styleName == "XP (Blue).vssf")
            {
                this.styleName = "XP (Olive).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Olive).vssf");
            }
            else if (this.styleName == "XP (Olive).vssf")
            {
                this.styleName = "XP (Royale).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Royale).vssf");
            }
            else if (this.styleName == "XP (Royale).vssf")
            {
                this.styleName = "XP (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Silver).vssf");
            }
            else
            {
                this.styleName = "Aero (Black).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Aero (Black).vssf");
            }
        }


        private void frmMainMenu_Load(object sender, EventArgs e)
        {            
            if(!dbCk.establishDbConnectionSettins(this))
                return;
            
            this.showPercentageOfProgress();
            
            this.cmdShow.Enabled = false;
            this.cmdSaveReportToFile.Enabled = false;

            this.bkgWrkr.WorkerReportsProgress = true;

            

            this.bkgWrkr.DoWork +=
                new DoWorkEventHandler(this.bkgWrker_DoWork);// gnrtSchul.beginGenerateSchedule);
            this.bkgWrkr.ProgressChanged +=
                new ProgressChangedEventHandler(this.bkgWrker_ProgressChanged);
            this.bkgWrkr.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(this.bkgWrker_RunWorkerCompleted);
        }

        private void cmdGaruds_Click(object sender, EventArgs e)
        {
            if (this.blSchedulGenerating)
            {
                MessageBox.Show("There is on going Schedule Genearation. " +
                    "Please Wait until it Finish.", "Process In Progress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmGaurd frmGrds = new frmGaurd();
            frmGrds.ShowDialog();
        }

        private void cmdPosts_Click(object sender, EventArgs e)
        {
            if (this.blSchedulGenerating)
            {
                MessageBox.Show("There is on going Schedule Genearation. " +
                    "Please Wait until it Finish.", "Process In Progress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmPost frmPst = new frmPost();
            frmPst.ShowDialog();
        }

        private void cmdShifts_Click(object sender, EventArgs e)
        {
            if (this.blSchedulGenerating)
            {
                MessageBox.Show("There is on going Schedule Genearation. " +
                    "Please Wait until it Finish.", "Process In Progress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShift frmShft = new frmShift();
            frmShft.ShowDialog();
        }

        private void cmdExclusions_Click(object sender, EventArgs e)
        {
            if (this.blSchedulGenerating)
            {
                MessageBox.Show("There is on going Schedule Genearation. " +
                    "Please Wait until it Finish.", "Process In Progress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmExclusion frmExclsn = new frmExclusion();
            frmExclsn.ShowDialog();
        }

        private void frmMainMenu_DoubleClick(object sender, EventArgs e)
        {
            if (this.blSchedulGenerating)
            {
                MessageBox.Show("There is on going Schedule Genearation. " +
                    "Please Wait until it Finish.", "Process In Progress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.changeUserInterface();
        }



        private void tmrGarbageCollector_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }


        private void cmdGenerateGaurdSchedule_Click(object sender, EventArgs e)
        {
            if (this.blSchedulGenerating)
            {
                MessageBox.Show("There is on going Schedule Genearation. " +
                    "Please Wait until it Finish.", "Process In Progress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dtpSchedulEnd.Value.CompareTo(this.dtpSchedulStart.Value) != 1)
            {
                MessageBox.Show("Please Correctly Specify Date for Schedule", 
                    "Generate Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if ((this.dtpSchedulEnd.Value - this.dtpSchedulStart.Value).TotalDays < 1)
            {
                MessageBox.Show("Too Small Date Range Selected",
                    "Generate Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.ckRegenerate.Checked)
            {
                if (MessageBox.Show("Your are about DELETE existing Schedule Permanently. \n " +
                                    " Are You Sure You Want TO PROCEED.", "", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    this.ckRegenerate.Checked = false;
                    return;
                }
            }

            this.gnrtSchul.erraseExisting = this.ckRegenerate.Checked;
            
            generalResultInformation.startDate = this.dtpSchedulStart.Value;
            generalResultInformation.EndDate = this.dtpSchedulEnd.Value;

            this.blSchedulGenerating = true;
            
            this.showPercentageOfProgress();
                        
            this.cmdShow.Enabled = false;
            this.cmdSaveReportToFile.Enabled = false;
            
            this.bkgWrkr.RunWorkerAsync();
        }

        private void bkgWrker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.gnrtSchul.beginGenerateSchedule(this.bkgWrkr);
        }

        private void bkgWrker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prgbScheduleGeranated.Increment(e.ProgressPercentage);

            this.showPercentageOfProgress();

            //this.lblProgress.Text = this.prgbScheduleGeranated.Value.ToString() + "%";
            //for (int prctComplete = e.ProgressPercentage; prctComplete >= 0; prctComplete--)
            //{
            //    this.prgbScheduleGeranated.PerformStep();
            //}
        }

        private void bkgWrker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.getDataFromDB.checkIfTableContainesData(generalResultInformation.searchResult))
            {
                this.cmdShow.Enabled = true;
                this.cmdSaveReportToFile.Enabled = true;
                this.dtSchedulInfo = generalResultInformation.searchResult.Copy();

                //frmSchedulView frm = new frmSchedulView();
                //frm.dtSchedul = this.dtSchedulInfo;
                //frm.ShowDialog();
                this.cmdShow_Click(sender, e);
            }
            else
            {
                this.cmdShow.Enabled = false;
                this.cmdSaveReportToFile.Enabled = false;
            }
            this.blSchedulGenerating = false;
            this.prgbScheduleGeranated.Value = 0;

            this.showPercentageOfProgress();            
        }


        private void cmdShow_Click(object sender, EventArgs e)
        {
            this.cmdShow.Enabled = false;
            if (this.fillScheduleReport())
            {
                this.showScheduleRptPrintPreview();
            }
            else
            {
                MessageBox.Show("No Data Found", "Print", MessageBoxButtons.OK);
            }
            this.cmdShow.Enabled = true;
        }

        private bool fillScheduleReport()
        {
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtSchedulInfo))
                return false;

            dtsScheduleInfo.Tables["dtScheduleInfo"].Rows.Clear();

            DataRow drScheduleInfo;

            string stColumnName = "";

            for (int rowCounter = 0; rowCounter <= this.dtSchedulInfo.Rows.Count - 1; rowCounter++)
            {
                drScheduleInfo =
                    dtsScheduleInfo.Tables["dtScheduleInfo"].NewRow();

                for (int columnCounter = 0;
                    columnCounter <=
                        dtsScheduleInfo.Tables["dtScheduleInfo"].Columns.Count - 1;
                        columnCounter++)
                {
                    stColumnName =
                        dtsScheduleInfo.Tables["dtScheduleInfo"].Columns[columnCounter].ColumnName;

                    drScheduleInfo[stColumnName] =
                        this.dtSchedulInfo.Rows[rowCounter][stColumnName];
                }

                dtsScheduleInfo.Tables["dtScheduleInfo"].Rows.Add(drScheduleInfo);
            }
            return true;

        }

        private void showScheduleRptPrintPreview()
        {

            if (!System.IO.File.Exists("rptSchedule.rpt"))
            {
                MessageBox.Show("Unable To find Crystal Report. \n Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            frmPrintPreview frmPrintView = new frmPrintPreview();
            frmPrintView.scheduleInformation = (dtsSchedule)this.dtsScheduleInfo.Copy();
            
            frmPrintView.ShowDialog();

        }

        private void cmdSaveReportToFile_Click(object sender, EventArgs e)
        {
            this.cmdSaveReportToFile.Enabled = false;
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtSchedulInfo))
                return;

            SaveFileDialog xlsToSave = new SaveFileDialog();
            xlsToSave.Filter = "Excel Workbook|*.xls";

            xlsToSave.ShowDialog();

            if (xlsToSave.FileName == "")
                return;            

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet sheet;
            Microsoft.Office.Interop.Excel.Range range;

            object misValue = System.Reflection.Missing.Value;
            
            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // Configure Excel not to show while we're working with it
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // create a new Workbook
                workBook =
                    excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                // get the first active sheet from the workbook
                sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
                sheet.Name = "Schedule";

                DataTable shedule = this.dtSchedulInfo.Copy();

                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("GS_DUTY_ID"));                
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("ISONDUTY"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("GS_POST_ID"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("GS_SHIFT_ID"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("GS_GAURD_ID"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("CREATED"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("CREATEDBY"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("UPDATED"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("UPDATEDBY"));
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("ISACTIVE"));                                
                shedule.Columns.RemoveAt(shedule.Columns.IndexOf("GS_EXCLUSION_ID"));                
                                                                  

                //Create The Report Header
                for (int i = 0; i < shedule.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1] = shedule.Columns[i].ColumnName;
                }

                // loop through each row and add Content
                int count = 1;
                foreach (DataRow row in shedule.Rows)
                {
                    count += 1;
                    for (int i = 1; i <= shedule.Columns.Count; i++)
                    {
                        sheet.Cells[count, i] = row[i - 1].ToString();                        
                    }
                }

                // now we resize the columns
                range = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[count, shedule.Columns.Count]);
                range.EntireColumn.AutoFit();

                //now save the workbook and exit Excel
                workBook.SaveAs(xlsToSave.FileName, 
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                    misValue, misValue, misValue, misValue, 
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    misValue, misValue, misValue, misValue, misValue);
                workBook.Close(true, misValue, misValue);;
                excel.Quit();
                MessageBox.Show("Export Complete", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            finally
            {
                sheet = null;
                range = null;
                workBook = null;            
            }
            this.cmdSaveReportToFile.Enabled = true;
        }

        private void showPercentageOfProgress()
        {
            int percent =
                (int)(((double)this.prgbScheduleGeranated.Value /
                (double)this.prgbScheduleGeranated.Maximum) * 100);
            this.prgbScheduleGeranated.CreateGraphics().DrawString
                (percent.ToString() + "%", new Font("Arial",
                    (float)8.25, FontStyle.Regular),
                    Brushes.Black, new PointF(this.prgbScheduleGeranated.Width / 2 - 10,
                        this.prgbScheduleGeranated.Height / 2 - 7));           
            
        }

        
    }
}
