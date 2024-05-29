using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyMoveDataBridge
{
    public partial class frmEasyMoveCompiereBridge : Form
    {
        public frmEasyMoveCompiereBridge()
        {
            InitializeComponent();
        }

        #region "Declaration Region"
        checkAndEstablishDbConnectionSettings checkConnections = new checkAndEstablishDbConnectionSettings();
        dataBuilder manageTheDataSynchronisation = new dataBuilder();
        bool EasyMovetoCompiereIsRunning = false;
        bool CompiereToEasyMoveIsRunning = false;
        bool EasyMoveBridgeAleadyRunnig = false;
        #endregion

        private void fillCompiereRecordChangesToForm()
        {
            this.lblInsertedMovement.Text = generalResultInformation.synchResultMovementInsert.ToString();
            this.lblUpdatedMovement.Text = generalResultInformation.synchResultMovementUpdate.ToString();
            this.lblDeletedMovement.Text = generalResultInformation.synchResultMovementDelete.ToString();

            this.lblInsertedMovementLine.Text = generalResultInformation.synchResultMovementLineInsert.ToString();
            this.lblUpdatedMovementLine.Text = generalResultInformation.synchResultMovementLineUpdate.ToString();
            this.lblDeletedMovementLine.Text = generalResultInformation.synchResultMovementLineDelete.ToString();
            

            this.lblErrorOnMovement.Text = generalResultInformation.synchResultMovementErros.ToString();
            this.lblWarnningOnMovement.Text = generalResultInformation.synchResultMovementWarnnings.ToString();
            this.lblScriptsOnMovement.Text = generalResultInformation.synchResultMovementScripts.ToString();

            this.lblErrorOnMovementLine.Text = generalResultInformation.synchResultMovementLineErros.ToString();
            this.lblWarnningOnMovementLine.Text = generalResultInformation.synchResultMovementLineWarnnings.ToString();
            this.lblScriptsOnMovementLine.Text = generalResultInformation.synchResultMovementLineScripts.ToString();


            this.lblInsertedInOut.Text = generalResultInformation.synchResultInOutInsert.ToString();
            this.lblUpdatedInOut.Text = generalResultInformation.synchResultInOutUpdate.ToString();
            this.lblDeletedInOut.Text = generalResultInformation.synchResultInOutDelete.ToString();

            this.lblInsertedInOutLine.Text = generalResultInformation.synchResultInOutLineInsert.ToString();
            this.lblUpdatedInOutLine.Text = generalResultInformation.synchResultInOutLineUpdate.ToString();
            this.lblDeletedInOutLine.Text = generalResultInformation.synchResultInOutLineDelete.ToString();


            this.lblErrorOnInOut.Text = generalResultInformation.synchResultInOutErros.ToString();
            this.lblWarnningOnInOut.Text = generalResultInformation.synchResultInOutWarnnings.ToString();
            this.lblScriptsOnInOut.Text = generalResultInformation.synchResultInOutScripts.ToString();

            this.lblErrorOnInOutLine.Text = generalResultInformation.synchResultInOutLineErros.ToString();
            this.lblWarnningOnInOutLine.Text = generalResultInformation.synchResultInOutLineWarnnings.ToString();
            this.lblScriptsOnInOutLine.Text = generalResultInformation.synchResultInOutLineScripts.ToString();


            this.lblInsertedProduction.Text = generalResultInformation.synchResultProductionInsert.ToString();
            this.lblUpdatedProduction.Text = generalResultInformation.synchResultProductionUpdate.ToString();
            this.lblDeletedProduction.Text = generalResultInformation.synchResultProductionDelete.ToString();

            this.lblInsertedProductionPlan.Text = generalResultInformation.synchResultProductionPlanInsert.ToString();
            this.lblUpdatedProductionPlan.Text = generalResultInformation.synchResultProductionPlanUpdate.ToString();
            this.lblDeletedProductionPlan.Text = generalResultInformation.synchResultProductionPlanDelete.ToString();

            this.lblInsertedProductionLine.Text = generalResultInformation.synchResultProductionLineInsert.ToString();
            this.lblUpdatedProductionLine.Text = generalResultInformation.synchResultProductionLineUpdate.ToString();
            this.lblDeletedProductionLine.Text = generalResultInformation.synchResultProductionLineDelete.ToString();


            this.lblErrorOnProduction.Text = generalResultInformation.synchResultProductionErros.ToString();
            this.lblWarnningOnProduction.Text = generalResultInformation.synchResultProductionWarnnings.ToString();
            this.lblScriptsOnProduction.Text = generalResultInformation.synchResultProductionScripts.ToString();

            this.lblErrorOnProductionPlan.Text = generalResultInformation.synchResultProductionPlanErros.ToString();
            this.lblWarnningOnProductionPlan.Text = generalResultInformation.synchResultProductionPlanWarnnings.ToString();
            this.lblScriptsOnProductionPlan.Text = generalResultInformation.synchResultProductionPlanScripts.ToString();

            this.lblErrorOnProductionLine.Text = generalResultInformation.synchResultProductionLineErros.ToString();
            this.lblWarnningOnProductionLine.Text = generalResultInformation.synchResultProductionLineWarnnings.ToString();
            this.lblScriptsOnProductionLine.Text = generalResultInformation.synchResultProductionLineScripts.ToString();

        }

        private void fillEasyMoveRecordChangesToForm()
        {
            this.lblInsertedItems.Text = generalResultInformation.synchResultProductInsert.ToString();
            this.lblUpdatedItems.Text = generalResultInformation.synchResultProductUpdate.ToString();
            this.lblDeletedItems.Text = generalResultInformation.synchResultProductDelete.ToString();

            this.lblInsertedBOMs.Text = generalResultInformation.synchResultBOMInsert.ToString();
            this.lblUpdatedBOMs.Text = generalResultInformation.synchResultBOMUpdate.ToString();
            this.lblDeletedBOMs.Text = generalResultInformation.synchResultBOMDelete.ToString();

            this.lblInsertedUserOrgAccess.Text = generalResultInformation.synchResultUserOrgAccessInsert.ToString();
            this.lblUpdatedUserOrgAccess.Text = generalResultInformation.synchResultUserOrgAccessUpdate.ToString();
            this.lblDeletedUserOrgAccess.Text = generalResultInformation.synchResultUserOrgAccessDelete.ToString();

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

            this.lblInsertedUser.Text = generalResultInformation.synchResultUserInsert.ToString();
            this.lblUpdatedUser.Text = generalResultInformation.synchResultUserUpdate.ToString();
            this.lblDeletedUser.Text = generalResultInformation.synchResultUserDelete.ToString();

            this.lblInsertedDocumentType.Text = generalResultInformation.synchResultDocumentTypeInsert.ToString();
            this.lblUpdatedDocumentType.Text = generalResultInformation.synchResultDocumentTypeUpdate.ToString();
            this.lblDeletedDocumentType.Text = generalResultInformation.synchResultDocumentTypeDelete.ToString();

            this.lblInsertedWarehouse.Text = generalResultInformation.synchResultWarehouseInsert.ToString();
            this.lblUpdatedWarehouse.Text = generalResultInformation.synchResultWarehouseUpdate.ToString();
            this.lblDeletedWarehouse.Text = generalResultInformation.synchResultWarehouseDelete.ToString();

            this.lblInsertedClient.Text = generalResultInformation.synchResultClientInsert.ToString();
            this.lblUpdatedClient.Text = generalResultInformation.synchResultClientUpdate.ToString();
            this.lblDeletedClient.Text = generalResultInformation.synchResultClientDelete.ToString();




            this.lblErrorOnItems.Text = generalResultInformation.synchResultProductErros.ToString();
            this.lblWarnningOnItems.Text = generalResultInformation.synchResultProductWarnnings.ToString();
            this.lblScriptsOnItems.Text = generalResultInformation.synchResultProductScripts.ToString();

            this.lblErrorOnBOMs.Text = generalResultInformation.synchResultBOMErros.ToString();
            this.lblWarnningOnBOMs.Text = generalResultInformation.synchResultBOMWarnnings.ToString();
            this.lblScriptsOnBOMs.Text = generalResultInformation.synchResultBOMScripts.ToString();

            this.lblErrorOnUserOrgAccess.Text = generalResultInformation.synchResultUserOrgAccessErros.ToString();
            this.lblWarnningOnUserOrgAccess.Text = generalResultInformation.synchResultUserOrgAccessWarnnings.ToString();
            this.lblScriptsOnUserOrgAccess.Text = generalResultInformation.synchResultUserOrgAccessScripts.ToString();

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

            this.lblErrorOnUser.Text = generalResultInformation.synchResultUserErros.ToString();
            this.lblWarnningOnUser.Text = generalResultInformation.synchResultUserWarnnings.ToString();
            this.lblScriptsOnUser.Text = generalResultInformation.synchResultUserScripts.ToString();

            this.lblErrorOnDocumentType.Text = generalResultInformation.synchResultDocumentTypeErros.ToString();
            this.lblWarnningOnDocumentType.Text = generalResultInformation.synchResultDocumentTypeWarnnings.ToString();
            this.lblScriptsOnDocumentType.Text = generalResultInformation.synchResultDocumentTypeScripts.ToString();

            this.lblErrorOnWarehouse.Text = generalResultInformation.synchResultWarehouseErros.ToString();
            this.lblWarnningOnWarehouse.Text = generalResultInformation.synchResultWarehouseWarnnings.ToString();
            this.lblScriptsOnWarehouse.Text = generalResultInformation.synchResultWarehouseScripts.ToString();

            this.lblErrorOnClient.Text = generalResultInformation.synchResultClientErros.ToString();
            this.lblWarnningOnClient.Text = generalResultInformation.synchResultClientWarnnings.ToString();
            this.lblScriptsOnClient.Text = generalResultInformation.synchResultClientScripts.ToString();

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


        private void frmEasyMoveCompiereBridge_Load(object sender, EventArgs e)
        {
            if (!checkConnections.establishDbConnectionSettins(this))
            {               
                Application.Exit();
                return;
            }
            //System.IO.File.Create("easyMoveRun");
            this.tmrCompToEasyMoveTimeSyncTimeController.Interval = 
                dbSettingInformationHandler.compSyncTimeInterval*60000;
            this.tmrEasyMoveTOCompTimeSyncTimeController.Interval = 
                dbSettingInformationHandler.easyMoveSyncTimeInterval * 60000;

            if (dbSettingInformationHandler.compAutoStartSynch)
            {
                this.mnuStartCompiereToEasyMove_Click(sender, e);
            }
            else
            {
                this.mnuStopCompiereToEasyMove_Click(sender, e);
            }

            if (dbSettingInformationHandler.easyMoveAutoStartSynch)
            {
                this.mnuStartEasyMoveToCompiere_Click(sender, e);
            }
            else
            {
                this.mnuStopEasyMoveToCompiere_Click(sender, e);
            }
        }

        private void frmEasyMoveCompiereBridge_FormClosing(object sender, FormClosingEventArgs e)
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
                //System.IO.File.Delete("easyMoveRun");
                Application.Exit();
            }
        }
        

        private void tmrCompToEasyMoveTimeSyncTimeController_Tick(object sender, EventArgs e)
        {            
            if (!this.CompiereToEasyMoveIsRunning)
            {
                this.CompiereToEasyMoveIsRunning = true;
                this.setLableText(this.lblCompiereEasyMoveStatus, "ON", KnownColor.LawnGreen);                
                this.setLableText(this.lblCompiereEasyMoveStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);                
                this.bkwCompiereToEasyMoveDataMapController.RunWorkerAsync();
            }
        }

        private void tmrEasyMoveTOCompTimeSyncTimeController_Tick(object sender, EventArgs e)
        {
            if (!this.EasyMovetoCompiereIsRunning)
            {
                this.EasyMovetoCompiereIsRunning = true;
                this.setLableText(this.lblEasyMoveCompiereStatus, "ON", KnownColor.LawnGreen);
                this.setLableText(this.lblEasyMoveCompiereStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
                this.bkwEasyMoveToCompiereDataMapController.RunWorkerAsync();
            }
        }


        private void bkwCompiereToEasyMoveDataMapController_DoWork(object sender, DoWorkEventArgs e)
        {                       
            
            dataBuilder startCompSync = new dataBuilder();
            startCompSync.synchroniseDataFromCompiereToEasyMove(this.bkwCompiereToEasyMoveDataMapController);

            if (this.bkwCompiereToEasyMoveDataMapController.CancellationPending)
            {
                e.Cancel = true;
            }            
        }

        private void bkwCompiereToEasyMoveDataMapController_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.fillEasyMoveRecordChangesToForm();
        }

        private void bkwCompiereToEasyMoveDataMapController_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.CompiereToEasyMoveIsRunning = false;
            if (!this.mnuStartCompiereToEasyMove.Enabled)
            {
                this.lblCompiereEasyMoveStatus.Text = "Waiting";
                this.lblCompiereEasyMoveStatus.ForeColor =
                    Color.FromKnownColor(KnownColor.OrangeRed);
            }
        }



        private void bkwEasyMoveToCompiereDataMapController_DoWork(object sender, DoWorkEventArgs e)
        {            
            dataBuilder startCompSync = new dataBuilder();
            startCompSync.synchroniseDataFromEasyMoveToCompiere(this.bkwEasyMoveToCompiereDataMapController);

            if (this.bkwEasyMoveToCompiereDataMapController.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bkwEasyMoveToCompiereDataMapController_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.fillCompiereRecordChangesToForm();
        }

        private void bkwEasyMoveToCompiereDataMapController_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.EasyMovetoCompiereIsRunning = false;
            if (!this.mnuStartEasyMoveToCompiere.Enabled)
            {
                this.lblEasyMoveCompiereStatus.Text = "Waiting";
                this.lblEasyMoveCompiereStatus.ForeColor =
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


        private void mnuStartEasyMoveToCompiere_Click(object sender, EventArgs e)
        {
            if (!this.mnuStartEasyMoveToCompiere.Enabled)
                return;
            this.tmrEasyMoveTOCompTimeSyncTimeController.Enabled = true;
            this.tmrEasyMoveTOCompTimeSyncTimeController_Tick(sender, e);

            this.mnuStartEasyMoveToCompiere.Enabled = false;
            this.mnuStopEasyMoveToCompiere.Enabled = true;

            if (!this.mnuStartCompiereToEasyMove.Enabled)
            {
                this.mnuStartBoth.Enabled = false;
                this.mnuStopBoth.Enabled = true;
            }   
        }

        private void mnuStartCompiereToEasyMove_Click(object sender, EventArgs e)
        {
            if (!this.mnuStartCompiereToEasyMove.Enabled)
                return;
            this.tmrCompToEasyMoveTimeSyncTimeController.Enabled = true;
            this.tmrCompToEasyMoveTimeSyncTimeController_Tick(sender, e);

            this.mnuStartCompiereToEasyMove.Enabled = false;
            this.mnuStopCompiereToEasyMove.Enabled = true;

            if (!this.mnuStartEasyMoveToCompiere.Enabled)
            {
                this.mnuStartBoth.Enabled = false;                
                this.mnuStopBoth.Enabled = true;
            }
   
        }
        
        private void mnuStartBoth_Click(object sender, EventArgs e)
        {
            this.mnuStartEasyMoveToCompiere_Click(sender, e);
            this.mnuStartCompiereToEasyMove_Click(sender, e);            
        }


        private void mnuStopEasyMoveToCompiere_Click(object sender, EventArgs e)
        {
            if (!this.mnuStopEasyMoveToCompiere.Enabled)
                return;
            this.tmrEasyMoveTOCompTimeSyncTimeController.Enabled = false;
            this.bkwEasyMoveToCompiereDataMapController.CancelAsync();

            this.mnuStartEasyMoveToCompiere.Enabled = true;
            this.mnuStopEasyMoveToCompiere.Enabled = false;

            if (!this.mnuStopCompiereToEasyMove.Enabled)
            {
                this.mnuStartBoth.Enabled = true;
                this.mnuStopBoth.Enabled = false;
            }
            this.setLableText(this.lblEasyMoveCompiereStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
            this.setLableText(this.lblEasyMoveCompiereStatus, "OFF", KnownColor.Red);
        }

        private void mnuStopCompiereToEasyMove_Click(object sender, EventArgs e)
        {
            if (!this.mnuStopCompiereToEasyMove.Enabled)
                return;
            this.tmrCompToEasyMoveTimeSyncTimeController.Enabled = false;
            this.bkwEasyMoveToCompiereDataMapController.CancelAsync();

            this.mnuStartCompiereToEasyMove.Enabled = true;
            this.mnuStopCompiereToEasyMove.Enabled = false;

            if (!this.mnuStopEasyMoveToCompiere.Enabled)
            {
                this.mnuStartBoth.Enabled = true;
                this.mnuStopBoth.Enabled = false;
            }
            this.setLableText(this.lblCompiereEasyMoveStartTime, DateTime.Now.ToString("HH:mm:ss"),
                    KnownColor.Black);
            this.setLableText(this.lblCompiereEasyMoveStatus, "OFF", KnownColor.Red);
        }

        private void mnuStopBoth_Click(object sender, EventArgs e)
        {
            this.mnuStopCompiereToEasyMove_Click(sender, e);
            this.mnuStopEasyMoveToCompiere_Click(sender, e);
        }



        private void mnuCleanEasyMoveSequecnce_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You would like to clean EasyMove" +
                                " change sequence tracker.",
                                "EasyMove bridge", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            this.Enabled = false;

            string migrateAllCommitedRecordsToDuplicateDicationary =
                "INSERT INTO `EM_MOVE_SYNCH_STATUS_BKP` " +
                "SELECT * FROM `EM_MOVE_SYNCH_STATUS` WHERE `STATUS` = 'COMMITED'";
            string cleanCommitedRecordsFromPOSSequenceTable =
                "DELETE FROM `EM_MOVE_SYNCH_STATUS` WHERE `STATUS` = 'COMMITED'";

            if (this.EasyMovetoCompiereIsRunning)
            {
            stopEasyMoveDataMapping:
                this.mnuStopEasyMoveToCompiere_Click(sender, e);
                if (this.EasyMovetoCompiereIsRunning)
                    goto stopEasyMoveDataMapping;

                this.manageTheDataSynchronisation.executeSqlOnEsayMove
                    (migrateAllCommitedRecordsToDuplicateDicationary);
                if (!dbCommitFailure.dbCommitError)
                {
                    this.manageTheDataSynchronisation.executeSqlOnEsayMove
                        (cleanCommitedRecordsFromPOSSequenceTable);
                }
                else
                {
                    MessageBox.Show("Unable to conduct clean up with error msg \n {"
                            + dbCommitFailure.dbCommitErrorMessage + "}.",
                            "EasyMove bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.mnuStartEasyMoveToCompiere_Click(sender, e);
                    this.Enabled = true;
                    return;
                }
                this.mnuStartEasyMoveToCompiere_Click(sender, e);
            }
            else
            {
                this.manageTheDataSynchronisation.executeSqlOnEsayMove
                    (migrateAllCommitedRecordsToDuplicateDicationary);
                if (!dbCommitFailure.dbCommitError)
                {
                    this.manageTheDataSynchronisation.executeSqlOnEsayMove
                        (cleanCommitedRecordsFromPOSSequenceTable);
                }
                else
                {
                    MessageBox.Show("Unable to conduct clean up with error msg \n {"
                            + dbCommitFailure.dbCommitErrorMessage + "}.",
                            "EasyMove bridge", MessageBoxButtons.OK,
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
                                "EasyMove bridge", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            this.Enabled = false;

            string migrateAllCommitedRecordsToDuplicateDicationary =
                "INSERT INTO DUP_EM_DMLSEQUENCE_BKP " +
                "SELECT * FROM DUP_EM_DMLSEQUENCE WHERE STATUS = 'COMMITED'";
            string cleanCommitedRecordsFromPOSSequenceTable =
                "DELETE FROM DUP_EM_DMLSEQUENCE WHERE STATUS = 'COMMITED'";

            if (this.CompiereToEasyMoveIsRunning)
            {
            stopCompiereDataMapping:
                this.mnuStopCompiereToEasyMove_Click(sender, e);
                if (this.CompiereToEasyMoveIsRunning)
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
                            "EasyMove bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.mnuStartCompiereToEasyMove_Click(sender, e);
                    this.Enabled = true;
                    return;
                }
                this.mnuStartCompiereToEasyMove_Click(sender, e);
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
                            "EasyMove bridge", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
            }
            this.Enabled = true;
        }

        

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.mnuStopBoth_Click(sender, e);
            FormClosingEventArgs eventArgument = new FormClosingEventArgs
                (CloseReason.ApplicationExitCall, false);
            this.frmEasyMoveCompiereBridge_FormClosing(sender, eventArgument);
        }


        private void cmnuOpenControl_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }


        private void cmnuStartEasyMovetoCompiere_Click(object sender, EventArgs e)
        {
            this.mnuStartEasyMoveToCompiere_Click(sender, e);            
        }

        private void cmnuStartCompiereToEasyMove_Click(object sender, EventArgs e)
        {
            this.mnuStartCompiereToEasyMove_Click(sender, e);
        }

        private void cmnuStartBoth_Click(object sender, EventArgs e)
        {
            this.mnuStopBoth_Click(sender, e);
        }


        private void cmnuStopEasyMovetoCompiere_Click(object sender, EventArgs e)
        {
            this.mnuStopEasyMoveToCompiere_Click(sender, e);
        }

        private void cmnuStopCompiereToEasyMove_Click(object sender, EventArgs e)
        {
            this.mnuStopCompiereToEasyMove_Click(sender, e);
        }

        private void cmnuStopBoth_Click(object sender, EventArgs e)
        {
            this.mnuStopBoth_Click(sender, e);
        }


        private void cmnuExit_Click(object sender, EventArgs e)
        {
            this.mnuExit_Click(sender, e);            
        }


                 
                
    }
}
