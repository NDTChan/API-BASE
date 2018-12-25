create or replace PROCEDURE "PHA_NGAN_SACH_MAU_65" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2,TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) AS 
    QUERY_STR  VARCHAR2(32767); 
    P_SQL_INSERT VARCHAR2(32767);
    P_CT VARCHAR2(32767);
    V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
    P_SELECT_DBHC VARCHAR2(32767);
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
    QUERY_STR :='
    SELECT * FROM(
    SELECT A.TEN_CTMTQG,
                        A.MA_CTMTQG,
                        A.MA_CHUONG,
                        A.MA_LOAI,
                        A.MA_NGANHKT,
                        A.MA_MUC, 
                        A.MA_TIEUMUC,
                        SUM (NVL(A.GIA_TRI_HACH_TOAN,0) /NVL('|| DONVI_TIEN ||',1))AS SOQT
    FROM PHA_HACHTOAN_CHI A
    WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''|| '0101'||V_TU_NAM ||''', ''ddMMyyyy'')
                     AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
          AND (A.MA_TKTN like ''8%'' or A.MA_TKTN like ''15%''or A.MA_TKTN like ''17%''or A.MA_TKTN like ''19%'')
          AND NOT A.MA_CTMTQG = 00000 AND NOT A.MA_CAP in (0,1)
          AND NOT A.MA_CTMTQG LIKE ''05%'' AND NOT A.MA_CTMTQG LIKE ''0027%'' AND NOT A.MA_CTMTQG LIKE ''0072%''
          '||P_SQL_INSERT||'
    GROUP BY A.TEN_CTMTQG,A.MA_CTMTQG,A.MA_CHUONG, A.MA_LOAI, A.MA_NGANHKT, A.MA_MUC, A.MA_TIEUMUC
    ) QT WHERE QT.SOQT <> 0'
    ;
DBMS_OUTPUT.put_line ('<your message>' || QUERY_STR);                      
BEGIN
EXECUTE IMMEDIATE QUERY_STR;
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;
END PHA_NGAN_SACH_MAU_65;
 