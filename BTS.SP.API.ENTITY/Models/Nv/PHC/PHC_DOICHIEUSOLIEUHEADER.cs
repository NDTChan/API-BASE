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
    [Table("PHC_DOICHIEUSOLIEUHEADER")]
    public class PHC_DOICHIEUSOLIEUHEADER : DataInfoEntityPHC
    {
        [Required]
        [Column("DVQHNS")]
        [StringLength(25)]
        [Description("Đơn vị quan hệ ngân sách")]
        public string DVQHNS { get; set; }

        [Column("LOAIDULIEU")]
        [StringLength(10)]
        [Description("Loại dữ liệu")]
        public string LOAIDULIEU { get; set; }

        [Column("SOTIEN")]
        [Description("Số tiền")]
        public decimal SOTIEN { get; set; }

        [Column("NGAYPHATSINH")]
        [Description("Ngày phát sinh")]
        public Nullable<DateTime> NGAYPHATSINH { get; set; }

        [Column("TUNGAY_HIEULUC")]
        [Description("Từ ngày hiệu lực")]
        public Nullable<DateTime> TUNGAY_HIEULUC { get; set; }

        [Column("DENNGAY_HIEULUC")]
        [Description("Đến ngày hiệu lực")]
        public Nullable<DateTime> DENNGAY_HIEULUC { get; set; }

        [Column("KY")]
        [Description("Kỳ hạch toán")]
        public int KY { get; set; }

        [Column("NAM")]
        [Description("Năm")]
        public int NAM { get; set; }

        [Column("TENFILE")]
        [StringLength(500)]
        [Description("Tên file")]
        public string TENFILE { get; set; }

        [Column("DUONGDAN")]
        [StringLength(1000)]
        [Description("Đường dẫn")]
        public string DUONGDAN { get; set; }

    }
}
