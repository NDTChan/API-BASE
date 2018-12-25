using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHF
{
    [Table("PHF_DM_DOITUONG")]
    public class PHF_DM_DOITUONG : DataInfoEntityPHF
    {
        [Required]
        [Column("MA_DOITUONG")]
        [StringLength(50)]
        [Description("Mã đối tượng")]
        public string MA_DOITUONG { get; set; }

        [Required]
        [Column("TEN_DOITUONG")]
        [StringLength(500)]
        [Description("Tên đối tượng")]
        public string TEN_DOITUONG { get; set; }

        [Required]
        [Column("NAM")]
        [Description("Năm")]
        public int NAM { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        [Description("Mã đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }
    }
}
