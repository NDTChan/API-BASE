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
    [Table("PHE_DM_TRANGTHAI_DUAN")]
    public class PHE_DM_TRANGTHAI_DUAN : DataInfoEntity
    {
        [Required]
        [Column("MA_TRANGTHAI_DUAN")]
        [StringLength(50)]
        public string MA_TRANGTHAI_DUAN { get; set; }

        [Column("TEN_TRANGTHAI_DUAN")]
        [StringLength(500)]
        public string TEN_TRANGTHAI_DUAN { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
