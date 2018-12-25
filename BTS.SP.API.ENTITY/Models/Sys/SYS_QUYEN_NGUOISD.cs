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
    [Table("SYS_QUYEN_NGUOISD")]
    public class SYS_QUYEN_NGUOISD:DataInfoEntity
    {
        [Column("MA_NHOMQUYEN")]
        [StringLength(30)]
        [Description("Mã nhóm quyền")]
        public string MA_NHOMQUYEN { get; set; }

        [Column("USER_NAME")]
        [StringLength(30)]
        [Description("USER_NAME")]
        public string USER_NAME { get; set; }

    }
}
