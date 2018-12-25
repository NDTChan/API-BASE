using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01A
{
    [Table("PHB_BIEU01A_DETAIL")]
    public class PHB_BIEU01A_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU01A")]
        [StringLength(50)]
        public string PHB_BIEU01A_REFID { get; set; }

        [Description("Mã mục, tiểu mục")]
        [StringLength(4)]
        [Required]
        public string MA_NOIDUNGKT { get; set; }

        [Description("Số thứ tự chỉ tiêu: 1.1,1.2,...")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Tên mục, tiểu mục")]
        [StringLength(255)]
        public string TEN_NOIDUNGKT { get; set; }

        [Description("Mã chỉ tiêu : 0: Tổng số, 1: Tổng thu, 2: Số phải nộp NSNN, 3:Số được khấu trừ để lại")]
        [Required]
        public int MA_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Dự toán : Số báo cáo")]
        public double DT_SOBAOCAO { get; set; }

        [Description("Dự toán: Số xét duyệt/TD")]
        public double DT_SOXDTD { get; set; }

        [Description("Thực hiện : Số báo cáo")]
        public double TH_SOBAOCAO { get; set; }

        [Description("Thực hiện: Số xét duyệt/TD")]
        public double TH_SOXDTD { get; set; }

        [Required]
        [Description("Loại chỉ tiêu : 1 PHÍ, 2 LỆ PHÍ")]
        public  int LOAI { get; set; }

    }
}
