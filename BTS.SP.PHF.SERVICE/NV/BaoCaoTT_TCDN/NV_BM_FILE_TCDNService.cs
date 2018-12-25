using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCDN
{
    public interface INV_BM_FILE_TCDNService : IBaseService<PHF_BM_FILE_TCDN>
    {
    }
    public class NV_BM_FILE_TCDNService : BaseService<PHF_BM_FILE_TCDN>, INV_BM_FILE_TCDNService
    {
        private readonly IRepositoryAsync<PHF_BM_FILE_TCDN> _repository;
        public NV_BM_FILE_TCDNService(IRepositoryAsync<PHF_BM_FILE_TCDN> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
