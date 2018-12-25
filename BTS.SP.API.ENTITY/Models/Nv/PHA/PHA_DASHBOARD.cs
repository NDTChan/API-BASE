using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_DASHBOARD")]
    public class PHA_DASHBOARD : DataInfoEntity
    {
        [Column("T_TW")]
        public Int64? T_TW { get; set; }

        [Column("T_TI")]
        public Int64? T_TI { get; set; }

        [Column("T_HU")]
        public Int64? T_HU { get; set; }

        [Column("T_XA")]
        public Int64? T_XA { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("C_TW")]
        public Int64? C_TW { get; set; }

        [Column("C_TI")]
        public Int64? C_TI { get; set; }

        [Column("C_HU")]
        public Int64? C_HU { get; set; }

        [Column("C_XA")]
        public Int64? C_XA { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }
        
        [Column("THANG")]
        public int? THANG { get; set; }

    }
}
