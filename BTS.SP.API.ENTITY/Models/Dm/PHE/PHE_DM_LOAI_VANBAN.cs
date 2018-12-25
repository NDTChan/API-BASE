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
    [Table("PHE_DM_LOAI_VANBAN")]
    public class PHE_DM_LOAI_VANBAN : DataInfoEntity
    {
        [Required]
        [Column("MA_LOAIVANBAN")]
        [StringLength(50)]
        public string MA_LOAIVANBAN { get; set; }

        [Column("TEN_LOAIVANBAN")]
        [StringLength(500)]
        public string TEN_LOAIVANBAN { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
