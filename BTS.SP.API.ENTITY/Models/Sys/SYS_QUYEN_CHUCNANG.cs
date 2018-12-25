using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_QUYEN_CHUCNANG")]
    public class SYS_QUYEN_CHUCNANG:DataInfoEntity
    {
        [Column("MA_NHOMQUYEN")]
        [StringLength(30)]
        [Description("Mã nhóm quyền")]
        public string MA_NHOMQUYEN { get; set; }

        [Column("MA_CHUCNANG")]
        [StringLength(30)]
        [Description("Mã chức năng")]
        public string MA_CHUCNANG { get; set; }

        [Column("QUYEN_XEM")]
        public Nullable<int> QUYEN_XEM { get; set; }

        [Column("QUYEN_CAPNHAT")]
        public Nullable<int> QUYEN_CAPNHAT { get; set; }

        [Column("QUYEN_XOA")]
        public Nullable<int> QUYEN_XOA { get; set; }

        [Column("QUYEN_PHEDUYET")]
        public Nullable<int> QUYEN_PHEDUYET { get; set; }

    }
}
