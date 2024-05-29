using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dbConnection
{
    public partial class ctlNumberTextBox : UserControl
    {
        private bool checkedNumber = true;
        private int pointPrecision = 2;

        //private bool decimalSepartorExist = false;

        public ctlNumberTextBox()
        {
            InitializeComponent();
        }

        public string Amount
        {
            get
            {
                return txtNumberTextBox.Text;
            }
            set
            {
                checkedNumber = false;
                txtNumberTextBox.Text = value;
            }
        }

        public int StandardPrecision
        {
            get
            {
                return pointPrecision;
            }
            set
            {
                pointPrecision = value;
            }
        }

        private void txtNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkedNumber)
            {
                return;
            }
            string userInput = txtNumberTextBox.Text;
            int stIndex = 0;
            if (userInput.Contains(","))
            {
                userInput = userInput.Replace(",", "");
                checkedNumber = true;
            }
            foreach (char m in userInput)
            {
                if (m != '0' && m != '1' && m != '2'
                    && m != '3' && m != '4' && m != '5' &&
                    m != '6' && m != '7' && m != '8' && m != '9'
                    && m != '.')
                {
                    userInput = userInput.Replace(m.ToString(), "");
                    checkedNumber = true;
                }
                if (m == '.')
                {
                    if (this.pointPrecision == 0)
                    {
                        userInput = userInput.Replace(m.ToString(), "");
                        continue;
                    }
                    if (stIndex == 0)
                    {
                        userInput = "0" + userInput;
                        checkedNumber = true;
                    }
                    if (userInput.IndexOf(m, 0) != userInput.LastIndexOf(m, 0))
                    {
                        int firstDecimalOccurence = userInput.IndexOf(".");
                        userInput = userInput.Replace(".", "");
                        userInput = userInput.Insert(firstDecimalOccurence, ".");
                        checkedNumber = true;
                    }
                }
                stIndex++;
            }

            if (userInput.StartsWith("0") && userInput.Length > 1)
            {
                if (userInput.Substring(1, 1) != ".")
                {
                    userInput = userInput.Remove(0, 1);
                    checkedNumber = true;
                }
            }

            if (userInput == "" || userInput.Length < 4)
            {
                checkedNumber = true;
                txtNumberTextBox.Text = userInput;
                txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);
                return;
            }

            string numbersBeforeDecimalPoint = "";
            if (userInput.Contains("."))
            {
                numbersBeforeDecimalPoint = userInput.Remove(userInput.IndexOf('.'));
                if ((userInput.Length - (numbersBeforeDecimalPoint.Length + 1)) > this.pointPrecision)
                {
                    userInput = userInput.Remove((userInput.IndexOf('.') + this.pointPrecision + 1), 1);
                }
            }
            else
                numbersBeforeDecimalPoint = userInput;
            if (numbersBeforeDecimalPoint.Length < 4)
            {
                checkedNumber = true;
                txtNumberTextBox.Text = userInput;
                txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);
                return;
            }

            int numberOfThousandSepartors = numbersBeforeDecimalPoint.Length / 3;
            int startingIndex = numbersBeforeDecimalPoint.Length % 3;

            if (startingIndex < 0)
                startingIndex = 2;
            if (startingIndex == 0)
            {
                startingIndex = 3;
                numberOfThousandSepartors--;
            }

            while (numberOfThousandSepartors > 0)
            {
                userInput = userInput.Insert(startingIndex, ",");
                startingIndex++;
                startingIndex += 3;
                numberOfThousandSepartors--;
            }

            checkedNumber = true;
            txtNumberTextBox.Text = userInput;
            txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);
        }

        private void txtNumberTextBox_LostFocus(object sender, EventArgs e)
        {
            checkedNumber = false;
            

            //Clear Insignificant digits from number.

            string userInput = txtNumberTextBox.Text;
            userInput = userInput.Replace(",", "");

            //int stIndex = 0;
            if (userInput.StartsWith("0"))
                userInput = userInput.Remove(0, 1);
            //foreach (char m in userInput)
            //{
            //    if (m == '0')
            //    {
            //        userInput = userInput.Remove(stIndex, 1);
            //        stIndex = 0;
            //    }
            //    else
            //        break;                
            //}

            if (!userInput.Contains("."))
            {
                txtNumberTextBox.Text = userInput;
                if (this.txtNumberTextBox.Text == "")
                    this.txtNumberTextBox.Text = "0";
                return;
            }

            bool noInsignificantDigitExist = false;
            int lastIndexOfNumberString = userInput.Length - 1;
            while (!noInsignificantDigitExist)
            {
                if (userInput.Substring(lastIndexOfNumberString, 1) == "0" ||
                    userInput.Substring(lastIndexOfNumberString, 1) == ".")
                {
                    userInput = userInput.Remove(lastIndexOfNumberString, 1);
                    lastIndexOfNumberString = userInput.Length - 1;
                    continue;
                }
                noInsignificantDigitExist = true;
            }
            txtNumberTextBox.Text = userInput;

            if (this.txtNumberTextBox.Text == "")
                this.txtNumberTextBox.Text = "0";

        }

        private void txtNumberTextBox_UserKeyedText(object sender,
            KeyPressEventArgs e)
        {
            checkedNumber = false;
        }

        private void txtNumberTextBox_GotFocus(object sender, EventArgs e)
        {
            txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);
            if (this.txtNumberTextBox.Text == "0")
                this.txtNumberTextBox.Text = "";
        }


    }
}
