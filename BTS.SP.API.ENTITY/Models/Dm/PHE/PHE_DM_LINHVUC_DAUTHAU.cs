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
    [Table("PHE_DM_LINHVUC_DAUTHAU")]
    public class PHE_DM_LINHVUC_DAUTHAU: DataInfoEntity
    {
        [Required]
        [Column("MA_LINHVUC_DAUTHAU")]
        [StringLength(50)]
        public string MA_LINHVUC_DAUTHAU { get; set; }

        [Column("TEN_LINHVUC_DAUTHAU")]
        [StringLength(500)]
        public string TEN_LINHVUC_DAUTHAU { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
