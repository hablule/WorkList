	public DataTable getV_TRXDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_TRANSACTION_ID, string T_TRXDETAIL_ID, string DOCUMENTNO, string M_BPARTNER_ID,
				string M_PRODUCT_ID, string M_WAREHOUSE_ID, string M_SHOP_ID, string M_PRODUCTCATEGORY_ID,
				DateTime TRXDATE, bool considerDatePrameter, triStateBool ISSALESTRX, triStateBool ActiveRecords,
				triStateBool PROCESSED, transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_TRXDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (ISSALESTRX != triStateBool.ignor)
            {
                if (ISSALESTRX == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'Y'";
                else if (ISSALESTRX == triStateBool.No)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector + 
                    "`DOCSTATUS` = '"+ 
                        DOCSTATUS.ToString().Substring(0,2).ToUpperInvariant() +"'";
            }
			
			if (TRXDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`TRXDATE` = " + TRXDATE.ToString("yyyy-MM-dd");
			
			if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";

            if (T_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`T_TRANSACTION_ID` = " + T_TRANSACTION_ID;
				
			if (T_TRXDETAIL_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL_ID` = " + T_TRXDETAIL_ID;

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;
				
			if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;
				
			if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL_ID` = " + M_WAREHOUSE_ID;
				
			if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL_ID` = " + M_WAREHOUSE_ID;
				
			if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL_ID` = " + M_WAREHOUSE_ID;
				
			
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_TRXDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);			
		}
	
	public DataTable getT_TRANSACTIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_TRANSACTION_ID, string DOCUMENTNO, string M_BPARTNER_ID, DateTime TRXDATE,
                    bool considerDatePrameter, triStateBool ISSALESTRX, triStateBool ActiveRecords,
                    triStateBool PROCESSED, transactionStatus DOCSTATUS,
				    bool structureOnly, string logicalConnector)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_TRANSACTION");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (ISSALESTRX != triStateBool.ignor)
            {
                if (ISSALESTRX == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'Y'";
                else if (ISSALESTRX == triStateBool.No)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector + 
                    "`DOCSTATUS` = '"+ 
                        DOCSTATUS.ToString().Substring(0,2).ToUpperInvariant() +"'";
            }

            if (T_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`T_TRANSACTION_ID` = " + T_TRANSACTION_ID;

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;

            if (TRXDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`TRXDATE` = " + TRXDATE.ToString("yyyy-MM-dd");
			
			if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_TRANSACTION` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);			
		}
        
    public DataTable getT_TRXDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_TRXDETAIL_ID, string T_TRANSACTION_ID, string M_BPARTNER_ID, DateTime TRXDATE, 
                    bool considerDatePrameter, triStateBool ISSALESTRX, string M_PRODUCT_ID,
				    triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_TRXDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (ISSALESTRX != triStateBool.ignor)
            {
                if (ISSALESTRX == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'Y'";
                else if (ISSALESTRX == triStateBool.No)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'N'";
            }
			
			if (T_TRXDETAIL_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL` = " + T_TRXDETAIL_ID;

            if (T_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`T_TRANSACTION_ID` = " + T_TRANSACTION_ID;

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;
			
			if (TRXDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`TRXDATE` = " + TRXDATE.ToString("yyyy-MM-dd");
			
			if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
            
         string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_TRXDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
		}

		
	public DataTable getM_WarehouseInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_WAREHOUSE_ID, string NAME, triStateBool AllowNegative, triStateBool ActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_WAREHOUSE");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (AllowNegative == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (AllowNegative == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (AllowNegative != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ALLOWNEGATIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ALLOWNEGATIVE` = 'N'";
            }            

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_WAREHOUSE` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

		
		
	public DataTable getM_SHOPInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_SHOP_ID, string NAME, triStateBool ActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_SHOP");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_SHOP` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        
	public DataTable getM_BPARTNERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BPARTNER_ID, string NAME, triStateBool ActiveRecords, 
            triStateBool ISVENDOR, triStateBool ISCUSTOMER, bool structureOnly, 
            string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_BPARTNER");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (ISVENDOR != triStateBool.ignor)
            {
                if (ISVENDOR == triStateBool.yes)
                    whereClause += logicalConnector + "`ISVENDOR` = 'Y'";
                else if (ISVENDOR == triStateBool.No)
                    whereClause += logicalConnector + "`ISVENDOR` = 'N'";
            }

            if (ISCUSTOMER != triStateBool.ignor)
            {
                if (ISCUSTOMER == triStateBool.yes)
                    whereClause += logicalConnector + "`ISCUSTOMER` = 'Y'";
                else if (ISCUSTOMER == triStateBool.No)
                    whereClause += logicalConnector + "`ISCUSTOMER` = 'N'";
            }

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_BPARTNER` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
	
	public DataTable getM_PRODUCTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_UOM_ID, string M_PRODUCTCATEGORY_ID, string CODE, string NAME,
			string PRODUCTTYPE, string UPC_EAN, string IMAGEPATH, triStateBool ActiveRecords, 
            bool structureOnly, string logicalConnector, int resultLimit)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCT");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;
				
			if (M_UOM_ID != "")
                whereClause += logicalConnector + "`M_UOM_ID` = " + M_UOM_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;
			
			if (CODE != "")
                whereClause += logicalConnector + "`CODE` LIKE '%" + CODE + "%'";
			
            if (NAME != "")
                whereClause += logicalConnector + "`NAME` LIKE '%" + NAME + "%'";
				
			if (PRODUCTTYPE != "")
                whereClause += logicalConnector + "`PRODUCTTYPE` = '" + PRODUCTTYPE + "'";
			
			if (UPC_EAN != "")
                whereClause += logicalConnector + "`UPC_EAN` = '" + UPC_EAN + "'";
			
			if (IMAGEPATH != "")
                whereClause += logicalConnector + "`IMAGEPATH` = '" + IMAGEPATH + "'";
			
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                               "FROM `M_PRODUCT` " + whereClause;
            if (resultLimit > 0)         
                getRequestedTableInformation = 
                    getRequestedTableInformation + " LIMIT 0 ," + resultLimit;
            

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
		}

	public DataTable getM_PRODUCTCATEGORYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTCATEGORY_ID, string NAME, triStateBool ActiveRecords,
                bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCTCATEGORY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTCATEGORY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

	
		