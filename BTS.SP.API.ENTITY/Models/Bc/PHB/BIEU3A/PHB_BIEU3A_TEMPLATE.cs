using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU3A
{
    [Table("PHB_BIEU3A_TEMPLATE")]
    public class PHB_BIEU3A_TEMPLATE:DataInfoEntity
    {
        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu hiển thị 01 02 03 ....")]
        [StringLength(50)]
        public string MA_CHI_TIEU_HIEN_THI { get; set; }

        [Description("Mã chỉ tiêu phần mềm quản lý")]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu cha")]
        [StringLength(50)]
        public string MA_CHI_TIEU_CHA { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Công thức")]
        [StringLength(255)]
        public string CONG_THUC { get; set; }

        [Description("Cấp")]
        public int CAP { get; set; }

        [Description("Sắp xếp")]
        public int SAP_XEP { get; set; }

        [Description("Loại chỉ tiêu : 0 Chỉ tiêu có công thức , 1 Chỉ tiêu chi tiết, 2 Có chỉ tiêu con, 3 Chỉ tiêu con")]
        public int LOAI { get; set; }

        public int INDAM { get; set; }
        public int INNGHIENG { get; set; }
    }
}
