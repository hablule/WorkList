-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 18, 2012 at 05:27 AM
-- Server version: 5.1.37
-- PHP Version: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Database: `liquiddb`
--

-- --------------------------------------------------------

--
-- Table structure for table `c_city`
--

CREATE TABLE IF NOT EXISTS `c_city` (
  `C_CITY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `M_COUNTRY_ID` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `COUNTRY` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISDEFAULT` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`C_CITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `c_city`
--


-- --------------------------------------------------------

--
-- Table structure for table `c_country`
--

CREATE TABLE IF NOT EXISTS `c_country` (
  `C_COUNTRY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISDEFAULT` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`C_COUNTRY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `c_country`
--

INSERT INTO `c_country` (`C_COUNTRY_ID`, `M_SHOP_ID`, `NAME`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `DESCRIPTION`, `ISACTIVE`, `ISDEFAULT`) VALUES
(1000000, 0, 'Ethiopia', '2012-03-17 12:06:08', 1000000, '2012-03-17 12:06:08', 1000000, NULL, 'Y', 'Y');

-- --------------------------------------------------------

--
-- Table structure for table `c_locality`
--

CREATE TABLE IF NOT EXISTS `c_locality` (
  `C_LOCALITY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `C_CITY_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISSUMMARY` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PARENTLOCALITY_ID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`C_LOCALITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `c_locality`
--


-- --------------------------------------------------------

--
-- Table structure for table `c_sublocality`
--

CREATE TABLE IF NOT EXISTS `c_sublocality` (
  `C_SUBLOCALITY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `C_LOCALITY_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISSUMMARY` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PARENTSUBLOC_ID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`C_SUBLOCALITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `c_sublocality`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_bpartner`
--

CREATE TABLE IF NOT EXISTS `m_bpartner` (
  `M_BPARTNER_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `NAME2` varchar(60) COLLATE utf8_unicode_ci DEFAULT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ADDRESS1` varchar(60) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ADDRESS2` varchar(60) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ADDRESS3` varchar(60) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ADDRESS4` varchar(60) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CITYNAME` varchar(60) COLLATE utf8_unicode_ci DEFAULT NULL,
  `LOCALITYNAME` varchar(40) COLLATE utf8_unicode_ci DEFAULT NULL,
  `C_COUNTRY_ID` int(10) DEFAULT NULL,
  `C_CITY_ID` int(10) DEFAULT NULL,
  `C_LOCALITY_ID` int(10) DEFAULT NULL,
  `C_SUBLOCALITY_ID` int(10) DEFAULT NULL,
  `POSTAL` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PHONE` varchar(40) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PHONE2` varchar(40) COLLATE utf8_unicode_ci DEFAULT NULL,
  `FAX` varchar(40) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TIN` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `VATREGNO` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISVENDOR` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `ISCUSTOMER` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  PRIMARY KEY (`M_BPARTNER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_bpartner`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_product`
--

CREATE TABLE IF NOT EXISTS `m_product` (
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `CODE` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `M_PRODUCTCATEGORY_ID` int(10) NOT NULL DEFAULT '0',
  `M_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `PRODUCTTYPE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `UPC_EAN` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `IMAGEPATH` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PURCHASEPRICE` double(15,5) DEFAULT '0.00000',
  `SELLINGPRICE` double(15,5) DEFAULT '0.00000',
  PRIMARY KEY (`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_product`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_productcategory`
--

CREATE TABLE IF NOT EXISTS `m_productcategory` (
  `M_PRODUCTCATEGORY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_PRODUCTCATEGORY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_productcategory`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_shop`
--

CREATE TABLE IF NOT EXISTS `m_shop` (
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_SHOP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_shop`
--

INSERT INTO `m_shop` (`M_SHOP_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES
(0, '2011-06-29 13:07:54', 1000000, '2011-06-29 13:07:54', 1000000, '*', 'Y', 'All Shops'),
(1000000, '2011-06-29 13:07:54', 1000000, '2011-06-29 13:07:54', 1000000, 'Head Quarter', 'Y', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `m_transaction`
--

CREATE TABLE IF NOT EXISTS `m_transaction` (
  `M_TRANSACTION_ID` int(10) NOT NULL DEFAULT '0',
  `AD_CLIENT_ID` int(10) NOT NULL DEFAULT '0',
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `MOVEMENTTYPE` enum('BL','V+','V-','M+','M-','I+','I-',' C+','C-') COLLATE utf8_unicode_ci NOT NULL DEFAULT 'BL',
  `M_LOCATOR_ID` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `MOVEMENTDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `MOVEMENTQTY` double(15,9) NOT NULL DEFAULT '0.000000000',
  `C_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `M_INVENTORYLINE_ID` int(10) DEFAULT NULL,
  `M_MOVEMENTLINE_ID` int(10) DEFAULT NULL,
  `M_INOUTLINE_ID` int(10) DEFAULT NULL,
  `M_PRODUCTIONLINE_ID` int(10) DEFAULT NULL,
  `C_PROJECTISSUE_ID` int(10) DEFAULT NULL,
  `M_ATTRIBUTESETINSTANCE_ID` int(10) NOT NULL DEFAULT '0',
  `PP_COST_COLLECTOR_ID` int(10) DEFAULT NULL,
  PRIMARY KEY (`M_TRANSACTION_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_transaction`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_uom`
--

CREATE TABLE IF NOT EXISTS `m_uom` (
  `M_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `STDPRECISION` int(1) NOT NULL DEFAULT '0',
  `ABBREVATION` varchar(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_UOM_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_uom`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_uom_conversion`
--

CREATE TABLE IF NOT EXISTS `m_uom_conversion` (
  `M_UOM_CONVERSION_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `M_BASE_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `M_DRIVED_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MULTIPLIER` double(15,5) DEFAULT '0.00000',
  PRIMARY KEY (`M_UOM_CONVERSION_ID`),
  UNIQUE KEY `M_BASE_UOM_ID` (`M_BASE_UOM_ID`,`M_DRIVED_UOM_ID`,`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_uom_conversion`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_warehouse`
--

CREATE TABLE IF NOT EXISTS `m_warehouse` (
  `M_WAREHOUSE_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ALLOWNEGATIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_warehouse`
--


-- --------------------------------------------------------

--
-- Table structure for table `q_cost`
--

CREATE TABLE IF NOT EXISTS `q_cost` (
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `CURRENTQTY` double(15,5) DEFAULT '0.00000',
  `CURRENTCOST` double(15,5) DEFAULT '0.00000',
  `ACCUMULATEDQTY` double(15,5) DEFAULT '0.00000',
  `ACCUMULATEDCOST` double(15,5) DEFAULT '0.00000',
  PRIMARY KEY (`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `q_cost`
--


-- --------------------------------------------------------

--
-- Table structure for table `q_stock`
--

CREATE TABLE IF NOT EXISTS `q_stock` (
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_WAREHOUSE_ID` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `CURRENTQTY` double(15,5) DEFAULT NULL,
  PRIMARY KEY (`M_PRODUCT_ID`,`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `q_stock`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_inventoryuse`
--

CREATE TABLE IF NOT EXISTS `t_inventoryuse` (
  `T_INVENTORYUSE_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `USEDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL DEFAULT '0',
  `DOCSTATUS` varchar(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_INVENTORYUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_inventoryuse`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_inventoryusedetail`
--

CREATE TABLE IF NOT EXISTS `t_inventoryusedetail` (
  `T_INVENTORYUSEDETAIL_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `T_INVENTORYUSE_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `USEDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `LINE` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `USEDQUANTITY` double(15,5) NOT NULL DEFAULT '0.00000',
  PRIMARY KEY (`T_INVENTORYUSEDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_inventoryusedetail`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_movement`
--

CREATE TABLE IF NOT EXISTS `t_movement` (
  `T_MOVEMENT_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MOVEDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL DEFAULT '0',
  `M_WAREHOUSETO_ID` int(10) NOT NULL DEFAULT '0',
  `DOCSTATUS` varchar(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_MOVEMENT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_movement`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_movementdetail`
--

CREATE TABLE IF NOT EXISTS `t_movementdetail` (
  `T_MOVEMENTDETAIL_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `T_MOVEMENT_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `MOVEDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL DEFAULT '0',
  `M_WAREHOUSETO_ID` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `LINE` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MOVEQUANTITY` double(15,5) NOT NULL DEFAULT '0.00000',
  PRIMARY KEY (`T_MOVEMENTDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_movementdetail`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_physicalcount`
--

CREATE TABLE IF NOT EXISTS `t_physicalcount` (
  `T_PHYSICALCOUNT_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `COUNTDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_WAREHOUSE_ID` int(10) NOT NULL DEFAULT '0',
  `DOCSTATUS` varchar(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_PHYSICALCOUNT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_physicalcount`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_physicalcountdetail`
--

CREATE TABLE IF NOT EXISTS `t_physicalcountdetail` (
  `T_PHYSICALCOUNTDETAIL_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `T_PHYSICALCOUNT_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `COUNTDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_WAREHOUSE_ID` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `LINE` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `BOOKQUANTITY` double(15,5) NOT NULL DEFAULT '0.00000',
  `COUNTQUANTITY` double(15,5) NOT NULL DEFAULT '0.00000',
  PRIMARY KEY (`T_PHYSICALCOUNTDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_physicalcountdetail`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_transaction`
--

CREATE TABLE IF NOT EXISTS `t_transaction` (
  `T_TRANSACTION_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TRXDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_BPARTNER_ID` int(10) NOT NULL DEFAULT '0',
  `ISSALESTRX` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `SUBTRXAMOUNT` double(15,2) DEFAULT NULL,
  `GRANDTRXAMOUNT` double(15,2) DEFAULT NULL,
  `TRXTAXAMOUNT` double(15,2) DEFAULT NULL,
  `ISPAID` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `PAYMENTRULE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'P',
  `DOCSTATUS` varchar(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_TRANSACTION_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_transaction`
--


-- --------------------------------------------------------

--
-- Table structure for table `t_trxdetail`
--

CREATE TABLE IF NOT EXISTS `t_trxdetail` (
  `T_TRXDETAIL_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `T_TRANSACTION_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `TRXDATE` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `M_BPARTNER_ID` int(10) NOT NULL DEFAULT '0',
  `ISSALESTRX` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `LINE` int(10) NOT NULL DEFAULT '0',
  `M_PRODUCT_ID` int(10) NOT NULL DEFAULT '0',
  `M_UOM_ID` int(10) NOT NULL DEFAULT '0',
  `M_WAREHOUSE_ID` int(10) NOT NULL DEFAULT '0',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TRXQUANTITY` double(15,5) NOT NULL DEFAULT '0.00000',
  `UNITPRICE` double(15,2) DEFAULT '0.00',
  `DISCOUNTRATE` double(15,5) DEFAULT '0.00000',
  `DISCOUNTAMT` double(15,2) DEFAULT '0.00',
  `MARGIN` double(15,5) DEFAULT '0.00000',
  `UNITCOST` double(15,5) DEFAULT '0.00000',
  `LINENETAMT` double(15,2) DEFAULT '0.00',
  `LINETAXAMOUNT` double(15,2) DEFAULT '0.00',
  PRIMARY KEY (`T_TRXDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_trxdetail`
--


-- --------------------------------------------------------

--
-- Table structure for table `u_activeshopid`
--

CREATE TABLE IF NOT EXISTS `u_activeshopid` (
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`M_SHOP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_activeshopid`
--


-- --------------------------------------------------------

--
-- Table structure for table `u_formaccess`
--

CREATE TABLE IF NOT EXISTS `u_formaccess` (
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `U_USER_ID` int(10) NOT NULL DEFAULT '0',
  `FORMNAME` varchar(30) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ACCESSLEVEL` varchar(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'NA',
  PRIMARY KEY (`M_SHOP_ID`,`U_USER_ID`,`FORMNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_formaccess`
--


-- --------------------------------------------------------

--
-- Table structure for table `u_sequence`
--

CREATE TABLE IF NOT EXISTS `u_sequence` (
  `U_SEQUENCE_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISTABLEID` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `BASEDOC` varchar(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `CURRENTNEXT` int(10) DEFAULT NULL,
  PRIMARY KEY (`U_SEQUENCE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_sequence`
--

INSERT INTO `u_sequence` (`U_SEQUENCE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `ISTABLEID`, `BASEDOC`, `CURRENTNEXT`) VALUES
(1000000, '2011-06-19 16:31:29', 1000000, '2011-06-19 16:31:29', 1000000, 'U_SEQUENCE', 'Y', 'Y', '', 1000000),
(1000001, '2011-06-19 16:31:29', 1000000, '2012-03-17 12:06:08', 1000000, 'C_CITY', 'Y', 'Y', '', 1000000),
(1000002, '2011-06-19 16:31:29', 1000000, '2012-03-17 12:06:29', 1000000, 'C_LOCALITY', 'Y', 'Y', '', 1000000),
(1000003, '2011-06-19 16:31:29', 1000000, '2012-03-17 12:06:34', 1000000, 'C_SUBLOCALITY', 'Y', 'Y', '', 1000000),
(1000004, '2011-06-19 16:31:29', 1000000, '2012-03-17 12:03:38', 1000000, 'M_UOM', 'Y', 'Y', '', 1000000),
(1000005, '2011-06-19 16:31:29', 1000000, '2012-03-23 12:50:46', 1000000, 'M_PRODUCTCATEGORY', 'Y', 'Y', '', 1000000),
(1000006, '2011-06-19 16:31:29', 1000000, '2012-04-16 20:38:36', 1000000, 'M_PRODUCT', 'Y', 'Y', '', 1000000),
(1000007, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:48:57', 1000000, 'M_BPARTNER', 'Y', 'Y', '', 1000000),
(1000008, '2011-06-19 16:31:29', 1000000, '2011-06-29 13:07:54', 1000000, 'M_SHOP', 'Y', 'Y', '', 1000000),
(1000009, '2011-06-19 16:31:29', 1000000, '2011-07-30 16:50:44', 1000000, 'U_USER', 'Y', 'Y', '', 1000000),
(1000010, '2011-06-19 16:31:29', 1000000, '2012-04-18 06:42:40', 1000000, 'T_TRANSACTION', 'Y', 'Y', '', 1000000),
(1000011, '2011-06-19 16:31:29', 1000000, '2012-04-18 06:42:40', 1000000, 'T_TRXDETAIL', 'Y', 'Y', '', 1000000),
(1000012, '2011-06-19 16:31:29', 1000000, '2011-07-02 12:21:10', 1000000, 'M_UOM_CONVERSION', 'Y', 'Y', '', 1000000),
(1000013, '2011-06-19 16:31:29', 1000000, '2012-04-18 06:42:40', 1000000, 'PURCHASE', 'Y', 'N', 'PURCHASE', 1000),
(1000014, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:50:06', 1000000, 'SALES', 'Y', 'N', 'SALES', 1000),
(1000015, '2011-06-19 16:31:29', 1000000, '2011-07-30 16:45:46', 1000000, 'M_WAREHOUSE', 'Y', 'Y', '', 1000000),
(1000016, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:52:51', 1000000, 'T_MOVEMENT', 'Y', 'Y', '', 1000000),
(1000017, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:52:52', 1000000, 'T_MOVEMENTDETAIL', 'Y', 'Y', '', 1000000),
(1000018, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:52:51', 1000000, 'MOVE', 'Y', 'N', 'MOVE', 1000),
(1000019, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:56:26', 1000000, 'USE', 'Y', 'N', 'USE', 1000),
(1000020, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:54:03', 1000000, 'COUNT', 'Y', 'N', 'COUNT', 1000),
(1000021, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:54:03', 1000000, 'T_PHYSICALCOUNT', 'Y', 'Y', '', 1000000),
(1000022, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:54:04', 1000000, 'T_PHYSICALCOUNTDETAIL', 'Y', 'Y', '', 1000000),
(1000023, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:56:26', 1000000, 'T_INVENTORYUSE', 'Y', 'Y', '', 1000000),
(1000024, '2011-06-19 16:31:29', 1000000, '2012-04-18 04:56:27', 1000000, 'T_INVENTORYUSEDETAIL', 'Y', 'Y', '', 1000000),
(1000025, '2011-06-19 16:31:29', 1000000, '2012-04-18 06:43:00', 1000000, 'M_TRANSACTION', 'Y', 'Y', '', 1000000),
(1000026, '2011-06-19 16:31:29', 1000000, '2012-03-17 12:06:08', 1000000, 'C_COUNTRY', 'Y', 'Y', '', 1000000);

--UPDATE `u_sequence` set `CURRENTNEXT` = 1000000 WHERE `ISTABLEID` = 'Y';
--UPDATE `u_sequence` set `CURRENTNEXT` = 1000 WHERE `ISTABLEID` = 'N';

-- --------------------------------------------------------

--
-- Table structure for table `u_shopaccess`
--

CREATE TABLE IF NOT EXISTS `u_shopaccess` (
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `U_USER_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ACCESSLEVEL` varchar(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'NA',
  PRIMARY KEY (`M_SHOP_ID`,`U_USER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_shopaccess`
--

INSERT INTO `u_shopaccess` (`M_SHOP_ID`, `U_USER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `ACCESSLEVEL`) VALUES
(0, 1000000, '2011-07-30 17:01:00', 1000000, '2011-07-30 17:01:00', 1000000, 'Y', NULL, 'ReadWite'),

-- --------------------------------------------------------

--
-- Table structure for table `u_user`
--

CREATE TABLE IF NOT EXISTS `u_user` (
  `U_USER_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `FIRSTNAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `MIDDLENAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `LASTNAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `USERNAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `PASSWORD` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`U_USER_ID`),
  UNIQUE KEY `USERNAME` (`USERNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_user`
--

INSERT INTO `u_user` (`U_USER_ID`, `M_SHOP_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `FIRSTNAME`, `MIDDLENAME`, `LASTNAME`, `USERNAME`, `PASSWORD`, `ISACTIVE`, `DESCRIPTION`) VALUES
(1000000, 0, '2012-01-01 13:08:51', 1000000, '2012-01-01 13:08:51', 1000000, 'Administrator', '', '', 'ad', '#passAdmin', 'Y', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `u_warehouseaccess`
--

CREATE TABLE IF NOT EXISTS `u_warehouseaccess` (
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `U_USER_ID` int(10) NOT NULL DEFAULT '0',
  `M_WAREHOUSE_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CANSALEFROM` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANBUYFOR` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANMOVEFORM` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANMOVETO` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANUSEFROM` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANCOUNT` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANREAD` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`M_SHOP_ID`,`U_USER_ID`,`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_warehouseaccess`
--

