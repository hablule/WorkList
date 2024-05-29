using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace dbConnection
{

    public enum changeType { none, Payee, Amount, Bank, Check, Description };

    public enum triStateBool
    {
        yes,
        no,
        Ignor 
    }

    public enum printDocType
    {
        UNKOWN,
        paymentVoucher,
        check,
        confirmation
    }


    public class otherSettings
    {
        public static string defaultPrinterName = "";
        public static string stPaperName = "DtlSARptPaper";
    }

    public class dbSettingInformationHandler
    {
        public static string settingFilePath = "settings.xml";
        public static string dbDataBaseType = "Oracle";
        public static string dbHostName = "";
        public static string dataBaseName = "";
        public static string dbUsername = "";
        public static string dbPassword = "";
        public static string scriptDirectory = "";
        public static string warningDirectory = "";
        public static string errorDirectory = "";
        public static string dbPort = "";
        public static bool logChangeScript = true;
        public static int updateTimeInterval = 0;
        public static int compiereToPOSWarning = 0;
        public static int compiereToPOSError = 0;

        public static string theme = "";
        //public static string defalutPrinterName = "";
    }

    public class generalResultInformation
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

        public static DataSet dtsSerachResult = new DataSet();
        public static DataTable searchResult = new DataTable();
        public static DataTable searchCritrion = new DataTable();

        public static DataTable dtAllocation = new DataTable();

        public static string logicConnector = "";

        public static printDocType requestedPrintDocType = printDocType.UNKOWN;

        public static string newBpartnerID = "";
        public static string newBpartnerName = "";

        public static bool allowAmountOverageShortage = false;
        public static string CustomerName = "";
        public static string InvoiceNumber = "";

        public static bool LDAPConnectionSet = false;
        public static bool useLDAPAuthentication = false;

        public static bool userCanEditSettings = false;

        public static bool allowOverageShortagePassKey = true;

        public static decimal allowedOverageShortageAmount = 0;
        
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
