using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHITIET_HOPDONG")]
    public class PHE_CHITIET_HOPDONG : DataInfoEntity
    {
        [Required]
        [Column("SO_HOPDONG")]
        [StringLength(50)]
        public string SO_HOPDONG { get; set; }

        [Column("LOAI_CHIPHI")]
        [StringLength(50)]
        public string LOAI_CHIPHI { get; set; }

        [Column("CHIPHI_CHA")]
        [StringLength(50)]
        public string CHIPHI_CHA { get; set; }

        [Column("TEN_CHIPHI")]
        [StringLength(1000)]
        public string TEN_CHIPHI { get; set; }

        [Column("MA_HANGMUC")]
        [StringLength(50)]
        public string MA_HANGMUC { get; set; }

        [Column("LOAI_NGOAITE")]
        [StringLength(50)]
        public string LOAI_NGOAITE { get; set; }

        [Column("SOLUONG")]
        public decimal? SOLUONG { get; set; }

        [Column("SOTIEN_NT")]
        public decimal? SOTIEN_NT { get; set; }

        [Column("TY_GIA")]
        public decimal? TY_GIA { get; set; }

        [Column("SOTIEN_VND")]
        public decimal? SOTIEN_VND { get; set; }

    }
}
