using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_BC_NS")]
    public class PHA_BC_NS : DataInfoEntity
    {
        [Column("MA_BAOCAOPK")]
        [StringLength(50)]
        public string MA_BAOCAOPK { get; set; }

        [Column("MA_BAOCAO")]
        [StringLength(50)]
        public string MA_BAOCAO { get; set; }

        [Column("NAM_BC")]
        [StringLength(10)]
        public string NAM_BC { get; set; }

        [Column("THANG_BC")]
        [StringLength(10)]
        public string THANG_BC { get; set; }

        [Column("DONVI")]
        [StringLength(200)]
        public string DONVI { get; set; }

        [Column("NGAY_TAO")]
        public DateTime? NGAY_TAO { get; set; }

        [Column("NGUOI_TAO")]
        [StringLength(200)]
        public string NGUOI_TAO { get; set; }

    }
}
