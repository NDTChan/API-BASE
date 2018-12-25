using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_LOAI_PHATSINH")]
    public class PHE_DM_LOAI_PHATSINH : DataInfoEntity
    {
        [Required]
        [Column("MA_LOAI_PHATSINH")]
        [StringLength(50)]
        public string MA_LOAI_PHATSINH { get; set; }

        [Required]
        [Column("TEN_LOAI_PHATSINH")]
        [StringLength(500)]
        public string TEN_LOAI_PHATSINH { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
