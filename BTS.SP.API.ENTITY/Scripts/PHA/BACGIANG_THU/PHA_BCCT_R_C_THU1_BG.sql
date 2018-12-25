create or replace PROCEDURE PHA_BCCT_R_C_THU1_BG (P_CAP IN NVARCHAR2,P_USER_NAME IN NVARCHAR2,P_MA_DBHC IN NVARCHAR2,P_LOAI_BAOCAO IN VARCHAR2, P_LOAI_DL IN VARCHAR2,MABAOCAO IN VARCHAR2,TABLENAME_TH IN VARCHAR2,P_TABLENAME IN VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,P_CONGTHUC IN NVARCHAR2, DONVI_TIEN NUMBER, cur OUT SYS_REFCURSOR) IS
   QUERY_STR  VARCHAR2(32767);    
   P_MA_BAOCAO VARCHAR2(100);
   P_SQL_CREATE_TABLE_TH  VARCHAR2(32767);  
   P_SQL_CREATE_TABLE  VARCHAR2(32767);  
   v_SQL_Clo  VARCHAR2(32767);  
   v_SQL_Clo_2  VARCHAR2(32767);  
   INSERT_QUERRY_CHI  VARCHAR2(32767);  
   INSERT_QUERRY_THU  VARCHAR2(32767);  
   TABLE_PHA_DT_CHI  VARCHAR2(100); 
   TABLE_PHA_DT_THU  VARCHAR2(100);   
   TABLE_PHA_DT_DUTOAN  VARCHAR2(100);  
   INSERT_QUERRY_DUTOAN  VARCHAR2(32767);
   SQL_QUERRY VARCHAR2(32767);
   N_COUNT NUMBER(17,4):=0;
   N_COUNT_2 NUMBER(17,4):=0;
   P_DONVI_TIEN NUMBER(17,4):=1;
   GIA_TRI_CLO NUMBER(18,2):=0;
   sx_dv VARCHAR2(5); 
   P_CT VARCHAR2(32767); 
   P_SUM VARCHAR2(32767);
   P_SUM_U VARCHAR2(32767);
   P_WHERE_C_R VARCHAR2(32767); 
   P_SELECT_1 VARCHAR2(32767);
   P_SELECT_2 VARCHAR2(32767);
   P_CT_DV clob;
   P_INSERT_C_R clob;
   P_UPDATE_SUM VARCHAR2(32767);
   P_UPDATE_SUBTRACT VARCHAR2(32767);
   P_SUBTRACT_U VARCHAR2(32767);
   P_TABLENAME_TH VARCHAR2(100);
   P_SUM_DV VARCHAR2(32767);
   P_WHERE_DATE_HL_TU VARCHAR2(100); P_WHERE_DATE_HL_DEN VARCHAR2(100); P_WHERE_DATE_KS_TU VARCHAR2(100); P_WHERE_DATE_KS_DEN VARCHAR2(100);
   P_CT_WHERE_DATE_HL_TU VARCHAR2(100); P_CT_WHERE_DATE_HL_DEN VARCHAR2(100);
   V_CONGTHUC_DUTOAN_QUYETTOAN clob;
   V_TU_NAM NUMBER := TO_NUMBER(to_char(TUNGAY_HL,'yyyy'));
   V_NGAY_HL NUMBER := TO_NUMBER(to_char(DENNGAY_HL,'dd'));
   V_THANG_HL NUMBER := TO_NUMBER(to_char(DENNGAY_HL,'MM'));
   V_THANG_HL_UOC NUMBER := V_THANG_HL + 1;
   P_DENNGAY_HL DATE;
   P_SELECT_DBHC VARCHAR2(32767);
   P_DELETE VARCHAR2(32767);
     BEGIN
     IF(TABLENAME_TH IS NULL OR LENGTH(TABLENAME_TH)<=0) THEN P_TABLENAME_TH:='PHA_TH_MLNS'; 
     ELSE P_TABLENAME_TH:=TABLENAME_TH;
     END IF;

     IF(DONVI_TIEN IS NULL OR DONVI_TIEN= 0) THEN P_DONVI_TIEN:= 1; 
     ELSE P_DONVI_TIEN:=DONVI_TIEN;
     END IF;

     -- TAO TABLE DE TONG HOP DU LIEU
        P_MA_BAOCAO:=''''||MABAOCAO||'''';   
        IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
            SELECT STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) INTO P_CT FROM dual;
        END IF;
        IF(P_CT IS NULL) THEN P_CT:='1=1'; 
        ELSIF(P_CT IS NOT NULL) THEN P_CT:=P_CT;
        END IF;
        P_SQL_CREATE_TABLE_TH := 'CREATE TABLE '||P_TABLENAME_TH||'(
        LOAI_CHITIEU NUMBER,MA_TKTN NVARCHAR2(100), MA_DIABAN NVARCHAR2(100), MA_CAP NVARCHAR2(100),MA_CHUONG NVARCHAR2(100),MA_NGANHKT NVARCHAR2(100),MA_LOAI NVARCHAR2(100),
        MA_TIEUMUC NVARCHAR2(100), MA_MUC NVARCHAR2(100), MA_TIEUNHOM NVARCHAR2(100),MA_CTMTQG NVARCHAR2(100),MA_KBNN NVARCHAR2(100), NGAY_HIEU_LUC DATE, NGAY_KET_SO DATE,LOAI_DU_TOAN NVARCHAR2(100),
        MA_NGUON_NSNN NVARCHAR2(100),MA_DVQHNS NVARCHAR2(100), MA_NVC NVARCHAR2(100), GIA_TRI_HACH_TOAN NUMBER)SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)';                      

       -- table PHA_HACHTOAN_THU              
        TABLE_PHA_DT_THU:='PHA_HACHTOAN_THU';
        SQL_QUERRY := 'SELECT 1,MA_TKTN,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI,MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,TO_DATE(to_char(NGAY_HIEU_LUC,''ddMMyyyy''), ''ddMMyyyy''),TO_DATE (to_char(NGAY_KET_SO,''ddMMyyyy''), ''ddMMyyyy''),ATTRIBUTE8
        ,SUM (GIA_TRI_HACH_TOAN) FROM '||TABLE_PHA_DT_THU||' VC 
         GROUP BY  MA_TKTN,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI,MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN, MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,NGAY_HIEU_LUC,NGAY_KET_SO,ATTRIBUTE8';     
        INSERT_QUERRY_THU := 'INSERT INTO '||P_TABLENAME_TH||'(LOAI_CHITIEU,MA_TKTN ,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI, MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,NGAY_HIEU_LUC,NGAY_KET_SO,LOAI_DU_TOAN,GIA_TRI_HACH_TOAN)('||SQL_QUERRY||')';

        -- table PHA_HACHTOAN_CHI
        TABLE_PHA_DT_CHI:='PHA_HACHTOAN_CHI';
        SQL_QUERRY := 'SELECT 2,MA_TKTN ,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI,MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,substr(MA_CTMTQG,2,length(MA_CTMTQG)),MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,TO_DATE(to_char(NGAY_HIEU_LUC,''ddMMyyyy''), ''ddMMyyyy''),TO_DATE (to_char(NGAY_KET_SO,''ddMMyyyy''), ''ddMMyyyy''),ATTRIBUTE8
        ,SUM (GIA_TRI_HACH_TOAN) FROM '||TABLE_PHA_DT_CHI||' VC 
         GROUP BY  MA_TKTN,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI,MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,NGAY_HIEU_LUC,NGAY_KET_SO,ATTRIBUTE8';   
        INSERT_QUERRY_CHI := 'INSERT INTO '||P_TABLENAME_TH||'(LOAI_CHITIEU,MA_TKTN ,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI, MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,NGAY_HIEU_LUC,NGAY_KET_SO,LOAI_DU_TOAN,GIA_TRI_HACH_TOAN)('||SQL_QUERRY||')';

        -- table PHA_DUTOAN
        TABLE_PHA_DT_DUTOAN:='PHA_DUTOAN';
        SQL_QUERRY := 'SELECT 3,MA_TKTN ,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI,MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,substr(MA_CTMTQG,2,length(MA_CTMTQG)),MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,TO_DATE(to_char(NGAY_HIEU_LUC,''ddMMyyyy''), ''ddMMyyyy''),TO_DATE (to_char(NGAY_KET_SO,''ddMMyyyy''), ''ddMMyyyy''),ATTRIBUTE8
        ,SUM (GIA_TRI_HACH_TOAN) FROM '||TABLE_PHA_DT_DUTOAN||' VC 
         GROUP BY  MA_TKTN,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI,MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,NGAY_HIEU_LUC,NGAY_KET_SO,ATTRIBUTE8';   
        INSERT_QUERRY_DUTOAN := 'INSERT INTO '||P_TABLENAME_TH||'(LOAI_CHITIEU,MA_TKTN ,MA_DIABAN,MA_CAP,MA_CHUONG,MA_NGANHKT,MA_LOAI, MA_TIEUMUC,MA_MUC,MA_TIEUNHOM,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,MA_DVQHNS,MA_NVC,NGAY_HIEU_LUC,NGAY_KET_SO,LOAI_DU_TOAN,GIA_TRI_HACH_TOAN)('||SQL_QUERRY||')';

    BEGIN
        SELECT COUNT(*)  INTO N_COUNT  FROM ALL_TAB_COLUMNS  WHERE TABLE_NAME = UPPER(P_TABLENAME_TH);
        EXCEPTION WHEN OTHERS THEN N_COUNT:=0;
    END;
    IF(N_COUNT IS NULL OR N_COUNT<=0) THEN
    BEGIN
        EXECUTE IMMEDIATE P_SQL_CREATE_TABLE_TH;  
        EXECUTE IMMEDIATE INSERT_QUERRY_THU; 
        EXECUTE IMMEDIATE INSERT_QUERRY_CHI;  
        EXECUTE IMMEDIATE INSERT_QUERRY_DUTOAN;   
    END;
    END IF;
