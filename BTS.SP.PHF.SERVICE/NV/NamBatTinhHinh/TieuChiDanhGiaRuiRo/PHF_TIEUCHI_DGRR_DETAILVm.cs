using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.NamBatTinhHinh.TieuChiDanhGiaRuiRo
{
    public class PHF_TIEUCHI_DGRR_DETAILVm
    {
        public class ViewModel
        {
            public long Id { get; set; }
            public string REF_ID { get; set; }
            public string MA { get; set; }
            public string TEN { get; set; }
            public Nullable<DateTime> THOIGIANNOP { get; set; }
            public Nullable<int> SONGAYNOPCHAM { get; set; }
        }
        public class InsertModel
        {
            public string MA { get; set; }
            public string TEN { get; set; }
            public Nullable<DateTime> THOIGIANNOP { get; set; }
            public Nullable<int> SONGAYNOPCHAM { get; set; }
        }
    }
}
