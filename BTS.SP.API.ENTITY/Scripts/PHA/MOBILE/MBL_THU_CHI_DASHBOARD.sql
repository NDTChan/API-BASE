create or replace PROCEDURE MBL_THU_CHI_DASHBOARD
IS
    -- Báo cáo B201,B301 -
   QUERY_STR  VARCHAR2(32767);    
   P_MA_BAOCAO VARCHAR2(100);
   P_SQL_CREATE_TABLE_TH  VARCHAR2(32767);  
   P_SQL_CREATE_TABLE_DL  VARCHAR2(32767);  
   P_SQL_CREATE_TABLE  VARCHAR2(32767);  
   v_SQL_Clo  VARCHAR2(32767);  
   v_SQL_Clo_2  VARCHAR2(32767);  
   INSERT_QUERRY_CHI  VARCHAR2(32767);  
   INSERT_QUERRY_THU  VARCHAR2(32767);  
   TABLE_PHA_DT_CHI  VARCHAR2(100); 
   TABLE_PHA_DT_THU  VARCHAR2(100);   
   SQL_QUERRY_CHI VARCHAR2(32767);
   SQL_QUERRY_THU VARCHAR2(32767);
   N_COUNT NUMBER(17,4):=0;
   N_COUNT_2 NUMBER(17,4):=0;
   P_DONVI_TIEN NUMBER(17,4):=1;
   GIA_TRI_CLO NUMBER(17,4):=0;
   sx_ctmtqg VARCHAR2(5); 
   P_CT VARCHAR2(32767); 
   P_SUM VARCHAR2(32767); 
   P_SUM_U VARCHAR2(32767);  
   P_WHERE_C_R VARCHAR2(32767);
   P_SELECT_1 VARCHAR2(32767);
   P_SELECT_2 VARCHAR2(32767); 
   P_CT_CTMTQG clob;
   P_INSERT_C_R clob;
   P_UPDATE_SUM VARCHAR2(32767);
   P_UPDATE_SUBTRACT VARCHAR2(32767);
   P_SUBTRACT_U VARCHAR2(32767);
   P_TABLENAME_TH VARCHAR2(100):='PHA_TH_MLNS';
   P_SUM_CTMTQG VARCHAR2(32767);
   P_WHERE_DATE_HL_TU VARCHAR2(100); P_WHERE_DATE_HL_DEN VARCHAR2(100); P_WHERE_DATE_KS_TU VARCHAR2(100); P_WHERE_DATE_KS_DEN VARCHAR2(100);
   P_CT_WHERE_DATE_HL_TU VARCHAR2(100); P_CT_WHERE_DATE_HL_DEN VARCHAR2(100);TUNGAY_KS DATE; DENNGAY_KS  DATE; TUNGAY_HL DATE; DENNGAY_HL DATE;
   V_CONGTHUC_DUTOAN_QUYETTOAN clob;
    V_TU_NAM NUMBER := TO_NUMBER(to_char(TUNGAY_HL,'yyyy'));
   P_SELECT_DBHC VARCHAR2(32767);
   P_DELETE VARCHAR2(32767);
   TABLENAME_TH VARCHAR2(32767);
   P_TABLENAME VARCHAR2(100):='B301_B201';
   P_TABLENAME_DL VARCHAR2(100):='MBL_B301_B201';
   MABAOCAO  VARCHAR2(100):='B301_B201';
   P_LOAI_BAOCAO VARCHAR2(10):='DH';
   P_LOAI_DL VARCHAR2(10):='CANDOI';
   P_CONGTHUC VARCHAR2(10);
   DONVI_TIEN NUMBER :=1;
   P_MA_DBHC VARCHAR2(32767);
   nam dbms_sql.varchar2_table;
    thang dbms_sql.varchar2_table;
    thangNum dbms_sql.number_table;
    dbhc dbms_sql.varchar2_table;
  P_INSERT VARCHAR2(32767);
  P_UPDATE VARCHAR2(32767);
   CURREN_YEAR NUMBER := TO_NUMBER(to_char(SYSDATE,'yyyy'));
     BEGIN 
     --tạo bảng chứa dữ liệu lên mbl
