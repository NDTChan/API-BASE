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
    [Table("PHE_DM_KHOANCHI")]
    public class PHE_DM_KHOANCHI : DataInfoEntity
    {
        [Required]
        [Column("MA_KHOANCHI")]
        [StringLength(50)]
        public string MA_KHOANCHI { get; set; }

        [Required]
        [Column("TEN_KHOANCHI")]
        [StringLength(500)]
        public string TEN_KHOANCHI { get; set; }

        [Required]
        [Column("PHAN_LOAI")]
        [StringLength(100)]
        public string PHAN_LOAI { get; set; }

        [Column("MA_KHOANCHI_CHA")]
        [StringLength(50)]
        public string MA_KHOANCHI_CHA { get; set; }

        [Column("LOAI_MUC_CHI")]
        [StringLength(50)]
        public string LOAI_MUC_CHI { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
