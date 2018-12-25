using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.PL32_P1_TT01
{
    public class PHB_PL32_P1_TT01_DETAIL : DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHB_PL32_P1_TT01_REFID { get; set; }

        [StringLength(120)]
        public string MASO { get; set; }

        [StringLength(250)]
        public string CHITIEU { get; set; }

        [StringLength(120)]
        public string LOAI_KHOAN { get; set; }

        public double? SO_BAOCAO { get; set; }
        public double? SO_XETDUYET { get; set; }
        public double? CHENH_LECH { get; set; }
    }
}
