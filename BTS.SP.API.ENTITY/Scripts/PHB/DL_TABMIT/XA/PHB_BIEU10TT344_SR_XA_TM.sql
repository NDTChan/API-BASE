--------------------------------------------------------
--  File created - Friday-May-04-2018   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Procedure PHB_BIEU10TT344_SR_XA_TM
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PHB_BIEU10TT344_SR_XA_TM" 
(
  MADBHC IN NVARCHAR2,
  MADBHC_CHA IN NVARCHAR2,
  TUNGAY_KS IN DATE,
  DENNGAY_KS IN DATE,
  TUNGAY_HL IN DATE,
  DENNGAY_HL IN DATE,
    MACHUONG IN NVARCHAR2,
  MALOAIKHOAN IN NVARCHAR2,
  MANDKT IN NVARCHAR2,
  CUR OUT SYS_REFCURSOR
)IS
P_QUERY VARCHAR2(32767);
P_SELECT VARCHAR2(32767);
P_WHERE VARCHAR2(32767);

   LST_DBHC VARCHAR2(5000) := '';
    P_LSTKY VARCHAR2(500);
   COUNT_BAOCAO NUMBER;

BEGIN
       IF MACHUONG IS NULL OR MACHUONG = '' THEN P_WHERE :=P_WHERE|| ' AND bieub01xDetail.MA_CHUONG IN ('||MACHUONG||')';
       ELSE P_WHERE := P_WHERE||'';
       END IF;
       IF MALOAIKHOAN IS NULL OR MALOAIKHOAN = '' THEN P_WHERE :=P_WHERE|| ' AND (bieub01xDetail.MA_LOAI IN ('||MALOAIKHOAN||') OR bieub01xDetail.MA_NGANHKT IN ('||MALOAIKHOAN||'))';
       ELSE P_WHERE := P_WHERE||'';
       END IF;
       IF MANDKT IS NULL OR MANDKT = '' THEN P_WHERE :=P_WHERE|| ' AND (bieub01xDetail.MA_MUC IN ('||MANDKT||') OR bieub01xDetail.MA_TIEUMUC IN ('||MANDKT||'))';
       ELSE P_WHERE := P_WHERE||'';
       END IF;


    IF(MADBHC = '-1') THEN
        FOR ITEM IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC_CHA =''||MADBHC_CHA||'')
        LOOP
            LST_DBHC := LST_DBHC || '''' || ITEM.MA_DBHC || '''' || ',';
        END LOOP;
        LST_DBHC := SUBSTR(LST_DBHC,0,LENGTH(LST_DBHC)-1); 
        DBMS_OUTPUT.PUT_LINE(LST_DBHC);
        P_SELECT :=' AND bieub01xDetail.MA_DIABAN IN ('||LST_DBHC||')';
    ELSE 
        P_SELECT :=' AND bieub01xDetail.MA_DIABAN = '''||MADBHC||'''';
    END IF;

        P_QUERY:='SELECT bieub01xDetail.MA_CHUONG,bieub01xDetail.MA_MUC,bieub01xDetail.MA_TIEUMUC,bieub01xDetail.TEN_TIEUMUC AS DIEN_GIAI,SUM(bieub01xDetail.GIA_TRI_HACH_TOAN) as QUYET_TOAN
            FROM PHA_HACHTOAN_THU bieub01xDetail WHERE NGAY_KET_SO >= '''||TUNGAY_KS||'''
                                                        AND NGAY_KET_SO <= '''||DENNGAY_KS||'''
                                                        AND NGAY_HIEU_LUC >= '''||TUNGAY_HL||'''
                                                        AND NGAY_HIEU_LUC <= '''||DENNGAY_HL||'''';
        P_QUERY:= P_QUERY || P_SELECT;
        P_QUERY:=P_QUERY||' GROUP BY bieub01xDetail.MA_CHUONG,bieub01xDetail.MA_LOAI,bieub01xDetail.TEN_TIEUMUC,bieub01xDetail.MA_MUC,bieub01xDetail.MA_TIEUMUC';
        P_QUERY:=P_QUERY||' ORDER BY bieub01xDetail.MA_CHUONG,bieub01xDetail.MA_LOAI,bieub01xDetail.TEN_TIEUMUC,bieub01xDetail.MA_MUC,bieub01xDetail.MA_TIEUMUC';

--        P_QUERY:= 'SELECT * FROM PHA_HACHTOAN_CHI WHERE 1 = 2';
    DBMS_output.put_line(P_QUERY);
    OPEN cur FOR P_QUERY;
END PHB_BIEU10TT344_SR_XA_TM;

/
