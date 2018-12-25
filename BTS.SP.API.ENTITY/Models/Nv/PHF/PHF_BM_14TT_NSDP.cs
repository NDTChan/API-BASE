using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_14TT_NSDP")]
    public class PHF_BM_14TT_NSDP : DataInfoEntityPHF
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

        [Column("TEN_DUAN")]
        [StringLength(1000)]
        [Description("Tên dự án")]
        public string TEN_DUAN { get; set; }

        [Column("DUAN_DAUTU")]
        [StringLength(500)]
        [Description("Dự án đầu tư")]
        public string DUAN_DAUTU { get; set; }

        [Column("DUAN_DUTOAN")]
        [StringLength(300)]
        [Description("Dự án dự toán")]
        public string DUAN_DUTOAN { get; set; }

        [Column("THOIGIAN_HOANTHANH")]
        [StringLength(500)]
        [Description("Thời gian hoàn thành")]
        public string THOIGIAN_HOANTHANH { get; set; }

        [Column("THOIGIAN_KHOICONG")]
        [StringLength(500)]
        [Description("Thời gian khởi công")]
        public string THOIGIAN_KHOICONG { get; set; }

        [Column("PHATHIEN_SAIPHAM")]
        [StringLength(500)]
        [Description("Phát hiện sai phạm")]
        public string PHATHIEN_SAIPHAM { get; set; }

        [Column("PHATHIEN_SOTIEN")]
        [StringLength(500)]
        [Description("Phát hiện số tiền")]
        public string PHATHIEN_SOTIEN { get; set; }

        [Column("KIENNGHI_NOIDUNG")]
        [StringLength(500)]
        [Description("Kiến nghị nội dung")]
        public string KIENNGHI_NOIDUNG { get; set; }

        [Column("KIENNGHI_SOTIEN")]
        [StringLength(500)]
        [Description("Kiến nghị số tiền")]
        public string KIENNGHI_SOTIEN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
