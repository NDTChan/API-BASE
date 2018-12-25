using Repository.Pattern.Ef6;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTS.SP.PHF.ENTITY.Sys
{
    public class SYS_DVQHNS:Entity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(7)]
        [Description("Mã đơn vị quan hệ ngân sách ")]
        public string MA_DVQHNS { get; set; }

        [StringLength(255)]
        [Description("Tên đơn vị quan hệ ngân sách ")]
        public string TEN_DVQHNS { get; set; }

        [Description("Ngày hiệu lực ")]
        public DateTime? NGAY_HL { get; set; }

        [StringLength(7)]
        [Description(" Tham chiếu tới mã cha ")]
        public string MA_DVQHNS_CHA { get; set; }

        [StringLength(2)]
        [Description(" Kiểu: 1 = Mã DVSDNS; 2=Mã ĐTXDCB; 3=Mã tổ chức; 4=Mã tổng hợp; 5=Mã logic ")]
        public string TYPE_DVQHNS { get; set; }

        [StringLength(2)]
        [Description(" Mã loại đơn vị ")]
        public string MA_LOAIDV { get; set; }

        [Description("Ngày khởi tạo ")]
        public DateTime? NGAY_PS { get; set; }

        [Description("Ngày cập nhật cuối cùng ")]
        public DateTime? NGAY_SD { get; set; }

        [StringLength(1)]
        [Description("Cấp dự toán ")]
        public string MA_CAP { get; set; }

        [StringLength(3)]
        [Description("Mã chương ")]
        public string MA_CHUONG { get; set; }

        [StringLength(2)]
        [Description("Mã tỉnh ")]
        public string MA_TINH { get; set; }

        [StringLength(5)]
        [Description("Mã xã")]
        public string MA_XA { get; set; }

        [StringLength(3)]
        [Description("Mã huyện")]
        public string MA_HUYEN { get; set; }

        [StringLength(100)]
        [Description("Căn cứ là văn bản, quyết định làm cơ sở xấy dựng cập nhật danh mục")]
        public string CAN_CU { get; set; }


        [StringLength(1)]
        [Description("Trạng thái sử dụng (A: Đang sử dụng; I: Không sử dụng) ")]
        public string TRANG_THAI { get; set; }

        [StringLength(20)]
        [Description("Người tạo ")]
        public string USER_NAME { get; set; }
    }
}
