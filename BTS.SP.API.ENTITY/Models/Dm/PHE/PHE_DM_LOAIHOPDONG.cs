using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_LOAIHOPDONG")]
    public class PHE_DM_LOAIHOPDONG : DataInfoEntity
    {
        [Required]
        [Column("MA_LOAIHOPDONG")]
        [StringLength(50)]
        public string MA_LOAIHOPDONG { get; set; }
        [Required]
        [Column("TEN_LOAIHOPDONG")]
        [StringLength(250)]
        public string TEN_LOAIHOPDONG { get; set; }
        [Column("TRANGTHAI")]
        [StringLength(10)]
        public string TRANGTHAI { get; set; }
    }
}
