using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_DBHC")]
    public class DM_DBHC:DataInfoEntity
    {
        [Column("MA_T")]
        [StringLength(10)]
        public string MA_T { get; set; }

        [Column("MA_H")]
        [StringLength(10)]
        public string MA_H { get; set; }

        [Column("MA_X")]
        [StringLength(10)]
        public string MA_X { get; set; }

        [Column("MA_DBHC")]
        [StringLength(500)]
        public string MA_DBHC { get; set; }

        [Column("TEN_DBHC")]
        [StringLength(500)]
        public string TEN_DBHC { get; set; }

        [Column("LOAI")]
        public Nullable<int> LOAI { get; set; }

        [Column("MA_DBHC_CHA")]
        [StringLength(10)]
        public string MA_DBHC_CHA { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("MA_THAMCHIEU")]
        [StringLength(150)]
        public string MA_THAMCHIEU { get; set; }

        [Column("CAN_CU")]
        [StringLength(500)]
        public string CAN_CU { get; set; }

        [Column("VALID")]
        public Nullable<int> VALID { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
