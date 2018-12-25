using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_TAISAN")]
    public class PHE_DM_TAISAN : DataInfoEntity
    {
        [Required]
        [Column("MA_TAISAN")]
        [StringLength(50)]
        public string MA_TAISAN { get; set; }

        [Required]
        [Column("TEN_TAISAN")]
        [StringLength(250)]
        public string TEN_TAISAN { get; set; }
        
        [Column("DONVITINH")]
        [StringLength(50)]
        public string DONVITINH { get; set; }

        [Column("DONGIA")]
        public decimal DONGIA { get; set; }

    }
}
