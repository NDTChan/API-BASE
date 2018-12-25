using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_NHOMMUCCHI")]
    public class PHB_DM_NHOMMUCCHI:DataInfoEntity
    {
        [StringLength(10)]
        [Required]
        public string MA_NHOMMC { get; set; }

        [StringLength(255)]
        [Required]
        public string TEN_NHOMMC { get; set; }

        [StringLength(255)]
        public string MO_TA { get; set; }

        [Description("Trạng thái sử dụng (true: Đang sử dụng; false: Không sử dụng)")]
        [Required]
        public bool TRANG_THAI { get; set; }
    }
}
