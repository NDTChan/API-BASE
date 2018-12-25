using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B04X
{
    [Table("PHB_C_B04X")]
    public class PHB_C_B04X : DataInfoEntity
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(3)]
        [Required]
        public string MA_CHUONG { get; set; }

        [Column("MA_QHNS")]
        [StringLength(10)]
        [Required]
        public string MA_QHNS { get; set; }

        [Column("NAM_BC")]
        [Required]
        public int NAM_BC { get; set; }

        [Column("KY_BC")]
        [Required]
        [Description(
            "0:Năm  | 101:Quý 1 | 102:Quý 2 | 103:Quý 3 | 104:Quý 4 | 201:6 tháng đầu năm | 202 : 6 tháng cuối năm")]
        public int KY_BC { get; set; }

        [Column("TRANG_THAI")]
        [Required]
        [Description("1: Đã duyệt | 0:chưa duyệt")]
        public int TRANG_THAI { get; set; }

        [Column("NGAY_TAO")]
        [Required]
        public DateTime NGAY_TAO { get; set; }

        [Column("NGUOI_TAO")]
        [StringLength(150)]
        [Required]
        public string NGUOI_TAO { get; set; }

        [Column("NGAY_SUA")]
        public DateTime? NGAY_SUA { get; set; }

        [Column("NGUOI_SUA")]
        [StringLength(150)]
        public string NGUOI_SUA { get; set; }

        [Description("Mã địa bàn hành chính")]
        [StringLength(5)]
        public string MA_DBHC { get; set; }

        [Description("Mã địa bàn hành chính cha")]
        [StringLength(5)]
        public string MA_DBHC_CHA { get; set; }

        [Column("TEN_QHNS")]
        [StringLength(255)]
        public string TEN_QHNS { get; set; }

        [Column("DIEN_TICH")]
        [Description("Diện tích")]
        public Nullable<decimal> DIEN_TICH { get; set; }

        [Column("DIEN_TICH_DAT")]
        [Description("Diện tích đất")]
        public Nullable<decimal> DIEN_TICH_DAT { get; set; }

        [Column("DANSO")]
        [Description("Dân số")]
        public Nullable<decimal> DANSO { get; set; }

        [Column("NGANH_NGHE")]
        [StringLength(2000)]
        [Description("Ngành nghề")]
        public string NGANH_NGHE { get; set; }

        [Column("MUCTIEU_NHIEMVU")]
        [StringLength(2000)]
        [Description("Mục tiêu nhiệm vụ")]
        public string MUCTIEU_NHIEMVU { get; set; }

        [Column("DANH_GIA")]
        [StringLength(2000)]
        [Description("Đánh giá")]
        public string DANH_GIA { get; set; }

        [Column("NGUYEN_NHAN")]
        [StringLength(2000)]
        [Description("Nguyên nhân")]
        public string NGUYEN_NHAN { get; set; }

        [Column("KHACH_QUAN")]
        [StringLength(2000)]
        [Description("Khách quan")]
        public string KHACH_QUAN { get; set; }

        [Column("CHU_QUAN")]
        [StringLength(2000)]
        [Description("Chủ quan")]
        public string CHU_QUAN { get; set; }

        [Column("DENGHI_KIENXUAT")]
        [StringLength(2000)]
        [Description("Đề nghị kiến xuất")]
        public string DENGHI_KIENXUAT { get; set; }
    }
}
