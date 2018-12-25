using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_TUDIEN")]
    public class SYS_TUDIEN: DataInfoEntity
    {
        [Column("FIELDNAME")]
        [StringLength(20)]
        [Description("Mã loại danh mục ")]
        public string FIELDNAME { get; set; }

        [Column("MA_TUDIEN")]
        [StringLength(6)]
        [Description("Mã từ điển ")]
        public string MA_TUDIEN { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public Nullable<DateTime> NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [Column("MO_TA")]
        [StringLength(2000)]
        [Description("Tên Danh mục ")]
        public string MO_TA { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo ")]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo ")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng ")]
        public Nullable<DateTime> NGAY_SD { get; set; }

    }
}
