using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_TIENDO_THUCHIEN_KH_CT")]
    public class PHF_TIENDO_THUCHIEN_KH_CT : BaseEntity
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("DOI_TUONG_TT")]
        [StringLength(500)]
        public string DOI_TUONG_TT { get; set; }

        [Column("KE_HOACH_TT")]
        [StringLength(500)]
        public string KE_HOACH_TT { get; set; }

        [Column("LOAI_TT")]
        [StringLength(500)]
        public string LOAI_TT { get; set; }

        [Column("NHOM_TT")]
        [StringLength(500)]
        public string NHOM_TT { get; set; }

        [Column("PHONG_TT")]
        [StringLength(500)]
        public string PHONG_TT { get; set; }

        [Column("TRUONGDOAN_TT")]
        [StringLength(500)]
        public string TRUONGDOAN_TT { get; set; }

        [Column("THANHVIEN_DOAN")]
        [StringLength(500)]
        public string THANHVIEN_DOAN { get; set; }

        [Column("SO_NGAY_THANG_QG")]
        [StringLength(500)]
        public string SO_NGAY_THANG_QG { get; set; }

        [Column("THOIHAN_TT")]
        [StringLength(500)]
        public string THOIHAN_TT { get; set; }

        [Column("NGAY_TRIENKHAI")]
        public DateTime? NGAY_TRIENKHAI { get; set; }

        [Column("NGAY_KETTHUC")]
        public DateTime? NGAY_KETTHUC { get; set; }

        [Column("GIAMSAT_DOAN")]
        [StringLength(500)]
        public string GIAMSAT_DOAN { get; set; }

        [Column("MA_DOITUONG")]
        [StringLength(500)]
        public string MA_DOITUONG { get; set; }

        [Column("MA_DOITUONG_CHA")]
        [StringLength(500)]
        public string MA_DOITUONG_CHA { get; set; }

    }
}
