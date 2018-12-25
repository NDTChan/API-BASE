create or replace FUNCTION FCN_GENERAL_SODU_CUOITHANG
RETURN SYS_REFCURSOR 
IS 
        QUERY_STR       VARCHAR2 (30000);
        P_CT VARCHAR2(32767);
        CURSOR_RESULT             SYS_REFCURSOR;
BEGIN 
    DECLARE
        TAIKHOAN_NSD VARCHAR(10);
        TAIKHOAN_CHUNGTU VARCHAR(10);
        TAIKHOAN_NOTIN VARCHAR(10000);
        QUERRY_EXTEND VARCHAR(2000);
        v_CLO_TMP  VARCHAR2(5000);
        v_COLUMN  VARCHAR2(5000);
        v_CLO_CO  VARCHAR2(5000);
        v_CLO_DYNAMIC VARCHAR2(10000);
        V_COUNT NUMBER;
        V_COUNT_SESSION NUMBER;
        v_INST_ID  NUMBER;
        v_SID  NUMBER;
        v_SERIAL  NUMBER;
    BEGIN
        TAIKHOAN_NSD := '';
        v_COLUMN := '';
        v_CLO_TMP := '';
        SELECT COUNT(*) INTO V_COUNT FROM USER_TABLES WHERE TABLE_NAME = UPPER('PHC_TEMP_SODU');
        IF V_COUNT > 0 THEN
            SELECT COUNT(*) INTO V_COUNT_SESSION FROM gv$session WHERE SID = (SELECT SID FROM v$lock WHERE TYPE = 'TO' AND ID1 = (SELECT OBJECT_ID FROM DBA_OBJECTS WHERE OBJECT_NAME = 'PHC_TEMP_SODU'));
            IF V_COUNT_SESSION > 0 THEN
                SELECT INST_ID,SID,SERIAL# INTO v_INST_ID, v_SID, v_SERIAL FROM gv$session WHERE SID = (SELECT SID FROM v$lock WHERE TYPE = 'TO' AND ID1 = (SELECT OBJECT_ID FROM DBA_OBJECTS WHERE OBJECT_NAME = 'PHC_TEMP_SODU'));
                IF v_INST_ID IS NOT NULL AND v_SID IS NOT NULL THEN
                        EXECUTE IMMEDIATE 'ALTER SYSTEM KILL SESSION '''||v_SID||','||v_SERIAL||','||'@'||v_INST_ID||'''';
                        EXECUTE IMMEDIATE 'DROP TABLE PHC_TEMP_SOCAI';
                        DBMS_OUTPUT.put_line ('KILLER SESSION' );
                END IF;
            ELSE
                EXECUTE IMMEDIATE 'DROP TABLE PHC_TEMP_SODU';
            END IF;
       END IF;
          FOR TK_NSD IN (SELECT DISTINCT(a.TAI_KHOAN) FROM V_PHC_TH_NHAPSODU a)
          LOOP    
            IF TK_NSD.TAI_KHOAN IS NULL OR TK_NSD.TAI_KHOAN <> '' THEN 
                  v_COLUMN := v_COLUMN || TK_NSD.TAI_KHOAN;
                  v_CLO_TMP := v_CLO_TMP || '''' || TK_NSD.TAI_KHOAN || '''' || ',';
            END IF;
          END LOOP;
         v_CLO_TMP := SUBSTR(v_CLO_TMP,0,LENGTH(v_CLO_TMP)-1); 
        DECLARE
            QUERY_TEST  VARCHAR2(32767); 
            v_Temp  VARCHAR2(5000);
            CUR_COL SYS_REFCURSOR;
            v_Temp_TaiKhoan VARCHAR2(50);
        BEGIN
            IF v_CLO_TMP IS NOT NULL OR v_CLO_TMP <> '' THEN
                QUERY_TEST:= 'SELECT DISTINCT(a.TAIKHOAN) FROM V_PHC_TH_CHUNGTU a WHERE a.TAIKHOAN NOT IN ('||v_CLO_TMP||')';
            ELSE
                QUERY_TEST:= 'SELECT DISTINCT(a.TAIKHOAN) FROM V_PHC_TH_CHUNGTU a ';
            END IF;
            OPEN CUR_COL FOR QUERY_TEST;
               LOOP
                  FETCH CUR_COL INTO v_Temp;
                  EXIT WHEN CUR_COL%NOTFOUND;
                  v_CLO_CO := v_CLO_CO || v_Temp || ',';
               END LOOP;
            CLOSE CUR_COL;
            v_CLO_CO := SUBSTR(v_CLO_CO,0,LENGTH(v_CLO_CO)-1);
            v_CLO_DYNAMIC := v_CLO_TMP || v_CLO_CO;
            --DBMS_OUTPUT.PUT_LINE('v_CLO_DYNAMIC : ' || v_CLO_DYNAMIC);
            EXECUTE IMMEDIATE 'CREATE GLOBAL TEMPORARY TABLE PHC_TEMP_SODU (
                                  TAI_KHOAN      NVARCHAR2(50),
                                  THANG          NUMBER(18,2),
                                  SODU_DAUKY_NO  NUMBER(18,2),
                                  SODU_DAUKY_CO  NUMBER(18,2),
                                  SO_PHATSINH_NO NUMBER(18,2),
                                  SO_PHATSINH_CO NUMBER(18,2),
                                  SODU_CUOIKY_NO 	 NUMBER(18,2),
                                  SODU_CUOIKY_CO 	 NUMBER(18,2),
                                  LUYKE_NO          NUMBER(18,2),
                                  LUYKE_CO          NUMBER(18,2)
                                ) ON COMMIT DELETE ROWS';
            -- END TAO BANG TEMP
            -- INSERT DU LIEU CAC TAI KHOAN THEO TUNG THANG
            FOR THANG IN (WITH t AS (SELECT DATE '2009-08-01' start_date,DATE '2010-07-16' end_date FROM DUAL) SELECT TO_CHAR(ADD_MONTHS(TRUNC(start_date,'mm'),level - 1),'MM') MONTH FROM  t CONNECT BY TRUNC(end_date,'MM') >= add_months(TRUNC(start_date,'MM'),LEVEL - 1) ORDER BY MONTH)
            LOOP
                --DBMS_OUTPUT.PUT_LINE('THANG : ' || THANG.MONTH);
                FOR RECORD_INSERT IN (WITH TEMP AS ( SELECT THANG.MONTH THANG,''||v_CLO_DYNAMIC||'' TAIKHOAN  FROM DUAL ) SELECT DISTINCT trim(REGEXP_SUBSTR(t.TAIKHOAN, '[^,]+', 1, LEVELS.COLUMN_VALUE)) AS TAI_KHOAN,t.THANG AS THANG FROM TEMP t,TABLE(CAST(MULTISET(SELECT LEVEL FROM DUAL CONNECT BY LEVEL <= LENGTH(REGEXP_REPLACE(t.TAIKHOAN, '[^,]+'))  + 1) AS SYS.OdciNumberList)) LEVELS)
                LOOP
                    --DBMS_OUTPUT.PUT_LINE('TAIKHOAN : ' || RECORD_INSERT.TAI_KHOAN || '   ' || 'THANG :' || RECORD_INSERT.THANG);
                    EXECUTE IMMEDIATE 'INSERT INTO PHC_TEMP_SODU(TAI_KHOAN,THANG,SODU_DAUKY_NO,SODU_DAUKY_CO,SO_PHATSINH_NO,SO_PHATSINH_CO,SODU_CUOIKY_NO,SODU_CUOIKY_CO,LUYKE_NO,LUYKE_CO) VALUES('''||RECORD_INSERT.TAI_KHOAN||''','||RECORD_INSERT.THANG||',0,0,0,0,0,0,0,0)'; 
                END LOOP;
            END LOOP;
            
            DECLARE
               t_THANG NUMBER;
               t_THANG_PS NUMBER;
               QUERY_UPDATE_DATA VARCHAR2(32767);
               QUERY_UPDATE_PHATSINH VARCHAR2(32767);
               CHECK_SIDE VARCHAR2(10);
               QUERY_UPDATE_NO VARCHAR2(2000);
               QUERY_UPDATE_CO VARCHAR2(2000);
               QUERY_UPDATE_LUONGTINH VARCHAR2(2000);
               QUERY_UPDATE_LUYKE_THANG1 VARCHAR2(2000);
               QUERY_UPDATE_LUYKE VARCHAR2(2000);
               t_LUYKE_NO NUMBER;
               t_LUYKE_CO NUMBER;
               QUERY_SELECT_LKNO VARCHAR2(2000);
               QUERY_SELECT_LKCO VARCHAR2(2000);
               QUERY_SELECT_DUCUOIKY_NO VARCHAR2(2000);
               QUERY_SELECT_DUCUOIKY_CO VARCHAR2(2000);
               QUERY_UPDATE_EXTEND VARCHAR2(2000);
            BEGIN
            --UPDATE DƯ ĐẦU KỲ
                FOR row_NSD IN (SELECT a.MA_CHUNGTU,a.NGAY_CT,a.NGAY_HT,a.TAI_KHOAN,SUM(NVL(a.TONG_DUNO,0)) AS TONG_DUNO,SUM(NVL(a.TONG_DUCO,0)) AS TONG_DUCO FROM V_PHC_TH_NHAPSODU a GROUP BY a.MA_CHUNGTU,a.NGAY_CT,a.NGAY_HT,a.TAI_KHOAN)
                LOOP    
                 -- Lấy tháng
                SELECT TO_CHAR(TO_DATE(''||row_NSD.NGAY_HT||'', 'DD-MM-YYYY'), 'MM') INTO t_THANG FROM DUAL;
                QUERY_UPDATE_DATA := 'UPDATE PHC_TEMP_SODU a SET a.SODU_DAUKY_NO = '||NVL(row_NSD.TONG_DUNO,0)||',a.SODU_DAUKY_CO = '||NVL(row_NSD.TONG_DUCO,0)||' WHERE  a.TAI_KHOAN = '''||row_NSD.TAI_KHOAN||''' AND a.THANG = '||t_THANG||'';
                --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_DATA : ' || QUERY_UPDATE_DATA);
                EXECUTE IMMEDIATE QUERY_UPDATE_DATA;
                END LOOP;
            --UPDATE PHÁT SINH
                FOR row_PHATSINH IN (SELECT a.TAIKHOAN AS TAI_KHOAN,a.LOAI,a.NGAY_CT,a.NGAY_HT,SUM(NVL(a.SOTIEN,0)) AS SOTIEN FROM V_PHC_TH_CHUNGTU a GROUP BY a.TAIKHOAN,a.LOAI,a.NGAY_CT,a.NGAY_HT)
                  LOOP
                    -- Lấy tháng
                    SELECT TO_CHAR(TO_DATE(''||row_PHATSINH.NGAY_HT||'', 'DD-MM-YYYY'), 'MM') INTO t_THANG_PS FROM DUAL;
                    IF(row_PHATSINH.LOAI = 'N') THEN 
                        QUERY_UPDATE_PHATSINH := 'UPDATE PHC_TEMP_SODU a SET a.SO_PHATSINH_NO = '||NVL(row_PHATSINH.SOTIEN,0)||' WHERE  a.TAI_KHOAN = '''||row_PHATSINH.TAI_KHOAN||''' AND a.THANG = '||t_THANG_PS||'';
                    ELSE
                        QUERY_UPDATE_PHATSINH := 'UPDATE PHC_TEMP_SODU a SET a.SO_PHATSINH_CO = '||NVL(row_PHATSINH.SOTIEN,0)||' WHERE  a.TAI_KHOAN = '''||row_PHATSINH.TAI_KHOAN||''' AND a.THANG = '||t_THANG_PS||'';
                    END IF;
                    EXECUTE IMMEDIATE QUERY_UPDATE_PHATSINH;
                  END LOOP;
                  
                  
                  --UPDATE DU CUOI KY
                FOR row_DUCUOIKY IN (SELECT * FROM PHC_TEMP_SODU)
                      LOOP
                       -- KIỂM TRA TÀI KHOẢN BÊN NỢ HAY BÊN CÓ
                            SELECT TINHCHAT_TK INTO CHECK_SIDE FROM DM_TAIKHOAN WHERE MA = ''||row_DUCUOIKY.TAI_KHOAN||'';
                                IF CHECK_SIDE = 'N' THEN
                                    QUERY_UPDATE_NO := 'UPDATE PHC_TEMP_SODU SET SODU_CUOIKY_NO = ABS((SODU_DAUKY_NO + SO_PHATSINH_NO) - SO_PHATSINH_CO) WHERE TAI_KHOAN = '''||row_DUCUOIKY.TAI_KHOAN||''' AND THANG = '||row_DUCUOIKY.THANG||' '; 
                                    --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_NO : ' || QUERY_UPDATE_NO);
                                    EXECUTE IMMEDIATE QUERY_UPDATE_NO;
                                ELSIF CHECK_SIDE = 'C' THEN 
                                    QUERY_UPDATE_CO := 'UPDATE PHC_TEMP_SODU SET SODU_CUOIKY_CO = ABS((SODU_DAUKY_CO + SO_PHATSINH_CO) - SO_PHATSINH_NO) WHERE TAI_KHOAN = '''||row_DUCUOIKY.TAI_KHOAN||''' AND THANG = '||row_DUCUOIKY.THANG||' ';
                                    --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_CO : ' || QUERY_UPDATE_CO);
                                    EXECUTE IMMEDIATE QUERY_UPDATE_CO;
                                ELSIF CHECK_SIDE = 'L' THEN
                                    IF ((row_DUCUOIKY.SODU_DAUKY_NO + row_DUCUOIKY.SO_PHATSINH_NO) > (row_DUCUOIKY.SODU_DAUKY_CO + row_DUCUOIKY.SO_PHATSINH_CO)) THEN
                                        QUERY_UPDATE_LUONGTINH := 'UPDATE PHC_TEMP_SODU SET SODU_CUOIKY_NO = ABS((SODU_DAUKY_NO + SO_PHATSINH_NO) - SO_PHATSINH_CO) WHERE TAI_KHOAN = '''||row_DUCUOIKY.TAI_KHOAN||''' AND THANG = '||row_DUCUOIKY.THANG||' ' ;
                                        --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_LUONGTINH IF : ' || QUERY_UPDATE_LUONGTINH);
                                        EXECUTE IMMEDIATE QUERY_UPDATE_LUONGTINH;
                                    ELSE
                                        QUERY_UPDATE_LUONGTINH := 'UPDATE PHC_TEMP_SODU SET SODU_CUOIKY_CO = ABS((SODU_DAUKY_CO + SO_PHATSINH_CO) - SO_PHATSINH_NO) WHERE TAI_KHOAN = '''||row_DUCUOIKY.TAI_KHOAN||''' AND THANG = '||row_DUCUOIKY.THANG||' ';
                                        --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_LUONGTINH ELSE : ' || QUERY_UPDATE_LUONGTINH);
                                        EXECUTE IMMEDIATE QUERY_UPDATE_LUONGTINH;
                                    END IF;
                            END IF;
                      END LOOP;
                      --VONG 1 CHAY HET THANG 1
                      FOR row_LUYKE IN (SELECT DISTINCT(TAI_KHOAN) FROM PHC_TEMP_SODU)
                      LOOP
                        FOR THANGLK IN (WITH t AS (SELECT DATE '2009-08-01' start_date,DATE '2010-07-16' end_date FROM DUAL) SELECT TO_CHAR(ADD_MONTHS(TRUNC(start_date,'mm'),level - 1),'MM') MONTH FROM  t CONNECT BY TRUNC(end_date,'MM') >= add_months(TRUNC(start_date,'MM'),LEVEL - 1) ORDER BY MONTH)
                        LOOP
                            IF THANGLK.MONTH = 1 THEN  
                                QUERY_UPDATE_LUYKE_THANG1 := 'UPDATE PHC_TEMP_SODU SET LUYKE_NO = ABS(SO_PHATSINH_NO),LUYKE_CO = ABS(SO_PHATSINH_CO) WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||THANGLK.MONTH||' ';
                                EXECUTE IMMEDIATE QUERY_UPDATE_LUYKE_THANG1;
                            ELSIF THANGLK.MONTH > 1 THEN  
                                SELECT TINHCHAT_TK INTO CHECK_SIDE FROM DM_TAIKHOAN WHERE MA = ''||row_LUYKE.TAI_KHOAN||'';
                                QUERY_SELECT_LKNO := 'SELECT ABS(LUYKE_NO) AS LUYKE_NO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                QUERY_SELECT_LKCO := 'SELECT ABS(LUYKE_CO) AS LUYKE_CO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                QUERY_SELECT_DUCUOIKY_NO := 'SELECT SODU_CUOIKY_NO AS SODU_CUOIKY_NO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                QUERY_SELECT_DUCUOIKY_CO := 'SELECT SODU_CUOIKY_CO AS SODU_CUOIKY_CO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                IF CHECK_SIDE = 'N'
                                    THEN  
                                    DBMS_OUTPUT.PUT_LINE('row_LUYKE.TEST N : ' || row_LUYKE.TAI_KHOAN); 
                                    QUERY_UPDATE_EXTEND := 'SODU_CUOIKY_NO = SODU_DAUKY_NO + ( '||QUERY_SELECT_DUCUOIKY_NO||' ) + SO_PHATSINH_NO - SO_PHATSINH_CO';
                                ELSIF CHECK_SIDE = 'C' 
                                    THEN                                     
                                QUERY_UPDATE_EXTEND := 'SODU_CUOIKY_CO = SODU_DAUKY_CO + ( '||QUERY_SELECT_DUCUOIKY_CO||' ) + SO_PHATSINH_CO - SO_PHATSINH_NO';
                                 ELSIF CHECK_SIDE = 'L' 
                                    THEN                                     
                                QUERY_UPDATE_EXTEND := 'SODU_CUOIKY_CO = SODU_DAUKY_CO + ( '||QUERY_SELECT_DUCUOIKY_CO||' )';
                                END IF;
                                QUERY_UPDATE_LUYKE := 'UPDATE PHC_TEMP_SODU SET 
                                    SODU_DAUKY_NO = SODU_DAUKY_NO + ( '||QUERY_SELECT_DUCUOIKY_NO||' ),
                                    SODU_DAUKY_CO = SODU_DAUKY_CO + ( '||QUERY_SELECT_DUCUOIKY_CO||' ),
                                    '||QUERY_UPDATE_EXTEND||',
                                    LUYKE_NO = ABS(SO_PHATSINH_NO) + ( '||QUERY_SELECT_LKNO||' ),
                                    LUYKE_CO = ABS(SO_PHATSINH_CO) + ( '||QUERY_SELECT_LKCO||' ) 
                                    WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH)||'';
                                EXECUTE IMMEDIATE QUERY_UPDATE_LUYKE;
                                --DBMS_OUTPUT.ENABLE (buffer_size => NULL);
                                --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_LUYKE : ' || QUERY_UPDATE_LUYKE);
                            END IF;
                        END LOOP;
                      END LOOP;
            END;
                
            OPEN CURSOR_RESULT FOR 'SELECT * FROM PHC_TEMP_SODU ORDER BY THANG,TAI_KHOAN';
        END; 
    END;
      RETURN CURSOR_RESULT;
END FCN_GENERAL_SODU_CUOITHANG;
/