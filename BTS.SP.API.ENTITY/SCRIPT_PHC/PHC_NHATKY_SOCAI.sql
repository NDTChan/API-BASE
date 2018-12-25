create or replace PROCEDURE PHC_NHATKY_SOCAI (P_CONGTHUC IN VARCHAR2,TUNGAY IN DATE, DENNGAY IN DATE, CUR_RESULT OUT SYS_REFCURSOR) AS 
    QUERY_STR  VARCHAR2(32767); 
    P_SQL_INSERT VARCHAR2(32767);
    P_WHERE VARCHAR2(32767);
    P_CT VARCHAR2(32767);
    QUERY_DROP VARCHAR2(500); 
    QUERY_INITIALIZE VARCHAR2(32767);
BEGIN
    DECLARE
        v_INST_ID  NUMBER;
        v_SID  NUMBER;
        v_SERIAL  NUMBER;
        v_CLO_TMP  VARCHAR2(5000);
        v_CLO_NO  VARCHAR2(5000);
        v_CLO_CO  VARCHAR2(5000);
        v_CLO_DYNAMIC VARCHAR2(10000);
        v_CLO_BOSUNG VARCHAR2(50);
        QUERY_CHECK_SESSION VARCHAR2(10000); 
        SID_V_LOCK  NUMBER;
        V_COUNT NUMBER;
        V_COUNT_SESSION NUMBER;
    BEGIN
        SELECT COUNT(*) INTO V_COUNT FROM USER_TABLES WHERE TABLE_NAME = UPPER('PHC_TEMP_SOCAI');
        IF V_COUNT > 0 THEN
            SELECT COUNT(*) INTO V_COUNT_SESSION FROM gv$session WHERE SID = (SELECT SID FROM v$lock WHERE TYPE = 'TO' AND ID1 = (SELECT OBJECT_ID FROM DBA_OBJECTS WHERE OBJECT_NAME = 'PHC_TEMP_SOCAI'));
            IF V_COUNT_SESSION > 0 THEN
                SELECT INST_ID,SID,SERIAL# INTO v_INST_ID, v_SID, v_SERIAL FROM gv$session WHERE SID = (SELECT SID FROM v$lock WHERE TYPE = 'TO' AND ID1 = (SELECT OBJECT_ID FROM DBA_OBJECTS WHERE OBJECT_NAME = 'PHC_TEMP_SOCAI'));
                IF v_INST_ID IS NOT NULL AND v_SID IS NOT NULL THEN
                        --EXECUTE IMMEDIATE 'ALTER SYSTEM KILL SESSION '''||v_SID||','||v_SERIAL||','||'@'||v_INST_ID||'''';
                        EXECUTE IMMEDIATE 'DROP TABLE PHC_TEMP_SOCAI';
                        --DBMS_OUTPUT.put_line ('ERROR' );
                END IF;
            ELSE
                EXECUTE IMMEDIATE 'DROP TABLE PHC_TEMP_SOCAI';
            END IF;
       END IF;
                FOR ITEM_NO IN (SELECT DISTINCT(b.TAIKHOAN_NO) FROM V_PHC_TH_CHUNGTU a INNER JOIN PHC_CHUNGTUDETAILS b ON a.SO_CHUNGTU_DETAIL = b.SO_CHUNGTU_DETAIL AND a.NGAY_HT >= TO_DATE (''||TUNGAY||'','DD-MM-YY') AND a.NGAY_HT <= TO_DATE (''||DENNGAY||'','DD-MM-YY') ORDER BY b.TAIKHOAN_NO ASC)
                LOOP   
                    IF(ITEM_NO.TAIKHOAN_NO IS NOT NULL OR ITEM_NO.TAIKHOAN_NO <> '') THEN 
                       v_CLO_NO := v_CLO_NO || 'NO' || ITEM_NO.TAIKHOAN_NO ||' NUMBER(18,2),' || 'CO' || ITEM_NO.TAIKHOAN_NO || ' NUMBER(18,2),';
                       v_CLO_TMP := v_CLO_TMP || '''' || ITEM_NO.TAIKHOAN_NO || '''' || ',';
                    END IF;
                END LOOP; 
                v_CLO_TMP := SUBSTR(v_CLO_TMP,0,LENGTH(v_CLO_TMP)-1);      
                DECLARE
                    QUERY_TEST  VARCHAR2(32767); 
                    v_Temp  VARCHAR2(5000);
                    CUR_COL_CO SYS_REFCURSOR;
                BEGIN
                    QUERY_TEST:= 'SELECT DISTINCT(b.TAIKHOAN_CO) FROM V_PHC_TH_CHUNGTU a INNER JOIN PHC_CHUNGTUDETAILS b ON a.SO_CHUNGTU_DETAIL = b.SO_CHUNGTU_DETAIL AND a.NGAY_HT >= TO_DATE ('''||TUNGAY||''',''DD-MM-YY'') AND a.NGAY_HT <= TO_DATE ('''||DENNGAY||''',''DD-MM-YY'') AND b.TAIKHOAN_CO  NOT IN ('||v_CLO_TMP||')';
                    OPEN CUR_COL_CO FOR QUERY_TEST;
                       LOOP
                          FETCH CUR_COL_CO INTO v_Temp;
                          EXIT WHEN CUR_COL_CO%NOTFOUND;
                          v_CLO_CO := v_CLO_CO || 'NO' || v_Temp ||' NUMBER(18,2),' || 'CO' || v_Temp || ' NUMBER(18,2),';
                       END LOOP;
                    CLOSE CUR_COL_CO;
                END; 
                BEGIN
                    v_CLO_DYNAMIC := v_CLO_NO ||  v_CLO_CO;
                    v_CLO_DYNAMIC := SUBSTR(v_CLO_DYNAMIC,0,LENGTH(v_CLO_DYNAMIC)-1);
                    --CREATE GLOBAL TEMPORARY TABLE PHC_TEMP_SOCAI
                    EXECUTE IMMEDIATE 'CREATE TABLE PHC_TEMP_SOCAI (
                                          NGAY_HT 		DATE,
                                          NGAY_CT 		DATE,
                                          SO_CHUNGTU 	NVARCHAR2(50),
                                          MA_CHUNGTU    NVARCHAR2(50),
                                          SO_CHUNGTU_DETAIL    NVARCHAR2(50),
                                          DIENGIAI 		NVARCHAR2(500),
                                          TAIKHOAN_NO 		NVARCHAR2(50),
                                          TAIKHOAN_CO 		NVARCHAR2(50),
                                          SOTIEN 		NUMBER(18,2),
                                          '||v_CLO_DYNAMIC||'
                                        )
                                        SEGMENT CREATION IMMEDIATE PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING STORAGE
                                        (
                                         INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645 PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT
                                        )';
                    --DBMS_OUTPUT.PUT_LINE(P_SQL_CREATE_TABLE);
                    IF(P_CONGTHUC IS NULL) THEN P_CT:= '1=1 AND ';
                    ELSE P_CT := P_CONGTHUC;
                    END IF;
                    P_WHERE:= P_CT || ' NGAY_HT >= TO_DATE ('''||to_char(TUNGAY,'ddMMyyyy')||''', ''ddMMyyyy'')' ||  ' AND NGAY_HT <= TO_DATE ('''||to_char(DENNGAY,'ddMMyyyy')||''', ''ddMMyyyy'')';    
                    COMMIT;
                    EXECUTE IMMEDIATE 'INSERT INTO PHC_TEMP_SOCAI(NGAY_HT,NGAY_CT,SO_CHUNGTU,MA_CHUNGTU,SO_CHUNGTU_DETAIL,DIENGIAI,TAIKHOAN_NO,TAIKHOAN_CO,SOTIEN) SELECT a.NGAY_HT,a.NGAY_CT,a.SO_CHUNGTU,a.MA_CHUNGTU,a.SO_CHUNGTU_DETAIL,a.DIENGIAI,b.TAIKHOAN_NO,b.TAIKHOAN_CO,a.SOTIEN FROM V_PHC_TH_CHUNGTU a INNER JOIN PHC_CHUNGTUDETAILS b
                    ON a.SO_CHUNGTU_DETAIL = b.SO_CHUNGTU_DETAIL AND '||P_WHERE||' GROUP BY a.NGAY_HT,a.NGAY_CT,a.SO_CHUNGTU,a.MA_CHUNGTU,a.SO_CHUNGTU_DETAIL,a.DIENGIAI,b.TAIKHOAN_NO,b.TAIKHOAN_CO,a.SOTIEN'; 
                    DECLARE
                         T_NGAY_HT DATE;
                         T_SO_CHUNGTU VARCHAR(100);
                         T_MA_CHUNGTU VARCHAR(100);
                         T_SO_CHUNGTU_DETAIL VARCHAR(100);
                         T_TAIKHOAN_NO VARCHAR(10);
                         T_TAIKHOAN_CO VARCHAR(10);
                         CURSOR_SOCAI SYS_REFCURSOR;
                         T_TEMP_NO VARCHAR(10);
                         T_TEMP_CO VARCHAR(10);
                         T_TEMP_TAIKHOAN_NO VARCHAR(10);
                         T_TEMP_TAIKHOAN_CO VARCHAR(10);
                         T_LOAI_NO VARCHAR(10);
                         T_LOAI_CO VARCHAR(10);
                         QUERY_UPDATE_NO VARCHAR2(5000);
                         QUERY_UPDATE_CO VARCHAR2(5000); 
                    BEGIN 
                         OPEN CURSOR_SOCAI FOR 'SELECT NGAY_HT,SO_CHUNGTU,MA_CHUNGTU,SO_CHUNGTU_DETAIL,TAIKHOAN_NO,TAIKHOAN_CO FROM PHC_TEMP_SOCAI';
                           LOOP
                              FETCH CURSOR_SOCAI INTO T_NGAY_HT,T_SO_CHUNGTU,T_MA_CHUNGTU,T_SO_CHUNGTU_DETAIL,T_TAIKHOAN_NO,T_TAIKHOAN_CO;
                              EXIT WHEN CURSOR_SOCAI%NOTFOUND;
                              -- GHÉP TÊN TÀI KHOẢN NỢ
                              FOR SELECT_NO IN (SELECT a.SOTIEN,a.TAIKHOAN FROM PHC_CHUNGTUCHITIET a WHERE a.SO_CHUNGTU = T_SO_CHUNGTU AND a.SO_CHUNGTU_DETAIL = T_SO_CHUNGTU_DETAIL AND a.LOAI = 'N')
                              LOOP
                                T_TEMP_NO := 'NO' || SELECT_NO.TAIKHOAN;
                                QUERY_UPDATE_NO := 'UPDATE PHC_TEMP_SOCAI SET '||T_TEMP_NO||' = '||SELECT_NO.SOTIEN||' WHERE SO_CHUNGTU = '''||T_SO_CHUNGTU||''' AND MA_CHUNGTU = '''||T_MA_CHUNGTU||''' AND SO_CHUNGTU_DETAIL = '''||T_SO_CHUNGTU_DETAIL||''' ';
                                DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_NO :  ' || QUERY_UPDATE_NO);
                                EXECUTE IMMEDIATE QUERY_UPDATE_NO;
                              END LOOP;
                               -- GHÉP TÊN TÀI KHOẢN CO
                              FOR SELECT_CO IN (SELECT a.SOTIEN,a.TAIKHOAN FROM PHC_CHUNGTUCHITIET a WHERE a.SO_CHUNGTU = T_SO_CHUNGTU AND a.SO_CHUNGTU_DETAIL = T_SO_CHUNGTU_DETAIL AND a.LOAI = 'C')
                              LOOP
                                T_TEMP_CO := 'CO' || SELECT_CO.TAIKHOAN;
                                QUERY_UPDATE_CO := 'UPDATE PHC_TEMP_SOCAI SET '||T_TEMP_CO||' = '||SELECT_CO.SOTIEN||' WHERE SO_CHUNGTU = '''||T_SO_CHUNGTU||''' AND MA_CHUNGTU = '''||T_MA_CHUNGTU||''' AND SO_CHUNGTU_DETAIL = '''||T_SO_CHUNGTU_DETAIL||''' ';
                                DBMS_OUTPUT.PUT_LINE('QUERY_UPDATE_CO :  ' || QUERY_UPDATE_CO);
                                EXECUTE IMMEDIATE QUERY_UPDATE_CO;
                              END LOOP;
                           END LOOP;
                        CLOSE CURSOR_SOCAI;
                        
                        OPEN CUR_RESULT FOR 'SELECT * FROM PHC_TEMP_SOCAI ORDER BY NGAY_HT,SO_CHUNGTU';
                        EXCEPTION
                           WHEN NO_DATA_FOUND
                           THEN
                              DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
                           WHEN OTHERS
                           THEN
                              DBMS_OUTPUT.put_line ('ERROR'  || SQLERRM); 
                        END;
                    EXCEPTION
                    WHEN OTHERS THEN 
                        NULL;
                    END;
        
    END;
END PHC_NHATKY_SOCAI;