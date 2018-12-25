using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    [Table("PHE_DM_NHOMVANBAN")]
    public class PHE_DM_NHOMVANBAN : DataInfoEntity
    {
        [Required]
        [Column("MA_NHOMVANBAN")]
        [StringLength(50)]
        [Description("Mã nhóm văn bản")]
        public string MA_NHOMVANBAN { get; set; }

        [Required]
        [Column("TEN_NHOMVANBAN")]
        [StringLength(250)]
        [Description("Tên nhóm văn bản")]
        public string TEN_NHOMVANBAN { get; set; }

        [Required]
        [Column("MA_LOAIVANBAN")]
        [StringLength(50)]
        [Description("Loại văn bản")]
        public string MA_LOAIVANBAN { get; set; }
    }
}
