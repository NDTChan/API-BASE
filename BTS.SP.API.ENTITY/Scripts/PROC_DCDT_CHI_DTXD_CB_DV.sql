create or replace PROCEDURE PROC_BCDT_CHI_DTXD_CB_DV(P_MADONVI VARCHAR2,P_MA_CONGTRINH VARCHAR2,P_TUNGAY_HL DATE, P_DENNGAY_HL DATE, CUR OUT SYS_REFCURSOR)
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
                                   WHERE     DT.MA_DVQHNS like ''7%''  
                                            AND DT.NGAY_HIEU_LUC >=TO_DATE ('''||P_TUNGAY_HL||''', ''DD/MM/YY'')
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