@mysql -hlocalhost -uroot -p marakipos2011
CREATE TABLE PER_SKIP_KPI_CHECK
(
	STATION_ID INT(10),
	DATESKIPPED DATE,
	CONSTRAINT PRIMARY KEY (STATION_ID)
);

INSERT INTO `per_skip_kpi_check` ( `STATION_ID` , `DATESKIPPED` )
VALUES ((SELECT MAX(STATION_ID) AS STATION_ID FROM AD_SEQUENCE), '2016-08-07');