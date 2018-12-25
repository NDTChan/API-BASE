
using System.Data.Entity;
using System.Diagnostics;
using BTS.SP.API.ENTITY.Models.Au;
using BTS.SP.API.ENTITY.Models.Au.PHA;
using BTS.SP.API.ENTITY.Models.Bc.PHB.Bieu03;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01A;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01B;
using BTS.SP.API.ENTITY.Models.Dm;
using BTS.SP.API.ENTITY.Models.Dm.PHA;
using BTS.SP.API.ENTITY.Models.Dm.PHB;
using BTS.SP.API.ENTITY.Models.Sys;
using BTS.SP.API.ENTITY.Models.Nv.PHA;
using BTS.SP.API.ENTITY.Models.Dm.PHC;
using BTS.SP.API.ENTITY.Models.Nv.PHC;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2A;
using BTS.SP.API.ENTITY.Models.Bc.PHB.B01BCQT;
using BTS.SP.API.ENTITY.Models.Bc.PHB.B02BCQT;
using BTS.SP.API.ENTITY.Models.Bc.PHB.B02BCTC;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2B;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU3A;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU4A;
using BTS.SP.API.ENTITY.Models.Bc.PHB.F01_01BCQT;
using BTS.SP.API.ENTITY.Models.Bc.PHC.S16_X;
using BTS.SP.API.ENTITY.Models.Bc.PHC.S17_X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01C;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU07TT344;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU08TT344;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU09TT344;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU3BP1;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU3BP2;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU4BP1;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU4BP2;
using BTS.SP.API.ENTITY.Models.Bc.PHC.QTXDCB;
using BTS.SP.API.ENTITY.Models.Bc.PHB.F01_02BCQT_PII;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU11TT344;
using BTS.SP.API.ENTITY.Models.Bc.PHB.PHB_F01_02BCQT;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU12TT344;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01CP2;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU10TT344;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU68NS;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU69NS;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU70NS;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU67NS;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2CP2;
using BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2CP1;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B01X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B02AX;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B02B_X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03A_X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03B_X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.DOICHIEUSOLIEU;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03D_X;
using BTS.SP.PHB.ENTITY.Rp.B03BCQT_BII1;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B04X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B06X;
using BTS.SP.API.ENTITY.Models.Dm.PHE;
using BTS.SP.API.ENTITY.Dm;
using BTS.SP.API.ENTITY.Models.Au.PHC;
using BTS.SP.API.ENTITY.Models.Bc.PHB.B02H_II;
using BTS.SP.API.ENTITY.Models.Nv.PHE;
using BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03C_X;
using BTS.SP.API.ENTITY.Models.Bc.PHB.PL3_1;
using BTS.SP.API.ENTITY.Models.Bc.PHB.PL41;
using BTS.SP.API.ENTITY.Models.Bc.PHB.PHB_PL32_P2_TT01;
using BTS.SP.API.ENTITY.Models.Bc.PHB.PL32_P1_TT01;
using BTS.SP.API.ENTITY.Models.Bc.PHB.PL42_P1_TT01;
using BTS.SP.API.ENTITY.Models.Mobile;
using BTS.SP.API.ENTITY.Models.Dm.PHF;
using BTS.SP.API.ENTITY.Models.Nv.PHF;
using BTS.SP.API.ENTITY.Models.Sys.PHF;

namespace BTS.SP.API.ENTITY
{
    public class STCContext : DataContext
    {
        public STCContext()
            : base("name=STCConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<STCContext>(new CreateDatabaseIfNotExists<STCContext>());
            this.Database.Log = s => Debug.WriteLine(s);
        }

        //Sys
        public virtual DbSet<SYS_DONVI> SYS_DONVIs { get; set; }
        public virtual DbSet<SYS_USER> SYS_USERs { get; set; }
        public virtual DbSet<SYS_CHUCNANG> SYS_CHUCNANGs { get; set; }
        public virtual DbSet<SYS_TUDIEN> SYS_TUDIEN { get; set; }
        public virtual DbSet<SYS_DVQHNS> SYS_DVQHNS { get; set; }
        public virtual DbSet<SYS_TONGHOPDL> SYS_TONGHOPDL { get; set; }
        public virtual DbSet<SYS_THAMSO_HETHONG> SYS_THAMSO_HETHONGs { get; set; }
        public virtual DbSet<TDL_SOLIEU> TDL_SOLIEUs { get; set; }
        public virtual DbSet<PHA_KBQT01> PHA_KBQT01s { get; set; }
        public virtual DbSet<PHA_KBQT82> PHA_KBQT82s { get; set; }
        public virtual DbSet<LogSignin> LogSignins { get; set; }

        #region AUTH

        public virtual DbSet<AU_NGUOIDUNG> AU_NGUOIDUNGs { get; set; }
        public virtual DbSet<AU_NGUOIDUNG_NHOMQUYEN> AU_NGUOIDUNG_NHOMQUYENs { get; set; }
        public virtual DbSet<AU_NGUOIDUNG_QUYEN> AU_NGUOIDUNG_QUYENs { get; set; }
        public virtual DbSet<AU_NHOMQUYEN> AU_NHOMQUYENs { get; set; }
        public virtual DbSet<AU_NHOMQUYEN_CHUCNANG> AU_NHOMQUYEN_CHUCNANGs { get; set; }

        #endregion


        #region AUTH PHA
        public virtual DbSet<PHA_AU_NGUOIDUNG_NHOMQUYEN> PHA_AU_NGUOIDUNG_NHOMQUYENs { get; set; }
        public virtual DbSet<PHA_AU_NGUOIDUNG_QUYEN> PHA_AU_NGUOIDUNG_QUYENs { get; set; }
        public virtual DbSet<PHA_AU_NHOMQUYEN> PHA_AU_NHOMQUYENs { get; set; }
        public virtual DbSet<PHA_AU_NHOMQUYEN_CHUCNANG> PHA_AU_NHOMQUYEN_CHUCNANGs { get; set; }
        #endregion

        #region AUTH PHC
        public virtual DbSet<AU_KYKETOAN> AU_KYKETOANs { get; set; }
        public virtual DbSet<AU_PROCESS> AU_PROCESSs { get; set; }
        #endregion
        //MBL
        #region MOBILE
        public virtual DbSet<MBL_PHA_TC_TOANTINH> MBL_PHA_TC_TOANTINHs { get; set; }
        public virtual DbSet<MBL_PHA_T_DIABAN> MBL_PHA_T_DIABANs { get; set; }
        public virtual DbSet<MBL_PHA_T_NSNN> MBL_PHA_T_NSNNs { get; set; }
        public virtual DbSet<MBL_PHA_T_NSDP> MBL_PHA_T_NSDPs { get; set; }
        public virtual DbSet<MBL_PHA_C_NSDP> MBL_PHA_C_NSDPs { get; set; }
        public virtual DbSet<MBL_PHA_QTTDB> MBL_PHA_QTTDBs { get; set; }
        public virtual DbSet<MBL_PHA_CQ_THU> MBL_PHA_CQ_THUs { get; set; }
        public virtual DbSet<MBL_PHA_C_DTTX> MBL_PHA_C_DTTXs { get; set; }


        #endregion
        //Dm
        public virtual DbSet<DM_CHUONG> DMCHUONGs { get; set; }
        public virtual DbSet<DM_NGANHKT> DMNGANHKTs { get; set; }
        public virtual DbSet<DM_TIEUNHOM> DMTIEUNHOMs { get; set; }
        public virtual DbSet<DM_MUC> DMMUCs { get; set; }
        public virtual DbSet<DM_TIEUMUC> DMTIEUMUCs { get; set; }
        public virtual DbSet<DM_TKTN> DMTKTNs { get; set; }
        public virtual DbSet<DM_NGUON_DIA_PHUONG> DM_NGUON_DIA_PHUONGs { get; set; }
        public virtual DbSet<DM_CTMTQG> DMCTMTQGs { get; set; }
        public virtual DbSet<DM_NGUON_NSNN> DM_NGUON_NSNNs { get; set; }
        public virtual DbSet<DM_CHITIEU> DM_CHITIEUs { get; set; }
        public virtual DbSet<DM_BAOCAO> DM_BAOCAOs { get; set; }

