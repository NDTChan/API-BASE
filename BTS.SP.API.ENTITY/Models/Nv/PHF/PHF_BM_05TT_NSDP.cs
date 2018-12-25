using BTS.SP.API.ENTITY;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_05TT_NSDP")]
    public class PHF_BM_05TT_NSDP : DataInfoEntityPHF
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

        [Column("TEN_DUAN")]
        [StringLength(1000)]
        [Description("Tên dự án")]
        public string TEN_DUAN { get; set; }

        [Column("QUYETDINH_SO")]
        [StringLength(500)]
        [Description("Quyết định số")]
        public string QUYETDINH_SO { get; set; }

        [Column("QUYETDINH_NGAY")]
        [StringLength(300)]
        [Description("Quyết định ngày")]
        public string QUYETDINH_NGAY { get; set; }

        [Column("TONGMUC_DAUTU")]
        [StringLength(500)]
        [Description("Tổng mức đầu tư")]
        public string TONGMUC_DAUTU { get; set; }

        [Column("THOIGIAN_KC_HT")]
        [StringLength(500)]
        [Description("Thời gian kc ht")]
        public string THOIGIAN_KC_HT { get; set; }

        [Column("VON_DUOCGIAO")]
        [StringLength(500)]
        [Description("Vốn được giao")]
        public string VON_DUOCGIAO { get; set; }

        [Column("BOTRI_KEHOACH_VON")]
        [StringLength(500)]
        [Description("Bố trí kế hoạch vốn")]
        public string BOTRI_KEHOACH_VON { get; set; }

        [Column("THUTU_UUTIEN")]
        [StringLength(500)]
        [Description("Thứ tự ưu tiên")]
        public string THUTU_UUTIEN { get; set; }

        [Column("VON_KHONGHOPLY")]
        [StringLength(500)]
        [Description("Vốn không hợp lý")]
        public string VON_KHONGHOPLY { get; set; }

        [Column("SAIPHAM_KHAC")]
        [StringLength(500)]
        [Description("Sai phạm khác")]
        public string SAIPHAM_KHAC { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
