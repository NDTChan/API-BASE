using System.Data.Entity;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Sys;
using Repository.Pattern.Ef6;
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.ENTITY.Nv;

namespace BTS.SP.PHF.ENTITY
{
    public class PHFContext : DataContext
    {
        public PHFContext() : base("name=STCConnection")
        {
        }

        #region AUTH
        public virtual DbSet<AU_NGUOIDUNG> AU_NGUOIDUNGs { get; set; }
        public virtual DbSet<AU_NHOMQUYEN> AU_NHOMQUYENs { get; set; }
        public virtual DbSet<AU_NHOMQUYEN_CHUCNANG> AU_NHOMQUYEN_CHUCNANGs { get; set; }
        public virtual DbSet<AU_NGUOIDUNG_NHOMQUYEN> AU_NGUOIDUNG_NHOMQUYENs { get; set; }
        public virtual DbSet<AU_NGUOIDUNG_QUYEN> AU_NGUOIDUNG_QUYENs { get; set; }
        #endregion
        #region SYS
        public virtual DbSet<SYS_DVQHNS> SYS_DVQHNSs { get; set; }
        public virtual DbSet<SYS_CHUCNANG> SYS_CHUCNANGs { get; set; }
        public virtual DbSet<PHF_SYS_TUDIEN> PHF_SYS_TUDIENs { get; set; }

        public virtual DbSet<PHF_DM_TAOMA> PHF_DM_TAOMAs { get; set; }

        #endregion

        #region DM
        public virtual DbSet<PHF_DM_CANBO> PHF_DM_CANBOs { get; set; }
        public virtual DbSet<PHF_DM_DOTTHANHTRA> PHF_DM_DOTTHANHTRAs { get; set; }
        public virtual DbSet<PHF_DM_DOITUONG> PHF_DM_DOITUONGs { get; set; }
        public virtual DbSet<PHF_DM_DONVI_PHONGBAN> PHF_DM_DONVI_PHONGBANs { get; set; }
        public virtual DbSet<PHF_THUMUC_FILE> PHF_THUMUC_FILEs { get; set; }
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
        public virtual DbSet<PHF_QD_PHEDUYET_THANHTRA> PHF_QD_PHEDUYET_THANHTRAs { get; set; }
        public virtual DbSet<PHF_QD_GIAOTHUCHIEN_THANHTRA> PHF_QD_GIAOTHUCHIEN_THANHTRAs { get; set; }
        public virtual DbSet<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO> PHF_QD_GIAOTHUCHIEN_TT_THUOCBOs { get; set; }

        public virtual DbSet<PHF_KH_THANHTRA_COQUAN> PHF_KH_THANHTRA_COQUANs { get; set; }
        public virtual DbSet<PHF_KH_THANHTRA_COQUAN_CT> PHF_KH_THANHTRA_COQUAN_CTs { get; set; }

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

        #region TỔNG HỢP FILE NSDVN
        public virtual DbSet<PHF_BM_FILE_NSDVN> PHF_BM_FILE_NSDVNs { get; set; }
        public virtual DbSet<PHF_BM_60TT_NSDVN> PHF_BM_60TT_NSDVNs { get; set; }
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BTSTC");
            base.OnModelCreating(modelBuilder);
        }
    }
}
