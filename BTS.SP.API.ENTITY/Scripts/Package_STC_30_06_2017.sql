--------------------------------------------------------
--  File created - Friday-June-30-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Package STC_PA_SYS
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "BTSTC"."STC_PA_SYS" 
AS
   FUNCTION FNC_GET_TEN_DM (TAB_NAME   IN VARCHAR,
                            F_NAME        VARCHAR,
                            F_CODE        VARCHAR,
                            S_VALUE    IN VARCHAR,
                            EFF_DATE      DATE)
      RETURN NVARCHAR2;

   FUNCTION FNC_GET_DICTIONARY (F_NAME      VARCHAR,
                                F_CODE      VARCHAR,
                                EFF_DATE    DATE)
      RETURN NVARCHAR2;

   FUNCTION FNC_GET_CONVERT_CHUONG2CAP (F_CHUONG NVARCHAR2)
      RETURN NVARCHAR2;


   FUNCTION FNC_GET_CONVERT_NKT2LOAI (F_NKT NVARCHAR2)
      RETURN NVARCHAR2;

   FUNCTION FNC_GET_CONVERT_NDKT2MUC (F_NDKT NVARCHAR2)
      RETURN NVARCHAR2;

   FUNCTION FNC_GET_LOAI_NS (F_MUC NVARCHAR2)
      RETURN NVARCHAR2;

   FUNCTION FNC_CONVERT_FORMULA (F_FORMULA NVARCHAR2)
      RETURN NVARCHAR2;

   FUNCTION FNC_GET_TEN_CHITIEU (p_Ma_CHITIEU IN VARCHAR2, p_NGAY_HL IN DATE)
      RETURN VARCHAR2;

   FUNCTION FNC_GET_CONGTHUC_CHITIEU (p_Ma_CHITIEU   IN VARCHAR2,
                                      p_NGAY_HL      IN DATE)
      RETURN VARCHAR2;

   FUNCTION FNC_GET_CONVERT_NDKT2NHOM (F_NDKT NVARCHAR2)
      RETURN NVARCHAR2;

   FUNCTION FNC_GET_CONVERT_NDKT2TNHOM (F_NDKT NVARCHAR2)
      RETURN NVARCHAR2;

   PROCEDURE PRC_TH_MLNS (P_BNGAY_HACHTOAN    DATE,
                          P_ENGAY_HACHTOAN    DATE,
                          P_BNGAY_KETSO       DATE,
                          P_ENGAY_KETSO       DATE,
                          P_LOAI              VARCHAR2);

   PROCEDURE PRC_TH_MLNS_EXCELL (P_BNGAY_HACHTOAN    DATE,
                                 P_ENGAY_HACHTOAN    DATE,
                                 P_BNGAY_KETSO       DATE,
                                 P_ENGAY_KETSO       DATE,
                                 P_LOAI              VARCHAR2,
                                 P_USERID            VARCHAR2);

   PROCEDURE PRC_TH_TONQUY (P_BNGAY_HACHTOAN DATE, P_ENGAY_HACHTOAN DATE);

   PROCEDURE PRC_SUM_UP;

   PROCEDURE PRC_GET_DATA (F_LOAIDATA      NUMBER,
                           F_TABLE_NAME    NCHAR,
                           F_TUNGAY        DATE,
                           F_DENNGAY       DATE,
                           F_SHKB          NCHAR);

   PROCEDURE PRC_TH_MLNS_BYFOMULAR (P_BNGAY_HACHTOAN    DATE,
                                    P_ENGAY_HACHTOAN    DATE,
                                    P_BNGAY_KETSO       DATE,
                                    P_ENGAY_KETSO       DATE,
                                    P_LOAI              NVARCHAR2,
                                    P_USERID            NVARCHAR2,
                                    P_CONGTHUC          NVARCHAR2);
END STC_PA_SYS;

/
--------------------------------------------------------
--  DDL for Package STC_PHA_BCDMCT
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "BTSTC"."STC_PHA_BCDMCT" AS 
    
    TYPE MEASURE_RECORD IS RECORD (
      TW_PS number(20,0),
      TW_LK number(20,0),
      TINH_PS number(20,0),
      TINH_LK number(20,0),
      HUYEN_PS number(20,0),
      HUYEN_LK number(20,0),
      XA_PS number(20,0),
      XA_LK number(20,0)
    );
    TYPE MEASURE_TABLE IS TABLE OF MEASURE_RECORD;
  FUNCTION FCN_GET_PHA_BCDMCT(LOAI_BC NVARCHAR2, CONGTHUC NVARCHAR2,CONGTHUC_SEG1 NVARCHAR2,CONGTHUC_SEG2 NVARCHAR2, TUNGAY_HL DATE, DENNGAY_HL DATE,TUNGAY_KS DATE, DENNGAY_KS DATE,DONVI_TIEN NUMBER)
  RETURN MEASURE_TABLE PIPELINED;
  FUNCTION FCN_GET_PHA_TONQUY(LOAI NVARCHAR2, CONGTHUC NVARCHAR2,CONGTHUC_SEG1 NVARCHAR2,CONGTHUC_SEG2 NVARCHAR2, TUNGAY_HL DATE, DENNGAY_HL DATE,TUNGAY_KS DATE, DENNGAY_KS DATE,DONVI_TIEN NUMBER)
  RETURN MEASURE_TABLE PIPELINED;
  FUNCTION FCN_GET_DATA_FROM_CT (CONGTHUC      NVARCHAR2)
      RETURN NUMBER;
   FUNCTION FCN_TESTDL (LOAI       varchar:= 'thu')
                               RETURN MEASURE_TABLE PIPELINED;
   PROCEDURE PROC_TESTDL (LOAI IN varchar:= 'thu', CUR OUT SYS_REFCURSOR);
    
END STC_PHA_BCDMCT;

/
