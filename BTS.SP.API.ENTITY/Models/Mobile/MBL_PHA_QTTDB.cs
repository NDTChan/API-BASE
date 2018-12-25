using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_QTTDB : DataInfoEntity
    {
        [Column("DT")]
        public Int64? DT { get; set; }

        [Column("QT")]
        public Int64? QT { get; set; }

        [Column("LOAIQT")]
        [StringLength(4)]
        public string LOAIQT { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }
    }
}
