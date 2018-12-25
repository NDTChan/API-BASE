using BTS.SP.PHF.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Dm
{
    [Table("PHF_DM_CHUCNANG")]
    public class PHF_DM_CHUCNANG : BaseEntity
    {
        [Column("MA_PHONG")]
        [StringLength(50)]
        [Description("Mã phòng ban ")]
        public string MA_PHONG { get; set; }

        [Column("TEN_PHONG")]
        [StringLength(256)]
        [Description("Tên phòng")]
        public string TEN_PHONG { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }
    }
}
