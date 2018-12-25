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
    [Table("PHC_PHIEU_GRT_IN")]
    public class PHC_PHIEU_GRT_IN : DataInfoEntityPHC
    {

        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("MA_SO_PHIEU")]
        [StringLength(20)]
        [Description("Mã số phiếu")]
        public string MA_SO_PHIEU { get; set; }

        [Column("DVLT")]
        [StringLength(100)]
        [Description("Đơn vị lĩnh tiền")]
        public string DVLT { get; set; }

        [Column("DIA_CHI")]
        [Description("Địa chỉ")]
        public string DIA_CHI { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(10)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("MA_TK")]
        [StringLength(30)]
        [Description("Mã tài khoản")]
        public string MA_TK { get; set; }

        [Column("TEN_KBNN")]
        [StringLength(100)]
        [Description("Tên KBNN")]
        public string TEN_KBNN { get; set; }

        [Column("NGUOI_LINH")]
        [StringLength(50)]
        [Description("Người lĩnh")]
        public string NGUOI_LINH { get; set; }

        [Column("SO_CMND")]
        [StringLength(20)]
        [Description("Số CMND")]
        public string SO_CMND { get; set; }

        [Column("NGAY_CAP")]
        [Description("Ngày cấp")]
        public DateTime NGAY_CAP { get; set; }

        [Column("NOI_CAP")]
        [StringLength(100)]
        [Description("Nơi cấp")]
        public string NOI_CAP { get; set; }

        [Column("NGAY_TAO")]
        [Description("Ngày tạo")]
        public Nullable<DateTime> NGAY_TAO { get; set; }
    }
}
