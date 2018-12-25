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
    [Table("PHC_DOICHIEUSOLIEUDETAILS")]
    public class PHC_DOICHIEUSOLIEUDETAILS : DataInfoEntity
    {
        [Required]
        [Column("DVQHNS")]
        [StringLength(25)]
        [Description("Đơn vị quan hệ ngân sách")]
        public string DVQHNS { get; set; }

        [Column("LOAIDULIEU")]
        [StringLength(10)]
        [Description("Loại dữ liệu")]
        public string LOAIDULIEU { get; set; }

        [Column("MAQUY")]
        [StringLength(25)]
        [Description("Mã quỹ")]
        public string MAQUY { get; set; }

        [Column("MATAIKHOAN")]
        [StringLength(25)]
        [Description("Mã tài khoản")]
        public string MATAIKHOAN { get; set; }

        [Column("CAP")]
        [Description("Cấp")]
        public int CAP { get; set; }
       
        [Column("DBHC")]
        [StringLength(25)]
        [Description("Địa bàn hành chính")]
        public string DBHC { get; set; }

        [Column("CHUONG")]
        [StringLength(25)]
        [Description("Chương")]
        public string CHUONG { get; set; }

        [Column("LOAI")]
        [StringLength(25)]
        [Description("Loại")]
        public string LOAI { get; set; }

        [Column("KHOAN")]
        [StringLength(25)]
        [Description("Khoản")]
        public string KHOAN { get; set; }

        [Column("MUC")]
        [StringLength(25)]
        [Description("Mục")]
        public string MUC { get; set; }

        [Column("TIEUMUC")]
        [StringLength(25)]
        [Description("Tiểu mục")]
        public string TIEUMUC { get; set; }


        [Column("NHOM")]
        [StringLength(25)]
        [Description("Nhóm")]
        public string NHOM { get; set; }

        [Column("TIEUNHOM")]
        [StringLength(25)]
        [Description("Tiểu nhóm")]
        public string TIEUNHOM { get; set; }

        [Column("CTMT")]
        [StringLength(25)]
        [Description("Chương trình mục tiêu")]
        public string CTMT { get; set; }

        [Column("KBNN")]
        [StringLength(25)]
        [Description("Kho bạc nhà nước")]
        public string KBNN { get; set; }

        [Column("MANGUONVON")]
        [StringLength(25)]
        [Description("Mã nguồn vốn")]
        public string MANGUONVON { get; set; }

        [Column("LOAICHUNGTU")]
        [StringLength(25)]
        [Description("Loại chứng từ")]
        public string LOAICHUNGTU { get; set; }

        [Column("SOTIEN")]
        [Description("Số tiền")]
        public decimal SOTIEN { get; set; }

        [Column("NGAYPHATSINH")]
        [Description("Ngày phát sinh")]
        public Nullable<DateTime> NGAYPHATSINH { get; set; }

        [Column("TUNGAY_HIEULUC")]
        [Description("Từ ngày hiệu lực")]
        public Nullable<DateTime> TUNGAY_HIEULUC { get; set; }

        [Column("DENNGAY_HIEULUC")]
        [Description("Đến ngày hiệu lực")]
        public Nullable<DateTime> DENNGAY_HIEULUC { get; set; }

        [Column("KY")]
        [Description("Kỳ hạch toán")]
        public int KY { get; set; }

        [Column("NAM")]
        [Description("Năm")]
        public int NAM { get; set; }
    }
}
