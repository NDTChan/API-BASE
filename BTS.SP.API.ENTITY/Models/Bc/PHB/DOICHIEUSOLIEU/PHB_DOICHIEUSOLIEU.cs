using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Bc.PHB.DOICHIEUSOLIEU
{
    public class PHB_DOICHIEUSOLIEU : DataInfoEntity
    {
        [Column("MA_DVQHNS")]
        [Required]
        [StringLength(20)]
        public string MA_DVQHNS { get; set; }

        [Column("TEN_DVQHNS")]
        [StringLength(240)]
        [Required]
        public string TEN_DVQHNS { get; set; }

        [Column("MA_DVQHNS_CHA")]
        [StringLength(20)]
        public string MA_DVQHNS_CHA { get; set; }

        [Column("CAP_DUTOAN")]
        [StringLength(2)]
        [Required]
        public string CAP_DUTOAN { get; set; }

        [Column("LOAI_DULIEU")]
        [StringLength(3)]
        public string LOAI_DULIEU { get; set; }

        [Column("NAM")]
        [Description("Năm đối chiếu")]
        public int NAM { get; set; }

        [Column("NGAY_TAO")]
        [Required]
        public DateTime NGAY_TAO { get; set; }

        //[Column("MA_HUYEN")]
        //[Description("Mã huyện")]
        //[StringLength(3)]
        //public string MA_HUYEN { get; set; }

        [Description("Mã địa bàn hành chính")]
        [StringLength(5)]
        public string MA_DBHC { get; set; }

        [Column("SOTIEN_DENGHI")]
        [Description("Số tiền đề nghị (đơn vị)")]
        public decimal SOTIEN_DENGHI { get; set; }

        [Column("SOTIEN_TABMIS")]
        [Description("Số tiền đã thực thi (Tabmis)")]
        public decimal SOTIEN_TABMIS { get; set; }
    }
}
