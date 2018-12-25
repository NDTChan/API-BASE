using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_TOTRINH")]
    public class PHE_TOTRINH : DataInfoEntity
    {
        [Column("SO_TOTRINH")]
        [StringLength(50)]
        public string SO_TOTRINH { get; set; }

        [Column("TEN_TOTRINH")]
        [StringLength(200)]
        public string TEN_TOTRINH { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MA_CONGVIEC{ get; set; }

        [Column("THONGTIN_KHAC")]
        [StringLength(300)]
        public string THONGTIN_KHAC { get; set; }

        [Column("MA_PHONGBAN")]
        [StringLength(100)]
        public string MA_PHONGBAN { get; set; }

        [Column("MA_DONVI")]
        [StringLength(100)]
        public string MA_DONVI { get; set; }

    }
}
