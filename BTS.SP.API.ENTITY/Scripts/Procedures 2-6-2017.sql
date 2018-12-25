--------------------------------------------------------
--  File created - Friday-June-02-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Procedure PROC_BCDT_CHI_DTXD_CB
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_BCDT_CHI_DTXD_CB" (P_MADONVI VARCHAR2,P_MA_CONGTRINH VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
as
    QUERY_STR VARCHAR(20000);
    P_INSERT VARCHAR(20000);
begin
    IF TRIM(P_MADONVI) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND DT.MA_DVQHNS_CHA IN ('''||P_MADONVI||''') ';
        END IF;
    IF TRIM(P_MA_CONGTRINH) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND DT.MA_DVQHNS IN ('''||P_MA_CONGTRINH||''') ';
        END IF;
 QUERY_STR := 'SELECT *
    FROM (SELECT DT.MA_DVQHNS, 
                 DT.TEN_DVQHNS,
                 DT.LoaiDuToan,
                 DT.So_DuToan,
                 TH.So_ThucHien
            FROM (  SELECT DT.MA_DVQHNS  AS MA_DVQHNS,
                           CAST (''00'' AS NVARCHAR2 (15)) AS LoaiDuToan,
                           dvqh.TEN_DVQHNS as TEN_DVQHNS,
                           SUM (DT.GIA_TRI_HACH_TOAN) AS So_DuToan
                      FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh. MA_DVQHNS 
                     WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB'' 
                        and DT.MA_DVQHNS like ''7%'' 
                           AND DT.NGAY_HIEU_LUC >=
                                  TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND DT.NGAY_HIEU_LUC <=
                                  TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY DT.MA_DVQHNS,dvqh.TEN_DVQHNS) DT
                 -- Left join Chi
                 LEFT JOIN
                 (  SELECT MA_DVQHNS,
                           SUM (GIA_TRI_HACH_TOAN) AS So_ThucHien
                      FROM PHA_HACHTOAN_CHI 
                     WHERE     1 = 1
                           AND NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY MA_DVQHNS) TH
                    ON DT.MA_DVQHNS = TH.MA_DVQHNS 
                    where 1=1 '||P_INSERT||' 
          UNION all
            SELECT DT.MA_DVQHNS,
                   dvqh.TEN_DVQHNS as TEN_DVQHNS,
                   DT.ATTRIBUTE8          AS LoaiDuToan,
                   SUM (DT.GIA_TRI_HACH_TOAN) AS So_DuToan,
                   SUM(TH.GIA_TRI_HACH_TOAN)  AS So_ThucHien
              FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh. MA_DVQHNS
              inner join PHA_HACHTOAN_CHI TH on dvqh.MA_DVQHNS = TH.MA_DVQHNS
             WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''  '||P_INSERT||' 
                   AND DT.MA_DVQHNS like ''7%'' 
                   AND DT.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND DT.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                   AND TH.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND TH.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
          GROUP BY DT.MA_DVQHNS, DT.ATTRIBUTE8,dvqh.TEN_DVQHNS)
          where LoaiDuToan <> ''00''
ORDER BY MA_DVQHNS, LoaiDuToan ';
 BEGIN
 --DBMS_OUTPUT.put_line (QUERY_STR);
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;
END PROC_BCDT_CHI_DTXD_CB;

/
--------------------------------------------------------
--  DDL for Procedure PROC_BCDT_CHI_DTXD_CB_DV
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_BCDT_CHI_DTXD_CB_DV" (P_MADONVI VARCHAR2,P_MA_CONGTRINH VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
as
    QUERY_STR VARCHAR(20000);
    P_INSERT VARCHAR(20000);
begin
    IF TRIM(P_MADONVI) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND DT.MA_DVQHNS_CHA IN ('''||P_MADONVI||''') ';
        END IF;
    IF TRIM(P_MA_CONGTRINH) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND DT.MA_DVQHNS IN ('''||P_MA_CONGTRINH||''') ';
        END IF;
 QUERY_STR := 'select * from (select DT.MA_DVQHNS,
                                     sy.TEN_DVQHNS,
                                     DT.TEN_NGUON_NSNN,
                                     sy.MA_DVQHNS_CHA,
                                     TongDuToan,
                                     So_ThucHien 
                             from (SELECT DT.MA_DVQHNS AS MA_DVQHNS, 
                                          dm.TEN_NGUON_NSNN as TEN_NGUON_NSNN,
                                          SUM (DT.GIA_TRI_HACH_TOAN) AS TongDuToan
                                   FROM PHA_DUTOAN DT inner join DM_NGUON_NSNN dm on dt.MA_NGUON_NSNN = dm.MA_NGUON_NSNN
                                       -- DT.MA_DVQHNS like ''7%''  
                                      WHERE DT.NGAY_HIEU_LUC >=TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                                            AND DT.NGAY_HIEU_LUC <=TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                                   GROUP BY DT.MA_DVQHNS,dm.TEN_NGUON_NSNN) DT
                            -- Left join Chi
                                LEFT JOIN
                                  (SELECT MA_DVQHNS,
                                          SUM (GIA_TRI_HACH_TOAN) AS So_ThucHien
                                   FROM PHA_HACHTOAN_CHI
                                   WHERE     1 = 1 AND NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                                                    AND NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                                   GROUP BY MA_DVQHNS) TH
                                ON DT.MA_DVQHNS = TH.MA_DVQHNS 
                                left join 
                                SYS_DVQHNS sy on dt.MA_DVQHNS = sy.MA_DVQHNS
                                where 1=1 '||P_INSERT||' 
                                 )
                            order by MA_DVQHNS';
 BEGIN
 DBMS_OUTPUT.put_line (QUERY_STR);
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;
END PROC_BCDT_CHI_DTXD_CB_DV;

