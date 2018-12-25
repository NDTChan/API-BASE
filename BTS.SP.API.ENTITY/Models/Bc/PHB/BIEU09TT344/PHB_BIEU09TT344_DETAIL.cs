using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU09TT344
{
    [Table("PHB_BIEU09TT344_DETAIL")]
    public class PHB_BIEU09TT344_DETAIL : DataInfoEntity
    {
        [Column("PHB_BIEU09TT344_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU09TT344")]
        [StringLength(50)]
        public string PHB_BIEU09TT344_REFID { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("MA_CHI_TIEU")]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }
        
        [Column("TEN_CHI_TIEU")]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("LOAI")]
        public int LOAI { get; set; }

        [Column("IN_DAM")]
        public int IN_DAM { get; set; }

        public double DT_TONGSO { get; set; }
        public double DT_DTPT { get; set; }
        public double DT_TX { get; set; }
        public double QT_TONGSO { get; set; }
        public double QT_DTPT { get; set; }
        public double QT_TX { get; set; }
        public double SS_TONGSO { get; set; }
        public double SS_DTPT { get; set; }
        public double SS_TX { get; set; }
    }
}
