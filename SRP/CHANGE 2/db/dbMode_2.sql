CREATE OR REPLACE VIEW `V_TRXDETAIL` AS
SELECT 
	ORDER.T_TRANSACTION_ID AS T_TRANSACTION_ID,
	ORDER.M_SHOP_ID AS M_SHOP_ID,
	ORDER.AD_ORG_ID AS AD_ORG_ID,
	ORDER.DOCUMENTNO AS DOCUMENTNO,
	ORDER.TRXDATE AS TRXDATE,
	ORDER.M_BPARTNER_ID AS M_BPARTNER_ID,
	ORDER.ISSALESTRX AS ISSALESTRX,
	ORDER.SUBTRXAMOUNT AS SUBTRXAMOUNT,
	ORDER.GRANDTRXAMOUNT AS GRANDTRXAMOUNT,
	ORDER.TRXTAXAMOUNT AS TRXTAXAMOUNT,
	ORDER.ISPAID AS ISPAID,
	ORDER.PAYMENTRULE AS PAYMENTRULE,
	ORDER.DESCRIPTION AS DESCRIPTION,
	ORDER.ISACTIVE AS ISACTIVE,
	ORDER.DOCSTATUS AS DOCSTATUS,
	ORDER.PROCESSED AS PROCESSED,
	ORDERLINE.T_TRXDETAIL_ID AS T_TRXDETAIL_ID,
	ORDERLINE.LINE AS LINE,
	ORDERLINE.M_PRODUCT_ID AS M_PRODUCT_ID,
	ORDERLINE.M_UOM_ID AS M_UOM_ID,
	ORDERLINE.M_WAREHOUSE_ID AS M_WAREHOUSE_ID,
	ORDERLINE.TRXQUANTITY AS TRXQUANTITY,
	ORDERLINE.DESCRIPTION AS LINE_DESCRIPTION,
	ORDERLINE.UNITPRICE AS UNITPRICE,
	ORDERLINE.DISCOUNTRATE AS DISCOUNTRATE,
	ORDERLINE.DISCOUNTAMT AS DISCOUNTAMT,
	ORDERLINE.MARGIN AS MARGIN,
	ORDERLINE.UNITCOST AS UNITCOST,
	ORDERLINE.LINENETAMT AS LINENETAMT,
	ORDERLINE.LINETAXAMOUNT AS LINETAXAMOUNT,
	PRD.CODE AS CODE,
	PRD.CODE2 AS CODE2,
	PRD.UPC_EAN AS BAR,
	PRD.NAME AS PRODUCT,	
	PRD.M_PRODUCTCATEGORY_ID AS M_PRODUCTCATEGORY_ID,
	PRD_CAT.NAME AS CATEGORY,
	UOM.NAME AS UNIT,
	UOM.ABBREVATION AS UOM,
	BPRTNER.NAME AS BUSINESSPARTNER,
	STATION.NAME AS STATION,
	ORG.NAME AS ORGANISATION,
	WAREHOUSE.NAME AS WAREHOUSE
