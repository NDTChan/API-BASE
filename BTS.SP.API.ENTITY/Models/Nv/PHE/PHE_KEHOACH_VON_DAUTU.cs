using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_KEHOACH_VON_DAUTU")]
    public class PHE_KEHOACH_VON_DAUTU : DataInfoEntity
    {
        [Column("NGAY_CHUNGTU")]
        public DateTime NGAY_CHUNGTU { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        public string SO_CHUNGTU { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("DIENGIAI")]
        [StringLength(500)]
        public string DIENGIAI { get; set; }

        [Column("MA_GIAIDOAN_VON")]
        [StringLength(50)]
        public string MA_GIAIDOAN_VON { get; set; }

        [Column("LOAI_KEHOACH_VON")]
        [StringLength(50)]
        public string LOAI_KEHOACH_VON { get; set; }

        [Column("NAM_DIEUCHINH")]
        public int NAM_DIEUCHINH { get; set; }

        [Column("LOAI_CHUNGTU")]
        [StringLength(500)]
        public string LOAI_CHUNGTU { get; set; }

        [Column("LOAI_DUAN")]
        [StringLength(500)]
        public string LOAI_DUAN { get; set; }

        [Column("CHITIET_KEHOACH_VON")]
        [StringLength(500)]
        public string CHITIET_KEHOACH_VON { get; set; }

        [Column("TYPE_VB")]
        [StringLength(500)]
        public string TYPE_VB { get; set; }
    }
}