--    P_SQL_CREATE_TABLE_DL := 'CREATE TABLE '||P_TABLENAME_DL||'(SHKB  NVARCHAR2(10) , NAM NUMBER(10,0), THANG NUMBER(10,0),LK_NSTT NUMBER, LK_NSQH NUMBER, LK_NSPX NUMBER, LKPX NUMBER, LKQH NUMBER, LKTT NUMBER)SEGMENT CREATION IMMEDIATE 
--  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
--  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
--  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)';
--  
--     BEGIN
--          SELECT COUNT(*)  INTO N_COUNT  FROM ALL_TAB_COLUMNS  WHERE TABLE_NAME = UPPER(P_TABLENAME_DL);
--          EXCEPTION WHEN OTHERS THEN N_COUNT:=0;
--      END;
--
--      IF(N_COUNT IS NULL OR N_COUNT<=0) THEN
--      BEGIN
--          EXECUTE IMMEDIATE P_SQL_CREATE_TABLE_DL;  
--      END;
--      END IF;
    nam(1):='2017';
    nam(2):='2018';

    thang(1):='JAN'; thangNum(1):=1;
    thang(2):='FEB'; thangNum(2):=2;
    thang(3):='MAR'; thangNum(3):=3;
    thang(4):='APR'; thangNum(4):=4;
    thang(5):='MAY'; thangNum(5):=5;
    thang(6):='JUN'; thangNum(6):=6;
    thang(7):='JUL'; thangNum(7):=7;
    thang(8):='AUG'; thangNum(8):=8;
    thang(9):='SEP'; thangNum(9):=9;
    thang(10):='OCT'; thangNum(10):=10;
    thang(11):='NOV'; thangNum(11):=11;
    thang(12):='DEC'; thangNum(12):=12;

    dbhc(1):='27';-- bac nhinh
    dbhc(2):='256'; 
    dbhc(3):='258';
    dbhc(4):='259';
    dbhc(5):='260';
    dbhc(6):='261';
    dbhc(7):='262';
    dbhc(8):='263';
    dbhc(9):='264';

     FOR item IN (SELECT MA_COT FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC)
    LOOP   
        v_SQL_Clo:= v_SQL_Clo || item.MA_COT ||' NUMBER, ';
        v_SQL_Clo_2:= v_SQL_Clo_2 || item.MA_COT ||', ';
        P_SUM_CTMTQG:= P_SUM_CTMTQG || item.MA_COT ||'=0 AND  ';
    END LOOP;
     P_SUM_CTMTQG:= P_SUM_CTMTQG || ' 1=1';
      FOR n IN thang.FIRST .. thang.LAST
   LOOP
        FOR m IN dbhc.FIRST .. dbhc.LAST
        LOOP
        P_CT:= '1=1';
                       TUNGAY_KS  := TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                       ----DBMS_OUTPUT.Put_Line(TUNGAY_KS);
                    DENNGAY_KS  :=LAST_DAY(TUNGAY_KS);
                                           ----DBMS_OUTPUT.Put_Line(DENNGAY_KS); 

                    TUNGAY_HL  :=TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                    DENNGAY_HL  :=LAST_DAY(TUNGAY_HL);
                    V_TU_NAM:= CURREN_YEAR;
                    P_DELETE:= 'DELETE FROM PHA_DASHBOARD WHERE NAM ='||CURREN_YEAR||' AND SHKB = '||dbhc(m)||' AND THANG = '||thangNum(n)||'';
                    P_INSERT:='INSERT INTO PHA_DASHBOARD (NAM,SHKB,THANG) VALUES('||CURREN_YEAR||','||dbhc(m)||','||thangNum(n)||')';
                    BEGIN
                        Execute Immediate P_DELETE;
                        Execute Immediate P_INSERT;
                    END;


--     IF(TABLENAME_TH IS NULL OR LENGTH(TABLENAME_TH)<=0) THEN P_TABLENAME_TH:='PHA_TH_MLNS_B301_B201_MBL'; 
--     ELSE P_TABLENAME_TH:=TABLENAME_TH;
--     END IF;

     IF(DONVI_TIEN IS NULL OR DONVI_TIEN= 0) THEN P_DONVI_TIEN:= 1; 
     ELSE P_DONVI_TIEN:=DONVI_TIEN;
     END IF;

     -- TAO TABLE DE TONG HOP DU LIEU
        P_MA_BAOCAO:=''''||MABAOCAO||'''';   
        IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
            SELECT STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) INTO P_CT FROM dual;
        END IF;

        IF(P_CONGTHUC IS NULL OR P_CT = '') THEN P_CT:='1=1'; 
        END IF;
       

