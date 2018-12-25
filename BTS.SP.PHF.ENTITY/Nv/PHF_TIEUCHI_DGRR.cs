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
    public enum LOAINHAP_TIEUCHI_DGRR
    {
        CHAMNOPBAOCAOQUYETTOAN = 1,
        KEHOACHKIEMTOANNHANUOC = 2,
        DENGHICUACUCTAICHINH = 3
    }
    public enum LOAIMANHAP
    {
        THEODVQHNS = 1,
        THEODIABAN = 2
    }
    [Table("PHF_TIEUCHI_DGRR")]
    public class PHF_TIEUCHI_DGRR : BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Description("ID tham chiếu bảng chi tiết")]
        public string REF_ID { get; set; }

        [Required]
        [Column("LOAINHAP_TIEUCHI_DGRR")]
        public LOAINHAP_TIEUCHI_DGRR LOAINHAP_TIEUCHI_DGRR {get;set;}

        [Required]
        [Description("Chọn nhập theo DVQHNS hoặc địa bàn")]
        public LOAIMANHAP LOAIMANHAP { get; set; }

        [Required]
        [Column("MA_LOAITHANHTRA")]
        [Description("Mã loại thanh tra")]
        [StringLength(50)]
        public string MA_LOAITHANHTRA { get; set; }

        [Required]
        [Column("MA_DOTTHANHTRA")]
        [StringLength(50)]
        [Description("Mã đợt thanh tra")]
        public string MA_DOTTHANHTRA { get; set; }

        public DateTime TUNGAY { get; set; }
        public DateTime DENNGAY { get; set; }
    }
}
