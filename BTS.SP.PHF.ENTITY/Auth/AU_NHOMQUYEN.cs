using Repository.Pattern.Ef6;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Auth
{
    [Table("AU_NHOMQUYEN")]
    public class AU_NHOMQUYEN : Entity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string PHANHE { get; set; }

        [StringLength(50)]
        [Required]
        public string MANHOMQUYEN { get; set; }

        [StringLength(100)]
        public string TENNHOMQUYEN { get; set; }

        [StringLength(200)]
        public string MOTA { get; set; }

        [Description("1: sudung | 0 : khongsudung")]
        public int TRANGTHAI { get; set; }
    }
}
