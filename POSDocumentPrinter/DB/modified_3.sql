@mysql -hlocalhost -uroot -p marakipos2011
DROP FUNCTION  IF EXISTS `PER_OPENRECORDCOUNT`;
DELIMITER $$
CREATE FUNCTION  PER_OPENRECORDCOUNT (STN_ID int(10)) RETURNS INT
DETERMINISTIC
BEGIN
	UPDATE PER_OPENRECORD
	SET ACTUALVALUE = 
	(
		SELECT COUNT(_RECORD)
		FROM 
		(
			SELECT s.ID AS _RECORD, ABS(COALESCE(SUM(sl.AMOUNT),0) - s.TOTAL_AMOUNT) as OPENAMT
			FROM SALES s LEFT JOIN C_CASHLINESOURCE sl
			ON s.ID = sl.C_INVOICE_ID AND s.STATION = sl.STATION_ID AND sl.SOURCETYPE = 'Sales'
			WHERE s.SOLD_DATE BETWEEN '2016-02-01' AND DATE_SUB(NOW(), INTERVAL 2 DAY) AND s.STATION = STN_ID
			GROUP BY s.ID
			HAVING OPENAMT != 0.5
		) RCD
	)
	WHERE CRITERIA_CODE = 10;
	
	UPDATE PER_OPENRECORD
	SET ACTUALVALUE = 
	(
		SELECT COUNT(_RECORD)
		FROM 
		(
			SELECT c.C_PAYMENT_ID AS _RECORD, ABS(COALESCE(SUM(sl.AMOUNT),0) - c.PAYAMT) as OPENAMT
			FROM C_PAYMENT c LEFT JOIN C_CASHLINESOURCE sl
			ON c.C_PAYMENT_ID = sl.C_PAYMENT_ID AND c.STATION_ID = sl.STATION_ID AND sl.SOURCETYPE = 'CRV'
			WHERE c.DATETRX BETWEEN '2016-02-01' AND DATE_SUB(NOW(), INTERVAL 2 DAY) AND c.STATION_ID = STN_ID
			GROUP BY c.C_PAYMENT_ID
			HAVING OPENAMT != 0.5
		) RCD
	)
	WHERE CRITERIA_CODE = 20;
	
	
	UPDATE PER_OPENRECORD
	SET ACTUALVALUE = 
	(
		SELECT COUNT(_RECORD)
		FROM 
		(
			SELECT e.C_EXEMPTION_ID AS _RECORD, ABS(COALESCE(SUM(ABS(sl.AMOUNT)),0) + COALESCE(SUM(ABS(cl.AMOUNT)),0) - e.EXEMPTEDAMT) as OPENAMT
			FROM C_PAYMENTALLOCATE cl RIGHT JOIN C_EXEMPTION e 
			ON cl.C_INVOICE_ID = e.C_EXEMPTION_ID AND e.STATION_ID = cl.STATION_ID AND ISEXEMPTION = 'Y'
			LEFT JOIN C_CASHLINESOURCE sl
			ON e.C_EXEMPTION_ID = sl.C_EXEMPTION_ID AND e.STATION_ID = sl.STATION_ID AND sl.SOURCETYPE = 'Exemption'
			WHERE e.DATEINVOICED BETWEEN '2016-02-01' AND DATE_SUB(NOW(), INTERVAL 2 DAY) AND e.STATION_ID = STN_ID
			GROUP BY e.C_EXEMPTION_ID
			HAVING OPENAMT != 0.5
		) RCD
	)
	WHERE CRITERIA_CODE = 30;
	
	UPDATE PER_OPENRECORD
	SET ACTUALVALUE = (SELECT DATEDIFF(NOW(),(SELECT REPORTEDDATE FROM PER_AUDITREPORT WHERE STATION_ID = STN_ID)))
	WHERE CRITERIA_CODE = 40;
	
	UPDATE PER_OPENRECORD
	SET ACTUALVALUE = (SELECT RECORDCOUNT FROM EASYMOVE.openmovement)
	WHERE CRITERIA_CODE = 50;
	
	RETURN 1;
	
END $$


CREATE TABLE PER_OPENRECORD
(
	CRITERIA_CODE INT(10),
	CRITERIA_DESCRIPTION VARCHAR(255),
	CRITERIA ENUM( '-', '0', '+' ) NOT NULL DEFAULT '0' COMMENT '[-] Actual value should be less or equal to target, [0] Actual value should be exactly the same as target, [+] Actual value should be greater or equal to target',
	TARGETVALUE INT(10),
	ACTUALVALUE INT(10),
	CONSTRAINT PRIMARY KEY (CRITERIA_CODE)
);

INSERT INTO PER_OPENRECORD VALUES
(10, 'UnDeposited Sale','0', 0,-1),
(20, 'UnDeposited CRV','0', 0,-1),
(30, 'UnUtilized Exemption','0', 0,-1),
(40, 'UnDeposited Sale','-', 2,-1),
(50, 'Open Transfer','0', 0,-1);


CREATE TABLE PER_AUDITREPORT
(
	STATION_ID INT(10),
	REPORTEDDATE DATE,
	CONSTRAINT PRIMARY KEY (STATION_ID)
);

INSERT INTO PER_AUDITREPORT VALUES
(10,'2016-01-31'),
(2,'2016-01-31'),
(3,'2016-01-31'),
(4,'2016-01-31'),
(6,'2016-01-31'),
(8,'2016-01-31'),
(9,'2016-01-31'),
(11,'2016-01-31'),
(12,'2016-01-31'),
(13,'2016-01-31'),
(14,'2016-01-31'),
(15,'2016-01-31');



