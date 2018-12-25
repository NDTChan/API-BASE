using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Au
{
    [Table("AU_NHOMQUYEN_CHUCNANG")]
    public class AU_NHOMQUYEN_CHUCNANG : DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHANHE { get; set; }

        [StringLength(50)]
        [Required]
        public string MANHOMQUYEN { get; set; }

        [StringLength(50)]
        [Required]
        public string MACHUCNANG { get; set; }

        [Required]
        public bool XEM { get; set; }

        [Required]
        public bool THEM { get; set; }

        [Required]
        public bool SUA { get; set; }

        [Required]
        public bool XOA { get; set; }

        [Required]
        public bool DUYET { get; set; }

        public int TRANGTHAI { get; set; }
    }
}
