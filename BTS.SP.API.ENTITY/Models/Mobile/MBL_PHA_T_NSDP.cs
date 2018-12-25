using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_T_NSDP : DataInfoEntity
    {
        [Column("T_DT")]
        public Int64? T_DT { get; set; }

        [Column("T_CG")]
        public Int64? T_CG { get; set; }

        [Column("T_CN")]
        public Int64? T_CN { get; set; }

        [Column("T_NNS")]
        public Int64? T_NNS { get; set; }

        [Column("T_KDNS")]
        public Int64? T_KDNS { get; set; }

        [Column("T_KBNN")]
        public Int64? T_KBNN { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }
    }
}
