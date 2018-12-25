using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_DVQHNS")]
    public class SYS_DVQHNS : DataInfoEntity
    {
        [Column("MA_DVQHNS")]
        [StringLength(20)]
        [Description("Mã đơn vị quan hệ ngân sách ")]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(240)]
        [Description("Tên đơn vị quan hệ ngân sách ")]
        public string TEN_DVQHNS { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public Nullable<DateTime> NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("MA_DVQHNS_CHA")]
        [StringLength(20)]
        [Description(" Tham chiếu tới mã cha ")]
        public string MA_DVQHNS_CHA { get; set; }

        [Column("TYPE_DVQHNS")]
        [StringLength(2)]
        [Description(" Kiểu: 1 = Mã DVSDNS; 2=Mã ĐTXDCB; 3=Mã tổ chức; 4=Mã tổng hợp; 5=Mã logic ")]
        public string TYPE_DVQHNS { get; set; }


        [Column("MA_LOAIDV")]
        [StringLength(2)]
        [Description(" Mã loại đơn vị ")]
        public string MA_LOAIDV { get; set; }

        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo ")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng ")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("MA_CAP")]
        [StringLength(1)]
        [Description("Cấp dự toán ")]
        public string MA_CAP { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(3)]
        [Description("Mã chương ")]
        public string MA_CHUONG { get; set; }

        [Column("MA_TINH")]
        [StringLength(2)]
        [Description("Mã tỉnh ")]
        public string MA_TINH { get; set; }

        [Column("MA_XA")]
        [StringLength(5)]
        [Description("Mã xã")]
        public string MA_XA { get; set; }

        [Column("MA_HUYEN")]
        [StringLength(3)]
        [Description("Mã huyện")]
        public string MA_HUYEN { get; set; }

        [Column("CAN_CU")]
        [StringLength(100)]
        [Description("Căn cứ là văn bản, quyết định làm cơ sở xấy dựng cập nhật danh mục")]
        public string CAN_CU { get; set; }


        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo ")]
        public string USER_NAME { get; set; }

        // update dau tu
        [Column("MA_DA_DP")]
        [StringLength(9)]
        public string MA_DA_DP { get; set; }

        [Column("MA_NHOM_DA")]
        [StringLength(9)]
        public string MA_NHOM_DA { get; set; }

        [Column("TEN_NHOM_DA")]
        [StringLength(2000)]
        public string TEN_NHOM_DA { get; set; }

        [Column("MA_NKT")]
        [StringLength(2000)]
        public string MA_NKT { get; set; }

        [Column("MA_CTMT")]
        [StringLength(2000)]
        public string MA_CTMT { get; set; }

        [Column("MA_DON_VI")]
        [StringLength(9)]
        public string MA_DON_VI { get; set; }

        [Column("SHKB")]
        [StringLength(9)]
        public string SHKB { get; set; }

        [Column("NGUON_DL")]
        [StringLength(9)]
        public string NGUON_DL { get; set; }

        [Column("TINH_TRANG")]
        [StringLength(9)]
        public string TINH_TRANG { get; set; }

        [Column("TM_DTU")]
        public Nullable<decimal> TM_DTU { get; set; }

        [Column("NGAY_KC")]
        public Nullable<DateTime> NGAY_KC { get; set; }

        [Column("NGAY_HT")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("CAP_QLY")]
        [StringLength(9)]
        public string CAP_QLY { get; set; }

        [Column("TRD_TPCP")]
        public Nullable<decimal> TRD_TPCP { get; set; }

        [Column("NGAY_TAO")]
        public Nullable<DateTime> NGAY_TAO { get; set; }

        [Column("NGUOI_TAO")]
        [StringLength(50)]
        public string NGUOI_TAO { get; set; }

        [Column("NGUOI_QLY")]
        [StringLength(50)]
        public string NGUOI_QLY { get; set; }

        [Column("CAP_NS")]
        [StringLength(9)]
        public string CAP_NS { get; set; }

        [Column("TEN_DA_DP")]
        [StringLength(500)]
        public string TEN_DA_DP { get; set; }

        [Column("NGAY_CHUYEN_DOI")]
        public Nullable<DateTime> NGAY_CHUYEN_DOI { get; set; }

        [Column("MA_BQLDA")]
        [StringLength(500)]
        public string MA_BQLDA { get; set; }

        [Column("CQUAN_TLAP")]
        [StringLength(9)]
        public string CQUAN_TLAP { get; set; }

        [Column("NVU_THIEN")]
        [StringLength(9)]
        public string NVU_THIEN { get; set; }

        [Column("TRD_NSNN")]
        public Nullable<decimal> TRD_NSNN { get; set; }

        [Column("TRD_ODA")]
        public Nullable<decimal> TRD_ODA { get; set; }

        [Column("MA_NTT")]
        [StringLength(200)]
        public string MA_NTT { get; set; }

        [Column("CHUDAUTU")]
        [StringLength(200)]
        public string CHUDAUTU { get; set; }

        [Column("SO_QD")]
        [StringLength(20)]
        public string SO_QD { get; set; }

        [Column("NGAY_QD")]
        public Nullable<DateTime> NGAY_QD { get; set; }
    }
}
