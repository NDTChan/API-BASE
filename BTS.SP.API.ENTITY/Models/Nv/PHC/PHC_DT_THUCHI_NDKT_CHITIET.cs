using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_DT_THUCHI_NDKT_CHITIET")]
    public class PHC_DT_THUCHI_NDKT_CHITIET : DataInfoEntity
    {
        [Column("MADUTOAN")]
        [StringLength(20)]
        [Description("Mã dự toán")]
        public string MADUTOAN { get; set; }

        [Column("MACHITIEU")]
        [StringLength(20)]
        [Description("Mã chỉ tiêu")]
        public string MACHITIEU { get; set; }

        [Column("LOAICHITIEU")]
        [Description("Loại chỉ tiêu")]
        public Nullable<int> LOAICHITIEU { get; set; }

        [Column("NSNN_DAUNAM")]
        [Description("ngan sach nha nuoc dau nam")]
        public Nullable<decimal> NSNN_DAUNAM { get; set; }

        [Column("NSX_DAUNAM")]
        [Description("ngan sach xa dau nam")]
        public Nullable<decimal> NSX_DAUNAM { get; set; }

        [Column("NSNN_BOSUNG")]
        [Description("ngan sach nha nuoc bo sung")]
        public Nullable<decimal> NSNN_BOSUNG{ get; set; }

        [Column("NSX_BOSUNG")]
        [Description("ngan sach xa bo sung")]
        public Nullable<decimal> NSX_BOSUNG { get; set; }

        [Column("NSNN_DIEUCHINH")]
        [Description("ngan sach nha nuoc dieuchinh")]
        public Nullable<decimal> NSNN_DIEUCHINH{ get; set; }

        [Column("NSX_DIEUCHINH")]
        [Description("ngan sach xa dieu chinh")]
        public Nullable<decimal> NSX_DIEUCHINH { get; set; }

        [Column("NSNN_HUY")]
        [Description("ngan sach nha nuoc Huy")]
        public Nullable<decimal> NSNN_HUY{ get; set; }

        [Column("NSX_HUY")]
        [Description("ngan sach xa huy")]
        public Nullable<decimal> NSX_HUY { get; set; }

    }
}
