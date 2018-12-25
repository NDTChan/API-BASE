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
    [Table("PHE_DM_GIAIDOAN_VON")]
    public class PHE_DM_GIAIDOAN_VON : DataInfoEntity
    {
        [Required]
        [Column("MA_GIAIDOAN_VON")]
        [StringLength(50)]
        public string MA_GIAIDOAN_VON { get; set; }

        [Required]
        [Column("TEN_GIAIDOAN_VON")]
        [StringLength(500)]
        public string TEN_GIAIDOAN_VON { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
