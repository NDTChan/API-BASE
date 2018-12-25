using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_DANHMUC")]
    public class DM_DANHMUC : DataInfoEntity
    {
        [Required]
        [Column("MADANHMUC")]
        [StringLength(50)]
        public string MADANHMUC { get; set; }

        [Column("MADANHMUC_CHA")]
        [StringLength(50)]
        public string MADANHMUC_CHA { get; set; }

        [Column("TENDANHMUC")]
        [StringLength(500)]
        public string TENDANHMUC { get; set; }

        [Column("TENDANHMUC_RUTGON")]
        [StringLength(250)]
        public string TENDANHMUC_RUTGON { get; set; }

        [Column("CHITIET")]
        public Nullable<int> CHITIET { get; set; }

        [Column("MALOAIHINH")]
        [StringLength(50)]
        public string MALOAIHINH { get; set; }

        [Column("TYLE_HAOMON")]
        public Nullable<int> TYLE_HAOMON { get; set; }

        [Column("DONVITINH")]
        [StringLength(20)]
        public string DONVITINH { get; set; }

        [Column("BAC")]
        public Nullable<int> BAC { get; set; }

        [Column("NAM_SX")]
        public Nullable<int> NAM_SX { get; set; }

        [Column("NAM_SD")]
        public Nullable<int> NAM_SD { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("USER_NAME")]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

    }
}