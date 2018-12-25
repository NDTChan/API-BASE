using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_GIAO_KEHOACH_VON")]
    public class PHE_GIAO_KEHOACH_VON : DataInfoEntity
    {
        [Column("NGAY_CHUNGTU")]
        public DateTime NGAY_CHUNGTU { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        public string SO_CHUNGTU { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("LOAI_DUAN")]
        [StringLength(50)]
        public string LOAI_DUAN { get; set; }

        [Column("DIENGIAI")]
        [StringLength(500)]
        public string DIENGIAI { get; set; }

        [Column("MA_GIAIDOAN_VON")]
        [StringLength(50)]
        public string MA_GIAIDOAN_VON { get; set; }

        [Column("LOAI_KEHOACH_VON")]
        [StringLength(50)]
        public string LOAI_KEHOACH_VON { get; set; }

        [Column("NAM_TAMUNG")]
        public int NAM_TAMUNG { get; set; }

        [Column("NAM_KEHOACHVON")]
        public int NAM_KEHOACHVON { get; set; }

        [Column("LOAI_PHIEU")]
        [StringLength(50)]
        public string LOAI_PHIEU { get; set; }
        [Column("MA_PHONGBAN")]
        [StringLength(100)]
        public string MA_PHONGBAN { get; set; }
        [Column("MA_DONVI")]
        [StringLength(100)]
        public string MA_DONVI { get; set; }
    }
}
