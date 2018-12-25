using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_06TT_TCXD")]
    public class PHF_BM_06TT_TCXD  : DataInfoEntityPHF
    {
        [Column("STT")]
        [Description("Số thứ tự")]
        public int STT { get; set; }

        [Column("STT_TIEUDE")]
        [Description("Số thứ tự tiêu đề")]
        [StringLength(5)]
        public string STT_TIEUDE { get; set; }

        [Column("STT_CHA")]
        [Description("Số thứ tự cha")]
        public int STT_CHA { get; set; }

        [Column("MA_FILE")]
        [StringLength(200)]
        [Description("Mã file Template")]
        public string MA_FILE { get; set; }

        [Column("MA_FILE_PK")]
        [StringLength(200)]
        [Description("Mã file pk Template")]
        public string MA_FILE_PK { get; set; }

        [Column("TEN_CONGVIEC")]
        [StringLength(1000)]
        [Description("Tên công việc")]
        public string TEN_CONGVIEC { get; set; }

        [Column("KL_DUTOAN")]
        [StringLength(1000)]
        [Description("Khối lượng dự toán")]
        public string KL_DUTOAN { get; set; }

        [Column("KL_TINHLAI")]
        [StringLength(1000)]
        [Description("Khối lượng tính lại")]
        public string KL_TINHLAI { get; set; }

        [Column("KL_CHENHLECH")]
        [StringLength(1000)]
        [Description("Khối lượng chênh lệch")]
        public string KL_CHENHLECH { get; set; }

        [Column("DG_DUTOAN")]
        [StringLength(1000)]
        [Description("Đơn giá dự toán")]
        public string DG_DUTOAN { get; set; }

        [Column("DG_TINHLAI")]
        [StringLength(1000)]
        [Description("Đơn giá tính lại")]
        public string DG_TINHLAI { get; set; }

        [Column("DG_CHENHLECH")]
        [StringLength(1000)]
        [Description("Đơn giá chênh lệch")]
        public string DG_CHENHLECH { get; set; }

        [Column("DM_DUTOAN")]
        [StringLength(1000)]
        [Description("Định mức dự toán")]
        public string DM_DUTOAN { get; set; }

        [Column("DM_TINHLAI")]
        [StringLength(1000)]
        [Description("Định mức tính lại")]
        public string DM_TINHLAI { get; set; }

        [Column("DM_CHENHLECH")]
        [StringLength(1000)]
        [Description("Định mức chênh lệch")]
        public string DM_CHENHLECH { get; set; }

        [Column("GIATRI_CHENHLECH")]
        [StringLength(1000)]
        [Description("Giá trị chênh lệch")]
        public string GIATRI_CHENHLECH { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
