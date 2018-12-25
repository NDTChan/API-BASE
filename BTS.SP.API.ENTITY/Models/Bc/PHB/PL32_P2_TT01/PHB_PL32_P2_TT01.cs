using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.PHB_PL32_P2_TT01
{
    public class PHB_PL32_P2_TT01 : DataInfoEntity
    {
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Required]
        [StringLength(3)]
        public string MA_CHUONG { get; set; }

        [Required]
        [StringLength(10)]
        public string MA_QHNS { get; set; }

        [StringLength(255)]
        public string TEN_QHNS { get; set; }

        [StringLength(10)]
        public string MA_QHNS_CHA { get; set; }

        public int NAM_BC { get; set; }

        [Description("0:Năm  | 101:Quý 1 | 102:Quý 2 | 103:Quý 3 | 104:Quý 4 | 201:6 tháng đầu năm | 202 : 6 tháng cuối năm")]
        public int KY_BC { get; set; }

        [Description("1: Đã duyệt | 0:chưa duyệt")]
        public int TRANG_THAI { get; set; }

        public DateTime NGAY_TAO { get; set; }

        [Required]
        [StringLength(150)]
        public string NGUOI_TAO { get; set; }

        public DateTime? NGAY_SUA { get; set; }

        [StringLength(150)]
        public string NGUOI_SUA { get; set; }

    }
}
