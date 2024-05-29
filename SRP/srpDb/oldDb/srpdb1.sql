-- phpMyAdmin SQL Dump
-- version 2.6.4-pl1
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Generation Time: Apr 06, 2012 at 05:39 PM
-- Server version: 4.1.14
-- PHP Version: 5.0.4
-- 
-- Database: `srpdb`
-- 

-- --------------------------------------------------------

CREATE TABLE `c_country` (
  `C_COUNTRY_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',  
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `ISDEFAULT` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`C_COUNTRY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_country`
-- 

INSERT INTO `c_country` ( `C_COUNTRY_ID` , `M_SHOP_ID` , `NAME` , `CREATED` , `CREATEDBY` , `UPDATED` , `UPDATEDBY` , `DESCRIPTION` , `ISACTIVE` , `ISDEFAULT` )
VALUES ( 1000, 0, 'Ethiopia', '2012-03-17 12:06:08', 1002, '2012-03-17 12:06:08', 1002, NULL , 'Y', 'Y' ) ;

-- 
-- Table structure for table `m_bpartner`
-- 

CREATE TABLE `m_bpartner` (
  `M_BPARTNER_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `NAME2` varchar(60),
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ADDRESS1` varchar(60),
  `ADDRESS2` varchar(60),
  `ADDRESS3` varchar(60),
  `ADDRESS4` varchar(60),
  `CITYNAME` varchar(60),
  `LOCALITYNAME` varchar(40),
  `C_COUNTRY_ID` int(10),
  `C_CITY_ID` int(10),
  `C_LOCALITY_ID` int(10),
  `C_SUBLOCALITY_ID` int(10),
  `POSTAL` varchar(10),
  `PHONE` varchar(40),
  `PHONE2` varchar(40),
  `FAX` varchar(40),
  `TIN`  varchar(10),
  `VATREGNO`  varchar(20),
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `ISVENDOR` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `ISCUSTOMER` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  PRIMARY KEY  (`M_BPARTNER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_bpartner`
-- 

INSERT INTO `m_bpartner` (`M_BPARTNER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `DESCRIPTION`, `ISACTIVE`, `ISVENDOR`, `ISCUSTOMER`) VALUES (1000, '2011-06-29 13:09:12', 1000, '2011-06-29 13:09:12', 1000, 'General Customer', NULL, 'Y', 'N', 'Y'),
(1001, '2011-06-29 13:09:41', 1000, '2011-06-29 13:09:41', 1000, 'Vendor One', NULL, 'Y', 'Y', 'N'),
(1002, '2011-07-30 16:20:11', 1002, '2011-07-30 16:20:11', 1002, 'aziza', NULL, 'Y', 'N', 'Y'),
(1003, '2011-07-30 16:47:19', 1002, '2011-07-30 16:47:19', 1002, 'ABC', NULL, 'Y', 'Y', 'Y');

-- --------------------------------------------------------

-- 
-- Table structure for table `C_CITY`
-- 

