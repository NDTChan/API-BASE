using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU11TT344
{
    [Table("PHB_BIEU11TT344_DETAIL")]
    public class PHB_BIEU11TT344_DETAIL: DataInfoEntity
    {
        [Column("PHB_BIEU11TT344_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU11TT344")]
        [StringLength(50)]
        public string PHB_BIEU11TT344_REFID { get; set; }

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

        [Description("Diễn giải")]
        [StringLength(255)]
        [Required]
        public string DIEN_GIAI { get; set; }

        [Description("Quyết toán")]
        public double QUYET_TOAN { get; set; }
    }
}
