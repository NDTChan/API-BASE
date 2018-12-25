using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.PL42_P1_TT01
{
    public class PHB_PL42_P1_TT01_DETAIL : DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHB_PL42_P1_TT01_REFID { get; set; }

        [StringLength(120)]
        public string MASO { get; set; }

        [StringLength(250)]
        public string CHITIEU { get; set; }

        [StringLength(120)]
        public string DON_VI { get; set; }

        [StringLength(120)]
        public string LOAI_KHOAN { get; set; }

        public decimal SO_TIEN { get; set; }
    }
}
