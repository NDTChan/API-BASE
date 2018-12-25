using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_PHC_CHITIEU_HAS_CONGTHUC")]
    public class DM_PHC_CHITIEU_HAS_CONGTHUC : DataInfoEntity
    {
        [Column("MACHITIEU")]
        [StringLength(20)]
        [Description("Mã chỉ tiêu")]
        public string MACHITIEU { get; set; }

        [Column("MACONGTHUC")]
        [StringLength(200)]
        [Description("Mã công thức")]
        public string MACONGTHUC { get; set; }

        [Column("CONGTHUC")]
        [StringLength(2000)]
        [Description("Mã công thức")]
        public string CONGTHUC { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

    }
}
