using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_VANBAN_PHAPQUY")]
    public class PHE_VANBAN_PHAPQUY : DataInfoEntity
    {
        [Required]
        [Column("LOAI_VANBAN")]
        [StringLength(50)]
        public string LOAI_VANBAN { get; set; }

        [Required]
        [Column("SO_VANBAN")]
        [StringLength(50)]
        public string SO_VANBAN { get; set; }

        [Required]
        [Column("TEN_VANBAN")]
        [StringLength(250)]
        public string TEN_VANBAN { get; set; }

        [Required]
        [Column("NGAY_BANHANH")]
        public DateTime NGAY_BANHANH { get; set; }

        [Column("CQBH")]
        [StringLength(50)]
        public string CQBH { get; set; }

        [Column("NGUOI_KY")]
        [StringLength(250)]
        public string NGUOI_KY { get; set; }

        [Required]
        [Column("DINH_KEM")]
        [StringLength(250)]
        public string DINH_KEM { get; set; }
    }
}
