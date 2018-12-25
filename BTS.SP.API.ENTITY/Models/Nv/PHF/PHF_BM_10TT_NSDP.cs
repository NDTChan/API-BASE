using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_10TT_NSDP")]
    public class PHF_BM_10TT_NSDP : DataInfoEntityPHF
    {
        [Column("STT")]
        [Description("Số thứ tự")]
        public int STT { get; set; }

        [Column("STT_TIEUDE")]
        [Description("Số thứ tự tiêu đề")]
        [StringLength(5)]
        public string STT_TIEUDE { get; set; }

        [Column("STT_CHA")]
        [Description("Số thứ tự cha")]
        public int STT_CHA { get; set; }

        [Column("MA_FILE")]
        [StringLength(200)]
        [Description("Mã file Template")]
        public string MA_FILE { get; set; }

        [Column("MA_FILE_PK")]
        [StringLength(200)]
        [Description("Mã file pk Template")]
        public string MA_FILE_PK { get; set; }

        [Column("TEN_NGUONVON")]
        [StringLength(1000)]
        [Description("Tên nguồn vốn")]
        public string TEN_NGUONVON { get; set; }

        [Column("DUTOAN")]
        [StringLength(500)]
        [Description("Dự toán")]
        public string DUTOAN { get; set; }

        [Column("SO_PHANBO")]
        [StringLength(300)]
        [Description("Số phân bổ")]
        public string SO_PHANBO { get; set; }

        [Column("TONGSO_GIAINGAN")]
        [StringLength(500)]
        [Description("Tổng số giải ngân")]
        public string TONGSO_GIAINGAN { get; set; }

        [Column("TONGSO_THANHTOAN")]
        [StringLength(500)]
        [Description("Tổng số thanh toán")]
        public string TONGSO_THANHTOAN { get; set; }

        [Column("TONGSO_TAMUNG")]
        [StringLength(500)]
        [Description("Tổng số tạm ứng")]
        public string TONGSO_TAMUNG { get; set; }

        [Column("TYLE_DUTOAN")]
        [StringLength(500)]
        [Description("Tỷ lệ dự toán")]
        public string TYLE_DUTOAN { get; set; }

        [Column("TYLE_PHANBO")]
        [StringLength(500)]
        [Description("Tỷ lệ phân bổ")]
        public string TYLE_PHANBO { get; set; }

        [Column("GHICHU")]
        [StringLength(1500)]
        [Description("Ghi chú")]
        public string GHICHU { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
