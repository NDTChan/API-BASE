
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
    [Table("PHC_PHIEU_GT_CCDC_IN")]
    public class PHC_PHIEU_GT_CCDC_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string SO_CHUNGTU { get; set; }

        [Column("DON_VI")]
        [StringLength(100)]
        [Description("đơn vị")]
        public string DON_VI { get; set; }

        [Column("BO_PHAN")]
        [StringLength(100)]
        public string BO_PHAN { get; set; }

        [Column("MA_DVSDNS")]
        [StringLength(100)]
        public string MA_DVSDNS { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}

