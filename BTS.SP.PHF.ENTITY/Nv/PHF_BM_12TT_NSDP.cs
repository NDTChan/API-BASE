using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_12TT_NSDP")]
    public class PHF_BM_12TT_NSDP : BaseEntity
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

        [Column("DUAN")]
        [StringLength(1000)]
        [Description("Dự án")]
        public string DUAN { get; set; }

        [Column("CHUDAUTU")]
        [StringLength(500)]
        [Description("Chủ đầu tư")]
        public string CHUDAUTU { get; set; }

        [Column("THOIDIEM_KHOICONG")]
        [StringLength(300)]
        [Description("Thời điểm khởi công")]
        public string THOIDIEM_KHOICONG { get; set; }

        [Column("THOIGIAN_HOANTHANH")]
        [StringLength(500)]
        [Description("Thời gian hoàn thành")]
        public string THOIGIAN_HOANTHANH { get; set; }

        [Column("GIATRI_HOPDONG")]
        [StringLength(500)]
        [Description("Giá trị hợp đồng")]
        public string GIATRI_HOPDONG { get; set; }

        [Column("GIATRI_NGHIEMTHU")]
        [StringLength(500)]
        [Description("Giá trị nghiệm thu")]
        public string GIATRI_NGHIEMTHU { get; set; }

        [Column("GIATRI_DUOC_THANHTOAN")]
        [StringLength(500)]
        [Description("Giá trị được thanh toán")]
        public string GIATRI_DUOC_THANHTOAN { get; set; }

        [Column("GIATRI_CHUA_THANHTOAN")]
        [StringLength(500)]
        [Description("Giá trị chưa thanh toán")]
        public string GIATRI_CHUA_THANHTOAN { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1500)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
