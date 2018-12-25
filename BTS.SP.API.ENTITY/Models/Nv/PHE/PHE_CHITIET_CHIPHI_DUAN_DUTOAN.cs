using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHITIET_CHIPHI_DUAN_DUTOAN")]
    public class PHE_CHITIET_CHIPHI_DUAN_DUTOAN : DataInfoEntity
    {
        [Required]
        [Column("SO_QUYETDINH")]
        [StringLength(50)]
        public string SO_QUYETDINH { get; set; }
        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MA_CONGVIEC { get; set; }
        [Column("MA_CHIPHI")]
        [StringLength(50)]
        public string MA_CHIPHI { get; set; }
        [Column("MA_CHIPHI_CHA")]
        [StringLength(50)]
        public string MA_CHIPHI_CHA { get; set; }
        [Column("MA_NGUONVON")]
        [StringLength(50)]
        public string MA_NGUONVON { get; set; }
        [Column("GTDT_DUYET")]
        public Decimal GTDT_DUYET { get; set; }
        [Column("GTDT_DIEUCHINH")]
        public Decimal GTDT_DIEUCHINH { get; set; }
    }
}
