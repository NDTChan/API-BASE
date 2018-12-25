using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_KEHOACH_KETQUA")]
    public class PHE_KEHOACH_KETQUA : DataInfoEntity
    {

        [Column("MA_KEHOACH")]
        [StringLength(50)]
        public string MA_KEHOACH { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("SO_PHEDUYET")]
        [StringLength(50)]
        public string SO_PHEDUYET { get; set; }

        [Column("NGAY_PHEDUYET")]
        public DateTime NGAY_PHEDUYET { get; set; }

        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MA_CONGVIEC { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(500)]
        public string NOI_DUNG { get; set; }

        [Column("MA_VANBAN")]
        [StringLength(50)]
        public string MA_VANBAN { get; set; }

        [Column("FILE_DINHKEM")]
        public string FILE_DINHKEM { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        public string MA_DONVI { get; set; }

        [Column("LOAI")]
        [StringLength(50)]
        public string LOAI { get; set; }

        [Column("SO_KQ")]
        public int? SO_KQ { get; set; }

        [Column("GIATRI_GOITHAU")]
        public decimal? GIATRI_GOITHAU { get; set; }

    }
}
