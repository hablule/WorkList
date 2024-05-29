using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSDataBridge
{
    public partial class frmPosCompiereBridge : Form
    {
        public frmPosCompiereBridge()
        {
            InitializeComponent();
        }

        #region "Declaration Region"
        checkAndEstablishDbConnectionSettings checkConnections = new checkAndEstablishDbConnectionSettings();
        dataBuilder manageTheDataSynchronisation = new dataBuilder();
        bool POStoCompiereIsRunning = false;
        bool CompiereToPOSIsRunning = false;
        #endregion

        private void fillCompiereRecordChangesToForm()
        {
            this.lblInsertedCustomers.Text = generalResultInformation.synchResultCustomerInsert.ToString();
            this.lblUpdatedCustomers.Text = generalResultInformation.synchResultCustomerUpdate.ToString();
            this.lblDeletedCustomers.Text = generalResultInformation.synchResultCustomerDelete.ToString();

            this.lblInsertedOrders.Text = generalResultInformation.synchResultOrderInsert.ToString();
            this.lblUpdatedOrders.Text = generalResultInformation.synchResultOrderUpdate.ToString();
            this.lblDeletedOrders.Text = generalResultInformation.synchResultOrderDelete.ToString();

            this.lblInsertedOrderLines.Text = generalResultInformation.synchResultOrderLineInsert.ToString();
            this.lblUpdatedOrderLines.Text = generalResultInformation.synchResultOrderLineUpdate.ToString();
            this.lblDeletedOrderLines.Text = generalResultInformation.synchResultOrderLineDelete.ToString();


            this.lblErrorOnCustomers.Text = generalResultInformation.synchResultCustomerErros.ToString();
            this.lblWarnningOnCustomers.Text = generalResultInformation.synchResultCustomerWarnnings.ToString();
            this.lblScriptsOnCustomers.Text = generalResultInformation.synchResultCustomerScripts.ToString();

            this.lblErrorOnOrders.Text = generalResultInformation.synchResultOrderErros.ToString();
            this.lblWarnningOnOrders.Text = generalResultInformation.synchResultOrderWarnnings.ToString();
            this.lblScriptsOnOrders.Text = generalResultInformation.synchResultOrderScripts.ToString();

            this.lblErrorOnOrderLines.Text = generalResultInformation.synchResultOrderLineErros.ToString();
            this.lblWarnningOnOrderLines.Text = generalResultInformation.synchResultOrderLineWarnnings.ToString();
            this.lblScriptsOnOrderLines.Text = generalResultInformation.synchResultOrderLineScripts.ToString();


            this.lblInsertedExemptions.Text = generalResultInformation.synchResultExemptionInsert.ToString();
            this.lblUpdatedExemptions.Text = generalResultInformation.synchResultExemptionUpdate.ToString();
            this.lblDeletedExemptions.Text = generalResultInformation.synchResultExemptionDelete.ToString();

            this.lblInsertedExemptionLine.Text = generalResultInformation.synchResultExemptionLineInsert.ToString();
            this.lblUpdatedExemptionsLine.Text = generalResultInformation.synchResultExemptionLineUpdate.ToString();
            this.lblDeletedExemptionsLine.Text = generalResultInformation.synchResultExemptionLineDelete.ToString();


            this.lblInsertedPayments.Text = generalResultInformation.synchResultPaymentInsert.ToString();
            this.lblUpdatedPayments.Text = generalResultInformation.synchResultPaymentUpdate.ToString();
            this.lblDeletedPayments.Text = generalResultInformation.synchResultPaymentDelete.ToString();

            this.lblInsertedPaymentLines.Text = generalResultInformation.synchResultPaymentLineInsert.ToString();
            this.lblUpdatedPaymentLines.Text = generalResultInformation.synchResultPaymentLineUpdate.ToString();
            this.lblDeletedPaymentLines.Text = generalResultInformation.synchResultPaymentLineDelete.ToString();


            this.lblInsertedAllocations.Text = generalResultInformation.synchResultAllocationInsert.ToString();
            this.lblUpdatedAllocations.Text = generalResultInformation.synchResultAllocationUpdate.ToString();
            this.lblDeletedAllocations.Text = generalResultInformation.synchResultAllocationDelete.ToString();

            this.lblInsertedAllocationLines.Text = generalResultInformation.synchResultAllocationLineInsert.ToString();
            this.lblUpdatedAllocationLines.Text = generalResultInformation.synchResultAllocationLineUpdate.ToString();
            this.lblDeletedAllocationLines.Text = generalResultInformation.synchResultAllocationLineDelete.ToString();


            this.lblInsertedCash.Text = generalResultInformation.synchResultCashInsert.ToString();
            this.lblUpdatedCash.Text = generalResultInformation.synchResultCashUpdate.ToString();
            this.lblDeletedCash.Text = generalResultInformation.synchResultCashDelete.ToString();

            this.lblInsertedCashLine.Text = generalResultInformation.synchResultCashLineInsert.ToString();
            this.lblUpdatedCashLine.Text = generalResultInformation.synchResultCashLineUpdate.ToString();
            this.lblDeletedCashLine.Text = generalResultInformation.synchResultCashLineDelete.ToString();



            this.lblErrorOnExemptions.Text = generalResultInformation.synchResultExemptionErrors.ToString();
            this.lblWarnningOnExemptions.Text = generalResultInformation.synchResultExemptionWarnnings.ToString();
            this.lblScriptsOnExemptions.Text = generalResultInformation.synchResultExemptionScripts.ToString();

            this.lblErrorOnExemptionLine.Text = generalResultInformation.synchResultExemptionLineErrors.ToString();
            this.lblWarnningOnExemptionsLine.Text = generalResultInformation.synchResultExemptionLineWarnnings.ToString();
            this.lblScriptsOnExemptionsLine.Text = generalResultInformation.synchResultExemptionLineScripts.ToString();


            this.lblErrorOnPayments.Text = generalResultInformation.synchResultPaymentErrors.ToString();
            this.lblWarnningOnPayments.Text = generalResultInformation.synchResultPaymentWarnnings.ToString();
            this.lblScriptsOnPayments.Text = generalResultInformation.synchResultPaymentScripts.ToString();

            this.lblErrorOnPaymentLines.Text = generalResultInformation.synchResultPaymentLineErrors.ToString();
            this.lblWarnningOnPaymentLines.Text = generalResultInformation.synchResultPaymentLineWarnnings.ToString();
            this.lblScriptsOnPaymentLines.Text = generalResultInformation.synchResultPaymentLineScripts.ToString();


            this.lblErrorOnAllocations.Text = generalResultInformation.synchResultAllocationErrors.ToString();
            this.lblWarnningOnAllocations.Text = generalResultInformation.synchResultAllocationWarnnings.ToString();
            this.lblScriptsOnAllocations.Text = generalResultInformation.synchResultAllocationScripts.ToString();

            this.lblErrorOnAllocationLines.Text = generalResultInformation.synchResultAllocationLineErrors.ToString();
            this.lblWarnningOnAllocationLines.Text = generalResultInformation.synchResultAllocationLineWarnnings.ToString();
            this.lblScriptsOnAllocationLines.Text = generalResultInformation.synchResultAllocationLineScripts.ToString();


            this.lblErrorOnCash.Text = generalResultInformation.synchResultCashErrors.ToString();
            this.lblWarnningOnCash.Text = generalResultInformation.synchResultCashWarnnings.ToString();
            this.lblScriptsOnCash.Text = generalResultInformation.synchResultCashScripts.ToString();

            this.lblErrorOnCashLine.Text = generalResultInformation.synchResultCashLineErrors.ToString();
            this.lblWarnningOnCashLine.Text = generalResultInformation.synchResultCashLineWarnnings.ToString();
            this.lblScriptsOnCashLine.Text = generalResultInformation.synchResultCashLineScripts.ToString();


        }

        private void fillPOSRecordChangesToForm()
        {
            this.lblInsertedItems.Text = generalResultInformation.synchResultProductInsert.ToString();
            this.lblUpdatedItems.Text = generalResultInformation.synchResultProductUpdate.ToString();
            this.lblDeletedItems.Text = generalResultInformation.synchResultProductDelete.ToString();

            this.lblInsertedProductPrice.Text = generalResultInformation.synchResultPriceInsert.ToString();
            this.lblUpdatedProductPrice.Text = generalResultInformation.synchResultPriceUpdate.ToString();
            this.lblDeletedProductPrice.Text = generalResultInformation.synchResultPriceDelete.ToString();

            this.lblInsertedUOM.Text = generalResultInformation.synchResultUOMInsert.ToString();
            this.lblUpdatedUOM.Text = generalResultInformation.synchResultUOMUpdate.ToString();
            this.lblDeletedUOM.Text = generalResultInformation.synchResultUOMDelete.ToString();

            this.lblInsertedCategories.Text = generalResultInformation.synchResultCatgoryInsert.ToString();
            this.lblUpdatedCategory.Text = generalResultInformation.synchResultCatgoryUpdate.ToString();
            this.lblDeletedCategories.Text = generalResultInformation.synchResultCatgoryDelete.ToString();

            this.lblInsertedLocators.Text = generalResultInformation.synchResultStoreInsert.ToString();
            this.lblUpdatedLocators.Text = generalResultInformation.synchResultStoreUpdate.ToString();
            this.lblDeletedLocators.Text = generalResultInformation.synchResultStoreDelete.ToString();

            this.lblInsertedOrganistion.Text = generalResultInformation.synchResultOrganisationInsert.ToString();
            this.lblUpdatedOrganisation.Text = generalResultInformation.synchResultOrganisationUpdate.ToString();
            this.lblDeletedOrganisation.Text = generalResultInformation.synchResultOrganisationDelete.ToString();

            this.lblInsertedPriceListVersion.Text = generalResultInformation.synchResultPriceVersionInsert.ToString();
            this.lblUpdatedPriceListVersion.Text = generalResultInformation.synchResultPriceVersionUpdate.ToString();
            this.lblDeletedPriceListVersion.Text = generalResultInformation.synchResultPriceVersionDelete.ToString();



            this.lblErrorOnItems.Text = generalResultInformation.synchResultProductErros.ToString();
            this.lblWarnningOnItems.Text = generalResultInformation.synchResultProductWarnnings.ToString();
            this.lblScriptsOnItems.Text = generalResultInformation.synchResultProductScripts.ToString();

            this.lblErrorOnProductPrice.Text = generalResultInformation.synchResultPriceErros.ToString();
            this.lblWarnningOnProductPrice.Text = generalResultInformation.synchResultPriceWarnnings.ToString();
            this.lblScriptsOnProductPrice.Text = generalResultInformation.synchResultPriceScripts.ToString();

            this.lblErrorOnUOM.Text = generalResultInformation.synchResultUOMErros.ToString();
            this.lblWarnningOnUOM.Text = generalResultInformation.synchResultUOMWarnnings.ToString();
            this.lblScriptsOnUOM.Text = generalResultInformation.synchResultUOMScripts.ToString();

            this.lblErrorOnCategories.Text = generalResultInformation.synchResultCatgoryErros.ToString();
            this.lblWarnningOnCategories.Text = generalResultInformation.synchResultCatgoryWarnnings.ToString();
            this.lblScriptsOnCategories.Text = generalResultInformation.synchResultCatgoryScripts.ToString();

            this.lblErrorOnLocators.Text = generalResultInformation.synchResultStoreErros.ToString();
            this.lblWarnningOnLocators.Text = generalResultInformation.synchResultStoreWarnnings.ToString();
            this.lblScriptsOnLocators.Text = generalResultInformation.synchResultStoreScripts.ToString();

            this.lblErrorOnOrganisation.Text = generalResultInformation.synchResultOrganisationErros.ToString();
            this.lblWarnningOnOrganisation.Text = generalResultInformation.synchResultOrganisationWarnnings.ToString();
            this.lblScriptsOnOrganisation.Text = generalResultInformation.synchResultOrganisationScripts.ToString();

            this.lblErrorOnPriceListVersion.Text = generalResultInformation.synchResultPriceVersionErros.ToString();
            this.lblWarnningOnPriceListVersion.Text = generalResultInformation.synchResultPriceVersionWarnnings.ToString();
            this.lblScriptsOnPriceListVersion.Text = generalResultInformation.synchResultPriceVersionScripts.ToString();

        }

        delegate void SetLableTextCallback(Label _lable, string text, KnownColor _color);

        private void setLableText(Label _lable, string _text, KnownColor _color)
        {
            if (_lable.InvokeRequired)
            {
                SetLableTextCallback recallFunctionWith = new SetLableTextCallback(setLableText);
                this.Invoke(recallFunctionWith, new object[] { _lable, _text, _color });
            }
            else
            {
                _lable.Text = _text;
                _lable.ForeColor = Color.FromKnownColor(_color);
            }
        }


        private void frmPosCompiereBridge_Load(object sender, EventArgs e)
        {
            if (!checkConnections.establishDbConnectionSettins(this))
            {               
                Application.Exit();
            }                        
            this.tmrCompToPOSTimeSyncTimeController.Interval = 
                dbSettingInformationHandler.compSyncTimeInterval*60000;
            this.tmrPOSTOCompTimeSyncTimeController.Interval = 
                dbSettingInformationHandler.posSyncTimeInterval * 60000;

            if (dbSettingInformationHandler.compAutoStartSynch)
            {
                this.mnuStartCompiereToPOS_Click(sender, e);                
            }
            else
            {
                this.mnuStopCompiereToPOS_Click(sender, e);
            }

            if (dbSettingInformationHandler.posAutoStartSynch)
            {
                this.mnuStartPOSToCompiere_Click(sender, e);
            }
            else
            {
                this.mnuStopPOSToCompiere_Click(sender, e);
            }
        }

        private void frmPosCompiereBridge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {   
                Application.Exit();
            }
        }
        

        private void tmrCompToPOSTimeSyncTimeController_Tick(object sender, EventArgs e)
        {            
            if (!this.CompiereToPOSIsRunning)
            {
                this.CompiereToPOSIsRunning = true;
                this.setLableText(this.lblCompierePOSStatus, "ON", KnownColor.LawnGreen);                
                this.setLableText(this.lblCompierePOSStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
                //this.lblCompierePOSStatus.Text = "ON";
                //this.lblCompierePOSStartTime.Text = DateTime.Now.ToString("HH:mm:ss");
                //this.lblCompierePOSStatus.ForeColor = Color.FromKnownColor(KnownColor.LawnGreen);
                this.bkwCompiereToPOSDataMapController.RunWorkerAsync();
            }
        }

        private void tmrPOSTOCompTimeSyncTimeController_Tick(object sender, EventArgs e)
        {
            if (!this.POStoCompiereIsRunning)
            {
                this.POStoCompiereIsRunning = true;
                this.setLableText(this.lblPosCompiereStatus, "ON", KnownColor.LawnGreen);
                this.setLableText(this.lblPosCompiereStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
                //this.lblPosCompiereStatus.Text = "ON";
                //this.lblPosCompiereStatus.ForeColor = Color.FromKnownColor(KnownColor.LawnGreen);
                //this.lblPosCompiereStartTime.Text = DateTime.Now.ToString("HH:mm:ss");
                this.bkwPOSToCompiereDataMapController.RunWorkerAsync();
            }
        }
        

        private void bkwCompiereToPOSDataMapController_DoWork(object sender, DoWorkEventArgs e)
        {                       
            
            dataBuilder startCompSync = new dataBuilder();
            startCompSync.synchroniseDataFromCompiereToPOS(this.bkwCompiereToPOSDataMapController);

            if (this.bkwCompiereToPOSDataMapController.CancellationPending)
            {
                e.Cancel = true;
            }            
        }

        private void bkwCompiereToPOSDataMapController_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.fillPOSRecordChangesToForm();
        }

        private void bkwCompiereToPOSDataMapController_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.CompiereToPOSIsRunning = false;
            if (!this.mnuStartCompiereToPOS.Enabled)
            {
                this.lblCompierePOSStatus.Text = "Waiting";
                this.lblCompierePOSStatus.ForeColor =
                    Color.FromKnownColor(KnownColor.OrangeRed);
            }
        }



        private void bkwPOSToCompiereDataMapController_DoWork(object sender, DoWorkEventArgs e)
        {            
            dataBuilder startCompSync = new dataBuilder();
            startCompSync.synchroniseDataFromPOSToCompiere(this.bkwPOSToCompiereDataMapController);

            if (this.bkwPOSToCompiereDataMapController.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bkwPOSToCompiereDataMapController_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.fillCompiereRecordChangesToForm();
        }

        private void bkwPOSToCompiereDataMapController_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.POStoCompiereIsRunning = false;
            if (!this.mnuStartPOSToCompiere.Enabled)
            {
                this.lblPosCompiereStatus.Text = "Waiting";
                this.lblPosCompiereStatus.ForeColor =
                    Color.FromKnownColor(KnownColor.OrangeRed);
            }
        }


        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmsettings settingForm = new frmsettings();
            this.WindowState = FormWindowState.Minimized;
            settingForm.ShowDialog();
            checkAndEstablishDbConnectionSettings reEstablishConnections =
                new checkAndEstablishDbConnectionSettings();
            if (!reEstablishConnections.establishDbConnectionSettins(this))
            {
                Application.Exit();
            }
            this.WindowState = FormWindowState.Normal;

        }
        

        private void mnuStartPOSToCompiere_Click(object sender, EventArgs e)
        {
            if (!this.mnuStartPOSToCompiere.Enabled)
                return;
            this.tmrPOSTOCompTimeSyncTimeController.Enabled = true;
            this.tmrPOSTOCompTimeSyncTimeController_Tick(sender, e);

            this.mnuStartPOSToCompiere.Enabled = false;
            this.mnuStopPOSToCompiere.Enabled = true;

            if (!this.mnuStartCompiereToPOS.Enabled)
            {
                this.mnuStartBoth.Enabled = false;
                this.mnuStopBoth.Enabled = true;
            }   
        }

        private void mnuStartCompiereToPOS_Click(object sender, EventArgs e)
        {
            if (!this.mnuStartCompiereToPOS.Enabled)
                return;
            this.tmrCompToPOSTimeSyncTimeController.Enabled = true;
            this.tmrCompToPOSTimeSyncTimeController_Tick(sender, e);

            this.mnuStartCompiereToPOS.Enabled = false;
            this.mnuStopCompiereToPOS.Enabled = true;

            if (!this.mnuStartPOSToCompiere.Enabled)
            {
                this.mnuStartBoth.Enabled = false;                
                this.mnuStopBoth.Enabled = true;
            }
   
        }
        
        private void mnuStartBoth_Click(object sender, EventArgs e)
        {
            this.mnuStartPOSToCompiere_Click(sender, e);
            this.mnuStartCompiereToPOS_Click(sender, e);            
        }


        private void mnuStopPOSToCompiere_Click(object sender, EventArgs e)
        {
            if (!this.mnuStopPOSToCompiere.Enabled)
                return;
            this.tmrPOSTOCompTimeSyncTimeController.Enabled = false;
            this.bkwPOSToCompiereDataMapController.CancelAsync();

            this.mnuStartPOSToCompiere.Enabled = true;
            this.mnuStopPOSToCompiere.Enabled = false;

            if (!this.mnuStopCompiereToPOS.Enabled)
            {
                this.mnuStartBoth.Enabled = true;
                this.mnuStopBoth.Enabled = false;
            }
            this.setLableText(this.lblPosCompiereStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
            this.setLableText(this.lblPosCompiereStatus, "OFF", KnownColor.Red);
        }

        private void mnuStopCompiereToPOS_Click(object sender, EventArgs e)
        {
            if (!this.mnuStopCompiereToPOS.Enabled)
                return;
            this.tmrCompToPOSTimeSyncTimeController.Enabled = false;
            this.bkwPOSToCompiereDataMapController.CancelAsync();

            this.mnuStartCompiereToPOS.Enabled = true;
            this.mnuStopCompiereToPOS.Enabled = false;

            if (!this.mnuStopPOSToCompiere.Enabled)
            {
                this.mnuStartBoth.Enabled = true;
                this.mnuStopBoth.Enabled = false;
            }
            this.setLableText(this.lblCompierePOSStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
            this.setLableText(this.lblCompierePOSStatus, "OFF", KnownColor.Red);
        }

        private void mnuStopBoth_Click(object sender, EventArgs e)
        {
            this.mnuStopCompiereToPOS_Click(sender, e);
            this.mnuStopPOSToCompiere_Click(sender, e);
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.mnuStopBoth_Click(sender, e);
            FormClosingEventArgs eventArgument = new FormClosingEventArgs
                (CloseReason.ApplicationExitCall, false);
            this.frmPosCompiereBridge_FormClosing(sender, eventArgument);
        }


        private void cmnuOpenControl_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }


        private void cmnuStartPOStoCompiere_Click(object sender, EventArgs e)
        {
            this.mnuStartPOSToCompiere_Click(sender, e);            
        }

        private void cmnuStartCompiereToPOS_Click(object sender, EventArgs e)
        {
            this.mnuStartCompiereToPOS_Click(sender, e);
        }

        private void cmnuStartBoth_Click(object sender, EventArgs e)
        {
            this.mnuStopBoth_Click(sender, e);
        }


        private void cmnuStopPOStoCompiere_Click(object sender, EventArgs e)
        {
            this.mnuStopPOSToCompiere_Click(sender, e);
        }

        private void cmnuStopCompiereToPOS_Click(object sender, EventArgs e)
        {
            this.mnuStopCompiereToPOS_Click(sender, e);
        }

        private void cmnuStopBoth_Click(object sender, EventArgs e)
        {
            this.mnuStopBoth_Click(sender, e);
        }


        private void cmnuExit_Click(object sender, EventArgs e)
        {
            this.mnuExit_Click(sender, e);            
        }



        private void mnuCleanPOSSequence_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You would like to clean Pos" +
                                " change sequence tracker.",
                                "POS bridge", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;                
            
            this.Enabled = false;

            string migrateAllCommitedRecordsToDuplicateDicationary =
                "INSERT INTO `UTL_CHANGE_ORDER_BKP` "+ 
                "SELECT * FROM `UTL_CHANGE_ORDER` WHERE `STATUS` = 'COMMITED'";
            string cleanCommitedRecordsFromPOSSequenceTable =
                "DELETE FROM `UTL_CHANGE_ORDER` WHERE `STATUS` = 'COMMITED'";

            if (this.POStoCompiereIsRunning)
            {
            stopPOSDataMapping:
                this.mnuStopPOSToCompiere_Click(sender, e);
                if (this.POStoCompiereIsRunning)
                    goto stopPOSDataMapping;

                this.manageTheDataSynchronisation.executeSqlOnPOS
                    (migrateAllCommitedRecordsToDuplicateDicationary);
                if (!dbCommitFailure.dbCommitError)
                {
                    this.manageTheDataSynchronisation.executeSqlOnPOS
                        (cleanCommitedRecordsFromPOSSequenceTable);
                }
                else
                {
                    MessageBox.Show("Unable to conduct clean up with error msg \n {" 
                            + dbCommitFailure.dbCommitErrorMessage + "}.", 
                            "POS bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.mnuStartPOSToCompiere_Click(sender, e);
                    this.Enabled = true;
                    return;                    
                }

                this.mnuStartPOSToCompiere_Click(sender, e);
            }
            else
            {
                this.manageTheDataSynchronisation.executeSqlOnPOS
                    (migrateAllCommitedRecordsToDuplicateDicationary);
                if (!dbCommitFailure.dbCommitError)
                {
                    this.manageTheDataSynchronisation.executeSqlOnPOS
                        (cleanCommitedRecordsFromPOSSequenceTable);
                }
                else
                {
                    MessageBox.Show("Unable to conduct clean up with error msg \n {"
                            + dbCommitFailure.dbCommitErrorMessage + "}.",
                            "POS bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
            }
            this.Enabled = true;
        }

        private void mnuCleanCompiereSequence_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You would like to clean Compiere" +
                                " change sequence tracker.",
                                "POS bridge", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            this.Enabled = false;

            string migrateAllCommitedRecordsToDuplicateDicationary =
                "INSERT INTO DUP_DMLSEQUENCE_BKP " +
                "SELECT * FROM DUP_DMLSEQUENCE WHERE STATUS = 'COMMITED'";
            string cleanCommitedRecordsFromPOSSequenceTable =
                "DELETE FROM DUP_DMLSEQUENCE WHERE STATUS = 'COMMITED'";

            if (this.CompiereToPOSIsRunning)
            {
            stopCompiereDataMapping:
                this.mnuStopCompiereToPOS_Click(sender, e);
                if (this.CompiereToPOSIsRunning)
                    goto stopCompiereDataMapping;

                this.manageTheDataSynchronisation.executeSqlOnCompiere
                    (migrateAllCommitedRecordsToDuplicateDicationary);
                if (!dbCommitFailure.dbCommitError)
                {
                    this.manageTheDataSynchronisation.executeSqlOnCompiere
                        (cleanCommitedRecordsFromPOSSequenceTable);
                }
                else
                {
                    MessageBox.Show("Unable to conduct clean up with error msg \n {"
                            + dbCommitFailure.dbCommitErrorMessage + "}.",
                            "POS bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.mnuStartCompiereToPOS_Click(sender, e);
                    this.Enabled = true;
                    return;
                }
                this.mnuStartCompiereToPOS_Click(sender, e);
            }
            else
            {
                this.manageTheDataSynchronisation.executeSqlOnCompiere
                    (migrateAllCommitedRecordsToDuplicateDicationary);
                if (!dbCommitFailure.dbCommitError)
                {
                    this.manageTheDataSynchronisation.executeSqlOnCompiere
                        (cleanCommitedRecordsFromPOSSequenceTable);
                }
                else
                {
                    MessageBox.Show("Unable to conduct clean up with error msg \n {"
                            + dbCommitFailure.dbCommitErrorMessage + "}.",
                            "POS bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
            }
            this.Enabled = true;
        }

        
    }
}
