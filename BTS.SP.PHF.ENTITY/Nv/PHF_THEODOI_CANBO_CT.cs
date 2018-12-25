using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_THEODOI_CANBO_CT")]
    public class PHF_THEODOI_CANBO_CT : BaseEntity
    {
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("TEN_CANBO")]
        [StringLength(500)]
        public string TEN_CANBO { get; set; }

        //[Column("MA_CHUCVU")]
        //[StringLength(50)]
        //public string MA_CHUCVU { get; set; }
        [Column("CHUCVU")]
        [StringLength(500)]
        public string CHUCVU { get; set; }

        [Column("GIOI_TINH")]
        public int? GIOI_TINH { get; set; }

        [Column("NGAY_SINH")]
        public DateTime? NGAY_SINH { get; set; }

        //[Column("SO_PHONG")]
        //[StringLength(50)]
        //public string SO_PHONG { get; set; }
        [Column("PHONGBAN")]
        [StringLength(500)]
        public string PHONGBAN { get; set; }

        [Column("SO_MAY_LE")]
        [StringLength(50)]
        public string SO_MAY_LE { get; set; }

        [Column("SO_DI_DONG")]
        [StringLength(50)]
        public string SO_DI_DONG { get; set; }

        [Column("TEN_DOT_THANHTRA")]
        [StringLength(500)]
        public string TEN_DOT_THANHTRA { get; set; }

        [Column("SO_QUYETDINH")]
        [StringLength(50)]
        public string SO_QUYETDINH { get; set; }

        [Column("STT")]
        public int? STT { get; set; }
    }
}
