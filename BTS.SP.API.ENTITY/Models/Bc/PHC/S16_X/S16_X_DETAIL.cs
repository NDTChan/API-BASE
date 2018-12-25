using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Bc.PHC.S16_X
{
    [Table("PHC_S16_X_DETAIL")]
    public class S16_X_DETAIL : DataInfoEntity
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("TENHO")]
        [Required]
        [StringLength(500)]
        [Description("TÊN HỘ")]
        public string TENHO { get; set; }

        [Column("DIACHI")]
        [StringLength(1000)]
        [Description("ĐỊA CHỈ")]
        public string DIACHI { get; set; }

        [Column("SOPHAITHU_NAMTRUOC")]
        [Description("Số phải thu năm trước chuyển sang")]
        public Nullable<decimal> SOPHAITHU_NAMTRUOC { get; set; }

        [Column("THUNAMNAY_SL1")]
        [Description("Thu năm nay số lượng 1 : Vụ chiêm")]
        public Nullable<decimal> THUNAMNAY_SL1 { get; set; }

        [Column("THUNAMNAY_GT1")]
        [Description("Thu năm nay giá trị 1 : Vụ mùa")]
        public Nullable<decimal> THUNAMNAY_GT1 { get; set; }

        [Column("THUNAMNAY_SL2")]
        [Description("Thu năm nay số lượng 2 : Vụ chiêm")]
        public Nullable<decimal> THUNAMNAY_SL2 { get; set; }

        [Column("THUNAMNAY_GT2")]
        [Description("Thu năm nay giá trị 2 : Vụ mùa")]
        public Nullable<decimal> THUNAMNAY_GT2 { get; set; }

        [Column("THUNAMNAY_CONGPHAITHU")]
        [Description("Thu năm cộng phải thu")]
        public Nullable<decimal> THUNAMNAY_CONGPHAITHU { get; set; }

        [Column("SUM_SPNOP_NAMNAY")]
        [Description("Tổng số phải nộp năm nay")]
        public Nullable<decimal> SUM_SPNOP_NAMNAY { get; set; }

        [Column("DANOP_VU1")]
        [Description("Đã nộp vụ 1")]
        public Nullable<decimal> DANOP_VU1 { get; set; }

        [Column("DANOP_VU2")]
        [Description("Đã nộp vụ 2")]
        public Nullable<decimal> DANOP_VU2 { get; set; }

        [Column("DANOP_CONGSO")]
        [Description("Đã nộp cộng số đã nộp")]
        public Nullable<decimal> DANOP_CONGSO { get; set; }

        [Column("SOCONNO_NAMSAU")]
        [Description("Số còn nợ chuyển năm sau")]
        public Nullable<decimal> SOCONNO_NAMSAU { get; set; }
    }
}
