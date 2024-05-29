-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 19, 2012 at 11:11 AM
-- Server version: 5.1.39
-- PHP Version: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Database: `liquiddb`
--

-- --------------------------------------------------------

--
-- Table structure for table `ad_org`
--

CREATE TABLE IF NOT EXISTS `ad_org` (
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`AD_ORG_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `ad_org`
--

INSERT INTO `ad_org` (`AD_ORG_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES
(0, '2011-06-29 13:07:54', 1000000, '2011-06-29 13:07:54', 1000000, '*', 'Y', 'All Organizations');

-- --------------------------------------------------------

--
-- Table structure for table `c_city`
--

CREATE TABLE IF NOT EXISTS `c_city` (
  `C_CITY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
  `C_COUNTRY_ID` int(10) NOT NULL DEFAULT '0',
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

INSERT INTO `c_city` (`C_CITY_ID`, `M_SHOP_ID`, `AD_ORG_ID`, `C_COUNTRY_ID`, `NAME`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `COUNTRY`, `DESCRIPTION`, `ISACTIVE`, `ISDEFAULT`) VALUES
(1000000, 1000000, 0, 1000000, 'Addis Ababa', '2012-04-24 11:19:28', 1000000, '2012-04-24 11:19:31', 1000000, '', NULL, 'Y', 'N');

-- --------------------------------------------------------

--
-- Table structure for table `c_country`
--

CREATE TABLE IF NOT EXISTS `c_country` (
  `C_COUNTRY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `ISOCODE` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
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

INSERT INTO `c_country` (`C_COUNTRY_ID`, `M_SHOP_ID`, `AD_ORG_ID`, `NAME`, `ISOCODE`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `DESCRIPTION`, `ISACTIVE`, `ISDEFAULT`) VALUES
(1000000, 0, 0, 'Ethiopia', 'ET', '2012-03-17 12:06:08', 1000000, '2012-03-17 12:06:08', 1000000, NULL, 'Y', 'Y');

-- --------------------------------------------------------

--
-- Table structure for table `c_locality`
--

CREATE TABLE IF NOT EXISTS `c_locality` (
  `C_LOCALITY_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
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
  `T_INVENTORYUSEDETAIL_ID` int(10) DEFAULT NULL,
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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

INSERT INTO `u_activeshopid` (`M_SHOP_ID`) VALUES
(1000000);

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
-- Table structure for table `u_orgaccess`
--

CREATE TABLE IF NOT EXISTS `u_orgaccess` (
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `U_USER_ID` int(10) NOT NULL DEFAULT '0',
  `CREATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL DEFAULT '0',
  `UPDATED` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL DEFAULT '0',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ACCESSLEVEL` varchar(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'NA',
  PRIMARY KEY (`AD_ORG_ID`,`M_SHOP_ID`,`U_USER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_orgaccess`
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
(1000000, '2011-06-19 16:31:29', 1000000, '2011-06-19 16:31:29', 1000000, 'U_SEQUENCE', 'Y', 'Y', '', 1000028),
(1000001, '2011-06-19 16:31:29', 1000000, '2012-04-24 11:33:49', 1000000, 'C_CITY', 'Y', 'Y', '', 1000001),
(1000002, '2011-06-19 16:31:29', 1000000, '2012-04-24 11:53:48', 1000000, 'C_LOCALITY', 'Y', 'Y', '', 1000000),
(1000003, '2011-06-19 16:31:29', 1000000, '2012-04-24 11:54:07', 1000000, 'C_SUBLOCALITY', 'Y', 'Y', '', 1000000),
(1000004, '2011-06-19 16:31:29', 1000000, '2012-03-17 12:03:38', 1000000, 'M_UOM', 'Y', 'Y', '', 1000000),
(1000005, '2011-06-19 16:31:29', 1000000, '2012-03-23 12:50:46', 1000000, 'M_PRODUCTCATEGORY', 'Y', 'Y', '', 1000000),
(1000006, '2011-06-19 16:31:29', 1000000, '2012-04-16 20:38:36', 1000000, 'M_PRODUCT', 'Y', 'Y', '', 1000000),
(1000007, '2011-06-19 16:31:29', 1000000, '2012-04-24 15:26:01', 1000000, 'M_BPARTNER', 'Y', 'Y', '', 1000000),
(1000008, '2011-06-19 16:31:29', 1000000, '2012-04-24 07:14:22', 1000000, 'M_SHOP', 'Y', 'Y', '', 1000001),
(1000009, '2011-06-19 16:31:29', 1000000, '2011-07-30 16:50:44', 1000000, 'U_USER', 'Y', 'Y', '', 1000001),
(1000010, '2011-06-19 16:31:29', 1000000, '2012-05-12 10:39:59', 1000000, 'T_TRANSACTION', 'Y', 'Y', '', 1000000),
(1000011, '2011-06-19 16:31:29', 1000000, '2012-05-12 10:40:36', 1000000, 'T_TRXDETAIL', 'Y', 'Y', '', 1000000),
(1000012, '2011-06-19 16:31:29', 1000000, '2012-05-11 16:23:22', 1000000, 'M_UOM_CONVERSION', 'Y', 'Y', '', 1000000),
(1000013, '2011-06-19 16:31:29', 1000000, '2012-05-11 16:26:12', 1000000, 'PURCHASE', 'Y', 'N', 'PURCHASE', 1000),
(1000014, '2011-06-19 16:31:29', 1000000, '2012-05-12 10:39:59', 1000000, 'SALES', 'Y', 'N', 'SALES', 1000),
(1000015, '2011-06-19 16:31:29', 1000000, '2012-04-24 07:18:57', 1000000, 'M_WAREHOUSE', 'Y', 'Y', '', 1000000),
(1000016, '2011-06-19 16:31:29', 1000000, '2012-05-12 16:53:11', 1000000, 'T_MOVEMENT', 'Y', 'Y', '', 1000000),
(1000017, '2011-06-19 16:31:29', 1000000, '2012-05-12 16:53:12', 1000000, 'T_MOVEMENTDETAIL', 'Y', 'Y', '', 1000000),
(1000018, '2011-06-19 16:31:29', 1000000, '2012-05-12 16:53:11', 1000000, 'MOVE', 'Y', 'N', 'MOVE', 1000),
(1000019, '2011-06-19 16:31:29', 1000000, '2012-05-12 18:58:10', 1000000, 'USE', 'Y', 'N', 'USE', 1000),
(1000020, '2011-06-19 16:31:29', 1000000, '2012-05-12 17:57:03', 1000000, 'COUNT', 'Y', 'N', 'COUNT', 1000),
(1000021, '2011-06-19 16:31:29', 1000000, '2012-05-12 17:57:03', 1000000, 'T_PHYSICALCOUNT', 'Y', 'Y', '', 1000000),
(1000022, '2011-06-19 16:31:29', 1000000, '2012-05-12 17:57:03', 1000000, 'T_PHYSICALCOUNTDETAIL', 'Y', 'Y', '', 1000000),
(1000023, '2011-06-19 16:31:29', 1000000, '2012-05-12 18:58:10', 1000000, 'T_INVENTORYUSE', 'Y', 'Y', '', 1000000),
(1000024, '2011-06-19 16:31:29', 1000000, '2012-05-12 18:58:10', 1000000, 'T_INVENTORYUSEDETAIL', 'Y', 'Y', '', 1000000),
(1000025, '2011-06-19 16:31:29', 1000000, '2012-05-12 18:58:10', 1000000, 'M_TRANSACTION', 'Y', 'Y', '', 1000000),
(1000026, '2011-06-19 16:31:29', 1000000, '2012-04-24 11:17:36', 1000000, 'C_COUNTRY', 'Y', 'Y', '', 1000001),
(1000027, '2011-06-19 16:31:29', 1000000, '2012-05-31 09:24:48', 1000000, 'AD_ORG', 'Y', 'Y', '', 1000000);

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
(0, 1000000, '2012-04-30 17:01:00', 1000000, '2012-04-30 17:01:00', 1000000, 'Y', NULL, 'ReadWite');

-- --------------------------------------------------------

--
-- Table structure for table `u_user`
--

CREATE TABLE IF NOT EXISTS `u_user` (
  `U_USER_ID` int(10) NOT NULL DEFAULT '0',
  `M_SHOP_ID` int(10) NOT NULL DEFAULT '0',
  `AD_ORG_ID` int(10) NOT NULL DEFAULT '0',
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

INSERT INTO `u_user` (`U_USER_ID`, `M_SHOP_ID`, `AD_ORG_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `FIRSTNAME`, `MIDDLENAME`, `LASTNAME`, `USERNAME`, `PASSWORD`, `ISACTIVE`, `DESCRIPTION`) VALUES
(1000000, 0, 0, '2012-01-01 13:08:51', 1000000, '2012-01-01 13:08:51', 1000000, 'Administrator', '', '', 'ad', '12', 'Y', NULL);

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


-- --------------------------------------------------------

--
-- Stand-in structure for view `v_inventoryusedetail`
--
CREATE TABLE IF NOT EXISTS `v_inventoryusedetail` (
`T_INVENTORYUSE_ID` int(10)
,`M_SHOP_ID` int(10)
,`AD_ORG_ID` int(10)
,`DOCUMENTNO` varchar(60)
,`USEDATE` datetime
,`M_WAREHOUSEFROM_ID` int(10)
,`DESCRIPTION` varchar(255)
,`ISACTIVE` char(1)
,`DOCSTATUS` varchar(2)
,`PROCESSED` char(1)
,`T_INVENTORYUSEDETAIL_ID` int(10)
,`LINE` int(10)
,`M_PRODUCT_ID` int(10)
,`M_UOM_ID` int(10)
,`LINE_DESCRIPTION` varchar(255)
,`USEDQUANTITY` double(15,5)
,`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`STATION` varchar(60)
,`WAREHOUSE` varchar(60)
,`ORGANISATION` varchar(60)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_movedfrom`
--
CREATE TABLE IF NOT EXISTS `v_movedfrom` (
`T_MOVEMENTDETAIL_ID` int(10)
,`M_WAREHOUSEFROM_ID` int(10)
,`M_WAREHOUSETO_ID` int(10)
,`MOVEDFROM` varchar(60)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_movementdetail`
--
CREATE TABLE IF NOT EXISTS `v_movementdetail` (
`T_MOVEMENT_ID` int(10)
,`M_SHOP_ID` int(10)
,`AD_ORG_ID` int(10)
,`DOCUMENTNO` varchar(60)
,`MOVEDATE` datetime
,`DESCRIPTION` varchar(255)
,`ISACTIVE` char(1)
,`DOCSTATUS` varchar(2)
,`PROCESSED` char(1)
,`T_MOVEMENTDETAIL_ID` int(10)
,`M_WAREHOUSEFROM_ID` int(10)
,`M_WAREHOUSETO_ID` int(10)
,`LINE` int(10)
,`M_PRODUCT_ID` int(10)
,`M_UOM_ID` int(10)
,`MOVEQUANTITY` double(15,5)
,`LINE_DESCRIPTION` varchar(255)
,`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`STATION` varchar(60)
,`MOVEDFROM` varchar(60)
,`MOVEDTO` varchar(60)
,`ORGANISATION` varchar(60)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_physicalcountdetail`
--
CREATE TABLE IF NOT EXISTS `v_physicalcountdetail` (
`T_PHYSICALCOUNT_ID` int(10)
,`M_SHOP_ID` int(10)
,`AD_ORG_ID` int(10)
,`DOCUMENTNO` varchar(60)
,`COUNTDATE` datetime
,`M_WAREHOUSE_ID` int(10)
,`DESCRIPTION` varchar(255)
,`ISACTIVE` char(1)
,`DOCSTATUS` varchar(2)
,`PROCESSED` char(1)
,`T_PHYSICALCOUNTDETAIL_ID` int(10)
,`LINE` int(10)
,`M_PRODUCT_ID` int(10)
,`M_UOM_ID` int(10)
,`BOOKQUANTITY` double(15,5)
,`COUNTQUANTITY` double(15,5)
,`LINE_DESCRIPTION` varchar(255)
,`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`STATION` varchar(60)
,`WAREHOUSE` varchar(60)
,`ORGANISATION` varchar(60)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_prductcost`
--
CREATE TABLE IF NOT EXISTS `v_prductcost` (
`M_PRODUCT_ID` int(10)
,`M_SHOP_ID` int(10)
,`AD_ORG_ID` int(10)
,`CREATED` datetime
,`CREATEDBY` int(10)
,`UPDATED` datetime
,`UPDATEDBY` int(10)
,`CODE` varchar(60)
,`NAME` varchar(60)
,`ISACTIVE` char(1)
,`DESCRIPTION` varchar(255)
,`M_PRODUCTCATEGORY_ID` int(10)
,`M_UOM_ID` int(10)
,`PRODUCTTYPE` char(1)
,`UPC_EAN` varchar(255)
,`IMAGEPATH` varchar(255)
,`PURCHASEPRICE` double(15,5)
,`SELLINGPRICE` double(15,5)
,`CURRENTQTY` double(15,5)
,`CURRENTCOST` double(15,5)
,`ACCUMULATEDQTY` double(15,5)
,`ACCUMULATEDCOST` double(15,5)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_storagedetail`
--
CREATE TABLE IF NOT EXISTS `v_storagedetail` (
`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_UOM_ID` int(10)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`M_PRODUCT_ID` int(10)
,`M_WAREHOUSE_ID` int(10)
,`CURRENTQTY` double(15,5)
,`WAREHOUSE` varchar(60)
,`ALLOWNEGATIVE` char(1)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_storagesummary`
--
CREATE TABLE IF NOT EXISTS `v_storagesummary` (
`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_UOM_ID` int(10)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`M_PRODUCT_ID` int(10)
,`M_WAREHOUSE_ID` int(10)
,`CURRENTQTY` double(22,5)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_transactionsummary`
--
CREATE TABLE IF NOT EXISTS `v_transactionsummary` (
`M_TRANSACTION_ID` int(10)
,`AD_CLIENT_ID` int(10)
,`M_SHOP_ID` int(10)
,`AD_ORG_ID` int(10)
,`MOVEMENTTYPE` enum('BL','V+','V-','M+','M-','I+','I-',' C+','C-')
,`M_LOCATOR_ID` int(10)
,`M_PRODUCT_ID` int(10)
,`MOVEMENTDATE` datetime
,`MOVEMENTQTY` double(15,9)
,`C_UOM_ID` int(10)
,`M_INOUTLINE_ID` int(10)
,`M_MOVEMENTLINE_ID` int(10)
,`M_INVENTORYLINE_ID` int(10)
,`T_INVENTORYUSEDETAIL_ID` int(10)
,`DOCUMENTNO` varchar(60)
,`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`STATION` varchar(60)
,`WAREHOUSE` varchar(60)
,`ORGANISATION` varchar(60)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_trxdetail`
--
CREATE TABLE IF NOT EXISTS `v_trxdetail` (
`T_TRANSACTION_ID` int(10)
,`M_SHOP_ID` int(10)
,`AD_ORG_ID` int(10)
,`DOCUMENTNO` varchar(60)
,`TRXDATE` datetime
,`M_BPARTNER_ID` int(10)
,`ISSALESTRX` char(1)
,`SUBTRXAMOUNT` double(15,2)
,`GRANDTRXAMOUNT` double(15,2)
,`TRXTAXAMOUNT` double(15,2)
,`ISPAID` char(1)
,`PAYMENTRULE` char(1)
,`DESCRIPTION` varchar(255)
,`ISACTIVE` char(1)
,`DOCSTATUS` varchar(2)
,`PROCESSED` char(1)
,`T_TRXDETAIL_ID` int(10)
,`LINE` int(10)
,`M_PRODUCT_ID` int(10)
,`M_UOM_ID` int(10)
,`M_WAREHOUSE_ID` int(10)
,`TRXQUANTITY` double(15,5)
,`LINE_DESCRIPTION` varchar(255)
,`UNITPRICE` double(15,2)
,`DISCOUNTRATE` double(15,5)
,`DISCOUNTAMT` double(15,2)
,`MARGIN` double(15,5)
,`UNITCOST` double(15,5)
,`LINENETAMT` double(15,2)
,`LINETAXAMOUNT` double(15,2)
,`CODE` varchar(60)
,`PRODUCT` varchar(60)
,`M_PRODUCTCATEGORY_ID` int(10)
,`CATEGORY` varchar(60)
,`UNIT` varchar(60)
,`UOM` varchar(3)
,`BUSINESSPARTNER` varchar(60)
,`STATION` varchar(60)
,`ORGANISATION` varchar(60)
,`WAREHOUSE` varchar(60)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `v_warehousemovement`
--
CREATE TABLE IF NOT EXISTS `v_warehousemovement` (
`T_MOVEMENTDETAIL_ID` int(10)
,`M_WAREHOUSEFROM_ID` int(10)
,`M_WAREHOUSETO_ID` int(10)
,`MOVEDFROM` varchar(60)
,`MOVEDTO` varchar(60)
);
-- --------------------------------------------------------

--
-- Structure for view `v_inventoryusedetail`
--
DROP TABLE IF EXISTS `v_inventoryusedetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_inventoryusedetail` AS select `usage`.`T_INVENTORYUSE_ID` AS `T_INVENTORYUSE_ID`,`usage`.`M_SHOP_ID` AS `M_SHOP_ID`,`usage`.`AD_ORG_ID` AS `AD_ORG_ID`,`usage`.`DOCUMENTNO` AS `DOCUMENTNO`,`usage`.`USEDATE` AS `USEDATE`,`usage`.`M_WAREHOUSEFROM_ID` AS `M_WAREHOUSEFROM_ID`,`usage`.`DESCRIPTION` AS `DESCRIPTION`,`usage`.`ISACTIVE` AS `ISACTIVE`,`usage`.`DOCSTATUS` AS `DOCSTATUS`,`usage`.`PROCESSED` AS `PROCESSED`,`usageline`.`T_INVENTORYUSEDETAIL_ID` AS `T_INVENTORYUSEDETAIL_ID`,`usageline`.`LINE` AS `LINE`,`usageline`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`usageline`.`M_UOM_ID` AS `M_UOM_ID`,`usageline`.`DESCRIPTION` AS `LINE_DESCRIPTION`,`usageline`.`USEDQUANTITY` AS `USEDQUANTITY`,`prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `PRODUCT`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd_cat`.`NAME` AS `CATEGORY`,`uom`.`NAME` AS `UNIT`,`uom`.`ABBREVATION` AS `UOM`,`station`.`NAME` AS `STATION`,`warehouse`.`NAME` AS `WAREHOUSE`,`org`.`NAME` AS `ORGANISATION` from (((((((`t_inventoryuse` `usage` left join `t_inventoryusedetail` `usageline` on((`usage`.`T_INVENTORYUSE_ID` = `usageline`.`T_INVENTORYUSE_ID`))) left join `m_product` `prd` on((`usageline`.`M_PRODUCT_ID` = `prd`.`M_PRODUCT_ID`))) left join `m_productcategory` `prd_cat` on((`prd`.`M_PRODUCTCATEGORY_ID` = `prd_cat`.`M_PRODUCTCATEGORY_ID`))) left join `m_uom` `uom` on((`usageline`.`M_UOM_ID` = `uom`.`M_UOM_ID`))) left join `m_shop` `station` on((`usage`.`M_SHOP_ID` = `station`.`M_SHOP_ID`))) left join `ad_org` `org` on((`usage`.`AD_ORG_ID` = `org`.`AD_ORG_ID`))) left join `m_warehouse` `warehouse` on((`usage`.`M_WAREHOUSEFROM_ID` = `warehouse`.`M_WAREHOUSE_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_movedfrom`
--
DROP TABLE IF EXISTS `v_movedfrom`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_movedfrom` AS select `t_movementdetail`.`T_MOVEMENTDETAIL_ID` AS `T_MOVEMENTDETAIL_ID`,`t_movementdetail`.`M_WAREHOUSEFROM_ID` AS `M_WAREHOUSEFROM_ID`,`t_movementdetail`.`M_WAREHOUSETO_ID` AS `M_WAREHOUSETO_ID`,`m_warehouse`.`NAME` AS `MOVEDFROM` from (`t_movementdetail` left join `m_warehouse` on((`t_movementdetail`.`M_WAREHOUSEFROM_ID` = `m_warehouse`.`M_WAREHOUSE_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_movementdetail`
--
DROP TABLE IF EXISTS `v_movementdetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_movementdetail` AS select `movement`.`T_MOVEMENT_ID` AS `T_MOVEMENT_ID`,`movement`.`M_SHOP_ID` AS `M_SHOP_ID`,`movement`.`AD_ORG_ID` AS `AD_ORG_ID`,`movement`.`DOCUMENTNO` AS `DOCUMENTNO`,`movement`.`MOVEDATE` AS `MOVEDATE`,`movement`.`DESCRIPTION` AS `DESCRIPTION`,`movement`.`ISACTIVE` AS `ISACTIVE`,`movement`.`DOCSTATUS` AS `DOCSTATUS`,`movement`.`PROCESSED` AS `PROCESSED`,`movementline`.`T_MOVEMENTDETAIL_ID` AS `T_MOVEMENTDETAIL_ID`,`movementline`.`M_WAREHOUSEFROM_ID` AS `M_WAREHOUSEFROM_ID`,`movementline`.`M_WAREHOUSETO_ID` AS `M_WAREHOUSETO_ID`,`movementline`.`LINE` AS `LINE`,`movementline`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`movementline`.`M_UOM_ID` AS `M_UOM_ID`,`movementline`.`MOVEQUANTITY` AS `MOVEQUANTITY`,`movementline`.`DESCRIPTION` AS `LINE_DESCRIPTION`,`prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `PRODUCT`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd_cat`.`NAME` AS `CATEGORY`,`uom`.`NAME` AS `UNIT`,`uom`.`ABBREVATION` AS `UOM`,`station`.`NAME` AS `STATION`,`warehouse`.`MOVEDFROM` AS `MOVEDFROM`,`warehouse`.`MOVEDTO` AS `MOVEDTO`,`org`.`NAME` AS `ORGANISATION` from (((((((`t_movement` `movement` left join `t_movementdetail` `movementline` on((`movement`.`T_MOVEMENT_ID` = `movementline`.`T_MOVEMENT_ID`))) left join `m_product` `prd` on((`movementline`.`M_PRODUCT_ID` = `prd`.`M_PRODUCT_ID`))) left join `m_productcategory` `prd_cat` on((`prd`.`M_PRODUCTCATEGORY_ID` = `prd_cat`.`M_PRODUCTCATEGORY_ID`))) left join `m_uom` `uom` on((`movementline`.`M_UOM_ID` = `uom`.`M_UOM_ID`))) left join `m_shop` `station` on((`movement`.`M_SHOP_ID` = `station`.`M_SHOP_ID`))) left join `ad_org` `org` on((`movement`.`AD_ORG_ID` = `org`.`AD_ORG_ID`))) left join `v_warehousemovement` `warehouse` on((`movementline`.`T_MOVEMENTDETAIL_ID` = `warehouse`.`T_MOVEMENTDETAIL_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_physicalcountdetail`
--
DROP TABLE IF EXISTS `v_physicalcountdetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_physicalcountdetail` AS select `count`.`T_PHYSICALCOUNT_ID` AS `T_PHYSICALCOUNT_ID`,`count`.`M_SHOP_ID` AS `M_SHOP_ID`,`count`.`AD_ORG_ID` AS `AD_ORG_ID`,`count`.`DOCUMENTNO` AS `DOCUMENTNO`,`count`.`COUNTDATE` AS `COUNTDATE`,`count`.`M_WAREHOUSE_ID` AS `M_WAREHOUSE_ID`,`count`.`DESCRIPTION` AS `DESCRIPTION`,`count`.`ISACTIVE` AS `ISACTIVE`,`count`.`DOCSTATUS` AS `DOCSTATUS`,`count`.`PROCESSED` AS `PROCESSED`,`countline`.`T_PHYSICALCOUNTDETAIL_ID` AS `T_PHYSICALCOUNTDETAIL_ID`,`countline`.`LINE` AS `LINE`,`countline`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`countline`.`M_UOM_ID` AS `M_UOM_ID`,`countline`.`BOOKQUANTITY` AS `BOOKQUANTITY`,`countline`.`COUNTQUANTITY` AS `COUNTQUANTITY`,`countline`.`DESCRIPTION` AS `LINE_DESCRIPTION`,`prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `PRODUCT`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd_cat`.`NAME` AS `CATEGORY`,`uom`.`NAME` AS `UNIT`,`uom`.`ABBREVATION` AS `UOM`,`station`.`NAME` AS `STATION`,`warehouse`.`NAME` AS `WAREHOUSE`,`org`.`NAME` AS `ORGANISATION` from (((((((`t_physicalcount` `count` left join `t_physicalcountdetail` `countline` on((`count`.`T_PHYSICALCOUNT_ID` = `countline`.`T_PHYSICALCOUNT_ID`))) left join `m_product` `prd` on((`countline`.`M_PRODUCT_ID` = `prd`.`M_PRODUCT_ID`))) left join `m_productcategory` `prd_cat` on((`prd`.`M_PRODUCTCATEGORY_ID` = `prd_cat`.`M_PRODUCTCATEGORY_ID`))) left join `m_uom` `uom` on((`countline`.`M_UOM_ID` = `uom`.`M_UOM_ID`))) left join `m_shop` `station` on((`count`.`M_SHOP_ID` = `station`.`M_SHOP_ID`))) left join `ad_org` `org` on((`count`.`AD_ORG_ID` = `org`.`AD_ORG_ID`))) left join `m_warehouse` `warehouse` on((`count`.`M_WAREHOUSE_ID` = `warehouse`.`M_WAREHOUSE_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_prductcost`
--
DROP TABLE IF EXISTS `v_prductcost`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_prductcost` AS select `prd`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`prd`.`M_SHOP_ID` AS `M_SHOP_ID`,`prd`.`AD_ORG_ID` AS `AD_ORG_ID`,`prd`.`CREATED` AS `CREATED`,`prd`.`CREATEDBY` AS `CREATEDBY`,`prd`.`UPDATED` AS `UPDATED`,`prd`.`UPDATEDBY` AS `UPDATEDBY`,`prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `NAME`,`prd`.`ISACTIVE` AS `ISACTIVE`,`prd`.`DESCRIPTION` AS `DESCRIPTION`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd`.`M_UOM_ID` AS `M_UOM_ID`,`prd`.`PRODUCTTYPE` AS `PRODUCTTYPE`,`prd`.`UPC_EAN` AS `UPC_EAN`,`prd`.`IMAGEPATH` AS `IMAGEPATH`,`prd`.`PURCHASEPRICE` AS `PURCHASEPRICE`,`prd`.`SELLINGPRICE` AS `SELLINGPRICE`,`cost`.`CURRENTQTY` AS `CURRENTQTY`,`cost`.`CURRENTCOST` AS `CURRENTCOST`,`cost`.`ACCUMULATEDQTY` AS `ACCUMULATEDQTY`,`cost`.`ACCUMULATEDCOST` AS `ACCUMULATEDCOST` from (`m_product` `prd` left join `q_cost` `cost` on((`prd`.`M_PRODUCT_ID` = `cost`.`M_PRODUCT_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_storagedetail`
--
DROP TABLE IF EXISTS `v_storagedetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_storagedetail` AS select `prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `PRODUCT`,`prd`.`M_UOM_ID` AS `M_UOM_ID`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd_cat`.`NAME` AS `CATEGORY`,`uom`.`NAME` AS `UNIT`,`uom`.`ABBREVATION` AS `UOM`,`stock`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`stock`.`M_WAREHOUSE_ID` AS `M_WAREHOUSE_ID`,`stock`.`CURRENTQTY` AS `CURRENTQTY`,`store`.`NAME` AS `WAREHOUSE`,`store`.`ALLOWNEGATIVE` AS `ALLOWNEGATIVE` from ((((`q_stock` `stock` left join `m_warehouse` `store` on((`stock`.`M_WAREHOUSE_ID` = `store`.`M_WAREHOUSE_ID`))) left join `m_product` `prd` on((`stock`.`M_PRODUCT_ID` = `prd`.`M_PRODUCT_ID`))) left join `m_productcategory` `prd_cat` on((`prd`.`M_PRODUCTCATEGORY_ID` = `prd_cat`.`M_PRODUCTCATEGORY_ID`))) left join `m_uom` `uom` on((`prd`.`M_UOM_ID` = `uom`.`M_UOM_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_storagesummary`
--
DROP TABLE IF EXISTS `v_storagesummary`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_storagesummary` AS select `v_storagedetail`.`CODE` AS `CODE`,`v_storagedetail`.`PRODUCT` AS `PRODUCT`,`v_storagedetail`.`M_UOM_ID` AS `M_UOM_ID`,`v_storagedetail`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`v_storagedetail`.`CATEGORY` AS `CATEGORY`,`v_storagedetail`.`UNIT` AS `UNIT`,`v_storagedetail`.`UOM` AS `UOM`,`v_storagedetail`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`v_storagedetail`.`M_WAREHOUSE_ID` AS `M_WAREHOUSE_ID`,sum(`v_storagedetail`.`CURRENTQTY`) AS `CURRENTQTY` from `v_storagedetail` group by `v_storagedetail`.`CODE`,`v_storagedetail`.`PRODUCT`,`v_storagedetail`.`M_UOM_ID`,`v_storagedetail`.`M_PRODUCTCATEGORY_ID`,`v_storagedetail`.`CATEGORY`,`v_storagedetail`.`UNIT`,`v_storagedetail`.`UOM`,`v_storagedetail`.`M_PRODUCT_ID`,`v_storagedetail`.`M_WAREHOUSE_ID`;

-- --------------------------------------------------------

--
-- Structure for view `v_transactionsummary`
--
DROP TABLE IF EXISTS `v_transactionsummary`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_transactionsummary` AS select `transaction`.`M_TRANSACTION_ID` AS `M_TRANSACTION_ID`,`transaction`.`AD_CLIENT_ID` AS `AD_CLIENT_ID`,`transaction`.`M_SHOP_ID` AS `M_SHOP_ID`,`transaction`.`AD_ORG_ID` AS `AD_ORG_ID`,`transaction`.`MOVEMENTTYPE` AS `MOVEMENTTYPE`,`transaction`.`M_LOCATOR_ID` AS `M_LOCATOR_ID`,`transaction`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`transaction`.`MOVEMENTDATE` AS `MOVEMENTDATE`,`transaction`.`MOVEMENTQTY` AS `MOVEMENTQTY`,`transaction`.`C_UOM_ID` AS `C_UOM_ID`,`transaction`.`M_INOUTLINE_ID` AS `M_INOUTLINE_ID`,`transaction`.`M_MOVEMENTLINE_ID` AS `M_MOVEMENTLINE_ID`,`transaction`.`M_INVENTORYLINE_ID` AS `M_INVENTORYLINE_ID`,`transaction`.`T_INVENTORYUSEDETAIL_ID` AS `T_INVENTORYUSEDETAIL_ID`,coalesce(`trxdetail`.`DOCUMENTNO`,`movementdetail`.`DOCUMENTNO`,`physicalcountdetail`.`DOCUMENTNO`,`inventoryusedetail`.`DOCUMENTNO`,'0') AS `DOCUMENTNO`,`prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `PRODUCT`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd_cat`.`NAME` AS `CATEGORY`,`uom`.`NAME` AS `UNIT`,`uom`.`ABBREVATION` AS `UOM`,`station`.`NAME` AS `STATION`,`warehouse`.`NAME` AS `WAREHOUSE`,`org`.`NAME` AS `ORGANISATION` from ((((((((((`m_transaction` `transaction` left join `m_product` `prd` on((`transaction`.`M_PRODUCT_ID` = `prd`.`M_PRODUCT_ID`))) left join `m_productcategory` `prd_cat` on((`prd`.`M_PRODUCTCATEGORY_ID` = `prd_cat`.`M_PRODUCTCATEGORY_ID`))) left join `m_uom` `uom` on((`transaction`.`C_UOM_ID` = `uom`.`M_UOM_ID`))) left join `m_shop` `station` on((`transaction`.`M_SHOP_ID` = `station`.`M_SHOP_ID`))) left join `ad_org` `org` on((`transaction`.`AD_ORG_ID` = `org`.`AD_ORG_ID`))) left join `m_warehouse` `warehouse` on((`transaction`.`M_LOCATOR_ID` = `warehouse`.`M_WAREHOUSE_ID`))) left join `v_physicalcountdetail` `physicalcountdetail` on(((`transaction`.`M_INVENTORYLINE_ID` = `physicalcountdetail`.`T_PHYSICALCOUNTDETAIL_ID`) and (`transaction`.`MOVEMENTTYPE` = 'I+')))) left join `v_inventoryusedetail` `inventoryusedetail` on(((`transaction`.`T_INVENTORYUSEDETAIL_ID` = `inventoryusedetail`.`T_INVENTORYUSEDETAIL_ID`) and (`transaction`.`MOVEMENTTYPE` = 'I-')))) left join `v_trxdetail` `trxdetail` on(((`transaction`.`M_INOUTLINE_ID` = `trxdetail`.`T_TRXDETAIL_ID`) and (`transaction`.`MOVEMENTTYPE` in ('V+','V-','C+','C-'))))) left join `v_movementdetail` `movementdetail` on(((`transaction`.`M_MOVEMENTLINE_ID` = `movementdetail`.`T_MOVEMENTDETAIL_ID`) and (`transaction`.`MOVEMENTTYPE` in ('M+','M-')))));

-- --------------------------------------------------------

--
-- Structure for view `v_trxdetail`
--
DROP TABLE IF EXISTS `v_trxdetail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_trxdetail` AS select `order`.`T_TRANSACTION_ID` AS `T_TRANSACTION_ID`,`order`.`M_SHOP_ID` AS `M_SHOP_ID`,`order`.`AD_ORG_ID` AS `AD_ORG_ID`,`order`.`DOCUMENTNO` AS `DOCUMENTNO`,`order`.`TRXDATE` AS `TRXDATE`,`order`.`M_BPARTNER_ID` AS `M_BPARTNER_ID`,`order`.`ISSALESTRX` AS `ISSALESTRX`,`order`.`SUBTRXAMOUNT` AS `SUBTRXAMOUNT`,`order`.`GRANDTRXAMOUNT` AS `GRANDTRXAMOUNT`,`order`.`TRXTAXAMOUNT` AS `TRXTAXAMOUNT`,`order`.`ISPAID` AS `ISPAID`,`order`.`PAYMENTRULE` AS `PAYMENTRULE`,`order`.`DESCRIPTION` AS `DESCRIPTION`,`order`.`ISACTIVE` AS `ISACTIVE`,`order`.`DOCSTATUS` AS `DOCSTATUS`,`order`.`PROCESSED` AS `PROCESSED`,`orderline`.`T_TRXDETAIL_ID` AS `T_TRXDETAIL_ID`,`orderline`.`LINE` AS `LINE`,`orderline`.`M_PRODUCT_ID` AS `M_PRODUCT_ID`,`orderline`.`M_UOM_ID` AS `M_UOM_ID`,`orderline`.`M_WAREHOUSE_ID` AS `M_WAREHOUSE_ID`,`orderline`.`TRXQUANTITY` AS `TRXQUANTITY`,`orderline`.`DESCRIPTION` AS `LINE_DESCRIPTION`,`orderline`.`UNITPRICE` AS `UNITPRICE`,`orderline`.`DISCOUNTRATE` AS `DISCOUNTRATE`,`orderline`.`DISCOUNTAMT` AS `DISCOUNTAMT`,`orderline`.`MARGIN` AS `MARGIN`,`orderline`.`UNITCOST` AS `UNITCOST`,`orderline`.`LINENETAMT` AS `LINENETAMT`,`orderline`.`LINETAXAMOUNT` AS `LINETAXAMOUNT`,`prd`.`CODE` AS `CODE`,`prd`.`NAME` AS `PRODUCT`,`prd`.`M_PRODUCTCATEGORY_ID` AS `M_PRODUCTCATEGORY_ID`,`prd_cat`.`NAME` AS `CATEGORY`,`uom`.`NAME` AS `UNIT`,`uom`.`ABBREVATION` AS `UOM`,`bprtner`.`NAME` AS `BUSINESSPARTNER`,`station`.`NAME` AS `STATION`,`org`.`NAME` AS `ORGANISATION`,`warehouse`.`NAME` AS `WAREHOUSE` from ((((((((`t_transaction` `order` left join `t_trxdetail` `orderline` on((`order`.`T_TRANSACTION_ID` = `orderline`.`T_TRANSACTION_ID`))) left join `m_product` `prd` on((`orderline`.`M_PRODUCT_ID` = `prd`.`M_PRODUCT_ID`))) left join `m_productcategory` `prd_cat` on((`prd`.`M_PRODUCTCATEGORY_ID` = `prd_cat`.`M_PRODUCTCATEGORY_ID`))) left join `m_uom` `uom` on((`orderline`.`M_UOM_ID` = `uom`.`M_UOM_ID`))) left join `m_bpartner` `bprtner` on((`order`.`M_BPARTNER_ID` = `bprtner`.`M_BPARTNER_ID`))) left join `m_shop` `station` on((`order`.`M_SHOP_ID` = `station`.`M_SHOP_ID`))) left join `ad_org` `org` on((`order`.`AD_ORG_ID` = `org`.`AD_ORG_ID`))) left join `m_warehouse` `warehouse` on((`orderline`.`M_WAREHOUSE_ID` = `warehouse`.`M_WAREHOUSE_ID`)));

-- --------------------------------------------------------

--
-- Structure for view `v_warehousemovement`
--
DROP TABLE IF EXISTS `v_warehousemovement`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_warehousemovement` AS select `movedfrom`.`T_MOVEMENTDETAIL_ID` AS `T_MOVEMENTDETAIL_ID`,`movedfrom`.`M_WAREHOUSEFROM_ID` AS `M_WAREHOUSEFROM_ID`,`movedfrom`.`M_WAREHOUSETO_ID` AS `M_WAREHOUSETO_ID`,`movedfrom`.`MOVEDFROM` AS `MOVEDFROM`,`m_warehouse`.`NAME` AS `MOVEDTO` from (`v_movedfrom` `movedfrom` left join `m_warehouse` on((`movedfrom`.`M_WAREHOUSETO_ID` = `m_warehouse`.`M_WAREHOUSE_ID`)));
