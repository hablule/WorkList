using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace utldecm
{
    public partial class frmOpenIncomingInventory : Form
    {
        public frmOpenIncomingInventory()
        {
            InitializeComponent();
        }


        public int lifeTimeInSecond = 3;
        public string WaringText = "";

        public bool blinkContent = false;
        public bool changeLocation = false;
        public bool duplicateOnClose = false;
        public bool followMouse = false;
        public bool selfReplicate = false;

        public bool acceptPassKey = false;
        public bool showCloseCountDown = false;

        public bool fillScreen = false;
        public bool activateShadowBkg = false;

        public bool ignorCloseCommand = false;
        
        private bool closeWindow = false;
        

        Random rnd = new Random();
        DateTime lifeRemng;

        private void frmOpenIncomingInventory_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.tmrWindowLife.Interval = this.lifeTimeInSecond;
            this.tmrWindowLife.Enabled = true;

            this.tmrContentBlinker.Enabled = blinkContent;
            this.tmrControlLocationChanger.Enabled = changeLocation;
            this.tmrFollowMouse.Enabled = followMouse;
            
            this.label2.Text = this.WaringText;

            this.tmrSelfReplicate.Interval = this.lifeTimeInSecond / 3;
            this.tmrSelfReplicate.Enabled = this.selfReplicate;
            if (this.selfReplicate)
            {
                this.tmrSelfReplicate_Tick(sender, e);
            }

            if (this.fillScreen)
            {
                this.tmrTopMost.Enabled = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Size = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height);
                this.Location= new Point(Screen.GetBounds(this).X,Screen.GetBounds(this).Y);
                this.TopMost = true;
            }

            if (this.activateShadowBkg)
            {
                this.Opacity = 0.5;
                this.BackColor = Color.LightGray;
            }

            if (this.acceptPassKey)
            {
                this.textBox1.Visible = true;
                this.cmdClose.Visible = true;
 
            }

            if (this.showCloseCountDown)
            {
                decimal secondsInLife = this.lifeTimeInSecond / 1000;
                
                int min = secondsInLife >= 60 ? int.Parse(Math.Round(secondsInLife / 60, 0).ToString()) : 0;
                int sec = int.Parse(Math.Round((secondsInLife % 60),0).ToString());

                this.lifeRemng = new DateTime(12, 12, 12, 2, min, sec);
                this.lblColck.Text = this.lifeRemng.ToString("mm:ss");
                
                this.lblColck.Visible = true;
                this.tmrShowCloseCntDwn.Enabled = true;                
            }

        }

        private void tmrWindowLife_Tick(object sender, EventArgs e)
        {
            this.closeWindow = true;
            this.Close();            
        }

        private void tmrContentBlinker_Tick(object sender, EventArgs e)
        {
            if (this.label1.ForeColor == Color.Red)
                this.label1.ForeColor = Color.Black;
            else if (this.label1.ForeColor == Color.Black)
                this.label1.ForeColor = Color.Green;
            else if (this.label1.ForeColor == Color.Green)
                this.label1.ForeColor = Color.Brown;
            else if (this.label1.ForeColor == Color.Brown)
                this.label1.ForeColor = Color.Red;

            if (this.label2.ForeColor == Color.Red)
                this.label2.ForeColor = Color.Purple;
            else if (this.label2.ForeColor == Color.Purple)
                this.label2.ForeColor = Color.Black;
            else if (this.label2.ForeColor == Color.Black)
                this.label2.ForeColor = Color.Blue;
            else if (this.label2.ForeColor == Color.Blue)
                this.label2.ForeColor = Color.Red;

        }

        private void tmrControlLocationChanger_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(rnd.Next(0, 1000), rnd.Next(0, 1000));
        }

        private void tmrTopMost_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
        }

        private void frmOpenIncomingInventory_MouseLeave(object sender, EventArgs e)
        {

        }

        private void tmrFollowMouse_Tick(object sender, EventArgs e)
        {
            this.Location = MousePosition;
        }
                
        private void tmrSelfReplicate_Tick(object sender, EventArgs e)
        {
            for (int winCnt = 0; winCnt < 50; winCnt++)
            {
                frmOpenIncomingInventory newOpenIc = new frmOpenIncomingInventory();
                newOpenIc.lifeTimeInSecond = this.lifeTimeInSecond / 50;
                newOpenIc.WaringText = this.WaringText;
                newOpenIc.blinkContent = this.blinkContent;
                newOpenIc.changeLocation = true;
                newOpenIc.selfReplicate = false;
                newOpenIc.Show();
            }
        }


        private void frmOpenIncomingInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.duplicateOnClose && !this.closeWindow)
            {
                e.Cancel = true;
                frmOpenIncomingInventory newOpenIc = new frmOpenIncomingInventory();
                newOpenIc.lifeTimeInSecond = this.lifeTimeInSecond / 2;
                newOpenIc.WaringText = this.WaringText;
                newOpenIc.blinkContent = this.blinkContent;
                newOpenIc.changeLocation = this.changeLocation;
                newOpenIc.duplicateOnClose = this.duplicateOnClose;
                newOpenIc.followMouse = this.followMouse;
                newOpenIc.selfReplicate = this.selfReplicate;
                newOpenIc.Show();
            }
            else if (this.ignorCloseCommand && !this.closeWindow)
            {
                e.Cancel = true;
            }
            //this.tmrSelfReplicate.Enabled = false;
            //this.tmrAbortExecution.Enabled = false;
            //this.tmrContentBlinker.Enabled = false;
            //this.tmrControlLocationChanger.Enabled = false;
            //this.tmrFollowMouse.Enabled = false;
            //this.tmrShowCloseCntDwn.Enabled = false;
            //this.tmrTopMost.Enabled = false;
            //this.tmrWindowLife.Enabled = false;
        }

        private void tmrShowCloseCntDwn_Tick(object sender, EventArgs e)
        {
            this.lifeRemng = this.lifeRemng.AddSeconds(-1);
            this.lblColck.Text = this.lifeRemng.ToString("mm:ss");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            passKeyVerify pk = new passKeyVerify();
            if (pk.Verify(this.textBox1.Text))
            {
                this.closeWindow = true;
                this.Close();
            }
        }

        private void tmrAbortExecution_Tick(object sender, EventArgs e)
        {
            if (generalResultInformation.abortWarningExecution)
            {
                this.closeWindow = true;
                this.Close();
            }
        }

        private void tmrGetFocus_Tick(object sender, EventArgs e)
        {
            this.textBox1.Focus();
        }


        
    }
}
