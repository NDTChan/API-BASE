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
    [Table("PHE_DM_NGHIEPVU")]
    public class PHE_DM_NGHIEPVU : DataInfoEntity
    {
        [Required]
        [Column("MA_NGHIEPVU")]
        [StringLength(50)]
        public string MA_NGHIEPVU { get; set; }

        [Required]
        [Column("TEN_NGHIEPVU")]
        [StringLength(500)]
        public string TEN_NGHIEPVU { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
