using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03B_X
{
    [Table("PHB_C_B03B_X_DETAIL")]
    public class PHB_C_B03B_X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B03B_X_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B03B_X")]
        [StringLength(50)]
        public string PHB_C_B03B_X_REFID { get; set; }

        [Description("Mã Chương")]
        [StringLength(3)]
        public string MA_CHUONG { get; set; }

        [Description("Mã ngành kinh tế")]
        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [Description("Mã tiểu mục")]
        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [Description("Nội dung chi")]
        [StringLength(255)]
        public string NOI_DUNG_CHI { get; set; }

        [Description("Nội dung chi old")]
        [StringLength(255)]
        public string NOI_DUNG_CHI_OLD { get; set; }

        [Description("Số tiền")]
        public double SO_TIEN { get; set; }

        [Column("LOAI")]
        public int LOAI { get; set; }

        [Column("PHAN")]
        [StringLength(20)]
        public string PHAN { get; set; }
    }
}