/
--------------------------------------------------------
--  DDL for Procedure PROC_BCDT_CHI_DTXD_CB_NG
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_BCDT_CHI_DTXD_CB_NG" (P_MADONVI VARCHAR2,P_MA_CONGTRINH VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
as
    QUERY_STR VARCHAR(20000);
    P_INSERT VARCHAR(20000);
begin
    IF TRIM(P_MADONVI) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND DT.MA_DVQHNS_CHA IN ('''||P_MADONVI||''') ';
        END IF;
    IF TRIM(P_MA_CONGTRINH) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND DT.MA_DVQHNS IN ('''||P_MA_CONGTRINH||''') ';
        END IF;
 QUERY_STR := 'select * from (select DT.MA_DVQHNS,
                                     sy.TEN_DVQHNS,
                                     DT.TEN_NGUON_NSNN,
                                     DT.LoaiDuToan,
                                     TongDuToan,
                                     TH.So_ThucHien 
                             from (SELECT DT.MA_DVQHNS  AS MA_DVQHNS,
                           CAST (''00'' AS NVARCHAR2 (15)) AS LoaiDuToan,
                           dvqh.TEN_DVQHNS as TEN_DVQHNS,
                           SUM (DT.GIA_TRI_HACH_TOAN) AS TongDuToan,
                           dm.TEN_NGUON_NSNN as TEN_NGUON_NSNN
                      FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh. MA_DVQHNS 
                      inner join DM_NGUON_NSNN dm on dt.MA_NGUON_NSNN = dm.MA_NGUON_NSNN
                     WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB'' 
                        and DT.MA_DVQHNS like ''7%'' 
                           AND DT.NGAY_HIEU_LUC >=
                                  TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND DT.NGAY_HIEU_LUC <=
                                  TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY DT.MA_DVQHNS,dvqh.TEN_DVQHNS,dm.TEN_NGUON_NSNN) DT
                                   
                            -- Left join Chi
                                LEFT JOIN
                                  (SELECT MA_DVQHNS,
                                          SUM (GIA_TRI_HACH_TOAN) AS So_ThucHien
                                   FROM PHA_HACHTOAN_CHI
                                   WHERE     1 = 1 AND NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                                                    AND NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                                   GROUP BY MA_DVQHNS) TH
                                ON DT.MA_DVQHNS = TH.MA_DVQHNS 
                                left join 
                                SYS_DVQHNS sy on dt.MA_DVQHNS = sy.MA_DVQHNS
                                where 1=1 '||P_INSERT||' 
                                UNION all
            SELECT DT.MA_DVQHNS,
                   dvqh.TEN_DVQHNS as TEN_DVQHNS,
                   DT.TEN_NGUON_NSNN,
                   DT.ATTRIBUTE8          AS LoaiDuToan,
                   SUM (DT.GIA_TRI_HACH_TOAN) AS TongDuToan,
                   SUM (TH.GIA_TRI_HACH_TOAN) AS So_ThucHien
              FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh. MA_DVQHNS inner join PHA_HACHTOAN_CHI TH on DT.MA_DVQHNS = TH.MA_DVQHNS
             WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''  '||P_INSERT||' 
                   AND DT.MA_DVQHNS like ''7%'' 
                   AND DT.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND DT.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                   AND TH.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND TH.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
          GROUP BY DT.MA_DVQHNS, DT.TEN_NGUON_NSNN, DT.ATTRIBUTE8,dvqh.TEN_DVQHNS)
          where LoaiDuToan <> ''00'' 
                            order by MA_DVQHNS,LoaiDuToan';
 BEGIN
 DBMS_OUTPUT.put_line (QUERY_STR);
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;
END PROC_BCDT_CHI_DTXD_CB_NG;

/
--------------------------------------------------------
--  DDL for Procedure PROC_BCDT_CHI_DV
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_BCDT_CHI_DV" (P_MADONVI VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
as
    QUERY_STR VARCHAR(20000);
    P_INSERT VARCHAR(20000);
    V_TK_GTGC VARCHAR(500) := '''8953/8954/8955/8958/8956/8957/''';
