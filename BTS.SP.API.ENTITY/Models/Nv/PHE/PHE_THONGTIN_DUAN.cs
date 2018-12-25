using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_THONGTIN_DUAN")]
    public class PHE_THONGTIN_DUAN : DataInfoEntity
    {
        [Required]
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_DUAN_CHA")]
        [StringLength(50)]
        public string MA_DUAN_CHA { get; set; }

        [Column("TOCHUC_QUANLY_DUAN")]
        [StringLength(50)]
        public string TOCHUC_QUANLY_DUAN { get; set; }
        [Column("TEN_DUAN")]
        [StringLength(500)]
        public string TEN_DUAN { get; set; }
        [Column("CHU_DAUTU")]
        [StringLength(50)]
        public string CHU_DAUTU { get; set; }
        [Column("TOCHUC_LAP_DUAN")]
        [StringLength(50)]
        public string TOCHUC_LAP_DUAN { get; set; }
        [Column("CHUNHIEM_LAP_DUAN")]
        [StringLength(500)]
        public string CHUNHIEM_LAP_DUAN { get; set; }
        [Column("MA_HT_DUAN")]
        [StringLength(50)]
        public string MA_HT_DUAN { get; set; }
        [Column("MA_NHOM_DUAN")]
        [StringLength(50)]
        public string MA_NHOM_DUAN { get; set; }
        [Column("MA_HT_QUANLY")]
        [StringLength(50)]
        public string MA_HT_QUANLY { get; set; }
        [Column("MA_LOAI_DUAN")]
        [StringLength(50)]
        public string MA_LOAI_DUAN { get; set; }
        [Column("MA_CT_MUCTIEU")]
        [StringLength(50)]
        public string MA_CT_MUCTIEU { get; set; }
        [Column("MA_LINHVUC")]
        [StringLength(50)]
        public string MA_LINHVUC { get; set; }
        [Column("NGAY_BATDAU")]
        public DateTime? NGAY_BATDAU { get; set; }
        [Column("NGAY_KETTHUC")]
        public DateTime? NGAY_KETTHUC { get; set; }
        [Column("MA_CAP_CONGTRINH")]
        [StringLength(50)]
        public string MA_CAP_CONGTRINH { get; set; }
        [Column("DIADIEM_MO_TAIKHOAN")]
        [StringLength(500)]
        public string DIADIEM_MO_TAIKHOAN { get; set; }
        [Column("DIADIEM_XAYDUNG")]
        [StringLength(500)]
        public string DIADIEM_XAYDUNG { get; set; }
        [Column("TONGSO_DAUTU")]
        public Decimal? TONGSO_DAUTU { get; set; }
        [Column("NOIDUNG")]
        [StringLength(1000)]
        public string NOIDUNG { get; set; }
        [Column("MUCTIEU_DAUTU")]
        [StringLength(500)]
        public string MUCTIEU_DAUTU { get; set; }
        [Column("NANGLUC_THIETKE")]
        [StringLength(500)]
        public string NANGLUC_THIETKE { get; set; }
        [Column("TEP_DINHKEM")]
        [StringLength(500)]
        public string TEP_DINHKEM { get; set; }
        [Column("GIAIDOAN")]
        [StringLength(500)]
        public string GIAIDOAN { get; set; }
        [Column("MA_TC_DUAN")]
        [StringLength(50)]
        public string MA_TC_DUAN { get; set; }
        [Column("CHUNHIEM_DUAN")]
        [StringLength(50)]
        public string CHUNHIEM_DUAN { get; set; }
        [Column("MA_PHONGBAN")]
        [StringLength(100)]
        public string MA_PHONGBAN { get; set; }
        [Column("MA_DONVI")]
        [StringLength(100)]
        public string MA_DONVI { get; set; }
    }
}
