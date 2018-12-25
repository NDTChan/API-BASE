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
    [Table("PHE_DM_LINHVUC")]
    public class PHE_DM_LINHVUC : DataInfoEntity
    {
        [Required]
        [Column("MA_LINHVUC")]
        [StringLength(50)]
        public string MA_LINHVUC { get; set; }

        [Column("TEN_LINHVUC")]
        [StringLength(500)]
        public string TEN_LINHVUC { get; set; }

        [Column("MA_LINHVUC_CHA")]
        [StringLength(50)]
        public string MA_LINHVUC_CHA { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
