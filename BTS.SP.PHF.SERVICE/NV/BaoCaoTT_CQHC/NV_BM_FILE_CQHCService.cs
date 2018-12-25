using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC
{
    public interface INV_BM_FILE_CQHCService : IBaseService<PHF_BM_FILE_CQHC>
    {
    }
    public class NV_BM_FILE_CQHCService : BaseService<PHF_BM_FILE_CQHC>, INV_BM_FILE_CQHCService
    {
        private readonly IRepositoryAsync<PHF_BM_FILE_CQHC> _repository;
        public NV_BM_FILE_CQHCService(IRepositoryAsync<PHF_BM_FILE_CQHC> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
