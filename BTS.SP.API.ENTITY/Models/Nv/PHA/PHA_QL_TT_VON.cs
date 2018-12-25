using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_QL_TT_VON")]

    public class PHA_QL_TT_VON : DataInfoEntity
    {
        [Column("REFID")]
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [Column("MA_PHIEU")]
        [Required]
        [Description("Mã phiếu")]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Column("SO_QD")]
        [StringLength(100)]
        [Description("Số quyết định")]
        public string SO_QD { get; set; }

        [Column("LOAI_KEHOACH_VON")]
        [Description("Loại kế hoạch vốn")]
        public int? LOAI_KEHOACH_VON { get; set; }

        [Column("NGAY_QUYETDINH")]
        [Description("Ngày quyết định")]
        public DateTime? NGAY_QUYETDINH { get; set; }

        [Column("NGAY_HACHTOAN")]
        [Description("Ngày hạch toán")]
        public DateTime? NGAY_HACHTOAN { get; set; }

        [Column("NAM_KEHOACH_VON")]
        [Description("Năm kế hoạch vốn")]
        public int? NAM_KEHOACH_VON { get; set; }

        [Column("DIEN_GIAI")]
        [Description("Diễn giải")]
        [StringLength(50)]
        public string DIEN_GIAI { get; set; }

        [Column("LOAI_QLTT_VON")]
        [Description("1: ql vốn;2: ql vốn: tạm ứng")]
        public int? LOAI_QLTT_VON { get; set; }

    }
}
