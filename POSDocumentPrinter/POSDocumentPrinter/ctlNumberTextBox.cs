using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSDocumentPrinter
{
    public partial class ctlNumberTextBox : UserControl
    {
        private bool checkedNumber = true;
        private int pointPrecision = 2;
        private int scale = 0;
        private bool allowNegative = false;        
        private bool showSeparator = true;
        private string defaultValue = "0";
        private bool LeadingZero = false;

        //private bool decimalSepartorExist = false;

        public event EventHandler contentChanged;

        
        public ctlNumberTextBox()
        {
            InitializeComponent();
        }

        public string Amount
        {
            get
            {
                return txtNumberTextBox.Text.Replace(",","");
            }
            set
            {
                checkedNumber = false;
                txtNumberTextBox.Text = value;
            }
        }

        public HorizontalAlignment Align
        {
            get
            {
                return txtNumberTextBox.TextAlign;
            }
            set
            {                
                txtNumberTextBox.TextAlign = value;
            }
        }

        public bool ShowThousandSeparetor
        {
            get
            {
                return showSeparator;
            }
            set
            {
                showSeparator = value;
            }
        }       


        public bool AllowNegative
        {
            get
            {
                return allowNegative;
            }
            set
            {
                allowNegative = value;
            }
        }

        public bool AllowLeadingZeros
        {
            get
            {
                return LeadingZero;
            }
            set
            {
                LeadingZero = value;
            }
        }       


        public string Value
        {
            get
            {
                return txtNumberTextBox.Text;
            }            
        }

        public string defaultAmount
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
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

        public int AllowedLength
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }


        private void txtNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkedNumber)
            {
                if (contentChanged != null)
                    contentChanged.Invoke(sender, e);
                return;
            }
            string userInput = txtNumberTextBox.Text;
            int stIndex = 0;
            if(userInput.Contains(","))
            {
                userInput = userInput.Replace(",", "");
                checkedNumber = true;
            }

            if(userInput.Length > this.scale && this.scale > 0)
            {
                checkedNumber = true;
                txtNumberTextBox.Text = 
                    txtNumberTextBox.Text.Remove(txtNumberTextBox.Text.Length - 1, 1);
                txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);

                if (contentChanged != null)
                    contentChanged.Invoke(sender, e);
                return;
            }

            foreach (char m in userInput)
            {
                if ((m != '0' && m != '1' && m != '2'
                    && m != '3' && m != '4' && m != '5' &&
                    m != '6' && m != '7' && m != '8' && m != '9'
                    && m != '.' && m != '-') || 
                    (m == '-' && (!this.allowNegative || stIndex != 0)))
                {
                    userInput = userInput.Replace(m.ToString(), "");
                    checkedNumber = true;
                }
                if (m == '-' && this.allowNegative)
                {
                    if (stIndex != 0)
                    {
                        userInput = userInput.Remove(userInput.LastIndexOf(m),1);
                        continue;
                    }
                }
                if(m=='.')
                {
                    if(this.pointPrecision == 0)
                    {
                        userInput = userInput.Replace(m.ToString(), "");
                        continue;
                    }
                    if(stIndex == 0)
                    {
                        userInput = "0" + userInput;
                        checkedNumber = true;
                    }
                    if (userInput.IndexOf(m.ToString(), 0) != 
                        userInput.LastIndexOf(m.ToString()))
                    {
                        int firstDecimalOccurence = userInput.IndexOf(".");
                        userInput = userInput.Replace(".", "");
                        userInput = userInput.Insert(firstDecimalOccurence, ".");
                        checkedNumber = true;
                    }
                }
               stIndex++;
            }

            if (userInput.StartsWith("0") && userInput.Length > 1 && !AllowLeadingZeros)
            {
                if (userInput.Substring(1, 1) != ".")
                {
                    userInput = userInput.Remove(0, 1);
                    checkedNumber = true;
                }
            }

            if (userInput.StartsWith("-") && userInput.Length > 1)
            {
                if (userInput.Substring(1, 1) == "0")
                {
                    userInput = userInput.Remove(1, 1);
                    checkedNumber = true;
                }
            }

            string negativeSign = "";
            if (userInput.StartsWith("-"))
            {
                userInput = userInput.Replace("-", "");
                negativeSign = "-";
            }
            
            if (userInput == "" || userInput.Length < 4)
            {
                checkedNumber = true;
                txtNumberTextBox.Text = negativeSign + userInput;
                txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);
                if(contentChanged != null)
                    contentChanged.Invoke(sender, e);
                return;
            }
            
            string numbersBeforeDecimalPoint = "";
            if(userInput.Contains("."))
            {
                numbersBeforeDecimalPoint = userInput.Remove(userInput.IndexOf('.'));
                if ((userInput.Length - (numbersBeforeDecimalPoint.Length + 1)) > this.pointPrecision)
                {
                    userInput = userInput.Remove((userInput.IndexOf('.') + this.pointPrecision+1), 1);
                }
            }
            else
                numbersBeforeDecimalPoint = userInput;
            if (numbersBeforeDecimalPoint.Length < 4)
            {
                checkedNumber = true;
                txtNumberTextBox.Text = negativeSign + userInput;
                txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);

                if (contentChanged != null)
                    contentChanged.Invoke(sender, e);
                return;
            }
            
            int numberOfThousandSepartors = numbersBeforeDecimalPoint.Length / 3;
            int startingIndex = numbersBeforeDecimalPoint.Length % 3;

            if (!this.showSeparator)
                goto finalline;

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

        finalline:            
            checkedNumber = true;
            txtNumberTextBox.Text = negativeSign + userInput;
            txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);

            if (contentChanged != null)
                contentChanged.Invoke(sender, e);
        }

        private void txtNumberTextBox_LostFocus(object sender, EventArgs e)
        {
            checkedNumber = false;
            
            //Clear Insignificant digits from number.
            
            string userInput = txtNumberTextBox.Text;
            userInput = userInput.Replace(",", "");
                        
            if (userInput.StartsWith("0") && userInput.Length > 1 && !this.LeadingZero)
                userInput = userInput.Remove(0, 1);
            if(userInput.StartsWith("-") && userInput.Length <= 1)
                userInput = "0";
            
            if (!userInput.Contains("."))
            {
                txtNumberTextBox.Text = userInput;
                if (this.txtNumberTextBox.Text == "")
                    this.txtNumberTextBox.Text = this.defaultAmount;
                return;
            }

            bool noInsignificantDigitExist = false;
            int lastIndexOfNumberString = userInput.Length - 1;
            while (!noInsignificantDigitExist)
            {
                if (userInput.Substring(lastIndexOfNumberString, 1) == "0")
                {
                    userInput = userInput.Remove(lastIndexOfNumberString, 1);
                    lastIndexOfNumberString = userInput.Length - 1;
                    continue;
                }
                else if (userInput.Substring(lastIndexOfNumberString, 1) == ".")
                {
                    userInput = userInput.Remove(lastIndexOfNumberString, 1);
                    lastIndexOfNumberString = userInput.Length - 1;                    
                }
                noInsignificantDigitExist = true;
            }
            txtNumberTextBox.Text = userInput;
            if (this.txtNumberTextBox.Text == "" || this.txtNumberTextBox.Text == "0")
                this.txtNumberTextBox.Text = this.defaultAmount;            
        }

        private void txtNumberTextBox_UserKeyedText(object sender, 
            KeyPressEventArgs e)
        {
            checkedNumber = false;
        }

        private void txtNumberTextBox_GotFocus(object sender, EventArgs e)
        {
            txtNumberTextBox.Select(txtNumberTextBox.Text.Length, 0);
            if (this.txtNumberTextBox.Text != "")
            {
                if (decimal.Parse(this.txtNumberTextBox.Text) == 0)
                    this.txtNumberTextBox.Text = "";
            }            
        }

    }
}
