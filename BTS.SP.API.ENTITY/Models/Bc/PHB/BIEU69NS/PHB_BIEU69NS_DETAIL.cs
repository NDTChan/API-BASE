using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU69NS
{
    public class PHB_BIEU69NS_DETAIL:DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong  PHB_BIEU69NS")]
        [StringLength(50)]
        public string PHB_BIEU69NS_REFID { get; set; }

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

        [Description("Mã chỉ tiêu cha")]
        [StringLength(50)]
        public string MA_CHI_TIEU_CHA { get; set; }

        [Description("Số kiến nghị của thanh tra")]
        public double SKN_THANHTRA { get; set; }

        [Description("Số kiến nghị của kiểm toán")]
        public double SKN_KIEMTOAN { get; set; }

        [Description("Số xử lý của thanh tra")]
        public double SXL_THANHTRA { get; set; }

        [Description("Số xử lý của kiểm toán")]
        public double SXL_KIEMTOAN { get; set; }

        [Description("Số tồn tại chưa xử lý của thanh tra")]
        public double SCXL_THANHTRA { get; set; }

        [Description("Số tồn tại chưa xử lý của kiểm toán")]
        public double SCXL_KIEMTOAN { get; set; }

        [StringLength(255)]
        public string GHI_CHU { get; set; }

        [Description("Loại : 0: không có chi tiết, 1: là chi tiết")]
        public int LOAI { get; set; }

        [Description("Thuộc phần: 1 - I, 2 - II,3 - III")]
        [StringLength(20)]
        public string PHAN { get; set; }
    }
}
