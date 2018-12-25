using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_LOAICT")]
    public class DM_LOAICT : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        public string TEN { get; set; }

        [Column("NHOM_CHA")]
        [StringLength(1)]
        public string NHOM_CHA { get; set; }

        [Column("MA_CHA")]
        [StringLength(250)]
        public string MA_CHA { get; set; }

        [Column("SO_CT")]
        public int SO_CT { get; set; }

        [Column("LOAI_CT")]
        public int LOAI_CT { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

    }
}