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
    [Table("PHC_PHIEU_BANGKENOPTHUE")]
    public class PHC_PHIEU_BANGKENOPTHUE : DataInfoEntityPHC
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

        [Column("HINH_THUC_NOP")]
        [Description("Hình thức nộp (1: Tiền mặt; 2: Chuyển khoản)")]
        [StringLength(1)]
        public string HINH_THUC_NOP { get; set; }

        [Column("LOAI_TIEN")]
        [Description("Loại tiền (1: VND; 2: USD; 3: khác)")]
        [StringLength(1)]
        public string LOAI_TIEN { get; set; }

        [Column("NGUOI_NOP")]
        [StringLength(100)]
        [Description("Người nộp")]
        public string NGUOI_NOP { get; set; }

        [Column("MA_SO_THUE")]
        [StringLength(20)]
        [Description("Mã số thuế")]
        public string MA_SO_THUE { get; set; }

        [Column("DIA_CHI")]
        [StringLength(500)]
        [Description("Địa chỉ người nộp thuế")]
        public string DIA_CHI { get; set; }

        [Column("HUYEN")]
        [StringLength(50)]
        [Description("Huyện người nộp")]
        public string HUYEN { get; set; }

        [Column("TINH")]
        [StringLength(50)]
        [Description("Tỉnh người nộp")]
        public string TINH { get; set; }

        [Column("NGUOI_NOP_THAY")]
        [StringLength(100)]
        [Description("Người nộp thay")]
        public string NGUOI_NOP_THAY { get; set; }

        [Column("DIA_CHI_NGUOI_NOP_THAY")]
        [StringLength(500)]
        [Description("Địa chỉ người nộp thay")]
        public string DIA_CHI_NGUOI_NOP_THAY { get; set; }

        [Column("HUYEN_NGUOI_NOP_THAY")]
        [StringLength(50)]
        [Description("Huyện người nộp thay")]
        public string HUYEN_NGUOI_NOP_THAY { get; set; }

        [Column("TINH_NGUOI_NOP_THAY")]
        [StringLength(50)]
        [Description("Tỉnh người nộp thay")]
        public string TINH_NGUOI_NOP_THAY { get; set; }

        [Column("KHO_BAC")]
        [StringLength(200)]
        [Description("Đề nghị NH/KBNN")]
        public string KHO_BAC { get; set; }

        [Column("TK_KHO_BAC")]
        [StringLength(50)]
        [Description("trích TK số")]
        public string TK_KHO_BAC { get; set; }

        [Column("NOP_NSNN_THEO")]
        [Description("hoặc thu tiền mặt để nộp NSNN theo (1: TK thu NSNN; 2: TK tạm thu; 3: TK thu hồi hoàn thuế GTGT)")]
        [StringLength(1)]
        public string NOP_NSNN_THEO { get; set; }

        [Column("TK_KHO_BAC_VAO")]
        [StringLength(50)]
        [Description("vào tài khoản của KBNN")]
        public string TK_KHO_BAC_VAO { get; set; }

        [Column("TINH_KHO_BAC_VAO")]
        [StringLength(50)]
        [Description("Tỉnh, TP")]
        public string TINH_KHO_BAC_VAO { get; set; }

        [Column("CO_QUAN")]
        [Description("Nộp theo văn bản của cơ quan có thẩm quyền (1: Kiểm toán nhà nước; 2: Thanh tra tài chính; 3: Thanh tra chính phủ; 4: Cơ quan có thẩm quyền khác)")]
        [StringLength(1)]
        public string CO_QUAN { get; set; }

        [Column("CQ_THU")]
        [Description("Tên cơ quan quản lý thu")]
        [StringLength(300)]
        public string CQ_THU { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}
