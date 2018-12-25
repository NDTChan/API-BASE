using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHE
{
    [Table("PHE_DUAN_CONGVIEC")]
    public class PHE_DUAN_CONGVIEC : DataInfoEntity
    {
        [Column("MA_DUAN")]
        [StringLength(50)]
        public string MA_DUAN { get; set; }

        [Column("MA_CONGVIEC")]
        [StringLength(50)]
        public string MaCongViec { get; set; }

        [Column("MA_CHA")]
        [StringLength(50)]
        public string MaCha { get; set; }

        [Column("STT")]
        [StringLength(50)]
        public string STT { get; set; }

        [Column("TENCONGVIEC")]
        [StringLength(250)]
        public string TenCongViec { get; set; }

        [Column("THOIGIAN")]
        public int? ThoiGian { get; set; }

        [Column("TUNGAY")]
        public DateTime? TuNgay { get; set; }

        [Column("DENNGAY")]
        public DateTime? DenNgay { get; set; }

        [Column("NGAYCAPNHAT")]
        public DateTime? NgayCapNhat { get; set; }

        [Column("NGUOITHUCHIEN")]
        [StringLength(250)]
        public string NguoiThucHien { get; set; }

        [Column("NGUOIGIAMSAT")]
        [StringLength(250)]
        public string NguoiGiamSat { get; set; }

        [Column("DONVIPHEDUYET")]
        [StringLength(250)]
        public string DonViPheDuyet { get; set; }

        [Column("VANBANDINHKEM")]
        [StringLength(500)]
        public string VanBanDinhKem { get; set; }

        [Column("TRANGTHAI")]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [Column("GHICHU")]
        [StringLength(300)]
        public string GhiChu { get; set; }

        [Column("FORMNAME")]
        [StringLength(50)]
        public string FORMNAME { get; set; }

    }
}