        public virtual DbSet<DM_IDBUILDER> DM_IDBUILDERs { get; set; }
        public virtual DbSet<DM_DBHC> DM_DBHCs { get; set; }
        public virtual DbSet<DM_CHITIEU_BAOCAO> DM_CHITIEU_BAOCAOs { get; set; }
        public virtual DbSet<DM_PHONGBAN> DM_PHONGBANs { get; set; }

        public virtual DbSet<DM_MAUBAOCAO> DM_MAUBAOCAOs { get; set; }
        public virtual DbSet<DM_NGHIEPVU> DM_NGHIEPVUs { get; set; }
        public virtual DbSet<TABWH_JEL_FCT_V2> TABWH_JEL_FCT_V2s { get; set; }
        public virtual DbSet<DM_CHITIEU_DUTOAN> DM_CHITIEU_DUTOANs { get; set; }
        public virtual DbSet<DM_CHUCVU> DM_CHUCVUs { get; set; }
        public virtual DbSet<DM_TINHCHAT_DONGTIEN> DM_TINHCHAT_DONGTIENs { get; set; }
        public virtual DbSet<DM_MA_LOAIVON> DM_MA_LOAIVONs { get; set; }
        public virtual DbSet<DM_LOAI_KHV> DM_LOAI_KHVs { get; set; }
        //DM phan he C
        public virtual DbSet<DM_HACHTOANTUDONG> DM_HACHTOANTUDONGs { get; set; }
        public virtual DbSet<DM_MAUBAOCAOTHU> DM_MAUBAOCAOTHUs { get; set; }
        public virtual DbSet<DM_MAUBAOCAOCHI> DM_MAUBAOCAOCHIs { get; set; }
        public virtual DbSet<DM_QUY> DM_QUYs { get; set; }
        public virtual DbSet<DM_DANHMUC> DM_DANHMUCs { get; set; }
        public virtual DbSet<DM_LOAIDUTOAN> DM_LOAIDUTOANs { get; set; }
        public virtual DbSet<DM_LOAIHINH> DM_LOAIHINHs { get; set; }
        public virtual DbSet<DM_NGUONVON> DM_NGUONVONs { get; set; }
        public virtual DbSet<DM_TAIKHOAN> DM_TAIKHOANs { get; set; }
        public virtual DbSet<DM_LOAICT> DM_LOAICTs { get; set; }
        public virtual DbSet<DM_CTMUCTIEU> DM_CTMUCTIEUs { get; set; }
        public virtual DbSet<DM_DTTHANHTOAN> DM_DTTHANHTOANs { get; set; }
        public virtual DbSet<DM_TKKHOBAC> DM_TKKHOBACs { get; set; }
        public virtual DbSet<DM_TINHCHATNGUON> DM_TINHCHATNGUONs { get; set; }
        public virtual DbSet<DM_VATTU> DM_VATTUs { get; set; }
        public virtual DbSet<DM_LOAI_TSCD> DM_LOAI_TSCDs { get; set; }
        public virtual DbSet<DM_TSCD> DM_TSCDs { get; set; }
        public virtual DbSet<DM_KHO> DM_KHOs { get; set; }

        public virtual DbSet<DM_LOAIPHI> DM_LOAIPHIs { get; set; }

        public virtual DbSet<DM_PHC_NGHIEPVU> DM_PHC_NGHIEPVUs { get; set; }
        public virtual DbSet<DM_PHC_CHITIEUTHU_CHI> DM_PHC_CHITIEUTHU_CHIs { get; set; }
        public virtual DbSet<DM_PHC_CONGTHUC_CHITIEUTHU_CHI> DM_PHC_CONGTHUC_CHITIEUTHUCHIs { get; set; }
        public virtual DbSet<DM_PHC_CHITIEU_HAS_CONGTHUC> DM_PHC_CHITIEU_HAS_CONGTHUCs { get; set; }
        public virtual DbSet<DM_DAUTU_XDCB> DM_DAUTU_XDCBs { get; set; }

        public virtual DbSet<PHC_HMTSCD> PHC_HMTSCDs { get; set; }
        public virtual DbSet<PHC_HMTSCD_DETAILS> PHC_HMTSCD_DETAILSs { get; set; }

        //DM Phân hệ E
        public virtual DbSet<PHE_DM_PHONGBAN> PHE_DM_PHONGBANs { get; set; }
        public virtual DbSet<PHE_DM_COQUANBANHANH> PHE_DM_COQUANBANHANHs { get; set; }
        public virtual DbSet<PHE_DM_LINHVUC> PHE_DM_LINHVUCs { get; set; }
        public virtual DbSet<PHE_DM_NHATHAU> PHE_DM_NHATHAUs { get; set; }
        public virtual DbSet<PHE_DM_NHOMDUAN> PHE_DM_NHOMDUANs { get; set; }
        public virtual DbSet<PHE_DM_TINHCHAT_DUAN> PHE_DM_TINHCHAT_DUANs { get; set; }
        public virtual DbSet<PHE_DM_TRANGTHAI_DUAN> PHE_DM_TRANGTHAI_DUANs { get; set; }
        public virtual DbSet<PHE_DM_DONVIQUANLY> PHE_DM_DONVIQUANLYs { get; set; }
        public virtual DbSet<PHE_DM_NHOMDONVI> PHE_DM_NHOMDONVIs { get; set; }
        public virtual DbSet<PHE_DM_LOAIDONVI> PHE_DM_LOAIDONVIs { get; set; }
        public virtual DbSet<PHE_DM_DU_AN> PHE_DM_DU_ANs { get; set; }
        public virtual DbSet<PHE_DM_LOAIDUAN> PHE_DM_LOAIDUANs { get; set; }
        public virtual DbSet<PHE_DM_DACTINH_NGUONVON> PHE_DM_DACTINH_NGUONVONs { get; set; }
        public virtual DbSet<PHE_DM_NGUON_VON> PHE_DM_NGUON_VONs { get; set; }
        public virtual DbSet<PHE_DM_HINHTHUC_QLDA> PHE_DM_HINHTHUC_QLDAs { get; set; }
        public virtual DbSet<PHE_DM_HINHTHUC_DUAN> PHE_DM_HINHTHUC_DUANs { get; set; }
        public virtual DbSet<PHE_DM_PHUONGTHUC_DAUTHAU> PHE_DM_PHUONGTHUC_DAUTHAUs { get; set; }
        public virtual DbSet<PHE_DM_HTLUACHON_NT> PHE_DM_HTLUACHON_NTs { get; set; }
        public virtual DbSet<PHE_DM_LINHVUC_DAUTHAU> PHE_DM_LINHVUC_DAUTHAUs { get; set; }
        public virtual DbSet<PHE_DM_LOAI_VANBAN> PHE_DM_LOAI_VANBANs { get; set; }
        public virtual DbSet<PHE_DM_KHOANCHI> PHE_DM_KHOANCHIs { get; set; }
        public virtual DbSet<PHE_DM_LOAI_KHVON> PHE_DM_LOAI_KHVONs { get; set; }
        public virtual DbSet<PHE_DM_LOAI_PHATSINH> PHE_DM_LOAI_PHATSINHs { get; set; }
        public virtual DbSet<PHE_DM_NGHIEPVU> PHE_DM_NGHIEPVUs { get; set; }
        public virtual DbSet<PHE_DM_GIAIDOAN_VON> PHE_DM_GIAIDOAN_VONs { get; set; }
        public virtual DbSet<PHE_DM_NHOMVANBAN> PHE_DM_NHOMVANBANs { get; set; }
        public virtual DbSet<PHE_DM_CHIPHI> PHE_DM_CHIPHIs { get; set; }
        public virtual DbSet<PHE_DM_TAISAN> PHE_DM_TAISANs { get; set; }
        public virtual DbSet<PHE_DM_LOAIHOPDONG> PHE_DM_LOAIHOPDONGs { get; set; }
        public virtual DbSet<PHE_DM_HIENTRANG_HOPDONG> PHE_DM_HIENTRANG_HOPDONGs { get; set; }
        public virtual DbSet<PHE_DM_DIABAN> PHE_DM_DIABANs { get; set; }
        public virtual DbSet<PHE_DM_CAPCONGTRINH> PHE_DM_CAPCONGTRINHs { get; set; }
        public virtual DbSet<PHE_DM_SYS_LIBRARY> PHE_DM_SYS_LIBRARYs { get; set; }
        public virtual DbSet<PHE_DM_DUAN_VANBAN> PHE_DM_DUAN_VANBANs { get; set; }
        public virtual DbSet<PHE_KEHOACH_VON_DAUTU> PHE_KEHOACH_VON_DAUTUs { get; set; }
        public virtual DbSet<PHE_CHITIET_KEHOACH_VON_DAUTU> PHE_CHITIET_KEHOACH_VON_DAUTUs { get; set; }
        public virtual DbSet<PHE_DM_CONGVIEC> PHE_DM_CONGVIECs { get; set; }
        public virtual DbSet<PHE_QUANLY_KL_THICONG> PHE_QUANLY_KL_THICONGs { get; set; }
        public virtual DbSet<PHE_CHITIET_QUANLY_KL_THICONG> PHE_CHITIET_QUANLY_KL_THICONGs { get; set; }
        public virtual DbSet<PHE_DM_DOITUONGVON> PHE_DM_DOITUONGVONs { get; set; }


