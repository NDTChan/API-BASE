using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Au.PHA
{
    [Table("PHA_AU_NGUOIDUNG_NHOMQUYEN")]
    public class PHA_AU_NGUOIDUNG_NHOMQUYEN : DataInfoEntity
    {
        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string MANHOMQUYEN { get; set; }
    }
}
