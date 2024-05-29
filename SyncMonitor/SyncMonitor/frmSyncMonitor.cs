using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SyncMonitor
{
    public partial class frmSyncMonitor : Form
    {
        public frmSyncMonitor()
        {
            InitializeComponent();
        }

        private void frmSyncMonitor_Load(object sender, EventArgs e)
        {
            string emSyncLogPath = @"\\glhqserver\d$\Data_Synch\EM-Sync\Logs";
            string emTableList = "tableList_EM.txt";
            string posSyncLogPath = @"\\glhqserver\d$\Data_Synch\POS-Sync\LOGS";
            string posTableList = "tableList_POS.txt";
            

            GenerateBaseFiles gnrtBase = new GenerateBaseFiles(posSyncLogPath);

            DataTable syncInfo = new DataTable();
            syncInfo.Columns.Add("File");
            syncInfo.Columns.Add("ReadID");
            syncInfo.Columns.Add("ReadTime");
            syncInfo.Columns.Add("srcDB");
            syncInfo.Columns.Add("trgtDB");

            foreach (syncFileInfo syncFile in gnrtBase.getSyncFileList())
            {
                syncInfo.Rows.Add(new object[] { syncFile.getSyncFilePath(), 
                                                 syncFile.getSyncFileReadID(),
                                                 syncFile.getSyncFileReadDate(),
                                                 syncFile.getSyncFileSrc(),
                                                 syncFile.getSyncFileTrgt()});
 
            }

            this.dataGridView1.DataSource = syncInfo;


            GenerateBaseFiles gnrtPOSBase = new GenerateBaseFiles(posSyncLogPath);

            foreach (syncFileInfo syncFile in gnrtPOSBase.getSyncFileList())
            {
                this.textBox1.Text = this.textBox1.Text + syncFile.getSyncFilePath() + "\t\t" +
                    new writeSyncLog().writeDB(syncFile, posTableList, "POS").ToString();
            }

            GenerateBaseFiles gnrtEMBase = new GenerateBaseFiles(emSyncLogPath);

            foreach (syncFileInfo syncFile in gnrtEMBase.getSyncFileList())
            {
                this.textBox1.Text = this.textBox1.Text +
                    new writeSyncLog().writeDB(syncFile, emTableList, "EasyMove").ToString();
            }


            //this.textBox1.Text = new parseSyncFile().generateSyncFileDBequivelant(gnrtBase.getSyncFileList()[0]).ToString();
            //this.textBox1.Text = new writeSyncLog().writeDB(gnrtBase.getSyncFileList()[0]).ToString();
            
        }


    }
}