        //---------------------------NV_PHE------------------------------------------------------------------//
        public virtual DbSet<PHE_VANBAN_HSPL> PHE_VANBAN_HSPLs { get; set; }
        public virtual DbSet<PHE_VANBAN_PHAPQUY> PHE_VANBAN_PHAPQUYs { get; set; }
        public virtual DbSet<PHE_DUTOAN> PHE_DUTOANs { get; set; }
        public virtual DbSet<PHE_DUTOAN_DS_DUAN> PHE_DUTOAN_DS_DUANs { get; set; }
        public virtual DbSet<PHE_QUANLY_VB_HS> PHE_QUANLY_VB_HSs { get; set; }
        public virtual DbSet<PHE_CHIPHI_DUAN_DUTOAN> PHE_CHIPHI_DUAN_DUTOANs { get; set; }
        public virtual DbSet<PHE_CHITIET_CHIPHI_DUAN_DUTOAN> PHE_CHITIET_CHIPHI_DUAN_DUTOANs { get; set; }
        public virtual DbSet<PHE_THONGTIN_DUAN> PHE_THONGTIN_DUANs { get; set; }
        //public virtual DbSet<PHE_CHITIET_THONGTIN_DUAN> PHE_CHITIET_THONGTIN_DUANs { get; set; }
        public virtual DbSet<PHE_KEHOACH_KETQUA> PHE_KETQUA_LUACHON_NHATHAUs { get; set; }
        public virtual DbSet<PHE_CHITIET_KEHOACH_KETQUA> PHE_CHITIET_THONGTIN_KEHOACH_DAUTHAUs { get; set; }
        public virtual DbSet<PHE_GIAO_KEHOACH_VON> PHE_GIAO_KEHOACH_VONs { get; set; }
        public virtual DbSet<PHE_CHITIET_GIAO_KEHOACH_VON> PHE_CHITIET_GIAO_KEHOACH_VONs { get; set; }

        public virtual DbSet<PHE_HOPDONG> PHE_HOPDONGs { get; set; }
        public virtual DbSet<PHE_CHITIET_HOPDONG> PHE_CHITIET_HOPDONGs { get; set; }

        public virtual DbSet<PHE_PHULUC_HOPDONG> PHE_PHULUC_HOPDONGs { get; set; }
        public virtual DbSet<PHE_PHULUC_HOPDONG_CHITIET> PHE_PHULUC_HOPDONG_CHITIETs { get; set; }

        public virtual DbSet<PHE_QUANLY_TAISAN> PHE_QUANLY_TAISANs { get; set; }
        public virtual DbSet<PHE_CHITIET_QUANLY_TAISAN> PHE_CHITIET_QUANLY_TAISANs { get; set; }
        public virtual DbSet<PHE_DUAN_CONGVIEC> PHE_DUAN_CONGVIECs { get; set; }
        public virtual DbSet<PHE_CANBOTHAMGIA_DUAN> PHE_CANBOTHAMGIA_DUANs { get; set; }
        public virtual DbSet<PHE_TT_DT_TMDT> PHE_TT_DT_TMDTs { get; set; }
        public virtual DbSet<PHE_CT_TT_DT_TMDT> PHE_CT_TT_DT_TMDTs { get; set; }
        public virtual DbSet<PHE_PHANCONG_CANBO> PHE_PHANCONG_CANBOs { get; set; }

        public virtual DbSet<PHE_TOTRINH> PHE_TOTRINHs { get; set; } 
        public virtual DbSet<PHE_TOTRINH_II> PHE_TOTRINH_IIs { get; set; } //  Phần công việc đã thực hiện vaf Phần công việc không áp dụng được một trong các hình thức lựa chọn nhà thầu
        public virtual DbSet<PHE_TOTRINH_IV> PHE_TOTRINH_IVs { get; set; }//  Phần công việc thuộc kế hoạch lựa chọn nhà thầu

        public virtual DbSet<PHE_THAMDINH> PHE_THAMDINHs { get; set; }
        public virtual DbSet<PHE_THAMDINH_CHITIET> PHE_THAMDINH_CHITIETs { get; set; }

        public virtual DbSet<PHE_KETQUA_DAUTHAU> PHE_KETQUA_DAUTHAUs { get; set; }
        public virtual DbSet<PHE_KETQUA_DAUTHAU_CHITIET> PHE_KETQUA_DAUTHAU_CHITIETs { get; set; }



        //---------------------------------------------------------------------------------------------------//
        // NvPHA
        public virtual DbSet<PHA_HACHTOAN_CHI> PHA_HACHTOAN_CHIs { get; set; }
        public virtual DbSet<PHA_HACHTOAN_THU> PHA_HACHTOAN_THUs { get; set; }
        public virtual DbSet<PHA_DUTOAN> PHA_DUTOANs { get; set; }
        public virtual DbSet<PHA_HACHTOAN_KHAC> PHA_HACHTOAN_KHACs { get; set; }
        public virtual DbSet<DM_BAOCAO_DETAIL> DM_BAOCAO_EXCELLs { get; set; }
        public virtual DbSet<PHA_BC_NS_CHITIET> PHA_BC_NS_CHITIETs { get; set; }
        public virtual DbSet<PHA_THDT_HCSN_DT> PHA_THDT_HCSN_DTs { get; set; }
        public virtual DbSet<PHA_BC_NS> PHA_BC_NSs { get; set; }
        public virtual DbSet<PHA_DASHBOARD> PHA_DASHBOARDs { get; set; }
        public virtual DbSet<DM_CHITIEU_BAOCAO_COL> DM_CHITIEU_BAOCAO_COLs { get; set; }
        public virtual DbSet<DM_CHITIEU_COT> DM_CHITIEU_COTS { get; set; }
        public virtual DbSet<DM_CHITIEU_COT_SOLIEU> DM_CHITIEU_COT_SOLIEUS { get; set; }
        public virtual DbSet<PHA_DUTOAN_THUCHI_NSNN> PHA_DUTOAN_THUCHI_NSNNs { get; set; }
        public virtual DbSet<PHA_DUTOAN_THUCHI_NSNN_DETAIL> PHA_DUTOAN_THUCHI_NSNN_DETAILs { get; set; }
        public virtual DbSet<PHA_QL_TT_VON> PHA_QL_TT_VONs { get; set; }
        public virtual DbSet<PHA_QL_TT_VON_CHITIET> PHA_QL_TT_VON_CHITIETs { get; set; }

