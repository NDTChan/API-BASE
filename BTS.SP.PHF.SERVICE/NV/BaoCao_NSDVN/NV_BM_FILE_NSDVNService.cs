using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.BaoCao_NSDVN
{
    public interface INV_BM_FILE_NSDVNService : IBaseService<PHF_BM_FILE_NSDVN>
    {
    }
    public class NV_BM_FILE_NSDVNService : BaseService<PHF_BM_FILE_NSDVN>, INV_BM_FILE_NSDVNService
    {
        private readonly IRepositoryAsync<PHF_BM_FILE_NSDVN> _repository;

        public NV_BM_FILE_NSDVNService(IRepositoryAsync<PHF_BM_FILE_NSDVN> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
