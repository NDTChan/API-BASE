
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_PHIEU_RVDT_IN")]
    public class PHC_PHIEU_RVDT_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string SO_CHUNGTU { get; set; }
        
        [Column("TEN_DA")]
        [StringLength(200)]
        public string TEN_DA { get; set; }

        [Column("TAI_KHOANKB")]
        [StringLength(20)]
        [Description("Tài khoản kho bạc")]
        public string TAI_KHOANKB { get; set; }


        [Column("TEN_CDT")]
        [StringLength(100)]
        [Description("Tên chủ đầu tư")]
        public string TEN_CDT { get; set; }

        [Column("NGAY_CKCHDK")]
        public Nullable<DateTime> NGAY_CKCHDK { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(10)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("TONG_TIEN")]
        [Description("Tổng tiền")]
        public Nullable<decimal> TONG_TIEN { get; set; }

        [Column("QUYEN_SO")]
        [StringLength(20)]
        [Description("Quyển số")]
        public string QUYEN_SO { get; set; }

        [Column("MA_DVNT")]
        [StringLength(10)]
        [Description("Mã đơn vị nộp thuế")]
        public string MA_DVNT { get; set; }

        [Column("MST")]
        [StringLength(5)]
        [Description("Mã số thuế")]
        public string MST { get; set; }

        [Column("MA_NDKT")]
        [StringLength(5)]
        [Description("Mã nội dung kinh tế")]
        public string MA_NDKT { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(5)]
        [Description("Mã chương")]
        public string MA_CHUONG { get; set; }

        [Column("MA_CQT")]
        [StringLength(10)]
        [Description("Mã cơ quan thu")]
        public string MA_CQT { get; set; }

        [Column("CQQL")]
        [StringLength(10)]
        [Description("Cơ quan quản lý")]
        public string CQQL { get; set; }

        [Column("MA_KBHTT")]
        [StringLength(10)]
        [Description("Mã kho bạc hạch toán thu")]
        public string MA_KBHTT { get; set; }

        [Column("TEN_KBHTT")]
        [StringLength(10)]
        [Description("Tên kho bạc hạch toán thu")]
        public string TEN_KBHTT { get; set; }

        [Column("TIEN_THUE")]
        [Description("Tiền thuế")]
        public Nullable<decimal> TIEN_THUE { get; set; }

        [Column("DV_NHANTIEN")]
        [StringLength(100)]
        [Description("Đơn vị nhận tiền")]
        public string DV_NHANTIEN { get; set; }

        [Column("DIA_CHI_DVH")]
        [StringLength(200)]
        [Description("Địa chỉ ĐV nhận tiền")]
        public string DIA_CHI_DVH { get; set; }

        [Column("TAI_KHOAN_DVH")]
        [StringLength(20)]
        [Description("Tài khoản ĐVN")]
        public string TAI_KHOAN_DVH { get; set; }

        [Column("MA_CTMT_DVH")]
        [StringLength(20)]
        [Description("Mã CMND")]
        public string MA_CTMT_DVH { get; set; }

        [Column("MA_DA")]
        [StringLength(20)]
        [Description("Mã dự án")]
        public string MA_DA { get; set; }

        [Column("MA_HTCT")]
        [StringLength(20)]
        [Description("MA_HTCT")]
        public string MA_HTCT { get; set; }

        [Column("MA_CMND_NL")]
        [StringLength(20)]
        [Description("MA_CMND_NL")]
        public string MA_CMND_NL { get; set; }

        [Column("NGAY_CAP_NL")]
        [Description("Ngày cấp")]
        public Nullable<DateTime> NGAY_CAP_NL { get; set; }

        [Column("NOI_CAP_NL")]
        [StringLength(200)]
        [Description("NOI_CAP_NL")]
        public string NOI_CAP_NL { get; set; }

        [Column("TONG_TIENTT_DVH")]
        [Description("Tổng tiền đơn vị hưởng")]
        public Nullable<decimal> TONG_TIENTT_DVH { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}

