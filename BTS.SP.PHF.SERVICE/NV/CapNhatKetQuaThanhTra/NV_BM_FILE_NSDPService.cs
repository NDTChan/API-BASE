using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.CapNhatKetQuaThanhTra
{
    public interface INV_BM_FILE_NSDPService : IBaseService<PHF_BM_FILE_NSDP>
    {
    }
    public class NV_BM_FILE_NSDPService : BaseService<PHF_BM_FILE_NSDP>, INV_BM_FILE_NSDPService
    {
        private readonly IRepositoryAsync<PHF_BM_FILE_NSDP> _repository;
        public NV_BM_FILE_NSDPService(IRepositoryAsync<PHF_BM_FILE_NSDP> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
