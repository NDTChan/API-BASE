using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyenChucNang
{
    public class AuNhomQuyenChucNangConfigModel
    {
        public string MANHOMQUYEN { get; set; }
        public List<AuNhomQuyenChucNangViewModel> LstAdd { get; set; }
        public List<AuNhomQuyenChucNangViewModel> LstEdit { get; set; }
        public List<AuNhomQuyenChucNangViewModel> LstDelete { get; set; }
    }
}
