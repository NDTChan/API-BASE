using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_QUANLY_VB_HS")]
    public class PHE_QUANLY_VB_HS : DataInfoEntity
    {
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_LOAIVANBAN")]
        [StringLength(50)]
        public string MA_LOAIVANBAN { get; set; }

        [Column("MA_NHOMVANBAN")]
        [StringLength(50)]
        public string MA_NHOMVANBAN { get; set; }

        [Column("MA_DONVI_GUI")]
        [StringLength(2000)]
        public string MA_DONVI_GUI { get; set; }

        [Column("MA_DONVI_NHAN")]
        [StringLength(2000)]
        public string MA_DONVI_NHAN { get; set; }

        [Column("MA_HOSO")]
        [StringLength(50)]
        public string MA_HOSO { get; set; }

        [Required]
        [Column("SOHIEU_VANBAN")]
        [StringLength(100)]
        public string SOHIEU_VANBAN { get; set; }

        [Column("NGAY_KY")]
        public DateTime? NGAY_KY { get; set; }

        [Column("NGAY_DEN")]
        public DateTime? NGAY_DEN { get; set; }

        [Column("MA_CANBO")]
        public string MA_CANBO { get; set; }

        [Column("MA_CONGVIEC")]
        public string MA_CONGVIEC { get; set; }

        [Column("TEP_DINHKEM")]
        public string TEP_DINHKEM { get; set; }

        [Column("MA_PHONGBAN")]
        [StringLength(100)]
        public string MA_PHONGBAN { get; set; }

        [Column("MA_DONVI_ND")]
        [StringLength(100)]
        public string MA_DONVI_ND { get; set; }

        [Column("TYPE_VANBAN")]
        [StringLength(50)]
        public string TYPE_VANBAN { get; set; }

        [Column("NOIDUNG")]
        public string NOIDUNG { get; set; }

        [Column("SO_DEN")]
        public int? SO_DEN { get; set; }

        [Column("SO_DI")]
        public int? SO_DI { get; set; }

        [Column("CANBO_XULY")]
        public string CANBO_XULY { get; set; }

        [Column("CANBO_PHOIHOP")]
        public string CANBO_PHOIHOP { get; set; }

        [Column("CANBO_PHUCTRACH")]
        public string CANBO_PHUCTRACH { get; set; }
    }
}
