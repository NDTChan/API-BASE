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
    [Table("DM_MAUBAOCAOTHU")]
    public class DM_MAUBAOCAOTHU : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        public string TEN { get; set; }

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
        [Description("Trạng thái sử dụng (A: Ðang sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

    }
}