
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
    [Table("PHC_PHIEU_UNT_IN")]
    public class PHC_PHIEU_UNT_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string SO_CHUNGTU { get; set; }

        [Column("DON_VI_BAN_HANG")]
        [StringLength(100)]
        [Description("đơn vị bán hàng")]
        public string DON_VI_BAN_HANG { get; set; }

        [Column("HOP_DONG")]
        [StringLength(100)]
        public string HOP_DONG { get; set; }

        [Column("KEM_THEO")]
        [StringLength(100)]
        public string KEM_THEO { get; set; }

        [Column("MA_DVNT")]
        [StringLength(100)]
        [Description("mã đơn vị thanh toán")]
        public string MA_DVNT { get; set; }

        [Column("NGAY_CHAM_TRA")]
        public string NGAY_CHAM_TRA { get; set; }

        [Column("SO_TIEN_PHAT")]
        [Description("số tiền phạt")]
        public Nullable<decimal> SO_TIEN_PHAT { get; set; }

        [Column("TONG_TIEN_CHUYEN")]
        [Description("số tiền phạt")]
        public Nullable<decimal> TONG_TIEN_CHUYEN { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}

