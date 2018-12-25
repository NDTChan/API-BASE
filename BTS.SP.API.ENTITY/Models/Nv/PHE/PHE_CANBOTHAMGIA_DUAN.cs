using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CANBOTHAMGIA_DUAN")]
    public class PHE_CANBOTHAMGIA_DUAN : DataInfoEntity
    {
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }
        [Column("MA_CANBOTHAMGIA")]
        [StringLength(30)]
        public string MA_CANBOTHAMGIA { get; set; }
    }
}
