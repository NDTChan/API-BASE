using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_CHITIEU")]
    public class DM_CHITIEU:DataInfoEntity
    {
        [Column("MA_CHITIEU")]
        [StringLength(100)]
        public string MA_CHITIEU { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("TEN_CHITIEU")]
        [StringLength(300)]
        public string TEN_CHITIEU { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("CONGTHUC")]
        [StringLength(2000)]
        public string CONGTHUC { get; set; }

        [Column("LOAI_CT")]
        public Nullable<int> LOAI_CT { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }
    }
}
