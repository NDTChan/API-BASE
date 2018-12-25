using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Mobile
{
    public class MBL_PHA_CQ_THU : DataInfoEntity
    {
        [Column("TW_THUE")]
        public Int64? TW_THUE { get; set; }
        [Column("TINH_THUE")]
        public Int64? TINH_THUE { get; set; }
        [Column("HUYEN_THUE")]
        public Int64? HUYEN_THUE { get; set; }

        [Column("XA_THUE")]
        public Int64? XA_THUE { get; set; }

        [Column("TW_HQ")]
        public Int64? TW_HQ { get; set; }
        [Column("TINH_HQ")]
        public Int64? TINH_HQ { get; set; }
        [Column("HUYEN_HQ")]
        public Int64? HUYEN_HQ { get; set; }

        [Column("XA_HQ")]
        public Int64? XA_HQ { get; set; }
        [Column("TW_KHAC")]
        public Int64? TW_KHAC { get; set; }
        [Column("TINH_KHAC")]
        public Int64? TINH_KHAC { get; set; }
        [Column("HUYEN_KHAC")]
        public Int64? HUYEN_KHAC { get; set; }

        [Column("XA_KHAC")]
        public Int64? XA_KHAC { get; set; }

        [Column("SHKB")]
        [StringLength(4)]
        public string SHKB { get; set; }

        [Column("NAM")]
        public int? NAM { get; set; }

        [Column("THANG")]
        public int? THANG { get; set; }

    }
}
