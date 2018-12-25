using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_SOANTHAO_THANHTRA")]
    public class PHF_SOANTHAO_THANHTRA : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("NAM_THANHTRA")]
        public int NAM_THANHTRA { get; set; }

        [Column("MA_DOITUONG_TT")]
        [StringLength(50)]
        public string MA_DOITUONG_TT { get; set; }

        [Column("MA_PHONGBAN")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(500)]
        public string NOI_DUNG { get; set; }

        [Column("DOT_THANHTRA")]
        [StringLength(50)]
        public string DOT_THANHTRA { get; set; }
    }
}
