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
    [Table("SYS_THAMSO_HETHONG") ]
    public class SYS_THAMSO_HETHONG : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        public string MA { get; set; }

        [Column("TEN_THAMSO")]
        [StringLength(500)]
        public string TEN_THAMSO { get; set; }

        [Column("GIA_TRI")]
        [StringLength(500)]
        public string GIA_TRI { get; set; }

        [Column("THAYDOI")]
        public Nullable<decimal>  THAYDOI { get; set; }

        [Column("KIEU_DULIEU")]
        public Nullable<decimal> KIEU_DULIEU { get; set; }

        [Column("LOAI_THAMSO")]
        public Nullable<decimal> LOAI_THAMSO { get; set; }

        [Column("GHI_CHU")]
        [StringLength(250)]
        public string GHI_CHU { get; set; }

        [Column("MA_CHA")]
        [StringLength(20)]
        public string MA_CHA { get; set; }

        [Column("SORT")]
        [Description("Sort")]
        public Nullable<int> SORT { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Ðang sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
