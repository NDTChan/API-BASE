using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.Bieu03
{
    [Table("PHB_BIEU03_TEMPLATE")]
    public class PHB_BIEU03_TEMPLATE:DataInfoEntity
    {
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Required]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string MA_CHI_TIEU { get; set; }


        [Required]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(250)]
        public string TEN_CHI_TIEU { get; set; }

        [StringLength(500)]
        public string CONG_THUC { get; set; }

        [Column("LOAI")]
        public int LOAI { get; set; }

        [Column("SAPXEP")]
        public int SAPXEP { get; set; }

        public int INDAM { get; set; }

        public int INNGHIENG { get; set; }
    }
}
