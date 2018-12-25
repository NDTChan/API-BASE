using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_NGUON_DIA_PHUONG")]
    public class DM_NGUON_DIA_PHUONG : DataInfoEntity
    {
        [Column("MA_NGUON_DIA_PHUONG")]
        [StringLength(4)]
        [Description("Mã du phong ")]
        public string MA_NGUON_DIA_PHUONG { get; set; }

        [Column("TEN_NGUON_DIA_PHUONG")]
        [StringLength(500)]
        [Description("tên du phong ")]
        public string TEN_NGUON_DIA_PHUONG { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }
    }
}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
