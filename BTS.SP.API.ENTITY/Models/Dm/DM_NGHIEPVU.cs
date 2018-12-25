using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_NGHIEPVU")]
    public class DM_NGHIEPVU : DataInfoEntity
    {
        [Column("MA_NGHIEPVU")]
        [StringLength(50)]
        public string MA_NGHIEPVU { get; set; }
        [Column("TEN_NGHIEPVU")]
        [StringLength(2000)]
        public string TEN_NGHIEPVU { get; set; }
        [Column("LOAI")]
        [StringLength(20)]
        public string LOAI { get; set; }
        [Column("GHI_CHU")]
        [StringLength(2000)]
        public string GHI_CHU { get; set; }
        [Column("CONG_THUC")]
        [StringLength(2000)]
        public string CONG_THUC { get; set; }
        [Column("DIEU_KIEN")]
        [StringLength(500)]
        public string DIEU_KIEN { get; set; }
        [Column("DR_CR")]
        [StringLength(50)]
        public string DR_CR { get; set; }
        [Column("CQD")]
        [StringLength(3)]
        public string CQD { get; set; }

        [Column("TU_NGAY")]
        [Description("Tu Ngày hiệu lực")]
        public Nullable<DateTime> TU_NGAY { get; set; }
        [Column("DEN_NGAY")]
        [Description("Den Ngày hiệu lực")]
        public Nullable<DateTime> DEN_NGAY { get; set; }
    }
}
