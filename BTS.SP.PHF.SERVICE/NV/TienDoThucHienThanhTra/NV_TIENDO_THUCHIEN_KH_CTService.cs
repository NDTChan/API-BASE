using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.NV.TienDoThucHienThanhTra
{
    public interface INV_TIENDO_THUCHIEN_KH_CTService : IBaseService<PHF_TIENDO_THUCHIEN_KH_CT>
    {
        //Add function here
    }
    public class NV_TIENDO_THUCHIEN_KH_CTService : BaseService<PHF_TIENDO_THUCHIEN_KH_CT>, INV_TIENDO_THUCHIEN_KH_CTService
    {
        private readonly IRepositoryAsync<PHF_TIENDO_THUCHIEN_KH_CT> _repository;
        public NV_TIENDO_THUCHIEN_KH_CTService(IRepositoryAsync<PHF_TIENDO_THUCHIEN_KH_CT> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
