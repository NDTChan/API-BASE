using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CT_TT_DT_TMDT")]
    public class PHE_CT_TT_DT_TMDT : DataInfoEntity
    {
        [Column("MA_TT_DT_TMDT")]
        [StringLength(50)]
        public string MA_TT_DT_TMDT { get; set; }

        [Column("MA_CHIPHI")]
        [StringLength(50)]
        public string MA_CHIPHI { get; set; }

        [Column("TEN_CHIPHI")]
        [StringLength(500)]
        public string TEN_CHIPHI { get; set; }

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
        [StringLength(50)]
        public string DVT { get; set; }

        [Column("SO_LUONG")]
        public Decimal? SO_LUONG { get; set; }

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
