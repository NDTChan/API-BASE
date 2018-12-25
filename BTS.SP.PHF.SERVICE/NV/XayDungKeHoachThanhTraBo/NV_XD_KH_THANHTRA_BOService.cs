using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraBo
{
    public interface INV_XD_KH_THANHTRA_BOService : IBaseService<PHF_XD_KH_THANHTRA_BO>
    {
        
    }
    public class NV_XD_KH_THANHTRA_BOService: BaseService<PHF_XD_KH_THANHTRA_BO>, INV_XD_KH_THANHTRA_BOService
    {
        private readonly IRepositoryAsync<PHF_XD_KH_THANHTRA_BO> _repository;
        public NV_XD_KH_THANHTRA_BOService(IRepositoryAsync<PHF_XD_KH_THANHTRA_BO> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
