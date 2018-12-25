using BTS.SP.API.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHF
{
    [Table("PHF_DM_TEST")]
    public class PHF_DM_TEST : DataInfoEntity
    {
        [Column("MA_TEST")]
        [StringLength(50)]
        [Description("Mã test")]
        [Required]
        public string MA_TEST { get; set; }

        [Column("TEN_TEST")]
        [StringLength(256)]
        [Description("Tên test")]
        [Required]
        public string TEN_TEST { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        [Required]
        public int TRANG_THAI { get; set; }
    }
}
