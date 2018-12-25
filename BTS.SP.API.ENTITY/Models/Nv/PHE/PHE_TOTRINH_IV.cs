using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_TOTRINH_IV")]
    public class PHE_TOTRINH_IV : DataInfoEntity
    {
        [Column("SO_TOTRINH")]
        [StringLength(50)]
        public string SO_TOTRINH { get; set; }

        [Column("HANGMUC")]
        [StringLength(500)]
        public string HANGMUC { get; set; }

        [Column("TEN_GOITHAU")]
        [StringLength(200)]
        public string TEN_GOITHAU { get; set; }

        [Column("GIA_GOITHAU")]
        public decimal? GIA_GOITHAU { get; set; }

        [Column("MA_NGUONVON")]
        [StringLength(50)]
        public string MA_NGUONVON { get; set; }

        [Column("HINHTHUC_LUACHON_NT")]
        [StringLength(200)]
        public string HINHTHUC_LUACHON_NT { get; set; }

        [Column("PHUONGTHUC_LUACHON_NT")]
        [StringLength(200)]
        public string PHUONGTHUC_LUACHON_NT { get; set; }

        [Column("THOIGIAN_BATDAU")]
        public DateTime? THOIGIAN_BATDAU { get; set; }

        [Column("LOAI_HOPDONG")]
        [StringLength(50)]
        public string LOAI_HOPDONG { get; set; }

        [Column("THOIGIAN_THUCHIEN")]
        public decimal? THOIGIAN_THUCHIEN { get; set; }

    }
}
