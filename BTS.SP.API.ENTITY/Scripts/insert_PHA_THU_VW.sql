﻿--------------------------------------------------------
--  DDL for Table PHA_HACHTOAN_THU
--------------------------------------------------------

  CREATE TABLE "BTSTC"."PHA_HACHTOAN_THU_TEST" 
   (
     "ID" NUMBER(10,0), 
	"LOAI_NGHIEPVU"  NVARCHAR2(50), 
	"SEGMENT1" NVARCHAR2(50), 
	"MA_TKTN" NVARCHAR2(50), "TEN_TKTN" NVARCHAR2(500), 
	"MA_NHOM" NVARCHAR2(50), "TEN_NHOM" NVARCHAR2(500), 
	"MA_TIEUNHOM" NVARCHAR2(50),"TEN_TIEUNHOM" NVARCHAR2(500), 
	"MA_MUC" NVARCHAR2(50), "TEN_MUC" NVARCHAR2(500), 
	"MA_TIEUMUC" NVARCHAR2(50), "TEN_TIEUMUC" NVARCHAR2(500), 
    "MA_CAP" NVARCHAR2(50), "TEN_CAP" NVARCHAR2(500), 
	"MA_DVQHNS" NVARCHAR2(50),"TEN_DVQHNS" NVARCHAR2(500), 
	"MA_DIABAN" NVARCHAR2(50), "TEN_DIABAN" NVARCHAR2(500), 
	"MA_CAPMLNS" NVARCHAR2(50), "TEN_CAPMLNS" NVARCHAR2(500),
	"MA_CHUONG" NVARCHAR2(50), "TEN_CHUONG" NVARCHAR2(500),
	"MA_NGANHKT" NVARCHAR2(50), "TEN_NGANHKT" NVARCHAR2(500),
	"MA_LOAI" NVARCHAR2(50), "TEN_LOAI" NVARCHAR2(500),
	"MA_CTMTQG" NVARCHAR2(50), 
	"TEN_CTMTQG" NVARCHAR2(500),
	"MA_KBNN" NVARCHAR2(50), "TEN_KBNN" NVARCHAR2(500),
	"MA_NGUON_NSNN" NVARCHAR2(50), "TEN_NGUON_NSNN" NVARCHAR2(500),
	"SEGMENT12" NVARCHAR2(50), 
	"SET_OF_BOOKS_ID" NUMBER(15,0), 
	"SOB_NAME" NVARCHAR2(30), 
	"PERIOD_NAME" NVARCHAR2(15), 
	"NGAY_KET_SO" DATE, 
	"NGAY_HIEU_LUC" DATE, 
	"ENTERED_DR" NUMBER(15,0), 
	"ENTERED_CR" NUMBER(15,0), 
	"GIA_TRI_HACH_TOAN" NUMBER(15,0),
	"ACTUAL_FLAG" NVARCHAR2(1), 
	"CURRENCY_CODE" NVARCHAR2(15), 
	"TRANSFORM_DATE" DATE, 
	"VOUCHER_DATE" DATE, 
	"ATTRIBUTE8" NVARCHAR2(150), 
	"MA_NGHIEPVU" NVARCHAR2(50)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 505 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "BTSTC" ;
--------------------------------------------------------
--  DDL for Index PK_PHA_HACHTOAN_THU
--------------------------------------------------------

  CREATE UNIQUE INDEX "BTSTC"."PK_PHA_HACHTOAN_THU" ON "BTSTC"."PHA_HACHTOAN_THU" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 505 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "BTSTC" ;
--------------------------------------------------------
--  DDL for Trigger TR_PHA_HACHTOAN_THU
--------------------------------------------------------



	insert into pha_hachtoan_thu_TEST
	(
	LOAI_NGHIEPVU, 
	SEGMENT1,
	MA_TKTN,TEN_TKTN,
	MA_NHOM,TEN_NHOM,
	MA_TIEUNHOM,
	TEN_TIEUNHOM,
	MA_MUC,TEN_MUC,
	MA_TIEUMUC,TEN_TIEUMUC,
	MA_CAP,TEN_CAP,
	MA_DVQHNS,TEN_DVQHNS,
	MA_DIABAN,TEN_DIABAN,
	MA_CAPMLNS,TEN_CAPMLNS,
	MA_CHUONG,TEN_CHUONG,
	MA_NGANHKT,TEN_NGANHKT,
	MA_LOAI,TEN_LOAI,
	MA_CTMTQG,TEN_CTMTQG,
	MA_KBNN,
	TEN_KBNN,
	MA_NGUON_NSNN,
	TEN_NGUON_NSNN,
	SEGMENT12,
	NGAY_KET_SO,
	NGAY_HIEU_LUC,
	TRANSFORM_DATE,
	VOUCHER_DATE,
	ATTRIBUTE8,
	GIA_TRI_HACH_TOAN,
	ENTERED_CR,
	ENTERED_DR,
	SET_OF_BOOKS_ID
	)

	SELECT 
	STC_PA_SYS.FNC_GET_LOAI_NS(SEGMENT3) AS LOAI_NGHIEPVU, 
	SEGMENT1,
	SEGMENT2 AS MA_TKTN, STC_PA_SYS.FNC_GET_TEN_DM('DM_TKTN','TEN_TKTN','MA_TKTN',SEGMENT2,EFFECTIVE_DATE) AS TEN_TKTN,
	STC_PA_SYS.FNC_GET_CONVERT_NDKT2NHOM(SEGMENT3) AS MA_NHOM, STC_PA_SYS.FNC_GET_DICTIONARY('MA_NHOM',STC_PA_SYS.FNC_GET_CONVERT_NDKT2NHOM(SEGMENT3),EFFECTIVE_DATE) AS TEN_NHOM, 
	STC_PA_SYS.FNC_GET_CONVERT_NDKT2TNHOM(SEGMENT3) AS MA_TIEUNHOM, STC_PA_SYS.FNC_GET_TEN_DM('PHA_DM_TIEUNHOM','TEN_TIEUNHOM','MA_TIEUNHOM',STC_PA_SYS.FNC_GET_CONVERT_NDKT2TNHOM(SEGMENT3),EFFECTIVE_DATE) AS TEN_TIEU_NHOM, 
	STC_PA_SYS.FNC_GET_CONVERT_NDKT2MUC(SEGMENT3) AS MA_MUC ,STC_PA_SYS.FNC_GET_TEN_DM('DM_MUC','TEN_MUC','MA_MUC',STC_PA_SYS.FNC_GET_CONVERT_NDKT2MUC(SEGMENT3),EFFECTIVE_DATE) AS TEN_MUC,
	SEGMENT3 AS MA_TIEUMUC,STC_PA_SYS.FNC_GET_TEN_DM('DM_TIEUMUC','TEN_TIEUMUC','MA_TIEUMUC',SEGMENT3,EFFECTIVE_DATE) AS TEN_TIEUMUC,
	SEGMENT4 AS MA_CAP, STC_PA_SYS.FNC_GET_DICTIONARY('MA_CAP',SEGMENT4,EFFECTIVE_DATE) AS TEN_CAP,
	SEGMENT5 AS MA_DVQHNS,'-' AS TEN_DVQHNS,
	SEGMENT6 AS MA_DIABAN,'-' AS TEN_DIABAN,
	STC_PA_SYS.FNC_GET_CONVERT_CHUONG2CAP(SEGMENT7) AS MA_CAPMLNS,STC_PA_SYS.FNC_GET_DICTIONARY('MA_CAP',STC_PA_SYS.FNC_GET_CONVERT_CHUONG2CAP(SEGMENT7),EFFECTIVE_DATE) AS TEN_CAPMLNS,
	SEGMENT7 AS MA_CHUONG, STC_PA_SYS.FNC_GET_TEN_DM('DM_CHUONG','TEN_CHUONG','MA_CHUONG',SEGMENT7,EFFECTIVE_DATE) AS TEN_CHUONG,

	SEGMENT8 AS MA_NGANHKT,STC_PA_SYS.FNC_GET_TEN_DM('DM_NGANHKT','TEN_NGANHKT','MA_NGANHKT',SEGMENT8,EFFECTIVE_DATE) AS TEN_NGANHKT,
	STC_PA_SYS.FNC_GET_CONVERT_NKT2LOAI(SEGMENT8) AS MA_LOAI,STC_PA_SYS.FNC_GET_DICTIONARY('MA_LOAI',STC_PA_SYS.FNC_GET_CONVERT_NDKT2MUC(SEGMENT8),EFFECTIVE_DATE) AS TEN_LOAI, 

	SEGMENT9 AS MA_CTMTQG, STC_PA_SYS.FNC_GET_TEN_DM('DM_CTMTQG','TEN_CTMTQG','MA_CTMTQG',SEGMENT9,EFFECTIVE_DATE) AS TEN_CTMTQG, 

	SEGMENT10 AS MA_KBNN, STC_PA_SYS.FNC_GET_TEN_DM('DM_KBNN','TEN_KBNN','MA_KBNN',SEGMENT10,EFFECTIVE_DATE) AS TEN_KBNN,

	SEGMENT11 AS MA_NGUON_NSNN,STC_PA_SYS.FNC_GET_TEN_DM('DM_NGUON_NSNN','TEN_NGUON_NSNN','MA_NGUON_NSNN',SEGMENT11,EFFECTIVE_DATE) AS TEN_NGUON_NSNN, 

	SEGMENT12,
	POSTED_DATE AS NGAY_KET_SO,
	EFFECTIVE_DATE AS NGAY_HIEU_LUC,
	TRANSFORM_DATE,
	VOUCHER_DATE,
	ATTRIBUTE8,
	ACCOUNTED_CR-ACCOUNTED_DR AS GIA_TRI_HACH_TOAN,
	ENTERED_CR,
	ENTERED_DR,
	SET_OF_BOOKS_ID
	from TABWH_JEL_FCT
	where SEGMENT3 < 6000
commit



--------------------------------------------------------
--  DDL for View PHA_THU_VW
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "BTSTC"."PHA_THU_VW" ("LOAI_NS", "MA_TKTN", "TEN_TKTN", "MA_DVQHNS", "TEN_DVQHNS", "MA_DIABAN", "TEN_DIABAN", "MA_CAP", "TEN_CAP", "MA_CAPNS", "TEN_CAPNS", "MA_CHUONG", "TEN_CHUONG", "MA_NGANHKT", "TEN_NGANHKT", "MA_LOAI", "TEN_LOAI", "MA_TIEUMUC", "TEN_TIEUMUC", "MA_MUC", "TEN_MUC", "MA_TIEUNHOM", "TEN_TIEUNHOM", "MA_NHOM", "TEN_NHOM", "MA_CTMTQG", "TEN_CTMTQG", "MA_KBNN", "TEN_KBNN", "MA_NGUON_NSNN", "TEN_NGUON_NSNN", "NGAY_KET_SO", "NGAY_HACH_TOAN", "GIA_TRI_HACH_TOAN", "LOAI_DU_TOAN") AS 
    
SEGMENT2 as MA_TKTN,STC_PA_SYS.FNC_GET_TEN_DM('DM_TKTN','TEN_TKTN','MA_TKTN',SEGMENT2,EFFECTIVE_DATE) AS TEN_TKTN, 



SEGMENT5 AS MA_DVQHNS,'TEN_DVQHNS' AS TEN_DVQHNS, 
SEGMENT6 AS MA_DIABAN,'TEN_DIABAN' AS TEN_DIABAN, 



SEGMENT8 AS MA_NGANHKT, STC_PA_SYS.FNC_GET_TEN_DM('DM_NGANHKT','TEN_NGANHKT','MA_NGANHKT',SEGMENT8,EFFECTIVE_DATE) AS TEN_NGANHKT, 
STC_PA_SYS.FNC_GET_CONVERT_NKT2LOAI(SEGMENT8) AS MA_LOAI,STC_PA_SYS.FNC_GET_DICTIONARY('MA_LOAI',STC_PA_SYS.FNC_GET_CONVERT_NDKT2MUC(SEGMENT8),EFFECTIVE_DATE) AS TEN_LOAI, 





POSTED_DATE AS NGAY_KET_SO,EFFECTIVE_DATE AS NGAY_HACH_TOAN,(ACCOUNTED_CR - ACCOUNTED_DR) AS GIA_TRI_HACH_TOAN, ATTRIBUTE8 AS LOAI_DU_TOAN
FROM PHA_HACHTOAN_THU htc
;