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

    [Table("PHF_BM_08TT_CQHC")]
    public class PHF_BM_08TT_CQHC : BaseEntity
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

        [Column("HO_VATEN")]
        [StringLength(1000)]
        [Description("Họ và tên")]
        public string HO_VATEN { get; set; }

        [Column("SLCDV_THUNHAP_CHIUTHUE")]
        [StringLength(1000)]
        [Description("Thu nhập chịu thuế (Số liệu của đơn vị)")]
        public string SLCDV_THUNHAP_CHIUTHUE { get; set; }

        [Column("TTXD_THUNHAP_CHIUTHUE")]
        [StringLength(1000)]
        [Description("Thu nhập chịu thuế (Thanh tra xác định)")]
        public string TTXD_THUNHAP_CHIUTHUE { get; set; }

        [Column("SLCDV_SOTHUE_PHAINOP")]
        [StringLength(1000)]
        [Description("Số thuế phải nộp (Số liệu của đơn vị)")]
        public string SLCDV_SOTHUE_PHAINOP { get; set; }

        [Column("TTXD_SOTHUE_PHAINOP")]
        [StringLength(1000)]
        [Description("Số thuế phải nộp (Thanh tra xác định)")]
        public string TTXD_SOTHUE_PHAINOP { get; set; }

        [Column("CL_THUNHAP_CHIUTHUE")]
        [StringLength(1000)]
        [Description("Thu nhập chịu thuế (Chênh lệch)")]
        public string CL_THUNHAP_CHIUTHUE { get; set; }

        [Column("CL_SOTHUE_PHAINOP")]
        [StringLength(1000)]
        [Description("Số thuế phải nộp (Chênh lệch)")]
        public string CL_SOTHUE_PHAINOP { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
