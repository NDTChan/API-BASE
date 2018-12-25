using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B04H
{
    [Table("PHB_B04H_TEMPLATE")]
    public class PHB_B04H_TEMPLATE:DataInfoEntity
    {
        [Column("MA_TEMPLATE")]
        [Required]
        [StringLength(15)]
        public string MA_TEMPLATE { get; set; }

        [Column("TSCD_STT")]
        [StringLength(15)]
        public string TSCD_STT { get; set; }

        [Column("TSCD_ID")]
        [Required]
        public int TSCD_ID { get; set; }

        [Column("TSCD_TEN")]
        [Required]
        [StringLength(250)]
        public string TSCD_TEN { get; set; }

        [Column("CAP")]
        public int? CAP { get; set; }

        [Column("CONG_THUC")]
        [StringLength(250)]
        public string CONG_THUC { get; set; }

        [Column("TRANG_THAI")]
        [Required]
        public int TRANG_THAI { get; set; }
    }
}
