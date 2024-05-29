using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyMove
{
    public partial class frmManualDocInfo : Form
    {
        public frmManualDocInfo()
        {
            InitializeComponent();
        }

        public string stDocumentNumber = "";
        public DateTime dtDocumentDate = DateTime.Now;


        private void frmManualDocInfo_Load(object sender, EventArgs e)
        {            
            generalResultInformation.manualDocumentNumber = "";
            generalResultInformation.manualDocumentDate = DateTime.Now;
            generalResultInformation.documentInfoChanged = false;
        }

        private void cmdChange_Click(object sender, EventArgs e)
        {
            if (this.txtManualDocumentNumber.Text == "")
            {
                MessageBox.Show("Input valid Document Number to Proceed", 
                    "Material Movement", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            if (this.txtManualDocumentNumber.Text.Contains("<<") ||
                this.txtManualDocumentNumber.Text.Contains(">>"))
            {
                MessageBox.Show("Input valid Document Number to Proceed",
                    "Material Movement", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Now.Date.CompareTo(this.dtpManualDocumentDate.Value.Date) < 0)
            {
                MessageBox.Show("Input valid Document Date to Proceed",
                    "Material Movement", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            generalResultInformation.manualDocumentNumber = 
                this.txtManualDocumentNumber.Text;
            generalResultInformation.manualDocumentDate = 
                this.dtpManualDocumentDate.Value;
            generalResultInformation.documentInfoChanged =
                true;

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
