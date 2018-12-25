using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_DTTHANHTOAN")]
    public class DM_DTTHANHTOAN : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        public string TEN { get; set; }

        [Column("TEN_RUTGON")]
        [StringLength(250)]
        public string TEN_RUTGON { get; set; }

        [Column("BAC")]
        public Nullable<int> BAC { get; set; }

        [Column("CHITIET")]
        public Nullable<int> CHITIET { get; set; }

        [Column("MA_DB")]
        [StringLength(100)]
        public string MA_DB { get; set; }

        [Column("DIACHI")]
        [StringLength(250)]
        public string DIACHI { get; set; }

        [Column("SO_TK")]
        [StringLength(50)]
        public string SO_TK { get; set; }

        [Column("TEN_NGANHANG")]
        [StringLength(250)]
        public string TEN_NGANHANG { get; set; }

        [Column("SO_CMTND")]
        [StringLength(20)]
        public string SO_CMTND { get; set; }

        [Column("NGAY_CAP")]
        public Nullable<DateTime> NGAY_CAP { get; set; }

        [Column("NOICAP")]
        [StringLength(250)]
        public string NOICAP { get; set; }

        [Column("MA_KBNN")]
        [StringLength(50)]
        public string MA_KBNN { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        public string MA_DVQHNS { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
        [Column("LOAI_DT")]
        public Nullable<int> LOAI_DT { get; set; }

        [Column("MST")]
        [StringLength(50)]
        public string MST { get; set; }

        [Column("TINH")]
        [StringLength(50)]
        public string TINH { get; set; }

        [Column("HUYEN")]
        [StringLength(50)]
        public string HUYEN { get; set; }
    }
}