using Repository.Pattern.Ef6;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Auth
{
    [Table("AU_NGUOIDUNG_NHOMQUYEN")]
    public class AU_NGUOIDUNG_NHOMQUYEN : Entity
    {
        [Key]
        public int Id { get; set; }

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
