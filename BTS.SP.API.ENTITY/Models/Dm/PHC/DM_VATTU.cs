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
    [Table("DM_VATTU")]
    public class DM_VATTU: DataInfoEntity
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

        [Column("LOAIVATTU")]
        [StringLength(50)]
        [Description("Loại vật tư")]
        [ExportExcel("Loại vật tư")]
        public string LOAIVATTU { get; set; }

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

        [Column("MA_KHO")]
        [StringLength(20)]
        [Description("Mã kho")]
        public string MA_KHO { get; set; }
    }
}
