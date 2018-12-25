using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_07TT_DVSN")]
    public class PHF_BM_07TT_DVSN : BaseEntity
    {
        [Column("STT")]
        [Description("Số thứ tự")]
        public int STT { get; set; }

        [Column("STT_TIEUDE")]
        [Description("Số thứ tự tiêu đề")]
        [StringLength(5)]
        public string STT_TIEUDE { get; set; }

        [Column("STT_CHA")]
        [Description("Số thứ tự cha")]
        public int STT_CHA { get; set; }

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

        [Column("NOIDUNG")]
        [StringLength(1000)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        [Column("BAOCAO_DONVI")]
        [Description("Báo cáo đơn vị")]
        public decimal? BAOCAO_DONVI { get; set; }

        [Column("THANHTRA_XACDINH")]
        [Description("Thanh tra xác định")]
        public decimal? THANHTRA_XACDINH { get; set; }

        [Column("NGUYENNHAN")]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int? IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int? IS_ITALIC { get; set; }
    }
}
