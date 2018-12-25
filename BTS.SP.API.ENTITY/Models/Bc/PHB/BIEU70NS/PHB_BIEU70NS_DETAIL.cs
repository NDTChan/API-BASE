
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU70NS
{
    public class PHB_BIEU70NS_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU70NS")]
        [StringLength(50)]
        public string PHB_BIEU70NS_REFID { get; set; }

        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu")]
        [Required]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(1000)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Số tiền năm trước, năm liền kề")]
        public double SO_TIEN_NT { get; set; }

        [Description("Số tiền năm báo cáo")]
        public double SO_TIEN_NBC { get; set; }

        [Description("Giải trình")]
        [StringLength(2000)]
        public string GIAI_TRINH { get; set; }
    }
}
