using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Sys
{
    [Table("SYS_USER")]
    public class SYS_USER : DataInfoEntity
    {
        [Column("USER_NAME")]
        [StringLength(30)]              
        [Description("Tên người dùng")]
        public string USER_NAME { get; set; }

        [Column("PASSWORD")]
        [StringLength(500)]
        [Description("Mật khẩu")]
        public string PASSWORD { get; set; }

        [Column("FULLNAME")]
        [StringLength(500)]
        [Description("Họ tên")]
        public string FULLNAME { get; set; }

        [Column("EMAIL")]
        [StringLength(500)]
        [Description("Email")]
        public string EMAIL { get; set; }

        [Column("PHONE")]
        [StringLength(20)]
        [Description("SĐT")]
        public string PHONE { get; set; }            

        [Column("MA_DV_TKKHOBAC")]
        [StringLength(500)]
        [Description("Mã đơn vị")]
        public string MA_DV_TKKHOBAC { get; set; }

        [Column("CHUC_VU")]
        [StringLength(500)]
        [Description("Chức vụ")]
        public string CHUC_VU { get; set; }

        [Column("MA_PHONGBAN")]
        [StringLength(50)]
        [Description("Phòng ban")]
        public string MA_PHONGBAN { get; set; }

        [Column("MA_DVQHNS")]
        [StringLength(50)]
        [Description("Đơn vị quan hệ ngân sách")]
        public string MA_DVQHNS { get; set; }

        [Column("MA_DVQHNS_CHA")]
        [StringLength(50)]
        [Description("Đơn vị quan hệ ngân sách cha")]
        public string MA_DVQHNS_CHA { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

    }
}
