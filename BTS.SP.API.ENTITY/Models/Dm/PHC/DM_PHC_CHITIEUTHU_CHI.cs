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
    [Table("DM_PHC_CHITIEUTHUCHI")]
    public class DM_PHC_CHITIEUTHU_CHI : DataInfoEntity
    {
        [Column("REFID")]
        [StringLength(50)]
        [Description("GUID")]
        public string REFID { get; set; }

        [Column("MACHA")]
        [StringLength(20)]
        [Description("Mã cha")]
        public string MACHA { get; set; }

        [Column("MACHITIEU")]
        [StringLength(20)]
        [Description("Mã chỉ tiêu")]
        public string MACHITIEU { get; set; }

        [Column("TENCHITIEU")]
        [StringLength(250)]
        [Description("Tên chỉ tiêu")]
        public string TENCHITIEU { get; set; }

        [Column("CAP")]
        [Description("cấp")]
        public Nullable<int> CAP { get; set; }

        [Column("TYLE_XADUOCHUONG")]
        [Description("Tỷ lệ xã được hưởng")]
        public Nullable<decimal> TYLE_XADUOCHUONG{ get; set; }

        [Column("MATAIKHOAN")]
        [StringLength(1000)]
        [Description("Mã tài khoản")]
        public string MATAIKHOAN { get; set; }

        [Column("LOAICHITIEU")]
        [Description("Loại chỉ tiêu")]
        public Nullable<int> LOAICHITIEU { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Ðang sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("SAPXEP")]
        [StringLength(100)]
        public string SAPXEP { get; set; }

        [Column("PHAN_HE")]
        [StringLength(3)]
        public string PHAN_HE { get; set; }
        [Column("CT_DH")]
        [Description("Công thức quyết toán")]
        public string CT_DH { get; set; }

        [Column("CT_DH_W")]
        [Description("Công thức quyết toán where")]
        public string CT_DH_W { get; set; }

        [Column("CT_QT")]
        [Description("Công thức quyết toán")]
        public string CT_QT { get; set; }

        [Column("CT_QT_W")]
        [Description("Công thức quyết toán where")]
        public string CT_QT_W { get; set; }

        [Column("CT_DT")]
        [Description("Công thức dự toán")]
        public string CT_DT { get; set; }

        [Column("CT_DT_W")]
        [Description("Công thức dự toán where")]
        public string CT_DT_W { get; set; }

        [Column("TUNGAY_HL")]
        public DateTime? TUNGAY_HL { get; set; }

        [Column("DENNGAY_HL")]
        public DateTime? DENNGAY_HL { get; set; }

        [Column("CODELOCATION")]
        [StringLength(5)]
        [Description("Mã địa bàn hành chính, để phân quyền")]
        public string CODELOCATION { get; set; }

        [Column("MA_DBHC")]
        [StringLength(10)]
        [Description("Mã địa bàn hành chính, để phân biệt công thức của tỉnh")]
        public string MA_DBHC { get; set; }
    }
}
