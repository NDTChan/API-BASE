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
    [Table("PHC_DIEUCHINHKINHPHIHEADER")]
    public class PHC_DIEUCHINHKINHPHIHEADER : DataInfoEntityPHC
    {
        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("LOAICHUNGTU")]
        [Description("Loại chứng từ.1: Thu, 2: Chi")]
        public int LOAICHUNGTU { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("DIENGIAI")]
        [StringLength(500)]
        [Description("Diễn giải")]
        public string DIENGIAI { get; set; }

        [Column("MANGUON")]
        [StringLength(50)]
        [Description("Mã nguồn")]
        public string MANGUON { get; set; }

        [Column("MAKBNN")]
        [StringLength(50)]
        [Description("Mã kho bạc nhà nước")]
        public string MAKBNN { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái duyệt phiếu 10: Duyệt ; 0 Chưa duyệt ; 20: Bỏ duyệt")]
        public Nullable<int> TRANGTHAI { get; set; }
    }
}
