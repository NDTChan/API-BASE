using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_CHUONG")]
    public class DM_CHUONG : DataInfoEntity
    {
        [Column("MA_CHUONG")]
        [StringLength(3)]
        [Description("Mã chương")]
        public string MA_CHUONG { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TEN_CHUONG")]
        [StringLength(240)]
        [Description("Tên chương")]
        public string TEN_CHUONG { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("MA_CAP")]
        [StringLength(1)]
        [Description("Cấp chương(1 - trung ương, 2 – tỉnh, 3 - huyện, 4 - xã)")]
        public string MA_CAP { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú")]
        public string GHI_CHU { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo")]
        public string USER_NAME  { get; set; }


        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng")]
        public Nullable<DateTime> NGAY_SD { get; set; }
    }
}
