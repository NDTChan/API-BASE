create or replace PROCEDURE       PROC_PHA_BC_THEO_DMCT (
   LOAI_BC      IN     NUMBER,
   mabaocao     IN     NVARCHAR2,
   DONVI_TIEN   IN     NUMBER,
   TUNGAY_HL    IN     DATE,
   DENNGAY_HL   IN     DATE,
   TUNGAY_KS    IN     DATE,
   DENNGAY_KS   IN     DATE,
   CUR1            OUT SYS_REFCURSOR)
AS

   Row_Type  DM_CHITIEU_BAOCAO%RowType;-- Chuyen doi FEET sang day
   CUR           SYS_REFCURSOR;
   STT           NVARCHAR2 (20000);
   SAPXEP        NVARCHAR2 (100);
   MA_CHITIEU    VARCHAR2 (50);
   NGAY_HL       DATE;
   NGAY_HET_HL   DATE;
   TEN_CHITIEU   VARCHAR2 (2000);
   TRANGTHAI     VARCHAR2 (1);
   MA_DONG       VARCHAR2 (100);
   INDAM         NUMBER (10, 0);
   INNGHIENG     NUMBER (10, 0);
   HIENTHI       VARCHAR2 (1);
   LOAI          NUMBER (10, 0);
   DAU           NUMBER (10, 0);
   ILV           NUMBER (10, 0);
   TW_PS         NUMBER (15, 0);
   TW_LK         NUMBER (15, 0);
   TINH_PS       NUMBER (15, 0);
   TINH_LK       NUMBER (15, 0);
   HUYEN_PS      NUMBER (15, 0);
   HUYEN_LK      NUMBER (15, 0);
   XA_PS         NUMBER (15, 0);
   XA_LK         NUMBER (15, 0);
BEGIN
   DELETE TEMPTB_DMCT;
   STC_PA_SYS.PRC_TH_MLNS (TUNGAY_HL,
                          DENNGAY_HL,
                          LOAI_BC);
   -- 1. Lay du lieu [Chi tieu, so lieu TW, Tinh, Huyen, Xa (sau khi convert)] vao Con tro
   OPEN CUR FOR
      SELECT DMCT_BC.INDAM,
             DMCT_BC.INNGHIENG,
             DMCT_BC.HIENTHI,
             DMCT_BC.STT,
             DMCT_BC.SAPXEP,
             DMCT_BC.MA_DONG,
             DMCT_BC.TEN_CHITIEU,
             DMCT_BC.NGAY_HL,
             DMCT_BC.DAU,
             NVL (GT.TW_PS, 0),
             NVL (GT.TW_LK, 0),
             NVL (GT.TINH_PS, 0),
             NVL (GT.TINH_LK, 0),
             NVL (GT.HUYEN_PS, 0),
             NVL (GT.HUYEN_LK, 0),
             NVL (GT.XA_PS, 0),
             NVL (GT.XA_LK, 0)
        FROM DM_CHITIEU_BAOCAO DMCT_BC,
             TABLE (STC_PHA_BCDMCT.FCN_GET_PHA_BCDMCT (
                       2,
                       DMCT_BC.CONGTHUC,
                        TUNGAY_HL,
                       DENNGAY_HL,
                       TUNGAY_KS,
                        DENNGAY_KS,
                       DONVI_TIEN)) GT
       WHERE DMCT_BC.MA_BAOCAO = mabaocao;
    -- End Of 1.
   --2. Lap Con tro sau do insert tung dong du lieu vao bang Temp
   LOOP
      FETCH CUR
         INTO INDAM, 
              INNGHIENG,
              HIENTHI,
              STT,
              SAPXEP,
              MA_DONG,
              TEN_CHITIEU,
              NGAY_HL,
              DAU,
              TW_PS,
              TW_LK,
              TINH_PS,
              TINH_LK,
              HUYEN_PS,
              HUYEN_LK,
              XA_PS,
              XA_LK;

      IF CUR%FOUND
      THEN
         BEGIN
            INSERT INTO temptb_dmct
                 VALUES (STT,
                         SAPXEP,
                         NGAY_HL,
                         TEN_CHITIEU,
                         TRANGTHAI,
                         MA_DONG,
                         INDAM,
                         INNGHIENG,
                         HIENTHI,
                         DAU,
                         TW_PS,
                         TW_LK,
                         TINH_PS,
                         TINH_LK,
                         HUYEN_PS,
                         HUYEN_LK,
                         XA_PS,
                         XA_LK);
         END;
      ELSE
         EXIT;
      END IF;
   END LOOP;
   -- End Of 2.
   -- 3. Tra du lieu ve con tro Out de len bao cao
   STC_PA_SYS.PRC_SUM_UP;
   OPEN CUR1 FOR select * from temptb_dmct ORDER BY MA_DONG;
   /*
   OPEN CUR1 FOR
        SELECT t.STT,
               t.SAPXEP,
               t.NGAY_HL,
               t.TEN_CHITIEU,
               t.MA_DONG,
               t.INDAM,
               t.INNGHIENG,
               t.HIENTHI,
               t.DAU,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE TW_PS * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     TW_PS
               END
                  AS TW_PS,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE TW_LK * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     TW_LK
               END
                  AS TW_LK,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (
                                CASE DAU WHEN 0 THEN 0 ELSE TINH_PS * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     TINH_PS
               END
                  AS TINH_PS,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (
                                CASE DAU WHEN 0 THEN 0 ELSE TINH_LK * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     TINH_LK
               END
                  AS TINH_LK,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (
                                CASE DAU WHEN 0 THEN 0 ELSE HUYEN_PS * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     HUYEN_PS
               END
                  AS HUYEN_PS,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (
                                CASE DAU WHEN 0 THEN 0 ELSE HUYEN_LK * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     HUYEN_LK
               END
                  AS HUYEN_LK,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE XA_PS * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     XA_PS
               END
                  AS XA_PS,
               CASE
                  WHEN DAU <> 0
                  THEN
                     (SELECT SUM (CASE DAU WHEN 0 THEN 0 ELSE XA_LK * DAU END)
                        FROM temptb_dmct
                       WHERE MA_DONG LIKE t.MA_DONG || '%')
                  ELSE
                     XA_LK
               END
                  AS XA_LK
          FROM temptb_dmct t
      ORDER BY MA_DONG;*/
END PROC_PHA_BC_THEO_DMCT;