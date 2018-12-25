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
    [Table("PHC_PHIEU_NHAPXUAT_KHO_IN")]
    public class PHC_PHIEU_NHAPXUAT_KHO_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("LOAI_PHIEU")]
        [StringLength(20)]
        [Description("Loại phiếu(N: phiếu nhập, X: phiếu xuất)")]
        public string LOAI_PHIEU { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("KHO_BAC")]
        [StringLength(300)]
        [Description("Kho bạc nhà nước")]
        public string KHO_BAC { get; set; }

        [Column("DON_VI")]
        [StringLength(100)]
        [Description("Đơn vị")]
        public string DON_VI { get; set; }

        [Column("LY_DO")]
        [StringLength(2000)]
        [Description("Lý do nhập/xuất")]
        public string LY_DO { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}
