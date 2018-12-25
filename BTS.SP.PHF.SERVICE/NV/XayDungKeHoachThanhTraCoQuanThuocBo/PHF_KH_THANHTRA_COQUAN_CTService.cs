using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraCoQuanThuocBo
{
    public interface IPHF_KH_THANHTRA_COQUAN_CTService : IBaseService<PHF_KH_THANHTRA_COQUAN_CT>
    {

    }
    public class PHF_KH_THANHTRA_COQUAN_CTService : BaseService<PHF_KH_THANHTRA_COQUAN_CT>, IPHF_KH_THANHTRA_COQUAN_CTService
    {
        private readonly IRepositoryAsync<PHF_KH_THANHTRA_COQUAN_CT> _repository;
        public PHF_KH_THANHTRA_COQUAN_CTService(IRepositoryAsync<PHF_KH_THANHTRA_COQUAN_CT> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
