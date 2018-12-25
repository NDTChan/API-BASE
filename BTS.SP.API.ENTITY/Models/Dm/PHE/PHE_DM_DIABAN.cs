using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_DIABAN")]
    public class PHE_DM_DIABAN : DataInfoEntity
    {
        [Required]
        [Column("MA_DIABAN")]
        [StringLength(50)]
        public string MA_DIABAN { get; set; }
        [Required]
        [Column("TEN_DIABAN")]
        [StringLength(250)]
        public string TEN_DIABAN { get; set; }
        [Column("TRANGTHAI")]
        [StringLength(10)]
        public string TRANGTHAI { get; set; }
    }
}
