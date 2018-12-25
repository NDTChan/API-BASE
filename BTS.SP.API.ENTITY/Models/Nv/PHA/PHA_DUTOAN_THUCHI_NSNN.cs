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
    [Table("PHA_DUTOAN_THUCHI_NSNN")]
    public class PHA_DUTOAN_THUCHI_NSNN : DataInfoEntity
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(10)]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DBHC")]
        [StringLength(255)]
        public string TEN_DBHC { get; set; }

        [Column("MA_BAOCAO")]
        [StringLength(20)]
        [Required]
        public string MA_BAOCAO { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(255)]
        public string TEN_DVQHNS { get; set; }

        [StringLength(10)]
        public string MA_DVQHNS_CHA { get; set; }

        [Column("NAM_DUTOAN")]
        [Required]
        public int NAM_DUTOAN { get; set; }

        [Column("LOAI_DUTOAN")]
        [StringLength(25)]
        [Required]
        public string LOAI_DUTOAN { get; set; }

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

        [Description("Mã địa bàn hành chính")]
        [StringLength(5)]
        public string MA_DBHC { get; set; }

        [Description("Mã địa bàn hành chính cha")]
        [StringLength(5)]
        public string MA_DBHC_CHA { get; set; }

        [Description("Cấp")]
        [StringLength(10)]
        public string CAP { get; set; }

        [Description("Loại")]
        [StringLength(10)]
        public string LOAI { get; set; }
    }
}
