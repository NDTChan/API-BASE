using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_TOTRINH_II")]
    public class PHE_TOTRINH_II : DataInfoEntity
    {
        [Column("SO_TOTRINH")]
        [StringLength(50)]
        public string SO_TOTRINH { get; set; }

        [Column("GOITHAU")]
        [StringLength(200)]
        public string GOITHAU { get; set; }

        [Column("DONVI_THUCHIEN")]
        [StringLength(200)]
        public string DONVI_THUCHIEN { get; set; }

        [Column("GIA_TRI")]
        public decimal? GIA_TRI { get; set; }

        [Column("VANBAN_PHEDUYET")]
        [StringLength(200)]
        public string VANBAN_PHEDUYET { get; set; }

        [Column("LOAI_TOTRINH")]
        public int LOAI_TOTRINH{ get; set; }

    }
}
