using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Bc.PHC.QTXDCB
{
    [Table("PHC_QTXDCB_DETAIL")]
    public class QTXDCB_DETAIL : DataInfoEntity
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
    
        [Column("TENCONGTRINH")]
        [Required]
        [StringLength(1000)]
        [Description("TÊN công trình")]
        public string TENCONGTRINH { get; set; }

        [Column("THOIGIAN")]
        [StringLength(200)]
        [Description("Thời gian")]
        public string THOIGIAN { get; set; }

        [Column("ISSTYLE")]
        [Description("ISSTYLE")]
        public Nullable<bool> ISSTYLE { get; set; }

        [Column("DISABLE_ADD")]
        [Description("DISABLE_ADD")]
        public Nullable<bool> DISABLE_ADD { get; set; }

        [Column("KEY")]
        [StringLength(1000)]
        [Description("KEY")]
        public string KEY { get; set; }

        [Column("DUOCDUYET_TONGSO")]
        [Description("Tổng dự toán được duyệt - Tổng số")]
        public Nullable<decimal> DUOCDUYET_TONGSO { get; set; }

        [Column("DUOCDUYET_NGUONDONGGOP")]
        [Description("Tổng dự toán được duyệt - Nguồn đóng góp")]
        public Nullable<decimal> DUOCDUYET_NGUONDONGGOP { get; set; }

        [Column("GIATRI_THUCHIEN")]
        [Description("Giá trị thực hiện cả năm")]
        public Nullable<decimal> GIATRI_THUCHIEN { get; set; }

        [Column("THANHTOAN_TONGSO")]
        [Description("Giá trị thanh toán - Tổng số")]
        public Nullable<decimal> THANHTOAN_TONGSO { get; set; }

        [Column("THANHTOAN_KHOILUONG")]
        [Description("Giá trị thanh toán - Khối lương năm trước")]
        public Nullable<decimal> THANHTOAN_KHOILUONG { get; set; }

        [Column("THANHTOAN_NGUONCANDOI")]
        [Description("Giá trị thanh toán - Nguồn cân đối ngân sách")]
        public Nullable<decimal> THANHTOAN_NGUONCANDOI { get; set; }

        [Column("THANHTOAN_NGUONDONGGOP")]
        [Description("Giá trị thanh toán - Nguồn đóng góp")]
        public Nullable<decimal> THANHTOAN_NGUONDONGGOP { get; set; }
    }
}
