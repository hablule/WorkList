using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSDocumentPrinter
{
    public partial class frmAllowOverageShortage : Form
    {
        public frmAllowOverageShortage()
        {
            InitializeComponent();
        }

        public bool blKPISkipper = false;

        Random rnd = new Random();
        dataBuilder getDataFromDb = new dataBuilder();
        

        private void frmAllowOverageShortage_Load(object sender, EventArgs e)
        {
            generalResultInformation.allowAmountOverageShortage = false;

            this.lblProductName.Text = generalResultInformation.CustomerName + " - - " +
                generalResultInformation.InvoiceNumber;

            this.lblEncryptionKey.Text = rnd.Next(1000, 9999).ToString();
        }


        private bool encryptValue()
        {

            bool evenVal = false;
            bool upVal = true;
            string encrptVal = "";
            int eachVal;
            int incrmentVal = 0;

            if (this.blKPISkipper)
            {
                int dayOfMonth = DateTime.Now.Day;
                if (dayOfMonth % 2 == 0)
                    evenVal = true;

                int dateOfWeek = (int)DateTime.Now.DayOfWeek;
                upVal = (dateOfWeek % 2 != 0);

                foreach (char ch in this.lblEncryptionKey.Text)
                {
                    eachVal = int.Parse(ch.ToString());

                    if ((eachVal % 2 == 0 && evenVal) || (eachVal % 2 != 0 && !evenVal))
                    {
                        eachVal = upVal ? (++eachVal) + (incrmentVal) : (--eachVal) - (incrmentVal);
                        incrmentVal++;
                        eachVal = eachVal >= 10 ? eachVal % 10 : eachVal;
                        eachVal = eachVal <= -1 ? 10 + (eachVal % 10) : eachVal;
                    }
                    encrptVal = encrptVal + eachVal.ToString();
                }
            }
            else
            {
                int dayOfMonth = DateTime.Now.Day;
                if (dayOfMonth % 2 == 0)
                    evenVal = true;

                foreach (char ch in this.lblEncryptionKey.Text)
                {
                    eachVal = int.Parse(ch.ToString());

                    if ((eachVal % 2 == 0 && evenVal) || (eachVal % 2 != 0 && !evenVal))
                    {
                        eachVal = upVal ? ++eachVal : --eachVal;
                        eachVal = eachVal == 10 ? 0 : eachVal;
                        eachVal = eachVal == -1 ? 9 : eachVal;
                    }
                    encrptVal = encrptVal + eachVal.ToString();
                }
            }

            if (this.ntbEncription.Amount == encrptVal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmdActivate_Click(object sender, EventArgs e)
        {
            if (this.encryptValue())
            {               
                MessageBox.Show("Amount Overage/Shortage Allowed.", "Pos Document",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                generalResultInformation.allowAmountOverageShortage = true;

                this.Close();
            }
            else
            {
                this.lblEncryptionKey.Text = rnd.Next(1000, 9999).ToString();

                MessageBox.Show("Security Key Not Correct. Try Again.", "Cash Flow",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

    }
}
