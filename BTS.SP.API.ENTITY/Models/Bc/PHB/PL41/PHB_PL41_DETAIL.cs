using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.PL41
{
    [Table("PHB_PL41_DETAIL")]
    public class PHB_PL41_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_PL41")]
        [StringLength(50)]
        public string PHB_PL41_REFID { get; set; }
        [Description("Đơn vị")]
        [StringLength(255)]
        public string DON_VI { get; set; }

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

        [Description("Số dự toán")]
        public double SO_DUTOAN { get; set; }

        [Description("Số thực hiện")]
        public double SO_THUCHIEN { get; set; }
    }
}
