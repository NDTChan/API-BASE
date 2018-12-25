using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Au
{
    [Table("AU_NGUOIDUNG_NHOMQUYEN")]
    public class AU_NGUOIDUNG_NHOMQUYEN : DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHANHE { get; set; }

        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string MANHOMQUYEN { get; set; }
    }
}

