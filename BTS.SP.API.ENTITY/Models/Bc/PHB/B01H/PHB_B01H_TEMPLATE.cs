using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B01H
{
    [Table("PHB_B01H_TEMPLATE")]
    public class PHB_B01H_TEMPLATE:DataInfoEntity
    {
        [Column("MA_TEMPLATE")]
        [Required]
        [StringLength(15)]
        public string MA_TEMPLATE { get; set; }

        [Column("MA_TAI_KHOAN")]
        [Required]
        [StringLength(15)]
        public string MA_TAI_KHOAN { get; set; }

        [Column("TEN_TAI_KHOAN")]
        [Required]
        [StringLength(250)]
        public string TEN_TAI_KHOAN { get; set; }

        [Column("TINH_CHAT")]
        [Description("0: Dư nợ | 1: Dư có | 2 : Lưỡng tính")]
        public int TINH_CHAT { get; set; }

        [Column("TRANG_THAI")]
        public int TRANG_THAI { get; set; }
    }
}
