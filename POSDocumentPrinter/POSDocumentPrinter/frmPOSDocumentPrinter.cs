using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using gma.System.Windows;

namespace POSDocumentPrinter
{
    public partial class frmPOSDocumentPrinter : Form
    {
        public frmPOSDocumentPrinter()
        {
            InitializeComponent();
        }

        #region "Declaration Region"

        string styleName = "";
        string latestSalesReferenceNo = "";
        string latestRefundedSalesReferenceNo = "";

        string stFormOriginalText = "";

        bool nonRefundedSalesRefNumberTextBoxEnabled = false;
        bool refundedSalesRefNumberTextBoxEnabled = false;
        bool formAutoHide = true;

        checkAndEstablishDbConnectionSettings checkConnections = 
            new checkAndEstablishDbConnectionSettings();

        dataBuilder getInformationFromDb = 
            new dataBuilder();

        Size szformOriginalSize = new Size();

        UserActivityHook actHook;
        
        #endregion


        private string getNextInterfaceName()
        {
            if (this.styleName == "Aero (Black).vssf")
            {
                this.styleName = "Aero (Blue).vssf";
                return "Skins\\Aero (Blue).vssf";
            }
            else if (this.styleName == "Aero (Blue).vssf")
            {
                this.styleName = "Aero (Silver).vssf";
                return "Skins\\Aero (Silver).vssf";
            }
            else if (this.styleName == "Aero (Silver).vssf")
            {
                this.styleName = "Office2007 (Black).vssf";
                return "Skins\\Office2007 (Black).vssf";
            }
            else if (this.styleName == "Office2007 (Black).vssf")
            {
                this.styleName = "Office2007 (Blue).vssf";
                return "Skins\\Office2007 (Blue).vssf";
            }
            else if (this.styleName == "Office2007 (Blue).vssf")
            {
                this.styleName = "Office2007 (Silver).vssf";
                return "Skins\\Office2007 (Silver).vssf";
            }
            else if (this.styleName == "Office2007 (Silver).vssf")
            {
                this.styleName = "OSX (Aqua).vssf";
                return "Skins\\OSX (Aqua).vssf";
            }
            else if (this.styleName == "OSX (Aqua).vssf")
            {
                this.styleName = "OSX (Brushed).vssf";
                return "Skins\\OSX (Brushed).vssf";
            }
            else if (this.styleName == "OSX (Brushed).vssf")
            {
                this.styleName = "OSX (iTunes).vssf";
                return "Skins\\OSX (iTunes).vssf";
            }
            else if (this.styleName == "OSX (iTunes).vssf")
            {
                this.styleName = "OSX (Leopard).vssf";
                return "Skins\\OSX (Leopard).vssf";
            }
            else if (this.styleName == "OSX (Leopard).vssf")
            {
                this.styleName = "OSX (Panther).vssf";
                return "Skins\\OSX (Panther).vssf";
            }
            else if (this.styleName == "OSX (Panther).vssf")
            {
                this.styleName = "OSX (Tiger).vssf";
                return "Skins\\OSX (Tiger).vssf";
            }
            else if (this.styleName == "OSX (Tiger).vssf")
            {
                this.styleName = "Vista (Aero).vssf";
                return "Skins\\Vista (Aero).vssf";
            }
            else if (this.styleName == "Vista (Aero).vssf")
            {
                this.styleName = "Vista (Basic).vssf";
                return "Skins\\Vista (Basic).vssf";
            }
            else if (this.styleName == "Vista (Basic).vssf")
            {
                this.styleName = "Vista (Black).vssf";
                return "Skins\\Vista (Black).vssf";
            }
            else if (this.styleName == "Vista (Black).vssf")
            {
                this.styleName = "Vista (Blue).vssf";
                return "Skins\\Vista (Blue).vssf";
            }
            else if (this.styleName == "Vista (Blue).vssf")
            {
                this.styleName = "Vista (Green).vssf";
                return "Skins\\Vista (Green).vssf";
            }
            else if (this.styleName == "Vista (Green).vssf")
            {
                this.styleName = "Vista (Silver).vssf";
                return "Skins\\Vista (Silver).vssf";
            }
            else if (this.styleName == "Vista (Silver).vssf")
            {
                this.styleName = "Vista (Teal).vssf";
                return "Skins\\Vista (Teal).vssf";
            }
            else if (this.styleName == "Vista (Teal).vssf")
            {
                this.styleName = "XP (Blue).vssf";
                return "Skins\\XP (Blue).vssf";
            }
            else if (this.styleName == "XP (Blue).vssf")
            {
                this.styleName = "XP (Olive).vssf";
                return "Skins\\XP (Olive).vssf";
            }
            else if (this.styleName == "XP (Olive).vssf")
            {
                this.styleName = "XP (Royale).vssf";
                return "Skins\\XP (Royale).vssf";
            }
            else if (this.styleName == "XP (Royale).vssf")
            {
                this.styleName = "XP (Silver).vssf";
                return "Skins\\XP (Silver).vssf";
            }
            else
            {
                this.styleName = "Aero (Black).vssf";
                return "Skins\\Aero (Black).vssf";
            }              
        }

