using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_XD_KH_THANHTRA_BO_CHITIET")]
    public class PHF_XD_KH_THANHTRA_BO_CHITIET : BaseEntity
    {
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("KEHOACH_THANHTRA")]
        [StringLength(50)]
        public string KEHOACH_THANHTRA { get; set; }

        [Column("LOAI_THANHTRA")]
        [StringLength(50)]
        public string LOAI_THANHTRA { get; set; }

        [Column("NHOM_THANHTRA")]
        [StringLength(50)]
        public string NHOM_THANHTRA { get; set; }

        [Column("PHONG_THANHTRA")]
        [StringLength(50)]
        public string PHONG_THANHTRA { get; set; }

        [Column("DOITUONG_THANHTRA")]
        [StringLength(50)]
        public string DOITUONG_THANHTRA { get; set; }

        [Column("LYDO_THANHTRA")]
        [StringLength(1000)]
        public string LYDO_THANHTRA { get; set; }

        [Column("MA_DOITUONG")]
        [StringLength(50)]
        public string MA_DOITUONG { get; set; }

        [Column("MA_DOITUONG_CHA")]
        [StringLength(50)]
        public string MA_DOITUONG_CHA { get; set; }

        [Column("TEN_DOITUONG")]
        [StringLength(500)]
        public string TEN_DOITUONG { get; set; }

        [Column("PHONG_CHUTRI")]
        [StringLength(50)]
        public string PHONG_CHUTRI { get; set; }
    }
}

