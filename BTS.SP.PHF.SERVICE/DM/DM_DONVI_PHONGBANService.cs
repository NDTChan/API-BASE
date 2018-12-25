using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.SERVICE.SERVICES;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.DM
{
    public interface IDM_DONVI_PHONGBANService : IBaseService<PHF_DM_DONVI_PHONGBAN>
    {
        //Add function here
    }

    public class DM_DONVI_PHONGBANService : BaseService<PHF_DM_DONVI_PHONGBAN>, IDM_DONVI_PHONGBANService
    {
        private readonly IRepositoryAsync<PHF_DM_DONVI_PHONGBAN> _repository;
        public DM_DONVI_PHONGBANService(IRepositoryAsync<PHF_DM_DONVI_PHONGBAN> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
