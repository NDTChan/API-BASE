using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B01H
{
    [Table("PHB_B01H_DETAIL")]
    public class PHB_B01H_DETAIL:DataInfoEntity
    {
        [Column("PHB_B01H_REFID")]
        [Required]
        [Description("RefID Guid ID trong  PHB_B01H")]
        [StringLength(50)]
        public string PHB_B01H_REFID { get; set; }

        [Column("MA_TAI_KHOAN")]
        [Required]
        [StringLength(15)]
        public string MA_TAI_KHOAN { get; set; }

        [Column("TEN_TAI_KHOAN")]
        [Required]
        [StringLength(250)]
        public string TEN_TAI_KHOAN { get; set; }

        [Column("MA_NGUON_NSNN")]
        [StringLength(15)]
        [Description("Mã nguồn ngân sách")]
        public string MA_NGUON_NSNN { get; set; }

        [Column("MA_LOAI")]
        [StringLength(15)]
        [Description("Mã loại")]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(15)]
        [Description("Mã khoản")]
        public string MA_KHOAN { get; set; }

        [Column("SO_TIEN_DUDK_C")]
        [Description("Số tiền dư đầu kỳ có")]
        public decimal SO_TIEN_DUDK_C { get; set; }

        [Column("SO_TIEN_DUDK_N")]
        [Description("Số tiền dư đầu kỳ nợ")]
        public decimal SO_TIEN_DUDK_N { get; set; }

        [Column("SO_TIEN_PSKN_N")]
        [Description("Số tiền phát sinh kỳ này nợ")]
        public decimal SO_TIEN_PSKN_N { get; set; }

        [Column("SO_TIEN_PSKN_C")]
        [Description("Số tiền phát sinh kỳ này có")]
        public decimal SO_TIEN_PSKN_C { get; set; }

        [Column("SO_TIEN_PSLK_N")]
        [Description("Số tiền phát sinh lũy kế nợ")]
        public decimal SO_TIEN_PSLK_N { get; set; }

        [Column("SO_TIEN_PSLK_C")]
        [Description("Số tiền phát sinh lũy kế có")]
        public decimal SO_TIEN_PSLK_C { get; set; }

        [Column("SO_TIEN_DUCK_C")]
        [Description("Số tiền dư cuối kỳ có")]
        public decimal SO_TIEN_DUCK_C { get; set; }

        [Column("SO_TIEN_DUCK_N")]
        [Description("Số tiền dư cuối kỳ nợ")]
        public decimal SO_TIEN_DUCK_N { get; set; }

    }
}
