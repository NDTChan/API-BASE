using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Dm
{
    [Table("PHF_DM_DOTTHANHTRA")]
    public class PHF_DM_DOTTHANHTRA : BaseEntity
    {
        [Required]
        [Column("MA_DOT")]
        [StringLength(50)]
        [Description("Mã đợt")]
        public string MA_DOT { get; set; }

        [Required]
        [Column("TEN_DOT")]
        [StringLength(500)]
        [Description("Tên đợt")]
        public string TEN_DOT { get; set; }

        [Column("TU_NGAY")]
        [Description("Từ ngày")]
        public DateTime? TU_NGAY { get; set; }

        [Column("DEN_NGAY")]
        [Description("Đến ngày")]
        public DateTime? DEN_NGAY { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }
    }
}
