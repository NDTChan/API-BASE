using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_NHAPSODUDETAILS")]
    public class PHC_NHAPSODUDETAILS : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("MACTMT")]
        [StringLength(20)]
        [Description("Mã CTMT")]
        public string MACTMT { get; set; }

        [Column("TAIKHOAN")]
        [StringLength(50)]
        [Description("Tài khoản")]
        public string TAIKHOAN { get; set; }

        [Column("NOI_DUNG_CHITIET")]
        [StringLength(500)]
        [Description("Nội dung Chi tiết")]
        public string NOI_DUNG_CHITIET { get; set; }

        [Column("TIEN_NSNN")]
        [Description("Tiền Ngân sách nhà nước")]
        public Nullable<decimal> TIEN_NSNN { get; set; }

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        [Column("MANGUON")]
        [StringLength(20)]
        [Description("Nguồn")]
        public string MANGUON { get; set; }

        [Column("MACHUONG")]
        [StringLength(20)]
        [Description("Chương")]
        public string MACHUONG { get; set; }

        [Column("MALOAI")]
        [StringLength(20)]
        [Description("Loại")]
        public string MALOAI { get; set; }

        [Column("MAKHOAN")]
        [StringLength(20)]
        [Description("Khoản")]
        public string MAKHOAN { get; set; }

        [Column("MAMUC")]
        [StringLength(20)]
        [Description("Mục")]
        public string MAMUC { get; set; }

        [Column("MATIEUMUC")]
        [StringLength(20)]
        [Description("Tiểu mục")]
        public string MATIEUMUC { get; set; }

        [Column("MATKKB")]
        [StringLength(20)]
        [Description("Mã TKKB")]
        public string MATKKB { get; set; }

        [Column("MADKTT")]
        [StringLength(20)]
        [Description("Mã ĐKTT")]
        public string MADKTT { get; set; }

        [Column("MADOITUONG")]
        [StringLength(20)]
        [Description("Mã ĐKTT")]
        public string MADOITUONG { get; set; }

        [Column("MAHOATDONG")]
        [StringLength(20)]
        [Description("Mã HOATDONG")]
        public string MAHOATDONG { get; set; }

        [Column("MALOAIXDCB")]
        [StringLength(20)]
        [Description("Mã LOAIXDCB")]
        public string MALOAIXDCB { get; set; }

        [Column("MATSCD")]
        [StringLength(20)]
        [Description("Mã TSCD")]
        public string MATSCD { get; set; }

        [Column("MAVATTU")]
        [StringLength(20)]
        [Description("Mã vật tư")]
        public string MAVATTU { get; set; }

        [Column("SOLUONG")]
        [Description("Số lượng")]
        public Nullable<decimal> SOLUONG { get; set; }

        [Column("DONGIA")]
        [Description("Giá")]
        public Nullable<decimal> DONGIA { get; set; }

        [Column("SOTIEN_NO")]
        [Description("Số tiền nợ")]
        public Nullable<decimal> SOTIEN_NO { get; set; }

        [Column("SOTIEN_CO")]
        [Description("Số tiền có")]
        public Nullable<decimal> SOTIEN_CO { get; set; }
    }
}