begin
    IF TRIM(P_MADONVI) IS NOT NULL THEN 
        P_INSERT:= P_INSERT ||' AND MA_DVQHNS IN ('''||P_MADONVI||''') ';
        END IF;
 QUERY_STR := 'SELECT *
    FROM (SELECT DT.MA_DVQHNS,
                 DT.TEN_DVQHNS,
                 DT.LoaiDuToan,
                 DT.So_DuToan,
                 TH.So_ThucHien,
                 TH.So_GhiThuGhiChi
            FROM (  SELECT DT.MA_DVQHNS              AS MA_DVQHNS,
                           dvqh.TEN_DVQHNS as TEN_DVQHNS,
                           CAST (''00'' AS NVARCHAR2 (15)) AS LoaiDuToan,                          
                           SUM (DT.GIA_TRI_HACH_TOAN) AS So_DuToan
                      FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh.MA_DVQHNS
                     WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''
                     AND DT.MA_DVQHNS <> ''0000000''
                           AND DT.NGAY_HIEU_LUC >=
                                  TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND DT.NGAY_HIEU_LUC <=
                                  TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY DT.MA_DVQHNS,dvqh.TEN_DVQHNS) DT
                 -- Left join Chi
                 LEFT JOIN
                 (  SELECT MA_DVQHNS,
                           SUM (GIA_TRI_HACH_TOAN) AS So_ThucHien,
                           SUM (CASE
                                   WHEN Instr(' || V_TK_GTGC || ',MA_TKTN || ''/'') >0
                                   THEN
                                      GIA_TRI_HACH_TOAN
                                   ELSE
                                      0
                                END) AS
                              So_GhiThuGhiChi
                      FROM PHA_HACHTOAN_CHI
                     WHERE     1 = 1
                           AND NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY MA_DVQHNS) TH
                    ON DT.MA_DVQHNS = TH.MA_DVQHNS
          UNION all
            SELECT DT.MA_DVQHNS,
                    dvqh.TEN_DVQHNS as TEN_DVQHNS,
                   DT.ATTRIBUTE8          AS LoaiDuToan, 
                   SUM (DT.GIA_TRI_HACH_TOAN) AS So_DuToan,
                   SUM (TH.GIA_TRI_HACH_TOAN) AS So_ThucHien,
                    SUM (CASE WHEN Instr(' || V_TK_GTGC || ',TH.MA_TKTN || ''/'') >0
                                   THEN
                                      TH.GIA_TRI_HACH_TOAN
                                   ELSE
                                      0
                                END) AS So_GhiThuGhiChi
              FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh. MA_DVQHNS 
              inner join PHA_HACHTOAN_CHI TH on DT.MA_DVQHNS = TH.MA_DVQHNS
             WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''
             AND DT.MA_DVQHNS <> ''0000000''
                   AND DT.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND DT.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                   AND TH.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND TH.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
          GROUP BY DT.MA_DVQHNS, DT.ATTRIBUTE8,dvqh.TEN_DVQHNS)
   WHERE 1 = 1 '||P_INSERT||' AND LOAIDUTOAN <>''00''
ORDER BY MA_DVQHNS, LOAIDUTOAN ';
--DBMS_OUTPUT.put_line ('<your message>' || QUERY_STR);
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
END PROC_BCDT_CHI_DV;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B202
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B202" (P_NGUONNS VARCHAR2,P_KHOAN VARCHAR2,P_MAKB VARCHAR2, P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
        ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
   IF TRIM(P_NGUONNS) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_DVQHNS in ('||P_NGUONNS||')';
        END IF;     
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   /*IF TRIM(P_DVQHNS) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_DVQHNS in ('||P_DVQHNS||')';
        END IF;
   */
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))
               THEN
                  GIA_TRI_HACH_TOAN /NVL('|| DONVI_TIEN ||',1)
               ELSE
                  0
            END)
            AS PS,
         SUM (NVL(GIA_TRI_HACH_TOAN,0))/NVL('|| DONVI_TIEN ||',1)
            AS LK
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 and '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||'  
GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( sum(PS) as PS, Sum(LK) as LK
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )order by MA_NGHIEPVU desc,MA_CAPMLNS asc, MA_CHUONG asc'; 
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
END PROC_PHA_B202;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B202_HINH_CAY
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B202_HINH_CAY" (P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         TEN_CAP,
         TEN_CHUONG,
         TEN_LOAI,
         TEN_NGANHKT,
         TEN_MUC,
         TEN_TIEUMUC,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''||TUNGAY_HL||''', ''DD/MM/YY'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||DENNGAY_HL||''', ''DD/MM/YY'')
                     and NGAY_KET_SO >=TO_DATE ('''||TUNGAY_KS||''', ''DD/MM/YY'') 
                     and NGAY_KET_SO <=TO_DATE ('''||DENNGAY_KS||''', ''DD/MM/YY''))
               THEN
                  GIA_TRI_HACH_TOAN /'|| DONVI_TIEN ||'
               ELSE
                  0
            END)
            AS PS
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 and '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' 
GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN,TEN_CAP,TEN_CHUONG,TEN_LOAI,TEN_NGANHKT,TEN_MUC,TEN_TIEUMUC
)
PIVOT ( sum(PS) as PS
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )
order by  MA_CHUONG'; 
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
END PROC_PHA_B202_HINH_CAY;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B202_HOP_MUC2
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B202_HOP_MUC2" (P_CAP VARCHAR2,P_NHOM VARCHAR2,P_TIEUNHOM VARCHAR2, P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_NHOM) IS NOT NULL THEN 
         select STC_PA_SYS.FNC_CONVERT_FORMULA (P_NHOM) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUNHOM) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUNHOM) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        --P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_MUC in ('||P_MUC||')';
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
  -- IF DONVI_TIEN IS NULL THEN 
    --    DONVI_TIEN:= 1;
     --   END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAP,
         MA_CAPMLNS,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,
         MA_NHOM,
         MA_TIEUNHOM,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))
               THEN
                  GIA_TRI_HACH_TOAN /NVL('|| DONVI_TIEN ||',1)
               ELSE
                  0
            END)
            AS PS
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 and  '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '
    ||P_SQL_INSERT||'
