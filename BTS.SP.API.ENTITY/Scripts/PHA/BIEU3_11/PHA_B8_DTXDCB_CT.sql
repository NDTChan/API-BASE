create or replace PROCEDURE PHA_B8_DTXDCB_CT (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
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
        

QUERY_STR:=' SELECT HT.MA_CHUONG, HT.TEN_CHUONG, HT.MA_DVQHNS, HT.TEN_DVQHNS
                , NVL(HT.DUTOAN,0) as DUTOAN
                ,NVL(SUM (CASE WHEN (B.MA_TKTN IN(''8211'',''8261'',''8941'',''8951'',''8956'') AND B.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                AND B.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                and B.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                and B.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))     THEN B.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI
                ,NVL(SUM (CASE WHEN (B.MA_TKTN IN(''1713'',''1717'') AND B.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                AND B.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                and B.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                and B.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))     THEN B.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS UNG
                FROM
                ( 
                 SELECT A.MA_CHUONG AS MA_CHUONG, A.TEN_CHUONG, A.MA_DVQHNS, A.TEN_DVQHNS, A.MA_KBNN
                        ,NVL(SUM (CASE WHEN (A.MA_TKTN LIKE ''9%'' AND NOT A.MA_TKTN IN (''9557'',''9567'')) THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS DUTOAN
                FROM PHA_DUTOAN A  
                WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                AND A.MA_DVQHNS LIKE ''7%''
                AND A.MA_CHUONG BETWEEN ''400'' AND ''599'' 
                '|| P_SQL_INSERT|| ' GROUP BY A.MA_CHUONG,A.TEN_CHUONG, A.MA_DVQHNS, A.TEN_DVQHNS, A.MA_KBNN
                ) HT LEFT JOIN PHA_HACHTOAN_CHI B ON HT.MA_DVQHNS = B.MA_DVQHNS AND HT.MA_CHUONG = B.MA_CHUONG AND HT.MA_KBNN = B.MA_KBNN
                WHERE 1=1 AND (HT.DUTOAN <> 0) 
                GROUP BY HT.MA_CHUONG, HT.TEN_CHUONG, HT.MA_DVQHNS, HT.TEN_DVQHNS
                , HT.DUTOAN
                ORDER BY HT.MA_CHUONG';
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
END PHA_B8_DTXDCB_CT;