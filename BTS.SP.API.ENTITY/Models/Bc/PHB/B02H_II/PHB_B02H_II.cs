using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B02H_II
{
    [Table("PHB_B02H_II")]
    public class PHB_B02H_II : DataInfoEntity
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(3)]
        [Required]
        public string MA_CHUONG { get; set; }

        [Column("MA_QHNS")]
        [StringLength(10)]
        [Required]
        public string MA_QHNS { get; set; }

        [StringLength(255)]
        public string TEN_QHNS { get; set; }

        [StringLength(10)]
        public string MA_QHNS_CHA { get; set; }

        [Column("NAM_BC")]
        [Required]
        public int NAM_BC { get; set; }

        [Column("KY_BC")]
        [Required]
        [Description("0:Năm  | 101:Quý 1 | 102:Quý 2 | 103:Quý 3 | 104:Quý 4 | 201:6 tháng đầu năm | 202 : 6 tháng cuối năm")]
        public int KY_BC { get; set; }

        [Column("TRANG_THAI")]
        [Required]
        [Description("1: Đã duyệt | 0:chưa duyệt")]
        public int TRANG_THAI { get; set; }

        [Column("NGAY_TAO")]
        [Required]
        public DateTime NGAY_TAO { get; set; }

        [Column("NGUOI_TAO")]
        [StringLength(150)]
        [Required]
        public string NGUOI_TAO { get; set; }

        [Column("NGAY_SUA")]
        public DateTime? NGAY_SUA { get; set; }

        [Column("NGUOI_SUA")]
        [StringLength(150)]
        public string NGUOI_SUA { get; set; }
    }
}
