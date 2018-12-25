using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_DU_AN")]
    public class PHE_DM_DU_AN : DataInfoEntity
    {
        [Column("CHU_DAU_TU")]
        [StringLength(20)]
        [Required]
        public string CHU_DAU_TU { get; set; }

        [Column("DONVIQUANLY")]
        [StringLength(20)]
        [Required]
        public string DONVIQUANLY { get; set; }

        [Column("MA_QLNB")]
        [StringLength(20)]
        [Required]
        public string MA_QLNB { get; set; }

        [Column("MA_DUAN")]
        [StringLength(20)]
        [Required]
        public string MA_DUAN { get; set; }

        [Column("MA_DUAN_CHA")]
        [StringLength(20)]
        public string MA_DUAN_CHA { get; set; }

        [Column("LINH_VUC")]
        [StringLength(20)]
        [Required]
        public string LINH_VUC { get; set; }

        [Column("TEN_DUAN")]
        [StringLength(250)]
        [Required]
        public string TEN_DUAN { get; set; }

        [Column("LOAI_DUAN")]
        [StringLength(20)]
        public string LOAI_DUAN { get; set; }

        [Column("NHOM_DUAN")]
        [StringLength(20)]
        public string NHOM_DUAN { get; set; }

        [Column("NGAY_BATDAU")]
        [Description("Ngày bắt đầu")]
        [Required]
        public DateTime NGAY_BATDAU { get; set; }

        [Column("NGAY_KETTHUC")]
        [Description("Ngày kết thúc")]
        public DateTime NGAY_KETTHUC { get; set; }

        [Column("SO_QD")]
        [StringLength(20)]
        public string SO_QD { get; set; }

        [Column("NGAY_QD")]
        [Description("Ngày quyết định")]
        public DateTime NGAY_QD { get; set; }

        [Column("CAP_QD")]
        [StringLength(50)]
        public string CAP_QD { get; set; }

        [Column("NGUOI_QD")]
        [StringLength(50)]
        public string NGUOI_QD { get; set; }

        public double KHAI_TOAN_TONG { get; set; }
        public double KINH_PHI_CHUAN_BI { get; set; }

        [Column("CTMT")]
        [StringLength(20)]
        public string CTMT { get; set; }

        [Column("CHUONG")]
        [StringLength(20)]
        public string CHUONG { get; set; }

        [Column("LOAI_KHOAN")]
        [StringLength(20)]
        public string LOAI_KHOAN { get; set; }

        [Column("DIA_DIEM_THUC_HIEN")]
        [StringLength(250)]
        [Required]
        public string DIA_DIEM_THUC_HIEN { get; set; }

        [Column("DIA_DIEM_MO_TK")]
        [StringLength(250)]
        public string DIA_DIEM_MO_TK { get; set; }

        [Column("QUY_MO")]
        [StringLength(50)]
        public string QUY_MO { get; set; }

        [Column("TRANG_THAI_DUAN")]
        [StringLength(20)]
        public string TRANG_THAI_DUAN { get; set; }

        [Column("DINH_KEM")]
        [StringLength(250)]
        public string DINH_KEM { get; set; }

    }
}
