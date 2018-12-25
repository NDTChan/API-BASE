using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.ThanhTraThuocBo
{
    public interface INV_XD_KH_TT_THUOC_BOService : IBaseService<PHF_XD_KH_TT_THUOC_BO>
    {
        
    }
    public class NV_XD_KH_TT_THUOC_BOService : BaseService<PHF_XD_KH_TT_THUOC_BO>, INV_XD_KH_TT_THUOC_BOService
    {
        private readonly IRepositoryAsync<PHF_XD_KH_TT_THUOC_BO> _repository;
        public NV_XD_KH_TT_THUOC_BOService(IRepositoryAsync<PHF_XD_KH_TT_THUOC_BO> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
