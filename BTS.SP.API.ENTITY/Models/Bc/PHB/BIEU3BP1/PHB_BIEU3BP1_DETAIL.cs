using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU3BP1
{
    [Table("PHB_BIEU3BP1_DETAIL")]
    public class PHB_BIEU3BP1_DETAIL:DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHB_BIEU3BP1_REFID { get; set; }

        [StringLength(3)]
        public string MA_LOAI { get; set; }

        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [StringLength(4)]
        public string MA_MUC { get; set; }

        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [StringLength(50)]
        public string STT_CHI_TIEU { get; set; }

        [StringLength(50)]
        [Required]
        public string MA_CHI_TIEU { get; set; }

        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        public double SO_BC { get; set; }
        public double SO_XDTD { get; set; }
        public int PHAN { get; set; }
    }
}
