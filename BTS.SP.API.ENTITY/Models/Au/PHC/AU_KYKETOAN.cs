using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Au.PHC
{
    [Table("AU_KYKETOAN")]
    public class AU_KYKETOAN : DataInfoEntityPHC
    {
        [Column("KY")]
        [Description("Kỳ là 12 tháng")]
        public int Period { get; set; }

        [Column("NAME")]
        [StringLength(500)]
        public string Name { get; set; }

        [Column("TUNGAY")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }

        [Column("DENNGAY")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }

        [Column("NAM")]
        public int Year { get; set; }

        [Column("TRANGTHAI")]
        [Description("Trạng thái sử dụng (1: Đang sử dụng; 0: Không sử dụng) ")]
        public int TrangThai { get; set; }

        public string GetTableName()
        {
            return string.Format("KHOASO_{0}_KY_{1}", this.Year, this.Period);
        }
    }
}
