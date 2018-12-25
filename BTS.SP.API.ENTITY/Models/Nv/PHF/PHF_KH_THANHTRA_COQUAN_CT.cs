using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_KH_THANHTRA_COQUAN_CT")]
    public class PHF_KH_THANHTRA_COQUAN_CT : DataInfoEntityPHF
    {
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("LOAI_THANHTRA")]
        [StringLength(50)]
        public string LOAI_THANHTRA { get; set; }

        [Column("NHOM_THANHTRA")]
        [StringLength(50)]
        public string NHOM_THANHTRA { get; set; }

        [Column("DOITUONG_THANHTRA")]
        [StringLength(50)]
        public string DOITUONG_THANHTRA { get; set; }

        [Column("COQUAN_THANHTRA")]
        [StringLength(50)]
        public string COQUAN_THANHTRA { get; set; }

        [Column("NOIDUNG_THANHTRA")]
        [StringLength(1000)]
        public string NOIDUNG_THANHTRA { get; set; }

        [Column("THOIKY_THANHTRA")]
        [StringLength(1000)]
        public string THOIKY_THANHTRA { get; set; }

        [Column("TEP_DINHKEM")]
        [StringLength(1000)]
        public string TEP_DINHKEM { get; set; }
    }
}
