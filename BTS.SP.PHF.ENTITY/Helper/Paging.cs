using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Helper
{
    public class Paging<T> where T:class 
    {
        public int totalItems { get; set; }
        public T data { get; set; }
    }
}
