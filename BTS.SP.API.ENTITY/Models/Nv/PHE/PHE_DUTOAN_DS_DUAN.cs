using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_DUTOAN_DS_DUAN")]
    public class PHE_DUTOAN_DS_DUAN : DataInfoEntity
    {
        [Required]
        [Column("MA_DUTOAN")]
        [StringLength(50)]
        public string MA_DUTOAN { get; set; }

        [Required]
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_NGUONVON")]
        [StringLength(50)]
        public string MA_NGUONVON { get; set; }

        [Column("KHOAN_CHI")]
        [StringLength(250)]
        public string KHOAN_CHI { get; set; }

        [Column("GIAI_DOAN_VON")]
        [StringLength(50)]
        public string GIAI_DOAN_VON { get; set; }

        public decimal SO_TIEN { get; set; }
    }
}
