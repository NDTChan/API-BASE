using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_01TT_TCXD")]
    public class PHF_BM_01TT_TCXD : BaseEntity
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

        [Column("TEN_THUTUC")]
        [StringLength(1000)]
        [Description("Tên thủ tục")]
        public string TEN_THUTUC { get; set; }

        [Column("COQUAN_DUYET")]
        [StringLength(1000)]
        [Description("Cơ quan duyệt")]
        public string COQUAN_DUYET { get; set; }

        [Column("GIATRI_KHOANMUC")]
        [StringLength(1000)]
        [Description("Giá trị khoản mục chi phí")]
        public string GIATRI_KHOANMUC { get; set; }

        [Column("TRANGTHAI_THUTUC")]
        [StringLength(1000)]
        [Description("Trạng thái thủ tục/ Đánh dấu x")]
        public string TRANGTHAI_THUTUC { get; set; }

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
