using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_SOANTHAO_THANHTRA_CT")]
    public class PHF_SOANTHAO_THANHTRA_CT : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("LOAI_TT")]
        [StringLength(50)]
        public string LOAI_TT { get; set; }

        [Column("NHOM_TT")]
        [StringLength(50)]
        public string NHOM_TT { get; set; }

        [Column("DOI_TUONG_TT")]
        [StringLength(50)]
        public string DOI_TUONG_TT { get; set; }

        [Column("COQUAN_TT")]
        [StringLength(50)]
        public string COQUAN_TT { get; set; }

        [Column("NOIDUNG_THANHTRA")]
        [StringLength(1000)]
        public string NOIDUNG_THANHTRA { get; set; }

        [Column("THOIKY_TT")]
        [StringLength(50)]
        public string THOIKY_TT { get; set; }

        [Column("TEP_DINHKEM")]
        [StringLength(1000)]
        public string TEP_DINHKEM { get; set; }
    }
}
