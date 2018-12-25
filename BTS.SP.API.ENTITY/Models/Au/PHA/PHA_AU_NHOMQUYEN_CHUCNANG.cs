using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Au.PHA
{
    [Table("PHA_AU_NHOMQUYEN_CHUCNANG")]
    public class PHA_AU_NHOMQUYEN_CHUCNANG : DataInfoEntity
    {
        [Column("MANHOMQUYEN")]
        [StringLength(50)]
        [Required]
        public string MANHOMQUYEN { get; set; }

        [Column("MACHUCNANG")]
        [StringLength(50)]
        [Required]
        public string MACHUCNANG { get; set; }

        [Column("XEM")]
        [Required]
        public bool XEM { get; set; }

        [Column("THEM")]
        [Required]
        public bool THEM { get; set; }

        [Column("SUA")]
        [Required]
        public bool SUA { get; set; }

        [Column("XOA")]
        [Required]
        public bool XOA { get; set; }

        [Column("DUYET")]
        [Required]
        public bool DUYET { get; set; }

        [Column("TRANGTHAI")]
        public int TRANGTHAI { get; set; }
    }
}
