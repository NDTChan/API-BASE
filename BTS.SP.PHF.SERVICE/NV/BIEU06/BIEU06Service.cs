using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.BIEU06
{
    public interface IBIEU06Service : IBaseService<PHF_BIEU06>
    {
    }
    public class BIEU06Service : BaseService<PHF_BIEU06>, IBIEU06Service
    {
        private readonly IRepositoryAsync<PHF_BIEU06> _repository;
        public BIEU06Service(IRepositoryAsync<PHF_BIEU06> repository) : base(repository)
        {
            _repository = repository;
        }
    }
    
}
