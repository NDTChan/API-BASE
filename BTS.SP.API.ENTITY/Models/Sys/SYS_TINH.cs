using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_TINH")]
    public class SYS_TINH : DataInfoEntity
    {
        [Column("MA_TINH")]
        [StringLength(2)]
        [Description("Mã tỉnh ")]
        public string MA_TINH { get; set; }

        [Column("TEN_TINH")]
        [StringLength(240)]
        [Description("Tên tỉnh ")]
        public string TEN_TINH { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public Nullable<DateTime> NGAY_HL { get; set; }

        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo ")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng ")]
        public Nullable<DateTime> NGAY_SD { get; set; }
        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo ")]
        public string USER_NAME { get; set; }

    }
}
