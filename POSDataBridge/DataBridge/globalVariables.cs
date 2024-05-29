using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSDataBridge
{
    enum triaStateBool
    {
        yes,
        no,
        Ignor
    }

    enum exemptionType
    {
        ignor,
        WITHHOLDING,
        VAT
    };

    enum tenderType
    {
        ignor,
        Cash,
        Check,
        CPO
    };
    
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
        public static string settingFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");// "settings.xml";

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

        
        public static string posDataBaseType = "MySql";
        public static string posHostName = "";
        public static string posDataBaseName = "";
        public static string posDBUserName = "";
        public static string posDBPassword = "";
        public static string posScriptDirectory = "";
        public static string posWarningDirectory = "";
        public static string posErrorDirectory = "";
        public static string posDBPort = "";
        public static bool posLogChangeScript = true;
        public static bool posAutoStartSynch = true;
        public static int posSyncTimeInterval = 0;
        public static int posToCompiereWarning = 0;
        public static int posToCompiereError = 0;
    }

    class generalResultInformation
    {
        public static string Station;
        public static string clientId = "1000000";
        public static string posErrorfileName = "";
        public static string posWarnnigfileName = "";
        public static string posScriptfileName = "";

        public static string compErrorfileName = "";
        public static string compWarnnigfileName = "";
        public static string compScriptfileName = "";
        
        public static int dbConfigTrials = 3;

        public static int synchResultProductInsert = 0;
        public static int synchResultProductUpdate = 0;
        public static int synchResultProductDelete = 0;

        public static int synchResultPriceInsert = 0;
        public static int synchResultPriceUpdate = 0;
        public static int synchResultPriceDelete = 0;

        public static int synchResultUOMInsert = 0;
        public static int synchResultUOMUpdate = 0;
        public static int synchResultUOMDelete = 0;
        
        public static int synchResultCatgoryInsert = 0;
        public static int synchResultCatgoryUpdate = 0;
        public static int synchResultCatgoryDelete = 0;
        
        public static int synchResultStoreInsert = 0;
        public static int synchResultStoreUpdate = 0;
        public static int synchResultStoreDelete = 0;

        public static int synchResultOrganisationInsert = 0;
        public static int synchResultOrganisationUpdate = 0;
        public static int synchResultOrganisationDelete = 0;

        public static int synchResultPriceVersionInsert = 0;
        public static int synchResultPriceVersionUpdate = 0;
        public static int synchResultPriceVersionDelete = 0;

        public static int synchResultCustomerInsert = 0;
        public static int synchResultCustomerUpdate = 0;
        public static int synchResultCustomerDelete = 0;

        public static int synchResultOrderInsert = 0;
        public static int synchResultOrderUpdate = 0;
        public static int synchResultOrderDelete = 0;

        public static int synchResultOrderLineInsert = 0;
        public static int synchResultOrderLineUpdate = 0;
        public static int synchResultOrderLineDelete = 0;

        public static int synchResultProductErros = 0;
        public static int synchResultProductWarnnings = 0;
        public static int synchResultProductScripts = 0;

        public static int synchResultPriceErros = 0;
        public static int synchResultPriceWarnnings = 0;
        public static int synchResultPriceScripts = 0;

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

        public static int synchResultPriceVersionErros = 0;
        public static int synchResultPriceVersionWarnnings = 0;
        public static int synchResultPriceVersionScripts = 0;

        public static int synchResultCustomerErros = 0;
        public static int synchResultCustomerWarnnings = 0;
        public static int synchResultCustomerScripts = 0;

        public static int synchResultOrderErros = 0;
        public static int synchResultOrderWarnnings = 0;
        public static int synchResultOrderScripts = 0;

        public static int synchResultOrderLineErros = 0;
        public static int synchResultOrderLineWarnnings = 0;
        public static int synchResultOrderLineScripts = 0;

        public static int synchResultExemptionInsert = 0;
        public static int synchResultExemptionUpdate = 0;
        public static int synchResultExemptionDelete = 0;

        public static int synchResultExemptionLineInsert = 0;
        public static int synchResultExemptionLineUpdate = 0;
        public static int synchResultExemptionLineDelete = 0;


        public static int synchResultPaymentInsert = 0;
        public static int synchResultPaymentUpdate = 0;
        public static int synchResultPaymentDelete = 0;

        public static int synchResultPaymentLineInsert = 0;
        public static int synchResultPaymentLineUpdate = 0;
        public static int synchResultPaymentLineDelete = 0;


        public static int synchResultAllocationInsert = 0;
        public static int synchResultAllocationUpdate = 0;
        public static int synchResultAllocationDelete = 0;

        public static int synchResultAllocationLineInsert = 0;
        public static int synchResultAllocationLineUpdate = 0;
        public static int synchResultAllocationLineDelete = 0;


        public static int synchResultCashInsert = 0;
        public static int synchResultCashUpdate = 0;
        public static int synchResultCashDelete = 0;

        public static int synchResultCashLineInsert = 0;
        public static int synchResultCashLineUpdate = 0;
        public static int synchResultCashLineDelete = 0;

        public static int synchResultExemptionErrors = 0;
        public static int synchResultExemptionWarnnings = 0;
        public static int synchResultExemptionScripts = 0;

        public static int synchResultExemptionLineErrors = 0;
        public static int synchResultExemptionLineWarnnings = 0;
        public static int synchResultExemptionLineScripts = 0;

        public static int synchResultPaymentErrors = 0;
        public static int synchResultPaymentWarnnings = 0;
        public static int synchResultPaymentScripts = 0;

        public static int synchResultPaymentLineErrors = 0;
        public static int synchResultPaymentLineWarnnings = 0;
        public static int synchResultPaymentLineScripts = 0;

        public static int synchResultAllocationErrors = 0;
        public static int synchResultAllocationWarnnings = 0;
        public static int synchResultAllocationScripts = 0;

        public static int synchResultAllocationLineErrors = 0;
        public static int synchResultAllocationLineWarnnings = 0;
        public static int synchResultAllocationLineScripts = 0;

        public static int synchResultCashErrors = 0;
        public static int synchResultCashWarnnings = 0;
        public static int synchResultCashScripts = 0;

        public static int synchResultCashLineErrors = 0;
        public static int synchResultCashLineWarnnings = 0;
        public static int synchResultCashLineScripts = 0;
		
               
        
    }

    class dbCommitFailure
    {
        public static bool dbCommitError = false;
        public static bool dbCommitWarnning = false;

        public static string dbCommitErrorMessage = "";
        public static string dbCommitWarnningMessage = "";

    }
    

}
