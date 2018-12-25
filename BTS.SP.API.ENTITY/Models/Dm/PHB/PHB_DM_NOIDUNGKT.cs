using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.API.ENTITY;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_NOIDUNGKT")]
    public class PHB_DM_NOIDUNGKT:DataInfoEntity
    {
        [StringLength(4)]
        [Description("Mã nội dung kinh tế : mục/tiểu mục")]
        [Required]
        public string MA { get; set; }

        [StringLength(255)]
        [Required]
        [Description("Tên nội dung kinh tế : mục/tiểu mục")]
        public string TEN { get; set; }

        [StringLength(4)]
        public string MA_CHA { get; set; }

        [Required]
        [Description("Loại nội dung kinh tế : 0,1,2,3")]
        public int LOAI { get; set; }

        [Required]
        [Description("Cấp")]
        public int CAP { get; set; }

        [Required]
        [Description("Là chi tiết")]
        public int LA_CHITIET { get; set; }

        [StringLength(10)]
        [Description("Mã nhóm mục chi")]
        public string MA_NHOMMC { get; set; }

        [Description("Trạng thái sử dụng (true: Đang sử dụng; false: Không sử dụng)")]
        [Required]
        public bool TRANG_THAI { get; set; }
    }
}
