using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_CHIPHI")]
    public class PHE_DM_CHIPHI : DataInfoEntity
    {
        [Required]
        [Column("MA_CHIPHI")]
        [StringLength(50)]
        public string MA_CHIPHI { get; set; }
        [Column("TEN_CHIPHI")]
        [StringLength(250)]
        public string TEN_CHIPHI { get; set; }
        [Column("MA_CHIPHI_CHA")]
        [StringLength(50)]
        public string MA_CHIPHI_CHA { get; set; }
    }
}
