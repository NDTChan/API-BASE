using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_THAMDINH_CHITIET")]
    public class PHE_THAMDINH_CHITIET : DataInfoEntity
    {
        [Column("SO_TOTRINH")]
        [StringLength(50)]
        public string SO_THAMDINH{ get; set; }

        [Column("NOI_DUNG")]
        [StringLength(300)]
        public string NOI_DUNG { get; set; }

        [Column("KET_QUA")]
        public int KET_QUA { get; set; }

        [Column("SO_BANG")]
        public int SO_BANG { get; set; }
    }
}
