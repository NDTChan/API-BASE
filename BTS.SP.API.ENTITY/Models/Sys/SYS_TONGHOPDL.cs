using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_TONGHOPDL")]
    public class SYS_TONGHOPDL : DataInfoEntity
    {
        [Column("LOAI_DULIEU")]
        [StringLength(20)]
        [Description("Loại dữ liệu")]
        public string LOAI_DULIEU { get; set; }

        [Column("SO_BANGHI")]
        [Description("Số bản ghi đã tổng hợp")]
        public Nullable<long> SO_BANGHI { get; set; }

        [Column("TU_NGAY")]
        [Description("Tổng hợp từ ngày")]
        public Nullable<DateTime> TU_NGAY { get; set; }

        [Column("DEN_NGAY")]
        [Description("Tổng hợp đến ngày")]
        public Nullable<DateTime> DEN_NGAY { get; set; }

        [Column("NGAY_TONGHOP")]
        [Description("Ngày tổng hợp")]
        public Nullable<DateTime> NGAY_TONGHOP { get; set; }

        [Column("NGUOI_TONGHOP")]
        [StringLength(200)]
        [Description("Người tổng hợp")]
        public string NGUOI_TONGHOP { get; set; }
    }
}
