using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_DVSN
{
    public interface INV_BM_FILE_DVSNService : IBaseService<PHF_BM_FILE_DVSN>
    {
    }

    public class NV_BM_FILE_DVSNService : BaseService<PHF_BM_FILE_DVSN>, INV_BM_FILE_DVSNService
    {
        private readonly IRepositoryAsync<PHF_BM_FILE_DVSN> _repository;

        public NV_BM_FILE_DVSNService(IRepositoryAsync<PHF_BM_FILE_DVSN> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
