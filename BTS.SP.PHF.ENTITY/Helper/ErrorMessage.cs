using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Helper
{
    public static class ErrorMessage
    {
        public static string ERROR_SYSTEM = "Lỗi hệ thống.";
        public static string EMPTY_DATA = "Không có dữ liệu.";
        public static string ERROR_DATA = "Lỗi định dạng dữ liệu.";
        public static string ERROR_UPDATE_DATA = "Lỗi cập nhật dữ liệu.";
        public static string EXITS_REPORT = "Đã có báo cáo kỳ này.";
        public static string NOT_FOUND = "Không tìm thấy dữ liệu.";
    }

    public static class SuccessMessage
    {
        public static string SUCCESS_UPDATE_DATA = "Cập nhật dữ liệu thành công.";
    }
}
