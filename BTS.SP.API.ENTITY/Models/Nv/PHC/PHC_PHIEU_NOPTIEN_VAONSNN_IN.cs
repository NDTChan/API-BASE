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
    [Table("PHC_PHIEU_NOPTIEN_VAONSNN_IN")]
    public class PHC_PHIEU_NOPTIEN_VAONSNN_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("NGAY_IN")]
        [Required]
        public DateTime NGAY_IN { get; set; }

        [Column("SO_CHUNGTU")]
        [Required]
        [StringLength(50)]
        public string SO_CHUNGTU { get; set; }

        [Column("MST")]
        [StringLength(50)]
        public string MST { get; set; }

        [Column("HINHTHUC")]
        [StringLength(2)]
        [Description("Hình thức nộp tiền: TM hoặc CK")]
        public string HINHTHUC { get; set; }

        [Column("NGUOINOPTHAY")]
        [StringLength(250)]
        [Description("Người nộp thay")]
        public string NGUOINOPTHAY { get; set; }

        [Column("NGUOINOPTHAY_MST")]
        [StringLength(20)]
        [Description("Mã số thuế")]
        public string NGUOINOPTHAY_MST { get; set; }

        [Column("NGUOINOPTHAY_DIACHI")]
        [StringLength(250)]
        [Description("Người nộp thay Địa chỉ")]
        public string NGUOINOPTHAY_DIACHI { get; set; }

        [Column("NGUOINOPTHAY_DIACHI_HUYEN")]
        [StringLength(250)]
        [Description("Người nộp thay Địa chỉ Huyện")]
        public string NGUOINOPTHAY_DIACHI_HUYEN { get; set; }

        [Column("NGUOINOPTHAY_DIACHI_TP")]
        [StringLength(250)]
        [Description("Người nộp thay Địa chỉ TP")]
        public string NGUOINOPTHAY_DIACHI_TP { get; set; }

        [Column("DENGHI_NH")]
        [StringLength(250)]
        [Description("Đề nghị ngân hàng")]
        public string DENGHI_NH { get; set; }

        [Column("DENGHI_NH_SOTK")]
        [StringLength(50)]
        [Description("Trích TK số")]
        public string DENGHI_NH_SOTK { get; set; }

        [Column("THU_TIEN_MAT_DE")]
        [StringLength(50)]
        [Description("Hoặc thu tiền mặt để")]
        public string THU_TIEN_MAT_DE { get; set; }

        [Column("TAI_KBNN")]
        [StringLength(250)]
        [Description("Tại KBNN")]
        public string TAI_KBNN { get; set; }

        [Column("KBNN_TINH_TP")]
        [StringLength(250)]
        [Description("Tại KBNN tỉnh, TP")]
        public string KBNN_TINH_TP { get; set; }

        [Column("MO_TAI_NHTM")]
        [StringLength(250)]
        [Description("Mở tại NHTM")]
        public string MO_TAI_NHTM { get; set; }

        [Column("NOP_THEO_QD_CQTQ")]
        [StringLength(50)]
        [Description("Nộp theo QĐ của CQ có TQ")]
        public string NOP_THEO_QD_CQTQ { get; set; }

        [Column("TEN_CQQL")]
        [StringLength(250)]
        [Description("Tên cơ quan QL thu")]
        public string TEN_CQQL { get; set; }

        [Column("TKHQ_SO")]
        [StringLength(50)]
        [Description("Tờ khai HQ số")]
        public string TKHQ_SO { get; set; }

        public DateTime? TKHQ_NGAY { get; set; }

        [Column("LOIAHINH_XNK")]
        [StringLength(50)]
        [Description("Loại hình XNK")]
        public string LOIAHINH_XNK { get; set; }

        [Column("MA_CQ_THU")]
        [StringLength(50)]
        [Description("Mã CQ thu")]
        public string MA_CQ_THU { get; set; }

        [Column("MA_DBHC")]
        [StringLength(50)]
        [Description("Mã ĐBHC")]
        public string MA_DBHC { get; set; }

        [Column("MA_NGUON_NSNN")]
        [StringLength(50)]
        [Description("Mã nguồn NSNN")]
        public string MA_NGUON_NSNN { get; set; }

        [Column("NO_TK")]
        [StringLength(50)]
        [Description("Nợ TK")]
        public string NO_TK { get; set; }

        [Column("CO_TK")]
        [StringLength(50)]
        [Description("Có TK")]
        public string CO_TK { get; set; }
    }
}
