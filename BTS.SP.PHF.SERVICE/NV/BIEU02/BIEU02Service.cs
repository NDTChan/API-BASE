using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.BIEU02
{
    public interface IBIEU02Service : IBaseService<PHF_BIEU02>
    {
    }
    public class BIEU02Service : BaseService<PHF_BIEU02>, IBIEU02Service
    {
        private readonly IRepositoryAsync<PHF_BIEU02> _repository;
        public BIEU02Service(IRepositoryAsync<PHF_BIEU02> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
