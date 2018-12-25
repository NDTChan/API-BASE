using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
namespace BTS.SP.PHF.SERVICE.NV.ThuMucFile
{
    public interface ITHUMUCFILEService : IBaseService<PHF_THUMUC_FILE>
    {
        //Add function here
    }

    public class THUMUCFILEService : BaseService<PHF_THUMUC_FILE>, ITHUMUCFILEService
    {
        private readonly IRepositoryAsync<PHF_THUMUC_FILE> _repository;
        public THUMUCFILEService(IRepositoryAsync<PHF_THUMUC_FILE> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
