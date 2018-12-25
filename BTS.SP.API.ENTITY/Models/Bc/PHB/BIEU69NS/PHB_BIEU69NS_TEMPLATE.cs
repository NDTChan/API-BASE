using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU69NS
{
    public class PHB_BIEU69NS_TEMPLATE:DataInfoEntity
    {
        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu")]
        [StringLength(50)]
        [Required]
        public string MA_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Loại : 0: không có chi tiết, 1: là chi tiết")]
        public int LOAI { get; set; }

        [Description("Thuộc phần: 1 - I, 2 - II,3 - III")]
        public int PHAN { get; set; }

        public int INDAM { get; set; }

        public int INNGHIENG { get; set; }
    }
}
