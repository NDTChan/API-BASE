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
    [Table("DM_TIEUNHOM")]
    public class DM_TIEUNHOM : DataInfoEntity
    {
        [Column("MA_TIEUNHOM")]
        [StringLength(6)]
        [Description("Mã nhóm")]
        public string MA_TIEUNHOM { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TEN_TIEUNHOM")]
        [StringLength(240)]
        [Description("Tên nhóm")]
        public string TEN_TIEUNHOM        { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("MA_NHOM")]
        [StringLength(4)]
        [Description("Mã nhóm")]
        public string MA_NHOM { get; set; }


        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú")]
        public string GHI_CHU { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo")]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng")]
        public Nullable<DateTime> NGAY_SD { get; set; }

    }
}
