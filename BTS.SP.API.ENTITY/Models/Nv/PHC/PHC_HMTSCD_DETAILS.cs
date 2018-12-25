using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_HMTSCD_DETAILS")]
    public class PHC_HMTSCD_DETAILS : DataInfoEntity
    {
        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("SO chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("TAISAN")]
        [StringLength(20)]
        [Description("Tài sản")]
        public string TAISAN { get; set; }

        [Column("TK_NO")]
        [StringLength(20)]
        [Description("TK NO")]
        public string TK_NO { get; set; }

        [Column("TK_CO")]
        [StringLength(20)]
        [Description("TK_CO")]
        public string TK_CO { get; set; }

        [Column("DIENGIAI")]
        [StringLength(200)]
        [Description("DIEN GIAI")]
        public string DIENGIAI { get; set; }

        [Column("SO_TIEN")]
        [Description("SO TIEN")]
        public Nullable<decimal> SO_TIEN { get; set; }

    }
}
