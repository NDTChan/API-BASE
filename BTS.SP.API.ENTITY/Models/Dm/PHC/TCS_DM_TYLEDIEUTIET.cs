using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("TCS_DM_TYLEDIEUTIET")]
    public class TCS_DM_TYLEDIEUTIET : DataInfoEntity
    {
        [Column("MA")]
        [Required]
        [StringLength(20)]
        public string MA { get; set; }

        [Column("TYLE_DIEUTIET")]
        [StringLength(30)]
        [Description("Tỷ lệ điều tiết")]
        public string TYLE_DIEUTIET { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [DefaultValue("A")]
        public string TRANG_THAI { get; set; }
    }
}