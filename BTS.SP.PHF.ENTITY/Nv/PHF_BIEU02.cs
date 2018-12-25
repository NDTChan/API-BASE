using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BIEU02")]
    public class PHF_BIEU02 : BaseEntity
    {
        [Column("MA_DVQHNS")]
        [StringLength(10)]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(100)]
        public string TEN_DVQHNS { get; set; }

        [Column("MA_CTMTQG")]
        [StringLength(10)]
        public string MA_CTMTQG { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(10)]
        public string MA_CHUONG { get; set; }

        [Column("MA_MUC")]
        [StringLength(10)]
        public string MA_MUC { get; set; }

        [Column("MA_TIEUMUC")]
        [StringLength(10)]
        public string MA_TIEUMUC { get; set; }

        [Column("MA_NGANHKT")]
        [StringLength(200)]
        public string MA_NGANHKT { get; set; }

        [Column("MA_LOAI")]
        [StringLength(10)]
        public string MA_LOAI { get; set; }

        [Column("SO_TIEN")]
        public decimal SOTIEN { get; set; }

    }
}