CREATE TABLE `C_CITY` (
  `C_CITY_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `M_COUNTRY_ID` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `COUNTRY` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `ISDEFAULT` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`C_CITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `C_CITY`
-- 

INSERT INTO `C_CITY` (`C_CITY_ID`, `M_SHOP_ID`, `M_COUNTRY_ID`, `NAME`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `COUNTRY`, `DESCRIPTION`, `ISACTIVE`, `ISDEFAULT`) VALUES (1000, 0, 1000, 'Addis Ababa', '2012-03-17 12:06:08', 1002, '2012-03-17 12:06:08', 1002, 'Ethiopia', NULL, 'Y', 'Y');

-- --------------------------------------------------------

-- 
-- Table structure for table `m_locality`
-- 

CREATE TABLE `m_locality` (
  `M_LOCALITY_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `C_CITY_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ISSUMMARY` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `M_PARENTLOCALITY_ID` int(11) NOT NULL default '0',
  PRIMARY KEY  (`M_LOCALITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_locality`
-- 

INSERT INTO `m_locality` (`M_LOCALITY_ID`, `C_CITY_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `DESCRIPTION`, `ISSUMMARY`, `ISACTIVE`, `M_PARENTLOCALITY_ID`) VALUES (1000, 1000, '2012-03-17 12:06:29', 1002, '2012-03-17 12:06:29', 1002, 'Gullele', NULL, 'N', 'Y', 0);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_product`
-- 

CREATE TABLE `m_product` (
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `CODE` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `M_PRODUCTCATEGORY_ID` int(10) NOT NULL default '0',
  `M_UOM_ID` int(10) NOT NULL default '0',
  `PRODUCTTYPE` char(1) collate utf8_unicode_ci NOT NULL default '',
  `UPC_EAN` varchar(255) collate utf8_unicode_ci default NULL,
  `IMAGEPATH` varchar(255) collate utf8_unicode_ci default NULL,
  `PURCHASEPRICE` double(15,5) default '0.00000',
  `SELLINGPRICE` double(15,5) default '0.00000',
  `CURRENTQTY` double(15,5) default '0.00000',
  `CURRENTCOST` double(15,5) default '0.00000',
  `ACCUMULATEDQTY` double(15,5) default '0.00000',
  `ACCUMULATEDCOST` double(15,5) default '0.00000',
  PRIMARY KEY  (`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_product`
-- 

INSERT INTO `m_product` (`M_PRODUCT_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `CODE`, `NAME`, `ISACTIVE`, `DESCRIPTION`, `M_PRODUCTCATEGORY_ID`, `M_UOM_ID`, `PRODUCTTYPE`, `UPC_EAN`, `IMAGEPATH`, `PURCHASEPRICE`, `SELLINGPRICE`, `CURRENTQTY`, `CURRENTCOST`, `ACCUMULATEDQTY`, `ACCUMULATEDCOST`) VALUES (1000, '2011-06-29 13:14:38', 1000, '2012-04-02 18:39:14', 1002, '1902', 'Garden and Pole Lamp 1902', 'Y', NULL, 1000, 1000, 'I', NULL, 'G:\\Electric World\\itemPic\\GnP 1902.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1001, '2011-06-29 13:14:38', 1000, '2012-04-02 18:39:22', 1002, '1905', 'Garden and Pole Lamp 1905', 'Y', NULL, 1000, 1000, 'I', NULL, 'G:\\Electric World\\itemPic\\GnP 1905.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1002, '2011-06-29 13:14:38', 1000, '2012-03-23 12:44:12', 1002, '1909', 'Garden and Pole Lamp 1909', 'Y', NULL, 1000, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\Gnp 1909.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1003, '2011-06-29 13:14:38', 1000, '2012-03-23 12:44:18', 1002, '1913A', 'Garden and Pole Lamp 1913A', 'Y', NULL, 1000, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\Gnp 1913A.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1004, '2011-06-29 13:14:38', 1000, '2012-04-02 18:39:28', 1002, '2013', 'Bulk Head Lamp 2013', 'Y', NULL, 1001, 1001, 'I', NULL, 'G:\\Electric World\\itemPic\\bh 2013.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1005, '2011-06-29 13:14:38', 1000, '2012-03-22 18:48:06', 1002, '2015', 'Bulk Head Lamp 2015', 'Y', NULL, 1001, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\bh 2015.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1006, '2011-06-29 13:14:38', 1000, '2012-03-22 18:48:10', 1002, '2032', 'Bulk Head Lamp 2032', 'Y', NULL, 1001, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\bh 2032.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1007, '2011-06-29 13:14:38', 1000, '2012-03-22 18:48:14', 1002, '2021', 'Bulk Head Lamp 2021', 'Y', NULL, 1001, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\bh 2021.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1008, '2011-06-29 13:14:38', 1000, '2012-03-23 12:44:32', 1002, 'E27', 'Genie Long Life 5w E27', 'Y', NULL, 1002, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\GENIE LONG LIFE.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1009, '2011-06-29 13:14:38', 1000, '2012-03-23 12:53:51', 1002, 'TL-D18', 'TL-D Snow White 18w', 'Y', NULL, 1006, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TL-D SW.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1010, '2011-06-29 13:14:38', 1000, '2012-03-23 12:53:56', 1002, 'TL-D36', 'TL-D Snow White 36w', 'Y', NULL, 1006, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TL-D SW.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1011, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:02', 1002, 'MR16-20', 'LV Halogen with Reflector ESS MR16 20w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\MR16.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1012, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:07', 1002, 'MR16-35', 'LV Halogen with Reflector ESS MR16 35w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\MR16.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1013, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:12', 1002, 'MR16-50', 'LV Halogen with Reflector ESS MR16 50w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\MR16.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1014, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:20', 1002, 'G4-10', 'LV Halogen without Reflector capsuleline 10w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\CAP LS GY6.35.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1015, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:25', 1002, 'G4-20', 'LV Halogen without Reflector capsuleline 20w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\CAP LS GY6.35.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1016, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:31', 1002, 'GY6.35', 'LV Halogen without Reflector capsuleline 50w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\CAP LS GY6.35.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1017, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:38', 1002, 'GU10-35', 'MV Halogen with Reflector twistline Alue 230v 35w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\GU110.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1018, '2011-06-29 13:14:38', 1000, '2012-03-23 12:45:43', 1002, 'GU10-50', 'MV Halogen with Reflector Twistline Alue 230v 50w', 'Y', NULL, 1003, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\GU110.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1019, '2011-06-29 13:14:38', 1000, '2012-03-23 12:46:26', 1002, 'SON-T-70W-E27', 'SON-T Sodium lamp 70w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\son-t.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1020, '2011-06-29 13:14:38', 1000, '2012-03-23 12:46:32', 1002, 'SON-T-100W-E40', 'SON-T Sodium lamp 100w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\son-t.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1021, '2011-06-29 13:14:38', 1000, '2012-03-23 12:46:39', 1002, 'SON-T-150W-E40', 'SON-T Sodium lamp 150w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\son-t.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1022, '2011-06-29 13:14:38', 1000, '2012-03-23 12:46:43', 1002, 'SON-T-250W-E40', 'SON-T Sodium lamp 250w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\son-t.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1023, '2011-06-29 13:14:38', 1000, '2012-03-23 12:46:49', 1002, 'SON-T-400W-E40', 'SON-T Sodium lamp 400w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\son-t.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1024, '2011-06-29 13:14:38', 1000, '2012-03-23 12:47:22', 1002, 'HPL-N-50w-542', 'HPL-N 50w /542', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\hpl.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1025, '2011-06-29 13:14:38', 1000, '2012-03-23 12:47:28', 1002, 'HPL-N-80w-543', 'HPL-N 80w /543', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\hpl.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1026, '2011-06-29 13:14:38', 1000, '2012-03-23 12:47:33', 1002, 'HPL-N-125w-544', 'HPL-N 125w /544', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\hpl.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1027, '2011-06-29 13:14:38', 1000, '2012-03-23 12:47:37', 1002, 'HPL-N-250w-545', 'HPL-N 250w /545', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\hpl.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1028, '2011-06-29 13:14:38', 1000, '2012-04-02 18:39:44', 1002, 'ML-E27-100w', 'ML E27 100w', 'Y', NULL, 1004, 1001, 'I', NULL, 'G:\\Electric World\\itemPic\\ml.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1029, '2011-06-29 13:14:38', 1000, '2012-03-23 12:47:48', 1002, 'ML-B22-160w', 'ML B22 160w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\ml.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1030, '2011-06-29 13:14:38', 1000, '2012-03-23 12:48:16', 1002, 'ML-E27-250w', 'ML E27 250w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\ml.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1031, '2011-06-29 13:14:38', 1000, '2012-03-23 12:48:20', 1002, 'ML-E40-250w', 'ML E40 250w', 'Y', NULL, 1004, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\ml.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1032, '2011-06-29 13:14:38', 1000, '2012-03-23 12:49:08', 1002, '1XTL-D-18W-EBE', 'Fluorescent lamp TMS012 1XTL-D 18W EBE', 'Y', NULL, 1005, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TMS012 EBE.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1033, '2011-06-29 13:14:38', 1000, '2012-03-23 12:49:13', 1002, '1XTL-D-36W-EBE', 'Fluorescent lamp TMS012 1XTL-D 36W EBE', 'Y', NULL, 1005, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TMS012 EBE.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1034, '2011-06-29 13:14:38', 1000, '2012-03-23 12:49:17', 1002, '2XTL-D-18W-EBE', 'Fluorescent lamp TMS012 2XTL-D 18W EBE', 'Y', NULL, 1005, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TMS012 EBE.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1035, '2011-06-29 13:14:38', 1000, '2012-03-23 12:49:21', 1002, '2XTL-D-36W-EBE', 'Fluorescent lamp TMS012 2XTL-D 36W EBE', 'Y', NULL, 1005, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TMS012 EBE.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1036, '2011-06-29 13:14:38', 1000, '2012-03-23 12:49:28', 1002, '2XTL-D-18W', 'Fluorescent lamp TMS012 2XTL-D 18W', 'Y', NULL, 1005, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TMS012.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1037, '2011-06-29 13:14:38', 1000, '2012-03-23 12:49:32', 1002, '2XTL-D-36W', 'Fluorescent lamp TMS012 2XTL-D 36W', 'Y', NULL, 1005, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\TMS012.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1038, '2011-06-29 13:14:38', 1000, '2012-03-23 12:51:54', 1002, 'LLB8-1p-6A', 'longJing DX Mini Circuit Breaker LLB8 1p 6A', 'Y', NULL, 1007, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LLB8-1P.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1039, '2011-06-29 13:14:38', 1000, '2012-03-23 12:52:12', 1002, 'LLB8-1p-16A', 'longJing DX Mini Circuit Breaker LLB8 1p 16A', 'Y', NULL, 1007, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LLB8-1P.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1040, '2011-06-29 13:14:38', 1000, '2012-03-23 12:52:20', 1002, 'LLB8-4p-32A', 'longJing DX Mini Circuit Breaker LLB8 4p 32A', 'Y', NULL, 1007, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LLB8-4P.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1041, '2011-06-29 13:14:38', 1000, '2012-03-23 12:52:28', 1002, 'LLB8-4p-63A', 'longJing DX Mini Circuit Breaker LLB8 4p 63A', 'Y', NULL, 1007, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LLB8-4P.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1042, '2011-06-29 13:14:38', 1000, '2012-03-23 12:52:40', 1002, 'Breaker-S-63', 'longJing S series Moulded Case Circuit Breaker S-63', 'Y', NULL, 1007, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\S-63.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1043, '2011-06-29 13:14:38', 1000, '2012-03-22 18:57:16', 1002, 'Breaker-4P', 'longJing S series Moulded Case Circuit Breaker 4P', 'Y', NULL, 1000, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\4P.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1044, '2011-06-29 13:14:38', 1000, '2012-03-22 18:57:32', 1002, 'LC1-D09', 'longJing LC1-D AC Contactor LC1-D09', 'Y', NULL, 1000, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LC1-D09.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1045, '2011-06-29 13:14:38', 1000, '2012-03-22 18:57:39', 1002, 'LC1-F115', 'longJing LC1-F AC Contactor LC1-F115', 'Y', NULL, 1000, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LC1-F115.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000),
(1046, '2011-06-29 13:14:38', 1000, '2012-03-22 18:57:53', 1002, 'LC1-F780', 'longJing LC1-F AC Contactor LC1-F780', 'Y', NULL, 1000, 1003, 'I', NULL, 'G:\\Electric World\\itemPic\\LC1-F780.png', 12.00000, 20.00000, 335.00000, 10.11458, 588.00000, 5970.00000);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_productcategory`
-- 

CREATE TABLE `m_productcategory` (
  `M_PRODUCTCATEGORY_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`M_PRODUCTCATEGORY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_productcategory`
-- 

INSERT INTO `m_productcategory` (`M_PRODUCTCATEGORY_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES (1000, '2011-06-29 13:11:26', 1000, '2012-03-23 12:39:51', 1002, 'Garden and Pole Lamp', 'Y', NULL),
(1001, '2011-06-29 13:11:34', 1000, '2012-03-23 12:40:30', 1002, 'BulkHead Lamp', 'Y', NULL),
(1002, '2011-07-30 16:14:45', 1002, '2012-03-23 12:42:10', 1002, 'Compact FI Lamps', 'Y', NULL),
(1003, '2012-03-23 12:42:30', 1002, '2012-03-23 12:42:30', 1002, 'Halogen Lamps', 'Y', NULL),
(1004, '2012-03-23 12:43:17', 1002, '2012-03-23 12:43:17', 1002, 'High Intensity D lamps', 'Y', NULL),
(1005, '2012-03-23 12:43:44', 1002, '2012-03-23 12:50:00', 1002, 'Luminaires', 'Y', NULL),
(1006, '2012-03-23 12:50:15', 1002, '2012-03-23 12:50:15', 1002, 'Compact FNI Lamps', 'Y', NULL),
(1007, '2012-03-23 12:50:36', 1002, '2012-03-23 12:50:36', 1002, 'Circuit Breakers', 'Y', NULL),
(1008, '2012-03-23 12:50:46', 1002, '2012-03-23 12:50:46', 1002, 'AC Contactor', 'Y', NULL);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_shop`
-- 

CREATE TABLE `m_shop` (
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`M_SHOP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_shop`
-- 

INSERT INTO `m_shop` (`M_SHOP_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) 
VALUES 
(0, '2011-06-29 13:07:54', 1000, '2011-06-29 13:07:54', 1000, '*', 'Y', 'All Shops'),
(1000, '2011-06-29 13:07:54', 1000, '2011-06-29 13:07:54', 1000, 'Legar', 'Y', NULL);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_sublocality`
-- 

CREATE TABLE `m_sublocality` (
  `M_SUBLOCALITY_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `M_LOCALITY_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ISSUMMARY` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `M_PARENTSUBLOC_ID` int(11) NOT NULL default '0',
  PRIMARY KEY  (`M_SUBLOCALITY_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_sublocality`
-- 

INSERT INTO `m_sublocality` (`M_SUBLOCALITY_ID`, `M_LOCALITY_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `DESCRIPTION`, `ISSUMMARY`, `ISACTIVE`, `M_PARENTSUBLOC_ID`) VALUES (1000, 1000, '2012-03-17 12:06:34', 1002, '2012-03-17 12:06:34', 1002, '09', NULL, 'N', 'Y', 0);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_uom`
-- 

CREATE TABLE `m_uom` (
  `M_UOM_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `STDPRECISION` int(1) NOT NULL default '0',
  `ABBREVATION` varchar(3) collate utf8_unicode_ci NOT NULL default '',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`M_UOM_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_uom`
-- 

INSERT INTO `m_uom` (`M_UOM_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `STDPRECISION`, `ABBREVATION`, `DESCRIPTION`) VALUES (1000, '2011-06-29 13:10:11', 1000, '2011-06-29 13:10:11', 1000, 'Pieces', 'Y', 0, 'pcs', NULL),
(1001, '2011-06-29 13:10:23', 1000, '2011-06-29 13:10:23', 1000, 'Dozen', 'Y', 0, 'dz', NULL),
(1002, '2011-06-29 13:10:41', 1000, '2011-06-29 13:10:41', 1000, 'Packet', 'Y', 0, 'pk', NULL),
(1003, '2011-07-02 12:15:40', 1002, '2011-07-02 12:15:40', 1002, 'Gram', 'Y', 2, 'grm', NULL),
(1004, '2011-07-30 16:15:44', 1002, '2011-07-30 16:15:44', 1002, 'pair', 'Y', 0, 'pr', NULL),
(1005, '2012-03-17 12:03:38', 1002, '2012-03-17 12:03:38', 1002, 'roll', 'Y', 0, 'Rl.', NULL);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_uom_conversion`
-- 

CREATE TABLE `m_uom_conversion` (
  `M_UOM_CONVERSION_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `M_BASE_UOM_ID` int(10) NOT NULL default '0',
  `M_DRIVED_UOM_ID` int(10) NOT NULL default '0',
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `MULTIPLIER` double(15,5) default '0.00000',
  PRIMARY KEY  (`M_UOM_CONVERSION_ID`),
  UNIQUE KEY `M_BASE_UOM_ID` (`M_BASE_UOM_ID`,`M_DRIVED_UOM_ID`,`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_uom_conversion`
-- 

INSERT INTO `m_uom_conversion` (`M_UOM_CONVERSION_ID`, `M_BASE_UOM_ID`, `M_DRIVED_UOM_ID`, `M_PRODUCT_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `MULTIPLIER`) VALUES (1000, 1000, 1001, 0, '2011-06-29 13:11:09', 1000, '2011-06-29 13:11:09', 1000, 'Y', NULL, 12.00000),
(1001, 1000, 1002, 1001, '2011-06-29 13:15:22', 1000, '2011-06-29 13:15:22', 1000, 'Y', NULL, 6.00000),
(1002, 1000, 1003, 1000, '2011-07-02 12:16:55', 1002, '2011-07-02 12:19:05', 1002, 'Y', NULL, 65.00000),
(1003, 1000, 1003, 1004, '2011-07-02 12:21:10', 1002, '2011-07-02 12:21:10', 1002, 'Y', NULL, 10.00000);

-- --------------------------------------------------------

-- 
-- Table structure for table `m_warehouse`
-- 

CREATE TABLE `m_warehouse` (
  `M_WAREHOUSE_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `m_warehouse`
-- 

INSERT INTO `m_warehouse` (`M_WAREHOUSE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `DESCRIPTION`) VALUES (1000, '2011-06-29 13:11:59', 1000, '2011-06-29 13:11:59', 1000, 'Babur Tabiya', 'Y', NULL),
(1001, '2011-06-29 13:12:10', 1000, '2011-06-29 13:12:10', 1000, 'Saris', 'Y', NULL),
(1002, '2011-07-30 16:45:46', 1002, '2011-07-30 16:45:46', 1002, 'Medhaniealem', 'Y', NULL);

-- --------------------------------------------------------

-- 
-- Table structure for table `q_cost`
-- 

CREATE TABLE `q_cost` (
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `CURRENTQTY` double(15,5) default NULL,
  `CURRENTCOST` double(15,5) default NULL,
  `ACCUMULATEDQTY` double(15,5) default NULL,
  `ACCUMULATEDCOST` double(15,5) default NULL,
  PRIMARY KEY  (`M_PRODUCT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `q_cost`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `q_stock`
-- 

CREATE TABLE `q_stock` (
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_WAREHOUSE_ID` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `CURRENTQTY` double(15,5) default NULL,
  PRIMARY KEY  (`M_PRODUCT_ID`,`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `q_stock`
-- 

INSERT INTO `q_stock` (`M_PRODUCT_ID`, `M_WAREHOUSE_ID`, `ISACTIVE`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `CURRENTQTY`) VALUES (1000, 1001, 'Y', '2011-06-29 13:20:27', 1002, '2012-04-03 10:31:31', 1002, 264.00000),
(1001, 1001, 'Y', '2011-06-29 13:20:27', 1002, '2012-04-03 10:31:31', 1002, 856.00000),
(1002, 1001, 'Y', '2011-06-29 16:05:30', 1002, '2012-04-03 10:31:31', 1002, 3600.00000),
(1005, 1000, 'Y', '2011-07-30 16:38:38', 1002, '2012-04-03 14:36:29', 1002, 0.00000),
(1003, 1000, 'Y', '2011-07-30 16:38:38', 1002, '2012-04-03 14:25:28', 1002, 0.00000),
(1003, 1001, 'Y', '2012-03-15 17:29:20', 1002, '2012-04-03 10:31:31', 1002, -5.00000),
(1004, 1001, 'Y', '2012-03-15 17:29:20', 1002, '2012-04-03 10:31:31', 1002, 1500.00000),
(1006, 1000, 'Y', '2012-03-17 12:15:46', 1002, '2012-04-03 14:23:03', 1002, 0.00000),
(1029, 1000, 'Y', '2012-04-01 16:17:36', 1002, '2012-04-03 14:23:03', 1002, 70.00000),
(1004, 1000, 'Y', '2012-04-01 16:17:36', 1002, '2012-04-03 14:23:03', 1002, 71.00000),
(1028, 1000, 'Y', '2012-04-01 16:17:36', 1002, '2012-04-03 14:23:03', 1002, 72.00000),
(1000, 1000, 'Y', '2012-04-03 14:39:28', 1002, '2012-04-03 14:39:28', 1002, 14.00000);

-- --------------------------------------------------------

-- 
-- Table structure for table `t_inventoryuse`
-- 

CREATE TABLE `t_inventoryuse` (
  `T_INVENTORYUSE_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `DOCUMENTNO` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `USEDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL default '0',
  `DOCSTATUS` varchar(2) collate utf8_unicode_ci NOT NULL default 'DR',
  `PROCESSED` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`T_INVENTORYUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_inventoryuse`
-- 

INSERT INTO `t_inventoryuse` (`T_INVENTORYUSE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `DOCUMENTNO`, `ISACTIVE`, `DESCRIPTION`, `USEDATE`, `M_WAREHOUSEFROM_ID`, `DOCSTATUS`, `PROCESSED`) VALUES (1000, '2012-04-01 15:44:00', 1002, '2012-04-01 16:19:09', 1002, '1', 'Y', NULL, '2012-04-01 00:00:00', 1000, 'RE', 'Y');

-- --------------------------------------------------------

-- 
-- Table structure for table `t_inventoryusedetail`
-- 

CREATE TABLE `t_inventoryusedetail` (
  `T_INVENTORYUSEDETAIL_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `T_INVENTORYUSE_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `USEDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_UOM_ID` int(10) NOT NULL default '0',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `USEDQUANTITY` double(15,5) NOT NULL default '0.00000',
  PRIMARY KEY  (`T_INVENTORYUSEDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_inventoryusedetail`
-- 

INSERT INTO `t_inventoryusedetail` (`T_INVENTORYUSEDETAIL_ID`, `T_INVENTORYUSE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `USEDATE`, `M_WAREHOUSEFROM_ID`, `ISACTIVE`, `M_PRODUCT_ID`, `M_UOM_ID`, `DESCRIPTION`, `USEDQUANTITY`) VALUES (1000, 1000, '2012-04-01 15:44:00', 1002, '2012-04-01 16:17:36', 1002, '2012-04-01 00:00:00', 1000, 'Y', 1029, 1003, NULL, 41.00000),
(1001, 1000, '2012-04-01 15:44:00', 1002, '2012-04-01 15:44:00', 1002, '2012-04-01 00:00:00', 1000, 'Y', 1004, 1003, NULL, 45.00000),
(1002, 1000, '2012-04-01 15:44:00', 1002, '2012-04-01 15:44:00', 1002, '2012-04-01 00:00:00', 1000, 'Y', 1028, 1003, NULL, 75.00000),
(1003, 1000, '2012-04-01 15:44:00', 1002, '2012-04-01 15:44:00', 1002, '2012-04-01 00:00:00', 1000, 'Y', 1029, 1003, NULL, 41.00000);

-- --------------------------------------------------------

-- 
-- Table structure for table `t_movement`
-- 

CREATE TABLE `t_movement` (
  `T_MOVEMENT_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `DOCUMENTNO` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `MOVEDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL default '0',
  `M_WAREHOUSETO_ID` int(10) NOT NULL default '0',
  `DOCSTATUS` varchar(2) collate utf8_unicode_ci NOT NULL default 'DR',
  `PROCESSED` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`T_MOVEMENT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_movement`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `t_movementdetail`
-- 

CREATE TABLE `t_movementdetail` (
  `T_MOVEMENTDETAIL_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `T_MOVEMENT_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `MOVEDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_WAREHOUSEFROM_ID` int(10) NOT NULL default '0',
  `M_WAREHOUSETO_ID` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_UOM_ID` int(10) NOT NULL default '0',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `MOVEQUANTITY` double(15,5) NOT NULL default '0.00000',
  PRIMARY KEY  (`T_MOVEMENTDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_movementdetail`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `t_physicalcount`
-- 

CREATE TABLE `t_physicalcount` (
  `T_PHYSICALCOUNT_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `DOCUMENTNO` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `COUNTDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_WAREHOUSE_ID` int(10) NOT NULL default '0',
  `DOCSTATUS` varchar(2) collate utf8_unicode_ci NOT NULL default 'DR',
  `PROCESSED` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`T_PHYSICALCOUNT_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_physicalcount`
-- 

INSERT INTO `t_physicalcount` (`T_PHYSICALCOUNT_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `DOCUMENTNO`, `ISACTIVE`, `DESCRIPTION`, `COUNTDATE`, `M_WAREHOUSE_ID`, `DOCSTATUS`, `PROCESSED`) VALUES (1000, '2012-04-03 09:40:52', 1002, '2012-04-03 10:17:03', 1002, '1', 'Y', NULL, '2012-04-03 00:00:00', 1001, 'CO', 'Y'),
(1001, '2012-04-03 10:20:08', 1002, '2012-04-03 10:21:26', 1002, '2', 'Y', NULL, '2012-04-03 00:00:00', 1001, 'CO', 'Y'),
(1002, '2012-04-03 10:31:31', 1002, '2012-04-03 10:31:31', 1002, '3', 'Y', NULL, '2012-04-03 00:00:00', 1001, 'CO', 'Y'),
(1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '4', 'Y', NULL, '2012-04-03 00:00:00', 1000, 'CO', 'Y'),
(1004, '2012-04-03 14:23:02', 1002, '2012-04-03 14:23:02', 1002, '5', 'Y', NULL, '2012-04-03 00:00:00', 1000, 'CO', 'Y'),
(1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:25:28', 1002, '6', 'Y', NULL, '2012-04-03 00:00:00', 1000, 'RE', 'Y'),
(1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '7', 'Y', NULL, '2012-04-03 00:00:00', 1000, 'CO', 'Y'),
(1007, '2012-04-03 14:39:28', 1002, '2012-04-03 14:39:28', 1002, '8', 'Y', NULL, '2012-04-03 00:00:00', 1000, 'CO', 'Y');

-- --------------------------------------------------------

-- 
-- Table structure for table `t_physicalcountdetail`
-- 

CREATE TABLE `t_physicalcountdetail` (
  `T_PHYSICALCOUNTDETAIL_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `T_PHYSICALCOUNT_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `COUNTDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_WAREHOUSE_ID` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_UOM_ID` int(10) NOT NULL default '0',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `BOOKQUANTITY` double(15,5) NOT NULL default '0.00000',
  `COUNTQUANTITY` double(15,5) NOT NULL default '0.00000',
  PRIMARY KEY  (`T_PHYSICALCOUNTDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_physicalcountdetail`
-- 

INSERT INTO `t_physicalcountdetail` (`T_PHYSICALCOUNTDETAIL_ID`, `T_PHYSICALCOUNT_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `COUNTDATE`, `M_WAREHOUSE_ID`, `ISACTIVE`, `M_PRODUCT_ID`, `M_UOM_ID`, `DESCRIPTION`, `BOOKQUANTITY`, `COUNTQUANTITY`) VALUES (1000, 1000, '2012-04-03 09:40:52', 1002, '2012-04-03 10:17:03', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1004, 1001, NULL, -74.00000, 74.00000),
(1001, 1000, '2012-04-03 09:40:52', 1002, '2012-04-03 09:40:52', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1001, 1000, NULL, 214.00000, 0.00000),
(1002, 1000, '2012-04-03 09:40:52', 1002, '2012-04-03 09:40:52', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1002, 1003, NULL, 450.00000, 450.00000),
(1003, 1000, '2012-04-03 09:40:52', 1002, '2012-04-03 09:40:52', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1003, 1003, NULL, -15.00000, 0.00000),
(1004, 1000, '2012-04-03 09:40:52', 1002, '2012-04-03 09:40:52', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1004, 1001, NULL, -74.00000, 74.00000),
(1005, 1001, '2012-04-03 10:20:08', 1002, '2012-04-03 10:21:26', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1004, 1001, NULL, 0.00000, 750.00000),
(1006, 1001, '2012-04-03 10:20:08', 1002, '2012-04-03 10:20:08', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1001, 1000, NULL, 214.00000, 214.00000),
(1007, 1001, '2012-04-03 10:20:08', 1002, '2012-04-03 10:20:08', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1002, 1003, NULL, 900.00000, 900.00000),
(1008, 1001, '2012-04-03 10:20:08', 1002, '2012-04-03 10:20:08', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1003, 1003, NULL, -15.00000, 0.00000),
(1009, 1001, '2012-04-03 10:20:08', 1002, '2012-04-03 10:20:08', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1004, 1001, NULL, 0.00000, 750.00000),
(1010, 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1000, 1000, NULL, 132.00000, 132.00000),
(1011, 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1001, 1000, NULL, 428.00000, 428.00000),
(1012, 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1002, 1003, NULL, 1800.00000, 1800.00000),
(1013, 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1003, 1003, NULL, -15.00000, 10.00000),
(1014, 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 10:31:31', 1002, '2012-04-03 00:00:00', 1001, 'Y', 1004, 1001, NULL, 750.00000, 750.00000),
(1015, 1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1005, 1003, NULL, -7.00000, 0.00000),
(1016, 1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1003, 1003, NULL, -2.00000, 0.00000),
(1017, 1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1006, 1003, NULL, 700.00000, 0.00000),
(1018, 1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1029, 1003, NULL, 0.00000, 0.00000),
(1019, 1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1004, 1001, NULL, 0.00000, 0.00000),
(1020, 1003, '2012-04-03 13:54:53', 1002, '2012-04-03 13:54:53', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1028, 1001, NULL, 0.00000, 0.00000),
(1021, 1004, '2012-04-03 14:23:03', 1002, '2012-04-03 14:23:03', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1005, 1003, NULL, -14.00000, -14.00000),
(1022, 1004, '2012-04-03 14:23:03', 1002, '2012-04-03 14:23:03', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1003, 1003, NULL, -4.00000, 0.00000),
(1023, 1004, '2012-04-03 14:23:03', 1002, '2012-04-03 14:23:03', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1006, 1003, NULL, 1400.00000, 0.00000),
(1024, 1004, '2012-04-03 14:23:03', 1002, '2012-04-03 14:23:03', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1029, 1003, NULL, 0.00000, 70.00000),
(1025, 1004, '2012-04-03 14:23:03', 1002, '2012-04-03 14:23:03', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1004, 1001, NULL, 0.00000, 71.00000),
(1026, 1004, '2012-04-03 14:23:03', 1002, '2012-04-03 14:23:03', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1028, 1001, NULL, 0.00000, 72.00000),
(1027, 1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:23:46', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1005, 1003, NULL, -14.00000, 0.00000),
(1028, 1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:23:46', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1003, 1003, NULL, 0.00000, 10.00000),
(1029, 1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:23:46', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1006, 1003, NULL, 0.00000, 0.00000),
(1030, 1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:23:46', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1029, 1003, NULL, 70.00000, 70.00000),
(1031, 1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:23:46', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1004, 1001, NULL, 71.00000, 71.00000),
(1032, 1005, '2012-04-03 14:23:46', 1002, '2012-04-03 14:23:46', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1028, 1001, NULL, 72.00000, 72.00000),
(1033, 1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1005, 1003, NULL, -14.00000, 0.00000),
(1034, 1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1003, 1003, NULL, 0.00000, 0.00000),
(1035, 1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1006, 1003, NULL, 0.00000, 0.00000),
(1036, 1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1029, 1003, NULL, 70.00000, 70.00000),
(1037, 1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1004, 1001, NULL, 71.00000, 71.00000),
(1038, 1006, '2012-04-03 14:36:29', 1002, '2012-04-03 14:36:29', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1028, 1001, NULL, 72.00000, 72.00000),
(1039, 1007, '2012-04-03 14:39:28', 1002, '2012-04-03 14:39:28', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1000, 1000, NULL, 0.00000, 14.00000),
(1040, 1007, '2012-04-03 14:39:28', 1002, '2012-04-03 14:39:28', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1029, 1003, NULL, 70.00000, 70.00000),
(1041, 1007, '2012-04-03 14:39:28', 1002, '2012-04-03 14:39:28', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1004, 1001, NULL, 71.00000, 71.00000),
(1042, 1007, '2012-04-03 14:39:28', 1002, '2012-04-03 14:39:28', 1002, '2012-04-03 00:00:00', 1000, 'Y', 1028, 1001, NULL, 72.00000, 72.00000);

-- --------------------------------------------------------

-- 
-- Table structure for table `t_transaction`
-- 

CREATE TABLE `t_transaction` (
  `T_TRANSACTION_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `DOCUMENTNO` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `TRXDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_BPARTNER_ID` int(10) NOT NULL default '0',
  `ISSALESTRX` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `SUBTRXAMOUNT` double(15,2) default NULL,
  `GRANDTRXAMOUNT` double(15,2) default NULL,
  `TRXTAXAMOUNT` double(15,2) default NULL,
  `ISPAID` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `PAYMENTRULE` char(1) collate utf8_unicode_ci NOT NULL default 'P',
  `DOCSTATUS` varchar(2) collate utf8_unicode_ci NOT NULL default 'DR',
  `PROCESSED` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`T_TRANSACTION_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_transaction`
-- 

INSERT INTO `t_transaction` (`T_TRANSACTION_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `DOCUMENTNO`, `ISACTIVE`, `DESCRIPTION`, `TRXDATE`, `M_BPARTNER_ID`, `ISSALESTRX`, `SUBTRXAMOUNT`, `GRANDTRXAMOUNT`, `TRXTAXAMOUNT`, `ISPAID`, `PAYMENTRULE`, `DOCSTATUS`, `PROCESSED`) VALUES (1000, '2011-06-29 13:20:26', 1002, '2011-06-29 13:20:26', 1002, '1', 'Y', NULL, '2011-06-29 00:00:00', 1001, 'N', 8556.00, 8556.00, 60.00, 'Y', 'P', 'CO', 'Y'),
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
(1013, '2011-07-30 16:44:54', 1002, '2011-07-30 16:44:54', 1002, '6', 'Y', NULL, '2011-07-30 00:00:00', 1001, 'N', 1904.00, 1904.00, 0.00, 'Y', 'P', 'CO', 'Y'),
(1014, '2012-03-15 16:45:20', 1002, '2012-03-15 17:29:20', 1002, '7', 'Y', NULL, '2012-03-15 00:00:00', 1000, 'Y', 4765.00, 4765.00, 555.00, 'Y', 'P', 'CO', 'Y'),
(1015, '2012-03-15 17:31:29', 1002, '2012-03-15 17:46:50', 1002, '8', 'Y', NULL, '2012-03-15 00:00:00', 1000, 'Y', 17474.25, 17474.25, 2279.25, 'Y', 'P', 'DR', 'N'),
(1016, '2012-03-17 12:13:12', 1002, '2012-03-17 12:13:12', 1002, '7', 'Y', NULL, '2012-03-17 00:00:00', 1001, 'N', 480.00, 480.00, 0.00, 'Y', 'P', 'DR', 'Y'),
(1017, '2012-03-17 12:15:46', 1002, '2012-03-19 10:56:42', 1002, '9', 'Y', NULL, '2012-03-17 00:00:00', 1000, 'Y', 1723.68, 1723.68, 0.00, 'Y', 'P', 'CO', 'Y'),
(1018, '2012-03-19 10:55:36', 1002, '2012-03-19 10:55:36', 1002, '8', 'Y', NULL, '2012-03-19 00:00:00', 1001, 'N', 0.00, 0.00, 0.00, 'Y', 'P', 'CO', 'Y');

-- --------------------------------------------------------

-- 
-- Table structure for table `t_trxdetail`
-- 

CREATE TABLE `t_trxdetail` (
  `T_TRXDETAIL_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `T_TRANSACTION_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `TRXDATE` datetime NOT NULL default '0000-00-00 00:00:00',
  `M_BPARTNER_ID` int(10) NOT NULL default '0',
  `ISSALESTRX` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `M_PRODUCT_ID` int(10) NOT NULL default '0',
  `M_UOM_ID` int(10) NOT NULL default '0',
  `M_WAREHOUSE_ID` int(10) NOT NULL default '0',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `TRXQUANTITY` double(15,5) NOT NULL default '0.00000',
  `UNITPRICE` double(15,2) default '0.00',
  `DISCOUNTRATE` double(15,5) default '0.00000',
  `DISCOUNTAMT` double(15,2) default '0.00',
  `MARGIN` double(15,5) default '0.00000',
  `UNITCOST` double(15,5) default '0.00000',
  `LINENETAMT` double(15,2) default '0.00',
  `LINETAXAMOUNT` double(15,2) default '0.00',
  PRIMARY KEY  (`T_TRXDETAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `t_trxdetail`
-- 

INSERT INTO `t_trxdetail` (`T_TRXDETAIL_ID`, `T_TRANSACTION_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `TRXDATE`, `M_BPARTNER_ID`, `ISSALESTRX`, `ISACTIVE`, `M_PRODUCT_ID`, `M_UOM_ID`, `M_WAREHOUSE_ID`, `DESCRIPTION`, `TRXQUANTITY`, `UNITPRICE`, `DISCOUNTRATE`, `DISCOUNTAMT`, `MARGIN`, `UNITCOST`, `LINENETAMT`, `LINETAXAMOUNT`) VALUES (1000, 1000, '2011-06-29 13:20:27', 1002, '2011-06-29 13:20:27', 1002, '2011-06-29 00:00:00', 1001, 'N', 'Y', 1000, 1000, 1001, NULL, 45.00000, 12.00, 0.00000, 0.00, 0.00000, 0.00000, 540.00, 60.00),
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
(1017, 1013, '2011-07-30 16:44:54', 1002, '2011-07-30 16:44:54', 1002, '2011-07-30 00:00:00', 1001, 'N', 'Y', 1001, 1002, 1001, NULL, 56.00000, 34.00, 0.00000, 0.00, 0.00000, 34.00000, 1904.00, 0.00),
(1018, 1014, '2012-03-15 16:45:21', 1002, '2012-03-15 17:29:20', 1002, '2012-03-15 00:00:00', 1000, 'Y', 'Y', 1004, 1003, 1001, NULL, 74.00000, 50.00, 0.00000, 0.00, 1.50000, 20.00000, 3700.00, 555.00),
(1019, 1015, '2012-03-15 17:31:29', 1002, '2012-03-15 17:46:50', 1002, '2012-03-15 00:00:00', 1000, 'Y', 'Y', 1005, 1004, 1000, NULL, 45.00000, 10.00, 0.00000, 0.00, 0.23324, 8.10870, 450.00, 67.50),
(1020, 1015, '2012-03-15 17:46:05', 1002, '2012-03-15 17:46:50', 1002, '2012-03-15 00:00:00', 1000, 'Y', 'Y', 1001, 1002, 1000, NULL, 15.00000, 55.00, 0.00000, 0.00, 0.61765, 34.00000, 825.00, 123.75),
(1021, 1015, '2012-03-15 17:46:50', 1002, '2012-03-15 17:46:50', 1002, '2012-03-15 00:00:00', 1000, 'Y', 'Y', 1005, 1004, 1000, NULL, 47.00000, 10.00, 0.00000, 0.00, 0.23324, 8.10870, 470.00, 70.50),
(1022, 1015, '2012-03-15 17:46:50', 1002, '2012-03-15 17:46:50', 1002, '2012-03-15 00:00:00', 1000, 'Y', 'Y', 1004, 1003, 1000, NULL, 47.00000, 50.00, 0.00000, 0.00, 1.50000, 20.00000, 2350.00, 352.50),
(1023, 1015, '2012-03-15 17:46:50', 1002, '2012-03-15 17:46:50', 1002, '2012-03-15 00:00:00', 1000, 'Y', 'Y', 1002, 1000, 1000, NULL, 74.00000, 150.00, 0.00000, 0.00, 0.15385, 130.00000, 11100.00, 1665.00),
(1024, 1016, '2012-03-17 12:13:12', 1002, '2012-03-17 12:13:12', 1002, '2012-03-17 00:00:00', 1001, 'N', 'Y', 1006, 1000, 1000, NULL, 480.00000, 1.00, 0.00000, 0.00, 0.00000, 0.00000, 480.00, 0.00),
(1025, 1017, '2012-03-17 12:15:46', 1002, '2012-03-19 10:56:42', 1002, '2012-03-17 00:00:00', 1000, 'Y', 'Y', 1006, 1000, 1000, NULL, 38.00000, 45.36, 0.00000, 0.00, 0.00000, 0.00000, 1723.68, 0.00),
(1026, 1018, '2012-03-19 10:55:36', 1002, '2012-03-19 10:55:36', 1002, '2012-03-19 00:00:00', 1001, 'N', 'Y', 1006, 1000, 1000, NULL, 750.00000, 0.00, 0.00000, 0.00, 0.00000, 0.00000, 0.00, 0.00);

-- --------------------------------------------------------

-- 
-- Table structure for table `u_activeshopid`
-- 

CREATE TABLE `u_activeshopid` (
  `M_SHOP_ID` int(10) NOT NULL default '0',
  PRIMARY KEY  (`M_SHOP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `u_activeshopid`
-- 

INSERT INTO `u_activeshopid` (`M_SHOP_ID`) VALUES (1000);

-- --------------------------------------------------------

-- 
-- Table structure for table `u_formaccess`
-- 

CREATE TABLE `u_formaccess` (
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `U_USER_ID` int(10) NOT NULL default '0',
  `FORMNAME` varchar(30) collate utf8_unicode_ci NOT NULL default '',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ACCESSLEVEL` varchar(20) collate utf8_unicode_ci NOT NULL default 'NA',
  PRIMARY KEY  (`M_SHOP_ID`,`U_USER_ID`,`FORMNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `u_formaccess`
-- 

INSERT INTO `u_formaccess` (`M_SHOP_ID`, `U_USER_ID`, `FORMNAME`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `ACCESSLEVEL`) VALUES (1000, 1003, 'ndSales', '2011-07-30 16:54:12', 1002, '2011-07-30 16:54:12', 1002, 'Y', NULL, 'InActive');

-- --------------------------------------------------------

-- 
-- Table structure for table `u_sequence`
-- 

CREATE TABLE `u_sequence` (
  `U_SEQUENCE_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `NAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `ISTABLEID` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `BASEDOC` varchar(10) collate utf8_unicode_ci NOT NULL default '',
  `CURRENTNEXT` int(10) default NULL,
  PRIMARY KEY  (`U_SEQUENCE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `u_sequence`
-- 

INSERT INTO `u_sequence` (`U_SEQUENCE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `NAME`, `ISACTIVE`, `ISTABLEID`, `BASEDOC`, `CURRENTNEXT`) 
VALUES 
(1000, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'U_SEQUENCE', 'Y', 'Y', '', 1027),
(1001, '2011-06-19 16:31:29', 0, '2012-03-17 12:06:08', 1002, 'C_CITY', 'Y', 'Y', '', 1001),
(1002, '2011-06-19 16:31:29', 0, '2012-03-17 12:06:29', 1002, 'M_LOCALITY', 'Y', 'Y', '', 1001),
(1003, '2011-06-19 16:31:29', 0, '2012-03-17 12:06:34', 1002, 'M_SUBLOCALITY', 'Y', 'Y', '', 1001),
(1004, '2011-06-19 16:31:29', 0, '2012-03-17 12:03:38', 1002, 'M_UOM', 'Y', 'Y', '', 1006),
(1005, '2011-06-19 16:31:29', 0, '2012-03-23 12:50:46', 1002, 'M_PRODUCTCATEGORY', 'Y', 'Y', '', 1009),
(1006, '2011-06-19 16:31:29', 0, '2012-03-17 12:02:01', 1002, 'M_PRODUCT', 'Y', 'Y', '', 1007),
(1007, '2011-06-19 16:31:29', 0, '2011-07-30 16:47:19', 1002, 'M_BPARTNER', 'Y', 'Y', '', 1004),
(1008, '2011-06-19 16:31:29', 0, '2011-06-29 13:07:54', 1000, 'M_SHOP', 'Y', 'Y', '', 1001),
(1009, '2011-06-19 16:31:29', 0, '2011-07-30 16:50:44', 1002, 'U_USER', 'Y', 'Y', '', 1004),
(1010, '2011-06-19 16:31:29', 0, '2012-03-19 10:55:36', 1002, 'T_TRANSACTION', 'Y', 'Y', '', 1019),
(1011, '2011-06-19 16:31:29', 0, '2012-03-19 10:55:36', 1002, 'T_TRXDETAIL', 'Y', 'Y', '', 1027),
(1012, '2011-06-19 16:31:29', 0, '2011-07-02 12:21:10', 1002, 'M_UOM_CONVERSION', 'Y', 'Y', '', 1004),
(1013, '2011-06-19 16:31:29', 0, '2012-03-19 10:55:36', 1002, 'PURCHASE', 'Y', 'N', 'PURCHASE', 9),
(1014, '2011-06-19 16:31:29', 0, '2012-03-17 12:15:46', 1002, 'SALES', 'Y', 'N', 'SALES', 10),
(1015, '2011-06-19 16:31:29', 0, '2011-07-30 16:45:46', 1002, 'M_WAREHOUSE', 'Y', 'Y', '', 1003),
(1016, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_MOVEMENT', 'Y', 'Y', '', 1000),
(1017, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'T_MOVEMENTDETAIL', 'Y', 'Y', '', 1000),
(1018, '2011-06-19 16:31:29', 0, '2011-06-19 16:31:29', 0, 'MOVE', 'Y', 'N', 'MOVE', 1),
(1019, '2011-06-19 16:31:29', 0, '2012-04-01 15:44:00', 1002, 'USE', 'Y', 'N', 'USE', 2),
(1020, '2011-06-19 16:31:29', 0, '2012-04-03 14:39:28', 1002, 'COUNT', 'Y', 'N', 'COUNT', 9),
(1021, '2011-06-19 16:31:29', 0, '2012-04-03 14:39:28', 1002, 'T_PHYSICALCOUNT', 'Y', 'Y', '', 1008),
(1022, '2011-06-19 16:31:29', 0, '2012-04-03 14:39:28', 1002, 'T_PHYSICALCOUNTDETAIL', 'Y', 'Y', '', 1043),
(1023, '2011-06-19 16:31:29', 0, '2012-04-01 15:44:00', 1002, 'T_INVENTORYUSE', 'Y', 'Y', '', 1001),
(1024, '2011-06-19 16:31:29', 0, '2012-04-01 15:44:00', 1002, 'T_INVENTORYUSEDETAIL', 'Y', 'Y', '', 1004);
(1025, '2011-06-19 16:31:29', 0, '2012-04-01 15:44:00', 1002, 'M_TRANSACTION', 'Y', 'Y', '', 1000),
(1026, '2011-06-19 16:31:29', 0, '2012-03-17 12:06:08', 1002, 'C_COUNTRY', 'Y', 'Y', '', 1001);

-- --------------------------------------------------------

-- 
-- Table structure for table `u_shopaccess`
-- 

CREATE TABLE `u_shopaccess` (
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `U_USER_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `ACCESSLEVEL` varchar(20) collate utf8_unicode_ci NOT NULL default 'NA',
  PRIMARY KEY  (`M_SHOP_ID`,`U_USER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `u_shopaccess`
-- 

INSERT INTO `u_shopaccess` (`M_SHOP_ID`, `U_USER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `ACCESSLEVEL`) VALUES (1000, 1003, '2011-07-30 17:01:00', 1002, '2011-07-30 17:01:00', 1002, 'Y', NULL, 'ReadWite'),
(1000, 1002, '2011-06-29 13:12:35', 1000, '2011-06-29 13:12:35', 1000, 'Y', NULL, 'ReadWite');

-- --------------------------------------------------------

-- 
-- Table structure for table `u_user`
-- 

CREATE TABLE `u_user` (
  `U_USER_ID` int(10) NOT NULL default '0',
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `FIRSTNAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `MIDDLENAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `LASTNAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `USERNAME` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `PASSWORD` varchar(60) collate utf8_unicode_ci NOT NULL default '',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`U_USER_ID`),
  UNIQUE KEY `USERNAME` (`USERNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `u_user`
-- 

INSERT INTO `u_user` (`U_USER_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `FIRSTNAME`, `MIDDLENAME`, `LASTNAME`, `USERNAME`, `PASSWORD`, `ISACTIVE`, `DESCRIPTION`) VALUES (1003, '2011-07-30 16:50:44', 1002, '2011-07-30 16:51:59', 1002, 'Aziza', 'Muzeyin', '', 'azz', '123', 'Y', NULL),
(1002, '2011-06-29 13:08:51', 1000, '2011-06-29 13:08:51', 1000, 'Administrator', '', '', 'ad', '12', 'Y', NULL);

-- --------------------------------------------------------

-- 
-- Table structure for table `u_warehouseaccess`
-- 

CREATE TABLE `u_warehouseaccess` (
  `M_SHOP_ID` int(10) NOT NULL default '0',
  `U_USER_ID` int(10) NOT NULL default '0',
  `M_WAREHOUSE_ID` int(10) NOT NULL default '0',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL default '0',
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL default '0',
  `ISACTIVE` char(1) collate utf8_unicode_ci NOT NULL default 'Y',
  `DESCRIPTION` varchar(255) collate utf8_unicode_ci default NULL,
  `CANSALEFROM` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `CANBUYFOR` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `CANMOVEFORM` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `CANMOVETO` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `CANUSEFROM` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  `CANCOUNT` char(1) collate utf8_unicode_ci NOT NULL default 'N',
  PRIMARY KEY  (`M_SHOP_ID`,`U_USER_ID`,`M_WAREHOUSE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Dumping data for table `u_warehouseaccess`
-- 

INSERT INTO `u_warehouseaccess` (`M_SHOP_ID`, `U_USER_ID`, `M_WAREHOUSE_ID`, `CREATED`, `CREATEDBY`, `UPDATED`, `UPDATEDBY`, `ISACTIVE`, `DESCRIPTION`, `CANSALEFROM`, `CANBUYFOR`, `CANMOVEFORM`, `CANMOVETO`, `CANUSEFROM`, `CANCOUNT`) VALUES (1000, 1002, 1000, '2011-06-29 13:13:20', 1000, '2011-06-29 13:13:20', 1000, 'Y', NULL, 'Y', 'Y', 'Y', 'Y', 'Y', 'Y'),
(1000, 1002, 1001, '2011-06-29 13:13:28', 1000, '2011-06-29 13:13:28', 1000, 'Y', NULL, 'Y', 'Y', 'Y', 'Y', 'Y', 'Y');

CREATE TABLE `M_TRANSACTION` (
  `M_TRANSACTION_ID`  int(10) NOT NULL,
  `AD_CLIENT_ID`  int(10) NOT NULL default '0',
  `AD_ORG_ID` int(10) NOT NULL,
  `ISACTIVE` char(1) NOT NULL default 'Y',
  `CREATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `CREATEDBY` int(10) NOT NULL,
  `UPDATED` datetime NOT NULL default '0000-00-00 00:00:00',
  `UPDATEDBY` int(10) NOT NULL,
  `MOVEMENTTYPE` enum('BL','V+', 'V-', 'M+', 'M-', 'I+', 'I-',' C+' ,'C-') NOT NULL,
  `M_LOCATOR_ID` int(10) NOT NULL,
  `M_PRODUCT_ID` int(10) NOT NULL,  
  `MOVEMENTDATE` datetime NOT NULL default '0000-00-00 00:00:00', 
  `MOVEMENTQTY` DOUBLE(15,9) NOT NULL DEFAULT '0',
  `C_UOM_ID` int(10) NOT NULL,
  `M_INVENTORYLINE_ID` int(10),
  `M_MOVEMENTLINE_ID` int(10),
  `M_INOUTLINE_ID` int(10),
  `M_PRODUCTIONLINE_ID` int(10),
  `C_PROJECTISSUE_ID` int(10),
  `M_ATTRIBUTESETINSTANCE_ID` int(10) NOT NULL default '0',
  `PP_COST_COLLECTOR_ID` int(10),
  PRIMARY KEY  (`M_TRANSACTION_ID`)  
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
