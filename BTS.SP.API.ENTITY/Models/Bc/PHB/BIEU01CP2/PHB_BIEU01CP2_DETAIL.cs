using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU01CP2
{
    [Table("PHB_BIEU01CP2_DETAIL")]
    public class PHB_BIEU01CP2_DETAIL : DataInfoEntity
    {
        [Column("PHB_BIEU01CP2_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU01CP2")]
        [StringLength(50)]
        public string PHB_BIEU01CP2_REFID { get; set; }

        [Description("NOI_DUNG_CHI")]
        [StringLength(255)]
        [Required]
        public string NOI_DUNG_CHI { get; set; }

        [Description("Mã loại")]
        [StringLength(3)]
        public string MA_LOAI { get; set; }

        [Description("Mã khoản")]
        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [Description("Mã mục")]
        [StringLength(4)]
        public string MA_MUC { get; set; }

        [Description("Mã tiểu mục")]
        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [Description("Tổng số : Số báo cáo")]
        public double TS_SOBAOCAO { get; set; }

        [Description("Tổng số: Số xét duyệt/TD")]
        public double TS_SOXDTD { get; set; }

        [Description("NGân sách trong nước : Số báo cáo")]
        public double NSTN_SOBAOCAO { get; set; }

        [Description("NGân sách trong nước : Số xét duyệt/TD")]
        public double NSTN_SOXDTD { get; set; }

        [Description("Viện trợ : Số báo cáo")]
        public double VT_SOBAOCAO { get; set; }

        [Description("Viện trợ: Số xét duyệt/TD")]
        public double VT_SOXDTD { get; set; }

        [Description("Vay nợ nhà nước : Số báo cáo")]
        public double VNNN_SOBAOCAO { get; set; }

        [Description("Vay nợ nhà nước : Số xét duyệt/TD")]
        public double VNNN_SOXDTD { get; set; }

        [Description("Phiếu được khấu trừ lại : Số báo cáo")]
        public double PDKTL_SOBAOCAO { get; set; }

        [Description("Phiếu được khấu trừ lại : Số xét duyệt/TD")]
        public double PDKTL_SOXDTD { get; set; }

        [Description("Nguồn hoạt động khác được để lại : Số báo cáo")]
        public double NHDKDL_SOBAOCAO { get; set; }

        [Description("Phiếu được khấu trừ lại : Số xét duyệt/TD")]
        public double NHDKDL_SOXDTD { get; set; }

        [Description("Loại nội dung chi")]
        public int LOAI { get; set; }

    }
}
