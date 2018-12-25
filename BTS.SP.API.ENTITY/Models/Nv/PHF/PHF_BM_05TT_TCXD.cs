using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_05TT_TCXD")]
    public class PHF_BM_05TT_TCXD  : DataInfoEntityPHF
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

        [Column("TEN_DUTOAN")]
        [StringLength(1000)]
        [Description("Tên dự toán")]
        public string TEN_DUTOAN { get; set; }

        [Column("GIATRI")]
        [StringLength(1000)]
        [Description("Giá trị")]
        public string GIATRI { get; set; }

        [Column("SO")]
        [StringLength(1000)]
        [Description("Quyết định phê duyệt - Số")]
        public string SO { get; set; }

        [Column("NGAY")]
        [StringLength(1000)]
        [Description("Quyết định phê duyệt - Ngày")]
        public string NGAY { get; set; }

        [Column("THAMQUYEN_DUYET")]
        [StringLength(1000)]
        [Description("Quyết định phê duyệt - Thẩm quyền duyệt")]
        public string THAMQUYEN_DUYET { get; set; }

        [Column("THUTUC_DACO")]
        [StringLength(1000)]
        [Description("Thủ tục đã có/ Đánh dấu x")]
        public string THUTUC_DACO { get; set; }

        [Column("NGUYENNHAN_THIEU")]
        [StringLength(1000)]
        [Description("Nguyên nhân thiếu")]
        public string NGUYENNHAN_THIEU { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
