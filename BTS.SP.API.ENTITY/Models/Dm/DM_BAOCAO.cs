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
    [Table("DM_BAOCAO")]
    public class DM_BAOCAO:DataInfoEntity
    {
        [Column("MA_BAOCAO")]
        [StringLength(100)]
        public string MA_BAOCAO { get; set; }
        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }
        [Column("TEN_BAOCAO")]
        [StringLength(200)]
        public string TEN_BAOCAO { get; set; }
        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
        [Column("LOAI_BC")]
        [Description("Loại báo cáo:- 1: Báo cáo Cân đối - 2: Báo cáo Điều hành - 3: Báo cáo Quyết toán")]
        public Nullable<int> LOAI_BC { get; set; }
        [Column("LOAI_CT")]
        [Description("Loại chỉ tiêu: - 1: Chỉ tiêu Thu - 2: Chỉ tiêu Chi")]
        public Nullable<int> LOAI_CT { get; set; }
        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }
        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }
        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

    }
}
