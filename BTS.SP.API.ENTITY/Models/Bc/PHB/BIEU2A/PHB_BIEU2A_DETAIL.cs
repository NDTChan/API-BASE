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
    [Table("PHB_BIEU2A_DETAIL")]
    public class PHB_BIEU2A_DETAIL : DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU2A")]
        [StringLength(50)]
        public string PHB_BIEU2A_REFID { get; set; }

        [Required]
        [Description("Loại chỉ tiêu : 1 PHÍ, 2 LỆ PHÍ")]
        public int LOAI { get; set; }

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

        [Description("Mã chỉ tiêu : 1: Tổng thu, 2: Số phải nộp NSNN, 3:Số được khấu trừ để lại")]
        [Required]
        public int MA_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Dự toán ")]
        public double DU_TOAN { get; set; }

        [Description("Thực hiện")]
        public double THUC_HIEN { get; set; }

    }
}
