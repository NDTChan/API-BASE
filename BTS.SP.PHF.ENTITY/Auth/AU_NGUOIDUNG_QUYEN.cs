using Repository.Pattern.Ef6;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Auth
{
    [Table("AU_NGUOIDUNG_QUYEN")]
    public class AU_NGUOIDUNG_QUYEN : Entity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string PHANHE { get; set; }

        [StringLength(50)]
        [Required]
        public string USERNAME { get; set; }

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
