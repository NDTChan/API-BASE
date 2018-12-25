using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_QUANLY_KL_THICONG")]
    public class PHE_QUANLY_KL_THICONG : DataInfoEntity
    {
        [Column("MA_KHOILUONG")]
        [StringLength(50)]
        public string MA_KHOILUONG { get; set; }

        [Column("TEN_KHOILUONG")]
        public string TEN_KHOILUONG { get; set; }

        [Column("NGAY_KHAIBAO")]
        public DateTime NGAY_KHAIBAO { get; set; }

        [Column("MA_GOITHAU")]
        [StringLength(50)]
        public string MA_GOITHAU { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        public string MA_DONVI { get; set; }

    }
}
