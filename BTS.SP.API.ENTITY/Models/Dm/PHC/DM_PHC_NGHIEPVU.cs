using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using BTS.SP.API.ENTITY.Helper;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_PHC_NGHIEPVU")]
    public class DM_PHC_NGHIEPVU : DataInfoEntity
    {
        [Column("NHOMCHA")]
        [StringLength(50)]
        [Description("Nhóm cha")]
        [ExportExcel("Nhóm cha")]
        public string NHOMCHA { get; set; }

        [Column("MA")]
        [StringLength(50)]
        [Description("Mã nghiệp vụ")]
        [ExportExcel("Mã nghiệp vụ")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        [Description("Tên nghiệp vụ")]
        [ExportExcel("Tên nghiệp vụ")]
        public string TEN { get; set; }

        [Column("TAIKHOANNO")]
        [StringLength(20)]
        [Description("Tài khoản nợ")]
        [ExportExcel("Tài khoản nợ")]
        public string TAIKHOANNO { get; set; }

        [Column("TAIKHOANNOTB")]
        [StringLength(20)]
        [Description("Tài khoản nợ TB")]
        [ExportExcel("Tài khoản nợ TB")]
        public string TAIKHOANNOTB { get; set; }

        [Column("TAIKHOANCO")]
        [StringLength(20)]
        [Description("Tài khoản có")]
        [ExportExcel("Tài khoản có")]
        public string TAIKHOANCO { get; set; }

        [Column("TAIKHOANCONB")]
        [StringLength(20)]
        [Description("Tài khoản có NB")]
        [ExportExcel("Tài khoản có NB")]
        public string TAIKHOANCONB { get; set; }

        [Column("NGUONNO")]
        [StringLength(20)]
        [Description("Nguồn nợ")]
        [ExportExcel("Nguồn nợ")]
        public string NGUONNO{ get; set; }

        [Column("NGUONCO")]
        [StringLength(20)]
        [Description("Nguồn có")]
        [ExportExcel("Nguồn có")]
        public string NGUONCO { get; set; }

        [Column("CHUONGNO")]
        [StringLength(3)]
        [Description("Chương nợ")]
        [ExportExcel("Chương nợ")]
        public string CHUONGNO { get; set; }

        [Column("CHUONGCO")]
        [StringLength(3)]
        [Description("Chương có")]
        [ExportExcel("Chương có")]
        public string CHUONGCO { get; set; }

        [Column("LOAIKHOANNO")]
        [StringLength(6)]
        [Description("Loại khoản nợ")]
        [ExportExcel("Loại khoản nợ")]
        public string LOAIKHOANNO { get; set; }

        [Column("LOAIKHOANCO")]
        [StringLength(6)]
        [Description("Loại khoản có")]
        [ExportExcel("Loại khoản có")]
        public string LOAIKHOANCO { get; set; }

        [Column("MUCNO")]
        [StringLength(6)]
        [Description("Mục nợ")]
        [ExportExcel("Mục nợ")]
        public string MUCNO { get; set; }

        [Column("MUCCO")]
        [StringLength(6)]
        [Description("Mục có")]
        [ExportExcel("Mục có")]
        public string MUCCO { get; set; }
    }
}
