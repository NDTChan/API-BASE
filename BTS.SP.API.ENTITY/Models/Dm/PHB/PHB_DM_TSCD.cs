using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_TSCD")]
    public class PHB_DM_TSCD:DataInfoEntity
    {
        [Column("MA_TSCD")]
        [StringLength(15)]
        [Required]
        public string MA_TSCD { get; set; }

        [Column("TEN_TSCD")]
        [StringLength(250)]
        [Required]
        public string TEN_TSCD { get; set; }

        [Column("MA_CHA")]
        [StringLength(15)]
        public string MA_CHA { get; set; }

        [Column("CAP")]
        [Required]
        public int CAP { get; set; }

        [Column("LACHITIET")]
        [Required]
        public int LACHITIET { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Required]
        public string TRANG_THAI { get; set; }

        [Column("MO_TA")]
        [StringLength(250)]
        public string MO_TA { get; set; }

        [Column("DON_VI_TINH")]
        [StringLength(15)]
        public string DON_VI_TINH { get; set; }
    }
}
