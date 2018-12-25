create or replace PROCEDURE "PHB_B02BCTC_SUMREPORT" 
(
      MADBHC IN NVARCHAR2,     
      NAMBC IN NUMBER,
      KYBC IN NUMBER,
      LOAIBC IN NUMBER,
      DSDVQHNS IN NVARCHAR2,
      CUR OUT SYS_REFCURSOR
)IS
P_QUERY VARCHAR2(32767);
TEMP_DVQHNS  VARCHAR2(32767);
TEMP_DBHC  VARCHAR2(32767);
BEGIN
    IF DSDVQHNS IS NOT NULL THEN TEMP_DVQHNS:= ' AND TH.MA_QHNS IN('||DSDVQHNS||')';
    ELSE TEMP_DVQHNS:= '';
    END IF;
    IF (MADBHC IS NOT NULL)
        THEN TEMP_DBHC:= ' AND TH.MA_DBHC_CHA='''||MADBHC||'''';
    ELSE TEMP_DBHC:= '';
    END IF;

    IF (LOAIBC = 1) THEN
        P_QUERY:='
        SELECT * FROM (
            select Cast(''I'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động hành chính, sự nghiệp'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND CT.PHAN=1
                AND TH.MA_QHNS IN (SELECT MA_DVQHNS FROM SYS_DVQHNS WHERE MA_DVQHNS_CHA IN (SELECT MA_QHNS FROM PHB_DM_DVQHNS WHERE MA_DBHC = '|| MADBHC ||'))             
            GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
            ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )
        union all
        SELECT * FROM (
            select Cast(''II'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động sản xuất kinh doanh, dịch vụ'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )   
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND CT.PHAN=2
                AND TH.MA_QHNS IN (SELECT MA_DVQHNS FROM SYS_DVQHNS WHERE MA_DVQHNS_CHA IN (SELECT MA_QHNS FROM PHB_DM_DVQHNS WHERE MA_DBHC = '|| MADBHC ||'))             
            GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
            ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )    
        union all
        SELECT * FROM (
            select Cast(''III'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động tài chính'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )   
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND CT.PHAN=3
                AND TH.MA_QHNS IN (SELECT MA_DVQHNS FROM SYS_DVQHNS WHERE MA_DVQHNS_CHA IN (SELECT MA_QHNS FROM PHB_DM_DVQHNS WHERE MA_DBHC = '|| MADBHC ||'))             
            GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
            ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )  
        union all
        SELECT * FROM (
            select Cast(''IV'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động khác'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )   
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND CT.PHAN=4
                AND TH.MA_QHNS IN (SELECT MA_DVQHNS FROM SYS_DVQHNS WHERE MA_DVQHNS_CHA IN (SELECT MA_QHNS FROM PHB_DM_DVQHNS WHERE MA_DBHC = '|| MADBHC ||'))             
            GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
            ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )
            
            
            '; 
    ELSIF (LOAIBC = 2 OR LOAIBC = 3) THEN
        P_QUERY:='
        SELECT * FROM (
            select Cast(''I'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động hành chính, sự nghiệp'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN SYS_DVQHNS DVQHNS ON TH.MA_QHNS=DVQHNS.MA_DVQHNS INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND DVQHNS.TRANG_THAI=''A'' AND CT.PHAN=1'
                || TEMP_DVQHNS
                || TEMP_DBHC
                || ' GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                    ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )
        union all
        SELECT * FROM (
            select Cast(''II'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động sản xuất kinh doanh, dịch vụ'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )   
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN SYS_DVQHNS DVQHNS ON TH.MA_QHNS=DVQHNS.MA_DVQHNS INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND DVQHNS.TRANG_THAI=''A'' AND CT.PHAN=2'
                || TEMP_DVQHNS
                || TEMP_DBHC
                || ' GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                    ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )    
        union all
        SELECT * FROM (
            select Cast(''III'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động tài chính'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )   
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN SYS_DVQHNS DVQHNS ON TH.MA_QHNS=DVQHNS.MA_DVQHNS INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND DVQHNS.TRANG_THAI=''A'' AND CT.PHAN=3'
                || TEMP_DVQHNS
                || TEMP_DBHC
                || ' GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                    ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )  
        union all
        SELECT * FROM (
            select Cast(''IV'' as nvarchar2(15)) as STT_CHI_TIEU, Cast('''' as nvarchar2(50)) as MA_CHI_TIEU,Cast(''Hoạt động khác'' as nvarchar2(255)) as TEN_CHI_TIEU
                        ,Cast(NULL as NUMBER(10,0)) as PHAN, Cast(NULL as NUMBER(10,0)) as THUYET_MINH, Cast(NULL as NUMBER(10,0)) as NAM_NAY, Cast(NULL as NUMBER(10,0)) as NAM_TRUOC                        
                from dual 
            )   
        union all
        SELECT * FROM (        
            SELECT CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                ,SUM(CT.THUYET_MINH) AS THUYET_MINH,SUM(CT.NAM_NAY) AS NAM_NAY,SUM(CT.NAM_TRUOC) AS NAM_TRUOC        
            FROM PHB_B02BCTC TH INNER JOIN SYS_DVQHNS DVQHNS ON TH.MA_QHNS=DVQHNS.MA_DVQHNS INNER JOIN PHB_B02BCTC_DETAIL CT ON CT.PHB_B02BCTC_REFID = TH.REFID
            WHERE (TH.NAM_BC=CASE '||NAMBC||' WHEN -1 THEN TH.NAM_BC ELSE '||NAMBC||' END) AND (TH.KY_BC=CASE '||KYBC||' WHEN -1 THEN TH.KY_BC ELSE '||KYBC||' END) AND DVQHNS.TRANG_THAI=''A'' AND CT.PHAN=4'
                || TEMP_DVQHNS
                || TEMP_DBHC
                || ' GROUP BY CT.STT_CHI_TIEU, CT.MA_CHI_TIEU, CT.TEN_CHI_TIEU, CT.PHAN
                    ORDER BY CT.PHAN, CT.MA_CHI_TIEU
            )
        
            
            ';  
    END IF;
    
    DBMS_OUTPUT.put_line(P_QUERY); 

    OPEN cur FOR P_QUERY;
END "PHB_B02BCTC_SUMREPORT";