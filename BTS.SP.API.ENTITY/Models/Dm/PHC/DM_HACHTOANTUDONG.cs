using BTS.SP.API.ENTITY.Helper;
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
    [Table("DM_HACHTOANTUDONG")]
    public class DM_HACHTOANTUDONG : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        [Description("Mã")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        [Description("Tên")]
        public string TEN { get; set; }

        [Column("LOAINGHIEPVU")]
        [StringLength(50)]
        [Description("Loại nghiệp vụ")]
        public string LOAINGHIEPVU { get; set; }

        [Column("DIENGIAI")]
        [StringLength(250)]
        [Description("Diễn giải")]
        public string DIENGIAI { get; set; }

        [Column("TAIKHOAN_CHUYEN")]
        [StringLength(20)]
        [Description("Tài khoản chuyển")]
        public string TAIKHOAN_CHUYEN { get; set; }

        [Column("LOAITK_CHUYEN")]
        [StringLength(20)]
        [Description("Loại tài khoản chuyển")]
        public string LOAITK_CHUYEN { get; set; }

        [Column("TAIKHOAN_DEN")]
        [StringLength(20)]
        [Description("Tài khoản đến")]
        public string TAIKHOAN_DEN { get; set; }

        [Column("LOAITK_DEN")]
        [StringLength(20)]
        [Description("Loại tài khoản đến")]
        public string LOAITK_DEN { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Ðang sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }
    }
}
