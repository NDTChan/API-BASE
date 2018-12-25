using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_PHC_CONGTHUC_CHITIEUTHU_CHI")]
    public class DM_PHC_CONGTHUC_CHITIEUTHU_CHI : DataInfoEntity
    {
        [Column("REFID")]
        [StringLength(50)]
        [Description("GUID")]
        public string REFID { get; set; }

        [Column("MACHITIEU")]
        [StringLength(20)]
        [Description("Mã chỉ tiêu")]
        public string MACHITIEU { get; set; }

        [Column("LOAICHITIEU")]
        [Description("Loại chỉ tiêu")]
        public Nullable<int> LOAICHITIEU { get; set; }

        [Column("MACONGTHUC")]
        [StringLength(200)]
        [Description("Mã công thức")]
        public string MACONGTHUC { get; set; }


        [Column("MACHUONG")]
        [Description("Mã Chương")]
        public string MACHUONG { get; set; }

        [Column("MALOAI")]
        [Description("Mã loại")]
        public string MALOAI { get; set; }

        [Column("MAKHOAN")]
        [Description("Mã khoản")]
        public string MAKHOAN { get; set; }

        [Column("MAMUC")]
        [Description("Mã Mục")]
        public string MAMUC { get; set; }

        [Column("MATIEUMUC")]
        [Description("Mã tiểu mục")]
        public string MATIEUMUC { get; set; }

        [Column("CAP")]
        [StringLength(1000)]
        [Description("Cấp")]
        public string CAP { get; set; }

        [Column("DAU")]
        [StringLength(10)]
        [Description("Dấu")]
        public string DAU { get; set; }

        [Column("MADVSDNS")]
        [StringLength(1000)]
        [Description("Mã đơn vị sử dụng ngân sách")]
        public string MADVSDNS { get; set; }

        [Column("MACTTM")]
        [StringLength(1000)]
        [Description("Mã chương trình tiểu mục")]
        public string MACTTM { get; set; }

        [Column("MAQHNS")]
        [StringLength(1000)]
        [Description("Mã đơn quan hệ ngân sách")]
        public string MAQHNS { get; set; }

        [Column("MANSH")]
        [StringLength(1000)]
        [Description("Mã Ngân sách hưởng")]
        public string MANSH { get; set; }

        [Column("MANGUONVON")]
        [StringLength(1000)]
        [Description("Mã Nguồn vốn")]
        public string MANGUONVON { get; set; }

        [Column("MADB")]
        [StringLength(1000)]
        [Description("Mã địa bàn")]
        public string MADB { get; set; }

        [Column("MANVC")]
        [StringLength(1000)]
        [Description("Mã nhiệm vụ chi")]
        public string MANVC { get; set; }

        [Column("MANHOM")]
        [StringLength(1000)]
        [Description("Mã nhóm")]
        public string MANHOM { get; set; }

        [Column("MATIEUNHOM")]
        [StringLength(1000)]
        [Description("Mã tiểu nhóm")]
        public string MATIEUNHOM { get; set; }
    }
}
