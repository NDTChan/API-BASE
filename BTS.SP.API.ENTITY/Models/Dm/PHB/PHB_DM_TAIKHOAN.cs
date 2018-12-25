using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_TAIKHOAN")]
    public class PHB_DM_TAIKHOAN:DataInfoEntity
    {
        [Column("MA_TAI_KHOAN")]
        [StringLength(15)]
        [Required]
        public string MA_TAI_KHOAN { get; set; }

        [Column("TEN_TAI_KHOAN")]
        [Required]
        [StringLength(250)]
        public string TEN_TAI_KHOAN { get; set; }

        [Column("MA_CHA")]
        [StringLength(15)]
        public string MA_CHA { get; set; }

        [Column("CAP")]
        [Required]
        public int CAP { get; set; }

        [Column("TINH_CHAT")]
        [Description("[BalanceSide]")]
        public int TINH_CHAT { get; set; }

        [Column("LA_MA_CHA")]
        [Description("[IsParent]")]
        public int LA_MA_CHA { get; set; }

        [Column("MO_TA")]
        [StringLength(250)]
        public string MO_TA { get; set; }

        [Column("TRANG_THAI")]
        [Required]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
