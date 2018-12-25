using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHF
{
    [Table("PHF_DM_CANBO")]
    public class PHF_DM_CANBO : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_CANBO")]
        [StringLength(50)]
        [Description("Mã cán bộ ")]
        public string MA_CANBO { get; set; }

        [Required]
        [Column("TEN_CANBO")]
        [StringLength(500)]
        [Description("Tên cán bộ")]
        public string TEN_CANBO { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }

        [Column("MA_PHONG")]
        [StringLength(50)]
        [Description("Mã phòng ban của cán bộ")]
        public string MA_PHONG { get; set; }

        [Column("MA_CHUCVU")]
        [StringLength(50)]
        [Description("Mã chức vụ của cán bộ")]
        public string MA_CHUCVU { get; set; }

        [Column("GIOI_TINH")]
        [Description("Giới tính")]
        public int? GIOI_TINH { get; set; }

        [Column("NGAY_SINH")]
        [Description("Ngày sinh")]
        public DateTime? NGAY_SINH { get; set; }

        [Column("SO_PHONG")]
        [StringLength(50)]
        [Description("Số phòng")]
        public string SO_PHONG { get; set; }

        [Column("SO_MAY_LE")]
        [StringLength(50)]
        [Description("Số máy lẻ")]
        public string SO_MAY_LE { get; set; }

        [Column("SO_DI_DONG")]
        [StringLength(50)]
        [Description("Di động")]
        public string SO_DI_DONG { get; set; }
    }
}
