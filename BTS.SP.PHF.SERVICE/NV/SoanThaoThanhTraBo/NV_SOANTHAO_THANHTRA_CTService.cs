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
    public interface INV_SOANTHAO_THANHTRA_CTService : IBaseService<PHF_SOANTHAO_THANHTRA_CT>
    {
        //Add function here
    }
    public class NV_SOANTHAO_THANHTRA_CTService : BaseService<PHF_SOANTHAO_THANHTRA_CT>, INV_SOANTHAO_THANHTRA_CTService
    {
        private readonly IRepositoryAsync<PHF_SOANTHAO_THANHTRA_CT> _repository;
        public NV_SOANTHAO_THANHTRA_CTService(IRepositoryAsync<PHF_SOANTHAO_THANHTRA_CT> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
