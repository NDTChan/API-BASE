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
    [Table("DM_CHUCVU")]
    public class DM_CHUCVU : DataInfoEntity
    {
        [Column("MA_CHUCVU")]
        [StringLength(4)]
        [Description("Mã chức vụ ")]
        public string MA_CHUCVU { get; set; }

        [Column("TEN_CHUCVU")]
        [StringLength(500)]
        [Description("tên chức vụ ")]
        public string TEN_CHUCVU { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú ")]
        public string GHI_CHU { get; set; }

    }
}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
