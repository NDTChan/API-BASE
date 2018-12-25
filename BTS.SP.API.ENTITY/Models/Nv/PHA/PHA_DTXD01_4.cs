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
    [Table("PHA_DTXD01_4")]
    public class PHA_DTXD01_4 : DataInfoEntity
    {
        [Column("MA_CHUONG")]
        [StringLength(50)]
        [Description("MA_CHUONG")]
        public string MA_CHUONG { get; set; }

        [Column("MA_NGUON_NSNN")]
        [StringLength(50)]
        [Description("MA_NGUON_NSNN")]
        public string MA_NGUON_NSNN { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        [Description("MA_DVQHNS")]
        public string MA_DVQHNS { get; set; }


        [Column("TEN_DVQHNS")]
        [StringLength(2000)]
        [Description("TEN_DVQHNS")]
        public string TEN_DVQHNS { get; set; }

        [Column("DUTAMUNG_NT")]
        [Description("DUTAMUNG_NT")]
        public Nullable<Decimal> DUTAMUNG_NT { get; set; }


        [Column("HOANUNG")]
        [Description("HOANUNG")]
        public Nullable<Decimal> HOANUNG { get; set; }

        [Column("KHVDT")]
        [Description("KHVDT")]
        public Nullable<Decimal> KHVDT { get; set; }


        [Column("TTKL")]
        [Description("TTKL")]
        public Nullable<Decimal> TTKL { get; set; }

        [Column("VTUCTH")]
        [Description("VTUCTH")]
        public Nullable<Decimal> VTUCTH { get; set; }

        [Column("KHVCSNS")]
        [Description("KHVCSNS")]
        public Nullable<Decimal> KHVCSNS { get; set; }

        [Column("KHVHB")]
        [Description("KHVHB")]
        public Nullable<Decimal> KHVHB { get; set; }

    }
}
