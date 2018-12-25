using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTS.SP.API.ENTITY.Helper;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_NGUON_NSNN")]
    public class DM_NGUON_NSNN:DataInfoEntity
    {
        [Column("MA_NGUON_NSNN")]
        [StringLength(4)]
        [Description("Mã nguồn NSNN ")]
        [ExportExcel("Mã nguồn NSNN ")]
        public string MA_NGUON_NSNN { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực ")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TEN_NGUON_NSNN")]
        [StringLength(240)]
        [Description("Tên nguồn ngân sách nhà nước")]
        [ExportExcel("Tên nguồn ngân sách nhà nước")]
        public string TEN_NGUON_NSNN { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [Column("MA_NGUON_NSNN_CHA")]
        [StringLength(4)]
        [Description("Mà nguồn NSNN cha ")]
        [ExportExcel("Mã nguồn NSNN cha ")]
        public string MA_NGUON_NSNN_CHA { get; set; }

        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú ")]
        public string GHI_CHU { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo ")]
        public string USER_NAME { get; set; }

        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo ")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng ")]
        public Nullable<DateTime> NGAY_SD { get; set; }

    }
}
