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
    [Table("DM_CHITIEU_COT")]
    public class DM_CHITIEU_COT : DataInfoEntity
    {
        [Column("MA_COT")]
        [StringLength(50)]
        public string MA_COT { get; set; }

        [Column("TEN_COT")]
        [StringLength(500)]
        public string TEN_COT { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(10)]
        public string TRANG_THAI { get; set; }

        [Column("CONGTHUC")]
        [StringLength(2000)]
        public string CONGTHUC { get; set; }

        [Column("CONGTHUC_WHERE")]
        public string CONGTHUC_WHERE { get; set; }

        [Column("SAPXEP")]
        public Nullable<int> SAPXEP { get; set; }

    }
}
