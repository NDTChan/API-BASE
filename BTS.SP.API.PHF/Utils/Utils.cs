using System;
using System.Collections.Generic;
using System.Linq;

namespace BTS.SP.API.PHF.Utils
{
    public class Utils
    {
        public static DateTime convertDate(Nullable<DateTime> date)
        {

            if (date != null)
            {
                DateTime tmp = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
                return tmp;
            }
            return DateTime.Now;
        }

        public static string dateToShortString(Nullable<DateTime> date)
        {
            if (date != null)
            {
                return date.Value.ToString("dd/MM/yyyy");
            }
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        public static string dateToYear(Nullable<DateTime> date)
        {
            if (date != null)
            {
                return date.Value.ToString("yyyy");
            }
            return DateTime.Now.ToString("yyyy");
        }
        public static string dateToDay(Nullable<DateTime> date)
        {
            if (date != null)
            {
                return date.Value.ToString("dd");
            }
            return DateTime.Now.ToString("dd");
        }

        public static string dateToMonth(Nullable<DateTime> date)
        {
            if (date != null)
            {
                return date.Value.ToString("MM");
            }
            return DateTime.Now.ToString("MM");
        }

        public static string Convert_DonViTien(long? tien)
        {
            if (tien != null)
            {
                switch (tien)
                {
                    case 1:
                        return "Đồng";
                    case 1000:
                        return "Nghìn đồng";
                    case 1000000:
                        return "Triệu đồng";
                }
            }
            return "NULL";
        }

        public static long Convert_ToNumber(string number)
        {
            if (number != null)
            {
                Int64 so = 1;
                Int64.TryParse(number, out so);
                return so;
            }
            return 1;
        }

        public static string Convert_LoaiDuToan(string str)
        {
            if (str.Equals("06"))
                return "(1) Dự toán năm trước chuyển sang";
            if (str.Equals("01"))
                return "(2) Dự toán kinh phí giao đầu năm";
            if (str.Equals("02"))
                return "(3) Dự toán kinh phí bổ sung trong năm";
            if (str.Equals("03"))
                return "(4) Dự toán kinh phí điều chỉnh giảm trong năm";
            return str;
        }
    }
}