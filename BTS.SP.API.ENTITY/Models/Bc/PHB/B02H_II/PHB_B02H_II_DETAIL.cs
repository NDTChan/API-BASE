using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B02H_II
{
    [Table("PHB_B02H_II_DETAIL")]
    public class PHB_B02H_II_DETAIL: DataInfoEntity
    {
        [Column("PHB_B02H_II_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B02H_II")]
        [StringLength(50)]
        public string PHB_B02H_II_REFID { get; set; }

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

        public int MA_SO { get; set; }

        public double TONG_SO { get; set; }
        public double NSNN_TONG_SO { get; set; }
        public double NSNN_NSNN_GIAO { get; set; }
        public double NSNN_PHI_LEPHI { get; set; }
        public double NSNN_VIEN_TRO { get; set; }
        public double NGUON_KHAC { get; set; }
    }
}
