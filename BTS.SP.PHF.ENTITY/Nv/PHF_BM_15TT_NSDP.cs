using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_15TT_NSDP")]
    public class PHF_BM_15TT_NSDP : BaseEntity
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

        [Column("TEN_DONVI")]
        [StringLength(1000)]
        [Description("Tên đơn vị")]
        public string TEN_DONVI { get; set; }

        [Column("NOIDUNG_HOTRO")]
        [StringLength(500)]
        [Description("Nội dung hỗ trợ")]
        public string NOIDUNG_HOTRO { get; set; }

        [Column("DUTOAN")]
        [StringLength(300)]
        [Description("Dự toán")]
        public string DUTOAN { get; set; }

        [Column("THUCHIEN")]
        [StringLength(500)]
        [Description("Thực hiện")]
        public string THUCHIEN { get; set; }

        [Column("TYLE_DUTOAN")]
        [StringLength(500)]
        [Description("Tỷ lệ dự toán")]
        public string TYLE_DUTOAN { get; set; }

        [Column("KHUYETDIEM_NOIDUNG")]
        [StringLength(500)]
        [Description("Khuyết điểm nội dung")]
        public string KHUYETDIEM_NOIDUNG { get; set; }

        [Column("KHUYETDIEM_HOSO")]
        [StringLength(500)]
        [Description("Khuyết điểm hồ sơ")]
        public string KHUYETDIEM_HOSO { get; set; }

        [Column("KHUYETDIEM_QUYETTOAN")]
        [StringLength(500)]
        [Description("Khuyết điểm quyết toán")]
        public string KHUYETDIEM_QUYETTOAN { get; set; }

        [Column("KHUYETDIEM_BOSUNG")]
        [StringLength(500)]
        [Description("Khuyết điểm bổ sung")]
        public string KHUYETDIEM_BOSUNG { get; set; }

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
