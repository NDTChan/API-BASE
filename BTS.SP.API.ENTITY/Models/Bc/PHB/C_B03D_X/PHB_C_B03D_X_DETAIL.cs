using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03D_X
{
    [Table("PHB_C_B03D_X_DETAIL")]
    public class PHB_C_B03D_X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B03D_X_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B03D_X")]
        [StringLength(50)]
        public string PHB_C_B03D_X_REFID { get; set; }

        [Column("MACHITIEU")]
        [StringLength(20)]
        [Description("Mã chỉ tiêu")]
        public string MACHITIEU { get; set; }

        [Column("TENCHITIEU")]
        [StringLength(255)]
        [Description("Tên chỉ tiêu")]
        public string TENCHITIEU { get; set; }

        [Column("TENCHITIEU_OLD")]
        [StringLength(255)]
        [Description("Tên chỉ tiêu cũ")]
        public string TENCHITIEU_OLD { get; set; }

        [Column("STTCHITIEU")]
        [StringLength(20)]
        [Description("stt chỉ tiêu")]
        public string STTCHITIEU { get; set; }

        [Column("DUTOANNAM")]
        [Description("dự toán năm")]
        public double DUTOANNAM { get; set; }

        [Column("QUYETTOANNAM")]
        [Description("quyết toán năm")]
        public double QUYETTOANNAM { get; set; }


    }
}
