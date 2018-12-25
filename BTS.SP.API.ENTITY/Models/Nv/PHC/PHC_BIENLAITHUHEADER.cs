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
    [Table("PHC_BIENLAITHUHEADER")]
    public class PHC_BIENLAITHUHEADER : DataInfoEntityPHC
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

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        [Column("TONGTIEN")]
        [Description("Tổng tiền")]
        public Nullable<decimal> TONGTIEN { get; set; }

        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("FILE_NAME")]
        [StringLength(300)]
        [Description("File đính kèm")]
        public string FILE_NAME { get; set; }
    }
}
