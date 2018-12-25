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
    [Table("PHF_BM_07TT_TCXD")]
    public class PHF_BM_07TT_TCXD  : DataInfoEntityPHF
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

        [Column("TEN_GOITHAU")]
        [StringLength(1000)]
        [Description("Tên gói thầu, hạng mục công việc")]
        public string TEN_GOITHAU { get; set; }

        [Column("DT_DUYET")]
        [StringLength(1000)]
        [Description("Dự toán duyệt")]
        public string DT_DUYET { get; set; }

        [Column("DT_TINHLAI")]
        [StringLength(1000)]
        [Description("Dự toán tính lại")]
        public string DT_TINHLAI { get; set; }

        [Column("GGT_DUYET")]
        [StringLength(1000)]
        [Description("Giá gói thầu được duyệt")]
        public string GGT_DUYET { get; set; }

        [Column("GGT_TINHLAI")]
        [StringLength(1000)]
        [Description("Giá gói thầu tính lại")]
        public string GGT_TINHLAI { get; set; }

        [Column("GIATRI_HOPDONG")]
        [StringLength(1000)]
        [Description("Giá trị hợp đồng")]
        public string GIATRI_HOPDONG { get; set; }

        [Column("HINHTHUC_HOPDONG")]
        [StringLength(1000)]
        [Description("Hình thức hợp đồng")]
        public string HINHTHUC_HOPDONG { get; set; }

        [Column("GIATRI_HOPDONG_VUOTGIA")]
        [StringLength(1000)]
        [Description("Giá trị hợp đồng vượt giá gói thầu")]
        public string GIATRI_HOPDONG_VUOTGIA { get; set; }

        [Column("GIATRI_KHOILUONG")]
        [StringLength(1000)]
        [Description("Giá trị khối lượng")]
        public string GIATRI_KHOILUONG { get; set; }

        [Column("GIATRI_GIAINGAN")]
        [StringLength(1000)]
        [Description("Giá trị giải ngân")]
        public string GIATRI_GIAINGAN { get; set; }

        [Column("GHICHU")]
        [StringLength(1000)]
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
