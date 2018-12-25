using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_BIENLAITHUDETAILS")]
    public class PHC_BIENLAITHUDETAILS : DataInfoEntity
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

        [Column("SO_BIENLAI")]
        [Description("Số biên lai")]
        [StringLength(50)]
        public string SO_BIENLAI { get; set; }

        [Column("TENHO_THU")]
        [Description("Tên hộ thu")]
        [StringLength(500)]
        public string TENHO_THU { get; set; }

        [Column("NOIDUNG_THU")]
        [Description("Nội dung thu")]
        [StringLength(500)]
        public string NOIDUNG_THU { get; set; }

        [Column("SOTIEN")]
        [Description("Số tiền")]
        public Nullable<decimal> SOTIEN { get; set; }

        [Column("NGAY_BIENLAI")]
        [Description("Ngày biên lai")]
        public Nullable<DateTime> NGAY_BIENLAI { get; set; }

        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }
    }
}
