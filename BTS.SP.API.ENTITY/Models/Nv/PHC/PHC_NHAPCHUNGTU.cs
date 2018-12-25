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
    [Table("PHC_NHAPCHUNGTU")]
    public class PHC_NHAPCHUNGTU : DataInfoEntityPHC
    {
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Column("SO_CHUNGTU")]
        [StringLength(50)]
        [Description("Số chứng từ")]
        public string SO_CHUNGTU { get; set; }

        [Column("SO_LENHCHI")]
        [StringLength(250)]
        [Description("Số lệnh chi")]
        public string SO_LENHCHI { get; set; }

        [Column("SO_CHUNGTUGOC")]
        [StringLength(250)]
        [Description("Số chứng từ gốc")]
        public string SO_CHUNGTUGOC { get; set; }

        [Column("NGAY_CT")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CT { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạch toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("TEN")]
        [StringLength(500)]
        [Description("Tên")]
        public string TEN { get; set; }

        [Column("DIA_CHI")]
        [StringLength(500)]
        [Description("Địa chỉ")]
        public string DIA_CHI { get; set; }

        [Column("CTMT")]
        [StringLength(250)]
        [Description("Chương trình mục tiêu")]
        public string CTMT { get; set; }

        [Column("TKKB")]
        [StringLength(250)]
        [Description("Tài khoản kho bạc")]
        public string TKKB { get; set; }

        [Column("CHI_TIET")]
        [StringLength(250)]
        [Description("Chi tiết")]
        public string CHI_TIET { get; set; }

        [Column("MA_NV")]
        [StringLength(50)]
        [Description("Mã nghiệp vụ")]
        public string MA_NV { get; set; }

        [Column("CO_HOADON")]
        [StringLength(1)]
        [Description("Có hóa đơn")]
        public string CO_HOADON { get; set; }

        [Column("SO_HOADON")]
        [StringLength(100)]
        [Description("Số hóa đơn")]
        public string SO_HOADON { get; set; }

        [Column("NGAY_HOADON")]
        [Description("Ngày hóa đơn")]
        public Nullable<DateTime> NGAY_HOADON { get; set; }

        [Column("NOI_DUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOI_DUNG { get; set; }
        

        [Column("TK_NO")]
        [StringLength(50)]
        [Description("TK nợ")]
        public string TK_NO { get; set; }

        [Column("TK_NO_NB")]
        [StringLength(50)]
        [Description("TK nợ NB")]
        public string TK_NO_NB { get; set; }

        [Column("NGUON_NO")]
        [StringLength(50)]
        [Description("Nguồn nợ")]
        public string NGUON_NO { get; set; }

        [Column("CHUONG_NO")]
        [StringLength(50)]
        [Description("Chương nợ")]
        public string CHUONG_NO { get; set; }

        [Column("KHOAN_NO")]
        [StringLength(50)]
        [Description("Khoản nợ")]
        public string KHOAN_NO { get; set; }

        [Column("MUC_NO")]
        [StringLength(50)]
        [Description("Mục nợ")]
        public string MUC_NO { get; set; }

        [Column("TIET_NO")]
        [StringLength(50)]
        [Description("Tiết nợ")]
        public string TIET_NO { get; set; }

        [Column("QUY_NO")]
        [StringLength(50)]
        [Description("Quỹ nợ")]
        public string QUY_NO { get; set; }

        [Column("DOI_TUONG_NO")]
        [StringLength(50)]
        [Description("Đối tượng nợ")]
        public string DOI_TUONG_NO { get; set; }

        [Column("LOAI_HINH_NO")]
        [StringLength(50)]
        [Description("Loại hình nợ")]
        public string LOAI_HINH_NO { get; set; }

        [Column("MA_CHITIET_NO")]
        [StringLength(50)]
        [Description("Mã chi tiết nợ")]
        public string MA_CHITIET_NO { get; set; }

        [Column("TK_CO")]
        [StringLength(50)]
        [Description("TK có")]
        public string TK_CO { get; set; }

        [Column("NGUON_CO")]
        [StringLength(50)]
        [Description("Nguồn có")]
        public string NGUON_CO { get; set; }

        [Column("CHUONG_CO")]
        [StringLength(50)]
        [Description("Chương có")]
        public string CHUONG_CO { get; set; }

        [Column("KHOAN_CO")]
        [StringLength(50)]
        [Description("Khoản có")]
        public string KHOAN_CO { get; set; }

        [Column("MUC_CO")]
        [StringLength(50)]
        [Description("Mục có")]
        public string MUC_CO { get; set; }    

        [Column("TIET_CO")]
        [StringLength(50)]
        [Description("Tiết có")]
        public string TIET_CO { get; set; }

        [Column("QUY_CO")]
        [StringLength(50)]
        [Description("Quỹ có")]
        public string QUY_CO { get; set; }

        [Column("DOI_TUONG_CO")]
        [StringLength(50)]
        [Description("Đối tượng có")]
        public string DOI_TUONG_CO { get; set; }

        [Column("LOAI_HINH_CO")]
        [StringLength(50)]
        [Description("Loại hình có")]
        public string LOAI_HINH_CO { get; set; }

        [Column("MA_CHITIET_CO")]
        [StringLength(50)]
        [Description("Mã chi tiểt có")]
        public string MA_CHITIET_CO { get; set; }

        [Column("DVT")]
        [StringLength(50)]
        [Description("Đơn vị tính")]
        public string DVT { get; set; }

        [Column("SO_LUONG")]        
        [Description("Số lượng")]
        public Nullable<decimal> SO_LUONG { get; set; }

        [Column("DON_GIA")]        
        [Description("Đơn giá")]
        public Nullable<decimal> DON_GIA { get; set; }

        [Column("NSNN")]
        [StringLength(250)]
        [Description("NSNN")]
        public string NSNN { get; set; }

        [Column("DONVI_HUONG")]
        [StringLength(250)]
        [Description("Đơn vị hưởng")]
        public string DONVI_HUONG { get; set; }

        [Column("NOP_THUE")]
        [StringLength(250)]
        [Description("Nộp thuế")]
        public string NOP_THUE { get; set; }

        [Column("SO_TIEN")]       
        [Description("Số tiền")]
        public Nullable<decimal> SO_TIEN { get; set; }

        [Column("SOTIEN_CHUNGTU")]
        [Description("Số tiền chứng từ")]
        public Nullable<decimal> SOTIEN_CHUNGTU { get; set; }

        [Column("TONG_NSNN")]
        [Description("Tổng NSNN")]
        public Nullable<decimal> TONG_NSNN { get; set; }

        [Column("TONG_PHATSINH")]
        [Description("Tổng phát sinh")]
        public Nullable<decimal> TONG_PHATSINH { get; set; }

        [Column("QUY_TM")]
        [StringLength(250)]
        [Description("Quỹ TM")]
        public string QUY_TM { get; set; }

        [Column("TRANG_THAI")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

    }
}
