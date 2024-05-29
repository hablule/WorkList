CREATE TABLE AD_SEQUENCE(
AD_SEQUENCE_ID LONG PRIMARY KEY,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
NAME VARCHAR (60),
DESCRIPTION VARCHAR (255),
INCREMENTNO SHORT NOT NULL,
STARTNO LONG NOT NULL,
CURRENTNEXT LONG NOT NULL,
ISTABLEID CHAR (1),
PREFIX VARCHAR (10),
SUFFIX VARCHAR (10)
);

INSERT INTO AD_SEQUENCE(AD_SEQUENCE_ID, CREATED, CREATEDBY, UPDATED, UPDATEDBY, ISACTIVE, NAME, INCREMENTNO, STARTNO, CURRENTNEXT, ISTABLEID)
VALUES
(100, '17-JAN-2014', 1000, '17-JAN-2014', 1000, 'Y', 'AD_SEQUENCE', 1, 100, 100, 'Y');
INSERT INTO AD_SEQUENCE(AD_SEQUENCE_ID, CREATED, CREATEDBY, UPDATED, UPDATEDBY, ISACTIVE, NAME, INCREMENTNO, STARTNO, CURRENTNEXT, ISTABLEID)
VALUES
(101, '17-JAN-2014', 1000, '17-JAN-2014', 1000, 'Y', 'GS_GAURD', 1, 100, 100, 'Y');
INSERT INTO AD_SEQUENCE(AD_SEQUENCE_ID, CREATED, CREATEDBY, UPDATED, UPDATEDBY, ISACTIVE, NAME, INCREMENTNO, STARTNO, CURRENTNEXT, ISTABLEID)
VALUES
(102, '17-JAN-2014', 1000, '17-JAN-2014', 1000, 'Y', 'GS_POST', 1, 100, 100, 'Y');
INSERT INTO AD_SEQUENCE(AD_SEQUENCE_ID, CREATED, CREATEDBY, UPDATED, UPDATEDBY, ISACTIVE, NAME, INCREMENTNO, STARTNO, CURRENTNEXT, ISTABLEID)
VALUES
(103, '17-JAN-2014', 1000, '17-JAN-2014', 1000, 'Y', 'GS_SHIFT', 1, 100, 100, 'Y');
INSERT INTO AD_SEQUENCE(AD_SEQUENCE_ID, CREATED, CREATEDBY, UPDATED, UPDATEDBY, ISACTIVE, NAME, INCREMENTNO, STARTNO, CURRENTNEXT, ISTABLEID)
VALUES
(104, '17-JAN-2014', 1000, '17-JAN-2014', 1000, 'Y', 'GS_EXCLUSION', 1, 100, 100, 'Y');
INSERT INTO AD_SEQUENCE(AD_SEQUENCE_ID, CREATED, CREATEDBY, UPDATED, UPDATEDBY, ISACTIVE, NAME, INCREMENTNO, STARTNO, CURRENTNEXT, ISTABLEID)
VALUES
(105, '17-JAN-2014', 1000, '17-JAN-2014', 1000, 'Y', 'GS_DUTY', 1, 100, 100, 'Y');

CREATE TABLE GS_GAURD (
GS_GAURD_ID LONG PRIMARY KEY,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CODE VARCHAR (30) UNIQUE NOT NULL,
FIRSTNAME VARCHAR (60) NOT NULL,
MIDDELNAME VARCHAR (60) NOT NULL,
LASTNAME VARCHAR (60),
DESCRIPTION VARCHAR (255)
);

CREATE TABLE GS_POST (
GS_POST_ID LONG PRIMARY KEY,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CODE VARCHAR (30) UNIQUE NOT NULL,
NAME VARCHAR (60),
DESCRIPTION VARCHAR (255)
);

CREATE TABLE GS_SHIFT (
GS_SHIFT_ID LONG PRIMARY KEY,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CODE VARCHAR(30) UNIQUE NOT NULL,
NAME VARCHAR(60),
STARTTIME TIME,
ENDTIME TIME,
DESCRIPTION VARCHAR (255)
);



