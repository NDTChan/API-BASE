using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHA
{
    [Table("DM_TINHCHAT_DONGTIEN")]
    public class DM_TINHCHAT_DONGTIEN: DataInfoEntity
    {
        [Column("MA_TCDT")]
        [StringLength(100)]
        public string MA_TCDT { get; set; }
        [Column("MA_CHA")]
        [StringLength(100)]
        public string MA_CHA { get; set; }
        [Column("TEN_TCDT")]
        [StringLength(250)]
        public string TEN_TCDT { get; set; }
        [Column("TINH_TRANG")]
        public int TINH_TRANG { get; set; }
        [Column("NGAY_TAO")]
        public DateTime? NGAY_TAO { get; set; }
        [Column("NGAY_SUA")]
        public DateTime? NGAY_SUA { get; set; }
        [Column("NGUOI_TAO")]
        [StringLength(100)]
        public string NGUOI_TAO { get; set; }
        [Column("NGUOI_SUA")]
        [StringLength(100)]
        public string NGUOI_SUA { get; set; }
    }
}
