using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace dbConnection
{
    public enum triStateBool
    {
        yes,
        no,
        Ignor 
    }

    public class otherSettings
    {
        public static string PrinterName = "";
        public static string stPaperName = "DtlSARptPaper";
    }

    public class dbSettingInformationHandler
    {
        public static string settingFilePath = "settings.xml";
        public static string settingFilePath_bkp = "sBkp.xml";
        public static string DataBaseType = "";
        public static string ServerHostName = "";
        public static string DataBaseName = "";
        public static string DBUserName = "";
        public static string DBPassword = "";
        public static string ScriptDirectory = "";
        public static string WarningDirectory = "";
        public static string ErrorDirectory = "";
        public static string DBPort = "";
        public static bool LogChangeScript = true;

        public static string theme = "";
        public static string dbTablePrefix = "";
        public static string upperCaseFunction = "";
    }

    public class generalResultInformation
    {
        public static string MyOdbcDrvr = "MySQL ODBC 3.51 Driver";
        public static string dateFormat = "dd-MMM-yyyy";

        public static string allOrganisationRepresentativeKey = "0";
        public static string allWarehouseRepresentativeKey = "0";
        public static string userId = "";
        public static string organiztionId = "";
        public static string clientId = "1000000";
        public static string userName = "";

        public static bool logedIn = false;
        public static bool userprevilageIsReadOnly = true;
        public static int userLoginTrials = 5;
        public static int dbConfigTrials = 3;

        public static DataTable AccessableWarehouse = new DataTable();
        public static DataTable AccessableLocators = new DataTable();

        public static DataSet dtsSerachResult = new DataSet();
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

    class dbCommitFailure
    {
        public static bool dbCommitError = false;
        public static bool dbCommitWarnning = false;

        public static string dbCommitErrorMessage = "";
        public static string dbCommitWarnningMessage = "";

    }

}
