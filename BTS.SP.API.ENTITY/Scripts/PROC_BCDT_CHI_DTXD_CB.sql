create or replace PROCEDURE PROC_BCDT_CHI_DTXD_CB(P_MADONVI VARCHAR2,P_MA_CONGTRINH VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
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
                   0                      AS So_ThucHien
              FROM PHA_DUTOAN DT inner join SYS_DVQHNS dvqh on DT.MA_DVQHNS = dvqh. MA_DVQHNS 
             WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''  '||P_INSERT||' 
                   AND DT.MA_DVQHNS like ''7%'' 
                   AND DT.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND DT.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
          GROUP BY DT.MA_DVQHNS, DT.ATTRIBUTE8,dvqh.TEN_DVQHNS)
ORDER BY MA_DVQHNS, LoaiDuToan ';
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
END PROC_BCDT_CHI_DTXD_CB;