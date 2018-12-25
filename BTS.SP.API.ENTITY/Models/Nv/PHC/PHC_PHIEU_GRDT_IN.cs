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
    [Table("PHC_PHIEU_GRDT_IN")]
    public class PHC_PHIEU_GRDT_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("THUC_CHI")]
        [Description("thực chi")]
        public Boolean THUC_CHI { get; set; }      

        [Column("TAM_UNG")]
        [Description("tạm ứng")]
        public Boolean TAM_UNG { get; set; }

        [Column("UNG_TRUOC_CHUA_DU")]
        [Description("ứng trước chưa đủ")]
        public Boolean UNG_TRUOC_CHUA_DU { get; set; }

        [Column("UNG_TRUOC_DU")]
        [Description("ứng trước đủ")]
        public Boolean UNG_TRUOC_DU { get; set; }

        [Column("CHUYEN_KHOAN")]
        [Description("chuyển khoản")]
        public Boolean CHUYEN_KHOAN { get; set; }

        [Column("TIEN_MAT_KB")]
        [Description("tien mat kho bac")]
        public Boolean TIEN_MAT_KB { get; set; }

        [Column("MA_SO_PHIEU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string MA_SO_PHIEU { get; set; }

        [Column("TIEN_MAT_NH")]
        [Description("tiền mặt ngân hàng")]
        public Boolean TIEN_MAT_NH { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("số")]
        public string SO_CHUNGTU { get; set; }

        [Column("KBNN")]
        [StringLength(100)]
        [Description("kho bạc nhà nước")]
        public string KBNN { get; set; }

        [Column("TAI_KHOAN")]
        [Description("tài khoản")]
        [StringLength(100)]
        public string TAI_KHOAN { get; set; }

        [Column("CKC_HDK")]
        [StringLength(100)]
        public string CKC_HDK { get; set; }

        [Column("CKC_HDTH")]
        [StringLength(100)]
        public string CKC_HDTH { get; set; }

        [Column("DON_VI_NHAN")]
        [StringLength(100)]
        [Description("DON VI NHAN")]
        public string DON_VI_NHAN { get; set; }

        [Column("DIA_CHI_NHAP")]
        [StringLength(100)]
        [Description("địa chỉ người nhập")]
        public string DIA_CHI_NHAP { get; set; }      

        [Column("KBNN_NHAP")]
        [StringLength(100)]
        [Description("KBNN người nhập")]
        public string KBNN_NHAP { get; set; }

        [Column("TAI_KHOAN_NHAP")]
        [StringLength(100)]
        [Description("tài khoản người nhập")]
        public string TAI_KHOAN_NHAP { get; set; }

        [Column("NGUOI_NHAN")]
        [StringLength(100)]
        [Description("người nhận")]
        public string NGUOI_NHAN { get; set; }

        [Column("CMND")]
        [StringLength(100)]
        [Description("CMND")]
        public string CMND { get; set; }

        [Column("NGAY")]
        [Description("NGAY")]
        public Nullable<DateTime> NGAY { get; set; }

        [Column("NOI_CAP")]
        [StringLength(100)]
        [Description("NOI_CAP")]
        public string NOI_CAP { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }


    }
}