        private void changeUserInterface()
        {
            this.visualStyler1.LoadVisualStyle(this.getNextInterfaceName());
            dbSettingInformationHandler.theme = this.styleName;
        }


        private bool simulateEnabelDisableOnTextBox
            (TextBox _textBox, bool readStatus, bool enable)
        {
            if (!readStatus)
            {
                if (!enable)
                {
                    _textBox.BackColor = Color.FromKnownColor(KnownColor.Silver);
                }
                else
                {
                    _textBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
                return true;
            }
            else
            {
                if (_textBox.BackColor == Color.FromKnownColor(KnownColor.Silver))
                    return false;
                else
                    return true;
            }
            
        }

        private void fillLatestSalesReferenceNumberToTextBoxes()
        {
            if (!this.simulateEnabelDisableOnTextBox(this.txtInvoiceReferenceNumber,true,false))
                this.txtInvoiceReferenceNumber.Text =
                    this.latestSalesReferenceNo;
            if (!this.simulateEnabelDisableOnTextBox(this.txtRefundReferenceNumber, true, false))
                this.txtRefundReferenceNumber.Text = this.latestRefundedSalesReferenceNo;
        }
        

        private void frmPOSDocumentPrinter_Load(object sender, EventArgs e)
        {   
            this.Size = new Size(334, 315);
            this.szformOriginalSize = this.Size;
            this.stFormOriginalText = this.Text;

            if (!checkConnections.establishDbConnectionSettins())
            {               
                Application.Exit();
                return;
            }
            if (generalResultInformation.Station == "" ||
                generalResultInformation.centralStation == "" ||
                generalResultInformation.machineRegistrationNumber == "")
            {
                Application.Exit();
                return;
            }
            if (!System.IO.File.Exists("crptAttachmentInvoice.rpt") ||
                !System.IO.File.Exists("crptDeliveryOrder.rpt") ||
                !System.IO.File.Exists("crptRefundBook.rpt"))
            {
                Application.Exit();
                return;
            }

            this.visualStyler1.LoadVisualStyle(dbSettingInformationHandler.theme);
                        
            
            this.tmrPOSDocumentRefreshTime.Enabled = true;
            this.tmrPOSDocumentRefreshTime_Tick(sender, e);

            this.WindowState = FormWindowState.Normal;

            int x = Screen.PrimaryScreen.WorkingArea.Left;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);
                        
            DateTime exemptedKPIDate =
                DateTime.Parse(this.getInformationFromDb.getKPIExemptedDate().ToString("yyyy-MM-dd"));


            if (DateTime.Now.Date.CompareTo(exemptedKPIDate) != 1)
            {
                generalResultInformation.allowAttachementBlocking = false;
            }
            else
            {
                generalResultInformation.allowAttachementBlocking = true; 
            }

            this.cmdDiminish_Click(sender, e);

            actHook = new UserActivityHook(true, false); // crate an instance with global hooks
            // hang on events
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.Start(true, false);
                        
            this.Enabled = true;
        }

        private void frmPosCompiereBridge_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dtSettingsTable = new DataTable();
            string settingFile = dbSettingInformationHandler.settingFilePath;
            bool settingFound = false;

            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");

