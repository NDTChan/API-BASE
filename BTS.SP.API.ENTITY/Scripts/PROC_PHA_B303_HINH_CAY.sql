create or replace PROCEDURE "PROC_PHA_B303_HINH_CAY" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2,TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   P_SELECT_DBHC VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN (P_CONGTHUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   
        P_SELECT_DBHC:= ' AND A.MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
       
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_SQL_INSERT:=P_SQL_INSERT || P_SELECT_DBHC;
        ELSE
        P_SQL_INSERT:=P_SQL_INSERT;
        END IF;
QUERY_STR:='select * FROM (SELECT 
         A.MA_NGHIEPVU,
         A.MA_CHUONG,
         A.MA_CAP,
         A.MA_MUC,
         A.MA_TIEUMUC,
         A.MA_CAPMLNS,
         A.MA_LOAI,
         A.MA_KBNN,
         A.MA_DVQHNS,
         A.MA_NGUON_NSNN,         
         A.MA_NGANHKT,
         A.TEN_DVQHNS,
         A.TEN_CAP,
         A.TEN_CHUONG,
         A.TEN_LOAI,
         A.TEN_NGANHKT,
         A.TEN_MUC,
         A.TEN_TIEUMUC,
          SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))
               THEN
                  GIA_TRI_HACH_TOAN /NVL('|| DONVI_TIEN ||',1)
               ELSE
                  0
            END)
            AS PS,
         SUM (NVL(GIA_TRI_HACH_TOAN,0))/NVL('|| DONVI_TIEN ||',1)
            AS LK
    FROM PHA_HACHTOAN_CHI A 
    WHERE 1=1 and A.MA_CAPMLNS in (''2'',''3'',''4'') and '||
    '  A.NGAY_HIEU_LUC >= TO_DATE ('''|| '0101'||V_TU_NAM ||''', ''ddMMyyyy'')
                     AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                     AND NOT A.MA_TKTN IN(''1916'',''8913'',''8916'')'||P_SQL_INSERT||'     
GROUP BY A.MA_NGHIEPVU,A.MA_CHUONG, A.MA_CAP, A.MA_CAPMLNS, A.MA_MUC, A.MA_TIEUMUC,A.MA_LOAI,A.MA_NGANHKT,A.MA_KBNN,A.MA_DVQHNS,A.MA_NGUON_NSNN,A.TEN_DVQHNS,A.TEN_CAP,A.TEN_CHUONG,A.TEN_LOAI,A.TEN_NGANHKT,A.TEN_MUC,A.TEN_TIEUMUC
)
PIVOT ( sum(PS) as PS, Sum(LK) as LK
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )
order by  MA_CHUONG'; 
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
END PROC_PHA_B303_HINH_CAY;