GROUP BY MA_NGHIEPVU, MA_CAP,MA_CAPMLNS, MA_MUC, MA_TIEUMUC, MA_NHOM, MA_TIEUNHOM,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( sum(PS) as PS
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )order by MA_NGHIEPVU desc,MA_CAPMLNS asc'; 
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
END PROC_PHA_B202_HOP_MUC2;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B202_PHANII
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B202_PHANII" (P_NHOM VARCHAR2,P_TIEUNHOM VARCHAR2, P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_NHOM) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_NHOM in ('||P_NHOM||')';
        END IF;
   IF TRIM(P_TIEUNHOM) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_TIEUNHOM in ('||P_TIEUNHOM||')';
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_MUC in ('||P_MUC||')';
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_TIEUMUC in ('||P_TIEUMUC||')';
        END IF;
  -- IF DONVI_TIEN IS NULL THEN 
    --    DONVI_TIEN:= 1;
     --   END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAP,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,
         MA_NHOM,
         MA_TIEUNHOM,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))
               THEN
                  GIA_TRI_HACH_TOAN /NVL('|| DONVI_TIEN ||',1)
               ELSE
                  0
            END)
            AS PS,
         SUM (NVL(GIA_TRI_HACH_TOAN,0))/NVL('|| DONVI_TIEN ||',1)
            AS LK
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 and  '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '
    ||P_SQL_INSERT||'
