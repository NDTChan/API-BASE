create or replace PROCEDURE MBL_THU_CHI_TOAN_TINH IS
 P_INSERT VARCHAR2(32767);
  P_UPDATE VARCHAR2(32767);
   CURREN_YEAR NUMBER := TO_NUMBER(to_char(SYSDATE,'yyyy'));
   thang dbms_sql.varchar2_table;
    thangNum dbms_sql.number_table;
     TUNGAY_KS  DATE;
   DENNGAY_KS  DATE;
   TUNGAY_HL DATE;
   DENNGAY_HL  DATE;
   V_TU_NAM NUMBER := TO_NUMBER(to_char(TUNGAY_HL,'yyyy'));
    P_CT clob;
     P_DELETE VARCHAR2(32767);
BEGIN
thang(1):='JAN'; thangNum(1):=1;
    thang(2):='FEB'; thangNum(2):=2;
    thang(3):='MAR'; thangNum(3):=3;
    thang(4):='APR'; thangNum(4):=4;
    thang(5):='MAY'; thangNum(5):=5;
    thang(6):='JUN'; thangNum(6):=6;
    thang(7):='JUL'; thangNum(7):=7;
    thang(8):='AUG'; thangNum(8):=8;
    thang(9):='SEP'; thangNum(9):=9;
    thang(10):='OCT'; thangNum(10):=10;
    thang(11):='NOV'; thangNum(11):=11;
    thang(12):='DEC'; thangNum(12):=12;


     FOR n IN thang.FIRST .. thang.LAST
   LOOP
       
        P_CT:= '1=1';
                       TUNGAY_KS  := TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                       ----DBMS_OUTPUT.Put_Line(TUNGAY_KS);
                    DENNGAY_KS  :=LAST_DAY(TUNGAY_KS);
                                           ----DBMS_OUTPUT.Put_Line(DENNGAY_KS); 

                    TUNGAY_HL  :=TO_DATE('01-'||thang(n)||'-'||CURREN_YEAR,'dd-MM-yyyy');
                    DENNGAY_HL  :=LAST_DAY(TUNGAY_HL);
                    V_TU_NAM:= CURREN_YEAR;
                    P_DELETE:= 'DELETE FROM MBL_PHA_TC_TOANTINH WHERE NAM ='||CURREN_YEAR||' AND THANG = '||thangNum(n)||'';
                    P_INSERT:='INSERT INTO MBL_PHA_TC_TOANTINH (NAM,THANG) VALUES('||CURREN_YEAR||','||thangNum(n)||')';
                    BEGIN
                        Execute Immediate P_DELETE;
                        Execute Immediate P_INSERT;
                    END;
                     P_UPDATE:='';
      P_UPDATE :='UPDATE MBL_PHA_TC_TOANTINH SET
                        T_DIABAN = 0,
                        T_NSNN = (SELECT SUM(SOTIEN) FROM MBL_PHA_T_DIABAN WHERE  NAM ='||Curren_Year||' AND THANG = '||thangNum(n)||' ),
                        T_NSDP = (SELECT SUM(T_DT + T_CG + T_CN + T_NNS + T_KDNS +T_KBNN) FROM MBL_PHA_T_NSDP WHERE NAM ='||Curren_Year||' AND THANG = '||thangNum(n)||'),
                        C_NSDP = (SELECT SUM(T_CCD + T_CTN + H_CCD + H_CTN + X_CCD + X_CTN) FROM MBL_PHA_C_NSDP WHERE NAM ='||Curren_Year||' AND THANG = '||thangNum(n)||')
                        WHERE NAM ='||Curren_Year||' AND THANG = '||thangNum(n)||'';
                        
            EXECUTE IMMEDIATE P_UPDATE;
END LOOP;


END MBL_THU_CHI_TOAN_TINH;