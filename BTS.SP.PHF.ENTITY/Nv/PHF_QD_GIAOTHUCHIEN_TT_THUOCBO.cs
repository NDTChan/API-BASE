using BTS.SP.PHF.ENTITY;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_QD_GIAOTHUCHIEN_TT_THUOCBO")]
    public class PHF_QD_GIAOTHUCHIEN_TT_THUOCBO : BaseEntity
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

        [Column("MA_DONVI")]
        [StringLength(50)]
        public string MA_DONVI { get; set; }

        [Column("FILE_DINHKEM")]
        [StringLength(1000)]
        public string FILE_DINHKEM { get; set; }
    }
}
