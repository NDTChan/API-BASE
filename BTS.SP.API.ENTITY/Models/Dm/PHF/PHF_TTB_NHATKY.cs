using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHF
{
    [Table("PHF_TTB_NHATKY")]
    public class PHF_TTB_NHATKY : DataInfoEntityPHF
    {
        [Column("SO_PHIEU")]
        [StringLength(50)]
        [Description("Số phiếu nhật ký")]
        public string SO_PHIEU { get; set; }

        [Column("NGAY_LUUTRU")]
        [Description("Ngày, tháng lưu trữ dữ liệu")]
        public DateTime? NGAY_LUUTRU { get; set; }

        [Column("MA_DOITUONG")]
        [Description("Đơn vị báo cáo")]
        [StringLength(50)]
        public string MA_DOITUONG { get; set; }

        [Column("NGUOI_BAOCAO")]
        [Description("Người báo cáo")]
        [StringLength(50)]
        public string NGUOI_BAOCAO { get; set; }

        [Column("MA_PHONGBAN")]
        [Description("Mã phòng ban")]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Column("MA_DOT")]
        [Description("Mã đợt thanh tra")]
        [StringLength(50)]
        public string MA_DOT { get; set; }

        [Column("NOIDUNG_BAOCAO")]
        [StringLength(1000)]
        [Description("Nội dung báo cáo")]
        public string NOIDDUNG_BAOCAO { get; set; }

        [Column("CONGVIEC_THUCHIEN")]
        [StringLength(1000)]
        [Description("Công việc đã thực hiện ")]
        public string CONGVIEC_THUCHIEN { get; set; }

        [Column("QD_SO")]
        [Description("Thanh tra số quyết định ")]
        [StringLength(50)]
        public string QD_SO { get; set; }

        [Column("TENTEP")]
        [StringLength(50)]
        [Description("Tên tệp")]
        public string TENTEP { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái")]
        public Nullable<int> TRANG_THAI { get; set; }

        [Column("NAM")]
        [Description("Năm")]
        public Nullable<int> NAM { get; set; }

        [Column("TU_NGAY")]
        [Description("Từ ngày TTr-Dựa vào đợt và năm TTr")]
        public DateTime? TU_NGAY { get; set; }

        [Column("DEN_NGAY")]
        [Description("Đến ngày TTr")]
        public DateTime? DEN_NGAY { get; set; }


    }
}
