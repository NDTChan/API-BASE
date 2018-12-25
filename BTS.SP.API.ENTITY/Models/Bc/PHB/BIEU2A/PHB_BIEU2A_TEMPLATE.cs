using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2A
{
    [Table("PHB_BIEU2A_TEMPLATE")]
    public class PHB_BIEU2A_TEMPLATE:DataInfoEntity
    {
        [Description("Loại chỉ tiêu: 1 PHÍ , 2 LỆ PHÍ")]
        public int LOAI { get; set; }

        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã mục, tiểu mục")]
        [Required]
        [StringLength(4)]
        public string MA_NOIDUNGKT { get; set; }

        [Description("Tên mục, tiểu mục")]
        [Required]
        [StringLength(255)]
        public string TEN_NOIDUNGKT { get; set; }
    }
}
