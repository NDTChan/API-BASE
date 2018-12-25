using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2CP1
{
    [Table("PHB_BIEU2CP1_TEMPLATE")]
    public class PHB_BIEU2CP1_TEMPLATE : DataInfoEntity
    {

        [Column("MA_CHI_TIEU")]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string MA_CHI_TIEU { get; set; }        

        [Column("TEN_CHI_TIEU")]
        [Required]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(250)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("SAP_XEP")]
        [Description("Sắp xếp")]
        [Required]
        public int SAP_XEP { get; set; }        

        [Column("TRANG_THAI")]
        [Required]
        public int TRANG_THAI { get; set; }


        [Column("IS_BOLD")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        public int IS_ITALIC { get; set; }
    }
}
