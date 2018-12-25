using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.TheoDoiCanBo
{
    public interface IPHF_THEODOI_CANBOService : IBaseService<PHF_THEODOI_CANBO>
    {

    }
    public class PHF_THEODOI_CANBOService : BaseService<PHF_THEODOI_CANBO>, IPHF_THEODOI_CANBOService
    {
        private readonly IRepositoryAsync<PHF_THEODOI_CANBO> _repository;
        public PHF_THEODOI_CANBOService(IRepositoryAsync<PHF_THEODOI_CANBO> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
