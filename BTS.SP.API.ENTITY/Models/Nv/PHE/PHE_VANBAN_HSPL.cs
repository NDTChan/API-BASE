using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_VANBAN_HSPL")]
    public class PHE_VANBAN_HSPL : DataInfoEntity
    {
        [Required]
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Required]
        [Column("LOAI_VANBAN")]
        [StringLength(50)]
        public string LOAI_VANBAN { get; set; }

        [Required]
        [Column("SO_HOSO")]
        [StringLength(50)]
        public string SO_HOSO { get; set; }

        [Required]
        [Column("TEN_HOSO")]
        [StringLength(250)]
        public string TEN_HOSO { get; set; }

        [Required]
        [Column("NGAY_KY")]
        [Description("Ngày ký")]
        public DateTime NGAY_KY { get; set; }

        [Required]
        [Column("COQUAN_DUYET")]
        [StringLength(250)]
        public string COQUAN_DUYET { get; set; }

        [Column("NGUOI_KY")]
        [StringLength(100)]
        public string NGUOI_KY { get; set; }

        [Column("CHUC_VU")]
        [StringLength(100)]
        public string CHUC_VU { get; set; }

        public double TONG_GIA_TRI { get; set; }

        [Column("DINH_KEM")]
        [StringLength(500)]
        public string DINH_KEM { get; set; }
    }
}
