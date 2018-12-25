using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_LOAINGANSACH")]
    public class PHB_DM_LOAINGANSACH:DataInfoEntity
    {
        [Column("MA_LOAINS")]
        [StringLength(15)]
        [Required]
        public string MA_LOAINS { get; set; }

        [Column("TEN_LOAINS")]
        [Required]
        [StringLength(150)]
        public string TEN_LOAINS { get; set; }

        [Column("MA_CHA")]
        [StringLength(15)]
        public string MA_CHA { get; set; }

        [Column("CAP")]
        [Required]
        public int CAP { get; set; }

        [Column("LA_CHITIET")]
        [Required]
        public int LA_CHITIET { get; set; }

        [Column("MO_TA")]
        [StringLength(150)]
        public string MO_TA { get; set; }

        [Column("TEN_MORONG")]
        [StringLength(150)]
        public string TEN_MORONG { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Required]
        public string TRANG_THAI { get; set; }


    }
}
