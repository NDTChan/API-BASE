using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_THANHTOAN_LUONG_DETAIL")]
    public class PHA_THANHTOAN_LUONG_DETAIL : DataInfoEntity
    {
        [Column("PHA_THANHTOAN_LUONG_REFID")]
        [Required]
        [StringLength(50)]
        public string PHA_THANHTOAN_LUONG_REFID { get; set; }

        [Column("STT")]
        [StringLength(5)]
        public string STT { get; set; }

        [Column("HO_TEN")]
        [StringLength(100)]
        public string HO_TEN { get; set; }

        [Column("CHUC_DANH")]
        [StringLength(200)]
        public string CHUC_DANH { get; set; }

        public Nullable<Decimal> HO_SO_LUONG { get; set; }
        public Nullable<Decimal> PC_KV { get; set; }
        public Nullable<Decimal> PC_CHUC_VU { get; set; }
        public Nullable<Decimal> PC_THAM_NIEN { get; set; }
        public Nullable<Decimal> PC_TRACH_NHIEM { get; set; }
        public Nullable<Decimal> PC_CONG_VU { get; set; }
        public Nullable<Decimal> PC_LOAI_XA { get; set; }
        public Nullable<Decimal> PC_LAU_NAM { get; set; }
        public Nullable<Decimal> PC_THU_HUT { get; set; }
        public Nullable<Decimal> TONG_HS { get; set; }
        public Nullable<Decimal> THANH_TIEN { get; set; }
        public Nullable<Decimal> BHXH { get; set; }
        public Nullable<Decimal> BHYT { get; set; }
        public Nullable<Decimal> CONG_CKPT { get; set; }
        public Nullable<Decimal> THUC_LINH { get; set; }

        [Column("KY_NHAN")]
        [StringLength(200)]
        public string KY_NHAN { get; set; }

        [Column("GHI_CHU")]
        [StringLength(1000)]
        public string GHI_CHU { get; set; }
    }
}
