using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMoveDataBridge
{
    enum triaStateBool
    {
        yes,
        no,
        Ignor
    }

    enum changeStatus 
    {
        UNKOWN,
        PENDING,
        ERROR,
        SYNCHRONISED
    }

    enum changeType 
    {
        UNKOWN,
        IN,//Insert
        UP,//Update
        DL//Delete
    }

    enum logType
    {
        UNKOWN,
        warnning,//Insert
        error,//Update
        script//Delete
    }

    class dbSettingInformationHandler
    {
        public static string settingFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");//"settings.xml";

        public static string compDataBaseType = "Oracle";
        public static string compHostName = "";
        public static string compDataBaseName = "";
        public static string compDBUsername = "";
        public static string compDBPassword = "";
        public static string compScriptDirectory = "";
        public static string compWarningDirectory = "";
        public static string compErrorDirectory = "";
        public static string compDBPort = "";
        public static bool compLogChangeScript = true;
        public static bool compAutoStartSynch = true;
        public static int compSyncTimeInterval = 0;
        public static int compiereToPOSWarning = 0;
        public static int compiereToPOSError = 0;

        
        public static string easyMoveDataBaseType = "MySql";
        public static string easyMoveHostName = "";
        public static string easyMoveDataBaseName = "";
        public static string easyMoveDBUserName = "";
        public static string easyMoveDBPassword = "";
        public static string easyMoveScriptDirectory = "";
        public static string easyMoveWarningDirectory = "";
        public static string easyMoveErrorDirectory = "";
        public static string easyMoveDBPort = "";
        public static bool easyMoveLogChangeScript = true;
        public static bool easyMoveAutoStartSynch = true;
        public static int easyMoveSyncTimeInterval = 0;
        public static int easyMoveToCompiereWarning = 0;
        public static int easyMoveToCompiereError = 0;
    }

    class generalResultInformation
    {
        public static string Station;
        public static string esayMoveErrorfileName = "";
        public static string esayMoveWarnnigfileName = "";
        public static string esayMoveScriptfileName = "";

        public static string compErrorfileName = "";
        public static string compWarnnigfileName = "";
        public static string compScriptfileName = "";
        
        public static int dbConfigTrials = 3;

        public static int synchResultProductInsert = 0;
        public static int synchResultProductUpdate = 0;
        public static int synchResultProductDelete = 0;

        public static int synchResultBOMInsert = 0;
        public static int synchResultBOMUpdate = 0;
        public static int synchResultBOMDelete = 0;

        public static int synchResultUserOrgAccessInsert = 0;
        public static int synchResultUserOrgAccessUpdate = 0;
        public static int synchResultUserOrgAccessDelete = 0;

        public static int synchResultUOMInsert = 0;
        public static int synchResultUOMUpdate = 0;
        public static int synchResultUOMDelete = 0;
        
        public static int synchResultCatgoryInsert = 0;
        public static int synchResultCatgoryUpdate = 0;
        public static int synchResultCatgoryDelete = 0;
        
        public static int synchResultStoreInsert = 0;
        public static int synchResultStoreUpdate = 0;
        public static int synchResultStoreDelete = 0;

        public static int synchResultWarehouseInsert = 0;
        public static int synchResultWarehouseUpdate = 0;
        public static int synchResultWarehouseDelete = 0;

        public static int synchResultDocumentTypeInsert = 0;
        public static int synchResultDocumentTypeUpdate = 0;
        public static int synchResultDocumentTypeDelete = 0;

        public static int synchResultOrganisationInsert = 0;
        public static int synchResultOrganisationUpdate = 0;
        public static int synchResultOrganisationDelete = 0;

        public static int synchResultUserInsert = 0;
        public static int synchResultUserUpdate = 0;
        public static int synchResultUserDelete = 0;

        public static int synchResultMovementInsert = 0;
        public static int synchResultMovementUpdate = 0;
        public static int synchResultMovementDelete = 0;

        public static int synchResultMovementLineInsert = 0;
        public static int synchResultMovementLineUpdate = 0;
        public static int synchResultMovementLineDelete = 0;


        public static int synchResultInOutInsert = 0;
        public static int synchResultInOutUpdate = 0;
        public static int synchResultInOutDelete = 0;

        public static int synchResultInOutLineInsert = 0;
        public static int synchResultInOutLineUpdate = 0;
        public static int synchResultInOutLineDelete = 0;

        public static int synchResultProductionInsert = 0;
        public static int synchResultProductionUpdate = 0;
        public static int synchResultProductionDelete = 0;

        public static int synchResultProductionPlanInsert = 0;
        public static int synchResultProductionPlanUpdate = 0;
        public static int synchResultProductionPlanDelete = 0;

        public static int synchResultProductionLineInsert = 0;
        public static int synchResultProductionLineUpdate = 0;
        public static int synchResultProductionLineDelete = 0;


        public static int synchResultClientInsert = 0;
        public static int synchResultClientUpdate = 0;
        public static int synchResultClientDelete = 0;

        public static int synchResultProductErros = 0;
        public static int synchResultProductWarnnings = 0;
        public static int synchResultProductScripts = 0;

        public static int synchResultBOMErros = 0;
        public static int synchResultBOMWarnnings = 0;
        public static int synchResultBOMScripts = 0;

        public static int synchResultUserOrgAccessErros = 0;
        public static int synchResultUserOrgAccessWarnnings = 0;
        public static int synchResultUserOrgAccessScripts = 0;

        public static int synchResultUOMErros = 0;
        public static int synchResultUOMWarnnings = 0;
        public static int synchResultUOMScripts = 0;

        public static int synchResultCatgoryErros = 0;
        public static int synchResultCatgoryWarnnings = 0;
        public static int synchResultCatgoryScripts = 0;

        public static int synchResultStoreErros = 0;
        public static int synchResultStoreWarnnings = 0;
        public static int synchResultStoreScripts = 0;

        public static int synchResultOrganisationErros = 0;
        public static int synchResultOrganisationWarnnings = 0;
        public static int synchResultOrganisationScripts = 0;

        public static int synchResultUserErros = 0;
        public static int synchResultUserWarnnings = 0;
        public static int synchResultUserScripts = 0;

        public static int synchResultMovementErros = 0;
        public static int synchResultMovementWarnnings = 0;
        public static int synchResultMovementScripts = 0;

        public static int synchResultMovementLineErros = 0;
        public static int synchResultMovementLineWarnnings = 0;
        public static int synchResultMovementLineScripts = 0;


        public static int synchResultInOutErros = 0;
        public static int synchResultInOutWarnnings = 0;
        public static int synchResultInOutScripts = 0;

        public static int synchResultInOutLineErros = 0;
        public static int synchResultInOutLineWarnnings = 0;
        public static int synchResultInOutLineScripts = 0;
        
        public static int synchResultProductionErros = 0;
        public static int synchResultProductionWarnnings = 0;
        public static int synchResultProductionScripts = 0;

        public static int synchResultProductionPlanErros = 0;
        public static int synchResultProductionPlanWarnnings = 0;
        public static int synchResultProductionPlanScripts = 0;

        public static int synchResultProductionLineErros = 0;
        public static int synchResultProductionLineWarnnings = 0;
        public static int synchResultProductionLineScripts = 0;

        public static int synchResultClientErros = 0;
        public static int synchResultClientWarnnings = 0;
        public static int synchResultClientScripts = 0;

        public static int synchResultWarehouseErros = 0;
        public static int synchResultWarehouseWarnnings = 0;
        public static int synchResultWarehouseScripts = 0;

        public static int synchResultDocumentTypeErros = 0;
        public static int synchResultDocumentTypeWarnnings = 0;
        public static int synchResultDocumentTypeScripts = 0;
        
    }

    class dbCommitFailure
    {
        public static bool dbCommitError = false;
        public static bool dbCommitWarnning = false;

        public static string dbCommitErrorMessage = "";
        public static string dbCommitWarnningMessage = "";

    }
    

}
