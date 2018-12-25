
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
    [Table("PHC_PHIEU_UNC_IN")]
    public class PHC_PHIEU_UNC_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string SO_CHUNGTU { get; set; }

        [Column("NAM_NS")]
        [StringLength(20)]
        [Description("năm ns")]
        public string NAM_NS { get; set; }

        [Column("DON_VI")]
        [StringLength(20)]
        public string DON_VI { get; set; }

        [Column("DIA_CHI")]
        [StringLength(100)]
        public string DIA_CHI { get; set; }

        [Column("DON_VI_NHAN")]
        [StringLength(100)]
        public string DON_VI_NHAN { get; set; }

        [Column("DIA_CHI_NHAP")]
        [StringLength(100)]
        public string DIA_CHI_NHAP { get; set; }

        [Column("TAI_KHOAN_NHAP")]
        [StringLength(20)]
        [Description("tài khoản nhập")]
        public string TAI_KHOAN_NHAP { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }
    }
}

