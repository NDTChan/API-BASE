using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03A_X
{
    [Table("PHB_C_B03A_X_DETAIL")]
    public class PHB_C_B03A_X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B03A_X_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B03A_X")]
        [StringLength(50)]
        public string PHB_C_B03A_X_REFID { get; set; }

        [Description("Mã Chương")]
        [StringLength(3)]
        public string MA_CHUONG { get; set; }

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

        [Description("Nội dung thu")]
        [StringLength(255)]
        public string NOI_DUNG_THU { get; set; }

        [Description("Nội dung thu old")]
        [StringLength(255)]
        public string NOI_DUNG_THU_OLD { get; set; }

        [Description("Số tiền")]
        public double SO_TIEN { get; set; }

        [Description("Lũy kế")]
        public double LUY_KE { get; set; }
    }
}
