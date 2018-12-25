using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU08TT344
{
    [Table("PHB_BIEU08TT344_DETAIL")]
    public class PHB_BIEU08TT344_DETAIL: DataInfoEntity
    {
        [Column("PHB_BIEU08TT344_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU08TT344_DETAIL")]
        [StringLength(50)]
        public string PHB_BIEU08TT344_REFID { get; set; }

        public int SAPXEP { get; set; }
        public int PHAN { get; set; }

        [Column("NOIDUNG")]
        [Description("Nội dung chỉ tiêu")]
        [StringLength(250)]
        public string NOIDUNG { get; set; }

        [Column("NOIDUNG_OLD")]
        [Description("Nội dung chỉ tiêu cũ")]
        [StringLength(250)]
        public string NOIDUNG_OLD { get; set; }

        [Column("MA_CHITIEU")]
        [Description("Mã chỉ tiêu")]
        [StringLength(20)]
        public string MA_CHITIEU { get; set; }

        public double DUTOAN_NSNN { get; set; }
        public double DUTOAN_NSX { get; set; }

        public double QUYETTOAN_NSNN { get; set; }
        public double QUYETTOAN_NSX { get; set; }

        public double SOSANH_NSNN { get; set; }
        public double SOSANH_NSX { get; set; }
    }
}