--    IF(N_COUNT>0) THEN
--    BEGIN
--        EXECUTE IMMEDIATE 'TRUNCATE TABLE ' ||P_TABLENAME_TH;  
--        EXECUTE IMMEDIATE INSERT_QUERRY_THU; 
--        EXECUTE IMMEDIATE INSERT_QUERRY_CHI;  
--        EXECUTE IMMEDIATE INSERT_QUERRY_DUTOAN;
--        
--    END;
--    END IF;

    FOR item IN (SELECT MA_COT FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC)
    LOOP   
        v_SQL_Clo:= v_SQL_Clo || item.MA_COT ||' NUMBER, ';
        v_SQL_Clo_2:= v_SQL_Clo_2 || item.MA_COT ||', ';
        P_SUM_DV:= P_SUM_DV || item.MA_COT ||'=0 AND  ';
    END LOOP;
     P_SUM_DV:= P_SUM_DV || ' 1=1';
    --- table 2
  P_SQL_CREATE_TABLE := 'CREATE TABLE '||P_TABLENAME||'(SAPXEP  NVARCHAR2(10) , CT NVARCHAR2(2000),CAP NUMBER(10,0), INDAM NUMBER(10,0), INNGHIENG NUMBER(10,0),HIENTHI NVARCHAR2(1), TRANG_THAI NVARCHAR2(10),LOAI_CHITIEU NUMBER(10,0),MA_CHITIEU NVARCHAR2(50),MA_CHITIEU_2 NVARCHAR2(50),TEN_CHITIEU NVARCHAR2(500),' 
                        ||v_SQL_Clo||' STT NVARCHAR2(100), USERNAME NVARCHAR2(50))SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)';
  /*P_SQL_CREATE_TABLE := 'CREATE GLOBAL TEMPORARY TABLE  '||P_TABLENAME||'(SAPXEP  NVARCHAR2(10) , CT NVARCHAR2(2000),CAP NUMBER(10,0), INDAM NUMBER(10,0), INNGHIENG NUMBER(10,0),HIENTHI NVARCHAR2(1), TRANG_THAI NVARCHAR2(10),LOAI_CHITIEU NUMBER(10,0),MA_CHITIEU NVARCHAR2(50),MA_CHITIEU_2 NVARCHAR2(50),TEN_CHITIEU NVARCHAR2(500),' 
                        ||v_SQL_Clo||' STT NVARCHAR2(100))ON COMMIT PRESERVE ROWS';*/
     BEGIN
          SELECT COUNT(*)  INTO N_COUNT  FROM ALL_TAB_COLUMNS  WHERE TABLE_NAME = UPPER(P_TABLENAME);
          EXCEPTION WHEN OTHERS THEN N_COUNT:=0;
      END;

      IF(N_COUNT IS NULL OR N_COUNT<=0) THEN
      BEGIN

          EXECUTE IMMEDIATE P_SQL_CREATE_TABLE;  
      END;
      END IF;
       IF(TO_NUMBER(to_char(TUNGAY_HL,'yyyy')) <> TO_NUMBER(to_char(DENNGAY_HL,'yyyy'))) THEN 
       P_DENNGAY_HL  := TO_DATE(''||V_NGAY_HL||'-'||V_THANG_HL||'-'||V_TU_NAM,'dd-MM-yyyy');
       ELSE 
       P_DENNGAY_HL := DENNGAY_HL;
       END IF;
        P_WHERE_DATE_HL_TU:= ' AND NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';
        P_WHERE_DATE_HL_DEN:= ' AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(P_DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';        
        P_WHERE_DATE_KS_TU:= ' AND NGAY_KET_SO >= TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')'; 
        P_WHERE_DATE_KS_DEN:= ' AND NGAY_KET_SO <= TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')';
        P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN || P_SELECT_DBHC;
        ELSE
        P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN;
        END IF;
        
      -- TAO TABLE 2
    --B2 XU LY DU LIEU TRONG DM CHI TIEU DUOC DAY VAO BAO CAO
    P_DELETE:= 'DELETE ' ||P_TABLENAME|| ' WHERE USERNAME = '''||P_USER_NAME||'''';
    EXECUTE IMMEDIATE P_DELETE;
    FOR item_R IN (SELECT ID,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAICHITIEU,MA_CHITIEU,TEN_CHITIEU,CT_QT_W,CT_DT_W,CT_DH_W,TUNGAY,DENNGAY,CONGTHUC_DH_WHERE, MA_DBHC FROM V_DMCTBC  WHERE MA_BAOCAO = MABAOCAO AND TUNGAY <= TO_DATE (''||TUNGAY_HL||'','dd-MM-yy') AND DENNGAY >= TO_DATE (''||P_DENNGAY_HL||'','dd-MM-yy') AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY SAPXEP ASC)
    LOOP      
        --DBMS_OUTPUT.put_line('item_R '||item_R.MA_CHITIEU);
        IF(item_R.TRANG_THAI IS NULL OR  item_R.TRANG_THAI='C') THEN  
        BEGIN
                P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(USERNAME,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,MA_CHITIEU,MA_CHITIEU_2,'||v_SQL_Clo_2||'TEN_CHITIEU)';
                P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''||P_USER_NAME||''','''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','|| item_R.HIENTHI ||',''C'','|| NVL(item_R.LOAICHITIEU,0) ||',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC)
                    LOOP
                    
                    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
                     SELECT STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) INTO P_CT FROM dual;
                     END IF;
        
                IF(P_CONGTHUC IS NULL OR P_CT = '') THEN P_CT:='1=1'; 
                END IF;
                IF(item_C.MA_COT = 'NS_HUYEN' OR item_C.MA_COT= 'NS_XA') THEN
                 P_WHERE_DATE_HL_TU:= ' AND NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';
                 P_WHERE_DATE_HL_DEN:= ' AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';        
                 P_WHERE_DATE_KS_TU:= ' AND NGAY_KET_SO >= TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')'; 
                 P_WHERE_DATE_KS_DEN:= ' AND NGAY_KET_SO <= TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')';
                 P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
                 IF(P_SELECT_DBHC IS NOT NULL) THEN
                 P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN || P_SELECT_DBHC;
                 ELSE
                 P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN;
                 END IF;
                 ELSIF(item_C.MA_COT = 'UOC_NS_HUYEN' OR item_C.MA_COT= 'UOC_NS_XA') THEN
                 P_WHERE_DATE_HL_TU:= ' AND NGAY_HIEU_LUC >= TO_DATE ('''|| '01'||V_THANG_HL_UOC ||V_TU_NAM|| ''', ''ddMMyyyy'')';
                 P_WHERE_DATE_HL_DEN:= ' AND NGAY_HIEU_LUC <= LAST_DAY(TO_DATE ('''|| '01'||V_THANG_HL_UOC||V_TU_NAM|| ''', ''ddMMyyyy''))';        
                 P_WHERE_DATE_KS_TU:= ' AND NGAY_KET_SO >= TO_DATE ('''|| '01'||V_THANG_HL_UOC||V_TU_NAM|| ''', ''ddMMyyyy'')'; 
                 P_WHERE_DATE_KS_DEN:= ' AND NGAY_KET_SO <= LAST_DAY(TO_DATE ('''|| '01'||V_THANG_HL_UOC ||V_TU_NAM|| ''', ''ddMMyyyy''))';
                 P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
                 IF(P_SELECT_DBHC IS NOT NULL) THEN
                 P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN || P_SELECT_DBHC;
                 ELSE
                 P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN;
                 END IF;
                 END IF;
                    
                    BEGIN
                        IF (item_C.MA_COT = 'DTT') THEN
                         SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '2' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                         ELSIF (item_C.MA_COT = 'DTH') THEN
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '3' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        ELSIF (item_C.MA_COT = 'DTX') THEN
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '4' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        ELSE 
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= item_C.MA_COT AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        END IF;

                            IF GIA_TRI_CLO IS NULL THEN GIA_TRI_CLO:=0; 
                            END IF;

                           -- DBMS_OUTPUT.put_line('GIA_TRI_CLO '||GIA_TRI_CLO);
                        END;

                        IF(UPPER(P_LOAI_BAOCAO) = 'DH') THEN 
                        IF(item_C.TRANG_THAI='A') THEN V_CONGTHUC_DUTOAN_QUYETTOAN:=item_R.CT_DH_W;END IF;-- CONG THỨC CỦA ĐIỀU HÀNH
                        IF(item_C.TRANG_THAI='B')THEN V_CONGTHUC_DUTOAN_QUYETTOAN:=item_R.CT_DT_W; END IF;-- CONG THỨC CỦA DỰ TOÁN 
                        END IF;
                        IF(UPPER(P_LOAI_BAOCAO) = 'QT') THEN 
                        IF(item_C.TRANG_THAI='A') THEN V_CONGTHUC_DUTOAN_QUYETTOAN:=item_R.CT_QT_W;END IF;-- CONG THỨC CỦA QUYẾT TOÁN
                        IF(item_C.TRANG_THAI='B')THEN V_CONGTHUC_DUTOAN_QUYETTOAN:=item_R.CT_DT_W; END IF;-- CONG THỨC CỦA DỰ TOÁN 
                        END IF;

                        IF(GIA_TRI_CLO >0) THEN
                              BEGIN
                                P_INSERT_C_R:=P_INSERT_C_R || GIA_TRI_CLO ||',';
                               -- DBMS_OUTPUT.put_line ('P_INSERT_C_R:=' ||  P_INSERT_C_R );
                              END;
                          END IF;
                          IF(GIA_TRI_CLO <=0) THEN
                                begin
                                  if(P_LOAI_DL IS NULL OR UPPER(P_LOAI_DL)='ALL')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND '; END IF;
                                  if(UPPER(P_LOAI_DL)='CANDOI')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND (LOAI_CHITIEU=' || item_R.LOAICHITIEU ||' OR LOAI_CHITIEU=3) AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='T')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=1 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='C')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=2 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)>0) THEN P_WHERE_C_R:= '(' || TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:='1=1'; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:=TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN); END IF;
                                  if(LENGTH(P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')'; END IF; 
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 OR V_CONGTHUC_DUTOAN_QUYETTOAN IS NULL) THEN P_SUM:='0'; END IF;
                                    P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';
                                end;
                            END IF;
                     END LOOP;
                     P_INSERT_C_R:=P_INSERT_C_R || '''' || item_R.TEN_CHITIEU || '''' ||')';
--                      DBMS_OUTPUT.ENABLE (buffer_size => NULL);
--                   DBMS_OUTPUT.put_line ('t:=' ||  P_INSERT_C_R );
                        EXECUTE IMMEDIATE P_INSERT_C_R;                 
            END;
        END IF;
        IF INSTR(item_R.TRANG_THAI, 'S', 1)>0  THEN
        BEGIN
                  P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(USERNAME,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,CT,MA_CHITIEU, MA_CHITIEU_2,'||v_SQL_Clo_2||' TEN_CHITIEU)';
                  P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| P_USER_NAME ||''','''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','''|| item_R.HIENTHI ||''',''' || item_R.TRANG_THAI  ||''','|| NVL(item_R.LOAICHITIEU,0) ||','''  ||  item_R.CONGTHUC_DH_WHERE ||  ''',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                  FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC)
                    LOOP
                    BEGIN
                         IF (item_C.MA_COT = 'DTT') THEN
                         SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '2' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                         --DBMS_OUTPUT.put_line('item_C '||item_C.MA_COT);
                         ELSIF (item_C.MA_COT = 'DTH') THEN
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '3' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        ELSIF (item_C.MA_COT = 'DTX') THEN
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '4' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        ELSE 
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= item_C.MA_COT AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        END IF;

                            IF GIA_TRI_CLO IS NULL THEN GIA_TRI_CLO:=0; 
                            END IF;

                           -- DBMS_OUTPUT.put_line('GIA_TRI_CLO '||GIA_TRI_CLO);
                        END;
                        IF(GIA_TRI_CLO >0) THEN
                              BEGIN
                                P_INSERT_C_R:=P_INSERT_C_R || GIA_TRI_CLO ||',';
                               -- DBMS_OUTPUT.put_line ('P_INSERT_C_R:=' ||  P_INSERT_C_R );
                              END;
                          END IF;
                          IF(GIA_TRI_CLO <=0) THEN
                                begin
                                  if(P_LOAI_DL IS NULL OR UPPER(P_LOAI_DL)='ALL')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND '; END IF;
                                  if(UPPER(P_LOAI_DL)='CANDOI')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND (LOAI_CHITIEU=' || item_R.LOAICHITIEU ||' OR LOAI_CHITIEU=3) AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='T')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=1 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='C')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=2 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)>0) THEN P_WHERE_C_R:= '(' || TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:='1=1'; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:=TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN); END IF;
                                  if(LENGTH(P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')'; END IF; 
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 OR V_CONGTHUC_DUTOAN_QUYETTOAN IS NULL) THEN P_SUM:='0'; END IF;
                                    P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';
                                end;
                            END IF;
                          END LOOP;
                  P_INSERT_C_R:=P_INSERT_C_R || '''' || item_R.TEN_CHITIEU || '''' ||')';
--                  DBMS_OUTPUT.ENABLE (buffer_size => NULL);
--                   DBMS_OUTPUT.put_line ('t:=' ||  P_INSERT_C_R );
--DBMS_OUTPUT.put_line ('t:=' ||  P_INSERT_C_R );
                  EXECUTE IMMEDIATE P_INSERT_C_R;


         END;
        END IF;
        IF INSTR(item_R.TRANG_THAI, 'T', 1)>0 THEN
        BEGIN
                  P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(USERNAME,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,CT,MA_CHITIEU, MA_CHITIEU_2,'||v_SQL_Clo_2||' TEN_CHITIEU)';
                  P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| P_USER_NAME ||''','''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','''|| item_R.HIENTHI ||''',''' || item_R.TRANG_THAI  ||''','|| NVL(item_R.LOAICHITIEU,0) ||','''  ||  item_R.CONGTHUC_DH_WHERE ||  ''',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                   FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC)
                    LOOP
                         BEGIN
                          IF (item_C.MA_COT = 'DTT') THEN
                         SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '2' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                         --DBMS_OUTPUT.put_line('item_C '||item_C.MA_COT);
                         ELSIF (item_C.MA_COT = 'DTH') THEN
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '3' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        ELSIF (item_C.MA_COT = 'DTX') THEN
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= 'DT' AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND CAP = '4' AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        ELSE 
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT= item_C.MA_COT AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''))
                            AND MA_DBHC_USER = ''||P_MA_DBHC||'';
                        END IF;

                            IF GIA_TRI_CLO IS NULL THEN GIA_TRI_CLO:=0; 
                            END IF;

                           -- DBMS_OUTPUT.put_line('GIA_TRI_CLO '||GIA_TRI_CLO);
                        END;
                        IF(GIA_TRI_CLO >0) THEN
                              BEGIN
                                P_INSERT_C_R:=P_INSERT_C_R || GIA_TRI_CLO ||',';
                               -- DBMS_OUTPUT.put_line ('P_INSERT_C_R:=' ||  P_INSERT_C_R );
                              END;
                          END IF;
                          IF(GIA_TRI_CLO <=0) THEN
                                begin
                                  if(P_LOAI_DL IS NULL OR UPPER(P_LOAI_DL)='ALL')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND '; END IF;
                                  if(UPPER(P_LOAI_DL)='CANDOI')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND (LOAI_CHITIEU=' || item_R.LOAICHITIEU ||' OR LOAI_CHITIEU=3) AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='T')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=1 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='C')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=2 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)>0) THEN P_WHERE_C_R:= '(' || TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:='1=1'; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:=TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN); END IF;
                                  if(LENGTH(P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')'; END IF; 
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 OR V_CONGTHUC_DUTOAN_QUYETTOAN IS NULL) THEN P_SUM:='0'; END IF;
                                    P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';
                                end;
                            END IF;
                          END LOOP;
                  P_INSERT_C_R:=P_INSERT_C_R || '''' || item_R.TEN_CHITIEU || '''' ||')';
                  EXECUTE IMMEDIATE P_INSERT_C_R;

        END;
        END IF;
        END LOOP; 
        --B2-2 XU LY DU LIEU DV, NEU GAP TRANG THAI=DV THI FRO ALL SYS_DVQHNS KET HOI FOR CLOUM DE INSER DU LIEU VAO TABLE
         BEGIN
            SELECT COUNT(*) INTO N_COUNT_2 FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='DV';
            SELECT  STT  INTO sx_dv FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='DV';
            SELECT CONGTHUC_WHERE  INTO P_CT_DV FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='DV';
            EXCEPTION WHEN OTHERS THEN N_COUNT_2:=0;
        END;
        IF(N_COUNT_2>0) THEN
            N_COUNT_2:=0;
            N_COUNT:=TO_NUMBER(sx_dv)+1;
            BEGIN
                  P_INSERT_C_R:='';
                  FOR item_DV IN (SELECT MA_DVQHNS,TEN_DVQHNS, P_CT_DV ||  ('MA_DVQHNS= ''' || MA_DVQHNS ||'''' ) AS CONGTHUC_WHERE FROM SYS_DVQHNS WHERE TRANG_THAI='A' AND MA_TINH LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY MA_DVQHNS ASC)
                  LOOP
                    begin
                    N_COUNT_2:=N_COUNT_2+1;
                      P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(USERNAME,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,MA_CHITIEU,'||v_SQL_Clo_2||'TEN_CHITIEU)';
                      P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| P_USER_NAME ||''','||N_COUNT_2||','||N_COUNT||',0,0,0,1,''DV_C'',0,''' || item_DV.MA_DVQHNS ||''',';
                          FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC)
                            LOOP   
                                begin
                                P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0) FROM '||P_TABLENAME_TH||' WHERE ';
                                if((LENGTH (item_C.CONGTHUC_WHERE)>0 and LENGTH (item_DV.CONGTHUC_WHERE)<=0) ) THEN P_WHERE_C_R:= '(' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                if((LENGTH (item_C.CONGTHUC_WHERE)>0 and LENGTH (item_DV.CONGTHUC_WHERE)>0) ) THEN P_WHERE_C_R:='(' || TRIM(item_DV.CONGTHUC_WHERE) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                if(LENGTH (P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')';END IF;
                                P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';    
                                end;
                            END LOOP; 
                      P_INSERT_C_R:=P_INSERT_C_R || '''' || item_DV.TEN_DVQHNS || '''' ||')';

                     EXECUTE IMMEDIATE P_INSERT_C_R; 
                  end; 
                  END LOOP; 

            END;
        END IF;
        
        --B2-3 XU LY DU LIEU DV, NEU GAP TRANG THAI=DV1 THI FRO ALL SYS_DVQHNS KET HOI FOR CLOUM DE INSER DU LIEU VAO TABLE
        N_COUNT:=0;
        N_COUNT_2:=0;
        sx_dv:='';
        P_CT_DV:='';
         BEGIN
            SELECT COUNT(*) INTO N_COUNT_2 FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='DV1';
            SELECT  STT  INTO sx_dv FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='DV1';
            SELECT CONGTHUC_WHERE  INTO P_CT_DV FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='DV1';
            EXCEPTION WHEN OTHERS THEN N_COUNT_2:=0;
        END;
        IF(N_COUNT_2>0) THEN
            N_COUNT_2:=0;
            N_COUNT:=TO_NUMBER(sx_dv)+1;
            BEGIN
                  P_INSERT_C_R:='';
                  FOR item_DV IN (SELECT MA_DVQHNS,TEN_DVQHNS, P_CT_DV ||  ('MA_DVQHNS= ''' || MA_DVQHNS ||'''' ) AS CONGTHUC_WHERE FROM SYS_DVQHNS WHERE TRANG_THAI='A' AND MA_TINH LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY MA_DVQHNS ASC)
                  LOOP
                    begin
                    N_COUNT_2:=N_COUNT_2+1;
                      P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(USERNAME,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,MA_CHITIEU,'||v_SQL_Clo_2||'TEN_CHITIEU)';
                      P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| P_USER_NAME ||''','||N_COUNT_2||','||N_COUNT||',0,0,0,1,''DV_C1'',0,''' || item_DV.MA_DVQHNS ||''',';
                          FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC)
                            LOOP   
                                begin
                                P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0) FROM '||P_TABLENAME_TH||' WHERE ';
                                if((LENGTH (item_C.CONGTHUC_WHERE)>0 and LENGTH (item_DV.CONGTHUC_WHERE)<=0) ) THEN P_WHERE_C_R:= '(' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                if((LENGTH (item_C.CONGTHUC_WHERE)>0 and LENGTH (item_DV.CONGTHUC_WHERE)>0) ) THEN P_WHERE_C_R:='(' || TRIM(item_DV.CONGTHUC_WHERE) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                if(LENGTH (P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')';END IF;
                                P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';    
                                end;
                            END LOOP; 
                      P_INSERT_C_R:=P_INSERT_C_R || '''' || item_DV.TEN_DVQHNS || '''' ||')';

                     EXECUTE IMMEDIATE P_INSERT_C_R; 
                  end; 
                  END LOOP; 

            END;
        END IF;



-- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 
    P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';  
                 --DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 



-- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 1
	 P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S1'' AND A.USERNAME = '''||P_USER_NAME||'''';
   -- DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

      --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T'' AND USERNAME = '''||P_USER_NAME||''' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)),'; 
                 --DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 


       --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T1 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T1'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T1'' AND USERNAME = '''||P_USER_NAME||''' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T1'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T1:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

        --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T2 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T2'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T2'' AND USERNAME = '''||P_USER_NAME||''' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T2'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T2:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

  --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 2
      P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:= P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S2'' AND A.USERNAME = '''||P_USER_NAME||'''';
      --DBMS_OUTPUT.put_line ('T6:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

      --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 3
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S3'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 
       --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 4
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S4'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

       --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 5
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S5''  AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

        --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T3 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T3''  AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T3''  AND USERNAME = '''||P_USER_NAME||'''';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T3'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T3:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

             --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 6
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S6'' AND USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 


          --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 7
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S7'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

       --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T4 (khác loại chỉ tiêu)
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T4'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T4'' AND USERNAME = '''||P_USER_NAME||'''';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.USERNAME = B.USERNAME)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T4'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T4:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

         --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T5 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T5'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T5'' AND USERNAME = '''||P_USER_NAME||''' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T5'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

        --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T6(khác loại chỉ tiêu)
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T6'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') + 4 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T6'' AND USERNAME = '''||P_USER_NAME||'''';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP AND A.USERNAME = B.USERNAME)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T6'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T6:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 


      --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T7(khác loại chỉ tiêu)
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T7'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) AND CAP IN (CAP) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T7'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2)';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP AND A.USERNAME = B.USERNAME)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T7'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 


      --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T8(khác loại chỉ tiêu)
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T8'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T8'' AND USERNAME = '''||P_USER_NAME||'''';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||')AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP AND A.USERNAME = B.USERNAME)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T8'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T8:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

             --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 8(khac loai chi tieu)
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.USERNAME = B.USERNAME),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S8'' AND A.USERNAME = '''||P_USER_NAME||'''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM;

            --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T9()
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T9'' AND USERNAME = '''||P_USER_NAME||''' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T9'' AND USERNAME = '''||P_USER_NAME||'''';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.USERNAME = B.USERNAME)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU AND A.USERNAME = B.USERNAME)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T9'' AND A.USERNAME = '''||P_USER_NAME||'''';
       --DBMS_OUTPUT.put_line ('T9:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

    -- update row co trang thai =DV=SUM (DV_C_)        
        P_UPDATE_SUM:=''; P_SUM:='';
        P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
        FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM:=P_SUM || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.TRANG_THAI=''DV_C''),';                  
            END LOOP;
       P_SUM:= SUBSTR(P_SUM,0,LENGTh(P_SUM)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM ||' WHERE A.TRANG_THAI=''DV''';
       --DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
       EXECUTE IMMEDIATE P_UPDATE_SUM; 
       -- XOA DU LIEU NHUNG ROW CUA DV CO CAC COT =0
       P_UPDATE_SUM:='';
       P_UPDATE_SUM:=' DELETE FROM ' || P_TABLENAME || ' WHERE TRANG_THAI=''DV_C'' AND ' || P_SUM_DV;
       EXECUTE IMMEDIATE P_UPDATE_SUM; 

 -- update row co trang thai =DV1=SUM (DV_C1_)        
        P_UPDATE_SUM:=''; P_SUM:='';
        P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
        FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI = 'A' AND MA_DBHC LIKE (SELECT MA_T FROM DM_DBHC WHERE MA_DBHC LIKE ''||P_MA_DBHC||'') ORDER BY STT ASC )
            LOOP   
                  P_SUM:=P_SUM || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.TRANG_THAI=''DV_C1''),';                  
            END LOOP;
       P_SUM:= SUBSTR(P_SUM,0,LENGTh(P_SUM)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM ||' WHERE A.TRANG_THAI=''DV1''';
       EXECUTE IMMEDIATE P_UPDATE_SUM; 
       -- XOA DU LIEU NHUNG ROW CUA DV1 CO CAC COT =0
       P_UPDATE_SUM:='';
       P_UPDATE_SUM:=' DELETE FROM ' || P_TABLENAME || ' WHERE TRANG_THAI=''DV_C1'' AND ' || P_SUM_DV;
       EXECUTE IMMEDIATE P_UPDATE_SUM; 

    -- IN RA MAM HINH  

    BEGIN
    DBMS_OUTPUT.ENABLE(1000000);
    --DBMS_OUTPUT.ENABLE (buffer_size => NULL);
     --DBMS_OUTPUT.put_line ('t:=' ||  QUERY_STR );
      QUERY_STR:='SELECT * FROM ' ||P_TABLENAME||' where 1=1 AND USERNAME = '''||P_USER_NAME||''' order by TO_NUMBER(STT) ASC';
        OPEN cur FOR QUERY_STR;
        EXCEPTION
         WHEN NO_DATA_FOUND
          THEN
            DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
          WHEN OTHERS
          THEN  DBMS_OUTPUT.put_line ('-'); 
    END;	

END PHA_BCCT_R_C_THU1_BG;