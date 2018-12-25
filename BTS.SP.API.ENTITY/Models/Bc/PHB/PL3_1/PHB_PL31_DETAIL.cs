using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.PL3_1
{
    [Table("PHB_PL31_DETAIL")]
    public class PHB_PL31_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_PL31")]
        [StringLength(50)]
        public string PHB_PL31_REFID { get; set; }

        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu hiển thị 01 02 03 ....")]
        [StringLength(50)]
        public string MA_CHI_TIEU_HIEN_THI { get; set; }

        [Description("Mã chỉ tiêu phần mềm quản lý")]
        [Required]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Description("Loại chỉ tiêu : 0 Chỉ tiêu có công thức , 1 Chỉ tiêu chi tiết, 2 Có chỉ tiêu con, 3 Chỉ tiêu con")]
        public int LOAI { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu old")]
        [StringLength(255)]
        public string TEN_CHI_TIEU_OLD { get; set; }

        [Description("Dự toán : Số báo cáo")]
        public double DT_SOBC { get; set; }

        [Description("Dự toán: Số đối chiếu, kiểm tra")]
        public double DT_SODCKT { get; set; }

        [Description("Thực hiện : Số báo cáo")]
        public double TH_SOBC { get; set; }

        [Description("Thực hiện: Số đối chiếu, kiểm tra")]
        public double TH_SODCKT { get; set; }

    }
}
