using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_HACHTOAN_CHI")]
    public class PHA_HACHTOAN_CHI: DataInfoEntity
    {
        [Column("SEGMENT1")]
        [StringLength(50)]
        [Description("Mã quý")]
        public string SEGMENT1 { get; set; }

        [Column("MA_TKTN")]
        [StringLength(50)]
        [Description("Mã tài khoản kế toán")]
        public string MA_TKTN { get; set; }

        [Column("TEN_TKTN")]
        [StringLength(2000)]
        [Description("Tên tài khoản tự nhiên")]
        public string TEN_TKTN { get; set; }


        [Column("MA_NHOM")]
        [StringLength(50)]
        [Description("Mã nhóm")]
        public string MA_NHOM { get; set; }

        [Column("TEN_NHOM")]
        [StringLength(2000)]
        [Description("Tên nhóm")]
        public string TEN_NHOM { get; set; }


        [Column("MA_TIEUNHOM")]
        [StringLength(50)]
        [Description("Mã tiểu nhóm")]
        public string MA_TIEUNHOM { get; set; }

        [Column("TEN_TIEUNHOM")]
        [StringLength(2000)]
        [Description("Tên tiểu nhóm")]
        public string TEN_TIEUNHOM { get; set; }


        [Column("MA_MUC")]
        [StringLength(50)]
        [Description("Mã mục")]
        public string MA_MUC { get; set; }

        [Column("TEN_MUC")]
        [StringLength(2000)]
        [Description("Tên mục")]
        public string TEN_MUC { get; set; }

        [Column("MA_TIEUMUC")]
        [StringLength(50)]
        [Description("Mã tiểu mục")]
        public string MA_TIEUMUC { get; set; }

        [Column("TEN_TIEUMUC")]
        [StringLength(2000)]
        [Description("Tên tiểu mục")]
        public string TEN_TIEUMUC { get; set; }

        [Column("MA_CAP")]
        [StringLength(50)]
        [Description("Mã cấp ngân sách")]
        public string MA_CAP { get; set; }

        [Column("TEN_CAP")]
        [StringLength(2000)]
        [Description("Tên cấp ngân sách")]
        public string TEN_CAP { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(2000)]
        [Description("Tên đơn vị quan hệ ngân sách")]
        public string TEN_DVQHNS { get; set; }

        [Column("MA_DIABAN")]
        [StringLength(50)]
        [Description("Mã địa bàn")]
        public string MA_DIABAN { get; set; }

        [Column("TEN_DIABAN")]
        [StringLength(2000)]
        [Description("Tên địa bàn")]
        public string TEN_DIABAN { get; set; }


        [Column("MA_CAPMLNS")]
        [StringLength(50)]
        [Description("Mã cấp mục lục ngân sách")]
        public string MA_CAPMLNS { get; set; }

        [Column("TEN_CAPMLNS")]
        [StringLength(2000)]
        [Description("Tên cấp mục lục ngân sách")]
        public string TEN_CAPMLNS { get; set; }


        [Column("MA_CHUONG")]
        [StringLength(50)]
        [Description("Mã chương")]
        public string MA_CHUONG { get; set; }

        [Column("TEN_CHUONG")]
        [StringLength(2000)]
        [Description("Tên chương")]
        public string TEN_CHUONG { get; set; }

        [Column("MA_NGANHKT")]
        [StringLength(50)]
        [Description("Mã nội dung ngành kinh tế")]
        public string MA_NGANHKT { get; set; }

        [Column("TEN_NGANHKT")]
        [StringLength(2000)]
        [Description("Tên ngành kinh tế")]
        public string TEN_NGANHKT { get; set; }

        [Column("MA_LOAI")]
        [StringLength(50)]
        [Description("Mã loại")]
        public string MA_LOAI { get; set; }


        [Column("TEN_LOAI")]
        [StringLength(2000)]
        [Description("Tên loại")]
        public string TEN_LOAI { get; set; }

        [Column("MA_CTMTQG")]
        [StringLength(50)]
        [Description("Mã chương trình mục tiêu, dự án và hạch toán chi tiết")]
        public string MA_CTMTQG { get; set; }

        [Column("TEN_CTMTQG")]
        [StringLength(2000)]
        [Description("Tên chương trình mục tiêu, dự án và hạch toán chi tiết")]
        public string TEN_CTMTQG { get; set; }

        [Column("MA_KBNN")]
        [StringLength(50)]
        [Description("Mã kho bạc nhà nước")]
        public string MA_KBNN { get; set; }

        [Column("TEN_KBNN")]
        [StringLength(2000)]
        [Description("Tên kho bạc nhà nước")]
        public string TEN_KBNN { get; set; }

        [Column("MA_NGUON_NSNN")]
        [StringLength(50)]
        [Description("Mã nguồn ngân sách nhà nước")]
        public string MA_NGUON_NSNN { get; set; }

        [Column("TEN_NGUON_NSNN")]
        [StringLength(2000)]
        [Description("Tên nguồn ngân sách nhà nước")]
        public string TEN_NGUON_NSNN { get; set; }

        [Column("SEGMENT12")]
        [StringLength(50)]
        [Description("Mã dự phòng")]
        public string SEGMENT12 { get; set; }

        [Column("SET_OF_BOOKS_ID")]
        [Description("Mã bộ sổ")]
        public int SET_OF_BOOKS_ID { get; set; }

        [Column("SOB_NAME")]
        [StringLength(30)]
        [Description("Tên bộ sổ")]
        public string SOB_NAME { get; set; }

        [Column("PERIOD_NAME")]
        [StringLength(50)]
        [Description("Kỳ tài chính")]
        public string PERIOD_NAME { get; set; }

        [Column("NGAY_KET_SO")]
        [Description("Ngày Post sổ")]
        public Nullable<DateTime> NGAY_KET_SO { get; set; }

        [Column("NGAY_HIEU_LUC")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HIEU_LUC { get; set; }

        [Column("ENTERED_DR")]
        [Description("Tổng PS nợ nguyên tệ")]
        public Nullable<decimal> ENTERED_DR { get; set; }

        [Column("ENTERED_CR")]
        [Description("Tổng PS có nguyên tệ")]
        public Nullable<decimal> ENTERED_CR { get; set; }

        [Column("ACCOUNTED_DR")]
        [Description("Tổng PS nợ bản tệ")]
        public Nullable<decimal> ACCOUNTED_DR { get; set; }

        [Column("ACCOUNTED_CR")]
        [Description("Tổng PS có bản tệ")]
        public Nullable<decimal> ACCOUNTED_CR { get; set; }

        [Column("ACTUAL_FLAG")]
        [StringLength(1)]
        [Description("Loại số dư:- B: Ngân sách- E: Dự chi- A: Thực")]
        public string ACTUAL_FLAG { get; set; }

        [Column("CURRENCY_CODE")]
        [StringLength(50)]
        [Description("Mã loại tiền")]
        public string CURRENCY_CODE { get; set; }

        [Column("TRANSFORM_DATE")]
        [Description("Ngày kết chuyển")]
        public DateTime TRANSFORM_DATE { get; set; }

        [Column("VOUCHER_DATE")]
        [Description("Ngày kết chuyển")]
        public DateTime VOUCHER_DATE { get; set; }

        [Column("ATTRIBUTE8")]
        [StringLength(15)]
        public string ATTRIBUTE8 { get; set; }

        [Column("MA_NGHIEPVU")]
        [StringLength(50)]
        [Description("Mã nghiệp vụ")]
        public string MA_NGHIEPVU { get; set; }

        [Column("GIA_TRI_HACH_TOAN")]
        [Description("Giá trị hạch toán")]
        public Nullable<decimal> GIA_TRI_HACH_TOAN { get; set; }

        [Column("MA_NVC")]
        [StringLength(50)]
        [Description("Mã nhiem vụ")]
        public string MA_NVC { get; set; }

        [Column("TEN_NVC")]
        [StringLength(500)]
        [Description("Ten nhiem vụ")]
        public string TEN_NVC { get; set; }
    }
}
