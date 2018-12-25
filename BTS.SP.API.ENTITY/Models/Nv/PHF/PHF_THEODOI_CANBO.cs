using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_THEODOI_CANBO")]
    public class PHF_THEODOI_CANBO : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("TEN_PHIEU")]
        [StringLength(500)]
        public string TEN_PHIEU { get; set; }

        [Column("MA_DOITUONG")]
        [Description("Đơn vị báo cáo")]
        [StringLength(50)]
        public string MA_DOITUONG { get; set; }

        [Column("MA_PHONGBAN")]
        [Description("Mã phòng ban")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Column("NAM_THANHTRA")]
        public int? NAM_THANHTRA { get; set; }

        [Column("DOT_THANHTRA")]
        [StringLength(50)]
        public string DOT_THANHTRA { get; set; }
    }
}
