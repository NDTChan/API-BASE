using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Nv
{

    [Table("PHF_BIEU06")]
    public class PHF_BIEU06 : BaseEntity
    {
        [Column("MA_DVQHNS")]
        [StringLength(10)]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(100)]
        public string TEN_DVQHNS { get; set; }

        [Column("MA_NGUON_NSNN")]
        [StringLength(10)]
        public string MA_NGUON_NSNN { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(10)]
        public string MA_CHUONG { get; set; }

        [Column("MA_MUC")]
        [StringLength(10)]
        public string MA_MUC { get; set; }

        [Column("MA_TIEUMUC")]
        [StringLength(10)]
        public string MA_TIEUMUC { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(200)]
        public string NOI_DUNG { get; set; }

        [Column("MA_LOAI")]
        [StringLength(10)]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(10)]
        public string MA_KHOAN { get; set; }

        [Column("SO_TIEN")]
        public decimal SO_TIEN { get; set; }

    }
}
