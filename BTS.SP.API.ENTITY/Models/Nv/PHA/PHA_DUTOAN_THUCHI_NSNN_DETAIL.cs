using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_DUTOAN_THUCHI_NSNN_DETAIL")]
    public class PHA_DUTOAN_THUCHI_NSNN_DETAIL :DataInfoEntity
    {
        [Column("PHA_DUTOAN_THUCHI_NSNN_REFID")]
        [Required]
        [StringLength(50)]
        public string PHA_DUTOAN_THUCHI_NSNN_REFID { get; set; }

        [Column("STT")]
        [StringLength(5)]
        public string STT { get; set; }

        [Column("MA_CHITIEU")]
        [StringLength(20)]
        public string MA_CHITIEU { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(200)]
        public string NOI_DUNG { get; set; }

        [Column("DONVI_TINH")]
        [StringLength(20)]
        public string DONVI_TINH { get; set; }

        [Column("LOAI_CHITIEU")]
        [StringLength(1)]
        [Required]
        public string LOAI_CHITIEU { get; set; }

        public decimal DUTOAN_NAMSAU { get; set; }
        public decimal UOC_NAMNAY { get; set; }
        public decimal SOSANH_UTH_DT { get; set; }
        public decimal HESO_LUONGCB { get; set; }
        public decimal SO_LUONG { get; set; }
        public decimal DINH_MUC { get; set; }
        public decimal DUTOAN_NAMNAY { get; set; }
        public decimal SOSANH { get; set; }
        public decimal GIAO_DONVI { get; set; }
        public decimal TRONGDO_QUYKT { get; set; }
        public decimal QD_UBND { get; set; }
        public decimal QD_HDND { get; set; }
    }
}
