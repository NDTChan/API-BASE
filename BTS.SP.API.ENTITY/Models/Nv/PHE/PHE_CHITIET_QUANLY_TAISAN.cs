using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHITIET_QUANLY_TAISAN")]
    public class PHE_CHITIET_QUANLY_TAISAN : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        public string MA_CHUNGTU { get; set; }
        [Column("MA_TAISAN")]
        [StringLength(50)]
        public string MA_TAISAN { get; set; }
        [Column("TEN_TAISAN")]
        [StringLength(500)]
        public string TEN_TAISAN { get; set; }
        [Column("DVT")]
        [StringLength(500)]
        public string DVT { get; set; }
        [Column("DONGIA")]
        public Decimal DONGIA { get; set; }
        [Column("DONGIA_QUYDOI")]
        public Decimal DONGIA_QUYDOI { get; set; }
        [Column("SOLUONG")]
        public int SOLUONG { get; set; }
        [Column("TONG_NGUYENGIA")]
        public Decimal TONG_NGUYENGIA { get; set; }
        [Column("TONG_NGUYENGIA_QUYDOI")]
        public Decimal TONG_NGUYENGIA_QUYDOI { get; set; }
    }
}