        public virtual DbSet<PHA_DTXD01_1> PHA_DTXD01_1s { get; set; }
        public virtual DbSet<PHA_DTXD01_2> PHA_DTXD01_2s { get; set; }
        public virtual DbSet<PHA_DTXD01_3> PHA_DTXD01_3s { get; set; }
        public virtual DbSet<PHA_DTXD01_4> PHA_DTXD01_4s { get; set; }
        public virtual DbSet<PHA_DTXD01_5> PHA_DTXD01_5s { get; set; }
        public virtual DbSet<PHA_DTXD01_6> PHA_DTXD01_6s { get; set; }
        public virtual DbSet<PHA_DTXD01_7> PHA_DTXD01_7s { get; set; }
        public virtual DbSet<PHA_THANHTOAN_LUONG> PHA_THANHTOAN_LUONGs { get; set; }
        public virtual DbSet<PHA_THANHTOAN_LUONG_DETAIL> PHA_THANHTOAN_LUONG_DETAILs { get; set; }
        public virtual DbSet<PHA_DTXDBG04_1> PHA_DTXDBG04_1s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_2> PHA_DTXDBG04_2s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_3> PHA_DTXDBG04_3s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_4> PHA_DTXDBG04_4s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_5> PHA_DTXDBG04_5s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_6> PHA_DTXDBG04_6s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_7> PHA_DTXDBG04_7s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_8> PHA_DTXDBG04_8s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_9> PHA_DTXDBG04_9s { get; set; }
        public virtual DbSet<PHA_DTXDBG04_10> PHA_DTXDBG04_10s { get; set; }
        public virtual DbSet<DM_DONVI_CHUDAUTU> DM_DONVI_CHUDAUTUs { get; set; }

        //public virtual DbSet<DM_BAOCAO_EXCELL_PL08BM05> DM_BAOCAO_EXCELL_PL08BM05s { get; set; }

        //Dm phân hệ B
        public virtual DbSet<PHB_DM_BAOCAO> PHB_DM_BAOCAOs { get; set; }
        public virtual DbSet<PHB_DM_DUAN> PHB_DM_DUANs { get; set; }
        public virtual DbSet<PHB_DM_HOATDONG> PHB_DM_HOATDONGs { get; set; }
        public virtual DbSet<PHB_DM_TSCD> PHB_DM_TSCDs { get; set; }
        public virtual DbSet<PHB_DM_TAIKHOAN> PHB_DM_TAIKHOANs { get; set; }
        public virtual DbSet<PHB_DM_LOAINGANSACH> PHB_DM_LOAINGANSACHs { get; set; }
        public virtual DbSet<PHB_DM_NGUONNGANSACH> PHB_DM_NGUONNGANSACHs { get; set; }
        public virtual DbSet<PHB_DM_DVQHNS> PHB_DM_DVQHNSs { get; set; }
        public virtual DbSet<PHB_DM_LOAIKHOAN> PHB_DM_LOAIKHOANs { get; set; }
        public virtual DbSet<PHB_DM_LOAI_CAPPHAT> PHB_DM_LOAI_CAPPHATs { get; set; }

        public virtual DbSet<PHB_DM_NHOMMUCCHI> PHB_DM_NHOMMUCCHIs { get; set; }

        public virtual DbSet<PHB_DM_NOIDUNGKT> PHB_DM_NOIDUNGKTs { get; set; }
        //end phân hệ B
        //Danh mục TCS
        public virtual DbSet<TCS_DM_COQUANTHU> TCS_DM_COQUANTHUs { get; set; }
        public virtual DbSet<TCS_DM_DOITUONGNOPTHUE> TCS_DM_DOITUONGNOPTHUEs { get; set; }
        public virtual DbSet<TCS_DM_TYLEDIEUTIET> TCS_DM_TYLEDIEUTIETs { get; set; }
        //end DM TCS
        //Báo cáo PHB
        public virtual DbSet<Models.Bc.PHB.PHB_REPORT_FIELD> PHB_REPORT_FIELDs { get; set; }

        #region BIEU03

        public virtual DbSet<PHB_BIEU03> PHB_BIEU03s { get; set; }
        public virtual DbSet<PHB_BIEU03_TEMPLATE> PHB_BIEU03_TEMPLATEs { get; set; }
        public virtual DbSet<PHB_BIEU03_DETAIL> PHB_BIEU03_DETAILs { get; set; }
        #endregion

        #region PHB_C_B03A_X

        public virtual DbSet<PHB_C_B03A_X> PHB_C_B03A_Xs { get; set; }
        public virtual DbSet<PHB_C_B03A_X_DETAIL> PHB_C_B03A_X_DETAILs { get; set; }
        #endregion

        #region PHB_C_B03C_X

        public virtual DbSet<PHB_C_B03C_X> PHB_C_B03C_Xs { get; set; }
        public virtual DbSet<PHB_C_B03C_X_DETAIL> PHB_C_B03C_X_DETAILs { get; set; }
        #endregion

        #region BIEU01B
        public virtual DbSet<PHB_BIEU01B> PHB_BIEU01Bs { get; set; }
        public virtual DbSet<PHB_BIEU01B_DETAIL> PHB_BIEU01B_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU01B_TEMPLATE> PHB_BIEU01B_TEMPLATEs { get; set; }
        #endregion

        #region BIEU2A
        public virtual DbSet<PHB_BIEU2A> PHB_BIEU2As { get; set; }
        public virtual DbSet<PHB_BIEU2A_DETAIL> PHB_BIEU2A_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU2A_TEMPLATE> PHB_BIEU2A_TEMPLATEs { get; set; }
        #endregion

        #region BIEU2B
        public virtual DbSet<PHB_BIEU2B> PHB_BIEU2Bs { get; set; }
        public virtual DbSet<PHB_BIEU2B_DETAIL> PHB_BIEU2B_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU2B_TEMPLATE> PHB_BIEU2B_TEMPLATEs { get; set; }
        #endregion

        #region BIEU2CP1
        public virtual DbSet<PHB_BIEU2CP1> PHB_BIEU2CP1s { get; set; }
        public virtual DbSet<PHB_BIEU2CP1_DETAIL> PHB_BIEU2CP1_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU2CP1_TEMPLATE> PHB_BIEU2CP1_TEMPLATEs { get; set; }
        #endregion

        #region BIEU3A
        public virtual DbSet<PHB_BIEU3A> PHB_BIEU3As { get; set; }
        public virtual DbSet<PHB_BIEU3A_DETAIL> PHB_BIEU3A_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU3A_TEMPLATE> PHB_BIEU3A_TEMPLATEs { get; set; }

        #endregion

        #region BIEU3BP1
        public virtual DbSet<PHB_BIEU3BP1> PHB_BIEU3BP1s { get; set; }
        public virtual DbSet<PHB_BIEU3BP1_DETAIL> PHB_BIEU3BP1_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU3BP1_TEMPLATE> PHB_BIEU3BP1_TEMPLATEs { get; set; }
        #endregion

