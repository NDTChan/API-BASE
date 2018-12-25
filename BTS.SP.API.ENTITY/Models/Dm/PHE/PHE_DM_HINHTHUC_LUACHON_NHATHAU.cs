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
    [Table("PHE_DM_HTLUACHON_NT")]
    public class PHE_DM_HTLUACHON_NT : DataInfoEntity
    {
        [Required]
        [Column("MA_HINHTHUC_LUACHON")]
        [StringLength(50)]
        public string MA_HINHTHUC_LUACHON { get; set; }

        [Column("TEN_HINHTHUC_LUACHON")]
        [StringLength(500)]
        public string TEN_HINHTHUC_LUACHON { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
