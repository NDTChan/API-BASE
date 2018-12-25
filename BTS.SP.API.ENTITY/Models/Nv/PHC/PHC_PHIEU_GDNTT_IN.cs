using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_PHIEU_GDNTT_IN")]
    public class PHC_PHIEU_GDNTT_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("BO_PHAN")]
        [StringLength(50)]
        [Description("bộ phận")]
        public string BO_PHAN { get; set; }

        [Column("MA_DVSDNS")]
        [StringLength(100)]
        [Description("Mã đơn vị")]
        public string MA_DVSDNS { get; set; }

        [Column("NGAY_THANG_NAM")]
        [Description("ngày tháng năm")]
        public Nullable<DateTime> NGAY_THANG_NAM { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(100)]
        public string SO_CHUNGTU { get; set; }

        [Column("KINH_GUI")]
        [StringLength(100)]
        public string KINH_GUI { get; set; }

        [Column("NGUOI_DE_NGHI")]
        [StringLength(100)]
        [Description("NGUOI_DE_NGHI")]
        public string NGUOI_DE_NGHI { get; set; }

        [Column("BO_PHAN_TT")]
        [StringLength(100)]
        [Description("BO_PHAN_TT")]
        public string BO_PHAN_TT { get; set; }      

        [Column("NOI_DUNG")]
        [StringLength(100)]
        [Description("NOI_DUNG")]
        public string NOI_DUNG { get; set; }

        [Column("SO_TIEN")]
        [Description("SO_TIEN")]
        public Nullable<decimal> SO_TIEN { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }


    }
}
