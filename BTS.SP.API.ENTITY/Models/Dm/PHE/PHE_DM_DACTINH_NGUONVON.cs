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
    [Table("PHE_DM_DACTINH_NGUONVON")]
    public class PHE_DM_DACTINH_NGUONVON: DataInfoEntity
    {
        [Required]
        [Column("MA_DACTINH_NGUONVON")]
        [StringLength(50)]
        public string MA_DACTINH_NGUONVON { get; set; }

        [Column("TEN_DACTINH_NGUONVON")]
        [StringLength(500)]
        public string TEN_DACTINH_NGUONVON { get; set; }

        [Column("MA_CHA")]
        [StringLength(50)]
        public string MA_CHA { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
