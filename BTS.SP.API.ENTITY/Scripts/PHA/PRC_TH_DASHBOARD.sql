create or replace PROCEDURE "PRC_TH_DASHBOARD"(
      --P_THANG           NUMBER,
     -- P_NAM             NUMBER,
    P_SHKB           VARCHAR2,
    P_NAM_BATDAU     NUMBER,
    P_NAM_KETTHUC    NUMBER
)
  IS  
    v_shkb varchar2(10);
  BEGIN
    --Check shkb
    If(Length(Nvl(P_SHKB,'')) = 0)
    Then 
        v_shkb := '%';
    Else
        v_shkb := P_SHKB || '%';
    End IF;
    --Delete old data
    
    FOR P_NAM IN P_NAM_BATDAU..P_NAM_KETTHUC LOOP    
        FOR P_THANG IN 1..12 LOOP            
            
                Delete PHA_DASHBOARD where SHKB = P_SHKB And NAM = P_NAM And THANG = P_THANG;
        
                Insert Into PHA_DASHBOARD(T_TW, T_TI, T_HU, T_XA, C_TW, C_TI, C_HU, C_XA, SHKB, NAM, THANG)
                Select T.T_TW, T.T_TI, T.T_HU, T.T_XA , C.C_TW, C.C_TI, C.C_HU, C.C_XA, P_SHKB, P_NAM, P_THANG From
                (
                Select 
                    Sum(Case To_char(T.ma_cap) when '1' then T.Gia_tri_hach_toan else 0 End) T_TW,
                    Sum(Case To_char(T.ma_cap) when '2' then T.Gia_tri_hach_toan else 0 End) T_TI,
                    Sum(Case To_char(T.ma_cap) when '3' then T.Gia_tri_hach_toan else 0 End) T_HU,
                    Sum(Case To_char(T.ma_cap) when '4' then T.Gia_tri_hach_toan else 0 End) T_XA
                from PHA_HACHTOAN_THU T
                where 1=1    
                AND (T.MA_KBNN Like v_shkb)
                And (To_Char(T.NGAY_HIEU_LUC,'MMyyyy') = (Case When (P_THANG < 10) Then '0'|| P_THANG || P_NAM Else ''|| P_THANG || P_NAM End))
                --AND (T.MA_KBNN = (Case Length(Nvl(P_SHKB,'')) When 0 Then To_Char(T.MA_KBNN) Else To_Char(P_SHKB) End))
                --And (T.NGAY_HIEU_LUC between P_BNGAY_HACHTOAN and P_ENGAY_HACHTOAN) 
                --And (T.NGAY_KET_SO between P_BNGAY_KETSO and P_ENGAY_KETSO) 
                ) T,
                (    
                Select 
                    Sum(Case To_char(C.ma_cap) when '1' then C.Gia_tri_hach_toan else 0 End) C_TW,
                    Sum(Case To_char(C.ma_cap) when '2' then C.Gia_tri_hach_toan else 0 End) C_TI,
                    Sum(Case To_char(C.ma_cap) when '3' then C.Gia_tri_hach_toan else 0 End) C_HU,
                    Sum(Case To_char(C.ma_cap) when '4' then C.Gia_tri_hach_toan else 0 End) C_XA
                from PHA_HACHTOAN_CHI C
                where 1=1    
                AND (C.MA_KBNN Like v_shkb)
                And (To_Char(C.NGAY_HIEU_LUC,'MMyyyy') = (Case When (P_THANG < 10) Then '0'|| P_THANG || P_NAM Else ''|| P_THANG || P_NAM End))
                --AND (C.MA_KBNN = (Case Length(Nvl(P_SHKB,'')) When 0 Then To_Char(C.MA_KBNN) Else To_Char(P_SHKB) End))
                --And (C.NGAY_HIEU_LUC between P_BNGAY_HACHTOAN and P_ENGAY_HACHTOAN) 
                --And (C.NGAY_KET_SO between P_BNGAY_KETSO and P_ENGAY_KETSO) 
                ) C
                Where 1=1;
            
        END LOOP;
   END LOOP;       

  END PRC_TH_DASHBOARD;