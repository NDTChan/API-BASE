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
    [Table("PHF_BM_10TT_TCXD")]
    public class PHF_BM_10TT_TCXD  : DataInfoEntityPHF
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

        [Column("TEN_HANGMUC")]
        [StringLength(1000)]
        [Description("Tên hạng mục công trình")]
        public string TEN_HANGMUC { get; set; }

        [Column("THOIGIAN_QUYETTOAN")]
        [StringLength(1000)]
        [Description("Thời gian quyết toán")]
        public string THOIGIAN_QUYETTOAN { get; set; }

        [Column("GIATRI_DENGHI")]
        [StringLength(1000)]
        [Description("Giá trị đề nghị")]
        public string GIATRI_DENGHI { get; set; }

        [Column("GIATRI_XACDINH")]
        [StringLength(1000)]
        [Description("Giá trị xác định")]
        public string GIATRI_XACDINH { get; set; }

        [Column("CHENHLECH")]
        [StringLength(1000)]
        [Description("Chênh lệch")]
        public string CHENHLECH { get; set; }

        [Column("THOIGIAN_QUYETTOAN_CHAM")]
        [StringLength(1000)]
        [Description("Thời gian quyết toán chậm")]
        public string THOIGIAN_QUYETTOAN_CHAM { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("GHICHU")]
        [StringLength(1000)]
        [Description("GHICHU")]
        public string GHICHU { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
