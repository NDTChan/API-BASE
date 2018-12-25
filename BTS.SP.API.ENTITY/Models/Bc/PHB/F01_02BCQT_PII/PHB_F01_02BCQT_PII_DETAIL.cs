using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.F01_02BCQT_PII
{
    [Table("PHB_F01_02BCQT_PII_DETAIL")]
    public class PHB_F01_02BCQT_PII_DETAIL:DataInfoEntity
    {
        [Description("Guid ID trong  PHB_F01_02BCQT_PII")]
        [StringLength(50)]
        [Required]

        public string PHB_F01_02BCQT_PII_REFID { get; set; }

        [Description("NOI_DUNG_CHI")]
        [StringLength(255)]
        [Required]
        public string NOI_DUNG_CHI { get; set; }

        [Description("Mã loại")]
        [StringLength(3)]
        public string MA_LOAI { get; set; }

        [Description("Mã khoản")]
        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [Description("Mã mục")]
        [StringLength(4)]
        public string MA_MUC { get; set; }

        [Description("Mã tiểu mục")]
        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [Description("Tổng số năm nay")]
        public double TONG_SO_NAM_NAY { get; set; }

        [Description("Ngân sách nhà nước trong nước năm nay")]
        public double NSNN_TRONGNUOC_NAM_NAY { get; set; }

        [Description("Viện trợ năm nay")]
        public double VIEN_TRO_NAM_NAY { get; set; }

        [Description("Vay nợ nước ngoài năm nay")]
        public double VAYNO_NUOCNGOAI_NAM_NAY { get; set; }

        [Description("Tổng số lũy kế")]
        public double TONG_SO_LUY_KE { get; set; }

        [Description("Ngân sách nhà nước trong nước lũy kế")]
        public double NSNN_TRONGNUOC_LUY_KE { get; set; }

        [Description("Viện trợ lũy kế")]
        public double VIEN_TRO_LUY_KE { get; set; }

        [Description("Vay nợ nước ngoài lũy kế")]
        public double VAYNO_NUOCNGOAI_LUY_KE { get; set; }

        [Description("Loại nội dung chi")]
        public int LOAI { get; set; }
    }
}
