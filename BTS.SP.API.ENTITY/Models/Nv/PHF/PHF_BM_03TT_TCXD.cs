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
    [Table("PHF_BM_03TT_TCXD")]
    public class PHF_BM_03TT_TCXD : DataInfoEntityPHF
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

        [Column("TEN_CHIPHI_DAUTU")]
        [StringLength(1000)]
        [Description("Tên chi phí đầu tư")]
        public string TEN_CHIPHI_DAUTU { get; set; }

        [Column("VON_NSNN_KHV")]
        [StringLength(1000)]
        [Description("Kế hoạch vốn/ Vốn NSNN")]
        public string VON_NSNN_KHV { get; set; }

        [Column("VONVAY_KHV")]
        [StringLength(1000)]
        [Description("Kế hoạch vốn/ Vốn vay")]
        public string VONVAY_KHV { get; set; }

        [Column("VONKHAC_KHV")]
        [StringLength(1000)]
        [Description("Kế hoạch vốn/ Vốn khác")]
        public string VONKHAC_KHV { get; set; }

        [Column("TONGCONG_KHV")]
        [StringLength(1000)]
        [Description("Kế hoạch vốn/ Tổng cộng")]
        public string TONGCONG_KHV { get; set; }

        [Column("VON_NSNN_GNV")]
        [StringLength(1000)]
        [Description("Giải ngân vốn/ Vốn NSNN")]
        public string VON_NSNN_GNV { get; set; }

        [Column("VONVAY_GNV")]
        [StringLength(1000)]
        [Description("Giải ngân vốn/ Vốn vay")]
        public string VONVAY_GNV { get; set; }

        [Column("VONKHAC_GNV")]
        [StringLength(1000)]
        [Description("Giải ngân vốn/ Vốn khác")]
        public string VONKHAC_GNV { get; set; }

        [Column("TONGCONG_GNV")]
        [StringLength(1000)]
        [Description("Giải ngân vốn/ Tổng cộng")]
        public string TONGCONG_GNV { get; set; }

        [Column("VON_NSNN_TLGN")]
        [StringLength(1000)]
        [Description("Tỉ lệ giải ngân/ Vốn NSNN")]
        public string VON_NSNN_TLGN { get; set; }

        [Column("VONVAY_TLGN")]
        [StringLength(1000)]
        [Description("Tỉ lệ giải ngân/ Vốn vay")]
        public string VONVAY_TLGN { get; set; }

        [Column("VONKHAC_TLGN")]
        [StringLength(1000)]
        [Description("Tỉ lệ giải ngân/ Vốn khác")]
        public string VONKHAC_TLGN { get; set; }

        [Column("TONGCONG_TLGN")]
        [StringLength(1000)]
        [Description("Tỉ lệ giải ngân/ Tổng cộng")]
        public string TONGCONG_TLGN { get; set; }

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
