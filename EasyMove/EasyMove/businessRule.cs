using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace EasyMove
{
    class businessRule
    {

        private dataBuilder getDbInformation = new dataBuilder();

        public DataTable buildOrganisationSelectionCriteria(string[] _AD_ORG_ID, 
            bool includeVisibleToAllOrganisation)
        {
            DataTable criteriaTable = new DataTable();
            criteriaTable.Columns.Add("Field");
            criteriaTable.Columns.Add("Criterion");
            criteriaTable.Columns.Add("Value");
            
            foreach (string organisation in _AD_ORG_ID)
            {
                if (organisation == null || organisation == "")
                    continue;
                    DataRow dt = criteriaTable.NewRow();
                    dt["Field"] = "AD_ORG_ID";
                    dt["Criterion"] = "=";
                    dt["Value"] = organisation;
                    criteriaTable.Rows.Add(dt);
            }

            if (includeVisibleToAllOrganisation)
            {
                DataRow dt = criteriaTable.NewRow();
                dt["Field"] = "AD_ORG_ID";
                dt["Criterion"] = "=";
                dt["Value"] = generalResultInformation.allOrganisationRepresentativeKey;
                criteriaTable.Rows.Add(dt);
            }
            return criteriaTable;            
        }

        private DataTable clearDataRowWhichIsNotAccessableByCurrentUser(DataTable tableToClear)
        {
            if (!getDbInformation.checkIfTableContainesData(tableToClear) ||
                !tableToClear.Columns.Contains("AD_ORG_ID") ||
                !getDbInformation.checkIfTableContainesData(tableToClear))
            {
                return tableToClear;
            }

            DataTable currentUserAccessableOrganisation = 
                getOrganisations(true, false);
            bool recordIsAccessable = false;

            for (int currentRecord = tableToClear.Rows.Count - 1;
                currentRecord >= 0; currentRecord--)
            {
                recordIsAccessable = false;
                for (int currentOrganization = currentUserAccessableOrganisation.Rows.Count - 1;
                    currentOrganization >= 0; currentOrganization--)
                    if (tableToClear.Rows[currentRecord]["AD_ORG_ID"].ToString() ==
                        currentUserAccessableOrganisation.Rows[currentOrganization]["AD_ORG_ID"].ToString() ||
                        tableToClear.Rows[currentRecord]["AD_ORG_ID"].ToString() == 
                        generalResultInformation.allOrganisationRepresentativeKey)
                    {
                        recordIsAccessable = true;
                        break;
                    }
                if (!recordIsAccessable)
                    tableToClear.Rows.RemoveAt(currentRecord);
            }

            return tableToClear;
        }

        private DataTable clearTransactionWhichIsNotCurrentUserConcern(DataTable tableToClear, 
            taskType tskTyp)
        {

            bool userIsConcernedWithTransaction = false;
            DataTable dtTransactionDetail = new DataTable();            
            DataTable dtUserWarehouseAccess = new DataTable();
            string trxRecordIDName = "";
            string LocatorFromWareHouseID = "";
            string LocatorToWareHouseID = "";
            string LocatorFromID = "";
            string LocatorToID = "";
                        

            dtUserWarehouseAccess =
                this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "", 
                                generalResultInformation.allWarehouseRepresentativeKey,                                
                                generalResultInformation.userId,
                                generalResultInformation.Station,
                                true, false, "AND");

            if (this.getDbInformation.checkIfTableContainesData(dtUserWarehouseAccess))
            {
                if (tskTyp == taskType.Request)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWREQUEST"].ToString() == "Y")
                    {
                        return tableToClear; 
                    }
                }
                else if (tskTyp == taskType.Order)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCHORDER"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Dispatch)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCH"].ToString() == "Y" ||
                        dtUserWarehouseAccess.Rows[0]["VIEWDELIVERY"].ToString() == "Y" ||
                        dtUserWarehouseAccess.Rows[0]["VIEWDISPUTE"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.In)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYIN"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Out)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYOUT"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Make)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYMAKE"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                } 
            }

            dtUserWarehouseAccess =
                this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                generalResultInformation.allWarehouseRepresentativeKey,
                                generalResultInformation.userId,
                                generalResultInformation.allStationRepresentativeKey,
                                true, false, "AND");

            if (this.getDbInformation.checkIfTableContainesData(dtUserWarehouseAccess))
            {
                if (tskTyp == taskType.Request)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWREQUEST"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Order)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCHORDER"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Dispatch)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCH"].ToString() == "Y" ||
                        dtUserWarehouseAccess.Rows[0]["VIEWDELIVERY"].ToString() == "Y" ||
                        dtUserWarehouseAccess.Rows[0]["VIEWDISPUTE"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.In)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYIN"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Out)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYOUT"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
                else if (tskTyp == taskType.Make)
                {
                    if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYMAKE"].ToString() == "Y")
                    {
                        return tableToClear;
                    }
                }
            }


            if (tskTyp == taskType.Request)
            {
                trxRecordIDName = "M_MOVEREQUEST_ID";
            }
            else if (tskTyp == taskType.Order)
            {
                trxRecordIDName = "M_MOVEORDER_ID";
            }
            else if (tskTyp == taskType.Dispatch)
            {
                trxRecordIDName = "M_MOVEMENT_ID";
            }
            else if (tskTyp == taskType.In)
            {
                trxRecordIDName = "M_INOUT_ID";
            }
            else if (tskTyp == taskType.Out)
            {
                trxRecordIDName = "M_INOUT_ID";
            }
            else if (tskTyp == taskType.Make)
            {
                trxRecordIDName = "M_PRODUCTION_ID";
            }
                        

            if (!tableToClear.Columns.Contains(trxRecordIDName))
            {
                tableToClear.Clear();
                return tableToClear;
            }

            string transactionId = "";

            for (int transactionRowCounter = tableToClear.Rows.Count - 1;
                transactionRowCounter >= 0; transactionRowCounter--)
            {
                userIsConcernedWithTransaction = false;

                transactionId =
                        tableToClear.Rows[transactionRowCounter][trxRecordIDName].ToString();

                if (transactionId != "")
                {
                    if (tskTyp == taskType.Request)
                    {
                        dtTransactionDetail =
                            this.getDbInformation.getEM_M_MOVEREQUESTLINEInfo(null, "", "",
                                            transactionId, "", false, false, "AND");
                    }
                    else if (tskTyp == taskType.Order)
                    {
                        dtTransactionDetail =
                            this.getDbInformation.getM_MOVEORDERLINEInfo(null, "", "",
                                            transactionId, "", "", false, false, "AND");
                    }
                    else if (tskTyp == taskType.In || tskTyp == taskType.Out)
                    {
                        dtTransactionDetail =
                            this.getDbInformation.getM_INOUTLINEInfo(null, "", "",
                                            transactionId, "", "", false, false, "AND");
                    }
                    else if (tskTyp == taskType.Make)
                    {
                        dtTransactionDetail =
                            this.getDbInformation.getM_PRODUCTIONLINEInfo(null, "", "",
                                            transactionId, "", "", false, false, "AND");
                    }
                    else if (tskTyp == taskType.Dispatch)
                    {
                        dtTransactionDetail =
                            this.getDbInformation.getEM_M_MOVEMENTLINEInfo(null, "", "",
                                            transactionId, "", "", false, false, "AND");
                    }
                }
                
                for (int transactionDetailRowCounter = dtTransactionDetail.Rows.Count - 1;
                    transactionDetailRowCounter >= 0; transactionDetailRowCounter--)
                {     

                    LocatorFromID =
                       dtTransactionDetail.Rows[transactionDetailRowCounter]["M_LOCATOR_ID"].ToString();

                    LocatorFromWareHouseID =
                        this.getDbInformation.getEM_M_LOCATORInfo(null, "", LocatorFromID,
                                false, false, "AND").Rows[0]["M_WAREHOUSE_ID"].ToString();

                    if (LocatorFromWareHouseID != "")
                    {
                        dtUserWarehouseAccess =
                            this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                    LocatorFromWareHouseID,
                                    generalResultInformation.userId,
                                    generalResultInformation.allStationRepresentativeKey,
                                    true, false, "AND");

                        if (this.getDbInformation.checkIfTableContainesData(dtUserWarehouseAccess))
                        {
                            if (tskTyp == taskType.Request)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWREQUEST"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }
                            else if (tskTyp == taskType.Order)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCHORDER"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }
                            else if (tskTyp == taskType.Dispatch)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCH"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDELIVERY"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDISPUTE"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }
                            else if (tskTyp == taskType.In)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYIN"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }
                            else if (tskTyp == taskType.Out)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYOUT"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }
                            else if (tskTyp == taskType.Make)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYMAKE"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }

                            dtTransactionDetail.Clear();
                            dtUserWarehouseAccess.Clear();
                            LocatorFromWareHouseID = "";
                            LocatorToWareHouseID = "";
                            LocatorFromID = "";
                            LocatorToID = "";

                            userIsConcernedWithTransaction = true;
                            break;
                        }

                    checkForStationSpecificAccess:
                        dtUserWarehouseAccess =
                            this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                LocatorFromWareHouseID,
                                generalResultInformation.userId,
                                generalResultInformation.Station,
                                true, false, "AND");

                        if (this.getDbInformation.checkIfTableContainesData(dtUserWarehouseAccess))
                        {
                            if (tskTyp == taskType.Request)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWREQUEST"].ToString() == "N")
                                {
                                    goto CHECKLOCATORTO;
                                }
                            }
                            else if (tskTyp == taskType.Order)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCHORDER"].ToString() == "N")
                                {
                                    goto CHECKLOCATORTO;
                                }
                            }
                            else if (tskTyp == taskType.Dispatch)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCH"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDELIVERY"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDISPUTE"].ToString() == "N")
                                {
                                    goto CHECKLOCATORTO;
                                }
                            }
                            else if (tskTyp == taskType.In)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYIN"].ToString() == "N")
                                {
                                    continue;
                                }
                            }
                            else if (tskTyp == taskType.Out)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYOUT"].ToString() == "N")
                                {
                                    continue;
                                }
                            }
                            else if (tskTyp == taskType.Make)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWINVENTORYMAKE"].ToString() == "N")
                                {
                                    continue;
                                }
                            }

                            dtTransactionDetail.Clear();
                            dtUserWarehouseAccess.Clear();
                            LocatorFromWareHouseID = "";
                            LocatorToWareHouseID = "";
                            LocatorFromID = "";
                            LocatorToID = "";

                            userIsConcernedWithTransaction = true;
                            break;
                        }
                    }
                    

                CHECKLOCATORTO:

                    LocatorToID =
                        dtTransactionDetail.Rows[transactionDetailRowCounter]["M_LOCATORTO_ID"].ToString();

                    LocatorToWareHouseID =
                        getDbInformation.getEM_M_LOCATORInfo(null, "", LocatorToID,
                                false, false, "AND").Rows[0]["M_WAREHOUSE_ID"].ToString();

                    if (LocatorToWareHouseID != "")
                    {
                        dtUserWarehouseAccess =
                            this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                    LocatorToWareHouseID,
                                    generalResultInformation.userId,
                                    generalResultInformation.allStationRepresentativeKey,
                                    true, false, "AND");

                        if (this.getDbInformation.checkIfTableContainesData(dtUserWarehouseAccess))
                        {
                            if (tskTyp == taskType.Request)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWREQUEST"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }
                            else if (tskTyp == taskType.Dispatch)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCH"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDELIVERY"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDISPUTE"].ToString() == "N")
                                {
                                    goto checkForStationSpecificAccess;
                                }
                            }

                            dtTransactionDetail.Clear();
                            dtUserWarehouseAccess.Clear();
                            LocatorFromWareHouseID = "";
                            LocatorToWareHouseID = "";
                            LocatorFromID = "";
                            LocatorToID = "";

                            userIsConcernedWithTransaction = true;
                            break;
                        }
                    checkForStationSpecificAccess:
                        dtUserWarehouseAccess =
                            this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                LocatorToWareHouseID,
                                generalResultInformation.userId,
                                generalResultInformation.Station,
                                true, false, "AND");

                        if (this.getDbInformation.checkIfTableContainesData(dtUserWarehouseAccess))
                        {
                            if (tskTyp == taskType.Request)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWREQUEST"].ToString() == "N")
                                {
                                    continue;
                                }
                            }
                            else if (tskTyp == taskType.Dispatch)
                            {
                                if (dtUserWarehouseAccess.Rows[0]["VIEWDISPATCH"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDELIVERY"].ToString() == "N" &&
                                    dtUserWarehouseAccess.Rows[0]["VIEWDISPUTE"].ToString() == "N")
                                {
                                    continue;
                                }
                            }
                            dtTransactionDetail.Clear();
                            dtUserWarehouseAccess.Clear();
                            LocatorFromWareHouseID = "";
                            LocatorToWareHouseID = "";
                            LocatorFromID = "";
                            LocatorToID = "";

                            userIsConcernedWithTransaction = true;
                            break;
                        }
                    }
                }
                if (!userIsConcernedWithTransaction)
                    tableToClear.Rows.RemoveAt(transactionRowCounter);
            }
            return tableToClear;
        }

        public bool validateUser(string userName, string passWord)
        {
            DataTable userInfo = new DataTable();

            if (generalResultInformation.useLDAPAuthentication)
            {
                LDAPConnection authenticate = new LDAPConnection();

                userInfo =
                    this.getDbInformation.getEM_AD_USERInfo(null, "", "", userName, "", true, false, "AND");

                if (!getDbInformation.checkIfTableContainesData(userInfo))
                {
                    MessageBox.Show("Invalid Username Or PassWord", "LogIn Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (userInfo.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid Username Or PassWord", "LogIn Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (!authenticate.validateUser(userName, passWord))
                {
                    MessageBox.Show("Invalid Username Or PassWord", "LogIn Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MD5 md5Hasher = MD5.Create();
                byte[] data =
                    md5Hasher.ComputeHash(Encoding.Default.GetBytes(passWord));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                userInfo =
                    getDbInformation.getEM_AD_USERInfo(null, "AND", "", userName,
                            sBuilder.ToString(), true, false, "AND");


                if (!getDbInformation.checkIfTableContainesData(userInfo) ||
                    userInfo.Rows.Count != 1 ||
                    userInfo.Rows[0]["NAME"].ToString() != userName ||
                    userInfo.Rows[0]["PASSWORD"].ToString() != sBuilder.ToString())
                {
                    MessageBox.Show("Invalid Username Or PassWord", "LogIn Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            DataTable userSationInfo =
                this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "", "",
                            userInfo.Rows[0]["AD_USER_ID"].ToString(),
                            generalResultInformation.Station,
                            true, false, "AND");

            if (userSationInfo.Rows.Count <= 0)
                userSationInfo =
                    this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "", "",
                            userInfo.Rows[0]["AD_USER_ID"].ToString(),
                            generalResultInformation.allStationRepresentativeKey,
                            true, false, "AND");

            if (!getDbInformation.checkIfTableContainesData(userSationInfo))
            {
                MessageBox.Show("You Luck Access privelage On this Station", "LogIn Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            generalResultInformation.userId =
                userInfo.Rows[0]["AD_USER_ID"].ToString();

            this.setUserBPName(generalResultInformation.userId);

            userAccessPrevilageInformation.userStationprevilageIsReadOnly = true;

            for (int rowCounter = 0; rowCounter <= userSationInfo.Rows.Count - 1; rowCounter++)
            {
                if (userSationInfo.Rows[rowCounter]["CREATEREQUEST"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMREQUEST"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["APPROVEREQUEST"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["REJECTREQUEST"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CREATEDISPATCHORDER"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMDISPATCHORDER"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CREATEDISPATCH"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMDISPATCH"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["REFUSEDISPATCH"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["ACCEPTDELIVERY"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMRECIPT"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["REJECTDELIVERY"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["DISPUTEDELIVERY"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["ACCEPTDISPUTE"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["REJECTDISPUTE"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CREATEINVENTORYIN"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMINVENTORYIN"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CREATEINVENTORYOUT"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMINVENTORYOUT"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CREATEINVENTORYMAKE"].ToString() == "Y" ||
                    userSationInfo.Rows[rowCounter]["CONFIRMINVENTORYMAKE"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.userStationprevilageIsReadOnly = false;
                    break;
                }
            }

            userInfo.Dispose();
            userSationInfo.Dispose();
            return true;
            
        }

        public void setUserBPName(string userID)
        {
            if (userID == "")
            {
                generalResultInformation.userBPName = "";
                return;
            }
            DataTable userInfo = 
                this.getDbInformation.getEM_AD_USERInfo(null, "", 
                            userID, "", "", true, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(userInfo))
            {
                generalResultInformation.userBPName = "";
                return; 
            }

            if (userInfo.Rows[0]["C_BPARTNER_ID"].ToString() == "")
            {
                generalResultInformation.userBPName = "";
                return;
            }

            DataTable bpInfo =
                this.getDbInformation.getC_BPARTNERInfo(null, "", 
                        userInfo.Rows[0]["C_BPARTNER_ID"].ToString(), "", 
                            true, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(bpInfo))
            {
                generalResultInformation.userBPName = "";
                return;
            }

            if (bpInfo.Rows[0]["NAME"].ToString() == "")
            {
                generalResultInformation.userBPName = "";
                return;
            }

            generalResultInformation.userBPName =
                bpInfo.Rows[0]["NAME"].ToString();
 
        }

        public DataTable getOrganisations (bool onlyCurrentUserAccessable,bool onlyActive)
        {
            DataTable Organization = new DataTable();
            
            if (onlyCurrentUserAccessable)
                Organization =
                    getDbInformation.getEM_AD_USER_ORGACCESSInfo(null, "", "",
                                 generalResultInformation.userId, triStateBool.ignor, true, false, "AND");
            else
                goto GetallOrganisation;
                
            if (!getDbInformation.checkIfTableContainesData(Organization))
            {
                return Organization;
            }
                        
            for (int rowCounter = Organization.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (Organization.Rows[rowCounter]["AD_ORG_ID"].ToString() ==
                    generalResultInformation.allOrganisationRepresentativeKey)
                {
                    //get All Organisation.
                    Organization.Clear();
                    goto GetallOrganisation;
                        
                }
            }

            if (!getDbInformation.checkIfTableContainesData(Organization))
            {
                return Organization;
            }

            for (int columnCounter = Organization.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (Organization.Columns[columnCounter].ColumnName != "AD_ORG_ID" &&
                    Organization.Columns[columnCounter].ColumnName != "ISREADONLY")
                    Organization.Columns.RemoveAt(columnCounter);                    
            }
            
            Organization.Columns.Add("NAME");            

            for (int rowCounter = Organization.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                Organization.Rows[rowCounter]["NAME"] = 
                    getDbInformation.getEM_AD_ORGInfo(
                                    null,"",Organization.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                                    false, false, "AND").Rows[0]["NAME"].ToString();

                if (Organization.Rows[rowCounter]["NAME"].ToString() == "")
                    Organization.Rows.RemoveAt(rowCounter);
            }

            return Organization;
            
            GetallOrganisation:            
            Organization =
                        getDbInformation.getEM_AD_ORGInfo(null, "", "", onlyActive, false, "");
            
            for (int columnCounter = Organization.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (Organization.Columns[columnCounter].ColumnName != "AD_ORG_ID" &&
                    Organization.Columns[columnCounter].ColumnName != "NAME")
                    Organization.Columns.RemoveAt(columnCounter);
            }
            Organization.Columns.Add("ISREADONLY");
            DataTable dt = getDbInformation.getEM_AD_USER_ORGACCESSInfo(
                                    null, "", generalResultInformation.allOrganisationRepresentativeKey,
                                    generalResultInformation.userId, triStateBool.ignor, true, false, "AND");
            if (getDbInformation.checkIfTableContainesData(dt))
            {
                string readOnlyStatus = dt.Rows[0]["ISREADONLY"].ToString();
                dt.Dispose();
                for (int rowCounter = Organization.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    Organization.Rows[rowCounter]["ISREADONLY"] = readOnlyStatus;                        
                }                
            }
                
            else
            {   
                for (int rowCounter = Organization.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
                {
                    Organization.Rows[rowCounter]["ISREADONLY"] = "C";
                    dt = getDbInformation.getEM_AD_USER_ORGACCESSInfo(
                                        null, "", Organization.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                                        generalResultInformation.userId,
                                        triStateBool.ignor, true, false, "AND");
                    if(getDbInformation.checkIfTableContainesData(dt))
                        Organization.Rows[rowCounter]["ISREADONLY"] = dt.Rows[0]["ISREADONLY"].ToString();
                }
            }

            DataView dv = Organization.DefaultView;
            dv.Sort = "NAME ASC";
            Organization = dv.ToTable();

            return Organization;
        }

        public DataTable getUserAccessableLocators(string AD_USER_ID, triStateBool readOnlyAccess, taskType tskTpy)
        {
            return getUserAccessableLocators(AD_USER_ID, readOnlyAccess, tskTpy, false);
        }

        public DataTable getUserAccessableLocators(string AD_USER_ID, triStateBool readOnlyAccess, taskType tskTpy, bool forNewRecord)
        {
            DataTable dtAccessableWarehouse = 
                this.getUserAccessableWarehouses(AD_USER_ID, readOnlyAccess, tskTpy, forNewRecord);
           
            if (!getDbInformation.checkIfTableContainesData(dtAccessableWarehouse))
            {
                return getDbInformation.getEM_M_LOCATORInfo(null, "", "", false, true, "AND");
            }

            DataTable criteriaTable = new DataTable();
            criteriaTable.Columns.Add("Field");
            criteriaTable.Columns.Add("Criterion");
            criteriaTable.Columns.Add("Value");

            for (int warehouseCounter = 0;
                warehouseCounter <= dtAccessableWarehouse.Rows.Count - 1; warehouseCounter++)
            {
                DataRow dt = criteriaTable.NewRow();
                dt["Field"] = "M_WAREHOUSE_ID";
                dt["Criterion"] = "=";
                dt["Value"] = dtAccessableWarehouse.Rows[warehouseCounter]["M_WAREHOUSE_ID"].ToString();
                criteriaTable.Rows.Add(dt);
            }        

            DataTable dtAccessableLocators = 
                this.getDbInformation.
                    getEM_M_LOCATORInfo(criteriaTable, "OR", "", true, false, "AND");      

            for (int columnCounter = dtAccessableLocators.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (dtAccessableLocators.Columns[columnCounter].ColumnName != "M_WAREHOUSE_ID" &&
                    dtAccessableLocators.Columns[columnCounter].ColumnName != "M_LOCATOR_ID" &&
                    dtAccessableLocators.Columns[columnCounter].ColumnName != "VALUE"
                    )
                    dtAccessableLocators.Columns.Remove(dtAccessableLocators.Columns[columnCounter].ColumnName);
            }

            DataView dv = dtAccessableLocators.DefaultView;
            dv.Sort = "VALUE ASC";
            dtAccessableLocators = dv.ToTable();

            return dtAccessableLocators;
        }
        

        public DataTable getUserAccessableWarehouses(string AD_USER_ID, triStateBool readOnlyAccess, taskType tskTpy, bool forNewRecord)
        {
            if (AD_USER_ID == "")
                AD_USER_ID = generalResultInformation.userId;

            DataTable dtAccessableWarehouse =
                this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                "",
                                AD_USER_ID, generalResultInformation.Station,
                                true, false, "AND");

            if (getDbInformation.checkIfTableContainesData(dtAccessableWarehouse))
            {
                DataTable allStationPrcAccess =
                    this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                "",
                                AD_USER_ID,
                                generalResultInformation.allStationRepresentativeKey,
                                true, false, "AND");
                if (getDbInformation.checkIfTableContainesData(allStationPrcAccess))
                {
                    dtAccessableWarehouse =
                        this.getDbInformation.mergeTables(dtAccessableWarehouse,
                                    allStationPrcAccess, "", false);
                }
            }
            else
            {
                dtAccessableWarehouse =
                    this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "",
                                "",
                                AD_USER_ID,
                                generalResultInformation.allStationRepresentativeKey,
                                true, false, "AND");
            }

            if (!getDbInformation.checkIfTableContainesData(dtAccessableWarehouse))
            {
                return getDbInformation.getEM_M_WAREHOUSEInfo(null, "", "", false, true, "AND");
            }

            if (readOnlyAccess != triStateBool.No)
            {
                for (int rowCounter = dtAccessableWarehouse.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    switch (tskTpy)
                    {
                        case taskType.Request:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWREQUEST"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Order:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWDISPATCHORDER"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Dispatch:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWDISPATCH"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Receive:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWDELIVERY"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["VIEWDISPUTE"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.In:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWINVENTORYIN"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Out:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWINVENTORYOUT"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Make:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["VIEWINVENTORYMAKE"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        default:
                            {
                                dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                continue;
                            }
                    }
                    if (dtAccessableWarehouse.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString() ==
                        generalResultInformation.allWarehouseRepresentativeKey)
                    {
                        dtAccessableWarehouse =
                            this.getDbInformation.getEM_M_WAREHOUSEInfo(null, "", "", true, false, "AND");
                        break;
                    }
                }
            }
            else
            {
                for (int rowCounter = dtAccessableWarehouse.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    switch (tskTpy)
                    {
                        case taskType.Request:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["CREATEREQUEST"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMREQUEST"].ToString() == "N" &&
                                    forNewRecord)
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                else if (dtAccessableWarehouse.Rows[rowCounter]["CREATEREQUEST"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMREQUEST"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["APPROVEREQUEST"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["REJECTREQUEST"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Order:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["CREATEDISPATCHORDER"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMDISPATCHORDER"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Dispatch:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["CREATEDISPATCH"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMDISPATCH"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["REFUSEDISPATCH"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Receive:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["ACCEPTDELIVERY"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMRECIPT"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["REJECTDELIVERY"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["DISPUTEDELIVERY"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["ACCEPTDISPUTE"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["REJECTDISPUTE"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.In:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["CREATEINVENTORYIN"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMINVENTORYIN"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Out:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["CREATEINVENTORYOUT"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMINVENTORYOUT"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        case taskType.Make:
                            {
                                if (dtAccessableWarehouse.Rows[rowCounter]["CREATEINVENTORYMAKE"].ToString() == "N" &&
                                    dtAccessableWarehouse.Rows[rowCounter]["CONFIRMINVENTORYMAKE"].ToString() == "N")
                                {
                                    dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                    continue;
                                }
                                break;
                            }
                        default:
                            {
                                dtAccessableWarehouse.Rows.RemoveAt(rowCounter);
                                continue;
                            }
                    }
                    if (dtAccessableWarehouse.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString() ==
                        generalResultInformation.allWarehouseRepresentativeKey)
                    {
                        dtAccessableWarehouse =
                            this.getDbInformation.getEM_M_WAREHOUSEInfo(null, "", "", true, false, "AND");
                        break;
                    }
                }
            }

            DataTable criteriaTable = new DataTable();
            criteriaTable.Columns.Add("Field");
            criteriaTable.Columns.Add("Criterion");
            criteriaTable.Columns.Add("Value");

            for (int warehouseCounter = 0;
                warehouseCounter <= dtAccessableWarehouse.Rows.Count - 1; warehouseCounter++)
            {
                DataRow dt = criteriaTable.NewRow();
                dt["Field"] = "M_WAREHOUSE_ID";
                dt["Criterion"] = "=";
                dt["Value"] = dtAccessableWarehouse.Rows[warehouseCounter]["M_WAREHOUSE_ID"].ToString();
                criteriaTable.Rows.Add(dt);
            }

            DataTable dtAccessableWrhs =
                this.getDbInformation.getEM_M_WAREHOUSEInfo(criteriaTable, "OR", "", forNewRecord, false, "AND");

            for (int columnCounter = dtAccessableWrhs.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (dtAccessableWrhs.Columns[columnCounter].ColumnName != "M_WAREHOUSE_ID" &&
                    dtAccessableWrhs.Columns[columnCounter].ColumnName != "NAME"
                    )
                    dtAccessableWrhs.Columns.Remove(dtAccessableWrhs.Columns[columnCounter].ColumnName);
            }

            DataView dv = dtAccessableWrhs.DefaultView;
            dv.Sort = "NAME ASC";
            dtAccessableWrhs = dv.ToTable();

            return dtAccessableWrhs;

        }


        public DataTable getWarehouses(bool onlyCurrentUserAccessable,
            bool onlyActive, string AD_ORG_ID, bool includeVisibleToAllOrganisation)
        {
            DataTable Warehouses = new DataTable();
            string[] organisation;
            if (AD_ORG_ID == "")
            {
                DataTable dtOrganisation = this.getOrganisations(onlyCurrentUserAccessable, onlyActive);

                organisation = new string[dtOrganisation.Rows.Count];
                for (int organisationCounter = 0;
                    organisationCounter <= dtOrganisation.Rows.Count - 1; organisationCounter++)
                    organisation[organisationCounter] =
                        dtOrganisation.Rows[organisationCounter]["AD_ORG_ID"].ToString();
            }
            else
            {
                organisation = new string[1];
                organisation[0] = AD_ORG_ID;
            }

            Warehouses = getDbInformation.getEM_M_WAREHOUSEInfo(
                this.buildOrganisationSelectionCriteria(organisation, includeVisibleToAllOrganisation),
                "OR", "", onlyActive, false, "AND");

            if (onlyCurrentUserAccessable)
            {
                Warehouses = clearDataRowWhichIsNotAccessableByCurrentUser(Warehouses);
            }

            if (!getDbInformation.checkIfTableContainesData(Warehouses))
            {
                return Warehouses;
            }

            Warehouses = getDbInformation.clearRedundantRow(Warehouses);

            for (int columnCounter = Warehouses.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (Warehouses.Columns[columnCounter].ColumnName != "AD_ORG_ID" &&
                    Warehouses.Columns[columnCounter].ColumnName != "M_WAREHOUSE_ID" &&
                    Warehouses.Columns[columnCounter].ColumnName != "VALUE"
                    )
                    Warehouses.Columns.Remove(Warehouses.Columns[columnCounter].ColumnName);
            }


            DataView dv = Warehouses.DefaultView;
            dv.Sort = "VALUE ASC";
            Warehouses = dv.ToTable();

            return Warehouses;
        }
        
        public DataTable getLocators (bool onlyCurrentUserAccessable,
            bool onlyActive, string AD_ORG_ID, bool includeVisibleToAllOrganisation)
        {
            DataTable locators = new DataTable();
            string[] organisation;
            if (AD_ORG_ID == "")
            {
                DataTable dtOrganisation = this.getOrganisations(onlyCurrentUserAccessable, onlyActive);

                organisation = new string[dtOrganisation.Rows.Count];
                for (int organisationCounter = 0;
                    organisationCounter <= dtOrganisation.Rows.Count - 1; organisationCounter++)
                    organisation[organisationCounter] =
                        dtOrganisation.Rows[organisationCounter]["AD_ORG_ID"].ToString();
            }
            else
            {
                organisation = new string[1];
                organisation[0] = AD_ORG_ID;
            }

            locators = getDbInformation.getEM_M_LOCATORInfo(
                this.buildOrganisationSelectionCriteria(organisation, includeVisibleToAllOrganisation), 
                "OR", "", onlyActive, false, "AND");

            if (onlyCurrentUserAccessable)
            {
                locators = clearDataRowWhichIsNotAccessableByCurrentUser(locators);
            }
            
            if (!getDbInformation.checkIfTableContainesData(locators))
            {
                return locators;
            }

            locators = getDbInformation.clearRedundantRow(locators);

            for (int columnCounter = locators.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (locators.Columns[columnCounter].ColumnName != "AD_ORG_ID" &&
                    locators.Columns[columnCounter].ColumnName != "M_WAREHOUSE_ID" &&
                    locators.Columns[columnCounter].ColumnName != "M_LOCATOR_ID" &&
                    locators.Columns[columnCounter].ColumnName != "VALUE"
                    )
                    locators.Columns.Remove(locators.Columns[columnCounter].ColumnName);               
            }


            DataView dv = locators.DefaultView;
            dv.Sort = "VALUE ASC";
            locators = dv.ToTable();

            return locators;
        }

        public DataTable getDocuments(bool onlyCurrentUserAccessable,
            bool onlyActive, string AD_ORG_ID, bool includeVisibleToAllOrganisation)
        {
            DataTable documents = new DataTable();
            documents =
                this.getDocuments(onlyCurrentUserAccessable, onlyActive, 
                            AD_ORG_ID, includeVisibleToAllOrganisation,taskType.Request);
            documents = 
                this.getDbInformation.mergeTables(documents,
                    this.getDocuments(onlyCurrentUserAccessable, onlyActive,
                            AD_ORG_ID, includeVisibleToAllOrganisation, taskType.Dispatch),
                            "C_DOCTYPE_ID",false);

            documents = 
                this.getDbInformation.mergeTables(documents,
                    this.getDocuments(onlyCurrentUserAccessable, onlyActive,
                            AD_ORG_ID, includeVisibleToAllOrganisation, taskType.Order),
                            "C_DOCTYPE_ID",false);

            documents = 
                this.getDbInformation.mergeTables(documents,
                    this.getDocuments(onlyCurrentUserAccessable, onlyActive,
                            AD_ORG_ID, includeVisibleToAllOrganisation, taskType.In),
                            "C_DOCTYPE_ID",false);


            documents = 
                this.getDbInformation.mergeTables(documents,
                    this.getDocuments(onlyCurrentUserAccessable, onlyActive,
                            AD_ORG_ID, includeVisibleToAllOrganisation, taskType.Make),
                            "C_DOCTYPE_ID",false);

            documents =
                this.getDbInformation.mergeTables(documents,
                    this.getDocuments(onlyCurrentUserAccessable, onlyActive,
                            AD_ORG_ID, includeVisibleToAllOrganisation, taskType.Out),
                            "C_DOCTYPE_ID", false);

            documents =
                this.getDbInformation.mergeTables(documents,
                    this.getDocuments(onlyCurrentUserAccessable, onlyActive,
                            AD_ORG_ID, includeVisibleToAllOrganisation, taskType.Makeup),
                            "C_DOCTYPE_ID", false);

                   
                    
            DataView dv = documents.DefaultView;
            dv.Sort = "NAME ASC";
            documents = dv.ToTable();

            return documents;
        }

        public bool isDocumentExisting(string documentNumber, taskType trxType)
        {
            if (trxType == taskType.In)
            {
                DataTable trxIN = this.getDbInformation.getV_INOUTDETAILInfo(null, "", "", "",
                            "", "", documentNumber, false, false, "AND", "", "");
                trxIN = this.getDbInformation.clearRedundantRow(trxIN, "DOCUMENTNO");

                for (int rowCounter = 0; rowCounter <= trxIN.Rows.Count - 1; rowCounter++)
                {
                    if (trxIN.Rows[rowCounter]["DOCUMENTNO"].ToString() == documentNumber &&
                        trxIN.Rows[rowCounter]["ISSOTRX"].ToString() == "N")
                    {
                        return true;
                    }
                }
                return false;
 
            }
            else if (trxType == taskType.Dispatch || trxType == taskType.Receive)
            {
                DataTable trxMV = this.getDbInformation.getV_MOVEMENTDETAILInfo(null, "", "", "",
                            "", "", "", documentNumber, "", false, false, "AND", "", "");
                trxMV = this.getDbInformation.clearRedundantRow(trxMV, "DOCUMENTNO");

                for (int rowCounter = 0; rowCounter <= trxMV.Rows.Count - 1; rowCounter++)
                {
                    if (trxMV.Rows[rowCounter]["DOCUMENTNO"].ToString() == documentNumber)
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (trxType == taskType.Make)
            {
                DataTable trxMK = this.getDbInformation.getV_PRODUCTIONDETAILInfo(null, "", "", "",
                            "", "", documentNumber, false, false, "AND", "", "");
                trxMK = this.getDbInformation.clearRedundantRow(trxMK, "NAME");

                for (int rowCounter = 0; rowCounter <= trxMK.Rows.Count - 1; rowCounter++)
                {
                    if (trxMK.Rows[rowCounter]["NAME"].ToString() == documentNumber)
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (trxType == taskType.Out)
            {
                DataTable trxOUT = this.getDbInformation.getV_INOUTDETAILInfo(null, "", "", "",
                            "", "", documentNumber, false, false, "AND", "", "");
                trxOUT = this.getDbInformation.clearRedundantRow(trxOUT, "DOCUMENTNO");

                for (int rowCounter = 0; rowCounter <= trxOUT.Rows.Count - 1; rowCounter++)
                {
                    if (trxOUT.Rows[rowCounter]["DOCUMENTNO"].ToString() == documentNumber &&
                        trxOUT.Rows[rowCounter]["ISSOTRX"].ToString() == "Y")
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public DataTable getDocuments(bool onlyCurrentUserAccessable,
            bool onlyActive, string AD_ORG_ID, bool includeVisibleToAllOrganisation,
            taskType _task)
        {
            DataTable documents = new DataTable();
            string[] organisation = { AD_ORG_ID };
            documents = this.buildOrganisationSelectionCriteria(organisation, includeVisibleToAllOrganisation);
            DataRow dt = documents.NewRow();
            dt["Field"] = "DOCBASETYPE";
            dt["Criterion"] = "=";
            if(_task == taskType.Request)
                dt["Value"] = generalResultInformation.requestDocumentBaseType;
            else if (_task == taskType.Dispatch || _task == taskType.Receive)
                dt["Value"] = generalResultInformation.moveDocumentBaseType;
            else if (_task == taskType.Order)
                dt["Value"] = generalResultInformation.moveOrderDocumentBaseType;
            else if (_task == taskType.In)
                dt["Value"] = generalResultInformation.merchandiseInDocumentBaseType;
            else if (_task == taskType.Make)
                dt["Value"] = generalResultInformation.merchandiseMakeDocumentBaseType;
            else if (_task == taskType.Out)
                dt["Value"] = generalResultInformation.merchandiseOutDocumentBaseType;
            else if (_task == taskType.Makeup)
                dt["Value"] = generalResultInformation.merchandiseMakeUpChangeDocumentBaseType;
            else
                dt["Value"] = generalResultInformation.unkownDocumentBaseType;
            documents.Rows.Add(dt);

            documents =
                getDbInformation.getEM_C_DOCTYPEInfo(documents, "AND", "", onlyActive, false, "AND");
            
            if (onlyCurrentUserAccessable)
            {
                documents = clearDataRowWhichIsNotAccessableByCurrentUser(documents);
            }

            if (!getDbInformation.checkIfTableContainesData(documents))
            {
                return documents;
            }

            for (int columnCounter = documents.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (documents.Columns[columnCounter].ColumnName != "C_DOCTYPE_ID" &&
                    documents.Columns[columnCounter].ColumnName != "NAME")
                    documents.Columns.Remove(documents.Columns[columnCounter].ColumnName);
            }
            DataView dv = documents.DefaultView;
            dv.Sort = "NAME ASC";
            documents = dv.ToTable();

            return documents;
        }

        public DataTable getProducts(bool onlyCurrentUserAccessable,
            bool onlyActive, triStateBool isSold, triStateBool isPurchased,
            triStateBool isMoved, triStateBool isDiscontinued,
            bool IncludeSummaryProducts, string ProductName, string AD_ORG_ID,
            bool includeVisibleToAllOrganisation)
        {


            return this.getProducts(onlyCurrentUserAccessable, onlyActive, isSold,
                        isPurchased, isMoved, triStateBool.ignor, isDiscontinued,
                        IncludeSummaryProducts, ProductName, AD_ORG_ID,
                        includeVisibleToAllOrganisation);
        }


        public DataTable getProducts(bool onlyCurrentUserAccessable,
            bool onlyActive, triStateBool isSold, triStateBool isPurchased,
            triStateBool isMoved, triStateBool isBOM, triStateBool isDiscontinued,
            bool IncludeSummaryProducts, string ProductName, string AD_ORG_ID, 
            bool includeVisibleToAllOrganisation)
        {
            DataTable Products = new DataTable();
            string[] organisation = { AD_ORG_ID };
            Products = 
                this.buildOrganisationSelectionCriteria(organisation, includeVisibleToAllOrganisation);

            if (!IncludeSummaryProducts)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISSUMMARY";
                dt["Criterion"] = "=";
                dt["Value"] = "N";
                Products.Rows.Add(dt);
            }

            if (isSold != triStateBool.ignor)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISSOLD";
                dt["Criterion"] = "=";
                dt["Value"] = isSold == triStateBool.yes ? "Y" : "N";
                Products.Rows.Add(dt);
            }

            if (isPurchased != triStateBool.ignor)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISPURCHASED";
                dt["Criterion"] = "=";
                dt["Value"] = isPurchased == triStateBool.yes ? "Y" : "N";
                Products.Rows.Add(dt);
            }

            if (isMoved != triStateBool.ignor)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISMOVED";
                dt["Criterion"] = "=";
                dt["Value"] = isMoved == triStateBool.yes ? "Y" : "N";
                Products.Rows.Add(dt);
            }

            if (isBOM != triStateBool.ignor)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISBOM";
                dt["Criterion"] = "=";
                dt["Value"] = isBOM == triStateBool.yes ? "Y" : "N";
                Products.Rows.Add(dt);
            }

            if (isDiscontinued != triStateBool.ignor)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "DISCONTINUED";
                dt["Criterion"] = "=";
                dt["Value"] = isDiscontinued == triStateBool.yes ? "Y" : "N";
                Products.Rows.Add(dt);
            }
            
            DataRow dt2 = Products.NewRow();
            dt2["Field"] = "NAME";
            dt2["Criterion"] = "like";
            dt2["Value"] = "%" + ProductName.ToUpper() + "%";
            Products.Rows.Add(dt2);

            Products =
                getDbInformation.getEM_M_PRODUCTInfo(Products, "AND", "", onlyActive, triStateBool.ignor, triStateBool.ignor, false, "AND");

            if (onlyCurrentUserAccessable)
            {
                Products = clearDataRowWhichIsNotAccessableByCurrentUser(Products);
            }

            if (!getDbInformation.checkIfTableContainesData(Products))
            {
                return Products;
            }
            //remove unneccessary fields.
            for (int columnCounter = Products.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (Products.Columns[columnCounter].ColumnName != "M_PRODUCT_ID" &&
                    Products.Columns[columnCounter].ColumnName != "VALUE" &&
                    Products.Columns[columnCounter].ColumnName != "NAME" &&
                    Products.Columns[columnCounter].ColumnName != "ISBOM" &&
                    Products.Columns[columnCounter].ColumnName != "C_UOM_ID" &&
                    Products.Columns[columnCounter].ColumnName != "M_PRODUCT_CATEGORY_ID")
                    Products.Columns.Remove(Products.Columns[columnCounter].ColumnName);
            }

            //Get Proudct's Catagory Name
            Products.Columns.Add("Category");

            for (int rowCounter = Products.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                Products.Rows[rowCounter]["Category"] =
                    getDbInformation.getEM_M_PRODUCT_CATEGORYInfo(null,"", Products.Rows[rowCounter]["M_PRODUCT_CATEGORY_ID"].ToString(),
                                    false, false, "AND").Rows[0]["NAME"].ToString();

                if (Products.Rows[rowCounter]["Category"].ToString() == "")
                    Products.Rows.RemoveAt(rowCounter);
            }

            //Get Product's UOM Name
            Products.Columns.Add("UOM");

            for (int rowCounter = Products.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                Products.Rows[rowCounter]["UOM"] =
                    getDbInformation.getEM_C_UOMInfo(null,"", Products.Rows[rowCounter]["C_UOM_ID"].ToString(),
                                    false, false, "AND").Rows[0]["NAME"].ToString();

                if (Products.Rows[rowCounter]["UOM"].ToString() == "")
                    Products.Rows.RemoveAt(rowCounter);
            }
            
            return Products;
        }

        public decimal getInStockQty(string productID, string locatorID)
        {
            DataTable dtStockInformation =
                this.getDbInformation.getEM_M_STORAGEInfo(null, "",
                    productID, locatorID, true, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(dtStockInformation))
            {
                return 0;
            }

            decimal qtyAvailable = 0;

            for (int stckEntryCounter = 0; stckEntryCounter < dtStockInformation.Rows.Count; stckEntryCounter++)
            {
                qtyAvailable += (decimal.Parse(dtStockInformation.Rows[stckEntryCounter]["QTYONHAND"].ToString()) -
                                 decimal.Parse(dtStockInformation.Rows[stckEntryCounter]["QTYRESERVED"].ToString()));
            }
            return qtyAvailable;
        }

        public bool isStockAvailable(string productID, string locatorID, decimal requiredQty)
        {
            decimal qtyAvailable = 
                this.getInStockQty(productID, locatorID);
 
            if (qtyAvailable >= requiredQty)
                return true;
            else
                return false;            
        }

        public bool isStockAvailable(string productID, decimal requiredQty)
        {
            return isStockAvailable(productID, "", requiredQty);
        }

        public void setUpuserViewPrevilage(string userID, string stationID) 
        {
            userAccessPrevilageInformation.canViewRequest = false;
            userAccessPrevilageInformation.canViewOrder = false;
            userAccessPrevilageInformation.canViewDispatch = false;
            userAccessPrevilageInformation.canViewDispute = false;
            userAccessPrevilageInformation.canViewDelivery = false;
            userAccessPrevilageInformation.canViewInventoryIn = false;
            userAccessPrevilageInformation.canViewInventoryMake = false;
            userAccessPrevilageInformation.canViewInventoryOut = false;
            userAccessPrevilageInformation.canViewInventoryMake = false;
            userAccessPrevilageInformation.canViewProductMakeUPChange = false;

            DataTable dtuserPrivilage = 
                this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "", "", 
                                            userID, stationID, true, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(dtuserPrivilage))
            {
                dtuserPrivilage =
                this.getDbInformation.getEM_PROCESS_ACCESSInfo(null, "", "",
                                            userID, generalResultInformation.allStationRepresentativeKey,
                                            true, false, "AND");

                if (!this.getDbInformation.checkIfTableContainesData(dtuserPrivilage))
                {
                    return;
                }
            }

            if (dtuserPrivilage.Rows.Count == 1)
            {
                userAccessPrevilageInformation.canViewRequest =
                    (dtuserPrivilage.Rows[0]["VIEWREQUEST"].ToString() == "Y");
                userAccessPrevilageInformation.canViewOrder =
                    (dtuserPrivilage.Rows[0]["VIEWDISPATCHORDER"].ToString() == "Y");
                userAccessPrevilageInformation.canViewDispatch =
                    (dtuserPrivilage.Rows[0]["VIEWDISPATCH"].ToString() == "Y");
                userAccessPrevilageInformation.canViewDelivery =
                    (dtuserPrivilage.Rows[0]["VIEWDELIVERY"].ToString() == "Y");
                userAccessPrevilageInformation.canViewDispute =
                    (dtuserPrivilage.Rows[0]["VIEWDISPUTE"].ToString() == "Y");
                userAccessPrevilageInformation.canViewInventoryIn =
                    (dtuserPrivilage.Rows[0]["VIEWINVENTORYIN"].ToString() == "Y");
                userAccessPrevilageInformation.canViewInventoryMake =
                    (dtuserPrivilage.Rows[0]["VIEWINVENTORYMAKE"].ToString() == "Y");
                userAccessPrevilageInformation.canViewInventoryOut =
                    (dtuserPrivilage.Rows[0]["VIEWINVENTORYOUT"].ToString() == "Y");
                userAccessPrevilageInformation.canViewProductMakeUPChange =
                    (dtuserPrivilage.Rows[0]["VIEWPRODUCTMAKEUPCHANGE"].ToString() == "Y");

                return; 
            }


            for (int rowCounter = 0; 
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWREQUEST"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewRequest = true;
                    break;
                }
            }

            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWDISPATCHORDER"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewOrder = true;
                    break;
                }
            }
            
            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWDISPATCH"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewDispatch = true;
                    break;
                }
            }
            
            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWDELIVERY"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewDelivery = true;
                    break;
                }
            }
                        
            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWDISPUTE"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewDispute = true;
                    break;
                }
            }

            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWINVENTORYIN"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewInventoryIn = true;
                    break;
                }
            }
                        
            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWINVENTORYMAKE"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewInventoryMake = true;                  
                    break;
                }
            }

            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWINVENTORYOUT"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewInventoryOut = true;
                    break;
                }
            }

            for (int rowCounter = 0;
                    rowCounter <= dtuserPrivilage.Rows.Count - 1; rowCounter++)
            {
                if (dtuserPrivilage.Rows[rowCounter]["VIEWPRODUCTMAKEUPCHANGE"].ToString() == "Y")
                {
                    userAccessPrevilageInformation.canViewProductMakeUPChange = true;
                    break;
                }
            }
        }

        // Method of Change Applied Is Addition. For Reduced Qty "changeQty" must be -ve.
        public void changeStockQty(string productID, string locatorID, decimal changeQty)
        {
            if (productID == "" || locatorID == "")
            {
                return;
            }

            DataTable dtStockInformation =
                this.getDbInformation.getEM_M_STORAGEInfo(null, "",
                    productID, locatorID, true, false, "AND");

            if (!this.getDbInformation.checkIfTableContainesData(dtStockInformation))
            {
                DataRow drNewStockInformation = dtStockInformation.NewRow();
                drNewStockInformation["M_PRODUCT_ID"] = productID;
                drNewStockInformation["M_LOCATOR_ID"] = locatorID;
                drNewStockInformation["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewStockInformation["AD_ORG_ID"] = 0;
                drNewStockInformation["ISACTIVE"] = "Y";
                drNewStockInformation["CREATEDBY"] = generalResultInformation.userId; ;
                drNewStockInformation["UPDATEDBY"] = generalResultInformation.userId; ;
                drNewStockInformation["QTYONHAND"] = changeQty;
                drNewStockInformation["QTYRESERVED"] = 0;
                drNewStockInformation["QTYORDERED"] = 0;
                drNewStockInformation["M_ATTRIBUTESETINSTANCE_ID"] = 0;

                dtStockInformation.Rows.Add(drNewStockInformation);
                this.getDbInformation.changeDataBaseTableData(dtStockInformation, "EM_M_STORAGE", "INSERT");
                
                return;
            }
            else
            {
                dtStockInformation.Rows[0]["QTYONHAND"] =
                    double.Parse(dtStockInformation.Rows[0]["QTYONHAND"].ToString()) 
                                    + double.Parse(changeQty.ToString());

                this.getDbInformation.changeDataBaseTableData(dtStockInformation, "EM_M_STORAGE", "UPDATE");

                return;
            }            
        }

        public void changeStockQty(DataTable dtStockInfoChange, string changedLocator, bool addToExisting)
        {
            if (changedLocator == "")
            {
                return;
            }

            if (!this.getDbInformation.checkIfTableContainesData(dtStockInfoChange))
            {
                return;
            }

            if (!dtStockInfoChange.Columns.Contains("M_PRODUCT_ID") ||
                !dtStockInfoChange.Columns.Contains("MOVEMENTQTY"))
            {
                return;
            }

            int addChange = 1;
            if (!addToExisting)
                addChange = -1;

            for (int stckChangeCounter = 0; stckChangeCounter < dtStockInfoChange.Rows.Count; stckChangeCounter++)
            {
                this.changeStockQty(dtStockInfoChange.Rows[stckChangeCounter]["M_PRODUCT_ID"].ToString(),
                                    changedLocator,
                                    decimal.Parse(dtStockInfoChange.Rows[stckChangeCounter]["MOVEMENTQTY"].ToString()) * addChange
                                    );                                    
            }            
        }

        
        public DataTable compileResult(DataTable searchResult, taskType _task)
        {
            searchResult.Columns.Add("ORGANISATION");
            searchResult.Columns.Add("IS ACTIVE", System.Type.GetType("System.Boolean"));
            searchResult.Columns.Add("DOCUMENT");
            searchResult.Columns.Add("REQUEST NO");
            searchResult.Columns.Add("M_LOCATOR_ID");
            searchResult.Columns.Add("STORE FROM");
            searchResult.Columns.Add("M_LOCATORTO_ID");
            searchResult.Columns.Add("STORE TO");
            searchResult.Columns.Add("IS REQUEST", System.Type.GetType("System.Boolean"));

            if (_task == taskType.Request)
            {
                searchResult.Columns["REQUESTDATE"].ColumnName = "DATE";
                searchResult.Columns["REQUESTSTATUS"].ColumnName = "STATUS";
            }
            else if (_task == taskType.Order)
            {
                searchResult.Columns["ORDERDATE"].ColumnName = "DATE";
                searchResult.Columns["ORDERSTATUS"].ColumnName = "STATUS";
            }
            else if (_task == taskType.Receive || _task == taskType.Dispatch)
            {
                searchResult.Columns["MOVEMENTDATE"].ColumnName = "DATE";
                searchResult.Columns["MOVESTATUS"].ColumnName = "STATUS";
                searchResult.Columns["REQUEST NO"].ColumnName = "ORDER NO";
            }

            if (!getDbInformation.checkIfTableContainesData(searchResult))
            {
                goto formatResult;
            }

            string m_MOVEREQUEST_ID = "";
            string m_MOVEORDER_ID = "";

            for (int currentMovement = searchResult.Rows.Count - 1;
                currentMovement >= 0; currentMovement--)
            {
                DataTable movementLine = new DataTable();

                if (_task == taskType.Request)
                {
                    movementLine =
                        getDbInformation.getEM_M_MOVEREQUESTLINEInfo(null, "", "",
                            searchResult.Rows[currentMovement]["M_MOVEREQUEST_ID"].ToString(),
                            "", false, false, "AND");
                    searchResult.Rows[currentMovement]["IS REQUEST"] = true;
                }
                else if (_task == taskType.Order)
                {
                    m_MOVEREQUEST_ID =
                        searchResult.Rows[currentMovement]["M_MOVEREQUEST_ID"].ToString();

                    if (m_MOVEREQUEST_ID != "")
                    {
                        DataTable requestInfo = 
                            getDbInformation.getEM_M_MOVEREQUESTInfo(null, "", 
                                        m_MOVEREQUEST_ID, "", false, false, "AND");
                        if (!this.getDbInformation.checkIfTableContainesData(requestInfo))
                        {
                            searchResult.Rows[currentMovement]["REQUEST NO"] = "N/A";
                        }
                        else
                        {
                            searchResult.Rows[currentMovement]["REQUEST NO"] =
                                requestInfo.Rows[0]["DOCUMENTNO"].ToString();
                        }
                    }
                        

                    movementLine =
                        getDbInformation.getM_MOVEORDERLINEInfo(null, "", "",
                            searchResult.Rows[currentMovement]["M_MOVEORDER_ID"].ToString(),
                            "", "", false, false, "AND");
                    searchResult.Rows[currentMovement]["IS REQUEST"] = true;
                }
                else if (_task == taskType.Receive || _task == taskType.Dispatch)
                {
                    m_MOVEORDER_ID =
                        searchResult.Rows[currentMovement]["M_MOVEORDER_ID"].ToString();

                    if (m_MOVEORDER_ID != "")
                    {
                        DataTable moveOrderInfo = 
                            getDbInformation.getM_MOVEORDERInfo(null, "", 
                                    m_MOVEORDER_ID, "", "", false, false, "AND");

                        if (!this.getDbInformation.checkIfTableContainesData(moveOrderInfo))
                        {
                            searchResult.Rows[currentMovement]["ORDER NO"] = "N/A";
                        }
                        else
                        {
                            searchResult.Rows[currentMovement]["ORDER NO"] =
                                moveOrderInfo.Rows[0]["DOCUMENTNO"].ToString();
                        }
                    }
                        

                    movementLine =
                        getDbInformation.getEM_M_MOVEMENTLINEInfo(null, "", "",
                            searchResult.Rows[currentMovement]["M_MOVEMENT_ID"].ToString(),
                            "", "", false, false, "AND");
                    searchResult.Rows[currentMovement]["IS REQUEST"] = false;
                }

                searchResult.Rows[currentMovement]["ORGANISATION"] =
                    getDbInformation.getEM_AD_ORGInfo(null, "",
                    searchResult.Rows[currentMovement]["AD_ORG_ID"].ToString(),
                    false, false, "AND").Rows[0]["NAME"].ToString();

                if (searchResult.Rows[currentMovement]["ISACTIVE"].ToString() == "Y")
                    searchResult.Rows[currentMovement]["IS ACTIVE"] = true;
                else
                    searchResult.Rows[currentMovement]["IS ACTIVE"] = false;

                searchResult.Rows[currentMovement]["DOCUMENT"] =
                    getDbInformation.getEM_C_DOCTYPEInfo(null, "",
                    searchResult.Rows[currentMovement]["C_DOCTYPE_ID"].ToString(),
                    false, false, "AND").Rows[0]["NAME"].ToString();
                

                if (this.getDbInformation.checkIfTableContainesData(movementLine))
                {
                    searchResult.Rows[currentMovement]["M_LOCATOR_ID"] =
                        movementLine.Rows[0]["M_LOCATOR_ID"].ToString();

                    searchResult.Rows[currentMovement]["M_LOCATORTO_ID"] =
                        movementLine.Rows[0]["M_LOCATORTO_ID"].ToString();
                }
                else
                {
                    searchResult.Rows.RemoveAt(currentMovement);
                    continue;
                }
                
                searchResult.Rows[currentMovement]["STORE FROM"] =
                        getDbInformation.getEM_M_LOCATORInfo(null, "",
                        searchResult.Rows[currentMovement]["M_LOCATOR_ID"].ToString(),
                        false, false, "AND").Rows[0]["VALUE"].ToString();

                searchResult.Rows[currentMovement]["STORE TO"] =
                    getDbInformation.getEM_M_LOCATORInfo(null, "",
                    searchResult.Rows[currentMovement]["M_LOCATORTO_ID"].ToString(),
                    false, false, "AND").Rows[0]["VALUE"].ToString();
                
            }

        formatResult:
                        
            searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("AD_CLIENT_ID"));
            searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("ISACTIVE"));
            searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("CREATED"));
            //searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("CREATEDBY"));
            //searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("UPDATEDBY"));
            searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("UPDATED"));
            searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("Is Active"));
            
            if (_task == taskType.Request)
            {
                searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("REQUEST NO"));
            }
            if (_task == taskType.Receive || _task == taskType.Dispatch)
            {
                searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("ISINTRANSIT"));
            }
            searchResult.Columns.RemoveAt(searchResult.Columns.IndexOf("ISAPPROVED"));


            return this.clearTransactionWhichIsNotCurrentUserConcern(searchResult, _task);
        }

        public DataTable getMovementListInAccordanceWithSearchCriteria(DataTable searchCriterion,
            string logicalConnector, string stQuery)
        {
            DataTable searchResult = new DataTable();

            searchResult =
                this.getDbInformation.getV_MOVEMENTDETAILInfo(searchCriterion, logicalConnector,
                        "", "", "", "", "", "", "", true, false, "AND", stQuery, logicalConnector);

            if (!getDbInformation.checkIfTableContainesData(searchResult))
            {
                searchResult = getDbInformation.getEM_M_MOVEMENTInfo(null, "", "", "", "", false, true, "");
                return this.compileResult(searchResult, taskType.Dispatch);
            }

            searchResult = this.getDbInformation.clearRedundantRow(searchResult, "M_MOVEMENT_ID");

            for (int columnCounter = searchResult.Columns.Count - 1;
                    columnCounter >= 0; columnCounter--)
                if (searchResult.Columns[columnCounter].ColumnName != "M_MOVEMENT_ID")
                    searchResult.Columns.RemoveAt(columnCounter);

            searchResult.Columns.Add("Field");
            searchResult.Columns.Add("Criterion");
            searchResult.Columns["M_MOVEMENT_ID"].ColumnName = "Value";
            
            for (int currentMovement = searchResult.Rows.Count - 1;
                currentMovement >= 0; currentMovement--)
            {
                searchResult.Rows[currentMovement]["Field"] = "M_MOVEMENT_ID";
                searchResult.Rows[currentMovement]["Criterion"] = "=";
            }

            searchResult =
                getDbInformation.getEM_M_MOVEMENTInfo(searchResult, "OR", "", "", "", false, false, "AND");

            return this.compileResult(searchResult, taskType.Dispatch);
        }
        
        public DataTable getMovementRequestListInAccordanceWithSearchCriteria(DataTable searchCriterion,
            string logicalConnector, string stQuery)
        {
            DataTable searchResult = new DataTable();
                        
            searchResult = 
                this.getDbInformation.getV_REQUESTDETAILInfo(searchCriterion, logicalConnector,
                        "", "", "", "", "", false, false, "AND", stQuery, logicalConnector);

            if (!getDbInformation.checkIfTableContainesData(searchResult))
            {
                searchResult = 
                    getDbInformation.getEM_M_MOVEREQUESTInfo(null, "", "", "", false, true, "");
                return this.compileResult(searchResult, taskType.Request);
            }

            for (int columnCounter = searchResult.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (searchResult.Columns[columnCounter].ColumnName != "M_MOVEREQUEST_ID")
                    searchResult.Columns.RemoveAt(columnCounter);
            }

            searchResult = 
                this.getDbInformation.clearRedundantRow(searchResult, "M_MOVEREQUEST_ID");

            searchResult.Columns.Add("Field");
            searchResult.Columns.Add("Criterion");
            searchResult.Columns["M_MOVEREQUEST_ID"].ColumnName = "Value";


            for (int currentMovement = searchResult.Rows.Count - 1;
                currentMovement >= 0; currentMovement--)
            {
                searchResult.Rows[currentMovement]["Field"] = "M_MOVEREQUEST_ID";
                searchResult.Rows[currentMovement]["Criterion"] = "=";
            }

            searchResult =
                getDbInformation.getEM_M_MOVEREQUESTInfo(searchResult, "OR", "", "", false, false, "AND");
        
            return this.compileResult(searchResult, taskType.Request);
        }

        public DataTable getMovementOrderListInAccordanceWithSearchCriteria(DataTable searchCriterion,
            string logicalConnector, string stQuery)
        {
            DataTable searchResult = new DataTable();

            searchResult =
                this.getDbInformation.getV_MOVEORDERDETAILInfo(searchCriterion, logicalConnector,
                        "", "", "", "", "", "", "", 
                        false, false, "AND", stQuery, logicalConnector);

            if (!getDbInformation.checkIfTableContainesData(searchResult))
            {
                searchResult =
                    getDbInformation.getM_MOVEORDERInfo(null, "", "", "", "", false, true, "");
                return this.compileResult(searchResult, taskType.Order);
            }

            for (int columnCounter = searchResult.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (searchResult.Columns[columnCounter].ColumnName != "M_MOVEORDER_ID")
                    searchResult.Columns.RemoveAt(columnCounter);
            }

            searchResult =
                this.getDbInformation.clearRedundantRow(searchResult, "M_MOVEORDER_ID");

            searchResult.Columns.Add("Field");
            searchResult.Columns.Add("Criterion");
            searchResult.Columns["M_MOVEORDER_ID"].ColumnName = "Value";


            for (int currentMovement = searchResult.Rows.Count - 1;
                currentMovement >= 0; currentMovement--)
            {
                searchResult.Rows[currentMovement]["Field"] = "M_MOVEORDER_ID";
                searchResult.Rows[currentMovement]["Criterion"] = "=";
            }

            searchResult =
                getDbInformation.getM_MOVEORDERInfo(searchResult, "OR", "", "", "", false, false, "AND");
            
            return this.compileResult(searchResult, taskType.Order);
        }


        public DataTable getMovementRequestResult(DataTable searchCriterion, string logicConnector,
            bool isRequest, string stQuery)
        {
            return this.getMovementRequestResult(searchCriterion, logicConnector, isRequest, false, stQuery);
        }

        public DataTable getMovementRequestResult(DataTable searchCriterion, string logicConnector,
            bool isRequest, bool isOrder, string stQuery)
        {
            DataTable movementRequestResult = new DataTable();
            if (isRequest || isOrder)
            {
                if (!isOrder)
                {
                    movementRequestResult =
                       this.getMovementRequestListInAccordanceWithSearchCriteria(searchCriterion, logicConnector, stQuery);
                }
                else
                {
                    movementRequestResult =
                       this.getMovementOrderListInAccordanceWithSearchCriteria(searchCriterion,
                            logicConnector, stQuery);
                }                
            }
            else            
            {
                movementRequestResult =
                    this.getMovementListInAccordanceWithSearchCriteria(searchCriterion, logicConnector, stQuery);
                
            }
            
            return movementRequestResult;

        }


        string un = "passMeIn";
        string pwd = "toMyEncryption";

        public DataTable readEncryptedXmlSettingFile(string file)
        {
            DataTable aDataTable = new DataTable();
            

            XMLEncryptor decryptSettings = new XMLEncryptor(un, pwd);
            aDataTable = decryptSettings.ReadEncryptedXML(file);

            if (aDataTable == null)
            {
                aDataTable = new DataTable();
                aDataTable.TableName = "Settings";
                aDataTable.Columns.Add("Parameter_Name");
                aDataTable.Columns.Add("Parameter_Value"); 
            }

            return aDataTable;            
        }

        public void writeDatatableToEncryptedXmlSettingFile(DataTable settings, string file)
        {
            XMLEncryptor encryptSettings = new XMLEncryptor(un, pwd);
            encryptSettings.WriteEncryptedXML(settings, file);            
        }
        
        public bool userCanModifySettings(string AD_USER_ID)
        {
            DataTable criteriaTable = new DataTable();
            DataTable userRoleResult = new DataTable();

            string[] allowedRoles = new string[] { "1000000", "351000003", "0" };

            criteriaTable.Columns.Add("Field");
            criteriaTable.Columns.Add("Criterion");
            criteriaTable.Columns.Add("Value");

            for (int counter = 0; counter <= allowedRoles.Length - 1; counter++)
            {
                DataRow criteriaValue = criteriaTable.NewRow();

                criteriaValue["Field"] = "AD_ROLE_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = allowedRoles[counter];
                criteriaTable.Rows.Add(criteriaValue);
            }

            userRoleResult = this.getDbInformation.getEM_AD_USER_ROLESInfo(criteriaTable, "OR", AD_USER_ID, "", true, false, "AND");

            return this.getDbInformation.checkIfTableContainesData(userRoleResult);
        }
    
    }
}
