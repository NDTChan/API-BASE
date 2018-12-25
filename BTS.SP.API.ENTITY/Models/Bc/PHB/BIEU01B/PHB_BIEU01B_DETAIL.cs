using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01B
{
    [Table("PHB_BIEU01B_DETAIL")]
    public class PHB_BIEU01B_DETAIL : DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU01B")]
        [StringLength(50)]
        public string PHB_BIEU01B_REFID { get; set; }

        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu")]
        [Required]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu cũ")]      
        [StringLength(50)]
        public string MA_CHI_TIEU_OLD { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Số báo cáo")]
        public double SO_BC { get; set; }

        [Description("Số đối chiếu, kiểm tra")]
        public double SO_DCKT { get; set; }

        [Description("PHAN")]
        public int PHAN { get; set; }

        [Description("Cấp")]
        [Required]
        public int CAP { get; set; }

        [Description("Loại")]
        public int LOAI { get; set; }
    }
}
