using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.TheoDoiCanBo
{
    public interface IPHF_THEODOI_CANBO_CTService : IBaseService<PHF_THEODOI_CANBO_CT>
    {
        
    }
    public class PHF_THEODOI_CANBO_CTService : BaseService<PHF_THEODOI_CANBO_CT>, IPHF_THEODOI_CANBO_CTService
    {
        private readonly IRepositoryAsync<PHF_THEODOI_CANBO_CT> _repository;
        public PHF_THEODOI_CANBO_CTService(IRepositoryAsync<PHF_THEODOI_CANBO_CT> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
