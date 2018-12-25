using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_T_DIABAN : DataInfoEntity
    {
    
        [Column("SOTIEN")]
        public Int64? SOTIEN { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }
    }
}
