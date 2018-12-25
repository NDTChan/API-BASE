using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Sys
{
    [Table("PHF_SYS_TUDIEN")]
    public class PHF_SYS_TUDIEN : BaseEntity
    {
        [Column("MA_TUDIEN")]
        [StringLength(50)]
        [Required]
        [Description("Mã test")]
        public string MA_TUDIEN{ get; set; }

        [Column("MA_TUDIEN_CHA")]
        [StringLength(50)]
        [Description("Mã test")]
        public string MA_TUDIEN_CHA { get; set; }

        [Column("TEN_TUDIEN")]
        [StringLength(500)]
        [Required]
        [Description("Tên test")]
        public string TEN_TUDIEN{ get; set; }

        [Column("LOAI_TUDIEN")]
        [StringLength(50)]
        [Description("Mã test")]
        [Required]
        public string LOAI_TUDIEN { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public int TRANG_THAI { get; set; }

        [Column("MA_DONVI")]
        [Description("Mã đơn vị")]
        public string MA_DONVI { get; set; }

        [Column("MA_PHONGBAN")]
        [Description("Mã phòng ban")]
        public string MA_PHONGBAN { get; set; }
    }
}
