using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB
{
    [Table("PHB_REPORT_FIELD")]
    public class PHB_REPORT_FIELD:DataInfoEntity
    {
        [Column("MA_BAO_CAO")]
        [Required]
        [StringLength(15)]
        public string MA_BAO_CAO { get; set; }

        [Column("HEADER_XML_FIELD")]
        [Required]
        [StringLength(2000)]
        public string HEADER_XML_FIELD { get; set; }

        [Column("HEADER_REPORT_FIELD")]
        [Required]
        [StringLength(2000)]
        public string HEADER_REPORT_FIELD { get; set; }

        [Column("DATA_XML_FIELD")]
        [Required]
        [StringLength(2000)]
        public string DATA_XML_FIELD { get; set; }

        [Column("DATA_REPORT_FIELD")]
        [Required]
        [StringLength(2000)]
        public string DATA_REPORT_FIELD { get; set; }

    }
}