        #region BIEU3BP2
        public virtual DbSet<PHB_BIEU3BP2> PHB_BIEU3BP2s { get; set; }
        public virtual DbSet<PHB_BIEU3BP2_DETAIL> PHB_BIEU3BP2_DETAILs { get; set; }

        #endregion

        #region PHB_PL32_P2_TT01
        public virtual DbSet<PHB_PL32_P2_TT01> PHB_PL32_P2_TT01s { get; set; }
        public virtual DbSet<PHB_PL32_P2_TT01_DETAIL> PHB_PL32_P2_TT01_DETAILs { get; set; }

        #endregion

        #region BIEU4A
        public virtual DbSet<PHB_BIEU4A> PHB_BIEU4As { get; set; }
        public virtual DbSet<PHB_BIEU4A_DETAIL> PHB_BIEU4A_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU4A_TEMPLATE> PHB_BIEU4A_TEMPLATEs { get; set; }

        #endregion

        #region BIEU4BP1
        public virtual DbSet<PHB_BIEU4BP1> PHB_BIEU4BP1s { get; set; }
        public virtual DbSet<PHB_BIEU4BP1_DETAIL> PHB_BIEU4BP1_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU4BP1_TEMPLATE> PHB_BIEU4BP1_TEMPLATEs { get; set; }
        #endregion

        #region BIEU4BP2
        public virtual DbSet<PHB_BIEU4BP2> PHB_BIEU4BP2s { get; set; }
        public virtual DbSet<PHB_BIEU4BP2_DETAIL> PHB_BIEU4BP2_DETAILs { get; set; }
        #endregion

        #region BIEU01A
        public virtual DbSet<PHB_BIEU01A> PHB_BIEU01As { get; set; }
        public virtual DbSet<PHB_BIEU01A_DETAIL> PHB_BIEU01A_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU01A_TEMPLATE> PHB_BIEU01A_TEMPLATEs { get; set; }
        #endregion

        #region F01-01BCQT
        public virtual DbSet<PHB_F01_01BCQT> PHB_F01_01BCQTs { get; set; }
        public virtual DbSet<PHB_F01_01BCQT_DETAIL> PHB_F01_01BCQT_DETAILs { get; set; }

        #endregion

        #region B01H
        //public virtual DbSet<PHB_B01H> PHB_B01Hs { get; set; }
        //public virtual DbSet<PHB_B01H_DETAIL> PHB_B01H_DETAILs { get; set; }
        //public virtual DbSet<PHB_B01H_TEMPLATE> PHB_B01H_TEMPLATEs { get; set; }
        #endregion

        #region B02/CT-H Phần I
        //public virtual DbSet<PHB_B02CTHP1> PHB_B02CTHP1s { get; set; }
        //public virtual DbSet<PHB_B02CTHP1_DETAIL> PHB_B02CTHP1_DETAILs { get; set; }
        //public virtual DbSet<PHB_B02CTHP1_TEMPLATE> PHB_B02CTHP1_TEMPLATEs { get; set; }
        #endregion

        #region B02H-P1
        //public virtual DbSet<PHB_B02HP1> PHB_B02HP1s { get; set; }
        //public virtual DbSet<PHB_B02HP1_DETAIL> PHB_B02HP1_DETAILs { get; set; }
        //public virtual DbSet<PHB_B02HP1_TEMPLATE> PHB_B02HP1_TEMPLATEs { get; set; }
        #endregion

        #region B03H
        //public virtual DbSet<Models.Bc.PHB.B03H.PHB_B03H> PHB_B03Hs { get; set; }
        //public virtual DbSet<Models.Bc.PHB.B03H.PHB_B03H_DETAIL> PHB_B03H_DETAILs { get; set; }
        //public virtual DbSet<Models.Bc.PHB.B03H.PHB_B03H_TEMPLATE> PHB_B03H_TEMPLATEs { get; set; }
        #endregion

        #region B03CTH
        //public virtual DbSet<Models.Bc.PHB.B03CTH.PHB_B03CTH> PHB_B03CTHs { get; set; }
        //public virtual DbSet<Models.Bc.PHB.B03CTH.PHB_B03CTH_DETAIL> PHB_B03CTH_DETAILs { get; set; }
        //public virtual DbSet<Models.Bc.PHB.B03CTH.PHB_B03CTH_TEMPLATE> PHB_B03CTH_TEMPLATEs { get; set; }
        #endregion

        #region B04H
        //public virtual DbSet<Models.Bc.PHB.B04H.PHB_B04H> PHB_B04Hs { get; set; }
        //public virtual DbSet<Models.Bc.PHB.B04H.PHB_B04H_DETAIL> PHB_B04H_DETAILs { get; set; }
        // public virtual DbSet<Models.Bc.PHB.B04H.PHB_B04H_TEMPLATE> PHB_B04H_TEMPLATEs { get; set; }
        #endregion

        #region B06H
        //public virtual DbSet<PHB_B06H> PHB_B06Hs { get; set; }
        //public virtual DbSet<PHB_B06H_DETAIL> PHB_B06H_DETAILs { get; set; }
        //public virtual DbSet<PHB_B06H_TEMPLATE> PHB_B06H_TEMPLATEs { get; set; }
        #endregion

        #region F022HP1
        //public virtual DbSet<PHB_F022HP1> PHB_F022HP1s { get; set; }
        //public virtual DbSet<PHB_F022HP1_DETAIL> PHB_F022HP1_DETAILs { get; set; }
        //public virtual DbSet<PHB_F022HP1_TEMPLATE> PHB_F022HP1_TEMPLATEs { get; set; }
        #endregion

        #region B01BCQT

        public virtual DbSet<PHB_B01BCQT> PHB_B01BCQTs { get; set; }
        public virtual DbSet<PHB_B01BCQT_DETAIL> PHB_B01BCQT_DETAILs { get; set; }
        public virtual DbSet<PHB_B01BCQT_TEMPLATE> PHB_B01BCQT_TEMPLATEs { get; set; }
        #endregion

        #region B02BCTC

        public virtual DbSet<PHB_B02BCTC> PHB_B02BCTCs { get; set; }
        public virtual DbSet<PHB_B02BCTC_DETAIL> PHB_B02BCTC_DETAILs { get; set; }
        public virtual DbSet<PHB_B02BCTC_TEMPLATE> PHB_B02BCTC_TEMPLATEs { get; set; }
        #endregion

        #region B02BCQT

        public virtual DbSet<PHB_B02BCQT> PHB_B02BCQTs { get; set; }
        public virtual DbSet<PHB_B02BCQT_DETAIL> PHB_B02BCQT_DETAILs { get; set; }
        public virtual DbSet<PHB_B02BCQT_TEMPLATE> PHB_B02BCQT_TEMPLATEs { get; set; }
        #endregion

        #region BIEU09TT344
        public virtual DbSet<PHB_BIEU09TT344> PHB_BIEU09TT344s { get; set; }
        public virtual DbSet<PHB_BIEU09TT344_DETAIL> PHB_BIEU09TT344_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU09TT344_TEMPLATE> PHB_BIEU09TT344_TEMPLATEs { get; set; }
        #endregion

        #region BIEU10TT344
        public virtual DbSet<PHB_BIEU10TT344> PHB_BIEU10TT344s { get; set; }
        public virtual DbSet<PHB_BIEU10TT344_DETAIL> PHB_BIEU10TT344_DETAILs { get; set; }
        #endregion

        #region BIEU07TT344
        public virtual DbSet<PHB_BIEU07TT344> PHB_BIEU07TT344s { get; set; }
        public virtual DbSet<PHB_BIEU07TT344_DETAIL> PHB_BIEU07TT344_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU07TT344_TEMPLATE> PHB_BIEU07TT344_TEMPLATEs { get; set; }
        #endregion



