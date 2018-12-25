using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU67NS
{
    public class PHB_BIEU67NS_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU67NS")]
        [StringLength(50)]
        public string PHB_BIEU67NS_REFID { get; set; }

        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu")]
        [Required]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Tổng số")]
        public double TONG_SO { get; set; }

        [Description("NS cấp tỉnh")]
        public double NS_TINH { get; set; }

        [Description("NS cấp huyện")]
        public double NS_HUYEN { get; set; }

        [Description("NS cấp xã")]
        public double NS_XA { get; set; }
    }
}
