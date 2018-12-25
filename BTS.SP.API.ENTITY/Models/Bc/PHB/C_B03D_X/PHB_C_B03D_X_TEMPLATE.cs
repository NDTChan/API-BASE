using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03D_X
{
    [Table("PHB_C_B03D_X_TEMPLATE")]
    public class PHB_C_B03D_X_TEMPLATE : DataInfoEntity
    {
        [Column("MACHITIEU")]
        [StringLength(20)]
        [Description("Mã chỉ tiêu")]
        public string MACHITIEU { get; set; }

        [Column("TENCHITIEU")]
        [StringLength(255)]
        [Description("Tên chỉ tiêu")]
        public string TENCHITIEU { get; set; }

        [Column("STTCHITIEU")]
        [StringLength(20)]
        [Description("stt chỉ tiêu")]
        public string STTCHITIEU { get; set; }

        [Column("LOAI")]
        [Description("Loại")]
        public int LOAI { get; set; }

        [Column("INDAM")]
        [Description("in dam")]
        public int INDAM { get; set; }

        [Column("INNGHIENG")]
        [Description("in nghieng")]
        public int INNGHIENG { get; set; }

    }
}