        #region BIEU01C

        public virtual DbSet<PHB_BIEU01C> PHB_BIEU01Cs { get; set; }
        public virtual DbSet<PHB_BIEU01C_DETAIL> PHB_BIEU01C_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU01C_TEMPLATE> PHB_BIEU01C_TEMPLATEs { get; set; }
        #endregion

        #region BIEU01CP2

        public virtual DbSet<PHB_BIEU01CP2> PHB_BIEU01CP2s { get; set; }
        public virtual DbSet<PHB_BIEU01CP2_DETAIL> PHB_BIEU01CP2_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU01CP2_TEMPLATE> PHB_BIEU01CP2_TEMPLATEs { get; set; }
        #endregion

        #region B02H_II

        public virtual DbSet<PHB_B02H_II> PHB_B02H_IIs { get; set; }
        public virtual DbSet<PHB_B02H_II_DETAIL> PHB_B02H_II_DETAILs { get; set; }
        public virtual DbSet<PHB_B02H_II_TEMPLATE> PHB_B02H_II_TEMPLATEs { get; set; }
        #endregion

        #region F01-02BCQT-PII
        public virtual DbSet<PHB_F01_02BCQT_PII> PHB_F01_02BCQT_PIIs { get; set; }
        public virtual DbSet<PHB_F01_02BCQT_PII_DETAIL> PHB_F01_02BCQT_PII_DETAILs { get; set; }

        #endregion

        #region PHB_BIEU08TT344
        public virtual DbSet<PHB_BIEU08TT344> PHB_BIEU08TT344s { get; set; }
        public virtual DbSet<PHB_BIEU08TT344_DETAIL> PHB_BIEU08TT344_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU08TT344_TEMPLATE> PHB_BIEU08TT344_TEMPLATEs { get; set; }

        #endregion

        #region F01_02BCQT

        public virtual DbSet<PHB_F01_02BCQT> PHB_F01_02BCQTs { get; set; }
        public virtual DbSet<PHB_F01_02BCQT_DETAIL> PHB_F01_02BCQT_DETAILs { get; set; }
        public virtual DbSet<PHB_F01_02BCQT_TEMPLATE> PHB_F01_02BCQT_TEMPLATEs { get; set; }
        #endregion



        #region BIEU2CP2

        public virtual DbSet<PHB_BIEU2CP2> PHB_BIEU2CP2s { get; set; }
        public virtual DbSet<PHB_BIEU2CP2_DETAIL> PHB_BIEU2CP2_DETAILs { get; set; }
        #endregion

        #region BIEU12TT342
        public virtual DbSet<PHB_BIEU12TT344> PHB_BIEU12TT344s { get; set; }
        public virtual DbSet<PHB_BIEU12TT344_DETAIL> PHB_BIEU12TT344_DETAILs { get; set; }

        #endregion

        #region BIEU11TT342
        public virtual DbSet<PHB_BIEU11TT344> PHB_BIEU11TT344s { get; set; }
        public virtual DbSet<PHB_BIEU11TT344_DETAIL> PHB_BIEU11TT344_DETAILs { get; set; }

        #endregion

        #region 70NS-TT342
        public virtual DbSet<PHB_BIEU70NS> PHB_70NSs { get; set; }
        public virtual DbSet<PHB_BIEU70NS_DETAIL> PHB_70NS_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU70NS_TEMPLATE> PHB_70NS_TEMPLATEs { get; set; }
        #endregion

        #region 69NS-TT342
        public virtual DbSet<PHB_BIEU69NS> PHB_BIEU69NSs { get; set; }
        public virtual DbSet<PHB_BIEU69NS_DETAIL> PHB_BIEU69NS_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU69NS_TEMPLATE> PHB_BIEU69NS_TEMPLATEs { get; set; }

        #endregion

        #region 68NS-TT342
        public virtual DbSet<PHB_BIEU68NS> PHB_BIEU68NSs { get; set; }
        public virtual DbSet<PHB_BIEU68NS_DETAIL> PHB_BIEU68NS_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU68NS_TEMPLATE> PHB_BIEU68NS_TEMPLATEs { get; set; }

        #endregion

        #region 67NS-TT342
        public virtual DbSet<PHB_BIEU67NS> PHB_BIEU67NSs { get; set; }
        public virtual DbSet<PHB_BIEU67NS_DETAIL> PHB_BIEU67NS_DETAILs { get; set; }
        public virtual DbSet<PHB_BIEU67NS_TEMPLATE> PHB_BIEU67NS_TEMPLATEs { get; set; }

        #endregion

        #region ĐỐI CHIẾU SỐ LIỆU
        public virtual DbSet<PHB_DOICHIEUSOLIEU> PHB_DOICHIEUSOLIEUs { get; set; }
        #endregion

        #region B03BCQT_BII1
        public virtual DbSet<PHB_B03BCQT_BII1> PHB_B03BCQT_BII1s { get; set; }
        public virtual DbSet<PHB_B03BCQT_BII1_DETAIL> PHB_B03BCQT_BII1_DETAILs { get; set; }
        public virtual DbSet<PHB_B03BCQT_BII1_TEMPLATE> PHB_B03BCQT_BII1_TEMPLATEs { get; set; }
        #endregion

        #region PL3.1
        public virtual DbSet<PHB_PL31> PHB_PL31s { get; set; }
        public virtual DbSet<PHB_PL31_DETAIL> PHB_PL31_DETAILs { get; set; }
        public virtual DbSet<PHB_PL31_TEMPLATE> PHB_PL31_TEMPLATEs { get; set; }

        #endregion

        #region PL41
        public virtual DbSet<PHB_PL41> PHB_PL41s { get; set; }
        public virtual DbSet<PHB_PL41_DETAIL> PHB_PL41_DETAILs { get; set; }
        public virtual DbSet<PHB_PL41_TEMPLATE> PHB_PL41_TEMPLATEs { get; set; }
        #endregion

        #region PL32_P1

        public virtual DbSet<PHB_PL32_P1_TT01> PHB_PL32_P1_TT01s { get; set; }
        public virtual DbSet<PHB_PL32_P1_TT01_DETAIL> PHB_PL32_P1_TT01_DETAILs { get; set; }

        #endregion

        #region PL42_P1

        public virtual DbSet<PHB_PL42_P1_TT01> PHB_PL42_P1_TT01s { get; set; }
        public virtual DbSet<PHB_PL42_P1_TT01_DETAIL> PHB_PL42_P1_TT01_DETAILs { get; set; }

        #endregion
        //End báo cáo PHB
        //PHB_C


        #region PHB_C_B01X
        public virtual DbSet<PHB_C_B01X> PHB_C_B01Xs { get; set; }
        public virtual DbSet<PHB_C_B01X_DETAIL> PHB_C_B01X_DETAILs { get; set; }
        public virtual DbSet<PHB_C_B01X_TEMPLATE> PHB_C_B01X_TEMPLATEs { get; set; }

        #endregion
        #region B02a-X

        public virtual DbSet<PHB_C_B02AX> PHB_C_B02aXs { get; set; }
        public virtual DbSet<PHB_C_B02AX_DETAIL> PHB_C_B02aX_DETAILs { get; set; }
        #endregion

        #region B02B_X
        public virtual DbSet<PHB_C_B02B_X> PHB_C_B02b_X { get; set; }
        public virtual DbSet<PHB_C_B02B_X_DETAIL> PHB_C_B02b_X_DETAIL { get; set; }
        #endregion

        #region PHB_C_B03B_X
        public virtual DbSet<PHB_C_B03B_X> PHB_C_B03B_Xs { get; set; }
        public virtual DbSet<PHB_C_B03B_X_DETAIL> PHB_C_B03B_X_DETAILs { get; set; }
        #endregion

