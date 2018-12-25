using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B06X
{
    [Table("PHB_C_B06X_TEMPLATE")]
    public class PHB_C_B06X_TEMPLATE : DataInfoEntity
    {
        [Description("Loại tài khoản: 1 - Quỹ công chuyên dụng , 2 - Hoạt động sự nghiệp, 3 - Hoạt động TC khác")]
        public int LOAI { get; set; }

        [Description("Số thứ tự chỉ tiêu: 1.1,1.2,...")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu")]
        [Required]
        [StringLength(20)]
        public string MA_CHITIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [Required]
        [StringLength(250)]
        public string TEN_CHITIEU { get; set; }

    }
}
