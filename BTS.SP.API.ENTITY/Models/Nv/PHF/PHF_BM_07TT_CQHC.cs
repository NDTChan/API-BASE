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
    [Table("PHF_BM_07TT_CQHC")]
    public class PHF_BM_07TT_CQHC : DataInfoEntityPHF
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

        [Column("NOIDUNG_SAIPHAM")]
        [StringLength(1000)]
        [Description("Nội dung sai phạm")]
        public string NOIDUNG_SAIPHAM { get; set; }

        [Column("SOTIEN")]
        [StringLength(1000)]
        [Description("Số tiền")]
        public string SOTIEN { get; set; }

        [Column("TRICHSAI_TYLE")]
        [StringLength(1000)]
        [Description("Trích sai tỷ lệ")]
        public string TRICHSAI_TYLE { get; set; }

        [Column("TRICHKHONG_DUNGNGUON")]
        [StringLength(1000)]
        [Description("Trích không đúng nguồn")]
        public string TRICHKHONG_DUNGNGUON { get; set; }

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
