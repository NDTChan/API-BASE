using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Helper
{
    public class PagingParam<T> where T:class 
    {
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public T searchModel { get; set; }
    }
}
