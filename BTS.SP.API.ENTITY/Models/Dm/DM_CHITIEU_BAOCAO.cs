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
    [Table("DM_CHITIEU_BAOCAO")]
    public class DM_CHITIEU_BAOCAO:DataInfoEntity
    {
        [Column("MA_BAOCAO")]
        [StringLength(50)]
        public string MA_BAOCAO { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("MA_CHITIEU")]
        [StringLength(50)]
        public string MA_CHITIEU { get; set; }

        [Column("MA_CONGTRINH")]
        [StringLength(50)]
        public string MA_CONGTRINH { get; set; }


        [Column("MA_DONG")]
        [StringLength(200)]
        public string MA_DONG { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(10)]
        public string TRANG_THAI { get; set; }

        [Column("SAPXEP")]
        [StringLength(100)]
        public string SAPXEP { get; set; }
        
        [Column("TEN_CHITIEU")]
        [StringLength(500)]
        public string TEN_CHITIEU { get; set; }
        
        [Column("STT")]
        [StringLength(100)]
        public string STT { get; set; }
        
        [Column("CONGTHUC")]
        public string CONGTHUC { get; set; }


        [Column("CONGTHUC_WHERE")]
        public string CONGTHUC_WHERE { get; set; }
        [Column("CONGTHUC_DH_WHERE")]
        public string CONGTHUC_DH_WHERE { get; set; }

        [Column("DAU")]
        public Nullable<int> DAU { get; set; }
        
        [Column("INDAM")]
        public Nullable<int> INDAM { get; set; }
        
        [Column("INNGHIENG")]
        public Nullable<int> INNGHIENG { get; set; }
        
        [Column("HIENTHI")]
        [StringLength(1)]
        public string HIENTHI { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("ISHIEN")]
        public Nullable<int> ISHIEN { get; set; }

        [Column("CONGCHA")]
        public Nullable<int> CONGCHA { get; set; }

        [Column("MA_CHUONG")]
        [StringLength(3)]
        public string MA_CHUONG { get; set; }

        [Column("LOAICHITIEU")]
        [Description("Loại chỉ tiêu")]
        public Nullable<int> LOAICHITIEU { get; set; }

        [Column("SOSAPXEP")]
        public Nullable<int> SOSAPXEP { get; set; }

        [Column("CAP")]
        public Nullable<int> CAP { get; set; }


    }
}