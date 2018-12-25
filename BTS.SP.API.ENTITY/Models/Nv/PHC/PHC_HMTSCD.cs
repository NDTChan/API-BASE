using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_HMTSCD")]
    public class PHC_HMTSCD : DataInfoEntityPHC
    {
        [Required]
        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("SO chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT{ get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạc toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("ISBOHAOMON")]
        [Description("Đã bỏ hao mòn")]
        public Nullable<bool> ISBOHAOMON { get; set; }



    }
}
