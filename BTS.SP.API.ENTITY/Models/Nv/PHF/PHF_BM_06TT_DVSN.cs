using BTS.SP.API.ENTITY;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_06TT_DVSN")]
    public class PHF_BM_06TT_DVSN : DataInfoEntityPHF
    {
        [Column("STT")]
        [Description("Số thứ tự")]
        public int STT { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        [Description("Mã Đơn vị")]
        public string MA_DONVI { get; set; }

        [Column("THOI_KY")]
        [StringLength(500)]
        [Description("Thời kỳ")]
        public string THOI_KY { get; set; }

        [Column("MA_FILE")]
        [StringLength(200)]
        [Description("Mã file Template")]
        public string MA_FILE { get; set; }

        [Column("MA_FILE_PK")]
        [StringLength(200)]
        [Description("Mã file pk Template")]
        public string MA_FILE_PK { get; set; }

        [Column("NOIDUNG_CHI")]
        [StringLength(1000)]
        [Description("Nội dung chi")]
        public string NOIDUNG_CHI { get; set; }

        [Column("SOTIEN")]
        [Description("Số tiền")]
        public decimal? SOTIEN { get; set; }

        [Column("TITLE_NGUYENNHAN")]
        [Description("Tên Nguyên nhân")]
        public string TITLE_NGUYENNHAN { get; set; }

        [Column("NGUYENNHAN")]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

    }
}
