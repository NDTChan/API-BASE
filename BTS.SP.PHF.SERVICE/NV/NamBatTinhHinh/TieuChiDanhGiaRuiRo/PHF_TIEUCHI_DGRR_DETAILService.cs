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
    public interface IPHF_TIEUCHI_DGRR_DETAILService : IBaseService<PHF_TIEUCHI_DGRR_DETAIL>
    {

    }
    public class PHF_TIEUCHI_DGRR_DETAILService : BaseService<PHF_TIEUCHI_DGRR_DETAIL>, IPHF_TIEUCHI_DGRR_DETAILService
    {
        public PHF_TIEUCHI_DGRR_DETAILService(IRepositoryAsync<PHF_TIEUCHI_DGRR_DETAIL> repository) : base(repository)
        {
        }
    }
}
