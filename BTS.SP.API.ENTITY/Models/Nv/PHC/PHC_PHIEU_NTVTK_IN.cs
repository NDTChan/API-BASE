
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
    [Table("PHC_PHIEU_NTVTK_IN")]
    public class PHC_PHIEU_NTVTK_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string SO_CHUNGTU { get; set; }

        [Column("NGAY_HT")]
        [Description("lập ngày")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("MA_DVNT")]
        [StringLength(100)]
        [Description("mã đơn vị thanh toán")]
        public string MA_DVNT { get; set; }

        [Column("TEN_DVNT")]
        [StringLength(100)]
        [Description("tên đơn vị thanh toán")]
        public string TEN_DVNT { get; set; }

        [Column("MA_TKKB")]
        [StringLength(100)]
        [Description("tài khoản kb")]
        public string MA_TKKB { get; set; }

        [Column("DIA_CHI_DT")]
        [Description("địa chỉ")]
        [StringLength(100)]
        public string DIA_CHI_DT { get; set; }

        [Column("MA_DVSDNS")]
        [Description("của")]
        [StringLength(100)]
        public string MA_DVSDNS { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}

