using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("TCS_DM_COQUANTHU")]
    public class TCS_DM_COQUANTHU : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        [Required]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(500)]
        public string TEN { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [DefaultValue("A")]
        public string TRANG_THAI { get; set; }
    }
}