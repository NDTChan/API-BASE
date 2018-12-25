create or replace PROCEDURE "PHA_NGAN_SACH_MAU_63_N_TM" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_CT VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   P_SELECT_DBHC VARCHAR2(32767);
   BEGIN
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) INTO P_CT from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_CT;
        END IF;
    IF(P_MA_DBHC <> 27) THEN
        P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
        ELSE P_SELECT_DBHC:= ' ';
        END IF;
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_SQL_INSERT:=P_SQL_INSERT || P_SELECT_DBHC;
        ELSE
        P_SQL_INSERT:=P_SQL_INSERT;
        END IF;
QUERY_STR:='select * FROM (SELECT 
          MA_NHOM, TEN_NHOM, MA_CAP,MA_MUC, TEN_MUC,MA_TIEUMUC,TEN_TIEUMUC, 
         MA_CAPMLNS,MA_TIEUNHOM, TEN_TIEUNHOM,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS LK
        FROM PHA_HACHTOAN_THU 
        WHERE 1=1 '||P_SQL_INSERT|| 
        'NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                        and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
         GROUP BY MA_NHOM, TEN_NHOM, MA_CAP,MA_MUC, TEN_MUC,MA_TIEUMUC,TEN_TIEUMUC, 
         MA_CAPMLNS,MA_TIEUNHOM, TEN_TIEUNHOM
        )
        PIVOT ( Sum(LK) as LK
                  FOR MA_CAP
                  IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
                  )
        order by  MA_NHOM DESC'; 
DBMS_OUTPUT.put_line (QUERY_STR);
BEGIN
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;    
END PHA_NGAN_SACH_MAU_63_N_TM;