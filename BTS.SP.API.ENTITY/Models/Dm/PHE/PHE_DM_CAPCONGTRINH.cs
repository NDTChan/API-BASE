using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_CAPCONGTRINH")]
    public class PHE_DM_CAPCONGTRINH : DataInfoEntity
    {
        [Required]
        [Column("MA_CAPCONGTRINH")]
        [StringLength(50)]
        public string MA_CAPCONGTRINH { get; set; }
        [Required]
        [Column("TEN_CAPCONGTRINH")]
        [StringLength(250)]
        public string TEN_CAPCONGTRINH { get; set; }
        [Column("TRANGTHAI")]
        [StringLength(10)]
        public string TRANGTHAI { get; set; }
    }
}
