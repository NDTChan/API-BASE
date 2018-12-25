using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("TDL_SOLIEU")]
    public class TDL_SOLIEU : DataInfoEntity
    {
        [Column("SHKB")]
        [StringLength(20)]
        public string SHKB { get; set; }

        [Column("SHKB_NV")]
        [StringLength(20)]
        public string SHKB_NV { get; set; }

        [Column("NIEN_DO_KH")]
        public Nullable<decimal> NIEN_DO_KH { get; set; }

        [Column("NAM_KH")]
        public Nullable<decimal> NAM_KH { get; set; }

        [Column("SO_HIEU_KY")]
        public Nullable<decimal> SO_HIEU_KY { get; set; }

        [Column("MA_DA")]
        [StringLength(50)]
        public string MA_DA { get; set; }

        [Column("TEN_DU_AN")]
        [StringLength(500)]
        public string TEN_DU_AN { get; set; }

        [Column("MA_NHOM_DA")]
        [StringLength(3)]
        public string MA_NHOM_DA { get; set; }

        [Column("TEN_NHOM_DA")]
        [StringLength(200)]
        public string TEN_NHOM_DA { get; set; }

        [Column("MA_DA_DP")]
        [StringLength(9)]
        public string MA_DA_DP { get; set; }

        [Column("TEN_DA_DP")]
        [StringLength(200)]
        public string TEN_DA_DP { get; set; }

        [Column("MA_DON_VI")]
        [StringLength(6)]
        public string MA_DON_VI { get; set; }

        [Column("TEN_DON_VI")]
        [StringLength(300)]
        public string TEN_DON_VI { get; set; }

        [Column("MA_LOAI_KHV")]
        [StringLength(1)]
        public string MA_LOAI_KHV { get; set; }

        [Column("TEN_LOAI_KHV")]
        [StringLength(300)]
        public string TEN_LOAI_KHV { get; set; }

        [Column("MA_NHOM_NV")]
        [StringLength(20)]
        public string MA_NHOM_NV { get; set; }

        [Column("MA_NVON")]
        [StringLength(8)]
        public string MA_NVON { get; set; }

        [Column("TEN_NVON")]
        [StringLength(500)]
        public string TEN_NVON { get; set; }

        [Column("MA_LV_DA")]
        [StringLength(20)]
        public string MA_LV_DA { get; set; }

        [Column("TEN_LV_DA")]
        [StringLength(500)]
        public string TEN_LV_DA { get; set; }

        [Column("MA_LOAI_VON")]
        [StringLength(20)]
        public string MA_LOAI_VON { get; set; }

        [Column("TEN_LOAI_VON")]
        [StringLength(500)]
        public string TEN_LOAI_VON { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(20)]
        public string MA_CHUONG { get; set; }

        [Column("TEN_CHUONG")]
        [StringLength(500)]
        public string TEN_CHUONG { get; set; }

        [Column("CAP_QLY")]
        [StringLength(20)]
        public string CAP_QLY { get; set; }

        [Column("MA_NKT")]
        [StringLength(20)]
        public string MA_NKT { get; set; }

        [Column("TEN_NKT")]
        [StringLength(500)]
        public string TEN_NKT { get; set; }

        [Column("MA_CTMT")]
        [StringLength(20)]
        public string MA_CTMT { get; set; }

        [Column("TEN_CTMT")]
        [StringLength(500)]
        public string TEN_CTMT { get; set; }

        [Column("CHI")]
        [StringLength(20)]
        public string CHI { get; set; }

        [Column("KEO_DAI")]
        [StringLength(20)]
        public string KEO_DAI { get; set; }

        [Column("KHV")]
        public Nullable<decimal> KHV { get; set; }

        [Column("CDT_DN_TTOAN")]
        public Nullable<decimal> CDT_DN_TTOAN { get; set; }

        [Column("TAM_UNG")]
        public Nullable<decimal> TAM_UNG { get; set; }

        [Column("TTKLHT")]
        public Nullable<decimal> TTKLHT { get; set; }

        [Column("DU_TAM_UNG")]
        public Nullable<decimal> DU_TAM_UNG { get; set; }

        [Column("THU_HOI_TAM_UNG")]
        public Nullable<decimal> THU_HOI_TAM_UNG { get; set; }

        [Column("KH_UNG_TRUOC")]
        public Nullable<decimal> KH_UNG_TRUOC { get; set; }

        [Column("MDB_TINH")]
        [StringLength(50)]
        public string MDB_TINH { get; set; }

        [Column("NGUOI_CAP_NHAT")]
        [StringLength(50)]
        public string NGUOI_CAP_NHAT { get; set; }

        [Column("NGAY_CAP_NHAT")]
        public Nullable<DateTime> NGAY_CAP_NHAT { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TTHAI_KX")]
        [StringLength(20)]
        public string TTHAI_KX { get; set; }

        [Column("NGAY_DIEU_CHINH")]
        public Nullable<DateTime> NGAY_DIEU_CHINH { get; set; }

        [Column("NGUOI_DIEU_CHINH")]
        [StringLength(20)]
        public string NGUOI_DIEU_CHINH { get; set; }

        [Column("TRANG_THAI_DIEU_CHINH")]
        [StringLength(20)]
        public string TRANG_THAI_DIEU_CHINH { get; set; }

        [Column("SHKB_PAR")]
        [StringLength(20)]
        public string SHKB_PAR { get; set; }

        [Column("QDINH_HOANTHANH")]
        [StringLength(200)]
        public string QDINH_HOANTHANH { get; set; }

        [Column("TT_LANCUOI")]
        [StringLength(20)]
        public string TT_LANCUOI { get; set; }

        [Column("TTHAI_KETDU")]
        [StringLength(20)]
        public string TTHAI_KETDU { get; set; }

        [Column("USER_KETDU")]
        [StringLength(200)]
        public string USER_KETDU { get; set; }

        [Column("NGAY_KETDU")]
        public Nullable<DateTime> NGAY_KETDU { get; set; }

        [Column("GIAM_TTKLHT")]
        public Nullable<decimal> GIAM_TTKLHT { get; set; }

        [Column("GIAM_TAM_UNG")]
        public Nullable<decimal> GIAM_TAM_UNG { get; set; }

        [Column("NGUON_DL")]
        [StringLength(20)]
        public string NGUON_DL { get; set; }

        [Column("MA_NDKT")]
        [StringLength(20)]
        public string MA_NDKT { get; set; }

        [Column("PKG_ID")]
        public Nullable<decimal> PKG_ID { get; set; }

        [Column("LOAI_DU_LIEU")]
        [StringLength(20)]
        public string LOAI_DU_LIEU { get; set; }

        [Column("NGUOI_CHUYEN_DOI")]
        [StringLength(20)]
        public string NGUOI_CHUYEN_DOI { get; set; }

        [Column("TH_GIAI_NGAN")]
        [StringLength(300)]
        public string TH_GIAI_NGAN { get; set; }

        [Column("TCHOI_TTOAN")]
        public Nullable<decimal> TCHOI_TTOAN { get; set; }

        [Column("THUC_TCHOI_TTOAN")]
        public Nullable<decimal> THUC_TCHOI_TTOAN { get; set; }

        [Column("LDO_TCHOI")]
        [StringLength(300)]
        public string LDO_TCHOI { get; set; }

        [Column("NGAY_NHAP")]
        public Nullable<DateTime> NGAY_NHAP { get; set; }

        [Column("TTHAI_GUI")]
        [StringLength(20)]
        public string TTHAI_GUI { get; set; }

        [Column("TTHAI_KSOAT")]
        [StringLength(20)]
        public string TTHAI_KSOAT { get; set; }

        [Column("MA_BQLDA")]
        [StringLength(20)]
        public string MA_BQLDA { get; set; }

        [Column("NGUOI_KSOAT")]
        [StringLength(20)]
        public string NGUOI_KSOAT { get; set; }

        [Column("NGAY_KSOAT")]
        public Nullable<DateTime> NGAY_KSOAT { get; set; }

        [Column("NGUOI_HUYKS")]
        [StringLength(20)]
        public string NGUOI_HUYKS { get; set; }

        [Column("NGAY_HUYKS")]
        public Nullable<DateTime> NGAY_HUYKS { get; set; }

        [Column("NGAY_CHUYEN_DOI")]
        public Nullable<DateTime> NGAY_CHUYEN_DOI { get; set; }


    }
}
