using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU12TT344
{
    [Table("PHB_BIEU12TT344_DETAIL")]
    public class PHB_BIEU12TT344_DETAIL: DataInfoEntity
    {
        [Column("PHB_BIEU12TT344_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU12TT344")]
        [StringLength(50)]
        public string PHB_BIEU12TT344_REFID { get; set; }

        [Description("Tên công trình")]
        [StringLength(255)]
        public string TEN_CONG_TRINH { get; set; }

        [Description("Thời gian")]
        public DateTime THOI_GIAN { get; set; }

        [Description("Tổng số dự toán")]
        public double TONG_SO_DU_TOAN { get; set; }

        [Description("Trong đó nguồn đóng góp")]
        public double TD_NDG { get; set; }

        [Description("Giá trị thực hiện")]
        public double GIA_TRI { get; set; }

        [Description("Tổng số thnah toán")]
        public double TONG_SO_THANH_TOAN { get; set; }

        [Description("Thanh toán khối lượng năm trước")]
        public double KHOI_LUONG_NAM_TRUOC { get; set; }

        [Description("Nguồn cân đối ngân sách")]
        public double NGUON_CAN_DOI { get; set; }

        [Description("Nguồn đóng góp")]
        public double NDG { get; set; }

        [Description("Loại")]
        public int LOAI { get; set; }

        [Description("Phần")]
        [StringLength(255)]
        public string PHAN { get; set; }
    }
}
