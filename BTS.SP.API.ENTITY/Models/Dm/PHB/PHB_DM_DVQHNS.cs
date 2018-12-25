using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_DVQHNS")]
    public class PHB_DM_DVQHNS:DataInfoEntity
    {
        [Column("MA_QHNS")]
        [Required]
        [StringLength(15)]
        public string MA_QHNS { get; set; }
        [Column("TEN_QHNS")]
        [Required]
        [StringLength(250)]
        public string TEN_QHNS { get; set; }
        [Column("MA_CHA")]
        [StringLength(15)]
        public string MA_CHA { get; set; }
        [Column("DIA_CHI")]
        [StringLength(500)]
        public string DIA_CHI { get; set; }
        [Column("CAP_DU_TOAN")]
        [Required]
        public int CAP_DU_TOAN { get; set; }
        [Column("DON_VI_TONG_HOP")]
        [Required]
        [Description("1: Là đơn vị nhận báo cáo tổng hợp")]
        public int DON_VI_TONG_HOP { get; set; }
        [Column("TRANG_THAI")]
        [Required]
        [Description("A: Sử dụng | I:Không sử dụng")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("MA_CHUONG")]
        [Required]
        [StringLength(15)]
        public string MA_CHUONG { get; set; }

        [Description("Mã địa bàn hành chính")]
        [StringLength(5)]
        public string MA_DBHC { get; set; }

        [Description("Mã địa bàn hành chính cha")]
        [StringLength(5)]
        public string MA_DBHC_CHA { get; set; }

        [Description("Mã đơn vị QHNS đơn vị quản lý")]
        [StringLength(50)]
        public string MA_QHNS_DVQL { get; set; }

    }
}
