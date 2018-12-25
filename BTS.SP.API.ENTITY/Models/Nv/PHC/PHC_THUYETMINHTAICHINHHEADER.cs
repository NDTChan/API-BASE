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
    [Table("PHC_THUYETMINHTAICHINHHEADER")]
    public class PHC_THUYETMINHTAICHINHHEADER : DataInfoEntityPHC
    {
        [Required]
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Column("NAM")]
        [Description("NAM")]
        public Nullable<int> NAM { get; set; }

        [Column("DIENTICH")]
        [Description("DIENTICH")]
        public Nullable<decimal> DIENTICH { get; set; }

        [Column("DIENTICHDAT")]
        [Description("DIENTICHDAT")]
        public Nullable<decimal> DIENTICHDAT { get; set; }

        [Column("DANSODEN")]
        [Description("DANSODEN")]
        public Nullable<decimal> DANSODEN { get; set; }

        [Column("NGANHNGHE")]
        [Description("Ngành nghề")]
        public string NGANHNGHE { get; set; }

        [Column("MUCTIEUNHIEMVU")]
        [Description("Mục tiêu nhiệm vụ")]
        public string MUCTIEUNHIEMVU { get; set; }

        [Column("DANHGIA")]
        [Description("Đánh giá")]
        public string DANHGIA { get; set; }

        [Column("NGUYENNHAN")]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("KHACHQUAN")]
        [Description("Khách quan")]
        public string KHACHQUAN { get; set; }

        [Column("CHUQUAN")]
        [Description("Chủ quan")]
        public string CHUQUAN { get; set; }

        [Column("DENGHIKIENXUAT")]
        [Description("Đề nghị kiến xuất")]
        public string DENGHIKIENXUAT { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
