using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_KETQUA_DAUTHAU_CHITIET")]
    public class PHE_KETQUA_DAUTHAU_CHITIET : DataInfoEntity
    {
        [Column("MA_KETQUA")]
        [StringLength(50)]
        public string MA_KETQUA { get; set; }

        [Column("MA_HANGMUC")]
        [StringLength(50)]
        public string MA_HANGMUC { get; set; }

        [Column("MA_CHIPHI")]
        [StringLength(200)]
        public string MA_CHIPHI { get; set; }

        [Column("MA_CHA")]
        [StringLength(200)]
        public string MA_CHA { get; set; }

        [Column("TEN_CHIPHI")]
        [StringLength(1000)]
        public string TEN_CHIPHI { get; set; }

        [Column("NGOAITE_DT")]
        public decimal? NGOAITE_DT { get; set; }

        [Column("DONGIA_DT")]
        public decimal? DONGIA_DT { get; set; }

        [Column("SOLUONG_DT")]
        public int? SOLUONG_DT { get; set; }

        [Column("THANHTIEN_DT")]
        public decimal? THANHTIEN_DT { get; set; }

        [Column("NGOAITE_GT")]
        public decimal? NGOAITE_GT { get; set; }

        [Column("DONGIA_GT")]
        public decimal? DONGIA_GT { get; set; }

        [Column("SOLUONG_GT")]
        public int? SOLUONG_GT { get; set; }

        [Column("THANHTIEN_GT")]
        public decimal? THANHTIEN_GT { get; set; }

        [Column("THOIGIAN_THUCHIEN")]
        public int? THOIGIAN_THUCHIEN { get; set; }

        [Column("THOIGIAN_LUACHON")]
        public int? THOIGIAN_LUACHON { get; set; }

        [Column("LOAINGOAITE_DT")]
        [StringLength(50)]
        public string LOAINGOAITE_DT { get; set; }

        [Column("LOAINGOAITE_GT")]
        [StringLength(50)]
        public string LOAINGOAITE_GT { get; set; }
    }
}