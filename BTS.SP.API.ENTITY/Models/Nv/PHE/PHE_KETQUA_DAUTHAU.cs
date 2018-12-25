using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_KETQUA_DAUTHAU")]
    public class PHE_KETQUA_DAUTHAU : DataInfoEntity
    {
        [Column("MA_KETQUA")]
        [StringLength(50)]
        public string MA_KETQUA { get; set; }

        [Column("MA_KEHOACH")]
        [StringLength(50)]
        public string MA_KEHOACH { get; set; }

        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MA_CONGVIEC{ get; set; }

        [Column("SO_PHEDUYET")]
        [StringLength(50)]
        public string SO_PHEDUYET { get; set; }

        [Column("NGAY_PHEDUYET")]
        public DateTime? NGAY_PHEDUYET { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        public string MA_DONVI { get; set; }

        [Column("DIACHI_DONVI")]
        [StringLength(200)]
        public string DIACHI_DONVI { get; set; }

        [Column("HINHGTHUC_HOPDONG")]
        [StringLength(200)]
        public string HINHGTHUC_HOPDONG { get; set; }

        [Column("FILE_DINHKEM")]
        public string FILE_DINHKEM { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(500)]
        public string NOI_DUNG { get; set; }

        [Column("THOIGIAN_THUCHIEN")]
        public int? THOIGIAN_THUCHIEN { get; set; }

        [Column("THOIGIAN_LUACHON")]
        public int? THOIGIAN_LUACHON { get; set; }
    }
}