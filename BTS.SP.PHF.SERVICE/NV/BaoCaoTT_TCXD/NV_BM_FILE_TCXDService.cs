using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCXD
{
    public interface INV_BM_FILE_TCXDService : IBaseService<PHF_BM_FILE_TCXD>
    {
    }
    public class NV_BM_FILE_TCXDService : BaseService<PHF_BM_FILE_TCXD>, INV_BM_FILE_TCXDService
    {
        private readonly IRepositoryAsync<PHF_BM_FILE_TCXD> _repository;
        public NV_BM_FILE_TCXDService(IRepositoryAsync<PHF_BM_FILE_TCXD> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
