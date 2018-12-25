using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_XD_KH_TT_THUOC_BO")]
    public class PHF_XD_KH_TT_THUOC_BO : BaseEntity
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("NGAY_LUU_DL")]
        public DateTime? NGAY_LUU_DL { get; set; }

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

        [Column("NAM_THANHTRA")]
        public int? NAM_THANHTRA { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(500)]
        public string NOI_DUNG { get; set; }

    }
}
