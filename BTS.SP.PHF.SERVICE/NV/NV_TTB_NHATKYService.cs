using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV
{ 
    public interface INV_TTB_NHATKYService : IBaseService<PHF_TTB_NHATKY>
    {
        //Add function here
    }

    public class NV_TTB_NHATKYService : BaseService<PHF_TTB_NHATKY>, INV_TTB_NHATKYService
    {
        private readonly IRepositoryAsync<PHF_TTB_NHATKY> _repository;
        public NV_TTB_NHATKYService(IRepositoryAsync<PHF_TTB_NHATKY> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
