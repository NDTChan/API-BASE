using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_NGUONNGANSACH")]
    public class PHB_DM_NGUONNGANSACH:DataInfoEntity
    {
        [Column("MA_NGUONNS")]
        [StringLength(15)]
        [Required]
        public string MA_NGUONNS { get; set; }

        [Column("TEN_NGUONNS")]
        [StringLength(150)]
        [Required]
        public string TEN_NGUONNS { get; set; }

        [Column("MA_CHA")]
        [StringLength(15)]
        public string MA_CHA { get; set; }

        [Column("CAP")]
        [Required]
        public int CAP { get; set; }

        [Column("LA_CHITIET")]
        [Required]
        public int LA_CHITIET { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Required]
        public string TRANG_THAI { get; set; }

    }
}
