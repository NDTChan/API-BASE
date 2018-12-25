using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B04H
{
    [Table("PHB_B04H_DETAIL")]
    public class PHB_B04H_DETAIL : DataInfoEntity
    {
        [Column("PHB_B04H_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B04H")]
        [StringLength(50)]
        public string PHB_B04H_REFID { get; set; }

        [Column("TSCD_ID")]
        [Required]
        public int TSCD_ID { get; set; }

        [Column("TSCD_TEN")]
        [Required]
        [StringLength(250)]
        public string TSCD_TEN { get; set; }

        [Column("DVT")]
        [StringLength(15)]
        public string DVT { get; set; }

        [Column("SODAUNAM_SL")]
        public decimal SODAUNAM_SL { get; set; }

        [Column("SODAUNAM_GT")]
        public decimal SODAUNAM_GT { get; set; }

        [Column("TANGTRONGNAM_SL")]
        public decimal TANGTRONGNAM_SL { get; set; }

        [Column("TANGTRONGNAM_GT")]
        public decimal TANGTRONGNAM_GT { get; set; }

        [Column("GIAMTRONGNAM_SL")]
        public decimal GIAMTRONGNAM_SL { get; set; }

        [Column("GIAMTRONGNAM_GT")]
        public decimal GIAMTRONGNAM_GT { get; set; }

        [Column("SOCUOINAM_SL")]
        public decimal SOCUOINAM_SL { get; set; }

        [Column("SOCUOINAM_GT")]
        public decimal SOCUOINAM_GT { get; set; }

    }
}
