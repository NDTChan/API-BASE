using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungQuyen
{
    public class AuNguoiDungQuyenConfigModel
    {
        public string USERNAME { get; set; }
        public List<AuNguoiDungQuyenViewModel> LstAdd { get; set; }
        public List<AuNguoiDungQuyenViewModel> LstEdit { get; set; }
        public List<AuNguoiDungQuyenViewModel> LstDelete { get; set; }
    }
}
