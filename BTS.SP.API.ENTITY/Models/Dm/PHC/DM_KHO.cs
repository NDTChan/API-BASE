using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_KHO")]
    public class DM_KHO : DataInfoEntity
    {
        [Column("MA_KHO")]
        [StringLength(20)]
        [Description("Mã kho")]
        public string MA_KHO { get; set; }

        [Column("TEN_KHO")]
        [StringLength(250)]
        [Description("Tên kho")]
        public string TEN_KHO { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Required]
        public string TRANG_THAI { get; set; }

    }
}
