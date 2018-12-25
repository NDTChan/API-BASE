using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_CHITIET_KEHOACH_KETQUA")]
    public class PHE_CHITIET_KEHOACH_KETQUA : DataInfoEntity
    {

        [Column("MA_KEHOACH")]
        [StringLength(50)]
        public string MA_KEHOACH { get; set; }

        [Column("MA_GOITHAU")]
        [StringLength(50)]
        public string MA_GOITHAU { get; set; }

        [Column("TEN_GOITHAU")]
        [StringLength(500)]
        public string TEN_GOITHAU { get; set; }

        [Column("MA_NGUONVON")]
        [StringLength(50)]
        public string MA_NGUONVON { get; set; }

        [Column("DUTOAN_DUOCDUYET")]
        [StringLength(50)]
        public string DUTOAN_DUOCDUYET { get; set; }

        [Column("MA_HINHTHUC_LUACHON_NHATHAU")]
        [StringLength(50)]
        public string MA_HINHTHUC_LUACHON_NHATHAU { get; set; }

        [Column("MA_PHUONGTHUC_LUACHON_NHATHAU")]
        [StringLength(50)]
        public string MA_PHUONGTHUC_LUACHON_NHATHAU { get; set; }

        [Column("MA_HIENTRANG_HOPDONG")]
        [StringLength(50)]
        public string MA_HIENTRANG_HOPDONG { get; set; }

        [Column("MA_LINHVUC")]
        [StringLength(50)]
        public string MA_LINHVUC { get; set; }

        [Column("MA_HANGMUC")]
        public string MA_HANGMUC { get; set; }

        [Column("KEHOACH_THOIGIAN_LUACHON")]
        [StringLength(50)]
        public string KEHOACH_THOIGIAN_LUACHON { get; set; }

        [Column("KEHOACH_THOIGIAN_THUCHIEN")]
        [StringLength(50)]
        public string KEHOACH_THOIGIAN_THUCHIEN { get; set; }

        [Column("KETQUA_THOIGIAN_LUACHON")]
        [StringLength(50)]
        public string KETQUA_THOIGIAN_LUACHON { get; set; }

        [Column("KETQUA_THOIGIAN_THUCHIEN")]
        [StringLength(50)]
        public string KETQUA_THOIGIAN_THUCHIEN { get; set; }

        [Column("GIA_GOITHAU_DUOCDUYET")]
        public decimal GIA_GOITHAU_DUOCDUYET { get; set; }

        [Column("MA_DONVI")]
        [StringLength(50)]
        public string MA_DONVI { get; set; }

        [Column("MA_DONVI_TRUNGTHAU")]
        [StringLength(50)]
        public string MA_DONVI_TRUNGTHAU { get; set; }

        [Column("DC_DONVI_TRUNGTHAU")]
        public string DC_DONVI_TRUNGTHAU { get; set; }

        [Column("TG_BATDAU_PHATHANH_HSMQT")]
        public DateTime? TG_BATDAU_PHATHANH_HSMQT { get; set; }

        [Column("TG_KETTHUC_PHATHANH_HSMQT")]
        public DateTime? TG_KETTHUC_PHATHANH_HSMQT { get; set; }

        [Column("DIADIEM_PHATHANH")]
        public string DIADIEM_PHATHANH { get; set; }

        [Column("THOIDIEM_DONGTHAU")]
        public DateTime? THOIDIEM_DONGTHAU { get; set; }

        [Column("THOIDIEM_MOTHAU")]
        public DateTime? THOIDIEM_MOTHAU { get; set; }


    }
}
