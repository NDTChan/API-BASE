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
    [Table("DM_LOAI_TSCD")]
    public class DM_LOAI_TSCD : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        [Description("Mã vật tư")]
        [ExportExcel("Mã loại TSCĐ")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        [Description("Tên vật tư")]
        [ExportExcel("Tên loại TSCĐ")]
        public string TEN { get; set; }

        [Column("TEN_RUTGON")]
        [StringLength(250)]
        [Description("Tên rút gọn")]
        [ExportExcel("Tên rút gọn")]
        public string TEN_RUTGON { get; set; }

        [Column("DONVI_TINH")]
        [StringLength(20)]
        [Description("Đơn vị tính")]
        [ExportExcel("Đơn vị tính")]
        public string DONVI_TINH { get; set; }

        [Column("TYLE_HAOMON")]
        [Description("Tỷ lệ hao mòn")]
        [ExportExcel("Tỷ lệ hao mòn")]
        public Nullable<decimal> TYLE_HAOMON { get; set; }        

        [Column("SONAM_SD")]
        [Description("Số năm sử dụng")]
        [ExportExcel("Số năm sử dụng")]
        public Nullable<int> SONAM_SD { get; set; }
    }
}
