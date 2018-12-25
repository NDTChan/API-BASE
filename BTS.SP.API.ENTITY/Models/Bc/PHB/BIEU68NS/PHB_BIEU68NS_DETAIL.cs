using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU68NS
{
    public class PHB_BIEU68NS_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU68NS")]
        [StringLength(50)]
        public string PHB_BIEU68NS_REFID { get; set; }

        [Description("Số thứ tự chỉ tiêu")]
        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [Description("Mã chỉ tiêu")]
        [Required]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Description("Tên chỉ tiêu")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Description("Tổng số")]
        public double TONG_SO { get; set; }

        [Description("Dự phòng")]
        public double DU_PHONG { get; set; }

        [Description("Tăng thu")]
        public double TANG_THU { get; set; }

        [Description("Thưởng vượt dự toán thu")]
        public double THUONG_VUOT_DTTHU { get; set; }

        [StringLength(255)]
        public string GHI_CHU { get; set; }
    }
}
