using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BTS.SP.PHF.ENTITY;

namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_04TT_TCXD")]
    public class PHF_BM_04TT_TCXD  : BaseEntity
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
        [Description("Tên sai phạm")]
        public string TEN_THUTUC { get; set; }

        [Column("GIATRI")]
        [StringLength(1000)]
        [Description("Giá trị")]
        public string GIATRI { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("KETQUA")]
        [StringLength(1000)]
        [Description("Kết quả")]
        public string KETQUA { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
