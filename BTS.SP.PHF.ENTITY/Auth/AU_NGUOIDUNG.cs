using Repository.Pattern.Ef6;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY.Auth
{
    [Table("AU_NGUOIDUNG")]
    public class AU_NGUOIDUNG : Entity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string USERNAME { get; set; }

        [StringLength(500)]
        [Description("Mật khẩu")]
        [Required]
        public string PASSWORD { get; set; }

        [StringLength(500)]
        [Description("Họ tên")]
        [Required]
        public string FULLNAME { get; set; }

        [StringLength(500)]
        [Description("Email")]
        public string EMAIL { get; set; }

        [StringLength(20)]
        [Description("SĐT")]
        public string PHONE { get; set; }

        [StringLength(50)]
        [Required]
        public string MA_DBHC { get; set; }

        [StringLength(50)]
        public string CHUCVU { get; set; }

        [StringLength(500)]
        public string GHICHU { get; set; }

        [Description("Trạng thái sử dụng (1: Đang sử dụng; 0: Không sử dụng) ")]
        public int TRANGTHAI { get; set; }

        [Description("Mã địa bàn hành chính cha")]
        [StringLength(50)]
        public string MA_DBHC_CHA { get; set; }

        [Description("Mã quan hệ ngân sách đơn vị")]
        [StringLength(2000)]
        public string MA_QHNS { get; set; }

        [Description("Loại user: 1: admin địa bàn, 2: theo đơn vị qhns")]
        public int LOAI { get; set; }
    }
}
