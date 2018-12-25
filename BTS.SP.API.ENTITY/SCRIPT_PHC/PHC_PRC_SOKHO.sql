create or replace PROCEDURE PHC_PRC_SOKHO (P_CONGTHUC VARCHAR2, P_TUNGAY_HL IN DATE, P_DENNGAY_HL IN DATE, P_MA_KHO VARCHAR2, P_MA_VATTU VARCHAR2, P_USERNAME IN VARCHAR, cur OUT SYS_REFCURSOR) as
   
   INSERT_STR  VARCHAR2(32767);
   P_CT        VARCHAR2(32767);
   V_COUNT NUMBER;
   T_SO_CHUNGTU VARCHAR2(200);
   P_TU_THANG VARCHAR2(2) := TO_NUMBER(TO_CHAR(TO_DATE(P_TUNGAY_HL,'DD/MM/YY'),'MM'));
   P_DEN_THANG VARCHAR2(2) := TO_NUMBER(TO_CHAR(TO_DATE(P_DENNGAY_HL,'DD/MM/YY'),'MM')); 
   FUNCTION F_CALC_MONTH(P_MONTH NUMBER,P_YEAR NUMBER,REQUEST VARCHAR2) RETURN DATE IS
        P_RETURN DATE;
        P_PARA VARCHAR2(50);
    BEGIN
        P_PARA := '01/' ||P_MONTH||'/'||P_YEAR||'';
        IF REQUEST = 'F' THEN 
            SELECT TRUNC(TO_DATE(''||P_PARA||'','DD/MM/YY')) - (to_number(to_char(TO_DATE(''||P_PARA||'','DD/MM/YY'),'DD')) - 1) INTO P_RETURN FROM DUAL;
        ELSIF REQUEST = 'L' THEN
            SELECT ADD_MONTHS(TRUNC(TO_DATE(''||P_PARA||'','DD/MM/YY')) - (to_number(to_char(TO_DATE(''||P_PARA||'','DD/MM/YY'),'DD')) - 1), 1) - 1 INTO P_RETURN FROM DUAL;
        END IF;
       RETURN P_RETURN;
    END F_CALC_MONTH; 
    BEGIN
        EXECUTE IMMEDIATE 'DELETE PHC_TEMP_SOKHO WHERE USER_NAME = '''||P_USERNAME||'''';  
        IF(P_CONGTHUC IS NULL) THEN P_CT:= '1=1 AND ';
            ELSE P_CT := P_CONGTHUC;
        END IF;   
        ----------------------- INSERT DỮ LIỆU VÀO BẢNG TẠM - PHC_TEMP_SOKHO -------------------------
        FOR LIST_CHUNGTU IN (SELECT MA_CHUNGTU,SO_CHUNGTU,NGAY_CT,NGAY_HT,MA_KHO,LOAIHINH_DOITUONG,SOLUONG,DIENGIAI FROM V_PHC_TH_CHUNGTU 
        WHERE MA_CHUNGTU IN ('PNK','GTCC','PXK','GGCC') AND MA_KHO = ''||P_MA_KHO||'' AND LOAIHINH_DOITUONG = ''||P_MA_VATTU||'' AND TO_DATE(NGAY_HT,'DD-MM-YY') > TO_DATE(P_TUNGAY_HL,'DD-MM-YY') AND TO_DATE(NGAY_HT,'DD-MM-YY') < TO_DATE(P_DENNGAY_HL,'DD-MM-YY') ORDER BY NGAY_HT,SO_CHUNGTU)
        LOOP
            INSERT_STR := 'INSERT INTO PHC_TEMP_SOKHO(THANG,NGAY_HT,NGAY_CT,SO_CHUNGTU,MA_CHUNGTU,MA_KHO,
            LOAIHINH_DOITUONG,SODU_DAUKY,TON_DAU,SOLUONG,TON_CUOI,SODU_CUOIKY,DIEN_GIAI,USER_NAME) 
            VALUES ('||TO_NUMBER(TO_CHAR(TO_DATE(LIST_CHUNGTU.NGAY_HT,'DD/MM/YY'),'MM'))||','''||LIST_CHUNGTU.NGAY_HT||''','''||LIST_CHUNGTU.NGAY_CT||'''
            ,'''||LIST_CHUNGTU.SO_CHUNGTU||''','''||LIST_CHUNGTU.MA_CHUNGTU||''','''||LIST_CHUNGTU.MA_KHO||''','''||LIST_CHUNGTU.LOAIHINH_DOITUONG||''',0,0,'||NVL(LIST_CHUNGTU.SOLUONG,0)||',0,0,'''||NVL(LIST_CHUNGTU.DIENGIAI,0)||''','''||P_USERNAME||''')';
            DBMS_OUTPUT.PUT_LINE('ẦDF' || INSERT_STR);
            EXECUTE IMMEDIATE INSERT_STR;
        END LOOP;
        DECLARE          
            QUERRY_UPDATE_TON_DAU VARCHAR2(5000);
            QUERRY_UPDATE_TON_CUOI VARCHAR2(5000);
            QUERRY_UPDATE_TON_THANG VARCHAR2(5000);
            TEMP_TON_CUOI NUMBER;
            TEMP_TON_DAU_NEXT NUMBER;
            T_THANG_MINUS NUMBER;
            T_THANG_NOW NUMBER;
            T_NAM NUMBER;
            T_CUOI_THANG_MINUS DATE;
            T_CUOI_THANG_NOW DATE;
            T_ROW_TEMP_SOKHO PHC_TEMP_SOKHO%ROWTYPE;
        BEGIN            
            ----------------------- TÍNH TỒN BẢN GHI -------------------------
            --- Update tồn đầu bản ghi đầu tiên theo ngày hạch toán
            FOR T_RECORD IN (SELECT * FROM PHC_TEMP_SOKHO WHERE  USER_NAME = ''||P_USERNAME||'' AND ROWNUM = 1 ORDER BY NGAY_HT,SO_CHUNGTU)
            LOOP
                QUERRY_UPDATE_TON_DAU := 'UPDATE PHC_TEMP_SOKHO SET 
                                                            TON_DAU = '||PHC_FCN_ACCOUNT_BY_MER(''||T_RECORD.NGAY_HT||'',''||T_RECORD.NGAY_HT||'',''||T_RECORD.MA_CHUNGTU||'',''||T_RECORD.LOAIHINH_DOITUONG||'',''||T_RECORD.MA_KHO||'',''||P_USERNAME||'','TONDAU_SL')||'                                                            
                                                            WHERE USER_NAME = '''||P_USERNAME||''' AND THANG = '||T_RECORD.THANG||' AND SO_CHUNGTU = '''||T_RECORD.SO_CHUNGTU||''' ';    
                --DBMS_OUTPUT.PUT_LINE('QUERRY_UPDATE_TON_DAU:'||QUERRY_UPDATE_TON_DAU);  
                EXECUTE IMMEDIATE      QUERRY_UPDATE_TON_DAU;  
            END LOOP;
            -- Kết thúc Update tồn đầu bản ghi đầu tiên theo ngày hạch toán

            --- Update tồn cuối các bản ghi          
            TEMP_TON_CUOI := 0;            
            TEMP_TON_DAU_NEXT :=0;
            SELECT COUNT(*) INTO V_COUNT FROM PHC_TEMP_SOKHO WHERE  USER_NAME = ''||P_USERNAME||'';
            --DBMS_OUTPUT.PUT_LINE('V_COUNT:'||V_COUNT);
            IF V_COUNT > 0 THEN
                FOR T_LIST_SOKHO IN (SELECT TON_DAU,SOLUONG,MA_CHUNGTU,SO_CHUNGTU,THANG,TON_CUOI FROM PHC_TEMP_SOKHO WHERE  USER_NAME = ''||P_USERNAME||'' ORDER BY NGAY_HT,SO_CHUNGTU)
                LOOP    
                        IF T_LIST_SOKHO.TON_DAU > 0 THEN TEMP_TON_DAU_NEXT := T_LIST_SOKHO.TON_DAU; END IF;
                        IF T_LIST_SOKHO.MA_CHUNGTU = 'PNK' OR T_LIST_SOKHO.MA_CHUNGTU = 'GTCC' THEN TEMP_TON_CUOI := TEMP_TON_DAU_NEXT + T_LIST_SOKHO.SOLUONG; 
                        ELSIF T_LIST_SOKHO.MA_CHUNGTU = 'PXK' OR T_LIST_SOKHO.MA_CHUNGTU = 'GGCC' THEN TEMP_TON_CUOI := TEMP_TON_DAU_NEXT - T_LIST_SOKHO.SOLUONG; 
                        END IF;
                        QUERRY_UPDATE_TON_CUOI := 'UPDATE PHC_TEMP_SOKHO SET TON_CUOI = '||TEMP_TON_CUOI||' WHERE USER_NAME = '''||P_USERNAME||''' AND MA_CHUNGTU = '''|| T_LIST_SOKHO.MA_CHUNGTU ||''' AND THANG = '''||T_LIST_SOKHO.THANG||''' ' ;
                        --DBMS_OUTPUT.put_line ('QUERRY_UPDATE_TON_CUOI:  ' || QUERRY_UPDATE_TON_CUOI);
                        EXECUTE IMMEDIATE QUERRY_UPDATE_TON_CUOI;
                        -- Lấy ra tồn cuối bản ghi hiện tại để làm tồn đầu bản ghi kế tiếp
                        SELECT TON_CUOI INTO TEMP_TON_DAU_NEXT FROM PHC_TEMP_SOKHO WHERE  USER_NAME = ''||P_USERNAME||'' AND MA_CHUNGTU= ''|| T_LIST_SOKHO.MA_CHUNGTU ||'' AND THANG= ''|| T_LIST_SOKHO.THANG ||'';
                        --DBMS_OUTPUT.PUT_LINE('TEMP_TON_DAU_NEXT:'||TEMP_TON_DAU_NEXT);
                END LOOP;         
            END IF;
           -- Kết thúc Update tồn cuối các bản ghi  
           ----------------------- KẾT THÚC TÍNH TỒN BẢN GHI -------------------------

           ----------------------- TÍNH TỒN THÁNG -------------------------
            FOR LIST_THANG IN (SELECT DISTINCT(THANG) FROM PHC_TEMP_SOKHO WHERE  USER_NAME = ''||P_USERNAME||'')
            LOOP                
                SELECT MAX(SO_CHUNGTU) INTO T_SO_CHUNGTU FROM PHC_TEMP_SOKHO WHERE USER_NAME = ''||P_USERNAME||'' AND THANG = ''||LIST_THANG.THANG||'';
                SELECT * INTO T_ROW_TEMP_SOKHO FROM  PHC_TEMP_SOKHO WHERE USER_NAME = ''||P_USERNAME||'' AND THANG = ''||LIST_THANG.THANG||'' AND SO_CHUNGTU = ''||T_SO_CHUNGTU||'';
                T_THANG_MINUS := TO_NUMBER(TO_CHAR(TO_DATE(T_ROW_TEMP_SOKHO.NGAY_HT,'DD/MM/YY'),'MM')) - 1;
                T_THANG_NOW := TO_NUMBER(TO_CHAR(TO_DATE(T_ROW_TEMP_SOKHO.NGAY_HT,'DD/MM/YY'),'MM'));
                T_NAM := TO_NUMBER(TO_CHAR(TO_DATE(T_ROW_TEMP_SOKHO.NGAY_HT,'DD/MM/YY'),'YYYY'));
                T_CUOI_THANG_MINUS := F_CALC_MONTH(T_THANG_MINUS,T_NAM,'L');
                T_CUOI_THANG_NOW := F_CALC_MONTH(T_THANG_NOW,T_NAM,'L');
                DBMS_OUTPUT.PUT_LINE('T_CUOI_THANG_NOW:'||T_CUOI_THANG_NOW);
                QUERRY_UPDATE_TON_THANG := 'UPDATE PHC_TEMP_SOKHO SET 
                SODU_DAUKY = '||PHC_FCN_ACCOUNT_BY_MER(''||T_CUOI_THANG_MINUS||'',''||T_CUOI_THANG_MINUS||'',''||T_ROW_TEMP_SOKHO.MA_CHUNGTU||'',''||T_ROW_TEMP_SOKHO.LOAIHINH_DOITUONG||'',''||T_ROW_TEMP_SOKHO.MA_KHO||'',''||P_USERNAME||'','TONDAU_THANG_SL')||',
                SODU_CUOIKY = '||PHC_FCN_ACCOUNT_BY_MER(''||T_CUOI_THANG_NOW||'',''||T_CUOI_THANG_NOW||'',''||T_ROW_TEMP_SOKHO.MA_CHUNGTU||'',''||T_ROW_TEMP_SOKHO.LOAIHINH_DOITUONG||'',''||T_ROW_TEMP_SOKHO.MA_KHO||'',''||P_USERNAME||'','TONCUOI_THANG_SL')||'
                WHERE USER_NAME = '''||P_USERNAME||''' AND THANG = '||T_ROW_TEMP_SOKHO.THANG||' AND SO_CHUNGTU = '''||T_SO_CHUNGTU||''' ';    
                --DBMS_OUTPUT.PUT_LINE('QUERRY_UPDATE_TON_THANG:'||QUERRY_UPDATE_TON_THANG);                                   
                EXECUTE IMMEDIATE QUERRY_UPDATE_TON_THANG;  
             END LOOP;
            ----------------------- KẾT THÚC TÍNH TỒN THÁNG -------------------------

        END;
        OPEN cur FOR 'SELECT * FROM PHC_TEMP_SOKHO WHERE USER_NAME = '''||P_USERNAME||''' ORDER BY NGAY_HT,SO_CHUNGTU' ;        
        EXCEPTION
           WHEN NO_DATA_FOUND
           THEN
              DBMS_OUTPUT.put_line ('<your message>' || SQLERRM);
           WHEN OTHERS
           THEN
              DBMS_OUTPUT.put_line ('ERROR'  || SQLERRM); 



END PHC_PRC_SOKHO;