-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Aug 02, 2011 at 09:15 AM
-- Server version: 5.1.37
-- PHP Version: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `srpdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `m_bpartner`
--

CREATE TABLE IF NOT EXISTS `m_bpartner` (
  `M_BPARTNER_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISVENDOR` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `ISCUSTOMER` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  PRIMARY KEY (`M_BPARTNER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_bpartner`
--

INSERT INTO `m_bpartner` (`M_BPARTNER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `DESCRIPTION`, `ISACTIVE`, `ISVENDOR`, `ISCUSTOMER`) VALUES
(1000, '2011-06-29 13:09:12', 1000, '2011-06-29 13:09:12', 1000, 'General Customer', NULL, 'Y', 'N', 'Y'),
(1001, '2011-06-29 13:09:41', 1000, '2011-06-29 13:09:41', 1000, 'Vendor One', NULL, 'Y', 'Y', 'N'),
(1002, '2011-07-30 16:20:11', 1002, '2011-07-30 16:20:11', 1002, 'aziza', NULL, 'Y', 'N', 'Y'),
(1003, '2011-07-30 16:47:19', 1002, '2011-07-30 16:47:19', 1002, 'ABC', NULL, 'Y', 'Y', 'Y');

-- --------------------------------------------------------

--
-- Table structure for table `m_city`
--

