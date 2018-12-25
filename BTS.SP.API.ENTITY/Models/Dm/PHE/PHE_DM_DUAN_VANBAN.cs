using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_DUAN_VANBAN")]
    public class PHE_DM_DUAN_VANBAN : DataInfoEntity
    {
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }
        [Column("MA_VANBAN")]
        [StringLength(50)]
        public string MA_VANBAN { get; set; }
    }
}
