using BTS.SP.API.ENTITY.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_NGANHKT")]
    public class DM_NGANHKT: DataInfoEntity
    {
        [Column("MA_NGANHKT")]
        [StringLength(6)]
        [Description("Mã ngành kinh tế")]
        [ExportExcel("Mã ngành kinh tế")]
        public string MA_NGANHKT { get; set; }

        [Column("NGAY_HL")]
        [Description("Ngày hiệu lực")]
        [ExportExcel("Ngày hiệu lực")]
        public DateTime NGAY_HL{ get; set; }

        [Column("NGAY_HET_HL")]
        [Description("Ngày hết hiệu lực")]
        public Nullable<DateTime> NGAY_HET_HL { get; set; }

        [Column("TEN_NGANHKT")]
        [StringLength(240)]
        [Description("Tên ngành kinh tế")]
        [ExportExcel("Tên ngành kinh tế")]
        public string TEN_NGANHKT        { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("LOAI_NGANHKT")]
        [StringLength(1)]
        [Description("(1- Ngành kinh tế cấp 1, 2- Ngành kinh tế cấp 2)")]
        public string LOAI_NGANHKT    { get; set; }

        [Column("MA_LOAI")]
        [StringLength(6)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng)")]
        public string MA_LOAI        { get; set; }


        [Column("GHI_CHU")]
        [StringLength(500)]
        [Description("Ghi chú")]
        public string GHI_CHU        { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        [Description("Người tạo")]
        public string USER_NAME        { get; set; }

        [Column("NGAY_PS")]
        [Description("Ngày khởi tạo")]
        public Nullable<DateTime> NGAY_PS        { get; set; }
        [Column("NGAY_SD")]
        [Description("Ngày cập nhật cuối cùng")]
        public Nullable<DateTime> NGAY_SD        { get; set; }

    }
}
