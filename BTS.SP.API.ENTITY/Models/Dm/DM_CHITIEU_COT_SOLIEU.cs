using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BTS.SP.API.ENTITY;
using System.ComponentModel;


namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_CHITIEU_COT_SOLIEU")]
    public class DM_CHITIEU_COT_SOLIEU : DataInfoEntity
    {
        [Column("MA_COT")]
        [StringLength(50)]
        public string MA_COT { get; set; }

        [Column("MA_CHITIEU")]
        [StringLength(50)]
        public string MA_CHITIEU { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(10)]
        public string TRANG_THAI { get; set; }

        [Column("LOAI_CHITIEU")]
        public Nullable<int> LOAI_CHITIEU{ get; set; }

        [Column("NAM")]
        public Nullable<int> NAM { get; set; }

        [Column("GIA_TRI")]
        public Nullable<decimal> GIA_TRI { get; set; }

        [Column("MA_DBHC")]
        [StringLength(20)]
        public string MA_DBHC { get; set; }

        [Column("MA_DBHC_XA")]
        [StringLength(20)]
        public string MA_DBHC_XA { get; set; }

        [Column("MA_DBHC_USER")]
        [StringLength(20)]
        public string MA_DBHC_USER { get; set; }

        [Column("CAP")]
        public Nullable<int> CAP { get; set; }
    }
}
