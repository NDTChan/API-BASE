using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("PHA_QL_TT_VON_CHITIET")]
    public class PHA_QL_TT_VON_CHITIET : DataInfoEntity
    {
        [Column("PHA_QL_TT_VON_REFID")]
        [Required]
        [StringLength(50)]
        public string PHA_QL_TT_VON_REFID { get; set; }

        [Column("MA_DUAN")]
        [Required]
        [StringLength(50)]
        [Description("Mã dự án")]
        public string MA_DUAN { get; set; }

        [Column("MA_NGUONVON")]
        [Required]
        [StringLength(50)]
        [Description("Mã nguồn vốn")]
        public string MA_NGUONVON { get; set; }

        [Column("MA_NGANHKT")]
        [StringLength(50)]
        [Description("Mã ngành kinh tế/khoản")]
        public string MA_NGANHKT{ get; set; }

        [Column("KEHOACH_VON_KEODAI")]
        [Required]
        [Description("Kế hoạch vốn kéo dài")]
        public decimal KEHOACH_VON_KEODAI { get; set; }

        [Column("SOVON_KLHT")]
        [Required]
        [Description("Số vốn thanh toán KLHT")]
        public decimal SOVON_KLHT { get; set; }

        [Column("TONG_SO")]
        [Required]
        [Description("Tổng số = Số vốn thanh toán KLHT + Số vốn tạm ứng theo chế độ chưa thu hồi")]
        public decimal TONG_SO { get; set; }

        [Column("SOVON_TAMUNG")]
        [Required]
        [Description("Số vốn tạm ứng theo chế độ chưa thu hồi")]
        public decimal SOVON_TAMUNG { get; set; }

        [Column("KEHOACH_VON_NAMSAU")]
        [Required]
        [Description("Kế hoạch vốn kéo dài đến năm sau")]
        public decimal KEHOACH_VON_NAMSAU { get; set; }

        [Column("SOVON_CONLAI_CTTHB")]
        [Required]
        [Description("Số vốn còn lại chưa thanh toán hủy bỏ (Nếu có)= Kh vốn đc kéo dài -Tổng số thanh toán - KH vốn được phép kéo dài sang năm sau")]
        public decimal SOVON_CONLAI_CTTHB { get; set; }
    }
}
