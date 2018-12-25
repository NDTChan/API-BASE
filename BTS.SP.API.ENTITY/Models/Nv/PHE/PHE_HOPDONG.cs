using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_HOPDONG")]
    public class PHE_HOPDONG : DataInfoEntity
    {
        [Required]
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Required]
        [Column("MA_GOITHAU")]
        [StringLength(50)]
        public string MA_GOITHAU { get; set; }

        [Column("MA_HOPDONG")]
        [StringLength(50)]
        public string MA_HOPDONG { get; set; }

        [Column("MA_NHATHAU")]
        [StringLength(50)]
        public string MA_NHATHAU { get; set; }

        [Column("TEN_HOPDONG")]
        [StringLength(500)]
        public string TEN_HOPDONG { get; set; }

        [Required]
        [Column("SO_HOPDONG")]
        [StringLength(50)]
        public string SO_HOPDONG { get; set; }

        [Column("NGAY_BATDAU")]
        public DateTime? NGAY_BATDAU { get; set; }

        [Column("NGAY_KETTHUC")]
        public DateTime? NGAY_KETTHUC { get; set; }

        [Column("SO_QUYETDINH")]
        [StringLength(50)]
        public string SO_QUYETDINH { get; set; }

        [Column("NGAY_QUYETDINH")]
        public DateTime? NGAY_QUYETDINH { get; set; }

        [Column("COQUAN_QUYETDINH")]
        [StringLength(500)]
        public string COQUAN_QUYETDINH { get; set; }

        [Column("THOIGIAN_THUCHIEN")]
        [StringLength(50)]
        public string THOIGIAN_THUCHIEN { get; set; }

        [Column("NGAY_NGHIEMTHU")]
        public DateTime? NGAY_NGHIEMTHU { get; set; }

        [Column("NGAY_THANHLY")]
        public DateTime? NGAY_THANHLY { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        public string MA_DONVI { get; set; }

        [Column("MA_PHONGBAN")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }
    }
}
