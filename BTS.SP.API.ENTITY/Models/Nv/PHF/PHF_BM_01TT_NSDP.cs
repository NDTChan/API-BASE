using BTS.SP.API.ENTITY;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_01TT_NSDP")]
    public class PHF_BM_01TT_NSDP : DataInfoEntityPHF
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

        [Column("NOIDUNG")]
        [StringLength(1000)]
        [Description("Nội dung thành phần công việc")]
        public string NOIDUNG { get; set; }

        [Column("CONGVIEC")]
        [StringLength(1000)]
        [Description("Nội dung công việc các địa phương phải triển khai thực hiện")]
        public string CONGVIEC { get; set; }

        [Column("TRANGTHAI_TRIENKHAI")]
        [StringLength(200)]
        [Description("Trạng thái triển khai")]
        public string TRANGTHAI_TRIENKHAI { get; set; }

        [Column("VANBAN_SAIPHAM")]
        [StringLength(500)]
        [Description("Văn bản chưa đúng về nội dung, thời hiệu ...")]
        public string VANBAN_SAIPHAM { get; set; }

        [Column("HAUQUA")]
        [StringLength(1000)]
        [Description("Hậu quả")]
        public string HAUQUA { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
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
