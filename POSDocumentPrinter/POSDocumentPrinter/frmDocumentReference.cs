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
    public partial class frmDocumentReference : Form
    {
        public frmDocumentReference()
        {
            InitializeComponent();
        }

        bool userRecordButtonClicked = false;

        

        private bool formIsClosing()
        {
            if (this.ctlReferenceNumber.Amount == "0" ||
                this.ctlReferenceNumber.Amount == "")
            {
                MessageBox.Show("Please Enter Valid Reference Number.", 
                    "Document Reference", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (generalResultInformation.requestedDocumenType == reportType.refundBook)
            {
                if (this.ctlSalesReferenceNumber.Amount == "0" ||
                    this.ctlSalesReferenceNumber.Amount == "")
                {
                    MessageBox.Show("Please Enter Valid Sales Reference Number.",
                        "Document Reference", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (this.txtDocumentNote.Text != "")
                {
                    string note = this.txtDocumentNote.Text.Replace(" ", "");
                    char[] reasons = note.ToCharArray();                        
                    if (reasons.Count() > 3)
                        goto validReference;
                }

                MessageBox.Show("Please Enter Reason for Refund.",
                    "Document Reference", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;                    
            }

            validReference :
            generalResultInformation.stDocumentReferenceNumber =
                this.ctlReferenceNumber.Amount;
            generalResultInformation.stRefundSalesReferenceNumber =
                this.ctlSalesReferenceNumber.Amount;
            generalResultInformation.stDocumentNote =
                this.txtDocumentNote.Text;
            return true;
        }

        private void frmDocumentReference_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.requestedDocumenType == reportType.UNKOWN)
                return;

            generalResultInformation.documentRequestInfoCancelled = false;

            if (generalResultInformation.requestedDocumenType == reportType.attachment)
            {
                this.Text = "Attachement Information";
                this.lblReferenceNumber.Text = "FS. No.";
                this.lblDocumentNote.Text = "Sales Comment";

                this.lblSalesReference.Visible = false;
                this.ctlSalesReferenceNumber.Visible = false;

                this.cmdRecordDocumentReferecne.Location =
                    new Point(16, 135);

                this.txtDocumentNote.Location =
                    new Point(111, 34);
                this.lblDocumentNote.Location =
                    new Point(10, 48);
                this.Size = new Size(360, 210);
            }
            else if (generalResultInformation.requestedDocumenType == reportType.refundBook)
            {
                this.Text = "Refund Book Information";
                this.lblReferenceNumber.Text = "RF. No.";
                this.lblDocumentNote.Text = "Reason For Refund Or Other Memo.";
                this.lblSalesReference.Visible = true;
                this.ctlSalesReferenceNumber.Visible = true;
            }

            this.ctlReferenceNumber.Amount = 
                generalResultInformation.stDocumentReferenceNumber;
            this.txtDocumentNote.Text = 
                generalResultInformation.stDocumentNote;
        }

        private void frmDocumentReference_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.userRecordButtonClicked)//string.Equals((sender as Button).Name, @"CloseButton"))
            {
                generalResultInformation.documentRequestInfoCancelled = true;
                //this.Close(); 
            }

            //if (!this.formIsClosing())
            //{
            //    e.Cancel = true;                
            //}            
        }

        private void cmdRecordDocumentReferecne_Click(object sender, EventArgs e)
        {
            if (!this.formIsClosing())
            {
                return;
            }
            this.userRecordButtonClicked = true;
            this.Close();
        }


    }
}
