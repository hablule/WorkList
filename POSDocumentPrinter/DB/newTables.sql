

-- 
-- Table structure for table `default_price_lst`
-- 

CREATE TABLE `default_price_lst` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `STATION` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table `default_price_lst`
-- 

INSERT INTO `default_price_lst` VALUES (1, 7);


CREATE TABLE `active_store_lst` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `STATION` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table `active_store_lst`
-- 

INSERT INTO `active_store_lst` VALUES (42, 7);
