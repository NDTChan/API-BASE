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
    [Table("PHA_KBQT82")]
    public class PHA_KBQT82 : DataInfoEntity
    {
        [Column("MA_BAOCAO")]
        [StringLength(50)]
        [Description("MA_BAOCAO")]
        public string MA_BAOCAO { get; set; }

        [Column("MA_CAP")]
        [StringLength(50)]
        [Description("MA_CAP")]
        public string MA_CAP { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(50)]
        [Description("MA_CHUONG")]
        public string MA_CHUONG { get; set; }
        
        [Column("MA_NGUON_NSNN")]
        [StringLength(2000)]
        [Description("MA_NGUON_NSNN")]
        public string MA_NGUON_NSNN { get; set; }

        [Column("MA_CTMTQG")]
        [StringLength(2000)]
        [Description("MA_CTMTQG")]
        public string MA_CTMTQG { get; set; }

        [Column("NAM")]
        [Description("NAM")]
        public Nullable<int> NAM { get; set; }

        [Column("TONG_MUC_DTU")]
        [Description("TONG_MUC_DTU")]
        public Nullable<Decimal> TONG_MUC_DTU { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        [Description("MA_DUAN")]
        public string MA_DUAN { get; set; }

        [Column("TEN_DUAN")]
        [StringLength(2000)]
        [Description("TEN_DUAN")]
        public string TEN_DUAN { get; set; }

        [Column("SHKB")]
        [StringLength(50)]
        [Description("SHKB")]
        public string SHKB { get; set; }

        [Column("STT")]
        [Description("STT")]
        [StringLength(50)]
        public string STT { get; set; }

        [Column("C4")]
        [Description("C4")]
        [StringLength(50)]
        public string C4 { get; set; }

        [Column("C6")]
        [Description("C6")]
        [StringLength(50)]
        public string C6 { get; set; }

        [Column("C7")]
        [Description("C7")]
        [StringLength(50)]
        public string C7 { get; set; }

        [Column("C8")]
        [Description("C8")]
        public Nullable<Decimal> C8 { get; set; }

        [Column("C9")]
        [Description("C9")]
        public Nullable<Decimal> C9 { get; set; }


        [Column("C10")]
        [Description("C10")]
        public Nullable<Decimal> C10 { get; set; }

        [Column("C11")]
        [Description("C11")]
        public Nullable<Decimal> C11 { get; set; }

        [Column("C12")]
        [Description("C12")]
        public Nullable<Decimal> C12 { get; set; }

        [Column("C13")]
        [Description("C13")]
        public Nullable<Decimal> C13 { get; set; }

        [Column("C14")]
        [Description("C14")]
        public Nullable<Decimal> C14 { get; set; }

        [Column("C15")]
        [Description("C15")]
        public Nullable<Decimal> C15 { get; set; }

        [Column("C16")]
        [Description("C16")]
        public Nullable<Decimal> C16 { get; set; }

        [Column("C17")]
        [Description("C17")]
        public Nullable<Decimal> C17 { get; set; }
    }
}
