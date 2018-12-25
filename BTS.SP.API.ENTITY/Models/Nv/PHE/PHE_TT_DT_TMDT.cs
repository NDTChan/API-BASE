using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_TT_DT_TMDT")]
    public class PHE_TT_DT_TMDT : DataInfoEntity
    {

        [Column("MA_TT_DT_TMDT")]
        [StringLength(50)]
        public string MA_TT_DT_TMDT { get; set; }

        [Column("TEN_TT_DT_TMDT")]
        [StringLength(50)]
        public string TEN_TT_DT_TMDT { get; set; }


        [Column("LOAI_TT_DT_TMDT")]
        public int LOAI_TT_DT_TMDT { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MA_CONGVIEC{ get; set; }

        [Column("SO_VANBAN")]
        [StringLength(50)]
        public string SO_VANBAN { get; set; }

        [Column("TONGSO_DT")]
        public Decimal? TONGSO_DT{ get; set; }

    }
}
