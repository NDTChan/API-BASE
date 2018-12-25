using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B02B_X
{
    public class PHB_C_B02B_X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B02B_X_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B02B_X")]
        [StringLength(50)]
        public string PHB_C_B02B_X_REFID { get; set; }

        [Column("STT")]
        [Description("Số thứ tự")]
        [StringLength(5)]
        public string STT { get; set; }

        public int SAPXEP { get; set; }

        [Column("NOIDUNG")]
        [Description("Nội dung chỉ tiêu")]
        [StringLength(250)]
        public string NOIDUNG { get; set; }

        [Column("NOIDUNG_OLD")]
        [Description("Nội dung chỉ tiêu")]
        [StringLength(250)]
        public string NOIDUNG_OLD { get; set; }

        public int MASO { get; set; }

        public double DUTOANNAM { get; set; }
        public double TRONGTHANG { get; set; }
        public double LUYKE { get; set; }
        public double SOSANH { get; set; }
    }
}
