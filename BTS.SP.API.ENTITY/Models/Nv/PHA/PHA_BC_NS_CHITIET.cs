using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_BC_NS_CHITIET")]
    public class PHA_BC_NS_CHITIET : DataInfoEntity
    {
        [Column("MA_BAOCAOPK")]
        [StringLength(50)]
        public string MA_BAOCAOPK { get; set; }

        [Column("MA_BAOCAO")]
        [StringLength(50)]
        public string MA_BAOCAO { get; set; }

        [Column("MA_CHITIEU")]
        [StringLength(50)]
        public string MA_CHITIEU { get; set; }

        [Column("TEN_CHITIEU")]
        [StringLength(500)]
        public string TEN_CHITIEU { get; set; }

        [Column("AMOUNT1")]
        public decimal? AMOUNT1 { get; set; }

        [Column("AMOUNT2")]
        public decimal? AMOUNT2 { get; set; }

        [Column("AMOUNT3")]
        public decimal? AMOUNT3 { get; set; }

        [Column("AMOUNT4")]
        public decimal? AMOUNT4 { get; set; }

        [Column("AMOUNT5")]
        public decimal? AMOUNT5 { get; set; }

        [Column("AMOUNT6")]
        public decimal? AMOUNT6 { get; set; }

        [Column("GHI_CHU")]
        [StringLength(2000)]
        public string GHI_CHU { get; set; }

    }
}
