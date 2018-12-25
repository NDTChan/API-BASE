using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_THUYETMINHTAICHINHDETAILS")]
    public class PHC_THUYETMINHTAICHINHDETAILS : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Column("CHITIEU")]
        [Description("Chỉ tiêu")]
        public string CHITIEU { get; set; }

        [Column("SODAUNAM")]
        [Description("Số đầu năm")]
        public Nullable<decimal> SODAUNAM { get; set; }

        [Column("SOPHATSINH_TANG")]
        [Description("Số phát sinh tăng")]
        public Nullable<decimal> SOPHATSINH_TANG { get; set; }

        [Column("SOPHATSINH_GIAM")]
        [Description("Số phát sinh giảm")]
        public Nullable<decimal> SOPHATSINH_GIAM { get; set; }

        [Column("SOCUOINAM")]
        [Description("Số cuối năm")]
        public Nullable<decimal> SOCUOINAM { get; set; }

    }
}
