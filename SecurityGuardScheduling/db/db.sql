CREATE TABLE GS_GAURD (
GS_GAURD_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR(1),
CODE CHAR (30),
FIRSTNAME VARCHAR (60),
MIDDELNAME VARCHAR (60),
LASTNAME VARCHAR (60),
DESCRIPTION VARCHAR(500)
);

CREATE TABLE GS_POST (
GS_POST_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1),
CODE CHAR (30),
NAME VARCHAR (60),
DESCRIPTION VARCHAR(500)
);

CREATE TABLE GS_SHIFT (
GS_SHIFT_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1),
CODE CHAR(30),
NAME VARCHAR(60),
STARTTIME TIME,
ENDTIME TIME,
DESCRIPTION VARCHAR(500)
);

CREATE TABLE GS_EXCLUSION (
GS_EXCLUSION_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1),
CODE CHAR(30),
NAME VARCHAR(60),
RANGE_EXCLUSION CHAR(1),
BEGINGING_EXCLUSION_DATE DATE,
END_EXCULSION_DATE DATE,
ISDAY_EXCLUSION CHAR(1),
ISDATE_EXCLUSION CHAR(1),
ISGAURD_EXCLUSION CHAR(1),
ISSHIFT_EXCLUSION CHAR(1),
ISPOST_EXCLUSION CHAR(1),
);

CREATE TABLE GS_DAY_EXCLUSION (
GS_EXCLUSION_ID NUMBER (10),
DAY_EXCLUDED ENUM('MON','TUE','WEN','THUR','FRI','SAT','SUN'),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1)
);

CREATE TABLE GS_GAURD_EXCLUSION (
GS_EXCLUSION_ID NUMBER (10),
GS_GAURD_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1)
);

CREATE TABLE GS_SHIFT_EXCLUSION (
GS_EXCLUSION_ID NUMBER (10),
GS_SHIFT_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1)
);

CREATE TABLE GS_POST_EXCLUSION (
GS_EXCLUSION_ID NUMBER (10),
GS_POST_ID NUMBER (10),
CREATED DATE,
CREATEDBY NUMBER (10),
UPDATED DATE,
UPDATEDBY  NUMBER (10),
ISACTIVE CHAR (1)
);
