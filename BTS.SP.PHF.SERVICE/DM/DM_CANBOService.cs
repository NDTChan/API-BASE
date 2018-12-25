
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.DM
{
    public interface IDM_CANBOService : IBaseService<PHF_DM_CANBO>
    {
        //Add function here
    }

    public class DM_CANBOService : BaseService<PHF_DM_CANBO>, IDM_CANBOService
    {
        private readonly IRepositoryAsync<PHF_DM_CANBO> _repository;
        public DM_CANBOService(IRepositoryAsync<PHF_DM_CANBO> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
