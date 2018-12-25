using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Au.PHB
{
    [Table("PHB_AU_NGUOIDUNG")]
    public class PHB_AU_NGUOIDUNG:DataInfoEntity
    {
        [Column("USERNAME")]
        [StringLength(30)]
        [Required]
        public string USERNAME { get; set; }

        [Column("PASSWORD")]
        [StringLength(500)]
        [Description("Mật khẩu")]
        [Required]
        public string PASSWORD { get; set; }

        [Column("FULLNAME")]
        [StringLength(500)]
        [Description("Họ tên")]
        [Required]
        public string FULLNAME { get; set; }

        [Column("EMAIL")]
        [StringLength(500)]
        [Description("Email")]
        public string EMAIL { get; set; }

        [Column("PHONE")]
        [StringLength(20)]
        [Description("SĐT")]
        public string PHONE { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (1: Đang sử dụng; 0: Không sử dụng) ")]
        public int TRANG_THAI { get; set; }
    }
}
