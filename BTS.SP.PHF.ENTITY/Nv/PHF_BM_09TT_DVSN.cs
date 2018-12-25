using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_09TT_DVSN")]
    public class PHF_BM_09TT_DVSN : BaseEntity
    {
        [Column("STT")]
        [Description("Số thứ tự")]
        public int STT { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        [Description("Mã Đơn vị")]
        public string MA_DONVI { get; set; }

        [Column("THOI_KY")]
        [StringLength(500)]
        [Description("Thời kỳ")]
        public string THOI_KY { get; set; }

        [Column("MA_FILE")]
        [StringLength(200)]
        [Description("Mã file Template")]
        public string MA_FILE { get; set; }

        [Column("MA_FILE_PK")]
        [StringLength(200)]
        [Description("Mã file pk Template")]
        public string MA_FILE_PK { get; set; }

        [Column("HOTEN")]
        [StringLength(1000)]
        [Description("Họ và tên")]
        public string HOTEN { get; set; }

        [Column("SOLIEU_DV_CHIUTHUE")]
        [Description("Số liệu đơn vị chịu thuế")]
        public decimal? SOLIEU_DV_CHIUTHUE { get; set; }

        [Column("SOLIEU_DV_PHAINOP")]
        [Description("Số liệu đơn vị phải nộp")]
        public decimal? SOLIEU_DV_PHAINOP { get; set; }

        [Column("THANHTRA_DV_CHIUTHUE")]
        [Description("Thanh tra số liệu đơn vị chịu thuế")]
        public decimal? THANHTRA_DV_CHIUTHUE { get; set; }

        [Column("THANHTRA_DV_PHAINOP")]
        [Description("Thanh tra số liệu đơn vị phải nộp")]
        public decimal? THANHTRA_DV_PHAINOP { get; set; }

        [Column("NGUYENNHAN")]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

    }
}
