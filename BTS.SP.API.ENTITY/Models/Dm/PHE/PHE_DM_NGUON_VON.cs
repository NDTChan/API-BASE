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
    [Table("PHE_DM_NGUON_VON")]
    public class PHE_DM_NGUON_VON : DataInfoEntity
    {
        [Required]
        [Column("MA_NGUONVON")]
        [StringLength(50)]
        public string MA_NGUONVON { get; set; }

        [Column("TEN_NGUONVON")]
        [StringLength(500)]
        public string TEN_NGUONVON { get; set; }

        [Column("NGUONVON_CHA")]
        [StringLength(50)]
        public string NGUONVON_CHA { get; set; }

        [Column("NHOM_NGUONVON")]
        [StringLength(200)]
        public string NHOM_NGUONVON { get; set; }

        [Column("LOAI_NGUONVON")]
        [StringLength(200)]
        public string LOAI_NGUONVON { get; set; }

        [Column("DACTINH_NGUONVON")]
        [StringLength(50)]
        public string DACTINH_NGUONVON { get; set; }

        [Column("CAP_NGANSACH")]
        [StringLength(50)]
        public string CAP_NGANSACH { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
