using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B03CTH
{
    [Table("PHB_B03CTH_DETAIL")]
    public class PHB_B03CTH_DETAIL : DataInfoEntity
    {
        [Column("PHB_B03CTH_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B03CTH")]
        [StringLength(50)]
        public string PHB_B03CTH_REFID { get; set; }

        [Column("MA_LOAI")]
        [StringLength(15)]
        [Description("Mã loại")]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(15)]
        [Description("Mã khoản")]
        public string MA_KHOAN { get; set; }


        [Column("MA_NGUONNS")]
        [Description("Mã nguồn ngân sách")]
        [StringLength(15)]
        public string MA_NGUONNS { get; set; }

        [Column("MA_CHI_TIEU")]
        [Required]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string MA_CHI_TIEU { get; set; }

        [Column("TEN_CHI_TIEU")]
        [Required]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(250)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("MA_SO")]
        [Description("Mã số chỉ tiêu")]
        [StringLength(15)]
        [Required]
        public string MA_SO { get; set; }

        [Column("CONG_THUC")]
        [StringLength(250)]
        public string CONG_THUC { get; set; }

        [Column("SO_DU_TOAN")]
        public decimal SO_DU_TOAN { get; set; }

        [Column("SO_THUC_HIEN")]
        public decimal SO_THUC_HIEN { get; set; }
    }
}
