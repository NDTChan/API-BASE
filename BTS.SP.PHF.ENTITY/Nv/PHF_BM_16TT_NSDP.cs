using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_16TT_NSDP")]
    public class PHF_BM_16TT_NSDP : BaseEntity
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

        [Column("MA_FILE")]
        [StringLength(200)]
        [Description("Mã file Template")]
        public string MA_FILE { get; set; }

        [Column("MA_FILE_PK")]
        [StringLength(200)]
        [Description("Mã file pk Template")]
        public string MA_FILE_PK { get; set; }

        [Column("DOITUONG")]
        [StringLength(1000)]
        [Description("Đối tượng có sai phạm, khuyết điểm")]
        public string DOITUONG { get; set; }

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung sai phạm, khuyết điểm")]
        public string NOIDUNG { get; set; }

        [Column("NOIDUNG_SOTIEN")]
        [StringLength(500)]
        [Description("Nội dung sai phạm, khuyết điểm, số tiền")]
        public string NOIDUNG_SOTIEN { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(500)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("GHICHU")]
        [StringLength(1000)]
        [Description("Ghi chú")]
        public string GHICHU { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
