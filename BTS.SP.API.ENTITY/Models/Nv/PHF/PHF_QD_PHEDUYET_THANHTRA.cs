using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_QD_PHEDUYET_THANHTRA")]
    public class PHF_QD_PHEDUYET_THANHTRA : DataInfoEntityPHF
    {
        [Required]
        [Column("SO_QUYETDINH")]
        [StringLength(50)]
        public string SO_QUYETDINH { get; set; }

        [Column("NAM_THANHTRA")]
        public int NAM_THANHTRA { get; set; }

        [Column("DOT_THANHTRA")]
        [StringLength(100)]
        public string DOT_THANHTRA { get; set; }

        [Column("NGAY_QUYETDINH")]
        public DateTime NGAY_QUYETDINH { get; set; }

        [Column("FILE_DINHKEM")]
        [StringLength(1000)]
        public string FILE_DINHKEM { get; set; }
    }
}
