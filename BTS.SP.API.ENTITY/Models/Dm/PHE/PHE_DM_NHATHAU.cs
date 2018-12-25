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
    [Table("PHE_DM_NHATHAU")]
    public class PHE_DM_NHATHAU : DataInfoEntity
    {
        [Required]
        [Column("MA_NHATHAU")]
        [StringLength(50)]
        public string MA_NHATHAU { get; set; }

        [Column("TEN_NHATHAU")]
        [StringLength(500)]
        public string TEN_NHATHAU { get; set; }

        [Column("DIA_CHI")]
        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [Column("DIEN_THOAI")]
        [StringLength(20)]
        public string DIEN_THOAI { get; set; }

        [Column("FAX")]
        [StringLength(20)]
        public string FAX { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }
    }
}
