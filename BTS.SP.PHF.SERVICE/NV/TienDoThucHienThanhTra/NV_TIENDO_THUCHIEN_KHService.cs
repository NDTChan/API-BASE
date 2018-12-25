using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.TienDoThucHienThanhTra
{
    public interface INV_TIENDO_THUCHIEN_KHService : IBaseService<PHF_TIENDO_THUCHIEN_KH>
    {
        
    }
    public class NV_TIENDO_THUCHIEN_KHService : BaseService<PHF_TIENDO_THUCHIEN_KH>, INV_TIENDO_THUCHIEN_KHService
    {
        private readonly IRepositoryAsync<PHF_TIENDO_THUCHIEN_KH> _repository;
        public NV_TIENDO_THUCHIEN_KHService(IRepositoryAsync<PHF_TIENDO_THUCHIEN_KH> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
