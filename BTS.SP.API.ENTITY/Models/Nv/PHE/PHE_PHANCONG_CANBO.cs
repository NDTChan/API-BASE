using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_PHANCONG_CANBO")]
    public class PHE_PHANCONG_CANBO : DataInfoEntity
    {
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }
        [Column("SOHIEU_VANBAN")]
        [StringLength(100)]
        public string SOHIEU_VANBAN { get; set; }

        [Column("CANBO_XULY")]
        public string CANBO_XULY { get; set; }

        [Column("CANBO_PHOIHOP")]
        public string CANBO_PHOIHOP { get; set; }
        [Column("CANBO_PHUCTRACH")]
        public string CANBO_PHUCTRACH { get; set; }
    }
}
