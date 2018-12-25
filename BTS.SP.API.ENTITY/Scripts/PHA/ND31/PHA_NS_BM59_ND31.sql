create or replace PROCEDURE PHA_NS_BM59_ND31(P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE, P_DBHC VARCHAR2, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR   CLOB;
   QUERY_STR1   CLOB;
   QUERY_STR2   CLOB;
   P_CT  VARCHAR2(32767);    
   P_SQL_INSERT  VARCHAR2(32767); 
   P_SQL_INSERT_DT  VARCHAR2(32767);
   P_SQL_INSERT_DT1  VARCHAR2(32767); 
   TEMP  VARCHAR2(32767);
   P_SQL_CREATE_TABLE  VARCHAR2(32767); 
   P_SQL_CREATE_TABLE_DT  VARCHAR2(32767); 
   N_COUNT NUMBER(17,4):=0;
   N_COUNT_DT NUMBER(17,4):=0;
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
--        IF(P_SELECT_DBHC IS NOT NULL) THEN
--        P_CT:=P_CT || P_SELECT_DBHC;
--        ELSE
--        P_CT:=P_CT;
--        END IF;
    CASE 
    WHEN LENGTH(P_DBHC) >= 0 THEN TEMP:=' AND DB.MA_DBHC_CHA = ' || P_DBHC || '';                
    ELSE TEMP:='';
    END CASE;
        
  P_SQL_CREATE_TABLE := 'CREATE TABLE BM59_ND31(MA_DBHC_CHA  NVARCHAR2(50) , MA_DBHC NVARCHAR2(50),TEN_DBHC NVARCHAR2(200), MA_DVQHNS NVARCHAR2(50), QT_BSCDNS NUMBER(18,2)
  ,QT_VTN NUMBER(18,2), QT_VNN NUMBER(18,2),QT_VCTMT NUMBER(18,2),DT_BSCDNS NUMBER(18,2),DT_BSMT NUMBER(18,2))SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  ';
    BEGIN
          SELECT COUNT(*)  INTO N_COUNT  FROM ALL_TAB_COLUMNS  WHERE TABLE_NAME = 'BM59_ND31';
          EXCEPTION WHEN OTHERS THEN N_COUNT:=0;
      END;

      IF(N_COUNT IS NULL OR N_COUNT<=0) THEN
      BEGIN

          EXECUTE IMMEDIATE P_SQL_CREATE_TABLE;  
      END;
      END IF;
      EXECUTE IMMEDIATE 'TRUNCATE TABLE BM59_ND31';
  P_SQL_CREATE_TABLE_DT := 'CREATE TABLE BM59_ND31_TEMP(MA_DVQHNS NVARCHAR2(50),MA_XA NVARCHAR2(50),DT_BSCDNS NUMBER(18,2),DT_BSMT NUMBER(18,2))SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  ';
    BEGIN
          SELECT COUNT(*)  INTO N_COUNT_DT  FROM ALL_TAB_COLUMNS  WHERE TABLE_NAME = 'BM59_ND31_TEMP';
          EXCEPTION WHEN OTHERS THEN N_COUNT_DT:=0;
      END;

      IF(N_COUNT_DT IS NULL OR N_COUNT_DT <= 0) THEN
      BEGIN
          EXECUTE IMMEDIATE P_SQL_CREATE_TABLE_DT;  
      END;
      END IF;
      EXECUTE IMMEDIATE 'TRUNCATE TABLE BM59_ND31_TEMP';

         P_SQL_INSERT:= 'INSERT INTO BM59_ND31(MA_DBHC_CHA,MA_DBHC,TEN_DBHC,MA_DVQHNS,QT_BSCDNS,QT_VTN,QT_VNN,QT_VCTMT)
                        SELECT HT.MA_DBHC_CHA, HT.MA_DBHC, HT.TEN_DBHC, HT.MA_DVQHNS
                        , NVL(HT.QT_BSCDNS,0) as QT_BSCDNS, NVL(HT.QT_VTN,0) as QT_VTN, NVL(HT.QT_VNN,0) as QT_VNN, NVL(HT.QT_VCTMT,0) as QT_VCTMT
                        FROM
                        (
                        SELECT DB.MA_DBHC_CHA AS MA_DBHC_CHA, A.MA_DIABAN AS MA_DBHC, DB.TEN_DBHC AS TEN_DBHC, A.MA_DVQHNS
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'') AND ( MA_CHUONG like ''160'' OR  MA_CHUONG like ''560'' OR  MA_CHUONG like ''760'') AND  MA_NGANHKT like ''356'' AND  MA_TIEUMUC like ''7301'') 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_BSCDNS
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'' OR  MA_TKTN like ''8953'' OR  MA_TKTN like ''8954'' OR  MA_TKTN like ''8955'' OR  MA_TKTN like ''8956'' OR  MA_TKTN like ''8957'' OR  MA_TKTN like ''8958'' OR  MA_TKTN like ''8959'') AND ( MA_CHUONG like ''160'' OR  MA_CHUONG like ''560'' OR  MA_CHUONG like ''760'') AND  MA_NGANHKT like ''346'' AND ( MA_TIEUMUC like ''7304'' OR  MA_TIEUMUC like ''7305'' OR  MA_TIEUMUC like ''7349'')) 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_VTN
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'' OR  MA_TKTN like ''8953'' OR  MA_TKTN like ''8954'' OR  MA_TKTN like ''8955'' OR  MA_TKTN like ''8956'' OR  MA_TKTN like ''8957'' OR  MA_TKTN like ''8958'' OR  MA_TKTN like ''8959'') AND ( MA_CHUONG like ''160'' OR  MA_CHUONG like ''560'' OR  MA_CHUONG like ''760'') AND  MA_NGANHKT like ''346'' AND ( MA_TIEUMUC like ''7302'' OR  MA_TIEUMUC like ''7303'')) 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_VNN
                        ,NVL(SUM (CASE WHEN (( MA_TKTN like ''8311'' OR  MA_TKTN like ''8312'' OR  MA_TKTN like ''8313'' OR  MA_TKTN like ''8953'' OR  MA_TKTN like ''8954'' OR  MA_TKTN like ''8955'' OR  MA_TKTN like ''8956'' OR  MA_TKTN like ''8957'' OR  MA_TKTN like ''8958'' OR  MA_TKTN like ''8959'') AND A.MA_NGUON_NSNN = ''43'') 
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS QT_VCTMT
                                
                        FROM PHA_HACHTOAN_CHI A LEFT JOIN DM_DBHC DB ON A.MA_DIABAN = DB.MA_DBHC
                        WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                        and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND NOT A.MA_CAP like ''1'' AND NOT A.MA_CHUONG LIKE ''000'' AND NOT A.MA_DIABAN IN(''274'',''56'',''60'',''24'',''00000'',''10939'') '
                        || TEMP
                        || P_CT || P_SELECT_DBHC
                        || ' GROUP BY MA_DBHC_CHA, A.MA_DIABAN, TEN_DBHC, A.MA_DVQHNS ORDER BY A.MA_DVQHNS
                        ) HT 
                        WHERE 1=1 ORDER BY HT.MA_DVQHNS ';
                         DBMS_OUTPUT.put_line(P_SQL_INSERT);
              EXECUTE IMMEDIATE P_SQL_INSERT;
              
         P_SQL_INSERT_DT:= 'INSERT INTO BM59_ND31_TEMP(MA_DVQHNS,MA_XA,DT_BSCDNS,DT_BSMT)
                        SELECT HT.MA_DVQHNS, HT.MA_XA
                        , NVL(HT.DT_BSCDNS,0) as DT_BSCDNS, NVL(HT.DT_BSMT,0) as DT_BSMT
                        FROM
                        (
                        SELECT A.MA_DVQHNS, DV.MA_XA
                        ,NVL(SUM (CASE WHEN (( (MA_TKTN like ''9622'' OR  MA_TKTN like ''9623'') AND MA_NGANHKT like ''346''))
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS DT_BSCDNS
                        ,NVL(SUM (CASE WHEN (( (MA_TKTN like ''9622'' OR  MA_TKTN like ''9623'') AND MA_NGANHKT like ''356''))
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS DT_BSMT
                        FROM PHA_DUTOAN A LEFT JOIN SYS_DVQHNS DV ON A.MA_DVQHNS = DV.MA_DVQHNS
                        WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                        and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.MA_DVQHNS <> ''2%''
                        AND NOT A.MA_CAP like ''1'' AND NOT A.MA_CHUONG LIKE ''000'' AND NOT A.MA_DIABAN IN(''274'',''56'',''60'',''24'',''10939'') '
                        || P_CT 
                        || ' GROUP BY A.MA_DVQHNS,DV.MA_XA ORDER BY A.MA_DVQHNS
                        ) HT 
                        WHERE 1=1 ORDER BY HT.MA_DVQHNS';
                        DBMS_OUTPUT.put_line(P_SQL_INSERT_DT);
            EXECUTE IMMEDIATE P_SQL_INSERT_DT;
        
         P_SQL_INSERT_DT1:= 'INSERT INTO BM59_ND31_TEMP(MA_DVQHNS,MA_XA,DT_BSCDNS,DT_BSMT)
                        SELECT HT.MA_DVQHNS, HT.MA_HUYEN
                        , NVL(HT.DT_BSCDNS,0) as DT_BSCDNS, NVL(HT.DT_BSMT,0) as DT_BSMT
                        FROM
                        (
                        SELECT A.MA_DVQHNS, DV.MA_HUYEN
                        ,NVL(SUM (CASE WHEN (( (MA_TKTN like ''9622'' OR  MA_TKTN like ''9623'') AND MA_NGANHKT like ''346''))
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS DT_BSCDNS
                        ,NVL(SUM (CASE WHEN (( (MA_TKTN like ''9622'' OR  MA_TKTN like ''9623'') AND MA_NGANHKT like ''356''))
                                THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS DT_BSMT
                        FROM PHA_DUTOAN A LEFT JOIN SYS_DVQHNS DV ON A.MA_DVQHNS = DV.MA_DVQHNS_CHA
                        WHERE A.NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')     
                        and A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        and A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
                        AND A.MA_DVQHNS LIKE ''2%''
                        AND NOT A.MA_CAP like ''1'' AND NOT A.MA_CHUONG LIKE ''000'' AND NOT A.MA_DIABAN IN(''274'',''56'',''60'',''24'',''10939'') '
                        || P_CT
                        || ' GROUP BY A.MA_DVQHNS,DV.MA_HUYEN ORDER BY A.MA_DVQHNS
                        ) HT 
                        WHERE 1=1 ORDER BY HT.MA_DVQHNS';
                        DBMS_OUTPUT.put_line(P_SQL_INSERT_DT1);
            EXECUTE IMMEDIATE P_SQL_INSERT_DT1;
            
              QUERY_STR:= 'UPDATE BM59_ND31 SET MA_DBHC_CHA = 27, MA_DBHC = 256, TEN_DBHC = ''Thành phố Bắc Ninh'' WHERE MA_DBHC_CHA IS NULL AND MA_DBHC = 27';
              QUERY_STR1:='UPDATE BM59_ND31 SET MA_DBHC_CHA = 258, MA_DBHC = ''09208'', TEN_DBHC =''Xã Thụy Hòa'' WHERE MA_DBHC_CHA = 27 AND MA_DBHC = 258 AND MA_DVQHNS = 1074387';
              EXECUTE IMMEDIATE QUERY_STR;
            --DBMS_OUTPUT.put_line(QUERY_STR);
              EXECUTE IMMEDIATE QUERY_STR1;
              QUERY_STR2:='SELECT A.MA_DBHC_CHA,A.MA_DBHC,A.TEN_DBHC,A.MA_DVQHNS,SUM(A.QT_BSCDNS) AS QT_BSCDNS, SUM(A.QT_VTN) AS QT_VTN, SUM(A.QT_VNN) AS QT_VNN, SUM(A.QT_VCTMT) AS QT_VCTMT ,SUM(B.DT_BSCDNS) AS DT_BSCDNS, SUM(B.DT_BSMT) AS DT_BSMT FROM BM59_ND31 A LEFT JOIN BM59_ND31_TEMP B ON B.MA_XA = A.MA_DBHC AND B.MA_DVQHNS = A.MA_DVQHNS GROUP BY A.MA_DBHC_CHA,A.MA_DBHC,A.TEN_DBHC,A.MA_DVQHNS ORDER BY A.MA_DBHC_CHA';
BEGIN
 EXECUTE IMMEDIATE QUERY_STR2;
OPEN cur FOR QUERY_STR2;
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
 