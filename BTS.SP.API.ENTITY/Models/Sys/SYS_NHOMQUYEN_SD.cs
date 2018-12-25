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
    [Table("SYS_NHOMQUYEN_SD")]
    public class SYS_NHOMQUYEN_SD:DataInfoEntity
    {
        [Column("MA_NHOMQUYEN")]
        [StringLength(30)]
        [Description("Mã nhóm quyền")]
        public string MA_NHOMQUYEN { get; set; }

        [Column("TEN_NHOMQUYEN")]
        [StringLength(300)]
        [Description("Tên nhóm quyền")]
        public string TEN_NHOMQUYEN { get; set; }

        [Column("MOTA")]
        [StringLength(300)]
        [Description("Mô tả")]
        public string MOTA { get; set; }

    }
}
