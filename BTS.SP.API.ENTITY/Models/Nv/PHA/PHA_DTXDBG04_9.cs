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
    [Table("PHA_DTXDBG04_9")]
    public class PHA_DTXDBG04_9 : DataInfoEntity
    {
        [Column("MA_CHUONG")]
        [StringLength(50)]
        [Description("MA_CHUONG")]
        public string MA_CHUONG { get; set; }

        [Column("MA_CAP")]
        [StringLength(50)]
        [Description("MA_CAP")]
        public string MA_CAP { get; set; }

        [Column("TEN_CAP")]
        [StringLength(2000)]
        [Description("TEN_CAP")]
        public string TEN_CAP { get; set; }

        [Column("MA_CTMTQG")]
        [StringLength(50)]
        [Description("MA_CTMTQG")]
        public string MA_CTMTQG { get; set; }

        [Column("TEN_CTMTQG")]
        [StringLength(2000)]
        [Description("TEN_CTMTQG")]
        public string TEN_CTMTQG { get; set; }

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

        [Column("KHVKD")]
        [Description("KHVKD")]
        public Nullable<Decimal> KHVKD { get; set; }

        [Column("KLHT")]
        [Description("KLHT")]
        public Nullable<Decimal> KLHT { get; set; }

        [Column("KHVNS")]
        [Description("KHVNS")]
        public Nullable<Decimal> KHVNS { get; set; }

        [Column("KHDTN")]
        [Description("KHDTN")]
        public Nullable<Decimal> KHDTN { get; set; }

        [Column("KLHTN")]
        [Description("KLHTN")]
        public Nullable<Decimal> KLHTN { get; set; }

        [Column("VTUCTH")]
        [Description("VTUCTH")]
        public Nullable<Decimal> VTUCTH { get; set; }

        [Column("KHVKD_NAM")]
        [Description("KHVKD_NAM")]
        public Nullable<Decimal> KHVKD_NAM { get; set; }

        [Column("VTUCTH_NAM")]
        [Description("VTUCTH_NAM")]
        public Nullable<Decimal> VTUCTH_NAM { get; set; }

    }
}
