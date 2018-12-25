using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_THANHTOAN_LUONG")]
    public class PHA_THANHTOAN_LUONG : DataInfoEntity
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Description("Mã địa bàn hành chính")]
        [StringLength(5)]
        public string MA_DBHC { get; set; }

        [Description("Mã địa bàn hành chính cha")]
        [StringLength(5)]
        public string MA_DBHC_CHA { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(10)]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DBHC")]
        [StringLength(255)]
        public string TEN_DBHC { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(255)]
        public string TEN_DVQHNS { get; set; }

        [StringLength(10)]
        public string MA_DVQHNS_CHA { get; set; }

        [Column("NAM")]
        [Required]
        public int NAM { get; set; }

        [Column("THANG")]
        [Required]
        public int THANG { get; set; }

        [Column("TRANG_THAI")]
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
