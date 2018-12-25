using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU10TT344
{
    [Table("PHB_BIEU10TT344_DETAIL")]
    public class PHB_BIEU10TT344_DETAIL : DataInfoEntity
    {
        [Column("PHB_BIEU10TT344_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU10TT344")]
        [StringLength(50)]
        public string PHB_BIEU10TT344_REFID { get; set; }

        [Column("STT_HIEN_THI")]
        [Description("STT hiển thị")]
        [StringLength(15)]
        public string STT_HIEN_THI { get; set; }

        [Column("MA_CHUONG")]
        [Description("Mã chương")]
        [StringLength(3)]
        public string MA_CHUONG { get; set; }

        [Column("MA_MUC")]
        [Description("Mã mục")]
        [StringLength(4)]
        public string MA_MUC { get; set; }

        [Column("MA_TIEU_MUC")]
        [Description("Mã tiểu mục")]
        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [Column("DIEN_GIAI")]
        [Description("Diễn giải")]
        [StringLength(255)]
        public string DIEN_GIAI { get; set; }

        public double QUYET_TOAN { get; set; }
    }
}
