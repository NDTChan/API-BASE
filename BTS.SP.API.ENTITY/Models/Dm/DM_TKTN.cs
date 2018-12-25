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
    [Table("DM_TKTN")]
    public class DM_TKTN : DataInfoEntity
    {
        [Column("MA_TKTN")]
        [StringLength(4)]
        [Description("Mã tài khoản Tự nhiên ")]
        public string MA_TKTN { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TEN_TKTN")]
        [StringLength(500)]
        [Description("tên tài khoản Tự nhiên ")]
        public string TEN_TKTN { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [Column("MA_TKTN_CHA")]
        [StringLength(6)]
        public string MA_TKTN_CHA { get; set; }

        [Column("LOAI_TKTN")]
        [StringLength(1)]
        public string LOAI_TKTN { get; set; }

        [Column("CAP_TKTN")]
        [StringLength(1)]
        public string CAP_TKTN { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú ")]
        public string GHI_CHU { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo ")]
        public string USER_NAME { get; set; }
        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo ")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng ")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("NGAY_KT")]
        [Description("Ngày KẾT THÚC ")]
        public Nullable<DateTime> NGAY_KT { get; set; }
        
    }
}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
