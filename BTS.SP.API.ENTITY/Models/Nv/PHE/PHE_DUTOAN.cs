using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_DUTOAN")]
    public class PHE_DUTOAN : DataInfoEntity
    {
        [Required]
        [Column("SO_VANBAN")]
        [StringLength(50)]
        public string SO_VANBAN { get; set; }

        [Required]
        [Column("MA_DUTOAN")]
        [StringLength(50)]
        public string MA_DUTOAN { get; set; }

        [Required]
        [Column("SO_QD")]
        [StringLength(50)]
        public string SO_QD { get; set; }

        [Required]
        [Column("NGAY_TRINH")]
        public DateTime NGAY_TRINH { get; set; }

        [Required]
        [Column("NGAY_QD")]
        public DateTime NGAY_QD { get; set; }

        [Required]
        [Column("LOAI_PHATSINH")]
        [StringLength(50)]
        public string LOAI_PHATSINH { get; set; }

        [Required]
        [Column("DIEN_GIAI")]
        [StringLength(250)]
        public string DIEN_GIAI { get; set; }

        [Required]
        [Column("DINH_KEM")]
        [StringLength(250)]
        public string DINH_KEM { get; set; }
    }
}
