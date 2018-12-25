using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_THEODOI_CANBO")]
    public class PHF_THEODOI_CANBO : BaseEntity
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("TEN_PHIEU")]
        [StringLength(500)]
        public string TEN_PHIEU { get; set; }

        [Column("MA_DOITUONG")]
        [Description("Đơn vị báo cáo")]
        [StringLength(50)]
        public string MA_DOITUONG { get; set; }

        [Column("MA_PHONGBAN")]
        [Description("Mã phòng ban")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Column("NAM_THANHTRA")]
        public int? NAM_THANHTRA { get; set; }

        [Column("DOT_THANHTRA")]
        [StringLength(50)]
        public string DOT_THANHTRA { get; set; }
    }
}
