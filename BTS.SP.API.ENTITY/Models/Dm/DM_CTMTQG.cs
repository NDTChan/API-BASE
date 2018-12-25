using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_CTMTQG")]
    public class DM_CTMTQG : DataInfoEntity
    {
        [Column("MA_CTMTQG")]
        [StringLength(5)]
        public string MA_CTMTQG { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TEN_CTMTQG")]
        [StringLength(500)]
        public string TEN_CTMTQG { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("MA_CTMTQG_CHA")]
        [StringLength(6)]
        public string MA_CTMTQG_CHA { get; set; }

        [Column("LOAI_CTMTQG")]
        [StringLength(1)]
        public string LOAI_CTMTQG { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }
    }
}
