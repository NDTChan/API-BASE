using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B04X
{
    [Table("PHB_C_B04X_DETAIL")]
    public class PHB_C_B04X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B04X_REFID")]
        [Required]
        [Description("Guid ID trong PHB_C_B04X")]
        [StringLength(50)]
        public string PHB_C_B04X_REFID { get; set; }

        [Column("CHI_TIEU")]
        [Description("Chỉ tiêu")]
        [Required]
        [StringLength(50)]
        public string CHI_TIEU { get; set; }

        [Column("CHI_TIEU_OLD")]
        [Description("Chỉ tiêu cũ")]
        [StringLength(50)]
        public string CHI_TIEU_OLD { get; set; }

        [Column("SO_DAUNAM")]
        [Description("Số đầu năm")]
        public Nullable<decimal> SO_DAUNAM { get; set; }

        [Column("PHATSINH_TANG")]
        [Description("Số phát sinh tăng")]
        public Nullable<decimal> PHATSINH_TANG { get; set; }

        [Column("PHATSINH_GIAM")]
        [Description("Số phát sinh giảm")]
        public Nullable<decimal> PHATSINH_GIAM { get; set; }

        [Column("CUOINAM")]
        [Description("Số cuối năm")]
        public Nullable<decimal> CUOINAM { get; set; }

    }
}
