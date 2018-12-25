using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BTS.SP.API.ENTITY;
using Oracle.ManagedDataAccess.Types;

namespace BTS.SP.API.ENTITY.Models.Dm.PHA
{
    [Table("DM_CHITIEU_BAOCAO_COL")]
    public class DM_CHITIEU_BAOCAO_COL : DataInfoEntity
    {

        [Column("STT")]
        [StringLength(100)]
        public string STT { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("MA_BAOCAO")]
        [StringLength(50)]
        public string MA_BAOCAO { get; set; }

        [Column("MA_COT")]
        [StringLength(100)]
        public string MA_COT { get; set; }

        [Column("MA_DBHC")]
        [StringLength(10)]
        public string MA_DBHC { get; set; }

        [Column("TEN_COT")]
        [StringLength(2000)]
        public string TEN_COLUMN { get; set; }

        [Column("CONGTHUC")]
        public string CONGTHUC { get; set; }

        [Column("CONGTHUC_WHERE")]
        public string CONGTHUC_WHERE { get; set; }

        [Column("CONGTHUC_DH")]
        public string CONGTHUC_DH { get; set; }

        [Column("CONGTHUC_DH_WHERE")]
        public string CONGTHUC_DH_WHERE { get; set; }

        [Column("GIA_TRI")]       
        public Nullable<decimal> GIA_TRI { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }
    }
}