            if (File.Exists(settingFile))
            {
                try
                {
                    dtSettingsTable.ReadXml(settingFile);
                    foreach (DataRow dr in dtSettingsTable.Rows)
                    {
                        if (dr["Parameter_Name"].ToString() == "theme")
                        {
                            dr["Parameter_Value"] = dbSettingInformationHandler.theme;
                            settingFound = true;
                            break;
                        }
                    }
                    if (!settingFound)
                    {
                        DataRow dr = dtSettingsTable.NewRow();
                        dr["Parameter_Name"] = "theme";
                        dr["Parameter_Value"] = dbSettingInformationHandler.theme;
                        dtSettingsTable.Rows.Add(dr);
                    }
                    dtSettingsTable.WriteXml(settingFile); 
                }
                catch
                {
                }
            }
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //    this.Hide();
            //    this.ShowInTaskbar = false;
            //    this.WindowState = FormWindowState.Minimized;
            //}
            //else
            //{
            //    Application.Exit();
            //}
        }
        

        private void tmrPOSDocumentRefreshTime_Tick(object sender, EventArgs e)
        {
            string lastSalesRefNo = this.latestSalesReferenceNo;
            //Get Latest Sales Id for Station
            DataTable latestSalesInfo = 
                this.getInformationFromDb.getSalesInfo(null, "", "",
                                    generalResultInformation.Station, "", generalResultInformation.concernedNode, "",
                                    triaStateBool.no, false, true,false, "AND");
            if (this.getInformationFromDb.checkIfTableContainesData(latestSalesInfo))
            {
                this.latestSalesReferenceNo = 
                    latestSalesInfo.Rows[0]["ref_note"].ToString().Trim().Replace(" ","") != "" ?
                    latestSalesInfo.Rows[0]["ref_note"].ToString() :
                    latestSalesInfo.Rows[0]["REF_NO"].ToString();
            }
            
            //Get Latest Refund Id for Station
            DataTable latestRefundedSales =
                this.getInformationFromDb.getSalesInfo(null, "", "",
                                    generalResultInformation.Station, "", generalResultInformation.concernedNode, "",
                                    triaStateBool.no, false,false,true, "AND");

            if (this.getInformationFromDb.checkIfTableContainesData(latestRefundedSales))
            {
                this.latestRefundedSalesReferenceNo = latestRefundedSales.Rows[0]["REF_NO"].ToString();
            }

            //Assign Sales Computer Invoice Number To Text Boxes.
            this.fillLatestSalesReferenceNumberToTextBoxes();

            this.lblLastReportedSales.Text = "Last Audited Sales : " + 
                this.getInformationFromDb.getLastAuditedSalesDate().ToString("MMMM, dddd dd,yyyy ");
            GC.Collect();

            if (lastSalesRefNo != this.latestSalesReferenceNo && 
                !this.ckAutoHidePin.Checked && lastSalesRefNo != "")
            {
                if (dbSettingInformationHandler.EnableDeliveryOrderPrint &&
                    dbSettingInformationHandler.AutoPrintDeliveryOrder)
                {
                    this.cmdDeliveryOrder_Click(sender, e);
                }

                if ((this.isKPIachieved() || 
                    !generalResultInformation.allowAttachementBlocking) && 
                    !generalResultInformation.logInSessionExpired)
                {                    
                    this.cmdAttachment_Click(sender, e); 
                } 
            }
        }       


