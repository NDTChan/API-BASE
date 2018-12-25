using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_DOITUONGVON")]
    public class PHE_DM_DOITUONGVON : DataInfoEntity
    {
        [Required]
        [Column("MA_DOITUONGVON")]
        [StringLength(50)]
        public string MA_DOITUONGVON { get; set; }
        [Column("TEN_DOITUONGVON")]
        [StringLength(250)]
        public string TEN_DOITUONGVON { get; set; }
    }
}
