using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_HOATDONG")]
    public class PHB_DM_HOATDONG:DataInfoEntity
    {
        [Column("TEN")]
        [Required]
        [StringLength(250)]
        public string TEN { get; set; }

        [Column("HOATDONG_CHA")]
        public int? HOATDONG_CHA { get; set; }

        [Column("CAP")]
        public int? CAP { get; set; }

        [Column("MO_TA")]
        [StringLength(250)]
        public string MO_TA { get; set; }

        [Column("TRANG_THAI")]
        [Required]
        [StringLength(1)]
        [Description("A:Sử dụng | I : Không sử dụng")]
        public string TRANG_THAI { get; set; }
    }
}
