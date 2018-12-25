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
    [Table("PHC_DT_CHI_MLNS_CHITIET")]
    public class PHC_DT_CHI_MLNS_CHITIET : DataInfoEntity
    {
        [Required]
        [Column("SOCHUNGTU")]
        [StringLength(20)]
        [Description("Số chứng từ")]
        public string SOCHUNGTU { get; set; }

        [Column("TAIKHOAN_NO")]
        [StringLength(50)]
        [Description("Tài khoản nợ")]
        public string TAIKHOAN_NO { get; set; }

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


        [Column("MACTMT")]
        [StringLength(6)]
        [Description("Mã chương trình mục tiêu")]
        public string MACTMT { get; set; }

        [Column("HUYENGIAO")]
        [Description("Tiền huyện giao")]
        public Nullable<decimal> HUYENGIAO { get; set; }

        [Column("QUY1")]
        [Description("QUY1")]
        public Nullable<decimal> QUY1 { get; set; }

        [Column("QUY2")]
        [Description("QUY2")]
        public Nullable<decimal> QUY2 { get; set; }

        [Column("QUY3")]
        [Description("QUY3")]
        public Nullable<decimal> QUY3 { get; set; }

        [Column("QUY4")]
        [Description("QUY4")]
        public Nullable<decimal> QUY4 { get; set; }

        [Column("THANG1")]
        [Description("THANG1")]
        public Nullable<decimal> THANG1 { get; set; }

        [Column("THANG2")]
        [Description("THANG2")]
        public Nullable<decimal> THANG2 { get; set; }

        [Column("THANG3")]
        [Description("THANG3")]
        public Nullable<decimal> THANG3 { get; set; }

        [Column("THANG4")]
        [Description("THANG4")]
        public Nullable<decimal> THANG4 { get; set; }

        [Column("THANG5")]
        [Description("THANG5")]
        public Nullable<decimal> THANG5 { get; set; }

        [Column("THANG6")]
        [Description("THANG6")]
        public Nullable<decimal> THANG6 { get; set; }

        [Column("THANG7")]
        [Description("THANG7")]
        public Nullable<decimal> THANG7 { get; set; }

        [Column("THANG8")]
        [Description("THANG8")]
        public Nullable<decimal> THANG8 { get; set; }

        [Column("THANG9")]
        [Description("THANG9")]
        public Nullable<decimal> THANG9 { get; set; }

        [Column("THANG10")]
        [Description("THANG10")]
        public Nullable<decimal> THANG10 { get; set; }

        [Column("THANG11")]
        [Description("THANG11")]
        public Nullable<decimal> THANG11 { get; set; }

        [Column("THANG12")]
        [Description("THANG12")]
        public Nullable<decimal> THANG12 { get; set; }
        
    }
}
