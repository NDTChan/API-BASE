using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU07TT344
{
    [Table("PHB_BIEU07TT344_TEMPLATE")]
    public class PHB_BIEU07TT344_TEMPLATE : DataInfoEntity
    {
        [Column("PHB_BIEU07TT344_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU07TT344")]
        [StringLength(50)]
        public string PHB_BIEU07TT344_REFID { get; set; }

        public double TONGTHU { get; set; }
        public double THU_XAHUONG100 { get; set; }
        public double THU_CHIATYLE { get; set; }
        public double THU_BOSUNG { get; set; }
        public double THU_BOSUNGCANDOINS { get; set; }
        public double THU_BOSUNGCOMUCTIEU { get; set; }
        public double THU_KETDUNSNAMTRUOC { get; set; }
        public double THU_VIENTRO { get; set; }
        public double THU_CHUYENNGUON { get; set; }

        public double TONGCHI { get; set; }
        public double CHI_DAUTUPT { get; set; }
        public double CHI_THUONGXUYEN { get; set; }
        public double CHI_CHUYENNGUON { get; set; }
        public double CHI_NOPTRANS { get; set; }

        public double KETDUNS { get; set; }
    }
}