--        P_WHERE_DATE_HL_TU:= ' AND NGAY_HIEU_LUC >= TO_DATE ('''|| '0101'||V_TU_NAM ||''', ''ddMMyyyy'')';
--        P_WHERE_DATE_HL_DEN:= ' AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';        
--        P_WHERE_DATE_KS_TU:= ' AND NGAY_KET_SO >= TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')'; 
--        P_WHERE_DATE_KS_DEN:= ' AND NGAY_KET_SO <= TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')';
--        P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN;
     --- table 2
  P_SQL_CREATE_TABLE := 'CREATE TABLE '||P_TABLENAME||'(SAPXEP  NVARCHAR2(10) , CT NVARCHAR2(2000),CAP NUMBER(10,0), INDAM NUMBER(10,0), INNGHIENG NUMBER(10,0),HIENTHI NVARCHAR2(1), TRANG_THAI NVARCHAR2(10),LOAI_CHITIEU NUMBER(10,0),MA_CHITIEU NVARCHAR2(50),MA_CHITIEU_2 NVARCHAR2(50),TEN_CHITIEU NVARCHAR2(500),' 
                        ||v_SQL_Clo||' STT NVARCHAR2(100))SEGMENT CREATION IMMEDIATE 
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



      -- TAO TABLE 2
    --B2 XU LY DU LIEU TRONG DM CHI TIEU DUOC DAY VAO BAO CAO
EXECUTE IMMEDIATE 'TRUNCATE TABLE ' ||P_TABLENAME;
    FOR item_R IN (SELECT ID,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAICHITIEU,MA_CHITIEU,TEN_CHITIEU,CT_QT_W,CT_DT_W,CT_DH_W,TUNGAY,DENNGAY,CONGTHUC_DH_WHERE FROM V_DMCTBC  WHERE MA_BAOCAO = MABAOCAO AND TUNGAY <= TO_DATE (''||TUNGAY_HL||'','dd-MM-yy') AND DENNGAY >= TO_DATE (''||DENNGAY_HL||'','dd-MM-yy') ORDER BY SAPXEP ASC)
    LOOP      
        IF(item_R.TRANG_THAI IS NULL OR  item_R.TRANG_THAI='C') THEN  
        BEGIN
                P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,MA_CHITIEU,MA_CHITIEU_2,'||v_SQL_Clo_2||'TEN_CHITIEU)';
                P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','|| item_R.HIENTHI ||',''C'','|| NVL(item_R.LOAICHITIEU,0) ||',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC)
                LOOP 

                 IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
                     SELECT STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) INTO P_CT FROM dual;
                     END IF;

                IF(P_CONGTHUC IS NULL OR P_CT = '') THEN P_CT:='1=1'; 
                END IF;
                 P_WHERE_DATE_HL_TU:= ' AND NGAY_HIEU_LUC >= TO_DATE ('''|| '0101'||V_TU_NAM ||''', ''ddMMyyyy'')';
                 P_WHERE_DATE_HL_DEN:= ' AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';        
                 P_WHERE_DATE_KS_TU:= ' AND NGAY_KET_SO >= TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')'; 
                 P_WHERE_DATE_KS_DEN:= ' AND NGAY_KET_SO <= TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')';
                 P_MA_DBHC:= 'AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||dbhc(m)||''' OR MA_DBHC_CHA = '''||dbhc(m)||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||dbhc(m)||''' OR MA_DBHC_CHA = '''||dbhc(m)||'''))';
                 P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN || P_MA_DBHC ;
                        IF(item_C.TRANG_THAI='A') THEN V_CONGTHUC_DUTOAN_QUYETTOAN:=item_R.CT_DH_W;END IF;-- CONG THỨC CỦA ĐIỀU HÀNH
                        IF(item_C.TRANG_THAI='B')THEN V_CONGTHUC_DUTOAN_QUYETTOAN:=item_R.CT_DT_W; END IF;-- CONG THỨC CỦA DỰ TOÁN 

                                begin
                                  if(P_LOAI_DL IS NULL OR UPPER(P_LOAI_DL)='ALL')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND '; END IF;
                                  if(UPPER(P_LOAI_DL)='CANDOI')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND LOAI_CHITIEU=' || item_R.LOAICHITIEU ||' AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='T')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=1) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='C')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| P_DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=2) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)>0) THEN P_WHERE_C_R:= '(' || TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:='1=1'; END IF;                                    
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)>0 and LENGTH (item_C.CONGTHUC_WHERE)<=0) THEN P_WHERE_C_R:=TRIM(V_CONGTHUC_DUTOAN_QUYETTOAN); END IF;
                                  if(LENGTH(P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')'; END IF; 
                                  if(LENGTH(V_CONGTHUC_DUTOAN_QUYETTOAN)<=0 OR V_CONGTHUC_DUTOAN_QUYETTOAN IS NULL) THEN P_SUM:='0'; END IF;
                                    P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';
                                end;

                     END LOOP;
                     P_INSERT_C_R:=P_INSERT_C_R || '''' || item_R.TEN_CHITIEU || '''' ||')';
                   --DBMS_OUTPUT.ENABLE (buffer_size => NULL);
                  -- DBMS_OUTPUT.put_line ('t:=' ||  P_INSERT_C_R );

                     --DBMS_OUTPUT.put_line ('ID:=' || item_R.ID);
                        EXECUTE IMMEDIATE P_INSERT_C_R;                 
            END;
        END IF;
        IF INSTR(item_R.TRANG_THAI, 'S', 1)>0  THEN
        BEGIN
                  P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,CT,MA_CHITIEU, MA_CHITIEU_2, TEN_CHITIEU)';
                  P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','''|| item_R.HIENTHI ||''',''' || item_R.TRANG_THAI  ||''','|| NVL(item_R.LOAICHITIEU,0) ||','''  ||  item_R.CONGTHUC_DH_WHERE ||  ''',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                  P_INSERT_C_R:=P_INSERT_C_R || '''' || item_R.TEN_CHITIEU || '''' ||')';

                  EXECUTE IMMEDIATE P_INSERT_C_R;


         END;
        END IF;
        END LOOP; 




-- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 
    P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI='A' ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';  
                 --DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 



-- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 1
	 P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI='A' ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S1''';
   -- DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 


  --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 2
      P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI='A' ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:= P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S2'' ';
      --DBMS_OUTPUT.put_line ('T6:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

      --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 3
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI='A' ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S3'' ';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 
       --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 4
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO AND TRANG_THAI='A' ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S4''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

      P_UPDATE:='';
      P_UPDATE :='UPDATE PHA_DASHBOARD SET
                        T_TI = (SELECT LK_NSTT FROM ' ||P_TABLENAME||' WHERE MA_CHITIEU = ''100000'' AND LOAI_CHITIEU = 1),
                        T_HU = (SELECT LK_NSQH FROM ' ||P_TABLENAME||' WHERE MA_CHITIEU = ''100000'' AND LOAI_CHITIEU = 1),
                        T_XA = (SELECT LK_NSPX FROM ' ||P_TABLENAME||' WHERE MA_CHITIEU = ''100000'' AND LOAI_CHITIEU = 1),
                        C_TI = (SELECT LKPX FROM ' ||P_TABLENAME||' WHERE MA_CHITIEU = ''100000_C'' AND LOAI_CHITIEU = 2),
                        C_HU = (SELECT LKQH FROM ' ||P_TABLENAME||' WHERE MA_CHITIEU = ''100000_C'' AND LOAI_CHITIEU = 2),
                        C_XA = (SELECT LKTT FROM ' ||P_TABLENAME||' WHERE MA_CHITIEU = ''100000_C'' AND LOAI_CHITIEU = 2)
                        WHERE NAM ='||Curren_Year||' AND SHKB = '||dbhc(m)||' AND THANG = '||thangNum(n)||'';
            BEGIN
                --DBMS_OUTPUT.ENABLE (buffer_size => NULL);
              -- DBMS_OUTPUT.put_line ('t:=' ||  P_UPDATE );
          EXECUTE IMMEDIATE P_UPDATE;



            END;
  END LOOP;
END LOOP;


    -- IN RA MAM HINH  

--    BEGIN
--    DBMS_OUTPUT.ENABLE(1000000);
--    --DBMS_OUTPUT.ENABLE (buffer_size => NULL);
--     --DBMS_OUTPUT.put_line ('t:=' ||  QUERY_STR );
--      QUERY_STR:='SELECT * FROM ' ||P_TABLENAME||' where 1=1  order by MA_CHITIEU ASC';
--       DBMS_OUTPUT.put_line ('t:=' ||  QUERY_STR );
--        OPEN cur FOR QUERY_STR;
--        EXCEPTION
--         WHEN NO_DATA_FOUND
--          THEN
--            DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
--          WHEN OTHERS
--          THEN  DBMS_OUTPUT.put_line ('-'); 
--    END;	

END MBL_THU_CHI_DASHBOARD;