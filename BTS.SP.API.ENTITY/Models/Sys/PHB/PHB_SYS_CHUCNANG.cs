using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Sys.PHB
{
    [Table("PHB_SYS_CHUCNANG")]
    public class PHB_SYS_CHUCNANG: DataInfoEntity
    {
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
