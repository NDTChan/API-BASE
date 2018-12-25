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
    [Table("PHC_PHIEUTHU_IN")]
    public class PHC_PHIEUTHU_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }      

        [Column("DON_VI")]
        [StringLength(100)]
        [Description("Đơn vị")]
        public string DON_VI { get; set; }

        [Column("BO_PHAN")]
        [StringLength(50)]
        [Description("Bộ phận")]
        public string BO_PHAN { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(10)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("QUYEN_SO")]
        [StringLength(20)]
        [Description("Quyển số")]
        public string QUYEN_SO { get; set; }

        [Column("MA_SO_PHIEU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string MA_SO_PHIEU { get; set; }

        [Column("TK_NO")]
        [StringLength(5)]
        [Description("Tài Khoản nợ")]
        public string TK_NO { get; set; }

        [Column("TK_CO")]
        [StringLength(5)]
        [Description("Tài Khoản có")]
        public string TK_CO { get; set; }

        [Column("NGUOI_NOP")]
        [StringLength(100)]
        [Description("Người nộp tiền")]
        public string NGUOI_NOP { get; set; }

        [Column("DIA_CHI")]
        [Description("Địa chỉ")]
        public string DIA_CHI { get; set; }

        [Column("SO_TIEN")]
        [Description("Số tiền nộp")]
        public Nullable<decimal> SO_TIEN { get; set; }

        [Column("KEM_THEO")]
        [StringLength(200)]
        [Description("Kèm theo")]
        public string KEM_THEO { get; set; }

        [Column("THU_TRUONG")]
        [StringLength(100)]
        [Description("Thủ trưởng đơn vị")]
        public string THU_TRUONG { get; set; }

        [Column("NGUOI_LAP")]
        [StringLength(100)]
        [Description("Người lập")]
        public string NGUOI_LAP { get; set; }      

        [Column("THU_QUY")]
        [StringLength(100)]
        [Description("Thủ quỹ")]
        public string THU_QUY { get; set; }

        [Column("NGAY_TAO")]
        [Description("Ngày tạo")]
        public Nullable<DateTime> NGAY_TAO { get; set; }

        [Column("NGUOI_TAO")]
        [StringLength(100)]
        [Description("Người tạo")]
        public string NGUOI_TAO { get; set; }

        [Column("NGAY_SUA")]
        [Description("Ngày sửa")]
        public Nullable<DateTime> NGAY_SUA { get; set; }

        [Column("NGUOI_SUA")]
        [StringLength(100)]
        [Description("Người sửa")]
        public string NGUOI_SUA { get; set; }


    }
}
