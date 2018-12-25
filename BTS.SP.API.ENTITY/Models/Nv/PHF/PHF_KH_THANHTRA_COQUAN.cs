using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_KH_THANHTRA_COQUAN")]
    public class PHF_KH_THANHTRA_COQUAN : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("NGAYTHANG_LUUTRU")]
        public DateTime? NGAYTHANG_LUUTRU { get; set; }

        [Column("NOIDUNG")]
        [StringLength(1000)]
        public string NOIDUNG { get; set; }

        [Column("DOT_THANHTRA")]
        [StringLength(50)]
        public string DOT_THANHTRA { get; set; }

        [Column("NAM_THANHTRA")]
        public int? NAM_THANHTRA { get; set; }
    }
}
