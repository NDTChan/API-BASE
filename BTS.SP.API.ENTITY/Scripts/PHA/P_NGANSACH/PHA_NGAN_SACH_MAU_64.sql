create or replace PROCEDURE "PHA_NGAN_SACH_MAU_64" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2,TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) AS 
    QUERY_STR  VARCHAR2(32767); 
    P_SQL_INSERT VARCHAR2(32767);
    P_CT VARCHAR2(32767);
    P_SELECT_DBHC VARCHAR2(32767);
   -- V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
BEGIN
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN (P_CONGTHUC) INTO P_CT from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' AND '||P_CT;
        END IF;
        IF(P_MA_DBHC <> 27) THEN
        P_SELECT_DBHC:= ' AND A.MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
        ELSE P_SELECT_DBHC:= ' ';
        END IF;
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_SQL_INSERT:=P_SQL_INSERT || P_SELECT_DBHC;
        ELSE
        P_SQL_INSERT:=P_SQL_INSERT;
        END IF;
    QUERY_STR :=' SELECT 
                        A.MA_CAP,
                        A.MA_CHUONG, 
                        A.MA_TKTN,
                        A.MA_DVQHNS,
                        A.TEN_DVQHNS,
                        A.MA_LOAI,
                        A.MA_NGANHKT,
                        A.MA_MUC,
                        A.MA_TIEUMUC, 
                        A.TEN_CHUONG,
                        SUM (NVL(A.GIA_TRI_HACH_TOAN,0) /NVL('|| DONVI_TIEN ||',1))AS SOQT
    FROM PHA_HACHTOAN_CHI A 
    WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                        and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and A.MA_CAP in (2,3,4) AND  A.MA_TKTN IN(''8113'',''8116'',''8123'',''8126'',''8211'',''8221'',''8251'',''8261'',''8311'',''8313'',''8411'',''8941'',''8951'',''8956'',''8959'',''1513'',''1523'',''1713'',''1717'')
                        '||P_SQL_INSERT||'
    GROUP BY A.MA_CAP,A.MA_CHUONG,A.MA_DVQHNS,A.TEN_DVQHNS, A.MA_LOAI, A.MA_NGANHKT, A.MA_MUC, A.MA_TIEUMUC,A.TEN_CHUONG,A.MA_TKTN
    ORDER BY A.MA_CAP';
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
END PHA_NGAN_SACH_MAU_64;
 