        #region PHB_C_B03X
        public virtual DbSet<PHB_C_B03X> PHB_C_B03Xs { get; set; }
        public virtual DbSet<PHB_C_B03X_DETAIL> PHB_C_B03X_DETAILs { get; set; }
        #endregion

        #region PHB_C_B03D_X
        public virtual DbSet<PHB_C_B03D_X> PHB_C_B03D_Xs { get; set; }
        public virtual DbSet<PHB_C_B03D_X_DETAIL> PHB_C_B03D_X_DETAILs { get; set; }
        public virtual DbSet<PHB_C_B03D_X_TEMPLATE> PHB_C_B03D_X_TEMPLATEs { get; set; }

        #endregion

        #region PHB_C_B04X
        public virtual DbSet<PHB_C_B04X> PHB_C_B04Xs { get; set; }
        public virtual DbSet<PHB_C_B04X_DETAIL> PHB_C_B04X_DETAILs { get; set; }

        #endregion

        #region PHB_C_B06X
        public virtual DbSet<PHB_C_B06X> PHB_C_B06Xs { get; set; }
        public virtual DbSet<PHB_C_B06X_DETAIL> PHB_C_B06X_DETAILs { get; set; }
        public virtual DbSet<PHB_C_B06X_TEMPLATE> PHB_C_B06X_TEMPLATEs { get; set; }

        #endregion



        //NvPHC
        public virtual DbSet<PHC_NHAPSODUHEADER> PHC_NHAPSODUHEADERs { get; set; }
        public virtual DbSet<PHC_NHAPSODUDETAILS> PHC_NHAPSODUDETAILSs { get; set; }
        public virtual DbSet<PHC_BIENLAITHUHEADER> PHC_BIENLAITHUHEADERs { get; set; }
        public virtual DbSet<PHC_BIENLAITHUDETAILS> PHC_BIENLAITHUDETAILSs { get; set; }
        public virtual DbSet<PHC_NHAPCHUNGTU> PHC_NHAPCHUNGTUs { get; set; }
        public virtual DbSet<PHC_DOICHIEUSOLIEUHEADER> PHC_DOICHIEUSOLIEUHEADERs { get; set; }
        public virtual DbSet<PHC_DOICHIEUSOLIEUDETAILS> PHC_DOICHIEUSOLIEUDETAILSs { get; set; }

        public virtual DbSet<PHC_CHUNGTUHEADER> PHC_CHUNGTUHEADERs { get; set; }
        public virtual DbSet<PHC_CHUNGTUDETAILS> PHC_CHUNGTUDETAILSs { get; set; }
        public virtual DbSet<PHC_DIEUCHINHKINHPHIHEADER> PHC_DIEUCHINHKINHPHIHEADERs { get; set; }
        public virtual DbSet<PHC_DIEUCHINHKINHPHIDETAILS> PHC_DIEUCHINHKINHPHIDETAILSs { get; set; }


        public virtual DbSet<PHC_DT_THUCHI_NDKT> PHC_DT_THUCHI_NDKTs { get; set; }

        public virtual DbSet<PHC_DT_THUCHI_NDKT_CHITIET> PHC_DT_THUCHI_NDKT_CHITIETs { get; set; }

        public virtual DbSet<PHC_DT_THU_MLNS> PHC_DT_THU_MLNSs { get; set; }

        public virtual DbSet<PHC_DT_THU_MLNS_CHITIET> PHC_DT_THU_MLNS_CHITIETs { get; set; }
        public virtual DbSet<PHC_DT_CHI_MLNS> PHC_DT_CHI_MLNSs { get; set; }

        public virtual DbSet<PHC_DT_CHI_MLNS_CHITIET> PHC_DT_CHI_MLNS_CHITIETs { get; set; }


        public virtual DbSet<PHC_THUYETMINHTAICHINHHEADER> PHC_THUYETMINHTAICHINHHEADERs { get; set; }
        public virtual DbSet<PHC_THUYETMINHTAICHINHDETAILS> PHC_THUYETMINHTAICHINHDETAILSs { get; set; }
        public virtual DbSet<PHC_TMTCTEMPLATE> PHC_TMTCTEMPLATEs { get; set; }
        public virtual DbSet<PHC_PHIEUTHU_IN> PHC_PHIEUTHU_INs { get; set; }
        public virtual DbSet<PHC_PHIEUCHI_IN> PHC_PHIEUCHI_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_RVDT_IN> PHC_PHIEU_RVDT_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_GRDT_IN> PHC_PHIEU_GRDT_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_GDNTT_IN> PHC_PHIEU_GDNTT_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_CTTT_IN> PHC_PHIEU_CTTT_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_UNC_IN> PHC_PHIEU_UNC_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_UNT_IN> PHC_PHIEU_UNT_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_GRT_IN> PHC_PHIEU_GRT_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_NTVTK_IN> PHC_PHIEU_NTVTK_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_BANGKENOPTHUE> PHC_PHIEU_BANGKENOPTHUEs { get; set; }
        public virtual DbSet<PHC_PHIEU_NHAPXUAT_KHO_IN> PHC_PHIEU_NHAPXUAT_KHO_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_NOPTIEN_VAONSNN_IN> PHC_PHIEU_NOPTIEN_VAONSNN_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_GG_CCDC_IN> PHC_PHIEU_GG_CCDC_INs { get; set; }
        public virtual DbSet<PHC_PHIEU_GT_CCDC_IN> PHC_PHIEU_GT_CCDC_INs { get; set; }


        #region Báo cáo THANH TOÁN CÁC KHOẢN NỢ PHẢI THU VỚI CÁC HỘ (S16_X) - Phạm Tuấn Anh
        public virtual DbSet<S16_X_HEADER> S16_X_HEADERs { get; set; }
        public virtual DbSet<S16_X_DETAIL> S16_X_DETAILs { get; set; }
        #endregion

        #region Báo cáo THEO DÕI SỔ LĨNH, THANH TOÁN BIÊN LAI VÀ TIỀN ĐÃ THU (S17_X) - Phạm Tuấn Anh
        public virtual DbSet<S17_X_HEADER> S17_X_HEADERs { get; set; }
        public virtual DbSet<S17_X_DETAIL> S17_X_DETAILs { get; set; }
        #endregion

        #region Báo cáo Quyết toán đầu tư xây dựng cơ bản (QTXDCB) - Phạm Tuấn Anh
        public virtual DbSet<QTXDCB_HEADER> QTXDCB_HEADERs { get; set; }
        public virtual DbSet<QTXDCB_DETAIL> QTXDCB_DETAILs { get; set; }
        #endregion



        #region PHF - Thanh tra
        #region DM
        public virtual DbSet<PHF_DM_CANBO> PHF_DM_CANBOs { get; set; }
        public virtual DbSet<PHF_DM_DOITUONG> PHF_DM_DOITUONGs { get; set; }
        public virtual DbSet<PHF_DM_DOTTHANHTRA> PHF_DM_DOTTHANHTRAs { get; set; }
        public virtual DbSet<PHF_DM_DONVI_PHONGBAN> PHF_DM_DONVI_PHONGBANs { get; set; }
        public virtual DbSet<PHF_DM_TAOMA> PHF_DM_TAOMAs { get; set; }

