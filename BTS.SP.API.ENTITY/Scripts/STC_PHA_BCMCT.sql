create or replace PACKAGE STC_PHA_BCDMCT AS 
    
    TYPE MEASURE_RECORD IS RECORD (
      TW_PS number(15,0),
      TW_LK number(15,0),
      TINH_PS number(15,0),
      TINH_LK number(15,0),
      HUYEN_PS number(15,0),
      HUYEN_LK number(15,0),
      XA_PS number(15,0),
      XA_LK number(15,0)
    );
    TYPE MEASURE_TABLE IS TABLE OF MEASURE_RECORD;
  FUNCTION FCN_GET_PHA_BCDMCT(LOAI_BC NVARCHAR2, CONGTHUC NVARCHAR2,CONGTHUC_SEG1 NVARCHAR2,CONGTHUC_SEG2 NVARCHAR2, TUNGAY_HL DATE, DENNGAY_HL DATE,TUNGAY_KS DATE, DENNGAY_KS DATE,DONVI_TIEN NUMBER)
  RETURN MEASURE_TABLE PIPELINED;
    FUNCTION FCN_TESTDL (LOAI       varchar:= 'thu')
                                RETURN MEASURE_TABLE PIPELINED;
    PROCEDURE PROC_TESTDL (LOAI IN varchar:= 'thu', CUR OUT SYS_REFCURSOR);
END STC_PHA_BCDMCT;
create or replace PACKAGE BODY       STC_PHA_BCDMCT
AS

PROCEDURE PROC_TESTDL (LOAI IN varchar:= 'thu', CUR OUT SYS_REFCURSOR)
as
    rowtype Test_DL%ROWTYPE;
begin
    delete TEMP_MLNS; 
    select * into rowtype from test_dl where name = loai and rownum = 1;
    STC_PA_SYS.PRC_TH_MLNS (To_DATE('0101' || rowtype.nam,'ddMMyyyy'),
                          To_DATE('3112' || rowtype.nam,'ddMMyyyy'),
                          case Loai when 'thu' then 2 else 1 end); 
    open cur for select * from Table(FCN_TESTDL(LOAI));
end;

FUNCTION FCN_TESTDL (LOAI       varchar:= 'thu')
                                RETURN MEASURE_TABLE
      PIPELINED
Is
    rowtype Test_DL%ROWTYPE;
    GIATRI_TABLE   MEASURE_RECORD;
Begin
    -- Xoa DL
    
    -- TH SO LIEU
    select * into rowtype from test_dl where name = loai and rownum = 1;
    
    --DBMS_OUTPUT.put_line(rowtype.ct);
    --DBMS_OUTPUT.put_line(rowtype.nam);
    select * into GIATRI_TABLE from TABLE(STC_PHA_BCDMCT.FCN_GET_PHA_BCDMCT(case Loai when 'thu' then 2 else 1 end,rowtype.ct,'','',To_DATE('0101' || rowtype.nam,'ddMMyyyy'),To_DATE('3112'  || rowtype.nam,'ddMMyyyy'),To_DATE('01012011','ddMMyyyy'),To_DATE('31122016','ddMMyyyy'),1)); 
         PIPE ROW (GIATRI_TABLE);
         RETURN;
