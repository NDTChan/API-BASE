using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_XD_KH_TT_THUOC_BO_CT")]
    public class PHF_XD_KH_TT_THUOC_BO_CT : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_PHIEU")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("LOAI_THANHTRA")]
        [StringLength(50)]
        public string LOAI_THANHTRA { get; set; }

        [Column("NHOM_THANHTRA")]
        [StringLength(50)]
        public string NHOM_THANHTRA { get; set; }

        [Column("DOITUONG_THANHTRA")]
        [StringLength(50)]
        public string DOITUONG_THANHTRA { get; set; }

        [Column("COQUAN_THANHTRA")]
        [StringLength(50)]
        public string COQUAN_THANHTRA { get; set; }

        [Column("NOIDUNG_THANHTRA")]
        [StringLength(200)]
        public string NOIDUNG_THANHTRA { get; set; }

        [Column("THOIKY_THANHTRA")]
        [StringLength(200)]
        public string THOIKY_THANHTRA { get; set; }

        [Column("TEP_DINHKEM")]
        [StringLength(300)]
        public string TEP_DINHKEM { get; set; }
    }
}
