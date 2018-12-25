create or replace PROCEDURE "PHA_NS_BM61_ND31_TT" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE, P_CAP VARCHAR2, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  CLOB; 
   P_CT VARCHAR2(32767);   
   P_SQL_INSERT VARCHAR2(32767); 
   TEMP VARCHAR2(32767);
   P_SELECT_DBHC VARCHAR2(32767);
   BEGIN
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN(P_CONGTHUC) INTO P_CT from dual;       
    END IF;
   IF(P_CT IS NULL) THEN P_CT:=' AND 1=1'; 
        ELSIF(P_CT IS NOT NULL) THEN P_CT:= ' AND ' || P_CT;
        END IF;
    IF(P_MA_DBHC <> 27) THEN
        P_SELECT_DBHC:= ' AND A.MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
        ELSE P_SELECT_DBHC:= ' ';
        END IF;
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_CT:=P_CT || P_SELECT_DBHC;
        ELSE
        P_CT:=P_CT;
        END IF;
            CASE 
                WHEN P_CAP='2' THEN TEMP:=' AND A.MA_CHUONG BETWEEN ''400'' AND ''989''';
                WHEN P_CAP='3' THEN TEMP:=' AND A.MA_CHUONG BETWEEN ''600'' AND ''989''';
                WHEN P_CAP='4' THEN TEMP:=' AND A.MA_CHUONG BETWEEN ''800'' AND ''989''';
                ELSE TEMP:='';
            END CASE;

           QUERY_STR:='SELECT HT.MA_CHUONG, HT.TEN_CHUONG, HT.MA_DVQHNS, HT.TEN_DVQHNS, HT.MA_CTMTQG, HT.TEN_CTMTQG
                        , NVL(HT.CDTTN,0) as CDTTN
                        , NVL(HT.CDTNN,0) as CDTNN , NVL(HT.CTXTN,0) as CTXTN , NVL(HT.CTXNN,0) as CTXNN

                        FROM
                        (
                        SELECT A.MA_CHUONG AS MA_CHUONG, A.TEN_CHUONG, A.MA_DVQHNS, A.TEN_DVQHNS, A.MA_CTMTQG, A.TEN_CTMTQG
                        ,NVL(SUM (CASE WHEN (((MA_TKTN like ''8%'' OR MA_TKTN like ''15%'' OR MA_TKTN like ''17%'' OR MA_TKTN like ''19%'')  AND NOT   MA_CTMTQG like ''00000'' AND NOT  MA_CTMTQG like ''0027%'' AND NOT  MA_CTMTQG like ''050%''  AND NOT   MA_CAP like ''1''  AND NOT   MA_CHUONG like ''509''  AND NOT   MA_CHUONG like ''560''  AND NOT   MA_CHUONG like ''564'' ) AND   MA_MUC  BETWEEN  ''9100'' AND ''9400'' AND  MA_NGUON_NSNN like ''43'')
                        THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CDTTN

                        ,NVL(SUM (CASE WHEN (((MA_TKTN like ''8%'' OR MA_TKTN like ''15%'' OR MA_TKTN like ''17%'' OR MA_TKTN like ''19%'')  AND NOT   MA_CTMTQG like ''00000'' AND NOT  MA_CTMTQG like ''0027%'' AND NOT  MA_CTMTQG like ''050%''  AND NOT   MA_CAP like ''1''  AND NOT   MA_CHUONG like ''509''  AND NOT   MA_CHUONG like ''560''  AND NOT   MA_CHUONG like ''564'') AND  MA_MUC  BETWEEN  ''9100'' AND ''9400'' AND  MA_NGUON_NSNN like ''50'') 
                                    THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CDTNN

                        ,NVL(SUM (CASE WHEN ((MA_TKTN like ''8%'' OR MA_TKTN like ''15%'' OR MA_TKTN like ''17%'' OR MA_TKTN like ''19%'') AND NOT   MA_CTMTQG like ''00000'' AND NOT  MA_CTMTQG like ''0027%'' AND NOT  MA_CTMTQG like ''050%''  AND NOT  MA_CTMTQG like ''0072%'' AND NOT   MA_CAP like ''1''  AND NOT   MA_CHUONG like ''509''  AND NOT   MA_CHUONG like ''560''  AND NOT   MA_CHUONG like ''564'' AND NOT   MA_MUC  BETWEEN  ''9100'' AND ''9400'') AND ( MA_NGUON_NSNN like ''51'' OR  MA_NGUON_NSNN like ''15'' OR  MA_NGUON_NSNN like ''27'' ) 
                                  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CTXTN

                       ,NVL(SUM (CASE WHEN ((MA_TKTN like ''8%'' OR MA_TKTN like ''15%'' OR MA_TKTN like ''17%'' OR MA_TKTN like ''19%'')  AND NOT   MA_CTMTQG like ''00000'' AND NOT  MA_CTMTQG like ''0027%'' AND NOT  MA_CTMTQG like ''050%''  AND NOT   MA_CAP like ''1''  AND NOT   MA_CHUONG like ''509''  AND NOT   MA_CHUONG like ''560''  AND NOT   MA_CHUONG like ''564''  AND NOT   MA_MUC  BETWEEN  ''9100'' AND ''9400''  AND   MA_NGUON_NSNN like ''50'') 
                                 THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CTXNN


                        FROM PHA_HACHTOAN_CHI A
                        WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                        and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                            AND NOT A.MA_CAP like ''1'' AND NOT A.MA_CHUONG LIKE ''000'' AND NOT A.MA_CTMTQG LIKE ''00000'' AND NOT A.MA_CTMTQG LIKE ''050%'' AND NOT A.MA_CTMTQG LIKE ''0027%'''
                            || TEMP
                            || P_CT
                        || ' GROUP BY A.MA_CHUONG,A.TEN_CHUONG, A.MA_DVQHNS, A.TEN_DVQHNS, A.MA_CTMTQG, A.TEN_CTMTQG
                        ) HT 

                        WHERE 1=1 ORDER BY HT.MA_CHUONG';
   --DBMS_OUTPUT.put_line (QUERY_STR);
BEGIN
EXECUTE IMMEDIATE QUERY_STR;
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      --DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
END;    
END PHA_NS_BM61_ND31_TT;
 