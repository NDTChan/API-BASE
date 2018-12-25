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
    [Table("DM_TSCD")]
    public class DM_TSCD: DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        [Description("Mã vật tư")]
        [ExportExcel("Mã vật tư")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        [Description("Tên vật tư")]
        [ExportExcel("Tên vật tư")]
        public string TEN { get; set; }

        [Column("TEN_RUTGON")]
        [StringLength(250)]
        [Description("Tên rút gọn")]
        [ExportExcel("Tên rút gọn")]
        public string TEN_RUTGON { get; set; }

        [Column("NAM_BD_KHAUHAO")]
        [StringLength(250)]
        [Description("Năm khấu hao")]
        [ExportExcel("Năm khấu hao")]
        public string NAM_BD_KHAUHAO { get; set; }

        [Column("LOAI_TSCD")]
        [StringLength(250)]
        [Description("Loại TSCĐ")]
        [ExportExcel("Loại TSCĐ")]
        public string LOAI_TSCD { get; set; }

        [Column("DONVI_TINH")]
        [StringLength(20)]
        [Description("Đơn vị tính")]
        [ExportExcel("Đơn vị tính")]
        public string DONVI_TINH { get; set; }

        [Column("TYLE_HAOMON")]        
        [Description("Tỷ lệ hao mòn")]
        public Nullable<decimal> TYLE_HAOMON { get; set; }

        [Column("NAM_SANXUAT")]
        [Description("Năm sản xuất")]
        [ExportExcel("Năm sản xuất")]
        public DateTime NAM_SANXUAT { get; set; }

        [Column("NAM_SD")]
        [Description("Năm sử dụng")]
        [ExportExcel("Năm sử dụng")]
        public DateTime NAM_SD { get; set; }

        [Column("SONAM_SD")]
        [Description("Số năm sử dụng")]
        [ExportExcel("Số năm sử dụng")]
        public Nullable<int> SONAM_SD { get; set; }

        [Column("GIATRI_HAOMON")]
        [Description("Giá trị hao mòn năm")]
        [ExportExcel("Giá trị hao mòn năm")]
        public Nullable<decimal> GIATRI_HAOMON { get; set; }

        [Column("NGUYEN_GIA")]
        [Description("Nguyên giá")]
        public Nullable<decimal> NGUYEN_GIA { get; set; }

        [Column("TAIKHOAN_NGUYENGIA")]
        [Description("TK nguyên giá")]
        public Nullable<decimal> TAIKHOAN_NGUYENGIA { get; set; }

        [Column("TAIKHOAN_HAOMON")]
        [Description("TK hao mòn")]
        public Nullable<decimal> TAIKHOAN_HAOMON { get; set; }

        [Column("TAIKHOAN_NGUON")]
        [Description("TK nguồn")]
        public Nullable<decimal> TAIKHOAN_NGUON { get; set; }


    }
}
