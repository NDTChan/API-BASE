using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.XmlModel.PHB
{
    public class PHB_B03H
    {
        public string MA_TEMPLATE { get; set; }
        public string MA_CHUONG { get; set; }
        public string MA_QHNS { get; set; }
        public int NAM_BC { get; set; }
        public int KY_BC { get; set; }
        public int TRANG_THAI { get; set; }
    }

    public class PHB_B03H_DETAIL
    {
        public int PHB_B03H_ID { get; set; }
        public int HOATDONG_ID { get; set; }
        public string MA_CHI_TIEU { get; set; }
        public string TEN_CHI_TIEU { get; set; }
        public string STT_CHI_TIEU { get; set; }
        public decimal SO_TIEN { get; set; }
        public string CONG_THUC { get; set; }
    }
}
