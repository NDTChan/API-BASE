using BTS.SP.API.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B01X
{
    [Table("PHB_C_B01X_DETAIL")]
    public class PHB_C_B01X_DETAIL : DataInfoEntity
    {
        [Required]
        [Description("Guid ID trong PHB_C_B01X")]
        [StringLength(50)]
        public string PHB_C_B01X_REFID { get; set; }

        [Description("Loại tài khoản: 1 TRONG BẢNG , 2 NGOÀI BẢNG")]
        public int LOAI { get; set; }

        [Description("Mã tài khoản")]
        [Required]
        [StringLength(20)]
        public string MA_TAIKHOAN { get; set; }

        [Description("Tên tài khoản")]
        [Required]
        [StringLength(250)]
        public string TEN_TAIKHOAN { get; set; }

        [Description("Số dư đầu kỳ - Nợ")]
        public double SDDK_NO { get; set; }

        [Description("Số dư đầu kỳ - Có")]
        public double SDDK_CO { get; set; }

        [Description("Phát sinh trong kỳ - Nợ")]
        public double PSTK_NO { get; set; }

        [Description("Phát sinh trong kỳ - Có")]
        public double PSTK_CO { get; set; }

        [Description("Lũy kế từ đầu năm - Nợ")]
        public double LUYKE_NO { get; set; }

        [Description("Lũy kế từ đầu năm - Có")]
        public double LUYKE_CO { get; set; }

        [Description("Số dư cuối kỳ - Nợ")]
        public double SDCK_NO { get; set; }

        [Description("Số dư cuối kỳ - Có")]
        public double SDCK_CO { get; set; }
    }
}
