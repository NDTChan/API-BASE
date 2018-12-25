using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_T_NSNN : DataInfoEntity
    {
        [Column("T_TW_100")]
        public Int64? T_TW_100 { get; set; }
        [Column("T_TW_PC")]
        public Int64? T_TW_PC { get; set; }

        [Column("T_T_100")]
        public Int64? T_T_100 { get; set; }
        [Column("T_T_PC")]
        public Int64? T_T_PC { get; set; }

        [Column("T_H_100")]
        public Int64? T_H_100 { get; set; }
        [Column("T_H_PC")]
        public Int64? T_H_PC { get; set; }

        [Column("T_X_100")]
        public Int64? T_X_100 { get; set; }
        [Column("T_X_PC")]
        public Int64? T_X_PC { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }
    }
}
