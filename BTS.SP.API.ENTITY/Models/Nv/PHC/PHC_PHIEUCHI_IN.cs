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
    [Table("PHC_PHIEUCHI_IN")]
    public class PHC_PHIEUCHI_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("DON_VI")]
        [StringLength(100)]
        [Description("Đơn vị")]
        public string DON_VI { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(10)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("TK_NO")]
        [StringLength(5)]
        [Description("Tài Khoản nợ")]
        public string TK_NO { get; set; }

        [Column("TK_CO")]
        [StringLength(5)]
        [Description("Tài Khoản có")]
        public string TK_CO { get; set; }

        [Column("HO_TEN")]
        [StringLength(100)]
        [Description("Họ và tên người nhận tiền")]
        public string HO_TEN { get; set; }

        [Column("DIA_CHI")]
        [StringLength(300)]
        [Description("Địa chỉ")]
        public string DIA_CHI { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOI_DUNG { get; set; }

        [Column("SO_TIEN")]
        [Description("Số tiền nộp")]
        public Nullable<decimal> SO_TIEN { get; set; }

        [Column("LOAI_TIEN")]
        [StringLength(200)]
        [Description("Loại tiền")]
        public string LOAI_TIEN { get; set; }

        [Column("KEM_THEO")]
        [StringLength(500)]
        [Description("Kèm theo")]
        public string KEM_THEO { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}
