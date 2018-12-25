using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Dm
{
    [Table("PHE_DM_COQUANBANHANH")]
    public class PHE_DM_COQUANBANHANH : DataInfoEntity
    {
        [Required]
        [Column("MA_COQUANBANHANH")]
        [StringLength(50)]
        public string MA_COQUANBANHANH { get; set; }

        [Column("TEN_COQUANBANHANH")]
        [StringLength(500)]
        public string TEN_COQUANBANHANH { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
