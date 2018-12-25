using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_QUANLY_TAISAN")]
    public class PHE_QUANLY_TAISAN : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        public string MA_CHUNGTU { get; set; }

        [Column("NGAY_CHUNGTU")]
        public DateTime? NGAY_CHUNGTU { get; set; }

        [Column("NGAY_SUDUNG")]
        public DateTime? NGAY_SUDUNG { get; set; }

        [Column("LOAI_TAISAN")]
        [StringLength(500)]
        public string LOAI_TAISAN { get; set; }

        [Column("NOIDUNG")]
        public string NOIDUNG { get; set; }

        [Column("NGUONVON_DAUTU")]
        [StringLength(50)]
        public string NGUONVON_DAUTU { get; set; }

        [Column("DONVI_SUDUNG")]
        [StringLength(50)]
        public string DONVI_SUDUNG { get; set; }
        [Column("MA_PHONGBAN")]
        [StringLength(100)]
        public string MA_PHONGBAN { get; set; }
        [Column("MA_DONVI")]
        [StringLength(100)]
        public string MA_DONVI { get; set; }
    }
}
