using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHITIET_THONGTIN_DUAN")]
    public class PHE_CHITIET_THONGTIN_DUAN : DataInfoEntity
    {
        [Required]
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }
        [Column("MA_CHIPHI")]
        [StringLength(50)]
        public string MA_CHIPHI { get; set; }
        [Column("MA_CHA")]
        [StringLength(50)]
        public string MA_CHA { get; set; }
        [Column("CONGTHUC")]
        public string CONGTHUC { get; set; }

        [Column("LOAI_NGOAITE")]
        [StringLength(50)]
        public string LOAI_NGOAITE { get; set; }
        [Column("TIGIA")]
        public double? TIGIA { get; set; }
        [Column("DVT")]
        public int? DVT { get; set; }
        [Column("SO_LUONG")]
        public int? SO_LUONG { get; set; }
        [Column("DONGIA_TRUOCTHUE")]
        public Decimal? DONGIA_TRUOCTHUE { get; set; }
        [Column("VAT")]
        public double? VAT { get; set; }
        [Column("DONGIA_SAUTHUE")]
        public Decimal? DONGIA_SAUTHUE { get; set; }
        [Column("GIATRI_TRUOCTHUE")]
        public Decimal? GIATRI_TRUOCTHUE { get; set; }
        [Column("GIATRI_SAUTHUE")]
        public Decimal? GIATRI_SAUTHUE { get; set; }

        [Column("GHICHU")]
        [StringLength(500)]
        public string GHICHU { get; set; }
    }
}
