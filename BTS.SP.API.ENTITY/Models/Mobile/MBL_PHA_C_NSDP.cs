using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_C_NSDP : DataInfoEntity
    {
        [Column("T_CCD")]
        public Int64? T_CCD { get; set; }
        [Column("T_CTN")]
        public Int64? T_CTN { get; set; }

        [Column("H_CCD")]
        public Int64? H_CCD { get; set; }
        [Column("H_CTN")]
        public Int64? H_CTN { get; set; }

        [Column("X_CCD")]
        public Int64? X_CCD { get; set; }
        [Column("X_CTN")]
        public Int64? X_CTN { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }

    }
}
