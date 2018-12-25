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
    [Table("PHC_CHUNGTUDETAILS")]
    public class PHC_CHUNGTUDETAILS : DataInfoEntity
    {
        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("SO chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Required]
        [Column("SO_CHUNGTU_DETAIL")]
        [StringLength(50)]
        [Description("Số chứng từ chi tiết")]
        public string SO_CHUNGTU_DETAIL{ get; set; }

        [Column("MACTMT_NO")]
        [StringLength(20)]
        [Description("Mã CTMT nợ")]
        public string MACTMT_NO { get; set; }

        [Column("MACTMT_CO")]
        [StringLength(20)]
        [Description("Mã CTMT CÓ")]
        public string MACTMT_CO { get; set; }

        [Column("MA_NGHIEPVU")]
        [StringLength(50)]
        [Description("Mã nghiệp vụ")]
        public string MA_NGHIEPVU { get; set; }

        [Column("TAIKHOAN_NO")]
        [StringLength(50)]
        [Description("Tài khoản nợ")]
        public string TAIKHOAN_NO { get; set; }

        [Column("TAIKHOAN_CO")]
        [StringLength(50)]
        [Description("Tài khoản có")]
        public string TAIKHOAN_CO { get; set; }
        
        [Column("SOTIEN")]
        [Description("Số tiền")]
        public Nullable<decimal> SOTIEN { get; set; }

        [Column("TIEN_NSNN")]
        [Description("Tiền Ngân sách nhà nước")]
        public Nullable<decimal> TIEN_NSNN { get; set; }

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        [Column("MANGUON_NO")]
        [StringLength(20)]
        [Description("Nguồn Nợ")]
        public string MANGUON_NO { get; set; }

        [Column("MANGUON_CO")]
        [StringLength(20)]
        [Description("Nguồn Có")]
        public string MANGUON_CO { get; set; }

        [Column("MACHUONG_NO")]
        [StringLength(20)]
        [Description("Chương nợ")]
        public string MACHUONG_NO { get; set; }

        [Column("MACHUONG_CO")]
        [StringLength(20)]
        [Description("Chương có")]
        public string MACHUONG_CO { get; set; }

        [Column("MALOAI_NO")]
        [StringLength(20)]
        [Description("Loại nợ")]
        public string MALOAI_NO { get; set; }

        [Column("MALOAI_CO")]
        [StringLength(20)]
        [Description("Loại có")]
        public string MALOAI_CO { get; set; }

        [Column("MAKHOAN_NO")]
        [StringLength(20)]
        [Description("Khoản nợ")]
        public string MAKHOAN_NO { get; set; }

        [Column("MAKHOAN_CO")]
        [StringLength(20)]
        [Description("Khoản có")]
        public string MAKHOAN_CO { get; set; }

        [Column("MAMUC_NO")]
        [StringLength(20)]
        [Description("Mục Nợ")]
        public string MAMUC_NO { get; set; }

        [Column("MAMUC_CO")]
        [StringLength(20)]
        [Description("Mục Có")]
        public string MAMUC_CO { get; set; }

        [Column("MATIEUMUC_NO")]
        [StringLength(20)]
        [Description("Tiểu mục Nợ")]
        public string MATIEUMUC_NO { get; set; }

        [Column("MATIEUMUC_CO")]
        [StringLength(20)]
        [Description("Tiểu mục Có")]
        public string MATIEUMUC_CO { get; set; }

        [Column("MATKKB_NO")]
        [StringLength(20)]
        [Description("Mã TKKB Nợ")]
        public string MATKKB_NO { get; set; }

        [Column("MATKKB_CO")]
        [StringLength(20)]
        [Description("Mã TKKB Có")]
        public string MATKKB_CO { get; set; }

        [Column("MADKTT_NO")]
        [StringLength(20)]
        [Description("Mã ĐKTT Nợ")]
        public string MADKTT_NO { get; set; }

        [Column("MADKTT_CO")]
        [StringLength(20)]
        [Description("Mã ĐKTT CÓ")]
        public string MADKTT_CO { get; set; }

        [Column("MADOITUONG_NO")]
        [StringLength(20)]
        [Description("Mã ĐKTT Nợ")]
        public string MADOITUONG_NO { get; set; }

        [Column("MADOITUONG_CO")]
        [StringLength(20)]
        [Description("Mã ĐKTT Có")]
        public string MADOITUONG_CO { get; set; }

        [Column("MAHOATDONG_NO")]
        [StringLength(20)]
        [Description("Mã HOATDONG nợ")]
        public string MAHOATDONG_NO { get; set; }

        [Column("MAHOATDONG_CO")]
        [StringLength(20)]
        [Description("Mã HOATDONG CÓ")]
        public string MAHOATDONG_CO { get; set; }

        [Column("MALOAIXDCB_NO")]
        [StringLength(20)]
        [Description("Mã LOAIXDCB nợ")]
        public string MALOAIXDCB_NO { get; set; }

        [Column("MALOAIXDCB_CO")]
        [StringLength(20)]
        [Description("Mã LOAIXDCB CÓ")]
        public string MALOAIXDCB_CO { get; set; }

        [Column("MATSCD_NO")]
        [StringLength(20)]
        [Description("Mã TSCD nợ")]
        public string MATSCD_NO { get; set; }

        [Column("MATSCD_CO")]
        [StringLength(20)]
        [Description("Mã TSCD CÓ")]
        public string MATSCD_CO { get; set; }

        [Column("MAVATTU_NO")]
        [StringLength(20)]
        [Description("Mã vật tư nợ")]
        public string MAVATTU_NO { get; set; }

        [Column("MAVATTU_CO")]
        [StringLength(20)]
        [Description("Mã Vật tư CÓ")]
        public string MAVATTU_CO { get; set; }

        [Column("SOLUONG")]
        [Description("Số lượng")]
        public Nullable<decimal> SOLUONG { get; set; }

        [Column("DONGIA")]
        [Description("Giá")]
        public Nullable<decimal> DONGIA { get; set; }

        [Column("NOP_THUE")]
        [Description("Tiền thuế")]
        public Nullable<decimal> NOP_THUE { get; set; }

    }
}
