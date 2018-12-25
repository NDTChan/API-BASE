using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.PHF.ENTITY.Nv
{
    [Table("PHF_BM_02TT_NSDP")]
    public class PHF_BM_02TT_NSDP : BaseEntity
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

        [Column("CHITIEU")]
        [StringLength(1000)]
        [Description("Chỉ tiêu")]
        public string CHITIEU { get; set; }

        [Column("TW_GIAO")]
        [StringLength(500)]
        [Description("Trung ương giao")]
        public string TW_GIAO { get; set; }

        [Column("HDND_TINH_QD")]
        [StringLength(300)]
        [Description("Hội đồng nhân dân tỉnh quyết định")]
        public string HDND_TINH_QD { get; set; }

        [Column("UBND_TINH_GIAO")]
        [StringLength(500)]
        [Description("Ủy ban nhân dân tỉnh giao")]
        public string UBND_TINH_GIAO { get; set; }

        [Column("SS_HDNS_PHANTRAM")]
        [StringLength(500)]
        [Description("So sánh hội đồng nhân dân phần trăm")]
        public string SS_HDNS_PHANTRAM { get; set; }

        [Column("SS_HDNS_CHENHLECH")]
        [StringLength(500)]
        [Description("So sánh hội đồng nhân dân chênh lệch")]
        public string SS_HDNS_CHENHLECH { get; set; }

        [Column("SS_UBND_PHANTRAM")]
        [StringLength(500)]
        [Description("So sánh ủy ban nhân dân phần trăm")]
        public string SS_UBND_PHANTRAM { get; set; }

        [Column("SS_UBND_CHENHLECH")]
        [StringLength(500)]
        [Description("So sánh ủy ban nhân dân chênh lệch")]
        public string SS_UBND_CHENHLECH { get; set; }

        [Column("GHICHU")]
        [StringLength(1500)]
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
