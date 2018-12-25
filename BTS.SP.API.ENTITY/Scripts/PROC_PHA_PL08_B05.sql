create or replace PROCEDURE PROC_PHA_PL08_B05(P_KHOAN VARCHAR2,P_MAKB VARCHAR2,P_CAP VARCHAR2,P_CHUONG VARCHAR2, P_LOAI VARCHAR2,P_MUC VARCHAR2, P_TIEUMUC VARCHAR2, P_NAM VARCHAR2,DONVI_TIEN number,PHANLOAI_CAP VARCHAR2, cur OUT SYS_REFCURSOR) as
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
    ---l?c m? kho b?c
   IF TRIM(P_MAKB) IS NOT NULL THEN 
        P_SQL_INSERT:= P_SQL_INSERT ||' AND b.MA_KBNN in ('||P_MAKB||')';
        END IF;
   IF TRIM(P_KHOAN) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA (P_KHOAN) into P_Q from dual; 
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_Q;
        END IF;
   -- PHANLOAI_CAP = 0 là c?p s?
   -- PHANLOAI_CAP = 1 là c?p ð?a phýõng
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
' GROUP BY MA_NGHIEPVU,MA_CHUONG, MA_CAP, MA_CAPMLNS, MA_MUC, MA_TIEUMUC,MA_LOAI,MA_NGANHKT,MA_KBNN,MA_DVQHNS,MA_NGUON_NSNN
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