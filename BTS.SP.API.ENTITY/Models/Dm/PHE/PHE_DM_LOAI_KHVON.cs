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
    [Table("PHE_DM_LOAI_KHVON")]
    public class PHE_DM_LOAI_KHVON : DataInfoEntity
    {
        [Required]
        [Column("MA_LOAI_KHVON")]
        [StringLength(50)]
        public string MA_LOAI_KHVON { get; set; }

        [Required]
        [Column("TEN_LOAI_KHVON")]
        [StringLength(500)]
        public string TEN_LOAI_KHVON { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
