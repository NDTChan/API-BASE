using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03C_X
{
    [Table("PHB_C_B03C_X_DETAIL")]
    public class PHB_C_B03C_X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B03C_X_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B03C_X")]
        [StringLength(50)]
        public string PHB_C_B03C_X_REFID { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Column("MA_CHI_TIEU")]
        [Description("Mã chỉ tiêu ")]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Column("MA_CHI_TIEU_CHA")]
        [Description("Mã chỉ tiêu cha")]
        [StringLength(15)]
        public string MA_CHI_TIEU_CHA { get; set; }

        [Column("TEN_CHI_TIEU")]
        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("LOAI")]
        [Description("Loại chỉ tiêu")]
        public int LOAI { get; set; }

        [Column("DT_TNSNN")]
        [Description("Dự toán-Thu ngân sách nhà nước")]
        public double DT_TNSNN { get; set; }

        [Column("DT_TNSX")]
        [Description("Dự toán-Thu ngân sách xã")]
        public double DT_TNSX { get; set; }

        [Column("QT_TNSNN")]
        [Description("Quyết toán-Thu ngân sách nhà nước")]
        public double QT_TNSNN { get; set; }

        [Column("QT_TNSX")]
        [Description("Quyết toán-Thu ngân sách xã")]
        public double QT_TNSX { get; set; }

        [Column("SAPXEP")]
        public int SAPXEP { get; set; }

        [Column("PHAN")]
        public int PHAN { get; set; }
    }
}
