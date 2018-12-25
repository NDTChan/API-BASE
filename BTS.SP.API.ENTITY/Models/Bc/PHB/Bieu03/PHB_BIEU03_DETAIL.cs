using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.Bieu03
{
    [Table("PHB_BIEU03_DETAIL")]
    public class PHB_BIEU03_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU03")]
        [StringLength(50)]
        public string PHB_BIEU03_REFID { get; set; }

        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Required]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string MA_CHI_TIEU { get; set; }

        [Required]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(250)]
        public string TEN_CHI_TIEU { get; set; }
        public double DU_TOAN_NAM_TRUOC { get; set; }
        public double DU_TOAN_DUOC_GIAO { get; set; }
        public double DU_TOAN_DUOC_SU_DUNG { get; set; }

        public double QUYET_TOAN_NAM { get; set; }

        [Column("LOAI")]
        public int LOAI { get; set; }

        [Column("SAPXEP")]
        public int SAPXEP { get; set; }
    }
}
