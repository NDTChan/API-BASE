using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.B06H
{
    [Table("PHB_B06H_DETAIL")]
    public class PHB_B06H_DETAIL : DataInfoEntity
    {
        [Column("PHB_B06H_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_B06H")]
        [StringLength(50)]
        public string PHB_B06H_REFID { get; set; }

        [Column("PHAN")]
        [Required]
        [Description("Phần báo cáo")]
        public int PHAN { get; set; }

        [Column("MA_CHI_TIEU")]
        [Required]
        [Description("Mã chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string MA_CHI_TIEU { get; set; }

        [Column("MA_LOAI")]
        [Description("Mã loại")]
        [StringLength(15)]
        public string MA_LOAI { get; set; }

        [Column("MA_KHOAN")]
        [Description("Mã khoản")]
        [StringLength(15)]
        public string MA_KHOAN { get; set; }

        [Column("STT_CHI_TIEU")]
        [Description("STT chỉ tiêu báo cáo")]
        [StringLength(15)]
        public string STT_CHI_TIEU { get; set; }

        [Column("TEN_CHI_TIEU")]
        [Description("Tên chỉ tiêu báo cáo")]
        [StringLength(250)]
        public string TEN_CHI_TIEU { get; set; }

        [Column("MA_SO")]
        [Description("Mã số chỉ tiêu")]
        [StringLength(15)]
        public string MA_SO { get; set; }

        [Column("NOI_DUNG")]
        [Description("Phần I,VIII")]
        [StringLength(2000)]
        public string NOI_DUNG { get; set; }

        [Column("SODU_DAUNAM")]
        [Description("Số dư đầu năm phần II")]
        public decimal SODU_DAUNAM { get; set; }

        [Column("SODU_CUOINAM")]
        [Description("Số dư cuối năm phần II")]
        public decimal SODU_CUOINAM { get; set; }

        [Column("QUY_KHENTHUONG")]
        [Description("Quỹ khen thường phần III")]
        public decimal QUY_KHENTHUONG { get; set; }

        [Column("QUY_PHUCLOI")]
        [Description("Quỹ phúc lợi phần III")]
        public decimal QUY_PHUCLOI { get; set; }

        [Column("QUY_KHAC")]
        [Description("Quỹ khác phần III")]
        public decimal QUY_KHAC { get; set; }

        [Column("QUY_TONGSO")]
        [Description("Tổng số quỹ phần III")]
        public decimal QUY_TONGSO { get; set; }

        [Column("SO_PHAI_NOP_NAMTRUOC")]
        [Description("Số phải nộp năm trước chuyển sang phần IV")]
        public decimal SO_PHAI_NOP_NAMTRUOC { get; set; }

        [Column("SO_PHAI_NOP")]
        [Description("Số phải nộp phần IV")]
        public decimal SO_PHAI_NOP { get; set; }

        [Column("SO_DA_NOP")]
        [Description("Số đã nộp phần IV")]
        public decimal SO_DA_NOP { get; set; }

        [Column("SO_CON_PHAI_NOP")]
        [Description("Số còn phải nộp phần IV")]
        public decimal SO_CON_PHAI_NOP { get; set; }

        [Column("DUTOAN_NAMTRUOC")]
        [Description("Dự toán năm trước chuyển sang phần V")]
        public decimal DUTOAN_NAMTRUOC { get; set; }

        [Column("DUTOAN_GIAO_TRONGNAM")]
        [Description("Dự toán giao trong năm phần V")]
        public decimal DUTOAN_GIAO_TRONGNAM { get; set; }

        [Column("DUTOAN_RUT_KHOBAC")]
        [Description("Dự toán đã nhận rút từ kho bạc phần V")]
        public decimal DUTOAN_RUT_KHOBAC { get; set; }

        [Column("DUTOAN_LENHCHI")]
        [Description("Dự toán đã nhận từ lệnh chi phần V")]
        public decimal DUTOAN_LENHCHI { get; set; }

        [Column("DUTOAN_GHITHUGHICHI")]
        [Description("Dự toán đã nhận ghi thu ghi chi phần V")]
        public decimal DUTOAN_GHITHUGHICHI { get; set; }

        [Column("DUTOAN_NGUONKHAC")]
        [Description("Dự toán đã nhận từ nguồn khác phần V")]
        public decimal DUTOAN_NGUONKHAC { get; set; }

        [Column("DUTOAN_HUY")]
        [Description("Dự toán bị hủy phần V")]
        public decimal DUTOAN_HUY { get; set; }

        [Column("NGUONPHI_LEPHI")]
        [Description("Nguồn phí, lệ phí phần VI")]
        public decimal NGUONPHI_LEPHI { get; set; }

        [Column("PHI_TIEPNHAN")]
        [Description("Phí, lệ phí tiếp nhận phần VII")]
        public decimal PHI_TIEPNHAN { get; set; }

        [Column("SO_TIEN")]
        [Description("Số tiền, Amount from Misa")]
        public decimal SO_TIEN { get; set; }

        [Column("INDAM")]
        [Required]
        public int INDAM { get; set; }

        [Column("INNGHIENG")]
        [Required]
        public int INNGHIENG { get; set; }

        [Column("CONG_THUC")]
        [StringLength(250)]
        public string CONG_THUC { get; set; }

        [Column("INPUT")]
        public int INPUT { get; set; }

    }
}
