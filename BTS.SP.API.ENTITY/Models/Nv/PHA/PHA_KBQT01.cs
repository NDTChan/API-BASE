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
    [Table("PHA_KBQT01")]
    public class PHA_KBQT01 : DataInfoEntity
    {
        [Column("MA_BAOCAO")]
        [StringLength(50)]
        [Description("MA_BAOCAO")]
        public string MA_BAOCAO { get; set; }

        [Column("MA_CAP")]
        [StringLength(50)]
        [Description("MA_CAP")]
        public string MA_CAP { get; set; }
        [Column("NAM")]
        [Description("NAM")]
        public Nullable<int> NAM { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(50)]
        [Description("MA_CHUONG")]
        public string MA_CHUONG { get; set; }
        
        [Column("MA_NGUON_NSNN")]
        [StringLength(2000)]
        [Description("MA_NGUON_NSNN")]
        public string MA_NGUON_NSNN { get; set; }

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

        [Column("COT1_01")]
        [Description("COT1_01")]
        [StringLength(50)]
        public string COT1_01 { get; set; }

        [Column("COT2_01")]
        [Description("COT2_01")]
        [StringLength(2000)]
        public string COT2_01 { get; set; }

        [Column("COT3_01")]
        [Description("COT3_01")]
        [StringLength(50)]
        public string COT3_01 { get; set; }

        [Column("COT4_01")]
        [Description("COT4_01")]
        public Nullable<Decimal> COT4_01 { get; set; }

        [Column("COT5_01")]
        [Description("COT5_01")]
        public Nullable<Decimal> COT5_01 { get; set; }


        [Column("COT6_01")]
        [Description("COT6_01")]
        public Nullable<Decimal> COT6_01 { get; set; }

        [Column("COT7_01")]
        [Description("COT7_01")]
        public Nullable<Decimal> COT7_01 { get; set; }

        [Column("COT8_01")]
        [Description("COT8_01")]
        public Nullable<Decimal> COT8_01 { get; set; }

        [Column("COT9_01")]
        [Description("COT9_01")]
        public Nullable<Decimal> COT9_01 { get; set; }

        [Column("COT10_01")]
        [Description("COT10_01")]
        public Nullable<Decimal> COT10_01 { get; set; }

        [Column("COT11_01")]
        [Description("COT11_01")]
        public Nullable<Decimal> COT11_01 { get; set; }

        [Column("COT12_01")]
        [Description("COT12_01")]
        public Nullable<Decimal> COT12_01 { get; set; }

        [Column("COT13_01")]
        [Description("COT13_01")]
        public Nullable<Decimal> COT13_01 { get; set; }

        [Column("COT14_01")]
        [Description("COT14_01")]
        public Nullable<Decimal> COT14_01 { get; set; }

        [Column("COT15_01")]
        [Description("COT15_01")]
        public Nullable<Decimal> COT15_01 { get; set; }

        [Column("COT16_01")]
        [Description("COT16_01")]
        public Nullable<Decimal> COT16_01 { get; set; }

        [Column("COT17_01")]
        [Description("COT17_01")]
        public Nullable<Decimal> COT17_01 { get; set; }

        [Column("COT18_01")]
        [Description("COT18_01")]
        public Nullable<Decimal> COT18_01 { get; set; }

        [Column("COT19_01")]
        [Description("COT19_01")]
        public Nullable<Decimal> COT19_01 { get; set; }

        [Column("COT20_01")]
        [Description("COT20_01")]
        public Nullable<Decimal> COT20_01 { get; set; }

        [Column("COT21_01")]
        [Description("COT21_01")]
        public Nullable<Decimal> COT21_01 { get; set; }

        [Column("COT22_01")]
        [Description("COT22_01")]
        public Nullable<Decimal> COT22_01 { get; set; }
    }
}
