using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_TMTCTEMPLATE")]
    public class PHC_TMTCTEMPLATE : DataInfoEntity
    {
        [Column("CHITIEU")]
        [Description("Chỉ tiêu")]
        public string CHITIEU { get; set; }
    }
}
