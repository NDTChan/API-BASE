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
    [Table("PHC_DIEUCHINHKINHPHIDETAILS")]
    public class PHC_DIEUCHINHKINHPHIDETAILS : DataInfoEntity
    {
        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("MADANHMUC")]
        [StringLength(50)]
        [Description("Mã danh mục")]
        public string MADANHMUC { get; set; }

        [Column("TAIKHOAN")]
        [StringLength(50)]
        [Description("Tài khoản")]
        public string TAIKHOAN { get; set; }

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

        [Column("SOTIEN")]
        [Description("Số tiền")]
        public Nullable<decimal> SOTIEN { get; set; }

        [Column("TAIKHOAN_DIEUCHINH")]
        [StringLength(50)]
        [Description("Tài khoản")]
        public string TAIKHOAN_DIEUCHINH { get; set; }

        [Column("MACHUONG_DIEUCHINH")]
        [StringLength(20)]
        [Description("Chương")]
        public string MACHUONG_DIEUCHINH { get; set; }

        [Column("MALOAI_DIEUCHINH")]
        [StringLength(20)]
        [Description("Loại")]
        public string MALOAI_DIEUCHINH { get; set; }

        [Column("MAKHOAN_DIEUCHINH")]
        [StringLength(20)]
        [Description("Khoản")]
        public string MAKHOAN_DIEUCHINH { get; set; }

        [Column("MAMUC_DIEUCHINH")]
        [StringLength(20)]
        [Description("Mục")]
        public string MAMUC_DIEUCHINH { get; set; }

        [Column("MATIEUMUC_DIEUCHINH")]
        [StringLength(20)]
        [Description("Tiểu mục")]
        public string MATIEUMUC_DIEUCHINH { get; set; }

        [Column("SOTIEN_DIEUCHINH")]
        [Description("Số tiền điều chỉnh")]
        public Nullable<decimal> SOTIEN_DIEUCHINH { get; set; }
    }
}
