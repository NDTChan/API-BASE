create or replace PROCEDURE "PHA_DTXD_MAU_02" (P_CONGTHUC VARCHAR2, TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_CT VARCHAR2(32767);   
   P_SQL_INSERT VARCHAR2(32767);

   MA_TKTN_DT VARCHAR2(50);
   MA_TKTN_VONUNG VARCHAR2(50);
   MA_TKTN_THANHTOAN VARCHAR2(50);
   ATTRIBUTE8_9 VARCHAR2(50);     
   NAM_TRUOC VARCHAR2(50);
   P_NAM VARCHAR2(50);


    BEGIN
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN(P_CONGTHUC) INTO P_CT from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_CT;
    END IF;
        MA_TKTN_DT := '''9%''';
        MA_TKTN_VONUNG := '''9631''';        
        MA_TKTN_THANHTOAN := '''1724,1727''';
        ATTRIBUTE8_9 := '''09''';
        P_NAM := TO_CHAR(DENNGAY_HL,'yyyy');
        NAM_TRUOC := REPLACE(TO_CHAR(TO_NUMBER(P_NAM, '9999') - 1,'9999'),chr(32),'');

       QUERY_STR:='select DT.MA_NGUON_NSNN,DT.MA_CHUONG, DT.TEN_CHUONG, DT.MA_DVQHNS,DT.TEN_DVQHNS, 
            NVL(DT.KH_VON_UNG_NT,0) as KH_VON_UNG_NT,NVL(DT.KH_VON_UNG_HT,0) as KH_VON_UNG_HT, NVL(DT.KH_VON_TH,0)as KH_VON_TH, NVL(TH.SO_THANH_TOAN_NT,0) as SO_THANH_TOAN_NT, NVL(TH.SO_THANH_TOAN_HT,0) as SO_THANH_TOAN_HT
            from
            (
            (select A.MA_NGUON_NSNN,A.MA_CHUONG, A.TEN_CHUONG, A.MA_DVQHNS, B.TEN_DVQHNS, 
            SUM(CASE WHEN (A.MA_TKTN = 9557 and A.ATTRIBUTE8 = ''09'' and  TO_CHAR(A.NGAY_HIEU_LUC,''yyyy'') = '''||NAM_TRUOC||''') THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) as KH_VON_UNG_NT,
            SUM(CASE WHEN (A.MA_TKTN = 9557 and A.ATTRIBUTE8 = ''09'' and  TO_CHAR(A.NGAY_HIEU_LUC,''yyyy'') = '''||P_NAM||''') THEN A.ACCOUNTED_DR/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) as KH_VON_UNG_HT,
            SUM(CASE WHEN (A.MA_TKTN = 9631 and A.ATTRIBUTE8 = ''10'' and TO_CHAR(A.NGAY_HIEU_LUC,''yyyy'') = '''||P_NAM||''') THEN A.GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) as KH_VON_TH             
            from PHA_DUTOAN A 
            left join
            SYS_DVQHNS B on A.MA_DVQHNS = B.MA_DVQHNS
            where 
            A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
            AND A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
            and A.MA_CAP <> 1
            and A.ATTRIBUTE8 in (''09'',''10'')
            and (A.MA_CHUONG between 402 and 599)
            and A.MA_DVQHNS like ''7%''            
            group by A.MA_NGUON_NSNN,A.MA_CHUONG, A.TEN_CHUONG, A.MA_DVQHNS, B.TEN_DVQHNS
            order by A.MA_NGUON_NSNN,A.MA_CHUONG) DT

            left join           

            (select A.MA_NGUON_NSNN,A.MA_CHUONG, A.TEN_CHUONG, A.MA_DVQHNS, B.TEN_DVQHNS, 
            SUM(CASE WHEN (TO_CHAR(A.NGAY_HIEU_LUC,''yyyy'') = '''||NAM_TRUOC||''') THEN (A.ACCOUNTED_DR-A.ACCOUNTED_CR)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) as SO_THANH_TOAN_NT,
            SUM(CASE WHEN (TO_CHAR(A.NGAY_HIEU_LUC,''yyyy'') = '''||P_NAM||''') THEN (A.ACCOUNTED_DR-A.ACCOUNTED_CR)/NVL('|| DONVI_TIEN ||',1) ELSE 0 END) as SO_THANH_TOAN_HT
            from PHA_HACHTOAN_KHAC A 
            left join
            SYS_DVQHNS B on A.MA_DVQHNS = B.MA_DVQHNS
            where 
            A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
            AND A.NGAY_HIEU_LUC <= TO_DATE ('''||to_char(DENNGAY_HL,'ddMMyyyy')||''', ''ddMMyyyy'')
            AND A.NGAY_KET_SO >=TO_DATE ('''||to_char(TUNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'') 
            AND A.NGAY_KET_SO <=TO_DATE ('''||to_char(DENNGAY_KS,'ddMMyyyy')||''', ''ddMMyyyy'')
            and A.MA_TKTN in (1724,1727) and A.MA_CAP <> 1
            and (A.MA_CHUONG between 402 and 599)
            and A.MA_DVQHNS like ''7%''            
            and not A.MA_DVQHNS in (3012708,3012848,3012910,3013121)
            group by A.MA_NGUON_NSNN,A.MA_CHUONG, A.TEN_CHUONG, A.MA_DVQHNS, B.TEN_DVQHNS
            order by A.MA_NGUON_NSNN, A.MA_CHUONG) TH

            on DT.MA_CHUONG = TH.MA_CHUONG and DT.MA_DVQHNS = TH.MA_DVQHNS

            )
            where (DT.KH_VON_UNG_NT + DT.KH_VON_UNG_HT + DT.KH_VON_TH) <> 0 and DT.KH_VON_TH = 0
            order by DT.MA_NGUON_NSNN,DT.MA_CHUONG';



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
END PHA_DTXD_MAU_02;
 