CREATE TABLE GS_EXCLUSION (
GS_EXCLUSION_ID LONG PRIMARY KEY,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CODE VARCHAR(30) UNIQUE NOT NULL,
NAME VARCHAR(60),
DESCRIPTION VARCHAR (255),
EXCLUSION_DATE_BEGIN DATE ,
EXCULSION_DATE_END DATE,
ISDAY_DATE_COMBINATION CHAR(1) NOT NULL,
ISDAY_EXCLUSION CHAR(1) NOT NULL,
ISDATE_EXCLUSION CHAR(1) NOT NULL,
ISRANGE_EXCLUSION CHAR(1) NOT NULL,
ISGAURD_EXCLUSION CHAR(1) NOT NULL,
ISSHIFT_EXCLUSION CHAR(1) NOT NULL,
ISPOST_EXCLUSION CHAR(1) NOT NULL
);


CREATE TABLE GS_DAY_EXCLUSION (
GS_EXCLUSION_ID LONG,
DAY_EXCLUDED CHAR(3),
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CONSTRAINT GS_DAY_EXCLUSION_PK PRIMARY KEY (GS_EXCLUSION_ID, DAY_EXCLUDED),
CONSTRAINT GS_DAY_EXCLUSION_FK FOREIGN KEY (GS_EXCLUSION_ID)
 REFERENCES GS_EXCLUSION (GS_EXCLUSION_ID) ON UPDATE CASCADE, ON DELETE CASCADE
);

CREATE TABLE GS_GAURD_EXCLUSION (
GS_EXCLUSION_ID LONG,
GS_GAURD_ID LONG,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CONSTRAINT GS_GAURD_EXCLUSION_PK PRIMARY KEY (GS_EXCLUSION_ID, GS_GAURD_ID),
CONSTRAINT GS_GAURD_EXCLUSION_FK1 FOREIGN KEY (GS_EXCLUSION_ID)
 REFERENCES GS_EXCLUSION (GS_EXCLUSION_ID) ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT GS_GAURD_EXCLUSION_FK2 FOREIGN KEY (GS_GAURD_ID)
 REFERENCES GS_GAURD (GS_GAURD_ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE GS_SHIFT_EXCLUSION (
GS_EXCLUSION_ID LONG,
GS_SHIFT_ID LONG,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CONSTRAINT GS_SHIFT_EXCLUSION_PK PRIMARY KEY (GS_EXCLUSION_ID, GS_SHIFT_ID),
CONSTRAINT GS_SHIFT_EXCLUSION_FK1 FOREIGN KEY (GS_EXCLUSION_ID)
 REFERENCES GS_EXCLUSION (GS_EXCLUSION_ID) ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT GS_SHIFT_EXCLUSION_FK2 FOREIGN KEY (GS_SHIFT_ID)
 REFERENCES GS_SHIFT (GS_SHIFT_ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE GS_POST_EXCLUSION (
GS_EXCLUSION_ID LONG,
GS_POST_ID LONG,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
CONSTRAINT GS_POST_EXCLUSION_PK PRIMARY KEY (GS_EXCLUSION_ID, GS_POST_ID),
CONSTRAINT GS_POST_EXCLUSION_FK1 FOREIGN KEY (GS_EXCLUSION_ID)
 REFERENCES GS_EXCLUSION (GS_EXCLUSION_ID) ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT GS_POST_EXCLUSION_FK2 FOREIGN KEY (GS_POST_ID)
 REFERENCES GS_POST (GS_POST_ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE GS_DUTY (
GS_DUTY_ID LONG PRIMARY KEY,
CREATED DATE NOT NULL,
CREATEDBY LONG NOT NULL,
UPDATED DATE NOT NULL,
UPDATEDBY  LONG NOT NULL,
ISACTIVE CHAR(1) NOT NULL,
DUTYDATE DATE NOT NULL,
ISONDUTY CHAR(1) NOT NULL,
GS_POST_ID LONG,
GS_SHIFT_ID LONG,
GS_GAURD_ID LONG,
GS_EXCLUSION_ID LONG,
CONSTRAINT GS_DUTY_FK1 FOREIGN KEY (GS_POST_ID)
 REFERENCES GS_POST (GS_POST_ID) ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT GS_DUTY_FK2 FOREIGN KEY (GS_SHIFT_ID)
 REFERENCES GS_SHIFT (GS_SHIFT_ID) ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT GS_DUTY_FK3 FOREIGN KEY (GS_GAURD_ID)
 REFERENCES GS_GAURD (GS_GAURD_ID) ON UPDATE CASCADE ON DELETE CASCADE
CONSTRAINT  GS_DUTY_FK4 FOREIGN KEY (GS_EXCLUSION_ID)
 REFERENCES GS_EXCLUSION (GS_EXCLUSION_ID) ON UPDATE CASCADE ON DELETE CASCADE
)
