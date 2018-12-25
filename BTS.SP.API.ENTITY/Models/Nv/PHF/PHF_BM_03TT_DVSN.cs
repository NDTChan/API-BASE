using BTS.SP.API.ENTITY;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_03TT_DVSN")]
    public class PHF_BM_03TT_DVSN : DataInfoEntityPHF
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

        [Column("NGUONTHU")]
        [StringLength(1000)]
        [Description("Nguồn thu")]
        public string NGUONTHU { get; set; }

        [Column("THUCTHI_DUOCGIAO")]
        [Description("Thực thi được giao")]
        public decimal? THUCTHI_DUOCGIAO { get; set; }

        [Column("THANHTRA_XACDINH")]
        [Description("Thanh tra xác định")]
        public decimal? THANHTRA_XACDINH { get; set; }

        [Column("TITLE_NGUYENNHAN")]
        [Description("Tên Nguyên nhân")]
        public string TITLE_NGUYENNHAN { get; set; }

        [Column("NGUYENNHAN")]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("GHICHU")]
        [StringLength(5000)]
        [Description("Ghi chú")]
        public string GHICHU { get; set; }
    }
}
