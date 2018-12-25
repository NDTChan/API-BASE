using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_KH_THANHTRA_COQUAN_CT")]
    public class PHF_KH_THANHTRA_COQUAN_CT : BaseEntity
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
