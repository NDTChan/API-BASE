using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_TIEUCHI_DGRR_DETAIL")]
    public class PHF_TIEUCHI_DGRR_DETAIL : DataInfoEntityPHF
    {
        [Required]
        [StringLength(50)]
        [Description("ID tham chiếu bảng cha")]
        public string REF_ID { get; set; }

        [Column("MA")]
        [Required]
        [StringLength(255)]
        [Description("Mã đơn vị/ mã địa bàn")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(255)]
        [Required]
        [Description("Tên đơn vị/ Tên địa bàn")]
        public string TEN { get; set; }

        [Column("THOIGIANNOP")]
        [Description("Thời gian nộp báo cáo quyết toán")]
        public Nullable<DateTime> THOIGIANNOP { get; set; }

        [Column("SONGAYNOPCHAM")]
        [Description("Số ngày nộp chậm báo cáo quyết toán")]
        public Nullable<int> SONGAYNOPCHAM { get; set; }
    }
}
