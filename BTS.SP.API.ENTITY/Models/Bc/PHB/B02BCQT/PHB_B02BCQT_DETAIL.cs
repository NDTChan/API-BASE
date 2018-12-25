using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B02BCQT
{
    [Table("PHB_B02BCQT_DETAIL")]
    public class PHB_B02BCQT_DETAIL : DataInfoEntity
    {
        [Column("PHB_B02BCQT_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B02BCQT")]
        [StringLength(50)]
        public string PHB_B02BCQT_REFID { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("MA_CHI_TIEU")]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(50)]
        public string MA_CHI_TIEU { get; set; }

        [Column("MA_CHI_TIEU_CHA")]
        [Description("Mã chỉ tiêu cha")]
        [StringLength(50)]
        public string MA_CHI_TIEU_CHA { get; set; }

        [Column("TEN_CHI_TIEU")]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(255)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("TEN_CHI_TIEU_OLD")]
        [Description("Tên chỉ tiêu báo cáo cũ")]
        [StringLength(255)]
        public string TEN_CHI_TIEU_OLD { get; set; }

        [Column("LOAI")]
        public int LOAI { get; set; }

        [Column("PHAN")]
        [StringLength(20)]
        public string PHAN { get; set; }

        public double SKN_TONGSO { get; set; }
        public double SKN_THANHTRA { get; set; }
        public double SKN_KIEMTOAN { get; set; }
        public double SKN_TAICHINH { get; set; }
        public double SDXL_TONGSO { get; set; }
        public double SDXL_THANHTRA { get; set; }
        public double SDXL_KIEMTOAN { get; set; }
        public double SDXL_TAICHINH { get; set; }
        public double SCXL_TONGSO { get; set; }
        public double SCXL_THANHTRA { get; set; }
        public double SCXL_KIEMTOAN { get; set; }
        public double SCXL_TAICHINH { get; set; }

    }
}
