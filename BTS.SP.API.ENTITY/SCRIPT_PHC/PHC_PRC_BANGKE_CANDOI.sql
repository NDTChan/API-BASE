create or replace PROCEDURE PHC_PRC_BANGKE_CANDOI(P_TUNGAY_HL IN DATE, P_DENNGAY_HL IN DATE, P_USER_NAME IN VARCHAR,CURSOR_RESULT OUT SYS_REFCURSOR)
IS 
        v_CLO_TMP  VARCHAR2(5000);
        v_COLUMN  VARCHAR2(5000);
        v_CLO_CO  VARCHAR2(5000);
        v_CLO_DYNAMIC VARCHAR2(10000);
        P_TU_THANG VARCHAR2(2) := TO_NUMBER(TO_CHAR(TO_DATE(P_TUNGAY_HL,'DD/MM/YY'),'MM'));
        P_DEN_THANG VARCHAR2(2) := TO_NUMBER(TO_CHAR(TO_DATE(P_DENNGAY_HL,'DD/MM/YY'),'MM'));
        P_GETDATA_TUTHANG VARCHAR2(2) := TO_NUMBER(TO_CHAR(TO_DATE('01-01-2017','DD/MM/YY'),'MM'));
        P_GETDATA_DENTHANG VARCHAR2(2) := TO_NUMBER(TO_CHAR(TO_DATE('31-12-2017','DD/MM/YY'),'MM'));
