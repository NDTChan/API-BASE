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
    [Table("PHF_DM_COQUAN")]
    public class PHF_DM_COQUAN : DataInfoEntity
    {
        [Column("MA_COQUAN")]
        [StringLength(50)]
        [Description("Mã cơ quan")]
        public string MA_COQUAN        { get; set; }

        [Column("TEN_COQUAN")]
        [StringLength(256)]
        [Description("Tên cơ quan")]
        public string TEN_COQUAN        { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }
    }
}
