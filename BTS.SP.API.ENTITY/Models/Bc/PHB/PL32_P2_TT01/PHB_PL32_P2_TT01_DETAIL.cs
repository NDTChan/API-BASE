using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.PHB_PL32_P2_TT01
{
    public class PHB_PL32_P2_TT01_DETAIL : DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHB_PL32_P2_TT01_REFID { get; set; }

        [StringLength(3)]
        public string MA_LOAI { get; set; }

        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [StringLength(4)]
        public string MA_MUC { get; set; }

        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [StringLength(255)]
        public string NOI_DUNG_CHI { get; set; }

        public double TS_SOBC { get; set; }
        public double TS_SOXDTD { get; set; }

        public double NSTN_SOBC { get; set; }
        public double NSTN_SOXDTD { get; set; }

        public double PHI_SOBC { get; set; }
        public double PHI_SOXDTD { get; set; }

        public double VT_SOBC { get; set; }
        public double VT_SOXDTD { get; set; }

        public double VN_SOBC { get; set; }
        public double VN_SOXDTD { get; set; }

        [Description("Nguồn hoạt động khác để lại - Số báo cáo")]
        public double HDKDL_SOBC { get; set; }
        [Description("Nguồn hoạt động khác để lại - Số xét duyệt/Thẩm định")]
        public double HDKDL_SOXDTD { get; set; }

    }
}
