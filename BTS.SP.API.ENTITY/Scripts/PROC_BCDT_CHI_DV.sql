create or replace PROCEDURE PROC_BCDT_CHI_DV(P_MADONVI VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
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
                 DT.LoaiDuToan,
                 DT.So_DuToan,
                 TH.So_ThucHien,
                 TH.So_GhiThuGhiChi
            FROM (  SELECT DT.MA_DVQHNS              AS MA_DVQHNS,
                           CAST (''00'' AS NVARCHAR2 (15)) AS LoaiDuToan,
                           SUM (DT.GIA_TRI_HACH_TOAN) AS So_DuToan
                      FROM PHA_DUTOAN DT
                     WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''
                           AND DT.NGAY_HIEU_LUC >=
                                  TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND DT.NGAY_HIEU_LUC <=
                                  TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY DT.MA_DVQHNS) DT
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
                                END)
                              So_GhiThuGhiChi
                      FROM PHA_HACHTOAN_CHI
                     WHERE     1 = 1
                           AND NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                           AND NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
                  GROUP BY MA_DVQHNS) TH
                    ON DT.MA_DVQHNS = TH.MA_DVQHNS
          UNION all
            SELECT DT.MA_DVQHNS,
                   DT.ATTRIBUTE8          AS LoaiDuToan,
                   SUM (DT.GIA_TRI_HACH_TOAN) AS So_DuToan,
                   0                      AS So_ThucHien,
                   0                      AS So_GhiThuGhiChi
              FROM PHA_DUTOAN DT
             WHERE     DT.MA_NGHIEPVU = ''DUTOAN_XDCB''
                   AND DT.NGAY_HIEU_LUC >= TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
                   AND DT.NGAY_HIEU_LUC <= TO_DATE ('''||P_DENNGAY_HL||''', ''DD/MM/YY'')
          GROUP BY DT.MA_DVQHNS, DT.ATTRIBUTE8)
   WHERE 1 = 1 '||P_INSERT||' 
ORDER BY MA_DVQHNS, LoaiDuToan ';
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