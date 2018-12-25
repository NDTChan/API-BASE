using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHA
{
    [Table("DM_LOAI_KHV")]
    public class DM_LOAI_KHV:DataInfoEntity
    {
        [Column("MA_LOAI_KHV")]
        [StringLength(100)]
        public string MA_LOAI_KHV { get; set; }
        [Column("TEN")]
        [StringLength(250)]
        public string TEN { get; set; }
        [Column("TTHAI_KX")]
        public int TTHAI_KX { get; set; }
    }
}
