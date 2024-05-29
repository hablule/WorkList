﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POSDocumentPrinter
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

    enum reportType
    {
        UNKOWN,
        attachment,
        deliveryOrder,
        refundBook,
        CashReceiptVoucher,
        BankDepositSlip,
        OpenInvoice
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

    static class tenderTypeMethods
    {

        public static String GetString(this tenderType tenderT)
        {
            switch (tenderT)
            {
                case tenderType.Cash:
                    return "Cash";
                case tenderType.Check:
                    return "Check";
                case tenderType.CPO:
                    return "CPO";
                default:
                    return "ignor";
            }
        }

        public static tenderType GettenderType(this String tenderT)
        {
            switch (tenderT)
            {
                case "Cash":
                    return tenderType.Cash;
                case "Check":
                    return tenderType.Check;
                case "CPO":
                    return tenderType.CPO;
                default:
                    return tenderType.ignor;
            }
        }
    }


    enum transactionPerformed
    {
        BankDeposit,
        CRV,
        Exemption,
        Attachement,
        DeliveryOrder,
        Inventory,
        Refund,
        ManulaSales,
        None
    };

    static class codeRequestedMethods
    {
        public static int GetCodeValue(this transactionPerformed codeR)
        {
            switch (codeR)
            {
                case transactionPerformed.BankDeposit:
                    return 0;
                case transactionPerformed.CRV:
                    return 3;
                case transactionPerformed.Exemption:
                    return 3;
                case transactionPerformed.Attachement:
                    return 2;
                case transactionPerformed.DeliveryOrder:
                    return 1;
                case transactionPerformed.Inventory:
                    return 3;
                default:
                    return 4;
            }
        }

    }


    enum CashSourceType
    {
        ignor,
        Sales,
        CRV,
        Exemption,
        Refund
    };

    enum PAYMENTRULE
    {
        ignor,
        Cash,
        Credit
    };

    class dbSettingInformationHandler
    {
        public static string settingFilePath = "settings.xml";
        public static string settingFilePath_bkp = "settingscp.xml";
        public static string encryptionSecurityKey = "myKy24/7";
        public static bool documentNumberAutoGenerated = false;
        
        public static string DataBaseType = "MySql";
        public static string ServerHostName = "";
        public static string DataBaseName = "";
        public static string DBUserName = "";
        public static string DBPassword = "";
        public static string ScriptDirectory = "";
        public static string WarningDirectory = "";
        public static string ErrorDirectory = "";
        public static string DBPort = "";
        public static string PrinterName = "";
        public static bool LogChangeScript = true;
        public static bool EnableDeliveryOrderPrint = true;
        public static bool AutoPrintDeliveryOrder = false;
        public static bool ControlDepositSourceConsistency = true;        

        public static string theme = "";
    }

    class generalResultInformation
    {
        //public static bool Os64bIT = false;
        public static string MyOdbcDrvr = "MySQL ODBC 3.51 Driver";

        public static string Station = "";
        public static string centralStation = "";
        public static string concernedNode = "";
        public static string machineRegistrationNumber = "";

        public static string userId = "";
        public static string userFullName = "";
        public static string userName = "";
        public static string userType = "";

        public static int userLoginTrials = 5;
        public static bool logedIn = false;
                
        public static int dbConfigTrials = 3;

        public static string stDocumentReferenceNumber = "";
        public static string stRefundSalesReferenceNumber = "";
        public static string stDocumentNote = "";
        public static reportType requestedDocumenType = reportType.UNKOWN;
        public static bool documentRequestInfoCancelled = false;

        public static int invoiceIdNumber = -1;

        public static reportType requestedReport = reportType.UNKOWN;

        public static dtsPOSDocumentData dtsDocumentPrintView = new dtsPOSDocumentData();

        public static DataTable searchResult = new DataTable();
        public static DataTable searchCritrion = new DataTable();        
        public static string logicConnector = "";

        public static DataTable newCashSource = new DataTable();
        public static string C_CASHLINE_ID = "";
        public static bool isCashLineProcessed = true;
        public static decimal cashLineAmt = 0;
        public static decimal cardCommissionRate = 0;

        public static string ProductName = "";
        public static string Product_Id = "";

        public static decimal shortAmtLimit = 1; //short Amount Received from Sales
        public static decimal overAmtLimit = -3; //Over Amount Received from Sales
        
        public static string CustomerName = "";
        public static string InvoiceNumber = "";
        public static bool securityPassKeyCorrect = false;
        //public static bool allowAmountOverageShortage = false;

        public static string CustomerID = "";
        public static string KPIresult = "";

        public static bool allowNegativeStock = false;
        public static bool allowAttachementBlocking = true;
        public static bool logInSessionExpired = true;
        
        public static transactionPerformed transationPerf;

        public static bool ControlAttachmentPrint = true;

        public static bool LDAPConnectionSet = false;
        public static bool useLDAPAuthentication = false;  

    }

    class dbCommitFailure
    {
        public static bool dbCommitError = false;
        public static bool dbCommitWarnning = false;

        public static string dbCommitErrorMessage = "";
        public static string dbCommitWarnningMessage = "";

    }
    

}
