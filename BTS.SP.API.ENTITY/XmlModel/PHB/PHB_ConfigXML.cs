using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.XmlModel.PHB
{
    public class PHB_ConfigXML
    {
        public static string MA_BAO_CAO = "ReportID";
        public static string KY_BC = "ReportPeriod";
        public static string NAM_BC = "ReportYear";
        public static string MA_QHNS = "CompanyID";
        public static string TEN_QHNS = "CompanyName";
        public static string MA_CHUONG = "BudgetChapterID";
        public static string MA_CHI_TIEU = "ReportItemAlias";
        public static string TEN_CHI_TIEU = "ReportItemName";
        public static string STT_CHI_TIEU = "ReportIndex";
        public static string SO_TIEN = "Amount";
        public static string MA_HOAT_DONG = "ActivityID";

        public static List<string> Org_Fields = new List<string>(){ "ActivityID", "BudgetKindItemID", "ReportItemAlias", "ReportItemName", "ReportIndex", "Amount" };
        public static List<string> Rep_Fields = new List<string>(){ "HOATDONG_ID", "LOAI_KHOAN","MA_CHI_TIEU","TEN_CHI_TIEU","STT_CHI_TIEU","SO_TIEN" };
    }

    public class PHB_ReportHeader
    {
        public string MA_BAO_CAO { get; set; }
        public int KY_BC { get; set; }
        public int NAM_BC { get; set; }
        public string MA_QHNS { get; set; }
        public string TEN_QHNS { get; set; }
        public string MA_CHUONG { get; set; }
    }
}
