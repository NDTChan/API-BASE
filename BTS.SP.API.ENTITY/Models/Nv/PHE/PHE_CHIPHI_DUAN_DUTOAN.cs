using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHIPHI_DUAN_DUTOAN")]
    public class PHE_CHIPHI_DUAN_DUTOAN : DataInfoEntity
    {
        [Required]
        [Column("SO_QUYETDINH")]
        [StringLength(50)]
        public string SO_QUYETDINH { get; set; }
        [Required]
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }
        [Required]
        [Column("NGAY_QUYETDINH")]
        public DateTime NGAY_QUYETDINH { get; set; }
        [Required]
        [Column("NGAY_CHUNGTU")]
        public DateTime NGAY_CHUNGTU { get; set; }
        [Column("DIENGIAI")]
        [StringLength(500)]
        public string DIENGIAI { get; set; }
    }
}
