using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace dbConnection
{
    public enum triaStateBool
    {
        yes,
        no,
        Ignor 
    }

    enum supportedDbList
    {
        Oracle_10g,
        MsSqlServer,
        MySQL_5x,
        MsAccess_2007
    }

    public enum daysOfWeek
    {
        A_None,
        Mon,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat,
        Sun
    }   


    class dbSettingInformationHandler
    {
        public static string settingFilePath = "settings.xml";
        public static string compDataBaseType = "";
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
    }

    public class generalResultInformation
    {
        public static string dbNull = "!!_NULL@_!!";
        public static string allOrganisationRepresentativeKey = "0";
        public static string userId = new dataBuilder().CREATEDBY;
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

        public static DateTime startDate = DateTime.Now.AddYears(1);
        public static DateTime EndDate = DateTime.Now.AddYears(1);

    }

    class documentInformation
    {
        public static string documentStatusAfterClosing = "CO";
        public static string documentActionAfterClosing = "--";

    }

    public class dbCommitFailure
    {
        public static bool dbCommitError = false;
        public static bool dbCommitWarnning = false;

        public static string dbCommitErrorMessage = "";
        public static string dbCommitWarnningMessage = "";

    }

}