        private void mnuExit_Click(object sender, EventArgs e)
        {            
            FormClosingEventArgs eventArgument = new FormClosingEventArgs
                (CloseReason.ApplicationExitCall, false);
            this.frmPosCompiereBridge_FormClosing(sender, eventArgument);
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn &&
                (generalResultInformation.userType == "System Admin" ||
                 generalResultInformation.userType == "Super Admin" ||
                 generalResultInformation.userType == "Admin")
               )
            {
                frmsettings frmDbConnection = new frmsettings();
                frmDbConnection.ShowDialog(this);
            }
        }


        private void txtInvoiceReferenceNumber_Click(object sender, EventArgs e)
        {
            this.txtInvoiceReferenceNumber.Text = "";
            this.simulateEnabelDisableOnTextBox(this.txtInvoiceReferenceNumber, 
                this.nonRefundedSalesRefNumberTextBoxEnabled, true);
        }

        private void txtInvoiceReferenceNumber_Leave(object sender, EventArgs e)
        {
            if(this.txtInvoiceReferenceNumber.Text == "")
                this.simulateEnabelDisableOnTextBox(this.txtInvoiceReferenceNumber,
                this.nonRefundedSalesRefNumberTextBoxEnabled, false);
        }

        private void txtRefunReferenceNumber_Click(object sender, EventArgs e)
        {
            this.txtRefundReferenceNumber.Text = "";
            this.simulateEnabelDisableOnTextBox(this.txtRefundReferenceNumber,
                this.refundedSalesRefNumberTextBoxEnabled, true);
        }
        
        private void txtRefunReferenceNumber_Leave(object sender, EventArgs e)
        {
            if (this.txtRefundReferenceNumber.Text == "")
                this.simulateEnabelDisableOnTextBox(this.txtRefundReferenceNumber,
                this.refundedSalesRefNumberTextBoxEnabled, false);
        }
                

        private void cmdDeliveryOrder_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.DeliveryOrder;

            if (!dbSettingInformationHandler.EnableDeliveryOrderPrint)
            {
                DialogResult dlgRslt =
                    MessageBox.Show("Delivery Order has not been Allowed." +
                            " Please contact your Administrator to obtain permission.\n " +
                            " Would You like to input pass key to proceed Temporally?",
                            "POS DocPrinter", MessageBoxButtons.YesNo, 
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dlgRslt == DialogResult.Yes)
                {
                    frmValidateSecurityKey frmAllg =
                        new frmValidateSecurityKey();
                    frmAllg.ShowDialog();

                    if (!generalResultInformation.securityPassKeyCorrect)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

            if (this.txtInvoiceReferenceNumber.Text == "")
            {
                this.Enabled = true;
                this.cmdDiminish_Click(sender, e);
                return;
            }


            if (generalResultInformation.logInSessionExpired)
            {
                frmLogIn logIn = new frmLogIn();
                logIn.TopMost = true;
                logIn.ShowDialog();

                if (generalResultInformation.logedIn)
                {
                    generalResultInformation.logInSessionExpired = false;
                    this.tmrUserLogionSession.Enabled = true;
                }
                else
                {
                    this.cmdDiminish_Click(sender, e);
                    this.Enabled = true;
                    return;
                }
            }

            DataTable salesInformation =
                this.getInformationFromDb.getSalesInfo(null, "", "",
                        generalResultInformation.Station, this.txtInvoiceReferenceNumber.Text,
                        generalResultInformation.concernedNode, "", triaStateBool.Ignor,
                        false, false, false, "AND");

           if (!this.getInformationFromDb.checkIfTableContainesData(salesInformation))
            {
                MessageBox.Show("No sales Information found for current reference.",
                    "POS Document Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                this.cmdDiminish_Click(sender, e);
                this.Enabled = true;
                return;
            }

           string salesId =  "";
           string customerId = "";
           string cashier_id = "";

           if (salesInformation.Rows.Count == 1)
           {
               salesId = salesInformation.Rows[0]["ID"].ToString();
               customerId = salesInformation.Rows[0]["customer_id"].ToString();
               cashier_id = salesInformation.Rows[0]["cashier_id"].ToString();
           }
           else
           {
               for (int rowCounter = 0; rowCounter <= salesInformation.Rows.Count - 1; rowCounter++)
               {
                   if (salesInformation.Rows[rowCounter]["REF_NO"].ToString() == this.txtInvoiceReferenceNumber.Text)
                   {
                       salesId = salesInformation.Rows[rowCounter]["ID"].ToString();
                       customerId = salesInformation.Rows[rowCounter]["customer_id"].ToString();
                       cashier_id = salesInformation.Rows[rowCounter]["cashier_id"].ToString(); 
                   }
                   else if (salesInformation.Rows[rowCounter]["REF_NOTE"].ToString() == this.txtInvoiceReferenceNumber.Text)
                       {
                           salesId = salesInformation.Rows[rowCounter]["ID"].ToString();
                           customerId = salesInformation.Rows[rowCounter]["customer_id"].ToString();
                           cashier_id = salesInformation.Rows[rowCounter]["cashier_id"].ToString();
                       }
               }
           }

            this.getInformationFromDb.getUserFullName(cashier_id);
                        
            generalResultInformation.requestedReport = reportType.deliveryOrder;
            //generalResultInformation.userId = cashier_id;
            

            DataTable dtsalesDetailInformation =
                this.getInformationFromDb.getSalesItemsInfo(null, "", "", 
                                                            generalResultInformation.Station,
                                                            generalResultInformation.concernedNode,
                                                            triaStateBool.Ignor, salesId, false, "AND");

            this.getInformationFromDb.establishSalesInformation(salesId,
                        generalResultInformation.Station,
                        generalResultInformation.concernedNode, false);

            List<String> stores = new List<string>();

            for (int rowCounter = 0; rowCounter <= dtsalesDetailInformation.Rows.Count - 1; rowCounter++)
            {
                if (!stores.Contains
                       (dtsalesDetailInformation.Rows[rowCounter]["sold_from_store_id"].ToString()))
                {
                    stores.Add(dtsalesDetailInformation.Rows[rowCounter]["sold_from_store_id"].ToString());
                }
            }

            string[] dispatchingStore = stores.ToArray();
            
            DataTable dtDispatchOrderInfo = new DataTable();

            foreach (string storeId in dispatchingStore)
            {
                if (storeId != "" && storeId != "0")
                {
                    //Check If Store has dispatch Order Over Existing Sales
                    dtDispatchOrderInfo =
                        this.getInformationFromDb.getCustomerDispatchInfo(null, "", salesId, "", 
                                    storeId, generalResultInformation.Station, "", 
                                    generalResultInformation.concernedNode, false, "AND");
                    if (!this.getInformationFromDb.checkIfTableContainesData(dtDispatchOrderInfo))
                    {
                        //... IF not Register New dispatchFor Sales Over Store
                        DataRow drNewDispatchInfo = dtDispatchOrderInfo.NewRow();
                        drNewDispatchInfo["SALES_ID"] = salesId;
                        drNewDispatchInfo["CUSTOMER_ID"] = customerId;
                        drNewDispatchInfo["SOLD_FROM_STORE_ID"] = storeId;
                        drNewDispatchInfo["STATION"] = generalResultInformation.Station;
                        drNewDispatchInfo["NODE"] = generalResultInformation.concernedNode;

                        dtDispatchOrderInfo.Rows.Add(drNewDispatchInfo);
                        this.getInformationFromDb.changeDataBaseTableData(dtDispatchOrderInfo, 
                                "CUSTOMER_DISPATCH", "INSERT", true);
                    }

                    this.getInformationFromDb.generateCustomerDispatchInvoice
                        (salesId, generalResultInformation.Station,
                            generalResultInformation.concernedNode, storeId);

                    frmDocPrintPreview frmAttachmentPrintPreview = new frmDocPrintPreview();
                    frmAttachmentPrintPreview.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Store Information Missing.",
                        "POS Document Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }

            //this.txtInvoiceReferenceNumber.Text = "";
            //this.txtInvoiceReferenceNumber_Leave(sender, e);

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }

        private void cmdAttachment_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.Attachement;
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);


            if (this.txtInvoiceReferenceNumber.Text == "")
            {
                this.cmdDiminish_Click(sender, e);
                this.Enabled = true;
                return;
            }

            if(!this.getInformationFromDb.isStockCorrect())
            {
                MessageBox.Show("The system suffers negative stock." +
                        " Please correct them soon.\n ", "KPI info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
            }

            if (!this.isKPIachieved())
            {
                if (generalResultInformation.allowAttachementBlocking &&
                    generalResultInformation.ControlAttachmentPrint)
                {
                    DialogResult dlgRslt = 
                        MessageBox.Show("The following performance issues hinder you operation." +
                                " Please correct them before proceeding.\n " +
                                " Would You like to input pass key to proceed Temporally?" +
                                generalResultInformation.KPIresult, "KPI info",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);

                    if (dlgRslt == DialogResult.Yes)
                    {
                        frmValidateSecurityKey frmAllg =
                            new frmValidateSecurityKey();                        
                        frmAllg.ShowDialog();

                        generalResultInformation.allowAttachementBlocking = true;

                        if (generalResultInformation.securityPassKeyCorrect)
                        {
                            this.getInformationFromDb.updatePER_SKIP_KPI_CHECK();
                            generalResultInformation.allowAttachementBlocking = false;
                        }
                        else 
                        {
                            MessageBox.Show("The following performance issues hinder you operation." +
                                " Please correct them before proceeding.\n " + 
                                generalResultInformation.KPIresult, "KPI info",
                                MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);

                            this.cmdDiminish_Click(sender, e);
                            this.Enabled = true;
                            return;
                        }
                    }
                    else
                    {
                        this.cmdDiminish_Click(sender, e);
                        this.Enabled = true;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The system suffers the following performance issues." +
                        " Please correct them soon.\n " +
                        generalResultInformation.KPIresult, "KPI info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1); 
                }
            }

            if (generalResultInformation.logInSessionExpired)
            {
                frmLogIn logIn = new frmLogIn();
                logIn.TopMost = true;
                logIn.ShowDialog();

                if (generalResultInformation.logedIn)
                {
                    generalResultInformation.logInSessionExpired = false;
                    this.tmrUserLogionSession.Enabled = true;
                }
                else
                {
                    this.cmdDiminish_Click(sender, e);
                    this.Enabled = true;
                    return; 
                }
            }


            DataTable salesInformation =
                this.getInformationFromDb.getSalesInfo(null, "", "",
                        generalResultInformation.Station, this.txtInvoiceReferenceNumber.Text,
                        generalResultInformation.concernedNode, "", triaStateBool.Ignor,
                        false, false, false, "AND");

            if (!this.getInformationFromDb.checkIfTableContainesData(salesInformation))
            {
                this.cmdDiminish_Click(sender, e);
                this.Enabled = true;
                return;
            }

            //If manual sales with same ref with FP sales recorded Remove Manual Sales and Give Preceedence to FP sales
            for (int rowCounter = salesInformation.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (salesInformation.Rows[rowCounter]["REF_NOTE"].ToString() != "")
                {
                    salesInformation.Rows.RemoveAt(rowCounter);
                }
            }

            if (!this.getInformationFromDb.checkIfTableContainesData(salesInformation))
            {
                this.cmdDiminish_Click(sender, e);
                this.Enabled = true;
                return;
            }

            string salesId = salesInformation.Rows[0]["ID"].ToString();
            string cashier_id = salesInformation.Rows[0]["cashier_id"].ToString();

            this.getInformationFromDb.getUserFullName(cashier_id);
            generalResultInformation.userId = cashier_id;

            generalResultInformation.documentRequestInfoCancelled = false;

            this.getInformationFromDb.generateAttachmentReport(salesId, generalResultInformation.Station,
                generalResultInformation.concernedNode, !this.ckAutoHidePin.Checked);

            if (generalResultInformation.documentRequestInfoCancelled)
            {
                this.cmdDiminish_Click(sender, e);
                this.Enabled = true;
                return;
            }

            generalResultInformation.requestedReport = reportType.attachment;
            frmDocPrintPreview frmAttachmentPrintPreview = new frmDocPrintPreview();
            frmAttachmentPrintPreview.ShowDialog();

            //this.txtInvoiceReferenceNumber.Text = "";
            //this.txtInvoiceReferenceNumber_Leave(sender, e);
            
            
            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;

        }

        private void cmbRefundBook_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.Refund;
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

            if (this.txtRefundReferenceNumber.Text == "")
            {
                this.Enabled = true;
                this.cmdDiminish_Click(sender, e);
                return;
            }
            DataTable refundInformation =
                this.getInformationFromDb.getRefundsInfo(null, "", "",
                        generalResultInformation.Station, this.txtRefundReferenceNumber.Text,
                        generalResultInformation.concernedNode, "", false, false, "AND");

            if (!this.getInformationFromDb.checkIfTableContainesData(refundInformation))
            {
                this.Enabled = true;
                this.cmdDiminish_Click(sender, e);
                return;
            }

            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {
                string refundId = refundInformation.Rows[0]["ID"].ToString();
                string cashier_id = refundInformation.Rows[0]["cashier_id"].ToString();

                this.getInformationFromDb.getUserFullName(cashier_id);
                generalResultInformation.userId = cashier_id;

                generalResultInformation.documentRequestInfoCancelled = false;

                this.getInformationFromDb.generateSalesRefundBook(refundId, generalResultInformation.Station,
                    generalResultInformation.concernedNode);

                if (generalResultInformation.documentRequestInfoCancelled)
                {
                    this.Enabled = true;
                    this.cmdDiminish_Click(sender, e);
                    return;
                }

                generalResultInformation.requestedReport = reportType.refundBook;
                frmDocPrintPreview frmAttachmentPrintPreview = new frmDocPrintPreview();
                frmAttachmentPrintPreview.ShowDialog();

                this.txtRefundReferenceNumber.Text = "";
                this.txtRefunReferenceNumber_Leave(sender, e);

            }

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }


        private void cmdManualSales_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.ManulaSales;
            
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

            generalResultInformation.logedIn = false;

            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {
                frmManualSales mnlSales = new frmManualSales();
                mnlSales.TopMost = true;
                mnlSales.ShowDialog();
            }

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }

        private void cmdPaymentExemption_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.Exemption;
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);
                        
            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {
                frmPaymentExemption pyExp = new frmPaymentExemption();
                pyExp.TopMost = true;
                pyExp.ShowDialog();
            }

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }

        private void cmdCRV_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.CRV;
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

                       
            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {
                frmCashReceiptVoucher newCRV = new frmCashReceiptVoucher();
                newCRV.TopMost = true;
                newCRV.ShowDialog();
            }

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }

        private void cmdDepositSlip_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.BankDeposit;
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

                       
            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {
                frmBankDepositSlips dpSlip = new frmBankDepositSlips();
                dpSlip.TopMost = true;
                dpSlip.ShowDialog();
            }

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }

        private void cmdInventory_Click(object sender, EventArgs e)
        {
            generalResultInformation.transationPerf = transactionPerformed.Inventory;
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {
                frmInventory inventory = new frmInventory();
                inventory.TopMost = true;
                inventory.ShowDialog();
            }

            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;
        }


        private void frmPOSDocumentPrinter_DoubleClick(object sender, EventArgs e)
        {
            this.changeUserInterface();
        }


        private void formMaximize()
        {
            this.cmdDiminish.Location = new Point(273, 1);
            this.Size = this.szformOriginalSize;
            this.Text = this.stFormOriginalText;
            this.lblLastReportedSales.Visible = true;
            this.ControlBox = true;

            int x = Screen.PrimaryScreen.WorkingArea.Left;// +this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);
        }

        private void formMinimize()
        {
            this.cmdDiminish.Location = new Point(0, 0);
            this.Size = new Size(58, 72);
            this.Text = "P.D.P";
            this.lblLastReportedSales.Visible = false;
            this.ControlBox = false;

            int x = Screen.PrimaryScreen.WorkingArea.Left;// +this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);
        }

        private void cmdDiminish_Click(object sender, EventArgs e)
        {
            if (!this.ckAutoHidePin.Checked)
                return;

            if (this.Size.Equals(this.szformOriginalSize))
            {
                this.formMinimize();
            }
            else
            {
                this.formMaximize();
            }            
        }
                        

        private bool isKPIachieved()
        {
            //this.getInformationFromDb.updateStationOverAllPerformance();

            DataTable dtPerformanceIndicator =
                this.getInformationFromDb.getPER_OPENRECORDInfo();

            bool KPIachieved = true;
            string KPIresult = "";

            for (int rowCounter = dtPerformanceIndicator.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (dtPerformanceIndicator.Rows[rowCounter]["CRITERIA"].ToString() == "-")
                {
                    if (int.Parse(dtPerformanceIndicator.Rows[rowCounter]["ACTUALVALUE"].ToString()) <=
                        int.Parse(dtPerformanceIndicator.Rows[rowCounter]["TARGETVALUE"].ToString()))
                    {
                        dtPerformanceIndicator.Rows.RemoveAt(rowCounter);
                    }
                    else
                    {
                        KPIachieved = false;
                        KPIresult = KPIresult + 
                            dtPerformanceIndicator.Rows[rowCounter]["CRITERIA_DESCRIPTION"].ToString() + " = " +
                            dtPerformanceIndicator.Rows[rowCounter]["ACTUALVALUE"].ToString() + ".\n";
                    }
                }
                else if (dtPerformanceIndicator.Rows[rowCounter]["CRITERIA"].ToString() == "+")
                {
                    if (int.Parse(dtPerformanceIndicator.Rows[rowCounter]["ACTUALVALUE"].ToString()) >=
                        int.Parse(dtPerformanceIndicator.Rows[rowCounter]["TARGETVALUE"].ToString()))
                    {
                        dtPerformanceIndicator.Rows.RemoveAt(rowCounter);
                    }
                    else
                    {
                        KPIachieved = false;
                        KPIresult = KPIresult +
                            dtPerformanceIndicator.Rows[rowCounter]["CRITERIA_DESCRIPTION"].ToString() + " = " +
                            dtPerformanceIndicator.Rows[rowCounter]["ACTUALVALUE"].ToString() + ".\n";
                    }
                }
                else
                {
                    if (int.Parse(dtPerformanceIndicator.Rows[rowCounter]["ACTUALVALUE"].ToString()) ==
                        int.Parse(dtPerformanceIndicator.Rows[rowCounter]["TARGETVALUE"].ToString()))
                    {
                        dtPerformanceIndicator.Rows.RemoveAt(rowCounter);
                    }
                    else
                    {
                        KPIachieved = false;
                        KPIresult = KPIresult +
                            dtPerformanceIndicator.Rows[rowCounter]["CRITERIA_DESCRIPTION"].ToString() + " = " +
                            dtPerformanceIndicator.Rows[rowCounter]["ACTUALVALUE"].ToString() + ".\n";
                    }
                }
            }

            generalResultInformation.KPIresult = KPIresult;

            return KPIachieved;

        }


        private void openInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.cmdDiminish_Click(sender, e);

            generalResultInformation.searchResult.Rows.Clear();
            generalResultInformation.searchCritrion.Rows.Clear();

            frmLogIn logIn = new frmLogIn();
            logIn.TopMost = true;
            logIn.ShowDialog();

            if (generalResultInformation.logedIn)
            {

                frmSearchOpenInvoice openInvoice = new frmSearchOpenInvoice();
                openInvoice.TopMost = true;
                openInvoice.ShowDialog();

                if (generalResultInformation.searchResult.Rows.Count > 0)
                {
                    generalResultInformation.dtsDocumentPrintView.Tables["dtOpenInvoice"].Clear();
                    DataRow drOpenInvoiceDetail;

                    for (int rowCounter = 0; rowCounter <= generalResultInformation.searchResult.Rows.Count - 1; rowCounter++)
                    {
                        drOpenInvoiceDetail =
                            generalResultInformation.dtsDocumentPrintView.Tables["dtOpenInvoice"].NewRow();

                        drOpenInvoiceDetail["ID"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["id"].ToString();
                        drOpenInvoiceDetail["Station"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["station"].ToString();
                        drOpenInvoiceDetail["Node"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["node"].ToString();
                        drOpenInvoiceDetail["Organisation"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["Node"].ToString();
                        drOpenInvoiceDetail["Customer"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["customer_name"].ToString();
                        drOpenInvoiceDetail["DateSold"] =
                            DateTime.Parse(generalResultInformation.searchResult.Rows[rowCounter]["sold_date"].ToString());
                        drOpenInvoiceDetail["Document"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["ref_no"].ToString();
                        drOpenInvoiceDetail["SalesAmount"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["total_amount"].ToString();
                        drOpenInvoiceDetail["RemainingAmount"] =
                            generalResultInformation.searchResult.Rows[rowCounter]["DUE"].ToString();

                        generalResultInformation.dtsDocumentPrintView.Tables["dtOpenInvoice"].Rows.Add(drOpenInvoiceDetail);

                    }

                    generalResultInformation.requestedReport = reportType.OpenInvoice;
                    frmDocPrintPreview frmCRVPrintPreview = new frmDocPrintPreview();
                    frmCRVPrintPreview.ShowDialog();

                }
            }


            this.cmdDiminish_Click(sender, e);
            this.Enabled = true;

        }

        private void tmrUserLogionSession_Tick(object sender, EventArgs e)
        {
            generalResultInformation.logInSessionExpired = true;
            this.tmrUserLogionSession.Enabled = false;
        }
        

        public void MouseMoved(object sender, MouseEventArgs e)
        {
            //labelMousePosition.Text = String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
            if (!this.formAutoHide)
            {
                return;
            }

            if (this.Location.X <= e.X && e.X <= this.Location.X + this.Width &&
                this.Location.Y <= e.Y && e.Y <= this.Location.Y + this.Height)
            {
                this.formMaximize();
            }
            else
            {
                this.formMinimize();
            }
        }
        
        private void ckAutoHidePin_CheckedChanged(object sender, EventArgs e)
        {
            this.formAutoHide = !this.ckAutoHidePin.Checked;

            if (!this.Size.Equals(this.szformOriginalSize))
            {
                this.formMaximize();
            }
            if (this.formAutoHide)
            {
                actHook.Start(true, false);
                this.ckAutoHidePin.Image = new Bitmap(POSDocumentPrinter.Properties.Resources.UnPin);
            }
            else
            {
                actHook.Stop();
                this.ckAutoHidePin.Image = new Bitmap(POSDocumentPrinter.Properties.Resources.pin);
            }
        }
    
    }
}
