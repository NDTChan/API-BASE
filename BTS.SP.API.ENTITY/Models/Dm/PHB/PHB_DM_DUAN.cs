using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHB
{
    [Table("PHB_DM_DUAN")]
    public class PHB_DM_DUAN : DataInfoEntity
    {
        [Column("MA_DA")]
        [StringLength(15)]
        [Required]
        public string MA_DA { get; set; }

        [Column("SOHIEU_DA")]
        [StringLength(15)]
        [Required]
        public string SOHIEU_DA { get; set; }

        [Column("TEN_DA")]
        [StringLength(250)]
        [Required]
        public string TEN_DA { get; set; }

        [Column("TEN_EN_DUAN")]
        [StringLength(250)]
        public string TEN_EN_DUAN { get; set; }

        [Column("TEN_CTMT")]
        [StringLength(250)]
        public string TEN_CTMT { get; set; }

        [Column("NGAY_BATDAU")]
        public DateTime NGAY_BATDAU { get; set; }

        [Column("NGAY_KETTHUC")]
        public DateTime NGAY_KETTHUC { get; set; }

        [Column("MA_CHA")]
        [StringLength(15)]
        public string MA_CHA { get; set; }

        [Column("CAP")]
        [Required]
        public int CAP { get; set; }

        [Column("DONVI_THUCHIEN")]
        [StringLength(250)]
        public string DONVI_THUCHIEN { get; set; }

        [Column("MO_TA")]
        [StringLength(250)]
        public string MO_TA { get; set; }

        [Column("LOAI_DOI_TUONG")]
        [Required]
        public int LOAI_DOI_TUONG { get; set; }

        [Column("LA_CHITIET")]
        [Required]
        public int LA_CHITIET { get; set; }

        [Column("LA_HETHONG")]
        [Required]
        public int LA_HETHONG { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        [Required]
        public string TRANG_THAI { get; set; }

    }
}
