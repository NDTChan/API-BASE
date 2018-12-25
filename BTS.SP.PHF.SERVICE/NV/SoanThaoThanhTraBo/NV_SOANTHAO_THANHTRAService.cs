using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.SoanThaoNoiDungThanhTraBo
{
    public interface INV_SOANTHAO_THANHTRAService : IBaseService<PHF_SOANTHAO_THANHTRA>
    {

    }
    public class NV_SOANTHAO_THANHTRAService : BaseService<PHF_SOANTHAO_THANHTRA>, INV_SOANTHAO_THANHTRAService
    {
        private readonly IRepositoryAsync<PHF_SOANTHAO_THANHTRA> _repository;
        public NV_SOANTHAO_THANHTRAService(IRepositoryAsync<PHF_SOANTHAO_THANHTRA> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
