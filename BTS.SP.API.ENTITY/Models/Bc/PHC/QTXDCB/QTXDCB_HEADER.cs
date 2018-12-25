using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Bc.PHC.QTXDCB
{
    [Table("PHC_QTXDCB_HEADER")]
    public class QTXDCB_HEADER : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("TUNGAY")]
        [Description("Từ ngày")]
        public Nullable<DateTime> TUNGAY { get; set; }

        [Column("DENNGAY")]
        [Description("Đến ngày")]
        public Nullable<DateTime> DENNGAY { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("TINH")]
        [StringLength(200)]
        public string TINH { get; set; }

        [Column("HUYEN")]
        [StringLength(200)]
        public string HUYEN { get; set; }

        [Column("XA")]
        [StringLength(200)]
        public string XA { get; set; }
    }
}
