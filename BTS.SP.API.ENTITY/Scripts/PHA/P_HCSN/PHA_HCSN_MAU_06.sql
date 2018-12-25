create or replace PROCEDURE "PHA_HCSN_MAU_06" (P_MA_DBHC IN NVARCHAR2,P_CONGTHUC VARCHAR2, TUNGAY_HL IN DATE, DENNGAY_HL IN DATE,TUNGAY_KS IN DATE, DENNGAY_KS IN DATE, DONVI_TIEN number, cur OUT SYS_REFCURSOR) as
   QUERY_STR  VARCHAR2(32767); 
   P_CT VARCHAR2(32767);   
   P_SQL_INSERT VARCHAR2(32767);
   P_SELECT_DBHC VARCHAR2(32767);

   BEGIN
    IF TRIM(P_CONGTHUC) IS NOT NULL THEN 
        select STC_PA_SYS.FNC_CONVERT_FORMULA_HCSN(P_CONGTHUC) INTO P_CT from dual;
        P_SQL_INSERT:= ' '||P_SQL_INSERT ||' and '||P_CT;
    END IF;
    
 IF(P_MA_DBHC <> 27) THEN
        P_SELECT_DBHC:= ' AND A.MA_DIABAN IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||''') OR MA_DBHC_CHA IN (SELECT MA_DBHC FROM DM_DBHC WHERE MA_DBHC = '''||P_MA_DBHC||''' OR MA_DBHC_CHA = '''||P_MA_DBHC||'''))';
        ELSE P_SELECT_DBHC:= ' ';
        END IF;
        IF(P_SELECT_DBHC IS NOT NULL) THEN
        P_SQL_INSERT:=P_SQL_INSERT || P_SELECT_DBHC;
        ELSE
        P_SQL_INSERT:=P_SQL_INSERT;
        END IF;

            QUERY_STR:='select TH.MA_CHUONG, TH.TEN_CHUONG,NVL(DT.DUTOAN,0) as DUTOAN, TH.CHI_QP, TH.CHI_AN, TH.CHI_GDDT,TH.CHI_YT, TH.CHI_DS, TH.CHI_KHCN, TH.CHI_VH, TH.CHI_PTTH, TH.CHI_DBXH, TH.CHI_TDTT, TH.CHI_KT, TH.CHI_MT, TH.CHI_QLHC, TH.MTQG, TH.CHI_KHAC
                        from
                        (
                        (
                        select A.MA_CHUONG, A.TEN_CHUONG,
                        NVL(SUM (0),0) AS CHI_QP,
                        NVL(SUM (0),0) AS CHI_AN,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (494,495,497,498,504,505) and not A.MA_NGUON_NSNN = 29 ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_GDDT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (521,522,523,526,532)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_YT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (534)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_DS,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (373) ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_KHCN,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (553,554,555,556,579) ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_VH,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (253)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_PTTH,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (562)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_TDTT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (527,528,533)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_DBXH,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (011,014,015,016,172,189,223,231,279,431,432,438,441) ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_KT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (281,283,309)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_MT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (462,463,472,473)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_QLHC,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (369)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_KHAC,
                        NVL(SUM (0),0) MTQG

                        from PHA_HACHTOAN_CHI A
                        where 
                        A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''|| to_char(DENNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_KET_SO >= TO_DATE ('''|| to_char(TUNGAY_KS,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_KET_SO <= TO_DATE ('''|| to_char(DENNGAY_KS,'ddMMyyyy') ||''', ''ddMMyyyy'') and A.MA_CAP = ''2'' and A.MA_TKTN IN (''8113'',''8123'')
                        and not A.MA_CHUONG in (509,515,599)
                        and not A.MA_DVQHNS in (3012616,3025869,3018905)
                        '||P_SQL_INSERT ||'
                        group by A.MA_CHUONG, A.TEN_CHUONG
                        order by A.MA_CHUONG
                        ) TH
                        left join 
                        (
                         select A.MA_CHUONG, A.TEN_CHUONG, (SUM(A.ACCOUNTED_DR - A.ACCOUNTED_CR)/NVL('|| DONVI_TIEN ||',1)) as DUTOAN from PHA_DUTOAN A
                         where 
                        A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''|| to_char(DENNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'') and A.MA_CAP = ''2''
                        and A.MA_TKTN in (9523,9527)
                        AND A.ATTRIBUTE8 in (''01'',''02'',''03'',''06'')
                        AND A.MA_NGUON_NSNN in (12,13,14,15,16,21)
                        AND A.MA_LOAI <> ''000''
                        AND NOT (A.MA_DVQHNS = 1063920 and A.MA_CHUONG = 425)
                        AND NOT (A.MA_DVQHNS = 1042939 and A.MA_CHUONG = 513)
                        AND NOT (A.MA_DVQHNS = 1026074 and A.MA_CHUONG = 412 and A.MA_NGANHKT = 018)
                        AND NOT A.MA_DVQHNS in (1098728,1053629)            
                        AND NOT A.MA_CHUONG in (509,560)
                        group by A.MA_CHUONG, A.TEN_CHUONG
                        order by A.MA_CHUONG
                        ) DT
                        on TH.MA_CHUONG = DT.MA_CHUONG
                        )
                        union
                         select TH.MA_CHUONG, TH.TEN_DVQHNS,NVL(DT.DUTOAN,0) as DUTOAN, TH.CHI_QP, TH.CHI_AN, TH.CHI_GDDT,TH.CHI_YT, TH.CHI_DS, TH.CHI_KHCN, TH.CHI_VH, TH.CHI_PTTH, TH.CHI_DBXH, TH.CHI_TDTT, TH.CHI_KT, TH.CHI_MT, TH.CHI_QLHC, TH.MTQG, TH.CHI_KHAC
                        from
                        (
                        (
                        select A.MA_CHUONG,A.MA_DVQHNS, A.TEN_DVQHNS,
                        NVL(SUM (0),0) AS CHI_QP,
                        NVL(SUM (0),0) AS CHI_AN,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (494,495,497,498,504,505) and not A.MA_NGUON_NSNN = 29 or (A.MA_CHUONG = 422 and A.MA_NGANHKT in (496,501))) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_GDDT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (521,522,523,526,532)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_YT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (534)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_DS,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (373) ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_KHCN,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (553,554,555,556,579) ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_VH,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (253)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_PTTH,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (562)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_TDTT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (527,528,533)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_DBXH,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (011,014,015,016,172,189,223,231,279,431,432,438,441) ) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_KT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (281,283,309)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_MT,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (462,463,472,473)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_QLHC,
                        NVL(SUM (CASE WHEN ( A.MA_NGANHKT in (369)) THEN GIA_TRI_HACH_TOAN/NVL('|| DONVI_TIEN ||',1) ELSE 0 END),0) AS CHI_KHAC,
                        NVL(SUM (0),0) MTQG

                        from PHA_HACHTOAN_CHI A
                        where 
                         A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''|| to_char(DENNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_KET_SO >= TO_DATE ('''|| to_char(TUNGAY_KS,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_KET_SO <= TO_DATE ('''|| to_char(DENNGAY_KS,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        and A.MA_CAP = ''2'' and A.MA_TKTN IN (''8113'',''8123'')
                        and A.MA_CHUONG = 599   
                        and not A.MA_DVQHNS = 1053629
                        '||P_SQL_INSERT ||'
                        group by A.MA_CHUONG,A.MA_DVQHNS, A.TEN_DVQHNS
                        order by A.MA_DVQHNS
                        ) TH
                        left join 
                        (
                         select A.MA_CHUONG,A.MA_DVQHNS, A.TEN_DVQHNS, (SUM(A.ACCOUNTED_DR - A.ACCOUNTED_CR)/NVL('|| DONVI_TIEN ||',1)) as DUTOAN from PHA_DUTOAN A
                         where 
                        A.NGAY_HIEU_LUC >= TO_DATE ('''|| to_char(TUNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_HIEU_LUC <= TO_DATE ('''|| to_char(DENNGAY_HL,'ddMMyyyy') ||''', ''ddMMyyyy'') 
                        AND A.NGAY_KET_SO >= TO_DATE ('''|| to_char(TUNGAY_KS,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        AND A.NGAY_KET_SO <= TO_DATE ('''|| to_char(DENNGAY_KS,'ddMMyyyy') ||''', ''ddMMyyyy'')
                        and A.MA_CAP = ''2''
                        and A.MA_TKTN in (9523,9527) 
                        and A.MA_CHUONG = 599   
                        and not A.MA_DVQHNS = 1053629
                        and A.ATTRIBUTE8 in (''01'',''02'',''03'',''06'')
                        and A.MA_NGUON_NSNN in (12,13,14,15,16,21)
                        and not (A.MA_DVQHNS = 1121766 and A.MA_NGANHKT = 505)                     
                        group by A.MA_CHUONG,A.MA_DVQHNS, A.TEN_DVQHNS
                        order by A.MA_DVQHNS
                        ) DT
                        on TH.MA_DVQHNS = DT.MA_DVQHNS
                        )';



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
END PHA_HCSN_MAU_06;