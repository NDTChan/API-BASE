using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.BIEU05
{
    public class BIEU05Vm
    {
        public class ParameterTraCuu
        {
            public DateTime P_TUNGAY_HL { get; set; }
            public DateTime P_DENNGAY_HL { get; set; }
            public DateTime P_TUNGAY_KS { get; set; }
            public DateTime P_DENNGAY_KS { get; set; }
            
        }
        public class Paged
        {
            public int currentPage { get; set; }
            public int fromItem { get; set; }
            public int itemsPerPage { get; set; }

            public int maxSize { get; set; }

            public int pageSize { get; set; }

            public bool takeAll { get; set; }

            public int toItem { get; set; }

            public int totalItems { get; set; }

            public decimal totalPage { get; set; }

        }
        public class InputPara
        {
            public ParameterTraCuu para { get; set; }
            public Paged paged { get; set; }

        }
        public class OutputData<T>
        {
            public OutputData()
            {
                lstdata = new List<T>();
            }

            public List<T> lstdata { get; set; }
            public Paged paged { get; set; }

        }
    }
}
