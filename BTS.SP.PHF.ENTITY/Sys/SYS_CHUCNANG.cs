using Repository.Pattern.Ef6;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Sys
{
    [Table("SYS_CHUCNANG")]
    public class SYS_CHUCNANG: Entity
    {
        [Key]
        public int Id { get; set; }

        [Column("PHANHE")]
        [StringLength(50)]
        [Required]
        public string PHANHE { get; set; }

        [Column("MACHUCNANG")]
        [StringLength(30)]
        [Required]
        public string MACHUCNANG { get; set; }

        [Column("TENCHUCNANG")]
        [StringLength(300)]
        [Description("Tên chức năng")]
        public string TENCHUCNANG { get; set; }

        [Column("MACHA")]
        [StringLength(30)]
        public string MACHA { get; set; }

        [Column("STATE")]
        [StringLength(100)]
        public string STATE { get; set; }

        [Column("SOTHUTU")]
        [StringLength(50)]
        public string SOTHUTU { get; set; }

        [Column("TRANGTHAI")]
        [Description("1: sudung | 0:khongsudung")]
        public int TRANGTHAI { get; set; }

    }
}
