using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B02BCTC
{
    [Table("PHB_B02BCTC_DETAIL")]
    public class PHB_B02BCTC_DETAIL : DataInfoEntity
    {
        [Column("PHB_B02BCTC_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B02BCTC")]
        [StringLength(50)]
        public string PHB_B02BCTC_REFID { get; set; }

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

        [Column("PHAN")]
        public int PHAN { get; set; }

        public double THUYET_MINH { get; set; }

        public double NAM_NAY { get; set; }

        public double NAM_TRUOC { get; set; }



    }
}
