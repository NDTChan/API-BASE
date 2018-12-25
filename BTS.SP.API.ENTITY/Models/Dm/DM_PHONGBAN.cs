using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_PHONGBAN")]
    public class DM_PHONGBAN : DataInfoEntity
    {
        [Required]
        [Column("MA_PHONGBAN")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Column("TEN_PHONGBAN")]
        [StringLength(500)]
        public string TEN_PHONGBAN { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        public string NOI_DUNG { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANGTHAI { get; set; }


    }
}
