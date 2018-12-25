using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_HIENTRANG_HOPDONG")]
    public class PHE_DM_HIENTRANG_HOPDONG : DataInfoEntity
    {
        [Required]
        [Column("MA_HIENTRANG_HOPDONG")]
        [StringLength(50)]
        public string MA_HIENTRANG_HOPDONG { get; set; }
        [Required]
        [Column("TEN_HIENTRANG_HOPDONG")]
        [StringLength(250)]
        public string TEN_HIENTRANG_HOPDONG { get; set; }
        [Column("TRANGTHAI")]
        [StringLength(10)]
        public string TRANGTHAI { get; set; }
    }
}
