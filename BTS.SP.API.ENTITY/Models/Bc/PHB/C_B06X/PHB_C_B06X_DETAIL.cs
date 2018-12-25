using BTS.SP.API.ENTITY;
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
    [Table("PHB_C_B06X_DETAIL")]
    public class PHB_C_B06X_DETAIL : DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong PHB_C_B06X")]
        [StringLength(50)]
        public string PHB_C_B06X_REFID { get; set; }

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

        [Description("Tên chỉ tiêu cũ")]
        [StringLength(250)]
        public string TEN_CHITIEU_OLD { get; set; }

        [Description("Số dư đầu kỳ")]
        public double SDDK { get; set; }

        [Description("Tổng thu")]
        public double TONG_THU { get; set; }

        [Description("Tổng chi")]
        public double TONG_CHI { get; set; }

        [Description("Số còn lại")]
        public double CON_LAI { get; set; }
        
    }
}
