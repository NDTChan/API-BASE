using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.PHF.ENTITY.Dm
{
    [Table("PHF_DM_DONVI_PHONGBAN")]
    public class PHF_DM_DONVI_PHONGBAN : BaseEntity
    {
        [Required]
        [Column("MA")]
        [StringLength(50)]
        [Description("Mã")]
        public string MA { get; set; }

        [Column("MA_CHA")]
        [Description("Mã cha")]
        [StringLength(50)]
        public string MA_CHA { get; set; }

        [Required]
        [Column("TEN")]
        [StringLength(500)]
        [Description("Tên")]
        public string TEN { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("LOAI")]
        [StringLength(8)]
        [Description("LOẠI ĐƠN VỊ THANH TRA : THUỘC BỘ HAY KHÔNG THUỘC BỘ")]
        public string LOAI { get; set; }

        [Column("FIELDNAME")]
        [StringLength(8)]
        [Description("PHÂN BIỆT LÀ ĐƠN VỊ HAY PHÒNG BAN")]
        public string FIELDNAME { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANGTHAI { get; set; }

        [Column("MADONVI")]
        [StringLength(50)]
        [Description("Mã đơn vị -- sử dụng phân tách dữ liệu")]
        public string MADONVI { get; set; }
    }
}
