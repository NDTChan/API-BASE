using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.ThanhTraThuocBo
{
    public interface INV_XD_KH_TT_THUOC_BO_CTService : IBaseService<PHF_XD_KH_TT_THUOC_BO_CT>
    {
        //Add function here
    }
    public class NV_XD_KH_TT_THUOC_BO_CTService : BaseService<PHF_XD_KH_TT_THUOC_BO_CT>, INV_XD_KH_TT_THUOC_BO_CTService
    {
        private readonly IRepositoryAsync<PHF_XD_KH_TT_THUOC_BO_CT> _repository;
        public NV_XD_KH_TT_THUOC_BO_CTService(IRepositoryAsync<PHF_XD_KH_TT_THUOC_BO_CT> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
