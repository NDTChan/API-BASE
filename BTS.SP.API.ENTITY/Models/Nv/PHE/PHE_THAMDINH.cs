using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_THAMDINH")]
    public class PHE_THAMDINH : DataInfoEntity
    {
        [Column("SO_THAMDINH")]
        [StringLength(50)]
        public string SO_THAMDINH{ get; set; }

        [Column("TEN_TOTRINH")]
        [StringLength(200)]
        public string TEN_THAMDINH{ get; set; }

        [Column("SO_TOTRINH")]
        [StringLength(50)]
        public string SO_TOTRINH { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MA_CONGVIEC{ get; set; }

        [Column("TO_CHUCTHAMDINH")]
        [StringLength(50)]
        public string TO_CHUCTHAMDINH { get; set; }

        [Column("NGUOI_THAMQUYEN")]
        [StringLength(50)]
        public string NGUOI_THAMQUYEN { get; set; }

        [Column("YKIEN_PHAPLY")]
        [StringLength(500)]
        public string YKIEN_PHAPLY { get; set; }

        [Column("YKIEN_PCONGVIEC")]
        [StringLength(500)]
        public string YKIEN_PCONGVIEC { get; set; }

        [Column("MA_PHONGBAN")]
        [StringLength(100)]
        public string MA_PHONGBAN { get; set; }

        [Column("MA_DONVI")]
        [StringLength(100)]
        public string MA_DONVI { get; set; }
    }
}
