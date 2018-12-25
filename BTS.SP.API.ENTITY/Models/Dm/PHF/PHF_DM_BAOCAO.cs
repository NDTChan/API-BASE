using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHF
{
    [Table("PHF_DM_BAOCAO")]
    public class PHF_DM_BAOCAO : DataInfoEntity
    {
        [Column("MA_BAO_CAO")]
        [StringLength(100)]
        [Required]
        public string MA_BAO_CAO { get; set; }

        [Column("TEN_BAO_CAO")]
        [StringLength(250)]
        [Required]
        public string TEN_BAO_CAO { get; set; }

        [Column("MO_TA")]
        [StringLength(250)]
        public string MO_TA { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("NGAY_HL")]
        public Nullable<DateTime> NGAY_HL { get; set; }

        [Column("TEMPLATE")]
        [Required]
        [Description(" 1: Có template | 0: Không có template")]
        public int TEMPLATE { get; set; }
    }
}
