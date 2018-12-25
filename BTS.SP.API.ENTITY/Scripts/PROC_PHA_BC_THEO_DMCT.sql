create or replace procedure PROC_PHA_BC_THEO_DMCT(mabaocao nvarchar2 default null,DONVI_TIEN NUMBER,TUNGAY_KS DATE, DENNGAY_KS DATE,oCurSp2 OUT SYS_REFCURSOR) as 
begin
open oCurSp2 for select ct.SAPXEP,ct.INDAM,ct.INNGHIENG,ct.STT,ct.TEN_CHITIEU,bcc.TW_PS,bcc.TW_LK,bcc.TINH_PS,bcc.TINH_LK,bcc.HUYEN_PS,bcc.HUYEN_LK,bcc.XA_PS,bcc.XA_LK 
                from (select MA_CHITIEU, sum(TW_PS) as TW_PS, sum(TW_LK) as TW_LK,sum(TINH_PS) as TINH_PS, sum(TINH_LK) as TINH_LK,sum(HUYEN_PS) as HUYEN_PS, sum(HUYEN_LK) as HUYEN_LK,sum(XA_PS) as XA_PS, sum(XA_LK) as XA_LK
                    from ( select connect_by_root(MA_CHITIEU) as MA_CHITIEU, TW_PS, TW_LK,TINH_PS,TINH_LK,HUYEN_LK,HUYEN_PS,XA_PS,XA_LK
                           from (select ct.SAPXEP,ct.MA_CHITIEU,ct.MA_CHITIEU_CHA, ct.TEN_CHITIEU,gt.TW_PS,gt.TW_LK,gt.TINH_PS,gt.TINH_LK, gt.HUYEN_LK,gt.HUYEN_PS,gt.XA_PS,gt.XA_LK
                                    from DM_CHITIEU ct ,table(STC_PHA_BCDMCT.FCN_GET_PHA_BCDMCT('2',ct.CONGTHUC,TUNGAY_KS,DENNGAY_KS,DONVI_TIEN)) gt 
                                    where ct.MA_BAOCAO=mabaocao
                            ) bc 
                           connect by MA_CHITIEU_CHA=(prior MA_CHITIEU))
                    group by MA_CHITIEU) bcc JOIN DM_CHITIEU ct on ct.MA_CHITIEU = bcc.MA_CHITIEU
                    order by ct.SAPXEP;
end PROC_PHA_BC_THEO_DMCT;