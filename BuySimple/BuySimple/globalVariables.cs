using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BuySimple
{
    enum triaStateBool
    {
        yes,
        no,
        Ignor 
    }

    class dbSettingInformationHandler
    {
        public static string settingFilePath = "settings.xml";
        public static string settingFilePath_bkp = "settingscp.xml";
        public static string encryptionSecurityKey = "myKy24/7";
        public static string compDataBaseType = "Oracle";
        public static string compHostName = "";
        public static string compDataBaseName = "";
        public static string compUsername = "";
        public static string compPassword = "";
        public static string compScriptDirectory = "";
        public static string compWarningDirectory = "";
        public static string compErrorDirectory = "";
        public static string compPort = "";
        public static bool compLogChangeScript = true;
        public static int compPurchaseCostUpdateTimeInterval = 0;
        public static int compiereToPOSWarning = 0;
        public static int compiereToPOSError = 0;

        public static string posPrinterNameList = "";

        public static string theme = "";
    }

    class generalResultInformation
    {
        public static string allOrganisationRepresentativeKey = "0";
        public static string userId = "";
        public static string organiztionId = "";
        public static string clientId = "1000000";
        public static string UserName = "";

        public static bool logedIn = false;
        public static bool userprevilageIsReadOnly = true;
        public static int userLoginTrials = 5;
        public static int dbConfigTrials = 3;
        
        public static DataTable searchResult = new DataTable();
        public static DataTable searchCritrion = new DataTable();
        public static string logicConnector = "";

        public static string invoiceVendorWindowId = "183";

        public static bool userCanCloseInvoiceCost = false;

        public static bool LDAPConnectionSet = false;
        public static bool useLDAPAuthentication = false;

        public static bool userCanEditSettings = false;

    }

    class documentInformation
    {
        public static string documentStatusAfterClosing = "CO";
        public static string documentActionAfterClosing = "--";

    }

}
