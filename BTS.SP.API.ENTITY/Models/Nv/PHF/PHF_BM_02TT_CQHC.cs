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
    [Table("PHF_BM_02TT_CQHC")]
    public class PHF_BM_02TT_CQHC : DataInfoEntityPHF
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
        [Description("Nội dung chi")]
        public string NOIDUNG { get; set; }

        [Column("DUTOAN_DUOCGIAO_LK")]
        [StringLength(1000)]
        [Description("Dự toán được giao, năm trước liền kề")]
        public string DUTOAN_DUOCGIAO_LK { get; set; }

        [Column("QUYETTOANCHI_LK")]
        [StringLength(1000)]
        [Description("Quyết toán chi, năm trước liền kề")]
        public string QUYETTOANCHI_LK { get; set; }

        [Column("DUTOAN_DONVILAP_NAM")]
        [StringLength(1000)]
        [Description("Dự toán do đơn vị lập, năm...")]
        public string DUTOAN_DONVILAP_NAM { get; set; }

        [Column("DUTOAN_DUOCGIAO_NAM")]
        [StringLength(1000)]
        [Description("Dự toán được giao, năm...")]
        public string DUTOAN_DUOCGIAO_NAM { get; set; }

        [Column("QUYETTOANCHI_NAM")]
        [StringLength(1000)]
        [Description("Quyết toán chi, năm...")]
        public string QUYETTOANCHI_NAM { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
        [Description("Nguyên nhân tăng, giảm")]
        public string NGUYENNHAN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
