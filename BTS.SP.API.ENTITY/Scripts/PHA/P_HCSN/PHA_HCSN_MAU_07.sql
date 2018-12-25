create or replace procedure PHA_HCSN_MAU_07(P_CONGTHUC VARCHAR2,NAM_HL VARCHAR2,DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_SQL_INSERT VARCHAR2(32767);
   P_Q VARCHAR2(32767);
   BEGIN
   IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC) into P_Q from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;

QUERY_STR:='select * FROM (SELECT 
         b.MA_NGHIEPVU,
         b.MA_CHUONG,
         b.MA_CAP,
         b.MA_MUC,
         b.MA_TIEUMUC,
         b.MA_CAPMLNS,
         b.MA_LOAI,
         b.MA_KBNN,
         b.MA_DVQHNS,
         b.MA_NGUON_NSNN,         
         b.MA_NGANHKT,
         c.TEN_DVQHNS,
         b.TEN_CAP,
         b.TEN_CHUONG,
         b.TEN_LOAI,
         b.TEN_NGANHKT,
         b.TEN_MUC,
         b.TEN_TIEUMUC,
         SUM (NVL(b.GIA_TRI_HACH_TOAN,0) /nvl('|| DONVI_TIEN ||',1))AS PS
    FROM PHA_HACHTOAN_CHI b LEFT JOIN SYS_DVQHNS c ON b.MA_DVQHNS = c.MA_DVQHNS
    WHERE 1=1 and b.MA_CAP in (''2'',''3'',''4'') '||P_SQL_INSERT||'
    And To_Char(b.NGAY_HIEU_LUC,' || Chr(39) || 'yyyy' || Chr(39) || ') = ' || NAM_HL ||'      
GROUP BY b.MA_NGHIEPVU,b.MA_CHUONG, b.MA_CAP, b.MA_CAPMLNS, 
b.MA_MUC, b.MA_TIEUMUC,b.MA_LOAI,b.MA_NGANHKT,b.MA_KBNN,b.MA_DVQHNS,
b.MA_NGUON_NSNN,c.TEN_DVQHNS,b.TEN_CAP,b.TEN_CHUONG,b.TEN_LOAI,b.TEN_NGANHKT,b.TEN_MUC,b.TEN_TIEUMUC
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
END PHA_HCSN_MAU_07;