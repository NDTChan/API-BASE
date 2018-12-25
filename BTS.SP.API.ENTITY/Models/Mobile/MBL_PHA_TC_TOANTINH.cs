using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_TC_TOANTINH : DataInfoEntity
    {
        [Column("T_DIABAN")]
        public Int64? T_DIABAN { get; set; }

        [Column("T_NSNN")]
        public Int64? T_NSNN{ get; set; }

        [Column("T_NSDP")]
        public Int64? T_NSDP{ get; set; }

        [Column("C_NSDP")]
        public Int64? C_NSDP{ get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }
    }
}