CREATE TABLE IF NOT EXISTS `m_city` (
  `M_CITY_ID` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `COUNTRY` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  PRIMARY KEY (`M_CITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_city`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_locality`
--

CREATE TABLE IF NOT EXISTS `m_locality` (
  `M_LOCALITY_ID` int(10) NOT NULL,
  `M_CITY_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISSUMMARY` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PARENTLOCALITY_ID` int(11) NOT NULL,
  PRIMARY KEY (`M_LOCALITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_locality`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_product`
--

CREATE TABLE IF NOT EXISTS `m_product` (
  `M_PRODUCT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `CODE` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `M_PRODUCTCATEGORY_ID` int(10) NOT NULL,
  `M_UOM_ID` int(10) NOT NULL,
  `PRODUCTTYPE` char(1) COLLATE utf8_unicode_ci NOT NULL,
  `UPC_EAN` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `IMAGEPATH` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PURCHASEPRICE` double(15,5) DEFAULT '0.00000',
  `SELLINGPRICE` double(15,5) DEFAULT '0.00000',
  `CURRENTQTY` double(15,5) DEFAULT '0.00000',
  `CURRENTCOST` double(15,5) DEFAULT '0.00000',
  `ACCUMULATEDQTY` double(15,5) DEFAULT '0.00000',
  `ACCUMULATEDCOST` double(15,5) DEFAULT '0.00000',
  PRIMARY KEY (`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_product`
--

INSERT INTO `m_product` (`M_PRODUCT_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `CODE`, `NAME`, `ISACTIVE`, `DESCRIPTION`, `M_PRODUCTCATEGORY_ID`, `M_UOM_ID`, `PRODUCTTYPE`, `UPC_EAN`, `IMAGEPATH`, `PURCHASEPRICE`, `SELLINGPRICE`, `CURRENTQTY`, `CURRENTCOST`, `ACCUMULATEDQTY`, `ACCUMULATEDCOST`) VALUES
(1000, '2011-06-29 13:14:38', 1000, '2011-07-30 16:22:10', 1002, '001', 'Item One', 'Y', NULL, 1000, 1003, 'I', NULL, 'C:\\Users\\Public\\Pictures\\Sample Pictures\\Koala.jpg', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1001, '2011-06-29 13:15:07', 1000, '2011-07-30 16:44:54', 1002, '002', 'Item 2', 'Y', NULL, 1001, 1002, 'I', NULL, NULL, 34.00000, 55.00000, 214.00000, 34.00000, 290.00000, 9860.00000),
(1002, '2011-06-29 16:04:11', 1002, '2011-06-29 16:14:52', 1002, '003', 'item no 3', 'Y', NULL, 1000, 1000, 'I', NULL, 'C:\\Users\\Public\\Pictures\\Sample Pictures\\Tulips.jpg', 130.00000, 150.00000, 450.00000, 130.00000, 450.00000, 58500.00000),
(1003, '2011-06-29 18:09:36', 1002, '2011-07-30 16:38:38', 1002, '004', 'Tyer', 'Y', NULL, 1000, 1000, 'I', NULL, 'C:\\Users\\Public\\Pictures\\Sample Pictures\\Lighthouse.jpg', 12.00000, 34.00000, -2.00000, 0.00000, 0.00000, 0.00000),
(1004, '2011-07-02 12:20:49', 1002, '2011-07-02 12:21:37', 1002, '90', 'neckless', 'Y', NULL, 1000, 1003, 'I', NULL, NULL, 20.00000, 50.00000, 50.00000, 20.00000, 50.00000, 1000.00000),
(1005, '2011-07-30 16:16:45', 1002, '2011-07-30 16:38:38', 1002, '87', 'sandal', 'Y', NULL, 1002, 1004, 'I', NULL, 'C:\\Users\\Public\\Pictures\\Sample Pictures\\Hydrangeas.jpg', 8.00000, 10.00000, 453.00000, 8.10870, 460.00000, 3730.00000);

-- --------------------------------------------------------

--
-- Table structure for table `m_productcategory`
--

CREATE TABLE IF NOT EXISTS `m_productcategory` (
  `M_PRODUCTCATEGORY_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_PRODUCTCATEGORY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_productcategory`
--

INSERT INTO `m_productcategory` (`M_PRODUCTCATEGORY_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES
(1000, '2011-06-29 13:11:26', 1000, '2011-06-29 13:11:26', 1000, 'Category One', 'Y', NULL),
(1001, '2011-06-29 13:11:34', 1000, '2011-06-29 13:11:34', 1000, 'Category Two', 'Y', NULL),
(1002, '2011-07-30 16:14:45', 1002, '2011-07-30 16:14:45', 1002, 'garment', 'Y', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `m_shop`
--

CREATE TABLE IF NOT EXISTS `m_shop` (
  `M_SHOP_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_SHOP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_shop`
--

INSERT INTO `m_shop` (`M_SHOP_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES
(1000, '2011-06-29 13:07:54', 1000, '2011-06-29 13:07:54', 1000, 'Legar', 'Y', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `m_sublocality`
--

CREATE TABLE IF NOT EXISTS `m_sublocality` (
  `M_SUBLOCALITY_ID` int(10) NOT NULL,
  `M_LOCALITY_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ISSUMMARY` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PARENTSUBLOC_ID` int(11) NOT NULL,
  PRIMARY KEY (`M_SUBLOCALITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_sublocality`
--


-- --------------------------------------------------------

--
-- Table structure for table `m_uom`
--

CREATE TABLE IF NOT EXISTS `m_uom` (
  `M_UOM_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `STDPRECISION` int(1) NOT NULL DEFAULT '0',
  `ABBREVATION` char(3) COLLATE utf8_unicode_ci NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_UOM_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_uom`
--

INSERT INTO `m_uom` (`M_UOM_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `STDPRECISION`, `ABBREVATION`, `DESCRIPTION`) VALUES
(1000, '2011-06-29 13:10:11', 1000, '2011-06-29 13:10:11', 1000, 'Pieces', 'Y', 0, 'pcs', NULL),
(1001, '2011-06-29 13:10:23', 1000, '2011-06-29 13:10:23', 1000, 'Dozen', 'Y', 0, 'dz', NULL),
(1002, '2011-06-29 13:10:41', 1000, '2011-06-29 13:10:41', 1000, 'Packet', 'Y', 0, 'pk', NULL),
(1003, '2011-07-02 12:15:40', 1002, '2011-07-02 12:15:40', 1002, 'Gram', 'Y', 2, 'grm', NULL),
(1004, '2011-07-30 16:15:44', 1002, '2011-07-30 16:15:44', 1002, 'pair', 'Y', 0, 'pr', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `m_uom_conversion`
--

CREATE TABLE IF NOT EXISTS `m_uom_conversion` (
  `M_UOM_CONVERSION_ID` int(10) NOT NULL,
  `M_BASE_UOM_ID` int(10) NOT NULL,
  `M_DRIVED_UOM_ID` int(10) NOT NULL,
  `M_PRODUCT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MULTIPLIER` double(15,5) DEFAULT '0.00000',
  PRIMARY KEY (`M_UOM_CONVERSION_ID`),
  UNIQUE KEY `M_BASE_UOM_ID` (`M_BASE_UOM_ID`,`M_DRIVED_UOM_ID`,`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_uom_conversion`
--

INSERT INTO `m_uom_conversion` (`M_UOM_CONVERSION_ID`, `M_BASE_UOM_ID`, `M_DRIVED_UOM_ID`, `M_PRODUCT_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `MULTIPLIER`) VALUES
(1000, 1000, 1001, 0, '2011-06-29 13:11:09', 1000, '2011-06-29 13:11:09', 1000, 'Y', NULL, 12.00000),
(1001, 1000, 1002, 1001, '2011-06-29 13:15:22', 1000, '2011-06-29 13:15:22', 1000, 'Y', NULL, 6.00000),
(1002, 1000, 1003, 1000, '2011-07-02 12:16:55', 1002, '2011-07-02 12:19:05', 1002, 'Y', NULL, 65.00000),
(1003, 1000, 1003, 1004, '2011-07-02 12:21:10', 1002, '2011-07-02 12:21:10', 1002, 'Y', NULL, 10.00000);

-- --------------------------------------------------------

--
-- Table structure for table `m_warehouse`
--

CREATE TABLE IF NOT EXISTS `m_warehouse` (
  `M_WAREHOUSE_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `m_warehouse`
--

INSERT INTO `m_warehouse` (`M_WAREHOUSE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES
(1000, '2011-06-29 13:11:59', 1000, '2011-06-29 13:11:59', 1000, 'Babur Tabiya', 'Y', NULL),
(1001, '2011-06-29 13:12:10', 1000, '2011-06-29 13:12:10', 1000, 'Saris', 'Y', NULL),
(1002, '2011-07-30 16:45:46', 1002, '2011-07-30 16:45:46', 1002, 'Medhaniealem', 'Y', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `q_cost`
--

CREATE TABLE IF NOT EXISTS `q_cost` (
  `M_PRODUCT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `CURRENTQTY` double(15,5) DEFAULT NULL,
  `CURRENTCOST` double(15,5) DEFAULT NULL,
  `ACCUMULATEDQTY` double(15,5) DEFAULT NULL,
  `ACCUMULATEDCOST` double(15,5) DEFAULT NULL,
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
  `M_PRODUCT_ID` int(10) NOT NULL,
  `M_WAREHOUSE_ID` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `CURRENTQTY` double(15,5) DEFAULT NULL,
  PRIMARY KEY (`M_PRODUCT_ID`,`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `q_stock`
--

INSERT INTO `q_stock` (`M_PRODUCT_ID`, `M_WAREHOUSE_ID`, `ISACTIVE`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `CURRENTQTY`) VALUES
(1000, 1001, 'Y', '2011-06-29 13:20:27', 1002, '2011-06-29 13:22:26', 1002, 33.00000),
(1001, 1001, 'Y', '2011-06-29 13:20:27', 1002, '2011-07-30 16:44:54', 1002, 214.00000),
(1002, 1001, 'Y', '2011-06-29 16:05:30', 1002, '2011-06-29 16:14:52', 1002, 450.00000),
(1005, 1000, 'Y', '2011-07-30 16:38:38', 1002, '2011-07-30 16:38:38', 1002, -7.00000),
(1003, 1000, 'Y', '2011-07-30 16:38:38', 1002, '2011-07-30 16:38:38', 1002, -2.00000);

-- --------------------------------------------------------

--
-- Table structure for table `t_movement`
--

CREATE TABLE IF NOT EXISTS `t_movement` (
  `T_MOVEMENT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MOVEDATE` datetime NOT NULL,
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL,
  `M_WAREHOUSETO_ID` int(10) NOT NULL,
  `DOCSTATUS` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
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
  `T_MOVEMENTDETAIL_ID` int(10) NOT NULL,
  `T_MOVEMENT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `MOVEDATE` datetime NOT NULL,
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL,
  `M_WAREHOUSETO_ID` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL,
  `M_UOM_ID` int(10) NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MOVEQUANTITY` double(15,5) NOT NULL,
  PRIMARY KEY (`T_MOVEMENTDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_movementdetail`
--


-- --------------------------------------------------------


--
-- Table structure for table `T_INVENTORYUSE`
--

CREATE TABLE IF NOT EXISTS `T_INVENTORYUSE` (
  `T_INVENTORYUSE_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `USEDATE` datetime NOT NULL,
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL,  
  `DOCSTATUS` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_INVENTORYUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `T_INVENTORYUSE`
--


-- --------------------------------------------------------

--
-- Table structure for table `T_INVENTORYUSEDETAIL`
--

CREATE TABLE IF NOT EXISTS `T_INVENTORYUSEDETAIL` (
  `T_INVENTORYUSEDETAIL_ID` int(10) NOT NULL,
  `T_INVENTORYUSE_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `USEDATE` datetime NOT NULL,
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL,
  `M_UOM_ID` int(10) NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `USEDQUANTITY` double(15,5) NOT NULL,
  PRIMARY KEY (`T_INVENTORYUSEDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `T_INVENTORYUSEDETAIL`
--

---************************************************************************************
-- --------------------------------------------------------


--
-- Table structure for table `T_PHYSICALCOUNT`
--

CREATE TABLE IF NOT EXISTS `T_PHYSICALCOUNT` (
  `T_PHYSICALCOUNT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `COUNTDATE` datetime NOT NULL,
  `M_WAREHOUSE_ID` int(10) NOT NULL,  
  `DOCSTATUS` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_PHYSICALCOUNT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `T_PHYSICALCOUNT`
--


-- --------------------------------------------------------

--
-- Table structure for table `T_PHYSICALCOUNTDETAIL`
--

CREATE TABLE IF NOT EXISTS `T_PHYSICALCOUNTDETAIL` (
  `T_PHYSICALCOUNTDETAIL_ID` int(10) NOT NULL,
  `T_PHYSICALCOUNT_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `COUNTDATE` datetime NOT NULL,
  `M_WAREHOUSE_ID` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL,
  `M_UOM_ID` int(10) NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `BOOKQUANTITY` double(15,5) NOT NULL,
  `COUNTQUANTITY` double(15,5) NOT NULL,
  PRIMARY KEY (`T_PHYSICALCOUNTDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `T_PHYSICALCOUNTDETAIL`
--

---**************************************************************************************

-- --------------------------------------------------------

--
-- Table structure for table `t_transaction`
--

CREATE TABLE IF NOT EXISTS `t_transaction` (
  `T_TRANSACTION_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `DOCUMENTNO` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TRXDATE` datetime NOT NULL,
  `M_BPARTNER_ID` int(10) NOT NULL,
  `ISSALESTRX` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `SUBTRXAMOUNT` double(15,2) DEFAULT NULL,
  `GRANDTRXAMOUNT` double(15,2) DEFAULT NULL,
  `TRXTAXAMOUNT` double(15,2) DEFAULT NULL,
  `ISPAID` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `PAYMENTRULE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'P',
  `DOCSTATUS` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'DR',
  `PROCESSED` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`T_TRANSACTION_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `t_transaction`
--

INSERT INTO `t_transaction` (`T_TRANSACTION_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `DOCUMENTNO`, `ISACTIVE`, `DESCRIPTION`, `TRXDATE`, `M_BPARTNER_ID`, `ISSALESTRX`, `SUBTRXAMOUNT`, `GRANDTRXAMOUNT`, `TRXTAXAMOUNT`, `ISPAID`, `PAYMENTRULE`, `DOCSTATUS`, `PROCESSED`) VALUES
(1000, '2011-06-29 13:20:26', 1002, '2011-06-29 13:20:26', 1002, '1', 'Y', NULL, '2011-06-29 00:00:00', 1001, 'N', 8556.00, 8556.00, 60.00, 'Y', 'P', 'CO', 'Y'),
(1001, '2011-06-29 13:22:26', 1002, '2011-06-29 13:22:26', 1002, '1', 'Y', NULL, '2011-06-29 00:00:00', 1000, 'Y', 350.00, 350.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1002, '2011-06-29 13:48:03', 1002, '2011-06-29 13:48:03', 1002, '2', 'Y', NULL, '2011-06-29 00:00:00', 1000, 'Y', 3960.00, 3960.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1003, '2011-06-29 16:05:29', 1002, '2011-06-29 16:05:29', 1002, '457', 'Y', NULL, '2011-06-28 00:00:00', 1001, 'N', 58500.00, 58500.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1004, '2011-06-29 16:07:20', 1002, '2011-06-29 16:14:52', 1002, '3', 'Y', NULL, '2011-06-29 00:00:00', 1000, 'Y', 7500.00, 7500.00, 0.00, 'Y', 'P', 'RE', 'Y'),
(1005, '2011-06-29 18:11:12', 1002, '2011-06-29 18:11:12', 1002, '2', 'Y', NULL, '2011-06-29 18:11:12', 1001, 'N', 5430.00, 10860.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1006, '2011-06-29 18:12:06', 1002, '2011-06-29 18:12:06', 1002, '4', 'Y', NULL, '2011-06-29 18:12:06', 1000, 'Y', 1444.00, 2888.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1007, '2011-07-02 12:19:37', 1002, '2011-07-02 12:19:37', 1002, '5', 'Y', NULL, '2011-07-02 12:19:37', 1000, 'Y', 2600.00, 5200.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1008, '2011-07-02 12:21:37', 1002, '2011-07-02 12:21:37', 1002, '3', 'Y', NULL, '2011-07-02 12:21:37', 1001, 'N', 1000.00, 2000.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1009, '2011-07-30 16:22:10', 1002, '2011-07-30 16:22:10', 1002, '6', 'Y', NULL, '2011-07-30 16:22:10', 1002, 'Y', 875.00, 1750.00, 780.00, 'Y', 'P', 'CO', 'Y'),
(1010, '2011-07-30 16:23:54', 1002, '2011-07-30 16:23:54', 1002, '4', 'Y', NULL, '2011-07-30 16:23:54', 1001, 'N', 3600.00, 7200.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1011, '2011-07-30 16:24:39', 1002, '2011-07-30 16:24:39', 1002, '5', 'Y', NULL, '2011-07-30 16:24:39', 1001, 'N', 130.00, 260.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1012, '2011-07-30 16:38:38', 1002, '2011-07-30 16:38:38', 1002, 'rt6788', 'Y', NULL, '2011-07-28 00:00:00', 1000, 'Y', 248.00, 248.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1013, '2011-07-30 16:44:54', 1002, '2011-07-30 16:44:54', 1002, '6', 'Y', NULL, '2011-07-30 00:00:00', 1001, 'N', 1904.00, 1904.00, 0.00, 'Y', 'P', 'CO', 'Y');

-- --------------------------------------------------------

--
-- Table structure for table `t_trxdetail`
--

CREATE TABLE IF NOT EXISTS `t_trxdetail` (
  `T_TRXDETAIL_ID` int(10) NOT NULL,
  `T_TRANSACTION_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `TRXDATE` datetime NOT NULL,
  `M_BPARTNER_ID` int(10) NOT NULL,
  `ISSALESTRX` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL,
  `M_UOM_ID` int(10) NOT NULL,
  `M_WAREHOUSE_ID` int(10) NOT NULL,
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TRXQUANTITY` double(15,5) NOT NULL,
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

INSERT INTO `t_trxdetail` (`T_TRXDETAIL_ID`, `T_TRANSACTION_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `TRXDATE`, `M_BPARTNER_ID`, `ISSALESTRX`, `ISACTIVE`, `M_PRODUCT_ID`, `M_UOM_ID`, `M_WAREHOUSE_ID`, `DESCRIPTION`, `TRXQUANTITY`, `UNITPRICE`, `DISCOUNTRATE`, `DISCOUNTAMT`, `MARGIN`, `UNITCOST`, `LINENETAMT`, `LINETAXAMOUNT`) VALUES
(1000, 1000, '2011-06-29 13:20:27', 1002, '2011-06-29 13:20:27', 1002, '2011-06-29 00:00:00', 1001, 'N', 'Y', 1000, 1000, 1001, NULL, 45.00000, 12.00, 0.00000, 0.00, 0.00000, 0.00000, 540.00, 60.00),
(1001, 1000, '2011-06-29 13:20:27', 1002, '2011-06-29 13:20:27', 1002, '2011-06-29 00:00:00', 1001, 'N', 'Y', 1001, 1002, 1001, NULL, 234.00000, 34.00, 0.00000, 0.00, 0.00000, 0.00000, 7956.00, 0.00),
(1002, 1001, '2011-06-29 13:22:26', 1002, '2011-06-29 13:22:26', 1002, '2011-06-29 00:00:00', 1000, 'Y', 'Y', 1001, 1002, 1001, NULL, 2.00000, 55.00, 0.00000, 0.00, 0.61765, 34.00000, 110.00, 0.00),
(1003, 1001, '2011-06-29 13:22:26', 1002, '2011-06-29 13:22:26', 1002, '2011-06-29 00:00:00', 1000, 'Y', 'Y', 1000, 1000, 1001, '234788 783', 12.00000, 20.00, 0.00000, 0.00, 0.66667, 12.00000, 240.00, 0.00),
(1004, 1002, '2011-06-29 13:48:04', 1002, '2011-06-29 13:48:04', 1002, '2011-06-29 00:00:00', 1000, 'Y', 'Y', 1001, 1002, 1001, NULL, 72.00000, 55.00, 0.00000, 0.00, 0.61765, 34.00000, 3960.00, 0.00),
(1005, 1003, '2011-06-29 16:05:29', 1002, '2011-06-29 16:05:29', 1002, '2011-06-28 00:00:00', 1001, 'N', 'Y', 1002, 1000, 1001, NULL, 450.00000, 130.00, 0.00000, 0.00, 0.00000, 0.00000, 58500.00, 0.00),
(1006, 1004, '2011-06-29 16:07:20', 1002, '2011-06-29 16:07:20', 1002, '2011-06-29 00:00:00', 1000, 'Y', 'Y', 1002, 1000, 1001, NULL, 50.00000, 150.00, 0.00000, 0.00, 0.15385, 130.00000, 7500.00, 0.00),
(1007, 1005, '2011-06-29 18:11:12', 1002, '2011-06-29 18:11:12', 1002, '2011-06-29 18:11:12', 1001, 'N', 'Y', 1000, 1000, 0, NULL, 543.00000, 10.00, 0.16667, 2.00, 0.00000, 0.00000, 5430.00, 0.00),
(1008, 1006, '2011-06-29 18:12:06', 1002, '2011-06-29 18:12:06', 1002, '2011-06-29 18:12:06', 1000, 'Y', 'Y', 1000, 1000, 0, NULL, 76.00000, 19.00, 0.05000, 1.00, 0.00000, 0.00000, 1444.00, 0.00),
(1009, 1007, '2011-07-02 12:19:37', 1002, '2011-07-02 12:19:37', 1002, '2011-07-02 12:19:37', 1000, 'Y', 'Y', 1000, 1003, 0, NULL, 130.00000, 20.00, 0.00000, 0.00, 0.00000, 0.00000, 2600.00, 0.00),
(1010, 1008, '2011-07-02 12:21:37', 1002, '2011-07-02 12:21:37', 1002, '2011-07-02 12:21:37', 1001, 'N', 'Y', 1004, 1003, 0, NULL, 50.00000, 20.00, 0.00000, 0.00, 0.00000, 0.00000, 1000.00, 0.00),
(1011, 1009, '2011-07-30 16:22:10', 1002, '2011-07-30 16:22:10', 1002, '2011-07-30 16:22:10', 1002, 'Y', 'Y', 1000, 1003, 0, NULL, 35.00000, 25.00, -0.25000, -5.00, 0.00000, 0.00000, 875.00, 780.00),
(1012, 1010, '2011-07-30 16:23:54', 1002, '2011-07-30 16:23:54', 1002, '2011-07-30 16:23:54', 1001, 'N', 'Y', 1005, 1004, 0, NULL, 450.00000, 8.00, 0.00000, 0.00, 0.00000, 0.00000, 3600.00, 0.00),
(1013, 1011, '2011-07-30 16:24:39', 1002, '2011-07-30 16:24:39', 1002, '2011-07-30 16:24:39', 1001, 'N', 'Y', 1005, 1004, 0, NULL, 10.00000, 13.00, -0.62500, -5.00, 0.00000, 0.00000, 130.00, 0.00),
(1014, 1012, '2011-07-30 16:38:38', 1002, '2011-07-30 16:38:38', 1002, '2011-07-28 00:00:00', 1000, 'Y', 'Y', 1005, 1004, 1000, NULL, 7.00000, 10.00, 0.00000, 0.00, 0.23324, 8.10870, 70.00, 0.00),
(1015, 1012, '2011-07-30 16:38:38', 1002, '2011-07-30 16:38:38', 1002, '2011-07-28 00:00:00', 1000, 'Y', 'Y', 1003, 1000, 1000, NULL, 2.00000, 34.00, 0.00000, 0.00, 0.00000, 0.00000, 68.00, 0.00),
(1016, 1012, '2011-07-30 16:38:38', 1002, '2011-07-30 16:38:38', 1002, '2011-07-28 00:00:00', 1000, 'Y', 'Y', 1001, 1002, 1001, NULL, 2.00000, 55.00, 0.00000, 0.00, 0.61765, 34.00000, 110.00, 0.00),
(1017, 1013, '2011-07-30 16:44:54', 1002, '2011-07-30 16:44:54', 1002, '2011-07-30 00:00:00', 1001, 'N', 'Y', 1001, 1002, 1001, NULL, 56.00000, 34.00, 0.00000, 0.00, 0.00000, 34.00000, 1904.00, 0.00);

-- --------------------------------------------------------

--
-- Table structure for table `u_activeshopid`
--

CREATE TABLE IF NOT EXISTS `u_activeshopid` (
  `M_SHOP_ID` int(10) NOT NULL,
  PRIMARY KEY (`M_SHOP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_activeshopid`
--

INSERT INTO `u_activeshopid` (`M_SHOP_ID`) VALUES
(1000);

-- --------------------------------------------------------

--
-- Table structure for table `u_formaccess`
--

CREATE TABLE IF NOT EXISTS `u_formaccess` (
  `M_SHOP_ID` int(10) NOT NULL,
  `U_USER_ID` int(10) NOT NULL,
  `FORMNAME` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ACCESSLEVEL` varchar(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'NA',
  PRIMARY KEY (`M_SHOP_ID`,`U_USER_ID`,`FORMNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_formaccess`
--

INSERT INTO `u_formaccess` (`M_SHOP_ID`, `U_USER_ID`, `FORMNAME`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `ACCESSLEVEL`) VALUES
(1000, 1003, 'ndSales', '2011-07-30 16:54:12', 1002, '2011-07-30 16:54:12', 1002, 'Y', NULL, 'InActive');

-- --------------------------------------------------------

--
-- Table structure for table `u_sequence`
--

CREATE TABLE IF NOT EXISTS `u_sequence` (
  `U_SEQUENCE_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `NAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `ISTABLEID` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `BASEDOC` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `CURRENTNEXT` int(10) DEFAULT NULL,
  PRIMARY KEY (`U_SEQUENCE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_sequence`
--

INSERT INTO `u_sequence` (`U_SEQUENCE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `ISTABLEID`, `BASEDOC`, `CURRENTNEXT`) VALUES
(1000, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'U_SEQUENCE', 'Y', 'Y', '', 1016),
(1001, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'M_CITY', 'Y', 'Y', '', 1000),
(1002, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'M_LOCALITY', 'Y', 'Y', '', 1000),
(1003, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'M_SUBLOCALITY', 'Y', 'Y', '', 1000),
(1004, '2011-06-19 16:31:29', 0, '2011-07-30 16:15:44', 1002, 'M_UOM', 'Y', 'Y', '', 1005),
(1005, '2011-06-19 16:31:29', 0, '2011-07-30 16:14:45', 1002, 'M_PRODUCTCATEGORY', 'Y', 'Y', '', 1003),
(1006, '2011-06-19 16:31:29', 0, '2011-07-30 16:16:45', 1002, 'M_PRODUCT', 'Y', 'Y', '', 1006),
(1007, '2011-06-19 16:31:29', 0, '2011-07-30 16:47:19', 1002, 'M_BPARTNER', 'Y', 'Y', '', 1004),
(1008, '2011-06-19 16:31:29', 0, '2011-06-29 13:07:54', 1000, 'M_SHOP', 'Y', 'Y', '', 1001),
(1009, '2011-06-19 16:31:29', 0, '2011-07-30 16:50:44', 1002, 'U_USER', 'Y', 'Y', '', 1004),
(1010, '2011-06-19 16:31:29', 0, '2011-07-30 16:44:54', 1002, 'T_TRANSACTION', 'Y', 'Y', '', 1014),
(1011, '2011-06-19 16:31:29', 0, '2011-07-30 16:44:54', 1002, 'T_TRXDETAIL', 'Y', 'Y', '', 1018),
(1012, '2011-06-19 16:31:29', 0, '2011-07-02 12:21:10', 1002, 'M_UOM_CONVERSION', 'Y', 'Y', '', 1004),
(1013, '2011-06-19 16:31:29', 0, '2011-07-30 16:44:54', 1002, 'PURCHASE', 'Y', 'N', 'PURCHASE', 7),
(1014, '2011-06-19 16:31:29', 0, '2011-07-30 16:22:10', 1002, 'SALES', 'Y', 'N', 'SALES', 7),
(1015, '2011-06-19 16:31:29', 0, '2011-07-30 16:45:46', 1002, 'M_WAREHOUSE', 'Y', 'Y', '', 1003),
(1016, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_MOVEMENT', 'Y', 'Y', '', 1000),
(1017, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_MOVEMENTDETAIL', 'Y', 'Y', '', 1000),
(1018, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'MOVE', 'Y', 'N', 'MOVE', 1),
(1019, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'USE', 'Y', 'N', 'USE', 1),
(1020, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'COUNT', 'Y', 'N', 'COUNT', 1),
(1021, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_PHYSICALCOUNT', 'Y', 'Y', '', 1000),
(1022, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_PHYSICALCOUNTDETAIL', 'Y', 'Y', '', 1000),
(1023, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_INVENTORYUSE', 'Y', 'Y', '', 1000),
(1024, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_INVENTORYUSEDETAIL', 'Y', 'Y', '', 1000);

-- --------------------------------------------------------

--
-- Table structure for table `u_shopaccess`
--

CREATE TABLE IF NOT EXISTS `u_shopaccess` (
  `M_SHOP_ID` int(10) NOT NULL,
  `U_USER_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ACCESSLEVEL` varchar(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'NA',
  PRIMARY KEY (`M_SHOP_ID`,`U_USER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_shopaccess`
--

INSERT INTO `u_shopaccess` (`M_SHOP_ID`, `U_USER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `ACCESSLEVEL`) VALUES
(1000, 1003, '2011-07-30 17:01:00', 1002, '2011-07-30 17:01:00', 1002, 'Y', NULL, 'ReadWite'),
(1000, 1002, '2011-06-29 13:12:35', 1000, '2011-06-29 13:12:35', 1000, 'Y', NULL, 'ReadWite');

-- --------------------------------------------------------

--
-- Table structure for table `u_user`
--

CREATE TABLE IF NOT EXISTS `u_user` (
  `U_USER_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `FIRSTNAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `MIDDLENAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `LASTNAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `USERNAME` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `PASSWORD` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`U_USER_ID`),
  UNIQUE KEY `USERNAME` (`USERNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_user`
--

INSERT INTO `u_user` (`U_USER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `FIRSTNAME`, `MIDDLENAME`, `LASTNAME`, `USERNAME`, `PASSWORD`, `ISACTIVE`, `DESCRIPTION`) VALUES
(1003, '2011-07-30 16:50:44', 1002, '2011-07-30 16:51:59', 1002, 'Aziza', 'Muzeyin', '', 'azz', '123', 'Y', NULL),
(1002, '2011-06-29 13:08:51', 1000, '2011-06-29 13:08:51', 1000, 'Administrator', '', '', 'ad', '12', 'Y', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `u_warehouseaccess`
--

CREATE TABLE IF NOT EXISTS `u_warehouseaccess` (
  `M_SHOP_ID` int(10) NOT NULL,
  `U_USER_ID` int(10) NOT NULL,
  `M_WAREHOUSE_ID` int(10) NOT NULL,
  `CREATED` datetime NOT NULL,
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL,
  `UPDATEDBY` int(10) NOT NULL,
  `ISACTIVE` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Y',
  `DESCRIPTION` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CANSALEFROM` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANBUYFOR` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANMOVEFORM` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANMOVETO` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANUSEFROM` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  `CANCOUNT` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'N',
  PRIMARY KEY (`M_SHOP_ID`,`U_USER_ID`,`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `u_warehouseaccess`
--

INSERT INTO `u_warehouseaccess` (`M_SHOP_ID`, `U_USER_ID`, `M_WAREHOUSE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `CANSALEFROM`, `CANBUYFOR`, `CANMOVEFORM`, `CANMOVETO`, `CANUSEFROM`, `CANCOUNT`) VALUES
(1000, 1002, 1000, '2011-06-29 13:13:20', 1000, '2011-06-29 13:13:20', 1000, 'Y', NULL, 'Y', 'Y', 'Y', 'Y', 'Y', 'Y'),
(1000, 1002, 1001, '2011-06-29 13:13:28', 1000, '2011-06-29 13:13:28', 1000, 'Y', NULL, 'Y', 'Y', 'Y', 'Y', 'Y', 'Y');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
