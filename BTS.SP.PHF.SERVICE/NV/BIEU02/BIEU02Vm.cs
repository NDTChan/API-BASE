using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY.Nv;

namespace BTS.SP.PHF.SERVICE.NV.BIEU02
{
    public class BIEU02Vm
    {
        public class ParameterTraCuu
        {
            public DateTime P_TUNGAY_HL { get; set; }
            public DateTime P_DENNGAY_HL { get; set; }
            public DateTime P_TUNGAY_KS { get; set; }
            public DateTime P_DENNGAY_KS { get; set; }
            public string P_MA_DBHC { get; set; }
        }
        public class InputPara
        {
            public ParameterTraCuu para { get; set; }

        }
        public class OutputData<T>
        {
            public OutputData()
            {
                lstdata = new List<T>();
            }

            public List<T> lstdata { get; set; }

        }

        public class ExportItems
        {
            public DateTime P_TUNGAY_HL { get; set; }
            public DateTime P_DENNGAY_HL { get; set; }
            public DateTime P_TUNGAY_KS { get; set; }
            public DateTime P_DENNGAY_KS { get; set; }
            public string P_MA_DBHC { get; set; }
            public List<PHF_BIEU02> b02Lst { get; set; } 
        }
    }
}
