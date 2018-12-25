using BTS.SP.API.ENTITY.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Dm.PHC
{
    [Table("DM_TAIKHOAN")]
    public class DM_TAIKHOAN : DataInfoEntity
    {
        [Column("MA")]
        [StringLength(20)]
        [Description("Mã tài khoản")]
        [ExportExcel("Mã tài khoản")]
        public string MA { get; set; }

        [Column("TEN")]
        [StringLength(250)]
        [Description("Tên tài khoản")]
        [ExportExcel("Tên tài khoản")]
        public string TEN { get; set; }

        [Column("LOAITK")]
        [StringLength(1)]
        [Description("Loại tài khoản")]
        [ExportExcel("Loại tài khoản")]
        public string LOAITK { get; set; }

        [Column("LOAIHINH_TK")]
        [StringLength(1)]
        [Description("Loại hình tài khoản")]
        public string LOAIHINH_TK { get; set; }

        [Column("TEN_RUTGON")]
        [StringLength(250)]
        [Description("Tên rút gọn")]
        public string TEN_RUTGON { get; set; }

        [Column("BAC_TK")]
        [Description("Bậc tài khoản")]
        public Nullable<int> BAC_TK { get; set; }

        [Column("TK_CHA")]
        [StringLength(10)]
        [Description("Tài khoản cha")]
        public string TK_CHA { get; set; }

        [Column("TINHCHAT_TK")]
        [StringLength(1)]
        [Description("Tính chất tài khoản")]
        public string TINHCHAT_TK { get; set; }

        [Column("THEODOI_DT")]
        [Description("Theo dõi đối tượng nào")]
        public Nullable<int> THEODOI_DT { get; set; }

        [Column("THEODOI_HOATDONG")]
        [Description("Theo dõi hoạt động")]
        public Nullable<int> THEODOI_HOATDONG { get; set; }

        [Column("THEODOI_DKTT")]
        [Description("Theo dõi điều kiện thanh toán")]
        public Nullable<int> THEODOI_DKTT { get; set; }

        [Column("THEODOI_LOAIXDCB")]
        [Description("Theo dõi loại xây dựng cơ bản")]
        public Nullable<int> THEODOI_LOAIXDCB { get; set; }

        [Column("THEODOI_VATTU")]
        [Description("Theo dõi vật tư/ công cụ dụng cụ")]
        public Nullable<int> THEODOI_VATTU { get; set; }

        [Column("THEODOI_CHITIET")]
        [Description("Theo dõi chi tiết")]
        public Nullable<int> THEODOI_CHITIET { get; set; }

        [Column("THEODOI_NGOAITE")]
        [Description("Theo dõi ngoại tệ")]
        public Nullable<int> THEODOI_NGOAITE { get; set; }

        [Column("THEODOI_SOLUONG")]
        [Description("Theo dõi số lượng")]
        public Nullable<int> THEODOI_SOLUONG { get; set; }


        [Column("TINHTON")]
        [Description("Tính tồn")]
        public Nullable<int> TINHTON { get; set; }

        [Column("TRONGBANG")]
        [Description("Trong bảng")]
        public Nullable<int> TRONGBANG { get; set; }

        [Column("LATAISANCODINH")]
        [Description("Là tài sản cố định")]
        public Nullable<int> LATAISANCODINH { get; set; }

        [Column("LATK_THUNS")]
        [Description("Là tài khoản thu ngân sách")]
        public Nullable<int> LATK_THUNS { get; set; }

        [Column("NGAY_HL")]
        public DateTime NGAY_HL { get; set; }

        [Column("NGAY_PS")]
        public Nullable<DateTime> NGAY_PS { get; set; }

        [Column("NGAY_SD")]
        public Nullable<DateTime> NGAY_SD { get; set; }

        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("THEODOI_MLNS_CHUONG")]
        [Description("Theo dõi mục lục ngân sách chương")]
        public Nullable<int> THEODOI_MLNS_CHUONG { get; set; }

        [Column("THEODOI_MLNS_LOAIKHOAN")]
        [Description("Theo dõi mục lục ngân sách loại khoản")]
        public Nullable<int> THEODOI_MLNS_LOAIKHOAN { get; set; }

        [Column("THEODOI_MLNS_MUC")]
        [Description("Theo dõi mục lục ngân sách mục")]
        public Nullable<int> THEODOI_MLNS_MUC { get; set; }

        [Column("THEODOI_MLNS_TIEUMUC")]
        [StringLength(20)]
        [Description("Theo dõi mục lục ngân sách tiểu mục")]
        public string THEODOI_MLNS_TIEUMUC { get; set; }

        [Column("THEODOI_NGUON")]
        [Description("Theo dõi nguồn")]
        public Nullable<int> THEODOI_NGUON { get; set; }

        [Column("NOP_THUE")]
        [Description("Nộp thuế")]
        public Nullable<int> NOP_THUE { get; set; }

        [Column("THEODOI_TKKB")]
        [Description("Theo TKKB")]
        public Nullable<int> THEODOI_TKKB { get; set; }

        [Column("TRANG_THAI")]
        [Description("Trạng thái sử dụng (A: Ðang sử dụng)")]
        [StringLength(1)]
        public string TRANG_THAI { get; set; }

        [Column("TAIKHOAN_NGUYENGIA")]
        [Description("TK nguyên giá")]
        public Nullable<decimal> TAIKHOAN_NGUYENGIA { get; set; }

        [Column("TAIKHOAN_HAOMON")]
        [Description("TK hao mòn")]
        public Nullable<decimal> TAIKHOAN_HAOMON { get; set; }

        [Column("TAIKHOAN_NGUON")]
        [Description("TK nguồn")]
        public Nullable<decimal> TAIKHOAN_NGUON { get; set; }
    }
}