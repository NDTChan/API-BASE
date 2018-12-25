using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_LOAI_CAPPHAT")]
    public class PHB_DM_LOAI_CAPPHAT:DataInfoEntity
    {
        [Column("LOAI_CAPPHAT")]
        public int LOAI_CAPPHAT { get; set; }

        [Column("TEN_LOAI_CAPPHAT")]
        [Required]
        [StringLength(250)]
        public string TEN_LOAI_CAPPHAT { get; set; }

    }
}
