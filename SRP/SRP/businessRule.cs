using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SRP
{
    class businessRule
    {
   
        private dataBuilder getDbInformation = new dataBuilder();

        public string getStringEquivelentOfMoveType(movementType moveType)
        {
            switch (moveType)
            {
                case movementType.C_p:
                    return "C+";
                case movementType.C_n:
                    return "C-";
                case movementType.I_p:
                    return "I+";
                case movementType.I_n:
                    return "I-";
                case movementType.M_n:
                    return "M-";
                case movementType.M_p:
                    return "M+";
                case movementType.V_p:
                    return "V+";
                case movementType.V_n:
                    return "V-";
                default:
                    return "BL";
            }            
        }

        public movementType getMoveTypeEquivelentOfString(string moveType)
        {
            switch (moveType)
            {
                case "C+":
                    return movementType.C_p;
                case "C-":
                    return movementType.C_n;
                case "I+":
                    return movementType.I_p;
                case "I-":
                    return movementType.I_n;
                case "M+":
                    return movementType.M_p;
                case "M-":
                    return movementType.M_n;
                case "V+":
                    return movementType.V_p;
                case "V-":
                    return movementType.V_n;
                default:
                    return movementType.BL;
            }
        }


        public string getNameEquivelentOfMoveType(movementType moveType)
        {
            switch (moveType)
            {
                case movementType.C_n:
                    return "Inventory Out";
                case movementType.C_p:
                    return "Sales Return";
                case movementType.I_p:
                    return "Inventory Count";
                case movementType.I_n:
                    return "Inventory Use";
                case movementType.M_n:
                    return "Moved From";
                case movementType.M_p:
                    return "Moved To";
                case movementType.V_p:
                    return "Inventory In";
                case movementType.V_n:
                    return "Vendor Return";
                default:
                    return "Unkown";
            }
        }

        public movementType getMoveTypeEquivelentOfName(string moveType)
        {
            switch (moveType)
            {
                case "Inventory Out":
                    return movementType.C_n;
                case "Sales Return":
                    return movementType.C_p;
                case "Inventory Count":
                    return movementType.I_p;
                case "Inventory Use":
                    return movementType.I_n;
                case "Moved From":
                    return movementType.M_n;
                case "Moved To":
                    return movementType.M_p;
                case "Inventory In":
                    return movementType.V_p;
                case "Vendor Return":
                    return movementType.V_n;
                default:
                    return movementType.BL;
            }
        }


        public bool validateUser(string userName, string passWord)
        {
            DataTable dtUserInfo =
                this.getDbInformation.getU_USERInfo
                        (null, "", "", "", userName, passWord,
                            triStateBool.yes, false, "AND");
            if (!this.getDbInformation.checkIfTableContainesData(dtUserInfo))
                return false;

            string stUserId = dtUserInfo.Rows[0]["U_USER_ID"].ToString();
            string stName = dtUserInfo.Rows[0]["FIRSTNAME"].ToString() + " " +
                            dtUserInfo.Rows[0]["MIDDLENAME"].ToString();

            DataTable dtActiveShop =
                this.getDbInformation.getU_ACTIVESHOPID(false);

            if (!this.getDbInformation.checkIfTableContainesData(dtActiveShop))
            {
                MessageBox.Show("UnKown Shop, Please Contact Your Admin.",
                        "SRP Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            DataTable dtUserStationAccess =
                this.getDbInformation.getU_SHOPACCESS(null, "",
                                dtActiveShop.Rows[0]["M_SHOP_ID"].ToString(),
                                stUserId, accessLevel.ignor, triStateBool.yes, false, "AND");

            if (this.getDbInformation.checkIfTableContainesData(dtUserStationAccess))
            {
                if (dtUserStationAccess.Rows[0]["ACCESSLEVEL"].ToString()
                    != accessLevel.InActive.ToString())
                {
                    generalResultInformation.userId = stUserId;
                    generalResultInformation.Station =
                        dtActiveShop.Rows[0]["M_SHOP_ID"].ToString();
                    generalResultInformation.activeStation =
                        dtActiveShop.Rows[0]["M_SHOP_ID"].ToString();
                    generalResultInformation.userName = stName;
                    return true;
                }
            }

            dtUserStationAccess =
                this.getDbInformation.getU_SHOPACCESS(null, "",
                                generalResultInformation.allStationRepresentativeKey,
                                stUserId, accessLevel.ignor, triStateBool.yes, false, "AND");

            if (this.getDbInformation.checkIfTableContainesData(dtUserStationAccess))
            {
                if (dtUserStationAccess.Rows[0]["ACCESSLEVEL"].ToString()
                    != accessLevel.InActive.ToString())
                {
                    generalResultInformation.userId = stUserId;
                    generalResultInformation.Station =
                        dtActiveShop.Rows[0]["M_SHOP_ID"].ToString();
                    generalResultInformation.activeStation =
                        dtActiveShop.Rows[0]["M_SHOP_ID"].ToString();
                    generalResultInformation.userName = stName;
                    return true;
                }
            }

            MessageBox.Show("Unable to log you In. \n" +
                    "You don't have access to current station",
                        "SRP Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public bool adjustStock(string M_PRODUCT_ID, string M_WAREHOUSE_ID, decimal adjustmentQty)
        {
            return this.adjustStock(generalResultInformation.allOrganisationRepresentativeKey,
                M_PRODUCT_ID, M_WAREHOUSE_ID, adjustmentQty);
        }
               

        public bool adjustStock(string AD_ORG_ID, string M_PRODUCT_ID, string M_WAREHOUSE_ID, decimal adjustmentQty)
        {
            if (M_PRODUCT_ID == "" || M_WAREHOUSE_ID == "")// || adjustmentQty == 0)
                return false;

            DataTable dtProductInformation =
                this.getDbInformation.getM_PRODUCTInfo(null, "", M_PRODUCT_ID, "", "", 
                            "", "", "I", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            
            if (!this.getDbInformation.checkIfTableContainesData(dtProductInformation))
                return true;
            
            DataTable dtWarehouseInformation =
                this.getDbInformation.getM_WarehouseInfo(null, "", M_WAREHOUSE_ID,
                    "", triStateBool.ignor, triStateBool.ignor, false, "AND");
                       
            if (!this.getDbInformation.checkIfTableContainesData(dtWarehouseInformation))
                return false;


            string stChangeType = "UPDATE";
            DataTable stockInformation = new DataTable();
            DataTable costInformation = new DataTable();
            try
            {
                stockInformation =
                    this.getDbInformation.getQ_STOCKInfo(null, "", M_PRODUCT_ID, 
                        M_WAREHOUSE_ID, triStateBool.ignor, false, "AND");
                if (!this.getDbInformation.checkIfTableContainesData(stockInformation))
                {
                    stChangeType = "INSERT";

                    DataRow drNewStockInformation = stockInformation.NewRow();
                    drNewStockInformation["AD_ORG_ID"] = AD_ORG_ID;
                    drNewStockInformation["M_PRODUCT_ID"] = M_PRODUCT_ID;
                    drNewStockInformation["M_WAREHOUSE_ID"] = M_WAREHOUSE_ID;
                    drNewStockInformation["CURRENTQTY"] = adjustmentQty;

                    stockInformation.Rows.Add(drNewStockInformation);
                }
                else
                {
                    stockInformation.Rows[0]["AD_ORG_ID"] = AD_ORG_ID;
                    stockInformation.Rows[0]["M_PRODUCT_ID"] = M_PRODUCT_ID;
                    stockInformation.Rows[0]["M_WAREHOUSE_ID"] = M_WAREHOUSE_ID;
                    stockInformation.Rows[0]["CURRENTQTY"] =
                        decimal.Parse(stockInformation.Rows[0]["CURRENTQTY"].ToString()) +
                        adjustmentQty;
                }
            }
            catch
            {
                return false;
            }

            this.getDbInformation.
                changeDataBaseTableData(stockInformation, "Q_STOCK", stChangeType);

            stChangeType = "UPDATE";
            try
            {
                costInformation =
                    this.getDbInformation.getQ_COSTInfo(null, "", M_PRODUCT_ID, 
                        0, 0, 0, 0, triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if (costInformation.Rows.Count <= 0)
                {
                    stChangeType = "INSERT";

                    DataRow drNewCostInformation = costInformation.NewRow();
                    drNewCostInformation["M_PRODUCT_ID"] = M_PRODUCT_ID;                    
                    drNewCostInformation["CURRENTQTY"] = adjustmentQty;

                    stockInformation.Rows.Add(drNewCostInformation);
                }
                else
                {
                    costInformation.Rows[0]["M_PRODUCT_ID"] = M_PRODUCT_ID;                    
                    costInformation.Rows[0]["CURRENTQTY"] =
                        decimal.Parse(costInformation.Rows[0]["CURRENTQTY"].ToString()) +
                        adjustmentQty;
                }
            }
            catch
            {
                return false;
            }

            this.getDbInformation.
                changeDataBaseTableData(costInformation, "Q_COST", stChangeType);

            return true;
        }
                
        public DataTable getCurrentUserAccessableWarehouse
            (triStateBool moveFromAccess, triStateBool moveToAccess, 
             triStateBool saleFromAccess, triStateBool purchaseToAccess, 
             triStateBool countAccess, triStateBool useAccess, triStateBool viewAccess, 
             triStateBool ActiveWarehouse, string logicalConnector)
        {
            DataTable stationCriterion = new DataTable();

            stationCriterion.Columns.Add("Field");
            stationCriterion.Columns.Add("Criterion");
            stationCriterion.Columns.Add("Value");
            
            DataRow criteriaValue = stationCriterion.NewRow();
            criteriaValue["Field"] = "M_SHOP_ID";
            criteriaValue["Criterion"] = " = ";
            criteriaValue["Value"] = generalResultInformation.Station;
            stationCriterion.Rows.Add(criteriaValue);

            criteriaValue = stationCriterion.NewRow();
            criteriaValue["Field"] = "M_SHOP_ID";
            criteriaValue["Criterion"] = " = ";
            criteriaValue["Value"] = generalResultInformation.allStationRepresentativeKey;
            stationCriterion.Rows.Add(criteriaValue);
            
            DataTable notAllWareHouseCriterion = new DataTable();
            notAllWareHouseCriterion.Columns.Add("Field");
            notAllWareHouseCriterion.Columns.Add("Criterion");
            notAllWareHouseCriterion.Columns.Add("Value");

            criteriaValue = notAllWareHouseCriterion.NewRow();
            criteriaValue["Field"] = "M_WAREHOUSE_ID";
            criteriaValue["Criterion"] = " != ";
            criteriaValue["Value"] = generalResultInformation.allWarehouseRepresentativeKey;
            notAllWareHouseCriterion.Rows.Add(criteriaValue);

            if (logicalConnector != "AND" && logicalConnector != "OR")
                logicalConnector = "AND";

            DataTable userAccessableWarehouse = new DataTable();

            if (logicalConnector == "AND")
            {
                userAccessableWarehouse =
                    this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                        "", generalResultInformation.userId,
                        generalResultInformation.allWarehouseRepresentativeKey,
                        triStateBool.yes, saleFromAccess,
                        purchaseToAccess, moveFromAccess, moveToAccess, useAccess,
                        countAccess, viewAccess, false, logicalConnector);
            }
            else if (logicalConnector == "OR")
            {
                userAccessableWarehouse =
                    this.getDbInformation.getU_WAREHOUSEACCESS(null, "",
                        generalResultInformation.allStationRepresentativeKey,
                        generalResultInformation.userId,
                        generalResultInformation.allWarehouseRepresentativeKey,
                        triStateBool.yes, saleFromAccess,
                        purchaseToAccess, moveFromAccess, moveToAccess, useAccess,
                        countAccess, viewAccess, false, logicalConnector);

                userAccessableWarehouse = 
                 this.getDbInformation.mergeTables
                    (userAccessableWarehouse,
                        this.getDbInformation.getU_WAREHOUSEACCESS(null, "",
                        generalResultInformation.Station,
                        generalResultInformation.userId,
                        generalResultInformation.allWarehouseRepresentativeKey,
                        triStateBool.yes, saleFromAccess,
                        purchaseToAccess, moveFromAccess, moveToAccess, useAccess,
                        countAccess, viewAccess, false, logicalConnector), "M_WAREHOUSE_ID", false);
            }
            

            if (this.getDbInformation.checkIfTableContainesData(userAccessableWarehouse))
            {
                userAccessableWarehouse =
                    this.getDbInformation.getM_WarehouseInfo(notAllWareHouseCriterion, "AND", "", "",
                        triStateBool.ignor, triStateBool.yes, false, "OR");

                for (int columnCounter = userAccessableWarehouse.Columns.Count - 1;
                        columnCounter >= 0; columnCounter--)
                {
                    if (userAccessableWarehouse.Columns[columnCounter].ColumnName != "M_WAREHOUSE_ID" &&
                        userAccessableWarehouse.Columns[columnCounter].ColumnName != "NAME")
                        userAccessableWarehouse.Columns.RemoveAt(columnCounter);
                }                
            }
            else
            {
                if (logicalConnector == "AND")
                {
                    userAccessableWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, "", triStateBool.yes, saleFromAccess,
                            purchaseToAccess, moveFromAccess, moveToAccess,
                            useAccess, countAccess, viewAccess, false, logicalConnector);
                }
                else if (logicalConnector == "OR")
                {
                    userAccessableWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(null, "",
                            generalResultInformation.Station,
                            generalResultInformation.userId, "", triStateBool.yes, saleFromAccess,
                            purchaseToAccess, moveFromAccess, moveToAccess,
                            useAccess, countAccess, viewAccess, false, logicalConnector);

                    userAccessableWarehouse = 
                        this.getDbInformation.mergeTables(
                          userAccessableWarehouse,
                            this.getDbInformation.getU_WAREHOUSEACCESS(null, "",
                                generalResultInformation.allStationRepresentativeKey,
                                generalResultInformation.userId, "", triStateBool.yes, saleFromAccess,
                                purchaseToAccess, moveFromAccess, moveToAccess,
                                useAccess, countAccess, viewAccess, false, logicalConnector), 
                          "M_WAREHOUSE_ID", false);
                }


                if (this.getDbInformation.checkIfTableContainesData(userAccessableWarehouse))
                {
                    for (int columnCounter = userAccessableWarehouse.Columns.Count - 1;
                        columnCounter >= 0; columnCounter--)
                    {
                        if (userAccessableWarehouse.Columns[columnCounter].ColumnName != "M_WAREHOUSE_ID")
                            userAccessableWarehouse.Columns.RemoveAt(columnCounter);
                    }                    

                    userAccessableWarehouse.Columns.Add("NAME");

                    for (int rowCounter = userAccessableWarehouse.Rows.Count - 1;
                         rowCounter >= 0; rowCounter--)
                    {
                        try
                        {
                            userAccessableWarehouse.Rows[rowCounter]["NAME"] =
                                this.getDbInformation.getM_WarehouseInfo(null, "",
                                    userAccessableWarehouse.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                                    "", triStateBool.ignor, ActiveWarehouse,
                                    false, "AND").Rows[0]["NAME"].ToString();
                        }
                        catch
                        {
                            userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        }
                    }
                }                
            }

            DataTable blockedAccessWarehouse = new DataTable();
            string stWarehouseID = "";

            for (int rowCounter = userAccessableWarehouse.Rows.Count - 1;
                         rowCounter >= 0; rowCounter--)
            {
                stWarehouseID =
                    userAccessableWarehouse.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();
                if (saleFromAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.No,
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

                if (purchaseToAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.ignor,
                            triStateBool.No, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

                if (moveFromAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.No, triStateBool.ignor, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

                if (moveToAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, triStateBool.No, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

                if (useAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, triStateBool.No,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

                if (countAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                            triStateBool.No, triStateBool.ignor, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

                if (viewAccess == triStateBool.yes)
                {
                    blockedAccessWarehouse =
                        this.getDbInformation.getU_WAREHOUSEACCESS(stationCriterion, "OR",
                            "", generalResultInformation.userId, stWarehouseID,
                            triStateBool.yes, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.No, false, "AND");
                    if (this.getDbInformation.checkIfTableContainesData(blockedAccessWarehouse))
                    {
                        userAccessableWarehouse.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                }

            }
            return userAccessableWarehouse;
        }

        public DataTable getCurrentUserAccessableStation(accessLevel userAccessLevel, 
            triStateBool ActiveStations)
        {
            DataTable currentUserAccessableStations = new DataTable();
            DataTable currentUserStationAccess =
                this.getDbInformation.getU_SHOPACCESS(null,"",
                    generalResultInformation.allStationRepresentativeKey,
                    generalResultInformation.userId, userAccessLevel, 
                    triStateBool.yes, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(currentUserStationAccess))
            {
                currentUserStationAccess =
                    this.getDbInformation.getU_SHOPACCESS(null,
                            "", "", generalResultInformation.userId, userAccessLevel,
                            triStateBool.yes, false, "AND");

                if (this.getDbInformation.checkIfTableContainesData(
                        currentUserStationAccess))
                {
                    DataTable searchQuery = new DataTable();

                    searchQuery.Columns.Add("Field");
                    searchQuery.Columns.Add("Criterion");
                    searchQuery.Columns.Add("Value");

                    for (int rowCounter = 0;
                        rowCounter <= currentUserStationAccess.Rows.Count - 1; rowCounter++)
                    {
                        DataRow criteriaValue = searchQuery.NewRow();

                        criteriaValue["Field"] = "M_SHOP_ID";
                        criteriaValue["Criterion"] = " = ";
                        criteriaValue["Value"] =
                            currentUserStationAccess.Rows[rowCounter]["M_SHOP_ID"].ToString();

                        searchQuery.Rows.Add(criteriaValue);
                    }

                    currentUserAccessableStations =
                        this.getDbInformation.getM_SHOPInfo(searchQuery,
                            "OR", "", "", ActiveStations, false, "AND");
                }
                else
                {
                    currentUserAccessableStations =
                        this.getDbInformation.getM_SHOPInfo(null,
                            "", "", "", ActiveStations, false, "AND");
                }
            }
            else
            {
                currentUserAccessableStations =
                    this.getDbInformation.getM_SHOPInfo(null, "", "", 
                            "", ActiveStations, false, "AND");
                for (int rowCounter = currentUserAccessableStations.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if (currentUserAccessableStations.Rows[rowCounter]["M_SHOP_ID"].ToString() == 
                        generalResultInformation.allStationRepresentativeKey)
                    {
                        currentUserAccessableStations.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
            }

            return this.getDbInformation.clearRedundantRow(currentUserAccessableStations, "M_SHOP_ID"); ;
        }

        public DataTable getCurrentUserAccessableOrganisation(accessLevel userAccessLevel,
           triStateBool ActiveOrganisation)
        {
            return this.getCurrentUserAccessableOrganisation(userAccessLevel, ActiveOrganisation, false);
        }
        
        public DataTable getCurrentUserAccessableOrganisation(accessLevel userAccessLevel,
            triStateBool ActiveOrganisation, bool includeAllOrgRepresentativeKey)
        {
            bool UserAccessAllOrganisation = false;
            
            DataTable currentUserAccessableOrganisations = new DataTable();
            
            DataTable currentUserOrganisationAccess =
                this.getDbInformation.getU_ORGACCESS(null,"",
                    generalResultInformation.allStationRepresentativeKey,
                    generalResultInformation.allOrganisationRepresentativeKey,
                    generalResultInformation.userId, userAccessLevel,
                    triStateBool.yes, false, "AND");

            if (this.getDbInformation.checkIfTableContainesData(currentUserOrganisationAccess))
            {
                UserAccessAllOrganisation = true;

            }
            else
            {
                currentUserOrganisationAccess =
                    this.getDbInformation.getU_ORGACCESS(null, "",
                            generalResultInformation.Station,
                            generalResultInformation.allOrganisationRepresentativeKey,
                            generalResultInformation.userId, userAccessLevel,
                            triStateBool.yes, false, "AND");
                
                if (this.getDbInformation.checkIfTableContainesData(currentUserOrganisationAccess))
                {
                    UserAccessAllOrganisation = true;

                }
            }

            if(UserAccessAllOrganisation)
            {
                currentUserAccessableOrganisations =
                    this.getDbInformation.getAD_ORGInfo(null,
                        "", "", "", ActiveOrganisation, false, "AND");

                currentUserAccessableOrganisations = 
                    this.getDbInformation.
                        clearRedundantRow(currentUserAccessableOrganisations, "AD_ORG_ID");

                if (!includeAllOrgRepresentativeKey)
                {
                    for (int rowCounter = currentUserAccessableOrganisations.Rows.Count - 1;
                            rowCounter >= 0; rowCounter--)
                    {
                        if (currentUserAccessableOrganisations.Rows[rowCounter]["AD_ORG_ID"].ToString() ==
                            generalResultInformation.allOrganisationRepresentativeKey)
                        {
                            currentUserAccessableOrganisations.Rows.RemoveAt(rowCounter);
                            break;
                        }
                    }
                }

                return currentUserAccessableOrganisations;
            }

            currentUserOrganisationAccess =
                    this.getDbInformation.getU_ORGACCESS(null, "",
                            generalResultInformation.Station,
                            "",
                            generalResultInformation.userId, userAccessLevel,
                            triStateBool.yes, false, "AND");                          

            currentUserOrganisationAccess =
                this.getDbInformation.mergeTables(currentUserOrganisationAccess,
                            this.getDbInformation.getU_ORGACCESS(null, "",
                                        generalResultInformation.allStationRepresentativeKey,
                                        "",
                                        generalResultInformation.userId, userAccessLevel,
                                        triStateBool.yes, false, "AND"),
                                    "", false);

            if (this.getDbInformation.checkIfTableContainesData(currentUserOrganisationAccess))
            {
                DataTable searchQuery = new DataTable();

                searchQuery.Columns.Add("Field");
                searchQuery.Columns.Add("Criterion");
                searchQuery.Columns.Add("Value");

                if (includeAllOrgRepresentativeKey)
                {
                    DataRow criteriaValue = searchQuery.NewRow();

                    criteriaValue["Field"] = "AD_ORG_ID";
                    criteriaValue["Criterion"] = " = ";
                    criteriaValue["Value"] =
                        generalResultInformation.allOrganisationRepresentativeKey;

                    searchQuery.Rows.Add(criteriaValue);
                }

                for (int rowCounter = 0;
                    rowCounter <= currentUserOrganisationAccess.Rows.Count - 1; rowCounter++)
                {
                    DataRow criteriaValue = searchQuery.NewRow();

                    criteriaValue["Field"] = "AD_ORG_ID";
                    criteriaValue["Criterion"] = " = ";
                    criteriaValue["Value"] =
                        currentUserOrganisationAccess.Rows[rowCounter]["AD_ORG_ID"].ToString();

                    searchQuery.Rows.Add(criteriaValue);
                }

                currentUserAccessableOrganisations =
                    this.getDbInformation.getAD_ORGInfo(searchQuery,
                        "OR", "", "", ActiveOrganisation, false, "AND");


            }
            else
            {
                currentUserAccessableOrganisations =
                    this.getDbInformation.getAD_ORGInfo(null,
                        "", "", "", ActiveOrganisation, true, "AND");
            }

            return this.getDbInformation.clearRedundantRow(currentUserAccessableOrganisations, "AD_ORG_ID");            
        }


        public accessLevel getCurrentUserStaionAccessLevel(string M_SHOP_ID)
        {
            DataTable dtUserStationAccess =
                this.getDbInformation.getU_SHOPACCESS(null, "", M_SHOP_ID, 
                        generalResultInformation.userId, accessLevel.ignor, 
                        triStateBool.yes, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(dtUserStationAccess))
            {
                dtUserStationAccess = 
                    this.getDbInformation.getU_SHOPACCESS(null, "",
                            generalResultInformation.allStationRepresentativeKey,
                            generalResultInformation.userId, accessLevel.ignor,
                            triStateBool.yes, false, "AND");

                if (!this.getDbInformation.checkIfTableContainesData(dtUserStationAccess))
                {
                    return accessLevel.InActive;
                }
            }

            if (dtUserStationAccess.Rows[0]["ACCESSLEVEL"].ToString() == accessLevel.InActive.ToString())
                return accessLevel.InActive;
            if (dtUserStationAccess.Rows[0]["ACCESSLEVEL"].ToString() == accessLevel.ReadOnly.ToString())
                return accessLevel.ReadOnly;
            if (dtUserStationAccess.Rows[0]["ACCESSLEVEL"].ToString() == accessLevel.ReadWite.ToString())
                return accessLevel.ReadWite;
            return accessLevel.InActive;
        }

        public accessLevel getCurrentUserOrganisationAccessLevel(string AD_ORG_ID)
        {
            DataTable dtUserOrganisationAccess =
                this.getDbInformation.getU_ORGACCESS(null, "", 
                       generalResultInformation.Station, AD_ORG_ID,
                       generalResultInformation.userId, accessLevel.ignor,
                        triStateBool.yes, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(dtUserOrganisationAccess))
            {
                dtUserOrganisationAccess =
                    this.getDbInformation.getU_ORGACCESS(null, "",
                            generalResultInformation.allStationRepresentativeKey, AD_ORG_ID,
                            generalResultInformation.userId, accessLevel.ignor,
                            triStateBool.yes, false, "AND");

                if (!this.getDbInformation.checkIfTableContainesData(dtUserOrganisationAccess))
                {
                    dtUserOrganisationAccess =
                            this.getDbInformation.getU_ORGACCESS(null, "",
                                    generalResultInformation.Station,
                                    generalResultInformation.allOrganisationRepresentativeKey,
                                    generalResultInformation.userId, accessLevel.ignor,
                                    triStateBool.yes, false, "AND");
                    if (!this.getDbInformation.checkIfTableContainesData(dtUserOrganisationAccess))
                    {
                        dtUserOrganisationAccess =
                            this.getDbInformation.getU_ORGACCESS(null, "",
                                    generalResultInformation.allStationRepresentativeKey, 
                                    generalResultInformation.allOrganisationRepresentativeKey,
                                    generalResultInformation.userId, accessLevel.ignor,
                                    triStateBool.yes, false, "AND");
                        if (!this.getDbInformation.checkIfTableContainesData(dtUserOrganisationAccess))
                        {
                            return accessLevel.InActive;
                        }
                    }
                }
            }

            if (dtUserOrganisationAccess.Rows[0]["ACCESSLEVEL"].ToString() == accessLevel.InActive.ToString())
                return accessLevel.InActive;
            if (dtUserOrganisationAccess.Rows[0]["ACCESSLEVEL"].ToString() == accessLevel.ReadOnly.ToString())
                return accessLevel.ReadOnly;
            if (dtUserOrganisationAccess.Rows[0]["ACCESSLEVEL"].ToString() == accessLevel.ReadWite.ToString())
                return accessLevel.ReadWite;
            return accessLevel.InActive;
        }



    }
}
