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
    public partial class frmValidateSecurityKey : Form
    {
        public frmValidateSecurityKey()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        dataBuilder getDataFromDb = new dataBuilder();


        private string generateRandomNumber()
        {
            return rnd.Next(10, 68).ToString() +
                rnd.Next(10, 68).ToString(); 
        }

        private string getEncryption(string testkey, bool considerDate, bool considerDay, 
            bool concernedDateValueUp, bool factored)
        {
            if (generalResultInformation.codeR.GetCodeValue() == -1)
            {
                return testkey;
            }

            ///
            //July 2017
            // New Code [0(1+3)],[1(2+4)],[2(1+2)],[3(3+4)]
            ///
            
            int[] keys = testkey.ToCharArray().Select(c => Convert.ToInt32(c.ToString())).ToArray();
            return
                (((keys[0] + keys[2]) + generalResultInformation.codeR.GetCodeValue()) % 10).ToString() +
                (((keys[1] + keys[3]) + generalResultInformation.codeR.GetCodeValue()) % 10).ToString() +
                (((keys[0] + keys[1]) + generalResultInformation.codeR.GetCodeValue()) % 10).ToString() +
                (((keys[2] + keys[3]) + generalResultInformation.codeR.GetCodeValue()) % 10).ToString(); 

            ///
            ///Muhammed's Encryption
            ///Split the number into two blocks and 
            ///Add the current Date to each block
            ///

            //return (int.Parse(testkey.Substring(0, 2)) + DateTime.Now.Day).ToString() +
            //        (int.Parse(testkey.Substring(2, 2)) + DateTime.Now.Day).ToString();

            ///
            ///Original Encription Algorithm
            ///
            /*
            bool evenVal = false;
            bool upVal = false;
            string encrptVal = "";
            int eachVal;
            int changedValueCounter = 0;

            if (considerDate)
            {
                int dayOfMonth = DateTime.Now.Day;
                if (dayOfMonth % 2 == 0)
                    evenVal = true;
            }

            if (considerDay)
            {
                DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
                if (dayOfWeek == DayOfWeek.Monday ||
                    dayOfWeek == DayOfWeek.Wednesday ||
                    dayOfWeek == DayOfWeek.Friday ||
                    dayOfWeek == DayOfWeek.Sunday)
                    upVal = true;
            }
            
            foreach (char ch in testkey)
            {
                eachVal = int.Parse(ch.ToString());

                if (considerDate && considerDay)
                {
                    if ((eachVal % 2 == 0 && evenVal) ||
                        (eachVal % 2 != 0 && !evenVal))
                    {
                        eachVal = upVal ? (++eachVal + changedValueCounter) : 
                            (--eachVal - changedValueCounter);
                        eachVal = eachVal == 10 ? 0 : eachVal;
                        eachVal = eachVal == -1 ? 9 : eachVal;
                        changedValueCounter = factored ? (changedValueCounter + 1) : changedValueCounter;
                    }
                }
                else if (considerDate)
                {
                    if ((eachVal % 2 == 0 && evenVal) ||
                        (eachVal % 2 != 0 && !evenVal))
                    {
                        eachVal = concernedDateValueUp ? (++eachVal + changedValueCounter) :
                            (--eachVal - changedValueCounter);
                        eachVal = eachVal == 10 ? 0 : eachVal;
                        eachVal = eachVal == -1 ? 9 : eachVal;
                        changedValueCounter = factored ? (changedValueCounter + 1) : changedValueCounter;
                    }
                }
                else
                {
                    eachVal = upVal ? (++eachVal + changedValueCounter) :
                            (--eachVal - changedValueCounter);
                    eachVal = eachVal == 10 ? 0 : eachVal;
                    eachVal = eachVal == -1 ? 9 : eachVal;
                    changedValueCounter = factored ? (changedValueCounter + 1) : changedValueCounter;
                }
                
                encrptVal = encrptVal + eachVal.ToString();
            }

            return encrptVal;
             */
        }

        private bool validateEncryption(string testKey, string resultKey, int encyptionLevel)
        {
            bool isValid = false;

            if (encyptionLevel == 0)
            {
                isValid =
                    (this.getEncryption(testKey, true, false, true, false) == resultKey);
 
            }
            else if (encyptionLevel == 1)
            {
                isValid =
                    (this.getEncryption(testKey, true, false, false, false) == resultKey);
            }
            else if (encyptionLevel == 2)
            {
                isValid =
                    (this.getEncryption(testKey, false, true, true, false) == resultKey);
            }
            else if (encyptionLevel == 3)
            {
                isValid =
                    (this.getEncryption(testKey, true, true, true, false) == resultKey);
            }
            else if (encyptionLevel == 4)
            {
                isValid =
                    (this.getEncryption(testKey, true, false, true, true ) == resultKey); 
            }
            else if (encyptionLevel == 5)
            {
                isValid =
                    (this.getEncryption(testKey, true, false, false, true) == resultKey); 
            }
            else if (encyptionLevel == 6)
            {
                isValid =
                    (this.getEncryption(testKey, false, true, true, true) == resultKey);
 
            }
            else if (encyptionLevel == 7)
            {
                isValid =
                    (this.getEncryption(testKey, true, true, true, true) == resultKey); 
            }            
            
            return isValid;
        }

        private void frmActivateProduct_Load(object sender, EventArgs e)
        {
            //this.lblProductName.Text = generalResultInformation.Productname;
            generalResultInformation.securityKeyValidityPassed = false;

            if (generalResultInformation.codeR.GetCodeValue() == -1)
            {
                this.lblProductName.Text = "Please Input the Key Indicated Below";
            }

            this.lblEncryptionKey.Text = this.generateRandomNumber();
        }

        private void cmdActivate_Click(object sender, EventArgs e)
        {            

            bool validPassKey =
                this.validateEncryption(this.lblEncryptionKey.Text, this.ntbEncription.Amount, 7);

            if (validPassKey)
            {
                generalResultInformation.securityKeyValidityPassed = true;

                MessageBox.Show("Correct Security Key.", "Materials Management",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                this.lblEncryptionKey.Text = this.generateRandomNumber();

                MessageBox.Show("Security Key Not Correct. Try Again.", "Materials Management",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


    }
}
