using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.BIEU05
{
    public interface IBIEU05Service : IBaseService<PHF_BIEU05>
    {
    }
    public class BIEU05Service : BaseService<PHF_BIEU05>, IBIEU05Service
    {
        private readonly IRepositoryAsync<PHF_BIEU05> _repository;
        public BIEU05Service(IRepositoryAsync<PHF_BIEU05> repository) : base(repository)
        {
            _repository = repository;
        }
    }
    
}
