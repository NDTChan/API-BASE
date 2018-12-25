create or replace procedure PHA_NS_BM59_ND31(P_CONGTHUC VARCHAR2, P_NAM VARCHAR2, P_DBHC VARCHAR2, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR   CLOB; 
   P_CT  VARCHAR2(32767);    
   P_SQL_INSERT  VARCHAR2(32767); 
   TEMP  VARCHAR2(32767);
   BEGIN
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN(P_CONGTHUC) INTO P_CT from dual;       
        P_CT:= ' AND ' || P_CT;
    END IF;
            CASE 
                WHEN P_DBHC='2' THEN TEMP:=' AND A.MA_CHUONG BETWEEN ''400'' AND ''989''';
                --WHEN P_CAP='3' THEN TEMP:=' AND A.MA_CHUONG BETWEEN ''600'' AND ''989''';
                --WHEN P_CAP='4' THEN TEMP:=' AND A.MA_CHUONG BETWEEN ''800'' AND ''989''';
                ELSE TEMP:='';
            END CASE;

            QUERY_STR:='SELECT HT.MA_DBHC, DB.TEN_DBHC
                        , NVL(HT.QT_BSCDNS,0) as QT_BSCDNS, NVL(HT.QT_VTN,0) as QT_VTN, NVL(HT.QT_VNN,0) as QT_VNN
                        FROM
                        (
                        SELECT A.MA_DIABAN AS MA_DBHC
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'') AND ( MA_CHUONG like ''160'' OR  MA_CHUONG like ''560'' OR  MA_CHUONG like ''760'') AND  MA_NGANHKT like ''356'' AND  MA_TIEUMUC like ''7301'') 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_BSCDNS
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'' OR  MA_TKTN like ''8953'' OR  MA_TKTN like ''8954'' OR  MA_TKTN like ''8955'' OR  MA_TKTN like ''8956'' OR  MA_TKTN like ''8957'' OR  MA_TKTN like ''8958'' OR  MA_TKTN like ''8959'') AND ( MA_CHUONG like ''160'' OR  MA_CHUONG like ''560'' OR  MA_CHUONG like ''760'') AND  MA_NGANHKT like ''346'' AND ( MA_TIEUMUC like ''7304'' OR  MA_TIEUMUC like ''7305'' OR  MA_TIEUMUC like ''7349'')) 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_VTN
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'' OR  MA_TKTN like ''8953'' OR  MA_TKTN like ''8954'' OR  MA_TKTN like ''8955'' OR  MA_TKTN like ''8956'' OR  MA_TKTN like ''8957'' OR  MA_TKTN like ''8958'' OR  MA_TKTN like ''8959'') AND ( MA_CHUONG like ''160'' OR  MA_CHUONG like ''560'' OR  MA_CHUONG like ''760'') AND  MA_NGANHKT like ''346'' AND ( MA_TIEUMUC like ''7302'' OR  MA_TIEUMUC like ''7303'')) 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_VNN
                        FROM PHA_HACHTOAN_CHI A
                        WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || P_NAM  ||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''|| '3112' || P_NAM  ||''', ''ddMMyyyy'')
                        AND NOT A.MA_CAP like ''1'' AND NOT A.MA_CHUONG LIKE ''000'' '
                        || TEMP
                        || P_CT
                        || ' GROUP BY A.MA_DIABAN
                        ) HT INNER JOIN DM_DBHC DB ON HT.MA_DBHC = DB.MA_DBHC
                        WHERE 1=1 ORDER BY HT.MA_DBHC';


--DBMS_OUTPUT.put_line(QUERY_STR); 

BEGIN
EXECUTE IMMEDIATE QUERY_STR;
OPEN cur FOR QUERY_STR;
EXCEPTION
  WHEN NO_DATA_FOUND
  THEN
     DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
    --DBMS_OUTPUT.ENABLE(200000);
     DBMS_OUTPUT.put_line ('<your message>'  || SQLERRM); 
END;   
END PHA_NS_BM59_ND31;