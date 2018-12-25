using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraBo
{
    public interface INV_XD_KH_THANHTRA_BO_CHITIETService : IBaseService<PHF_XD_KH_THANHTRA_BO_CHITIET>
    {
        //Add function here
    }
    public class NV_XD_KH_THANHTRA_BO_CHITIETService : BaseService<PHF_XD_KH_THANHTRA_BO_CHITIET>, INV_XD_KH_THANHTRA_BO_CHITIETService
    {
        private readonly IRepositoryAsync<PHF_XD_KH_THANHTRA_BO_CHITIET> _repository;
        public NV_XD_KH_THANHTRA_BO_CHITIETService(IRepositoryAsync<PHF_XD_KH_THANHTRA_BO_CHITIET> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
