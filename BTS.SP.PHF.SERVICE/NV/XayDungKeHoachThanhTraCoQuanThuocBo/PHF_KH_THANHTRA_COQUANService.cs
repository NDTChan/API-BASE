using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraCoQuanThuocBo
{
    public interface IPHF_KH_THANHTRA_COQUANService : IBaseService<PHF_KH_THANHTRA_COQUAN>
    {
        
    }
    public class PHF_KH_THANHTRA_COQUANService : BaseService<PHF_KH_THANHTRA_COQUAN>, IPHF_KH_THANHTRA_COQUANService
    {
        private readonly IRepositoryAsync<PHF_KH_THANHTRA_COQUAN> _repository; 
        public PHF_KH_THANHTRA_COQUANService(IRepositoryAsync<PHF_KH_THANHTRA_COQUAN> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
