create or replace procedure       PROC_PHA_B303(P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   V_TU_NAM VARCHAR(4):= to_char(TUNGAY_HL,'yyyy');
   BEGIN
   IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
QUERY_STR:='select (case MA_NGHIEPVU when Cast(''CHITAMUNG''  as nvarchar2(50)) then Cast(''NGOAICANDOI'' as nvarchar2(50)) else  Cast(''TRONGCANDOI'' as nvarchar2(50)) end) as MA_NGHIEPVU,
         MA_CHUONG,        
         MA_MUC,
         MA_TIEUMUC,
         MA_CAPMLNS,
         MA_LOAI,
         MA_KBNN,
         MA_DVQHNS,
         MA_NGUON_NSNN,         
         MA_NGANHKT,
         TW_PS,
         TINH_PS,
         HUYEN_PS,
         XA_PS,
         TW_LK,
         TINH_LK,
         HUYEN_LK,
         XA_LK 
FROM (SELECT 
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
               WHEN (     NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
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
    ' NGAY_HIEU_LUC >= TO_DATE ('''|| '0101'||V_TU_NAM ||''', ''ddMMyyyy'')
                     AND NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
                     and NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
     ' ||P_SQL_INSERT||'
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