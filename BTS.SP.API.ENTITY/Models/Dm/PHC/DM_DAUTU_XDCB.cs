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
    [Table("DM_DAUTU_XDCB")]
    public class DM_DAUTU_XDCB : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        public string TEN { get; set; }

        [Column("NHOM_CHA")]
        [StringLength(1)]
        public string NHOM_CHA { get; set; }

        [Column("MA_CHA")]
        [StringLength(250)]
        public string MA_CHA { get; set; }    
 
        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("CHU_DAU_TU")]
        [StringLength(250)]
        public string CHU_DAU_TU { get; set; }

        [Column("LOAI_DA")]
        [StringLength(250)]
        public string LOAI_DA { get; set; }

        [Column("NHOM_DA")]
        [StringLength(250)]
        public string NHOM_DA { get; set; }

        [Column("TONG_MUC_DAU_TU")]
        public Nullable<decimal> TONG_MUC_DAU_TU { get; set; }

        [Column("TU_NGAY_HIEU_LUC")]      
        public Nullable<DateTime> TU_NGAY_HIEU_LUC { get; set; }

        [Column("DEN_NGAY_HIEU_LUC")]
        public Nullable<DateTime> DEN_NGAY_HIEU_LUC { get; set; }

        [Column("DIA_DIEM_MO_TK")]
        [StringLength(250)]
        public string DIA_DIEM_MO_TK { get; set; }

        [Column("KIEU_DA")]
        [StringLength(3)]
        [Description(" (1: DVSDNS; 2-XDCB; 3:...)")]
        public string KIEU_DA { get; set; }

        [Column("MA_HTDA")]
        [StringLength(3)]
        [Description("Mã hạ tầng dự án")]
        public string MA_HTDA { get; set; }

        [Column("TEN_HTDA")]
        [StringLength(255)]
        [Description("Tên hạ tầng dự án")]
        public string TEN_HTDA { get; set; }

        [Column("MA_HTQL")]
        [StringLength(3)]
        [Description("Mã hạ tầng quản lý")]
        public string MA_HTQL { get; set; }

        [Column("TEN_HTQL")]
        [StringLength(255)]
        [Description("Tên hạ tầng quản lý")]
        public string TEN_HTQL{ get; set; }

    }
}