End;

   FUNCTION FCN_GET_PHA_BCDMCT (LOAI_BC       NVARCHAR2,
                                CONGTHUC      NVARCHAR2,
                                CONGTHUC_SEG1 NVARCHAR2,
                                CONGTHUC_SEG2 NVARCHAR2,
                                TUNGAY_HL     DATE,
                                DENNGAY_HL    DATE,
                                TUNGAY_KS     DATE,
                                DENNGAY_KS    DATE,
                                DONVI_TIEN    NUMBER)
      RETURN MEASURE_TABLE
      PIPELINED
   IS
      QUERY_STR      VARCHAR2 (30000);
      P_SQL_INSERT   VARCHAR2 (1000);
      P_CONGTHUC     VARCHAR2 (24000);
      P_CONGTHUC1     NVARCHAR2 (12000);
      cur            SYS_REFCURSOR;
      GIATRI_TABLE   MEASURE_RECORD;
   BEGIN
      IF CONGTHUC IS NULL
      THEN
         SELECT 0, 0, 0, 0, 0, 0, 0, 0 INTO GIATRI_TABLE FROM DUAL;
         PIPE ROW (GIATRI_TABLE);
         RETURN;
      END IF;

      IF LOAI_BC IS NULL
      THEN
         P_SQL_INSERT := 'TEMP_MLNS b';
      END IF;

      IF (TRIM (LOAI_BC) = '1')
      THEN
         P_SQL_INSERT := 'TEMP_MLNS b';
      ELSIF (TRIM (LOAI_BC) = '2')
      THEN
         P_SQL_INSERT := 'TEMP_MLNS b';
      ELSE
         P_SQL_INSERT := 'TEMP_MLNS b';
      END IF;
      
      /*if Length(Trim(CONGTHUC_SEG1)) > 0 then
        P_CONGTHUC := CONGTHUC || CONGTHUC_SEG1 || CONGTHUC_SEG2;
        end if;*/
        P_CONGTHUC1 := CONGTHUC || nvl(CONGTHUC_SEG1,'') || nvl(CONGTHUC_SEG2,'');
      
      /*SELECT STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC1)
        INTO P_CONGTHUC
        FROM DUAL;*/
        
        P_CONGTHUC := STC_PA_SYS.FNC_CONVERT_FORMULA (P_CONGTHUC1);

      QUERY_STR :=
            'select SUM(TW_PS)as TW_PS, NVL(SUM(TW_LK),0)as TW_LK,NVL(SUM(TINH_PS),0)as TINH_PS,NVL(SUM(TINH_LK),0)as TINH_LK,NVL(SUM(HUYEN_PS),0)as HUYEN_PS,NVL(SUM(HUYEN_LK),0)as HUYEN_LK,NVL(SUM(XA_PS),0)as XA_PS,NVL(SUM(XA_LK),0)as XA_LK FROM (SELECT 
                 MA_CAP, MA_CAPNS,
                 NVL(SUM (
                    CASE
                       WHEN (    NGAY_HACH_TOAN >= TO_DATE ('''|| TO_CHAR (TUNGAY_HL, 'DD/MM/YY')|| ''', ''DD/MM/YY'')
                             AND NGAY_HACH_TOAN <= TO_DATE ('''|| TO_CHAR (DENNGAY_HL, 'DD/MM/YY')|| ''', ''DD/MM/YY''))
                       THEN
                          GIA_TRI_HACH_TOAN
                       ELSE
                          0
                    END) ,0)
                    AS PS,'||
                 /*NVL(SUM ( CASE
                       WHEN (    NGAY_HACH_TOAN >= TO_DATE ('''||TO_CHAR(TUNGAY_HL, 'YY')||'-01-01'|| ''', ''DD/MM/YY'')
                             AND NGAY_HACH_TOAN <= TO_DATE ('''|| TO_CHAR (DENNGAY_HL, 'DD/MM/YY')|| ''', ''DD/MM/YY''))
                       THEN
                          GIA_TRI_HACH_TOAN
                       ELSE
                          0
                    END ),0) AS LK*/
                    ' Sum(NVL(GIA_TRI_HACH_TOAN,0)) as LK' ||
            ' FROM '
         || P_SQL_INSERT
         || ' 
            WHERE 1=1 And '
         || P_CONGTHUC
         || ' 
        GROUP BY MA_CAP, MA_CAPNS
        )
        PIVOT ( sum(PS) as PS, Sum(LK) as LK
                  FOR MA_CAPNS
                  IN (''1'' AS TW, ''2'' AS TINH, ''3'' AS HUYEN, ''4'' AS XA)
                  )
        ';
        
        -- 13/05/2017 Kiem tra ty le dieu tiet 
--DBMS_OUTPUT.put_line ('abc:' || QUERY_STR);
      /*IF((TRIM (LOAI_BC) = '2'))
      Then
        QUERY_STR:= Replace (QUERY_STR, 'MA_CAPNS','MA_CAP');
      End If;*/
      BEGIN
         OPEN cur FOR QUERY_STR;
      EXCEPTION
         WHEN NO_DATA_FOUND
         THEN
            --DBMS_OUTPUT.put_line ('NoData:' || SQLERRM);
            return;
         WHEN OTHERS
         THEN            
            /*DBMS_OUTPUT.put_line ('Loi:' || QUERY_STR);
            DBMS_OUTPUT.put_line ('CT:' || CONGTHUC);
            DBMS_OUTPUT.put_line ('CT:' || CONGTHUC_SEG1);
            DBMS_OUTPUT.put_line ('CT:' || CONGTHUC_SEG2);
            */
            return;
      END;
      --return;
      OPEN cur FOR QUERY_STR;
      LOOP
         FETCH cur
            INTO GIATRI_TABLE.TW_PS,
                 GIATRI_TABLE.TW_LK,
                 GIATRI_TABLE.TINH_PS,
                 GIATRI_TABLE.TINH_LK,
                 GIATRI_TABLE.HUYEN_PS,
                 GIATRI_TABLE.HUYEN_LK,
                 GIATRI_TABLE.XA_PS,
                 GIATRI_TABLE.XA_LK;

         IF cur%FOUND
         THEN
            PIPE ROW (GIATRI_TABLE);
         ELSE
            EXIT;
         END IF;
      END LOOP;

      RETURN;
   END FCN_GET_PHA_BCDMCT;
END STC_PHA_BCDMCT;