create or replace PROCEDURE "MBL_PHA_BIEU3" AS
 noidung dbms_sql.varchar2_table;
 congthuc dbms_sql.varchar2_table;
 stt dbms_sql.varchar2_table;
 cmd_sql dbms_sql.clob_TABLE;
 nam dbms_sql.varchar2_table;
 dbhc dbms_sql.varchar2_table;
  shkb dbms_sql.varchar2_table;

DONVI_TIEN number:=1;
 QUERY_STR1  CLOB;
 P_SQL_INSERT VARCHAR2(32767);
 P_CT VARCHAR2(32767);
 P_SELECT_DBHC VARCHAR2(32767);
  P_DELETE VARCHAR2(32767);
  P_INSERT VARCHAR2(32767);

 TUNGAY_KS DATE;
  DENNGAY_KS DATE;
 TUNGAY_HL DATE;
 DENNGAY_HL DATE;
    thang dbms_sql.varchar2_table;
    thangNum dbms_sql.number_table;
   CURREN_YEAR NUMBER := TO_NUMBER(to_char(SYSDATE,'yyyy'));

BEGIN
--   noidung(1) := '60000';
   noidung(1) := '60200';
   noidung(2) := '60100';

       stt(1) := '1';
       stt(2) := '2';
       stt(3) := '3';

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
   FOR n IN thang.FIRST .. thang.LAST
       LOOP
            FOR m IN dbhc.FIRST .. dbhc.LAST
            LOOP
            P_SELECT_DBHC := '';
            P_SQL_INSERT := '';
            QUERY_STR1 := '';

                       TUNGAY_KS  := TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                       --DBMS_OUTPUT.Put_Line(TUNGAY_KS);
                    DENNGAY_KS  :=LAST_DAY(TUNGAY_KS);
                                           --DBMS_OUTPUT.Put_Line(DENNGAY_KS);

                    TUNGAY_HL  :=TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                    DENNGAY_HL  :=LAST_DAY(TUNGAY_HL);
                    P_DELETE:= 'DELETE FROM MBL_PHA_T_NSNN WHERE NAM ='||CURREN_YEAR||' AND SHKB = '||dbhc(m)||' AND THANG = '||thangNum(n)||'';
                    P_INSERT:='INSERT INTO MBL_PHA_T_NSNN (NAM,SHKB,THANG) VALUES('||CURREN_YEAR||','||dbhc(m)||','||thangNum(n)||')';
                    BEGIN
                        Execute Immediate P_DELETE;
                        Execute Immediate P_INSERT;
                    END;

                   P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||dbhc(m)||''' OR MA_DBHC_CHA = '''||dbhc(m)||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||dbhc(m)||''' OR MA_DBHC_CHA = '''||dbhc(m)||'''))';
                   IF(P_SELECT_DBHC IS NOT NULL) THEN
                   P_SQL_INSERT:=P_SQL_INSERT || P_SELECT_DBHC;
                   ELSE
                   P_SQL_INSERT:=P_SQL_INSERT;
                   END IF;
                   FOR i IN noidung.FIRST .. noidung.LAST
                   LOOP
                      -- Do something
                           select CT_DH_W INTO congthuc(i) from DM_PHC_CHITIEUTHUCHI a WHERE MACHITIEU = noidung(i) AND LOAICHITIEU = 1 AND PHAN_HE = 'A' AND a.TUNGAY_HL <= TUNGAY_KS
                                          AND (a.DENNGAY_HL >= DENNGAY_KS OR a.DENNGAY_HL IS NULL) ;
                           IF(congthuc(i) IS NOT NULL) THEN
                           congthuc(i):='AND' || congthuc(i);
                           ELSE
                           congthuc(i):='AND 1=1';
                           END IF;
                   END LOOP;


                   FOR i IN noidung.FIRST .. noidung.LAST
                   LOOP
                      -- Do something
                      IF(noidung(i)='60200') THEN
                        QUERY_STR1:='UPDATE MBL_PHA_T_NSNN SET T_TW_100 = (select SUM (CASE WHEN (MA_CAP = 1) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||'),
                                          T_T_100 = (select SUM (CASE WHEN (MA_CAP = 2) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||'),
                                          T_H_100 = (select SUM (CASE WHEN (MA_CAP = 3) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||'),
                                          T_X_100 = (select SUM (CASE WHEN (MA_CAP = 4) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||')                                            
                                    WHERE NAM ='||CURREN_YEAR||' AND SHKB = '||dbhc(m)||'';
                      ELSIF (noidung(i)='60100') THEN
                        QUERY_STR1:='UPDATE MBL_PHA_T_NSNN SET T_TW_PC= (select SUM (CASE WHEN (MA_CAP = 1) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||') ,
                                          T_T_PC = (select SUM (CASE WHEN (MA_CAP = 2) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||'),
                                          T_H_PC = (select SUM (CASE WHEN (MA_CAP = 3) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||'),
                                          T_X_PC = (select SUM (CASE WHEN (MA_CAP = 4) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END)
                                              from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                                              AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                                              AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                                              AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||')                                              
                                    WHERE NAM ='||CURREN_YEAR||' AND SHKB = '||dbhc(m)||' AND THANG = '||thangNum(n)||'';
                      END IF;   
                      congthuc(i):='';
                   BEGIN
                    --DBMS_OUTPUT.ENABLE (buffer_size => NULL); 
                    --DBMS_OUTPUT.Put_Line(QUERY_STR1);
                        Execute Immediate QUERY_STR1;
                    END;

                    END LOOP;
                    P_SQL_INSERT :='';
--                    QUERY_STR1 :='';
--                    FOR i IN cmd_sql.FIRST .. cmd_sql.LAST
--                       LOOP
--                       IF TRIM(QUERY_STR1) IS NOT NULL THEN 
--                            QUERY_STR1 := QUERY_STR1 || ' union all '|| cmd_sql(i);
--                       ELSE
--                            QUERY_STR1 := cmd_sql(i);
--                        END IF;
--                        cmd_sql(i):='';
--                    END LOOP;
--                    --DBMS_OUTPUT.ENABLE (buffer_size => NULL); 
--                    --DBMS_OUTPUT.Put_Line(QUERY_STR1);
            END LOOP;
       END LOOP;


END MBL_PHA_BIEU3;