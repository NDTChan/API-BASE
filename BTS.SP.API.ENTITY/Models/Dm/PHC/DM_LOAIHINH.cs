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
    [Table("DM_LOAIHINH")]
    public class DM_LOAIHINH : DataInfoEntity
    {
        [Column("MALOAIHINH")]
        [StringLength(50)]
        [ExportExcel("Mã loại hình")]
        public string MALOAIHINH { get; set; }

        [Column("MALOAIHINH_CHA")]
        [StringLength(50)]
        [ExportExcel("Mã loại hình cha")]
        public string MALOAIHINH_CHA { get; set; }

        [Column("TENLOAIHINH")]
        [StringLength(500)]
        [ExportExcel("Tên loại hình")]
        public string TENLOAIHINH { get; set; }

        [Column("TENLOAIHINH_RUTGON")]
        [StringLength(250)]
        [ExportExcel("Tên rút gọn")]
        public string TENLOAIHINH_RUTGON { get; set; }

        [Column("CAPLOAIHINH")]
        [ExportExcel("Cấp")]
        public Nullable<int> CAPLOAIHINH { get; set; }

        [Column("LOAIHINH_CUOI")]
        public Nullable<int> LOAIHINH_CUOI { get; set; }

        [Column("LOAI_LOAIHINH")]
        public Nullable<int> LOAI_LOAIHINH { get; set; }

        [Column("NGAY_HL")]
        [Required]
        [ExportExcel("Ngày hiệu lực")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("USER_NAME")]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Required]
        public string TRANG_THAI { get; set; }

    }
}