using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_CHUNGTUHEADER")]
    public class PHC_CHUNGTUHEADER : DataInfoEntityPHC
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
        
        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("MA_DTTHANHTOAN")]
        [StringLength(50)]
        [Description("Mã đối tượng thanh toán")]
        public string MA_DTTHANHTOAN { get; set; }

        [Column("ONGBA")]
        [StringLength(500)]
        [Description("Ông bà")]
        public string ONGBA { get; set; }

        [Column("DIA_CHI")]
        [StringLength(250)]
        [Description("Địa chỉ")]
        public string DIA_CHI { get; set; }

        [Column("DIENGIAI")]
        [StringLength(500)]
        [Description("Diễn giải")]
        public string DIENGIAI { get; set; }

        [Column("SOLENHCHI")]
        [StringLength(50)]
        [Description("Số lệnh chi")]
        public string SOLENHCHI { get; set; }

        [Column("MA_DIABAN")]
        [StringLength(50)]
        [Description("Mã địa bàn")]
        public string MA_DIABAN { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("SOCHUNGTUGOC")]
        [StringLength(50)]
        [Description("Số chứng từ gốc")]
        public string SOCHUNGTUGOC { get; set; }

        [Column("MA_KHO")]
        [StringLength(20)]
        [Description("Mã kho")]
        public string MA_KHO { get; set; }

        [Column("ISDIEUCHINH")]
        [Description("Trạng thái điều chỉnh")]
        public Nullable<bool> ISDIEUCHINH { get; set; }

        [Column("IDORIGINAL")]
        [Description("ID phiếu gốc")]
        public Nullable<int> IDORIGINAL { get; set; }

        [Column("FILE_NAME")]
        [StringLength(300)]
        [Description("File đính kèm")]
        public string FILE_NAME { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái duyệt phiếu 10: Duyệt ; 0 Chưa duyệt ; 20: Bỏ duyệt")]
        public Nullable<int> TRANGTHAI { get; set; }
    }
}
