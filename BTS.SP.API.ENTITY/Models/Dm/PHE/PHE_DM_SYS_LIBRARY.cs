using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_SYS_LIBRARY")]
    public class PHE_DM_SYS_LIBRARY : DataInfoEntity
    {
        [Required]
        [Column("MA_MUC")]
        [StringLength(50)]
        public string MA_MUC { get; set; }
        [Column("TEN_MUC")]
        [StringLength(250)]
        public string TEN_MUC { get; set; }
        [Required]
        [Column("FIELD_DM")]
        [StringLength(100)]
        public string FIELD_DM { get; set; }

        [Column("GIA_TRI")]
        public decimal? GIA_TRI { get; set; }
    }
}
