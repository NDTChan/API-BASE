using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCDN;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    public class NvBaoCaoTT_TCDNController : ApiController
    {
        public readonly INV_BM_FILE_TCDNService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public NvBaoCaoTT_TCDNController(INV_BM_FILE_TCDNService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
    }
}