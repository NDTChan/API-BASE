using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_XD_KH_THANHTRA_BO")]
    public class PHF_XD_KH_THANHTRA_BO : BaseEntity
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("NGAY_LAPPHIEU")]
        public DateTime? NGAY_LAPPHIEU { get; set; }

        [Column("NOIDUNG")]
        [StringLength(1000)]
        public string NOIDUNG { get; set; }

        [Column("MA_DOITUONG")]
        [Description("Đơn vị báo cáo")]
        [StringLength(50)]
        public string MA_DOITUONG { get; set; }

        [Column("MA_PHONGBAN")]
        [Description("Mã phòng ban")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Column("DOT_THANHTRA")]
        [StringLength(50)]
        public string DOT_THANHTRA { get; set; }

        [Column("NAM")]
        [Description("Năm")]
        public Nullable<int> NAM { get; set; }

        [Column("TUNGAY")]
        public DateTime? TUNGAY { get; set; }

        [Column("DENNGAY")]
        public DateTime? DENNGAY { get; set; }
    }
}
