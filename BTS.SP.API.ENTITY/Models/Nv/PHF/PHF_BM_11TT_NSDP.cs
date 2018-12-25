using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_11TT_NSDP")]
    public class PHF_BM_11TT_NSDP : DataInfoEntityPHF
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

        [Column("TEN_DUAN")]
        [StringLength(1000)]
        [Description("Tên dự án")]
        public string TEN_DUAN { get; set; }

        [Column("TONG_DUTOAN")]
        [StringLength(500)]
        [Description("Tổng dự toán được duyệt")]
        public string TONG_DUTOAN { get; set; }

        [Column("KEHOACH_VON")]
        [StringLength(300)]
        [Description("Kế hoạch vốn")]
        public string KEHOACH_VON { get; set; }

        [Column("KHOILUONG_TRONGNAM")]
        [StringLength(500)]
        [Description("Khối lượng trong năm")]
        public string KHOILUONG_TRONGNAM { get; set; }

        [Column("KHOILUONG_LUYKE")]
        [StringLength(500)]
        [Description("Khối lượng lũy kế")]
        public string KHOILUONG_LUYKE { get; set; }

        [Column("TONGSO_TAMUNG")]
        [StringLength(500)]
        [Description("Tổng số tạm ứng")]
        public string TONGSO_TAMUNG { get; set; }

        [Column("THANHTOAN_TONGSO")]
        [StringLength(500)]
        [Description("Thanh toán trong năm tổng số")]
        public string THANHTOAN_TONGSO { get; set; }

        [Column("THANHTOAN_THANHTOAN")]
        [StringLength(500)]
        [Description("Thanh toán trong năm thanh toán")]
        public string THANHTOAN_THANHTOAN { get; set; }

        [Column("THANHTOAN_TAMUNG")]
        [StringLength(500)]
        [Description("Thanh toán trong năm tạm ứng")]
        public string THANHTOAN_TAMUNG { get; set; }

        [Column("LUYKE_TONGSO")]
        [StringLength(500)]
        [Description("Lũy kế tổng số")]
        public string LUYKE_TONGSO { get; set; }

        [Column("LUYKE_TAMUNG")]
        [StringLength(500)]
        [Description("Lũy kế tạm ứng")]
        public string LUYKE_TAMUNG { get; set; }

        [Column("GIAINGAN_KHONGDUOC")]
        [StringLength(500)]
        [Description("Tình hình giải ngân không giải ngân được")]
        public string GIAINGAN_KHONGDUOC { get; set; }

        [Column("GIAINGAN_CHAM")]
        [StringLength(500)]
        [Description("Tình hình giải ngân chậm")]
        public string GIAINGAN_CHAM { get; set; }

        [Column("SAIPHAM_HOSO")]
        [StringLength(500)]
        [Description("Sai phạm hồ sơ thủ tục")]
        public string SAIPHAM_HOSO { get; set; }

        [Column("SAIPHAM_NGHIEMTHU")]
        [StringLength(500)]
        [Description("Sai phạm khối lượng nghiệm thu")]
        public string SAIPHAM_NGHIEMTHU { get; set; }

        [Column("SAIPHAM_THOIGIAN")]
        [StringLength(500)]
        [Description("Sai phạm thời gian")]
        public string SAIPHAM_THOIGIAN { get; set; }

        [Column("SAIPHAM_TAMUNG")]
        [StringLength(500)]
        [Description("Sai phạm tạm ứng")]
        public string SAIPHAM_TAMUNG { get; set; }

        [Column("SAIPHAM_THUHOI")]
        [StringLength(500)]
        [Description("Sai phạm thu hồi")]
        public string SAIPHAM_THUHOI { get; set; }

        [Column("SAIPHAM_BOSUNG")]
        [StringLength(500)]
        [Description("Sai phạm bổ sung")]
        public string SAIPHAM_BOSUNG { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
