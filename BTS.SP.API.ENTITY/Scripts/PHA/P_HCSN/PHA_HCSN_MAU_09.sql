create or replace procedure PHA_HCSN_MAU_09(P_CONGTHUC VARCHAR2,NAM_HL VARCHAR2, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_CT VARCHAR2(32767);   
   P_SQL_INSERT VARCHAR2(32767);
   
   MA_TKTN VARCHAR2(50);
   MA_TM7 VARCHAR2(50);
   MA_TM8 VARCHAR2(50);
   MA_TM9 VARCHAR2(50);
   MA_TM10 VARCHAR2(50);
   MA_TM11a VARCHAR2(50);
   MA_TM11b VARCHAR2(50); 

    BEGIN
       IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN (P_CONGTHUC) INTO P_CT from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_CT;
        END IF;

        MA_TM7 := '''6406''';
        MA_TM8 := '''6299''';
        MA_TM9 := '''7954''';
        MA_TM10 := '''7951''';
        MA_TM11a := '''7952''';
        MA_TM11b := '''7953''';
        MA_TKTN := '''8%''';
       
    
       QUERY_STR:='select  A.MA_CHUONG AS MA_CHUONG,A.MA_DVQHNS AS MA_DVQHNS, B.TEN_DVQHNS AS TEN_DVQHNS,A.MA_NVC, A.MA_LOAI, A.MA_NGANHKT as MA_KHOAN,            
            SUM (CASE WHEN (A.MA_TKTN like '||MA_TKTN||' AND MA_TIEUMUC = '||MA_TM7||') THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS CHI_THU_NHAP,
            SUM (CASE WHEN (A.MA_TKTN like '||MA_TKTN||' AND MA_TIEUMUC = '||MA_TM8||') THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS CHI_PHUC_LOI,
            SUM (CASE WHEN (A.MA_TKTN like '||MA_TKTN||' AND MA_TIEUMUC = '||MA_TM9||') THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS QUY_PSTN,
            SUM (CASE WHEN (A.MA_TKTN like '||MA_TKTN||' AND MA_TIEUMUC = '||MA_TM10||') THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS QUY_ONDINH_TN,
            SUM (CASE WHEN (A.MA_TKTN like '||MA_TKTN||' AND MA_TIEUMUC = '||MA_TM11a||' AND MA_TIEUMUC = '||MA_TM11b||') THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) AS QUY_KTPL
            
            from PHA_HACHTOAN_CHI A
            inner join SYS_DVQHNS B on B.MA_DVQHNS = A.MA_DVQHNS
            where A.MA_CAPMLNS = ''2'' and A.MA_NVC is not null and A.MA_DVQHNS like ''1%''
            AND A.NGAY_HIEU_LUC >= TO_DATE ('''|| '0101' || NAM_HL  ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''|| '3112' || NAM_HL  ||''', ''ddMMyyyy'')'||P_SQL_INSERT||'
            group by A.MA_CHUONG,A.MA_DVQHNS, B.TEN_DVQHNS,A.MA_NVC, A.MA_LOAI, A.MA_NGANHKT
            order by A.MA_CHUONG';

   DBMS_OUTPUT.put_line (QUERY_STR);
BEGIN
EXECUTE IMMEDIATE QUERY_STR;
OPEN cur FOR QUERY_STR;
EXCEPTION
   WHEN NO_DATA_FOUND
   THEN
      DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
   WHEN OTHERS
   THEN
      DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
END;    
END PHA_HCSN_MAU_09;
 