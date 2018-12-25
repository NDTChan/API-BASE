using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHITIET_QUANLY_KL_THICONG")]
    public class PHE_CHITIET_QUANLY_KL_THICONG : DataInfoEntity
    {
        [Column("MA_KHOILUONG")]
        [StringLength(50)]
        public string MA_KHOILUONG { get; set; }

        [Column("MA_GOITHAU")]
        [StringLength(50)]
        public string MA_GOITHAU { get; set; }

        [Column("MA_CHIPHI")]
        [StringLength(50)]
        public string MA_CHIPHI { get; set; }

        [Column("GIATIEN_TRUNGTHAU")]
        public decimal GIATIEN_TRUNGTHAU { get; set; }

        [Column("GIATIEN_PHIEUHOANTHANH")]
        public decimal GIATIEN_PHIEUHOANTHANH { get; set; }

        [Column("FILE_DINHKEM")]
        public string FILE_DINHKEM { get; set; }


    }
}
