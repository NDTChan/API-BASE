using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Bc.PHC.S17_X
{
    [Table("PHC_S17_X_DETAIL")]
    public class S17_X_DETAIL : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT { get; set; }

        [Column("SOHIEU")]
        [StringLength(50)]
        [Description("Số hiệu")]
        public string SOHIEU { get; set; }

        [Column("DIENGIAI")]
        [StringLength(1000)]
        [Description("Diễn giải")]
        public string DIENGIAI { get; set; }

        [Column("DONVITINH")]
        [StringLength(50)]
        [Description("Đơn vị tính")]
        public string DONVITINH { get; set; }

        [Column("SERIAL")]
        [StringLength(50)]
        [Description("Serial")]
        public string SERIAL { get; set; }

        [Column("QUYENSO")]
        [StringLength(100)]
        [Description("Quyển số")]
        public string QUYENSO { get; set; }

        [Column("TUSO")]
        [Description("Từ số")]
        public Nullable<decimal> TUSO { get; set; }

        [Column("DENSO")]
        [Description("Đến số")]
        public Nullable<decimal> DENSO { get; set; }

        [Column("SOLINH")]
        [Description("Số lĩnh")]
        public Nullable<decimal> SOLINH { get; set; }

        [Column("THANHTOAN_CONG")]
        [Description("Thanh toán biên lai và số tiền đã thu - cộng")]
        public Nullable<decimal> THANHTOAN_CONG { get; set; }

        [Column("THANHTOAN_SOLUONGDUNG")]
        [Description("Thanh toán biên lai và số tiền đã thu - số lượng dùng")]
        public Nullable<decimal> THANHTOAN_SOLUONGDUNG { get; set; }

        [Column("THANHTOAN_TRALAI")]
        [Description("Thanh toán biên lai và số tiền đã thu - trả lại")]
        public Nullable<decimal> THANHTOAN_TRALAI { get; set; }

        [Column("THANHTOAN_TONTHAT")]
        [Description("Thanh toán biên lai và số tiền đã thu - tổn thât được thanh toán")]
        public Nullable<decimal> THANHTOAN_TONTHAT { get; set; }

        [Column("THANHTOAN_XOABO")]
        [Description("Thanh toán biên lai và số tiền đã thu - xóa bỏ")]
        public Nullable<decimal> THANHTOAN_XOABO { get; set; }

        [Column("THANHTOAN_SODATHU")]
        [Description("Thanh toán biên lai và số tiền đã thu - số đã thu")]
        public Nullable<decimal> THANHTOAN_SODATHU { get; set; }

        [Column("THANHTOAN_SODANOP")]
        [Description("Thanh toán biên lai và số tiền đã thu - số đã nộp")]
        public Nullable<decimal> THANHTOAN_SODANOP { get; set; }

        [Column("BIENLAICONLAI_TUSO")]
        [Description("Biên lai còn lại - từ số")]
        public Nullable<decimal> BIENLAICONLAI_TUSO { get; set; }

        [Column("BIENLAICONLAI_DENSO")]
        [Description("Biên lai còn lại - đến số")]
        public Nullable<decimal> BIENLAICONLAI_DENSO { get; set; }

        [Column("BIENLAICONLAI_TTCHUATT")]
        [Description("Biên lai còn lại - tổn thất chưa thanh toán")]
        public Nullable<decimal> BIENLAICONLAI_TTCHUATT { get; set; }
    }
}
