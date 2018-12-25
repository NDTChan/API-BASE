--------------------------------------------------------
--  File created - Wednesday-April-11-2018   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Procedure MBL_PHA_MAUBS_02
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."MBL_PHA_MAUBS_02" (P_MA_DBHC IN NVARCHAR2,P_LOAI_BAOCAO IN VARCHAR2, P_LOAI_DL IN VARCHAR2,P_CONGTHUC VARCHAR2,TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
  
    QUERY_STR  VARCHAR2(32767); 
   QUERY_STR1  VARCHAR2(32767); 
   QUERY_STR2  VARCHAR2(32767); 
   QUERY_STR3  VARCHAR2(32767); 
   QUERY_STR4  VARCHAR2(32767); 
   QUERY_STR5  VARCHAR2(32767);
   QUERY_STR1_COT2 VARCHAR2(32767);

    noidung dbms_sql.varchar2_table;
 congthuc dbms_sql.varchar2_table;
 stt dbms_sql.varchar2_table;
 cmd_sql dbms_sql.varchar2_table;
 TEMP_THU_DB decimal(18,2);
    -- cot 4
   P_CT VARCHAR2(32767);   
   P_SQL_INSERT VARCHAR2(32767);
   P_SELECT_DBHC VARCHAR2(32767);
    P_SQL_CREATE_TABLE_TH  VARCHAR2(32767);  
   P_SQL_CREATE_TABLE  VARCHAR2(32767);  
   P_TABLENAME_TH VARCHAR2(100);
      P_TABLENAME VARCHAR2(100);
   INSERT_QUERRY_CHI  VARCHAR2(32767);  
   INSERT_QUERRY_THU  VARCHAR2(32767);  
   TABLE_PHA_DT_CHI  VARCHAR2(100); 
   TABLE_PHA_DT_THU  VARCHAR2(100);   
   TABLE_PHA_DT_DUTOAN  VARCHAR2(100);  
   INSERT_QUERRY_DUTOAN  VARCHAR2(32767);
   SQL_QUERRY VARCHAR2(32767);
   N_COUNT NUMBER(17,4):=0;
   N_COUNT_2 NUMBER(17,4):=0;
   v_SQL_Clo  VARCHAR2(32767);  
   v_SQL_Clo_2  VARCHAR2(32767);  
   P_SUM_CTMTQG VARCHAR2(32767);
   P_WHERE_DATE_HL_TU VARCHAR2(100); P_WHERE_DATE_HL_DEN VARCHAR2(100); P_WHERE_DATE_KS_TU VARCHAR2(100); P_WHERE_DATE_KS_DEN VARCHAR2(100);
   sx_ctmtqg VARCHAR2(5); 
   P_INSERT_C_R clob;
   P_CT_CTMTQG clob;
   P_WHERE_C_R VARCHAR2(32767); 
   P_SUM VARCHAR2(32767);
   P_SUM_U VARCHAR2(32767);
   P_UPDATE_SUM VARCHAR2(32767);
   V_TU_NAM NUMBER := TO_NUMBER(to_char(TUNGAY_HL,'yyyy'));
   V_CONGTHUC_DUTOAN_QUYETTOAN clob;
   GIA_TRI_CLO NUMBER(17,4):=0;
    MABAOCAO VARCHAR(100);
       P_SELECT_1 VARCHAR2(32767);
   P_SELECT_2 VARCHAR2(32767);
   P_UPDATE_SUBTRACT VARCHAR2(32767);
   P_SUBTRACT_U VARCHAR2(32767);
   P_UPDATE_COT4 VARCHAR2(32767);
   BEGIN
       P_SQL_CREATE_TABLE_TH:='
      CREATE TABLE "BTSTC"."MBL_PHA_BIEU1" 
       (	"THU_DB" NUMBER(18,2), 
        "THU_NSNN" NUMBER(18,2), 
        "THU_NSDP" NUM  BER(18,2), 
        "CHI_NSDP" NUMBER(18,2)
       ) SEGMENT CREATION DEFERRED 
      PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
      TABLESPACE "USERS" ;
     
    ';
       BEGIN
        SELECT COUNT(*)  INTO N_COUNT  FROM ALL_TAB_COLUMNS  WHERE TABLE_NAME = UPPER('MBL_PHA_BIEU1');
        EXCEPTION WHEN OTHERS THEN N_COUNT:=0;
    END;
    IF(N_COUNT IS NULL OR N_COUNT<=0) THEN
    BEGIN
        EXECUTE IMMEDIATE P_SQL_CREATE_TABLE_TH;  
    END;
    END IF;
     BEGIN
        EXECUTE IMMEDIATE 'DELETE MBL_PHA_BIEU1';  
    END;

   -- COT1 - BS-02 --
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN(P_CONGTHUC) INTO P_CT from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_CT;
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

            EXECUTE IMMEDIATE 'DELETE PHA_THDT_HCSN_DT WHERE DL_BAOCAO = ''BS-02'''; 
            QUERY_STR1:='INSERT INTO PHA_THDT_HCSN_DT (MA_TKTN,MA_CAP,MA_DVQHNS,MA_DIABAN,MA_CHUONG,TEN_CHUONG,MA_NGANHKT,MA_LOAI,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,NGAY_KET_SO,NGAY_HIEU_LUC,ENTERED_DR,ENTERED_CR,ACCOUNTED_DR,ACCOUNTED_CR,ATTRIBUTE8,GIA_TRI_HACH_TOAN,MA_NVC,DL_BAOCAO)
            SELECT A.MA_TKTN,A.MA_CAP,A.MA_DVQHNS,A.MA_DIABAN,A.MA_CHUONG,A.TEN_CHUONG,A.MA_NGANHKT,A.MA_LOAI,A.MA_CTMTQG,A.MA_KBNN,A.MA_NGUON_NSNN,A.NGAY_KET_SO,A.NGAY_HIEU_LUC,A.ENTERED_DR,A.ENTERED_CR,A.ACCOUNTED_DR,A.ACCOUNTED_CR,A.ATTRIBUTE8,A.GIA_TRI_HACH_TOAN,A.MA_NVC,Cast(''BS-02'' as nvarchar2(50)) as DL_BAOCAO from PHA_HACHTOAN_CHI A
            WHERE            
            A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
            AND A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND
            (
            A.MA_TKTN like ''8%'' 
            OR A.MA_TKTN like ''36%''
            )
            '||P_SQL_INSERT||'' ;
            QUERY_STR2:='INSERT INTO PHA_THDT_HCSN_DT (MA_TKTN,MA_CAP,MA_DVQHNS,MA_DIABAN,MA_CHUONG,TEN_CHUONG,MA_NGANHKT,MA_LOAI,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,NGAY_KET_SO,NGAY_HIEU_LUC,ENTERED_DR,ENTERED_CR,ACCOUNTED_DR,ACCOUNTED_CR,ATTRIBUTE8,GIA_TRI_HACH_TOAN,MA_NVC,DL_BAOCAO)
            SELECT A.MA_TKTN,A.MA_CAP,A.MA_DVQHNS,A.MA_DIABAN,A.MA_CHUONG,A.TEN_CHUONG,A.MA_NGANHKT,A.MA_LOAI,A.MA_CTMTQG,A.MA_KBNN,A.MA_NGUON_NSNN,A.NGAY_KET_SO,A.NGAY_HIEU_LUC,A.ENTERED_DR,A.ENTERED_CR,A.ACCOUNTED_DR,A.ACCOUNTED_CR,A.ATTRIBUTE8,A.GIA_TRI_HACH_TOAN,A.MA_NVC,Cast(''BS-02'' as nvarchar2(50)) as DL_BAOCAO from PHA_HACHTOAN_THU A
            WHERE
            A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
            AND A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND 
            (
            A.MA_TKTN like ''7%''
            OR A.MA_TKTN like ''36%''
            )
            '||P_SQL_INSERT||'';

            QUERY_STR3:='INSERT INTO PHA_THDT_HCSN_DT (MA_TKTN,MA_CAP,MA_DVQHNS,MA_DIABAN,MA_CHUONG,TEN_CHUONG,MA_NGANHKT,MA_LOAI,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,NGAY_KET_SO,NGAY_HIEU_LUC,ENTERED_DR,ENTERED_CR,ACCOUNTED_DR,ACCOUNTED_CR,ATTRIBUTE8,GIA_TRI_HACH_TOAN,DL_BAOCAO)
            SELECT A.MA_TKTN,A.MA_CAP,A.MA_DVQHNS,A.MA_DIABAN,A.MA_CHUONG,A.TEN_CHUONG,A.MA_NGANHKT,A.MA_LOAI,A.MA_CTMTQG,A.MA_KBNN,A.MA_NGUON_NSNN,A.NGAY_KET_SO,A.NGAY_HIEU_LUC,A.ENTERED_DR,A.ENTERED_CR,A.ACCOUNTED_DR,A.ACCOUNTED_CR,A.ATTRIBUTE8,A.GIA_TRI_HACH_TOAN,Cast(''BS-02'' as nvarchar2(50)) as DL_BAOCAO from PHA_HACHTOAN_KHAC A
            WHERE
            A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
            AND A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND (A.MA_TKTN like ''15%'' or A.MA_TKTN like ''17%'' or A.MA_TKTN like ''19%'')
            '||P_SQL_INSERT||'';

            QUERY_STR4:='UPDATE PHA_THDT_HCSN_DT A SET A.MA_DIABAN_CHA = (select B.MA_DBHC_CHA from DM_DBHC B where B.MA_DBHC = A.MA_DIABAN)';
            QUERY_STR5:='
            INSERT INTO MBL_PHA_BIEU1 (THU_DB)
            select SUM(K.THU_DB) AS THU_DB from 
            (
            select T.THU_DB from
            (
            select SUM (CASE WHEN ((A.MA_TKTN = 7111 OR A.MA_TKTN = 7113) and  A.MA_DIABAN = 27) THEN (GIA_TRI_HACH_TOAN)/NVL(1,1) ELSE 0 END) AS THU_DB
            FROM PHA_THDT_HCSN_DT A    
            where A.DL_BAOCAO = ''BS-02''   
            )T
            union all            
            -- cap huyen
            select T.THU_DB from
            (

            select 
            SUM (CASE WHEN ((A.MA_TKTN = 7111 OR A.MA_TKTN = 7113) and A.MA_DIABAN in (259,262,260,261,258,263,264,256)) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS THU_DB
            FROM PHA_THDT_HCSN_DT A
            left join DM_DBHC B on A.MA_DIABAN_CHA = B.MA_DBHC            
            where   
            A.MA_KBNN <> 1111
            and A.DL_BAOCAO = ''BS-02''
            group by A.MA_KBNN
            order by A.MA_KBNN
            )T
            union all          
            -- cap xa
             select T.THU_DB from
            (
            select 
            SUM (CASE WHEN ((A.MA_TKTN = 7111 OR A.MA_TKTN = 7113)) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS THU_DB
            FROM PHA_THDT_HCSN_DT A 
            left join DM_DBHC B on A.MA_DIABAN_CHA = B.MA_DBHC
            left join DM_DBHC C on A.MA_DIABAN = C.MA_DBHC
            where A.MA_DIABAN like ''09%''
            and A.MA_DIABAN <> ''09058''
            and A.DL_BAOCAO = ''BS-02''
            group by A.MA_DIABAN_CHA,B.TEN_DBHC,A.MA_DIABAN,C.TEN_DBHC
            order by A.MA_DIABAN_CHA
            )T
            )K';
               -- END COT1 - BS-02 --

            
              -- COT1 - BS-02 --
   noidung(1) := 'Tỉnh Bắc Ninh';
   noidung(2) := 'Huyện Yên Phong';
   noidung(3) := 'Huyện Lương Tài';
   noidung(4) := 'Huyện Tiên Du';
   noidung(5) := 'Huyện Quế Võ';
   noidung(6) := 'Huyện Thuân Thành';
   noidung(7) := 'Thành phố Bắc Ninh';
   noidung(8) := 'Thị xã Từ Sơn';
   noidung(9) := 'Huyện Gia Bình';


   congthuc(1) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113)and MA_KBNN = 1111';
   congthuc(2) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1112';
   congthuc(3) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1113';
   congthuc(4) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1114';
   congthuc(5) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1115';
   congthuc(6) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1116';
   congthuc(7) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1117';
   congthuc(8) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1118';
   congthuc(9) := 'and (MA_TKTN = 7111 OR MA_TKTN = 7113) and MA_KBNN = 1119';
   stt(1) := 'P1';
   stt(2) := 'P2';
   stt(3) := 'P3';
   stt(4) := 'P4';
   stt(5) := 'P5';
   stt(6) := 'P6';
   stt(7) := 'P7';
   stt(8) := 'P8';
   stt(9) := 'P9';



   FOR i IN noidung.FIRST .. noidung.LAST
   LOOP
      -- Do something
      cmd_sql(i):='select SUM (CASE WHEN (MA_CAP = 2) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS Cap2,
                          SUM (CASE WHEN (MA_CAP = 3) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS Cap3,
                          SUM (CASE WHEN (MA_CAP = 4) THEN (GIA_TRI_HACH_TOAN)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS Cap4
                          from PHA_HACHTOAN_THU where NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                          AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                          AND NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                          AND NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' '||congthuc(i)||'

                        ';


   END LOOP;
    FOR i IN cmd_sql.FIRST .. cmd_sql.LAST
   LOOP
   IF TRIM(QUERY_STR1_COT2) IS NOT NULL THEN 
        QUERY_STR1_COT2 := QUERY_STR1_COT2 || ' union all '|| cmd_sql(i);
   ELSE
        QUERY_STR1_COT2 := cmd_sql(i);
    END IF;

   END LOOP;
   QUERY_STR1_COT2:= 'UPDATE MBL_PHA_BIEU1 a SET THU_NSNN = (SELECT SUM(K.Cap2 + K.Cap3+K.Cap4) AS   THU_NSNN    from ('||QUERY_STR1_COT2||')K) 
                WHERE a.THU_DB = (SELECT THU_DB FROM MBL_PHA_BIEU1 WHERE ROWNUM =1)';
--dbms_output.put_line(QUERY_STR1_COT2);

               -- END COT2 - BS-02 --
-- COT4 - BM60_TT342_2017 --
-- bang 1
        P_TABLENAME_TH:='PHA_TH_MLNS'; 
        MABAOCAO :='BM60_TT342_2017';
        P_TABLENAME := 'BM60_TT342_2017';
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
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  ';                      

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
    FOR item IN (SELECT MA_COT FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC)
    LOOP   
        v_SQL_Clo:= v_SQL_Clo || item.MA_COT ||' NUMBER, ';
        v_SQL_Clo_2:= v_SQL_Clo_2 || item.MA_COT ||', ';
        P_SUM_CTMTQG:= P_SUM_CTMTQG || item.MA_COT ||'=0 AND  ';
    END LOOP;
     P_SUM_CTMTQG:= P_SUM_CTMTQG || ' 1=1';

-- bang 2

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

        P_WHERE_DATE_HL_TU:= ' AND NGAY_HIEU_LUC >= TO_DATE ('''||to_char(TUNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';
        P_WHERE_DATE_HL_DEN:= ' AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')';        
        P_WHERE_DATE_KS_TU:= ' AND NGAY_KET_SO >= TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')'; 
        P_WHERE_DATE_KS_DEN:= ' AND NGAY_KET_SO <= TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')';
        IF(P_MA_DBHC <> 27) THEN
        P_SELECT_DBHC:= ' AND MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
        ELSE P_SELECT_DBHC:= ' ';
        END IF;
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN || P_SELECT_DBHC;
        ELSE
        P_CT:=P_CT || P_WHERE_DATE_HL_TU ||  P_WHERE_DATE_HL_DEN || P_WHERE_DATE_KS_TU ||  P_WHERE_DATE_KS_DEN;
        END IF;
      -- TAO TABLE 2
    --B2 XU LY DU LIEU TRONG DM CHI TIEU DUOC DAY VAO BAO CAO
    EXECUTE IMMEDIATE 'TRUNCATE TABLE ' ||P_TABLENAME;
    FOR item_R IN (SELECT ID,SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAICHITIEU,MA_CHITIEU,TEN_CHITIEU,CT_QT_W,CT_DT_W,CT_DH_W,TUNGAY,DENNGAY,CONGTHUC_DH_WHERE FROM V_DMCTBC  WHERE MA_BAOCAO = MABAOCAO AND TUNGAY <= TO_DATE (''||TUNGAY_HL||'','dd-MM-yy') AND DENNGAY >= TO_DATE (''||DENNGAY_HL||'','dd-MM-yy') ORDER BY SAPXEP ASC)
    LOOP      
        --DBMS_OUTPUT.put_line('item_R '||item_R.MA_CHITIEU);
        IF(item_R.TRANG_THAI IS NULL OR  item_R.TRANG_THAI='C') THEN  
        BEGIN
                P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,MA_CHITIEU,MA_CHITIEU_2,'||v_SQL_Clo_2||'TEN_CHITIEU)';
                P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','|| item_R.HIENTHI ||',''C'','|| NVL(item_R.LOAICHITIEU,0) ||',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO ORDER BY STT ASC)
                    LOOP
                         BEGIN
                         --DBMS_OUTPUT.put_line('item_C '||item_C.MA_COT);
                            SELECT SUM(NVL(GIA_TRI,0)) INTO GIA_TRI_CLO  FROM DM_CHITIEU_COT_SOLIEU  WHERE 
                            MA_COT=item_C.MA_COT AND MA_CHITIEU=item_R.MA_CHITIEU AND LOAI_CHITIEU=item_R.LOAICHITIEU AND NAM= V_TU_NAM 
                            AND MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||'') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = ''||P_MA_DBHC||'' OR MA_DBHC_CHA = ''||P_MA_DBHC||''));    
                            IF GIA_TRI_CLO IS NULL THEN GIA_TRI_CLO:=0; 
                            END IF;
                            --DBMS_OUTPUT.put_line('GIA_TRI_CLO '||GIA_TRI_CLO);
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
                                --DBMS_OUTPUT.put_line ('P_INSERT_C_R:=' ||  P_INSERT_C_R );
                              END;
                          END IF;
                          IF(GIA_TRI_CLO <=0) THEN
                                begin
                                  if(P_LOAI_DL IS NULL OR UPPER(P_LOAI_DL)='ALL')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND '; END IF;
                                  if(UPPER(P_LOAI_DL)='CANDOI')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE '|| P_CT  || ' AND (LOAI_CHITIEU=' || item_R.LOAICHITIEU ||' OR LOAI_CHITIEU=3) AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='T')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=1 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
                                  if(UPPER(P_LOAI_DL)='C')THEN P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0)/'|| DONVI_TIEN ||' FROM '||P_TABLENAME_TH||' WHERE (LOAI_CHITIEU=2 OR LOAI_CHITIEU=3) AND ' || P_CT || ' AND '; END IF;                                    
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
                     --DBMS_OUTPUT.ENABLE (buffer_size => NULL); 
                 -- DBMS_OUTPUT.ENABLE (buffer_size => NULL);
                  -- DBMS_OUTPUT.put_line ('ID:=' ||  P_INSERT_C_R );
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
        IF INSTR(item_R.TRANG_THAI, 'T', 1)>0 THEN
        BEGIN
                  P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,CT,MA_CHITIEU, MA_CHITIEU_2, TEN_CHITIEU)';
                  P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('''|| item_R.SAPXEP ||''','''|| NVL(item_R.STT,'NULL') ||''','|| NVL(item_R.CAP,0) ||','|| NVL(item_R.INDAM,0) ||','|| NVL(item_R.INNGHIENG,0) ||','''|| item_R.HIENTHI ||''',''' || item_R.TRANG_THAI  ||''','|| NVL(item_R.LOAICHITIEU,0) ||','''  ||  item_R.CONGTHUC_DH_WHERE ||  ''',''' ||  item_R.MA_CHITIEU || ''',''''''' ||  item_R.MA_CHITIEU || ''''''',';
                  P_INSERT_C_R:=P_INSERT_C_R || '''' || item_R.TEN_CHITIEU || '''' ||')';
                  EXECUTE IMMEDIATE P_INSERT_C_R;

        END;
        END IF;
        END LOOP; 
        --B2-2 XU LY DU LIEU CTMTQD, NEU GAP TRANG THANG=CTMTQG THI FRO ALL DMCTMTQT KET HOI FOR CLOUM DE INSER DU LIEU VAO TABLE
         BEGIN
            SELECT COUNT(*) INTO N_COUNT_2 FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='CTMTQG';
            SELECT  STT  INTO sx_ctmtqg FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='CTMTQG';
            SELECT CONGTHUC_WHERE  INTO P_CT_CTMTQG FROM DM_CHITIEU_BAOCAO WHERE MA_BAOCAO = MABAOCAO AND TRANG_THAI='CTMTQG';
            EXCEPTION WHEN OTHERS THEN N_COUNT_2:=0;
        END;
        IF(N_COUNT_2>0) THEN
            N_COUNT_2:=0;
            N_COUNT:=TO_NUMBER(sx_ctmtqg)+1;
            BEGIN
                  P_INSERT_C_R:='';
                  FOR item_CTMT IN (SELECT MA_CTMTQG,TEN_CTMTQG, P_CT_CTMTQG ||  ('MA_CTMTQG= ''' || MA_CTMTQG ||'''' )AS CONGTHUC_WHERE FROM DM_CTMTQG WHERE TRANG_THAI='A' ORDER BY MA_CTMTQG ASC)
                  LOOP
                    begin
                    N_COUNT_2:=N_COUNT_2+1;
                      P_INSERT_C_R:= 'INSERT INTO '|| P_TABLENAME ||'(SAPXEP,STT,CAP,INDAM,INNGHIENG,HIENTHI,TRANG_THAI,LOAI_CHITIEU,MA_CHITIEU,'||v_SQL_Clo_2||'TEN_CHITIEU)';
                      P_INSERT_C_R:=P_INSERT_C_R || 'VALUES('||N_COUNT_2||','||N_COUNT||',0,0,0,1,''CTMTQG_C'',0,''' || item_CTMT.MA_CTMTQG ||''',';
                          FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE,TRANG_THAI FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO ORDER BY STT ASC)
                            LOOP    
                                begin
                                P_SUM:='SELECT NVL(SUM(GIA_TRI_HACH_TOAN),0) FROM '||P_TABLENAME_TH||' WHERE ';
                                if((LENGTH (item_C.CONGTHUC_WHERE)>0 and LENGTH (item_CTMT.CONGTHUC_WHERE)<=0) ) THEN P_WHERE_C_R:= '(' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                if((LENGTH (item_C.CONGTHUC_WHERE)>0 and LENGTH (item_CTMT.CONGTHUC_WHERE)>0) ) THEN P_WHERE_C_R:='(' || TRIM(item_CTMT.CONGTHUC_WHERE) || ') AND (' || TRIM(item_C.CONGTHUC_WHERE) ||')'; END IF;
                                if(LENGTH (P_WHERE_C_R)>0) THEN P_SUM:='(' || P_SUM|| TRIM(P_WHERE_C_R) || ')';ELSE P_SUM:='(' || P_SUM|| ')';END IF;
                                P_INSERT_C_R:=P_INSERT_C_R || P_SUM ||',';    
                                end;
                            END LOOP; 
                      P_INSERT_C_R:=P_INSERT_C_R || '''' || item_CTMT.TEN_CTMTQG || '''' ||')';
--                       DBMS_OUTPUT.ENABLE (buffer_size => NULL);
--                   DBMS_OUTPUT.put_line ('t:=' ||  P_INSERT_C_R );
                     EXECUTE IMMEDIATE P_INSERT_C_R; 
                  end; 
                  END LOOP; 

            END;
        END IF;



-- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 
    P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO ORDER BY STT ASC )
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
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S1''';
   -- DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

      --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T'' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)),'; 
                 --DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 


       --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T1 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T1'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T1'' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T1''';
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

        --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T2 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T2'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T2'' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T2''';
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

  --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 2
      P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:= P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S2''';
      --DBMS_OUTPUT.put_line ('T6:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

      --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 3
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S3''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 
       --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 4
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S4''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

       --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 5
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S5''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

        --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T3 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T3'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T3'' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T3''';
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

             --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 6
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S6''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 


          --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 7
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S7''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM; 

       --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T4 (khác loại chỉ tiêu)
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T4'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T4'' ';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||'))
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||'))),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T4''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

         --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T5 
    P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:=''; P_SELECT_1:='';P_SELECT_2:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T5'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T5'' ';
    --DBMS_OUTPUT.put_line ('T5:=' ||  P_SELECT_2 );
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||')  AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)),'; 
                -- DBMS_OUTPUT.put_line ('T5:=' ||  P_SUM_U );
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T5''';
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

        --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T6(khác loại chỉ tiêu)
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T6'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') + 4 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T6'' ';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||'))
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP )),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T6''';
       --DBMS_OUTPUT.put_line ('T6:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 


      --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T7(khác loại chỉ tiêu)
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T7'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) AND CAP IN (CAP) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T7'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2)';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||'))
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T7''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 


      --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T8(khác loại chỉ tiêu)
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T8'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T8'' ';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||'))
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP )),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T8''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

             --- B2 UPDATE CONG THUC TONG TAI CAC CHI TIEU CO TRANG THAI S 8(khac loai chi tieu)
	   P_UPDATE_SUM:=''; P_SUM_U:='';
     P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM_U:=P_SUM_U || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE instr(A.CT,B.MA_CHITIEU_2)>0 AND A.CAP = B.CAP),';                  
            END LOOP;
       P_SUM_U:= SUBSTR(P_SUM_U,0,LENGTh(P_SUM_U)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM_U ||' WHERE A.TRANG_THAI=''S8''';
      -- DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
      EXECUTE IMMEDIATE P_UPDATE_SUM;

            --B2 UPDATE CONG THUC tru TAI CAC CHI TIEU CO TRANG THAI T9()
     P_UPDATE_SUBTRACT:=''; P_SUBTRACT_U:='';
    P_SELECT_1 := 'SELECT SUBSTR(ct,2,INSTR(trim(ct),'','') - 2) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T9'' AND MA_CHITIEU_2 IN (MA_CHITIEU_2) ';
    P_SELECT_2 := 'SELECT SUBSTR(ct,instr(trim(ct),'','') + 1, length(trim(ct)) - instr(trim(ct),'','') - 1 ) FROM '|| P_TABLENAME ||' WHERE TRANG_THAI =''T9'' ';
     P_UPDATE_SUBTRACT:=' UPDATE ' || P_TABLENAME || ' A SET ';
     FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUBTRACT_U:=P_SUBTRACT_U || 'A.'|| item_C.MA_COT || ' = ((SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_1||'))
                  - (SELECT NVL(('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.MA_CHITIEU_2 = ('||P_SELECT_2||') AND A.CAP = B.CAP AND A.LOAI_CHITIEU = B.LOAI_CHITIEU)),'; 
            END LOOP;
       P_SUBTRACT_U:= SUBSTR(P_SUBTRACT_U,0,LENGTh(P_SUBTRACT_U)-1);
       P_UPDATE_SUBTRACT:=P_UPDATE_SUBTRACT || P_SUBTRACT_U ||' WHERE A.TRANG_THAI=''T9''';
       --DBMS_OUTPUT.put_line ('T5:=' ||  P_UPDATE_SUBTRACT );
      EXECUTE IMMEDIATE P_UPDATE_SUBTRACT; 

    -- update row co trang thai =CTMTQG=SUM (CTMTQT_C_)        
        P_UPDATE_SUM:=''; P_SUM:='';
        P_UPDATE_SUM:=' UPDATE ' || P_TABLENAME || ' A SET ';
        FOR item_C IN (SELECT MA_COT,CONGTHUC_WHERE FROM DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO=MABAOCAO  ORDER BY STT ASC )
            LOOP   
                  P_SUM:=P_SUM || 'A.'|| item_C.MA_COT || ' = (SELECT NVL(SUM('|| item_C.MA_COT ||'),0) FROM '||P_TABLENAME||' B WHERE B.TRANG_THAI=''CTMTQG_C''),';                  
            END LOOP;
       P_SUM:= SUBSTR(P_SUM,0,LENGTh(P_SUM)-1);
       P_UPDATE_SUM:=P_UPDATE_SUM || P_SUM ||' WHERE A.TRANG_THAI=''CTMTQG''';
       --DBMS_OUTPUT.put_line ('T7:=' ||  P_UPDATE_SUM );
       EXECUTE IMMEDIATE P_UPDATE_SUM; 
       -- XOA DU LIEU NHUNG ROW CUA CTMTQG CO CAC COT DIEU =0
       P_UPDATE_SUM:='';
       P_UPDATE_SUM:=' DELETE FROM ' || P_TABLENAME || ' WHERE TRANG_THAI=''CTMTQG_C'' AND ' || P_SUM_CTMTQG;
       EXECUTE IMMEDIATE P_UPDATE_SUM; 
        P_UPDATE_COT4:='UPDATE MBL_PHA_BIEU1 a SET CHI_NSDP=( SELECT (NST+NSH+NSX) FROM ' ||P_TABLENAME||' where TEN_CHITIEU = ''TỔNG SỐ CHI'') 
                        WHERE a.THU_DB = (SELECT THU_DB FROM MBL_PHA_BIEU1 WHERE ROWNUM =1) ';
        
-- END COT4 - BM60_TT342_2017 --
            QUERY_STR := 'SELECT * FROM MBL_PHA_BIEU1';

            
BEGIN
EXECUTE IMMEDIATE QUERY_STR1;
EXECUTE IMMEDIATE QUERY_STR2;
EXECUTE IMMEDIATE QUERY_STR3;
EXECUTE IMMEDIATE QUERY_STR4;
EXECUTE IMMEDIATE QUERY_STR5;
EXECUTE IMMEDIATE QUERY_STR1_COT2;
EXECUTE IMMEDIATE P_UPDATE_COT4;

OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;
END MBL_PHA_MAUBS_02;

/
