using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_DONVIQUANLY")]
    public class PHE_DM_DONVIQUANLY : DataInfoEntity
    {
        [Required]
        [Column("MA")]
        [StringLength(50)]
        [Description("Mã")]
        public string MA { get; set; }

        [Required]
        [Column("TEN")]
        [StringLength(500)]
        [Description("Tên")]
        public string TEN { get; set; }

        [Column("MA_DVQHNS_CHA")]
        [StringLength(50)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS_CHA { get; set; }

        [Column("LOAI")]
        [StringLength(8)]
        [Description("LOẠI CHỦ ĐẦU TƯ BAN QUẢN LÝ HAY NHÀ THẦU")]
        public string LOAI { get; set; }

        [Column("MA_CAP")]
        [StringLength(50)]
        [Description("Cấp")]
        public string MA_CAP { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(500)]
        [Description("Chương")]
        public string MA_CHUONG { get; set; }

        [Column("MA_TINH")]
        [StringLength(50)]
        [Description("Tỉnh")]
        public string MA_TINH { get; set; }

        [Column("MA_HUYEN")]
        [StringLength(50)]
        [Description("Huyện")]
        public string MA_HUYEN { get; set; }

        [Column("MA_XA")]
        [StringLength(50)]
        [Description("Xã")]
        public string MA_XA { get; set; }

        [Column("FIELDNAME")]
        [StringLength(8)]
        [Description("PHÂN BIỆT LÀ ĐƠN VỊ HAY PHÒNG BAN")]
        public string FIELDNAME { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }

        [Column("PARENTID")]
        [Description("Mã cha")]
        public Nullable<int> PARENTID { get; set; }

        [Column("DIA_CHI")]
        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [Column("SDT")]
        [StringLength(20)]
        public string SDT { get; set; }

        [Column("FAX")]
        [StringLength(20)]
        public string FAX { get; set; }

        [Column("DONVI_SUDUNG")]
        public bool DONVI_SUDUNG { get; set; }

        [Column("SO_TAIKHOAN_1")]
        [StringLength(50)]
        public string SO_TAIKHOAN_1 { get; set; }

        [Column("SO_TAIKHOAN_2")]
        [StringLength(50)]
        public string SO_TAIKHOAN_2 { get; set; }

        [Column("SO_TAIKHOAN_3")]
        [StringLength(50)]
        public string SO_TAIKHOAN_3 { get; set; }

        [Column("MASOTHUE")]
        [StringLength(50)]
        public string MASOTHUE { get; set; }
    }
}
