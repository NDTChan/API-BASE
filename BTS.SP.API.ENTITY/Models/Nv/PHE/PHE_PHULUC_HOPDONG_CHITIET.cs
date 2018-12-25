using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_PHULUC_HOPDONG_CHITIET")]
    public class PHE_PHULUC_HOPDONG_CHITIET : DataInfoEntity
    {
        [Column("MA_PHULUC_HOPDONG")]
        [StringLength(50)]
        public string MA_PHULUC_HOPDONG { get; set; }

        [Column("MA_HANGMUC")]
        [StringLength(50)]
        public string MA_HANGMUC { get; set; }

        [Column("MA_CHIPHI")]
        [StringLength(200)]
        public string MA_CHIPHI { get; set; }

        [Column("TEN_CHIPHI")]
        [StringLength(500)]
        public string TEN_CHIPHI { get; set; }

        [Column("MA_CHA")]
        [StringLength(200)]
        public string MA_CHA { get; set; }

        [Column("LOAI_NGOAITE")]
        [StringLength(50)]
        public string LOAI_NGOAITE { get; set; }

        [Column("SOLUONG")]
        public decimal? SOLUONG { get; set; }

        [Column("SOTIEN_NT")]
        public decimal? SOTIEN_NT { get; set; }

        [Column("TY_GIA")]
        public decimal? TY_GIA { get; set; }

        [Column("SOTIEN_VND")]
        public decimal? SOTIEN_VND { get; set; }
    }
}
