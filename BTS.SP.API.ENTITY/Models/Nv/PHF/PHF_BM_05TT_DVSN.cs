using BTS.SP.API.ENTITY;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_05TT_DVSN")]
    public class PHF_BM_05TT_DVSN : DataInfoEntityPHF
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

        [Column("HOTEN")]
        [StringLength(1000)]
        [Description("Họ và tên")]
        public string HOTEN { get; set; }

        [Column("CHILUONG_SAI_CHEDO")]
        [Description("Chi lương sai chế độ")]
        public decimal? CHILUONG_SAI_CHEDO { get; set; }

        [Column("CHIBH_SAI_CHEDO")]
        [Description("Chi bảo hiểm sai chế độ")]
        public decimal? CHIBH_SAI_CHEDO { get; set; }

        [Column("CHITN_SAI_CHEDO")]
        [Description("Chi thu nhập sai chế độ")]
        public decimal? CHITN_SAI_CHEDO { get; set; }

        [Column("CHI_KHAC")]
        [Description("Chi khác")]
        public decimal? CHI_KHAC { get; set; }

        [Column("GHICHU")]
        [StringLength(5000)]
        [Description("Ghi chú")]
        public string GHICHU { get; set; }

    }
}
