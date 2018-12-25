using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B02HP1
{
    [Table("PHB_B02HP1_DETAIL")]
    public class PHB_B02HP1_DETAIL:DataInfoEntity
    {
        [Column("PHB_B02HP1_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B02HP1")]
        [StringLength(50)]
        public string PHB_B02HP1_REFID { get; set; }

        [Column("MA_NGUONNS")]
        [Required]
        [StringLength(15)]
        public string MA_NGUONNS { get; set; }

        [Column("MA_CTMT")]
        [StringLength(15)]
        [Description("Mã chương trình mục tiêu")]
        public string MA_CTMT { get; set; }

        [Column("MA_LOAI")]
        [StringLength(15)]
        [Required]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(15)]
        [Required]
        public string MA_KHOAN { get; set; }

        [Column("MA_LOAINS")]
        [StringLength(15)]
        [Required]
        public string MA_LOAINS { get; set; }

        [Column("MA_CHI_TIEU")]
        [StringLength(15)]
        [Required]
        public string MA_CHI_TIEU { get; set; }

        [Column("TEN_CHI_TIEU")]
        [StringLength(150)]
        [Required]
        public string TEN_CHI_TIEU { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [Required]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("SO_TIEN")]
        public decimal SO_TIEN { get; set; }

        [Column("CONG_THUC")]
        [StringLength(250)]
        public string CONG_THUC { get; set; }
    }
}
