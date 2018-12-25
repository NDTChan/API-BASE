create or replace PROCEDURE "PHA_NS_BM60_ND31" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE, P_CAP VARCHAR2, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
  QUERY_STR   CLOB; 
   QUERY_STR1  CLOB; 
   QUERY_STR2  CLOB;
   QUERY_STR3  CLOB;
   P_CT  VARCHAR2(32767);    
   P_SQL_INSERT  VARCHAR2(32767); 
   P_SELECT_DBHC VARCHAR2(32767);

   CT_NSDP_TL VARCHAR2(32767);   CT_NSDP_100 VARCHAR2(32767);   CT_BSCT VARCHAR2(32767);   CT_TSBS VARCHAR2(32767);     CT_TCN VARCHAR2(32767);   CT_TKD VARCHAR2(32767); CT_TTNSDP VARCHAR2(32767);

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

    -------gán công thức
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_TTNSDP from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='TTNSDP';
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_NSDP_TL from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='NSDP_TL';
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_NSDP_100 from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='NSDP_100';
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_BSCT from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='BSCT';
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_TSBS from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='TSBS';
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_TCN from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='TCN';
     select REPLACE(CONGTHUC_WHERE, '''', '''') INTO CT_TKD from DM_CHITIEU_BAOCAO_COL WHERE MA_BAOCAO='BM60_ND31' AND MA_COT='TKD';


    EXECUTE IMMEDIATE 'DELETE PHA_THDT_HCSN_DT WHERE DL_BAOCAO = ''BM60_ND31_CT''';
      QUERY_STR1:='INSERT INTO PHA_THDT_HCSN_DT (MA_TKTN,MA_NHOM,MA_TIEUNHOM,MA_MUC,MA_TIEUMUC,MA_CAP,MA_DVQHNS,MA_DIABAN,MA_CHUONG,TEN_CHUONG,MA_NGANHKT,MA_LOAI,MA_CTMTQG,MA_KBNN,MA_NGUON_NSNN,NGAY_KET_SO,NGAY_HIEU_LUC,ENTERED_DR,ENTERED_CR,ACCOUNTED_DR,ACCOUNTED_CR,ATTRIBUTE8,GIA_TRI_HACH_TOAN,MA_NVC,DL_BAOCAO)
            SELECT A.MA_TKTN,A.MA_NHOM,A.MA_TIEUNHOM,A.MA_MUC,A.MA_TIEUMUC,A.MA_CAP,A.MA_DVQHNS,A.MA_DIABAN,A.MA_CHUONG,A.TEN_CHUONG,A.MA_NGANHKT,A.MA_LOAI,A.MA_CTMTQG,A.MA_KBNN,A.MA_NGUON_NSNN,A.NGAY_KET_SO,A.NGAY_HIEU_LUC,A.ENTERED_DR,A.ENTERED_CR,A.ACCOUNTED_DR,A.ACCOUNTED_CR,A.ATTRIBUTE8,A.GIA_TRI_HACH_TOAN,A.MA_NVC,Cast(''BM60_ND31_CT'' as nvarchar2(50)) as DL_BAOCAO from PHA_HACHTOAN_THU A
            WHERE
            A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
            AND A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND 
            (
            A.MA_TKTN like ''7%''
            OR A.MA_TKTN like ''36%''
            )'
            || P_CT ||' 
            ';
    QUERY_STR2:='UPDATE PHA_THDT_HCSN_DT A SET A.MA_DIABAN_CHA = (select B.MA_DBHC_CHA from DM_DBHC B where B.MA_DBHC = A.MA_DIABAN)';
            QUERY_STR:='
            select * from 
            (           
            -- cap huyen
            select HT.CAP,HT.MA_DIABAN_CHA,HT.TEN_DIABAN_CHA,HT.MA_KBNN as MA_DIABAN,HT.TEN_DBHC
            ,NVL(HT.TTNSDP,0) as TTNSDP, NVL(HT.NSDP_TL,0) as NSDP_TL, NVL(HT.NSDP_100,0) as NSDP_100
                    , NVL(HT.BSCT,0) as BSCT , NVL(HT.TSBS,0) as TSBS
                    , NVL(HT.TCN,0) as TCN, NVL(HT.TKD,0) as TKD
            from
            (

            select Cast(''3'' as nvarchar2(50)) as CAP,A.MA_KBNN,Cast(''27'' as nvarchar2(50)) as MA_DIABAN_CHA,Cast(''Tỉnh Bắc Ninh'' as nvarchar2(50)) as TEN_DIABAN_CHA,
            Cast(
            CASE 
                 WHEN A.MA_KBNN =  1112 THEN ''Huyện Yên Phong''
                 WHEN A.MA_KBNN =  1113 THEN ''Huyện Lương Tài''
                 WHEN A.MA_KBNN =  1114 THEN ''Huyện Tiên Du''
                 WHEN A.MA_KBNN =  1115 THEN ''Huyện Quế Võ''
                 WHEN A.MA_KBNN =  1116 THEN ''Huyện Thuận Thành''
                 WHEN A.MA_KBNN =  1117 THEN ''Thành phố Bắc Ninh''
                 WHEN A.MA_KBNN =  1118 THEN ''Thị xã Từ Sơn''
                 WHEN A.MA_KBNN =  1119 THEN ''Huyện Gia Bình''
                 ELSE '' ''
              END  as nvarchar2(50)) AS TEN_DBHC
                    ,NVL(SUM (CASE WHEN ('|| CT_TTNSDP ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TTNSDP
                    ,NVL(SUM (CASE WHEN ('|| CT_NSDP_TL ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS NSDP_TL
                    ,NVL(SUM (CASE WHEN ('|| CT_NSDP_100 ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS NSDP_100    
                    ,NVL(SUM (CASE WHEN ('|| CT_BSCT ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS BSCT    
                    ,NVL(SUM (CASE WHEN ('|| CT_TSBS ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TSBS    
                    ,NVL(SUM (CASE WHEN ('|| CT_TCN ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TCN
                    ,NVL(SUM (CASE WHEN ('|| CT_TKD ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TKD


            FROM PHA_THDT_HCSN_DT A
            left join DM_DBHC B on A.MA_DIABAN_CHA = B.MA_DBHC            
            where   
            A.MA_KBNN <> 1111
            and A.MA_CAP = ''3''
            and A.DL_BAOCAO = ''BM60_ND31_CT''
            group by A.MA_KBNN
            order by A.MA_KBNN
            ) HT ';

             QUERY_STR3:='
            union all              
            -- cap xa
             select HT.CAP,HT.MA_DIABAN_CHA as MA_DBHC_CHA,HT.TEN_DIABAN_CHA as TEN_DBHC_CHA,HT.MA_DIABAN as MA_DBHC,HT.TEN_DBHC as TEN_DBHC
             ,NVL(HT.TTNSDP,0) as TTNSDP, NVL(HT.NSDP_TL,0) as NSDP_TL, NVL(HT.NSDP_100,0) as NSDP_100
                    , NVL(HT.BSCT,0) as BSCT , NVL(HT.TSBS,0) as TSBS
                    , NVL(HT.TCN,0) as TCN, NVL(HT.TKD,0) as TKD
             from
            (
            select  Cast(''4'' as nvarchar2(50)) as CAP,A.MA_DIABAN_CHA,B.TEN_DBHC as TEN_DIABAN_CHA,A.MA_DIABAN AS MA_DIABAN, C.TEN_DBHC AS TEN_DBHC
                    ,NVL(SUM (CASE WHEN ('|| CT_TTNSDP ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TTNSDP
                    ,NVL(SUM (CASE WHEN ('|| CT_NSDP_TL ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS NSDP_TL
                    ,NVL(SUM (CASE WHEN ('|| CT_NSDP_100 ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS NSDP_100    
                    ,NVL(SUM (CASE WHEN ('|| CT_BSCT ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS BSCT    
                    ,NVL(SUM (CASE WHEN ('|| CT_TSBS ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TSBS    
                    ,NVL(SUM (CASE WHEN ('|| CT_TCN ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TCN
                    ,NVL(SUM (CASE WHEN ('|| CT_TKD ||')  THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS TKD

            FROM PHA_THDT_HCSN_DT A 
            left join DM_DBHC B on A.MA_DIABAN_CHA = B.MA_DBHC
            left join DM_DBHC C on A.MA_DIABAN = C.MA_DBHC
            where 
            A.MA_DIABAN <> ''09058''
            and A.MA_CAP = ''4''
            and A.DL_BAOCAO = ''BM60_ND31_CT''
            group by A.MA_DIABAN_CHA,B.TEN_DBHC, A.MA_DIABAN, C.TEN_DBHC
            order by A.MA_DIABAN_CHA
            )HT 
            )';

--DBMS_OUTPUT.put_line(QUERY_STR); 

BEGIN

EXECUTE IMMEDIATE QUERY_STR1;
EXECUTE IMMEDIATE QUERY_STR2;
--EXECUTE IMMEDIATE QUERY_STR || QUERY_STR3;
--DBMS_OUTPUT.put_line (QUERY_STR);
--DBMS_OUTPUT.put_line ('QUERY_STR3: ' || QUERY_STR3);

OPEN cur FOR (QUERY_STR||QUERY_STR3);
EXCEPTION
  WHEN NO_DATA_FOUND
  THEN
     DBMS_OUTPUT.put_line ('ERROR 1' || QUERY_STR||QUERY_STR3);
   WHEN OTHERS
   THEN
    DBMS_OUTPUT.put_line ('ERROR 2' || QUERY_STR||QUERY_STR3);
END;

END PHA_NS_BM60_ND31;
 