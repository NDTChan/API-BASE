create or replace PROCEDURE "MBL_PHA_MAUBS_04" AS
 noidung dbms_sql.varchar2_table;
 congthuc dbms_sql.varchar2_table;
 stt dbms_sql.varchar2_table;
 cmd_sql dbms_sql.varchar2_table;
  nam dbms_sql.varchar2_table;

 QUERY_STR1  CLOB;
  QUERY_STR2  CLOB;

 P_SQL_INSERT VARCHAR2(32767);
 P_CT VARCHAR2(32767);
 P_SELECT_DBHC VARCHAR2(32767);
 TUNGAY_KS DATE;
  DENNGAY_KS DATE;
 TUNGAY_HL DATE;
 DENNGAY_HL DATE;
 DONVI_TIEN number :=1;
 P_MA_DBHC VARCHAR2(10);
  P_CONGTHUC VARCHAR2(10);
  P_DELETE VARCHAR2(32767);
  P_INSERT VARCHAR2(32767);
    thang dbms_sql.varchar2_table;
    thangNum dbms_sql.number_table;
   CURREN_YEAR NUMBER := TO_NUMBER(to_char(SYSDATE,'yyyy'));
 dbhc dbms_sql.varchar2_table;

BEGIN
   
   
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

          congthuc(1) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113)and MA_KBNN = 1111';
           congthuc(2) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1117';
           congthuc(3) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1112';
           congthuc(4) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1115';
           congthuc(5) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1114';
           congthuc(6) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1118';
           congthuc(7) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1116';
           congthuc(8) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1119';
           congthuc(9) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1113';
        
        
           stt(1) := '1111';
           stt(2) := '1117';
           stt(3) := '1112';
           stt(4) := '1115';
           stt(5) := '1114';
           stt(6) := '1118';
           stt(7) := '1116';
           stt(8) := '1119';
           stt(9) := '1113';
        
    dbhc(1):='27';-- bac nhinh
    dbhc(2):='256'; 
    dbhc(3):='258';
    dbhc(4):='259';
    dbhc(5):='260';
    dbhc(6):='261';
    dbhc(7):='262';
    dbhc(8):='263';
    dbhc(9):='264';
--    dbhc(10):='20'; -- lang son
--    dbhc(11):='178';
--    dbhc(12):='180'; 
--    dbhc(13):='181';
--    dbhc(14):='182';
--    dbhc(15):='183';
--    dbhc(16):='184';
--    dbhc(17):='185';
--    dbhc(18):='186';
--    dbhc(19):='187';
--    dbhc(20):='188';
--    dbhc(21):='189';

   nam(1):='2017';
    nam(2):='2018';
   FOR n IN thang.FIRST .. thang.LAST
       LOOP
            FOR m IN dbhc.FIRST .. dbhc.LAST
            LOOP
            P_MA_DBHC := dbhc(m);
             P_CT :='1=1';
             P_SELECT_DBHC := '';
             P_SQL_INSERT := '';
             QUERY_STR1 := '';
                       TUNGAY_KS  := TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                       --DBMS_OUTPUT.Put_Line(TUNGAY_KS);
                    DENNGAY_KS  :=LAST_DAY(TUNGAY_KS);
                                           --DBMS_OUTPUT.Put_Line(DENNGAY_KS);

                    TUNGAY_HL  :=TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                    DENNGAY_HL  :=LAST_DAY(TUNGAY_HL);
                    P_DELETE:= 'DELETE FROM MBL_PHA_T_DIABAN WHERE NAM ='||CURREN_YEAR||' AND SHKB = '||dbhc(m)||' AND THANG = '||thangNum(n)||'';
                    P_INSERT:='INSERT INTO MBL_PHA_T_DIABAN (NAM,SHKB,THANG) VALUES('||CURREN_YEAR||','||dbhc(m)||','||thangNum(n)||')';

--            P_DELETE:= 'DELETE FROM MBL_PHA_T_DIABAN WHERE NAM ='||nam(n)||'';
           IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
           select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) INTO P_CT from dual;
           P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_CT;
           END IF;
           P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
           IF(P_SELECT_DBHC IS NOT NULL) THEN
           P_SQL_INSERT:=P_SQL_INSERT || P_SELECT_DBHC;
           ELSE
           P_SQL_INSERT:=P_SQL_INSERT;
           END IF;

            
              -- Do something
              --cmd_sql(m):='';
              QUERY_STR1:='select Cast('''||dbhc(m)||''' as nvarchar2(50)) as STT ,
                                  NVL(SUM (CASE WHEN (MA_CAP = 1) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS Cap1,
                                  NVL(SUM (CASE WHEN (MA_CAP = 2) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS Cap2,
                                  NVL(SUM (CASE WHEN (MA_CAP = 3) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS Cap3,
                                  NVL(SUM (CASE WHEN (MA_CAP = 4) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS Cap4,
                                  NVL(SUM (CASE WHEN (MA_CAP = 0) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS Cap0
                                  from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                  AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                  AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                  AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(m)||'
                                AND MA_DIABAN = '''||dbhc(m)||'''
                                ';
                                IF(P_MA_DBHC = '260') THEN
                                DBMS_OUTPUT.ENABLE (buffer_size => NULL); 
                   dbms_output.put_line(QUERY_STR1);
                   END IF;
--           QUERY_STR1:='';
--           FOR i IN cmd_sql.FIRST .. cmd_sql.LAST
--           LOOP
--           IF TRIM(QUERY_STR1) IS NOT NULL THEN 
--                QUERY_STR1 := QUERY_STR1 || ' union all '|| cmd_sql(i);
--           ELSE
--                QUERY_STR1 := cmd_sql(i);
--            END IF;
--           END LOOP;
           QUERY_STR2:='';
        QUERY_STR2:='INSERT INTO MBL_PHA_T_DIABAN (NAM,SHKB,THANG,SOTIEN) SELECT Cast('''||CURREN_YEAR||''' as nvarchar2(50)) as nam, STT,'||thangNum(n)||',(Cap1+Cap2+Cap3+Cap4+Cap0) AS TONGSO from ('||QUERY_STR1||')';
        BEGIN
          --  DBMS_OUTPUT.ENABLE (buffer_size => NULL); 
                   -- dbms_output.put_line(QUERY_STR2);
                    EXECUTE IMMEDIATE P_DELETE;
                    --EXECUTE IMMEDIATE P_INSERT;
                    EXECUTE IMMEDIATE QUERY_STR2;
            END;
                        END LOOP;

    END LOOP;

        
        
--        BEGIN
--                             DBMS_OUTPUT.ENABLE (buffer_size => NULL); 
--        dbms_output.put_line(QUERY_STR1);
--        EXECUTE IMMEDIATE QUERY_STR1;
--
----OPEN cur FOR QUERY_STR1;
----EXCEPTION
----   WHEN NO_DATA_FOUND
----   THEN
----      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
----   WHEN OTHERS
----   THEN
----      DBMS_OUTPUT.put_line (QUERY_STR1  || SQLERRM); 
--END;
END MBL_PHA_MAUBS_04;