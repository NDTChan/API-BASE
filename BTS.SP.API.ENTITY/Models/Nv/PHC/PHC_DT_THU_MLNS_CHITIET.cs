using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_DT_THU_MLNS_CHITIET")]
    public class PHC_DT_THU_MLNS_CHITIET : DataInfoEntity
    {
        [Column("MADUTOAN")]
        [StringLength(20)]
        [Description("Mã dự toán")]
        public string MADUTOAN { get; set; }

        [Column("SO_QD")]
        [Description("Số quyết định")]
        public Nullable<int> SO_QD { get; set; }

        [Column("MANGUON")]
        [StringLength(20)]
        [Description("Mã nguồn")]
        public string MANGUON { get; set; }

        [Column("MACHUONG")]
        [StringLength(3)]
        [Description("Mã Chương")]
        public string MACHUONG { get; set; }

        [Column("MAKHOAN")]
        [StringLength(6)]
        [Description("Mã khoản")]
        public string MAKHOAN { get; set; }

        [Column("MATIEUMUC")]
        [StringLength(6)]
        [Description("Mã tiểu mục")]
        public string MATIEUMUC { get; set; }

        [Column("NSNN")]
        [Description("ngan sach nha nuoc")]
        public Nullable<decimal> NSNN { get; set; }

        [Column("NSX")]
        [Description("ngan sach xa")]
        public Nullable<decimal> NSX { get; set; }

    }
}
