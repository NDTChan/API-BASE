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
    [Table("PHC_PHIEU_CTTT_IN")]
    public class PHC_PHIEU_CTTT_IN : DataInfoEntityPHC
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("THANH_TOAN_TT")]
        [Description("thanh toán trực tiếp")]
        public Boolean THANH_TOAN_TT { get; set; }      

        [Column("THANH_TOAN_TAM_UNG")]
        [Description("thanh toán tạm ứng")]
        public Boolean THANH_TOAN_TAM_UNG { get; set; }

        [Column("TAM_UNG")]
        [Description("tạm ứng")]
        public Boolean TAM_UNG { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string SO_CHUNGTU { get; set; }

        [Column("MA_DVSDNS")]
        [StringLength(50)]
        [Description("MA_DVSDNS")]
        public string MA_DVSDNS { get; set; }

        [Column("SO_HOA_DON")]
        [StringLength(100)]
        [Description("số hóa đơn")]
        public string SO_HOA_DON { get; set; }

        [Column("NGAY_HD")]
        [Description("ngày hóa đơn")]
        public Nullable<DateTime> NGAY_HD { get; set; }

        [Column("SO_LUONG")]
        [StringLength(100)]
        public string SO_LUONG { get; set; }

        [Column("DINH_MUC")]
        [StringLength(100)]
        public string DINH_MUC { get; set; }

        [Column("SO_TIEN")]
        [StringLength(100)]
        public string SO_TIEN { get; set; }

        [Column("NGAY_IN")]
        [Description("Ngày in")]
        public Nullable<DateTime> NGAY_IN { get; set; }

        [Column("NGUOI_IN")]
        [StringLength(100)]
        [Description("Người in")]
        public string NGUOI_IN { get; set; }


    }
}