BEGIN 
        --  CREATE TABLE "BTSTC"."PHC_TEMP_SODU" 
        --   (	"TAI_KHOAN" NVARCHAR2(50), 
        --	"TEN_TAIKHOAN" NVARCHAR2(500), 
        --    "LOAI_TAIKHOAN" NUMBER(18,2),
        --	"THANG" NUMBER(18,2), 
        --	"SODU_DAUKY_NO" NUMBER(18,2), 
        --	"SODU_DAUKY_CO" NUMBER(18,2), 
        --	"SO_PHATSINH_NO" NUMBER(18,2), 
        --	"SO_PHATSINH_CO" NUMBER(18,2), 
        --	"SODU_CUOIKY_NO" NUMBER(18,2), 
        --	"SODU_CUOIKY_CO" NUMBER(18,2), 
        --	"LUYKE_NO" NUMBER(18,2), 
        --	"LUYKE_CO" NUMBER(18,2), 
        --	"USER_NAME" NVARCHAR2(50)
        --   ) SEGMENT CREATION IMMEDIATE 
        --  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
        --  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
        --  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
        --  TABLESPACE "BTSTC" ;
     EXECUTE IMMEDIATE 'DELETE PHC_TEMP_SODU WHERE USER_NAME = '''||P_USER_NAME||'''';
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
           T_TEN_TAIKHOAN VARCHAR2(500); 
           t_THANG  NUMBER;
           t_THANG_PS NUMBER;
           T_LOAI_TAIKHOAN  NUMBER;
           QUERY_UPDATE_DATA VARCHAR2(32767);
           QUERY_UPDATE_PHATSINH VARCHAR2(32767);
           CHECK_SIDE VARCHAR2(10);
           QUERY_UPDATE_NO VARCHAR2(2000);
           QUERY_UPDATE_CO VARCHAR2(2000);
           QUERY_UPDATE_LUONGTINH VARCHAR2(2000);
           QUERY_UPDATE_LUYKE VARCHAR2(2000);
           QUERY_SELECT_LKNO VARCHAR2(2000);
           QUERY_SELECT_LKCO VARCHAR2(2000);
           QUERY_SELECT_DUCUOIKY_NO VARCHAR2(2000);
           QUERY_SELECT_DUCUOIKY_CO VARCHAR2(2000);
           QUERY_UPDATE_EXTEND VARCHAR2(2000);
        BEGIN
            IF v_CLO_TMP IS NOT NULL OR v_CLO_TMP <> '' THEN
                --QUERY_TEST:= 'SELECT DISTINCT(a.TAIKHOAN) FROM V_PHC_TH_CHUNGTU a WHERE a.TAIKHOAN NOT IN ('||v_CLO_TMP||')';
                QUERY_TEST:= 'SELECT DISTINCT(a.TAIKHOAN) FROM V_PHC_TH_CHUNGTU a ';
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
            FOR THANG IN (SELECT (P_GETDATA_TUTHANG + LEVEL - 1) AS month FROM dual CONNECT BY LEVEL <= P_GETDATA_DENTHANG - P_GETDATA_TUTHANG +1)
            LOOP
                FOR RECORD_INSERT IN (WITH TEMP AS ( SELECT THANG.MONTH THANG,''||v_CLO_DYNAMIC||'' TAIKHOAN  FROM DUAL ) SELECT DISTINCT trim(REGEXP_SUBSTR(t.TAIKHOAN, '[^,]+', 1, LEVELS.COLUMN_VALUE)) AS TAI_KHOAN,t.THANG AS THANG FROM TEMP t,TABLE(CAST(MULTISET(SELECT LEVEL FROM DUAL CONNECT BY LEVEL <= LENGTH(REGEXP_REPLACE(t.TAIKHOAN, '[^,]+'))  + 1) AS SYS.OdciNumberList)) LEVELS)
                LOOP
                    SELECT a.TEN,a.TRONGBANG INTO T_TEN_TAIKHOAN,T_LOAI_TAIKHOAN FROM DM_TAIKHOAN a WHERE a.MA = ''||RECORD_INSERT.TAI_KHOAN||'';
                    EXECUTE IMMEDIATE 'INSERT INTO PHC_TEMP_SODU(TAI_KHOAN,TEN_TAIKHOAN,LOAI_TAIKHOAN,THANG,SODU_DAUKY_NO,SODU_DAUKY_CO,SO_PHATSINH_NO,SO_PHATSINH_CO,SODU_CUOIKY_NO,SODU_CUOIKY_CO,LUYKE_NO,LUYKE_CO,USER_NAME) VALUES('''||RECORD_INSERT.TAI_KHOAN||''','''||T_TEN_TAIKHOAN||''','||T_LOAI_TAIKHOAN||','||RECORD_INSERT.THANG||',0,0,0,0,0,0,0,0,'''||P_USER_NAME||''')'; 
                END LOOP;
            END LOOP;
            -- Tính toán
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
                                   -- DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_NO : ' || QUERY_UPDATE_NO);
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
                        FOR THANGLK IN (SELECT (P_GETDATA_TUTHANG + LEVEL - 1) AS month FROM dual CONNECT BY LEVEL <= P_GETDATA_DENTHANG - P_GETDATA_TUTHANG +1)
                        LOOP
                            IF THANGLK.MONTH = 1 THEN  
                                QUERY_UPDATE_LUYKE := 'UPDATE PHC_TEMP_SODU SET LUYKE_NO = ABS(SO_PHATSINH_NO),LUYKE_CO = ABS(SO_PHATSINH_CO) WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||THANGLK.MONTH||' ';
                                EXECUTE IMMEDIATE QUERY_UPDATE_LUYKE;
                            ELSIF THANGLK.MONTH > 1 THEN  
                                SELECT TINHCHAT_TK INTO CHECK_SIDE FROM DM_TAIKHOAN WHERE MA = ''||row_LUYKE.TAI_KHOAN||'';
                                QUERY_SELECT_LKNO := 'SELECT ABS(LUYKE_NO) AS LUYKE_NO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                QUERY_SELECT_LKCO := 'SELECT ABS(LUYKE_CO) AS LUYKE_CO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                QUERY_SELECT_DUCUOIKY_NO := 'SELECT SODU_CUOIKY_NO AS SODU_CUOIKY_NO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                QUERY_SELECT_DUCUOIKY_CO := 'SELECT SODU_CUOIKY_CO AS SODU_CUOIKY_CO FROM PHC_TEMP_SODU WHERE TAI_KHOAN = '''||row_LUYKE.TAI_KHOAN||''' AND THANG = '||TO_CHAR(THANGLK.MONTH - 1)||'';
                                IF CHECK_SIDE = 'N'
                                    THEN  
                                    --DBMS_OUTPUT.PUT_LINE('row_LUYKE.TEST N : ' || row_LUYKE.TAI_KHOAN); 
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
                                    --DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_LUYKE : ' || QUERY_UPDATE_LUYKE);
                                EXECUTE IMMEDIATE QUERY_UPDATE_LUYKE;
                                --DBMS_OUTPUT.ENABLE (buffer_size => NULL);
                                --
                            END IF;
                        END LOOP;
                      END LOOP;
                      BEGIN
                        --OPEN CURSOR_RESULT FOR 'SELECT * FROM PHC_TEMP_SODU ORDER BY THANG,TAI_KHOAN';
                        --Kiểm tra ngày bắt đầu lấy dữ liệu để lấy ra tồn đầu kỳ và ngày đến để lấy số dư cuối kỳ
                           --SUM_SODU_DAUKY  NUMBER;
                           --SUM_PHATSINH  NUMBER;
                           --SUM_SODU_CUOIKY  NUMBER;
                           --SUM_LUYKE  NUMBER;
                        DECLARE
                               QUERY_KHOITAO VARCHAR2(2000);
                               SUM_SODU_DAUKY_NO  NUMBER;
                               SUM_SODU_DAUKY_CO  NUMBER;
                               SUM_PHATSINH_NO  NUMBER;
                               SUM_PHATSINH_CO  NUMBER;
                               SUM_SODU_CUOIKY_NO  NUMBER;
                               SUM_SODU_CUOIKY_CO  NUMBER;
                               SUM_LUYKE_NO  NUMBER;
                               SUM_LUYKE_CO  NUMBER;
                               TEMP_SODU_DAUKY_NO  NUMBER;
                               TEMP_SODU_DAUKY_CO  NUMBER;
                               TEMP_PHATSINH_NO  NUMBER;
                               TEMP_PHATSINH_CO  NUMBER;
                               TEMP_SODU_CUOIKY_NO  NUMBER;
                               TEMP_SODU_CUOIKY_CO  NUMBER;
                               TEMP_LUYKE_NO  NUMBER;
                               TEMP_LUYKE_CO  NUMBER;
                               QUERY_UPDATE_DUDAU VARCHAR2(2000);
                               QUERY_UPDATE_PHATSINH VARCHAR2(2000);
                               QUERY_UPDATE_CUOIKY VARCHAR2(2000);
                               QUERY_UPDATE_LUYKE VARCHAR2(2000);
                        BEGIN
                            
                            FOR KHOITAO IN (SELECT DISTINCT(TAI_KHOAN),TEN_TAIKHOAN, LOAI_TAIKHOAN FROM PHC_TEMP_SODU WHERE USER_NAME = ''||P_USER_NAME||'')
                            LOOP
                                SUM_SODU_DAUKY_NO := 0;
                                SUM_SODU_DAUKY_CO := 0;
                                SUM_PHATSINH_NO := 0;
                                SUM_PHATSINH_CO := 0;
                                QUERY_KHOITAO := 'INSERT INTO PHC_TEMP_SODU(TAI_KHOAN,TEN_TAIKHOAN,LOAI_TAIKHOAN,THANG,SODU_DAUKY_NO,SODU_DAUKY_CO,SO_PHATSINH_NO,SO_PHATSINH_CO,SODU_CUOIKY_NO,SODU_CUOIKY_CO,LUYKE_NO,LUYKE_CO,USER_NAME) VALUES('''||KHOITAO.TAI_KHOAN||''','''||KHOITAO.TEN_TAIKHOAN||''','||KHOITAO.LOAI_TAIKHOAN||',13,0,0,0,0,0,0,0,0,'''||P_USER_NAME||''')'; 
                                EXECUTE IMMEDIATE QUERY_KHOITAO;
                                FOR THANG_BATDAU IN (SELECT (P_GETDATA_TUTHANG + LEVEL - 1) AS month FROM DUAL CONNECT BY LEVEL <= P_TU_THANG - P_GETDATA_TUTHANG +1)
                                LOOP
                                   
                                    SELECT NVL(SODU_DAUKY_NO,0),NVL(SODU_DAUKY_CO,0) INTO TEMP_SODU_DAUKY_NO,TEMP_SODU_DAUKY_CO FROM PHC_TEMP_SODU WHERE THANG = THANG_BATDAU.MONTH AND TAI_KHOAN = KHOITAO.TAI_KHOAN AND USER_NAME  =  ''||P_USER_NAME||'';
                                    SUM_SODU_DAUKY_NO := SUM_SODU_DAUKY_NO + TEMP_SODU_DAUKY_NO;
                                    SUM_SODU_DAUKY_CO := SUM_SODU_DAUKY_CO + TEMP_SODU_DAUKY_CO;
                                END LOOP;
                                
                                FOR THANG_PHATSINH IN (SELECT (P_TU_THANG + LEVEL - 1) AS month FROM DUAL CONNECT BY LEVEL <= P_DEN_THANG - P_TU_THANG +1)
                                LOOP
                                    
                                    SELECT NVL(SO_PHATSINH_NO,0),NVL(SO_PHATSINH_CO,0) INTO TEMP_PHATSINH_NO,TEMP_PHATSINH_CO FROM PHC_TEMP_SODU WHERE THANG = THANG_PHATSINH.MONTH AND TAI_KHOAN = KHOITAO.TAI_KHOAN AND USER_NAME  =  ''||P_USER_NAME||'';
                                    SUM_PHATSINH_NO := SUM_PHATSINH_NO + TEMP_PHATSINH_NO;
                                    SUM_PHATSINH_CO := SUM_PHATSINH_CO + TEMP_PHATSINH_CO;
                                END LOOP;                    
                               
                                QUERY_UPDATE_DUDAU := 'UPDATE PHC_TEMP_SODU SET SODU_DAUKY_NO = '||SUM_SODU_DAUKY_NO||',SODU_DAUKY_CO = '||SUM_SODU_DAUKY_CO||' WHERE TAI_KHOAN = '''||KHOITAO.TAI_KHOAN||''' AND THANG = 13 AND USER_NAME = '''||P_USER_NAME||''' ';
                                EXECUTE IMMEDIATE QUERY_UPDATE_DUDAU;
                                
                                QUERY_UPDATE_PHATSINH := 'UPDATE PHC_TEMP_SODU SET SO_PHATSINH_NO = '||SUM_PHATSINH_NO||',SO_PHATSINH_CO = '||SUM_PHATSINH_CO||' WHERE TAI_KHOAN = '''||KHOITAO.TAI_KHOAN||''' AND THANG = 13 AND USER_NAME = '''||P_USER_NAME||''' ';
                                EXECUTE IMMEDIATE QUERY_UPDATE_PHATSINH;
                                
                                SELECT NVL(SODU_CUOIKY_NO,0),NVL(SODU_CUOIKY_CO,0) INTO TEMP_SODU_CUOIKY_NO,TEMP_SODU_CUOIKY_CO FROM PHC_TEMP_SODU WHERE THANG = ''||P_DEN_THANG||'' AND TAI_KHOAN = KHOITAO.TAI_KHOAN AND USER_NAME  =  ''||P_USER_NAME||'';
                                QUERY_UPDATE_CUOIKY := 'UPDATE PHC_TEMP_SODU SET SODU_CUOIKY_NO = '''||TEMP_SODU_CUOIKY_NO||''',SODU_CUOIKY_CO = '''||TEMP_SODU_CUOIKY_CO||''' WHERE TAI_KHOAN = '''||KHOITAO.TAI_KHOAN||''' AND THANG = 13 AND USER_NAME = '''||P_USER_NAME||''' ';
                                EXECUTE IMMEDIATE QUERY_UPDATE_CUOIKY;
                                
                                SELECT NVL(LUYKE_NO,0),NVL(LUYKE_CO,0) INTO TEMP_LUYKE_NO,TEMP_LUYKE_CO FROM PHC_TEMP_SODU WHERE THANG = ''||P_DEN_THANG||'' AND TAI_KHOAN = KHOITAO.TAI_KHOAN AND USER_NAME  =  ''||P_USER_NAME||'';
                                QUERY_UPDATE_LUYKE := 'UPDATE PHC_TEMP_SODU SET LUYKE_NO = '''||TEMP_LUYKE_NO||''',LUYKE_CO = '''||TEMP_LUYKE_CO||''' WHERE TAI_KHOAN = '''||KHOITAO.TAI_KHOAN||''' AND THANG = 13 AND USER_NAME = '''||P_USER_NAME||''' ';
                                EXECUTE IMMEDIATE QUERY_UPDATE_LUYKE;
                            END LOOP;
                            
                        END;
                        OPEN CURSOR_RESULT FOR 'SELECT * FROM PHC_TEMP_SODU WHERE THANG = 13 ORDER BY THANG,TAI_KHOAN';
                        EXCEPTION
                           WHEN NO_DATA_FOUND
                           THEN
                              DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
                           WHEN OTHERS
                           THEN
                              --DBMS_OUTPUT.put_line (QUERY_STR  || SQLERRM); 
                              DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
                              END;
        END;
END PHC_PRC_BANGKE_CANDOI;