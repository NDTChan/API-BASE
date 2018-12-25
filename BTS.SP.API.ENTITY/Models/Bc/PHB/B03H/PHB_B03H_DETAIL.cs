using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B03H
{
    [Table("PHB_B03H_DETAIL")]
    public class PHB_B03H_DETAIL : DataInfoEntity
    {

        [Column("PHB_B03H_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B03H")]
        [StringLength(50)]
        public string PHB_B03H_REFID { get; set; }

        [Column("HOATDONG_ID")]
        [Required]
        [Description("ID trong danh mục loại hoạt động")]
        public int HOATDONG_ID { get; set; }

        [Column("MA_CHI_TIEU")]
        [Required]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string MA_CHI_TIEU { get; set; }

        [Column("MA_SO")]
        [Description("Mã số chỉ tiêu")]
        [StringLength(15)]
        public string MA_SO { get; set; }

        [Column("TEN_CHI_TIEU")]
        [Required]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(250)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("SO_TIEN")]
        public decimal SO_TIEN { get; set; }

        [Column("CONG_THUC")]
        [StringLength(250)]
        public string CONG_THUC { get; set; }

        [Column("MA_LOAI")]
        [StringLength(15)]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(15)]
        public string MA_KHOAN { get; set; }
    }
}
