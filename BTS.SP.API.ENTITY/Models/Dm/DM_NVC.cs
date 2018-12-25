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
    [Table("DM_NVC")]
    public class DM_NVC: DataInfoEntity
    {
        [Column("MA_NVC")]
        [StringLength(3)]
        [Description("Mã nhiệm vụ chi")]
        public string MA_NVC { get; set; }

        [Column("TEN_NVC")]
        [StringLength(240)]
        [Description("Tên nhiệm vụ chi")]
        public string TEN_NVC { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực")]
        public DateTime NGAY_HL { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú")]
        public string GHI_CHU { get; set; }
    }
}
