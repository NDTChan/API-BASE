using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_PHULUC_HOPDONG")]
    public class PHE_PHULUC_HOPDONG : DataInfoEntity
    {
        [Column("MA_PHULUC_HOPDONG")]
        [StringLength(50)]
        public string MA_PHULUC_HOPDONG { get; set; }

        [Column("TEN_PHULUC_HOPDONG")]
        public string TEN_PHULUC_HOPDONG { get; set; }

        [Column("GIATRI_HOPDONG")]
        public decimal GIATRI_HOPDONG { get; set; }

        [Column("GIATRI_DIEUCHINH")]
        public decimal GIATRI_DIEUCHINH { get; set; }

        [Column("NGAY_KY_PHULUC")]
        public DateTime NGAY_KY_PHULUC { get; set; }

        [Column("THOIGIAN_DIEUCHINH")]
        public int THOIGIAN_DIEUCHINH { get; set; }

        [Column("NGAY_DIEUCHINH_KETTHUC")]
        public DateTime NGAY_DIEUCHINH_KETTHUC { get; set; }

        [Column("NOIDUNG_PHULUC")]
        [StringLength(1000)]
        public string NOIDUNG_PHULUC { get; set; }

        [Column("MA_HOPDONG")]
        [StringLength(50)]
        public string MA_HOPDONG { get; set; }

        [Column("NGAY_KY_HOPDONG")]
        public DateTime NGAY_KY_HOPDONG { get; set; }

        [Column("DONVI_THUCHIEN")]
        [StringLength(50)]
        public string DONVI_THUCHIEN { get; set; }

        [Column("THOIGIAN_THUCHIEN")]
        public int THOIGIAN_THUCHIEN { get; set; }

        [Column("NGAY_KETTHUC_HD")]
        public DateTime NGAY_KETTHUC_HD { get; set; }
    }
}
