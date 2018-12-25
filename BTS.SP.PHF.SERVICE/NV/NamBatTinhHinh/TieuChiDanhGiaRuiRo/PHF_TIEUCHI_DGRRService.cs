using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.NamBatTinhHinh.TieuChiDanhGiaRuiRo
{
    public interface IPHF_TIEUCHI_DGRRService : IBaseService<PHF_TIEUCHI_DGRR>
    {

    }
    public class PHF_TIEUCHI_DGRRService : BaseService<PHF_TIEUCHI_DGRR>, IPHF_TIEUCHI_DGRRService
    {
        public PHF_TIEUCHI_DGRRService(IRepositoryAsync<PHF_TIEUCHI_DGRR> repository) : base(repository)
        {
        }
    }
}
