using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_DONVI_CHUDAUTU")]
    public class DM_DONVI_CHUDAUTU : DataInfoEntity
    {
        [Column("MA_DONVI")]
        [StringLength(10)]
        [Description("Mã đơn vị chủ đầu tư")]
        public string MaDonVi { get; set; }

        [Column("TEN_DONVI_CHUDAUTU")]
        [StringLength(255)]
        [Description("Tên đơn vị chủ đầu tư")]
        public string Ten_DonVi_ChuThau { get; set; }

        [Column("DIACHI")]
        [StringLength(500)]
        [Description("Địa chỉ")]
        public string DiaChi { get; set; }

        [Column("SODIENTHOAI")]
        [StringLength(11)]
        [Description("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Column("NGUOIDAIDIEN")]
        [StringLength(255)]
        [Description("Người đại diện chủ đầu tư")]
        public string NguoiDaiDien { get; set; }

        [Column("EMAIL")]
        [StringLength(255)]
        [Description("Email của chủ đầu tư")]
        public string Email { get; set; }
    }
}