FROM (((((((`T_TRANSACTION` `ORDER` LEFT JOIN `T_TRXDETAIL` `ORDERLINE`
ON `ORDER`.`T_TRANSACTION_ID` = `ORDERLINE`.`T_TRANSACTION_ID`) 
LEFT JOIN `M_PRODUCT` `PRD`
ON `ORDERLINE`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`)
LEFT JOIN `M_PRODUCTCATEGORY` `PRD_CAT`
ON `PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)
LEFT JOIN `M_UOM` `UOM`
ON `ORDERLINE`.`M_UOM_ID` = `UOM`.`M_UOM_ID`)
LEFT JOIN `M_BPARTNER` `BPRTNER`
ON `ORDER`.`M_BPARTNER_ID` = `BPRTNER`.`M_BPARTNER_ID`)
LEFT JOIN `M_SHOP` `STATION`
ON `ORDER`.`M_SHOP_ID` = `STATION`.`M_SHOP_ID`)
LEFT JOIN `AD_ORG` `ORG`
ON `ORDER`.`AD_ORG_ID` = `ORG`.`AD_ORG_ID`)
LEFT JOIN `M_WAREHOUSE` `WAREHOUSE`
ON `ORDERLINE`.`M_WAREHOUSE_ID` = `WAREHOUSE`.`M_WAREHOUSE_ID`;


-- ----------------------------------------




CREATE OR REPLACE VIEW `V_PHYSICALCOUNTDETAIL` AS
SELECT
	COUNT.T_PHYSICALCOUNT_ID AS T_PHYSICALCOUNT_ID,
	COUNT.M_SHOP_ID AS M_SHOP_ID,
	COUNT.AD_ORG_ID AS AD_ORG_ID,
	COUNT.DOCUMENTNO AS DOCUMENTNO,
	COUNT.COUNTDATE AS COUNTDATE,
	COUNT.M_WAREHOUSE_ID AS M_WAREHOUSE_ID,
	COUNT.DESCRIPTION AS DESCRIPTION,
	COUNT.ISACTIVE AS ISACTIVE,
	COUNT.DOCSTATUS AS DOCSTATUS,
	COUNT.PROCESSED AS PROCESSED,
	COUNTLINE.T_PHYSICALCOUNTDETAIL_ID AS T_PHYSICALCOUNTDETAIL_ID,	
	COUNTLINE.LINE AS LINE,
	COUNTLINE.M_PRODUCT_ID AS M_PRODUCT_ID,
	COUNTLINE.M_UOM_ID AS M_UOM_ID,	
	COUNTLINE.BOOKQUANTITY AS BOOKQUANTITY,
	COUNTLINE.COUNTQUANTITY AS COUNTQUANTITY,
	COUNTLINE.DESCRIPTION AS LINE_DESCRIPTION,
	PRD.CODE AS CODE,
	PRD.CODE2 AS CODE2,
	PRD.UPC_EAN AS BAR,
	PRD.NAME AS PRODUCT,
	PRD.M_PRODUCTCATEGORY_ID AS M_PRODUCTCATEGORY_ID,
	PRD_CAT.NAME AS CATEGORY,
	UOM.NAME AS UNIT,
	UOM.ABBREVATION AS UOM,
	STATION.NAME AS STATION,
	WAREHOUSE.NAME AS WAREHOUSE,
	ORG.NAME AS ORGANISATION
FROM ((((((`T_PHYSICALCOUNT` `COUNT` LEFT JOIN `T_PHYSICALCOUNTDETAIL` `COUNTLINE`
ON `COUNT`.`T_PHYSICALCOUNT_ID` = `COUNTLINE`.`T_PHYSICALCOUNT_ID`) 
LEFT JOIN `M_PRODUCT` `PRD`
ON `COUNTLINE`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`)
LEFT JOIN `M_PRODUCTCATEGORY` `PRD_CAT`
ON `PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)
LEFT JOIN `M_UOM` `UOM`
ON `COUNTLINE`.`M_UOM_ID` = `UOM`.`M_UOM_ID`)
LEFT JOIN `M_SHOP` `STATION`
ON `COUNT`.`M_SHOP_ID` = `STATION`.`M_SHOP_ID`)
LEFT JOIN `AD_ORG` `ORG`
ON `COUNT`.`AD_ORG_ID` = `ORG`.`AD_ORG_ID`)
LEFT JOIN `M_WAREHOUSE` `WAREHOUSE`
ON `COUNT`.`M_WAREHOUSE_ID` = `WAREHOUSE`.`M_WAREHOUSE_ID`;


-- --------------------------------------------------------


CREATE OR REPLACE VIEW `V_INVENTORYUSEDETAIL` AS
SELECT
	USAGE.T_INVENTORYUSE_ID AS T_INVENTORYUSE_ID,
	USAGE.M_SHOP_ID AS M_SHOP_ID,
	USAGE.AD_ORG_ID AS AD_ORG_ID,
	USAGE.DOCUMENTNO AS DOCUMENTNO,
	USAGE.USEDATE AS USEDATE,
	USAGE.M_WAREHOUSEFROM_ID AS M_WAREHOUSEFROM_ID,
	USAGE.DESCRIPTION AS DESCRIPTION,
	USAGE.ISACTIVE AS ISACTIVE,
	USAGE.DOCSTATUS AS DOCSTATUS,
	USAGE.PROCESSED AS PROCESSED,
	USAGELINE.T_INVENTORYUSEDETAIL_ID AS T_INVENTORYUSEDETAIL_ID,
	USAGELINE.LINE AS LINE,
	USAGELINE.M_PRODUCT_ID AS M_PRODUCT_ID,
	USAGELINE.M_UOM_ID AS M_UOM_ID,
	USAGELINE.DESCRIPTION AS LINE_DESCRIPTION,
	USAGELINE.USEDQUANTITY AS USEDQUANTITY,
	PRD.CODE AS CODE,
	PRD.CODE2 AS CODE2,
	PRD.UPC_EAN AS BAR,
	PRD.NAME AS PRODUCT,
	PRD.M_PRODUCTCATEGORY_ID AS M_PRODUCTCATEGORY_ID,
	PRD_CAT.NAME AS CATEGORY,
	UOM.NAME AS UNIT,
	UOM.ABBREVATION AS UOM,	
	STATION.NAME AS STATION,
	WAREHOUSE.NAME AS WAREHOUSE,
	ORG.NAME AS ORGANISATION
FROM ((((((`T_INVENTORYUSE` `USAGE` LEFT JOIN `T_INVENTORYUSEDETAIL` `USAGELINE`
ON `USAGE`.`T_INVENTORYUSE_ID` = `USAGELINE`.`T_INVENTORYUSE_ID`) 
LEFT JOIN `M_PRODUCT` `PRD`
ON `USAGELINE`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`)
LEFT JOIN `M_PRODUCTCATEGORY` `PRD_CAT`
ON `PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)
LEFT JOIN `M_UOM` `UOM`
ON `USAGELINE`.`M_UOM_ID` = `UOM`.`M_UOM_ID`)
LEFT JOIN `M_SHOP` `STATION`
ON `USAGE`.`M_SHOP_ID` = `STATION`.`M_SHOP_ID`)
LEFT JOIN `AD_ORG` `ORG`
ON `USAGE`.`AD_ORG_ID` = `ORG`.`AD_ORG_ID`)
LEFT JOIN `M_WAREHOUSE` `WAREHOUSE`
ON `USAGE`.`M_WAREHOUSEFROM_ID` = `WAREHOUSE`.`M_WAREHOUSE_ID`;

-- ------------------------------------



CREATE OR REPLACE VIEW `V_MOVEMENTDETAIL` AS
SELECT
	MOVEMENT.T_MOVEMENT_ID AS T_MOVEMENT_ID,
	MOVEMENT.M_SHOP_ID AS M_SHOP_ID,
	MOVEMENT.AD_ORG_ID AS AD_ORG_ID,
	MOVEMENT.DOCUMENTNO AS DOCUMENTNO,
	MOVEMENT.MOVEDATE AS MOVEDATE,	
	MOVEMENT.DESCRIPTION AS DESCRIPTION,
	MOVEMENT.ISACTIVE AS ISACTIVE,
	MOVEMENT.DOCSTATUS AS DOCSTATUS,
	MOVEMENT.PROCESSED AS PROCESSED,
	MOVEMENTLINE.T_MOVEMENTDETAIL_ID AS T_MOVEMENTDETAIL_ID,	
	MOVEMENTLINE.M_WAREHOUSEFROM_ID AS M_WAREHOUSEFROM_ID,
	MOVEMENTLINE.M_WAREHOUSETO_ID AS M_WAREHOUSETO_ID,
	MOVEMENTLINE.LINE AS LINE,
	MOVEMENTLINE.M_PRODUCT_ID AS M_PRODUCT_ID,
	MOVEMENTLINE.M_UOM_ID AS M_UOM_ID,
	MOVEMENTLINE.MOVEQUANTITY AS MOVEQUANTITY,
	MOVEMENTLINE.DESCRIPTION AS LINE_DESCRIPTION,
	PRD.CODE AS CODE,
	PRD.CODE2 AS CODE2,
	PRD.UPC_EAN AS BAR,
	PRD.NAME AS PRODUCT,
	PRD.M_PRODUCTCATEGORY_ID AS M_PRODUCTCATEGORY_ID,
	PRD_CAT.NAME AS CATEGORY,
	UOM.NAME AS UNIT,
	UOM.ABBREVATION AS UOM,
	STATION.NAME AS STATION,
	WAREHOUSE.MOVEDFROM AS MOVEDFROM,
	WAREHOUSE.MOVEDTO AS MOVEDTO,
	ORG.NAME AS ORGANISATION
FROM (((((((`T_MOVEMENT` `MOVEMENT` LEFT JOIN `T_MOVEMENTDETAIL` `MOVEMENTLINE`
ON `MOVEMENT`.`T_MOVEMENT_ID` = `MOVEMENTLINE`.`T_MOVEMENT_ID`) 
LEFT JOIN `M_PRODUCT` `PRD`
ON `MOVEMENTLINE`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`)
LEFT JOIN `M_PRODUCTCATEGORY` `PRD_CAT`
ON `PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)
LEFT JOIN `M_UOM` `UOM`
ON `MOVEMENTLINE`.`M_UOM_ID` = `UOM`.`M_UOM_ID`)
LEFT JOIN `M_SHOP` `STATION`
ON `MOVEMENT`.`M_SHOP_ID` = `STATION`.`M_SHOP_ID`)
LEFT JOIN `AD_ORG` `ORG`
ON `MOVEMENT`.`AD_ORG_ID` = `ORG`.`AD_ORG_ID`)
LEFT JOIN `V_WAREHOUSEMOVEMENT` `WAREHOUSE`
ON `MOVEMENTLINE`.`T_MOVEMENTDETAIL_ID` = `WAREHOUSE`.`T_MOVEMENTDETAIL_ID`);


-- -----------------------------------------------------


CREATE OR REPLACE VIEW `V_TRANSACTIONSUMMARY` AS
SELECT
	TRANSACTION.M_TRANSACTION_ID AS M_TRANSACTION_ID,
	TRANSACTION.AD_CLIENT_ID AS AD_CLIENT_ID,
	TRANSACTION.M_SHOP_ID AS M_SHOP_ID,
	TRANSACTION.AD_ORG_ID AS AD_ORG_ID,	
	TRANSACTION.MOVEMENTTYPE AS MOVEMENTTYPE,
	TRANSACTION.M_LOCATOR_ID AS M_LOCATOR_ID,
	TRANSACTION.M_PRODUCT_ID AS M_PRODUCT_ID,
	TRANSACTION.MOVEMENTDATE AS MOVEMENTDATE,
	TRANSACTION.MOVEMENTQTY AS MOVEMENTQTY,
	TRANSACTION.C_UOM_ID AS C_UOM_ID,	
	TRANSACTION.M_INOUTLINE_ID AS M_INOUTLINE_ID,
	TRANSACTION.M_MOVEMENTLINE_ID AS M_MOVEMENTLINE_ID,	
	TRANSACTION.M_INVENTORYLINE_ID AS M_INVENTORYLINE_ID,
	TRANSACTION.T_INVENTORYUSEDETAIL_ID AS T_INVENTORYUSEDETAIL_ID,
	GET_DOCUMENTNO(TRANSACTION.M_TRANSACTION_ID) AS DOCUMENTNO,
	TRX_TYPE (TRANSACTION.M_TRANSACTION_ID) AS Type,
	PRD.CODE AS CODE,
	PRD.CODE2 AS CODE2,
	PRD.UPC_EAN AS BAR,
	PRD.NAME AS PRODUCT,
	PRD.M_PRODUCTCATEGORY_ID AS M_PRODUCTCATEGORY_ID,
	PRD_CAT.NAME AS CATEGORY,
	UOM.NAME AS UNIT,
	UOM.ABBREVATION AS UOM,
	STATION.NAME AS STATION,
	WAREHOUSE.NAME AS WAREHOUSE,
	ORG.NAME AS ORGANISATION
FROM (((((`M_TRANSACTION` `TRANSACTION` INNER JOIN `M_PRODUCT` `PRD`
ON `TRANSACTION`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`)
INNER JOIN `M_PRODUCTCATEGORY` `PRD_CAT`
ON `PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)
INNER JOIN `M_UOM` `UOM`
ON `TRANSACTION`.`C_UOM_ID` = `UOM`.`M_UOM_ID`)
INNER JOIN `M_SHOP` `STATION`
ON `TRANSACTION`.`M_SHOP_ID` = `STATION`.`M_SHOP_ID`)
INNER JOIN `AD_ORG` `ORG`
ON `TRANSACTION`.`AD_ORG_ID` = `ORG`.`AD_ORG_ID`)
INNER JOIN `M_WAREHOUSE` `WAREHOUSE`
ON `TRANSACTION`.`M_LOCATOR_ID` = `WAREHOUSE`.`M_WAREHOUSE_ID`;


-- -------------------------------------------

CREATE OR REPLACE VIEW `V_STORAGEDETAIL` AS
SELECT 
	PRD.CODE AS CODE,
	PRD.CODE2 AS CODE2,
	PRD.UPC_EAN AS BAR,
	PRD.NAME AS PRODUCT,
	PRD.M_UOM_ID AS M_UOM_ID,
	PRD.M_PRODUCTCATEGORY_ID AS M_PRODUCTCATEGORY_ID,
	PRD_CAT.NAME AS CATEGORY,
	UOM.NAME AS UNIT,
	UOM.ABBREVATION AS UOM,
	STOCK.M_PRODUCT_ID AS M_PRODUCT_ID,
	STOCK.M_WAREHOUSE_ID AS M_WAREHOUSE_ID,
	STOCK.CURRENTQTY AS CURRENTQTY,
	STORE.NAME AS WAREHOUSE,
	STORE.ALLOWNEGATIVE AS ALLOWNEGATIVE	
FROM (((`Q_STOCK` `STOCK` LEFT JOIN `M_WAREHOUSE` `STORE`
ON `STOCK`.`M_WAREHOUSE_ID` = `STORE`.`M_WAREHOUSE_ID`)
LEFT JOIN `M_PRODUCT` `PRD`
ON `STOCK`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`)
LEFT JOIN `M_PRODUCTCATEGORY` `PRD_CAT`
ON `PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)
LEFT JOIN `M_UOM` `UOM`
ON `PRD`.`M_UOM_ID` = `UOM`.`M_UOM_ID`;

-- -------------------------------

CREATE OR REPLACE VIEW `V_STORAGESUMMARY` AS
SELECT 
	CODE,
	CODE2,
	BAR,
	PRODUCT,
	M_UOM_ID,
	M_PRODUCTCATEGORY_ID,
	CATEGORY,
	UNIT,
	UOM,
	M_PRODUCT_ID,	
	SUM(CURRENTQTY) AS CURRENTQTY
FROM `V_STORAGEDETAIL`
GROUP BY CODE,CODE2,BAR,PRODUCT,M_UOM_ID,M_PRODUCTCATEGORY_ID,CATEGORY,UNIT,UOM,M_PRODUCT_ID;


-- ----------------------------


CREATE OR REPLACE VIEW `v_productstoragedetail` 
AS 
SELECT 
	`PRD`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,
	`PRD`.`CODE` AS `CODE`,
	`PRD`.`CODE2` AS CODE2,
	`PRD`.`UPC_EAN` AS BAR,
	`PRD`.`NAME` AS `PRODUCT`,
	`PRD`.`M_UOM_ID` AS `M_UOM_ID`,
	`PRD`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,
	`PRD`.`NAME` AS `CATEGORY`,
	`UOM`.`NAME` AS `UNIT`,
	`UOM`.`ABBREVATION` AS `UOM`,
	coalesce(`STOCK`.`M_WAREHOUSE_ID`,0) AS `M_WAREHOUSE_ID`,
	coalesce(`STOCK`.`CURRENTQTY`,'N/A') AS `CURRENTQTY`,
	coalesce(`STORE`.`NAME`,'N/A') AS `WAREHOUSE`,
	coalesce(`STORE`.`ALLOWNEGATIVE`,'N/A') AS `ALLOWNEGATIVE` 
FROM ((((`M_PRODUCT` `PRD` left join `Q_STOCK` `STOCK` 
	on((`STOCK`.`M_PRODUCT_ID` = `PRD`.`M_PRODUCT_ID`))) left join 
	`M_WAREHOUSE` `STORE` on((`STOCK`.`M_WAREHOUSE_ID` = `STORE`.`M_WAREHOUSE_ID`))) 
	left join `M_PRODUCTCATEGORY` `PRD_CAT` 
		on((`PRD`.`M_PRODUCTCATEGORY_ID` = `PRD_CAT`.`M_PRODUCTCATEGORY_ID`)))
	left join `M_UOM` `UOM` on((`PRD`.`M_UOM_ID` = `UOM`.`M_UOM_ID`)));
	
	
-- ---------------------------------------


CREATE OR REPLACE VIEW `v_prductcategory` 
AS
 SELECT 
	`PRD`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,
	`PRD`.`M_SHOP_ID` AS `M_SHOP_ID`,
	`PRD`.`AD_ORG_ID` AS `AD_ORG_ID`,
	`PRD`.`CREATED` AS `CREATED`,
	`PRD`.`CREATEDBY` AS `CREATEDBY`,
	`PRD`.`UPDATED` AS `UPDATED`,
	`PRD`.`UPDATEDBY` AS `UPDATEDBY`,
	`PRD`.`CODE` AS `CODE`,
	`PRD`.`CODE2` AS CODE2,
	`PRD`.`UPC_EAN` AS BAR,
	`PRD`.`NAME` AS `NAME`,
	`PRD`.`ISACTIVE` AS `ISACTIVE`,
	`PRD`.`DESCRIPTION` AS `DESCRIPTION`,
	`PRD`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,
	`PRD`.`M_UOM_ID` AS `M_UOM_ID`,
	`PRD`.`PRODUCTTYPE` AS `PRODUCTTYPE`,
	`PRD`.`UPC_EAN` AS `UPC_EAN`,
	`PRD`.`IMAGEPATH` AS `IMAGEPATH`,
	`PRD`.`PURCHASEPRICE` AS `PURCHASEPRICE`,
	`PRD`.`SELLINGPRICE` AS `SELLINGPRICE`,
	`CAT`.`NAME` AS `CATEGORY` 
 FROM (`M_PRODUCT` `PRD` left join `M_PRODUCTCATEGORY` `CAT` 
	on((`PRD`.`M_PRODUCTCATEGORY_ID` = `CAT`.`M_PRODUCTCATEGORY_ID`)));