GROUP BY MA_NGHIEPVU, MA_CAP, MA_MUC, MA_TIEUMUC, MA_NHOM, MA_TIEUNHOM,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( sum(PS) as PS, sum(LK) as LK
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )'; 
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
END PROC_PHA_B202_PhanII;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B303
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B303" (P_MAKB VARCHAR2,P_KHOAN VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAP in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))
               THEN
                  GIA_TRI_HACH_TOAN /NVL('|| DONVI_TIEN ||',1)
               ELSE
                  0
            END)
            AS PS,
         SUM (NVL(GIA_TRI_HACH_TOAN,0))/NVL('|| DONVI_TIEN ||',1)
            AS LK
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' 
GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( sum(PS) as PS, Sum(LK) as LK
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )
order by  MA_NGHIEPVU DESC'; 
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
END PROC_PHA_B303;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B303_HINH_CAY
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B303_HINH_CAY" (P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         TEN_CAP,
         TEN_CHUONG,
         TEN_LOAI,
         TEN_NGANHKT,
         TEN_MUC,
         TEN_TIEUMUC,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''||TUNGAY_HL||''', ''DD/MM/YY'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||DENNGAY_HL||''', ''DD/MM/YY'')
                     and NGAY_KET_SO >=TO_DATE ('''||TUNGAY_KS||''', ''DD/MM/YY'') 
                     and NGAY_KET_SO <=TO_DATE ('''||DENNGAY_KS||''', ''DD/MM/YY''))
               THEN
                  GIA_TRI_HACH_TOAN /'|| DONVI_TIEN ||'
               ELSE
                  0
            END)
            AS PS
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and MA_CAP in (''2'',''3'',''4'') and '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||' 
GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN,TEN_CAP,TEN_CHUONG,TEN_LOAI,TEN_NGANHKT,TEN_MUC,TEN_TIEUMUC
)
PIVOT ( sum(PS) as PS
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )
order by  MA_CHUONG'; 
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
END PROC_PHA_B303_HINH_CAY;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_B303_PHANII
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_B303_PHANII" (P_NHOM VARCHAR2,P_TIEUNHOM VARCHAR2, P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_NHOM) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_NHOM in ('||P_NHOM||')';
        END IF;
   IF TRIM(P_TIEUNHOM) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_TIEUNHOM in ('||P_TIEUNHOM||')';
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_MUC in ('||P_MUC||')';
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_TIEUMUC in ('||P_TIEUMUC||')';
        END IF;
  -- IF DONVI_TIEN IS NULL THEN 
    --    DONVI_TIEN:= 1;
     --   END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAP,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,
         MA_NHOM,
         MA_TIEUNHOM,
         SUM (
            CASE
               WHEN (    NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy''))
               THEN
                  GIA_TRI_HACH_TOAN /NVL('|| DONVI_TIEN ||',1)
               ELSE
                  0
            END)
            AS PS,
         SUM (NVL(GIA_TRI_HACH_TOAN,0))/NVL('|| DONVI_TIEN ||',1)
            AS LK
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and '||
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || v_tu_nam  ||''', ''ddMMyyyy'')
    AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') '||P_SQL_INSERT||'
GROUP BY MA_NGHIEPVU, MA_CAP, MA_MUC, MA_TIEUMUC, MA_NHOM, MA_TIEUNHOM,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( sum(PS) as PS, Sum(LK) as LK
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )'; 
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
END PROC_PHA_B303_PhanII;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_BC_THEO_DMCT
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_BC_THEO_DMCT" (
   LOAI_BC      IN     VARCHAR2,
   mabaocao     IN     NVARCHAR2,
   DONVI_TIEN   IN     NUMBER,
   TUNGAY_HL    IN     DATE,
   DENNGAY_HL   IN     DATE,
   TUNGAY_KS    IN     DATE,
   DENNGAY_KS   IN     DATE,
   CUR1            OUT SYS_REFCURSOR)
AS
   Row_Type              DM_CHITIEU_BAOCAO%ROWTYPE; -- Chuyen doi FEET sang day
   CUR                   SYS_REFCURSOR;
   STT                   NVARCHAR2 (500);
   SAPXEP                NVARCHAR2 (100);
   MA_CHITIEU            VARCHAR2 (50);
   NGAY_HL               DATE;
   NGAY_HET_HL           DATE;
   TEN_CHITIEU           VARCHAR2 (500);
   TRANGTHAI             VARCHAR2 (1);
   MA_DONG               VARCHAR2 (100);
   INDAM                 NUMBER (10, 0);
   INNGHIENG             NUMBER (10, 0);
   HIENTHI               VARCHAR2 (1);
   LOAI                  NUMBER (10, 0);
   DAU                   NUMBER (10, 0);
   ILV                   NUMBER (10, 0);
   TW_PS                 NUMBER (15, 0);
   TW_LK                 NUMBER (15, 0);
   TINH_PS               NUMBER (15, 0);
   TINH_LK               NUMBER (15, 0);
   HUYEN_PS              NUMBER (15, 0);
   HUYEN_LK              NUMBER (15, 0);
   XA_PS                 NUMBER (15, 0);
   XA_LK                 NUMBER (15, 0);

   --
   DMCT_BC_INDAM         DM_CHITIEU_BAOCAO.INDAM%TYPE;
   DMCT_BC_INNGHIENG     DM_CHITIEU_BAOCAO.INNGHIENG%TYPE;
   DMCT_BC_HIENTHI       DM_CHITIEU_BAOCAO.HIENTHI%TYPE;
   DMCT_BC_STT           DM_CHITIEU_BAOCAO.STT%TYPE;
   DMCT_BC_SAPXEP        DM_CHITIEU_BAOCAO.SAPXEP%TYPE;
   DMCT_BC_MA_DONG       DM_CHITIEU_BAOCAO.MA_DONG%TYPE;
   DMCT_BC_TEN_CHITIEU   DM_CHITIEU_BAOCAO.TEN_CHITIEU%TYPE;
   DMCT_BC_NGAY_HL       DM_CHITIEU_BAOCAO.NGAY_HL%TYPE;
   DMCT_BC_DAU           DM_CHITIEU_BAOCAO.DAU%TYPE;
BEGIN

   DELETE TEMPTB_DMCT;
    -- Tong h?p d? li?u vào b?ng temp
   STC_PA_SYS.PRC_TH_MLNS (TUNGAY_HL, DENNGAY_HL, LOAI_BC);
   --return;
   -- 1. Lay du lieu [Chi tieu, so lieu TW, Tinh, Huyen, Xa (sau khi convert)] vao Con tro

   OPEN CUR FOR
      SELECT DMCT_BC.INDAM,
             DMCT_BC.INNGHIENG,
             DMCT_BC.HIENTHI,
             DMCT_BC.STT,
             DMCT_BC.SAPXEP,
             DMCT_BC.MA_DONG,
             DMCT_BC.TEN_CHITIEU,
             DMCT_BC.NGAY_HL,
             DMCT_BC.DAU,
             NVL (GT.TW_PS, 0),
             NVL (GT.TW_LK, 0),
             NVL (GT.TINH_PS, 0),
             NVL (GT.TINH_LK, 0),
             NVL (GT.HUYEN_PS, 0),
             NVL (GT.HUYEN_LK, 0),
             NVL (GT.XA_PS, 0),
             NVL (GT.XA_LK, 0)
        FROM DM_CHITIEU_BAOCAO DMCT_BC,
             TABLE (STC_PHA_BCDMCT.FCN_GET_PHA_BCDMCT (LOAI_BC,
                                                       DMCT_BC.CONGTHUC,
                                                       DMCT_BC.CONGTHUC_SEG1,
                                                       DMCT_BC.CONGTHUC_SEG2,
                                                       TUNGAY_HL,
                                                       DENNGAY_HL,
                                                       TUNGAY_KS,
                                                       DENNGAY_KS,
                                                       DONVI_TIEN)) GT
       WHERE DMCT_BC.MA_BAOCAO = mabaocao;

   -- End Of 1.
   --2. Lap Con tro sau do insert tung dong du lieu vao bang Temp
   LOOP
      FETCH CUR
         INTO /*INDAM,
              INNGHIENG,
              HIENTHI,
              STT,
              SAPXEP,
              MA_DONG,
              TEN_CHITIEU,
              NGAY_HL,
              DAU,*/
              DMCT_BC_INDAM, 
              DMCT_BC_INNGHIENG,
              DMCT_BC_HIENTHI,
              DMCT_BC_STT,
              DMCT_BC_SAPXEP,
              DMCT_BC_MA_DONG,
              DMCT_BC_TEN_CHITIEU,
              DMCT_BC_NGAY_HL,
              DMCT_BC_DAU,
              TW_PS,
              TW_LK,
              TINH_PS,
              TINH_LK,
              HUYEN_PS,
              HUYEN_LK,
              XA_PS,
              XA_LK;

      IF CUR%FOUND
      THEN
         BEGIN
            INSERT INTO temptb_dmct (STT,
                                     SAPXEP,
                                     NGAY_HL,
                                     TEN_CHITIEU,
                                     MA_DONG,
                                     INDAM,
                                     INNGHIENG,
                                     HIENTHI, 
                                     DAU,
                                     TW_PS,
                                     TW_LK,
                                     TINH_PS,
                                     TINH_LK,
                                     HUYEN_PS,
                                     HUYEN_LK,
                                     XA_PS,
                                     XA_LK)
                 VALUES (DMCT_BC_STT,
                         DMCT_BC_SAPXEP,
                         DMCT_BC_NGAY_HL,
                         DMCT_BC_TEN_CHITIEU,
                         DMCT_BC_MA_DONG,
                         DMCT_BC_INDAM,
                         DMCT_BC_INNGHIENG,
                         DMCT_BC_HIENTHI,
                         DMCT_BC_DAU,
                         TW_PS,
                         TW_LK,
                         TINH_PS,
                         TINH_LK,
                         HUYEN_PS,
                         HUYEN_LK,
                         XA_PS,
                         XA_LK);
         END;
      ELSE
         EXIT;
      END IF;
   END LOOP;

   -- End Of 2.
   -- 3. Tra du lieu ve con tro Out de len bao cao
   STC_PA_SYS.PRC_SUM_UP;

   OPEN CUR1 FOR
        SELECT *
          FROM temptb_dmct
      ORDER BY MA_DONG;
--OPEN CUR1 FOR
--     SELECT t.STT,
--            t.SAPXEP,
--            t.NGAY_HL,
--            t.TEN_CHITIEU,
--            t.MA_DONG,
--            t.INDAM,
--            t.INNGHIENG,
--            t.HIENTHI,
--            t.DAU,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE TW_PS * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  TW_PS
--            END
--               AS TW_PS,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE TW_LK * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  TW_LK
--            END
--               AS TW_LK,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (
--                             CASE DAU WHEN 0 THEN 0 ELSE TINH_PS * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  TINH_PS
--            END
--               AS TINH_PS,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (
--                             CASE DAU WHEN 0 THEN 0 ELSE TINH_LK * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  TINH_LK
--            END
--               AS TINH_LK,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (
--                             CASE DAU WHEN 0 THEN 0 ELSE HUYEN_PS * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  HUYEN_PS
--            END
--               AS HUYEN_PS,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (
--                             CASE DAU WHEN 0 THEN 0 ELSE HUYEN_LK * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  HUYEN_LK
--            END
--               AS HUYEN_LK,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE XA_PS * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  XA_PS
--            END
--               AS XA_PS,
--            CASE
--               WHEN DAU <> 0
--               THEN
--                  (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE XA_LK * DAU END)
--                     FROM temptb_dmct
--                    WHERE MA_DONG LIKE t.MA_DONG || '%')
--               ELSE
--                  XA_LK
--            END
--               AS XA_LK
--       FROM temptb_dmct t
--   ORDER BY MA_DONG;
END PROC_PHA_BC_THEO_DMCT;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL06_B52
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL06_B52" (
   LOAI_BC          IN      nvarchar2,
   P_CONGTHUC      IN     nVARCHAR2,
   DONVI_TIEN   IN     NUMBER,
   P_NAM        IN     nVARCHAR2,    
   CUR1            OUT SYS_REFCURSOR)
AS
BEGIN

    ---t?ng h?p d? li?u
   STC_PA_SYS.PRC_TH_MLNS (TO_DATE(TO_CHAR('0101'||P_NAM),'ddMMyyyy'), TO_DATE(TO_CHAR('3112'||P_NAM),'ddMMyyyy'), LOAI_BC);
   -- l?y d? li?u
    OPEN CUR1 FOR SELECT  STC_PHA_BCDMCT.FCN_GET_DATA_FROM_CT(P_CONGTHUC)/DONVI_TIEN AS GIA_TRI FROM DUAL;
END PROC_PHA_PL06_B52;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL08_B04
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL08_B04" (P_NGUONNS VARCHAR2,P_KHOAN VARCHAR2,P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
     ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
   IF TRIM(P_NGUONNS) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_DVQHNS in ('||P_NGUONNS||')';
        END IF;
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS LK
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 '||P_SQL_INSERT|| 
    ' And To_Char(NGAY_HIEU_LUC,' ||    Chr(39) || 'yyyy' || Chr(39) || ') = ' || P_NAM ||
    ' And MA_NGHIEPVU In (Select MA_NGHIEPVU From Dm_NghiepVu Where SUBSTR(CQD,2,1) = ' || Chr(39)|| '1' || Chr(39) ||  ')' ||    
' GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( Sum(LK) as LK
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )
order by  MA_NGHIEPVU DESC'; 
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
END PROC_PHA_PL08_B04;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL08_B05
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL08_B05" (P_NGUONNS VARCHAR2,P_KHOAN VARCHAR2,P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number,PHANLOAI_CAP VARCHAR2, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
    ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
   IF TRIM(P_NGUONNS) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_DVQHNS in ('||P_NGUONNS||')';
        END IF;     
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   -- PHANLOAI_CAP = 0 là c?p s?
   -- PHANLOAI_CAP = 1 là c?p ??a ph??ng
IF PHANLOAI_CAP = '0' THEN 
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS LK
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and MA_CAP IN (''2'',''3'',''4'') '||P_SQL_INSERT|| 
    ' And To_Char(NGAY_HIEU_LUC,' ||    Chr(39) || 'yyyy' || Chr(39) || ') = ' || P_NAM ||
    -- D? LI?U HI?N T?I TRONG B?NG Dm_NghiepVu ch?a có MA_NGHIEPVU = Chi_Test
    ' And MA_NGHIEPVU In (Select MA_NGHIEPVU From Dm_NghiepVu Where SUBSTR(CQD,2,1) = ' || Chr(39)|| '1' || Chr(39) ||  ')' ||
  ' GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
order by  MA_NGHIEPVU DESC'; 
ELSE
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS LK
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and MA_CAP IN (''3'',''4'') '||P_SQL_INSERT|| 
    ' And To_Char(NGAY_HIEU_LUC,' ||    Chr(39) || 'yyyy' || Chr(39) || ') = ' || P_NAM ||
    ' And MA_NGHIEPVU In (Select MA_NGHIEPVU From Dm_NghiepVu Where SUBSTR(CQD,2,1) = ' || Chr(39)|| '1' || Chr(39) ||  ')' || 
  'GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
order by  MA_NGHIEPVU DESC'; 
END IF;

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
END PROC_PHA_PL08_B05;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL08_B05_XA_PHUONG
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL08_B05_XA_PHUONG" (P_MADIABAN VARCHAR2,P_KHOAN VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) 
AS 
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   str_pivot    VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;

INSERT INTO TEMP_PL08BM05 
(MA_NGHIEPVU,MA_CHUONG,MA_CAP,MA_DIABAN,TEN_DIABAN,MA_MUC,MA_TIEUMUC,
MA_CAPMLNS,MA_LOAI,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN,MA_NGANHKT,LK)
select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,         
         MA_DIABAN,
         TEN_DIABAN,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl(DONVI_TIEN,1))AS LK
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 and MA_CAP IN (4)  
    AND To_Char(NGAY_HIEU_LUC,'yyyy') = P_NAM
    GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP,MA_DIABAN,TEN_DIABAN, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
);
DECLARE    
  c_madiaban VARCHAR2(50);    
  c_tendiaban VARCHAR2(50);      
  CURSOR C_TEMP_PL08BM05 is       
    SELECT DISTINCT MA_DIABAN, TEN_DIABAN FROM TEMP_PL08BM05 ORDER BY MA_DIABAN;
BEGIN    
  OPEN C_TEMP_PL08BM05;    
  LOOP    
  FETCH C_TEMP_PL08BM05 into c_madiaban, c_tendiaban;       
   str_pivot := str_pivot || Chr(39) || c_madiaban || Chr(39) || ' AS XA' || c_madiaban;
    EXIT WHEN C_TEMP_PL08BM05%notfound;
    --ten dia ban dang null tam thoi fix cung
    str_pivot := str_pivot || ',';
    --dbms_output.put_line(str_pivot);    
  END LOOP;    
CLOSE C_TEMP_PL08BM05; 
END;

QUERY_STR:='SELECT * FROM TEMP_PL08BM05
            PIVOT (Sum(LK) as LK
            FOR MA_DIABAN
            IN ('||str_pivot||'))';      
--DBMS_OUTPUT.put_line (QUERY_STR);
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
     
END PROC_PHA_PL08_B05_XA_PHUONG;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL08_B05_XA_PHUONG1
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL08_B05_XA_PHUONG1" (P_MADIABAN VARCHAR2,P_KHOAN VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) 
AS 
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   str_pivot    VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_LOAI) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_LOAI) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;

INSERT INTO TEMP_PL08BM05 
(MA_NGHIEPVU,MA_CHUONG,MA_CAP,MA_DIABAN,TEN_DIABAN,MA_MUC,MA_TIEUMUC,
MA_CAPMLNS,MA_LOAI,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN,MA_NGANHKT,LK)
select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,         
         MA_DIABAN,
         TEN_DIABAN,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl(DONVI_TIEN,1))AS LK
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 and MA_CAP IN (4)  
    AND To_Char(NGAY_HIEU_LUC,'yyyy') = P_NAM
    GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP,MA_DIABAN,TEN_DIABAN, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
);
DECLARE    
  c_madiaban VARCHAR2(50);    
  c_tendiaban VARCHAR2(50);      
  CURSOR C_TEMP_PL08BM05 is       
    SELECT DISTINCT MA_DIABAN, TEN_DIABAN FROM TEMP_PL08BM05;
BEGIN    
  OPEN C_TEMP_PL08BM05;    
  LOOP    
  FETCH C_TEMP_PL08BM05 into c_madiaban, c_tendiaban;       
   str_pivot := str_pivot || Chr(39) || c_madiaban || Chr(39) ||'AS XA' || c_madiaban;
    EXIT WHEN C_TEMP_PL08BM05%notfound;
    --ten dia ban dang null tam thoi fix cung
    str_pivot := str_pivot || ',';
    --dbms_output.put_line(str_pivot);    
  END LOOP;    
CLOSE C_TEMP_PL08BM05; 
END;

QUERY_STR:='SELECT * FROM TEMP_PL08BM05
            PIVOT (Sum(LK) as LK
            FOR MA_DIABAN
            IN ('||str_pivot||'))';      
--DBMS_OUTPUT.put_line (QUERY_STR);
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
     
END PROC_PHA_PL08_B05_XA_PHUONG1;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL08_BM04_HM1
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL08_BM04_HM1" (P_CAP VARCHAR2, P_NAM VARCHAR2,P_NHOM VARCHAR2,P_TIEUNHOM VARCHAR2, P_MUC VARCHAR2, P_TIEUMUC VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_NHOM) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_NHOM in ('||P_NHOM||')';
        END IF;
   IF TRIM(P_TIEUNHOM) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_TIEUNHOM in ('||P_TIEUNHOM||')';
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
  -- IF DONVI_TIEN IS NULL THEN 
    --    DONVI_TIEN:= 1;
     --   END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_MUC,
         MA_CAP,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,
         MA_NHOM,
         MA_TIEUNHOM,
         SUM (GIA_TRI_HACH_TOAN /'|| DONVI_TIEN ||') AS SOQUYETTOAN
    FROM PHA_HACHTOAN_THU b
    WHERE 1=1 '||P_SQL_INSERT||
    ' And To_Char(NGAY_HIEU_LUC,' ||    Chr(39) || 'yyyy' || Chr(39) || ') = ' || P_NAM ||
    ' And MA_NGHIEPVU In (Select MA_NGHIEPVU From Dm_NghiepVu Where SUBSTR(CQD,2,1) = ' || Chr(39)|| '1' || Chr(39) ||  ')' ||    
' GROUP BY MA_NGHIEPVU,MA_MUC, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_NHOM,MA_TIEUNHOM,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
PIVOT ( sum(SOQUYETTOAN) as SOQUYETTOAN
          FOR MA_CAP
          IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
          )'; 
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
END PROC_PHA_PL08_BM04_HM1;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PHA_PL08_BM05_C_C_M_TM
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PHA_PL08_BM05_C_C_M_TM" (P_NGUONNS VARCHAR2,P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
    ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS LK
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and MA_CAP IN (''3'',''4'') '||P_SQL_INSERT|| 
    ' And To_Char(NGAY_HIEU_LUC,' ||    Chr(39) || 'yyyy' || Chr(39) || ') = ' || P_NAM ||
    ' And MA_NGHIEPVU In (Select MA_NGHIEPVU From Dm_NghiepVu Where SUBSTR(CQD,2,1) = ' || Chr(39)|| '1' || Chr(39) ||  ')' ||    
' GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
order by  MA_NGHIEPVU DESC'; 

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
END PROC_PHA_PL08_BM05_C_C_M_TM;

/
--------------------------------------------------------
--  DDL for Procedure PROC_PL08_BM05_C_C_M_TM
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_PL08_BM05_C_C_M_TM" (P_NGUONNS VARCHAR2,P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CAP) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_CAPMLNS in ('||P_CAP||')';
        END IF;
   IF TRIM(P_CHUONG) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CHUONG) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_MUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_MUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   IF TRIM(P_TIEUMUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_TIEUMUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
    ---l?c mã kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
QUERY_STR:='select * FROM (SELECT 
         MA_NGHIEPVU,
         MA_CHUONG,
         MA_CAP,
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         SUM (NVL(GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS LK
    FROM PHA_HACHTOAN_CHI b
    WHERE 1=1 and MA_CAP IN (''3'',''4'') '||P_SQL_INSERT|| 
    ' And To_Char(NGAY_HIEU_LUC,' ||    Chr(39) || 'yyyy' || Chr(39) || ') = ' || P_NAM ||
    ' And MA_NGHIEPVU In (Select MA_NGHIEPVU From Dm_NghiepVu Where SUBSTR(CQD,2,1) = ' || Chr(39)|| '1' || Chr(39) ||  ')' ||    
' GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
)
order by  MA_NGHIEPVU DESC'; 

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
END PROC_PL08_BM05_C_C_M_TM;

/
--------------------------------------------------------
--  DDL for Procedure PROC_TESTDL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "BTSTC"."PROC_TESTDL" (LOAI IN varchar:= 'thu', CUR OUT SYS_REFCURSOR)
as
    rowtype Test_DL%ROWTYPE;
begin
    delete TEMP_MLNS; 
    select * into rowtype from test_dl where name = loai and rownum = 1;
    STC_PA_SYS.PRC_TH_MLNS (To_DATE('0101' || rowtype.nam,'ddMMyyyy'),
                          To_DATE('3112' || rowtype.nam,'ddMMyyyy'),
                          case Loai when 'thu' then 2 else 1 end); 
    open cur for select * from Table(STC_PHA_BCDMCT.FCN_TESTDL(LOAI)); 
end;

/
