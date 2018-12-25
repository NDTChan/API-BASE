using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.F022HP1
{
    [Table("PHB_F022HP1_DETAIL")]
    public class PHB_F022HP1_DETAIL : DataInfoEntity
    {
        [Column("PHB_F022HP1_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_F022HP1")]
        [StringLength(50)]
        public string PHB_F022HP1_REFID { get; set; }

        [Column("MA_DA")]
        [Required]
        [StringLength(100)]
        public string MA_DA { get; set; }

        [Column("MA_NGUONNS")]
        [Required]
        [StringLength(15)]
        public string MA_NGUONNS { get; set; }

        [Column("LOAI_CAPPHAT")]
        [Description("Loại cấp phát")]
        public int LOAI_CAPPHAT { get; set; }

        [Column("MA_LOAI")]
        [StringLength(15)]
        [Required]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [StringLength(15)]
        [Required]
        public string MA_KHOAN { get; set; }

        [Column("MA_CHI_TIEU")]
        [StringLength(15)]
        [Required]
        public string MA_CHI_TIEU { get; set; }

        [Column("TEN_CHI_TIEU")]
        [StringLength(150)]
        [Required]
        public string TEN_CHI_TIEU { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [Required]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("MA_SO")]
        [Description("MÃ số")]
        [Required]
        [StringLength(15)]
        public string MA_SO { get; set; }

        [Column("SO_TIEN_DA_DUYET")]
        public decimal SO_TIEN_DA_DUYET { get; set; }

        [Column("SO_TIEN_KY_NAY")]
        public decimal SO_TIEN_KY_NAY { get; set; }

        [Column("LUY_KE_DAU_NAM")]
        public decimal LUY_KE_DAU_NAM { get; set; }

        [Column("LUY_KE_KHOI_DAU")]
        public decimal LUY_KE_KHOI_DAU { get; set; }

        [Column("TONG_SO_TIEN_DA_DUYET")]
        public decimal TONG_SO_TIEN_DA_DUYET { get; set; }

        [Column("CONG_THUC")]
        [StringLength(250)]
        public string CONG_THUC { get; set; }
    }
}
