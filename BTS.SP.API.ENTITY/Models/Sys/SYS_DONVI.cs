using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_DONVI")]
    public class SYS_DONVI : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(30)]
        [Description("Mã cơ quan tài chính")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(500)]
        [Description("Tên cơ quan tài chính")]
        public string TEN { get; set; }

        [Column("MA_DVSDNS")]
        [StringLength(50)]
        [Description("Mã đơn vị sử dụng ngân sách")]
        public string MA_DVSDNS { get; set; }

        [Column("LOAI")]
        [Description("Loại (1- Cơ quan Tài chính cấp TW, 2 - CQ Tài chính cấp tỉnh, 3 – CQ Tài chính cấp quận huyện, 4 – CQ Tài chính cấp quận xã)")]
        public int LOAI { get; set; }

        [Column("ID_CAPTREN")]
        [Description("Id cơ quan tài chính cấp trên")]
        public int ID_CAPTREN { get; set; }

        [Column("MA_DIABAN")]
        [StringLength(50)]
        public string MA_DIABAN { get; set; }

        [Column("MA_CAPTREN")]
        [StringLength(50)]
        public string MA_CAPTREN { get; set; }

        [Column("MA_DTNT")]
        [StringLength(50)]
        public string MA_DTNT { get; set; }

        [Column("MA_T")]
        [StringLength(50)]
        public string MA_T { get; set; }

        [Column("MA_H")]
        [StringLength(50)]
        public string MA_H { get; set; }

        [Column("MA_X")]
        [StringLength(50)]
        public string MA_X { get; set; }

        [Column("VALID")]
        public int VALID { get; set; }

        [Column("NGAY_PS")]
        public DateTime NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("NGAY_HL")]
        public Nullable<DateTime> NGAY_HL { get; set; }

        [Column("NGAY_KT")]
        public Nullable<DateTime> NGAY_KT { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("CAN_CU")]
        [StringLength(500)]
        public string CAN_CU { get; set; }

    }
}