        //public virtual DbSet<PHF_DM_CHUCNANG> PHF_DM_CHUCNANGs { get; set; }
        //public virtual DbSet<PHF_DM_PHONGBAN> PHF_DM_PHONGBANs { get; set; }
        //public virtual DbSet<PHF_DM_CHUCVU> PHF_DM_CHUCVUs { get; set; }
        //public virtual DbSet<PHF_DM_COQUAN> PHF_DM_COQUANs { get; set; }
        //public virtual DbSet<PHF_DM_DIABAN> PHF_DM_DIABANs { get; set; }
        //public virtual DbSet<PHF_DM_LOAITHANHTRA> PHF_DM_LOAITHANHTRAs { get; set; }
        //public virtual DbSet<PHF_DM_NHOMTHANHTRA> PHF_DM_NHOMTHANHTRAs { get; set; }
        //public virtual DbSet<PHF_DM_BAOCAO> PHF_DM_BAOCAOs { get; set; }
        //public virtual DbSet<PHF_DM_KEHOACHTHANHTRA> PHF_DM_KEHOACHTHANHTRAs { get; set; }
        //public virtual DbSet<PHF_DM_TEST> PHF_DM_TESTs { get; set; }
        #endregion
        #region NV
        public virtual DbSet<PHF_TTB_NHATKY> PHF_TTB_NHATKYs { get; set; }
        public virtual DbSet<PHF_XD_KH_THANHTRA_BO> PHF_XD_KH_THANHTRA_BOs { get; set; }
        public virtual DbSet<PHF_XD_KH_THANHTRA_BO_CHITIET> PHF_XD_KH_THANHTRA_BO_CHITIETs { get; set; }
        public virtual DbSet<PHF_TIENDO_THUCHIEN_KH> PHF_TIENDO_THUCHIEN_KHs { get; set; }
        public virtual DbSet<PHF_TIENDO_THUCHIEN_KH_CT> PHF_TIENDO_THUCHIEN_KH_CTs { get; set; }
        public virtual DbSet<PHF_XD_KH_TT_THUOC_BO> PHF_XD_KH_TT_THUOC_BOs { get; set; }
        public virtual DbSet<PHF_XD_KH_TT_THUOC_BO_CT> PHF_XD_KH_TT_THUOC_BO_CTs { get; set; }
        public virtual DbSet<PHF_SOANTHAO_THANHTRA> PHF_SOANTHAO_THANHTRAs { get; set; }
        public virtual DbSet<PHF_SOANTHAO_THANHTRA_CT> PHF_SOANTHAO_THANHTRA_CTs { get; set; }
        public virtual DbSet<PHF_THEODOI_CANBO> PHF_THEODOI_CANBOs { get; set; }
        public virtual DbSet<PHF_THEODOI_CANBO_CT> PHF_THEODOI_CANBO_CTs { get; set; }
        // TỔNG HỢP FILE NSĐP
        public virtual DbSet<PHF_BM_FILE_NSDP> PHF_BM_FILE_NSDPs { get; set; }
        //BIỂU 01 - NSDP
        public virtual DbSet<PHF_BM_01TT_NSDP> PHF_BM_01TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_02TT_NSDP> PHF_BM_02TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_03TT_NSDP> PHF_BM_03TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_05TT_NSDP> PHF_BM_05TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_10TT_NSDP> PHF_BM_10TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_11TT_NSDP> PHF_BM_11TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_12TT_NSDP> PHF_BM_12TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_14TT_NSDP> PHF_BM_14TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_15TT_NSDP> PHF_BM_15TT_NSDPs { get; set; }
        public virtual DbSet<PHF_BM_16TT_NSDP> PHF_BM_16TT_NSDPs { get; set; }

        public virtual DbSet<PHF_THUMUC_FILE> PHF_THUMUC_FILEs { get; set; }
        public virtual DbSet<PHF_QD_PHEDUYET_THANHTRA> PHF_QD_PHEDUYET_THANHTRAs { get; set; }
        public virtual DbSet<PHF_QD_GIAOTHUCHIEN_THANHTRA> PHF_QD_GIAOTHUCHIEN_THANHTRAs { get; set; }
        public virtual DbSet<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO> PHF_QD_GIAOTHUCHIEN_TT_THUOCBOs { get; set; }

        public virtual DbSet<PHF_KH_THANHTRA_COQUAN> PHF_KH_THANHTRA_COQUANs { get; set; }
        public virtual DbSet<PHF_KH_THANHTRA_COQUAN_CT> PHF_KH_THANHTRA_COQUAN_CTs { get; set; }

        //public virtual DbSet<PHF_TTB_NHATKY_Ver> PHF_TTB_NHATKY_Vers { get; set; }
        //public virtual DbSet<PHF_KEHOACH_THANHTRA_D> PHF_KEHOACH_THANHTRA_Ds { get; set; }
        //public virtual DbSet<PHF_KEHOACH_THANHTRA_H> PHF_KEHOACH_THANHTRA_Hs { get; set; }

        #region Nắm bắt tình hình đối tượng thanh tra - Tiêu chí đánh giá rủi ro
        public virtual DbSet<PHF_TIEUCHI_DGRR> PHF_TIEUCHI_DGRRs { get; set; }
        public virtual DbSet<PHF_TIEUCHI_DGRR_DETAIL> PHF_TIEUCHI_DGRR_DETAILs { get; set; }
        #endregion


        #region TỔNG HỢP FILE TCXD
        public virtual DbSet<PHF_BM_FILE_TCXD> PHF_BM_FILE_TCXDs { get; set; }

        public virtual DbSet<PHF_BM_01TT_TCXD> PHF_BM_01TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_02TT_TCXD> PHF_BM_02TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_03TT_TCXD> PHF_BM_03TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_04TT_TCXD> PHF_BM_04TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_05TT_TCXD> PHF_BM_05TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_06TT_TCXD> PHF_BM_06TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_07TT_TCXD> PHF_BM_07TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_08TT_TCXD> PHF_BM_08TT_TCXDs { get; set; }
        public virtual DbSet<PHF_BM_10TT_TCXD> PHF_BM_10TT_TCXDs { get; set; }
        #endregion

        #region TỔNG HỢP FILE DVSN
        public virtual DbSet<PHF_BM_FILE_DVSN> PHF_BM_FILE_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_01TT_DVSN> PHF_BM_01TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_02TT_DVSN> PHF_BM_02TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_03TT_DVSN> PHF_BM_03TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_04TT_DVSN> PHF_BM_04TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_05TT_DVSN> PHF_BM_05TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_06TT_DVSN> PHF_BM_06TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_07TT_DVSN> PHF_BM_07TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_08TT_DVSN> PHF_BM_08TT_DVSNs { get; set; }
        public virtual DbSet<PHF_BM_09TT_DVSN> PHF_BM_09TT_DVSNs { get; set; }
        #endregion

        #endregion

        #region TỔNG HỢP FILE NSDCN
        public virtual DbSet<PHF_BM_FILE_NSDVN> PHF_BM_FILE_NSDVNs { get; set; }
        public virtual DbSet<PHF_BM_60TT_NSDVN> PHF_BM_60TT_NSDVNs { get; set; }
        #endregion

        #region SYS
        public virtual DbSet<PHF_SYS_TUDIEN> PHF_SYS_TUDIENs { get; set; }
        #endregion

        #region TỔNG HỢP FILE CQHC
        public virtual DbSet<PHF_BM_FILE_CQHC> PHF_BM_FILE_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_01TT_CQHC> PHF_BM_01TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_02TT_CQHC> PHF_BM_02TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_03TT_CQHC> PHF_BM_03TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_04TT_CQHC> PHF_BM_04TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_05TT_CQHC> PHF_BM_05TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_06TT_CQHC> PHF_BM_06TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_07TT_CQHC> PHF_BM_07TT_CQHCs { get; set; }
        public virtual DbSet<PHF_BM_08TT_CQHC> PHF_BM_08TT_CQHCs { get; set; }

        #endregion

        #region TỔNG HỢP FILE TCDN
        public virtual DbSet<PHF_BM_FILE_TCDN> PHF_BM_FILE_TCDNs { get; set; }
        #endregion

        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BTSTC");
            base.OnModelCreating(modelBuilder);
        }
    }
}
