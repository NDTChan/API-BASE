using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("TABWH_JEL_FCT_V2")]
    public class TABWH_JEL_FCT_V2 : DataInfoEntity
    {
        [Column("MA_QUY")]
        [StringLength(200)]
        [Description("Mã quý")]
        public string MA_QUY { get; set; }

        [Column("MA_TKTN")]
        [StringLength(200)]
        [Description("Mã tktn")]
        public string MA_TKTN { get; set; }

        [Column("MA_TIEUMUC")]
        [StringLength(200)]
        [Description("Mã tiểu mục")]
        public string MA_TIEUMUC { get; set; }

        [Column("MA_CAP")]
        [StringLength(200)]
        [Description("Mã cấp")]
        public string MA_CAP { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(200)]
        [Description("Mã dvqhns")]
        public string MA_DVQHNS { get; set; }

        [Column("MA_DIABAN")]
        [StringLength(200)]
        [Description("Mã dịa bàn")]
        public string MA_DIABAN { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(200)]
        [Description("Mã chương")]
        public string MA_CHUONG { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(200)]
        [Description("Mã khoản")]
        public string MA_KHOAN { get; set; }

        [Column("MA_CTMTQG")]
        [StringLength(200)]
        [Description("Mã ct mtieu quốc gia")]
        public string MA_CTMTQG { get; set; }

        [Column("MA_KBNN")]
        [StringLength(200)]
        [Description("Mã kho bạc nn")]
        public string MA_KBNN { get; set; }

        [Column("MA_NGUONNS")]
        [StringLength(200)]
        [Description("Mã nguồn ns")]
        public string MA_NGUONNS { get; set; }

        [Column("NGAY_KET_SO")]
        [Description("Ngày Post sổ")]
        public Nullable<DateTime> NGAY_KET_SO { get; set; }

        [Column("NGAY_HIEU_LUC")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HIEU_LUC { get; set; }

        [Column("DP")]
        [StringLength(200)]
        [Description("DP")]
        public string DP { get; set; }

        [Column("DU_DAU")]
        [Description("dư đầu")]
        public Nullable<decimal> DU_DAU { get; set; }

        [Column("DU_CUOI")]
        [Description("dư cuối")]
        public Nullable<decimal> DU_CUOI { get; set; }

        [Column("PS_NO")]
        [Description("Tổng PS nợ")]
        public Nullable<decimal> PS_NO { get; set; }

        [Column("PS_CO")]
        [Description("Tổng PS có")]
        public Nullable<decimal> PS_CO { get; set; }

    }
}
