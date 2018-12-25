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
    [Table("PHF_BM_04TT_CQHC")]
    public class PHF_BM_04TT_CQHC : DataInfoEntityPHF
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

        [Column("NOIDUNG")]
        [StringLength(1000)]
        [Description("Nội dung thu")]
        public string NOIDUNG { get; set; }

        [Column("SOTIEN")]
        [StringLength(1000)]
        [Description("Số tiền")]
        public string SOTIEN { get; set; }

        [Column("THUKHONG_QDNC_NN")]
        [StringLength(1000)]
        [Description("Thu không có trong quy định Nhà nước")]
        public string THUKHONG_QDNC_NN { get; set; }

        [Column("THUCAOTHAP_QDNC_NN")]
        [StringLength(1000)]
        [Description("Thu cao (+), thấp (-) hơn quy định")]
        public string THUCAOTHAP_QDNC_NN { get; set; }

        [Column("THUKHONG_SSQT_NN")]
        [StringLength(1000)]
        [Description("Thu không phản ánh vào sổ sách, Quyết toán")]
        public string THUKHONG_SSQT_NN { get; set; }

        [Column("CHUAGHI_THUCHI_NN")]
        [StringLength(1000)]
        [Description("Số thu chưa thực hiện ghi thu - ghi chi")]
        public string CHUAGHI_THUCHI_NN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
