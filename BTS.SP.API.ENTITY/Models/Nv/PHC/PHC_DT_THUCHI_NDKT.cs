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
    [Table("PHC_DT_THUCHI_NDKT")]
    public class PHC_DT_THUCHI_NDKT : DataInfoEntityPHC
    {
        [Column("MADUTOAN")]
        [StringLength(20)]
        [Description("Mã dự toán")]
        public string MADUTOAN { get; set; }

        [Column("TENDUTOAN")]
        [StringLength(500)]
        [Description("Tên dự toán")]
        public string TENDUTOAN { get; set; }

        [Column("NAM")]
        [Description("nam du toan")]
        public Nullable<int> NAM { get; set; }

        [Column("LOAICHITIEU")]
        [Description("Loại chỉ tiêu")]
        public Nullable<int> LOAICHITIEU { get; set; }

        [Column("NGAY_QD")]
        [Description("Ngày quyết định")]
        public Nullable<DateTime> NGAY_QD { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT{ get; set; }

        [Column("SO_QD")]
        [Description("Số quyết định")]
        public Nullable<int> SO_QD { get; set; }

        [Column("SO_CTGS")]
        [Description("Số CTGS")]
        public Nullable<int> SO_CTGS { get; set; }

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        [Column("FILE_NAME")]
        [StringLength(300)]
        [Description("File đính kèm")]
        public string FILE_NAME { get; set; }

    }
}
