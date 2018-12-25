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
    [Table("PHF_DM_DIABAN")]

    public class PHF_DM_DIABAN : BaseEntity
    {
        [Column("MA_DIABAN")]
        [StringLength(50)]
        [Description("Mã địa bàn")]
        public string MA_DIABAN  { get; set; }

        [Column("TEN_DIABAN")]
        [StringLength(256)]
        [Description("Tên địa bàn")]
        public string TEN_DIABAN { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }
    }
}
