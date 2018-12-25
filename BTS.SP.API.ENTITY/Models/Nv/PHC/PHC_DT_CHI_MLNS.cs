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
    [Table("PHC_DT_CHI_MLNS")]
    public class PHC_DT_CHI_MLNS : DataInfoEntityPHC
    {
        [Required]
        [Column("SOCHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SOCHUNGTU { get; set; }


        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT { get; set; }

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        //Không phân bổ = 0,
        //Theo quý = 1,
        //Theo tháng = 2,
        [Column("LOAIPHANBO")]
        [Description("Loại phân bổ")]
        public Nullable<int> LOAIPHANBO { get; set; }

        [Column("TUDONGPHANBO")]
        [Description("Tự động phân bổ")]
        public Nullable<bool> TUDONGPHANBO { get; set; }


        //DAUNAM = 1,
        //BOSUNG = 2,
        //DIEUCHINH = 3,
        //HUY = 4,
        [Column("LOAI_DT")]
        [Description("Loại Dự toán")]
        public Nullable<int> LOAI_DT { get; set; }


        [Column("FILE_NAME")]
        [StringLength(300)]
        [Description("File đính kèm")]
        public string FILE_NAME { get; set; }

        [Column("SOCHUNGTUGOC")]
        [StringLength(50)]
        [Description("Số chứng từ gốc")]
        public string SOCHUNGTUGOC { get; set; }

        [Column("LUUTAM")]
        [Description("Lưu tạm ")]
        public Nullable<int> LUUTAM { get; set; }

    }
}
